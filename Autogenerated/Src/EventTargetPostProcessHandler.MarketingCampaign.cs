namespace BPMSoft.Configuration.GeneratedWebFormService.Campaigns
{
	using System;
	using Core;
	using Core.DB;
	using BPMSoft.Configuration.CampaignService;

	#region Class: EventTargetPostProcessHandler

	/// <summary>
	/// Implements <see cref="BPMSoft.Configuration.IGeneratedWebFormPostProcessHandler" /> for post-processing 
	/// generated web form for EventTarget.
	/// </summary>
	public class EventTargetPostProcessHandler : IGeneratedWebFormPostProcessHandler
	{

		#region Methods: Private

		private Guid GetContactId(UserConnection userConnection, Guid eventTargetId) {
			var select = new Select(userConnection)
				.Column("ContactId")
				.From("EventTarget")
				.Where("Id").IsEqual(Column.Parameter(eventTargetId)) as Select;
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
		/// <param name="eventTargetId">The event target identifier.</param>
		public void Execute(UserConnection userConnection, Guid landingId, FormFieldsData[] formData,
				Guid eventTargetId) {
			Guid contactId = GetContactId(userConnection, eventTargetId);
			var mergeHelper = new GeneratedWebFormHelper(userConnection, landingId);
			mergeHelper.MergeContactIntoCampaign(contactId);
		}

		#endregion

	}

	#endregion

}

