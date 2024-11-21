define("IntegrationLogLookupSection", [], function() {
	return {
		attributes: {
			IsGridSettingsMenuVisible: {
				value: false
			}
		},
		methods: {

			getProfileKey: function() {
				return "IntegrationLogLookupSectionIntegrationLogGridSettingsGridDataView";
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