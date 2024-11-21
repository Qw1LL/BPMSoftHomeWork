namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using global::Common.Logging;

	#region Class: NotificationFactory

	public class NotificationFactory : INotificationFactory
	{
		#region Fields: Private

		private readonly UserConnection _userConnection;
		private static readonly ILog _log = LogManager.GetLogger("Notifications");

		#endregion

		#region Construstors: Public

		public NotificationFactory(UserConnection userConnection) {
			_userConnection = userConnection;
		}

		#endregion

		#region Methods: Private

		private bool GetIsClassMarkedAsObsolete(Type classType) {
			object[] attributes = classType.GetCustomAttributes(typeof(ObsoleteAttribute), true);
			return !attributes.IsNullOrEmpty();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Creates instance by <paramref name = "className"/>.
		/// </summary>
		/// <param name="className">Name of class.</param>
		/// <returns>Instance of <paramref name = "className"/>.</returns>
		public INotification CreateInstance(string className) {
			Type classType = Type.GetType(className);
			if (classType == null || 
			    (_userConnection.GetIsFeatureEnabled("NotificationV2") && GetIsClassMarkedAsObsolete(classType))) {
				return null;
			}
			string assemblyQualifiedName = classType.AssemblyQualifiedName;
			try {
				return ClassFactory.ForceGet<INotification>(assemblyQualifiedName,
					new ConstructorArgument("userConnection", _userConnection));
			} catch (Exception ex) {
				_log.Error(ex.Message, ex);
			}
			return null;
		}

		#endregion
	}

	#endregion
}
