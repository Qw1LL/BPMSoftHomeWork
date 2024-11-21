define("ProjectPlanHistoryDetailV2", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "ProjectPlanHistoryItem",
			attributes: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "RoleListedGridColumn",
									"bindTo": "Role",
									"position": {
										"column": 1,
										"colSpan": 6
									}
								},
								{
									"name": "PlanningWorkListedGridColumn",
									"bindTo": "PlanningWork",
									"position": {
										"column": 7,
										"colSpan": 4
									}
								},
								{
									"name": "EndDateListedGridColumn",
									"bindTo": "EndDate",
									"position": {
										"column": 11,
										"colSpan": 6
									}
								},
								{
									"name": "PlanningCompletionListedGridColumn",
									"bindTo": "PlanningCompletion",
									"position": {
										"column": 17,
										"colSpan": 4
									}
								},
								{
									"name": "ActualCompletionListedGridColumn",
									"bindTo": "ActualCompletion",
									"position": {
										"column": 21,
										"colSpan": 4
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 3
							},
							"items": [
								{
									"name": "RoleTiledGridColumn",
									"bindTo": "Role",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 6
									}
								},
								{
									"name": "PlanningWorkTiledGridColumn",
									"bindTo": "PlanningWork",
									"position": {
										"row": 1,
										"column": 7,
										"colSpan": 4
									}
								},
								{
									"name": "EndDateTiledGridColumn",
									"bindTo": "EndDate",
									"position": {
										"row": 1,
										"column": 11,
										"colSpan": 6
									}
								},
								{
									"name": "PlanningCompletionTiledGridColumn",
									"bindTo": "PlanningCompletion",
									"position": {
										"row": 1,
										"column": 17,
										"colSpan": 4
									}
								},
								{
									"name": "ActualCompletionTiledGridColumn",
									"bindTo": "ActualCompletion",
									"position": {
										"row": 1,
										"column": 21,
										"colSpan": 4
									}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
