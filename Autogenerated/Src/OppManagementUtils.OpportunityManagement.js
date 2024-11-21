define("OppManagementUtils", ["OppManagementUtilsResources", "Activity", "ControlGridModule"], function(resources) {
	/**
	 * ########## ############# #####.
	 * @return {Object}
	 */
	function generateGridViewConfig(name) {
		return {
			"itemType": BPMSoft.ViewItemType.GRID,
			"className": "BPMSoft.ControlGrid",
			"primaryColumnName": "Id",
			"tag": name,
			"listedZebra": true,
			"collection": { "bindTo": name + "Collection" },
			"activeRow": { "bindTo": name + "ActiveRow" },
			"selectedRows": { "bindTo": name + "SelectedRows" },
			"type": "listed",
			"linkClick": { "bindTo": "linkClicked" },
			"applyControlConfig": { "bindTo": "onApplyControlConfig" },
			"controlColumnName": "Actions",
			"listedConfig": {
				"name": name + "DataGridListedConfig",
				"items": [
					{
						"name": name + "ActivitiesTitleColumn",
						"caption": BPMSoft.Activity.columns.Title.caption,
						"bindTo": "Title",
						"position": { "column": 0, "colSpan": 14 },
						"type": BPMSoft.GridCellType.TEXT
					},
					{
						"name": name + "ActivitiesStartDateColumn",
						"caption": BPMSoft.Activity.columns.StartDate.caption,
						"bindTo": "StartDate",
						"position": { "column": 0, "colSpan": 6 },
						"type": BPMSoft.GridCellType.TEXT
					},
					{
						"name": name + "ActivitiesButtonColumn",
						"bindTo": "Actions",
						"caption": resources.localizableStrings.Actions,
						"position": { "column": 0, "colSpan": 4 },
						"type": BPMSoft.GridCellType.TEXT
					}
				]
			},
			"tiledConfig": {
				"name": name + "DataGridTiledConfig",
				"grid": {
					"columns": 24,
					"rows": 3
				},
				"items": []
			}
		};
	}
	return {
		generateGridViewConfig: generateGridViewConfig
	};
});
