namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using global::Common.Logging;
	using BPMSoft.Core;
	using BPMSoft.Common;
	using BPMSoft.Core.Factories;

	/// <summary>
	/// Provides sending notifications methods.
	/// </summary>
	public class NotificationSender : INotificationSender
	{
		#region Fields: Private

		private ILog _log;
		private IEnumerable<INotificationHandler> _handlers;

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		protected ILog Log => _log ?? (_log = LogManager.GetLogger("Notifications"));

		protected IEnumerable<INotificationHandler> Handlers {
			get {
				var args = new[] {
					new ConstructorArgument("userConnection", UserConnection)
				};
				return _handlers ?? (_handlers = ClassFactory.GetAll<INotificationHandler>(args));
			}
		}

		#endregion

		#region Construstors: Public

		public NotificationSender(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Sends notifications.
		/// </summary>
		/// <param name="notifications">The notification informations.</param>
		public void Send(IEnumerable<INotificationInfo> notifications) {
			if (notifications.IsEmpty()) {
				return;
			}
			foreach (var handler in Handlers) {
				try {
					handler.Handle(notifications);
				}
				catch (Exception e) {
					Log.Error(e);
				}
			}
		}

		#endregion
	}
}
