namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;
	using BPMSoft.Core.Store;
	using BPMSoft.Messaging.Common;
	using global::Common.Logging;

	#region Class: QueuesUtilities

	/// <summary>
	/// ####### ### ###### # ######## # ###### ####.
	/// </summary>
	public static class QueuesUtilities
	{

		#region Constants: Private

		/// <summary>
		/// ######## ####### ####### ########## ######## ####### #### ## #########. # #######.
		/// </summary>
		private const int DefaultUpdateQueuesIntervalMinutes = 5;

		/// <summary>
		/// ### ####### ############ ########## ######## ####### ####.
		/// </summary>
		private const string UpdateQueuesJobName = "UpdateQueuesJob";

		/// <summary>
		/// ######## ###### ####### ############ ####### #### #########.
		/// </summary>
		private const string UpdateQueuesJobGroup = "OperatorSingleWindow";

		/// <summary>
		/// ######## ######## ########## ######## ####### ####.
		/// </summary>
		private const string UpdateQueuesProcessName = "QueuesUpdateProcess";
		
		/// <summary>
		/// ######## ##### # #### ######### ########### ######### ########.
		/// </summary>
		private const string QueuesNotificationsSubscribersKey = "QueuesNotificationsSubscribers";

		#endregion

		#region Fields: Private

		/// <summary>
		/// ######.
		/// </summary>
		private static readonly ILog _log = LogManager.GetLogger(typeof(QueuesUtilities));

		#endregion

		#region Methods: Private

		/// <summary>
		/// ########## ####### ####, ### ########### ######## ########.
		/// </summary>
		/// <param name="userConnection">################ ###########.</param>
		/// <returns><c>true</c>, #### ########### ########, ##### - <c>false</c>.</returns>
		private static bool GetIsSchedulerDisabled(UserConnection userConnection) {
			object isDisabled;
			if (Core.Configuration.SysSettings.TryGetValue(userConnection, "DisableQueueFillingScheduler",
					out isDisabled)) {
				return (bool)isDisabled;
			}
			return false;
		}

		/// <summary>
		/// ########## ######## ########## ######## ####### ####.
		/// </summary>
		/// <param name="userConnection">################ ###########.</param>
		/// <returns>
		/// ######## ########## ######## ####### ####.
		/// </returns>
		private static int GetQueuesUpdateInterval(UserConnection userConnection) {
			object interval;
			if (Core.Configuration.SysSettings.TryGetValue(userConnection, "QueuesUpdateInterval", out interval)) {
				return (int)interval;
			}
			return DefaultUpdateQueuesIntervalMinutes;
		}

		/// <summary>
		/// ########## ######### ###########.
		/// </summary>
		/// <param name="type">### #########.</param>
		/// <param name="message">#########.</param>
		private static void NotifySubscribers(string type, string message) {
			try {
				foreach (Guid subscriberId in QueuesNotificationsSubscribers) {
					MsgChannelManager manager = MsgChannelManager.Instance;
					IMsgChannel channel = manager.FindItemByUId(subscriberId);
					if (channel == null) {
						continue;
					}
					var simpleMessage = new SimpleMessage();
					simpleMessage.Body = message;
					simpleMessage.Id = channel.Id;
					simpleMessage.Header.BodyTypeName = type;
					simpleMessage.Header.Sender = "QueuesNotification";
					channel.PostMessage(simpleMessage);
				}
			} catch (Exception e) {
				_log.ErrorFormat(message, e.Message, e);
			}
		}

		#endregion

		#region Fields: Public

		/// <summary>
		/// ######### ########### ## ######### ########.
		/// </summary>
		private static IList<Guid> _queuesNotificationsSubscribers = null;
		public static IList<Guid> QueuesNotificationsSubscribers {
			get {
				if (_queuesNotificationsSubscribers == null) {
					ICacheStore cache = Store.Cache[CacheLevel.Application];
					_queuesNotificationsSubscribers = new List<Guid>();
					cache[QueuesNotificationsSubscribersKey] = _queuesNotificationsSubscribers;
				}
				return _queuesNotificationsSubscribers;
			}
		}

		#endregion
		
		#region Methods: Public

		/// <summary>
		/// ######### ####### ############ ########## ######## ####### ####.
		/// </summary>
		/// <param name="userConnection">################ ###########.</param>
		public static void UpdateQueuesTrigger(UserConnection userConnection) {
			try {
				if (GetIsSchedulerDisabled(userConnection)) {
					AppScheduler.RemoveJob(UpdateQueuesJobName, UpdateQueuesJobGroup);
					IResourceStorage resourceStorage = userConnection.Workspace.ResourceStorage;
					var message = new LocalizableString(resourceStorage,
						"QueuesUtilities", "LocalizableStrings.SchedulerDisabledMessage.Value");
					_log.DebugFormat(message);
					NotifySubscribers("Debug", message);
					return;
				}
				string userName = userConnection.CurrentUser.Name;
				string workspaceName = userConnection.Workspace.Name;
				int periodInMinutes = GetQueuesUpdateInterval(userConnection);
				AppScheduler.ScheduleMinutelyProcessJob(UpdateQueuesJobName, UpdateQueuesJobGroup, 
					UpdateQueuesProcessName, workspaceName, userName, periodInMinutes, null, true);
			} catch (Exception e) {
				LogError(e.Message, e);
				throw;
			}
		}

		/// <summary>
		/// ########## # ### ######### ## ######.
		/// </summary>
		/// <param name="message">#########.</param>
		public static void LogError(string message) {
			if (!_log.IsErrorEnabled) {
				return;
			}
			_log.Error(message);
			NotifySubscribers("Error", message);
		}

		/// <summary>
		/// ########## # ### ######### ## ######.
		/// </summary>
		/// <param name="message">#########.</param>
		/// <param name="exception">##########.</param>
		public static void LogError(string message, Exception exception) {
			if (!_log.IsErrorEnabled) {
				return;
			}
			_log.Error(message, exception);
			NotifySubscribers("Error", message);
		}
		
		/// <summary>
		/// ########## # ### ######### # ##############.
		/// </summary>
		/// <param name="message">#########.</param>
		public static void LogWarn(string message) {
			if (!_log.IsWarnEnabled) {
				return;
			}
			_log.Warn(message);
		}
		
		/// <summary>
		/// ########## # ### ######### # ##############.
		/// </summary>
		/// <param name="message">#########.</param>
		/// <param name="exception">##########.</param>
		public static void LogWarn(string message, Exception exception) {
			if (!_log.IsWarnEnabled) {
				return;
			}
			_log.Warn(message, exception);
		}

		/// <summary>
		/// ########## # ### ############## #########.
		/// </summary>
		/// <param name="message">#########.</param>
		public static void LogInfo(string message) {
			if (!_log.IsInfoEnabled) {
				return;
			}
			_log.Info(message);
		}

		/// <summary>
		/// ########## # ### ############## #########.
		/// </summary>
		/// <param name="message">#########.</param>
		/// <param name="exception">##########.</param>
		public static void LogInfo(string message, Exception exception) {
			if (!_log.IsInfoEnabled) {
				return;
			}
			_log.Info(message, exception);
		}
		
		/// <summary>
		/// ########## # ### ########## #########.
		/// </summary>
		/// <param name="message">#########.</param>
		public static void LogDebug(string message) {
			if (!_log.IsDebugEnabled) {
				return;
			}
			_log.Debug(message);
		}

		/// <summary>
		/// ########## # ### ########## #########.
		/// </summary>
		/// <param name="message">#########.</param>
		/// <param name="exception">##########.</param>
		public static void LogDebug(string message, Exception exception) {
			if (!_log.IsDebugEnabled) {
				return;
			}
			_log.Debug(message, exception);
		}

		#endregion

	}

	#endregion

}

