namespace BPMSoft.Configuration
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Configuration.ForecastV2;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;
	using Consts = ForecastHistoryRowConstants;

	#region Class: ForecastHistoryRowConstants

	/// <summary>
	/// Provides forecast history cell constants.
	/// </summary>
	public static class ForecastHistoryRowConstants
	{
		public static readonly string RowSchemaName = "ForecastHistoryRow";
		public static readonly string ForecastSnapshotSchemaName = "ForecastSnapshot";
		public static readonly string EntityColumnName = "EntityId";
		public static readonly string SheetColumnName = "SheetId";
		public static readonly string SnapshotColumnName = "SnapshotId";
		public static readonly string IdColumnName  = "Id";
		public static readonly string RowColumnName = "RowId";
		public static readonly string SnapshotDateColumnName = "Date";
		public static readonly string DeletedOnColumnName = "DeletedOn";
		public static readonly string SnapshotDateQueryAlias = "fs_date";
	}

	#endregion

	#region Class: ForecastHistoryRowData

	/// <summary>
	/// Provides properties for forecast history row data.
	/// </summary>
	public class ForecastHistoryRowData
	{
		/// <summary>
		/// Gets or sets the sheet identifier.
		/// </summary>
		/// <value>
		/// The sheet identifier.
		/// </value>
		public Guid SheetId { get; set; }

		/// <summary>
		/// Gets or sets the snapshot identifier.
		/// </summary>
		/// <value>
		/// The snapshot identifier.
		/// </value>
		public Guid SnapshotId { get; set; }

		/// <summary>
		/// Gets or sets the row identifier.
		/// </summary>
		/// <value>
		/// The forecast row identifier.
		/// </value>
		public Guid RowId { get; set; }

		/// <summary>
		/// Gets or sets the entity identifier.
		/// </summary>
		/// <value>
		/// The entity identifier.
		/// </value>
		public Guid EntityId { get; set; }
	}

	#endregion

	#region Class: ForecastHistoricalRowsDeleteParams

	/// <summary>
	/// Parameters for forecast historical rows delete operation.
	/// </summary>
	public class ForecastHistoricalRowsDeleteParams
	{
		public Guid SheetId { get; set; }

		public IEnumerable<Guid> RowsIds { get; set; }

		public DateTime DeletedOn { get; set; }
	}

	#endregion
	#region Interface: IForecastHistoricalHierarchyRowDataRepository

	/// <summary>
	/// Provides methods for manipulating with history rows in the forecast.
	/// </summary>
	public interface IForecastHistoricalHierarchyRowDataRepository : IForecastHierarchyRowDataRepository
	{
		/// <summary>
		/// Insert the hierarchy rows.
		/// </summary>
		/// <param name="historyRows">The hierarchy rows.</param>
		void InsertRows(IEnumerable<ForecastHistoryRowData> historyRows);

		/// <summary>
		/// Sets historical rows deleted.
		/// </summary>
		/// <param name="parameters">Delete operation parameters.</param>
		void DeleteRows(ForecastHistoricalRowsDeleteParams parameters);
	}

	#endregion

	#region Interface: IForecastHistoricalHierarchyRowDataRepository

	[DefaultBinding(typeof(IForecastHistoricalHierarchyRowDataRepository), Name = "Default")]
	public class ForecastHistoryRowRepository : BaseForecastHierarchyRowRepository, IForecastHistoricalHierarchyRowDataRepository, ISnapshot
	{
		#region Properties: Private

		private ChunksConfig ChunksConfig => new ChunksConfig() {
			InsertColumnsCount = 4,
			MaxParametersCounterPerQueryChunk = 1000
		};

		#endregion

		#region Constructors: Public

		public ForecastHistoryRowRepository(UserConnection userConnection) : base(userConnection) {
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// The forecast snapshot data.
		/// </summary>
		public ForecastSnapshotData SnapshotData { get; set; }

		#endregion

		#region Methods: Protected

		protected virtual void MultiInsertCell(IEnumerable<ForecastHistoryRowData> rows) {
			var insert = new Insert(UserConnection).Into(Consts.RowSchemaName);
			foreach (var row in rows) {
				insert.Values()
					.Set(Consts.SheetColumnName, Column.Parameter(row.SheetId))
					.Set(Consts.EntityColumnName, Column.Parameter(row.EntityId))
					.Set(Consts.SnapshotColumnName, Column.Parameter(row.SnapshotId))
					.Set(Consts.RowColumnName, Column.Parameter(row.RowId));
			}
			if (insert.ColumnValues.IsNotEmpty()) {
				insert.Execute();
			}
		}

		protected override Select AddConditions(Select @select, SelectQueryConfig config) {
			select = base.AddConditions(select, config);
			return select
				.And("fs", Consts.SnapshotDateColumnName)
					.IsLessOrEqual(Consts.SnapshotDateQueryAlias, Consts.SnapshotDateColumnName)
				.And()
					.OpenBlock(ForecastEnityInCellAlias, Consts.DeletedOnColumnName)
						.IsGreater(Consts.SnapshotDateQueryAlias, Consts.SnapshotDateColumnName)
					.Or(ForecastEnityInCellAlias, Consts.DeletedOnColumnName).IsNull()
				.CloseBlock() as Select;
		}

		protected override Select GetForecastEntitySelect(string forecastEntityName, Sheet sheet) {
			var select = new Select(UserConnection)
				.From(forecastEntityName).As(ForecastEntityAlias)
				.InnerJoin(Consts.RowSchemaName).As(ForecastEnityInCellAlias)
				.On(ForecastEntityAlias, Consts.IdColumnName).IsEqual(ForecastEnityInCellAlias, Consts.EntityColumnName)
				.And(ForecastEnityInCellAlias, Consts.SheetColumnName).IsEqual(Column.Parameter(sheet.Id))
				.InnerJoin(Consts.ForecastSnapshotSchemaName).As(Consts.SnapshotDateQueryAlias)
					.On(Consts.SnapshotDateQueryAlias, Consts.IdColumnName).IsEqual(Column.Parameter(SnapshotData.SnapshotId))
				.InnerJoin(Consts.ForecastSnapshotSchemaName).As("fs")
				.On("fs", Consts.IdColumnName).IsEqual(ForecastEnityInCellAlias, Consts.SnapshotColumnName);
			return select as Select;
		}

		protected override EntitySchema GetForecastRowsSchema(Sheet sheet) {
			return UserConnection.EntitySchemaManager.GetInstanceByName(Consts.RowSchemaName);
		}

		protected Query GetDeleteRowsQuery(ForecastHistoricalRowsDeleteParams parameters) {
			var update = new Update(UserConnection, Consts.RowSchemaName)
					.Set(Consts.DeletedOnColumnName, Column.Parameter(parameters.DeletedOn))
				.Where(Consts.RowSchemaName, Consts.SheetColumnName).IsEqual(Column.Parameter(parameters.SheetId))
					.And(Consts.RowSchemaName, Consts.RowColumnName).In(Column.Parameters(parameters.RowsIds));
			return update;
		}

		#endregion

		#region Properties: Public

		/// <inheritdoc />
		public IEnumerable<HierarchyRow> GetHierarchyRows(Sheet sheet, IEnumerable<HierarchySettingItem> hierarchy,
				PageableConfig pageableConfig) {
			sheet.CheckArgumentNull(nameof(sheet));
			pageableConfig.CheckArgumentNull(nameof(pageableConfig));
			EntitySchema entitySchema = UserConnection.EntitySchemaManager.GetInstanceByUId(sheet.ForecastEntityUId);
			var select =  GetForecastEntitySelect(entitySchema.Name, sheet);
			var config = new SelectQueryConfig() {
				Select = select,
				Hierarchy = hierarchy,
				Sheet = sheet,
				PageableConfig = pageableConfig
			};
			return GetSelectQueryWithOptions(config);
		}


		/// <inheritdoc />
		public void InsertRows(IEnumerable<ForecastHistoryRowData> historyRows) {
			if (historyRows.IsNullOrEmpty()) {
				return;
			}
			IEnumerable<IEnumerable<ForecastHistoryRowData>> chunks
				= ForecastExtensions.GetChunks(historyRows, ChunksConfig);
			foreach (var chunkCells in chunks) {
				MultiInsertCell(chunkCells);
			}
		}

		/// <summary>
		/// Deletes history rows by setting DeletedOn column with snapshot date value.
		/// </summary>
		/// <param name="parameters">Delete operation parameters.</param>
		public void DeleteRows(ForecastHistoricalRowsDeleteParams parameters) {
			parameters.CheckArgumentNull(nameof(parameters));
			if (parameters.RowsIds.IsNullOrEmpty()) {
				return;
			}
			Query update = GetDeleteRowsQuery(parameters);
			update.Execute();
		}

		#endregion
	}

	#endregion
}

