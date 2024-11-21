namespace BPMSoft.Configuration.SocialLeadGen
{
	using System.Collections.Generic;

	#region Class: IntegrationListResponse

	/// <summary>
	/// Cloud response DTO with information of integration list.
	/// </summary>
	public class IntegrationListResponse : SocialLeadGenRestProviderResponse
	{

		#region Properties: Public

		/// <summary>
		/// Gets or sets integration list.
		/// </summary>
		public List<Integration> Integrations { get; set; }

		#endregion

	}

	#endregion

}

