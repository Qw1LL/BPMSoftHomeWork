namespace BPMSoft.Configuration
{
	using Quartz;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;
	using CoreCampaignConsts = Core.Campaign.CampaignConstants;
	using global::Common.Logging;

	#region Class: CampaignQueueMonitoringJobDispatcher

	/// <summary>
	/// Provides methods to handle broken campaign queue monitoring.
	/// </summary>
	public class CampaignQueueMonitoringJobDispatcher : BaseQueueJobDispatcher, IAppEventListener
	{

		#region Constants: Private

		private const int QueueMonitoringTriggerPriority = 10;

		#endregion

		#region Properties: Public

		public override string JobGroupName => CampaignConsts.CampaignJobGroupName;

		/// <summary>
		/// An instance of <see cref="CampaignQueueMonitoring"/> class.
		/// </summary>
		private CampaignQueueMonitoring _queueMonitoring;
		public CampaignQueueMonitoring QueueMonitoring {
			get => _queueMonitoring ?? (_queueMonitoring = new CampaignQueueMonitoring(UserConnection));
			set => _queueMonitoring = value;
		}

		/// <summary>
		/// An instance of <see cref="CampaignHelper"/> class.
		/// </summary>
		private CampaignHelper _campaignHelper;
		public CampaignHelper CampaignHelper {
			get => _campaignHelper ?? (_campaignHelper = new CampaignHelper(UserConnection));
			set => _campaignHelper = value;
		}

		/// <summary>
		/// Gets or sets the campaign scheduler. Instance of <see cref="CampaignJobDispatcher"/>.
		/// </summary>
		private ICampaignJobDispatcher _campaignJobDispatcher;
		public ICampaignJobDispatcher CampaignJobDispatcher {
			get => _campaignJobDispatcher ?? (_campaignJobDispatcher = new CampaignJobDispatcher(UserConnection));
			set => _campaignJobDispatcher = value;
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override ILog GetLogger() => LogManager.GetLogger(CoreCampaignConsts.CampaignLoggerName);

		/// <inheritdoc/>
		protected override IScheduler GetScheduler() => DefaultScheduler.Instance;

		/// <inheritdoc/>
		protected override void ScheduleJob(string workspaceName, string userName) {
			AppScheduler.ScheduleMinutelyJob<CampaignQueueMonitoringJobDispatcher>(
				CampaignConsts.CampaignJobGroupName, workspaceName, userName, periodInMinutes: 1,
				isSystemUser: true, scheduler: Scheduler, priority: QueueMonitoringTriggerPriority);
		}

		/// <inheritdoc/>
		protected override void UnscheduleUnactualJobs() {
			ProcessSchedulerJobTriggers(CampaignJobDispatcher.CampaignScheduler, (trigger) => {
				if (trigger.Key.Name.Contains(GetType().Name)) {
					TryUnscheduleJob(CampaignJobDispatcher.CampaignScheduler, trigger.Key);
				}
			});
		}

		/// <summary>
		/// Processes campaign queue.
		/// </summary>
		protected override void InternalExecute() {
			QueueMonitoring.Run();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules minutely job for campaign queue and tries to reschedule broken triggers.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnAppStart(AppEventContext context) {
			GetUserConnection(context);
			TryRescheduleJob();
		}

		public void OnAppEnd(AppEventContext context) { }

		public void OnSessionStart(AppEventContext context) { }

		public void OnSessionEnd(AppEventContext context) { }

		#endregion

	}

	#endregion

}
