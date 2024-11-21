namespace BPMSoft.Configuration
{
	using Quartz;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;
	using global::Common.Logging;

	#region Class: TouchQueueJobDispatcher

	/// <summary>
	/// Serves touch points queue.
	/// </summary>
	public class TouchQueueJobDispatcher : BaseQueueJobDispatcher, IAppEventListener
	{

		#region Properties: Private

		/// <summary>
		/// Instance of <see cref="IScheduler"/> with name <see cref="TouchPointsSchedulerName"/> or default.
		/// </summary>
		public IScheduler TouchPointsScheduler => DefaultScheduler.FindScheduler("TouchPointsQuartzScheduler")
			?? DefaultScheduler.Instance;

		#endregion

		#region Properties: Public

		public override string JobGroupName => "TouchPoints";

		/// <summary>
		/// Processes any message from <see cref="TouchQueue"/>.
		/// </summary>
		private TouchQueueMessageProcessor _messageProcessor;
		public TouchQueueMessageProcessor MessageProcessor {
			get => _messageProcessor ?? (_messageProcessor = new TouchQueueMessageProcessor(UserConnection));
			set => _messageProcessor = value;
		}

		/// <summary>
		/// An instance of <see cref="TouchQueueManager"/> class.
		/// </summary>
		private TouchQueueManager _queueManager;
		public TouchQueueManager QueueManager {
			get {
				if (_queueManager == null) {
					_queueManager = new TouchQueueManager(UserConnection);
					_queueManager.OnMessageDequeued += OnMessageDequeued;
				}
				return _queueManager;
			}
			set => _queueManager = value;
		}

		#endregion

		#region Methods: Private

		private void OnMessageDequeued(object sender, TouchQueueMessage message) {
			MessageProcessor.Process(message);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override ILog GetLogger() => LogManager.GetLogger("TouchPoints");

		/// <inheritdoc/>
		protected override IScheduler GetScheduler() => TouchPointsScheduler;

		/// <summary>
		/// Processes touch queue messages.
		/// </summary>
		protected override void InternalExecute() {
			while (true) {
				var message = QueueManager.Dequeue();
				if (message == null) {
					break;
				}
			}
		}

		/// <inheritdoc/>
		protected override void ScheduleJob(string workspaceName, string userName) {
			AppScheduler.ScheduleMinutelyJob<TouchQueueJobDispatcher>(
				JobGroupName, workspaceName, userName, periodInMinutes: 1,
				isSystemUser: true, scheduler: Scheduler,
				misfireInstruction: AppSchedulerMisfireInstruction.SmartPolicy);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules minutely job for touch queue and tries to reschedule broken triggers.
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

