namespace BPMSoft.Configuration.ESN
{
	using System;
	using System.Runtime.Serialization;

	#region Class: EsnLikeDTO

	[DataContract]
	public class EsnLikeDTO
	{
		#region Properties: Public

		[DataMember(Name = "id")]
		public Guid Id { get; set; }

		[DataMember(Name = "socialMessageId")]
		public Guid SocialMessageId { get; set; }

		[DataMember(Name = "userId")]
		public Guid UserId { get; set; }

		[DataMember(Name = "contactId")]
		public Guid ContactId { get; set; }

		[DataMember(Name = "contactName")]
		public string ContactName { get; set; }

		[DataMember(Name = "contactPrimaryImageId")]
		public Guid ContactPrimaryImageId { get; set; }

		#endregion
	}

	#endregion
}
