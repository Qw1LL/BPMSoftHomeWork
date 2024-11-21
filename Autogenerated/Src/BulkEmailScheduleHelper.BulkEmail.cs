namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using Quartz;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Scheduler;

	/// <summary>
	/// Helper class to work with scheduled mailings.
	/// </summary>
	public class BulkEmailScheduleHelper
	{
		#region Consts: Private

		private const string JobGroupName = "Mailing";

		private const string SendProcessName = "SendBulkEmailProcess";

		private const int TriggerEmailStartDateShift = 1;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="applicationUrl">External address of the BPMCRM application.</param>
		public BulkEmailScheduleHelper(UserConnection userConnection, string applicationUrl) {
			UserConnection = userConnection;
			ApplicationUrl = applicationUrl;
		}

		#endregion

		#region Properties: Private

		private UserConnection UserConnection {
			get;
			set;
		}

		private string ApplicationUrl {
			get;
			set;
		}

		#endregion

		#region Methods: Private

		private string GetJobName(Guid entityId) {
			return "SendBulkEmail_" + entityId.ToString().Replace("-", "_");
		}

		private string GetJobExecutorName() {
			string jobExecutorName = UserConnection.CurrentUser.Name;
			if (UserConnection.CurrentUser.Id != BaseConsts.SystemUserId) {
				var selectQuery = new Select(UserConnection)
					.Column("Name")
					.From("SysAdminUnit")
					.Where("Id")
				.IsEqual(Column.Parameter(BaseConsts.SystemUserId)) as Select;
				using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
					using (IDataReader reader = selectQuery.ExecuteReader(dbExecutor)) {
						if (reader.Read()) {
							jobExecutorName = reader.GetColumnValue<string>("Name");
						}
					}
				}
			}
			return jobExecutorName;
		}

		private void ScheduleImmediateJob(string jobName, Guid entityId) {
			string jobExecutorName = GetJobExecutorName();
			Dictionary<string, object> parameters = new Dictionary<string, object>();
			parameters.Add("ApplicationUrl", ApplicationUrl);
			parameters.Add("BulkEmailId", entityId.ToString());
			AppScheduler.ScheduleImmediateProcessJob(jobName, JobGroupName, SendProcessName,
				UserConnection.Workspace.Name, jobExecutorName, parameters);
		}

		private void ShiftTriggerEmailStartDate(Guid bulkEmailId, int daysCount) {
			var parameters = new KeyValuePair<string, object>[] {
				new KeyValuePair<string, object>("RecordId", bulkEmailId),
				new KeyValuePair<string, object>("DaysCount", daysCount)
			};
			MailingDbUtilities.ExecuteStoredProcedure(UserConnection, "tsp_ShiftTriggerEmailStartDate", parameters);
		}

		private IEnumerable<Guid> GetBulkEmailsFromSendQueue() {
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "VwBulkEmailSendWaiting");
			esq.JoinRightState = BPMSoft.Core.DB.QueryJoinRightLevel.Disabled;
			string primaryColumnName = esq.AddColumn("Id").Name;
			EntityCollection entities = esq.GetEntityCollection(UserConnection);
			List<Guid> resultCollection = new List<Guid>();
			foreach (Entity entity in entities) {
				Guid entityId = entity.GetTypedColumnValue<Guid>(primaryColumnName);
				resultCollection.Add(entityId);
			}
			return resultCollection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules bulk email from send queue to sent.
		/// </summary>
		public void ScheduleBulkEmailsFromSendQueue() {
			IEnumerable<Guid> bulkEmailIds = GetBulkEmailsFromSendQueue();
			foreach (Guid entityId in bulkEmailIds) {
				string jobName = GetJobName(entityId);
				IJobDetail jobDetail = MailingSchedulerUtilities.FindJob(jobName, JobGroupName);
				if (jobDetail != null) {
					continue;
				}
				ShiftTriggerEmailStartDate(entityId, TriggerEmailStartDateShift);
				ScheduleImmediateJob(jobName, entityId);
			}
		}

		#endregion
	}
}
