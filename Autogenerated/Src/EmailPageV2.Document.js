define("EmailPageV2", ["BusinessRuleModule"], function(BusinessRuleModule) {
	return {
		entitySchemaName: "Activity",
		methods: {
			/**
			 * ######## ######## ####### ## ##### # ####### ######.
			 * @overridden
			 * @param {Object} entity ##### ##########.
			 * @param {Object} actionType ########, ########### # #######.
			 */
			copyEntityColumnValues: function(entity, actionType) {
				var document = entity.get("Document");
				if (document) {
					this.set("Document", document);
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
				columnsArray.push("Document");
				return columnsArray;
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
		rules: {
			"Document": {
				"FiltrationDocumentByAccount": {
					"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
					"autocomplete": true,
					"autoClean": true,
					"baseAttributePatch": "Account",
					"comparisonType": BPMSoft.ComparisonType.EQUAL,
					"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					"attribute": "Account"
				},
				"FiltrationDocumentByContact": {
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
