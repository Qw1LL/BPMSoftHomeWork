namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using global::Common.Logging;

	#region Class: TouchQueueMessageProcessor

	/// <summary>
	/// Processes all messages from <see cref="TouchQueue"/>.
	/// </summary>
	public class TouchQueueMessageProcessor
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of the class.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		public TouchQueueMessageProcessor(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Private

		private IEnumerable<BaseTouchQueueMessageProcessor> _messageProcessorsChain;

		private IEnumerable<BaseTouchQueueMessageProcessor> MessageProcessorsChain =>
			_messageProcessorsChain ?? (_messageProcessorsChain = Loader.GetProcessors());

		#endregion

		#region Properties: Public

		/// <summary>
		/// An instance of the <see cref="UserConnection"/> class.
		/// </summary>
		public virtual UserConnection UserConnection { get; set; }

		/// <summary>
		/// Logger.
		/// </summary>
		private ILog _logger;
		public ILog Logger {
			get => _logger ?? (_logger = LogManager.GetLogger("TouchPoints"));
			set => _logger = value;
		}

		/// <summary>
		/// An instance of <see cref="TouchQueueMessageNotifier"/> class to notify about processing.
		/// </summary>
		private TouchQueueMessageNotifier _touchQueueNotifier;
		public TouchQueueMessageNotifier Notifier {
			get => _touchQueueNotifier ?? (_touchQueueNotifier = new TouchQueueMessageNotifier(UserConnection));
			set => _touchQueueNotifier = value;
		}

		/// <summary>
		/// Instance of <see cref="TouchQueueMessageProcessorLoader"/> to get all available message processors.
		/// </summary>
		private TouchQueueMessageProcessorLoader _loader;
		protected virtual TouchQueueMessageProcessorLoader Loader {
			get => _loader ?? (_loader = new TouchQueueMessageProcessorLoader(UserConnection));
			set => _loader = value;
		}

		#endregion

		#region Methods: Private

		private void InternalProcess(TouchQueueMessage message) {
			foreach (var processor in MessageProcessorsChain) {
				if (processor.CanProcessMessage(message)) {
					processor.Process(message);
					return;
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Tries to process touch queue message.
		/// </summary>
		/// <param name="message">Instance of <see cref="EventQueueMessage"/>.</param>
		/// <exception cref="ArgumentNullOrEmptyException">In case of <paramref name="message"/> is null.</exception>
		public virtual void Process(TouchQueueMessage message) {
			message.CheckArgumentNull("message");
			InternalProcess(message);
		}

		#endregion

	}

	#endregion

}

