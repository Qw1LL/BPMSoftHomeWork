define("ContactInternalRateDetailV2", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "ContactInternalRate",
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
									"name": "StartDateListedGridColumn",
									"bindTo": "StartDate",
									"position": {
										"column": 1,
										"colSpan": 8
									}
								},
								{
									"name": "DueDateListedGridColumn",
									"bindTo": "DueDate",
									"position": {
										"column": 9,
										"colSpan": 8
									}
								},
								{
									"name": "RateListedGridColumn",
									"bindTo": "Rate",
									"position": {
										"column": 17,
										"colSpan": 8
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
									"name": "StartDateTiledGridColumn",
									"bindTo": "StartDate",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 8
									}
								},
								{
									"name": "DueDateTiledGridColumn",
									"bindTo": "DueDate",
									"position": {
										"row": 1,
										"column": 9,
										"colSpan": 8
									}
								},
								{
									"name": "RateTiledGridColumn",
									"bindTo": "Rate",
									"position": {
										"row": 1,
										"column": 17,
										"colSpan": 8
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
