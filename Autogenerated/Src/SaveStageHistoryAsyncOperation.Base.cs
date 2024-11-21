namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Factories;

	#region Class: SaveStageHistoryAsyncOperation

	/// <inheritdoc />
	public class SaveStageHistoryAsyncOperation : IEntityEventAsyncOperation
	{

		#region Methods: Private

		private IEntityStageManagerV2 GetEntityStageManager(UserConnection userConnection,
				StageHistorySetting setting) {
			var entityStageRepository = ClassFactory.Get<IGetRepository<CommonStageData>>("StageGetRepository",
				new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("stageHistorySetting", setting));
			var cacheGetRepositoryProxy = ClassFactory.Get<CacheGetRepositoryProxy<CommonStageData>>(
				new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("repository", entityStageRepository),
				new ConstructorArgument("schemaName", setting.StageSchemaName));
			var entityInStageRepository = ClassFactory.Get<ICommonEntityInStageRepository<EntityInHistoricalStage>>(
				new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("stageHistorySetting", setting));
			return ClassFactory.Get<IEntityStageManagerV2>(new ConstructorArgument("userConnection", userConnection),
				new ConstructorArgument("entityStageRepository", cacheGetRepositoryProxy),
				new ConstructorArgument("entityInStageRepository", entityInStageRepository),
				new ConstructorArgument("stageHistorySetting", setting));
		}

		private ISysModuleStageHistoryRepository GetHistorySettingsRepository(UserConnection userConnection) {
			return ClassFactory
				.Get<ISysModuleStageHistoryRepository>(new ConstructorArgument("userConnection", userConnection));
		}

		private StageHistorySetting GetActiveStageHistorySetting(UserConnection userConnection, Guid schemaUId) {
			var historySettingsRepository = GetHistorySettingsRepository(userConnection);
			var historySetting = historySettingsRepository.Find(schemaUId);
			if (historySetting == null) {
				return null;
			}
			return historySetting.IsActive ? historySetting : null;
		}

		private IEnumerable<EntityColumnValue> GetEntityColumnOldValues(UserConnection userConnection,
				EntityEventAsyncOperationArgs arguments) {
			var columnValues = arguments.EntityColumnValues.Select(e => {
				arguments.OldEntityColumnValues.TryGetValue(e.Key, out var oldValue);
				return new EntityColumnValue(userConnection) {
					Value = e.Value,
					OldValue = oldValue,
					Name = e.Key,
					IsLoaded = true
				};
			});
			return columnValues;
		}

		private void FillEntityColumnValues(Entity entity, EntityEventAsyncOperationArgs arguments) {
			foreach (var column in arguments.EntityColumnValues) {
				entity.SetColumnValue(column.Key, column.Value);
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc />
		public void Execute(UserConnection userConnection, EntityEventAsyncOperationArgs arguments) {
			var entitySchema = userConnection.EntitySchemaManager.GetInstanceByName(arguments.EntitySchemaName);
			var setting = GetActiveStageHistorySetting(userConnection, entitySchema.UId);
			if (setting == null || entitySchema == null) {
				return;
			}
			var entity = entitySchema.CreateEntity(userConnection);
			FillEntityColumnValues(entity, arguments);
			entity.SetColumnValue(entitySchema.PrimaryColumn.Name, arguments.EntityId);
			var columnOldValues = GetEntityColumnOldValues(userConnection, arguments);
			var stageManager = GetEntityStageManager(userConnection, setting);
			stageManager.SynchronizeStage(entity, columnOldValues);
		}

		#endregion

	}

	#endregion

}

