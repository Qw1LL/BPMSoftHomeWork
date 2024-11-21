namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Nui.ServiceModel.DataContract;
	using System.Runtime.Serialization;

	#region Class: CampaignConfigurationServiceResponse

	/// <summary>
	/// Contract for campaign service response.
	/// </summary>
	[DataContract]
	public class CampaignConfigurationServiceResponse : ConfigurationServiceResponse
	{

		#region Constructors: Public

		/// <summary>
		/// Default constructor to create instance of CampaignConfigurationServiceResponse.
		/// </summary>
		public CampaignConfigurationServiceResponse() {
			WarningInfo = new WarningInfo();
		}

		/// <summary>
		/// Create instance of CampaignConfigurationServiceResponse with error info based on exception.
		/// </summary>
		public CampaignConfigurationServiceResponse(Exception e) : base(e) {
			WarningInfo = new WarningInfo();
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Warning object.
		/// </summary>
		[DataMember(Name = "warningInfo")]
		public WarningInfo WarningInfo {
			get;
			set;
		}

		#endregion

	}

	#endregion

}

