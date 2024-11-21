{
	"CustomSchemas": [
		"MobileLookupGridOpportunityPageConfig",
		"MobileOpportunityUtilities"
	],
	"SyncOptions": {
		"SysSettingsImportConfig": [],
		"ModelDataImportConfig": [
			{
				"Name": "Account",
				"SyncColumns": []
			},
			{
				"Name": "Opportunity",
				"SyncFilter": {
					"property": "Owner",
					"valueIsMacros": true,
					"value": "BPMSoft.ValueMacros.CurrentUserContact"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "Opportunity",
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
						}
					}
				},
				"SyncColumns": [
					"Title",
					"Type",
					"Stage",
					"Account",
					"Amount",
					"Probability",
					"Budget",
					"Owner",
					"Contact",
					"Mood",
					"DueDate",
					"LeadType"
				]
			},
			{
				"Name": "OpportunityType",
				"SyncColumns": []
			},
			{
				"Name": "OpportunityStage",
				"SyncColumns": [
					"End",
					"MaxProbability",
					"Number"
				]
			},
			{
				"Name": "Activity",
				"SyncColumns": [
					"Opportunity"
				]
			},
			{
				"Name": "OpportunityContact",
				"SyncByParentObjectWithRights": "Opportunity",
				"SyncFilter": {
					"property": "Opportunity.Owner",
					"valueIsMacros": true,
					"value": "BPMSoft.ValueMacros.CurrentUserContact"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "OpportunityContact",
					"items": {
						"OpportunityOwnerCurrentUser": {
							"filterType": 1,
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
							},
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Opportunity.Owner"
							},
							"comparisonType": 3
						}
					}
				},
				"SyncColumns": [
					"Opportunity",
					"Contact",
					"IsMainContact",
					"Role",
					"Influence",
					"ContactMotivator",
					"ContactLoyality"
				]
			},
			{
				"Name": "Contact",
				"SyncColumns": []
			},
			{
				"Name": "OppContactRole",
				"SyncColumns": []
			},
			{
				"Name": "OppContactInfluence",
				"SyncColumns": []
			},
			{
				"Name": "OppContactLoyality",
				"SyncColumns": [
					"Position"
				]
			},
			{
				"Name": "OpportunityProductInterest",
				"SyncByParentObjectWithRights": "Opportunity",
				"SyncColumns": [
					"Opportunity",
					"Product",
					"OfferResult",
					"Quantity",
					"OfferDate",
					"Comment"
				]
			},
			{
				"Name": "Product",
				"SyncColumns": []
			},
			{
				"Name": "PropositionResult",
				"SyncColumns": []
			},
			{
				"Name": "FileType",
				"SyncColumns": []
			},
			{
				"Name": "OpportunityFile",
				"SyncByParentObjectWithRights": "Opportunity",
				"SyncColumns": [
					"Opportunity",
					"Type",
					"Data",
					"Size",
					"Name"
				],
				"SyncFilter": {
					"property": "Opportunity.Owner",
					"valueIsMacros": true,
					"value": "BPMSoft.ValueMacros.CurrentUserContact"
				},
				"QueryFilter": {
					"logicalOperation": 0,
					"filterType": 6,
					"rootSchemaName": "OpportunityFile",
					"items": {
						"OpportunityOwnerCurrentUser": {
							"filterType": 1,
							"rightExpression": {
								"expressionType": 1,
								"functionType": 1,
								"macrosType": 2
							},
							"leftExpression": {
								"expressionType": 0,
								"columnPath": "Opportunity.Owner"
							},
							"comparisonType": 3
						}
					}
				}
			},
			{
				"Name": "OpportunityOfferResult",
				"SyncColumns": []
			},
			{
				"Name": "OpportunityProbability",
				"SyncColumns": []
			},
			{
				"Name": "ActivityPriority",
				"SyncColumns": []
			},
			{
				"Name": "ActivityType",
				"SyncColumns": []
			},
			{
				"Name": "ActivityCategory",
				"SyncColumns": []
			},
			{
				"Name": "ActivityStatus",
				"SyncColumns": [
					"Finish"
				]
			},
			{
				"Name": "ActivityParticipant",
				"SyncColumns": [
					"Activity",
					"Participant"
				]
			},
			{
				"Name": "ActivityParticipantRole",
				"SyncColumns": []
			},
			{
				"Name": "AccountCommunication",
				"SyncColumns": []
			},
			{
				"Name": "CommunicationType",
				"SyncColumns": []
			},
			{
				"Name": "AccountAddress",
				"SyncColumns": []
			},
			{
				"Name": "AddressType",
				"SyncColumns": []
			},
			{
				"Name": "Country",
				"SyncColumns": []
			},
			{
				"Name": "Region",
				"SyncColumns": []
			},
			{
				"Name": "City",
				"SyncColumns": []
			},
			{
				"Name": "AccountAnniversary",
				"SyncColumns": []
			},
			{
				"Name": "AnniversaryType",
				"SyncColumns": []
			},
			{
				"Name": "OpportunityMood",
				"SyncColumns": []
			},
			{
				"Name": "LeadType",
				"SyncColumns": []
			}
		]
	},
	"Modules": {
		"Opportunity": {
			"Position": 5,
			"Hidden": false
		}
	},
	"Models": {
		"Account": {
			"PagesExtensions": [
				"MobileAccountRecordPageSettingsDefaultWorkplace"
			]
		},
		"Activity": {
			"ModelExtensions": [
				"MobileActivityOpportunityModelConfig"
			],
			"PagesExtensions": [
				"MobileActivityRecordPageSettingsDefaultWorkplace",
				"MobileActivityOpportunityModuleConfig"
			]
		},
		"Opportunity": {
			"Preview": "MobileOpportunityPreviewPage",
			"Edit": "MobileOpportunityEditPage",
			"ModelExtensions": [
				"MobileOpportunityModelConfig"
			],
			"PagesExtensions": [
				"MobileOpportunityRecordPageSettingsDefaultWorkplace",
				"MobileOpportunityGridPageSettingsDefaultWorkplace",
				"MobileOpportunityActionsSettingsDefaultWorkplace",
				"MobileOpportunityModuleConfig"
			],
			"RequiredModels": [
				"Opportunity",
				"Account",
				"Contact",
				"OpportunityStage",
				"OpportunityMood",
				"OpportunityType",
				"LeadType",
				"OpportunityContact",
				"OppContactRole",
				"OppContactInfluence",
				"OppContactLoyality",
				"OpportunityProductInterest",
				"Product",
				"PropositionResult",
				"OpportunityFile"
			]
		},
		"OpportunityContact": {
			"ModelExtensions": [
				"MobileOpportunityContactModelConfig"
			],
			"RequiredModels": [
				"OpportunityContact",
				"Opportunity",
				"Contact",
				"OpportunityType",
				"OpportunityStage",
				"OpportunityProbability"
			]
		},
		"OpportunityProductInterest": {
			"ModelExtensions": [
				"MobileOpportunityProductInterestModelConfig"
			]
		},
		"SysDashboard": {
			"PagesExtensions": [
				"MobileDashboardPageConfig"
			]
		}
	}
}