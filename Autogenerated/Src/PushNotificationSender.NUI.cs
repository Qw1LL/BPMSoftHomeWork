namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Common;

	#region Class: PushNotificationSender

	/// <summary>
	/// Class that sends push notifications handling notifications.
	/// </summary>
	public class PushNotificationSender : INotificationHandler
	{

		#region Constants: Private

		private const string ENABLE_PUSHSERVICE_FEATURE_CODE = "UseMobilePushNotifications";
		private const string ENABLE_HANDLER_FEATURE_CODE = "SendPushByNotifications";
		private const string HISTORY_ENTITY_SCHEMA_NAME = "PushNotificationHistory";

		#endregion

		#region Fields: Private

		private bool? _isFeatureEnabled;
		private UserConnection _userConnection;
		private readonly object _locker;
		private readonly Func<PushNotification> _createPushNotification;

		#endregion

		#region Construstors: Private

		private PushNotificationSender(UserConnection userConnection, object locker) {
			_userConnection = userConnection;
			_locker = locker;
		}

		#endregion

		#region Construstors: Public

		public PushNotificationSender(UserConnection userConnection) : this(userConnection, new object()) {
			_createPushNotification = GetPushNotification;
		}

		public PushNotificationSender(UserConnection userConnection, Func<PushNotification> createPushNotificationDelegate)
			: this(userConnection, new object ()) {
			_createPushNotification = createPushNotificationDelegate;
		}

		#endregion

		#region Methods: Private

		private bool GetIsFeatureDisabled() {
			if (_isFeatureEnabled == null) {
				_isFeatureEnabled = _userConnection.GetIsFeatureEnabled(ENABLE_PUSHSERVICE_FEATURE_CODE) &&
					_userConnection.GetIsFeatureEnabled(ENABLE_HANDLER_FEATURE_CODE);
			}
			return _isFeatureEnabled != true;
		}

		#endregion

		#region Methods: Private

		private bool GetIsMessageSent(string messageId, string sysAdminUnitId, DateTime remindTime) {
			string entitySchemaName = HISTORY_ENTITY_SCHEMA_NAME;
			var query = new Select(_userConnection)
					.Column(Func.Count(entitySchemaName, "Id"))
				.From(entitySchemaName)
				.Where(entitySchemaName, "MessageId").IsEqual(Column.Parameter(messageId))
				.And(entitySchemaName, "SysAdminUnitId").IsEqual(Column.Parameter(sysAdminUnitId)
			) as Select;
			if (remindTime != default) {
				query.And(entitySchemaName, "RemindTime").IsEqual(Column.Parameter(remindTime));
			}
			var result = query.ExecuteScalar<int>();
			return result != 0;
		}

		private void SaveMessageInHistory(string messageId, string sysAdminUnitId, DateTime remindTime) {
			var insert = new Insert(_userConnection).Into(HISTORY_ENTITY_SCHEMA_NAME)
				.Set("MessageId", Column.Parameter(messageId))
				.Set("SysAdminUnitId", Column.Parameter(sysAdminUnitId))
				.Set("RemindTime", Column.Parameter(remindTime));
			insert.Execute();
		}

		#endregion

		#region Methods: Protected

		protected virtual PushNotification GetPushNotification() {
			return new PushNotification(_userConnection);
		}

		#endregion

		#region Methods: Public

		public void SendPushNotification(INotificationInfo info) {
			PushNotification pushNotification = _createPushNotification();
			var additionalData = new Dictionary<string, string>();
			string messageId = info.MessageId.ToString();
			Guid sysAdminUnit = info.SysAdminUnit;
			string sysAdminUnitId = sysAdminUnit.ToString();
			if (!GetIsMessageSent(messageId, sysAdminUnitId, info.RemindTime)) {
				additionalData.Add("entityName", info.EntitySchemaName);
				additionalData.Add("recordId", info.EntityId.ToString());
				additionalData.Add("messageId", messageId);
				DateTime remindTime = info.RemindTime;
				additionalData.Add("remindTime", remindTime.ToString(@"dd.MM.yyyy HH:mm"));
				pushNotification.Send(sysAdminUnit, info.Title, info.Body, additionalData);
				SaveMessageInHistory(messageId, sysAdminUnitId, remindTime);
			}
		}

		/// <summary>
		/// Processes notifications.
		/// </summary>
		/// <param name="notifications">Collection of the notifications.</param>
		public void Handle(IEnumerable<INotificationInfo> notifications) {
			notifications.CheckArgumentNullOrEmpty("notifications");
			if (GetIsFeatureDisabled()) {
				return;
			}
			lock (_locker) {
				foreach (var info in notifications) {
					SendPushNotification(info);
				}
			}
		}

		#endregion

	}

	#endregion

}

