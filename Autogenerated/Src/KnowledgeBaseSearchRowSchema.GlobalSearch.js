define("KnowledgeBaseSearchRowSchema", [], function() {
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
						"colSpan": 18
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "CreatedBy",
				"values": {
					"layout": {
						"column": 18,
						"row": 1,
						"colSpan": 6
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
