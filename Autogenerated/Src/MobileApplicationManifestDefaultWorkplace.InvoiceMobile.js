{
	"SyncOptions": {
		"SysLookupsImportConfig": [
			"InvoicePaymentStatus",
			"Currency"
		],
		"ModelDataImportConfig": [
			{
				"Name": "Invoice",
				"SyncColumns": [
					"Number",
					"Account",
					"Owner",
					"PaymentStatus",
					"PrimaryAmount",
					"Currency",
					"Amount",
					"DueDate",
					"PaymentAmount"
				]
			},
			{
				"Name": "Account",
				"SyncColumns": []
			},
			{
				"Name": "Contact",
				"SyncColumns": []
			},
			{
				"Name": "InvoicePaymentStatus",
				"SyncColumns": []
			},
			{
				"Name": "Currency",
				"SyncColumns": []
			},
			{
				"Name": "SocialMessage",
				"SyncColumns": [
					"EntityId"
				]
			},
			{
				"Name": "InvoiceVisa",
				"SyncColumns": [
					"Objective",
					"VisaOwner",
					"Status",
					"IsCanceled",
					"Invoice"
				],
				"QueryFilter": {
					"filterType": 6,
					"isEnabled": true,
					"logicalOperation": 0,
					"items": {
						"CurrentUser": {
							"comparisonType": 15,
							"filterType": 5,
							"isEnabled": true,
							"leftExpression": {
								"columnPath": "[SysAdminUnitInRole:SysAdminUnitRoleId:VisaOwner].Id",
								"expressionType": 0
							},
							"subFilters": {
								"filterType": 6,
								"isEnabled": true,
								"items": {
									"detailedFilter": {
										"comparisonType": 3,
										"filterType": 1,
										"isEnabled": true,
										"leftExpression": {
											"columnPath": "SysAdminUnit",
											"expressionType": 0
										},
										"rightExpression": {
											"expressionType": 1,
											"functionType": 1,
											"macrosType": 1
										},
										"trimDateTimeParameterToDate": false
									}
								},
								"logicalOperation": 0,
								"rootSchemaName": "SysAdminUnitInRole"
							},
							"trimDateTimeParameterToDate": false
						},
						"StatusNotFinal": {
							"filterType": 6,
							"isEnabled": true,
							"items": {
								"item0": {
									"comparisonType": 1,
									"filterType": 2,
									"isEnabled": true,
									"isNull": true,
									"leftExpression": {
										"columnPath": "Status",
										"expressionType": 0
									},
									"trimDateTimeParameterToDate": false
								},
								"item1": {
									"comparisonType": 3,
									"filterType": 1,
									"isEnabled": true,
									"leftExpression": {
										"columnPath": "Status.IsFinal",
										"expressionType": 0
									},
									"rightExpression": {
										"expressionType": 2,
										"parameter": {
											"dataValueType": 12,
											"value": false
										}
									},
									"trimDateTimeParameterToDate": false
								}
							},
							"logicalOperation": 1
						},
						"IsNotCanceled": {
							"comparisonType": 3,
							"filterType": 1,
							"isEnabled": true,
							"leftExpression": {
								"columnPath": "IsCanceled",
								"expressionType": 0
							},
							"rightExpression": {
								"expressionType": 2,
								"parameter": {
									"dataValueType": 12,
									"value": false
								}
							},
							"trimDateTimeParameterToDate": false
						}
					}
				}
			},
			{
				"Name": "SysAdminUnit",
				"SyncColumns": []
			}
		]
	},
	"Modules": {
		"Invoice": {
			"Group": "main",
			"Model": "Invoice",
			"Position": 6,
			"Hidden": false
		}
	},
	"Models": {
		"Invoice": {
			"RequiredModels": [
				"Invoice",
				"InvoicePaymentStatus",
				"Account",
				"Contact",
				"Currency",
				"SocialMessage",
				"InvoiceVisa",
				"SysAdminUnit",
				"VisaStatus"
			],
			"ModelExtensions": [],
			"PagesExtensions": [
				"MobileInvoiceActionsSettingsDefaultWorkplace",
				"MobileInvoiceGridPageSettingsDefaultWorkplace",
				"MobileInvoiceRecordPageSettingsDefaultWorkplace"
			]
		},
		"SocialMessage": {
			"RequiredModels": [],
			"ModelExtensions": [],
			"PagesExtensions": []
		}
	}
}