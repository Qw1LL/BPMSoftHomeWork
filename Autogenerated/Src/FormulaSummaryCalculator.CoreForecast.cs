 namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Collections.Immutable;
	using System.Globalization;
	using System.Linq;
	using global::Common.Logging;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Class: FormulaSummaryParams

	public partial class FormulaSummaryParams
	{

		#region Properties: Public

		/// <summary>
		/// Forecast identifier.
		/// </summary>
		public Guid ForecastId { get; set; }

		/// <summary>
		/// Summary dictionary.
		/// Key: column id + period code. "column1_2020"
		/// Value: column value.
		/// </summary>
		public IEnumerable<TableCell> Cells { get; set; }

		/// <summary>
		/// Table rows for which to calculate summary cell values.
		/// </summary>
		public IEnumerable<TreeTableDataItem> Rows { get; set; }

		/// <summary>
		/// Defines a function by which the needed formula from settings will be resolved.
		/// </summary>
		public Func<FormulaSetting, IEnumerable<FormulaItem>> FormulaResolver = (setting) => setting.Value;

		#endregion

	}

	#endregion

	#region Interface: IFormulaSummaryCalculator

	/// <summary>
	/// Contract for formula summary calculator.
	/// </summary>
	public interface IFormulaSummaryCalculator
	{

		#region Methods: Public

		/// <summary>
		/// Calculates formula columns summary values;
		/// </summary>
		/// <param name="parameters">Forecast summary parameters.</param>
		/// <returns></returns>
		IEnumerable<TreeTableDataItem> CalcFormulaSummary(FormulaSummaryParams parameters);

		#endregion

	}

	#endregion

	#region Class: FormulaSummaryCalculator

	/// <summary>
	/// Calculates summary formula columns.
	/// </summary>
	[DefaultBinding(typeof(IFormulaSummaryCalculator))]
	public class FormulaSummaryCalculator : IFormulaSummaryCalculator {

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger<FormulaSummaryCalculator>();
		private FormulaUtilities _formulaUtilities;
		private IPeriodRepository _periodRepository;
		private IForecastColumnRepository _columnRepository;
		private readonly UserConnection _userConnection;
		private IForecastSheetRepository _sheetRepository;

		#endregion

		#region Constructors: Public

		public FormulaSummaryCalculator(UserConnection userConnection) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			_userConnection = userConnection;
		}

		#endregion

		protected Sheet Sheet { get; set; }
		protected Func<FormulaSetting,IEnumerable<FormulaItem>> FormulaResolver { get; set; }

		#region Properties: Public

		public IForecastColumnRepository ColumnRepository {
			get =>
				_columnRepository ??
				(_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
					new ConstructorArgument("userConnection", _userConnection)));
			set => _columnRepository = value;
		}

		public IPeriodRepository PeriodRepository {
			get =>
				_periodRepository ??
				(_periodRepository = ClassFactory.Get<IPeriodRepository>(
					new ConstructorArgument("userConnection", _userConnection)));
			set => _periodRepository = value;
		}

		public IForecastSheetRepository SheetRepository {
			get =>
				_sheetRepository ??
				(_sheetRepository = ClassFactory.Get<IForecastSheetRepository>(
					new ConstructorArgument("userConnection", _userConnection)));
			set => _sheetRepository = value;
		}

		public FormulaUtilities FormulaUtilities =>
			_formulaUtilities ?? (_formulaUtilities = ClassFactory.Get<FormulaUtilities>());

		public IEnumerable<ForecastColumn> ForecastColumns { get; set; }

		#endregion

		#region Methods: Private

		private IEnumerable<TableCell> CalculateValuesForColumn(ForecastColumn calculationColumn,
				IEnumerable<TableCell> cells, Guid recordId, IEnumerable<Period> periods) {
			var calculatedCells = new List<TableCell>();
			var setting = calculationColumn.GetColumnSettings<FormulaSetting>();
			foreach (var period in periods) {
				var formula = FormulaResolver?.Invoke(setting) ?? setting.Value;
				var periodCells = cells.Where(c => c.GroupCode == period.Code);
				var values = GetFormulaValues(formula, periodCells);
				var value = default(decimal);
				try {
					value = FormulaUtilities.Calculate(formula, values);
				} catch (Exception ex) {
					LogCalculatedCellException(calculationColumn, period, recordId, ex);
				}
				TableCell cell = cells.FirstOrDefault(c =>
					c.ColumnCode.StartsWith(calculationColumn.Id.ToString()) && c.GroupCode == period.Code);
				if (cell == null) {
					cell = CreateTableCell(calculationColumn, recordId, period);
				}
				cell.Value = Math.Round((double)value, GetValuePrecision());
				calculatedCells.Add(cell);
			}
			return calculatedCells;
		}

		private TableCell CreateTableCell(ForecastColumn calculationColumn, Guid recordId, Period period) {
			var cell = new TableCell {
				GroupCode = period.Code,
				GroupId = period.Id,
				ColumnCode = calculationColumn.Code,
				ColumnId = calculationColumn.Id,
				RecordId = recordId,
				Id = calculationColumn.Id
			};
			if (_userConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
				cell.ColumnCode = cell.FormColumnCode();
			}
			return cell;
		}

		private void LogCalculatedCellException(ForecastColumn calculationColumn, Period period, Guid recordId, Exception ex) {
			_log.Error($"Error during forecast calculation with record id {recordId.ToString()} in column with name \"{calculationColumn?.Name}\" " +
				$"and id \"{calculationColumn?.Id.ToString()}\" during period calculation with name \"{period?.Name}\" " +
				$"and id \"{period?.Id.ToString()}\"", ex);
		}

		private IEnumerable<Period> GetPeriodsFromCells(IEnumerable<TableCell> cells) {
			var periods = cells.GroupBy(cell => new {
				cell.GroupCode,
				cell.GroupId
			}).Select(grpCells => new Period {
				Name = grpCells.Key.GroupCode,
				Id = grpCells.Key.GroupId,
			});
			if (periods.IsEmpty()) {
				periods = new[] { new Period() };
			}
			return periods;
		}

		private Dictionary<string, string> GetFormulaValues(IEnumerable<FormulaItem> formula,
				IEnumerable<TableCell> cells) {
			int precision = GetValuePrecision();
			return FormulaUtilities.GetFormulaValues(formula, cells, new FormulaValueConfig {
				Precision = precision
			});
		}

		private int GetValuePrecision() {
			return Sheet.GetForecastValueColumnPrecision(_userConnection);
		}

		private IEnumerable<TableCell> InnerCalculate(TreeTableDataItem row) {
			var periods = GetPeriodsFromCells(row.ColumnValues);
			if (!_userConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
				FilterColumnValues(row);
			}
			var calculatedCells = new List<TableCell>(row.ColumnValues);
			var formulaSummaryCells = new List<TableCell>();
			IEnumerable<ForecastColumn> notFormulaColumns =
				ForecastColumns.Where(column => !column.GetColumnSettings<FormulaSetting>().UseInSummary);
			FormulaUtilities.IterateFormulaColumns(ForecastColumns,
				(formulaColumn) => {
					if (!_userConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
						if (notFormulaColumns.Contains(formulaColumn)) {
							return;
						}
					}
					IEnumerable<TableCell> newCells = CalculateValuesForColumn(formulaColumn, calculatedCells,
						row.RecordId, periods);
					formulaSummaryCells.AddRange(newCells);
					calculatedCells.AddRange(newCells);
				});
			return formulaSummaryCells;
		}

		private void FilterColumnValues(TreeTableDataItem row) {
			var formulaColumns = ForecastColumns.Where(c => c.GetColumnSettings<FormulaSetting>().UseInSummary);
			row.ColumnValues = row.ColumnValues.Where(c =>
					!formulaColumns.Any(fc => c.ColumnCode.StartsWith(fc.Code)))
				.ToList();
		}

		private void FormatCells(IEnumerable<TableCell> cells) {
			cells.ForEach(cell => {
				if (Sheet.CheckForecastValueExceedMaxSize(_userConnection, (decimal)cell.Value)) {
					cell.Value = 0;
				}
			});
		}

		private void SetCellValues(IEnumerable<TableCell> calculatedCells, TreeTableDataItem row) {
			calculatedCells.ForEach(cell => {
				var existingCell = row.ColumnValues.FirstOrDefault(cv => cv.ColumnCode == cell.ColumnCode);
				if (existingCell == null) {
					row.ColumnValues.Add(cell);
				} else {
					existingCell.Value = cell.Value;
				}
			});
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc/>
		public IEnumerable<TreeTableDataItem> CalcFormulaSummary(FormulaSummaryParams parameters) {
			parameters.CheckArgumentNull(nameof(parameters));
			FormulaResolver = parameters.FormulaResolver;
			Guid forecastId = parameters.ForecastId;
			Sheet = SheetRepository.GetSheet(forecastId);
			ForecastColumns = ColumnRepository.GetColumns(forecastId);
			var rows = new List<TreeTableDataItem>(parameters.Rows);
			rows.ForEach((row) => {
				var calculatedCells = InnerCalculate(row);
				FormatCells(calculatedCells);
				if (_userConnection.GetIsFeatureEnabled("ForecastSummaryFormula")) {
					SetCellValues(calculatedCells, row);
				} else {
					row.ColumnValues.AddRange(calculatedCells);
				}
			});
			return rows;
		}

		#endregion

	}

	#endregion

}

