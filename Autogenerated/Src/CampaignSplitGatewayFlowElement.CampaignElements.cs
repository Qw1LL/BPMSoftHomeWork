namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using System.Threading;
	using BPMSoft.Common;
	using BPMSoft.Configuration.CampaignService;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Process;

	#region Class: CampaignSplitGatewayFlowElement

	/// <summary>
	/// Executable part of split gateway element.
	/// </summary>
	public class CampaignSplitGatewayFlowElement : CampaignFlowElement
	{

		#region Properties: Public

		/// <summary>
		/// Pairs of campaign transition element Id and it's expected percentage of audience to transfer.
		/// </summary>
		public Dictionary<Guid, int> Distribution { get; set; }

		/// <summary>
		/// Flag to indicate that distribution is customized for flows.
		/// </summary>
		public bool UseCustomDistribution { get; set; }

		#endregion

		#region Methods: Private

		private void InsertParticipantsForTransition(Guid transitionId, IEnumerable<Guid> participants) {
			var chunksCount = (int)Math.Ceiling(decimal.One * (participants.Count() / SafeQueryBatchSize)) + 1;
			var chunks = participants.SplitOnParts(chunksCount);
			foreach (var chunk in chunks) {
				var insert = new Insert(UserConnection).Into("CmpgnSplitDistribution");
				foreach (var participant in chunk) {
					insert.Values()
						.Set("CampaignParticipantId", Column.Parameter(participant))
						.Set("TransitionId", Column.Parameter(transitionId));
				}
				if (insert.ColumnValues.IsNotEmpty()) {
					insert.Execute();
				}
				Thread.Sleep(10);
			}
		}

		private void SaveParticipantsGroups(Dictionary<Guid, Guid[]> groups) {
			foreach (var group in groups) {
				var transitionId = group.Key;
				var participants = group.Value;
				InsertParticipantsForTransition(transitionId, participants);
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Executes current flow element.
		/// </summary>
		/// <param name="context">The execution context.</param>
		/// <returns>Number of processed participants.</returns>
		protected override int SafeExecute(ProcessExecutingContext context) {
			var result = 0;
			if (Distribution.Count == 0) {
				return result;
			}
			using (var dbExecutor = UserConnection.EnsureDBConnection(QueryKind.Limited)) {
				dbExecutor.StartTransaction(IsolationLevel.ReadCommitted);
				try {
					var audienceQuery = GetAudienceQuery();
					var participants = GetKeysByQuery(audienceQuery).ToArray();
					var groups = participants.DistributeByGroups(Distribution);
					SaveParticipantsGroups(groups);
					result = base.SafeExecute(context);
					dbExecutor.CommitTransaction();
					return result;
				} catch (Exception) {
					dbExecutor.RollbackTransaction();
					throw;
				}
			}
		}

		#endregion

	}

	#endregion

}

