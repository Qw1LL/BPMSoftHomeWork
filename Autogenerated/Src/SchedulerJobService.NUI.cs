namespace BPMSoft.Configuration.SchedulerJobService
{
	using System;
	using System.ServiceModel;
	using System.ServiceModel.Activation;
	using System.ServiceModel.Web;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;

	[ServiceContract]
	[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Required)]
	public class SchedulerJobService : BaseService
	{

		#region Methods: Private

		private void CreateSyncJob(UserConnection userConnection, string jobName, string syncJobGroupName,
				string syncProcessName, int periodInMinutes, bool recreate, string schedulerName = null) {
			var scheduler = AppScheduler.GetSchedulerOrDefault(schedulerName);
			AppScheduler.RemoveJob(jobName, syncJobGroupName, scheduler);
			if (periodInMinutes < 0 || !recreate) {
				return;
			}
			AppScheduler.ScheduleMinutelyProcessJob(jobName, syncJobGroupName, syncProcessName,
				userConnection.Workspace.Name, userConnection.CurrentUser.Name, periodInMinutes, scheduler: scheduler);
		}

		private void CreateImmediateSyncJob(UserConnection userConnection, string jobName, string syncJobGroupName,
				string syncProcessName, string schedulerName = null) {
			var scheduler = AppScheduler.GetSchedulerOrDefault(schedulerName);
			AppScheduler.ScheduleImmediateProcessJob(jobName, syncJobGroupName, syncProcessName,
				userConnection.Workspace.Name, userConnection.CurrentUser.Name, scheduler: scheduler);
		}

		#endregion

		#region Methods: Public

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateSyncJob", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CreateSyncJob(string JobName, string SyncJobGroupName, string SyncProcessName, int periodInMinutes,
				bool recreate, string schedulerName = null) {
			CreateSyncJob(UserConnection, JobName, SyncJobGroupName, SyncProcessName, periodInMinutes, recreate,
				schedulerName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateSyncJobWithResponse", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public ConfigurationServiceResponse CreateSyncJobWithResponse(string JobName, string SyncJobGroupName,
				string SyncProcessName, int periodInMinutes, bool recreate, string schedulerName = null) {
			try {
				if (periodInMinutes == 0) {
					CreateImmediateSyncJob(UserConnection, JobName, SyncJobGroupName, SyncProcessName, schedulerName);
				} else {
					CreateSyncJob(UserConnection, JobName, SyncJobGroupName, SyncProcessName, periodInMinutes, recreate,
						schedulerName);
				}
				return new ConfigurationServiceResponse();
			} catch (Exception e) {
				return new ConfigurationServiceResponse { Exception = e};
			}
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateImmediateSyncJob", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CreateImmediateSyncJob(string jobName, string syncJobGroupName, string syncProcessName, 
				string schedulerName = null) {
			CreateImmediateSyncJob(UserConnection, jobName, syncJobGroupName, syncProcessName, schedulerName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CreateSyncJobByPeriodicity", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public void CreateSyncJobByPeriodicity(Guid id, string JobName, string SyncJobGroupName, string SyncProcessName,
			string SyncWorkspaceName, string SyncUserName, string schedulerName = null) {
			if (id.IsEmpty()) {
				return;
			}
			var periodicitySettingsUtilities = new PeriodicitySettingsUtilities(UserConnection, id);
			periodicitySettingsUtilities.CreateTrigger(JobName, SyncJobGroupName, SyncProcessName, SyncWorkspaceName,
				SyncUserName, schedulerName);
		}

		[OperationContract]
		[WebInvoke(Method = "POST", UriTemplate = "CheckIfJobExist", BodyStyle = WebMessageBodyStyle.Wrapped,
			RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
		public bool CheckIfJobExist(string JobName, string SyncJobGroupName, string schedulerName = null) {
			var scheduler = AppScheduler.GetSchedulerOrDefault(schedulerName);
			return AppScheduler.DoesJobExist(JobName, SyncJobGroupName, scheduler);
		}

		#endregion

	}
}
