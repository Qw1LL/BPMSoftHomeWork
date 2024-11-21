namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Data;
	using System.Globalization;
	using System.Linq;
	using Newtonsoft.Json;
	using BPMSoft.Common;
	using BPMSoft.Core.Factories;

	#region Enum: FormulaItemType

	/// <summary>
	/// Formula item type.
	/// </summary>
	public enum FormulaItemType
	{
		Number = 0,
		Column = 1,
		Operand = 2,
		Function = 4
	}

	#endregion

	#region Class: FormulaItem

	/// <summary>
	/// Formula item.
	/// </summary>
	public class FormulaItem : IEquatable<FormulaItem>
	{

		/// <summary>
		/// Gets or sets the type.
		/// </summary>
		/// <value>
		/// The type.
		/// </value>
		[JsonProperty("type")]
		public FormulaItemType Type { get; set; }

		/// <summary>
		/// Gets or sets the caption.
		/// </summary>
		/// <value>
		/// The caption.
		/// </value>
		[JsonProperty("caption")]
		public string Caption { get; set; }

		/// <summary>
		/// Gets or sets the value.
		/// </summary>
		/// <value>
		/// The value.
		/// </value>
		[JsonProperty("value")]
		public string Value { get; set; }

		/// <summary>
		/// Indicates whether the current object is equal to another object of the same type.
		/// </summary>
		/// <param name="other">An object to compare with this object.</param>
		/// <returns>
		///   <see langword="true" /> if the current object is equal to the <paramref name="other" />
		///   parameter; otherwise, <see langword="false" />.
		/// </returns>
		public bool Equals(FormulaItem other) {
			if (Object.ReferenceEquals(other, null)) return false;
			if (Object.ReferenceEquals(this, other)) return true;
			return Value.Equals(other.Value) && Type.Equals(other.Type);
		}

		public override int GetHashCode() {
			return Type.GetHashCode() ^ Value.GetHashCode();
		}
	}

	#endregion

	#region Class: FormulaValueConfig

	/// <summary>
	/// Configuration of formula values format.
	/// </summary>
	public class FormulaValueConfig
	{
		/// <summary>
		/// Value precision.
		/// </summary>
		public int Precision { get; set; } = 2;
	}

	#endregion

	#region Class: FormulaUtilities

	/// <summary>
	/// Provides methods of formula working.
	/// </summary>
	public class FormulaUtilities
	{
		#region Properties: Protected

		/// <summary> Gets the function validator. </summary>
		/// <value> The function validator. </value>
		protected FunctionValidator FunctionValidator => ClassFactory.Get<FunctionValidator>();

		#endregion

		#region Methods: Private

		private bool HasReference(ForecastColumn formulaColumn, ForecastColumn parentColumn) {
			var formulaItems = GetFormulaItems(formulaColumn);
			return formulaItems
				.Where(item => item.Type.Equals(FormulaItemType.Column))
				.Any(item => item.Value.Equals(parentColumn.Id.ToString()));
		}

		private IEnumerable<FormulaItem> GetFormulaItems(ForecastColumn column) {
			return column.GetColumnSettings<FormulaSetting>().Value ?? new FormulaItem[0];
		}

		private decimal GetCalculatedFormulaValue(string formula) {
			var dt = new DataTable();
			var result = default(decimal);
			try {
				var value = dt.Compute(formula, string.Empty);
				result = Convert.ToDecimal(value);
			} catch (DivideByZeroException) {
			} catch (OverflowException) {
			} catch (Exception ex) {
				throw new Exception($"Error during forecast formula calculation. Formula: {formula}.", ex);
			}
			return result;
		}

		private string GetFormula(IEnumerable<FormulaItem> formulaItems, IDictionary<string, string> injectedValues) {
			var formula = string.Empty;
			var items = formulaItems.ToList();
			IEnumerable<FunctionInfo> functions = null;
			for (var i = 0; i < items.Count(); i++) {
				FormulaItem currentItem = items[i];
				switch (currentItem.Type) {
					case FormulaItemType.Column: {
						formula += GetInjectedValue(injectedValues, currentItem.Value);
						break;
					}
					case FormulaItemType.Number:
					case FormulaItemType.Operand:
						formula += currentItem.Value;
						break;
					case FormulaItemType.Function: {
						functions = functions ?? GetFunctions(formulaItems);
						var function = functions.First(f => f.StartIndexInFormula == i);
						var columnOperand = function.Operands.First();
						string key = FormFunctionValueKey(currentItem.Value, columnOperand.Value);
						formula += GetInjectedValue(injectedValues, key);
						i += function.Rule.FunctionMaxLengthExpectHeader;
						break;
					}
					default:
						throw new Exception(
							string.Format("Formula type {0} not supported", currentItem.Type.ToString()));
				}
			}
			return formula;
		}

		private string GetInjectedValue(IDictionary<string, string> dictionary, string key) {
			dictionary.TryGetValue(key, out var value);
			return string.IsNullOrEmpty(value) ? "0" : value;
		}

		private bool HasCorrectOrder(IEnumerable<FormulaItem> formulaItems) {
			var items = formulaItems?.ToList();
			if (items == null || items.IsEmpty()) {
				return false;
			}
			if (items.Count() == 1) {
				return items[0].Type == FormulaItemType.Number || items[0].Type == FormulaItemType.Column;
			}
			FormulaItem lastItem = items[items.Count() - 1];
			if (lastItem.Type == FormulaItemType.Function) {
				return false;
			}
			var functions = GetFunctions(items).ToList();
			for (var i = 0; i < items.Count() - 1; i++) {
				FormulaItem currentItem = items[i];
				FormulaItem nextItem = items[i + 1];
				switch (currentItem.Type) {
					case FormulaItemType.Number: {
						if (nextItem.Type == FormulaItemType.Column ||
							nextItem.Type == FormulaItemType.Function) {
							return false;
						}
						break;
					}
					case FormulaItemType.Column: {
						if (nextItem.Type == FormulaItemType.Column ||
							nextItem.Type == FormulaItemType.Number ||
							nextItem.Type == FormulaItemType.Function) {
							return false;
						}
						break;
					}
					case FormulaItemType.Function: {
						FunctionInfo functionInfo
							= functions.First(item => item.StartIndexInFormula.Equals(i));
						if (!FunctionValidator.Validate(functionInfo) ||
							IsNextElementAfterFunctionNotAllowed(items, functionInfo)) {
							return false;
						}
						i += functionInfo.Rule.FunctionMaxLengthExpectHeader;
						break;
					}
				}
			}
			return true;
		}

		private bool IsNextElementAfterFunctionNotAllowed(List<FormulaItem> items, FunctionInfo functionInfo) {
			int nextElementIndex
				= functionInfo.StartIndexInFormula + functionInfo.Rule.FunctionMaxLength;
			bool isNextElementNotOutOfListRange = nextElementIndex < items.Count();
			if (isNextElementNotOutOfListRange) {
				FormulaItem nextItem = items[nextElementIndex];
				if (nextItem.Type == FormulaItemType.Column ||
					nextItem.Type == FormulaItemType.Number ||
					nextItem.Type == FormulaItemType.Function) {
					return true;
				}
			}
			return false;
		}

		private IDictionary<string, string> GetTestInjectableColumnValues(IEnumerable<FormulaItem> formulaItems) {
			var cells = formulaItems.Where(i => i.Type == FormulaItemType.Column)
				.Distinct()
				.Select(i => new TableCell {
					ColumnCode = i.Value,
					Value = 1,
					FunctionsValueMap = new Dictionary<string, double> {
						{ FunctionConstants.Sum, 1},
						{ FunctionConstants.Avg, 1}
					}
				});
			return GetFormulaValues(formulaItems, cells);
		}

		private bool CheckCanCalculate(IEnumerable<ForecastColumn> allColumns, ForecastColumn formulaColumn,
			IEnumerable<Guid> calculatedColumns) {
			var result = true;
			var referenceColumns = GetReferenceColumns(allColumns, formulaColumn);
			foreach (var referenceColumn in referenceColumns) {
				if (referenceColumn.TypeId.Equals(ForecastConsts.FormulaColumnTypeId) ) {
					if (calculatedColumns.Contains(referenceColumn.Id)) {
						continue;
					}
					result = false;
				}
				break;
			}
			return result;
		}

		private ForecastColumn NextCalculationColumn(IEnumerable<ForecastColumn> formulaColumns,
			IEnumerable<Guid> calculatedColumns, ForecastColumn lastColumn = null) {
			return formulaColumns.FirstOrDefault(column =>
				!calculatedColumns.Contains(column.Id) && !column.Id.Equals(lastColumn?.Id));
		}

		private IEnumerable<ForecastColumn> GetFormulaColumns(IEnumerable<ForecastColumn> columns) {
			return columns.Where(column => column.TypeId == ForecastConsts.FormulaColumnTypeId);
		}

		#endregion

		#region Methods: Public

		/// <summary>
		/// Forms formula values from table cells.
		/// </summary>
		/// <param name="formula">Formula items collection.</param>
		/// <param name="cells">Table cells with values.</param>
		/// <param name="config">Value configuration.</param>
		/// <returns>Dictionary with values needed for formula column items.</returns>
		public Dictionary<string, string> GetFormulaValues(IEnumerable<FormulaItem> formula,
			IEnumerable<TableCell> cells, FormulaValueConfig config = null) {
			var values = new Dictionary<string, string>();
			config = config ?? new FormulaValueConfig();
			IEnumerable<FunctionInfo> functions = null;
			for (int i = 0; i < formula.Count(); i++) {
				var formulaItem = formula.ElementAt(i);
				double value = 0;
				string columnId, key;
				TableCell cell;
				switch (formulaItem.Type) {
					case FormulaItemType.Column:
						key = columnId = formulaItem.Value;
						cell = cells.FirstOrDefault(item => item.ColumnCode.StartsWith(columnId));
						value = cell?.Value ?? 0;
						break;
					case FormulaItemType.Function:
						functions = functions ?? GetFunctions(formula);
						var function = functions.First(f => f.StartIndexInFormula == i);
						var columnOperand = function.Operands.First();
						columnId = columnOperand.Value;
						cell = cells.FirstOrDefault(item => item.ColumnCode.StartsWith(columnId));
						cell?.FunctionsValueMap?.TryGetValue(formulaItem.Value, out value);
						key = FormFunctionValueKey(formulaItem.Value, columnId);
						i += function.Rule.FunctionMaxLength;
						break;
					default:
						continue;
				}
				if (values.ContainsKey(key)) {
					continue;
				}
				values.Add(key, value.ToString("F" + config.Precision, CultureInfo.InvariantCulture));
			}
			return values;
		}

		/// <summary>
		/// Iterates formula columns in their dependency order.
		/// </summary>
		/// <param name="columns">All columns collection.</param>
		/// <param name="iterateFn">Iterate function.</param>
		public void IterateFormulaColumns(IEnumerable<ForecastColumn> columns, Action<ForecastColumn> iterateFn) {
			List<Guid> calculatedColumns = new List<Guid>();
			var formulaColumns = GetFormulaColumns(columns);
			ForecastColumn calculationColumn = NextCalculationColumn(formulaColumns, calculatedColumns);
			while (calculationColumn != null) {
				if (CheckCanCalculate(columns, calculationColumn, calculatedColumns)) {
					iterateFn?.Invoke(calculationColumn);
					calculatedColumns.Add(calculationColumn.Id);
				}
				calculationColumn = NextCalculationColumn(formulaColumns, calculatedColumns,
					calculationColumn);
			}
		}

		/// <summary>
		/// Returns the depend columns.
		/// </summary>
		/// <param name="columns">The columns.</param>
		/// <param name="parentColumn">The parent column.</param>
		/// <returns>
		/// Collection of depend columns.
		/// </returns>
		public virtual IEnumerable<ForecastColumn> GetDependColumns(IEnumerable<ForecastColumn> columns, ForecastColumn parentColumn) {
			var result = new List<ForecastColumn>();
			var formulaColumns = columns.Where(item => item.TypeId.Equals(ForecastConsts.FormulaColumnTypeId));
			foreach (var formulaColumn in formulaColumns) {
				if (HasReference(formulaColumn, parentColumn)) {
					result.Add(formulaColumn);
				}
			}
			return result;
		}

		/// <summary>
		/// Returns the reference columns.
		/// </summary>
		/// <param name="columns">The columns.</param>
		/// <param name="targetColumn">The target column.</param>
		/// <returns>
		/// Collection of reference columns.
		/// </returns>
		public IEnumerable<ForecastColumn> GetReferenceColumns(IEnumerable<ForecastColumn> columns,
				ForecastColumn targetColumn) {
			if (!targetColumn.TypeId.Equals(ForecastConsts.FormulaColumnTypeId)) {
				return Enumerable.Empty<ForecastColumn>();
			}
			var formulaItems = GetFormulaItems(targetColumn);
			var columnItems = formulaItems?.Where(item => item.Type.Equals(FormulaItemType.Column));
			return columns.Where(column =>
				columnItems.Any(a =>
					a.Value.Equals(column.Id.ToString())
				)
			);
		}

		/// <summary>
		/// Deserializes the formula.
		/// </summary>
		/// <param name="column">The formula column.</param>
		/// <returns>
		/// Collection of <see cref="FormulaItem" />
		/// </returns>
		public IEnumerable<FormulaItem> DeserializeFormula(ForecastColumn column) {
			return GetFormulaItems(column);
		}

		/// <summary>
		/// Calculates the specified formula items.
		/// </summary>
		/// <param name="formulaItems">The formula items.</param>
		/// <param name="injectedValues">The injected values.</param>
		/// <returns>
		/// Calculated value.
		/// </returns>
		public decimal Calculate(IEnumerable<FormulaItem> formulaItems, IDictionary<string, string> injectedValues) {
			var formula = GetFormula(formulaItems, injectedValues);
			return GetCalculatedFormulaValue(formula);
		}

		/// <summary>
		/// Validates the specified formula items.
		/// </summary>
		/// <param name="formulaItems">The formula items.</param>
		/// <returns>
		/// It is valid formula.
		/// </returns>
		public bool Validate(IEnumerable<FormulaItem> formulaItems) {
			if (formulaItems == null) {
				return false;
			}
			if (!HasCorrectOrder(formulaItems)) {
				return false;
			}
			var testInjectableValues = GetTestInjectableColumnValues(formulaItems);
			var formula = GetFormula(formulaItems, testInjectableValues);
			try {
				var value = GetCalculatedFormulaValue(formula);
			}
			catch (Exception) {
				return false;
			}
			return true;
		}

		/// <summary>
		/// Forms function value code.
		/// </summary>
		/// <param name="functionCode">Function code.</param>
		/// <param name="columnCode">Column code.</param>
		/// <returns>Function value code.</returns>
		public string FormFunctionValueKey(string functionCode, string columnCode) {
			return $"{functionCode}:{columnCode}";
		}

		/// <summary>
		/// Gets functions from specified formula.
		/// </summary>
		/// <param name="formulaItems">Formula items.</param>
		/// <returns>List of functions witch contains in specified formula.</returns>
		public IEnumerable<FunctionInfo> GetFunctions(IEnumerable<FormulaItem> formulaItems) {
			var items = formulaItems.ToList();
			var result = new List<FunctionInfo>();
			for (var i = 0; i < items.Count(); i++) {
				FormulaItem currentItem = items[i];
				if (currentItem.Type == FormulaItemType.Function) {
					var funcInfo = new FunctionInfo(formulaItems, i);
					result.Add(funcInfo);
				}
			}
			return result;
		}


		#endregion

	}

	#endregion

}

