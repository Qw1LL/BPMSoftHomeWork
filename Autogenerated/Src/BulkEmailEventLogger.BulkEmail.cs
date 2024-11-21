namespace BPMSoft.Configuration
{
	using System;
	using Core;
	using Core.DB;

	#region Class: BulkEmailEventLogger

	/// <summary>
	/// Provides methods to log mailing process.
	/// </summary>
	public class BulkEmailEventLogger
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly Guid _errorResult = new Guid("ECDAD8FE-6F04-45CE-91F3-291CC54D80CD");
		private readonly Guid _infoResult = new Guid("6E20EC0C-96C9-44B4-ABD5-2D3AA635A26D");
		private readonly int _maxLengthLogWithoutParsing = 40000;
		private readonly int _substringLength = 2000;

		#endregion

		#region Constructors: Public

		public BulkEmailEventLogger(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private void InternalLog(Guid bulkEmailId, DateTime startDate, string eventName, Exception exception, 
				string messageTemplate, Guid errorResult, Guid userId, params object[] parameters) {
			try {
				var message = string.Format(messageTemplate, parameters);
				var insert = new Insert(_userConnection).Into("BulkEmailEventLog")
					.Set("Name", Column.Parameter(eventName))
					.Set("StartDate", Column.Parameter(startDate))
					.Set("BulkEmailId", Column.Parameter(bulkEmailId))
					.Set("ResultId", Column.Parameter(errorResult))
					.Set("Description", Column.Parameter(message));
				if (exception != null) {
					string exceptionDetails = GetExceptionDetails(exception);
					insert.Set("DetailedResult", Column.Parameter(exceptionDetails));
				}
				if (userId != Guid.Empty) {
					insert.Set("CreatedById", Column.Parameter(userId));
				}
				insert.Execute();
			} catch (Exception e) {
				MailingUtilities.Log.ErrorFormat("Exception while writing log. Msg template: {0}", e, messageTemplate);
			}
			
		}

		private string GetExceptionDetails(Exception exception) {
			string exceptionDetails = "Type: {0}\nMessage:{1}\nCallstack:{2}";
			var targetException = exception.InnerException ?? exception;
			var type = targetException.GetType().FullName;
			var message = targetException.Message;
			var callStack = targetException.StackTrace;
			var log = string.Format(exceptionDetails, type, message, callStack);
			var logResult = CheckLineLength(log);
			return logResult;
		}

		private string CheckLineLength(string log) {
			if(log.Length > _maxLengthLogWithoutParsing) {
				log = $"{log.Substring(0, _substringLength)} <removed by script> {log.Substring(log.Length - _substringLength)}";
			}
			return log;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Logs the error message.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="startDate">Date and time when action has been started.</param>
		/// <param name="eventName">Name of the event.</param>
		/// <param name="messageTemplate">The message template.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="parameters">The parameters.</param>
		public void LogError(Guid bulkEmailId,DateTime startDate,  string eventName, string messageTemplate, Guid userId,
				params object[] parameters) {
			InternalLog(bulkEmailId, startDate, eventName, null, messageTemplate, _errorResult, userId, parameters);
		}

		/// <summary>
		/// Logs the error message with exception details.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="startDate">Date and time when action has been started.</param>
		/// <param name="eventName">Name of the event.</param>
		/// <param name="exception">The exception.</param>
		/// <param name="messageTemplate">The message template.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="parameters">The parameters.</param>
		public void LogError(Guid bulkEmailId, DateTime startDate, string eventName, Exception exception, 
				string messageTemplate, Guid userId, params object[] parameters) {
			InternalLog(bulkEmailId, startDate, eventName, exception, messageTemplate, _errorResult, userId, 
				parameters);
		}

		/// <summary>
		/// Logs the information massage.
		/// </summary>
		/// <param name="bulkEmailId">The bulk email identifier.</param>
		/// <param name="startDate">Date and time when action has been started.</param>
		/// <param name="eventName">Name of the event.</param>
		/// <param name="messageTemplate">The message template.</param>
		/// <param name="userId">User identifier.</param>
		/// <param name="parameters">The parameters.</param>
		public void LogInfo(Guid bulkEmailId, DateTime startDate, string eventName, string messageTemplate, Guid userId,
				params object[] parameters) {
			InternalLog(bulkEmailId, startDate, eventName, null, messageTemplate, _infoResult, userId, parameters);
		}

		#endregion

	}

	#endregion
	
}
