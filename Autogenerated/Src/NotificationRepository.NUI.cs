namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using global::Common.Logging;

	/// <summary>
	/// Class for data access notification.
	/// </summary>
	public class NotificationRepository : INotificationRepository
	{
		#region Fields: Private

		private readonly INotificationFactory _factory;
		private readonly INotificationStore _store;
		private readonly object _locker = new object();
		private static readonly ILog _log = LogManager.GetLogger("Notifications");

		#endregion

		#region Contructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="store"></param>
		/// <param name="factory"></param>
		public NotificationRepository(INotificationStore store, INotificationFactory factory) {
			if (store == null || factory == null) {
				throw new ArgumentNullOrEmptyException();
			}
			_store = store;
			_factory = factory;
		}

		#endregion

		#region Methods: Private

		private IEnumerable<string> GetProvidersName() {
			return _store.GetNotificationProvidersName();
		}

		private IEnumerable<INotification> GetProviders() {
			var result = new List<INotification>();
			IEnumerable<string> providersName = GetProvidersName();
			if (providersName == null || providersName.IsEmpty()) {
				return result;
			}
			foreach (string name in providersName) {
				INotification instance = _factory.CreateInstance(name);
				if (instance != null) {
					result.Add(instance);
				}
			}
			return result;
		}

		private IEnumerable<INotificationInfo> GetNotificationInfos(Func<INotification,
					IEnumerable<INotificationInfo>> predicate) {
			var result = new List<INotificationInfo>();
			IEnumerable<INotification> notifications = GetProviders();
			if (notifications.IsEmpty()) {
				return result;
			}
			foreach (INotification notification in notifications) {
				if (notification != null) {
					try {
						IEnumerable<INotificationInfo> infos = predicate(notification);
						if (infos != null) {
							result.AddRange(infos);
						}
					} catch (Exception ex) {
						_log.Error(ex.Message, ex);
					}					
				}
			}
			return result;
		}

		private static IEnumerable<INotificationInfo> GetNotificationInfosByEqualsParameter(
				string parameterValue, string expectedValue, INotification notification) {
			if (parameterValue.Equals(expectedValue)) {
				return notification.GetNotifications();
			}
			return null;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns all notifications.
		/// </summary>
		/// <returns>Collection of the notification.</returns>
		public IEnumerable<INotificationInfo> GetAll() {
			lock (_locker) {
				IEnumerable<INotificationInfo> result =
					GetNotificationInfos((INotification notification) =>
						notification.GetNotifications());
				return result;
			}
		}

		/// <summary>
		/// Returns notifications by name.
		/// </summary>
		/// <param name="name">Name of the notification.</param>
		/// <returns>Collection of the notification.</returns>
		public IEnumerable<INotificationInfo> GetByName(string name) {
			if (string.IsNullOrEmpty(name)) {
				throw new ArgumentNullOrEmptyException("name");
			}
			lock (_locker) {
				IEnumerable<INotificationInfo> result = GetNotificationInfos((INotification notification) =>
					GetNotificationInfosByEqualsParameter(notification.Name, name, notification));
				return result;
			}
		}

		/// <summary>
		/// Returns notifications by group name.
		/// </summary>
		/// <param name="group">Group name of the notification.</param>
		/// <returns>Collection of the notification.</returns>
		public IEnumerable<INotificationInfo> GetByGroup(string group) {
			if (string.IsNullOrEmpty(group)) {
				throw new ArgumentNullOrEmptyException("group");
			}
			lock (_locker) {
				IEnumerable<INotificationInfo> result = GetNotificationInfos((INotification notification) =>
					GetNotificationInfosByEqualsParameter(notification.Group, group, notification));
				return result;
			}
		}

		#endregion

	}
}

