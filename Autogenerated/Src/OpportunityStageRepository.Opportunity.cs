namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;

	#region Class: OpportunityEntityStageData

	/// <summary>
	/// Opportunity stage data contract.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.StageData" />
	public class OpportunityStageData : CommonStageData
	{

	}

	#endregion

	#region Class: OpportunityStageRepository

	/// <summary>
	/// The repository for opportunity stage data.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.EntityStageRepository{BPMSoft.Configuration.OpportunityStageData}" />
	public class OpportunityStageRepository : EntityStageRepository<OpportunityStageData>
	{
		#region Constants: Public

		public const string OpportunityCacheGroupName = "OpportunityStages";

		#endregion

		#region Constructors: Public

		public OpportunityStageRepository(UserConnection userConnection)
			: base(userConnection, "OpportunityStage", OpportunityCacheGroupName) {
		}

		#endregion

		#region Methods: Protected

		protected override OpportunityStageData CreateObjectFromEntity(Entity stage) {
			OpportunityStageData data = base.CreateObjectFromEntity(stage);
			data.IsSuccessful = stage.GetTypedColumnValue<bool>("Successful");
			return data;
		}

		protected override EntitySchemaQuery GetEntityCollectionEsq() {
			var esq = base.GetEntityCollectionEsq();
			esq.AddColumn("Successful");
			return esq;
		}

		#endregion
	}

	#endregion
}
