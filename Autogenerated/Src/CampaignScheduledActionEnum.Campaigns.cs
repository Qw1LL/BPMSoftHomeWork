namespace BPMSoft.Configuration
{

	#region Enum: CampaignScheduledAction

	/// <summary>
	/// Deascribes actions for campaign dispatcher.
	/// </summary>
	public enum CampaignScheduledAction
	{
		/// <summary>
		/// Run campaign action.
		/// </summary>
		Run = 0,

		/// <summary>
		/// Start campaign action.
		/// </summary>
		Start = 1,

		/// <summary>
		/// Stop campaign action.
		/// </summary>
		Stop = 2,

		/// <summary>
		/// Scheduled start campaign action. When campaign started on time defines
		/// in ScheduledStartDate in Campaign entity.
		/// </summary>
		ScheduledStart = 3,

		/// <summary>
		/// Scheduled stop campaign action. When campaign stopped on time defines
		/// in ScheduledStopDate in Campaign entity.
		/// </summary>
		ScheduledStop = 4
	}

	#endregion

}

