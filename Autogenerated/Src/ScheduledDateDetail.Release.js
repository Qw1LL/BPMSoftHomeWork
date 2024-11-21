define("ScheduledDateDetail", ["BPMSoft", "ConfigurationGrid",
		"ConfigurationGridGenerator", "ConfigurationGridUtilities"],
	function(BPMSoft) {
		return {
			entitySchemaName: "ScheduledDate",
			attributes: {
				IsEditable: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				},
				ReleaseStatusDefValue: {
					dataValueType: BPMSoft.DataValueType.STRING,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: "ReleaseStatusDefValue"
				}
			},
			mixins: {
				ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"className": "BPMSoft.ConfigurationGrid",
						"generator": "ConfigurationGridGenerator.generatePartial",
						"generateControlsConfig": {bindTo: "generatActiveRowControlsConfig"},
						"changeRow": {bindTo: "changeRow"},
						"unSelectRow": {bindTo: "unSelectRow"},
						"onGridClick": {bindTo: "onGridClick"},
						"initActiveRowKeyMap": {bindTo: "initActiveRowKeyMap"},
						"activeRowActions": [
							{
								"className": "BPMSoft.Button",
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "save",
								"markerValue": "save",
								"imageConfig": {"bindTo": "Resources.Images.SaveIcon"}
							},
							{
								"className": "BPMSoft.Button",
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "cancel",
								"markerValue": "cancel",
								"imageConfig": {"bindTo": "Resources.Images.CancelIcon"}
							},
							{
								"className": "BPMSoft.Button",
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"tag": "remove",
								"markerValue": "remove",
								"imageConfig": {"bindTo": "Resources.Images.RemoveIcon"}
							}
						],
						"listedZebra": true,
						"activeRowAction": {bindTo: "onActiveRowAction"}
					}
				}
			]/**SCHEMA_DIFF*/,
			methods: {
				init: function() {
					if (!BPMSoft.SysSettings.cachedSettings[this.ReleaseStatusDefValue]) {
						this.BPMSoft.SysSettings.querySysSettings("ReleaseStatusDef", null);
					}
					this.callParent(arguments);
				},
				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getFilterDefaultColumnName
				 * @overridden
				 */
				getFilterDefaultColumnName: function() {
					return "Status";
				}
			}
		};
	});
