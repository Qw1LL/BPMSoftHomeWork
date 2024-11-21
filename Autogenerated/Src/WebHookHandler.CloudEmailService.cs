namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Linq;
	using Core;
	using Core.DB;
	using Newtonsoft.Json.Linq;

	#region Class: WebHookHandler

	/// <summary>
	/// Provides methods to process web hooks from CES.
	/// </summary>
	public class WebHookHandler
	{

		#region Constants: Private

		private const int WebHookBatchMinSize = 1;

		private const int WebHookBatchMaxSize = 1000;

		private readonly UserConnection _userConnection;

		private const int MaxIterationsCount = 10;

		#endregion

		#region Costructors: Public

		/// <summary>
		/// Initializes dictionary of all handlers for web hook types.
		/// </summary>
		public WebHookHandler(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private DateTime? DoNotParseWebhooksFrom {
			get {
				return (DateTime?)BPMSoft.Core.Configuration.SysSettings.GetValue(
					_userConnection, "StopHandleWebHookProcessAt");
			}
		}

		private DateTime? DoNotParseWebhooksTo {
			get {
				return (DateTime?)BPMSoft.Core.Configuration.SysSettings.GetValue(
					_userConnection, "StartHandleWebHookProcessAt");
			}
		}

		#endregion

		#region Methods: Private

		private Select GetWebHookBatchSelect() {
			var webHookBatchSize = (int) BPMSoft.Core.Configuration.SysSettings.GetValue(_userConnection,
				"MandrillWebHookProcessingPackageCount");
			if (webHookBatchSize < WebHookBatchMinSize) {
				webHookBatchSize = WebHookBatchMinSize;
			}
			if (webHookBatchSize > WebHookBatchMaxSize) {
				webHookBatchSize = WebHookBatchMaxSize;
			}
			var webhookSelect = new Select(_userConnection)
			.Top(webHookBatchSize)
			.Column("RawWebHooks", "JsonData")
			.Column("RawWebHooks", "Id")
			.From(GetWebhookIdsSelect(StatisticEventType.EmailStatistics)
			.Union(GetWebhookIdsSelect(StatisticEventType.Unsubscribe))
			.Union(GetWebhookIdsSelect(null)) as Select).As("u")
			.LeftOuterJoin("RawWebHooks").On("u","Id").IsEqual("RawWebHooks", "Id") as Select;
			return webhookSelect;
		}

		private Select GetWebhookIdsSelect(StatisticEventType? type) {
			var query = new Select(_userConnection)
				.Column("Id")
				.From("RawWebHooks")
				.Where("Failed").IsEqual(Column.Parameter(false));
			if (type != null) {
				query = query.And("Type").IsEqual(Column.Parameter((int)type));
			}
			return query as Select;
		}

		private void DeleteWebHooks(IEnumerable<Guid> idList) {
			new Delete(_userConnection)
				.From("RawWebHooks")
				.Where("Id")
				.In(Column.Parameters(idList)).Execute();
		}

		private void SetWebHooksFailed(List<Guid> idList) {
			new Update(_userConnection, "RawWebHooks")
				.Set("Failed", Column.Const(true))
				.Where("Id").In(Column.Parameters(idList)).Execute();
		}

		private IEnumerable<Guid> ProcessWebHooks(Dictionary<Guid, IEnumerable<BaseWebHook>> webHooks) {
			var lastWebHooks = WebHookUtilities.GetLastWebHooks(webHooks);
			var filteredWebhooks = WebHookUtilities.FilterUnsubscribeWebHook(_userConnection, lastWebHooks);
			var failedWebhooksBatch = new List<Guid>();
			using (DBExecutor dbExecutor = _userConnection.EnsureDBConnection()) {
				foreach (var webHook in filteredWebhooks) {
					var result = webHook.Value.TryHandleWebHook(dbExecutor, _userConnection);
					if (!result) {
						failedWebhooksBatch.AddRange(webHook.Key);
					}
				}
			}
			var processedWebHooksId = filteredWebhooks.SelectMany(x => x.Key)
				.Where(x => !failedWebhooksBatch.Contains(x));
			var filteredUnsubWebhooks = lastWebHooks.Except(filteredWebhooks).SelectMany(x => x.Key);
			processedWebHooksId = processedWebHooksId.Concat(filteredUnsubWebhooks);
			if (processedWebHooksId.Any()) {
				DeleteWebHooks(processedWebHooksId.Distinct());
			}
			return failedWebhooksBatch;
		}

		private int GetNumberOfPackagesForActualizingAudience() {
			return (int)BPMSoft.Core.Configuration.SysSettings.GetValue(_userConnection,
				"NumberOfPackagesForActualizingAudienceOfBulkEmail");
		}

		/// <summary>
		/// Parses the web hook.
		/// </summary>
		/// <param name="data">The web hook data.</param>
		/// <returns>The web hook.</returns>
		private JArray ParseWebHook(byte[] data) {
			var webhook = new JArray();
			if (data == null) {
				return webhook;
			}
			var stream = new MemoryStream(data);
			try {
				string jsonString = MailingUtilities.DecompressToString(stream);
				webhook = JArray.Parse(jsonString);
			} catch (Exception e) {
				webhook = null;
				MailingUtilities.WebHookLog.ErrorFormat("[WebHookHandler.WebHookLog]", e);
			}
			return webhook;
		}

		/// <summary>
		/// Returns next batch of web hooks to process.
		/// </summary>
		/// <param name="webHooks">List of web hook batches.</param>
		/// <param name="parsedIds">List of successful parsed ids from batches.</param>
		/// <param name="failedIds">List of not parsed ids from batches.</param>
		/// <returns>Number of read records.</returns>
		private int GetRawWebHooks(out Dictionary<Guid, JArray> webHooks, out List<Guid> failedIds) {
			var webhookSelect = GetWebHookBatchSelect();
			webHooks = new Dictionary<Guid, JArray>();
			failedIds = new List<Guid>();
			var counter = 0;
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var dr = webhookSelect.ExecuteReader(dbExecutor)) {
					while (dr.Read()) {
						var id = _userConnection.DBTypeConverter.DBValueToGuid(dr["Id"]);
						var data = dr["JsonData"] as byte[];
						JArray webhook = ParseWebHook(data);
						if (webhook != null) {
							webHooks[id] = webhook;
						} else {
							failedIds.Add(id);
						}
						counter++;
					}
				}
			}
			return counter;
		}

		private bool IsHandlePeriod() {
			if (DoNotParseWebhooksFrom == null ||
				DoNotParseWebhooksTo == null ||
				DoNotParseWebhooksFrom == DoNotParseWebhooksTo) {
				return true;
			}
			var now = _userConnection.CurrentUser.GetCurrentDateTime();
			var from = now.Date + DoNotParseWebhooksFrom.Value.TimeOfDay;
			var to = now.Date + DoNotParseWebhooksTo.Value.TimeOfDay;
			if (from > to) {
				if (now > from || now < to) {
					return false;
				}
			} else if (now > from && now < to) {
				return false;
			}
			return true;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Processes all web hooks from storage.
		/// </summary>
		public void ProcessWebHooks() {
			if (!IsHandlePeriod()) {
				return;
			}
			int actualizeAudiencePackagesNumber = GetNumberOfPackagesForActualizingAudience();
			int packagesCounter = 0;
			try {
				int numberOfReadPackages;
				List<Guid> failedIds;
				Dictionary<Guid, JArray> webHooks = new Dictionary<Guid, JArray>();
				int currentIteration = 0;
				while ((numberOfReadPackages = GetRawWebHooks(out webHooks, out failedIds)) > 0
						&& currentIteration < MaxIterationsCount) {
					packagesCounter += numberOfReadPackages;
					var webHookList = webHooks.ToDictionary(x => x.Key,
						x => x.Value.AsJEnumerable()
							.Select(jToken => WebHookUtilities.DeserializeWebHook(jToken.ToString())));
					if (webHookList.Any()) { 
						var failedIdsBatch = ProcessWebHooks(webHookList);
						failedIds.AddRange(failedIdsBatch); 
					}
					if (packagesCounter >= actualizeAudiencePackagesNumber) {
						packagesCounter = 0;
						WebHookUtilities.ActualizeMailingRecipients(_userConnection);
					}
					if (failedIds != null && failedIds.Any()) {
						SetWebHooksFailed(failedIds);
					}
					currentIteration++;
				}
				if (packagesCounter > 0) {
					WebHookUtilities.ActualizeMailingRecipients(_userConnection);
				}
			} catch (Exception e) {
				MailingUtilities.WebHookLog.ErrorFormat("[WebHookHandler.ProcessWebHooks]", e);
			}
		}

		#endregion

	}

	#endregion

}
