namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: OpportunityStageManager

	/// <summary>
	/// The manager for opportunity stages.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EntityStageManager{BPMSoft.Configuration.OpportunityInStageData, 
	/// BPMSoft.Configuration.OpportunityStageData, 
	/// BPMSoft.Configuration.IOpportunityInStageRepository{BPMSoft.Configuration.OpportunityInStageData}}" />
	/// <seealso cref="BPMSoft.Configuration.EntityStageManager{BPMSoft.Configuration.OpportunityInStageData, 
	/// BPMSoft.Configuration.OpportunityStageData}" />
	public class OpportunityStageManager : EntityStageManager<OpportunityInStageData, OpportunityStageData,
		IOpportunityInStageRepository<OpportunityInStageData>>
	{
		#region Constructors: Public

		public OpportunityStageManager(UserConnection userConnection,
			IEntityRepository<OpportunityStageData> opportunityStageRepository,
			IOpportunityInStageRepository<OpportunityInStageData> opportunityInStageRepository)
			: base(userConnection, opportunityStageRepository, opportunityInStageRepository) {
		}

		#endregion

		#region Methods: Private

		private OpportunityInStageData FillOwnerId(Entity entity, OpportunityInStageData oppInStageData) {
			oppInStageData.OwnerId = entity.GetTypedColumnValue<Guid>("OwnerId");
			return oppInStageData;
		}

		private bool IsLastStageSuccessful(OpportunityStageData newStageData) {
			return newStageData.IsSuccessful && newStageData.IsEnd || !newStageData.IsEnd;
		}

		#endregion

		#region Methods: Protected

		protected override void ProcessColumnValues(Entity entity, IEnumerable<EntityColumnValue> entityValues) {
			base.ProcessColumnValues(entity, entityValues);
			Guid entityStageId = entity.GetTypedColumnValue<Guid>("StageId");
			Guid oldOwnerId = GetOldColumnValue<Guid>(entity, entityValues, "OwnerId");
			Guid ownerId = entity.GetTypedColumnValue<Guid>("OwnerId");
			bool isOwnerChaged = oldOwnerId != ownerId;
			if (isOwnerChaged) {
				var entityId = entity.GetTypedColumnValue<Guid>("Id");
				ChangeCurrentStageOwner(entityId, entityStageId, ownerId);
			}
		}

		protected override OpportunityInStageData FormNewStageHistoryRecord(Entity entity, 
				OpportunityStageData newStageData) {
			OpportunityInStageData oppInStageData = base.FormNewStageHistoryRecord(entity, newStageData);
			return FillOwnerId(entity, oppInStageData);
		}

		protected override OpportunityInStageData FormIntermediateStageRecord(Entity entity, 
				OpportunityStageData stage) {
			OpportunityInStageData oppInStageData = base.FormIntermediateStageRecord(entity, stage);
			return FillOwnerId(entity, oppInStageData);
		}

		[Obsolete("7.12.3 | Method is deprecated. Use ProcessPreviousStages(Entity entity, " +
			"OpportunityStageData oldStageData, OpportunityStageData newStageData)")]
		protected override void ProcessPreviousStages(Guid entityId, Guid newStageOwnerId,
				OpportunityStageData oldStageData, OpportunityStageData newStageData) {
			base.ProcessPreviousStages(entityId, newStageOwnerId, oldStageData, newStageData);
			var historicalStages = EntityInStageRepository.GetHistoricalOpportunityInStage(entityId, newStageData.Number);
			EntityInStageRepository.BulkUpdate(historicalStages, new Dictionary<string, object> {
				{"Historical", true}
			});
		}

		protected override void ProcessPreviousStages(Entity entity, OpportunityStageData oldStageData, 
				OpportunityStageData newStageData) {
			base.ProcessPreviousStages(entity, oldStageData, newStageData);
			Guid entityId = entity.PrimaryColumnValue;
			var historicalStages = EntityInStageRepository.GetHistoricalOpportunityInStage(entityId, newStageData.Number);
			EntityInStageRepository.BulkUpdate(historicalStages, new Dictionary<string, object> {
				{"Historical", true}
			});
		}

		[Obsolete("7.12.3 | Method is deprecated. Use ProcessIntermediateStages(Entity entity, " +
			"OpportunityStageData oldStageData, OpportunityStageData newStageData)")]
		protected override void ProcessIntermediateStages(Guid entityId, Guid newStageOwnerId,
				OpportunityStageData oldStageData, OpportunityStageData newStageData) {
			if (newStageData.IsSuccessful && newStageData.IsEnd || !newStageData.IsEnd) {
				base.ProcessIntermediateStages(entityId, newStageOwnerId, oldStageData, newStageData);
			}
		}

		protected override void ProcessIntermediateStages(Entity entity, OpportunityStageData oldStageData, 
				OpportunityStageData newStageData) {
			if (IsLastStageSuccessful(newStageData)) {
				base.ProcessIntermediateStages(entity, oldStageData, newStageData);
			}
		}

		#endregion
	}

	#endregion
}
