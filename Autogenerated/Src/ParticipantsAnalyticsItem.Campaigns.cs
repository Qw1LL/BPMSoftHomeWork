namespace BPMSoft.Configuration
{
	using System;
	using System.Runtime.Serialization;

	#region Class: ParticipantsAnalyticsItem

	/// <summary>
	/// Describes numerical indicators for intem with <see cref="ItemId"/>
	/// </summary>
	[DataContract]
	public class ParticipantsAnalyticsItem
	{

		#region Properties: Public

		/// <summary>
		/// Campaign item identifier.
		/// </summary>
		[DataMember(Name = "itemId")]
		public Guid ItemId {
			get; set;
		}

		/// <summary>
		/// Participants count with <see cref="CampaignParticipant.StepCompleted"/> is equal true.
		/// </summary>
		[DataMember(Name = "completedParticipantsCount")]
		public int CompletedParticipantsCount {
			get; set;
		}

		/// <summary>
		/// Participants count with <see cref="CampaignParticipant.StepCompleted"/> is equal false.
		/// </summary>
		[DataMember(Name = "nonCompletedParticipantsCount")]
		public int NonCompletedParticipantsCount {
			get; set;
		}

		[DataMember(Name = "errorParticipantsCount")]
		public int ErrorParticipantsCount {
			get; set;
		}

		[DataMember(Name = "processingParticipantsCount")]
		public int ProcessingParticipantsCount {
			get; set;
		}

		[DataMember(Name = "suspendedParticipantsCount")]
		public int SuspendedParticipantsCount {
			get; set;
		}

		/// <summary>
		/// Total participants count from the Campaign's log.
		/// </summary>
		[DataMember(Name = "historyParticipantsCount")]
		public int HistoryParticipantsCount {
			get; set;
		}

		#endregion

	}

	#endregion

}
