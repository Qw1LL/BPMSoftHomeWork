namespace BPMSoft.Configuration
{

	#region Enum: CampaignExecutionLateness

	/// <summary>
	/// Describes lateness for campaign execution.
	/// </summary>
	public enum CampaignExecutionLateness
	{
		/// <summary>
		/// Zero lateness.
		/// </summary>
		None = 0,

		/// <summary>
		/// Nothing have been misfired.
		/// </summary>
		NoMisfire = 1,

		/// <summary>
		/// Some elements with time condition have been misfired.
		/// </summary>
		MisfiredTimeConditionElements = 2,

		/// <summary>
		/// Lateness is greater than specified critical lateness time.
		/// </summary>
		Critical = 3,

		/// <summary>
		/// Lateness is greater than specified critical lateness time
		/// and some elements with time condition have been misfired.
		/// </summary>
		CriticalAndMisfiredTimeConditionElements = 4
	}

	#endregion

}

