namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core;

	#region Class : EmailMacrosManagerFactory

	/// <summary>
	/// Manage instances of email managers for delayed notification.
	/// </summary>
	public class EmailMacrosManagerFactory
	{
		
		#region Fields: Private

		private Dictionary<string, EmailWithMacrosManager> _managerMap;

		#endregion

		#region Properties: Public

		/// <summary>
		/// E-mail sender which allows to control the flow of activity creating, filling and macroses processing.
		/// Instance of the <see cref="DefaultMacrosManager"/> class.
		/// </summary>
		protected EmailWithMacrosManager DefaultMacrosManager {	get; set; }

		/// <summary>
		/// User connection.
		/// </summary>
		public UserConnection UserConnection { get; }

		#endregion

		#region Constructors: Protected

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailMacrosManagerFactory"/> class.
		/// </summary>
		protected EmailMacrosManagerFactory() {
			_managerMap = new Dictionary<string, EmailWithMacrosManager>();
		}

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="EmailMacrosManagerFactory"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public EmailMacrosManagerFactory(UserConnection userConnection) 
				: this() {
			UserConnection = userConnection;
			DefaultMacrosManager = new EmailWithMacrosManager(UserConnection);
		}

		public EmailMacrosManagerFactory(UserConnection userConnection, EmailWithMacrosManager defaultManager) 
				: this() {
			UserConnection = userConnection;
			DefaultMacrosManager = defaultManager;
		}

		#endregion

		#region Methods: Private

		private bool IsEmailWithMacrosManagerType(string managerName) {
			var type = Type.GetType(managerName);
			return type != null && type.IsSubclassOf(typeof(EmailWithMacrosManager));
		}

		private EmailWithMacrosManager CreateManagerInstace(string managerName) {
			return ClassFactory.ForceGet<EmailWithMacrosManager>(managerName, 
				new ConstructorArgument("userConnection", UserConnection));
		}

		private EmailWithMacrosManager MapManager(string managerName) {
			EmailWithMacrosManager manager = DefaultMacrosManager;
			if (IsEmailWithMacrosManagerType(managerName)) {
				manager = CreateManagerInstace(managerName);
			}
			_managerMap.Add(managerName, manager);
			return manager;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Get instance of EmailManager from manager storage or create new instance.
		/// </summary>
		/// <param name="managerName">Class name.</param>
		protected EmailWithMacrosManager GetManagerInstance(string managerName) {
			return _managerMap.ContainsKey(managerName) ? _managerMap[managerName] : MapManager(managerName);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Get instance of EmailManager.
		/// </summary>
		/// <param name="managerName">Class name.</param>
		public EmailWithMacrosManager GetByTypeName(string managerName) {
			return GetManagerInstance(managerName);
		}

		#endregion
	}

	#endregion
}
