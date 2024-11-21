namespace BPMSoft.Configuration.SocialLeadGen
{
	using System;

	#region Class: AccountInfoResponse

	/// <summary>
	/// DTO response with information about account.
	/// </summary>
	public class AccountInfoResponse
	{

		#region Properties: Public

		/// <summary>
		/// Is account exists.
		/// </summary>
		public bool IsAccountExists { get; set; }

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

