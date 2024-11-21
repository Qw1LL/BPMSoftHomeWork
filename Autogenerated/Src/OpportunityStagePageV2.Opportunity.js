define("OpportunityStagePageV2", [],
	function() {
		return {
			entitySchemaName: "OpportunityStage",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {},
			methods: {},
			rules: {},
			userCode: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ShowInFunnel",
					"values": {
						"bindTo": "ShowInFunnel",
						"layout": {"column": 0, "row": 1, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ShowInProgressBar",
					"values": {
						"bindTo": "ShowInProgressBar",
						"layout": {"column": 0, "row": 2, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "End",
					"values": {
						"bindTo": "End",
						"layout": {"column": 0, "row": 3, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Successful",
					"values": {
						"bindTo": "Successful",
						"layout": {"column": 0, "row": 4, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Number",
					"values": {
						"bindTo": "Number",
						"layout": {"column": 13, "row": 1, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "MaxProbability",
					"values": {
						"bindTo": "MaxProbability",
						"layout": {"column": 13, "row": 2, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "NextStepTerm",
					"values": {
						"bindTo": "NextStepTerm",
						"layout": {"column": 13, "row": 3, "colSpan": 11}
					}
				},
				{
					"operation": "merge",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Description",
					"values": {
						"bindTo": "Description",
						"layout": {"column": 0, "row": 5, "colSpan": 24}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
