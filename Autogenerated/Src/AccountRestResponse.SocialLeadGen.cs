namespace BPMSoft.Configuration.SocialLeadGen
{
	using System;

	#region Class: AccountRestResponse

	/// <summary>
	/// Cloud response DTO with information about account.
	/// </summary>
	public class AccountRestResponse : SocialLeadGenRestProviderResponse
	{

		#region Properties: Public

		/// <summary>
		/// Account id.
		/// </summary>
		public Guid AccountId { get; set; }

		/// <summary>
		/// Is account active.
		/// </summary>
		public bool IsActive { get; set; }

		/// <summary>
		/// BPMStudio URL.
		/// </summary>
		public string BPMStudioUrl { get; set; }

		#endregion

	}

	#endregion

}

