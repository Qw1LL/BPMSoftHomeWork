define("WidgetGridLayoutEditItemModel", ["GridLayoutEditItemModel", "MaskHelper"], function() {

	/**
	 * @class BPMSoft.configuration.WidgetGridLayoutEditItemModel
	 * Class of WidgetGridLayoutEditItemModel.
	 */
	Ext.define("BPMSoft.configuration.WidgetGridLayoutEditItemModel", {
		extend: "BPMSoft.GridLayoutEditItemModel",
		alternateClassName: "BPMSoft.WidgetGridLayoutEditItemModel",

		/**
		 * Widget type.
		 * @type {String}
		 */
		widgetType: null,

		/**
		 * Widget caption.
		 * @type {String}
		 */
		widgetCaption: null,

		/**
		 * @inheritdoc BPMSoft.DesignTimeItemModel#getImageConfig
		 * @overridden
		 */
		getImageConfig: function() {
			switch (this.widgetType) {
				case "Chart":
					return this.get("Resources.Images.ChartImage");
				case "Indicator":
					return this.get("Resources.Images.MetricImage");
				case "Gauge":
					return this.get("Resources.Images.GaugeImage");
				case "DashboardGrid":
					return this.get("Resources.Images.ListImage");
				case "WebPage":
					return this.get("Resources.Images.WebPageImage");
				default:
					return null;
			}
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getCaption
		 * @overridden
		 */
		getCaption: function() {
			return this.widgetCaption;
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getMessages
		 * @overridden
		 */
		getMessages: function() {
			var designerModuleId = this.getDesignerModuleId();
			return [{
				ownerId: this.instanceId,
				messageName: "PostModuleConfig",
				moduleId: designerModuleId,
				handler: this.onDesignerSave
			}, {
				ownerId: this.instanceId,
				messageName: "WidgetDesignerCancel",
				moduleId: designerModuleId,
				handler: this.onDesignerCancel
			}];
		},

		/**
		 * Designer save event handler.
		 * @protected
		 */
		onDesignerSave: function(widgetConfig) {
			this.set("content", widgetConfig.caption);
			if (this.designSchema.get("ActionLayoutCreate")) {
				this.designSchema.set("ActionLayoutCreate", false);
				this._saveNewWidget(widgetConfig);
			} else {
				this._saveExistingWidget(widgetConfig);
			}
			this.designSchema.sandbox.unloadModule(this.getDesignerModuleId());
			this.designSchema.set("CardWidgetDesignerContainerVisible", false);
		},

		/**
		 * @private
		 */
		_saveNewWidget: function(widgetConfig) {
			var layoutName = this.designSchema.get("ActionLayoutName");
			var collection = this.designSchema.getGridLayoutEditCollection(layoutName);
			collection.add(this.itemConfig.name, this);
			this._addWidgetToSchemaModules();
			this._setWidgetToDashboardManagerItem(widgetConfig);
		},

		/**
		 * @private
		 */
		_saveExistingWidget: function(widgetConfig) {
			var module = this.designSchema.$Schema.modules && this.designSchema.$Schema.modules[this.itemConfig.name];
			var managerItemId = this.designSchema.$WritableWidgetDashboardManagerItem.getId();
			if (!module || BPMSoft.findValueByPath(module, "config.parameters.viewModelConfig.recordId") !== managerItemId) {
				this._addWidgetToSchemaModules();
			}
			this._setWidgetToDashboardManagerItem(widgetConfig);
		},

		/**
		 * @private
		 */
		_addWidgetToSchemaModules: function() {
			if (!this.designSchema.$Schema.modules) {
				this.designSchema.$Schema.modules = {};
			}
			this.designSchema.$Schema.modules[this.itemConfig.name] = {
				moduleId: this.itemConfig.name,
				moduleName: "CardWidgetModule",
				config: {
					parameters: {
						viewModelConfig: {
							widgetKey: this.itemConfig.name,
							recordId: this.designSchema.$WritableWidgetDashboardManagerItem.getId(),
							primaryColumnValue: {getValueMethod: "getPrimaryColumnValue"}
						}
					}
				}
			};
		},

		/**
		 * @private
		 */
		_setWidgetToDashboardManagerItem: function(widgetConfig) {
			this.designSchema.$WritableWidgetDashboardManagerItem.setWidgetItem(this.itemConfig.name, {
				widgetType: this.widgetType,
				parameters: widgetConfig || {}
			});
		},

		/**
		 * Designer cancel event handler.
		 * @protected
		 */
		onDesignerCancel: function() {
			var designSchema = this.designSchema;
			designSchema.sandbox.unloadModule(this.getDesignerModuleId());
			designSchema.set("CardWidgetDesignerContainerVisible", false);
			designSchema.set("ActionLayoutItem", null);
			designSchema.set("ActionLayoutCreate", false);
		},

		/**
		 * Opens widget designer.
		 * @protected
		 */
		openDesigner: function(callback, scope) {
			this.designSchema.set("CardWidgetDesignerContainerVisible", true);
			BPMSoft.MaskHelper.showBodyMask();
			BPMSoft.chain(
				function(next) {
					this.designSchema.initWidgetDashboardManagerItems(next, this);
				},
				function() {
					var designConfig = BPMSoft.DashboardEnums.WidgetType[this.widgetType].design;
					this.designSchema.sandbox.loadModule(designConfig.moduleName, {
						id: this.getDesignerModuleId(),
						renderTo: "CardWidgetDesignerMainContainer",
						instanceConfig: {
							parameters: {
								viewModelConfig: {
									WidgetInitConfig: this._getDesignerInitConfig(),
									UseCurrentState: false
								}
							},
							useHistoryState: false,
							isSchemaConfigInitialized: true,
							schemaName: designConfig.stateConfig.stateObj.designerSchemaName
						},
						callback: function() {
							BPMSoft.MaskHelper.hideBodyMask();
							Ext.callback(callback, scope);
						},
						scope: this
					});
				}, this
			);
		},

		/**
		 * @private
		 */
		_getDesignerInitConfig: function() {

			var primaryDataModel = this.designSchema.dataModelCollection.first() || this.designSchema.$PageSchema;
			var config = {designEntitySchemaName: primaryDataModel.name};
			if (this.designSchema.get("ActionLayoutCreate")) {
				Ext.apply(config, {
					caption: this.widgetCaption,
					sectionId: this.designSchema.$ApplicationStructureItemId,
					relatedObjectCaptionConfig: this.designSchema.getApplicationStructureItemConfig()
				});
			} else {
				var moduleKey = this.itemConfig.name;
				var item = this._getReadableWidgetItemByModuleKey(moduleKey);
				Ext.apply(config, item.parameters);
			}
			return config;
		},

		/**
		 * @private
		 */
		_getReadableWidgetItemByModuleKey: function(moduleKey) {
			var schemaModules = this.designSchema.$Schema.modules || {};
			var modules = this.designSchema.modules || {};
			var module = schemaModules[moduleKey] || modules[moduleKey];
			var config = BPMSoft.findValueByPath(module, "config.parameters.viewModelConfig");
			var managerItem = this.designSchema.$ReadableWidgetDashboardManagerItemCollection.get(config.recordId);
			var item = managerItem.getWidgetItem(config.widgetKey);
			return item;
		},

		/**
		 * Returns card widget designer module id.
		 * @protected
		 * @return {String} Card designer module id.
		 */
		getDesignerModuleId: function() {
			return this.designSchema.sandbox.id + "CardDesigner_Module";
		},

		/**
		 * @private
		 */
		_removeWidgetItemFromModules: function() {
			delete this.designSchema.$Schema.modules[this.itemConfig.name];
		},

		/**
		 * @private
		 */
		_removeWidgetItemFromManagerItem: function() {
			var module = this.designSchema.$Schema.modules[this.itemConfig.name];
			if (module) {
				var widgetKey = BPMSoft.findValueByPath(module, "config.parameters.viewModelConfig.widgetKey");
				if (widgetKey) {
					this.designSchema.$WritableWidgetDashboardManagerItem.removeWidgetItem(widgetKey);
				}
			}
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#createDesignItem
		 * @overridden
		 */
		createDesignItem: function(designSchema, config) {
			var newLayout = designSchema.get(config.layoutName + "Selection");
			var itemConfig = BPMSoft.deepClone(this.itemConfig);
			Ext.apply(itemConfig.layout, newLayout);
			itemConfig.name += BPMSoft.generateGUID();
			delete itemConfig.caption;
			itemConfig.itemType = BPMSoft.ViewItemType.MODULE;
			itemConfig.classes = {wrapClassName: ["card-widget-grid-layout-item"]};
			itemConfig.layout.useFixedColumnHeight = true;
			return Ext.create("BPMSoft.WidgetGridLayoutEditItemModel", {
				designSchema: designSchema,
				itemConfig: itemConfig,
				widgetCaption: this.widgetCaption,
				widgetType: this.widgetType
			});
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#addToDesignSchema
		 * @overridden
		 */
		addToDesignSchema: function(config, callback, scope) {
			var designSchema = this.designSchema;
			designSchema.set("ActionLayoutName", config.layoutName);
			designSchema.set("ActionLayoutItem", this);
			designSchema.set("ActionLayoutCreate", true);
			this.openDesigner(callback, scope);
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#edit
		 * @overridden
		 */
		edit: function(config, callback, scope) {
			var designSchema = this.designSchema;
			designSchema.set("ActionLayoutName", config.layoutName);
			designSchema.set("ActionLayoutItem", this);
			designSchema.set("ActionLayoutCreate", false);
			this.openDesigner(callback, scope);
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#removeFromDesignSchema
		 * @overridden
		 */
		removeFromDesignSchema: function() {
			this.callParent(arguments);
			if (this.designSchema.$Schema.modules) {
				this._removeWidgetItemFromManagerItem();
				this._removeWidgetItemFromModules();
			}
		}
	});

	return BPMSoft.WidgetGridLayoutEditItemModel;
});
