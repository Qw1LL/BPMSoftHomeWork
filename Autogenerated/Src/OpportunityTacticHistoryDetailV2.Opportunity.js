define("OpportunityTacticHistoryDetailV2", [],
	function() {
		return {
			entitySchemaName: "OpportunityTacticHist",
			methods: {
				/**
				 * ######### # ######### ####### ########### ## #### ## #########
				 */
				getGridDataColumns: function() {
					var gridDataColumns = this.callParent(arguments);
					gridDataColumns.ModifyDate = {
						path: "ModifyDate",
						orderPosition: 0,
						orderDirection: this.BPMSoft.OrderDirection.DESC
					};
					return gridDataColumns;
				},

				/**
				 * ######### ######### ######.
				 * @return {boolean} ######### ######.
				 */
				isDetailVisible: function() {
					if (this.get("IsGridLoading")) {
						return false;
					} else {
						return !this.get("IsGridEmpty");
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return false;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#sortColumn
				 * @overridden
				 */
				sortColumn: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
				 * @overridden
				 */
				getGridSortMenuItem: this.BPMSoft.emptyFn
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Detail",
					"values": {
						visible: {
							bindTo: "isDetailVisible"
						}
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "TacticsListedGridColumn",
									"bindTo": "Tactics",
									"position": {
										"column": 1,
										"colSpan": 11
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "CheckDateListedGridColumn",
									"bindTo": "CheckDate",
									"position": {
										"column": 13,
										"colSpan": 6
									}
								},
								{
									"name": "ModifyDateListedGridColumn",
									"bindTo": "ModifyDate",
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
								"rows": 2
							},
							"items": [
								{
									"name": "TacticsTiledGridColumn",
									"bindTo": "Tactics",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 24
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "CheckDateTiledGridColumn",
									"bindTo": "CheckDate",
									"position": {
										"row": 2,
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "ModifyDateTiledGridColumn",
									"bindTo": "ModifyDate",
									"position": {
										"row": 2,
										"column": 13,
										"colSpan": 11
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
