namespace BPMSoft.Configuration
{

	using System;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;
	using Quartz.Impl.Triggers;
	using Quartz;

	public class ActualizeCertificatesEventListener : AppEventListenerBase
	{
		#region Constants: Private

		private const string JOB_GROUP = "JobGroup";
		private const string TRIGGER = "Trigger";
		private const string DEF_CRON_TRIGGER = "0 0 4 ? * *";
		private const string CLASS_NAME = "CertificatesActualization";
		private const string SYS_SETTING_CRON_TRIGGER = "ActualizeCertificatesByCronTrigger";

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


		private string GetProcessJobGroupName() {
			return String.Concat(CLASS_NAME, JOB_GROUP);
		}

		private string GetProcessTriggerName() {
			return String.Concat(CLASS_NAME, TRIGGER);
		}

		#endregion

		#region Methods : Public

		/// <summary>
		/// Creates and schedules a job for certificates actualization.
		/// </summary>
		/// <param name="context">Execution context.</param>
		public override void OnAppStart(AppEventContext context) {
			InitializeData(context);
			string processJobGroup = GetProcessJobGroupName();
			string processTrigger = GetProcessTriggerName();
			IJobDetail job = AppScheduler.CreateClassJob<CertificatesActualizationJob>(CLASS_NAME, processJobGroup,
				UserConnection);
			ITrigger trigger = new CronTriggerImpl(processTrigger, processJobGroup, _cronTigger);
			if (!AppScheduler.DoesJobExist(CLASS_NAME, processJobGroup)) {
				AppScheduler.Instance.ScheduleJob(job, trigger); 
			}

		}

		#endregion

	}
}



