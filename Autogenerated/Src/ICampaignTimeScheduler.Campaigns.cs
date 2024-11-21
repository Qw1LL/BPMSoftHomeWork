namespace BPMSoft.Configuration
{
	using System;
	using CoreCampaignSchema = BPMSoft.Core.Campaign.CampaignSchema;

	#region Interface: ICampaignTimeScheduler

	/// <summary>
	/// Represents methods for calculation campaign time parameters.
	/// </summary>
	public interface ICampaignTimeScheduler
	{

		#region Methods: Public

		/// <summary>
		/// Returns next fire time for campaign.
		/// When <paramref name="previousScheduledFireTime"/> is null then used
		/// <see cref="DateTime.UtcNow"/> as benchmark point for calculation.
		/// </summary>
		/// <param name="campaignId">Campaign identifier.</param>
		/// <param name="useCurrentUserTimezone">Flag that indicates add current user
		/// timezone offset to next campaign scheduled time(in UTC) or not.</param>
		/// <param name="previousScheduledFireTime">Time of the previous campaign run.
		/// It can be null when need calculate next fire time relatively current time.</param>
		/// <returns>Returns campaign's next run time.</returns>
		DateTime GetCampaignNextFireTime(Guid campaignId, bool useCurrentUserTimezone,
			DateTime? previousScheduledFireTime = null);

		/// <summary>
		/// Returns next fire time for campaign's schema.
		/// </summary>
		/// <param name="schema">Campaign schema.
		/// Instance of <see cref="BPMSoft.Core.Campaign.CampaignSchema"/></param>
		/// <param name="previousScheduledFireTime">Time of the previous campaign run.
		/// It can be null when need calculate next fire time relatively current time.</param>
		/// <returns>Returns instance of <see cref="CampaignFireTimeConfig"/> that contains
		/// all needed information for schedule next campaign job.</returns>
		CampaignFireTimeConfig GetNextFireTime(CoreCampaignSchema schema, DateTime? previousScheduledFireTime);

		/// <summary>
		/// Returns config <see cref="CampaignExecutionLatenessConfig"/>, which describes lateness parameters.
		/// Lateness calculates relatively <paramref name="scheduledTime"/>.
		/// </summary>
		/// <param name="schema">Campaign's schema instance of
		/// <see cref="BPMSoft.Core.Campaign.CampaignSchema"/></param>
		/// <param name="scheduledTime">Time relatively this need calculate lateness config.</param>
		/// <returns>Returns instance <see cref="CampaignExecutionLatenessConfig"/>.</returns>
		CampaignExecutionLatenessConfig GetLatenessConfig(CoreCampaignSchema schema, DateTime scheduledTime);

		#endregion

	}

	#endregion

}

