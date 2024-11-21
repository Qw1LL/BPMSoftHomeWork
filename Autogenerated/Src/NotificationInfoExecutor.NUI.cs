namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: NotificationInfoExecutor

	/// <summary>
	/// Class for notification execution.
	/// </summary>
	[Obsolete("7.16.2 | Class will be removed after delete feature 'NotificationsOnOneClassJob'.")]
	public class NotificationInfoExecutor : INotificationInfoExecutor
	{
		
		#region Constants: Private
		
		private const string EXECUTE_TYPE_ALL = "All";
		private const string EXECUTE_TYPE_BY_NAME = "byName";
		private const string EXECUTE_TYPE_BY_GROUP = "byGroup";
		
		#endregion
		
		#region Fields: Private

		private readonly IDictionary<string, object> _parameters;
		private readonly UserConnection _userConnection;

		#endregion

		#region Constructors: Public

		public NotificationInfoExecutor(UserConnection userConnection, INotificationRepository repository, List<INotificationInfoHandler> handlers)
			: this(userConnection, repository, handlers, null) {
		}

		public NotificationInfoExecutor(UserConnection userConnection, INotificationRepository repository, List<INotificationInfoHandler> handlers, IDictionary<string, object> parameters) {
			bool isParametersValid = CheckParameters(parameters);
			if (repository == null || handlers == null) {
				throw new ArgumentNullOrEmptyException();
			}
			if (!isParametersValid) {
				throw new KeyNotFoundException();
			}
			_userConnection = userConnection;
			_repository = repository;
			_handlers = handlers;
			_parameters = parameters;
		}

		#endregion

		#region Properties: Protected

		private readonly List<INotificationInfoHandler> _handlers;
		protected List<INotificationInfoHandler> Handlers {
			get { return _handlers; }
		}

		private readonly INotificationRepository _repository;
		protected INotificationRepository Repository {
			get { return _repository; }
		}

		#endregion

		#region Methods: Private

		private bool CheckParameters(IDictionary<string, object> parameters) {
			return parameters == null || (parameters.Keys.Contains("type") && parameters.Keys.Contains("typeParameter"));
		}

		private string GetExecuteType() {
			object executeType = EXECUTE_TYPE_ALL;
			if (_parameters != null) {
				_parameters.TryGetValue("type", out executeType);
			}
			return (string)executeType;
		}

		private string GetExecuteTypeParameter() {
			object executeTypeParameter = string.Empty;
			if (_parameters != null) {
				_parameters.TryGetValue("typeParameter", out executeTypeParameter);
			}
			return (string)executeTypeParameter;
		}
		
		private IEnumerable<INotificationInfo> GetNotificationInfos() {
			string type = GetExecuteType();
			string typeParameter = GetExecuteTypeParameter();
			IEnumerable<INotificationInfo> notificationInfos = null;
			switch (type) {
				case EXECUTE_TYPE_ALL:
					notificationInfos = Repository.GetAll();
					break;
				case EXECUTE_TYPE_BY_NAME:
					notificationInfos = Repository.GetByName(typeParameter);
					break;
				case EXECUTE_TYPE_BY_GROUP:
					notificationInfos = Repository.GetByGroup(typeParameter);
					break;
				default:
					break;
			}
			return notificationInfos;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes notification.
		/// </summary>
		/// <returns>Returns execution status.</returns>
		public bool Execute() {
			IEnumerable<INotificationInfo> notificationInfos = GetNotificationInfos();
			if (notificationInfos != null && !notificationInfos.IsEmpty()) {
				IEnumerable<Guid> users = NotificationInfoUtilities.GetUsers(ref notificationInfos, _userConnection);
				foreach (INotificationInfoHandler handler in Handlers) {
					handler.HandleInfo(notificationInfos, users);
				}
				return true;
			}
			return false;
		}

		#endregion

	}

	#endregion

}

