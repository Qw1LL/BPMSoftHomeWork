namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: PushNotification

	/// <summary>
	/// Push notification.
	/// </summary>
	public class PushNotification
	{
		#region Constructors: Public

		public PushNotification(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;

		#endregion

		#region Methods: Protected

		protected virtual IPushNotificationProvider CreateProviderInstance(string className, string settings) {
			Type classType = Type.GetType(className);
			IPushNotificationProvider providerInstance = null;
			if (classType != null) {
				string assemblyQualifiedName = classType.AssemblyQualifiedName;
				providerInstance = ClassFactory.ForceGet<IPushNotificationProvider>(assemblyQualifiedName,
					new ConstructorArgument("settings", settings));
			}
			return providerInstance;
		}

		#endregion

		#region Methods: Public
		
		public virtual void Send(Guid sysAdminUnitId, string title, string message) {
			Send(sysAdminUnitId, title, message, null);
		}

		public virtual void Send(Guid sysAdminUnitId, string title, string message, Dictionary<string, string> additionalData) {
			if (!_userConnection.GetIsFeatureEnabled("UseMobilePushNotifications")) {
				return;
			}
			EntitySchema schema = _userConnection.EntitySchemaManager.GetInstanceByName("PushNotificationToken");
			var esq = new EntitySchemaQuery(schema);
			EntitySchemaQueryColumn tokenColumn = esq.AddColumn("Token");
			EntitySchemaQueryColumn settingsColumn = esq.AddColumn("=Service.Settings");
			EntitySchemaQueryColumn classNameColumn = esq.AddColumn("=Service.ClassName");
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "SysAdminUnit.Id", sysAdminUnitId));
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Service.Enabled", true));
			esq.IsDistinct = true;
			EntityCollection entityCollection = esq.GetEntityCollection(_userConnection);
			var providers = new Dictionary<string, IPushNotificationProvider>();
			foreach (var item in entityCollection) {
				var token = item.GetTypedColumnValue<string>(tokenColumn.Name);
				var settings = item.GetTypedColumnValue<string>(settingsColumn.Name);
				var className = item.GetTypedColumnValue<string>(classNameColumn.Name);
				IPushNotificationProvider providerInstance = null;
				if (!providers.ContainsKey(className)) {
					providerInstance = CreateProviderInstance(className, settings);
					providers.Add(className, providerInstance);
				} else {
					providers.TryGetValue(className, out providerInstance);
				}
				var data = new PushNotificationData() {
					Token = token,
					Title = title,
					Message = message,
					AdditionalData = additionalData
				};
				providerInstance.Send(data);
			}
		}

		#endregion

	}

	#endregion

}
