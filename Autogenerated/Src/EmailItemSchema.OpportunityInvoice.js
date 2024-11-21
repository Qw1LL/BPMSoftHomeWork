define("EmailItemSchema", ["BusinessRuleModule", "EmailConstants"], function(BusinessRuleModule, EmailConstants) {
    return {
        entitySchemaName: EmailConstants.entitySchemaName,
        methods: {},
        diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
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
        }
    };
});
