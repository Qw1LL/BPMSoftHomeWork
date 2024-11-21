namespace BPMSoft.Configuration.SocialLeadGen
{

	#region Class: IntegrationRequest

	/// <summary>
	/// Cloud request DTO with information of integration.
	/// </summary>
	public class IntegrationRequest : SocialLeadGenRestProviderResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets integration list.
		/// </summary>
		public Integration IntegrationData { get; set; }

		#endregion

	}

	#endregion

}

