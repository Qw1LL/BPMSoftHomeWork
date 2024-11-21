using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Common;
using BPMSoft.Core;
using BPMSoft.Core.Entities;
using BPMSoft.Core.DB;
using BPMSoft.Core.Store;
using BPMSoft.Nui.ServiceModel.Extensions;

namespace BPMSoft.Configuration
{
	
	#region Class: OpportunityStageHelper

	[Obsolete("Class is deprecated, please use OpportunityStageManager.")]
	public class OpportunityStageHelper
	{

		#region Class: OpportunityStageData

		protected class OpportunityStageData
		{
			public Guid StageId { 
				get;
				set;
			}
			public int Number { 
				get;
				set;
			}
			public bool End {
				get;
				set;
			}
		}
		
		#endregion
		
		#region Class: OpportunityInStageData

		protected class OpportunityInStageData
		{
			public Guid Id { 
				get;
				set;
			}
			public Guid OpportunityId { 
				get; 
				set;
			}
			public Guid OwnerId { 
				get; 
				set; 
			}
			public OpportunityStageData StageData { 
				get; 
				set;
			}

			public DateTime? Date {
				get; 
				set;
			}	
		}

		#endregion

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private EntitySchema _oppInStageSchema;

		#endregion

		#region Fields: Public

		public const string OppInStageCacheGroupName = "OpportunityStages";
		public const string OppInStageCacheGroupItem = "StagesSynchronizing";

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection {
			get { return _userConnection; }
		}

		protected EntitySchema OppInStageSchema {
			get { 
				return _oppInStageSchema;
			} 
			set { 
				_oppInStageSchema = value;
			}
		}

		#endregion

		#region Constructors: Public

		public OpportunityStageHelper(UserConnection userConnection, EntitySchema oppInStageSchema) {
			_userConnection = userConnection;
			_oppInStageSchema = oppInStageSchema;
		}

		public OpportunityStageHelper(UserConnection userConnection) {
			_userConnection = userConnection;
			_oppInStageSchema = UserConnection.EntitySchemaManager.GetInstanceByName("OpportunityInStage");
		}

		#endregion

		#region Methods: Private

		protected List<OpportunityStageData> GetStagesCollection() {
			var result = new List<OpportunityStageData>();
			var stageEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, "OpportunityStage");
			stageEsq.Cache = UserConnection.ApplicationCache.WithLocalCaching(OppInStageCacheGroupName);
			stageEsq.CacheItemName = OppInStageCacheGroupItem;
			var idColumn = stageEsq.AddColumn("Id");
			var numberColumn = stageEsq.AddColumn("Number").OrderByAsc();
			var endColumn = stageEsq.AddColumn("End");
			var stages = stageEsq.GetEntityCollection(UserConnection);
			stages.ForEach(stage => result.Add(new OpportunityStageData {
				StageId = stage.GetTypedColumnValue<Guid>(idColumn.Name),
				Number = stage.GetTypedColumnValue<int>(numberColumn.Name),
				End = stage.GetTypedColumnValue<bool>(endColumn.Name)
			}));
			return result;
		}

		private Guid GetLastOpportunityInStageId(Guid opportunityId, Guid stageId) {
			Select select = new Select(UserConnection).Top(1)
					.Column("Id")
				.From("OpportunityInStage")
				.Where("OpportunityId").IsEqual(Column.Parameter(opportunityId))
				.And("StageId").IsEqual(Column.Parameter(stageId))
				.OrderByDesc("CreatedOn") as Select;
			return select.ExecuteScalar<Guid>();
		}

