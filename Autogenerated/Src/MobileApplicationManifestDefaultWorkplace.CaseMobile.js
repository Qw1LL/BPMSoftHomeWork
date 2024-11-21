{
	"CustomSchemas": [
		"MobileCaseCss",
		"MobileCaseUtilities"
	],
	"SyncOptions": {
		"SysSettingsImportConfig": [
			"CaseStatusDef",
			"CasePriorityDef",
			"CaseOriginDef",
			"CaseServiceLevelDef",
			"MobileDefaultCaseOrigin"
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
					"Group"
				],
				"SyncFilter": {
					"type": "BPMSoft.FilterTypes.Group",
					"logicalOperation": "BPMSoft.FilterLogicalOperations.And",
					"subfilters": [
						{
							"compareType": "BPMSoft.ComparisonTypes.GreaterOrEqual",
							"property": "RegisteredOn",
							"valueIsMacros": true,
							"value": "BPMSoft.ValueMacros.CurrentDate",
							"macrosParams": {
								"datePart": "d",
								"value": -30
							}
						},
						{
							"type": "BPMSoft.FilterTypes.Group",
							"logicalOperation": "BPMSoft.FilterLogicalOperations.Or",
							"subfilters": [
								{
									"property": "Owner",
									"compareType": "BPMSoft.ComparisonTypes.Equal",
									"valueIsMacros": true,
									"value": "BPMSoft.ValueMacros.CurrentUserContact"
								},
								{
									"property": "Owner",
									"compareType": "BPMSoft.ComparisonTypes.NotEqual",
									"isNot": true,
									"value": null
								}
							]
						},
						{
							"type": "BPMSoft.FilterTypes.Group",
							"logicalOperation": "BPMSoft.FilterLogicalOperations.Or",
							"subfilters": [
								{
									"compareType": "BPMSoft.ComparisonTypes.GreaterOrEqual",
									"property": "RegisteredOn",
									"valueIsMacros": true,
									"value": "BPMSoft.ValueMacros.CurrentDate",
									"macrosParams": {
										"datePart": "d",
										"value": -7
									}
								},
								{
									"property": "Status.IsFinal",
									"value": false
								}
							]
						}
					]
				},
				"QueryFilter": {
					"logicalOperation": 0,
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
						"OwnerFilter": {
							"logicalOperation": 1,
							"filterType": 6,
							"rootSchemaName": "Case",
							"items": {
								"OwnerCurrentUser": {
									"filterType": 1,
									"rightExpression": {
										"expressionType": 1,
										"functionType": 1,
										"macrosType": 2
									},
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "Owner"
									},
									"comparisonType": 3
								},
								"OwnerEmpty": {
									"filterType": 2,
									"isNull": true,
									"leftExpression": {
										"expressionType": 0,
										"columnPath": "Owner"
									}
								}
							}
						},
						"ActualStateFilter": {
							"logicalOperation": 1,
							"filterType": 6,
							"rootSchemaName": "Case",
							"items": {
								"RegistredOnPrevious7Days": {
									"filterType": 1,
									"rightExpression": {
										"expressionType": 1,
										"functionType": 1,
										"macrosType": 25,
										"functionArgument": {
											"expressionType": 2,
											"parameter": {
												"dataValueType": 4,
												"value": 7
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
					"Data",
					"Size"
				]
			},
			{
				"Name": "VwMobileCaseMessageHistory",
				"SyncByParentObjectWithRights": "Case",
				"SyncColumns": [
					"OwnerName",
					"OwnerPhoto",
					"Message",
					"MessageNotifier",
					"RecordId",
					"HasAttachment",
					"Case",
					"Id",
					"Recepient"
				]
			},
			{
				"Name": "MessageNotifier",
				"SyncColumns": [
					"Name",
					"Description"
				]
			},
			{
				"Name": "Activity",
				"SyncColumns": [
					"Case"
				]
			},
			{
				"Name": "CaseCategory",
				"SyncColumns": []
			}
		]
	},
	"Modules": {
		"Case": {
			"Group": "main",
			"Model": "Case",
			"Position": 3,
			"Title": "CaseSectionTitle",
			"Hidden": false
		}
	},
	"Models": {
		"Case": {
			"Grid": "MobileCaseGridPage",
			"Preview": "MobileCasePreviewPage",
			"Edit": "MobileCaseEditPage",
			"CacheConfig": {
				"AssociatedModels": [
					"VwMobileCaseMessageHistory"
				]
			},
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
				"VwMobileCaseMessageHistory",
				"Activity",
				"CaseCategory"
			],
			"ModelExtensions": [],
			"PagesExtensions": [
				"MobileCaseActionsSettingsDefaultWorkplace",
				"MobileCaseGridPageSettingsDefaultWorkplace",
				"MobileCaseRecordPageSettingsDefaultWorkplace",
				"MobileCaseModuleConfig",
				"MobileCaseModelConfig",
				"MobileCaseGridPageView",
				"MobileCaseGridPageController",
				"MobileCasePreviewPageView",
				"MobileCasePreviewPageController",
				"MobileCaseEditPageView",
				"MobileCaseEditPageController"
			]
		},
		"VwMobileCaseMessageHistory": {
			"Grid": "MobileCaseMessageHistoryGridPage",
			"Preview": "MobileCaseMessageHistoryPreviewPage",
			"RequiredModels": [
				"Case",
				"MessageNotifier",
				"VwMobileCaseMessageHistory"
			],
			"ModelExtensions": [],
			"PagesExtensions": [
				"MobileCaseMessageHistoryActionsSettingsDefaultWorkplace",
				"MobileCaseMessageHistoryGridPageSettingsDefaultWorkplace",
				"MobileCaseMessageHistoryRecordPageSettingsDefaultWorkplace",
				"MobileCaseMessageHistoryModuleConfig",
				"MobileCaseMessageHistoryGridPageView",
				"MobileCaseMessageHistoryGridPageController"
			]
		}
	}
}