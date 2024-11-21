namespace BPMSoft.Configuration {
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Scheduler;

	public static class CampaignCreateLeadProcessHelper {
		
		private const string CampaignLeadCreatorJobNamePattern = "CampaignLeadCreator_{0}";
		
		/// <summary>
		/// ######### ####### ######## ##### ## ###### ###### ########.
		/// </summary>
		/// <param name="userConnection">######### ################# ###########.</param>
		/// <param name="leadStepId">Id #### "####### ###".</param>
		/// <param name="targetInfoCollection">############ ### Id ###### # Id ######## ######### ########.</param>
		public static void CreateCampaignLead(UserConnection userConnection, Guid leadStepId, IEnumerable<KeyValuePair<Guid, Guid>> targetInfoCollection) {
			string syncJobName = string.Format(CampaignLeadCreatorJobNamePattern, Guid.NewGuid());
			Dictionary<string, object> parameters = new Dictionary<string, object>() {
				{ "LeadStepId", leadStepId },
				{ "TargetInfoCollection", targetInfoCollection }
			};
			AppScheduler.ScheduleImmediateProcessJob(syncJobName, "Campaign", "CampaignCreateLeadProcess", 
				userConnection.Workspace.Name, userConnection.CurrentUser.Name, parameters);
		}
	}
}
