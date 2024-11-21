define("PartnershipParameterPage", [], function() {
	return {
		entitySchemaName: "PartnershipParameter",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "ParameterType",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "ParameterValueType",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Partnership",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "PartnerParamCategory",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "PartnershipParameterType",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "CurrentValue",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 2
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			}
		]/**SCHEMA_DIFF*/,
		methods: {},
		rules: {}
	};
});
