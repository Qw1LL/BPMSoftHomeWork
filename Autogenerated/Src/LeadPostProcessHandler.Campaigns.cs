namespace BPMSoft.Configuration.GeneratedWebFormService.CoreLead
{
	using System;
	using BPMSoft.Configuration.CampaignService;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	
	#region Class : LeadPostProcessHandler

	public class LeadPostProcessHandler : IGeneratedWebFormPostProcessHandler
	{
		#region Methods: Private

		private Guid GetContactId(UserConnection userConnection, Guid leadId) {
			var select = new Select(userConnection)
				.Column("QualifiedContactId")
				.From("Lead")
				.Where("Id").IsEqual(Column.Parameter(leadId)) as Select;
			return select.ExecuteScalar<Guid>();
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Executes the post processing for specified landing page.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		/// <param name="landingId">The landing identifier.</param>
		/// <param name="formData">The form data.</param>
		/// <param name="leadId">The event target identifier.</param>
		public void Execute(UserConnection userConnection, Guid landingId, FormFieldsData[] formData,
				Guid leadId) {
			Guid contactId = GetContactId(userConnection, leadId);
			var mergeHelper = new GeneratedWebFormHelper(userConnection, landingId);
			mergeHelper.MergeContactIntoCampaign(contactId);
		}

		#endregion
	}

	#endregion
}

