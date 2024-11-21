namespace BPMSoft.Configuration.Omnichannel.Messaging
{
	using System;
	using System.Runtime.Serialization;
	using BPMSoft.Core.ServiceModelContract;

	/// <summary>
	/// Class container for chat contact data.
	/// </summary>
	[DataContract]
	public class ChatContact
	{
		[DataMember(Name = "id")]
		public Guid Id;
		[DataMember(Name = "name")]
		public string Name;
		[DataMember(Name = "photo")]
		public string Photo;
		[DataMember(Name = "email")]
		public string Email;
		[DataMember(Name = "account")]
		public LookupValue Account;
	}
}
