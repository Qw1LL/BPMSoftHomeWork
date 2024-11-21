namespace BPMSoft.Configuration
{
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: FullPipelineStageGetRepository

	/// <summary>
	/// Provides methods of return show in funnel stages.
	/// </summary>
	[DefaultBinding(typeof(IGetRepository<CommonStageData>), Name = "ShowInFunnelStages")]
	public class FullPipelineStageGetRepository : StageGetRepository
	{

		#region Fields: Private

		private readonly string _defaultShowInFunnelColumnName = "ShowInFunnel";

		#endregion

		#region Constructors: Public

		public FullPipelineStageGetRepository(UserConnection userConnection, StageHistorySetting stageHistorySetting)
			: base(userConnection, stageHistorySetting) {
		}

		#endregion

		#region Methods: Protected

		protected override Select GetSelect() {
			var select = base.GetSelect();
			AddShowInFunnelFilter(select);
			return select;
		}

		protected virtual void AddShowInFunnelFilter(Select select) {
			var displayingColumnName = _defaultShowInFunnelColumnName;
			//TODO: Must be removed while use DCM stages.
			if (StageHistorySetting.StageSchemaName.Equals("QualifyStatus")) {
				displayingColumnName = "IsDisplayed";
			}
			if (select.HasCondition) {
				select.And(displayingColumnName).IsEqual(Column.Parameter(true));
				return;
			}
			select.Where(displayingColumnName).IsEqual(Column.Parameter(true));
		}

		#endregion

	}

	#endregion

}

