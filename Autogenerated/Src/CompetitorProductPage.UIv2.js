﻿define("CompetitorProductPage", [],
		function() {
			return {
				entitySchemaName: "CompetitorProduct",
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "CompetitorProductPageGeneralTabContainer",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "CompetitorProductPageGeneralTabContainer",
						"propertyName": "items",
						"name": "CompetitorProductPageGeneralBlock",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Competitor",
						"values": {

							"bindTo": "Competitor",
							"layout": { "column": 0, "row": 1, "colSpan": 11 }
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Name",
						"values": {
							"bindTo": "Name",
							"layout": { "column": 0, "row": 0, "colSpan": 11 }
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Weakness",
						"values": {
							"bindTo": "Weakness",
							"layout": { "column": 0, "row": 2, "colSpan": 11 },
							"contentType": BPMSoft.ContentType.LONG_TEXT
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Strengths",
						"values": {
							"bindTo": "Strengths",
							"layout": { "column": 0, "row": 3, "colSpan": 11 },
							"contentType": BPMSoft.ContentType.LONG_TEXT
						}
					},
					{
						"operation": "merge",
						"name": "Tabs",
						"parentName": "CardContentContainer",
						"propertyName": "items",
						"values": {
							"visible": false
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
