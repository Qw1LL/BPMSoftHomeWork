namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Factories;

	#region Class: ForecastHistoryCellRepository

	[DefaultBinding(typeof(IGetForecastCellRepository), Name = "History")]
	[DefaultBinding(typeof(IInsertForecastCellRepository), Name = "History")]
	public class ForecastHistoryCellRepository : IGetForecastCellRepository, IInsertForecastCellRepository, ISnapshot
	{
		#region Constructors: Public

		public ForecastHistoryCellRepository(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			UserConnection = userConnection;
		}

		#endregion
		
		#region Properties: Private

		private ChunksConfig ChunksConfig => new ChunksConfig() {
			InsertColumnsCount = 7,
			MaxParametersCounterPerQueryChunk = 1000
		};

		#endregion

		#region Properties: Protected

		protected UserConnection UserConnection { get; }

		private IForecastHistoryCellQueryBuilder _forecastHistoryCellQueryBuilder;

		protected IForecastHistoryCellQueryBuilder ForecastHistoryCellQueryBuilder {
			get {
				if (_forecastHistoryCellQueryBuilder == null) {
					_forecastHistoryCellQueryBuilder = ClassFactory.Get<IForecastHistoryCellQueryBuilder>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _forecastHistoryCellQueryBuilder;
			}
		}

		#endregion

		#region Properties: Public

		/// <summary>
		/// The forecast snapshot data.
		/// </summary>
		public ForecastSnapshotData SnapshotData { get; set; }

		#endregion

		#region Methods: Private

		private Cell CreateCell(IDataReader reader) {
			return new Cell {
				EntityId = reader.GetColumnValue<Guid>(ForecastHistoryCellConstants.EntityColumnName),
				ColumnId = reader.GetColumnValue<Guid>(ForecastHistoryCellConstants.ForecastColumnName),
				PeriodId = reader.GetColumnValue<Guid>(ForecastHistoryCellConstants.PeriodColumnName),
				RowId = reader.GetColumnValue<Guid>(ForecastHistoryCellConstants.ForecastRowColumnName),
				Value = reader.GetColumnValue<decimal>(ForecastHistoryCellConstants.ValueColumnName)
			};
		}

		#endregion

		#region Methods: Protected

		protected virtual void MultiInsertCell(Guid sheetId, IEnumerable<Cell> cells) {
			var insert = new Insert(UserConnection).Into(ForecastHistoryCellConstants.CellSchemaName);
			foreach (var cell in cells) {
				var periodIdValue = cell.PeriodId.IsEmpty() ? Column.Const(null) : Column.Parameter(cell.PeriodId);
				insert.Values()
					.Set(ForecastHistoryCellConstants.SheetColumnName, Column.Parameter(sheetId))
					.Set(ForecastHistoryCellConstants.PeriodColumnName, periodIdValue)
					.Set(ForecastHistoryCellConstants.ForecastColumnName, Column.Parameter(cell.ColumnId))
					.Set(ForecastHistoryCellConstants.EntityColumnName, Column.Parameter(cell.EntityId))
					.Set(ForecastHistoryCellConstants.SnapshotColumnName, Column.Parameter(SnapshotData.SnapshotId))
					.Set(ForecastHistoryCellConstants.ValueColumnName, Column.Parameter(cell.Value))
					.Set(ForecastHistoryCellConstants.ForecastRowColumnName, Column.Parameter(cell.RowId));
			}
			if (insert.ColumnValues.IsNotEmpty()) {
				insert.Execute();
			}
		}

		#endregion

		#region Methods: Public

		///<inheritdoc />
		public IEnumerable<Cell> GetCells(Sheet forecastSheet, FilterConfig filterConfig) {
			forecastSheet.CheckArgumentNull(nameof(forecastSheet));
			filterConfig.CheckArgumentNull(nameof(filterConfig));
			filterConfig.RecordIds.CheckArgumentNullOrEmpty(nameof(filterConfig.RecordIds));
			SnapshotData.CheckArgumentNull(nameof(SnapshotData));
			Select cellsSelect = ForecastHistoryCellQueryBuilder.CreateCellsSnapshotSelect(forecastSheet.Id, SnapshotData.SnapshotId, filterConfig);
			var cells = new List<Cell>();
			cellsSelect.ExecuteReader((reader) => {
				cells.Add(CreateCell(reader));
			});
			return cells;
		}

		/// <summary>
		/// Insert the cells.
		/// </summary>
		/// <param name="forecastSheet">Forecast sheet info</param>
		/// <param name="cell">Cells info</param>
		public void InsertCells(Sheet forecastSheet, IEnumerable<Cell> cells) {
			SnapshotData.CheckArgumentNull(nameof(SnapshotData));
			forecastSheet.CheckArgumentNull(nameof(forecastSheet));
			if (cells.IsNullOrEmpty()) {
				return;
			}
			IEnumerable<IEnumerable<Cell>> chunks = ForecastExtensions.GetChunks(cells, ChunksConfig);
			foreach (var chunkCells in chunks) {
				MultiInsertCell(forecastSheet.Id, chunkCells);
			}
		}

		#endregion

	}

	#endregion

}

