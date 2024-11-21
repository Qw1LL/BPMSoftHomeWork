namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core;

	#region Class: CampaignAudienceConfig

	/// <summary>
	/// Class which contains parameters for create campaign audience store.
	/// </summary>
	public class CampaignAudienceConfig
	{

		#region Constructors: Public

		/// <summary>
		/// Public constructor.
		/// </summary>
		/// <param name="userConnection">Instance of the user connection.</param>
		/// <param name="campaignId">Identifier of the Campaign.</param>
		/// <param name="sessionId">Session identifier. Has default value as default Guid value.</param>
		public CampaignAudienceConfig(UserConnection userConnection, Guid campaignId, Guid sessionId = default(Guid)) {
			UserConnection = userConnection;
			SessionId = sessionId;
			CampaignId = campaignId;
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// Contains UserConnection for queries.
		/// </summary>
		public UserConnection UserConnection { get; }

		/// <summary>
		/// Session identifier. Needs for create campaign audience store for work 
		/// with sessioned participants from signals.
		/// </summary>
		public Guid SessionId { get; }

		/// <summary>
		/// Campaign identifier.
		/// </summary>
		public Guid CampaignId { get; }

		/// <summary>
		/// Time for wich was planned campaign execution.
		/// </summary>
		public DateTime? CampaignScheduledDate { get; set; }

		#endregion

	}

	#endregion

}
