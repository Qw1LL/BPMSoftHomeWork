namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Quartz;
	using Quartz.Impl.Triggers;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Scheduler;
	using CoreSysSettings = BPMSoft.Core.Configuration.SysSettings;

	#region Class: MailingSchedulerUtilities

	public static class MailingSchedulerUtilities {

		#region Fields: Private

		private static readonly string SystemUserSysSettingsCode = "SystemUser";
		private static readonly string CampaignBulkEmailJobNamePattern = "SendCampaignBulkEmail_{0}_Session_{1}";

		#endregion

		#region Fields: Public

		/// <summary>
		/// Business process name for emails sending.
		/// </summary>
		public static readonly string SendBulkEmailProcessName = "SendImmediatelyTriggeredSessionedEmailProcess";

		/// <summary>
		/// The name of job group.
		/// </summary>
		public static readonly string BulkEmailJobGroupName = "Mailing";

		#endregion

		#region Methods: Private

		private static string GetJobExecutorUserName(UserConnection userConnection) {
			var sysUserId = (Guid)CoreSysSettings.GetValue(userConnection, SystemUserSysSettingsCode);
			return userConnection.CurrentUser.Id == sysUserId 
				? userConnection.CurrentUser.Name 
				: GetUserNameById(userConnection, sysUserId);
		}
		
		private static string GetUserNameById(UserConnection userConnection, Guid sysUserId) {
			var selectQuery = new Select(userConnection).Column("Name").From("SysAdminUnit").Where("Id")
				.IsEqual(Column.Parameter(sysUserId)) as Select;
			return selectQuery.ExecuteScalar<string>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates scheduled job.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="periodInMinutes">The frequency of task startups in minutes.</param>
		/// <param name="parameters">Process parameters.</param>
		/// <param name="isSystemUser">Execute job by the systems user.</param>
		/// <param name="useMisfireInstructionFireOnceNow">Execute job immediately when it misfired.</param>
		public static void CreateJob(UserConnection userConnection, string jobName, string jobGroupName,
				string processName, int periodInMinutes, IDictionary<string, object> parameters = null,
				bool isSystemUser = false,
				bool useMisfireInstructionFireOnceNow = false) {
			IJobDetail jobDetail = FindJob(jobName, jobGroupName);
			if (jobDetail != null) {
				IList<ITrigger> triggers = AppScheduler.Instance.GetTriggersOfJob(jobDetail.Key);
				if (triggers.Any()) {
					var intervalTrigger = triggers.First() as ICalendarIntervalTrigger;
					if (periodInMinutes == 0 && intervalTrigger == null) {
						return;
					}
					if (intervalTrigger != null && periodInMinutes > 0
						&& periodInMinutes == intervalTrigger.RepeatInterval) {
						return;
					}
				}
			}
			string jobExecutorName = GetJobExecutorUserName(userConnection);
			if (periodInMinutes == 0) {
				AppScheduler.ScheduleImmediateProcessJob(jobName, jobGroupName, processName,
					userConnection.Workspace.Name, jobExecutorName, parameters, isSystemUser);
			} else {
				AppScheduler.ScheduleMinutelyProcessJob(jobName, jobGroupName, processName,
					userConnection.Workspace.Name, jobExecutorName, periodInMinutes, parameters,
					isSystemUser,
					useMisfireInstructionFireOnceNow);
			}
		}

		/// <summary>
		/// Searches for the task by the given parameters.
		/// </summary>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <returns>The job info.</returns>
		public static IJobDetail FindJob(string jobName, string jobGroupName) {
			var key = new JobKey(jobName, jobGroupName);
			IJobDetail jobDetail = AppScheduler.Instance.GetJobDetail(key);
			return jobDetail;
		}

		/// <summary>
		/// Creates the immediately job.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="parameters">Process parameters.</param>
		public static void CreateImmediatelyJob(UserConnection userConnection, string jobName, string jobGroupName, 
				string processName, IDictionary<string, object> parameters) {
			string jobExecutorName = GetJobExecutorUserName(userConnection);
			AppScheduler.ScheduleImmediateProcessJob(jobName, jobGroupName,
				processName, userConnection.Workspace.Name, jobExecutorName, parameters);
		}

		/// <summary>
		/// Creates the immediately job.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="parameters">Process parameters.</param>
		/// <param name="isSystemUser">Executes job with the system user rights.</param>
		public static void CreateImmediatelyJob(UserConnection userConnection, string jobName, string jobGroupName,
				string processName, IDictionary<string, object> parameters, bool isSystemUser) {
			string jobExecutorName = GetJobExecutorUserName(userConnection);
			AppScheduler.RemoveJob(jobName, jobGroupName);
			IJobDetail job = AppScheduler.CreateProcessJob(jobName, jobGroupName, processName,
				userConnection.Workspace.Name, jobExecutorName, parameters, isSystemUser);
			ITrigger trigger = new SimpleTriggerImpl(jobName + "Trigger", jobGroupName,
					DateTime.UtcNow, null, 0, TimeSpan.Zero) {
				MisfireInstruction = MisfireInstruction.IgnoreMisfirePolicy
			};
			AppScheduler.Instance.ScheduleJob(job, trigger);
		}

		/// <summary>
		/// Creates scheduled job by cron expression.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="cronExpression">Cron scheduling parameters.</param>>
		/// <param name="jobName">Name of the job.</param>
		/// <param name="jobGroupName">Name of the group.</param>
		/// <param name="processName">Name of the process.</param>
		/// <param name="parameters">Process parameters.</param>
		/// <param name="isSystemUser">Execute job by the systems user.</param>
		/// <param name="useMisfireInstructionFireOnceNow">Execute job immediately when it misfired.</param>
		public static void CreateCronJob(UserConnection userConnection, string cronExpression, string jobName, 
				string jobGroupName, string processName, IDictionary<string, object> parameters,
				bool isSystemUser = false, bool useMisfireInstructionFireOnceNow = false) {
			string jobExecutorName = GetJobExecutorUserName(userConnection);
			if (AppScheduler.DoesJobExist(jobName, jobGroupName)) {
				return;
			}
			var job = AppScheduler.CreateProcessJob(jobName, jobGroupName,
				processName, userConnection.Workspace.Name, jobExecutorName, parameters, isSystemUser);
			var trigger = new CronTriggerImpl(jobName + "Trigger",
				jobGroupName, cronExpression);
			trigger.TimeZone = TimeZoneInfo.Local;
			trigger.MisfireInstruction = useMisfireInstructionFireOnceNow
				? MisfireInstruction.CronTrigger.FireOnceNow
				: MisfireInstruction.SmartPolicy;
			AppScheduler.Instance.ScheduleJob(job, trigger);
		}

		/// <summary>
		/// Creates immediately job for the trigger emails.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="bulkEmailId">The Id of a bulk email.</param>
		/// <param name="sessionUId">The UId of a session for a bulk email.</param>
		public static void CreateCampaignBulkEmailJob(UserConnection userConnection, Guid bulkEmailId,
				Guid sessionUId) {
			var jobName = GetTriggerEmailJobName(bulkEmailId, sessionUId);
			var parameters = new Dictionary<string, object> {
				{ "BulkEmailId", bulkEmailId },
				{ "SessionUId", sessionUId },
				{ "ApplicationUrl", string.Empty }
			};
			CreateImmediatelyJob(userConnection, jobName, BulkEmailJobGroupName, SendBulkEmailProcessName,
				parameters, true);
		}

		/// <summary>
		/// Returns the name for the mailing job.
		/// </summary>
		/// <param name="bulkEmailId">The Id of a trigger email.</param>
		/// <param name="sessionUId">The UId of a session for a trigger email.</param>
		/// <returns>Generated name for the mailing job.</returns>
		public static string GetTriggerEmailJobName(Guid bulkEmailId, Guid sessionUId) {
			return string.Format(CampaignBulkEmailJobNamePattern, bulkEmailId, sessionUId);
		}

		#endregion

	}

	#endregion
}
