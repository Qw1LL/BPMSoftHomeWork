define("ExpressionEnums", [], function() {

	Ext.ns("BPMSoft.ExpressionEnums");

	/**
	 * Expression type.
	 * @enum [BPMSoft.ExpressionEnums.ExpressionType]
	 */
	BPMSoft.ExpressionEnums.ExpressionType = {
		CONSTANT: "ConstantBusinessRuleExpression",
		ATTRIBUTE: "AttributeBusinessRuleExpression",
		SYSSETTING: "SysSettingBusinessRuleExpression",
		SYSVALUE: "SysValueBusinessRuleExpression",
		COLUMN: "ColumnBusinessRuleExpression",
		PARAMETER: "ParameterBusinessRuleExpression",
		DATASOURCE: "DataSourceBusinessRuleExpression",
		DETAIL: "DetailBusinessRuleExpression",
		MODULE: "ModuleBusinessRuleExpression",
		GROUP: "GroupBusinessRuleExpression",
		TAB: "TabBusinessRuleExpression",
		FORMULA: "FormulaBusinessRuleExpression"
	};

});
