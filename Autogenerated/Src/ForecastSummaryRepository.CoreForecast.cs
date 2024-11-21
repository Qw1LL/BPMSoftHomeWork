namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Entities;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastSummaryRepository

	/// <summary>Provides methods for forecast summary</summary>
	public interface IForecastSummaryRepository
	{
		/// <summary>Gets the summary.</summary>
		/// <param name="sheetId">The sheet identifier.</param>
		/// <param name="periodIds">The period ids.</param>
		/// <returns>Summary table cells.</returns>
		IEnumerable<TableCell> GetSummary(Guid sheetId, IEnumerable<Guid> periodIds);
	}

	#endregion

	#region Interface: IForecastSummaryRepositoryV2

	/// <summary>Provides methods for forecast summary</summary>
	public interface IForecastSummaryRepositoryV2 : IForecastSummaryRepository
	{
		/// <summary>Gets the summary.</summary>
		/// <param name="sheet">The forecast sheet.</param>
		/// <param name="filterConfig">Configuration to filter records.</param>
		/// <returns>Summary table cells.</returns>
		IEnumerable<TableCell> GetSummary(Sheet sheet, FilterConfig filterConfig);

	}

	#endregion

	#region Class: ForecastSummaryRepository

	[DefaultBinding(typeof(IForecastSummaryRepository))]
	[DefaultBinding(typeof(IForecastSummaryRepositoryV2), Name = "Total")]
	public class ForecastSummaryRepository : IForecastSummaryRepositoryV2
	{

		#region Fields: Private

		private string _aggregationColumnName;

		#endregion

		#region Constructors: Public

		public ForecastSummaryRepository(UserConnection userConnection, IPeriodRepository periodRepository,
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

		#region Methods: Private

		private void AddForecastEntityFilter(EntitySchemaColumn referenceColumn, EntitySchemaQuery esq) {
			var forecastEntityEsq =
				new EntitySchemaQuery(UserConnection.EntitySchemaManager, referenceColumn.ReferenceSchema.Name);
			forecastEntityEsq.PrimaryQueryColumn.IsAlwaysSelect = true;
			esq.Filters.Add(esq.CreateFilter(FilterComparisonType.Equal, referenceColumn.Name, forecastEntityEsq));
		}

		private IEnumerable<ForecastColumn> GetColumnsToCalculate(Guid sheetId) {
			var useFormulaColumn = UserConnection.GetIsFeatureEnabled("CalcTotalByFormula");
			var columnsToCalculate = ColumnRepository.GetColumns(sheetId).Where(column => {
				if (!useFormulaColumn) {
					return column.TypeId != ForecastConsts.FormulaColumnTypeId;
				}
				FormulaSetting setting = column.GetColumnSettings<FormulaSetting>();
				return !setting.UseInSummary;
			});
			return columnsToCalculate;
		}

		#endregion

		#region Methods: Protected

		protected virtual TableCell FormTableCellFromEntity(Entity item) {
			var periodName = item.GetTypedColumnValue<string>("PeriodName");
			var periodId = item.GetTypedColumnValue<Guid>("PeriodId");
			var columnId = item.GetTypedColumnValue<Guid>("ForecastColumnId");
			var summary = item.GetTypedColumnValue<double>(_aggregationColumnName);
			var cell = new TableCell {
				Id = columnId,
				ColumnCode = columnId.ToString(),
				ColumnId = columnId,
				GroupCode = Period.FormCode(periodName),
				GroupId = periodId,
				Value = summary
			};
			return cell;
		}

		protected virtual EntitySchemaQuery GetSummaryEsq(Sheet sheet, IEnumerable<Period> periodsInfo,
			IEnumerable<ForecastColumn> filterColumns, FilterConfig filterConfig) {
			var periodIds = periodsInfo.Select(a => a.Id);
			var columnsIds = filterColumns.Select(c => c.Id);
			EntitySchema entityForecastSchema =
				UserConnection.EntitySchemaManager.GetInstanceByUId(sheet.ForecastEntityInCellUId);
			EntitySchemaColumn referenceColumn = sheet.GetEntityReferenceColumn(UserConnection);
			var schemaName = entityForecastSchema.Name;
			var esq = new EntitySchemaQuery(UserConnection.EntitySchemaManager, schemaName);
			_aggregationColumnName =
				esq.AddColumn(esq.CreateAggregationFunction(AggregationTypeStrict.Sum, "Value")).Name;
			esq.AddColumn("Period");
			esq.AddColumn("ForecastColumn");
			AddForecastEntityFilter(referenceColumn, esq);
			esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Sheet", sheet.Id));
			if (periodIds.IsNotEmpty()) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "Period",
					periodIds.Cast<object>().ToArray()));
			}
			if (columnsIds.IsNotEmpty()) {
				esq.Filters.Add(esq.CreateFilterWithParameters(FilterComparisonType.Equal, "ForecastColumn",
					columnsIds.Cast<object>().ToArray()));
			}
			return esq;
		}

		#endregion

		#region Methods: Public

		[Obsolete("7.15.3. Use GetSummary(Guid sheetId, FilterConfig filterConfig) instead.")]
		public IEnumerable<TableCell> GetSummary(Guid sheetId, IEnumerable<Guid> periodIds) {
			return new TableCell[0];
		}

		/// <summary>Gets the summary.</summary>
		/// <param name="sheet">The forecast sheet.</param>
		/// <param name="filterConfig">Configuration to filter records.</param>
		/// <returns>Summary table cells.</returns>
		public virtual IEnumerable<TableCell> GetSummary(Sheet sheet, FilterConfig filterConfig) {
			filterConfig.CheckArgumentNull(nameof(filterConfig));
			var columnsToCalculate = GetColumnsToCalculate(sheet.Id);
			if (columnsToCalculate.IsEmpty()) {
				return new TableCell[0];
			}
			var periodIds = filterConfig.PeriodIds;
			var cellValues = new List<TableCell>();
			IEnumerable<Period> periodsInfo = PeriodRepository.GetForecastPeriods(periodIds, sheet.PeriodTypeId);
			EntitySchemaQuery esq = GetSummaryEsq(sheet, periodsInfo, columnsToCalculate, filterConfig);
			EntityCollection collection = esq.GetEntityCollection(UserConnection);
			foreach (var item in collection) {
				cellValues.Add(FormTableCellFromEntity(item));
			}
			return cellValues;
		}

		#endregion

	}

	#endregion

}

