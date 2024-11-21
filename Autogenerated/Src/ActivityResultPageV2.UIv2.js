 define("ActivityResultPageV2", [],
	function() {
		return {
			entitySchemaName: "ActivityResult",
			methods: {
			},
			details: /**SCHEMA_DETAILS*/{
				ActivityCategoryResultEntryDetail: {
					schemaName: "ActivityCategoryResultEntryDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "ActivityResult"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Tabs",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 18}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Category",
					"values": {
						"bindTo": "Category",
						"layout": {"column": 0, "row": 1, "colSpan": 9},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "BusinessProcessOnly",
					"values": {
						"layout": {"column": 9, "row": 1, "colSpan": 9}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Description",
					"values": {
						"bindTo": "Description",
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"layout": {"column": 0, "row": 2, "colSpan": 18}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ActivityCategoryResultEntryDetail",
					"values": {
						"layout": {"column": 0, "row": 4, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
