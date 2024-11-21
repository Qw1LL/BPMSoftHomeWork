define("LeadPageV2", ["BusinessRuleModule", "ConfigurationConstants"],
		function(BusinessRuleModule, ConfigurationConstants) {
			return {
				entitySchemaName: "Lead",
				attributes: {
					"PartnersSaleOpportunityType": {
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"value": ConfigurationConstants.Opportunity.Type.PartnerSale
					},
					"Partner": {
						"dependencies": [
							{
								"columns": ["SalesChannel"],
								"methodName": "onSalesChannelChanged"
							},
							{
								"columns": ["Owner"],
								"methodName": "onOwnerChanged"
							}
						],
						"onChange": "autoCompleteOwner",
						"lookupListConfig": {
							"columns": [
								"[VwSystemUsers:Contact:PrimaryContact].Contact"
							]
						}
					},
					"PartnerAccountType": {
						"dataValueType": BPMSoft.DataValueType.GUID,
						"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						"value": ConfigurationConstants.AccountType.Partner
					},
					"Owner": {
						"dataValueType": BPMSoft.DataValueType.LOOKUP,
						"lookupListConfig": {
							"filter": function () {
								return this.getOwnerFilter("SalesChannel");
							},
							"columns": [
								"Account.Type"
							]
						}
					}
				},
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"name": "SalesChannel",
						"values": {
							"layout": {
								"column": 0,
								"row": 7,
								"colSpan": 24
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"parentName": "ProfileContainer",
						"propertyName": "items",
						"name": "Partner",
						"values": {
							"layout": {
								"column": 0,
								"row": 8,
								"colSpan": 24
							}
						}
					}
				],
				methods: {

					/**
					 * SalesChannel changed event method handler.
					 */
					onSalesChannelChanged: function() {
						this.clearPartnerIfColumnChange("SalesChannel");
					},

					/**
					 * Handle Owner column change.
					 */
					onOwnerChanged: function() {
						this.fillPartnerByOwner();
					}
				},
				rules: {
					"Partner": {
						"VisibleRule": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.VISIBLE,
							"conditions": [{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "SalesChannel"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "PartnersSaleOpportunityType"
								}
							}]
						},
						"RequiredRule": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.REQUIRED,
							"conditions": [{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "SalesChannel"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "PartnersSaleOpportunityType"
								}
							}]
						},
						"FiltrationPartnerByAccountType": {
							"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
							"autocomplete": true,
							"baseAttributePatch": "Type",
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "PartnerAccountType"
						}
					},
					"Owner": {
						"RequiredRule": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.REQUIRED,
							"conditions": [{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "SalesChannel"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "PartnersSaleOpportunityType"
								}
							}]
						}
					}
				}
		};
	});
