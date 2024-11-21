define("ServiceEngineerDetail", ["BPMSoft",
		"ConfigurationGrid", "ConfigurationGridGenerator", "ConfigurationGridUtilities"],
	function(BPMSoft) {
		return {
			attributes: {
				"IsEditable": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": true
				}
			},
			mixins: {
				ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
			},
			messages: {},
			methods: {},
			diff: [
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"className": "BPMSoft.ConfigurationGrid",
						"generator": "ConfigurationGridGenerator.generatePartial",
						"generateControlsConfig": {"bindTo": "generateActiveRowControlsConfig"},
						"changeRow": {"bindTo": "changeRow"},
						"unSelectRow": {"bindTo": "unSelectRow"},
						"onGridClick": {"bindTo": "onGridClick"},
						"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
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
						"listedZebra": true,
						"activeRowAction": {"bindTo": "onActiveRowAction"}
					}
				}
			]
		};
	});
