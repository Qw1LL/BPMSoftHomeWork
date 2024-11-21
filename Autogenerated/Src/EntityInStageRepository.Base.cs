namespace BPMSoft.Configuration
{
	using System;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: EntityInStageData

	/// <summary>
	/// Entity in stage data contract.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EntityData" />
	public class EntityInStageData : EntityData
	{
		/// <summary>
		/// Gets or sets the entity identifier.
		/// </summary>
		/// <value>
		/// The entity identifier.
		/// </value>
		public Guid EntityId { get; set; }

		/// <summary>
		/// Gets or sets the owner identifier.
		/// </summary>
		/// <value>
		/// The stage owner identifier.
		/// </value>
		public Guid OwnerId { get; set; }

		/// <summary>
		/// Gets or sets the stage identifier.
		/// </summary>
		/// <value>
		/// The stage identifier.
		/// </value>
		public Guid StageId { get; set; }

		/// <summary>
		/// Gets or sets the stage start date.
		/// </summary>
		/// <value>
		/// The stage start date.
		/// </value>
		public DateTime? StartDate { get; set; }

		/// <summary>
		/// Gets or sets the stage end date.
		/// </summary>
		/// <value>
		/// The stage end date.
		/// </value>
		public DateTime? EndDate { get; set; }
	}

	#endregion

	#region Interface: IEntityInStageRepository

	/// <summary>
	/// Interface of entity in stage repository. 
	/// Provides method for obtaining last opportunity in stage data.
	/// </summary>
	/// <typeparam name="TEntityData">The type of the entity data.</typeparam>
	/// <seealso cref="BPMSoft.Configuration.IEntityRepository{TEntityData}" />
	public interface IEntityInStageRepository<TEntityData> : IEntityRepository<TEntityData>
		where TEntityData : EntityData
	{
		/// <summary>
		/// Gets the last entity in stage data.
		/// </summary>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="stageId">The stage identifier.</param>
		/// <returns></returns>
		TEntityData GetLastEntityInStage(Guid entityId, Guid stageId);
	}

	#endregion

	#region Class: EntityInStageRepository

	/// <summary>
	/// The repository for entity in stage data.
	/// </summary>
	/// <typeparam name="TEntityInStage">The type of the entity in stage.</typeparam>
	/// <seealso cref="BPMSoft.Configuration.EntityRepository{TEntityInStage}" />
	/// <seealso cref="BPMSoft.Configuration.IEntityInStageRepository{TEntityInStage}" />
	public class EntityInStageRepository<TEntityInStage> : EntityRepository<TEntityInStage>,
		IEntityInStageRepository<TEntityInStage>
		where TEntityInStage : EntityInStageData, new()
	{

		#region Properties: Protected

		protected string EntitySchemaColumnName { get; }


		private StageHistorySetting _stageHistorySetting;
		protected StageHistorySetting StageHistorySetting {
			get => _stageHistorySetting ?? (_stageHistorySetting = ClassFactory.Get<StageHistorySetting>(
				new ConstructorArgument("userConnection", UserConnection)));
			set => _stageHistorySetting = value;
		}
		#endregion

		#region Constructors: Public

		public EntityInStageRepository(UserConnection userConnection, string entitySchemaName, 
				string entitySchemaColumnPath) : base(userConnection, entitySchemaName) {
			EntitySchemaColumn entitySchemaColumn = SchemaInstance.FindSchemaColumnByPath(entitySchemaColumnPath);
			EntitySchemaColumnName = entitySchemaColumn.Name;
		}

		public EntityInStageRepository(UserConnection userConnection, StageHistorySetting stageHistorySetting)
				: base(userConnection, stageHistorySetting.StageHistorySchemaName) {
			StageHistorySetting = stageHistorySetting;
			EntitySchemaColumnName = stageHistorySetting.StageHistoryMainEntityColumnName;
		}

		#endregion

		#region Methods: Private

		private void SetLastEntityInStageFilters(EntitySchemaQuery esq, Guid entityId, Guid stageId) {
			IEntitySchemaQueryFilterItem entityFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, EntitySchemaColumnName, entityId);
			IEntitySchemaQueryFilterItem stageFilter =
				esq.CreateFilterWithParameters(FilterComparisonType.Equal, StageHistorySetting.StageHistoryStageColumnName, stageId);
			esq.Filters.Add(entityFilter);
			esq.Filters.Add(stageFilter);
		}

		#endregion

		#region Methods: Protected

		protected override TEntityInStage CreateObjectFromEntity(Entity entity) {
			var item = base.CreateObjectFromEntity(entity);
			item.StageId = entity.GetTypedColumnValue<Guid>($"{StageHistorySetting.StageHistoryStageColumnName}Id");
			item.StartDate = entity.GetTypedColumnValue<DateTime>(StageHistorySetting.StageHistoryStartDateColumnName);
			item.EndDate = entity.GetTypedColumnValue<DateTime>(StageHistorySetting.StageHistoryDueDateColumnName);
			item.EntityId = entity.GetTypedColumnValue<Guid>($"{EntitySchemaColumnName}Id");
			return item;
		}

		protected override void FillEntityFromObject(Entity entity, TEntityInStage item) {
			base.FillEntityFromObject(entity, item);
			entity.SetColumnValue($"{StageHistorySetting.StageHistoryStageColumnName}Id", item.StageId);
			entity.SetColumnValue($"{EntitySchemaColumnName}Id", item.EntityId);
			entity.SetColumnValue(StageHistorySetting.StageHistoryStartDateColumnName, item.StartDate);
			entity.SetColumnValue(StageHistorySetting.StageHistoryDueDateColumnName, item.EndDate);
		}

		protected virtual EntitySchemaQuery GetEntityInStageEsq(Guid entityId, Guid stageId) {
			var esq = new EntitySchemaQuery(SchemaInstance);
			esq.AddAllSchemaColumns();
			SetLastEntityInStageFilters(esq, entityId, stageId);
			esq.Columns.FindByName("CreatedOn").OrderByDesc();
			esq.RowCount = 1;
			return esq;
		}
		
		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets the last entity in stage.
		/// </summary>
		/// <param name="entityId">The connected entity identifier.</param>
		/// <param name="stageId">The stage identifier.</param>
		/// <returns>Entity in stage data.</returns>
		/// <exception cref="Common.ItemNotFoundException"></exception>
		public TEntityInStage GetLastEntityInStage(Guid entityId, Guid stageId) {
			var esq = GetEntityInStageEsq(entityId, stageId);
			Entity entity = esq.GetEntityCollection(UserConnection).FirstOrDefault();
			if (entity == null) {
				throw new Common.ItemNotFoundException(
					$"{SchemaInstance.Name} with stageId={stageId} and {EntitySchemaColumnName}Id={entityId}");
			}
			TEntityInStage result = CreateObjectFromEntity(entity);
			return result;
		}

		#endregion
	}

	#endregion
}
