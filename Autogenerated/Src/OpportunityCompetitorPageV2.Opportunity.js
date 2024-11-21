define("OpportunityCompetitorPageV2", ["BusinessRuleModule", "ConfigurationConstants"],
	function(BusinessRuleModule, ConfigurationConstants) {
		return {
			entitySchemaName: "OpportunityCompetitor",
			attributes: {
				"CompetitorProduct": {
					lookupListConfig: {
						columns: ["Weakness", "Strengths"]
					}
				},
				"Weakness": {
					dependencies: [
						{
							columns: ["CompetitorProduct"],
							methodName: "onCompetitorProductSelect"
						}
					]
				},
				"Strengths": {
					dependencies: [
						{
							columns: ["Competitor"],
							methodName: "onCompetitorSelect"
						}
					]
				}
			},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			methods: {
				/**
				 * ######### ############ ########## ##### ########
				 * @overriden
				 * @returns {boolean}
				 */
				validate: function() {
					if (!this.callParent(arguments)) {
						return false;
					}
					return this.externalValidate();
				},

				externalValidate: function() {
					if (!this.get("Supplier") && !this.get("CompetitorProduct")) {
						var message = Ext.String.format(
							this.get("Resources.Strings.SupplierOrProductRequiredMessage"));
						this.showInformationDialog(message);
						return false;
					}
					return true;
				},

				/**
				 * ##### ########## ###### Weakness # Strengths ### ##### CompetitorProduct
				 * @private
				 */
				onCompetitorProductSelect: function() {
					var competitorProduct = this.get("CompetitorProduct");
					if (!competitorProduct) {
						this.set("Weakness", null);
						this.set("Strengths", null);
					} else {
						this.set("Weakness", competitorProduct.Weakness);
						this.set("Strengths", competitorProduct.Strengths);
					}
				},

				/**
				 * ####### CompetitorProduct ### ##### Competitor
				 * @private
				 */
				onCompetitorSelect: function() {
					var competitor = this.get("Competitor");
					if (this.Ext.isEmpty(competitor)) {
						this.set("CompetitorProduct", null);
					}
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Opportunity",
					"values": {
						"bindTo": "Opportunity",
						"layout": { "column": 0, "row": 0, "colSpan": 11 },
						"enabled": false,
						"controlConfig": {
							"enableRightIcon": false
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Supplier",
					"values": {
						"bindTo": "Supplier",
						"layout": { "column": 13, "row": 0, "colSpan": 11 }
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Competitor",
					"values": {
						"bindTo": "Competitor",
						"layout": { "column": 0, "row": 1, "colSpan": 11 }
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "CompetitorProduct",
					"values": {
						"bindTo": "CompetitorProduct",
						"layout": { "column": 13, "row": 1, "colSpan": 11 }
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Weakness",
					"values": {
						"bindTo": "Weakness",
						"layout": { "column": 0, "row": 2, "colSpan": 11 },
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Strengths",
					"values": {
						"bindTo": "Strengths",
						"layout": { "column": 13, "row": 2, "colSpan": 11 },
						"contentType": BPMSoft.ContentType.LONG_TEXT
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "IsWinner",
					"values": {
						"bindTo": "IsWinner",
						"layout": { "column": 0, "row": 3, "colSpan": 11 }
					}
				},
				{
					"operation": "merge",
					"name": "Tabs",
					"parentName": "CardContentContainer",
					"propertyName": "items",
					"values": {
						"visible": false
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"CompetitorProduct": {
					"FiltrationCompetitorProductByCompetitor": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "Competitor",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Competitor"
					}
				},
				"Supplier": {
					"FiltrationSupplierByCompetitorType": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"baseAttributePatch": "Type",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.CONSTANT,
						"value": ConfigurationConstants.AccountType.Competitor
					}
				}
			}
		};
	});
