define("CasePage", [],
		function() {
			return {
				entitySchemaName: "Case",
				details: /**SCHEMA_DETAILS*/{
					"ProblemInCase": {
						"schemaName": "ProblemInCaseDetail",
						"entitySchemaName": "ProblemInCase",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Case"
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "ProblemInCase",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "SolutionTab",
						"propertyName": "items",
						"index": 2
					}
				]/**SCHEMA_DIFF*/,
				
				attributes: {},

				methods: {}
			};
		});
