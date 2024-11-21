namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using global::Common.Logging;

	#region Class: BaseQueueMessageProcessor

	public abstract class BaseQueueMessageProcessor
	{

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseQueueMessageProcessor"/> class.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		/// <param name="logger">Provider of the logging methods.</param>
		/// <param name="notifier">Provider of the notification methods.</param>
		public BaseQueueMessageProcessor(UserConnection userConnection, ILog logger,
				BaseQueueMessageNotifier notifier) {
			UserConnection = userConnection;
			Logger = logger;
			Notifier = notifier;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseQueueMessageProcessor"/> class.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		public BaseQueueMessageProcessor(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Properties: Protected

		protected virtual bool CanNotify => true;
		protected virtual ILog Logger { get; set; }
		protected UserConnection UserConnection { get; set; }
		protected BaseQueueMessageNotifier Notifier { get; set; }

		#endregion

		#region Methods: Protected

		protected abstract int ProcessMessage(BaseTaskQueueMessage message);

		/// <summary>
		/// Returns message processing success operation result text.
		/// </summary>
		/// <param name="count">Processed records count.</param>
		/// <returns>Message processing success result text.</returns>
		protected virtual string GetOperationSuccessText(BaseTaskQueueMessage message, int count) {
			return string.Empty;
		}

		/// <summary>
		/// Returns message processing failed operation result text.
		/// </summary>
		/// <returns>Message processing failed result text.</returns>
		protected virtual string GetOperationFailedText(BaseTaskQueueMessage message) {
			return string.Empty;
		}

		/// <summary>
		/// Notifies about message processing operation result where it is needed.
		/// </summary>
		/// <param name="message">Instance of <see cref="BaseTaskQueueMessage"/> that had been processed.</param>
		/// <param name="count">Processed records count.</param>
		/// <param name="success">Message processing result.</param>
		protected virtual void Notify(BaseTaskQueueMessage message, int count, bool success) {
			var operationResult = success
					? GetOperationSuccessText(message, count)
					: GetOperationFailedText(message);
			var result = new QueueMessageProcessResult {
				Success = success,
				OperationResult = operationResult,
				Silent = !CanNotify,
				RowsCount = count
			};
			Notifier.Notify(message, result);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes logic.
		/// </summary>
		public virtual void Process(BaseTaskQueueMessage message) {
			int result = 0;
			try {
				result = ProcessMessage(message);
			} catch {
				Notify(message, result, false);
				throw;
			}
			Notify(message, result, true);
		}

		#endregion

		}

	#endregion

	#region Class: QueueMessageProcessResult

	/// <summary>
	/// Class to represent processing result of queue message.
	/// </summary>
	public class QueueMessageProcessResult
	{

		#region Properties: Public

		/// <summary>
		/// Is result success.
		/// </summary>
		public bool Success { get; set; }

		/// <summary>
		/// Count of processed records.
		/// </summary>
		public int RowsCount { get; set; }

		/// <summary>
		/// Text of operation result.
		/// </summary>
		public string OperationResult { get; set; }

		/// <summary>
		/// Flag to indicate result to be silent for notification system.
		/// </summary>
		public bool Silent { get; set; }

		#endregion

	}

	#endregion

}

