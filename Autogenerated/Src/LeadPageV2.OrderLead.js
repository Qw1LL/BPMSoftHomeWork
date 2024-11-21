define("LeadPageV2", ["LeadPageV2Resources", "BusinessRuleModule", "LeadConfigurationConst"],
	function(resources, BusinessRuleModule, LeadConfigurationConst) {
		return {
			entitySchemaName: "Lead",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "move",
					"parentName": "LeadPageDealInformationBlock",
					"propertyName": "items",
					"name": "SalesOwner",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11
						},
						"contentType": BPMSoft.ContentType.LOOKUP,
						"bindTo": "SalesOwner"
					}
				},
				{
					"operation": "move",
					"parentName": "LeadPageDealInformationBlock",
					"propertyName": "items",
					"name": "OpportunityDepartment",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11
						},
						"contentType": BPMSoft.ContentType.ENUM,
						"enabled": {"bindTo": "SourceDataEditable"}
					}
				},
				{
					"operation": "insert",
					"parentName": "LeadPageDealInformationBlock",
					"propertyName": "items",
					"name": "Order",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"Order": {
					"FilterOrderByAccount": {
						ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
						autocomplete: true,
						baseAttributePatch: "Account",
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						attribute: "QualifiedAccount"
					},
					"EnabledOrderForQualifyStatus": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.ENABLED,
						conditions: [{
							leftExpression: {
								type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								attribute: "QualifyStatus"
							},
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							rightExpression: {
								type: BusinessRuleModule.enums.ValueType.CONSTANT,
								value: LeadConfigurationConst.LeadConst.QualifyStatus.WaitingForSale
							}
						}]
					}
				}
			},
			userCode: {}
		};
	});
