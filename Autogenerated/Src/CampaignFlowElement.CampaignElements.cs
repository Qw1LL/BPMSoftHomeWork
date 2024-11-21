namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: CampaignFlowElement

	/// <summary>
	/// Executable campaign element which set ItemCompleted flag for all audience on it.
	/// </summary>
	public class CampaignFlowElement : BaseCampaignFlowElement
	{

		#region Methods: Private

		private Select GetItemAudienceSelect() {
			var select = new Select(UserConnection)
				.Column("Id")
				.From(CampaignParticipantTable)
				.Where(CampaignParticipantTable, "CampaignId").IsEqual(Column.Parameter(CampaignId))
					.And(CampaignParticipantTable, "CampaignItemId").IsEqual(Column.Parameter(CampaignItemId))
					.And(CampaignParticipantTable, "StatusId")
						.IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantParticipatingStatusId))
					.And(CampaignParticipantTable, "StepCompleted").IsEqual(Column.Parameter(false)) as Select;
			if (!SessionId.Equals(default(Guid))) {
				select.And(CampaignParticipantTable, "SessionId").IsEqual(Column.Parameter(SessionId));
			}
			select.SpecifyNoLockHints();
			return select;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Initializes audience <see cref="Select"/> query.
		/// </summary>
		protected override Query GetAudienceQuery() => GetItemAudienceSelect();

		/// <summary>
		/// Executes current flow element for selected audience.
		/// </summary>
		/// <param name="audienceQuery">Audience select Query to process.</param>
		/// <returns>Number of successfully processed participants.</returns>
		protected override int SingleExecute(Query audienceQuery) => SetItemCompleted(audienceQuery as Select);

		#endregion

	}

	#endregion

}

