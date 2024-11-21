namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.Linq;
	using System.Reflection;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Web.Common;
	using global::Common.Logging;

	#region Class: FailoverHandlerDispatcher

	/// <summary>
	/// Represents methods to initialize failover handlers.
	/// </summary>
	public class FailoverHandlerDispatcher : IAppEventListener
	{

		#region Fields: Private

		private UserConnection _userConnection;
		private static readonly ILog _log = LogManager.GetLogger("Common");

		#endregion
		
		#region Constructors: Public
		
		/// <summary>
		/// Default constructor.
		/// </summary>
		public FailoverHandlerDispatcher() {
		}

		/// <summary>
		/// Instantiates class with defined user connection.
		/// </summary>
		/// <param name="userConnection"></param>
		public FailoverHandlerDispatcher(UserConnection userConnection) : this() {
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets or sets the failover handler types.
		/// </summary>
		private ICollection<IFailoverHandler> _failoverHandlers;
		public ICollection<IFailoverHandler> FailoverHandlers {
			get {
				if (_failoverHandlers == null) {
					_failoverHandlers = GetInstances();
				}
				return _failoverHandlers;
			}
			set {
				_failoverHandlers = value;
			}
		}

		#endregion

		#region Methods: Private

		private void SetUserConnection(AppEventContext context) {
			if (_userConnection == null) {
				var appConection = context.Application["AppConnection"] as AppConnection;
				_userConnection = appConection.SystemUserConnection;
			}
		}

		private Assembly GetWorkspaceAssembly() {
			if (_userConnection != null && _userConnection.Workspace.IsWorkspaceAssemblyInitialized) {
				return _userConnection.Workspace.WorkspaceAssembly;
			}
			return null;
		}

		private bool TryGetTypes(out ICollection<Type> types) {
			types = null;
			Assembly assembly = GetWorkspaceAssembly();
			if (assembly == null) {
				return false;
			}
			Type baseType = typeof(IFailoverHandler);
			try {
				types = assembly.GetTypes().Where(baseType.IsAssignableFrom)
					.Where(x => x.IsClass && !x.IsAbstract).ToList();
			} catch (ReflectionTypeLoadException exception) {
				var message = GetLczStringValue("FailoverHandlerDispatcher", "GetFailoverHandlerTypesError");
				_log.Error(message, exception);
				return false;
			}
			return true;
		}

		private IFailoverHandler CreateInstance(Type type) {
			return Activator.CreateInstance(type) as IFailoverHandler;
		}

		private ICollection<IFailoverHandler> GetInstances() {
			var instances = new Collection<IFailoverHandler>();
			ICollection<Type> types;
			if (TryGetTypes(out types)) {
				foreach (Type type in types) {
					try {
						IFailoverHandler handler = CreateInstance(type);
						if (handler != null) {
							instances.Add(handler);
						}
					} catch (Exception ex) {
						var message = GetLczStringValue("FailoverHandlerDispatcher", "CreateInstanceError");
						_log.ErrorFormat(message, ex, type.FullName);
					}
				}
			}
			return instances;
		}

		private string GetLczStringValue(string className, string lczStringName) {
			string localizableStringName = string.Format("LocalizableStrings.{0}.Value", lczStringName);
			var localizableString = new LocalizableString(
				_userConnection.Workspace.ResourceStorage, className, localizableStringName);
			string value = localizableString.Value;
			if (value == null) {
				value = localizableString.GetCultureValue(GeneralResourceStorage.DefCulture, false);
			}
			return value;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules jobs for failover handlers if not exist.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnAppStart(AppEventContext context) {
			SetUserConnection(context);
			foreach (IFailoverHandler handler in FailoverHandlers) {
				try {
					handler.CreateJob(_userConnection);
				} catch (Exception ex) {
					string typeName = handler.GetType().FullName;
					var message = GetLczStringValue("FailoverHandlerDispatcher", "CallCreateJobError");
					_log.ErrorFormat(message, ex, typeName);
				}
			}
		}

		/// <summary>
		/// OnAppEnd empty handler.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnAppEnd(AppEventContext context) {
			//Do nothing for this package yet.
		}

		/// <summary>
		/// OnSessionStart empty handler.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnSessionStart(AppEventContext context) {
			//Do nothing for this package yet.
		}

		/// <summary>
		/// OnSessionEnd empty handler.
		/// </summary>
		/// <param name="context">Instance of <see cref="AppEventContext"/>.</param>
		public void OnSessionEnd(AppEventContext context) {
			//Do nothing for this package yet.
		}

		#endregion

	}

	#endregion

}
