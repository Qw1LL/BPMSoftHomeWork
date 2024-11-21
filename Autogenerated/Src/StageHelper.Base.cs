using System;
using System.Collections.Generic;
using System.Linq;
using BPMSoft.Core;
using BPMSoft.Core.Entities;
using BPMSoft.Core.DB;
using BPMSoft.Core.Store;

namespace BPMSoft.Configuration
{

	#region Class: StageHelper

	/// <summary>
	/// Manage stage history logging
	/// </summary>
	public abstract class StageHelper
	{
		#region Constructors: Protected
		
		/// <summary>
		/// StageHelper constructor
		/// </summary>
		/// <param name="userConnection"> Connection info </param>
		protected StageHelper(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		/// <summary>
		/// Stage history schema entity
		/// </summary>
		private EntitySchema _stageHistorySchema;

		#endregion

		#region Properties: Protected

		/// <summary>
		/// Name of entity that represents stage info
		/// </summary>
		protected abstract string StageSchemaName { get; }

		/// <summary>
		/// Name of entity that represent stage log
		/// </summary>
		protected abstract string StageLogSchemaName { get; }

		/// <summary>
		/// Connection info
		/// </summary>
		protected UserConnection UserConnection { get; private set; }

		/// <summary>
		/// Stage history schema entity
		/// </summary>
		protected EntitySchema StageHistorySchema {
			get {
				return _stageHistorySchema ??
					(_stageHistorySchema = UserConnection.EntitySchemaManager.GetInstanceByName(StageLogSchemaName));
			}
		}

		/// <summary>
		/// Root entity columns
		/// Should contains at least:
		///		"Id" - Root entity identifier column name
		///		"Stage" - Stage identifier column name
		///		"Owner" - Owner identifier column name
		/// </summary>
		protected virtual Dictionary<string, string> RootEntityColumns {
			get {
				return new Dictionary<string, string> {
					{ "Id", "Id"},
					{ "Stage", "StageId"},
					{ "Owner", "OwnerId"},
				};
			}
		}

		#endregion

		#region Methods: Private

		/// <summary>
		/// Update last stage finish date
		/// </summary>
		/// <param name="stageId"> Stage identifier </param>
		/// <param name="rootEntityId"> Root entity identifier </param>
		private void UpdateDueDateForLastStage(Guid stageId, Guid rootEntityId) {

            Guid lastStageHistoryRecordId = GetLastStageHistoryRecordId(rootEntityId, stageId);
            Entity lastStageHistoryRecord = GetLastStageHistoryRecord(lastStageHistoryRecordId);
			DateTime currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
            lastStageHistoryRecord.SetColumnValue("DueDate", currentDate);
            lastStageHistoryRecord.Save(false);
		}

		/// <summary>
		/// Handle intermediate stages log records
		/// </summary>
		/// <param name="number"> New stage index number </param>
		/// <param name="rootEntityId"> Root entity identifier </param>
		private void UpdateIntermediateStages(int number, Guid rootEntityId) {
			var notValidStageSelect = (Select)new Select(UserConnection)
				.Column("Id")
				.From(StageSchemaName)
				.Where("Number")
				.IsGreaterOrEqual(Column.Parameter(number));
            notValidStageSelect.SpecifyNoLockHints();
            var updHistory = new Update(UserConnection, StageLogSchemaName)
					.Set("Historical", Column.Parameter(true))
				.Where("RootEntityId").IsEqual(Column.Parameter(rootEntityId))
				.And("StageId").In(notValidStageSelect);
			updHistory.Execute();
		}

		/// <summary>
		/// Changes owner of current stage
		/// </summary>
		/// <param name="rootEntity"> Root enttity info </param>
		private void ChangeCurrentStageOwner(Entity rootEntity) {
			Guid rootEntityId = rootEntity.PrimaryColumnValue;
			Guid stageId = rootEntity.GetTypedColumnValue<Guid>(RootEntityColumns["Stage"]);
			Guid lastStageHistoryRecordId = GetLastStageHistoryRecordId(rootEntityId, stageId);
			Guid ownerId = rootEntity.GetTypedColumnValue<Guid>(RootEntityColumns["Owner"]);
			UpdateCurrentStageOwner(lastStageHistoryRecordId, ownerId);
		}

		/// <summary>
		/// Updates owner of current stage
		/// </summary>
		/// <param name="lastStageHistoryRecordId"></param>
		/// <param name="ownerId"></param>
		private void UpdateCurrentStageOwner(Guid lastStageHistoryRecordId, Guid ownerId) {
            var lastStageHistoryRecord = GetLastStageHistoryRecord(lastStageHistoryRecordId);
            lastStageHistoryRecord.SetColumnValue("OwnerId", ownerId);
			lastStageHistoryRecord.Save(false);
		}

        /// <summary>
        /// Gets last stage history record
        /// </summary>
        /// <param name="lastStageHistoryRecordId"> Stage history record Id </param>
        /// <returns> Last stage history record </returns>
        private Entity GetLastStageHistoryRecord(Guid lastStageHistoryRecordId) {
            Entity lastStageHistoryRecord = StageHistorySchema.CreateEntity(UserConnection);
            if (!lastStageHistoryRecord.FetchFromDB(lastStageHistoryRecordId, false))
            {
                lastStageHistoryRecord.SetDefColumnValues();
            }
            return lastStageHistoryRecord;
        }

		/// <summary>
		/// Creates intermediate stages
		/// </summary>
		/// <param name="rootEntityId"> Root entity identifier </param>
		/// <param name="stageOwnerId"> Stage owner identifier </param>
		/// <param name="intermStages"> Collection of stages to create </param>
		private void CreateIntermediateStages(Guid rootEntityId, Guid stageOwnerId, IEnumerable<StageData> intermStages) {
			DateTime currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			var stageHistoryDataList = intermStages.Select(intermStage => new StageHistoryData {
				Stage = intermStage,
				EntityId = rootEntityId,
				OwnerId = stageOwnerId,
				Date = currentDate.AddSeconds(intermStage.Number)
			}).ToList();
			foreach(var stageHistoryData in stageHistoryDataList) {
				var newHistoryRecord = CreateStageHistoryRecord(stageHistoryData, true);
				newHistoryRecord.Save();
			}
		}

		#endregion

		#region Methods: Protected

		/// <summary>
		/// Gets identifier of last record in stage log for particular stage
		/// </summary>
		/// <param name="rootEntityId"> Root entity identifier </param>
		/// <param name="stageId"> Stage to find </param>
		/// <returns> Identifier of stage history record </returns>
		protected virtual Guid GetLastStageHistoryRecordId(Guid rootEntityId, Guid stageId)
		{
			var select = new Select(UserConnection).Top(1)
				.Column("Id")
				.From(StageLogSchemaName)
				.Where("RootEntityId").IsEqual(Column.Parameter(rootEntityId))
				.And("StageId").IsEqual(Column.Parameter(stageId))
				.OrderByDesc("CreatedOn") as Select;
			select.SpecifyNoLockHints();
			return select == null ? Guid.Empty : select.ExecuteScalar<Guid>();
		}

		/// <summary>
		/// Get info about all available stages
		/// </summary>
		/// <returns> Available stages collection </returns>
		protected virtual IEnumerable<StageData> GetStagesCollection() {
			var stageEsq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, StageSchemaName) {
				Cache = UserConnection.ApplicationCache.WithLocalCaching(StageSchemaName),
				CacheItemName = string.Concat(StageSchemaName, "Item")
			};
			string idColumnName = stageEsq.AddColumn("Id").Name;
			string endColumnName = stageEsq.AddColumn("End").Name;
			string numberColumnName = stageEsq.AddColumn("Number").OrderByAsc().Name;
			EntityCollection entityCollection = stageEsq.GetEntityCollection(UserConnection);
			return entityCollection.Select(x => new StageData {
				End = x.GetTypedColumnValue<bool>(endColumnName),
				Number = x.GetTypedColumnValue<int>(numberColumnName),
				StageId = x.GetTypedColumnValue<Guid>(idColumnName),
			});
		}

