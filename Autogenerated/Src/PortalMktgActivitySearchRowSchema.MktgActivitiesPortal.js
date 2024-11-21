define("PortalMktgActivitySearchRowSchema", [], function() {
	return {
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "EntitySchemaCaption"
			},
			{
				"operation": "merge",
				"name": "FoundColumnsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 12
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Status",
				"values": {
					"layout": {
						"column": 12,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Channel",
				"values": {
					"layout": {
						"column": 18,
						"row": 0,
						"colSpan": 6
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
