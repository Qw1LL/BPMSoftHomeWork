namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;

	public class ImplementedNotificationProviderHelper
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly INotificationStore _notificationStore;

		#endregion

		#region Contructors: Public

		public ImplementedNotificationProviderHelper(UserConnection userConnection,
			INotificationStore notificationStore) {
			_userConnection = userConnection;
			_notificationStore = notificationStore;
		}

		#endregion

		#region Methods: Private

		private IDictionary<string, NotificationProviderType> GetRegisteredProvider() {
			var result = new Dictionary<string, NotificationProviderType>();
			Select select = GetRegisteredProviderSelect();
			using (var dbExecutor = _userConnection.EnsureDBConnection()) {
				using (var dataReader = select.ExecuteReader(dbExecutor)) {
					int columnClassName = dataReader.GetOrdinal("ClassName");
					int columnType = dataReader.GetOrdinal("Type");
					while (dataReader.Read()) {
						string className = dataReader.GetString(columnClassName);
						int type = dataReader.GetInt32(columnType);
						result.Add(className, (NotificationProviderType)type);
					}
				}
			}
			return result;
		}

		private Select GetRegisteredProviderSelect() {
			return new Select(_userConnection)
				.Distinct()
				.Column("NotificationProvider", "ClassName")
				.Column("NotificationProvider", "Type")
				.From("NotificationProvider");
		}

		private IEnumerable<string> GetImplementedProvidersName() {
			return _notificationStore.GetNotificationProvidersName();
		}

		#endregion

		#region Methods: Public

		public bool IsUsedProviderNotImplementedNotification() {
			IDictionary<string, NotificationProviderType> notImplementedProviders = GetNotImplementedProviders();
			return notImplementedProviders.Any();
		}

		public IDictionary<string, NotificationProviderType> GetNotImplementedProviders() {
			IDictionary<string, NotificationProviderType> registeredProviders = GetRegisteredProvider();
			IEnumerable<string> implementedProvider = GetImplementedProvidersName();
			IDictionary<string, NotificationProviderType> notImplementedProvider = registeredProviders
				.Where(provider => !implementedProvider.Contains(provider.Key))
				.ToDictionary(provider => provider.Key, provider => provider.Value);
			return notImplementedProvider;
		}
	
		#endregion

	}
}
