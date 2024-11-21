namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;
	using Quartz;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Web.Common;
	using global::Common.Logging;

	#region Class: MarketingEventQueueJobDispatcher

	/// <summary>
	/// Serves marketing event message queue.
	/// </summary>
	public class MarketingEventQueueJobDispatcher : BaseQueueJobDispatcher, IAppEventListener
	{

		#region Properties: Protected

		protected virtual IEnumerable<EventQueueMessageType> AllowedMessageTypes =>
			new EventQueueMessageType[] {
				EventQueueMessageType.AddAudienceByFilter,
				EventQueueMessageType.AddAudienceByFolderId,
				EventQueueMessageType.AddAudienceByList,
				EventQueueMessageType.RemoveAllAudience,
				EventQueueMessageType.RemoveAudienceByFilter,
				EventQueueMessageType.RemoveAudienceByList
			};

		#endregion

		#region Properties: Public

		public override string JobGroupName => "MarketingEvent";

		/// <summary>
		/// Processes any message from <see cref="MarketingEventQueue"/>.
		/// </summary>
		private EventQueueMessageProcessor _messageProcessor;
		public EventQueueMessageProcessor MessageProcessor {
			get => _messageProcessor ?? (_messageProcessor = new EventQueueMessageProcessor(UserConnection));
			set => _messageProcessor = value;
		}

		/// <summary>
		/// An instance of <see cref="MarketingEventQueueManager"/> class.
		/// </summary>
		private MarketingEventQueueManager _queueManager;
		public MarketingEventQueueManager QueueManager {
			get {
				if (_queueManager == null) {
					_queueManager = new MarketingEventQueueManager(UserConnection);
					_queueManager.OnMessageDequeued += OnMessageDequeued;
				}
				return _queueManager;
			}
			set => _queueManager = value;
		}

		#endregion

		#region Methods: Private

		private void OnMessageDequeued(object sender, EventQueueMessage message) {
			MessageProcessor.Process(message);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override ILog GetLogger() => LogManager.GetLogger("MarketingEventLogger");

		/// <inheritdoc/>
		protected override IScheduler GetScheduler() => DefaultScheduler.Instance;

		/// <summary>
		/// Processes bulk email audience queue.
		/// </summary>
		protected override void InternalExecute() {
			while (true) {
				var messageTypes = AllowedMessageTypes.Select(x => (int)x);
				var message = QueueManager.Dequeue(messageTypes);
				if (message == null) {
					break;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules minutely job for bulk email audience queue and tries to reschedule broken triggers.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnAppStart(AppEventContext context) {
			GetUserConnection(context);
			TryRescheduleJob();
		}

		public void OnAppEnd(AppEventContext context) { }

		public void OnSessionStart(AppEventContext context) { }

		public void OnSessionEnd(AppEventContext context) { }

		/// <inheritdoc/>
		protected override void ScheduleJob(string workspaceName, string userName) {
			AppScheduler.ScheduleMinutelyJob<MarketingEventQueueJobDispatcher>(
				JobGroupName, workspaceName, userName, periodInMinutes: 1,
				isSystemUser: true, scheduler: Scheduler,
				misfireInstruction: AppSchedulerMisfireInstruction.SmartPolicy);
		}

		#endregion

	}

	#endregion

}

