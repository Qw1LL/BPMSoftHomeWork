namespace BPMSoft.Configuration.CampaignService
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class : GeneratedWebFormHelper

	/// <summary>
	/// Helper class that incapsulates logic for landing in campaigns.
	/// </summary>
	public class GeneratedWebFormHelper
	{
		#region Contructors: Public

		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="userConnection">Instance of user connection.</param>
		/// <param name="webFormId">Unique identifier of landing.</param>
		public GeneratedWebFormHelper(UserConnection userConnection, Guid webFormId) {
			_userConnection = userConnection;
			_webFormId = webFormId;
		}

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		
		private readonly Guid _webFormId;

		#endregion
		
		#region Methods: Private

		private KeyValuePair<int, string> GetContactMailingDataById(UserConnection userConnection, Guid contactId) {
			int contactRId = int.MinValue;
			string contactEmail = string.Empty;
			var select = new Select(userConnection)
				.Column("RId").As("ContactRId")
				.Column("Email").As("ContactEmail")
				.From("Contact")
				.Where("Id").IsEqual(Column.Parameter(contactId)) as Select;
			using (DBExecutor dbExecutor = userConnection.EnsureDBConnection()) {
				using (IDataReader reader = select.ExecuteReader(dbExecutor)) {
					int contactRIdColumnIndex = reader.GetOrdinal("ContactRId");
					int contactEmailColumnIndex = reader.GetOrdinal("ContactEmail");
					if (reader.Read()) {
						contactRId = reader.GetInt32(contactRIdColumnIndex);
						contactEmail = reader.GetString(contactEmailColumnIndex);
					}
				}
			}
			return new KeyValuePair<int, string>(contactRId, contactEmail);
		}

		private CampaignStepsHandler GetHandler(UserConnection userConnection) {
			return ClassFactory.Get<CampaignStepsHandler>(new ConstructorArgument("userConnection", userConnection));
		}

		private void ExecuteImmediateCampaignStep(UserConnection userConnection, Guid campaignId, Guid stepId,
				Guid contactId) {
			KeyValuePair<int, string> contactData = GetContactMailingDataById(userConnection, contactId);
			int contactRId = contactData.Key;
			string contactEmail = contactData.Value;
			KeyValuePair<Guid, int> bulkEmailInfo = CampaignHelper.GetImmediatelyTriggerBulkEmailIdentifierByStepId(
				userConnection, stepId);
			if (bulkEmailInfo.Key.IsEmpty()) {
				return;
			}
			Guid bulkEmailId = bulkEmailInfo.Key;
			int bulkEmailRId = bulkEmailInfo.Value;
			var jobParameters = new Dictionary<string, object> {
				{ "ApplicationUrl", string.Empty },
				{ "CampaignId",  campaignId },
				{ "BulkEmailId",  bulkEmailId },
				{ "BulkEmailRId",  bulkEmailRId },
				{ "BulkEmailStepId", stepId },
				{ "ContactId", contactId },
				{ "ContactRId", contactRId },
				{ "ContactEmail", contactEmail }
			};
			CampaignHelper.CreateSendEmailImmediatelyJob(userConnection, jobParameters);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Insert or update contact into every campaign where given landing is used.
		/// </summary>
		/// <param name="contactId">Uniqie identifier of contact.</param>
		public void MergeContactIntoCampaign(Guid contactId) {
			if (contactId.IsEmpty()) {
				return;
			}
			Dictionary<Guid, Guid> campaignList = CampaignHelper.GetCampaignListByLandingId(_userConnection, _webFormId);
			CampaignStepsHandler stepsHandler = null;
			if (!campaignList.Any()) {
				return;
			}
			stepsHandler = GetHandler(_userConnection);
			foreach (KeyValuePair<Guid, Guid> campaign in campaignList) {
				Guid campaignId = campaign.Key;
				Guid landingStepId = campaign.Value;
				if (!CampaignHelper.CanMergeContactIntoCampaign(_userConnection, campaignId, landingStepId, contactId)) {
					continue;
				}
				IEnumerable<Guid> nextSteps = stepsHandler.GetImmediateTargetSteps(landingStepId);
				if (nextSteps.Any()) {
					Guid nextStepId = nextSteps.First();
					ExecuteImmediateCampaignStep(_userConnection, campaignId, nextStepId, contactId);
				} else {
					CampaignHelper.MergeContactIntoCampaign(_userConnection, campaignId, landingStepId, contactId);
				}
			}
		}

		#endregion
	}

	#endregion
}

