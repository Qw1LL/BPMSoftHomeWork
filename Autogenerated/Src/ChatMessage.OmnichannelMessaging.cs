namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using OmnichannelProviders.Domain.Entities;
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	/// <summary>
	/// Class container for chat messages.
	/// </summary>
	[DataContract]
	public class ChatMessage
	{
		[DataMember(Name = "id")]
		public Guid Id;

		[DataMember(Name = "author")]
		public ChatContact Author;

		[DataMember(Name = "time")]
		public string Time;

		[DataMember(Name = "text")]
		public string Text;

		[DataMember(Name = "direction")]
		public MessageDirection Direction;

		[DataMember(Name = "type")]
		public MessageType Type;

		[DataMember(Name = "attachments")]
		public List<MessageAttachment> Attachments;

		[DataMember(Name = "isBotMessage")]
		public bool IsBotMessage;
	}
}
