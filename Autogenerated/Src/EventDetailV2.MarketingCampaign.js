define("EventDetailV2", function() {
	return {
		entitySchemaName: "Event",
		attributes: {},
		methods: {
			/**
			 * ########## ######### ###### ########## ######.
			 * @overridden
			 */
			getAddRecordButtonVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
			 * @overridden
			 */
			getDeleteRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @overridden
			 */
			getSwitchGridModeMenuItem: BPMSoft.emptyFn
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
								"name": "NameListedGridColumn",
								"bindTo": "Name",
								"type": "text",
								"position": {
									"column": 0,
									"colSpan": 24
								}
							}
						]
					},
					"tiledConfig": {
						"name": "DataGridTiledConfig",
						"grid": {
							"columns": 24,
							"rows": 1
						},
						"items": [
							{
								"name": "NameTiledGridColumn",
								"bindTo": "Name",
								"type": "text",
								"position": {
									"row": 1,
									"column": 0,
									"colSpan": 24
								},
								"captionConfig": {
									"visible": false
								}
							}
						]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
