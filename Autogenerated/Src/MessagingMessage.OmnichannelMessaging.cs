namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: MessagingMessage

	/// <summary>
	/// DTO which represents unified message for messaging.
	/// </summary>
	[Serializable]
	[DataContract]
	public class MessagingMessage: UnifiedMessage
	{

		private string _channelName;
		/// <summary>
		/// Stores channel name for third-party developers.
		/// </summary>
		[DataMember]
		public string ChannelName { get {
				return string.IsNullOrEmpty(_channelName) ? Source.ToString() : _channelName;
			}
			set {
				_channelName = value;
			}
		}

		/// <summary>
		/// Represents unique identifier of contact that sends message.
		/// </summary>
		[DataMember]
		public Guid? ContactId { get; set; }

		/// <summary>
		/// Represents display value of contact that sends message.
		/// </summary>
		[DataMember]
		public string ContactDisplayValue { get; set; }

		/// <summary>
		/// Represents unique identifier`s of operators that assigned or pre-assigned to this message.
		/// </summary>
		[DataMember]
		public List<Guid> OperatorIds { get; set; }

		/// <summary>
		/// Represents unique identifier of Queue for that channel.
		/// </summary>
		[DataMember]
		public Guid ChannelQueueId { get; set; }

		/// <summary>
		/// Represents sender if is echo mode.
		/// </summary>
		public string SenderIfEcho { 
			get {
				return IsEcho ? Recipient : Sender;
			} 
		}

		#region Constructors: Public

		/// <summary>
		/// Initializes new instance of <see cref="MessagingMessage"/>.
		/// </summary>
		public MessagingMessage() {
		}


		/// <summary>
		/// Initializes new instance of <see cref="MessagingMessage"/>.
		/// </summary>
		/// <param name="unifiedmessage">Unified message.<see cref="UnifiedMessage"/></param>
		public MessagingMessage(UnifiedMessage unifiedmessage) {
			Sender = unifiedmessage.Sender;
			Recipient = unifiedmessage.Recipient;
			Message = unifiedmessage.Message;
			Timestamp = unifiedmessage.Timestamp;
			Source = unifiedmessage.Source;
			ChatId = unifiedmessage.ChatId;
			ChannelId = unifiedmessage.ChannelId;
			MessageDirection = unifiedmessage.MessageDirection;
			MessageType = unifiedmessage.MessageType;
			Attachments = unifiedmessage.Attachments;
			IsStandBy = unifiedmessage.IsStandBy;
			IsEcho = unifiedmessage.IsEcho;
			ContactIdentification = unifiedmessage.ContactIdentification;
			IsGuestUser = unifiedmessage.IsGuestUser;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Returns size of message in bytes.
		/// </summary>
		/// <returns>Size of message in bytes</returns>
		public long GetSize() {
			long size = string.IsNullOrEmpty(Message) ? 0 : Message.Length;
			if (Attachments != null) {
				Attachments.ForEach(a => size += a.Content == null ? 0 : a.Content.Length);
			}
			return size;
		}

		#endregion

	}

	#endregion

}
