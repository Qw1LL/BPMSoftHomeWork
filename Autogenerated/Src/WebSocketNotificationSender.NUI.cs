namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Messaging.Common;

	#region Class: WebSocketNotificationSender

	public class WebSocketNotificationSender : INotificationHandler
	{
		#region Constants: Private

		private const string SENDER = "NotificationInfo";

		#endregion

		#region Fields: Private

		private readonly MsgChannelManager _channelManager;
		private readonly string _bodyTypeName;
		private UserConnection _userConnection;

		#endregion

		#region Construstors: Public

		public WebSocketNotificationSender(UserConnection userConnection): this(userConnection, string.Empty) {
		}

		public WebSocketNotificationSender(UserConnection userConnection, string bodyTypeName) {
			_userConnection = userConnection;
			_channelManager = MsgChannelManager.Instance;
			_bodyTypeName = bodyTypeName;
		}

		#endregion

		#region Methods: Private

		private IMsgChannel GetSysAdminUnitChannel(Guid sysAdminUnit) {
			return _channelManager.FindItemByUId(sysAdminUnit);
		}

		private DateTime RoundDateToSeconds(DateTime dateSource) {
			return dateSource.AddTicks(TimeSpan.TicksPerSecond - (dateSource.Ticks % TimeSpan.TicksPerSecond));
		}

		private DateTime GetLastRemindTime(Guid sysAdminUnitId) {
			var sysAdminUniDateTime = NotificationUtilities.GetSysAdminUnitLocalDateTime(_userConnection, sysAdminUnitId);
			return RoundDateToSeconds(sysAdminUniDateTime);
		}

		private NotificationInfoResponse GetNotificationInfoResponse(IEnumerable<INotificationInfo> notifications) {
			var counters = notifications.Where(n => n.GroupName.IsNotEmpty())
				.GroupBy(n => n.GroupName)
				.Select(group => new {
					group.Key,
					Count = group.Count()
				}).ToDictionary(x => x.Key, x => x.Count);

			var notificationInfoResponse = new NotificationInfoResponse {
				Counters = counters,
				Notifications = notifications
			};
			if (_userConnection.GetIsFeatureEnabled("UseDateForNotificationsQuery") && notifications.Any()) {
				notificationInfoResponse.LastRemindTime =
					GetLastRemindTime(notifications.First().SysAdminUnit);
			}
			return notificationInfoResponse;
		}

		private IMsg GetChannelMessage(Guid sysAdminUnit, NotificationInfoResponse messageBody) {
			var message = new SimpleMessage {
				Id = sysAdminUnit,
				Body = messageBody,
				Header = {
					Sender = SENDER,
					BodyTypeName = _bodyTypeName
				}
			};
			return message;
		}

		private void SendMessage(Guid sysAdminUnitId, NotificationInfoResponse messageBody) {
			IMsgChannel channel = GetSysAdminUnitChannel(sysAdminUnitId);
			if (channel == null) {
				return;
			}
			IMsg message = GetChannelMessage(sysAdminUnitId, messageBody);
			channel.PostMessage(message);
		}

		#endregion

		#region Methods: Public

		public void Handle(IEnumerable<INotificationInfo> notifications) {
			notifications.CheckArgumentNullOrEmpty("notifications");
			var notificationGroups = notifications.GroupBy(g => g.SysAdminUnit);
			foreach (var notificationGroup in notificationGroups) {
				var messageBody = GetNotificationInfoResponse(notificationGroup.ToList());
				SendMessage(notificationGroup.Key, messageBody);
			}
		}

		#endregion
	}

	#endregion

}
