define("StageInOpportunityDetailV2",
	function() {
		return {
			entitySchemaName: "OpportunityInStage",
			methods: {
				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var filters = this.callParent();
					filters.add("showInProgressBarFilter",
						this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Stage.ShowInProgressBar", true
						)
					);
					return filters;
				},

				/**
				 * @inheritdoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					var editRecordMenuItem = this.getEditRecordMenuItem();
					if (editRecordMenuItem) {
						toolsButtonMenu.addItem(editRecordMenuItem);
					}
				},

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
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "Stage";
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"primaryDisplayColumnName": "Stage",
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "StageListedGridColumn",
									"bindTo": "Stage",
									"position": {
										"column": 1,
										"colSpan": 11
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "StartDateListedGridColumn",
									"bindTo": "StartDate",
									"position": {
										"column": 13,
										"colSpan": 6
									}
								},
								{
									"name": "DueDateListedGridColumn",
									"bindTo": "DueDate",
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
									"name": "StageTiledGridColumn",
									"bindTo": "Stage",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 11
									},
									"type": BPMSoft.GridCellType.TITLE
								},
								{
									"name": "StartDateTiledGridColumn",
									"bindTo": "StartDate",
									"position": {
										"row": 1,
										"column": 13,
										"colSpan": 6
									}
								},
								{
									"name": "DueDateTiledGridColumn",
									"bindTo": "DueDate",
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
