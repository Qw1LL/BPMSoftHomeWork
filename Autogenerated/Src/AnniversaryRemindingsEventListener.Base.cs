namespace BPMSoft.Configuration
{

	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;
	using Quartz.Impl.Triggers;
	using Quartz;

	public class AnniversaryRemindingsEventListener : IAppEventListener
	{
		#region Constants: Private

		private const string JOB = "Job";
		private const string JOB_GROUP = "JobGroup";
		private const string TRIGGER = "Trigger";
		private const string DEF_CRON_TRIGGER = "0 0 3 * * ?";
		private const string PROCESS = "GenerateAnniversaryRemindings";
		private const string SYS_SETTING_CRON_TRIGGER = "GenerateRemindingsByCronTrigger";

		#endregion

		#region Fields: Private

		private string _cronTigger;
		private UserConnection _userConnection;

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get {
				return _userConnection;
			}
			set {
				if(_userConnection == null) {
					_userConnection = value;
				}
			}
		}

		#endregion

		#region Methods: Private

		private void InitializeData(AppEventContext context) {
			SetUserConnection(context);
			SetCronTrigger();
		}

		private void SetUserConnection(AppEventContext context) {
			var appConection = context.Application["AppConnection"] as AppConnection;
			UserConnection = appConection.SystemUserConnection;
		}

		private void SetCronTrigger() {
			_cronTigger = BPMSoft.Core.Configuration.SysSettings.GetValue<string>(UserConnection,
				SYS_SETTING_CRON_TRIGGER, DEF_CRON_TRIGGER);
		}

		private string GetProcessJobName() {
			return String.Concat(PROCESS, JOB);
		}

		private string GetProcessJobGroupName() {
			return String.Concat(PROCESS, JOB_GROUP);
		}

		private string GetProcessTriggerName() {
			return String.Concat(PROCESS, TRIGGER);
		}

		#endregion

		#region Implement: IAppEventListener

		public void OnAppStart(AppEventContext context) {
			InitializeData(context);
			string processJob = GetProcessJobName();
			string processJobGroup = GetProcessJobGroupName();
			if (!AppScheduler.DoesJobExist(processJob, processJobGroup)) {
				string processTrigger = GetProcessTriggerName();
				IJobDetail job = AppScheduler.CreateProcessJob(processJob, processJobGroup, PROCESS,
					UserConnection.Workspace.Name, UserConnection.CurrentUser.Name, null, true);
				ITrigger trigger = new CronTriggerImpl(processTrigger, processJobGroup, _cronTigger);
				AppScheduler.Instance.ScheduleJob(job, trigger);
			}
		}

		public void OnAppEnd(AppEventContext context) {
			return;
		}

		public void OnSessionStart(AppEventContext context) {
			return;
		}

		public void OnSessionEnd(AppEventContext context) {
			return;
		}

		#endregion

	}
}

