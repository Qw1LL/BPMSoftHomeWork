namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: CampaignLandingFlowElement

	/// <summary>
	/// Executable landing page element that filters audience due to landing entities.
	/// </summary>
	public class CampaignLandingFlowElement : CampaignFlowElement
	{

		#region Properties: Public

		/// <summary>
		/// The unique identifier of a current web form.
		/// </summary>
		public Guid LandingId { get; set; }

		/// <summary>
		/// Provides query model for the specified landing.
		/// </summary>
		private LandingContactQueryProvider _queryProvider;
		public LandingContactQueryProvider QueryProvider {
			get => _queryProvider ?? (_queryProvider = new LandingContactQueryProvider(UserConnection));
			set => _queryProvider = value;
		}

		#endregion

		#region Methods: Protecteds

		/// <summary>
		/// Contains custom logic for <see cref="AudieceQuery"/> initialization.
		/// </summary>
		/// <returns>Initialized <see cref="Query"/> to use as campaign audience.</returns>
		protected override Query GetAudienceQuery() {
			var selectModel = QueryProvider.GetSelectModel(LandingId);
			var contactSelect = selectModel.ContactSelect;
			var contactIdColumn = contactSelect.Columns.FindByAlias(selectModel.ContactIdColumnName);
			if (contactSelect.HasCondition) {
				contactSelect.And(contactIdColumn).IsEqual(CampaignParticipantTable, "ContactId");
			} else {
				contactSelect.Where(contactIdColumn).IsEqual(CampaignParticipantTable, "ContactId");
			}
			var participantsSelect = base.GetAudienceQuery();
			participantsSelect.And().Exists(contactSelect);
			return participantsSelect;
		}

		#endregion

	}

	#endregion

}

