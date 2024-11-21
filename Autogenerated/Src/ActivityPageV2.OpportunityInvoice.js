define("ActivityPageV2", ["BusinessRuleModule"], function(BusinessRuleModule) {
	return {
		entitySchemaName: "Activity",
		rules: {
			"Invoice": {
				"FiltrationInvoiceByOpportunity": {
					"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
					"autocomplete": true,
					"autoClean": true,
					"baseAttributePatch": "Opportunity",
					"comparisonType": BPMSoft.ComparisonType.EQUAL,
					"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					"attribute": "Opportunity"
				}
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
