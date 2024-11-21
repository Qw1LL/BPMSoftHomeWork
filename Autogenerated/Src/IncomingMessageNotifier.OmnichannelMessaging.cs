namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System.Collections.Generic;
	using BPMSoft.Core.Factories;

	#region Class: IncomingMessageNotifier

	/// <summary>
	/// Represents class-notifier for notifing listeners about new message.
	/// </summary>
	[DefaultBinding(typeof(IIncomingMessageNotifier))]
	public class IncomingMessageNotifier : IIncomingMessageNotifier
	{
		#region Fields: Private

		private static List<IIncomingMessageListener> messageListeners;

		#endregion

		#region Constructors: Static
		static IncomingMessageNotifier() {
			messageListeners = new List<IIncomingMessageListener>();
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="BPMSoft.Configuration.Omnichannel.Messaging.IIncomingMessageNotifier" />
		public void AddListener(IIncomingMessageListener messageListener) {
			messageListeners.Add(messageListener);
		}

		/// <inheritdoc cref="BPMSoft.Configuration.Omnichannel.Messaging.IIncomingMessageNotifier" />
		public void RemoveListener(IIncomingMessageListener messageListener) {
			messageListeners.Remove(messageListener);
		}

		/// <inheritdoc cref="BPMSoft.Configuration.Omnichannel.Messaging.IIncomingMessageNotifier" />
		public void NotifyListeners(MessagingMessage message) {
			foreach (IIncomingMessageListener listener in messageListeners) {
				listener.Update(message);
			}
		}

		#endregion
	}

	#endregion

}
