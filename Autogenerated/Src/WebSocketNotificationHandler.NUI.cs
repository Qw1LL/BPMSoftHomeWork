namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Newtonsoft.Json;
	using BPMSoft.Core;

	#region Class: WebSocketNotificationHandler

	[Obsolete("7.16.2 | Class is obsolete, use BPMSoft.Configuration.WebSocketNotificationSender instead.")]
	public class WebSocketNotificationHandler : BaseNotificationInfoHandler, INotificationHandler
	{
		#region Constants: Private

		private const string SENDER = "NotificationInfo";

		#endregion

		#region Fields: Private

		private WebSocketNotificationSender _webSocketNotificationSender;

		#endregion

		#region Construstors: Public

		public WebSocketNotificationHandler(UserConnection userConnection)
			: this(userConnection, null) {
		}

		public WebSocketNotificationHandler(UserConnection userConnection,
			IDictionary<string, object> parameters)
			: base(userConnection, parameters) {
			_webSocketNotificationSender = new WebSocketNotificationSender(userConnection, BodyTypeName);
		}

		#endregion

		#region Properties: Private

		private string _bodyTypeName;

		protected string BodyTypeName {
			get {
				if (_bodyTypeName == null) {
					object bodyTypeName = string.Empty;
					if (_parameters != null) {
						_parameters.TryGetValue("typeParameter", out bodyTypeName);
					}

					_bodyTypeName = (string) bodyTypeName;
				}

				return _bodyTypeName;
			}
		}

		#endregion

		#region Methods: Protected

		protected override void HandleInfo() {
			lock (_locker) {
				Handle(_notificationInfo);
			}
		}

		#endregion

		#region Methods: Public

		public void Handle(IEnumerable<INotificationInfo> notifications) {
			_webSocketNotificationSender.Handle(notifications);
		}

		#endregion
	}

	#endregion

	#region Class: NotificationInfoResponse

	[JsonObject(MemberSerialization.OptIn)]
	public class NotificationInfoResponse
	{
		[JsonProperty("Counters")]
		public IDictionary<string, int> Counters { get; set; }

		[JsonProperty("Notifications")]
		public IEnumerable<INotificationInfo> Notifications { get; set; }

		[JsonProperty("LastRemindTime")]
		public DateTime LastRemindTime { get; set; }

	}

	#endregion
}
