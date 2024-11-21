namespace BPMSoft.Configuration
{
	using System.Collections.Generic;
	using System;
	using System.Linq;
	using System.Reflection;
	using BPMSoft.Core;
	using BPMSoft.Core.Store;

	#region Class: NotificationStore

	public class NotificationStore : INotificationStore
	{

		#region Constants: Private

		private const string STORE_KEY = "NotificationCollection";

		#endregion

		#region Fields: Private

		private string[] _notificationProvidersName;
		private readonly object _locker = new object();
		private readonly ICacheStore _store;

		#endregion

		#region Constructors: Public

		public NotificationStore() {
			_store = Store.Cache[CacheLevel.Application];
			_notificationProvidersName = _store.GetValue<string[]>(STORE_KEY);
		}

		#endregion

		#region Properties: Private

		private string[] NotificationProvidersName {
			get {
				if (_notificationProvidersName == null) {
					_notificationProvidersName = GetNotificationProvidersNameByAssembly();
					SaveToCacheStore();
				}
				return _notificationProvidersName;
			}
		}

		#endregion

		#region Methods: Private

		private void SaveToCacheStore() {
			_store[STORE_KEY] = _notificationProvidersName;
		}

		private string[] GetNotificationProvidersNameByAssembly() {
			Type classType = typeof(INotification);
			IEnumerable<Type> types;
			try {
				var assembly = Assembly.GetAssembly(classType);
				types = assembly.GetTypes();
			} catch (ReflectionTypeLoadException e) {
				types = e.Types.Where(t => t != null);
			}
			IEnumerable<Type> typesByInterface = GetTypesByInterface(types, classType);
			IEnumerable<Type> typesWithConstructor = GetTypesWithConstructor(typesByInterface);
			IEnumerable<string> classesName = typesWithConstructor.Select(type => type.FullName);
			return classesName.ToArray();
		}

		private IEnumerable<Type> GetTypesByInterface(IEnumerable<Type> types, Type classType) {
			return types
				.Where(type => type.GetInterfaces().Contains(classType));
		}

		private IEnumerable<Type> GetTypesWithConstructor(IEnumerable<Type> types) {
			return types.Where(type => type.GetConstructor(new[] {
				typeof(UserConnection)
			}) != null);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns names of notification providers.
		/// </summary>
		/// <returns>List of names.</returns>
		public IEnumerable<string> GetNotificationProvidersName() {
			lock (_locker) {
				return NotificationProvidersName;
			}
		}

		#endregion

	}

	#endregion
}
