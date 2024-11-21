namespace BPMSoft.Configuration
{
	using System;
	using BPMSoft.Core.Campaign;
	using BPMSoft.Core.DB;

	#region Class: CampaignTransitionProcessElement

	/// <summary>
	/// Base executable transition process element.
	/// </summary>
	public class CampaignTransitionProcessElement : BaseCampaignFlowElement
	{

		#region Properties: Protected

		/// <summary>
		/// Transition update query.
		/// </summary>
		protected Query TransitionQuery { get; set; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// Unique identifier of the source element.
		/// </summary>
		public Guid SourceItemId { get; set; }

		/// <summary>
		/// Unique identifier of the target element.
		/// </summary>
		public Guid TargetItemId { get; set; }

		/// <summary>
		/// Condition that indicates wich query condition to apply for StepCompleted property.
		/// </summary>
		public StepCompletedCondition StepCompletedCondition { get; set; }

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Applies StepCompleted condition to transition update query.
		/// </summary>
		protected virtual void ApplyStepCompletedCondition() {
			switch (StepCompletedCondition) {
				case StepCompletedCondition.UseCompletedOnly:
					TransitionQuery.And("StepCompleted").IsEqual(Column.Parameter(true));
					break;
				case StepCompletedCondition.UseIncompletedOnly:
					TransitionQuery.And("StepCompleted").IsEqual(Column.Parameter(false));
					break;
				case StepCompletedCondition.Any:
					break;
				default:
					TransitionQuery.And("StepCompleted").IsEqual(Column.Parameter(true));
					break;
			}
		}

		/// <summary>
		/// Returns base query for <see cref="SequenceFlowElement"/>
		/// </summary>
		/// <param name="sourceRefUId">Unique identifier of the sequence's source element.</param>
		/// <param name="targetRefUId">Unique identifier of the sequence's target element.</param>
		/// <returns>Query with base logic of <see cref="SequenceFlowElement"/>.</returns>
		protected virtual Update GetSequenceFlowBaseUpdate(Guid sourceRefUId, Guid targetRefUId) {
			var result = new Update(UserConnection, CampaignParticipantTable)
				.Set("CampaignItemId", Column.Parameter(targetRefUId))
				.Set("StepModifiedOn", Column.Parameter(DateTime.UtcNow))
				.Set("StepCompletedOn", Column.Parameter(null, "DateTime"))
				.Set("StepCompleted", Column.Parameter(false))
				.Where("StatusId").IsEqual(Column.Parameter(CampaignConstants.CampaignParticipantParticipatingStatusId))
					.And("CampaignItemId")
						.IsEqual(Column.Parameter(sourceRefUId)) as Update;
			if (!SessionId.Equals(default(Guid))) {
				result.And(CampaignParticipantTable, "SessionId").IsEqual(Column.Parameter(SessionId));
			}
			result.WithHints(new RowLockHint());
			return result;
		}

		/// <summary>
		/// Creates query that contains base logic for transition.
		/// </summary>
		/// <returns><see cref="Update"/> that moves participants from the current step to the next one.</returns>
		protected virtual void CreateQuery() {
			TransitionQuery = GetSequenceFlowBaseUpdate(SourceItemId, TargetItemId);
			ApplyStepCompletedCondition();
		}

		/// <summary>
		/// Contains custom logic for <see cref="AudieceQuery"/> initialization.
		/// </summary>
		protected override Query GetAudienceQuery() {
			CreateQuery();
			return TransitionQuery;
		}

		/// <summary>
		/// Executes current flow element for selected audience.
		/// </summary>
		/// <param name="audienceQuery">Query for item which audience have to be processed.</param>
		/// <returns>Number of successfully processed participants.</returns>
		protected override int SingleExecute(Query audienceQuery) => audienceQuery.Execute();

		#endregion

	}

	#endregion

}

