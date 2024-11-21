namespace BPMSoft.Configuration.Omnichannel.Messaging
{

	#region Interface: IIncomingMessageNotifier

	/// <summary>
	/// Represents interface for notifing listeners about new message.
	/// </summary>
	public interface IIncomingMessageNotifier
	{
		#region Methods: Public

		/// <summary>
		/// Adds new listener.
		/// </summary>
		/// <param name="listener">Message listener.</param>
		void AddListener(IIncomingMessageListener listener);

		/// <summary>
		/// Removes listener.
		/// </summary>
		/// <param name="listener">Message listener.</param>
		void RemoveListener(IIncomingMessageListener listener);

		/// <summary>
		/// Notifies listeners.
		/// </summary>
		/// <param name="message">Incoming message.</param>
		void NotifyListeners(MessagingMessage message);

		#endregion

	}

	#endregion

}