		protected List<OpportunityStageData> GetIntermediateStages(List<OpportunityStageData> stages, OpportunityStageData oldStage,
			OpportunityStageData newStage)
		{
			var intermStages = new List<OpportunityStageData>();
			if (oldStage == null) {
				intermStages = stages
					.Where(stage => stage.Number < newStage.Number)
					.ToList();
			} else {
				intermStages = stages.Where(stage => (stage.Number > oldStage.Number) && stage.Number < newStage.Number)
					.ToList();
			}
			return intermStages
				.Where(stage => !stage.End)
				.OrderBy(stage => stage.Number)
				.ToList();

		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Creates opportunity in stage.
		/// </summary>
		/// <param name="oppData">Opportunity in stage data</param>
		/// <param name="isIntermediateStage">Is stage for creation is intermediate stage</param>
		protected virtual void  CreateOpportunityInStage(OpportunityInStageData oppData, bool isIntermediateStage = false) {
			var currentDate = oppData.Date.HasValue? oppData.Date.Value : UserConnection.CurrentUser.GetCurrentDateTime();
			Entity newEntity = OppInStageSchema.CreateEntity(UserConnection);
			newEntity.SetColumnValue("Id", Guid.NewGuid());
			newEntity.SetColumnValue("OpportunityId", oppData.OpportunityId);
			newEntity.SetColumnValue("OwnerId", oppData.OwnerId);
			newEntity.SetColumnValue("StageId", oppData.StageData.StageId);
			newEntity.SetColumnValue("StartDate", currentDate);
			if (oppData.StageData.End || isIntermediateStage) {
				newEntity.SetColumnValue("DueDate", currentDate);
			}
			newEntity.Save();
		}

		/// <summary>
		/// Updates opportunity stage owner.
		/// </summary>
		/// <param name="oppInStageId">Opportunity stage identifier</param>
		/// <param name="ownerId">New owner identifier</param>
		protected virtual void UpdateOpportunityInStageOwner(Guid oppInStageId, Guid ownerId) {
			Entity oppInStageEntity = OppInStageSchema.CreateEntity(UserConnection);
			if (!oppInStageEntity.FetchFromDB(oppInStageId, false)) {
				oppInStageEntity.SetDefColumnValues();
			}
			oppInStageEntity.SetColumnValue("OwnerId", ownerId);
			oppInStageEntity.Save(false);
		}

		/// <summary>
		/// Handles changing of current opportunity stage owner.
		/// </summary>
		/// <param name="opportunity">Current opportunity state</param>
		protected virtual void ChangeCurrentStageOwner(Entity opportunity) {
			Guid opportunityId = opportunity.PrimaryColumnValue;
			var stageId = opportunity.GetTypedColumnValue<Guid>("StageId");
			Guid lastOppInStageId = GetLastOpportunityInStageId(opportunityId, stageId);
			var ownerId = opportunity.GetTypedColumnValue<Guid>("OwnerId");
			UpdateOpportunityInStageOwner(lastOppInStageId, ownerId);
		}

		/// <summary>
		/// Synchronizes stages for opportunity.
		/// </summary>
		/// <param name="oldStageId">Last opportunity stage identifier</param>
		/// <param name="opportunity">Current opportunity state</param>
		protected virtual void SynchronizeStage(Guid oldStageId, Entity opportunity) {
			List<OpportunityStageData> stages = GetStagesCollection();
			var oppId = opportunity.GetTypedColumnValue<Guid>("Id");
			var newStageId = opportunity.GetTypedColumnValue<Guid>("StageId");
			var newStageOwnerId = opportunity.GetTypedColumnValue<Guid>("OwnerId");
			OpportunityStageData newStageData = stages.FirstOrDefault(s => s.StageId == newStageId);
			OpportunityStageData oldStageData = stages.FirstOrDefault(s => s.StageId == oldStageId);
			if (newStageData == null) {
				return;
			}
			if (oldStageData != null) {
				UpdateDueDateForLastStage(oldStageId, oppId);
			}
			bool isStagePrevious = oldStageData != null && newStageData.Number < oldStageData.Number;
			if (isStagePrevious) {
				UpdateIntermediateStages(newStageData.Number, oppId);
			} else {
				var intermStages = GetIntermediateStages(stages, oldStageData, newStageData);
				CreateIntermediateStages(oppId, newStageOwnerId, intermStages);
			}
			var currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			OpportunityInStageData oppData = new OpportunityInStageData {
				OpportunityId = opportunity.GetTypedColumnValue<Guid>("Id"),
				StageData = newStageData,
				OwnerId = newStageOwnerId,
				Date = currentDate.AddSeconds(newStageData.Number)
			};
			CreateOpportunityInStage(oppData);
		}

		/// <summary>
		/// Creates intermediate stages for opportunity which are skipped.
		/// </summary>
		/// <param name="opportunityId">Opportunity identifier</param>
		/// <param name="newStageOwnerId">Owner identifier</param>
		/// <param name="startStageNumber">Start stage number</param>
		/// <param name="endStageNumber">End stage number</param>
		protected virtual void CreateIntermediateStages(Guid opportunityId, Guid newStageOwnerId,
			List<OpportunityStageData> intermStages)
		{
			var oppDataList = new List<OpportunityInStageData>();
			var currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			intermStages.ForEach(stage =>
			{
				oppDataList.Add(new OpportunityInStageData
				{
					StageData = stage,
					OpportunityId = opportunityId,
					OwnerId = newStageOwnerId,
					Date = currentDate.AddSeconds(stage.Number)
				});
			});
			oppDataList.ForEach(oppInStage => CreateOpportunityInStage(oppInStage, true));
		}

		/// <summary>
		/// Sets Historical attribute to not actual stages.
		/// </summary>
		/// <param name="newStageNumber">Position of new opportunity stage</param>
		/// <param name="oppId">Opportunity identifier</param>
		protected virtual void UpdateIntermediateStages(int newStageNumber, Guid oppId)
		{
			var notValidStageSelect = (Select) new Select(UserConnection)
					.Column("Id")
				.From("OpportunityStage")
				.Where("Number")
				.IsGreaterOrEqual(Column.Parameter(newStageNumber));
			var updOppInStages = new Update(UserConnection, "OpportunityInStage")
					.Set("Historical", Column.Parameter(true))
				.Where("OpportunityId").IsEqual(Column.Parameter(oppId))
				.And("StageId").In(notValidStageSelect);
			updOppInStages.Execute();
		}

		/// <summary>
		/// Updates DueDate for last opportunity stage.
		/// </summary>
		/// <param name="oldStageId">Last opportunity stage identifier</param>
		/// <param name="oppId">Opportunity identifier</param>
		protected virtual void UpdateDueDateForLastStage(Guid oldStageId, Guid oppId)
		{
			Entity oppInStageEntity = OppInStageSchema.CreateEntity(UserConnection);
			Guid oppInStageId = GetLastOpportunityInStageId(oppId, oldStageId);
			if (!oppInStageEntity.FetchFromDB(oppInStageId, false)) {
				oppInStageEntity.SetDefColumnValues();
			}
			var currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			oppInStageEntity.SetColumnValue("DueDate", currentDate);
			oppInStageEntity.Save(false);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Handles opportunity stages synchronization.
		/// </summary>
		/// <param name="oldStageId">Previous opportunity stage</param>
		/// <param name="oldOwnerId">Previous opportunity owner</param>
		/// <param name="opportunity">Current opportunity state</param>
		public virtual void SynchronizeStage(Guid oldStageId, Guid oldOwnerId, Entity opportunity) {
			bool isOwnerChaged = oldOwnerId != opportunity.GetTypedColumnValue<Guid>("OwnerId");
			bool isStateChanged = oldStageId != opportunity.GetTypedColumnValue<Guid>("StageId");
			if (isStateChanged) {
				SynchronizeStage(oldStageId, opportunity);
				return;
			}
			if (isOwnerChaged) {
				ChangeCurrentStageOwner(opportunity);
			}
		}

		#endregion
		
	}

	#endregion

}

