/**
 * @class GridDesignerTestModule
 * @public
 * Grid designer module (for testing, for demonstration).
 */
/* jshint ignore:start */
define("GridDesignerTestModule", ["BPMSoft", "GridDesignerTestModuleResources", "GridDesigner", "ProfileProvider",
		"EntityStructureHelperMixin"],
	function(BPMSoft) {
		return {
			attributes: {},
			messages: {

				/**
				 * @message PushHistoryState
				 * Notification that history state was modified.
				 */
				"PushHistoryState": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message OnDesignerSaved
				 * Notification that designer was saved.
				 */
				"OnDesignerSaved": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				}

			},
			mixins: {
				EntityStructureHelper: "BPMSoft.EntityStructureHelperMixin"
			},
			methods: {

				/**
				 * Grid designer initialization.
				 * @protected
				 * @virtual
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback scope.
				 */
				init: function(callback, scope) {
					this.callParent([
						function() {
							this.entitySchemaName = "Contact";
							callback.call(scope);
						},
						this
					]);
				},

				/**
				 * Loads the grid settings from the profile for designer.
				 * @protected
				 * @virtual
				 */
				loadGridSettings: function(config) {
					var callback = config.callback;
					var scope = config.scope;
					var profileKey = this.entitySchemaName + "GridSettings";
					BPMSoft.ProfileProvider.load({
						profileKey: profileKey,
						success: function(profile) {
							this.decompressProfile(profile, function(gridSettings) {
								Ext.callback(callback, scope,
									[(!Ext.isEmpty(profile.entitySchemaName)) ? gridSettings : null]);
							});
						},
						failure: function() {
							Ext.callback(callback, scope);
						},
						scope: this
					});
				},

				/**
				 * Saves grid settings into the profile.
				 * @protected
				 * @virtual
				 */
				saveGridSettings: function(config) {
					var profileKey = this.entitySchemaName + "GridSettings";
					var profileData = this.compressProfile(config.profile);
					console.info(JSON.stringify(profileData));
					var profile = Ext.encode(profileData);
					BPMSoft.ProfileProvider.save({
						key: profileKey,
						profile: profile,
						success: config.success,
						failure: config.failure,
						isDef: config.isDefault,
						scope: config.scope
					});
				},

				/**
				 * Shows grid designer.
				 * @protected
				 * @virtual
				 */
				showGridDesigner: function() {
					this.loadGridSettings({
						callback: function(profile) {
							if (!profile) {
								profile = {
									entitySchemaName: this.entitySchemaName,
									gridType: BPMSoft.GridDesignerEnums.GridType.Vertical
								};
							}
							var gridDesignerId =  this.sandbox.id + "GridDesignerModule";
							var params = this.sandbox.publish("GetHistoryState");
							this.sandbox.publish("PushHistoryState", {
								hash: params.hash.historyState,
								"stateObj": {
									"designerSchemaName": "GridDesigner",
									"gridSettings": profile
								},
								silent: true
							});
							this.sandbox.loadModule("ConfigurationModuleV2", {
								renderTo: "centerPanel",
								id: gridDesignerId,
								keepAlive: true
							});
							this.sandbox.subscribe("OnDesignerSaved", function(config) {
								this.saveGridSettings({
									profile: config,
									isDefault: true
								});
							}, this);
						},
						scope: this
					});
				},

				/**
				 * Returns optimized version grid element settings, taking into account the
				 * registry type.
				 * @private
				 */
				compressProfile: function(designerConfig) {
					var gridType = designerConfig.gridType;
					if (gridType === BPMSoft.GridDesignerEnums.GridType.Vertical ||
						gridType === BPMSoft.GridDesignerEnums.GridType.Mobile) {
						delete designerConfig.columns;
						var items = designerConfig.items;
						for (var i = 0, ln = items.length; i < ln; i++) {
							var item = items[i];
							delete item.column;
							delete item.colSpan;
							delete item.rowSpan;
							delete item.content;
						}
					}
					return designerConfig;
				},

				/**
				 * Returns the designer settings with the necessary set of the grid elements properties,
				 * taking into account the registry type.
				 * @private
				 */
				decompressProfile: function(designerConfig, callback) {
					var items = designerConfig.items;
					if (!items || items.length === 0) {
						callback.call(this, designerConfig);
						return;
					}
					var gridType = designerConfig.gridType;
					if (gridType === BPMSoft.GridDesignerEnums.GridType.Vertical ||
						gridType === BPMSoft.GridDesignerEnums.GridType.Mobile) {
						designerConfig.columns = 1;
					}
					var processedItems = 0;
					var self = this;
					var entitySchemaName = designerConfig.entitySchemaName;
					for (var i = 0, count = items.length; i < count; i++) {
						var item = items[i];
						if (gridType === BPMSoft.GridDesignerEnums.GridType.Vertical ||
							gridType === BPMSoft.GridDesignerEnums.GridType.Mobile) {
							item.column = 0;
							item.colSpan = 1;
							item.rowSpan = 1;
						}
						var columnName = item.columnName;
						this.getColumnCaption({
							entitySchemaName: entitySchemaName,
							columnName: columnName,
							key: i,
							callback: function(columnInfo) {
								if (columnInfo) {
									var columnItem = items[columnInfo.key];
									columnItem.content = columnInfo.columnCaption;
								}
								processedItems++;
								if (processedItems === count) {
									callback.call(self, designerConfig);
								}
							}
						});
					}
				},

				/**
				 * Returns the column caption, both simple and compound.
				 * @private
				 */
				getColumnCaption: function(config) {
					var serviceParameter = {
						schemaName: config.entitySchemaName,
						columnPath: config.columnName,
						key: config.key
					};
					var callback = config.callback;
					this.getColumnPathCaption(Ext.JSON.encode([serviceParameter]), function(response) {
						callback.call(this, (response) ? response[0] : null);
					}, this);
				}

			},
			diff: [
				{
					"operation": "insert",
					"name": "GridDesignerModuleContainer",
					"values": {
						"id": "GridDesignerModuleContainer",
						"selectors": {
							"wrapEl": "#GridDesignerModuleContainer"
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
					"name": "GridDesignerModuleContainerHeaderContainer",
					"parentName": "GridDesignerModuleContainerContainer",
					"propertyName": "items",
					"values": {
						"id": "GridDesignerModuleContainerHeaderContainer",
						"selectors": {
							"wrapEl": "#GridDesignerModuleContainerHeaderContainer"
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
					"parentName": "GridDesignerModuleContainerHeaderContainer",
					"propertyName": "items",
					"name": "ShowGridDesignerButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": {
							"bindTo": "Resources.Strings.ShowGridDesignerButtonCaption"
						},
						"classes": {
							"textClass": "actions-button-margin-right"
						},
						"click": {
							"bindTo": "showGridDesigner"
						},
						"style": "orange",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 2
						}
					}
				}
			]
		};
	});
/* jshint ignore:end */
