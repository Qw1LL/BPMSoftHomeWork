namespace BPMSoft.Configuration {
	using System;
	using System.Collections;
	using System.Collections.Generic;
	using System.Data;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;
	using BPMSoft.Core.Scheduler;
	using global::Common.Logging;

	#region class: CampaignLeadQualificationHelper

	/// <summary>
	/// Helper class for lead qualification.
	/// </summary>
	[Obsolete("7.8.4 | Use class BPMSoft.Configuration.CampaignService.GeneratedWebFormHelper")]
	public class CampaignLeadQualificationHelper: LeadQualificationHelper {

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger("CampaignLeadQualificationHelper");

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initializes new class instance <see cref="CampaignLeadQualificationHelper"/>.
		/// </summary>
		/// <param name="userConnection">User connection instance.</param>
		/// <param name="applicationUrl">Application URL.</param>
		public CampaignLeadQualificationHelper(UserConnection userConnection, string applicationUrl)
				: base(userConnection, applicationUrl) {}

		#endregion

		#region Methods: Private

		private bool IsLeadFromLandingAndHaveContact(Guid leadId, out Guid landingId, out Guid contactId,
				out int contactRId, out string contactEmail) {
			landingId = Guid.Empty;
			contactId = Guid.Empty;
			contactRId = -1;
			contactEmail = string.Empty;
			var select = new Select(UserConnection)
				.Column("GeneratedWebForm", "Id").As("LandingId")
				.Column("Lead", "QualifiedContactId").As("ContactId")
				.Column("Contact", "Email").As("ContactEmail")
				.Column("Contact", "RId").As("ContactRId")
				.From("GeneratedWebForm")
				.Join(JoinType.Inner, "Lead")
					.On("Lead", "WebFormId").IsEqual("GeneratedWebForm", "Id")
				.Join(JoinType.LeftOuter, "Contact")
					.On("Contact", "Id").IsEqual("Lead", "QualifiedContactId")
				.Where("Lead", "Id").IsEqual(Column.Parameter(leadId))
				.And("Lead", "QualifiedContactId").Not().IsNull()
				.And("GeneratedWebForm", "StateId").IsEqual(Column.Parameter(LendingConsts.ActiveLendingStateId)) as Select;
			using (DBExecutor dbExecutor = UserConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					int landingIdColumnIndex = reader.GetOrdinal("LandingId");
					int contactIdColumnIndex = reader.GetOrdinal("ContactId");
					int contactRIdColumnIndex = reader.GetOrdinal("ContactRId");
					int contactEmailColumnIndex = reader.GetOrdinal("ContactEmail");
					while (reader.Read()) {
						landingId = reader.GetGuid(landingIdColumnIndex);
						contactId = reader.GetGuid(contactIdColumnIndex);
						contactRId = reader.GetInt32(contactRIdColumnIndex);
						contactEmail = reader.GetString(contactEmailColumnIndex);
						break;
					}
				}
			}
			return !Guid.Empty.Equals(landingId) && !Guid.Empty.Equals(contactId);
		}

		private bool IsSendNow(Guid? nextStepId, string contactEmail, out Guid bulkEmailId, out int bulkEmailRId) {
			bool result = false;
			if (nextStepId.HasValue) {
				KeyValuePair<Guid, int> bulkEmailInfo = CampaignHelper.GetImmediatelyTriggerBulkEmailIdentifierByStepId(
					UserConnection, nextStepId.Value);
				bulkEmailId = bulkEmailInfo.Key;
				bulkEmailRId = bulkEmailInfo.Value;
				result = !bulkEmailId.Equals(Guid.Empty);
			} else {
				bulkEmailId = Guid.Empty;
				bulkEmailRId = -1;
			}
			return result;
		}

		private void AddToCampaignAudienceOrSendEmail(Guid campaignId, Guid landingStepId, Guid contactId,
				int contactRId, Guid? nextStepId, string contactEmail) {
			Guid bulkEmailId;
			int bulkEmailRId;
			try {
				if (IsSendNow(nextStepId, contactEmail, out bulkEmailId, out bulkEmailRId)) {
					var jobParameters = new Dictionary<string, object> {
						{ "ApplicationUrl", ApplicationUrl },
						{ "CampaignId",  campaignId },
						{ "BulkEmailId",  bulkEmailId },
						{ "BulkEmailRId",  bulkEmailRId },
						{ "BulkEmailStepId", nextStepId },
						{ "ContactId", contactId },
						{ "ContactRId", contactRId },
						{ "ContactEmail", contactEmail }
					};
					CampaignHelper.CreateSendEmailImmediatelyJob(UserConnection, jobParameters);
				} else {
					CampaignHelper.MergeContactIntoCampaign(UserConnection, campaignId, landingStepId, contactId);
				}
			} catch (Exception e){
				_log.ErrorFormat("[CampaignLeadQualificationHelper.AddToCampaignAudienceOrSendEmail].", e);
			}
		}

		#endregion

		#region Methods: Protected

		protected virtual void AddLeadContactToCampaigns(Guid leadId) {
			Guid landingId;
			Guid contactId;
			int contactRId;
			string contactEmail;
			if (IsLeadFromLandingAndHaveContact(leadId, out landingId, out contactId, out contactRId,
					out contactEmail)) {
						
				Dictionary<Guid, Guid> campaignList = 
					CampaignHelper.GetCampaignListByLandingId(UserConnection, landingId);
				var campaignStepsHandler = ClassFactory.Get<CampaignStepsHandler>(
					new ConstructorArgument("userConnection", UserConnection));
				foreach (var campaign in campaignList) {
					Guid campaignId = campaign.Key;
					Guid landingStepId = campaign.Value;
					Guid? nextStepId = campaignStepsHandler.GetCampaignSecondStepId(campaignId);
					AddToCampaignAudienceOrSendEmail(campaignId, landingStepId, contactId, contactRId, nextStepId,
						contactEmail);
				}
			}
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Action after lead qualification.
		/// </summary>
		/// <param name="leadId">Unique identifier of lead.</param>
		public override void ActionAfterIdentification(Guid leadId) {
			AddLeadContactToCampaigns(leadId);
		}

		#endregion

	}

	#endregion

}
