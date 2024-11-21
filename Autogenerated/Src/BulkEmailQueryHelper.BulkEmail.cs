namespace BPMSoft.Configuration {
	using System;
	using System.Data;
	using System.Collections.Generic;
	using System.Linq;
	using Quartz.Util;
	using BPMSoft.Configuration.CESModels;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	#region Class: BulkEmailQueryHelper

	public class BulkEmailQueryHelper {

		#region Methods: Private
		
		private Select GetBulkReplicasSenderEmailSelect(IEnumerable<Guid> bulkEmailIds, UserConnection userConnection) {
			var replicaSenderEmailSelect = new Select(userConnection)
				.Column(nameof(BulkEmailReplicaHeaders), nameof(BulkEmailReplicaHeaders.SenderEmail))
				.Column(nameof(BulkEmail), nameof(BulkEmail.ProviderName))
				.From(nameof(BulkEmailReplicaHeaders))
				.InnerJoin(nameof(DCReplica))
				.On(nameof(BulkEmailReplicaHeaders), nameof(BulkEmailReplicaHeaders.DCReplicaId))
				.IsEqual(nameof(DCReplica), nameof(DCReplica.Id))
				.InnerJoin(nameof(DCTemplate))
				.On(nameof(DCReplica), nameof(DCReplica.DCTemplateId))
				.IsEqual(nameof(DCTemplate), nameof(DCTemplate.Id))
				.InnerJoin(nameof(BulkEmail))
				.On(nameof(DCTemplate), nameof(DCTemplate.RecordId))
				.IsEqual(nameof(BulkEmail), nameof(BulkEmail.Id))
				.Where(nameof(BulkEmail), nameof(BulkEmail.Id))
				.In(Column.Parameters(bulkEmailIds)) as Select;
			return replicaSenderEmailSelect;
		}

		private Select GetBulkEmailsSenderEmailSelect(IEnumerable<Guid> bulkEmailIds, UserConnection userConnection) {
			var bulkEmailSenderEmailSelect = new Select(userConnection)
				.Column("SenderEmail")
				.Column("ProviderName")
				.From("BulkEmail")
				.Where(nameof(BulkEmail.Id)).In(Column.Parameters(bulkEmailIds)) as Select;
			return bulkEmailSenderEmailSelect;
		}

		private Select GetSenderEmailSelect(Guid bulkEmailId, UserConnection userConnection) {
			return GetSenderEmailsSelect(new []{ bulkEmailId }, userConnection);
		}

		private Select GetSenderEmailsSelect(IEnumerable<Guid> bulkEmailIds, UserConnection userConnection) {
			var bulkEmailSenderEmailSelect = GetBulkEmailsSenderEmailSelect(bulkEmailIds, userConnection);
			var replicaSenderEmailSelect = GetBulkReplicasSenderEmailSelect(bulkEmailIds, userConnection);
			var resultSelect = bulkEmailSenderEmailSelect.Union(replicaSenderEmailSelect) as Select;
			return resultSelect;
		}

		/// <summary>
		/// Returns query for RId of bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Query for RId of bulk email.</returns>
		private static Select GetBulkEmailRIdSelect(Guid bulkEmailId, UserConnection userConnection) {
			return new Select(userConnection)
				.Column("RId")
				.From("BulkEmail")
				.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Select;
		}

		/// <summary>
		/// Returns query for start date of bulk email.
		/// </summary>
		/// <param name="bulkEmailRId">RId of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Query for start date of bulk email.</returns>
		private static Select GetBulkEmailStartDateSelect(int bulkEmailRId, UserConnection userConnection) {
			return new Select(userConnection)
				.Column("StartDate")
				.From("BulkEmail")
				.Where("RId").IsEqual(Column.Parameter(bulkEmailRId)) as Select;
		}

		/// <summary>
		/// Returns query for count of sent messages of bulk email.
		/// </summary>
		/// <param name="bulkEmailRId">RId of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Query for count of sent messages of bulk email.</returns>
		private static Select GetBulkEmailSentMessageCountSelect(int bulkEmailRId, UserConnection userConnection) {
			return new Select(userConnection)
				.Column(Func.Count("Id"))
				.From("MandrillRecipient")
				.Where("IsSent").IsEqual(Column.Const(true))
				.And("BulkEmailRId").IsEqual(Column.Parameter(bulkEmailRId)) as Select;
		}

		/// <summary>
		/// Returns query for count of recipients in queue of bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Query for count of recipients in queue of bulk email.</returns>
		private static Select GetRecipientsInQueueCountSelect(Guid bulkEmailId, UserConnection userConnection) {
			var countSelect = new Select(userConnection)
				.Column(Func.Count("Id"))
				.From("VwBulkEmailAudience")
				.Where("BulkEmailId").IsEqual(Column.Parameter(bulkEmailId)) as Select;
			HintsHelper.SpecifyNoLockHints(countSelect, true);
			return countSelect;
		}

		/// <summary>
		/// Returns query for status of bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Query for status of bulk email.</returns>
		private static Select GetBulkEmailStatusSelect(Guid bulkEmailId, UserConnection userConnection) {
			return new Select(userConnection)
				.Column("StatusId")
			.From("BulkEmail")
			.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Select;
		}

		private static Select GetBulkEmailNameSelect(Guid bulkEmailId, UserConnection userConnection) {
			return new Select(userConnection)
				.Column("Name")
				.From("BulkEmail")
				.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Select;
		}

		/// <summary>
		/// Converts date to unix timestamp.
		/// </summary>
		/// <param name="dateTime">Date time to convert.</param>
		/// <returns>Unix timestamp.</returns>
		private static int ConvertDateTimeToTimestamp(DateTime dateTime) {
			return (Int32)(dateTime.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns RId of bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>RId of bulk email.</returns>
		public static int GetBulkEmailRId(Guid bulkEmailId, UserConnection userConnection) {
			var select = GetBulkEmailRIdSelect(bulkEmailId, userConnection);
			return select.ExecuteScalar<int>();
		}

		/// <summary>
		/// Returns start date of bulk email.
		/// </summary>
		/// <param name="bulkEmailRId">RId of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Start date of bulk email.</returns>
		public static int GetBulkEmailStartDate(int bulkEmailRId, UserConnection userConnection) {
			var select = GetBulkEmailStartDateSelect(bulkEmailRId, userConnection);
			var startDate = select.ExecuteScalar<DateTime>();
			return ConvertDateTimeToTimestamp(startDate);
		}

		/// <summary>
		/// Returns count of sent messages for bulk email.
		/// </summary>
		/// <param name="bulkEmailRId">RId of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Count of sent messages for bulk email.</returns>
		public static int GetBulkEmailSentMessageCount(int bulkEmailRId, UserConnection userConnection) {
			var select = GetBulkEmailSentMessageCountSelect(bulkEmailRId, userConnection);
			return select.ExecuteScalar<int>();
		}

		/// <summary>
		/// Returns count of recipients in queue of bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Count of recipients in queue of bulk email.</returns>
		public static int GetRecipientsInQueueCount(Guid bulkEmailId, UserConnection userConnection) {
			var countSelect = GetRecipientsInQueueCountSelect(bulkEmailId, userConnection);
			return countSelect.ExecuteScalar<int>();
		}

		/// <summary>
		/// Returns identifier of bulk email status.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Identifier of bulk email status.</returns>
		public static Guid GetBulkEmailStatus(Guid bulkEmailId, UserConnection userConnection) {
			var select = GetBulkEmailStatusSelect(bulkEmailId, userConnection);
			return select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Returns name of bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Identifier of bulk email status.</returns>
		public static string GetBulkEmailName(Guid bulkEmailId, UserConnection userConnection) {
			var select = GetBulkEmailNameSelect(bulkEmailId, userConnection);
			return select.ExecuteScalar<string>();
		}

		/// <summary>
		/// Returns email of sender of bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Email of bulk email sender.</returns>
		public string GetBulkEmailSenderEmail(Guid bulkEmailId, UserConnection userConnection) {
			var senderSelect = GetSenderEmailSelect(bulkEmailId, userConnection);
			return senderSelect.ExecuteScalar<string>();
		}

		/// <summary>
		/// Returns emails of sender of bulk email.
		/// </summary>
		/// <param name="bulkEmailIds">Identifiers of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Collection of the emails of bulk email sender.</returns>
		[Obsolete("7.18.3 | Use GetSenderEmailsWithProviderNames instead")]
		public List<string> GetBulkEmailsSenderEmail(IEnumerable<Guid> bulkEmailIds, UserConnection userConnection) {
			List<string> resultCollection = new List<string>();
			var sendersSelect = GetSenderEmailsSelect(bulkEmailIds, userConnection);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = sendersSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						resultCollection.Add(reader.GetString(0));
					}
				}
			}
			return resultCollection;
		}

		/// <summary>
		/// Gets the name of the provider.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="userConnection">The user connection.</param>
		/// <returns>The provider name.</returns>
		public static string GetProviderName(Guid bulkEmailId, UserConnection userConnection) {
			var select = new Select(userConnection)
				.Column("ProviderName")
				.From("BulkEmail")
				.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Select;
			return select?.ExecuteScalar<string>();
		}

		/// <summary>
		/// Returns emails of sender of bulk email.
		/// </summary>
		/// <param name="bulkEmailIds">Identifiers of bulk email.</param>
		/// <param name="userConnection">User connection instance.</param>
		/// <returns>Collection of the emails of bulk email sender with provider name.</returns>
		public List<ProviderSenderEmail> GetSenderEmailsWithProviderNames(IEnumerable<Guid> bulkEmailIds,
				UserConnection userConnection) {
			List<Tuple<string, string>> tupleCollection = new List<Tuple<string, string>>();
			List<ProviderSenderEmail> resultCollection = new List<ProviderSenderEmail>();
			var sendersSelect = GetSenderEmailsSelect(bulkEmailIds, userConnection);
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = sendersSelect.ExecuteReader(dbExecutor)) {
					while (reader.Read()) {
						tupleCollection.Add(new Tuple<string, string>(reader.GetString("SenderEmail"),
							reader.GetString("ProviderName")));
					}
				}
			}
			var groupedCollection = tupleCollection.GroupBy(x => x.Item2);
			foreach (var group in groupedCollection) {
				resultCollection.Add(new ProviderSenderEmail {
					ProviderName = group.Key,
					SenderEmails = group.Select(x => x.Item1).Distinct().ToList()
				});
			}
			return resultCollection;
		}

		/// <summary>
		/// Updates bulk email.
		/// </summary>
		/// <param name="bulkEmailId">Unique id of bulk email.</param>
		/// <param name="userConnection">User connection instatnce.</param>
		/// <param name="parameters">KeyValuePair of properties ti update and their values.</param>
		public static void UpdateBulkEmail(Guid bulkEmailId, UserConnection userConnection,
			params KeyValuePair<string, object>[] parameters) {
			if (!parameters.Any()) {
				return;
			}
			var update = new Update(userConnection, "BulkEmail");
			foreach (KeyValuePair<string, object> parameter in parameters) {
				var expressionParameter = parameter.Value as QueryColumnExpression;
				if (expressionParameter != null) {
					update.Set(parameter.Key, expressionParameter);
				} else {
					update.Set(parameter.Key, Column.Parameter(parameter.Value));
				}
			}
			update = update.Where("Id").IsEqual(Column.Parameter(bulkEmailId)) as Update;
			update.Execute();
		}

		/// <summary>
		/// Updates BulkEmail CommonErrorCount with 0 values.
		/// </summary>
		/// <param name="bulkEmailRId">Id of email.</param>
		/// <param name="userConnection">Instance of <see cref="UserConnection"/>.</param>
		public static void ResetBulkEmailCounters(int bulkEmailRId, UserConnection userConnection) {
			var bulkEmailUpdate = new Update(userConnection, "BulkEmail")
					.Set("CommonErrorCount", Column.Parameter(0))
					.Where("RId").IsEqual(Column.Parameter(bulkEmailRId)) as Update;
			bulkEmailUpdate.Execute();
		}

		#endregion
	}

	#endregion
}

