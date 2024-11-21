define("FileImportLookupSection", [], function() {
	return {
		attributes: {
			IsGridSettingsMenuVisible: {
				value: false
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "SeparateModeAddRecordButton"
			},
			{
				"operation": "remove",
				"name": "CombinedModeAddRecordButton"
			},
			{
				"operation": "remove",
				"name": "DataGrid"
			},
			{
				"operation": "merge",
				"name": "SeparateModeBackButton",
				"values": {
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE
				}
			},
			{
				"operation": "insert",
				"name": "DataGrid",
				"parentName": "DataGridContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID,
					"listedZebra": true,
					"activeRow": {"bindTo": "ActiveRow"},
					"collection": {"bindTo": "GridData"},
					"isEmpty": {"bindTo": "IsGridEmpty"},
					"multiSelect": {"bindTo": "MultiSelect"},
					"multiSelectChanged": {"bindTo": "onMultiSelectChanged"},
					"selectedRows": {"bindTo": "SelectedRows"},
					"loadMore": {"bindTo": "loadMore"},
					"selectRow": {"bindTo": "rowSelected"},
					"isLoading": {"bindTo": "IsGridLoading"},
					"primaryColumnName": "Id",
					"sortColumn": {"bindTo": "sortColumn"},
					"sortColumnDirection": {"bindTo": "GridSortDirection"},
					"sortColumnIndex": {"bindTo": "SortColumnIndex"},
					"needLoadData": {"bindTo": "needLoadData"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
