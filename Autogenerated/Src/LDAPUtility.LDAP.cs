namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using global::Common.Logging;
	using System.Data;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;
	using System.Text;

	#region Class: LDAPUtility

	/// <summary>
	/// ######## ######### ###### ### ###### # ######### LDAP.
	/// </summary>
	public static class LDAPUtility
	{

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("LDAP");

		#endregion

		#region Methods: Private

		private static Guid GetProcessLogRecordId(UserConnection userConnection, ProcessSchema processSchema) {
			Guid recorId = Guid.Empty;
			var subSelect = new Select(userConnection)
							.Column("SPS", "Id")
							.From("SysProcessStatus").As("SPS")
							.Where("SPS", "Id").IsEqual("SPL", "StatusId")
							.And("SPS", "Value").IsEqual(Column.Parameter(1));
			Select select = new Select(userConnection).Top(1)
							.Column("SPL", "Id").As("RecordId")
							.From("SysProcessLog").As("SPL")
							.Where("SPL", "SysWorkspaceId").IsEqual(Column.Parameter(userConnection.Workspace.Id))
							.And("SPL", "OwnerId").IsEqual(Column.Parameter(userConnection.CurrentUser.ContactId))
							.And("SPL", "Name").IsEqual(Column.Parameter(processSchema.Caption.ToString()))
							.And().Exists(subSelect)
							.OrderBy(OrderDirectionStrict.Descending, "SPL", "CreatedOn") as Select;
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					if (reader.Read()) {
						recorId = reader.GetColumnValue<Guid>("RecordId");
					}
				}
			}
			return recorId;
		}

		private static string GetRemindingHash(Dictionary<string, object> dictionary) {
			var str = new StringBuilder();
			foreach (object value in dictionary.Values) {
				str.Append(value);
			}
			return FileUtilities.GetMD5Hash(Encoding.Unicode.GetBytes(str.ToString()));
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// ####### ########### ############ ## ########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		/// <param name="processName">### ########.</param>
		/// <param name="subject">######### ###########.</param>
		/// <param name="description">######## ###########.</param>
		/// <param name="overrideReminding">#######, ############## ## ###########.</param>
		public static void CreateRemindingByProcess(UserConnection userConnection, string processName, string subject,
				string description = null, bool overrideReminding = false) {
			ProcessSchema processSchema = userConnection.ProcessSchemaManager.FindInstanceByName(processName);
			EntitySchema processLogSchema = userConnection.EntitySchemaManager.FindInstanceByName("SysProcessLog");
			Guid processLogRecordId = GetProcessLogRecordId(userConnection, processSchema);
			if (processLogRecordId == Guid.Empty) {
				_log.ErrorFormat("Error occurred while creating reminder by Process: {0}. Error details: ProcessLog record not found.",
					processName);
				return;
			}
			Entity remindingEntity = userConnection.EntitySchemaManager.GetInstanceByName("Reminding")
				.CreateEntity(userConnection);
			var condition = new Dictionary<string, object> {
				{
					"Author", userConnection.CurrentUser.ContactId
				}, {
					"Contact", userConnection.CurrentUser.ContactId
				}, {
					"Source", RemindingConsts.RemindingSourceAuthorId
				}, {
					"SubjectCaption", subject
				}, {
					"SysEntitySchema", processSchema.UId
				},
			};
			string hash = GetRemindingHash(condition);
			if (!string.IsNullOrEmpty(description)) {
				subject = string.Concat(subject, " ", description);
			}
			if (!overrideReminding ||
					!remindingEntity.FetchFromDB(new Dictionary<string, object> { { "Hash", hash } }, false)) {
				remindingEntity.SetDefColumnValues();
			}
			remindingEntity.SetColumnValue("AuthorId", userConnection.CurrentUser.ContactId);
			remindingEntity.SetColumnValue("ContactId", userConnection.CurrentUser.ContactId);
			remindingEntity.SetColumnValue("SourceId", RemindingConsts.RemindingSourceAuthorId);
			remindingEntity.SetColumnValue("RemindTime", userConnection.CurrentUser.GetCurrentDateTime());
			remindingEntity.SetColumnValue("Description", description);
			remindingEntity.SetColumnValue("SubjectCaption", subject);
			remindingEntity.SetColumnValue("SysEntitySchemaId", processLogSchema.UId);
			remindingEntity.SetColumnValue("SubjectId", processLogRecordId);
			remindingEntity.SetColumnValue("Hash", hash);
			remindingEntity.Save();
		}

		#endregion
	}

	#endregion
}
