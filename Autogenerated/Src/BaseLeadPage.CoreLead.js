define("BaseLeadPage", ["BusinessRuleModule", "LeadSectionActionsDashboard", "LeadManagementUtilities"],
		function(BusinessRuleModule) {
	return {
		entitySchemaName: "Lead",
		mixins: {
			LeadManagementUtilities: "BPMSoft.LeadManagementUtilities"
		},
		details: /**SCHEMA_DETAILS*/{
			LeadProduct: {
				schemaName: "LeadProductDetailV2",
				entitySchemaName: "LeadProduct",
				filter: {
					masterColumn: "Id",
					detailColumn: "Lead"
				}
			}
		}/**SCHEMA_DETAILS*/,
		messages: {

			/**
			 * @message LaunchLeadManagement
			 * Launches LeadManagement process.
			 */
			"LaunchLeadManagement": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {
			"SourceDataEditable": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},
		methods: {

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.set("SourceDataEditable", true);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#subscribeSandboxEvents
			 * @overridden
			 */
			subscribeSandboxEvents: function() {
				const modulesIds = this.getModuleIds();
				this.sandbox.subscribe("LaunchLeadManagement", this.executeLeadManagementProcess, this,
					modulesIds);
				this.callParent(arguments);
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"name": "NewLeadType",
				"values": {
					"bindTo": "LeadType",
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"contentType": BPMSoft.ContentType.ENUM
				},
				"alias": {
					"name": "LeadType",
					"excludeProperties": ["layout"],
					"excludeOperations": ["remove", "move"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"name": "LeadRegisterMethodInProfile",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24
					},
					"contentType": BPMSoft.ContentType.ENUM,
					"bindTo": "RegisterMethod"
				},
				"alias": {
					"name": "RegisterMethodInProfile",
					"excludeProperties": ["layout"],
					"excludeOperations": ["remove", "move"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"name": "LeadBudget",
				"values": {
					"bindTo": "Budget",
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 24
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"name": "LeadCreatedOn",
				"values": {
					"bindTo": "CreatedOn",
					"layout": {
						"column": 0,
						"row": 5,
						"colSpan": 24
					},
					"enabled": false
				},
				"alias": {
					"name": "CreatedOn",
					"excludeProperties": ["layout"],
					"excludeOperations": ["remove", "move"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"name": "LeadOwner",
				"values": {
					"bindTo": "Owner",
					"layout": {
						"column": 0,
						"row": 6,
						"colSpan": 24
					}
				},
				"alias": {
					"name": "Owner",
					"excludeProperties": ["layout"],
					"excludeOperations": ["remove", "move"]
				}
			},
			{
				"operation": "insert",
				"name": "ActionsDashboardModule",
				"parentName": "ActionDashboardContainer",
				"propertyName": "items",
				"values": {
					"classes": {wrapClassName: ["actions-dashboard-module"]},
					"itemType": BPMSoft.ViewItemType.MODULE
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageGeneralInfoTabContainer",
				"propertyName": "items",
				"index": 0,
				"name": "LeadPageRegisterInfo",
				"values": {
					"caption": {bindTo: "Resources.Strings.LeadPageRegisterInfoCaption"},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"controlConfig": {"collapsed": false}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfo",
				"propertyName": "items",
				"name": "LeadPageRegisterInfoBlock",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"enabled": {"bindTo": "SourceDataEditable"},
					"collapseEmptyRow": false
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"name": "Contact",
				"values": {
					"markerValue": {"bindTo": "Resources.Strings.ContactCaption"},
					"enabled": {"bindTo": "SourceDataEditable"},
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					},
					"isRequired": false
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"name": "MobilePhone",
				"values": {
					"className": "BPMSoft.PhoneEdit",
					"markerValue": {"bindTo": "Resources.Strings.MobilePhoneCaption"},
					"enabled": {"bindTo": "SourceDataEditable"},
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"name": "Job",
				"values": {
					"markerValue": {"bindTo": "Resources.Strings.JobCaption"},
					"enabled": {"bindTo": "SourceDataEditable"},
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					},
					"contentType": BPMSoft.ContentType.ENUM
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"name": "Email",
				"values": {
					"markerValue": {"bindTo": "Resources.Strings.EmailCaption"},
					"enabled": {"bindTo": "SourceDataEditable"},
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"name": "Account",
				"values": {
					"enabled": {"bindTo": "SourceDataEditable"},
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"name": "EmployeesNumber",
				"values": {
					"enabled": {"bindTo": "SourceDataEditable"},
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"name": "Country",
				"values": {
					"markerValue": {"bindTo": "Resources.Strings.CountryCaption"},
					"enabled": {"bindTo": "SourceDataEditable"},
					"layout": {
						"column": 13,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"name": "Website",
				"values": {
					"enabled": {"bindTo": "SourceDataEditable"},
					"layout": {
						"column": 13,
						"row": 3,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "LeadPageRegisterInfo",
				"propertyName": "items",
				"name": "LeadProduct",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
		],/**SCHEMA_DIFF*/
		modules: /**SCHEMA_MODULES*/{
			ActionsDashboardModule: {
				"config": {
					"isSchemaConfigInitialized": true,
					"schemaName": "LeadSectionActionsDashboard",
					"useHistoryState": false,
					"parameters": {
						"viewModelConfig": {
							"entitySchemaName": "Lead",
							"actionsConfig": {
								"schemaName": "QualifyStatus",
								"columnName": "QualifyStatus",
								"colorColumnName": "Color",
								"filterColumnName": "IsDisplayed",
								"orderColumnName": "StageOrder",
								"innerOrderColumnName": "StageInnerOrder",
								"decouplingConfig": {
									"name": "QualifyStatusDecoupling",
									"masterColumnName": "CurrentStatus",
									"referenceColumnName": "AvailableStatus"
								}
							},
							"dashboardConfig": {
								"Activity": {
									"masterColumnName": "Id",
									"referenceColumnName": "Lead"
								}
							}
						}
					}
				}
			}
		}, /**SCHEMA_MODULES*/
		rules: {
			"LeadType": {
				"LeadTypeRequired": {
					"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					"property": BusinessRuleModule.enums.Property.REQUIRED,
					"conditions": [
						{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"dataValueType": BPMSoft.DataValueType.BOOLEAN,
								"value": true
							},
							"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"dataValueType": BPMSoft.DataValueType.BOOLEAN,
								"value": true
							}
						}
					]
				}
			},
			"Contact": {
				"EnabledContact": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.ENABLED,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "SourceDataEditable"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			},
			"Account": {
				"EnabledAccount": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.ENABLED,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "SourceDataEditable"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			},
			"MobilePhone": {
				"EnabledMobilePhone": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.ENABLED,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "SourceDataEditable"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			},
			"Email": {
				"EnabledEmail": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.ENABLED,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "SourceDataEditable"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			},
			"EmployeesNumber": {
				"EnabledEmployeesNumber": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.ENABLED,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "SourceDataEditable"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			},
			"Country": {
				"EnabledCountry": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.ENABLED,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "SourceDataEditable"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			},
			"Website": {
				"EnabledWebsite": {
					ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
					property: BusinessRuleModule.enums.Property.ENABLED,
					conditions: [{
						leftExpression: {
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "SourceDataEditable"
						},
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						rightExpression: {
							type: BusinessRuleModule.enums.ValueType.CONSTANT,
							value: true
						}
					}]
				}
			}
		}
	};
});
