namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using Quartz;
	using Quartz.Impl.Matchers;
	using Quartz.Impl.Triggers;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using BPMSoft.Web.Common;
	using BPMSoft.Common;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Core.Configuration;

	/// <summary>
	/// Actualize partner contact certificates.
	/// </summary>
	public class PrmCertifiedContactsActualizerEventListener : AppEventListenerBase
	{

		#region Fields: Private

		private readonly string _jobGroup = "PartnershipCertifiedContactsActualizerJobGroup";
		private readonly string _triggerName = "PartnershipCertifiedContactsActualizerJobTrigger";
		private readonly string _cronExpression = "0 0 5 * * ?";
		private readonly string _className = "PartnershipCertifiedContactsActualizerJob";


		private AppEventContext _appEventContext;
		private AppConnection _appConnection;
		private UserConnection _userConnection;

		#endregion

		#region Properties: Public

		public UserConnection UserConnection {
			get => _userConnection ?? (_userConnection = AppConnection.SystemUserConnection);
			set {
				value.CheckArgumentNull("UserConnection");
				_userConnection = value;
			}
		}

		public AppConnection AppConnection {
			get {
				if (_appConnection == null) {
					AppConnection = _appEventContext.Application["AppConnection"] as AppConnection;
				}
				return _appConnection;
			}
			set {
				value.CheckArgumentNull("AppConnection");
				_appConnection = value;
			}
		}

		#endregion

		#region Methods: Private

		private void ScheduleCronTriggerJob() {
			IJobDetail job = AppScheduler.CreateClassJob<PartnershipCertifiedContactsActualizerJob>(_className, _jobGroup, UserConnection);
			ITrigger trigger = new CronTriggerImpl(_triggerName, _jobGroup, _cronExpression);
			if (!AppScheduler.DoesJobExist(_className, _jobGroup)) {
				AppScheduler.Instance.ScheduleJob(job, trigger);
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates and schedules a job for certificated partner contact actualization.
		/// </summary>
		/// <param name="context">Execution context.</param>
		public override void OnAppStart(AppEventContext context) {
			context.CheckArgumentNull("context");
			_appEventContext = context;
			ScheduleCronTriggerJob();
		}

		#endregion
	}
}

