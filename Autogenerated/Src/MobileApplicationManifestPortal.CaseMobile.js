{
	"onboardingName": "Portal",
	"SyncOptions": {
		"SysLookupsImportConfig": [
			"CaseStatus",
			"CasePriority",
			"MessageNotifier",
			"CaseCategory",
			"CaseStatusDef",
			"CasePriorityDef",
			"CaseOriginDef",
			"CaseServiceLevelDef",
			"MobileDefaultCaseOrigin"
		],
		"SysSettingsImportConfig": [
			"CaseStatusDef",
			"CasePriorityDef",
			"CaseOriginDef",
			"CaseServiceLevelDef"
		],
		"ModelDataImportConfig": [
			{
				"Name": "Case",
				"ExpandLookups": true,
				"SyncColumns": [
					"Number",
					"RegisteredOn",
					"Subject",
					"Status",
					"Symptoms",
					"Owner",
					"Priority",
					"Account",
					"Contact",
					"Category",
					"SolutionDate",
					"ResponseDate"
				],
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "Case",
					"items": {
						"ActualStateFilter": {
							"logicalOperation": 1,
							"filterType": 6,
							"rootSchemaName": "Case",
							"items": {
								"RegistredOnPrevious30Days": {
									"filterType": 1,
									"rightExpression": {
										"expressionType": 1,
										"functionType": 1,
										"macrosType": 25,
										"functionArgument": {
											"expressionType": 2,
											"parameter": {
												"dataValueType": 4,
												"value": 30
											}
										}
									},
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "RegisteredOn"
									},
									"comparisonType": 8,
									"trimDateTimeParameterToDate": true
								},
								"StatusNotFinal": {
									"filterType": 1,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 12,
											"value": false
										}
									},
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "Status.IsFinal"
									},
									"comparisonType": 3
								}
							}
						}
					}
				}
			},
			{
				"Name": "CaseStatus",
				"SyncColumns": [
					"Name",
					"IsFinal"
				]
			},
			{
				"Name": "MessageNotifier",
				"SyncColumns": []
			},
			{
				"Name": "CasePriority",
				"SyncColumns": []
			},
			{
				"Name": "CaseOrigin",
				"SyncColumns": []
			},
			{
				"Name": "CaseFile",
				"SyncByParentObjectWithRights": "Case",
				"SyncColumns": [
					"Case",
					"Type",
					"Name",
					"Data",
					"Size"
				]
			},
			{
				"Name": "CaseCategory",
				"SyncColumns": []
			},
			{
				"Name": "CaseMessageHistory",
				"SyncColumns": [
					"CreatedOn",
					"CreatedBy",
					"Message",
					"Case",
					"RecordId",
					"MessageNotifier",
					"Id"
				],
				"QueryFilter": {
					"filterType": 6,
					"isEnabled": true,
					"logicalOperation": 0,
					"items": {
						"CaseIdNotNullFilter": {
							"comparisonType": 2,
							"filterType": 2,
							"isEnabled": true,
							"isNull": false,
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Id"
							},
							"columnPath": "Id",
							"expressionType": 0
						},
						"HistoryV2ClassNameFilter": {
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "MessageNotifier.HistoryV2ClassName"
							},
							"comparisonType": 2,
							"isEnabled": true,
							"trimDateTimeParameterToDate": false,
							"filterType": 2,
							"isNull": false
						},
						"MessageNotifierFilter": {
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "MessageNotifier"
							},
							"comparisonType": 4,
							"isEnabled": true,
							"trimDateTimeParameterToDate": false,
							"filterType": 1,
							"rightExpression": {
								"expressionType": 2,
								"parameter": {
									"dataValueType": 1,
									"value": "ed501edb-8ebf-4c76-a35d-6f23be243043"
								}
							}
						},
						"MessageNotifierBySectionFilter": {
							"filterType": 6,
							"isEnabled": true,
							"logicalOperation": 1,
							"items": {
								"fb98b21c-0e00-4286-ba82-bf352f9590ea": {
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "[MessageNotifierBySection:MessageNotifier:MessageNotifier].Section"
									},
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"filterType": 1,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 1,
											"value": "302a835d-fb19-4335-a9a4-ef9cd7df6006"
										}
									}
								},
								"512a5598-0c5e-48da-8375-6d39cc1dd442": {
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "[MessageNotifier:AliasNotifier:MessageNotifier].[MessageNotifierBySection:MessageNotifier:Id].Section"
									},
									"comparisonType": 3,
									"isEnabled": true,
									"trimDateTimeParameterToDate": false,
									"filterType": 1,
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 1,
											"value": "302a835d-fb19-4335-a9a4-ef9cd7df6006"
										}
									}
								}
							}
						}
					}
				}
			},
			{
				"Name": "FileType",
				"SyncColumns": []
			}
		]
	},
	"Modules": {
		"Case": {
			"Group": "main",
			"Model": "Case",
			"Position": 0,
			"Title": "CaseSectionTitle",
			"Hidden": false,
			"Icon": {
				"ImageId": "MobileImageListTreatmentModuleImage"
			},
			"IconV2": {
				"ImageId": "MobileImageListTreatmentModuleImageV2"
			},
			"screens": {
				"start": {
					"schemaName": "MobileCaseGridPageSettingsPortal"
				},
				"edit": {
					"schemaName": "MobileCaseRecordPageSettingsPortal"
				},
				"add": {
					"schemaName": "MobileCaseMiniPagePortal"
				}
			}
		}
	},
	"Models": {
		"Case": {
			"RequiredModels": [
				"Case",
				"CaseStatus",
				"CasePriority",
				"CaseOrigin",
				"SocialMessage",
				"Contact",
				"Account",
				"CaseFile",
				"FileType",
				"KnowledgeBase",
				"KnowledgeBaseFile",
				"Activity",
				"CaseCategory",
				"CaseMessageHistory",
				"PortalMessage",
				"PortalMessageFile",
				"ActivityFile",
				"MessageNotifier"
			],
			"ModelExtensions": [],
			"PagesExtensions": [
				"MobileCaseRecordPageSettingsPortal",
				"MobileCaseGridPageSettingsPortal",
				"MobileCaseMiniPagePortal"
			]
		},
		"SocialMessage": {
			"RequiredModels": [],
			"ModelExtensions": [],
			"PagesExtensions": []
		},
		"CaseMessageHistory": {
			"RequiredModels": [],
			"ModelExtensions": [],
			"PagesExtensions": []
		}
	}
}