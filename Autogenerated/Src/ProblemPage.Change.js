define("ProblemPage", ["BaseFiltersGenerateModule", "ServiceDeskConstants"],
	function() {
		return {
			entitySchemaName: "Problem",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Change",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Change",
						"caption": {
							"bindTo": "Resources.Strings.ChangeCaption"
						},
						"enabled": true
					},
					"parentName": "SolutionRichText_gridLayout",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "merge",
					"name": "Solution",
					"values": {
						"contentType": this.BPMSoft.ContentType.RICH_TEXT,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					},
					"parentName": "SolutionRichText_gridLayout",
					"propertyName": "items",
					"index": 1
				}
			]/**SCHEMA_DIFF*/,
			attributes: {},
			methods: {},
			rules: {},
			userCode: {}
		};
	});