		/// <summary>
		/// Gets all stages that were sciped between old stage and new
		/// </summary>
		/// <param name="stages"> Stages collection </param>
		/// <param name="oldStageData"> Old stage info </param>
		/// <param name="newStageData"> New stage info </param>
		/// <returns> Intermediate stages </returns>
		protected virtual List<StageData> GetIntermediateStages(List<StageData> stages,
			StageData oldStageData, StageData newStageData) {
			List<StageData> intermStages;
			if (oldStageData == null) {
				intermStages = stages
					.Where(stage => stage.Number < newStageData.Number)
					.ToList();
			} else {
				intermStages = stages.Where(stage => (stage.Number > oldStageData.Number)
					&& stage.Number < newStageData.Number)
					.ToList();
			}
			return intermStages
				.Where(stage => !stage.End)
				.OrderBy(stage => stage.Number)
				.ToList();
		}

		/// <summary>
		/// Creates new record
		/// </summary>
		/// <param name="stageHistoryData"> Stage history data to create </param>
		/// <param name="isIntermediateStage"> Shows if this stage intemediate </param>
		/// <returns>Stage entity</returns>
		protected virtual Entity CreateStageHistoryRecord(StageHistoryData stageHistoryData, bool isIntermediateStage = false)
		{
			DateTime currentDate = stageHistoryData.Date ?? UserConnection.CurrentUser.GetCurrentDateTime();
			Entity newEntity = StageHistorySchema.CreateEntity(UserConnection);
			newEntity.SetColumnValue("Id", Guid.NewGuid());
			newEntity.SetColumnValue("RootEntityId", stageHistoryData.EntityId);
			newEntity.SetColumnValue("OwnerId", stageHistoryData.OwnerId);
			newEntity.SetColumnValue("StageId", stageHistoryData.Stage.StageId);
			newEntity.SetColumnValue("StartDate", currentDate);
			if (stageHistoryData.Stage.End || isIntermediateStage)
			{
				newEntity.SetColumnValue("DueDate", currentDate);
			}
			return newEntity;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Synchronizes stages with stage log
		/// </summary>
		/// <param name="oldStageId"> Old stage identifier </param>
		/// <param name="oldOwnerId"> Old owner identifier </param>
		/// <param name="rootEntity"> Root entity data </param>
		public virtual void SynchronizeStage(Guid oldStageId, Guid oldOwnerId, Entity rootEntity) {
			bool isOwnerChaged = oldOwnerId != rootEntity.GetTypedColumnValue<Guid>("OwnerId");
			bool isStateChanged = oldStageId != rootEntity.GetTypedColumnValue<Guid>("StageId");
			if (isStateChanged) {
				SynchronizeStage(oldStageId, rootEntity);
				return;
			}
			if (isOwnerChaged) {
				ChangeCurrentStageOwner(rootEntity);
			}
		}

		/// <summary>
		/// Synchronizes stages with stage log
		/// </summary>
		/// <param name="oldStageId"> Old stage identifier </param>
		/// <param name="rootEntity"> Root entity data </param>
		public virtual void SynchronizeStage(Guid oldStageId, Entity rootEntity) {
			var stages = GetStagesCollection().ToList();
			var rootEntityId = rootEntity.GetTypedColumnValue<Guid>(RootEntityColumns["Id"]);
			var rootEntityNewStageId = rootEntity.GetTypedColumnValue<Guid>(RootEntityColumns["Stage"]);
			var rootEntityNewStageOwnerId = rootEntity.GetTypedColumnValue<Guid>(RootEntityColumns["Owner"]);

			var newStageData = stages.FirstOrDefault(s => s.StageId == rootEntityNewStageId);
			var oldStageData = stages.FirstOrDefault(s => s.StageId == oldStageId);

			if (newStageData == null) {
				return;
			}
			if (oldStageData != null) {
				UpdateDueDateForLastStage(oldStageId, rootEntityId);
			}
			var isStagePrevious = oldStageData != null && newStageData.Number < oldStageData.Number;
			if (isStagePrevious) {
				UpdateIntermediateStages(newStageData.Number, rootEntityId);
			} else {
				var intermStages = GetIntermediateStages(stages, oldStageData, newStageData);
				CreateIntermediateStages(rootEntityId, rootEntityNewStageOwnerId, intermStages);
			}

			var currentDate = UserConnection.CurrentUser.GetCurrentDateTime();
			var stageHistoryData = new StageHistoryData {
				EntityId = rootEntity.GetTypedColumnValue<Guid>("Id"),
				Stage = newStageData,
				OwnerId = rootEntityNewStageOwnerId,
				Date = currentDate.AddSeconds(newStageData.Number)
			};

			var newHistoryRecord = CreateStageHistoryRecord(stageHistoryData);
			newHistoryRecord.Save();
		}

		#endregion

		#region Class: StageHistoryData

		/// <summary>
		/// Represents stage history data record
		/// </summary>
		public class StageHistoryData
		{
			/// <summary>
			/// identifier
			/// </summary>
			public Guid Id {
				get;
				set;
			}

			/// <summary>
			/// Entity identifier
			/// </summary>
			public Guid EntityId {
				get;
				set;
			}

			/// <summary>
			/// Owner identifier
			/// </summary>
			public Guid OwnerId {
				get;
				set;
			}

			/// <summary>
			/// Stage info
			/// </summary>
			public StageData Stage {
				get;
				set;
			}

			/// <summary>
			/// Start time
			/// </summary>
			public DateTime? Date {
				get;
				set;
			}
		}

		#endregion

		#region Class: StageData

		/// <summary>
		/// Represents stage data data record
		/// </summary>
		public class StageData
		{
			/// <summary>
			/// Stage identifier
			/// </summary>
			public Guid StageId {
				get;
				set;
			}

			/// <summary>
			/// Stage index number
			/// </summary>
			public int Number {
				get;
				set;
			}

			/// <summary>
			/// Is final stage
			/// </summary>
			public bool End {
				get;
				set;
			}
		}

		#endregion
	}

	#endregion
}
