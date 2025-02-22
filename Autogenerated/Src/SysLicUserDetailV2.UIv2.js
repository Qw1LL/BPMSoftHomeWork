﻿define("SysLicUserDetailV2", ["ConfigurationGrid", "ConfigurationGridGenerator", "ConfigurationGridUtilities"],
	function() {
		return {
			entitySchemaName: "SysLicUser",
			mixins: {
				ConfigurationGridUtilites: "BPMSoft.ConfigurationGridUtilities"
			},
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
						"initActiveRowKeyMap": {"bindTo": "initActiveRowKeyMap"},
						"activeRowAction": {"bindTo": "onActiveRowAction"},
						"multiSelect": false,
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "SysLicPackageListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.SysLicPackageCaption"},
									"bindTo": "SysLicPackage.Name",
									"type": "text",
									"position": {
										"column": 0,
										"colSpan": 11
									}
								},
								{
									"name": "ActiveListedGridColumn",
									"caption": {"bindTo": "Resources.Strings.ActiveCaption"},
									"bindTo": "Active",
									"type": "text",
									"position": {
										"column": 13,
										"colSpan": 3
									}
								}
							]
						}
					}
				}
			],
			attributes: {
				IsEditable: {
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: true
				}
			},
			methods: {
				getGridDataColumns: function() {
					var config = this.callParent(arguments);
					config["SysLicPackage.Name"] = { path: "SysLicPackage.Name" };
					return config;
				}
			}
		};
	});
