﻿define("MultiDeleteDetailViewConfigV2", ["MultiDeleteDetailViewConfigV2Resources", "css!DetailModuleV2"],
	function(Resources) {
		Ext.define("BPMSoft.configuration.MultiDeleteDetailViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.MultiDeleteDetailViewConfig",

			viewModelClass: null,

			/**
			 * Returns the view configuration of the module.
			 * @param {Object} config Configuration.
			 * @return {Object} The view configuration of the module.
			 */
			generate: function(config) {
				var instanceId = this.instanceId;
				return [
					{
						"name": instanceId + "ModuleContainer",
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {wrapClassName: ["multi-delete-detail-module"]},
						"items": [this.getDetailContainer(config), this.getNoRightContainer()]
					}
				];
			},

			/**
			 * Returns config for "No right" container.
			 * @return {Object} Config for "No right" container.
			 */
			getNoRightContainer: function() {
				var instanceId = this.instanceId;
				var config = {
					"name": instanceId + "NoRightContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [
						{
							"name": instanceId + "Label",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": Resources.localizableStrings.HasNoRight,
							"visible": {
								"bindTo": "CanRead",
								"bindConfig": {
									"converter": function(value) {
										return !value;
									}
								}
							},
							"classes": {
								"labelClass": ["multi-delete-noright-container-message"]
							}
						}
					]
				};
				return config;
			},

			/**
			 * Returns config for detail container.
			 * @return {Object} Config detail container.
			 */
			getDetailContainer: function(config) {
				var instanceId = this.instanceId;
				var listedConfig = JSON.parse(config.profile.listedConfig);
				return {
					"name": instanceId + "LabelContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["multi-delete-detail"]},
					"visible": {"bindTo": "CanRead"},
					"items": [
						{
							"name": instanceId + "ControlGroup",
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Caption"},
							"classes": {"wrapClass": ["detail"]},
							"items": [this.getGridContainer(listedConfig)],
							"controlConfig": {
								"collapsed": true,
								"safeBind": true
							}
						}
					]
				};
			},

			/**
			 * Returns config for grid container.
			 * @param {Object} listedConfig Config of listed view.
			 * @return {Object} Config for grid.
			 */
			getGridContainer: function(listedConfig) {
				var instanceId = this.instanceId;
				var primaryDisplayColumnName = listedConfig.items[0].name;
				var config = {
					"name": instanceId + "GridContainer",
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [
						{
							"name": instanceId + "DataGrid",
							"itemType": BPMSoft.ViewItemType.GRID,
							"collection": {"bindTo": "GridData"},
							"linkClick": {"bindTo": "linkClicked"},
							"type": "listed",
							"multiSelect": false,
							"listedZebra": true,
							"safeBind": true,
							"visible": {"bindTo": "CanRead"},
							"isEmpty": {"bindTo": "IsGridEmpty"},
							"primaryDisplayColumnName": primaryDisplayColumnName,
							"listedConfig": {
								"name": instanceId + "DataGridTiledConfig",
								"captionsConfig": listedConfig.captionsConfig,
								"columnsConfig": listedConfig.columnsConfig,
								"items": listedConfig.items
							}
						}
					]
				};
				return config;
			}
		});
	});
