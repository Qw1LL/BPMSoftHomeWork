namespace BPMSoft.Configuration.Omnichannel.Messaging
{

	#region Interface: IIncomingMessageNotifier

	/// <summary>
	/// Represents interface for listening incoming messages. 
	/// </summary>
	public interface IIncomingMessageListener
	{

		#region Methods: Public

		/// <summary>
		/// Performs action on incoming message.
		/// </summary>
		/// <param name="message">Incoming message.</param>
		void Update(MessagingMessage message);

		#endregion

	}

	#endregion

}
