namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.DB;

	#region Class: OpportunityEntityInStageData

	/// <summary>
	/// Opportunity in stage data contract.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EntityInStageData" />
	public class OpportunityInStageData : EntityInHistoricalStage
	{

	}

	#endregion

	#region Interface: IOpportunityInStageRepository

	/// <summary>
	/// Interface of opportunity in stage repository.
	/// Provides method for obtaining opportunity in stage identifiers with historical flag.
	/// </summary>
	/// <typeparam name="TOpportunityInStageData">The type of the opportunity in stage data.</typeparam>
	/// <seealso cref="BPMSoft.Configuration.IEntityInStageRepository{TOpportunityInStageData}" />
	public interface IOpportunityInStageRepository<TOpportunityInStageData> : IEntityInStageRepository<TOpportunityInStageData>
		where TOpportunityInStageData : OpportunityInStageData
	{
		/// <summary>
		/// Gets opportunity in stage identifiers with historical flag.
		/// </summary>
		/// <param name="opportunityId">The opportunity identifier.</param>
		/// <param name="newStageNumber">The new stage number.</param>
		/// <returns></returns>
		IEnumerable<Guid> GetHistoricalOpportunityInStage(Guid opportunityId, int newStageNumber);
	}

	#endregion

	#region Class: OpportunityInStageRepository

	/// <summary>
	/// The repository for opportunity in stage data.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EntityInStageRepository{BPMSoft.Configuration.OpportunityInStageData}" />
	/// <seealso cref="BPMSoft.Configuration.IOpportunityInStageRepository{BPMSoft.Configuration.OpportunityInStageData}" />
	public class OpportunityInStageRepository : EntityInStageRepository<OpportunityInStageData>,
		IOpportunityInStageRepository<OpportunityInStageData>
	{
		public OpportunityInStageRepository(UserConnection userConnection)
			: base(userConnection, "OpportunityInStage", "Opportunity") {
		}

		protected override void FillEntityFromObject(Entity entity, OpportunityInStageData item) {
			base.FillEntityFromObject(entity, item);
			entity.SetColumnValue("Historical", item.IsHistorical);
			entity.SetColumnValue("OwnerId", item.OwnerId);
		}

		protected override OpportunityInStageData CreateObjectFromEntity(Entity entity) {
			var item = base.CreateObjectFromEntity(entity);
			item.IsHistorical = entity.GetTypedColumnValue<bool>("Historical");
			item.OwnerId = entity.GetTypedColumnValue<Guid>("OwnerId");
			return item;
		}

		/// <summary>
		/// Gets historical opportunity in stage identifiers.
		/// </summary>
		/// <param name="opportunityId">The opportunity identifier.</param>
		/// <param name="newStageNumber">The new stage number.</param>
		/// <returns>Opportunity in stage identifiers with historical flag</returns>
		public IEnumerable<Guid> GetHistoricalOpportunityInStage(Guid opportunityId, int newStageNumber) {
			var notValidStageSelect = (Select) new Select(UserConnection)
				.Column("ois", "Id")
				.From("OpportunityInStage").As("ois")
				.InnerJoin("OpportunityStage").As("os").On("os", "Id").IsEqual("ois", "StageId")
				.Where("ois", "OpportunityId").IsEqual(Column.Parameter(opportunityId))
				.And("os", "Number").IsGreaterOrEqual(Column.Parameter(newStageNumber));
			var result = new List<Guid>();
			notValidStageSelect.ExecuteReader(reader => { result.Add(reader.GetColumnValue<Guid>("Id")); });
			return result;
		}
	}

	#endregion
}
