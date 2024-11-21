namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastSummaryProvider

	public interface IForecastSummaryProvider
	{
		/// <summary>
		/// Gets total summary values for all sheet records.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="filterConfig">Filters configuration</param>
		/// <returns></returns>
		IEnumerable<TableCell> GetSummary(Sheet sheet, FilterConfig filterConfig);

		/// <summary>
		/// Gets summary values for forecast group records.
		/// </summary>
		/// <param name="sheet">Forecast sheet.</param>
		/// <param name="filterConfig">Filters configuration</param>
		/// <returns></returns>
		IEnumerable<TableCell> GetGroupsSummary(Sheet sheet, FilterConfig filterConfig);
	}

	#endregion

	#region Class: ForecastSummaryProvider

	[DefaultBinding(typeof(IForecastSummaryProvider))]
	public class ForecastSummaryProvider : IForecastSummaryProvider
	{

		#region Fields: Private

		private readonly UserConnection _userConnection;
		private IForecastColumnRepository _forecastColumnRepository;
		private IForecastSummaryRepositoryV2 _forecastSummaryRepository;
		private IForecastSummaryRepositoryV2 _forecastGroupSummaryRepository;
		private IFormulaSummaryCalculator _formulaSummaryCalculator;
		private IPeriodRepository _periodRepository;

		#endregion

		#region Constructors: Public

		public ForecastSummaryProvider(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion

		#region Properties: Public

		public IForecastColumnRepository ColumnRepository {
			get =>
				_forecastColumnRepository ?? (_forecastColumnRepository =
					ClassFactory.Get<IForecastColumnRepository>(GetUserConnectionArgs()));
			set => _forecastColumnRepository = value;
		}

		public IPeriodRepository PeriodRepository {
			get =>
				_periodRepository ?? (_periodRepository = ClassFactory.Get<IPeriodRepository>(GetUserConnectionArgs()));
			set => _periodRepository = value;
		}

		public IFormulaSummaryCalculator FormulaSummaryCalculator {
			get =>
				_formulaSummaryCalculator ?? (_formulaSummaryCalculator =
					ClassFactory.Get<IFormulaSummaryCalculator>(new ConstructorArgument("columnRepository",
						ColumnRepository)));
			set => _formulaSummaryCalculator = value;
		}

		public IForecastSummaryRepositoryV2 ForecastSummaryRepository {
			get => _forecastSummaryRepository ?? (_forecastSummaryRepository =
					ClassFactory.Get<IForecastSummaryRepositoryV2>("Total", new[] {
						GetUserConnectionArgs(),
						new ConstructorArgument("periodRepository", PeriodRepository),
						new ConstructorArgument("columnRepository", ColumnRepository)
					}));
			set => _forecastSummaryRepository = value;
		}

		public IForecastSummaryRepositoryV2 ForecastGroupSummaryRepository {
			get => _forecastGroupSummaryRepository ?? (_forecastGroupSummaryRepository =
				ClassFactory.Get<IForecastSummaryRepositoryV2>("Group", new[] {
					GetUserConnectionArgs(),
					new ConstructorArgument("periodRepository", PeriodRepository),
					new ConstructorArgument("columnRepository", ColumnRepository)
				}));
			set => _forecastGroupSummaryRepository = value;
		}

		private ForecastDataMapper _forecastDataMapper;
		/// <summary>Gets the forecast data mapper.</summary>
		/// <value>The forecast data mapper.</value>
		protected ForecastDataMapper ForecastDataMapper =>
			_forecastDataMapper ?? (_forecastDataMapper = ClassFactory.Get<ForecastDataMapper>());

		#endregion

		#region Methods: Private

		private List<TableCell> GetCellsToCalc(IEnumerable<TableCell> summaryCells, IEnumerable<Period> periods,
				IEnumerable<ForecastColumn> columns, IEnumerable<Guid> records) {
			var cellsToCalc = new List<TableCell>(summaryCells);
			var recordIds = new List<Guid>();
			if (records != null) {
				recordIds.AddRange(records);
			}
			if (recordIds.IsEmpty()) {
				recordIds.Add(Guid.Empty);
			}
			periods.ForEach(period => {
				recordIds.ForEach(recordId => {
					columns.ForEach(column => {
						if (!summaryCells.Any(cell =>
								cell.GroupId == period.Id &&
								cell.ColumnId == column.Id &&
								cell.RecordId == recordId)) {
							cellsToCalc.Add(new TableCell {
								Id = column.Id,
								GroupCode = period.Code,
								GroupId = period.Id,
								ColumnCode = column.Code,
								ColumnId = column.Id,
								RecordId = recordId,
								Value = 0
							});
						}
					});
				});
			});
			return cellsToCalc;
		}

		private ConstructorArgument GetUserConnectionArgs() {
			return new ConstructorArgument("userConnection", _userConnection);
		}

		private IEnumerable<TableCell> GetSummaryCells(Sheet sheet, FilterConfig filterConfig,
				IForecastSummaryRepositoryV2 summaryRepository) {
			var summaryCells = summaryRepository.GetSummary(sheet, filterConfig).ToList();
			var periodInfos = PeriodRepository.GetForecastPeriods(filterConfig.PeriodIds, sheet.PeriodTypeId);
			var forecastColumns = ColumnRepository.GetColumns(sheet.Id);
			var cellsToCalc = GetCellsToCalc(summaryCells, periodInfos, forecastColumns, filterConfig.RecordIds);
			if (_userConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
				cellsToCalc.ForEach(cell => cell.ColumnCode = cell.FormColumnCode());
			}
			var rows = ForecastDataMapper.GetMapTreeTableDataItems(cellsToCalc);
			var calculatedRows = FormulaSummaryCalculator.CalcFormulaSummary(new FormulaSummaryParams {
				ForecastId = sheet.Id,
				Rows = rows
			});
			var allCells = new List<TableCell>();
			calculatedRows.ForEach(row => allCells.AddRange(row.ColumnValues));
			if (!_userConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
				allCells.ForEach(cell => cell.ColumnCode = cell.FormColumnCode());
			}
			return allCells;
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public IEnumerable<TableCell> GetGroupsSummary(Sheet sheet, FilterConfig filterConfig) {
			return GetSummaryCells(sheet, filterConfig, ForecastGroupSummaryRepository);
		}

		/// <inheritdoc/>
		public IEnumerable<TableCell> GetSummary(Sheet sheet, FilterConfig filterConfig) {
			return GetSummaryCells(sheet, filterConfig, ForecastSummaryRepository);
		}

		#endregion

	}

	#endregion

}

