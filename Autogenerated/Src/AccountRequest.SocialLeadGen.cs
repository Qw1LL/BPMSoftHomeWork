namespace BPMSoft.Configuration.SocialLeadGen
{

	#region Class: AccountRequest

	/// <summary>
	/// DTO request for account updates.
	/// </summary>
	public class AccountRequest
	{

		#region Properties: Public

		/// <summary>
		/// BPMStudio domain.
		/// </summary>
		public string BPMStudioDomain { get; set; }

		/// <summary>
		/// Ping BPMStudio instance.
		/// </summary>
		public bool PingBPMStudioInstance { get; set; }

		#endregion

	}

	#endregion

}
