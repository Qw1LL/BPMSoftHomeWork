define("EmailPageV2", ["BusinessRuleModule", "ConfigurationConstants"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "Activity",
			methods: {
				/**
				 * ######## ######## ####### ## ##### # ####### ######.
				 * @overridden
				 * @param {Object} entity ##### ##########.
				 */
				copyEntityColumnValues: function(entity) {
					var order = entity.get("Order");
					if (order) {
						this.set("Order", order);
					}
					this.callParent(arguments);
				},

				/**
				 * ########## ###### ########### #######.
				 * @private
				 * @overridden
				 * @return {Array} ###### #######.
				 */
				getEmailSelectColumns: function() {
					var columnsArray = this.callParent(arguments);
					columnsArray.push("Order");
					return columnsArray;
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				/*{
					"operation": "merge",
					"name": "Lead",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "EmailPageLinksBlock",
					"propertyName": "items",
					"name": "Order",
					"values": {
						"bindTo": "Order",
						"layout": {"column": 0, "row": 2, "colSpan": 11}
					}
				}*/
			]/**SCHEMA_DIFF*/,
			rules: {
				"Order": {
					"FiltrationOrderByContact": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Contact",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Contact"
					},
					"FiltrationOrderByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"autoClean": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "Account"
					}
				}
			}
		};
	});
