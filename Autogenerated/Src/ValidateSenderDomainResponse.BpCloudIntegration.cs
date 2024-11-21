namespace BPMSoft.Configuration.CESModels
{
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: ValidateSenderDomainResponse

	/// <summary>
	/// Represents response of the service for retrieving domains for sending email.
	/// </summary>
	public class ValidateSenderDomainResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the domain.
		/// </summary>
		[DataMember(Name = "senderDomainInfos")]
		public List<SenderDomainInfo> SenderDomainInfos { get; set; }

		#endregion

	}

	#endregion

	#region Class: SenderDomainInfo

	/// <summary>
	/// Represents response of the service for retrieving domains for sending email.
	/// </summary>
	public class SenderDomainInfo
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets the domain.
		/// </summary>
		public string Domain { get; set; }

		/// <summary>
		/// Returns true if the sender domain is valid.
		/// </summary>
		public bool IsValid { get; set; }

		#endregion

	}

	#endregion

}

