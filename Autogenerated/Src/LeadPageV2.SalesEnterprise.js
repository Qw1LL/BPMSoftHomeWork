define("LeadPageV2", ["BusinessRuleModule", "LeadConfigurationConst"],
	function(BusinessRuleModule, LeadConfigurationConst) {
		return {
			entitySchemaName: "Lead",
			attributes: {
				"OpportunityOrOrder": {
					"caption": {"bindTo": "Resources.Strings.OpportunityOrOrderCaption"},
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"multiLookupColumns": ["Opportunity", "Order"]
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "LeadWebFormInProfile",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3
					}
				}
			},
			{
				"operation": "move",
				"name": "LeadWebFormInProfile",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "merge",
				"name": "SalesChannel",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 7
					}
				}
			},
			{
				"operation": "move",
				"name": "SalesChannel",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "merge",
				"name": "Partner",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 9
					}
				}
			},
			{
				"operation": "insert",
				"name": "OpportunityOrOrderV2",
				"values": {
					"markerValue": {
						"bindTo": "Resources.Strings.OpportunityOrOrderCaption"
					},
					"caption": {
						"bindTo": "Resources.Strings.OpportunityOrOrderCaption"
					},
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "LeadPageSQLTabGridLayout"
					},
					"contentType": 5,
					"bindTo": "OpportunityOrOrder"
				},
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "merge",
				"name": "SalesOwnerV2",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "LeadPageSQLTabGridLayout"
					}
				}
			},
			{
				"operation": "move",
				"name": "SalesOwnerV2",
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "merge",
				"name": "OpportunityDepartmentV2",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "LeadPageSQLTabGridLayout"
					}
				}
			},
			{
				"operation": "move",
				"name": "OpportunityDepartmentV2",
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "merge",
				"name": "CountryStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "RegionStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "CityStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "BpmRef",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0
					}
				}
			},
			{
				"operation": "move",
				"name": "BpmRef",
				"parentName": "LeadPageSourceInfoBlock",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "WebForm",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1
					}
				}
			},
			{
				"operation": "move",
				"name": "WebForm",
				"parentName": "LeadPageSourceInfoBlock",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "OpportunityOrOrder",
				"values": {
					"markerValue": {
						"bindTo": "Resources.Strings.OpportunityOrOrderCaption"
					},
					"caption": {
						"bindTo": "Resources.Strings.OpportunityOrOrderCaption"
					},
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					},
					"contentType": 5,
					"bindTo": "OpportunityOrOrder"
				},
				"parentName": "LeadPageDealInformationBlock",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "merge",
				"name": "SalesOwner",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2
					},
					"caption": {
						"bindTo": "Resources.Strings.DealOwnerCaption"
					}
				}
			},
			{
				"operation": "move",
				"name": "SalesOwner",
				"parentName": "LeadPageDealInformationBlock",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "merge",
				"name": "OpportunityDepartment",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 3
					}
				}
			},
			{
				"operation": "remove",
				"name": "Order"
			},
			{
				"operation": "remove",
				"name": "Opportunity"
			}
		]/**SCHEMA_DIFF*/,
			rules: {
				"OpportunityOrOrder": {
					"EnabledOpportunityOrOrderForQualifyStatus": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "QualifyStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": LeadConfigurationConst.LeadConst.QualifyStatus.TransferForSale
							}
						}, {
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "QualifyStatus"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": LeadConfigurationConst.LeadConst.QualifyStatus.WaitingForSale
							}
						}]
					}
				},
				"Opportunity": {
					"FilterOpportunityrByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "QualifiedAccount"
					}
				},
				"Order": {
					"FilterOrderByAccount": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "Account",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "QualifiedAccount"
					}
				},
				"MeetingDate": {
					"VisibleMeetingDateByOpportunityr": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Opportunity"
								},
								"comparisonType": BPMSoft.core.enums.ComparisonType.IS_NOT_NULL
							}
						]
					}
				},
				"DecisionDate": {
					"VisibleDecisionDateDateByOpportunityr": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Opportunity"
								},
								"comparisonType": BPMSoft.core.enums.ComparisonType.IS_NOT_NULL
							}
						]
					}
				},
				"OpportunityDepartment": {
					"VisibleOpportunityDepartmentByOpportunityr": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "Opportunity"
								},
								"comparisonType": BPMSoft.core.enums.ComparisonType.IS_NOT_NULL
							}
						]
					}
				}
			}
		};
	});
