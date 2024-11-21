namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using global::Common.Logging;
	using BPMSoft.Core.Factories;

	#region Class: BaseTouchQueueMessageProcessor

	/// <summary>
	/// Processes single typed message from <see cref="TouchQueue"/>.
	/// </summary>
	public abstract class BaseTouchQueueMessageProcessor : BaseQueueMessageProcessor {

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseTouchQueueMessageProcessor"/> class.
		/// </summary>
		/// <param name="userConnection">Current user connection.</param>
		public BaseTouchQueueMessageProcessor(UserConnection userConnection) : base(userConnection) {
			Logger = LogManager.GetLogger("TouchPoints");
			Notifier = new TouchQueueMessageNotifier(userConnection);
			InitStrategy();
		}

		#endregion

		#region Properties: Protected

		protected Dictionary<Type, Func<TouchQueueMessage, int>> Strategy;

		/// <summary>
		/// Instance of <see cref="TouchEventLogger"/> to log touch processing events.
		/// </summary>
		private TouchEventLogger _eventLogger;
		protected virtual TouchEventLogger EventLogger {
			get => _eventLogger ?? (_eventLogger =
				ClassFactory.Get<TouchEventLogger>(new ConstructorArgument("userConnection", UserConnection)));
			set => _eventLogger = value;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Initializes strategies.
		/// </summary>
		protected abstract void InitStrategy();

		protected abstract string GetEventName(TouchQueueMessage message);

		protected abstract string GetEventDescription(TouchQueueMessage message, int result);

		protected virtual void Log(TouchQueueMessage message, DateTime startDate, int result = 0, Exception exception = null) {
			var eventName = GetEventName(message);
			if (exception == null) {
				var eventDescription = GetEventDescription(message, result);
				EventLogger.Info(eventName, startDate, message, result, eventDescription);
				return;
			}
			EventLogger.Error(eventName, startDate, exception, message);	
		}

		protected override int ProcessMessage(BaseTaskQueueMessage message) {
			var msg = message as TouchQueueMessage;
			int result;
			var startDate = DateTime.UtcNow;
			try {
				result = Strategy[msg.GetType()].Invoke(msg);
			} catch (Exception ex) {
				Log(msg, startDate, exception: ex);
				throw;
			}
			Log(msg, startDate, result);
			return result;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Defines if class can process message of some type.
		/// </summary>
		/// <param name="message">Instance of <see cref="TouchQueueMessage"/>.</param>
		/// <returns></returns>
		public virtual bool CanProcessMessage(TouchQueueMessage message) => Strategy.ContainsKey(message.GetType());

		#endregion

	}

	#endregion

}

