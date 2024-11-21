namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;

	#region Class: FunctionConstants

	/// <summary>
	/// Provides function constants.
	/// </summary>
	public static class FunctionConstants
	{
		/// <summary>
		/// Gets constant for sum function.
		/// </summary>
		public const string Sum = "SUM";

		/// <summary>
		/// Gets constant for average function.
		/// </summary>
		public const string Avg = "AVG";

	}

	#endregion

	#region Class: FunctionInfo

	/// <summary>
	/// Provides function information.
	/// </summary>
	public class FunctionInfo
	{

		#region Properties: Public

		/// <summary>
		/// Gets function start index in formula.
		/// </summary>
		public int StartIndexInFormula { get; private set; }

		/// <summary>
		/// Gets function item.
		/// </summary>
		public FormulaItem Function { get; private set; }

		/// <summary>
		/// Gets function body.
		/// </summary>
		public IEnumerable<FormulaItem> Body { get; private set; }

		/// <summary>
		/// Gets function operands.
		/// </summary>
		public IEnumerable<FormulaItem> Operands { get; private set; }

		/// <summary>
		/// Gets function rule.
		/// </summary>
		public FunctionRule Rule { get; private set; }
		
		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialized instance.
		/// </summary>
		/// <param name="formulaItems">Formula items.</param>
		/// <param name="functionStartIndex">Function start index.</param>
		public FunctionInfo(IEnumerable<FormulaItem> formulaItems, int functionStartIndex) {
			ValidateArguments(formulaItems, functionStartIndex);
			Init(formulaItems, functionStartIndex);
		}
		
		#endregion

		#region Methods: Private

		private void Init(IEnumerable<FormulaItem> formulaItems, int functionStartIndex) {
			StartIndexInFormula = functionStartIndex;
			var items = formulaItems.ToList();
			Function = items[functionStartIndex];
			Rule = FunctionRuleFactory.GetRule(Function);
			var rangeCount =
				GetMaxAvailableFunctionRangeCount(items.Count(), functionStartIndex, Rule.FunctionMaxLength);
			Body = items.GetRange(functionStartIndex, rangeCount);
			Operands = Body.Where(item => item.Type == FormulaItemType.Column);
		}
		
		private int GetMaxAvailableFunctionRangeCount(int itemsCount, int functionStartIndex, int functionMaxLength) {
			int maxAvailableItemsCount = functionMaxLength;
			int functionExpectedEndIndex = functionStartIndex + functionMaxLength;
			bool isFunctionEndOutOfListRange = functionExpectedEndIndex >= itemsCount;
			if (isFunctionEndOutOfListRange) {
				maxAvailableItemsCount = itemsCount - functionStartIndex;
			}
			return maxAvailableItemsCount;
		}

		private void ValidateArguments(IEnumerable<FormulaItem> formulaItems, int functionStartIndex) {
			formulaItems.CheckArgumentNull(nameof(formulaItems));
			if (functionStartIndex < 0) {
				throw new ArgumentException($"Argument {nameof(functionStartIndex)} can not be less then zero.");
			}
			int formulaCount = formulaItems.Count();
			if (functionStartIndex > formulaCount) {
				throw new ArgumentException($"Argument {nameof(functionStartIndex)} can not be " +
					$"greater then {nameof(formulaItems)} count.");
			}
		}
		
		#endregion
	}
	
	#endregion

	#region Class: FunctionValidator

	/// <summary>
	/// Provides methods for function validation
	/// </summary>
	public class FunctionValidator
	{

		#region Properties: Public

		/// <summary>
		/// Gets supported function types.
		/// </summary>
		public static readonly IEnumerable<string> SupportedTypes = new List<string>() {
			FunctionConstants.Sum,
			FunctionConstants.Avg
		};

		#endregion

		#region Methods: Public

		/// <summary>
		/// Verify is specific function supported.
		/// </summary>
		/// <param name="functionType">The function type.</param>
		/// <returns>
		/// True if function supported.
		/// </returns>
		public static bool IsFunctionTypeSupported(string functionType) {
			return SupportedTypes.Contains(functionType);
		}

		/// <summary>
		/// Validate function based on function type.
		/// </summary>
		/// <param name="functionInfo">Function information.</param>
		/// <returns>True when function valid, false when function not valid.</returns>
		public bool Validate(FunctionInfo functionInfo) {
			functionInfo.CheckArgumentNull(nameof(functionInfo));
			return IsFunctionMatchesPattern(functionInfo);
		}

		#endregion

		#region Methods: Private

		private bool IsFunctionMatchesPattern(FunctionInfo functionInfo) {
			var formulaItems = functionInfo.Body?.ToList();
			if (formulaItems == null || formulaItems.Count() != functionInfo.Rule.FunctionMaxLength) {
				return false;
			}
			var functionPattern = functionInfo.Rule.Pattern;
			for (var i = 0; i < functionPattern.Count(); i++) {
				FormulaItem itemToValidate = formulaItems[i];
				FormulaItem validationPattern = functionPattern[i];
				if (!IsValidItem(itemToValidate, validationPattern)) {
					return false;
				}
			}
			return true;
		}

		private bool IsValidItem(FormulaItem itemToValidate, FormulaItem patternItem) {
			if (itemToValidate.Type != patternItem.Type) {
				return false;
			}
			if (itemToValidate.Type == FormulaItemType.Function) {
				return IsFunctionTypeSupported(itemToValidate.Value);
			}
			if (patternItem.Value != null) {
				return itemToValidate.Value.Equals(patternItem.Value);
			}
			return true;
		}

		#endregion

	}

	#endregion

}

