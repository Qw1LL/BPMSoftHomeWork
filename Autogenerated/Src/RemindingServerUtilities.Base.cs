namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Text;
	using System.Data;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Process;
	using BPMSoft.Common;
	using BPMSoft.Core.DB;

	#region Class: RemindingServerUtilities

	/// <summary>
	/// ######## ######### ###### ### ###### # ######### Exchange Server.
	/// </summary>
	public static class RemindingServerUtilities
	{
		#region Methods: Public

		/// <summary>
		/// Returns instance of reminding.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="subject">Caption of reminding.</param>
		/// <param name="description">Description of reminding.</param>
		/// <param name="overrideReminding">Sign to override existing reminding.</param>
		/// <returns>Instance of reminding.</returns>
		public static Entity GetRemindingByProcess(UserConnection userConnection, string processName, string subject,
				string description = null, bool overrideReminding = false) {
			ProcessSchema processSchema = userConnection.ProcessSchemaManager.FindInstanceByName(processName);
			EntitySchema processLogSchema = userConnection.EntitySchemaManager.FindInstanceByName("VwSysProcessLog");
			Guid processLogRecordId = GetProcessLogRecordId(userConnection, processSchema);
			if (processLogRecordId == Guid.Empty) {
				return null;
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
			return remindingEntity;
		}

		/// <summary>
		/// Creates instance of reminding.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="subject">Caption of reminding.</param>
		/// <param name="description">Description of reminding.</param>
		/// <param name="overrideReminding">Sign to override existing reminding.</param>
		public static void CreateRemindingByProcess(UserConnection userConnection, string processName, string subject,
				string description = null, bool overrideReminding = false) {
			Entity remindingEntity =
				GetRemindingByProcess(userConnection, processName, subject, description, overrideReminding);
			if (remindingEntity == null) {
				return;
			}
			remindingEntity.Save();
		}

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

	}

	#endregion

}

