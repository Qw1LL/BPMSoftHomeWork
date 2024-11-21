namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	#region Class: ParticipantsAnalyticsRequest

	/// <summary>
	/// Request parameter for
	/// <see cref="CampaignService.CampaignService.GetParticipantsAnalytics(ParticipantsAnalyticsRequest)"/>.
	/// Contains parameters for calculates campaign participants analytics.
	/// </summary>
	[DataContract]
	public class ParticipantsAnalyticsRequest
	{

		#region Properties: Public

		/// <summary>
		/// Campaign identifier for which participants needs calculate analytics.
		/// </summary>
		[DataMember(Name = "campaignId")]
		public Guid CampaignId {
			get; set;
		}

		/// <summary>
		/// Start filter day.
		/// </summary>
		[DataMember(Name = "filterStartDate")]
		public DateTime FilterStartDate {
			get; set;
		}

		/// <summary>
		/// Due filter date.
		/// </summary>
		[DataMember(Name = "filterDueDate")]
		public DateTime FilterDueDate {
			get; set;
		}

		/// <summary>
		/// Flag that indicates use <see cref="FilterStartDate"/> and <see cref="FilterDueDate"/> or calculates 
		/// statystics for the whole period.
		/// </summary>
		[DataMember(Name = "useTimeFilters")]
		public bool UseTimeFilters {
			get; set;
		}

		/// <summary>
		/// Flag that indicates usage of campaign log data.
		/// </summary>
		[DataMember(Name = "useHistoryData")]
		public bool UseHistoryData {
			get; set;
		}



		#endregion

	}

	#endregion

}
