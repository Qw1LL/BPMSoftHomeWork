namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;

	#region Class: PushNotificationInfoHandler

	/// <summary>
	/// Class that sends push notifications handling notifications.
	/// </summary>
	[Obsolete("7.16.2 | Class is obsolete, use BPMSoft.Configuration.PushNotificationSender instead.")]
	public class PushNotificationInfoHandler : BaseNotificationInfoHandler, INotificationHandler
	{

		#region Constants: Private

		private const string ENABLE_PUSHSERVICE_FEATURE_CODE = "UseMobilePushNotifications";
		private const string ENABLE_HANDLER_FEATURE_CODE = "SendPushByNotifications";

		#endregion

		#region Fields: Private

		private bool? _isFeatureEnabled;
		private readonly PushNotificationSender _pushNotificationSender;

		#endregion

		#region Construstors: Public

		public PushNotificationInfoHandler(UserConnection userConnection)
			: this(userConnection, null) {
		}

		public PushNotificationInfoHandler(UserConnection userConnection,
				IDictionary<string, object> parameters)
			: base(userConnection, parameters) {
			_pushNotificationSender = new PushNotificationSender(userConnection, GetPushNotification);
		}

		#endregion

		#region Methods: Private

		private bool GetIsFeatureEnabled() {
			if (_isFeatureEnabled == null) {
				_isFeatureEnabled = _userConnection.GetIsFeatureEnabled(ENABLE_PUSHSERVICE_FEATURE_CODE) &&
					_userConnection.GetIsFeatureEnabled(ENABLE_HANDLER_FEATURE_CODE);
			}
			return _isFeatureEnabled == true;
		}

		#endregion

		#region Methods: Protected

		protected virtual PushNotification GetPushNotification() {
			return new PushNotification(_userConnection);
		}

		protected override void HandleInfo() {
			if (GetIsFeatureEnabled()) {
				lock (_locker) {
					foreach (INotificationInfo info in _notificationInfo) {
						_pushNotificationSender.SendPushNotification(info);
					}
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Processes notifications.
		/// </summary>
		/// <param name="notifications">Collection of the notifications.</param>
		public void Handle(IEnumerable<INotificationInfo> notifications) {
			_pushNotificationSender.Handle(notifications);
		}
		
		#endregion
	}

	#endregion

}

