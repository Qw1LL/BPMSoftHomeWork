define("OpportunityDetailV2", [],
	function() {
		return {
			entitySchemaName: "Opportunity",
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
									"name": "TitleListedGridColumn",
									"bindTo": "Title",
									"position": {
										"column": 1,
										"colSpan": 10
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "StageListedGridColumn",
									"bindTo": "Stage",
									"position": {
										"column": 11,
										"colSpan": 8
									}
								},
								{
									"name": "RevenueListedGridColumn",
									"bindTo": "Amount",
									"position": {
										"column": 19,
										"colSpan": 6
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
									"name": "TitleTiledGridColumn",
									"bindTo": "Title",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 10
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "StageTiledGridColumn",
									"bindTo": "Stage",
									"position": {
										"row": 1,
										"column": 11,
										"colSpan": 8
									}
								},
								{
									"name": "RevenueTiledGridColumn",
									"bindTo": "Amount",
									"position": {
										"row": 1,
										"column": 19,
										"colSpan": 6
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
