namespace BPMSoft.Configuration.SocialLeadGen
{
	using System;

	#region Class: LandingInfoRestResponse

	/// <summary>
	/// Cloud response DTO with information about landing subscribtion.
	/// </summary>
	public class LandingInfoRestResponse : SocialLeadGenRestProviderResponse
	{

		#region Properties: Public

		/// <summary>
		/// Form id.
		/// </summary>
		public string FormId { get; set; }

		/// <summary>
		/// Form name.
		/// </summary>
		public string FormName { get; set; }

		/// <summary>
		/// Page id.
		/// </summary>
		public string PageId { get; set; }

		/// <summary>
		/// Page name.
		/// </summary>
		public string PageName { get; set; }

		/// <summary>
		/// Landing id.
		/// </summary>
		public Guid LandingId { get; set; }

		#endregion

	}

	#endregion

}

