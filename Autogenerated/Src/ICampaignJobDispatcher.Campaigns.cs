namespace BPMSoft.Configuration
{
	using System;
	using CoreCampaignSchema = BPMSoft.Core.Campaign.CampaignSchema;
	using Quartz;

	#region Interface: ICampaignJobDispatcher

	/// <summary>
	/// Represents methods for jobs' management.
	/// </summary>
	public interface ICampaignJobDispatcher
	{

		#region Properties: Public

		/// <summary>
		/// Instance of <see cref="IScheduler"/> with name <see cref="_campaignSchedulerName"/> or default.
		/// </summary>
		IScheduler CampaignScheduler { get; } 

		#endregion

		#region Methods: Public

		/// <summary>
		/// Schedules next job for the specified campaign.
		/// </summary>
		/// <param name="schema">The <see cref="CoreCampaignSchema"/> object for wich Job plans.</param>
		/// <param name="fireTimeConfig">Fire time config for job.</param>
		void ScheduleJob(CoreCampaignSchema schema, CampaignFireTimeConfig fireTimeConfig);

		/// <summary>
		/// Schedule next job for the specified campaign.
		/// </summary>
		/// <param name="campaignSchemaUId">The unique identifier of campaign schema instance.</param>
		/// <param name="fireTimeConfig">Fire time config for job.</param>
		void ScheduleJob(Guid campaignSchemaUId, CampaignFireTimeConfig fireTimeConfig);

		/// <summary>
		/// Removes scheduled jobs for the specified campaign.
		/// </summary>
		/// <param name="campaignId">The unique identifier of campaign entity which job should be deleted.</param>
		void RemoveJobs(Guid campaignId);

		/// <summary>
		/// Reschedules job for the specified campaign.
		/// </summary>
		/// <param name="schema">The <see cref="CoreCampaignSchema"/> object for wich Job plans.</param>
		/// <param name="fireTimeConfig">Fire time config for job.</param>
		void RescheduleJob(CoreCampaignSchema schema, CampaignFireTimeConfig fireTimeConfig);

		#endregion

	}

	#endregion

}

