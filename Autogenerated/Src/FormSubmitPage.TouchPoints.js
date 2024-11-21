define("FormSubmitPage", [], function() {
	return {
		entitySchemaName: "FormSubmit",
		attributes: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Contact",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Contact"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "WebForma",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "WebForm"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "RegisterMethodfbeab4ab-a91e-4149-a19c-1e16b05da94a",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "RegisterMethod"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Channel96534683-2239-4f20-8ddd-aca67b55adc4",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Channel"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Source97e426b8-4d2a-4a19-85b5-6012abafc883",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Source"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ContactDetailsTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.ContactDetailsTabTabCaption"
					},
					"items": [],
					"order": 0
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ContactDetailsTabGroup",
				"values": {
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "ContactDetailsTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ContactDetailsTabGridLayoutaf097a2a",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "ContactDetailsTabGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FullName",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ContactDetailsTabGridLayoutaf097a2a"
					},
					"bindTo": "FullName"
				},
				"parentName": "ContactDetailsTabGridLayoutaf097a2a",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "FirstName",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ContactDetailsTabGridLayoutaf097a2a"
					},
					"bindTo": "FirstName"
				},
				"parentName": "ContactDetailsTabGridLayoutaf097a2a",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LastNamea",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "ContactDetailsTabGridLayoutaf097a2a"
					},
					"bindTo": "LastName"
				},
				"parentName": "ContactDetailsTabGridLayoutaf097a2a",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "BirthDate",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ContactDetailsTabGridLayoutaf097a2a"
					},
					"bindTo": "BirthDate"
				},
				"parentName": "ContactDetailsTabGridLayoutaf097a2a",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Gender",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 2,
						"layoutName": "ContactDetailsTabGridLayoutaf097a2a"
					},
					"bindTo": "Gender",
					"enabled": true,
					"contentType": 3
				},
				"parentName": "ContactDetailsTabGridLayoutaf097a2a",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "CommunicationOptionsGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.CommunicationOptionsGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "ContactDetailsTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ContactDetailsTabGridLayout85dda6f7",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "CommunicationOptionsGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Email2aba0f5e-e506-4068-9748-1de29842b563",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ContactDetailsTabGridLayout85dda6f7"
					},
					"bindTo": "Email"
				},
				"parentName": "ContactDetailsTabGridLayout85dda6f7",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "PhoneNumberf8f86d16-86c3-4fa7-89f1-1c916f481e01",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "ContactDetailsTabGridLayout85dda6f7"
					},
					"bindTo": "PhoneNumber"
				},
				"parentName": "ContactDetailsTabGridLayout85dda6f7",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LocationDetailsGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.LocationDetailsGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "ContactDetailsTab",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ContactDetailsTabGridLayout5895e7f0",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "LocationDetailsGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CountryStr358d4d4c-4b90-441a-9837-f1b962646faa",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ContactDetailsTabGridLayout5895e7f0"
					},
					"bindTo": "CountryStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.CountryStr358d4d4c4b90441a9837f1b962646faaLabelCaption"
						}
					}
				},
				"parentName": "ContactDetailsTabGridLayout5895e7f0",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Territory8bd0a2ab-f8b7-4710-b317-407b9e57caa3",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "ContactDetailsTabGridLayout5895e7f0"
					},
					"bindTo": "Territory"
				},
				"parentName": "ContactDetailsTabGridLayout5895e7f0",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CityStr154a5076-0903-4900-b7fb-9ca2b2aaaa72",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ContactDetailsTabGridLayout5895e7f0"
					},
					"bindTo": "CityStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.CityStr154a507609034900b7fb9ca2b2aaaa72LabelCaption"
						}
					}
				},
				"parentName": "ContactDetailsTabGridLayout5895e7f0",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "TimeZone0a39adb3-04c8-4ca6-9fe7-879a545ac134",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "ContactDetailsTabGridLayout5895e7f0"
					},
					"bindTo": "TimeZone"
				},
				"parentName": "ContactDetailsTabGridLayout5895e7f0",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "MarketingDetailsGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.MarketingDetailsGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "ContactDetailsTab",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ContactDetailsTabGridLayout4f81e02d",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "MarketingDetailsGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UtmMediumStr736abadb-2b9f-489e-bc85-04451aa7df93",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "ContactDetailsTabGridLayout4f81e02d"
					},
					"bindTo": "UtmMediumStr"
				},
				"parentName": "ContactDetailsTabGridLayout4f81e02d",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Referrer7ac95143-3b3b-43d1-bf7d-9f59445bc97d",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "ContactDetailsTabGridLayout4f81e02d"
					},
					"bindTo": "Referrer"
				},
				"parentName": "ContactDetailsTabGridLayout4f81e02d",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UtmSourceStr40154c8c-94a3-4dc8-ace3-845382473d1b",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ContactDetailsTabGridLayout4f81e02d"
					},
					"bindTo": "UtmSourceStr"
				},
				"parentName": "ContactDetailsTabGridLayout4f81e02d",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "UtmCampaignStrdb4c5d2d-8e48-4b62-b9f4-2f5362c44a09",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ContactDetailsTabGridLayout4f81e02d"
					},
					"bindTo": "UtmCampaignStr"
				},
				"parentName": "ContactDetailsTabGridLayout4f81e02d",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "JobDetailsTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.JobDetailsTabTabCaption"
					},
					"items": [],
					"order": 1
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "JobDetailsTabGroup",
				"values": {
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "JobDetailsTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "JobDetailsTabGridLayoutf145c46f",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "JobDetailsTabGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Account",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "JobDetailsTabGridLayoutf145c46f"
					},
					"bindTo": "Account"
				},
				"parentName": "JobDetailsTabGridLayoutf145c46f",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AccountIndustryStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "JobDetailsTabGridLayoutf145c46f"
					},
					"bindTo": "AccountIndustryStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.AccountIndustryStrLabelCaption"
						}
					}
				},
				"parentName": "JobDetailsTabGridLayoutf145c46f",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "JobTitle",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "JobDetailsTabGridLayoutf145c46f"
					},
					"bindTo": "JobTitle"
				},
				"parentName": "JobDetailsTabGridLayoutf145c46f",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "AccountEmployeesNumberStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "JobDetailsTabGridLayoutf145c46f"
					},
					"bindTo": "AccountEmployeesNumberStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.AccountEmployeesNumberStrLabelCaption"
						}
					}
				},
				"parentName": "JobDetailsTabGridLayoutf145c46f",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ContactDecisionRoleStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "JobDetailsTabGridLayoutf145c46f"
					},
					"bindTo": "ContactDecisionRoleStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.ContactDecisionRoleStrLabelCaption"
						}
					}
				},
				"parentName": "JobDetailsTabGridLayoutf145c46f",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "WorkEmail",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "JobDetailsTabGridLayoutf145c46f"
					},
					"bindTo": "WorkEmail"
				},
				"parentName": "JobDetailsTabGridLayoutf145c46f",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "Website",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 3,
						"layoutName": "JobDetailsTabGridLayoutf145c46f"
					},
					"bindTo": "Website"
				},
				"parentName": "JobDetailsTabGridLayoutf145c46f",
				"propertyName": "items",
				"index": 6
			}
		]/**SCHEMA_DIFF*/
	};
});
