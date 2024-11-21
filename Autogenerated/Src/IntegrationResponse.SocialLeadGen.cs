namespace BPMSoft.Configuration.SocialLeadGen
{
	using System.Runtime.Serialization;

	#region Class: IntegrationListResponse

	/// <summary>
	/// Cloud response DTO with information of integration.
	/// </summary>
	[DataContract]
	public class IntegrationResponse : SocialLeadGenRestProviderResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets integration list.
		/// </summary>
		[DataMember(Name = "integrationData")]
		public Integration IntegrationData { get; set; }

		#endregion

	}

	#endregion

}

