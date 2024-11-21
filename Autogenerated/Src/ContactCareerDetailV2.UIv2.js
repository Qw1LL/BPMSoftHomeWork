define("ContactCareerDetailV2", ["BPMSoft"],
	function(BPMSoft) {
		return {
			entitySchemaName: "ContactCareer",
			attributes: {},
			methods: {

				/**
				 * ########## ### ####### ### ########## ## #########.
				 * @overridden
				 * @return {String} ### #######.
				 */
				getFilterDefaultColumnName: function() {
					return "Account";
				}
			},
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
									"name": "AccountListedGridColumn",
									"bindTo": "Account",
									"position": {
										"column": 1,
										"colSpan": 8
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "JobListedGridColumn",
									"bindTo": "Job",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {
										"column": 9,
										"colSpan": 8
									}
								},
								{
									"name": "CurrentListedGridColumn",
									"bindTo": "Current",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {
										"column": 17,
										"colSpan": 4
									}
								},
								{
									"name": "PrimaryListedGridColumn",
									"bindTo": "Primary",
									"type": BPMSoft.GridCellType.TEXT,
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
									"name": "AccountTiledGridColumn",
									"bindTo": "Account",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 24
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "JobTiledGridColumn",
									"bindTo": "Job",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {
										"row": 2,
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "CurrentTiledGridColumn",
									"bindTo": "Current",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {
										"row": 2,
										"column": 13,
										"colSpan": 6
									}
								},
								{
									"name": "PrimaryTiledGridColumn",
									"bindTo": "Primary",
									"type": BPMSoft.GridCellType.TEXT,
									"position": {
										"row": 2,
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
