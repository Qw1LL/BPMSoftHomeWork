/**
 * Parent: ViewModelSchemaDesignerSchema
 */
define("MiniPageDesignerSchema", [], function() {
	return {
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_getGetAllModes: function() {
				return [
					BPMSoft.ConfigurationEnums.CardOperation.ADD,
					BPMSoft.ConfigurationEnums.CardOperation.EDIT,
					BPMSoft.ConfigurationEnums.CardOperation.VIEW
				];
			},

			/**
			 * @private
			 */
			_getVisibleItemsForMode: function(items, mode) {
				var oldMode = this.get("Mode");
				this.set("Mode", mode, {silent: true});
				var visibleItems = _.filter(items, function(item) {
					var visible = oldMode === mode;
					var visibleMethod = item.visible && item.visible.bindTo;
					if (visibleMethod && this[visibleMethod]) {
						this.setTrackingState(true);
						this[visibleMethod]();
						this.setTrackingState(false);
						var properties = _.keys(this.dependentProperties);
						if (_.contains(properties, "Mode")) {
							visible = this[visibleMethod]();
						}
					}
					return visible;
				}, this);
				this.set("Mode", oldMode, {silent: true});
				return visibleItems;
			},

			/**
			 * @private
			 */
			_getHiddenLayoutName: function(item) {
				return item.name + "_hidden";
			},

			/**
			 * @private
			 */
			_getHiddenModes: function() {
				var allModes = this._getGetAllModes();
				var currentMode = this.get("Mode");
				var modes = _.filter(allModes, function(mode) {
					return currentMode !== mode;
				}, this);
				return modes;
			},

			/**
			 * @private
			 */
			_updateExistingItemsUsed: function() {
				var usedColumns = this.get("UsedColumns");
				BPMSoft.each(this.dataModelCollection, function(dataModel) {
					var entityDataModel = this.$DataModels.get(dataModel.name);
					var columns = entityDataModel.get("ExistingModelDraggableItems");
					columns.each(function(column) {
						var name = column.get("Name");
						column.set("IsUsed", _.has(usedColumns, name));
					}, this);
				}, this);
			},

			/**
			 * @private
			 */
			_initLocalStore: function() {
				var localStore = BPMSoft.StoreManager.registerStore({
					levelName: "MiniPageDesigner",
					type: "BPMSoft.LocalStore",
					isCache: false
				});
				this.set("LocalStore", localStore);
			},

			/**
			 * @private
			 */
			_initMode: function() {
				var localStore = this.get("LocalStore");
				var mode = localStore.getItem("Mode");
				var modes = this._getGetAllModes();
				if (_.contains(modes, mode)) {
					this.set("Mode", mode);
				} else {
					this.set("Mode", modes[0]);
				}
			},

			/**
			 * @private
			 */
			_saveMode: function() {
				var localStore = this.get("LocalStore");
				var mode = this.get("Mode");
				localStore.setItem("Mode", mode);
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc ViewModelSchemaDesignerSchema#initSchemaBindings
			 * @override
			 */
			initSchemaBindings: function() {
				this.callParent(arguments);
				this._initLocalStore();
				this._initMode();
			},

			/**
			 * @inheritdoc ViewModelSchemaDesignerSchema#createGridLayoutEditCollection
			 * @override
			 */
			createGridLayoutEditCollection: function(config, mode) {
				var collection = new BPMSoft.BaseViewModelCollection();
				var items = this._getVisibleItemsForMode(config.items, mode || this.get("Mode"));
				items = BPMSoft.GridLayoutUtils.fixItemsIntersections(items);
				BPMSoft.each(items, function(item) {
					this.addGridLayoutItemToCollection(collection, item);
				}, this);
				return collection;
			},

			/**
			 * @inheritdoc ViewModelSchemaDesignerSchema#addControlItemToCollection
			 * @override
			 */
			addControlItemToCollection: function(collection, item, config) {
				config = config || {};
				if (item.name === "HeaderContainer") {
					Ext.apply(config, {
						dragActionsCode: 0,
						canRemove: false
					});
				}
				this.callParent([collection, item, config]);
			},

			/**
			 * @inheritdoc ViewModelSchemaDesignerSchema#createDesignSchemaItem
			 * @override
			 */
			createDesignSchemaItem: function(schemaDesignToolItem) {
				var visibleBinding;
				if (this.isAddMode()) {
					visibleBinding = {bindTo: "isAddMode"};
				} else if (this.isEditMode()) {
					visibleBinding = {bindTo: "isEditMode"};
				} else if (this.isViewMode()) {
					visibleBinding = {bindTo: "isViewMode"};
				} else {
					visibleBinding = true;
				}
				Ext.apply(schemaDesignToolItem.internalItem.itemConfig, {
					isMiniPageModelItem: true,
					visible: visibleBinding
				});
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc ViewModelSchemaDesignerSchema#applyGridLayoutEditItems
			 * @override
			 */
			applyGridLayoutEditItems: function(schemaView) {
				this.callParent(arguments);
				var collections = BPMSoft.deepClone(this.get("GridLayoutsHidden") || []);
				var gridLayouts = this.getGridLayoutsByCollections(collections);
				BPMSoft.iterateChildItems(schemaView, function(iterationConfig) {
					var schemaItem = iterationConfig.item;
					var layoutName = this._getHiddenLayoutName(schemaItem);
					var schemaItemConfigItems = gridLayouts[layoutName];
					if (!Ext.isEmpty(schemaItemConfigItems) || Ext.isArray(schemaItemConfigItems)) {
						schemaItem.items = schemaItem.items.concat(schemaItemConfigItems);
					}
				}, this);
			},

			/**
			 * @inheritdoc ViewModelSchemaDesignerSchema#initGridLayoutItemsCollection
			 * @override
			 */
			initGridLayoutItemsCollection: function() {
				this.callParent(arguments);
				this.set("GridLayoutsHidden", []);
				var schemaView = this.get("SchemaView");
				BPMSoft.iterateChildItems(schemaView, function(iterationConfig) {
					var item = iterationConfig.item;
					if (item.itemType === BPMSoft.ViewItemType.GRID_LAYOUT) {
						var itemsCollectionName = this.getGridLayoutEditCollectionName(item);
						var items = this.get(itemsCollectionName);
						var hiddenItems = new BPMSoft.BaseViewModelCollection();
						var modes = this._getHiddenModes();
						modes.forEach(function(mode) {
							var modeItems = this.createGridLayoutEditCollection(item, mode);
							modeItems.eachKey(function(name, item) {
								if (!hiddenItems.contains(name) && !items.contains(name)) {
									hiddenItems.add(name, item);
								}
							}, this);
						}, this);
						var layoutName = this._getHiddenLayoutName(item);
						var hiddenItemsCollectionName = this.getGridLayoutEditCollectionName(layoutName);
						this.set(hiddenItemsCollectionName, hiddenItems);
						this.get("GridLayoutsHidden").push(layoutName);
					}
				}, this);
			},

			/**
			 * @inheritdoc ViewModelSchemaDesignerSchema#modifyDraggableConfigByLayoult
			 * @override
			 */
			modifyDraggableConfigByLayoult: function(config) {
				if (config) {
					config.colSpan = 24;
				}
			},

			/**
			 * @inheritdoc ViewModelSchemaDesignerSchema#asyncValidate
			 * @override
			 */
			asyncValidate: function(callback, scope) {
				callback.call(scope, true);
			},

			/**
			 * Handler for mode switch buttons. Changes mode depends on CardOperation in tag.
			 * @protected
			 */
			onModeSwitchChange: function() {
				this.applyGridLayoutEditItems(this.get("SchemaView"));
				this.set("Mode", arguments[3]);
				this.initGridLayoutItemsCollection();
				this._updateExistingItemsUsed();
				this.onSchemaChanged();
				this._saveMode();
			}

			// endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "DesignContainer",
				"name": "ModeSwitchContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["mode-switch-container"],
					"items": [
						{
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"name": "AddModeButton",
							"click": {"bindTo": "onModeSwitchChange"},
							"caption": {"bindTo": "Resources.Strings.AddModeCaption"},
							"pressed": {"bindTo": "isAddMode"},
							"tag": BPMSoft.ConfigurationEnums.CardOperation.ADD
						},
						{
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"name": "EditModeButton",
							"click": {"bindTo": "onModeSwitchChange"},
							"caption": {"bindTo": "Resources.Strings.EditModeCaption"},
							"pressed": {"bindTo": "isEditMode"},
							"tag": BPMSoft.ConfigurationEnums.CardOperation.EDIT
						},
						{
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"name": "ViewModeButton",
							"click": {"bindTo": "onModeSwitchChange"},
							"caption": {"bindTo": "Resources.Strings.ViewModeCaption"},
							"pressed": {"bindTo": "isViewMode"},
							"tag": BPMSoft.ConfigurationEnums.CardOperation.VIEW
						}
					]
				}
			},
			{
				"operation": "remove",
				"name": "EditButtonsContainer"
			},
			{
				"operation": "remove",
				"name": "RequiredColumnsContainer"
			}
		]/**SCHEMA_DIFF*/
	};
});
