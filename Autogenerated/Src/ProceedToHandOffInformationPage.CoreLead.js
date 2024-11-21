define("ProceedToHandOffInformationPage", [], function() {
	return {
		entitySchemaName: "",
		attributes: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "LeadType",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "LeadType",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Budget",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 1,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "Budget",
					"enabled": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "OpportunityResponsible",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "OpportunityResponsible",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "OpportunityDepartment",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 1,
						"row": 3,
						"layoutName": "Header"
					},
					"bindTo": "OpportunityDepartment",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "MeetingTime",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "Header"
					},
					"bindTo": "MeetingTime",
					"enabled": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "DecisionDate",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 1,
						"row": 5,
						"layoutName": "Header"
					},
					"bindTo": "DecisionDate",
					"enabled": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "Comment",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 2,
						"column": 0,
						"row": 6,
						"layoutName": "Header"
					},
					"bindTo": "Comment",
					"enabled": true
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 6
			}
		]/**SCHEMA_DIFF*/
	};
});
