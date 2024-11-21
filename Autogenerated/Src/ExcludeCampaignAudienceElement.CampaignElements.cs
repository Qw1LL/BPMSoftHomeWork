namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using System.Collections.Generic;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: ExcludeCampaignAudienceElement

	/// <summary>
	/// Executable campaign element which exclude contacts from campaign audience.
	/// </summary>
	public class ExcludeCampaignAudienceElement : CampaignFlowElement
	{

		#region Properties: Private

		private Guid ParticipantStatusId => IsCampaignGoal
			? CampaignConstants.CampaignParticipantReachedGoalStatusId
			: CampaignConstants.CampaignParticipantExitedStatusId;

		private IEnumerable<Guid> AllowedParticipantStatuses =>
			new[] {
				CampaignConstants.CampaignParticipantParticipatingStatusId,
				CampaignConstants.CampaignParticipantExitedStatusId,
				CampaignConstants.CampaignParticipantReachedGoalStatusId
			};

		#endregion

		#region Properties: Public

		/// <summary>
		/// Flag which indicates that element is campaign's goal or not.
		/// </summary>
		public bool IsCampaignGoal { get; set; }

		#endregion

		#region Methods: Private

		private Select CreateAudienceSelect() {
			var select = base.GetAudienceQuery();
			var statusIdCondition = select.Condition.FirstOrDefault(x =>
				x.LeftExpression.SourceColumnAlias.Equals("StatusId")
					&& x.LeftExpression.SourceAlias.Equals(CampaignParticipantTable));
			if (statusIdCondition != null) {
				select.Condition.Remove(statusIdCondition);
			}
			return select
				.And(CampaignParticipantTable, "StatusId")
					.In(Column.Parameters(AllowedParticipantStatuses)) as Select;
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Returns instance of <see cref="Query"/> with conditions to get audience to process.
		/// </summary>
		/// <returns>Query with filter audience conditions.</returns>
		protected override Query GetAudienceQuery() => CreateAudienceSelect();

		/// <summary>
		/// Executes current flow element with audience query conditions.
		/// </summary>
		/// <param name="audieceQuery">Query for item audience to be processed.</param>
		/// <returns>Count of campaign participants which were processed by current step.</returns>
		protected override int SingleExecute(Query audieceQuery) =>
			SetParticipantsStatus(audieceQuery as Select, ParticipantStatusId);

		#endregion

	}

	#endregion

}

