namespace BPMSoft.Configuration.RemindingService
{
	using System;
	using System.Collections.Generic;
	using System.ServiceModel;
	using System.ServiceModel.Web;
	using System.ServiceModel.Activation;
	using System.Web.SessionState;
	using BPMSoft.Core;
	using BPMSoft.Core.Configuration;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class RemindingService : BaseService, IReadOnlySessionState
	{

		#region Constants: Private

		private const int PERIOD_OF_EXECUTE_JOB = 1;

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		[Obsolete("7.16.2 | Method will be removed after delete feature 'NotificationsOnOneClassJob'.")]
		public void UpdateRemindingsCountersStart() {
			bool isTestFeatureEnabled = UserConnection.GetIsFeatureEnabled("TestNotificationOnWork");
			bool isNotificationV2FeatureEnabled = UserConnection.GetIsFeatureEnabled("NotificationV2");
			if (isTestFeatureEnabled || isNotificationV2FeatureEnabled) {
				return;
			}

			bool isFeatureEnabled = UserConnection.GetIsFeatureEnabled("NotificationsOnOneClassJob");
			var store = new NotificationStore();
			var helper = new ImplementedNotificationProviderHelper(UserConnection, store);
			if (isFeatureEnabled && !helper.IsUsedProviderNotImplementedNotification()) {
				return;
			}
			UpdateCountersStart();
		}

		#endregion

		#region Methods: Private

		private void UpdateCountersStart() {
			SysUserInfo currentUser = UserConnection.CurrentUser;
			string shedulerJobName = string.Format("RemindingCountersJob_{0}", currentUser.Id);
			string shedulerJobGroupName = "RemindingCountersGroup";
			string jobProcessName = "GetRemindingCounters";
			var jobParameters = new Dictionary<string, object> {
				{"TimeZoneId", currentUser.TimeZoneId}
			};
			AppScheduler.ScheduleMinutelyProcessJob(shedulerJobName, shedulerJobGroupName, jobProcessName,
				UserConnection.Workspace.Name, currentUser.Name, PERIOD_OF_EXECUTE_JOB, jobParameters);
		}

		#endregion
	}
}
