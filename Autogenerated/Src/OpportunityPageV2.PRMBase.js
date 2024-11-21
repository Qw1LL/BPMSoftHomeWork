define("OpportunityPageV2", ["BusinessRuleModule", "ConfigurationConstants"],
		function(BusinessRuleModule, ConfigurationConstants) {
			return {
				entitySchemaName: "Opportunity",
				attributes: {
					"PartnerAccountType": {
						"dataValueType": BPMSoft.DataValueType.GUID,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"value": ConfigurationConstants.AccountType.Partner
					},
					"Partner": {
						dependencies: [
							{
								columns: ["Type"],
								methodName: "onTypeChanged"
							},
							{
								columns: ["Owner"],
								methodName: "onOwnerChanged"
							}
						],
						onChange: "autoCompleteOwner",
						lookupListConfig: {
							columns: [
								"[VwSystemUsers:Contact:PrimaryContact].Contact"
							]
						}
					},
					"Owner": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {
							filter: function () {
								return this.getOwnerFilter("Type");
							},
							columns: [
								"Account.Type"
							]
						},
						dependencies: [
							{
								columns: ["ResponsibleDepartment"],
								methodName: "setOpportunityByResponsibleDepartment"
							}
						]
					}
				},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[],
				methods: {

					/**
					 * Clear partner if type change.
					 */
					onTypeChanged: function () {
						this.clearPartnerIfColumnChange("Type");
					},

					/**
					 * Handle Owner column change.
					 */
					onOwnerChanged: function() {
						this.clearPartnerIfColumnChange("Type");
						this.fillPartnerByOwner();
					}

				},
				rules: {
					"Partner": {
						"FiltrationPartnerByAccountType": {
							"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
							"autocomplete": true,
							"baseAttributePatch": "Type",
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "PartnerAccountType"
						}
					}
				}
		};
	});
