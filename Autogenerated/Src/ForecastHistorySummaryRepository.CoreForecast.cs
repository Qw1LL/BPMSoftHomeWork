namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.DB;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Class: ForecastHistorySummaryRepository

	/// <summary>
	/// Provides methods for forecast history summary.
	/// </summary>
	[DefaultBinding(typeof(IForecastSummaryRepositoryV2), Name = "HistoryTotal")]
	public class ForecastHistorySummaryRepository : IForecastSummaryRepositoryV2, ISnapshot
	{
		#region Fields: Private

		private IForecastHistoryCellQueryBuilder _forecastHistoryCellQueryBuilder;

		#endregion

		#region Fields: Protected

		protected string _historyCellAlias = "fhc";
		protected string _snapshotAlias = "fs";

		#endregion

		#region Constructors: Public

		public ForecastHistorySummaryRepository(UserConnection userConnection, IPeriodRepository periodRepository,
			IForecastColumnRepository columnRepository) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			periodRepository.CheckArgumentNull(nameof(periodRepository));
			columnRepository.CheckArgumentNull(nameof(columnRepository));
			UserConnection = userConnection;
			PeriodRepository = periodRepository;
			ColumnRepository = columnRepository;
		}

		#endregion

		#region Properties: Protected

		/// <summary>Gets the forecast history cell query builder..</summary>
		/// <value>The forecast history cell query builder.</value>
		protected IForecastHistoryCellQueryBuilder ForecastHistoryCellQueryBuilder {
			get {
				if (_forecastHistoryCellQueryBuilder == null) {
					_forecastHistoryCellQueryBuilder = ClassFactory.Get<IForecastHistoryCellQueryBuilder>(
						new ConstructorArgument("userConnection", UserConnection));
				}
				return _forecastHistoryCellQueryBuilder;
			}
		}

		/// <summary>Gets the column repository.</summary>
		/// <value>The column repository.</value>
		protected IForecastColumnRepository ColumnRepository { get; }

		/// <summary>Gets the period repository.</summary>
		/// <value>The period repository.</value>
		protected IPeriodRepository PeriodRepository { get; }

		/// <summary>Gets the user connection.</summary>
		/// <value>The user connection.</value>
		protected UserConnection UserConnection { get; }

		#endregion

		#region Properties: Public

		/// <summary>
		/// The forecast snapshot data.
		/// </summary>
		public ForecastSnapshotData SnapshotData { get; set; }

		#endregion

		#region Methods: Private



		#endregion

		#region Methods: Protected

		protected virtual TableCell FormTableCellFromEntity(IDataReader reader, IEnumerable<Period> periodsInfo) {
			var periodId = reader.GetColumnValue<Guid>(ForecastHistoryCellConstants.PeriodColumnName);
			var columnId = reader.GetColumnValue<Guid>(ForecastHistoryCellConstants.ForecastColumnName);
			var summary = reader.GetColumnValue<double>(ForecastHistoryCellConstants.ValueColumnName);
			var cell = new TableCell {
				Id = columnId,
				ColumnCode = columnId.ToString(),
				ColumnId = columnId,
				GroupCode = periodsInfo.FirstOrDefault(x => x.Id.Equals(periodId))?.Code,
				GroupId = periodId,
				Value = summary
			};
			return cell;
		}

		protected virtual Select CreateCellsSelect(Sheet sheet, Guid snapshotId, FilterConfig filterConfig) {
			var select = new Select(UserConnection);
			GenerateColumnsSelect(select, sheet, snapshotId, filterConfig);
			GenerateFromForSelect(select, sheet, snapshotId, filterConfig);
			GenerateWhereForSelect(select, sheet, snapshotId, filterConfig);
			GenerateGroupByForSelect(select, sheet, snapshotId, filterConfig);
			return select;
		}

		protected virtual void GenerateGroupByForSelect(Select select, Sheet sheet, Guid snapshotId, FilterConfig filterConfig) {
			select.GroupBy(_historyCellAlias, ForecastHistoryCellConstants.PeriodColumnName)
				.GroupBy(_historyCellAlias, ForecastHistoryCellConstants.ForecastColumnName);
		}

		protected virtual void GenerateWhereForSelect(Select select, Sheet sheet, Guid snapshotId, FilterConfig filterConfig) {
			EntitySchema entityForecastSchema =
				UserConnection.EntitySchemaManager.GetInstanceByUId(sheet.ForecastEntityUId);
			select.Where(Column.Const(1)).IsEqual(Column.Const(1));
			ForecastHistoryCellQueryBuilder.AddRightsConditions(select, entityForecastSchema);
		}

		protected virtual void GenerateFromForSelect(Select select, Sheet sheet, Guid snapshotId, FilterConfig filterConfig) {
			select.From(ForecastHistoryCellQueryBuilder.CreateCellsSnapshotSelect(sheet.Id, snapshotId, filterConfig))
				.As(_historyCellAlias);
		}

		protected virtual void GenerateColumnsSelect(Select select, Sheet sheet, Guid snapshotId, FilterConfig filterConfig) {
			select.Column(_historyCellAlias, ForecastHistoryCellConstants.ForecastColumnName)
				.Column(_historyCellAlias, ForecastHistoryCellConstants.PeriodColumnName)
				.Column(Func.Sum(_historyCellAlias, ForecastHistoryCellConstants.ValueColumnName))
				.As(ForecastHistoryCellConstants.ValueColumnName);
		}

		#endregion

		#region Methods: Public

		[Obsolete("7.15.3. Use GetSummary(Guid sheetId, FilterConfig filterConfig) instead.")]
		public IEnumerable<TableCell> GetSummary(Guid sheetId, IEnumerable<Guid> periodIds) {
			return new TableCell[0];
		}

		/// <summary>Gets the historical summary.</summary>
		/// <param name="sheet">The forecast sheet.</param>
		/// <param name="filterConfig">Configuration to filter records.</param>
		/// <returns>Summary table cells.</returns>
		public virtual IEnumerable<TableCell> GetSummary(Sheet sheet, FilterConfig filterConfig) {
			filterConfig.CheckArgumentNull(nameof(filterConfig));
			var periodIds = filterConfig.PeriodIds;
			var cellValues = new List<TableCell>();
			IEnumerable<Period> periodsInfo = PeriodRepository.GetForecastPeriods(periodIds, sheet.PeriodTypeId);
			filterConfig.PeriodIds = periodsInfo.Select(x => x.Id);
			Select cellsSelect = CreateCellsSelect(sheet, SnapshotData.SnapshotId, filterConfig);
			cellsSelect.ExecuteReader((reader) => {
				cellValues.Add(FormTableCellFromEntity(reader, periodsInfo));
			});
			return cellValues;
		}

		#endregion
	}

	#endregion

}

