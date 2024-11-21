namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Common;
	using BPMSoft.Core.Factories;

	#region Interface: IEntityStageManager

	/// <summary>
	/// Interface of entity stage manager.
	/// Provides method for entity stage synchronization.
	/// </summary>
	public interface IEntityStageManager
	{
		/// <summary>
		/// Synchronizes the stage.
		/// </summary>
		/// <param name="oldStageId">The old stage identifier.</param>
		/// <param name="oldOwnerId">The old owner identifier.</param>
		/// <param name="entity">The entity.</param>
		void SynchronizeStage(Guid oldStageId, Guid oldOwnerId, Entity entity);
	}

	#endregion

	#region Interface: IEntityStageManagerV2

	/// <inheritdoc />
	public interface IEntityStageManagerV2 : IEntityStageManager
	{

		/// <summary>
		/// Synchronizes the stage.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="entityOldValues">The entity old values.</param>
		void SynchronizeStage(Entity entity, IEnumerable<EntityColumnValue> entityOldValues);
	}

	#endregion

	#region Class: EntityStageManager

	/// <summary>
	/// The manager for entity stages.
	/// </summary>
	/// <typeparam name="TEntityInStage">The type of the entity in stage.</typeparam>
	/// <typeparam name="TStageData">The type of the stage data.</typeparam>
	/// <typeparam name="TEntityInStageRepository">The type of the entity in stage repository.</typeparam>
	/// <seealso cref="BPMSoft.Configuration.IEntityStageManager" />
	public class EntityStageManager<TEntityInStage, TStageData, TEntityInStageRepository> : IEntityStageManagerV2
		where TEntityInStage : EntityInStageData, new()
		where TStageData : StageData, new()
		where TEntityInStageRepository: IEntityInStageRepository<TEntityInStage>
	{

		#region Fields: Private

		private IEnumerable<TStageData> _stages;
		
		private StageHistorySetting _stageHistorySetting;

		#endregion
		
		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		protected IGetRepository<TStageData> EntityStageRepository { get; }

		protected TEntityInStageRepository EntityInStageRepository { get; }

		protected StageHistorySetting StageHistorySetting {
			get => _stageHistorySetting ?? (_stageHistorySetting = ClassFactory
				.Get<StageHistorySetting>(new ConstructorArgument("userConnection", UserConnection)));
			set => _stageHistorySetting = value;
		}

		protected IEnumerable<TStageData> Stages => _stages ?? (_stages = EntityStageRepository.GetAll());

		#endregion

		#region Constructors: Public

		public EntityStageManager(UserConnection userConnection, IEntityRepository<TStageData> entityStageRepository,
				TEntityInStageRepository entityInStageRepository) {
			UserConnection = userConnection;
			EntityStageRepository = entityStageRepository;
			EntityInStageRepository = entityInStageRepository;
		}

		public EntityStageManager(UserConnection userConnection, IGetRepository<TStageData> entityStageRepository,
			TEntityInStageRepository entityInStageRepository,
			StageHistorySetting stageHistorySetting) {
			UserConnection = userConnection;
			EntityStageRepository = entityStageRepository;
			EntityInStageRepository = entityInStageRepository;
			StageHistorySetting = stageHistorySetting;
		}

		#endregion

		#region Methods: Private

		private void AddNewStageRecord(Entity entity, TStageData newStageData) {
			var entityInStage = FormNewStageHistoryRecord(entity, newStageData);
			EntityInStageRepository.Add(entityInStage);
		}
		
		private TStageData GetStageDataById(Guid stageId) {
			return Stages.FirstOrDefault(member => member.Id.Equals(stageId));
		}
	
		#endregion

		#region Methods: Protected

		protected void ChangeCurrentStageOwner(Guid entityId, Guid entityStageId, Guid ownerId) {
			Guid lastEntityInStageId = EntityInStageRepository.GetLastEntityInStage(entityId, entityStageId).Id;
			EntityInStageRepository.Update(lastEntityInStageId, new Dictionary<string, object> {
				{"OwnerId", ownerId}
			});
		}

		protected T GetOldColumnValue<T>(Entity entity, IEnumerable<EntityColumnValue> entityValues, string columnName) {
			EntityColumnValue columnValue = entityValues.FirstOrDefault(column => column.Name == columnName);
			if (columnValue == null) {
				return entity.GetTypedColumnValue<T>(columnName);
			}
			if (columnValue.OldValue is T variable) {
				return variable;
			}
			return default(T);
		}

		[Obsolete("7.12.3 | Method is deprecated. Use CreateIntermediateStages(Entity entity, " +
			"IEnumerable<TStageData> intermediateStages)")]
		protected void CreateIntermediateStages(Guid entityId, Guid stageOwnerId, IEnumerable<StageData> intermediateStages) {
			var currentDate = GetCurrentDateTime();
			intermediateStages.ForEach(stage => {
				EntityInStageRepository.Add(new TEntityInStage {
					StageId = stage.Id,
					EntityId = entityId,
					OwnerId = stageOwnerId,
					StartDate = currentDate.AddSeconds(stage.Number),
					EndDate = currentDate.AddSeconds(stage.Number)
				});
			});
		}

		protected void CreateIntermediateStages(Entity entity, IEnumerable<TStageData> intermediateStages) {
			intermediateStages.ForEach(stage => {
				EntityInStageRepository.Add(FormIntermediateStageRecord(entity, stage));
			});
		}

		protected virtual TEntityInStage FormIntermediateStageRecord(Entity entity, TStageData stage) {
			var entityId = entity.PrimaryColumnValue;
			var currentDate = GetCurrentDateTime();
			return new TEntityInStage {
				StageId = stage.Id,
				EntityId = entityId,
				StartDate = currentDate.AddSeconds(stage.Number),
				EndDate = currentDate.AddSeconds(stage.Number)
			};
		}

		protected IEnumerable<TStageData> GetIntermediateStages(IEnumerable<TStageData> stages, TStageData oldStage,
				TStageData newStage) {
			var intermediateStages = oldStage == null
				? stages.Where(stage => stage.Number < newStage.Number)
				: stages.Where(stage => stage.Number > oldStage.Number && stage.Number < newStage.Number && !stage.IsEnd);
			return intermediateStages.OrderBy(stage => stage.Number).ToList();
		}

		[Obsolete("7.12.3 | Method is deprecated. Use ProcessPreviousStages(Entity entity, " +
			"TStageData oldStageData, TStageData newStageData) instead.")]
		protected virtual void ProcessPreviousStages(Guid entityId, Guid newStageOwnerId, TStageData oldStageData,
			TStageData newStageData) {
		}

		protected virtual void ProcessPreviousStages(Entity entity, TStageData oldStageData,
			TStageData newStageData) {
		}

		[Obsolete("7.12.3 | Method is deprecated. Use ProcessIntermediateStages(Entity entity, " +
			"TStageData oldStageData, TStageData newStageData) instead.")]
		protected virtual void ProcessIntermediateStages(Guid entityId, Guid newStageOwnerId, TStageData oldStageData,
				TStageData newStageData) {
			var intermediateStages = GetIntermediateStages(Stages, oldStageData, newStageData);
			CreateIntermediateStages(entityId, newStageOwnerId, intermediateStages);
		}

		protected virtual void ProcessIntermediateStages(Entity entity, TStageData oldStageData,
				TStageData newStageData) {
			var intermediateStages = GetIntermediateStages(Stages, oldStageData, newStageData);
			CreateIntermediateStages(entity, intermediateStages);
		}

		protected virtual bool GetIsStagePrevious(TStageData oldStageData, TStageData newStageData) {
			return oldStageData != null && newStageData.Number < oldStageData.Number;
		}

		protected virtual void UpdateDueDateForLastStage(Guid oldStageId, Guid entityId) {
			Guid lastEntityInStageId;
			try {
				lastEntityInStageId = EntityInStageRepository.GetLastEntityInStage(entityId, oldStageId).Id;
			}
			catch (Common.ItemNotFoundException) {
				return;
			}
			DateTime currentDate = GetCurrentDateTime();
			var values = new Dictionary<string, object> {
				{StageHistorySetting.StageHistoryDueDateColumnName, currentDate}
			};
			EntityInStageRepository.Update(lastEntityInStageId, values);
		}

		protected virtual DateTime GetCurrentDateTime() {
			return UserConnection.CurrentUser.GetCurrentDateTime();
		}

		protected virtual void SynchronizeStage(Guid oldStageId, Entity entity) {
			Guid entityId = entity.PrimaryColumnValue;
			Guid newStageId = entity.GetTypedColumnValue<Guid>($"{StageHistorySetting.StageColumnName}Id");
			if (newStageId == oldStageId) {
				return;
			}
			var newStageData = GetStageDataById(newStageId);
			var oldStageData = GetStageDataById(oldStageId);
			if (oldStageData != null) {
				UpdateDueDateForLastStage(oldStageId, entityId);
			}
			var isStagePrevious = GetIsStagePrevious(oldStageData, newStageData);
			if (isStagePrevious) {
				ProcessPreviousStages(entity, oldStageData, newStageData);
			} else {
				ProcessIntermediateStages(entity, oldStageData, newStageData);
			}
			AddNewStageRecord(entity, newStageData);
		}

		protected virtual TEntityInStage FormNewStageHistoryRecord(Entity entity, TStageData newStageData) {
			DateTime currentDate = GetCurrentDateTime();
			var newStageId = entity.GetTypedColumnValue<Guid>($"{StageHistorySetting.StageColumnName}Id");
			var startDate = currentDate.AddSeconds(newStageData.Number);
			var result = new TEntityInStage {
				EntityId = entity.GetTypedColumnValue<Guid>("Id"),
				StageId = newStageId,
				StartDate = startDate
			};
			if (newStageData.IsEnd) {
				result.EndDate = startDate;
			}
			return result;
		}

		protected virtual void ProcessColumnValues(Entity entity, IEnumerable<EntityColumnValue> entityValues) {
			Guid oldStageId = GetOldColumnValue<Guid>(entity, entityValues, $"{StageHistorySetting.StageColumnName}Id");
			SynchronizeStage(oldStageId, entity);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Synchronizes the stage.
		/// </summary>
		/// <param name="oldStageId">The old stage identifier.</param>
		/// <param name="oldOwnerId">The old owner identifier.</param>
		/// <param name="entity">The entity.</param>
		[Obsolete("7.12.3 | Method is deprecated. Use SynchronizeStage(Entity, IEnumerable<EntityColumnValue>) instead.")]	
		public void SynchronizeStage(Guid oldStageId, Guid oldOwnerId, Entity entity) {
			Guid entityStageId = entity.GetTypedColumnValue<Guid>("StageId");
			Guid ownerId = entity.GetTypedColumnValue<Guid>("OwnerId");
			bool isOwnerChaged = oldOwnerId != ownerId;
			bool isStateChanged = oldStageId != entityStageId;
			if (isStateChanged) {
				SynchronizeStage(oldStageId, entity);
			}
			else if (isOwnerChaged) {
				var entityId = entity.GetTypedColumnValue<Guid>("Id");
				ChangeCurrentStageOwner(entityId, entityStageId, ownerId);
			}
		}

		/// <summary>
		/// Synchronizes the stage.
		/// </summary>
		/// <param name="entity">The entity.</param>
		/// <param name="entityValues">The entity old values.</param>
		public void SynchronizeStage(Entity entity, IEnumerable<EntityColumnValue> entityValues) {
			ProcessColumnValues(entity, entityValues);
		}

		#endregion

	}

	#endregion
	
}

