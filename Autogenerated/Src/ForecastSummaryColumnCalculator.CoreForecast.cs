namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;
	using BPMSoft.Core;
	using BPMSoft.Core.Factories;

	#region Interface: IForecastSummaryColumnCalculator

	/// <summary>
	/// Forecast summary columns calculator.
	/// </summary>
	public interface IForecastSummaryColumnCalculator
	{
		/// <summary>
		/// Adds summary columns to forecast columns collection.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="columns">Forecast columns.</param>
		/// <returns>Forecast columns with summary columns.</returns>
		void ApplySummaryColumns(UserConnection userConnection, ICollection<TableColumn> columns);

		/// <summary>
		/// Adds summary cells data to existing record's column values.
		/// </summary>
		/// <param name="userConnection">User connection.</param>
		/// <param name="forecastId">Forecast identifier.</param>
		/// <param name="records">Table records.</param>
		void ApplySummaryData(UserConnection userConnection, Guid forecastId, IEnumerable<TreeTableDataItem> records);
	}

	#endregion

	#region Class: ForecastSummaryColumnCalculator

	/// <summary>
	/// Forecast summary columns calculator.
	/// </summary>
	[DefaultBinding(typeof(IForecastSummaryColumnCalculator))]
	public class ForecastSummaryColumnCalculator : IForecastSummaryColumnCalculator
	{

		#region Constants: Private

		private const string SummaryCode = "summary";
		private const string ForecastSummaryFormulaFeature = "ForecastSummaryFormula";

		#endregion

		#region Fields: Private

		private UserConnection _userConnection;

		#endregion

		#region Properties: Protected

		private IForecastColumnRepository _columnRepository;
		protected IForecastColumnRepository ColumnRepository =>
			_columnRepository ?? (_columnRepository = ClassFactory.Get<IForecastColumnRepository>(
				new ConstructorArgument("userConnection", _userConnection)));

		private IFormulaSummaryCalculator _formulaSummaryCalculator;
		protected IFormulaSummaryCalculator FormulaSummaryCalculator =>
			_formulaSummaryCalculator ?? (_formulaSummaryCalculator = ClassFactory.Get<IFormulaSummaryCalculator>(
				new ConstructorArgument("userConnection", _userConnection)));

		private FormulaUtilities _formulaUtilities;
		protected FormulaUtilities FormulaUtilities =>
			_formulaUtilities ?? (_formulaUtilities = ClassFactory.Get<FormulaUtilities>());

		#endregion

		#region Properties: Public

		public IEnumerable<ForecastColumn> ForecastColumns { get; set; }

		#endregion

		#region Methods: Private

		private double CalcColumnSummary(IEnumerable<TableCell> columnValues, ForecastColumn column, string functionCode) {
			var cellsToCalc = GetCellsByColumn(columnValues, column);
			return CalcCellsByFunction(functionCode, cellsToCalc);
		}

		private void CalcFormulaColumnSummary(ForecastColumn column, IEnumerable<TableCell> columnValues,
				IEnumerable<TableCell> summaryCells) {
			var functions = GetFormulaFunctions(column);
			foreach (FunctionInfo functionInfo in functions) {
				ForecastColumn funcColumn = GetColumnByFunction(functionInfo);
				CalcFunctionCell(columnValues, summaryCells, funcColumn, functionInfo.Function);
			}
		}

		private IEnumerable<FunctionInfo> GetFormulaFunctions(ForecastColumn column) {
			var settings = column.GetColumnSettings<FormulaSetting>();
			var formula = settings.SummaryValue ?? settings.Value ?? new FormulaItem[0];
			var functions = FormulaUtilities.GetFunctions(formula);
			return functions;
		}

		private void CalcFunctionCell(IEnumerable<TableCell> columnValues, IEnumerable<TableCell> summaryCells,
				ForecastColumn funcColumn, FormulaItem function) {
			TableCell summaryCell = GetSummaryCell(summaryCells, funcColumn);
			string functionCode = function.Value;
			summaryCell.FunctionsValueMap = summaryCell.FunctionsValueMap ?? new Dictionary<string, double>();
			double value = CalcColumnSummary(columnValues, funcColumn, functionCode);
			summaryCell.FunctionsValueMap[functionCode] = value;
		}

		private IEnumerable<TableCell> CalcSummaryCells(Guid forecastId, TreeTableDataItem record) {
			var summaryCells = PrepareSummaryCells(record);
			foreach (var column in ForecastColumns) {
				if (IsFormulaColumn(column)) {
					CalcFormulaColumnSummary(column, record.ColumnValues, summaryCells);
				} else {
					TableCell summaryCell = GetSummaryCell(summaryCells, column);
					summaryCell.Value = CalcColumnSummary(record.ColumnValues, column, FunctionConstants.Sum);
				}
			}
			if (ForecastColumns.Any(IsFormulaColumn)) {
				var formulaCalcParams = new FormulaSummaryParams {
					ForecastId = forecastId,
					Rows = new [] { new TreeTableDataItem {
						Id = record.Id,
						RecordId = record.RecordId,
						ColumnValues = summaryCells
					}}
				};
				if (_userConnection.GetIsFeatureEnabled(ForecastSummaryFormulaFeature)) {
					formulaCalcParams.FormulaResolver = (setting => setting.SummaryValue);
				}
				FormulaSummaryCalculator.CalcFormulaSummary(formulaCalcParams);
				summaryCells = formulaCalcParams.Rows.First().ColumnValues.ToList();
				if (!_userConnection.GetIsFeatureEnabled(ForecastSummaryFormulaFeature)) {
					summaryCells.Where(c => c.ColumnCode != $"{c.ColumnId}_{c.GroupCode}")
						.ForEach(c => c.ColumnCode = c.FormColumnCode());
				}
			}
			return summaryCells;
		}

		private List<TableCell> PrepareSummaryCells(TreeTableDataItem record) {
			var summaryCells = new List<TableCell>();
			ForecastColumns.ForEach(column => {
				summaryCells.Add(new TableCell {
					Id = column.Id,
					ColumnCode = FormSummaryColumnCode(column),
					ColumnId = column.Id,
					GroupCode = SummaryCode,
					RecordId = record.RecordId
				});
			});
			return summaryCells;
		}

		private string FormSummaryColumnCode(ForecastColumn column) {
			return $"{column.Code}_{SummaryCode}";
		}

		private IEnumerable<TableCell> GetCellsByColumn(IEnumerable<TableCell> columnValues, ForecastColumn column) {
			var cellsToCalc = columnValues.Where(cell =>
				cell.ColumnCode.StartsWith(column.Id.ToString()));
			return cellsToCalc;
		}

		private ForecastColumn GetColumnByFunction(FunctionInfo function) {
			var columnOperand = function.Operands.First();
			Guid columnId = new Guid(columnOperand.Value);
			var funcColumn = ForecastColumns.FirstOrDefault(c => c.Id == columnId) ??
				throw new ArgumentException($"Function {function.Function.Value} has column argument that does not exist.");
			return funcColumn;
		}

		private TableCell GetSummaryCell(IEnumerable<TableCell> cells, ForecastColumn column) {
			string summaryColumnCode = FormSummaryColumnCode(column);
			return cells.First(cell => cell.ColumnCode == summaryColumnCode);
		}

		private bool IsFormulaColumn(ForecastColumn column) {
			FormulaSetting settings = column.GetColumnSettings<FormulaSetting>();
			bool calcColumnAsFormula = _userConnection.GetIsFeatureEnabled(ForecastSummaryFormulaFeature) ||
				settings.UseInSummary;
			return column.TypeId == ForecastConsts.FormulaColumnTypeId && calcColumnAsFormula;
		}

		#endregion

		#region Methods: Protected

		protected virtual double CalcCellsByFunction(string funcCode, IEnumerable<TableCell> cells) {
			switch (funcCode.ToUpper()) {
				case FunctionConstants.Sum:
					return cells.Sum(cell => cell.Value);
				case FunctionConstants.Avg:
					return cells.Average(cell => cell.Value);
				default:
					return 0;
			}
		}

		#endregion

		#region Methods: Public

		/// <inheritdoc cref="IForecastSummaryColumnCalculator.ApplySummaryColumns"/>
		public void ApplySummaryColumns(UserConnection userConnection, ICollection<TableColumn> columns) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			if (columns.IsEmpty() || columns.Any(c => c.Code == SummaryCode)) {
				return;
			}
			var summaryColumn = new TableColumn {
				Code = SummaryCode,
				Caption = userConnection.GetLocalizableString("ForecastLczResources", "SummaryCaption"),
				Children = new List<TableColumn>()
			};
			var subColumns = columns.ElementAt(0).Children;
			foreach (TableColumn column in subColumns) {
				if (!column.IsHide) {
					summaryColumn.Children.Add(new TableColumn {
						Caption = column.Caption,
						Code = column.Code,
						Id = column.Id
					});
				}
			}
			columns.Add(summaryColumn);
		}

		/// <inheritdoc cref="IForecastSummaryColumnCalculator.ApplySummaryData"/>
		public void ApplySummaryData(UserConnection userConnection, Guid forecastId, IEnumerable<TreeTableDataItem> records) {
			userConnection.CheckArgumentNull(nameof(userConnection));
			records.CheckArgumentNull(nameof(records));
			if (records.IsEmpty()) {
				return;
			}
			_userConnection = userConnection;
			ForecastColumns = ColumnRepository.GetColumns(forecastId);
			foreach (TreeTableDataItem record in records) {
				var calculatedCells = CalcSummaryCells(forecastId, record);
				record.ColumnValues.AddRange(calculatedCells);
			}
		}

		#endregion

	}

	#endregion

}

