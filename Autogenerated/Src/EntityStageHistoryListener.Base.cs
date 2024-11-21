namespace BPMSoft.Configuration
{
	using Core;
	using Core.Entities;
	using Core.Entities.AsyncOperations;
	using Core.Entities.AsyncOperations.Interfaces;
	using Core.Entities.Events;
	using Core.Factories;

	#region Class: EntityStageHistoryListener

	[EntityEventListener(IsGlobal = true)]
	public class EntityStageHistoryListener : BaseEntityEventListener
	{

		#region Methods: Private
		
		private static ISysModuleStageHistoryRepository GetHistorySettingsRepository(UserConnection userConnection) {
			return ClassFactory
				.Get<ISysModuleStageHistoryRepository>(new ConstructorArgument("userConnection", userConnection));
		}

		private static bool IsStagedEntity(Entity entity, StageHistorySetting setting) {
			return setting?.IsActive ?? false;
		}
		
		private static bool IsChangedColumn(EntityAfterEventArgs entityAfterEventArgs, StageHistorySetting setting) {
			var column = entityAfterEventArgs?.ModifiedColumnValues?.FindByName(setting.StageColumnName + "Id");
			return column != null;
		}
		
		private static StageHistorySetting GetStageHistorySetting(Entity entity) {
			var historySettingsRepository = GetHistorySettingsRepository(entity.UserConnection);
			var setting = historySettingsRepository.Find(entity.Schema.UId);
			return setting;
		}

		private static void ExecuteStageHistoryAsyncOperation(EntityAfterEventArgs e, Entity entity) {
			var asyncExecutor = ClassFactory.Get<IEntityEventAsyncExecutor>(
				new ConstructorArgument("userConnection", entity.UserConnection));
			var operationArgs = new EntityEventAsyncOperationArgs(entity, e);
			asyncExecutor.ExecuteAsync<SaveStageHistoryAsyncOperation>(operationArgs);
		}

		#endregion
		
		#region Methods: Public

		public override void OnSaved(object sender, EntityAfterEventArgs e) {
			base.OnSaved(sender, e);
			var entity = (Entity) sender;
			if (!entity.UserConnection.GetIsFeatureEnabled("EntityStageHistoryJournaling")) {
				return;
			}
			var setting = GetStageHistorySetting(entity);
			if (IsStagedEntity(entity, setting) && IsChangedColumn(e, setting)) {
				ExecuteStageHistoryAsyncOperation(e, entity);
			}
		}

		#endregion
		
	}

	#endregion
	
}

