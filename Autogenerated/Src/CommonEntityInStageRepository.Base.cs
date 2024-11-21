namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using Core.Factories;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;

	#region Class: EntityInHistorycalStage

	/// <summary>
	/// Entity in stage data contract.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EntityInStageData" />
	public class EntityInHistoricalStage : EntityInStageData
	{
		/// <summary>
		/// Gets or sets a value indicating whether stage in opportunity is historical.
		/// </summary>
		/// <value>
		///   <c>true</c> if stage in entity is historical; otherwise, <c>false</c>.
		/// </value>
		public bool IsHistorical { get; set; }
	}

	#endregion

	#region Interface: ICommonEntityInStageRepository

	/// <summary>
	/// Declares common entity in stage repository methods.
	/// </summary>
	/// <typeparam name="TEntityInStageData">The type of the entity in stage data.</typeparam>
	/// <seealso cref="BPMSoft.Configuration.IEntityInStageRepository{TEntityInStageData}" />
	public interface ICommonEntityInStageRepository<TEntityInStageData> : IEntityInStageRepository<TEntityInStageData>
		where TEntityInStageData : EntityInHistoricalStage
	{
		/// <summary>
		/// Gets entity in stage identifiers with historical flag.
		/// </summary>
		/// <param name="opportunityId">The entity identifier.</param>
		/// <param name="newStageNumber">The new stage number.</param>
		/// <returns></returns>
		IEnumerable<Guid> GetHistoricalEntityInStage(Guid entityId, int newStageNumber);
	}

	#endregion

	#region Class: CommonEntityInStageRepository

	/// <summary>
	/// Common configurable repository for entity in stage object.
	/// </summary>
	/// <seealso cref="EntityInHistoricalStage" />
	/// <seealso cref="EntityInHistoricalStage" />
	[DefaultBinding(typeof(ICommonEntityInStageRepository<EntityInHistoricalStage>))]
	public class CommonEntityInStageRepository : EntityInStageRepository<EntityInHistoricalStage>,
		ICommonEntityInStageRepository<EntityInHistoricalStage>
	{

		#region Constructors: Public

		public CommonEntityInStageRepository(UserConnection userConnection, StageHistorySetting stageHistorySetting)
			: base(userConnection, stageHistorySetting) {
		}

		#endregion

		#region Methods: Private

		private bool HasHistoricalColumn() {
			return SchemaInstance.Columns.FindByName(StageHistorySetting.StageHistoryHistoricalColumnName) != null;
		}

		#endregion

		#region Methods: Protected

		protected override void FillEntityFromObject(Entity entity, EntityInHistoricalStage item) {
			base.FillEntityFromObject(entity, item);
			if (HasHistoricalColumn()) {
				entity.SetColumnValue(StageHistorySetting.StageHistoryHistoricalColumnName, item.IsHistorical);
			}
		}

		protected override EntityInHistoricalStage CreateObjectFromEntity(Entity entity) {
			var item = base.CreateObjectFromEntity(entity);
			if (HasHistoricalColumn()) {
				item.IsHistorical = entity.GetTypedColumnValue<bool>(StageHistorySetting.StageHistoryHistoricalColumnName);
			}
			return item;
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Gets historical entity in stage identifiers.
		/// </summary>
		/// <param name="entityId">The entity identifier.</param>
		/// <param name="newStageNumber">The new stage number.</param>
		/// <returns>Entity in stage identifiers with historical flag</returns>
		public IEnumerable<Guid> GetHistoricalEntityInStage(Guid entityId, int newStageNumber) {
			var notValidStageSelect = (Select)new Select(UserConnection)
					.Column("eis", "Id")
				.From(StageHistorySetting.StageHistorySchemaName).As("eis")
				.InnerJoin(StageHistorySetting.StageSchemaName).As("es").On("es", "Id")
					.IsEqual("eis", $"{StageHistorySetting.StageHistoryStageColumnName}Id")
				.Where("eis", $"{StageHistorySetting.StageHistoryMainEntityColumnName}Id").IsEqual(Column.Parameter(entityId))
					.And("es", StageHistorySetting.StageOrderColumnName)
						.IsGreaterOrEqual(Column.Parameter(newStageNumber));
			var result = new List<Guid>();
			notValidStageSelect.ExecuteReader(reader => { result.Add(reader.GetColumnValue<Guid>("Id")); });
			return result;
		}

		#endregion

	}

	#endregion
}
