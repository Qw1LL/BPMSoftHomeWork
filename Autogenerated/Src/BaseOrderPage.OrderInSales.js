define("BaseOrderPage", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "Order",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
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
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "OrderPageGeneralInformationBlock",
					"propertyName": "items",
					"name": "Opportunity",
					"values": {
						"bindTo": "Opportunity",
						"layout": {"column": 0, "row": 1, "colSpan": 11, "rowSpan": 1},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OpportunityTip"}
						}
					},
					"index": 2
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"Opportunity": {
					"FiltrationOpportunityByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					},
					"FiltrationOpportunityByContact": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "Contact",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Contact"
					}
				}
			}
		};
	});
