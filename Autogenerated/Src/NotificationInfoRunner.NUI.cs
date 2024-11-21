namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Reflection;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: NotificationInfoRunner

	/// <summary>
	/// Class of the data service for notification information.
	/// </summary>
	[Obsolete("7.16.2 | Class will be removed after delete feature 'NotificationsOnOneClassJob'.")]
	public class NotificationInfoRunner
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private readonly IDictionary<string, object> _parameters;
		private INotificationRepository _repository;
		private List<INotificationInfoHandler> _handlers;

		#endregion

		#region Constructors: Public

		public NotificationInfoRunner(UserConnection userConnection)
			: this(userConnection, null) {
		}

		public NotificationInfoRunner(UserConnection userConnection, IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			_parameters = parameters;
		}

		#endregion

		#region Methods: Private

		private void InitializeClasses() {
			var store = ClassFactory.ForceGet<INotificationStore>(GetName<NotificationStore>());
			var factory = ClassFactory.ForceGet<INotificationFactory>(
				GetName<NotificationFactory>(),
				new ConstructorArgument("userConnection", _userConnection));
			_repository = ClassFactory.ForceGet<INotificationRepository>(
				GetName<NotificationRepository>(),
				new ConstructorArgument("store", store),
				new ConstructorArgument("factory", factory));
		}

		private void InitializeHandlers() {
			_handlers = new List<INotificationInfoHandler>();
			Assembly assembly = _userConnection.AppConnection.Workspace.WorkspaceAssembly;
			Type handlerType = typeof(INotificationInfoHandler);
			foreach (Type type in assembly.GetTypes()) {
				if (handlerType.IsAssignableFrom(type) && type != handlerType && type != typeof(BaseNotificationInfoHandler)) {
					_handlers.Add(
						ClassFactory.ForceGet<INotificationInfoHandler>(type.AssemblyQualifiedName,
							new ConstructorArgument("userConnection", _userConnection),
							new ConstructorArgument("parameters", _parameters))
					);
				}
			}
		}

		private INotificationInfoExecutor GetExecutor() {
			return ClassFactory.ForceGet<INotificationInfoExecutor>(GetName<NotificationInfoExecutor>(),
				new ConstructorArgument("userConnection", _userConnection),
				new ConstructorArgument("repository", _repository),
				new ConstructorArgument("handlers", _handlers),
				new ConstructorArgument("parameters", _parameters));
		}

		private string GetName<T>()
			where T : class {
			return typeof(T).AssemblyQualifiedName;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Runs publication notification information.
		/// </summary>
		public void Run() {
			if (!_userConnection.GetIsFeatureEnabled("NotificationsOnOneClassJob")) {
				return;
			}
			InitializeClasses();
			InitializeHandlers();
			INotificationInfoExecutor executor = GetExecutor();
			executor.Execute();
		}

		#endregion
	}

	#endregion

}

