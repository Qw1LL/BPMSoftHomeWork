namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;
	using Quartz;
	using BPMSoft.Web.Common;
	using global::Common.Logging;

	#region Class: BaseBulkEmailQueueJobDispatcher

	/// <summary>
	/// Serves bulk email queue.
	/// </summary>
	public abstract class BaseBulkEmailQueueJobDispatcher : BaseQueueJobDispatcher
	{

		#region Properties: Private

		/// <summary>
		/// Instance of <see cref="IScheduler"/> with name <see cref="BulkEmailSchedulerName"/> or default.
		/// </summary>
		public IScheduler BulkEmailScheduler => DefaultScheduler.FindScheduler(MailingConsts.BulkEmailQuartzScheduler)
			?? DefaultScheduler.Instance;

		#endregion

		#region Properties: Protected

		protected virtual IEnumerable<BulkEmailQueueMessageType> AllowedMessageTypes =>
			default(IEnumerable<BulkEmailQueueMessageType>);

		#endregion

		#region Properties: Public

		public override string JobGroupName => MailingConsts.BulkEmailQuartzJobGroupName;

		/// <summary>
		/// Processes any message from <see cref="BulkEmailQueue"/>.
		/// </summary>
		private BulkEmailQueueMessageProcessor _messageProcessor;
		public BulkEmailQueueMessageProcessor MessageProcessor {
			get => _messageProcessor ?? (_messageProcessor = new BulkEmailQueueMessageProcessor(UserConnection));
			set => _messageProcessor = value;
		}

		/// <summary>
		/// An instance of <see cref="BulkEmailQueueManager"/> class.
		/// </summary>
		private BulkEmailQueueManager _queueManager;
		public BulkEmailQueueManager QueueManager {
			get {
				if (_queueManager == null) {
					_queueManager = new BulkEmailQueueManager(UserConnection);
					_queueManager.OnMessageDequeued += OnMessageDequeued;
				}
				return _queueManager;
			}
			set => _queueManager = value;
		}

		#endregion

		#region Methods: Private

		private void OnMessageDequeued(object sender, BulkEmailQueueMessage message) {
			MessageProcessor.Process(message);
		}

		#endregion

		#region Methods: Protected

		/// <inheritdoc/>
		protected override ILog GetLogger() => MailingUtilities.Log;

		/// <inheritdoc/>
		protected override IScheduler GetScheduler() => BulkEmailScheduler;

		/// <summary>
		/// Processes bulk email audience queue.
		/// </summary>
		protected override void InternalExecute() {
			while (true) {
				var messageTypes = AllowedMessageTypes?.Select(x => (int)x);
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

		#endregion

	}

	#endregion

}

