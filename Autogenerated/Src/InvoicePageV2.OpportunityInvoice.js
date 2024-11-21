define("InvoicePageV2", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "Invoice",
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#init
				 * @overridden
				 */
				init: function() {
					this.on("change:Opportunity", this.initMultiLookup, this);
					this.callParent(arguments);
				}
			},
			rules: {
				"Opportunity": {
					"FiltrationOpportunityByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					},
					"FiltrationOpportunityByContact": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Contact",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Contact"
					}
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
