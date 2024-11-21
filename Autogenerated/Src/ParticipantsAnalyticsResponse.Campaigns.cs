namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Runtime.Serialization;

	#region Class: ParticipantsAnalyticsResponse

	/// <summary>
	/// Response for 
	/// <see cref="CampaignService.CampaignService.GetParticipantsAnalytics(ParticipantsAnalyticsRequest)"/>.
	/// Contains information about participants allocation in each campaign item.
	/// </summary>
	[DataContract]
	public class ParticipantsAnalyticsResponse
	{

		#region Properties: Public

		/// <summary>
		/// Campaign identifier.
		/// </summary>
		[DataMember(Name = "campaignId")]
		public Guid CampaignId {
			get; set;
		}

		/// <summary>
		/// List of campaign items which contains participants.
		/// </summary>
		[DataMember(Name = "analyticsItems")]
		public IEnumerable<ParticipantsAnalyticsItem> AnalyticsItems {
			get; set;
		}

		#endregion

	}

	#endregion

}
