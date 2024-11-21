namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;
	using System.Globalization;
	using global::Common.Logging;

	/// <summary>
	/// Calculates formula columns.
	/// </summary>
	/// <seealso cref="BPMSoft.Configuration.ForecastV2.IForecastCalculator" />
	[DefaultBinding(typeof(IForecastCalculator), Name = ForecastConsts.FormulaColumnTypeName)]
	public class FormulaColumnCalculator : IForecastCalculator {

		#region Constructors: Public

		/// <summary>
		/// Initializes a new instance of the <see cref="FormulaColumnCalculator"/> class.
		/// </summary>
		/// <param name="userConnection">The user connection.</param>
		public FormulaColumnCalculator(UserConnection userConnection) {
			UserConnection = userConnection;
		}

		#endregion

		#region Fields: Private

		private static readonly ILog _log = LogManager.GetLogger<FormulaSummaryCalculator>();
		private ForecastCalcParams _parameters;
		private IForecastColumnRepository _columnRepository;
		private IPeriodRepository _periodRepository;
		private IForecastSheetRepository _sheetRepository;
		private IForecastCellRepository _cellRepository;
		private FormulaUtilities _formulaUtilities;
		private Sheet _sheet;
		private IEnumerable<Period> _periods;

		#endregion

		#region Properties: Propected

		protected UserConnection UserConnection { get; private set; }

		protected IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected IPeriodRepository PeriodRepository =>
			_periodRepository ?? (_periodRepository = ClassFactory.Get<IPeriodRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected IForecastSheetRepository SheetRepository =>
			_sheetRepository ?? (_sheetRepository = ClassFactory.Get<IForecastSheetRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected IForecastCellRepository CellRepository =>
			_cellRepository ?? (_cellRepository = ClassFactory.Get<IForecastCellRepository>(
				new ConstructorArgument("userConnection", UserConnection)));

		protected Sheet Sheet => 
			_sheet ?? (_sheet = SheetRepository.GetSheet(_parameters.ForecastId));

		protected IEnumerable<Period> Periods =>
			_periods ?? (_periods = PeriodRepository.GetForecastPeriods(_parameters.Periods, Sheet.PeriodTypeId));

		protected FormulaUtilities FormulaUtilities =>
			_formulaUtilities ?? (_formulaUtilities = ClassFactory.Get<FormulaUtilities>());

		#endregion

		#region Methods: Private

		private void SaveCells(IEnumerable<Cell> cells) {
			CellRepository.InsertCells(Sheet, cells);
		}

		private Cell GetCalculatedCell(IEnumerable<Cell> cells, IEnumerable<FormulaItem> formulaItems) {
			var values = new Dictionary<string, string>();
			foreach (var formulaItem in formulaItems) {
				if (formulaItem.Type.Equals(FormulaItemType.Column)) {
					if (values.ContainsKey(formulaItem.Value)) {
						continue;
					}
					var referenceColumnId = new Guid(formulaItem.Value);
					var cell = cells.FirstOrDefault(item => item.ColumnId.Equals(referenceColumnId));
					decimal columnValue = 0;
					if (cell != null) {
						columnValue = cell.Value;
					}
					values.Add(formulaItem.Value, columnValue.ToString(CultureInfo.InvariantCulture));
				}
			}
			decimal value = FormulaUtilities.Calculate(formulaItems, values);
			if (value == 0) {
				return null;
			}
			var firstItemInGroup = cells.First();
			return new Cell {
				Value = value,
				EntityId = firstItemInGroup.EntityId,
				RowId = firstItemInGroup.RowId
			};
		}

		private void InternalCalculation() {
			IEnumerable<ForecastColumn> forecastColumns = ColumnRepository.GetColumns(Sheet.Id);
			FormulaUtilities.IterateFormulaColumns(forecastColumns,
				(formulaColumn) => {
					CellRepository.DeleteCells(Sheet, Periods, new[] { formulaColumn });
					var referenceColumns = FormulaUtilities.GetReferenceColumns(forecastColumns, formulaColumn);
					CalculateByPeriods(formulaColumn, referenceColumns);
			});
		}

		private void CalculateByPeriods(ForecastColumn calculationColumn, IEnumerable<ForecastColumn> referenceColumns) {
			var formula = FormulaUtilities.DeserializeFormula(calculationColumn);
			foreach (var period in Periods) {
				var cells = new List<Cell>();
				ICollection<Cell> currentCells = CellRepository
					.GetCells(Sheet, new[] { period }, referenceColumns).ToList();
				var groupedCells = currentCells.GroupBy(cell => cell.RowId);
				foreach (var group in groupedCells) {
					Cell calculatedCell = null;
					try {
						calculatedCell = GetCalculatedCell(group.Select(a => a), formula);
					} catch (Exception ex) {
						LogCalculatedCellException(calculationColumn, period, ex);
					}
					if (calculatedCell != null) {
						calculatedCell.PeriodId = period.Id;
						calculatedCell.ColumnId = calculationColumn.Id;
						cells.Add(calculatedCell);
					}
				}
				SaveCells(cells);
			}
		}

		private void LogCalculatedCellException(ForecastColumn calculationColumn, Period period, Exception ex) {
			_log.Error($"Error during forecast calculation in column with name \"{calculationColumn?.Name}\" " +
				$"and id \"{calculationColumn?.Id.ToString()}\" during period calculation with name \"{period?.Name}\" " +
				$"and id \"{period?.Id.ToString()}\"", ex);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Calculates formula column's values.
		/// </summary>
		/// <param name="parameters">Parameters.</param>
		/// <returns>
		/// Modified parameters.
		/// </returns>
		/// <exception cref="System.NotImplementedException"></exception>
		public ForecastCalcParams Calculate(ForecastCalcParams parameters) {
			parameters.ForecastId.CheckArgumentEmpty(nameof(parameters.ForecastId));
			_parameters = parameters;
			InternalCalculation();
			return parameters;
		}

		#endregion

	}

}
