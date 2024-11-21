define("FormulaColumnExtractor", [], function() {
	return Ext.define("BPMSoft.configuration.FormulaColumnExtractor", {
		alternateClassName: "BPMSoft.FormulaColumnExtractor",
		extend: "BPMSoft.BaseObject",
		
		_formulaItemTypes: null,
		
		_formulaOperatorTypes: null,
		
		_formulaOperandTypes: null,

		/**
		 * @type {Object}
		 */
		formula: null,

		/**
		 * @inheritDoc BPMSoft.BaseObject.constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			if (!this.formula) {
				throw Ext.create("BPMSoft.NullOrEmptyException");
			}
			this._formulaItemTypes = {
				operator: 0,
				operand: 1,
				function: 2
			};
			this._formulaOperatorTypes = {
				parentheses: 0,
				arithmetic: 1
			};
			this._formulaOpeandTypes = {
				column: 1
			};
		},

		_extractColumnsFromOperandFormulaItem: function(operandFormulaItem) {
			if (operandFormulaItem.operandType === this._formulaOpeandTypes.column) {
				return [operandFormulaItem.columnPath];
			}
			return [];
		},
		
		_extractColumnsFromOperatorFormulaItem: function(operatorFormulaItem) {
			switch (operatorFormulaItem.operatorType) {
				case this._formulaOperatorTypes.parentheses:
					return this._extractColumnsFromFormulaItem(operatorFormulaItem.expression);
				case this._formulaOperatorTypes.arithmetic:
					const leftExpressionColumnPaths = this._extractColumnsFromFormulaItem(operatorFormulaItem.leftExpression);
					const rightExpressionColumnPaths = this._extractColumnsFromFormulaItem(operatorFormulaItem.rightExpression);
					return leftExpressionColumnPaths.concat(rightExpressionColumnPaths);
				default:
					return [];
			}
		},

		_extractColumnsFromFunctionFormulaItem: function(functionFormulaItem) {
			return functionFormulaItem.arguments.reduce(function(columnPaths, formulaItem) {
				return columnPaths.concat(this._extractColumnsFromFormulaItem(formulaItem));
			}.bind(this), []);
		},
		
		_extractColumnsFromFormulaItem: function(formulaItem) {
			switch (formulaItem.type) {
				case this._formulaItemTypes.operator:
					return this._extractColumnsFromOperatorFormulaItem(formulaItem);
				case this._formulaItemTypes.operand:
					return this._extractColumnsFromOperandFormulaItem(formulaItem);
				case this._formulaItemTypes.function:
					return this._extractColumnsFromFunctionFormulaItem(formulaItem);
				default:
					return [];
			}
		},

		/**
		 * Extracts all column paths which used in formula expression. 
		 * @return {Array<String>}
		 */
		extractColumns: function() {
			return _.unique(this._extractColumnsFromFormulaItem(this.formula));
		}
	});
});
 