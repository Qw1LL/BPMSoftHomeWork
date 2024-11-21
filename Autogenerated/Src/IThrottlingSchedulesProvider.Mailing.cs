namespace BPMSoft.Configuration
{
	using BPMSoft.Configuration.CESResponses;

	#region Interface: IThrottlingSchedulesProvider

	/// <summary>
	/// Provides functionality to get throttling schedules for current user.
	/// </summary>
	public interface IThrottlingSchedulesProvider
	{

		#region Methods: Public

		/// <summary>
		/// Gets throttling schedules for the current user by the required strategy.
		/// </summary>
		/// <param name="getThrottlingScheduleRequest">Request instance with the required service id.</param>
		/// <returns>Throttling for the current user by the required strategy.</returns>
		GetThrottlingSchedulesResponse GetThrottlingSchedules(GetThrottlingScheduleRequest getThrottlingScheduleRequest);

		#endregion

	}

	#endregion

}

