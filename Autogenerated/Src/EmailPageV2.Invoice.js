define("EmailPageV2", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
	return {
		entitySchemaName: "Activity",
		methods: {
			/**
			 * ######## ######## ####### ## ##### # ####### ######.
			 * @overridden
			 * @param {Object} entity ##### ##########.
			 * @param {Object} actionType ########, ########### # #######.
			 */
			copyEntityColumnValues: function(entity) {
				var invoice = entity.get("Invoice");
				if (invoice) {
					this.set("Invoice", invoice);
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
				columnsArray.push("Invoice");
				return columnsArray;
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[],/**SCHEMA_DIFF*/
		rules: {
			"Invoice": {
				"FiltrationInvoiceByAccount": {
					"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
					"autocomplete": true,
					"autoClean": true,
					"baseAttributePatch": "Account",
					"comparisonType": BPMSoft.ComparisonType.EQUAL,
					"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					"attribute": "Account"
				},
				"FiltrationInvoiceByContact": {
					"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
					"autocomplete": true,
					"autoClean": true,
					"baseAttributePatch": "Contact",
					"comparisonType": BPMSoft.ComparisonType.EQUAL,
					"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					"attribute": "Contact"
				}
			}
		}
	};
});
