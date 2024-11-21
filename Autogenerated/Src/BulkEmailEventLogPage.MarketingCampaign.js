define("BulkEmailEventLogPage", [], function() {
	return {
		entitySchemaName: "BulkEmailEventLog",
		attributes: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "Name"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Result",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "Result"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "StartDate",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "StartDate"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "EndDate",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "EndDate"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "Description",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 4,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "Description",
					"enabled": true,
					"contentType": 0
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "DetailedResult",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 4,
						"column": 0,
						"row": 6,
						"layoutName": "Header"
					},
					"bindTo": "DetailedResult",
					"enabled": true,
					"contentType": 0
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 5
			}
		]/**SCHEMA_DIFF*/
	};
});
