define("ActivityPageV2", [],
	function() {
		return {
			entitySchemaName: "Activity",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Lead",
					"values": {
						"layout": { "column": 13, "row": 2, "colSpan": 11 }
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
