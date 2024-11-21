define("SystemDesignerTileConfigEdit", ["BPMSoft", "LookupUtilities", "SystemDesignerTileConfigEditResources"],
	function(BPMSoft, LookupUtilities, resources) {
		var localizableStrings = resources.localizableStrings;
		return {

			messages: {
				/**
				 * ######### ######### #########.
				 */
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######### ######## ######### ######
				 */
				"PostModuleConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######### ######### ######## ######.
				 */
				"GetSystemDesignerTileConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * ######### ######## # ########### #########.
				 */
				"BackHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			mixins: {},
			attributes: {
				ModuleName: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				ModuleParameters: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			methods: {
				/**
				 * ############## ######### ######## ######.
				 * @protected
				 * @virtual
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						var config = this.sandbox.publish("GetSystemDesignerTileConfig", null, [this.getModuleId()]);
						this.initParams(config);
						this.sandbox.publish("ChangeHeaderCaption", {
							caption: localizableStrings.Header,
							dataViews: new BPMSoft.Collection(),
							moduleName: this.name
						});
						callback.call(scope);
					}, this]);
				},

				initParams: function(config) {
					if (config.requiredModule) {
						this.set("ModuleName", config.requiredModule);
						delete config.requiredModule;
						var moduleParameters = JSON.stringify(config, null, "\t");
						this.set("ModuleParameters", moduleParameters);
					} else {
						var sectionId = config.sectionId.value;
						var params = {"sectionId": sectionId};
						var moduleParameters = JSON.stringify(params, null, "\t");
						this.set("ModuleParameters", moduleParameters);
					}
				},

				/**
				 * ######### ####### # ########## ########.
				 * @protected
				 * @virtual
				 */
				goBack: function() {
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * ######### ############ ######
				 * @protected
				 * @virtual
				 */
				save: function() {
					var moduleName = this.get("ModuleName");
					var strModuleParameters = this.get("ModuleParameters");
					var result = BPMSoft.deserialize(strModuleParameters);
					result.requiredModule = moduleName;
					this.sandbox.publish("PostModuleConfig", result, [this.getModuleId()]);
					this.goBack();
				},

				/**
				 * ########## ############## ######.
				 * @protected
				 * @virtual
				 * @returns {string} ############# ######.
				 */
				getModuleId: function() {
					return this.sandbox.id;
				}
			},
			rules: {},
			diff: [
				{
					"operation": "insert",
					"name": "ModuleSelectingContainer",
					"values": {
						"id": "ModuleSelectingContainer",
						"selectors": {wrapEl: "#ModuleSelectingContainer"},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [
						]
					}
				},
				{
					"operation": "insert",
					"name": "HeaderContainer",
					"parentName": "ModuleSelectingContainer",
					"propertyName": "items",
					"values": {
						"id": "HeaderContainer",
						"selectors": {wrapEl: "#HeaderContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {column: 0, row: 0, colSpan: 24},
						"items": [
						]
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "SaveButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": localizableStrings.SaveButtonCaption,
						"click": {bindTo: "save"},
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"layout": {column: 0, row: 0, colSpan: 2},
						"classes": {textClass: "actions-button-margin-right"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HeaderContainer",
					"propertyName": "items",
					"name": "CancelButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": localizableStrings.CancelButtonCaption,
						"click": { bindTo: "goBack" },
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"layout": { column: 4, row: 0, colSpan: 2 }
					}
				},
				{
					"operation": "insert",
					"name": "ModuleSettingsContainer",
					"parentName": "ModuleSelectingContainer",
					"propertyName": "items",
					"values": {
						"id": "ModuleSettingsContainer",
						"selectors": {wrapEl: "#ModuleSettingsContainer"},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {column: 0, row: 1, colSpan: 11},
						"items": [
						]
					}
				},
				{
					"operation": "insert",
					"name": "moduleName",
					"parentName": "ModuleSettingsContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "ModuleName",
						"contentType": BPMSoft.ContentType.TEXT,
						"labelConfig": {
							"visible": true,
							"caption": localizableStrings.ModuleNameEditCaption
						}
					}
				},
				{
					"operation": "insert",
					"name": "moduleParameters",
					"parentName": "ModuleSettingsContainer",
					"propertyName": "items",
					"values": {
						"bindTo": "ModuleParameters",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {
							"visible": true,
							"caption": localizableStrings.ModuleParametersEditCaption
						}
					}
				}
			]
		};
	});
