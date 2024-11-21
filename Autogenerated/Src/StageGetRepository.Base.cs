namespace BPMSoft.Configuration
{
	using System;
	using System.Data;
	using Common;
	using Core;
	using Core.DB;
	using Core.Entities;
	using Core.Factories;

	#region Class: GetStageRepository

	/// <summary>
	/// Provides methods to obtain stages.
	/// </summary>
	/// <typeparam name="TEntityData">Data</typeparam>
	[DefaultBinding(typeof(IGetRepository<CommonStageData>), Name = nameof(StageGetRepository))]
	public class StageGetRepository : GetRepository<CommonStageData> 
	{

		#region Constructors: Public

		public StageGetRepository(UserConnection userConnection, StageHistorySetting stageHistorySetting)
				: base(userConnection, stageHistorySetting.StageSchemaName) {
			StageHistorySetting = stageHistorySetting;
		}

		#endregion

		#region Properties: Protected

		protected StageHistorySetting StageHistorySetting { get; }

		private EntitySchema _schemaInstance;

		protected EntitySchema SchemaInstance => _schemaInstance ?? (_schemaInstance = CreateSchemaInstance());

		#endregion

		#region Methods: Private

		private bool HasSuccessfulColumn() {
			return SchemaInstance.Columns.FindByName(StageHistorySetting.StageIsSuccessfulColumnName) != null;
		}

		private EntitySchema CreateSchemaInstance() {
			return UserConnection.EntitySchemaManager.FindInstanceByName(StageHistorySetting.StageSchemaName);
		}

		private void AddDisplayColumn(Select select) {
			var displayColumnName = SchemaInstance.GetPrimaryDisplayColumnName();
			if (SchemaInstance.IsLocalizable) {
				var localizationSchema = SchemaInstance.GetLocalizationSchema();
				var localizationSchemaName = localizationSchema.Name;
				Guid currentUserCultureId = UserConnection.CurrentUser.SysCultureId;
				select.Column(Func.IsNull(Column.SourceColumn(localizationSchemaName, displayColumnName),
						Column.SourceColumn(SchemaInstance.Name, displayColumnName))).As(displayColumnName)
					.Join(JoinType.LeftOuter, localizationSchemaName)
						.On(SchemaInstance.Name, "Id").IsEqual(localizationSchemaName, "RecordId")
						.And(localizationSchemaName, "SysCultureId").IsEqual(Column.Parameter(currentUserCultureId));
			} else {
				select.Column(SchemaInstance.Name, displayColumnName).As(displayColumnName);
			}
		}

		#endregion

		#region Methods: Protected

		protected override Select GetSelect() {
			var select = base.GetSelect();
			var schemaName = StageHistorySetting.StageSchemaName;
			select
				.Column(schemaName, StageHistorySetting.StageOrderColumnName)
					.As(StageHistorySetting.StageOrderColumnName)
				.Column(schemaName, StageHistorySetting.StageIsFinalColumnName)
					.As(StageHistorySetting.StageIsFinalColumnName)
				.From(StageHistorySetting.StageSchemaName);
			if (HasSuccessfulColumn()) {
				select.Column(schemaName, StageHistorySetting.StageIsSuccessfulColumnName)
					.As(StageHistorySetting.StageIsSuccessfulColumnName);
			}
			AddDisplayColumn(select);
			return select;
		}

		protected override CommonStageData GetData(IDataReader reader) {
			var result = base.GetData(reader);
			result.Number = reader.GetColumnValue<int>(StageHistorySetting.StageOrderColumnName);
			result.IsEnd = reader.GetColumnValue<bool>(StageHistorySetting.StageIsFinalColumnName);
			result.DisplayValue = reader.GetColumnValue<string>(SchemaInstance.GetPrimaryDisplayColumnName());
			if (HasSuccessfulColumn()) {
				result.IsSuccessful = reader.GetColumnValue<bool>(StageHistorySetting.StageIsSuccessfulColumnName);
			}
			return result;
		}

		#endregion

	}

	#endregion

}

