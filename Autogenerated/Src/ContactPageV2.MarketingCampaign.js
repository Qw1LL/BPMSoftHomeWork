define("ContactPageV2", [],
		function() {
			return {
				entitySchemaName: "Contact",
				details: /**SCHEMA_DETAILS*/{
					BulkEmailSubscriptionDetail: {
						schemaName: "BulkEmailSubscriptionDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Contact"
						}
					},
					EventDetail: {
						schemaName: "ContactInEventDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Contact"
						}
					},
					BulkEmailDetail: {
						schemaName: "ContactInBulkEmailDetailV2",
						filter: {
							masterColumn: "Id",
							detailColumn: "Contact"
						}
					},
					CampaignDetail: {
						schemaName: "ContactInCampaignDetail",
						filter: {
							masterColumn: "Id",
							detailColumn: "Contact"
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "CommunicationChannelsTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {"bindTo": "Resources.Strings.CommunicationChannelsTabCaption"},
							"items": []
						},
						"index": 3
					},
					{
						"operation": "insert",
						"name": "CommunicationChannelsContainer",
						"propertyName": "items",
						"parentName": "CommunicationChannelsTab",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "DoNotUseEmail",
						"propertyName": "items",
						"parentName": "CommunicationChannelsContainer",
						"values": {
							"layout": {"column": 0, "row": 0},
							"enabled": false
						}
					},
					{
						"operation": "insert",
						"name": "DoNotUseCall",
						"propertyName": "items",
						"parentName": "CommunicationChannelsContainer",
						"values": {
							"layout": {"column": 0, "row": 1},
							"enabled": false
						}
					},
					{
						"operation": "insert",
						"name": "DoNotUseSms",
						"propertyName": "items",
						"parentName": "CommunicationChannelsContainer",
						"values": {
							"layout": {"column": 13, "row": 0},
							"enabled": false
						}
					},
					{
						"operation": "insert",
						"name": "DoNotUseMail",
						"propertyName": "items",
						"parentName": "CommunicationChannelsContainer",
						"values": {
							"layout": {"column": 13, "row": 1},
							"enabled": false
						}
					},
					{
						"operation": "insert",
						"parentName": "CommunicationChannelsTab",
						"propertyName": "items",
						"name": "BulkEmailSubscriptionDetail",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "HistoryTab",
						"propertyName": "items",
						"name": "EventDetail",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "HistoryTab",
						"propertyName": "items",
						"name": "BulkEmailDetail",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "HistoryTab",
						"propertyName": "items",
						"name": "CampaignDetail",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					},
					{
						"operation": "insert",
						"parentName": "ContactPageGeneralContainer",
						"propertyName": "items",
						"name": "Dear",
						"values": {
							"layout": {
								"column": 13,
								"row": 3,
								"colSpan": 11,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "Age",
						"values": {
							"layout": {
								"row": 2,
								"column": 0,
								"colSpan": 11,
								"rowSpan": 1
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
