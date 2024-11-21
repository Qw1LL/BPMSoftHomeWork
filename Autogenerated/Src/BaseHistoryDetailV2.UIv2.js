define("BaseHistoryDetailV2", [],
	function() {
		return {
			methods: {
				/**
				 * ######### # ######### ####### ########### ## #### ## #########
				 */
				getGridDataColumns: function() {
					var gridDataColumns = this.callParent(arguments);
					gridDataColumns.StartDate = {
						path: "StartDate",
						orderPosition: 0,
						orderDirection: this.BPMSoft.OrderDirection.DESC
					};
					return gridDataColumns;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: BPMSoft.emptyFn

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
									"name": "TitleListedGridColumn",
									"bindTo": "Title",
									"position": {
										"column": 1,
										"colSpan": 14
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "SysEntityListedGridColumn",
									"bindTo": "SysEntity",
									"position": {
										"column": 15,
										"colSpan": 5
									}
								},
								{
									"name": "StartDateListedGridColumn",
									"bindTo": "StartDate",
									"position": {
										"column": 20,
										"colSpan": 5
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
										"colSpan": 14
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "SysEntityTiledGridColumn",
									"bindTo": "SysEntity",
									"position": {
										"row": 1,
										"column": 15,
										"colSpan": 5
									}
								},
								{
									"name": "StartDateTiledGridColumn",
									"bindTo": "StartDate",
									"position": {
										"row": 1,
										"column": 20,
										"colSpan": 5
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
