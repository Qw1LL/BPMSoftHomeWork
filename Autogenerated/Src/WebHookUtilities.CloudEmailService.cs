namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Common.Json;
	using Core;
	using Core.DB;
	using Newtonsoft.Json;
	using Newtonsoft.Json.Linq;
	using CoreConf = BPMSoft.Core.Configuration;
	using HttpUtility = System.Web.HttpUtility;

	#region Class: WebHookUtilities

	public static class WebHookUtilities {

		#region Constants: Private

		private const string JsonTypeField = "Type";

		private const string WebHookTypeNamespace = "BPMSoft.Configuration";

		private const string ActualizeRecipientsMassMailingProcedureName = "tsp_ActualizeCESMassEmails";

		private const string UrlTrackIdParameterName = "bpmtrackid";

		private const string UrlReplicaMaskParameterName = "bpmreplica";

		#endregion

		#region Fields: Private

		private static readonly DateTime SqlMinDate = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);

		#endregion

		#region Methods: Private

		/// <summary>
		/// Returns name of the type represented by given JSON.
		/// </summary>
		/// <param name="webHookJson">Web hook body.</param>
		/// <returns>Name of the web hook class.</returns>
		private static Type GetWebHookType(string webHookJson) {
			JObject jsonData = Json.Deserialize(webHookJson) as JObject;
			if (jsonData == null) {
				return null;
			}
			var typeIndex = jsonData.Value<int>(JsonTypeField);
			var type = (StatisticEventType) typeIndex;
			return Type.GetType(WebHookTypeNamespace + "." + type);
		}

		/// <summary>
		/// Returns distinct list of web hooks for given type.
		/// </summary>
		/// <param name="type">Type of web hook.</param>
		/// <param name="webHookList">All web hooks.</param>
		/// <returns>Filtered web hooks for given type.</returns>
		[Obsolete("7.14.4|Use FilterWebHooksByType(Type type, Dictionary<Guid, IEnumerable<BaseWebHook>> webHookList)")]
		private static List<BaseWebHook> FilterWebHooksByType(Type type, List<BaseWebHook> webHookList) {
			IEnumerable<BaseWebHook> list = webHookList.Where(webHook => webHook.GetType() == type).ToList();
			try {
				List<BaseWebHook> lastWebHooks = list.GroupBy(webHook => webHook.GetGroupKey())
					.Select(group => group.OrderByDescending(x => x.EventDate).First()).ToList();
				return lastWebHooks;
			} catch (Exception e) {
				MailingUtilities.WebHookLog.ErrorFormat("[WebHookUtilities.FilterWebHooksByType]: {0}", e);
				throw;
			}
		}

		private static IEnumerable<KeyValuePair<IEnumerable<Guid>, BaseWebHook>> FilterWebHooksByType(Type type,
				Dictionary<Guid, IEnumerable<BaseWebHook>> webHookList) {
			var list = webHookList.Where(webHook => webHook.Value.All(w => w.GetType() == type));
			var fullWebHookMap =
				list.SelectMany(x => x.Value.Select(n => new KeyValuePair<Guid, BaseWebHook>(x.Key, n)));
			try {
				var lastWebHooks = fullWebHookMap.GroupBy(webHook => webHook.Value.GetGroupKey()).Select(group =>
					new KeyValuePair<IEnumerable<Guid>, BaseWebHook>(group.Select(id => id.Key),
						group.OrderByDescending(x => x.Value.EventDate).First().Value));
				return lastWebHooks;
			} catch (Exception e) {
				MailingUtilities.WebHookLog.ErrorFormat("[WebHookUtilities.FilterWebHooksByType]: {0}", e);
				throw;
			}
		}

		private static Select GetEmailForActualizationSelect(UserConnection userConnection,
				string bulkEmailJoinProperty, string mandrillMessageResponseJoinProperty) {
			var emailsIdsSelect = new Select(userConnection)
					.Column("be", "Id")
					.Column("be", "CategoryId")
				.From("BulkEmail").As("be")
				.InnerJoin("MandrillMessageResponse").As("mmr").On("be", bulkEmailJoinProperty)
				.IsEqual("mmr", mandrillMessageResponseJoinProperty)
				.Where("be", "ResponseProcessingCompleted").IsEqual(Column.Parameter(false))
				.And("be", "StatusId").In(
					Column.Parameter(MarketingConsts.BulkEmailStatusFinishedId),
					Column.Parameter(MarketingConsts.BulkEmailStatusStoppedId),
					Column.Parameter(MarketingConsts.BulkEmailStatusActiveId)) as Select;
			emailsIdsSelect.SpecifyNoLockHints();
			return emailsIdsSelect;
		}
		
		private static Select GetEmailForActualizationFromMandrillRecipientSelect(UserConnection userConnection,
			int statisticUpdatePeriod) {
			var oldEmailDate = DateTime.Today.AddDays(-statisticUpdatePeriod);
			var bulkEmailSelect = new Select(userConnection)
				.Column("be", "Id")
				.Column("be", "CategoryId")
				.From("BulkEmail").As("be")
				.Where("be", "CategoryId")
				.IsEqual(Column.Parameter(MailingConsts.MassmailingBulkEmailCategoryId))
				.And("be", "SendStartDate").IsLess(Column.Parameter(oldEmailDate))
				.And("be", "StatusId").In(
					Column.Parameter(MarketingConsts.BulkEmailStatusFinishedId),
					Column.Parameter(MarketingConsts.BulkEmailStatusStoppedId),
					Column.Parameter(MarketingConsts.BulkEmailStatusActiveId)) 
				 as Select;
			var mandrillRecipientSelect = new Select(userConnection)
				.Column(Column.Parameter(1))
				.From("MandrillRecipient").As("mr")
				.Where("mr", "BulkEmailRId").IsEqual("be", "RId") as Select;
			var emailsIdsSelect = bulkEmailSelect.And().Exists(mandrillRecipientSelect) as Select;
			emailsIdsSelect.SpecifyNoLockHints();
			return emailsIdsSelect;
		}

		private static Dictionary<Guid, Guid> GetEmailsForActualization(UserConnection userConnections,
			int statisticUpdatePeriod) {
			var bulkEmailRIds = new Dictionary<Guid, Guid>();
			var getByIdsSelect = GetEmailForActualizationSelect(userConnections, "Id", "BulkEmailId");
			var getByRIdsSelect = GetEmailForActualizationSelect(userConnections, "RId", "BulkEmailRId");
			var bulkEmailIds = GetEmailForActualizationFromMandrillRecipientSelect(userConnections, statisticUpdatePeriod);
			getByIdsSelect.Union(getByRIdsSelect).Union(bulkEmailIds);
			using (DBExecutor dbExecutor = userConnections.EnsureDBConnection()) {
				using (IDataReader reader = getByIdsSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						Guid id = userConnections.DBTypeConverter.DBValueToGuid(reader.GetValue(0));
						Guid categoryId = userConnections.DBTypeConverter.DBValueToGuid(reader.GetValue(1));
						bulkEmailRIds[id] = categoryId;
					}
				}
			}
			return bulkEmailRIds;
		}

		private static string RemoveExtraParametersFromUri(string hyperLink) {
			var preparedUrl = HttpUtility.UrlDecode(hyperLink);
			preparedUrl = BulkEmailUtmHelper.RemoveUtmFromUri(preparedUrl);
			return BulkEmailHyperlinkHelper.RemoveExtraParametersFromUri(preparedUrl);
		}

		private static Select BuildRIdSelect(UserConnection userConnection, Guid bulkEmailId, string preparedUrl) {
			var uriTrackingParams =
				BulkEmailUriHelper.GetParametersFromUri(preparedUrl, UrlTrackIdParameterName,
					UrlReplicaMaskParameterName);
			var rIdSelect = new Select(userConnection)
				.Column("RId")
				.From("BulkEmailHyperlink");
			if(uriTrackingParams.ContainsKey(UrlTrackIdParameterName) 
				&& int.TryParse(uriTrackingParams[UrlTrackIdParameterName], out int trackId)
				&& uriTrackingParams.ContainsKey(UrlReplicaMaskParameterName) 
				&& long.TryParse(uriTrackingParams[UrlReplicaMaskParameterName], out long replicaMask)) {
				rIdSelect = AppendWhereCloseByTrackingParams(bulkEmailId, trackId, replicaMask, rIdSelect);
			} else {
				rIdSelect = AppendWhereClauseByHash(bulkEmailId, preparedUrl, rIdSelect);
			}
			rIdSelect.SpecifyNoLockHints();
			return rIdSelect;
		}

		private static Select AppendWhereClauseByHash(Guid bulkEmailId, string preparedUrl, Select rIdSelect) {
			var urlHash = MailingUtilities.GetMD5HashGuid(preparedUrl.ToLower());
			rIdSelect = rIdSelect
				.Where("Hash").IsEqual(Column.Parameter(urlHash))
				.And("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId)) as Select;
			return rIdSelect;
		}

		private static Select AppendWhereCloseByTrackingParams(Guid bulkEmailId, int trackId, long replicaMask, Select rIdSelect) {
			rIdSelect = rIdSelect
				.Where("BpmTrackId").IsEqual(Column.Parameter(trackId))
				.And("BpmReplicaMask").IsEqual(Column.Parameter(replicaMask))
				.And("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId)) as Select;
			return rIdSelect;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns <see cref="BaseWebHook"/> instance from json.
		/// </summary>
		/// <param name="webHookJson">Source json.</param>
		/// <returns>Deserialized <see cref="BaseWebHook"/>.</returns>
		public static BaseWebHook DeserializeWebHook(string webHookJson) {
			try {
				Type webHookType = GetWebHookType(webHookJson);
				return JsonConvert.DeserializeObject(webHookJson, webHookType) as BaseWebHook;
			} catch (Exception e) {
				MailingUtilities.WebHookLog.ErrorFormat("[WebHookUtilities.DeserializeWebHook]: {0}", e);
				throw;
			}
		}

		/// <summary>
		/// Returns hyperlink identifier.
		/// </summary>
		/// <param name="userConnection">Instance of user conection.</param>
		/// <param name="hyperLink">Date time value.</param>
		/// <param name="bulkEmailId">Bulk email unique identifier.</param>
		/// <returns>Hyperlink identifier.</returns>
		public static int GetHyperLinkRId(UserConnection userConnection, string hyperLink, Guid bulkEmailId) {
			var preparedUrl = RemoveExtraParametersFromUri(hyperLink);
			var rIdSelect = BuildRIdSelect(userConnection, bulkEmailId, preparedUrl);
			var hyperLinkRId = rIdSelect.ExecuteScalar<int>();
			return hyperLinkRId;
		}

		/// <summary>
		/// Gets unix epoch time.
		/// </summary>
		/// <param name="eventDate">Date time value.</param>
		/// <returns>Unix epoch time.</returns>
		public static long GetEpochTime(DateTime eventDate) {
			DateTime unixStart = DateTime.SpecifyKind(new DateTime(1970, 1, 1), DateTimeKind.Utc);
			return (long)Math.Floor((eventDate - unixStart).TotalSeconds);
		}

		/// <summary>
		/// Returns safe sql date time value.
		/// </summary>
		/// <param name="dateTime">Date time value.</param>
		/// <returns>Safe sql date time value.</returns>
		public static DateTime GetSafeSqlDate(DateTime dateTime) {
			if (dateTime < SqlMinDate) {
				return SqlMinDate;
			}
			return dateTime;
		}

		/// <summary>
		/// Returns distinct list of web hooks.
		/// </summary>
		/// <param name="userConnection">Instance of user conection.</param>
		/// <param name="jArrayList">All selected web hooks.</param>
		/// <returns>Distinct list of web hooks.</returns>
		[Obsolete("7.14.4|Use GetLastWebHooks(Dictionary<Guid, IEnumerable<BaseWebHook>> webHookList)")]
		public static List<BaseWebHook> GetLastWebHooks(UserConnection userConnection, List<JArray> jArrayList) {
			IEnumerable<string> jsonList = jArrayList.SelectMany(jArray =>
				jArray.AsJEnumerable().Select(jToken => jToken.ToString()));
			List<BaseWebHook> webHookList = jsonList.Select(DeserializeWebHook).ToList();
			List<BaseWebHook> lastWebHooks = new List<BaseWebHook>();
			IEnumerable<Type> typesList = webHookList.Select(webhook => webhook.GetType()).Distinct();
			foreach (Type classType in typesList) {
				lastWebHooks.AddRange(FilterWebHooksByType(classType, webHookList));
			}
			return lastWebHooks;
		}

		/// <summary>
		/// Returns distinct list of web hooks.
		/// </summary>
		/// <param name="userConnection">Instance of user conection.</param>
		/// <param name="jArrayList">All selected web hooks.</param>
		/// <returns>Distinct list of web hooks.</returns>
		public static IEnumerable<KeyValuePair<IEnumerable<Guid>, BaseWebHook>> GetLastWebHooks(
			Dictionary<Guid, IEnumerable<BaseWebHook>> webHookList) {
			var lastWebHooks = new List<KeyValuePair<IEnumerable<Guid>, BaseWebHook>>();
			IEnumerable<Type> typesList =
				webHookList.SelectMany(webhook => webhook.Value.Select(x => x.GetType())).Distinct();
			foreach (Type classType in typesList) {
				lastWebHooks.AddRange(FilterWebHooksByType(classType, webHookList));
			}
			return lastWebHooks;
		}

		/// <summary>
		/// Filters webhooks with unsubscribe event.
		/// </summary>
		/// <param name="userConnection">Instance of user conection.</param>
		/// <param name="lastWebHooks">Collection of webhooks.</param>
		/// <returns>Filtered collection of webhooks.</returns>
		[Obsolete("7.14.4|Use FilterUnsubscribeWebHook(UserConnection userConnection, IEnumerable<KeyValuePair<IEnumerable<Guid>, BaseWebHook>> lastWebHooks)")]
		public static List<BaseWebHook> FilterUnsubscribeWebHook(UserConnection userConnection, 
				List<BaseWebHook> lastWebHooks) {
			var unsubscribeFromAllMailings = (bool)CoreConf.SysSettings.GetValue(userConnection, "UnsubscribeFromAllMailings");
			return !unsubscribeFromAllMailings
				? lastWebHooks.Where(webHook => !(webHook is Unsubscribe)).ToList()
				: lastWebHooks;
		}

		/// <summary>
		/// Filters webhooks with unsubscribe event.
		/// </summary>
		/// <param name="userConnection">Instance of user conection.</param>
		/// <param name="lastWebHooks">Collection of webhooks.</param>
		/// <returns>Filtered collection of webhooks.</returns>
		public static IEnumerable<KeyValuePair<IEnumerable<Guid>, BaseWebHook>> FilterUnsubscribeWebHook(UserConnection userConnection,
			IEnumerable<KeyValuePair<IEnumerable<Guid>, BaseWebHook>> lastWebHooks) {
			var unsubscribeFromAllMailings = (bool)CoreConf.SysSettings.GetValue(userConnection,
				"UnsubscribeFromAllMailings");
			return !unsubscribeFromAllMailings
				? lastWebHooks.Where(webHook => !(webHook.Value is Unsubscribe))
				: lastWebHooks;
		}

		/// <summary>
		/// Actualize email recipients.
		/// </summary>
		/// <param name="userConnection">Instance of user conection.</param>
		public static void ActualizeMailingRecipients(UserConnection userConnection) {
			var statisticUpdatePeriod = (int)CoreConf.SysSettings.GetValue(userConnection,
			 "MailingStatisticUpdatePeriod");
			var packageSizeForTransferAudienceToBulkEmailTarget = CoreConf.SysSettings.GetValue<int>(userConnection,
			 "MandrillWebHookProcessingPackageCount", 1000);
			Dictionary<Guid, Guid> emails = GetEmailsForActualization(userConnection, statisticUpdatePeriod);
			foreach(KeyValuePair<Guid, Guid> email in emails) {
				var storedProcedure = new StoredProcedure(userConnection, ActualizeRecipientsMassMailingProcedureName);
				storedProcedure.WithParameter(email.Key);
				storedProcedure.WithParameter(statisticUpdatePeriod);
				storedProcedure.WithParameter(packageSizeForTransferAudienceToBulkEmailTarget);
				using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
					dbExecutor.CommandTimeout = 1800;
					storedProcedure.Execute(dbExecutor);
				}
			}
		}

		#endregion

	}
	
	#endregion

}
