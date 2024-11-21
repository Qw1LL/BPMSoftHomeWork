namespace BPMSoft.Configuration.SocialLeadGen
{
	using System.Collections.Generic;

	#region Class: LinkedInAdAccountListResponse

	/// <summary>
	/// 
	/// </summary>
	public class LinkedInAdAccountListResponse : SocialLeadGenRestProviderResponse
	{

		#region Class: AdAccount

		/// <summary>
		/// 
		/// </summary>
		public class AdAccount
		{

			#region Properties: Public

			/// <summary>
			/// 
			/// </summary>
			public string AdAccountId { get; set; }

			/// <summary>
			/// 
			/// </summary>
			public string AdAccountName { get; set; }

			#endregion

		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// 
		/// </summary>
		public List<AdAccount> AdAccounts { get; set; }

		#endregion

	}

	#endregion
}
