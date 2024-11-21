define("CaseRuleInStageDetail", ["ConfigurationGrid", "ConfigurationGridGenerator",
	"ConfigurationGridUtilities"], function() {
	return {
		entitySchemaName: "CaseRuleInStage",
		attributes: {
			"IsEditable": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			}
		},
		mixins: {
			ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
		},
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
			 * @overridden
			 */
			getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getShowQuickFilterButton
			 * @overridden
			 */
			getShowQuickFilterButton: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getDeleteRecordMenuItem
			 * @overridden
			 */
			getDeleteRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getGridSortMenuItem
			 * @overridden
			 */
			getGridSortMenuItem: this.BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#sortColumn
			 * @overridden
			 */
			sortColumn: this.BPMSoft.emptyFn
		},
		diff: [
			{
				"operation": "merge",
				"name": "DataGrid",
				"values": {
					"className": "BPMSoft.ConfigurationGrid",
					"generator": "ConfigurationGridGenerator.generatePartial",
					"generateControlsConfig": {"bindTo": "generatActiveRowControlsConfig"},
					"changeRow": {"bindTo": "changeRow"},
					"unSelectRow": {"bindTo": "unSelectRow"},
					"onGridClick": {"bindTo": "onGridClick"},
					"activeRowActions": [
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "save",
							"markerValue": "save",
							"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
						},
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "cancel",
							"markerValue": "cancel",
							"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
						},
						{
							"className": "BPMSoft.Button",
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"tag": "remove",
							"markerValue": "remove",
							"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
						}
					],
					"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
					"activeRowAction": {"bindTo": "onActiveRowAction"}
				}
			}
		]
	};
});
