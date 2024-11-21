define("ProcessInDetailsDetailV2", function() {
	return {
		/**
		 * Entity schema name.
		 * @type {String}
		 */
		entitySchemaName: "ProcessInDetails",
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"rowDataItemMarkerColumnName": "SysDetail",
					"type": "listed",
					"listedConfig": {
						"name": "DataGridListedConfig",
						"items": [
							{
								"name": "CaptionListedGridColumn",
								"bindTo": "Caption",
								"type": BPMSoft.GridCellType.TEXT,
								"position": {
									"column": 1,
									"colSpan": 24
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
								"name": "CaptionTiledGridColumn",
								"bindTo": "Caption",
								"type": BPMSoft.GridCellType.TEXT,
								"position": {
									"row": 1,
									"column": 1,
									"colSpan": 24
								},
								"captionConfig": {
									"visible": true
								}
							}
						]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
