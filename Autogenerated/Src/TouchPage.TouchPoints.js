define("TouchPage", [], function() {
	return {
		entitySchemaName: "Touch",
		attributes: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"TouchPageActionDetail": {
				"schemaName": "TouchActionDetail",
				"entitySchemaName": "TouchAction",
				"filter": {
					"detailColumn": "Touch",
					"masterColumn": "Id"
				}
			}
		}/**SCHEMA_DETAILS*/,
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
				"name": "Channel7c939708-e804-4b27-aa01-ed8d15681932",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Channel"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Source9ed8dc2d-94fd-4af8-a7fc-d89b50a784dc",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Source"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "PageReferrer",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "PageReferrer"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "StartDate7a5612f7-50e2-4532-bc05-3f253ecf394b",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "StartDate"
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "Durationd",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 5,
						"layoutName": "ProfileContainer"
					},
					"bindTo": "Duration",
					"enabled": true
				},
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "SessionDetailsTabLabel",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.SessionDetailsTabLabelTabCaption"
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
				"name": "LocationDetailsGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.LocationDetailsGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "SessionDetailsTabLabel",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "SessionDetailsTabLabelGridLayoute76e6457",
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
				"name": "CountryStrf9566d7f-71f4-4a25-9765-fdfebb44e9df",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "SessionDetailsTabLabelGridLayoute76e6457"
					},
					"bindTo": "CountryStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.CountryStrf9566d7f71f44a259765fdfebb44e9dfLabelCaption"
						}
					}
				},
				"parentName": "SessionDetailsTabLabelGridLayoute76e6457",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "RegionStra806941a-309e-412e-85ac-4e44eb66e781",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "SessionDetailsTabLabelGridLayoute76e6457"
					},
					"bindTo": "RegionStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.RegionStra806941a309e412e85ac4e44eb66e781LabelCaption"
						}
					}
				},
				"parentName": "SessionDetailsTabLabelGridLayoute76e6457",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "CityStr836ea796-4f4d-440c-aa93-a80be0198e00",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "SessionDetailsTabLabelGridLayoute76e6457"
					},
					"bindTo": "CityStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.CityStr836ea7964f4d440caa93a80be0198e00LabelCaption"
						}
					}
				},
				"parentName": "SessionDetailsTabLabelGridLayoute76e6457",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Locationff545b56-5de3-4363-ad7c-d5e481827141",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "SessionDetailsTabLabelGridLayoute76e6457"
					},
					"bindTo": "Location"
				},
				"parentName": "SessionDetailsTabLabelGridLayoute76e6457",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Languagee46983d6-db3c-4c06-a749-c423cb61ed43",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "SessionDetailsTabLabelGridLayoute76e6457"
					},
					"bindTo": "Language"
				},
				"parentName": "SessionDetailsTabLabelGridLayoute76e6457",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ReferrerDetailsGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.ReferrerDetailsGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "SessionDetailsTabLabel",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SessionDetailsTabLabelGridLayout63a8e465",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "ReferrerDetailsGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ReferrerTypeStr6ccf2f5f-d67c-4f49-a616-7f34bc499b71",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "SessionDetailsTabLabelGridLayout63a8e465"
					},
					"bindTo": "ReferrerTypeStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.ReferrerTypeStr6ccf2f5fd67c4f49a6167f34bc499b71LabelCaption"
						}
					}
				},
				"parentName": "SessionDetailsTabLabelGridLayout63a8e465",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ReferrerNameStrc981d6d3-3760-4f55-9552-3ddd9dc7db7b",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "SessionDetailsTabLabelGridLayout63a8e465"
					},
					"bindTo": "ReferrerNameStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.ReferrerNameStrc981d6d337604f5595523ddd9dc7db7bLabelCaption"
						}
					}
				},
				"parentName": "SessionDetailsTabLabelGridLayout63a8e465",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ReferrerKeyword56423972-a03e-4440-93e1-e4fc0bd7aed5",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "SessionDetailsTabLabelGridLayout63a8e465"
					},
					"bindTo": "ReferrerKeyword"
				},
				"parentName": "SessionDetailsTabLabelGridLayout63a8e465",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ReferrerUrl40d7ad58-dad3-4aff-8dc7-76399acbdfe7",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "SessionDetailsTabLabelGridLayout63a8e465"
					},
					"bindTo": "ReferrerUrl"
				},
				"parentName": "SessionDetailsTabLabelGridLayout63a8e465",
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
				"parentName": "SessionDetailsTabLabel",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "SessionDetailsTabLabelGridLayout0060b6cc",
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
				"name": "UtmIdStr357f0832-b0b0-46eb-978c-de21f22be9a8",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "SessionDetailsTabLabelGridLayout0060b6cc"
					},
					"bindTo": "UtmIdStr"
				},
				"parentName": "SessionDetailsTabLabelGridLayout0060b6cc",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "UtmMediumStr207c9800-ccc9-48ee-8f44-e61ac623c3b7",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "SessionDetailsTabLabelGridLayout0060b6cc"
					},
					"bindTo": "UtmMediumStr"
				},
				"parentName": "SessionDetailsTabLabelGridLayout0060b6cc",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "UtmContentStrdb2644ab-a177-4f3e-8b21-94fc1a08ee7f",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "SessionDetailsTabLabelGridLayout0060b6cc"
					},
					"bindTo": "UtmContentStr"
				},
				"parentName": "SessionDetailsTabLabelGridLayout0060b6cc",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "UtmSourceStr2a5099ef-e2f8-423d-834b-cdcf1079feef",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "SessionDetailsTabLabelGridLayout0060b6cc"
					},
					"bindTo": "UtmSourceStr"
				},
				"parentName": "SessionDetailsTabLabelGridLayout0060b6cc",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "UtmTermStr6b56590f-32da-49ee-a9a6-2209cee6f095",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "SessionDetailsTabLabelGridLayout0060b6cc"
					},
					"bindTo": "UtmTermStr"
				},
				"parentName": "SessionDetailsTabLabelGridLayout0060b6cc",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "UtmCampaignStr993ea4cf-0223-41b2-a516-9a03649cc837",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 2,
						"layoutName": "SessionDetailsTabLabelGridLayout0060b6cc"
					},
					"bindTo": "UtmCampaignStr"
				},
				"parentName": "SessionDetailsTabLabelGridLayout0060b6cc",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "AdditionalDetailsGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.AdditionalDetailsGroupGroupCaption"
					},
					"itemType": 15,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "SessionDetailsTabLabel",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "SessionDetailsTabLabelGridLayout0b1745c5",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "AdditionalDetailsGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "PlatformStrf5abb822-5a42-414f-b572-f0fa14564546",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "SessionDetailsTabLabelGridLayout0b1745c5"
					},
					"bindTo": "PlatformStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.PlatformStrf5abb8225a42414fb572f0fa14564546LabelCaption"
						}
					}
				},
				"parentName": "SessionDetailsTabLabelGridLayout0b1745c5",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "DeviceStr0414f908-aec5-43bf-94aa-12a092f70a20",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "SessionDetailsTabLabelGridLayout0b1745c5"
					},
					"bindTo": "DeviceStr",
					"enabled": true,
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.DeviceStr0414f908aec543bf94aa12a092f70a20LabelCaption"
						}
					}
				},
				"parentName": "SessionDetailsTabLabelGridLayout0b1745c5",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "IPc04a4d2c-4cda-49f1-a532-89c8cbe046e7",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "SessionDetailsTabLabelGridLayout0b1745c5"
					},
					"bindTo": "IP"
				},
				"parentName": "SessionDetailsTabLabelGridLayout0b1745c5",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ActionsTabLabel",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.ActionsTabLabelTabCaption"
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
				"name": "TouchPageActionDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "ActionsTabLabel",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_DIFF*/
	};
});
