namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using BPMSoft.Core.DB;

	#region Class: CampaignSplitGatewayTransitionFlowElement

	/// <summary>
	/// Transition from the split gateway element.
	/// </summary>
	public class CampaignSplitGatewayTransitionFlowElement : CampaignTransitionProcessElement
	{

		#region Properties: Public

		/// <summary>
		/// Unique identifier of transition per campaign schema, that is used for split distribution definition.
		/// </summary>
		public Guid TransitionId { get; set; }

		#endregion

		#region Methods: Private

		private void DeleteUsedDistribution() =>
			new Delete(UserConnection)
				.From("CmpgnSplitDistribution")
				.Where("TransitionId").IsEqual(Column.Parameter(TransitionId))
				.And("CampaignParticipantId").In(Column.Parameters(AudienceBatch))
				.Execute();

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Extends base transition query with split distribution join.
		/// </summary>
		/// <returns>Extended <see cref="Update"/> query.</returns>
		protected override void CreateQuery() {
			base.CreateQuery();
			var distributionSelect = new Select(UserConnection)
				.Column(Column.Parameter(1))
				.From("CmpgnSplitDistribution")
				.Where("CmpgnSplitDistribution", "TransitionId").IsEqual(Column.Parameter(TransitionId))
				.And(CampaignParticipantTable, "Id").IsEqual("CmpgnSplitDistribution", "CampaignParticipantId");
			(distributionSelect as Select).SpecifyNoLockHints();
			TransitionQuery.And().Exists(distributionSelect);
		}

		/// <summary>
		/// Executes current flow element with an audience batch.
		/// </summary>
		/// <param name="audienceQuery">Update query with audience to process.</param>
		/// <returns>Number of successfully processed participants.</returns>
		protected override int SingleExecute(Query audienceQuery) {
			var result = 0;
			using (var dbExecutor = UserConnection.EnsureDBConnection()) {
				dbExecutor.StartTransaction(IsolationLevel.ReadCommitted);
				try {
					result = base.SingleExecute(audienceQuery);
					if (result > 0) {
						DeleteUsedDistribution();
					}
					dbExecutor.CommitTransaction();
				} catch (Exception) {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
			return result;
		}

		#endregion

	}

	#endregion

}

