namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;

	#region Class: BaseNotificationInfoHandler

	/// <summary>
	/// Base class for handling notification information.
	/// </summary>
	[Obsolete("Will be removed after 7.12.2")]
	public abstract class BaseNotificationInfoHandler : INotificationInfoHandler
	{
		
		#region Fields: Protected

		protected readonly object _locker;
		protected readonly UserConnection _userConnection;
		protected IEnumerable<INotificationInfo> _notificationInfo;
		protected IEnumerable<Guid> _userIds;
		protected IDictionary<string, object> _parameters;

		#endregion

		#region Construstors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="BaseNotificationInfoHandler"/> class.
		/// </summary>
		public BaseNotificationInfoHandler(UserConnection userConnection, 
				IDictionary<string, object> parameters) {
			_userConnection = userConnection;
			_parameters = parameters;
			_locker = new object();
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Handles notification information.
		/// </summary>
		protected abstract void HandleInfo();

		#endregion

		#region Methods: Public

		/// <summary>
		/// Initializers fields and handles notification information.
		/// </summary>
		/// <param name="informations">Collection of informations.</param>
		/// <param name="userIds">Collection of ids from SysAdminUnit.</param>
		public virtual void HandleInfo(IEnumerable<INotificationInfo> informations, IEnumerable<Guid> userIds) {
			informations.CheckArgumentNullOrEmpty("infos");
			_notificationInfo = informations;
			_userIds = userIds;
			HandleInfo();
		}

		#endregion

	}

	#endregion

}

