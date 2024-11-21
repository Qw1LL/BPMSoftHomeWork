namespace BPMSoft.Configuration
{

	#region Enum: EmailState

	/// <summary>
	/// Email states.
	/// </summary>
	public enum EmailState
	{
		/// <summary>
		/// Default state.
		/// </summary>
		Queued = 0,

		/// <summary>
		/// Archival email.
		/// </summary>
		Archival = 1,

		/// <summary>
		/// Completed Email
		/// </summary>
		Complete = 2,

		/// <summary>
		/// Expired Email
		/// </summary>
		Expired = 3,

		/// <summary>
		/// Canceled Email
		/// </summary>
		Canceled = 4
	}

	#endregion

}

