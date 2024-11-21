namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using Quartz;
	using Quartz.Impl.Matchers;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;
	using BPMSoft.Common;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Core.Configuration;
    using System;

    [Obsolete("7.16.2 | Class will be removed after delete feature 'NotificationsOnOneClassJob'.")]
	public class NotificationEventListenerObsolete : AppEventListenerBase
	{

		#region Methods: Private

		private void ScheduleNotificationsJob(UserConnection userConnection) {
			SysUserInfo currentUser = userConnection.CurrentUser;
			string jobGroupName = "NotificationsCountersGroup";
			string oldJobGroupName = "RemindingCountersGroup";
			DeleteOldJobs(oldJobGroupName);
			var jobParameters = new Dictionary<string, object> {
				{"TimeZoneId", currentUser.TimeZoneId},
				{"type", "All"},
				{"typeParameter", ""}
			};
			AppScheduler.ScheduleMinutelyJob<NotificationsJob>(jobGroupName, userConnection.Workspace.Name,
				currentUser.Name, GetNotificatonJobInterval(userConnection), jobParameters, true);
		}

		private int GetNotificatonJobInterval(UserConnection userConnection) {
			return Core.Configuration.SysSettings.GetValue(userConnection, "NotificatonJobInterval", 1);
		}

		private void DeleteOldJobs(string groupName) {
			IScheduler scheduler = AppScheduler.Instance;
			var groupMatcher = GroupMatcher<JobKey>.GroupContains(groupName);
			var jobKeys = scheduler.GetJobKeys(groupMatcher);
			foreach (JobKey jobKey in jobKeys) {
				scheduler.DeleteJob(jobKey);
			}
		}

		#endregion

		#region Members: IAppEventListener

		public override void OnAppStart(AppEventContext context) {
			context.CheckArgumentNull("context");
			var appConnection = context.Application["AppConnection"] as AppConnection;

			ScheduleNotificationsJob(appConnection.SystemUserConnection);
		}

		#endregion
	}
}

