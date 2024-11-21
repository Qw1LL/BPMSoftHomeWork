/**
 * @class MobileDesignerModulePage
 * @public
 * ##### ########### ###### ######### ########## ##########
 */
define("MobileDesignerModulePage", ["BPMSoft", "MobileDesignerModulePageResources"],
	function(BPMSoft) {
		return {
			messages: {

				/**
				 * ########## ######### ######### ######### ###### #########.
				 */
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				"OnDesignerSaved": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				"OnDesignerCanceled": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				"BackHistoryState": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				},

				"GetDesignerSettings" : {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				"PostDesignerSettings" : {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}

			},
			attributes: {

				"SectionCaption": {
					dataValueType: BPMSoft.DataValueType.TEXT
				}

			},
			methods: {

				/**
				 * ############## ######### ######## ######.
				 * @protected
				 * @virtual
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ####### ######### ######.
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						var history = this.sandbox.publish("GetHistoryState");
						var historyState = history.state;
						var moduleConfig = this.moduleConfig = historyState.moduleConfig;
						this.changeDesignerCaption(moduleConfig.title);
						callback.call(scope);
					}, this]);
				},

				/**
				 * ############# ######### ###### #########.
				 * @protected
				 * @virtual
				 */
				changeDesignerCaption: function(caption) {
					this.sandbox.publish("ChangeHeaderCaption", {
						caption: caption,
						moduleName: this.name
					});
				},

				/**
				 * ######### ######### # #########.
				 * @protected
				 * @virtual
				 */
				save: function() {
					var config = this.getDesignerSettings();
					this.sandbox.publish("OnDesignerSaved", config);
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * ######### ######## #########.
				 * @protected
				 * @virtual
				 */
				cancel: function() {
					this.sandbox.publish("OnDesignerCanceled");
					this.sandbox.publish("BackHistoryState");
				},


				/**
				 * ########## ######### ######### #########.
				 * @protected
				 * @virtual
				 */
				getDesignerSettings: function() {
					var designerSettings = this.sandbox.publish("PostDesignerSettings");
					return designerSettings;
				},

				/**
				 * ######### ########, ########### ##### ########### ########.
				 * @protected
				 * @virtual
				 */
				onRender: function() {
					this.sandbox.subscribe("GetDesignerSettings", function() {
						return this.moduleConfig.designerSettings;
					}, this);
					var designerModuleSchemaName = this.moduleConfig.designerModuleSchemaName;
					this.sandbox.loadModule(designerModuleSchemaName, {
						renderTo: "MobileDesignerFooterContainer",
						id: this.sandbox.id + designerModuleSchemaName
					});
				},

				getCancelButtonCaption: function() {
					return BPMSoft.Resources.SchemaDesigner.DiscardStorageButtonCaption;
				}

			},
			diff: [
				{
					"operation": "insert",
					"name": "MobileDesignerContainer",
					"values": {
						"id": "MobileDesignerContainer",
						"selectors": {
							"wrapEl": "#MobileDesignerContainer"
						},
						"classes": {
							"textClass": "center-panel"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "MobileDesignerHeaderContainer",
					"parentName": "MobileDesignerContainer",
					"propertyName": "items",
					"values": {
						"id": "MobileDesignerHeaderContainer",
						"selectors": {
							"wrapEl": "#MobileDesignerHeaderContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "FooterContainer",
					"parentName": "MainContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"generateId": false,
						"classes": {"wrapClassName": ["footer-container", "mobile-section-designer-footer"]},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "FooterContainer",
					"propertyName": "items",
					"name": "SaveButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.SaveButtonCaption"
						},
						"classes": {
							"textClass": "actions-button-margin-right"
						},
						"click": {
							"bindTo": "save"
						},
						"style": "orange",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 2
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "FooterContainer",
					"propertyName": "items",
					"name": "CancelButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "getCancelButtonCaption"
						},
						"classes": {
							"textClass": "actions-button-margin-right"
						},
						"click": {
							"bindTo": "cancel"
						},
						"style": "default",
						"layout": {
							"column": 4,
							"row": 0,
							"colSpan": 2
						}
					}
				},
				{
					"operation": "insert",
					"name": "MobileDesignerFooterContainer",
					"parentName": "MobileDesignerContainer",
					"propertyName": "items",
					"values": {
						"id": "MobileDesignerFooterContainer",
						"selectors": {
							"wrapEl": "#MobileDesignerFooterContainer"
						},
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				}
			]
		};
	});
