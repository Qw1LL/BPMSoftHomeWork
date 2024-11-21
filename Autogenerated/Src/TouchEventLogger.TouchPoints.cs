namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using global::Common.Logging;

	#region Class: TouchEventLogger

	/// <summary>
	/// Provides methods to log touch actions.
	/// </summary>
	public class TouchEventLogger
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly int _maxDetailsLength = 40000;
		private readonly int _minLength = 2000;

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Constructor for <see cref="TouchEventLogger"/>.
		/// </summary>
		/// <param name="userConnection"></param>
		public TouchEventLogger(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Logger for <see cref="TouchEventLogger"/>.
		/// </summary>
		private ILog _logger;
		public ILog Logger {
			get => _logger ?? (_logger = LogManager.GetLogger("TouchPoints"));
			set => _logger = value;
		}

		#endregion

		#region Methods: Private

		private void InternalLog(string eventName, string eventType, string description, DateTime startDate,
				int amount, Guid trackingId, Exception exception = null) {
			try {
				var insert = new Insert(_userConnection).Into(nameof(TouchEventLog))
					.Set(nameof(TouchEventLog.Name), Column.Parameter(eventName ?? ""))
					.Set(nameof(TouchEventLog.StartDate), Column.Parameter(startDate))
					.Set(nameof(TouchEventLog.MessageTypeName), Column.Parameter(eventType ?? ""))
					.Set(nameof(TouchEventLog.Amount), Column.Parameter(amount))
					.Set(nameof(TouchEventLog.Description), Column.Parameter(description ?? ""));
				if (exception != null) {
					var errorDetails = GetErrorDetails(exception);
					insert.Set(nameof(TouchEventLog.HasErrors), Column.Parameter(true));
					insert.Set(nameof(TouchEventLog.ErrorDetails), Column.Parameter(errorDetails ?? ""));
				}
				if (trackingId.IsNotEmpty()) {
					insert.Set(nameof(TouchEventLog.TrackingId), Column.Parameter(trackingId));
				}
				insert.Execute();
			} catch (Exception e) {
				Logger.Error($"Error for logging touch tracking event: {eventName} {eventType} {startDate}"
					+ $" {exception?.Message ?? ""} {exception?.StackTrace}", e);
			}
		}

		private void InternalLog(TouchQueueMessage message, string eventName, string description,
				DateTime startDate, int amount, Exception exception = null) {
			var eventType = message.GetTypeName();
			var trackingId = message.GetTracking();
			InternalLog(eventName, eventType, description, startDate, amount, trackingId, exception);
		}

		private string GetErrorDetails(Exception exception) {
			var targetException = exception.InnerException ?? exception;
			var message = targetException.Message;
			var callStack = targetException.StackTrace;
			var exceptionDetails = $"Message:{message}\nCallstack:{callStack}";
			return CheckLength(exceptionDetails);
		}

		private string CheckLength(string log) =>
			log.Length > _maxDetailsLength
				? $"{log.Substring(0, _minLength)} <...removed...> {log.Substring(log.Length - _minLength)}"
				: log;

		#endregion

		#region Methods: Public

		/// <summary>
		/// Logs error to <see cref="TouchEventLog"/>.
		/// </summary>
		/// <param name="eventName">Touch event name.</param>
		/// <param name="startDate">Event start date.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="message">Touch queue message to process.</param>
		public void Error(string eventName, DateTime startDate, Exception exception, TouchQueueMessage message) =>
			InternalLog(message, eventName, string.Empty, startDate, 0, exception);

		/// <summary>
		/// Logs error to <see cref="TouchEventLog"/>.
		/// </summary>
		/// <param name="eventName">Touch event name.</param>
		/// <param name="startDate">Event start date.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="eventType">Event log type.</param>
		public void Error(string eventName, DateTime startDate, Exception exception, string eventType = "") =>
			InternalLog(eventName, eventType, string.Empty, startDate, 0, Guid.Empty, exception);

		/// <summary>
		/// Logs error to <see cref="TouchEventLog"/> for tracking system specified.
		/// </summary>
		/// <param name="eventName">Touch event name.</param>
		/// <param name="startDate">Event start date.</param>
		/// <param name="exception">Exception.</param>
		/// <param name="trackingId">Id of tracking system.</param>
		/// <param name="eventType">Event log type.</param>
		public void Error(string eventName, DateTime startDate, Exception exception, Guid trackingId,
				string eventType = "") =>
			InternalLog(eventName, eventType, string.Empty, startDate, 0, trackingId, exception);

		/// <summary>
		/// Logs success actions to <see cref="TouchEventLog"/>.
		/// </summary>
		/// <param name="eventName">Touch event name.</param>
		/// <param name="startDate">Event start date.</param>
		/// <param name="message">Touch queue message to process.</param>
		/// <param name="amount">Message process result count.</param>
		/// <param name="description">Event description.</param>
		public void Info(string eventName, DateTime startDate, TouchQueueMessage message, int amount = 0,
				string description = "") =>
			InternalLog(message, eventName, description, startDate, amount);

		/// <summary>
		/// Logs success actions to <see cref="TouchEventLog"/>.
		/// </summary>
		/// <param name="eventName">Touch event name.</param>
		/// <param name="startDate">Event start date.</param>
		/// <param name="eventType">Event log type.</param>
		/// <param name="amount">Message process result count.</param>
		/// <param name="description">Event description.</param>
		public void Info(string eventName, DateTime startDate, string eventType = "", int amount = 0,
				string description = "") =>
			InternalLog(eventName, eventType, description, startDate, amount, Guid.Empty);

		/// <summary>
		/// Logs success actions to <see cref="TouchEventLog"/> for tracking system specified.
		/// </summary>
		/// <param name="eventName">Touch event name.</param>
		/// <param name="startDate">Event start date.</param>
		/// <param name="trackingId">Id of tracking system.</param>
		/// <param name="eventType">Event log type.</param>
		/// <param name="amount">Message process result count.</param>
		/// <param name="description">Event description.</param>
		public void Info(string eventName, DateTime startDate, Guid trackingId, string eventType = "", int amount = 0,
				string description = "") =>
			InternalLog(eventName, eventType, description, startDate, amount, trackingId);

		#endregion

	}

	#endregion

}
