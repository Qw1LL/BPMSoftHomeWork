define("PortalKnowledgeBaseSearchRowSchema", [], function() {
	return {
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "EntitySchemaCaption"
			},
			{
				"operation": "merge",
				"name": "PrimaryColumnContainer",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					}
				}
			},
			{
				"operation": "merge",
				"name": "FoundColumnsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Type",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
