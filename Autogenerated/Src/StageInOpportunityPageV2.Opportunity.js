define("StageInOpportunityPageV2", ["BaseFiltersGenerateModule"],
	function(BaseFiltersGenerateModule) {
		return {
			entitySchemaName: "OpportunityInStage",
			attributes: {
				"Owner": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
				}
			},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Opportunity",
					"values": {
						"bindTo": "Opportunity",
						"layout": { "column": 0, "row": 0, "colSpan": 24 },
						"enabled": false,
						"controlConfig": {
							"enableRightIcon": false
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Stage",
					"values": {
						"bindTo": "Stage",
						"layout": { "column": 0, "row": 1, "colSpan": 11 },
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Owner",
					"values": {
						"bindTo": "Owner",
						"layout": { "column": 0, "row": 4, "colSpan": 11 }
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "StartDate",
					"values": {
						"bindTo": "StartDate",
						"layout": { "column": 0, "row": 2, "colSpan": 11 },
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "DueDate",
					"values": {
						"bindTo": "DueDate",
						"layout": { "column": 0, "row": 3, "colSpan": 11 },
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Comments",
					"values": {
						"bindTo": "Comments",
						"layout": { "column": 0, "row": 5, "colSpan": 11 },
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
