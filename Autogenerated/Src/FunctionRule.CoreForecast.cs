namespace BPMSoft.Configuration.ForecastV2
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using BPMSoft.Common;

	#region Class: FunctionRuleFactory

	/// <summary>
	/// Provides factory methods for getting function rules
	/// </summary>
	public static class FunctionRuleFactory
	{
		/// <summary>
		/// Returns function rules based on function type.
		/// </summary>
		/// <param name="item">The function formula item.</param>
		/// <returns><see cref="FunctionRule"/>The function rule.</returns>
		public static FunctionRule GetRule(FormulaItem item) {
			ValidateArguments(item);
			return new SimpleFunctionRules();
		}

		private static void ValidateArguments(FormulaItem formulaItem) {
			formulaItem.CheckArgumentNull(nameof(formulaItem));
			if (formulaItem.Type != FormulaItemType.Function) {
				throw new ArgumentException($"Expected formula item with type " +
					$"{FormulaItemType.Function.ToString()} but was passed item with type {formulaItem.Type.ToString()}.");
			}
		}
	}

	#endregion
	
	#region Class: FunctionRule

	/// <summary>
	/// Provides function rules
	/// </summary>
	public abstract class FunctionRule
	{

		#region Fields: Private

		private List<FormulaItem> _functionPattern;

		#endregion

		#region Properties: Public

		/// <summary>
		/// Gets the function pattern.
		/// </summary>
		public List<FormulaItem> Pattern {
			get {
				if (_functionPattern == null) {
					_functionPattern = GetDefinedPattern();
				}
				return _functionPattern;
			}
		}

		/// <summary>
		/// Gets max operand count in pattern..
		/// </summary>
		public int FunctionMaxOperandCount { get; }

		/// <summary>
		/// Gets count of service items in pattern.
		/// </summary>
		public int FunctionServiceItemsCount { get; }

		/// <summary>
		/// Gets position of first operand in pattern.
		/// </summary>
		public int FunctionStartOperandPosition { get; }

		/// <summary>
		/// Gets count of function headers in pattern.
		/// </summary>
		public int FunctionHeaderItemsCount { get; }

		/// <summary>
		/// Gets max function length based on pattern.
		/// </summary>
		public int FunctionMaxLength { get; }

		/// <summary>
		/// Gets max function length expect header items based on pattern.
		/// </summary>
		public int FunctionMaxLengthExpectHeader { get; }

		#endregion

		#region Methods: Abstract

		/// <summary>
		/// Gets defined function pattern.
		/// </summary>
		protected abstract List<FormulaItem> GetDefinedPattern();

		#endregion

		#region Constructors: Public

		/// <summary>
		/// Initialized function rules
		/// </summary>
		protected FunctionRule() {
			FunctionMaxOperandCount = Pattern.Count(item => item.Type == FormulaItemType.Column);
			FunctionServiceItemsCount = Pattern.Count(item => item.Type == FormulaItemType.Operand);
			FunctionStartOperandPosition = Pattern.FindIndex(item => item.Type == FormulaItemType.Column);
			FunctionHeaderItemsCount = Pattern.Count(item => item.Type == FormulaItemType.Function);
			FunctionMaxLength = FunctionHeaderItemsCount + FunctionServiceItemsCount + FunctionMaxOperandCount;
			FunctionMaxLengthExpectHeader = FunctionMaxLength - FunctionHeaderItemsCount;
		}

		#endregion

	}

	#endregion

	#region Class: SimpleFunctionRules

	/// <summary>
	/// Provides simple function rules
	/// </summary>
	public class SimpleFunctionRules : FunctionRule
	{
		/// <inheritdoc />
		protected override List<FormulaItem> GetDefinedPattern() {
			var pattern = new List<FormulaItem>() {
				new FormulaItem {
					Type = FormulaItemType.Function,
					Value = null
				},
				new FormulaItem {
					Type = FormulaItemType.Operand,
					Value = "("
				},
				new FormulaItem {
					Type = FormulaItemType.Column,
					Value = null
				},
				new FormulaItem {
					Type = FormulaItemType.Operand,
					Value = ")"
				}
			};
			return pattern;
		}
	}
	
	#endregion
}

