namespace BPMSoft.Configuration.CESModels
{
	using System;
	using System.Runtime.Serialization;

	#region Class: ValidateSenderDomainRequest

	/// <summary>
	/// Class for request to validate sender domain.
	/// </summary>
	[DataContract]
	public class ValidateSenderDomainRequest
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the email identifier.
		/// </summary>
		[DataMember(Name = "emailId")]
		public Guid EmailId { get; set; }

		/// <summary>
		/// Gets or sets the sender domains.
		/// </summary>
		[DataMember(Name = "senderDomains")]
		public string[] SenderDomains { get; set; }

		/// <summary>
		/// Gets or sets the name of the provider.
		/// </summary>
		[DataMember(Name = "providerName")]
		public string ProviderName { get; set; }

		#endregion

	}

	#endregion

}

