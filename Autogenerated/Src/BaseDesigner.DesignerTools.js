/**
 * @class BaseDesigner
 * @public
 * Base designer class module.
 */
define("BaseDesigner", ["BPMSoft", "BaseDesignerResources"],
	function(BPMSoft) {
		return {
			messages: {

				/**
				 * @message ChangeHeaderCaption
				 * Notification that the header caption was changed.
				 */
				"ChangeHeaderCaption": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message OnDesignerSaved
				 * Notification that designer finished saving.
				 */
				"OnDesignerSaved": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message OnDesignerCanceled
				 * Notification that that designer was closed.
				 */
				"OnDesignerCanceled": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message BackHistoryState
				 * Notification that state was returned to previous.
				 */
				"BackHistoryState": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}

			},
			attributes: {

				/**
				 * Section caption.
				 * @private
				 * @type {String}
				 */
				"SectionCaption": {
					dataValueType: BPMSoft.DataValueType.TEXT
				}

			},
			methods: {

				/**
				 * Initializes the initial state of the model.
				 * @protected
				 * @virtual
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				init: function(callback, scope) {
					this.initSectionCaption();
					this.callParent([function() {
						this.changeDesignerCaption();
						callback.call(scope);
					}, this]);
				},

				/**
				 * Initializes section caption.
				 * @protected
				 * @virtual
				 */
				initSectionCaption: function() {
					var history = this.sandbox.publish("GetHistoryState");
					if (history) {
						var historyState = history.state;
						this.settings = historyState.settings;
						var title = historyState.title;
						if (title) {
							this.set("SectionCaption", title);
						}
					}
				},

				/**
				 * Sets the designer module caption.
				 * @protected
				 * @virtual
				 */
				changeDesignerCaption: function() {
					var designerCaption = this.get("Resources.Strings.DesignerCaption");
					var sectionCaption = this.get("SectionCaption");
					if (!Ext.isEmpty(sectionCaption)) {
						designerCaption += Ext.String.format(" \"{0}\"", sectionCaption);
					}
					this.sandbox.publish("ChangeHeaderCaption", {
						caption: designerCaption,
						moduleName: this.name
					});
				},

				/**
				 * Saves designer change.
				 * @protected
				 * @virtual
				 */
				save: function() {
					var config = this.getDesignerConfig();
					this.sandbox.publish("OnDesignerSaved", config);
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * Closes designer page.
				 * @protected
				 * @virtual
				 */
				cancel: function() {
					this.sandbox.publish("OnDesignerCanceled");
					this.sandbox.publish("BackHistoryState");
				},

				/**
				 * Returns designer configuration.
				 * @protected
				 * @virtual
				 */
				getDesignerConfig: Ext.emptyFn,

				/**
				 * Returns array of grid element values.
				 * @param {BPMSoft.Collection} collection Collection.
				 * @return {Array} Returns array of grid element values.
				 */
				getItemConfigsByCollection: function(collection) {
					var result = [];
					collection.eachKey(function(itemId, item) {
						var itemConfig = {};
						var values = item.values;
						for (var propertyKey in values) {
							itemConfig[propertyKey] = item.get(propertyKey);
						}
						result.push(itemConfig);
					}, this);
					return result;
				}

			},
			diff: [
				{
					"operation": "insert",
					"name": "BaseDesignerContainer",
					"values": {
						"id": "BaseDesignerContainer",
						"selectors": {
							"wrapEl": "#BaseDesignerContainer"
						},
						"classes": {
							"textClass": "center-panel"
						},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "BaseDesignerHeaderContainer",
					"parentName": "BaseDesignerContainer",
					"propertyName": "items",
					"values": {
						"id": "BaseDesignerHeaderContainer",
						"selectors": {
							"wrapEl": "#BaseDesignerHeaderContainer"
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
					"parentName": "BaseDesignerHeaderContainer",
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
					"parentName": "BaseDesignerHeaderContainer",
					"propertyName": "items",
					"name": "CancelButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.CancelButtonCaption"
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
					"name": "BaseDesignerFooterContainer",
					"parentName": "BaseDesignerContainer",
					"propertyName": "items",
					"values": {
						"id": "BaseDesignerFooterContainer",
						"selectors": {
							"wrapEl": "#BaseDesignerFooterContainer"
						},
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						},
						"items": []
					}
				}
			]
		};
	});
