define("ViewModelSchemaDesignerSchema", [
	"MaskHelper",
	"ColumnHelper",
	"ModalBox",
	"ViewModelSchemaDesignerUtils",
	"ContainerListGenerator",
	"ContainerList",
	"ViewModelSchemaDesignerItem",
	"css!ViewModelSchemaDesignerItem",
	"ImageCustomGeneratorV2",
	"DetailManager",
	"ImageCustomGeneratorV2",
	"ViewModelSchemaDesignerTabModalBox",
	"DesignTimeReorderableItemModel",
	"NewColumnGridLayoutEditItemModel",
	"ExistingColumnGridLayoutEditItemModel",
	"ControlGridLayoutEditItemModel",
	"WidgetGridLayoutEditItemModel",
	"AngularGridLayoutEditItemModel",
	"SchemaDesignToolItem",
	"SchemaColumnDesignToolItem",
	"SchemaParameterDesignToolItem",
	"SchemaButtonDesignToolItem",
	"SchemaWidgetDesignToolItem",
	"SchemaAngularDesignToolItem",
	"EntityDataSourceViewModel",
	"ParameterDataSourceViewModel",
	"ElementDataSourceViewModel",
	"TooltipUtilities"
], function(MaskHelper, ColumnHelper, ModalBox) {
	return {
		mixins: {
			TooltipUtilities: "BPMSoft.TooltipUtilities",
		},
		messages: {
			"GetModuleInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"OnDesignerSaved": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"GetColumnConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"GetModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"AngularModulesConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"GetModuleConfigResult": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"Validate": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"ValidationResult": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"GetNewLookupPackageUId": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"GetPackageUId": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"Save": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"SavingResult": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"GetSchemaColumnsNames": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"GetEntitySchemaName": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"GetDesignerDisplayConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"SaveTabConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"SaveControlGroupConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"SaveDetailConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * Fires when card widget design mode was canceled.
			 */
			"WidgetDesignerCancel": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * Returns card widget parameters which was designed.
			 */
			"PostModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"SaveDataModel": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			"OnAfterSave": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetControlGroupConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetDetailConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetTabConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"SaveWizard": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"OpenDetailDesigner": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.BIDIRECTIONAL
			},
			"ReInitializeDetail": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
			"onAngularDesignerSave": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
		},
		attributes: {

			/**
			 * Collection of existing columns for drag and drop.
			 */
			ExistingModelDraggableItems: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * Collection of existing parameters for drag and drop.
			 */
			ExistingParameterDraggableItems: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * Collection of types new columns for drag and drop.
			 */
			NewModelDraggableItems: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * Collection of types new parameters for drag and drop.
			 */
			NewParametersDraggableItems: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * Collection of types new widgets for drag and drop.
			 */
			NewWidgetsModelDraggableItems: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * Collection of types new widgets for drag and drop.
			 */
			ExistingAngularModelDraggableItems: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * Related profiles collection.
			 */
			RelatedProfileItems: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			/**
			 * Related profiles reorder index.
			 */
			RelatedProfileReorderableIndex: {dataValueType: BPMSoft.DataValueType.INTEGER},

			/**
			 * Novelty tab sign.
			 */
			IsNewTab: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

			/**
			 * Changing control group caption.
			 */
			ChangingControlGroupName: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: null
			},

			/**
			 * Editable detail entity schema object.
			 */
			editableDetailEntitySchema: {dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT},

			/**
			 * Default widget module name.
			 */
			DefaultWidgetModuleName: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: "CardWidgetModule"
			},

			/**
			 * Writable widget dashboard manager item.
			 */
			WritableWidgetDashboardManagerItem: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Readable widget dashboard manager items.
			 */
			ReadableWidgetDashboardManagerItemCollection: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Card designer container visible.
			 */
			CardWidgetDesignerContainerVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			MessageMap: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				value: null
			},

			/**
			 * Current editing client unit schema.
			 */
			PageSchema: {dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT},

			/**
			 * Primary entity schema name.
			 */
			EntitySchemaName: {dataValueType: BPMSoft.DataValueType.TEXT},

			/**
			 * Application structure item id.
			 */
			ApplicationStructureItemId: {dataValueType: BPMSoft.DataValueType.GUID},



			/**
			 * Design data models.
			 */
			DataModels: {dataValueType: BPMSoft.DataValueType.COLLECTION},

			EditDataModelName: {dataValueType: BPMSoft.DataValueType.TEXT},

			/**
			 * Flag that indicates init process.
			 */
			Initializing: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Flag that indicates whether designer supports parameters data model.
			 */
			SupportParametersDataModel: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			AngularModules: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			AngularModulesCollection: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Is current page registered as SSP section page.
			 */
			IsSspSection: {dataValueType: BPMSoft.DataValueType.BOOLEAN},

			/**
			 * Collection of used lookup columns.
			 */
			UsedLookupColumns: {dataValueType: BPMSoft.DataValueType.COLLECTION}
		},
		properties: {
			/**
			 * @private
			 * @type {String[]}
			 */
			_newItemNames: null,
			/**
			 * @private
			 * @type {String}
			 */
			_detailId: null
		},
		methods: {

			//region Methods: Private

			/**
			 * Removes data model from design schema by the specified name.
			 * @private
			 */
			_removeDataModelFromSchema: function(name) {
				const dataModels = this.$Schema.dataModels || {};
				delete dataModels[name];
			},

			/**
			 * @private
			 */
			onGetDataSourcePageData: function() {
				return {
					schemaName: "DataSourcePropertiesPage",
					DataModelName: this.$EditDataModelName,
					Designer: this
				};
			},

			/**
			 * @private
			 */
			_parseItemBindTo: function(bindTo) {
				const path = bindTo.split(".");
				let dataModel;
				let schemaColumn;
				if (path.length === 2) {
					dataModel = this.$DataModels.find(path[0]);
					if (dataModel) {
						schemaColumn = dataModel.get("Schema").columns.findByPath("name", path[1]);
					}
				}
				this.$DataModels.each(function(item) {
					if (item.get("Name") === "Elements") {
						return;
					}
					if (!schemaColumn) {
						schemaColumn = item.get("Schema").columns.findByPath("name", bindTo);
						dataModel = schemaColumn ? item : null;
					}
				}, this);
				return {
					dataModel: dataModel,
					schemaColumn: schemaColumn
				};
			},

			/**
			 * @private
			 */
			_safeCallMethod: function(methodName) {
				const method = this[methodName];
				if (method) {
					method.call(this);
				}
			},

			/**
			 * @private
			 */
			_initEvents: function() {
				this.addEvents(
					/**
					 * @event schemaChanged
					 * It works when need to refresh the view.
					 * @param {Array} diff Array of diffs.
					 */
					"schemaChanged"
				);
			},

			/**
			 * @private
			 */
			_getSchemaProperty: function(propertyName, defaultValue) {
				const designSchemaPropertyValue = this.get("Schema")[propertyName] || defaultValue;
				const schemaPropertyValue = this[propertyName] || defaultValue;
				return Ext.apply(BPMSoft.deepClone(schemaPropertyValue), designSchemaPropertyValue);
			},

			/**
			 * @private
			 */
			_getSchemaDetails: function() {
				return this._getSchemaProperty("details", {});
			},

			/**
			 * @private
			 */
			_getSchemaDetail: function(detailName) {
				return this._getSchemaDetails()[detailName];
			},

			/**
			 * @private
			 */
			_getSchemaModules: function() {
				return this._getSchemaProperty("modules", {});
			},

			/**
			 * @private
			 */
			_getSchemaModule: function(moduleName) {
				return this._getSchemaModules()[moduleName];
			},

			/**
			 * @private
			 */
			_initEmptyInfoImageSrc: function() {
				const emptyInfoImage = this.get("Resources.Images.EmptyInfoImage");
				this.set("EmptyInfoImageSrc", BPMSoft.ImageUrlBuilder.getUrl(emptyInfoImage));
			},

			/**
			 * @private
			 */
			_loadPageSchemaConfig: function(next, scope) {
				this.sandbox.subscribe("GetModuleConfigResult", function(config) {
					this.onGetModuleConfigResult(config, next, scope);
				}, this, [this.sandbox.id]);
				this.sandbox.publish("GetModuleConfig", null, [this.sandbox.id]);
			},

			/**
			 * @private
			 */
			_initWritableWidgetDashboardManagerItem: function() {
				return new Promise(
					function(resolve) {
						const managerItemId = this._getWidgetDashboardManagerItemIds(this.$Schema.modules || {})[0];
						if (managerItemId) {
							const item = BPMSoft.WidgetDashboardManager.getItem(managerItemId);
							item.loadLazyPropertiesData(function() {
								resolve(item);
							}, this);
						} else {
							BPMSoft.WidgetDashboardManager.createItem(null, function(createdItem) {
								BPMSoft.WidgetDashboardManager.addItem(createdItem);
								resolve(createdItem);
							}, this);
						}
					}.bind(this)
				).then(
					function(item) {
						this.$WritableWidgetDashboardManagerItem = item;
					}.bind(this)
				);
			},

			/**
			 * @private
			 */
			_initReadableWidgetDashboardItemCollection: function() {
				const managerItemIds = this._getWidgetDashboardManagerItemIds(this._getSchemaModules());
				const promise = BPMSoft.WidgetDashboardManager.loadLazyPropertiesDataForItems(managerItemIds);
				return promise.then(
					function(items) {
						const collection = Ext.create("BPMSoft.Collection");
						items.forEach(function(item) {
							collection.add(item.getId(), item);
						}, this);
						const writableItem = this.$WritableWidgetDashboardManagerItem;
						if (writableItem.getIsNew()) {
							collection.addIfNotExists(writableItem.getId(), writableItem);
						}
						this.$ReadableWidgetDashboardManagerItemCollection = collection;
					}.bind(this)
				);
			},

			/**
			 * @private
			 */
			_getWidgetDashboardManagerItemIds: function(schemaModules) {
				const itemIds = [];
				BPMSoft.each(schemaModules, function(module) {
					const itemId = BPMSoft.findValueByPath(module, "config.parameters.viewModelConfig.recordId");
					if (itemId && BPMSoft.WidgetDashboardManager.contains(itemId) && !_.contains(itemIds, itemId)) {
						itemIds.push(itemId);
					}
				}, this);
				return itemIds.sort();
			},

			/**
			 * @private
			 */
			_initDetailsCaptionsAsync: function(callback, scope) {
				const notFilledDetailKeys = this._fillDetailCaptionsFromPageResources();
				if (notFilledDetailKeys.length > 0) {
					this._fillDetailCaptionsFromDetailResources(notFilledDetailKeys, callback, scope);
				} else {
					Ext.callback(callback, scope);
				}
			},

			/**
			 * @private
			 */
			_fillDetailCaptionsFromPageResources: function() {
				const schemaDetails = this._getSchemaDetails();
				const keys = [];
				BPMSoft.each(schemaDetails, function(detail, key) {
					const isRegisteredDetail = this._isRegisteredDetail(detail);
					const caption = this._generateDetailCaptionFromPageResource(key, isRegisteredDetail);
					if (caption) {
						this.set(this.getDetailCaptionResourcesName(key), caption);
					} else {
						keys.push(key);
					}
				}, this);
				BPMSoft.each(keys, function(key) {
					const format = this.get(this._getDetailCaptionTemplateResourceName(true));
					const caption = Ext.String.format(format, key);
					this.set(this.getDetailCaptionResourcesName(key), caption);
				}, this);
				return keys;
			},

			/**
			 * @private
			 */
			_getNotFilledDetailManagerItems: function(notFilledDetailKeys, schemaDetails) {
				const managerItems = BPMSoft.ClientUnitSchemaManager.getItems();
				const notFilledDetailManagerItems = [];
				BPMSoft.each(notFilledDetailKeys, function(detailKey) {
					const schemaName = schemaDetails[detailKey].schemaName;
					const hasSchema = notFilledDetailManagerItems.some(function(item) {
						return item.getName() === schemaName;
					});
					if (!hasSchema) {
						const managerItem = managerItems.firstOrDefault(function(item) {
							return item.getName() === schemaName && !item.getExtendParent();
						}, this);
						if (managerItem) {
							notFilledDetailManagerItems.push(managerItem);
						}
					}
				}, this);
				return notFilledDetailManagerItems;
			},

			/**
			 * @private
			 */
			_fillDetailCaptionsFromDetailResources: function(notFilledDetailKeys, callback, scope) {
				const schemaDetails = this._getSchemaDetails();
				const notFilledDetailManagerItems =
					this._getNotFilledDetailManagerItems(notFilledDetailKeys, schemaDetails);
				const currentPackageUId = this.getPackageUId();
				const promiseChain = notFilledDetailManagerItems.map(function(item) {
					const config = {schemaUId: item.uId, packageUId: currentPackageUId};
					return new Promise(function(resolve) {
						BPMSoft.ClientUnitSchemaManager.findBundleSchemaInstance(config, function(instance) {
							resolve(instance);
						}, this);
					}.bind(this));
				}, this);
				Promise.all(promiseChain).then(function(instances) {
					BPMSoft.each(notFilledDetailKeys, function(detailKey) {
						const detail = schemaDetails[detailKey];
						const designSchema = instances.filter(function(instance) {
							return instance.name === detail.schemaName;
						})[0];
						let caption = "";
						if (designSchema && designSchema.localizableStrings.contains("Caption")) {
							caption = this._generateDetailCaptionFromDetailResource(
								designSchema,
								this._isRegisteredDetail(detail));
						} else {
							caption = Ext.String.format(this.get(
								this._getDetailCaptionTemplateResourceName(false)),
								detailKey);
						}
						this.set(this.getDetailCaptionResourcesName(detailKey), caption);
					}, this);
					Ext.callback(callback, scope);
				}.bind(this));
			},

			/**
			 * @private
			 */
			_isRegisteredDetail: function(detail) {
				const managerItems = BPMSoft.DetailManager.getItems();
				const detailManagerItem = managerItems.firstOrDefault(function(item) {
					return item.getDetailSchemaName() === detail.schemaName &&
						(!detail.entitySchemaName || item.getEntitySchemaName() === detail.entitySchemaName);
				}, this);
				return !Ext.isEmpty(detailManagerItem);
			},

			/**
			 * @private
			 */
			_getDetailCaptionTemplateResourceName: function(isRegisteredDetail) {
				return isRegisteredDetail
					? "Resources.Strings.DesignerDetailCaption"
					: "Resources.Strings.DesignerUnregisteredDetailCaption";
			},

			/**
			 * @private
			 */
			_generateDetailCaptionFromPageResource: function(detailKey, isRegisteredDetail) {
				const resourceName = BPMSoft.ViewModelSchemaDesignerUtils.generateDetailCaptionResourcesName(detailKey);
				const caption = this.get("Resources.Strings." + resourceName);
				const captionTemplateResourceName = this._getDetailCaptionTemplateResourceName(isRegisteredDetail);
				return caption ? Ext.String.format(this.get(captionTemplateResourceName), caption) : null;
			},

			/**
			 * @private
			 */
			_generateDetailCaptionFromDetailResource: function(designSchema, isRegisteredDetail) {
				const captionTemplateResourceName = this._getDetailCaptionTemplateResourceName(isRegisteredDetail);
				return Ext.String.format(this.get(captionTemplateResourceName), designSchema.localizableStrings.get("Caption"));
			},

			/**
			 * @private
			 */
			_getExistingModelDraggableItems: function(designSchema, dataModel) {
				const items = Ext.create("BPMSoft.BaseViewModelCollection");
				this.loadColumnsCollection(items, designSchema.columns,
					"BPMSoft.ExistingColumnGridLayoutEditItemModel", dataModel);
				items.on("itemChanged", this.draggableItemChanged, this);
				return items;
			},

			/**
			 * @private
			 */
			_getNewModelColumnConfig: function (columnClassName, type, typeName) {
				let dataValueType = type.dataValueType;
				let caption = type.caption;
				if (type === ColumnHelper.Type.DATE) {
					dataValueType = BPMSoft.DataValueType.DATE_TIME;
					caption = BPMSoft.data.constants.DataValueTypeConfig.DATE_TIME.displayValue;
					typeName = "DATETIME";
				}
				if (type === ColumnHelper.Type.STRING) {
					dataValueType = BPMSoft.DataValueType.MEDIUM_TEXT;
				}
				const columnConfig = {
					uId: BPMSoft.generateGUID(),
					name: typeName,
					dataValueType: dataValueType,
					status: BPMSoft.ModificationStatus.NEW
				};
				if (columnClassName === "BPMSoft.EntitySchemaColumn") {
					columnConfig.isValueCloneable = true;
				}
				columnConfig.caption = caption;
				return columnConfig;
			},

			/**
			 * @private
			 */
			_getNewModelDraggableItems: function(model, columnClassName) {
				const columns = Ext.create("BPMSoft.Collection");
				const result = Ext.create("BPMSoft.BaseViewModelCollection");
				BPMSoft.each(ColumnHelper.Type, function(type, typeName) {
					const columnConfig = this._getNewModelColumnConfig(columnClassName, type, typeName);
					const column = Ext.create(columnClassName, columnConfig);
					columns.add(column.uId, column);
				}, this);

				this.loadColumnsCollection(result, columns, "BPMSoft.NewColumnGridLayoutEditItemModel", model);
				result.on("itemChanged", this.draggableItemChanged, this);
				return result;
			},

			/**
			 * @private
			 */
			_onDraggableItemsCollapsedChanged: function(model, value) {
				if (!value) {
					this.set("ElementsCollapsed", true);
					this.$DataModels.each(function(dataViewModel) {
						if (model.get("Name") !== dataViewModel.get("Name")) {
							dataViewModel.set("Collapsed", true);
						}
					}, this);
				}
			},

			/**
			 * @private
			 */
			_initDataModelsDesignSchema: function(callback, scope) {
				const packageUId = this.getPackageUId();
				const items = this.dataModelCollection.getItems();
				BPMSoft.eachAsync(items, function(dataModel, next) {
						BPMSoft.EntitySchemaManager.forceGetPackageSchema({
							schemaUId: dataModel.schema.uId,
							packageUId: packageUId
						}, function(entitySchema) {
							this._prepareDesignEntitySchema(entitySchema);
							dataModel.designSchema = entitySchema;
							next();
						}, this);
					},
					function() {
						Ext.callback(callback, scope);
					}, this
				);
			},

			/**
			 * @private
			 */
			_prepareDesignEntitySchema: function(entitySchema) {
				if (!BPMSoft.EntitySchemaManager.contains(entitySchema.uId)) {
					if (entitySchema.extendParent) {
						entitySchema.on("changed", this._onEntitySchemaChange, this);
					} else {
						BPMSoft.EntitySchemaManager.addSchema(entitySchema);
					}
				}
			},

			/*
			 * @private
			 */
			_onEntitySchemaChange: function(changes, entitySchema) {
				if (!BPMSoft.EntitySchemaManager.findItem(entitySchema.uId)) {
					BPMSoft.EntitySchemaManager.addSchema(entitySchema);
				}
			},

			/**
			 * @private
			 */
			_createElementsDataModel: function() {
				this.$DataModels.add("Elements", Ext.create("BPMSoft.ElementDataSourceViewModel", {
					values: {
						Schema: this.$PageSchema
					}
				}));
			},

			/**
			 * @private
			 */
			_createParametersDataModel: function() {
				if (!this.get("SupportParametersDataModel")) {
					return;
				}
				this.$DataModels.add("Parameters", Ext.create("BPMSoft.ParameterDataSourceViewModel", {
					values: {
						Schema: this.$PageSchema,
						NewModelDraggableItems: this.get("NewParametersDraggableItems")
					}
				}));
			},

			/**
			 * @private
			 */
			_createEntityDataModels: function() {
				return this.dataModelCollection.map((dataModel) => this.createEntityDataModel(dataModel));
			},

			/**
			 * @protected
			 */
			createEntityDataModel: function(dataModel) {
				const designSchema = dataModel.designSchema;
				this._prepareDesignEntitySchema(designSchema);
				const resourceName = dataModel.name + "DataModelCaption";
				const resourceString = this.$PageSchema.localizableStrings.find(resourceName);
				const caption = (resourceString || designSchema.caption).toString();
				const canAddNewColumn = designSchema.canDesignSchema();
				this.set(dataModel.name + "Collapsed", true);
				const viewModel = Ext.create("BPMSoft.EntityDataSourceViewModel", {
					values: {
						EntitySchemaUId: dataModel.schema.uId,
						Name: dataModel.name,
						Caption: caption,
						Schema: designSchema,
						CanAddNewColumn: canAddNewColumn,
						IsPrimary: dataModel.isPrimary,
						DataModelMenu: this._createEntityDataModelMenu(),
						IsDataModelMenuVisible: false,
						Designer: this
					}
				});
				return viewModel;
			},

			/**
			 * @private
			 */
			_createEntityDataModelMenu: function() {
				const menuItems = Ext.create("BPMSoft.BaseViewModelCollection");
				const editMenuItem = Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Caption: this.get("Resources.Strings.DataModelEditMenuItem"),
						Click: {"bindTo": "onEditDataSourceClick"},
						MarkerValue: "Edit"
					}
				});
				const removeMenuItem = Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Caption: this.get("Resources.Strings.DataModelRemoveMenuItem"),
						Click: {"bindTo": "onRemoveDataSourceClick"},
						MarkerValue: "Remove"
					}
				});
				menuItems.addItem(editMenuItem);
				menuItems.addItem(removeMenuItem);
				return menuItems;
			},

			/**
			 * @private
			 */
			_initParametersDraggableItems: function() {
				if (!this.get("SupportParametersDataModel")) {
					return;
				}
				const dataModel = this.$DataModels.get("Parameters");
				const newItems = this._getNewModelDraggableItems(dataModel, "BPMSoft.ClientUnitSchemaParameter");
				const existingItems = this._getExistingModelDraggableItems(this.$PageSchema, dataModel);
				dataModel.set("NewModelDraggableItems", newItems);
				dataModel.set("ExistingModelDraggableItems", existingItems);
			},

			/**
			 * @private
			 */
			_initEntityDataModelsDraggableItems: function(entityDataModels) {
				BPMSoft.each(this.dataModelCollection, function(dataModel) {
					const entityDataModel = entityDataModels.findByAttr('Name', dataModel.name);
					this._initDataModelDraggableItem(dataModel, entityDataModel);
				}, this);
			},

			/**
			 * @private
			 */
			_initDataModelDraggableItem: function(dataModel, entityDataModel) {
				const entitySchema = dataModel.designSchema;
				const newItems = this._getNewModelDraggableItems(entityDataModel, "BPMSoft.EntitySchemaColumn");
				const existingItems = this._getExistingModelDraggableItems(entitySchema, entityDataModel);
				entityDataModel.set("NewModelDraggableItems", newItems);
				entityDataModel.set("ExistingModelDraggableItems", existingItems);
			},

			/**
			 * @private
			 */
			_initDataModels: function(callback, scope) {
				this.$DataModels = Ext.create("BPMSoft.BaseViewModelCollection");
				this._createElementsDataModel();
				this._createParametersDataModel();
				const entityDataModels = this._createEntityDataModels();
				BPMSoft.each(entityDataModels, (dataModel) => this.$DataModels.add(dataModel.$Name, dataModel));
				this.initGridLayoutItemsCollection();
				this._initParametersDraggableItems();
				this._initEntityDataModelsDraggableItems(entityDataModels);
				BPMSoft.defer(function() {
					this.initNewWidgetsModelDraggableItems();
					this.initAngularModelDraggableItems();
				}, this);
				this._initDataModelsCollapsed();
				Ext.callback(callback, scope);
			},

			/**
			 * @private
			 */
			_saveModelsCollapsed: function() {
				const profile = {};
				this.$DataModels.each(function(model) {
					const modelName = model.get("Name");
					profile[modelName] = model.get("Collapsed");
				}, this);
				const profileKey = this.getProfileKey();
				BPMSoft.DomainCache.setItem(profileKey, {modelsCollapsed: profile});
			},

			/**
			 * @private
			 */
			_initDataModelsCollapsed: function() {
				const profile = BPMSoft.DomainCache.getItem(this.getProfileKey()) || {};
				const modelsCollapsed = profile.modelsCollapsed || {};
				let expandedCount = 0;
				this.$DataModels.each(function(model) {
					const modelName = model.get("Name");
					const collapsed = modelsCollapsed.hasOwnProperty(modelName) ? modelsCollapsed[modelName] : true;
					if (!collapsed) {
						expandedCount++;
					}
					this._setCollapsedDataModel(modelName, collapsed);
				}, this);
				if (expandedCount === 0) {
					this._initDefaultExpandedDataModel();
				}
			},

			/**
			 * @private
			 */
			_initDefaultExpandedDataModel: function() {
				const defaultDataModel = this.dataModelCollection.first();
				const modelName = (defaultDataModel && defaultDataModel.name) || "Parameters";
				this._setCollapsedDataModel(modelName, false);
			},

			/**
			 * @private
			 */
			_setCollapsedDataModel: function(name, collapsed) {
				const model = this.$DataModels.find(name);
				if (model) {
					model.set("Collapsed", collapsed);
				}
			},

			/**
			 * @private
			 */
			_isWidgetItem: function(moduleKey) {
				const widgetModule = this._getSchemaModule(moduleKey);
				if (!widgetModule) {
					return false;
				}
				const config = BPMSoft.findValueByPath(widgetModule, "config.parameters.viewModelConfig");
				if (!config || !this.$ReadableWidgetDashboardManagerItemCollection.contains(config.recordId)) {
					return false;
				}
				const managerItem = this.$ReadableWidgetDashboardManagerItemCollection.get(config.recordId);
				return Ext.isObject(managerItem.getWidgetItem(config.widgetKey));
			},

			/**
			 * @private
			 */
			_addWidgetItemToCollection: function(collection, item) {
				const widgetModule = this._getSchemaModule(item.name);
				const config = BPMSoft.findValueByPath(widgetModule, "config.parameters.viewModelConfig");
				const managerItem = this.$ReadableWidgetDashboardManagerItemCollection.get(config.recordId);
				const widget = managerItem.getWidgetItem(config.widgetKey);
				collection.add(item.name, Ext.create("BPMSoft.WidgetGridLayoutEditItemModel", {
					designSchema: this,
					itemConfig: item,
					widgetType: widget.widgetType,
					widgetCaption: widget.parameters && widget.parameters.caption
				}));
			},

			getClassSuffix: function (classList, prefix) {
				var classString = classList.find(function(className) {
					return className.startsWith(prefix);
				});
				return classString ? classString.split(prefix)[1] : null;
			},

			addAngularItemToCollection: function(collection, item) {
				var isSchemaNew = this.$PageSchema.isNew();
				console.log("isSchemaNew", isSchemaNew);

				var combinedResults = this.get('AngularModules');
				if (!combinedResults) {
					console.error('combinedResults is undefined');
					return;
				}

				var sysSchemaUId = this.getClassSuffix(item.classes.wrapClassName, 'sysSchemaUId-');
				var appWrapperId = this.getClassSuffix(item.classes.wrapClassName, 'uniqueGuid-');
				var appBuildData = combinedResults[sysSchemaUId];

				if (!appBuildData) {
					item.angularParameters = [];
					return;
				}

				var appWrapperData = appBuildData.appWrappers[appWrapperId];

				if (!appWrapperData) {
					item.angularParameters = [];
					return;
				}

				 // Объединение данных из BPMSoft.angularDesignerObj.angularModules с appWrappers в combinedResults
				 if (BPMSoft.angularDesignerObj && BPMSoft.angularDesignerObj.angularModules) {
					BPMSoft.angularDesignerObj.angularModules.forEach((angularModule) => {
						var targetSysSchemaUId = angularModule.sysSchemaUId;
						var targetAppWrapperUId = angularModule.appWrapperUId;
						
						if (combinedResults[targetSysSchemaUId]) {
							if (!combinedResults[targetSysSchemaUId].appWrappers) {
								combinedResults[targetSysSchemaUId].appWrappers = {};
							}
		
							// Добавляем appWrapper только если он не существует
							if (!combinedResults[targetSysSchemaUId].appWrappers[targetAppWrapperUId]) {
								combinedResults[targetSysSchemaUId].appWrappers[targetAppWrapperUId] = this.createAppWrapperItem(angularModule);
							}
						}
					});
				}

				item.angularParameters = appWrapperData.params;
				item.displayValue = appWrapperData.displayValue;
				item.sysSchemaId = appBuildData.sysSchemaId;
				item.existName = appBuildData.fileName;
				item.appWrapperUId = appWrapperData.uId;
				item.sysSchemaUId = appBuildData.sysSchemaUId;
				item.isParent = appWrapperData.isParent;

				collection.add(item.name, Ext.create("BPMSoft.AngularGridLayoutEditItemModel", {
					designSchema: this,
					itemConfig: item,
					itemCaption: appWrapperData.displayValue
				}));
			},

			createAppWrapperItem: function(angularModule) {
				// Создание нового объекта appWrapper на основе данных из angularModule
				var newItem = {
					...angularModule,
					displayValue: angularModule.displayValue,
					params: angularModule.angularParameters,
				};
				return newItem;
			},
			
			/**
			 * @private
			 */
			_getColumnItemDesignerName: function(viewModel) {
				return viewModel && viewModel.$Name === "Parameters"
					? "ClientUnitSchemaModelItemDesigner"
					: "SchemaModelItemDesigner";
			},

			/**
			 * @private
			 */
			_getExistedNames: function (excludedName) {
				const existedNames = [];
				const tabCollection = this.get("TabsCollection");
				tabCollection.each((tabItem) => {
					existedNames.push(tabItem.$Name);
					const items = tabItem.$Content;
					existedNames.push(...items.getKeys());
				}, this);

				existedNames.push(...Object.keys(this.$UsedColumns));
				return existedNames.filter((item) => item !== excludedName);
			},

			/**
			 * @private
			 */
			_canEditName: function(isNew, name) {
				return isNew || this._newItemNames.includes(name);
			},

			/**
			 * @private
			 */
			_getControlGroupConfig: function() {
				const controlGroupName = this.get("ChangingControlGroupName");
				const name = controlGroupName || this._getNewGroupName();
				return {
					name,
					captionResourcesName: this.getCaptionResourcesName(controlGroupName),
					pageSchema: this.$PageSchema,
					existedNames: this._getExistedNames(name),
					canEditName: this._canEditName(!controlGroupName, name)
				};
			},

			/**
			 * @private
			 */
			_getTabConfig: function() {
				const name = this.$IsNewTab ? this._getNewTabName() : this.get("ActiveTabName");
				const existedNames = this._getExistedNames(name);
				return {
					name,
					captionResourcesName: this.getCaptionResourcesName(name),
					pageSchema: this.$PageSchema,
					existedNames,
					canEditName: this._canEditName(this.$IsNewTab, name)
				};
			},

			/**
			 * @private
			 */
			_openGroupSetting: function() {
				const moduleId = this.getControlGroupModalBoxWindowId();
				const renderTo = ModalBox.show({
					widthPixels: 550,
					heightPixels: 383,
					allowClickPropagation: true
				}, function() {
					this.sandbox.unloadModule(moduleId);
				}, this);
				this.sandbox.loadModule("ControlGroupPropertiesPageModule", {
					id: moduleId,
					renderTo: renderTo
				});
			},

			/**
			 * @private
			 */
			_openTabSetting: function() {
				const moduleId = this.getTabModalBoxWindowId();
				const renderTo = ModalBox.show({
					widthPixels: 550,
					heightPixels: 383,
					allowClickPropagation: true
				}, function() {
					this.sandbox.unloadModule(moduleId);
				}, this);
				this.sandbox.loadModule("TabPropertiesPageModule", {
					id: moduleId,
					renderTo: renderTo
				});
			},

			/**
			 * @private
			 */
			_openDetailSetting: function() {
				const moduleId = this.getDetailModalBoxWindowId();
				const renderTo = ModalBox.show({
					widthPixels: 550,
					heightPixels: 610,
					allowClickPropagation: true
				}, function() {
					this.sandbox.unloadModule(moduleId);
				}, this);
				this.sandbox.loadModule("DetailPropertiesPageModule", {
					id: moduleId,
					renderTo: renderTo,
					instanceConfig: {
						packageUId: this.getPackageUId()
					}
				});
			},

			/**
			 * @private
			 */
			_getNewGroupName: function() {
				const tabName = this.get("ActiveTabName");
				return BPMSoft.ViewModelSchemaDesignerUtils.getUniqueItemName(tabName + "Group");
			},

			/**
			 * @private
			 */
			_getNewTabName: function() {
				return BPMSoft.ViewModelSchemaDesignerUtils.getUniqueItemName("Tab") + "TabLabel";
			},

			/**
			 * @private
			 */
			_onBroadcastServerMessage: function(channel, broadcastMessage) {
				if (broadcastMessage) {
					if (broadcastMessage.event === "SavedDetailWizard" &&
							BPMSoft.sessionId === broadcastMessage.sessionId &&
							!BPMSoft.DetailManager.hasChanges()) {
						BPMSoft.DetailManager.reInitialize(() => {
							BPMSoft.ClientUnitSchemaManager.resetBundleInstanceCache();
							BPMSoft.EntitySchemaManager.resetBundleInstanceCache();
							this.sandbox.publish("ReInitializeDetail", null, [this.getDetailModalBoxWindowId()]);
						});
					}
				}
			},

			/**
			 * @protected
			 */
			addColumnItemToCollection: function(collection, item) {
				this.initItemLabelCaption(item);
				if (BPMSoft.Features.getIsDisabled("DisableEntityColumnTooltipField")) {
					this.initItemTip(item);
				}
				const bindToConfig = this._parseItemBindTo(item.bindTo || item.name);
				const viewModel = bindToConfig.dataModel;
				const designerName = this._getColumnItemDesignerName(viewModel);
				const itemColumn = this.getItemColumn(item);
				collection.add(item.name, Ext.create("BPMSoft.ExistingColumnGridLayoutEditItemModel", {
					designSchema: this,
					itemConfig: item,
					column: bindToConfig.schemaColumn,
					itemColumnType: itemColumn && itemColumn.type,
					schemaModelItemDesignerName: designerName,
					parentViewModel: viewModel,
					isUsed: true
				}));
			},

			/**
			 * @protected
			 */
			addControlItemToCollection: function(collection, item, config) {
				const itemModelConfig = Ext.apply({itemConfig: item}, config);
				if (itemModelConfig.itemConfig.markerValue === 'AngularModule') {
					return;
				} else {
					const itemModel = Ext.create("BPMSoft.ControlGridLayoutEditItemModel", itemModelConfig);
					collection.add(item.name, itemModel);
				}
			},

			/**
			 * @protected
			 */
			addGridLayoutItemToCollection: function(collection, item) {
				if (item.markerValue === 'AngularModule') {
					this.addAngularItemToCollection(collection, item)
				}
				if (this._isWidgetItem(item.name)) {
					this._addWidgetItemToCollection(collection, item);
				} else {
					const bindToConfig = this._parseItemBindTo(item.bindTo || item.name);
					if (bindToConfig.schemaColumn) {
						this.addColumnItemToCollection(collection, item);
					} else {
						this.addControlItemToCollection(collection, item, {designSchema: this});
					}
				}
			},

			/**
			 * @protected
			 */
			initGridLayoutItemsCollection: function() {
				const schemaView = this.get("SchemaView");
				this.set("GridLayouts", []);
				BPMSoft.iterateChildItems(schemaView, function(iterationConfig) {
					const item = iterationConfig.item;
					if (item.itemType === BPMSoft.ViewItemType.GRID_LAYOUT) {
						const itemsCollectionName = this.getGridLayoutEditCollectionName(item);
						const collection = this.createGridLayoutEditCollection(item);
						this.set(itemsCollectionName, collection);
						this.get("GridLayouts").push(item.name);
					}
				}, this);
				this.updateUsedColumns();
				this.updateUsedLookupColumns();
			},

			/**
			 * @private
			 */
			_sameSelection: function(selection, config) {
				return selection.row === config.row &&
					selection.rowSpan === config.rowSpan &&
					selection.column === config.column &&
					selection.colSpan === config.colSpan;
			},

			/**
			 * @private
			 */
			_saveNewDetail: function(config) {
				const utils = BPMSoft.ViewModelSchemaDesignerUtils;
				const detailKey = config.detailKey || utils.getUniqueItemName(config.detailSchemaName);
				this._addDetailToSchemaDetails(detailKey, {
					schemaName: config.detailSchemaName,
					entitySchemaName: config.detailEntitySchemaName,
					filter: {
						detailColumn: config.detailEntitySchemaColumn,
						masterColumn: config.masterEntitySchemaColumn
					}
				});
				if (config.isDetailCaptionChanged) {
					const resourceName = utils.generateDetailCaptionResourcesName(detailKey);
					this._saveCaptionToDesignSchema(resourceName, config.localizableDetailCaption);
				}
				this._saveDetailCaptionToSchema(detailKey, config.localizableDetailCaption.getValue());
				this.set("EditableDetailName", detailKey);
				this.addDetail(detailKey, config.detailIndex);
			},

			/**
			 * @private
			 */
			_onSaveDataModel: function(dataModel) {
				this._applyDataModelToSchema(dataModel.name, {
					entitySchemaName: dataModel.entitySchemaName,
					primaryColumnValue: {
						bindTo: dataModel.bindTo
					}
				});
				const utils = BPMSoft.ViewModelSchemaDesignerUtils;
				const resourceName = utils.generateDataModelCaptionResourcesName(dataModel.name);
				const resource = Ext.create("BPMSoft.LocalizableString", dataModel.caption);
				this._saveCaptionToDesignSchema(resourceName, resource);
				if (this.$DataModels.contains(dataModel.name)) {
					const viewModel = this.$DataModels.get(dataModel.name);
					viewModel.$Caption = dataModel.caption.toString();
					this.updateGridLayoutEditCollection();
				} else {
					const entityDataModel = this.createEntityDataModel(dataModel);
					this._initDataModelDraggableItem(dataModel, entityDataModel);
					this.$DataModels.add(dataModel.name, entityDataModel);
					this._setCollapsedDataModel(dataModel.name, false);
					const dataModelViewModel = this.$DataModels.get(dataModel.name);
					this._onDraggableItemsCollapsedChanged(dataModelViewModel, false);
				}
			},

			/**
			 * @private
			 */
			_saveExistingDetail: function(detailKey, config) {
				if (!Ext.isEmpty(this.get("Schema").details[detailKey])) {
					this._addDetailToSchemaDetails(detailKey, {
						schemaName: config.detailSchemaName,
						entitySchemaName: config.detailEntitySchemaName,
						filter: {
							detailColumn: config.detailEntitySchemaColumn,
							masterColumn: config.masterEntitySchemaColumn
						}
					});
				}
				if (config.isDetailCaptionChanged) {
					const utils = BPMSoft.ViewModelSchemaDesignerUtils;
					const resourceName = utils.generateDetailCaptionResourcesName(detailKey);
					this._saveCaptionToDesignSchema(resourceName, config.localizableDetailCaption);
					this._saveDetailCaptionToSchema(detailKey, config.localizableDetailCaption.getValue());
				}
			},

			/**
			 * Add new detail into current detail collection.
			 * @private
			 * @param {String} detailKey Unique detail name.
			 * @param {Object} detail Detail configuration object.
			 */
			_addDetailToSchemaDetails: function(detailKey, detail) {
				const schemaDetails = this.get("Schema").details;
				if (schemaDetails[detailKey]) {
					Ext.apply(schemaDetails[detailKey], detail);
				} else {
					schemaDetails[detailKey] = detail;
				}
			},

			/**
			 * @private
			 */
			_applyDataModelToSchema: function(name, dataModel) {
				const dataModels = this.$Schema.dataModels || {};
				if (dataModels[name]) {
					Ext.apply(dataModels[name], dataModel);
				} else {
					dataModels[name] = dataModel;
				}
				this.$Schema.dataModels = dataModels;
			},

			/**
			 * Saves caption localizable string to design client unit schema.
			 * @private
			 * @param {String} resourceName Resource name.
			 * @param {BPMSoft.core.LocalizableString} caption Localizable string.
			 */
			_saveCaptionToDesignSchema: function(resourceName, caption) {
				const instance = this.get("PageSchema");
				let localizableString;
				if (instance.localizableStrings.contains(resourceName)) {
					localizableString = instance.localizableStrings.get(resourceName);
					if (BPMSoft.Features.getIsEnabled("DetailPropertiesPage")) {
						instance.localizableStrings.replace(localizableString, caption, resourceName);
					} else {
						localizableString.setValue(caption.getValue());
					}
				} else {
					localizableString = Ext.create("BPMSoft.LocalizableString");
					localizableString.merge(caption);
					instance.localizableStrings.add(resourceName, localizableString);
				}
			},

			/**
			 * @private
			 */
			_saveDetailCaptionToSchema: function(detailKey, detailCaption) {
				const captionTemplateResourceName = this._getDetailCaptionTemplateResourceName(true);
				const caption = Ext.String.format(this.get(captionTemplateResourceName), detailCaption);
				this.set(this.getDetailCaptionResourcesName(detailKey), caption);
			},

			/**
			 * @private
			 */
			_confirmRemoveBusinessRules: function(config, callback, scope) {
				const dot = String.fromCharCode(8226);
				const rulesCaptions = config.rules.map(function(rule) {
					return dot + " " + rule.instance.caption.toString();
				}, this);
				const message = [config.messageHeader].concat(rulesCaptions).join("\n");
				const removeButtonCaption = this.get("Resources.Strings.RemoveBusinessRulesButtonCaption");
				const removeButton = {
					className: "BPMSoft.Button",
					returnCode: "remove",
					caption: removeButtonCaption,
					markerValue: removeButtonCaption
				};
				this.showConfirmationDialog(message, function(returnCode) {
					callback.call(scope, returnCode === "remove");
				}, [removeButton, "cancel"], {defaultButton: 0});
			},

			/**
			 * @private
			 */
			_checkBusinessRuleColumnDependencies: function(columnName, dataModelSchema, callback, scope) {
				const config = {
					columnName: columnName,
					pageSchemaUId: dataModelSchema.uId
				};
				BPMSoft.BusinessRuleSchemaManager.getRulesDependsOnColumn(config, function(rules) {
					if (!rules.length) {
						Ext.callback(callback, scope);
						return;
					}
					this._confirmRemoveBusinessRules({
						messageHeader: this.get("Resources.Strings.FieldUsedInRulesMessage"),
						rules: rules
					}, function(isConfirmed) {
						if (isConfirmed) {
							this._removeBusinessRules(rules, callback, scope);
						}
					}, this);
				}, this);
			},

			/**
			 * @private
			 */
			_checkBusinessRuleDataSourceDependencies: function(dataModel, callback, scope) {
				const config = {
					dataModel: dataModel,
					pageSchemaUId: this.$PageSchema.uId,
					entitySchemaId: dataModel.get("Schema").uId
				};
				BPMSoft.BusinessRuleSchemaManager.getRulesDependsOnDataModel(config, function(rules) {
					if (!rules.length) {
						Ext.callback(callback, scope);
						return;
					}
					this._confirmRemoveBusinessRules({
						messageHeader: this.get("Resources.Strings.DataSourceUsedInRules"),
						rules: rules
					}, function(isConfirmed) {
						if (isConfirmed) {
							this._removeBusinessRules(rules, callback, scope);
						}
					}, this);
				}, this);
			},

			/**
			 * @private
			 */
			_removeBusinessRules: function(rules, callback, scope) {
				this.showBodyMask();
				BPMSoft.BusinessRuleSchemaManager.removeRules(rules, function() {
					this.hideBodyMask();
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_checkDataModelDependencies: function(columnName) {
				const dataModels = this.$Schema.dataModels || {};
				let isValid = true;
				BPMSoft.each(dataModels, function(dataModel) {
					const bindTo = Ext.isObject(dataModel.primaryColumnValue)
						? dataModel.primaryColumnValue.bindTo
						: dataModel.primaryColumnValue;
					isValid = isValid && bindTo !== columnName;
				}, this);
				return isValid;
			},

			/**
			 * @private
			 */
			_removeExistingModelDraggableItem: function(columnUId, dataModel) {
				const collectionsNames = this.getGridLayoutEditCollections();
				BPMSoft.each(collectionsNames, function(gridLayoutName) {
					const collectionName = this.getGridLayoutEditCollectionName(gridLayoutName);
					const layoutCollection = this.get(collectionName);
					if (layoutCollection) {
						layoutCollection.each(function(item) {
							if (item.column.uId === columnUId) {
								layoutCollection.remove(item);
							}
						}, this);
					}
				}, this);
				const collection = dataModel.get("ExistingModelDraggableItems");
				if (collection.contains(columnUId)) {
					collection.removeByKey(columnUId);
				}
			},

			/**
			 * @private
			 */
			_getAddDataSourceWindowId: function() {
				return this.sandbox.id + "_DataSourcePropertiesPage";
			},

			/**
			 * @private
			 */
			_updateNewDraggableItemsVisibility: function() {
				this.$DataModels.get("Elements").set("IsNewPageSchema", this.$PageSchema.isNew());
			},

			/**
			 * Adds new tab to tabs collection.
			 * @protected
			 * @param {String} name Tab name.
			 * @param {String} caption Tab caption.
			 * @param {Number} index Tab index.
			 */
			_addTabToCollection: function(name, caption, index) {
				const tabsCollection = this.$TabsCollection;
				const tabContentCollection = Ext.create("BPMSoft.BaseViewModelCollection", {
					entitySchema: Ext.create("BPMSoft.BaseEntitySchema", {
						columns: {},
						primaryColumnName: "Name"
					})
				});
				const newTab = Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Caption: caption,
						Name: name,
						Content: tabContentCollection
					}
				});
				tabsCollection.insert(index, name, newTab);
			},

			/**
			 * Creates localizable string for tab caption.
			 * @private
			 * @param {String} resourceName Name of the localizable string.
			 * @param {String | BPMSoft.LocalizableString} value Tab caption.
			 */
			_addNewTabLocalizableString: function(resourceName, value) {
				const clientUnitSchema = this.get("PageSchema");
				const localizableString = value instanceof BPMSoft.LocalizableString
					? value
					: Ext.create("BPMSoft.LocalizableString", value);
				clientUnitSchema.localizableStrings.add(resourceName, localizableString);
			},

			/**
			 * @private
			 */
			_isExistsLocalizableString: function(bindTo) {
				const clientUnitSchema = this.get("PageSchema");
				const resourceName = this.getSchemaResourceNameFromModelResourceName(bindTo);
				return clientUnitSchema.localizableStrings.contains(resourceName);
			},

			/**
			 * Returns current page entity schema.
			 * @private
			 * @return {Object} Current page entity schema.
			 */
			_getEntitySchemaInstance: function() {
				const dataModels = this.$DataModels;
				const dataModel = dataModels.get(this.entitySchemaName);
				return dataModel.get("Schema");
			},

			/**
			 * Updates SSP section modified on property.
			 * Need for rights change actualization on edit.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			_updateSspSectionModifiedOn: function(callback, scope) {
				const sectionItem = BPMSoft.SectionManager.findByFn(function(item) {
					return item.getId() === this.$ApplicationStructureItemId;
				}, this);
				if (!this.$IsSspSection || !sectionItem) {
					return Ext.callback(callback, scope || this);
				}
				sectionItem.setPropertyValue("modifiedOn", new Date());
				Ext.callback(callback, scope || this);
			},

			/**
			 * Returns current page unique identifier.
			 * @private
			 * @return {String} Current page unique identifier.
			 */
			_getCardSchemaUId: function() {
				const pageSchema = this.$PageSchema;
				return pageSchema.extendParent ? pageSchema.parentSchemaUId : pageSchema.uId;
			},

			/**
			 * @private
			 */
			_isIntersectWithExistLayoutItems: function(currentSelection, layoutItems) {
				return BPMSoft.some(layoutItems, function(item) {
					const a = {
						x1: currentSelection.column,
						x2: currentSelection.column + currentSelection.colSpan,
						y1: currentSelection.row,
						y2: currentSelection.row + currentSelection.rowSpan
					};
					const b = {
						x1: item.$column,
						x2: item.$column + item.$colSpan,
						y1: item.$row,
						y2: item.$row + item.$rowSpan
					};
					const separated = b.x2 <= a.x1 || a.x2 <= b.x1 || b.y2 <= a.y1 || a.y2 <= b.y1;
					return !separated;
				});
			},

			/**
			 * @private
			 */
			_onReplaceTabContentItem: function() {
				return false;
			},

			/**
			 * @private
			 */
			_generateTipResourcesName: function(itemName) {
				return itemName.replace(/-/g, "") + "Tip";
			},

			//endregion

			//region Methods: Protected

			/**
			 * Generates diff for inserting new tab.
			 * @protected
			 * @param {String} name Tab name.
			 * @param {String} resourceName Name of the localizable string of the tab's caption.
			 * @param {Number} index Tab index.
			 * @return {Array} insertDiff Generated diff.
			 */
			generateTabInsertDiff: function(name, resourceName, index) {
				const insertDiff = [{
					"operation": "insert",
					"propertyName": "tabs",
					"parentName": "Tabs",
					"name": name,
					"index": index,
					"values": {
						"caption": {"bindTo": resourceName},
						"items": []
					}
				}];
				return insertDiff;
			},

			/**
			 * Generates diff for moving tab.
			 * @protected
			 * @param {String} name Tab name.
			 * @param {Number} index Tab index.
			 * @return {Array} moveDiff Generated diff.
			 */
			generateTabMoveDiff: function(name, index) {
				const moveDiff = [{
					"operation": "move",
					"name": name,
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": index
				}];
				return moveDiff;
			},

			/**
			 * Generates diff for removing tab.
			 * @protected
			 * @param {String} name Tab name.
			 * @return {Array} removeDiff Generated diff.
			 */
			generateTabRemoveDiff: function(name) {
				const removeDiff = [{
					"operation": "remove",
					"name": name
				}];
				return removeDiff;
			},

			/**
			 * Schema changed handler.
			 * @protected
			 * @param {Array} diff Array of diffs.
			 */
			onSchemaChanged: function(diff) {
				this.fireEvent("schemaChanged", diff);
			},

			/**
			 * Initialization parameters, which has bindings to the base card.
			 * @protected
			 */
			initSchemaBindings: function() {
				this.set("ReportGridData", Ext.create("BPMSoft.Collection"));
				this.set("IsSeparateMode", false);
				this._safeCallMethod("initTabs");
				this._safeCallMethod("initContainersVisibility");
				this._safeCallMethod("initHasAnyDcm");
			},

			/**
			 * @protected
			 */
			onGetModuleConfigResult: function(config, callback, scope) {
				this.set("PageSchema", config.clientUnitSchema);
				this.set("ApplicationStructureItemId", config.applicationStructureItemId);
				this.set("IsSspSection", config.isSspSection);
				this.set("CanAddNewColumn", this.$PageSchema.canDesignSchema());
				this.set("WizardType", config.wizardType);
				this.set("WizardManagerName", config.wizardManagerName);
				Ext.callback(callback, scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#constructor
			 * @override
			 */
			constructor: function() {
				this.callParent(arguments);
				this._newItemNames = [];
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#init
			 * @override
			 */
			init: function(callback, scope) {
				var self = this;
				this.subscribeSandboxEvents();
				this._initEvents();
				this._initEmptyInfoImageSrc();
				if (!this.canDesignSchema()) {
					this.log(this.get("GenerationInfoMessage"));
					Ext.callback(callback, scope);
					return;
				}
			
				this.getAppBuild().then(combinedResults => {
					console.log(combinedResults);
					console.log('combinedResults');
					const moduleName = self.BPMSoft.moduleName;
			
					if (!self.isEmptyObject(combinedResults) && moduleName === 'SectionPageDesignerModule') {
						self.set("AngularModulesCollection", combinedResults);
						self.set('AngularModules', combinedResults);
					} else {
						self.set("AngularModulesCollection", {});
						self.set('AngularModules', {});
					}
			
					// Продолжение процесса инициализации
					continueInitProcess();
				}).catch(error => {
					console.error(error);
					// Обработка ошибки
					continueInitProcess();
				});
			
				// Функция для продолжения процесса инициализации
				function continueInitProcess() {
					self.initSchemaBindings();
					BPMSoft.eachAsyncAll([
						self._loadPageSchemaConfig,
						self._initDataModelsDesignSchema,
						self.initWidgetDashboardManagerItems,
						self.initRelatedProfileItems,
						self.subscribeTabCollectionEvents,
					], function() {
						BPMSoft.chain(
							function(next) {
								self._initDataModels(next, self);
							},
							function() {
								self._fillDetailCaptionsFromPageResources();
								self.set("Initializing", false);
								setTimeout(self._initDetailsCaptionsAsync.bind(self), 1000);
								self.showWizardWarning();
								BPMSoft.ServerChannel.on(BPMSoft.ServerChannelSender.BROADCAST_MESSAGE,
									self._onBroadcastServerMessage.bind(self), self);
								Ext.callback(callback, scope);
							}
						);
					}, self);
				}
			},

			/**
			 * Shows warning with collapsible container.
			 * @protected
			 */
			showWizardWarning: function() {
				const warnings = this.$ValidationWarnings;
				if (Ext.isEmpty(warnings)) {
					return;
				}
				this.sandbox.loadModule("ModalBoxSchemaModule", {
					instanceConfig: {
						moduleInfo: {
							schemaName: "WizardWarningModalBoxPage",
							messageText: warnings[0].mainMessage,
							additionalInfo: warnings[0].additionalMessage
						}
					}
				});
			},

			/**
			 * Handler for before page unload event.
			 * @protected
			 */
			onBeforeUnload: function() {
				BPMSoft.Mask.show({timeout: 0});
				this._saveModelsCollapsed();
			},

			/**
			 * Returns a flag that indicates whether a schema can be designed.
			 */
			canDesignSchema: function() {
				return this.get("GenerationValid");
			},

			/**
			 * Initializes new type collection of new widgets for drag and drop.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initNewWidgetsModelDraggableItems: function(callback, scope) {
				const widgetsType = this.getWidgetTypes();
				const collection = Ext.create("BPMSoft.BaseViewModelCollection");
				BPMSoft.each(widgetsType, function(item) {
					const itemKey = BPMSoft.generateGUID();
					const widgetItem = this.getWidgetGridLayoutItem(item);
					collection.add(itemKey, widgetItem);
				}, this);
				collection.on("itemChanged", this.draggableItemChanged, this);
				this.$DataModels.get("Elements").set("NewWidgetsModelDraggableItems", collection);
				Ext.callback(callback, scope);
			},


			initAngularModelDraggableItems: function(callback, scope) {
				const angularCollection = this.getAngularCollection();
				const collection = Ext.create("BPMSoft.BaseViewModelCollection");
				BPMSoft.each(angularCollection, function(item) {
					const itemKey = item.$Id;
					const angularItem = this.getAngularGridLayoutItem(item);
					collection.add(itemKey, angularItem);
				}, this);
				collection.on("itemChanged", this.draggableItemChanged, this);
				this.$DataModels.get("Elements").set("ExistingAngularModelDraggableItems", collection);
				Ext.callback(callback, scope);
			},

			/**
			 * Returns widget grid layout item.
			 * @param {Object} item Item configuration.
			 * @return {BPMSoft.SchemaWidgetDesignToolItem} Widget grid layout item.
			 */
			getWidgetGridLayoutItem: function(item) {
				const draggableGroupNames = this.getGridLayoutEditCollections();
				return Ext.create("BPMSoft.SchemaWidgetDesignToolItem", {
					designItemClassName: "BPMSoft.WidgetGridLayoutEditItemModel",
					item: item,
					values: {
						Name: item.type,
						draggableGroupNames: draggableGroupNames
					},
					sandbox: {id: this.sandbox.id}
				});
			},

			getAngularGridLayoutItem: function(item) {
				const draggableGroupNames = this.getGridLayoutEditCollections();
				const itemConfig = {
					designItemClassName: "BPMSoft.AngularGridLayoutEditItemModel",
					item: item,
					values: {
						name: item.fileName,
						sysSchemaId: item.sysSchemaId,
						sysSchemaUId: item.sysSchemaUId,
						isSchemaIsChanged: item.schemaIsChanged,
						angularParameters: item.angularParameters,
					},
					sandbox: { id: this.sandbox.id }
				};
			
				if (!item.schemaIsChanged) {
					itemConfig.values.draggableGroupNames = draggableGroupNames;
				}

				return Ext.create("BPMSoft.SchemaAngularDesignToolItem", itemConfig);
			},

			/**
			 * Returns widget types.
			 * @protected
			 * @return {Object} Widget types.
			 */
			getWidgetTypes: function() {
				return {
					"Chart": {
						"type": "Chart",
						"caption": this.get("Resources.Strings.NewWidgetChartCaption")
					},
					"Metric": {
						"type": "Indicator",
						"caption": this.get("Resources.Strings.NewWidgetMetricCaption")
					},
					"Gauge": {
						"type": "Gauge",
						"caption": this.get("Resources.Strings.NewWidgetGaugeCaption")
					},
					"WebPage": {
						"type": "WebPage",
						"caption": this.get("Resources.Strings.NewWidgetWebPageCaption")
					}
				};
			},

			/**
			 * Initializes Related Profile Items.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initRelatedProfileItems: function(callback, scope) {
				let relatedProfileItems = this.get("RelatedProfileItems");
				if (!relatedProfileItems) {
					relatedProfileItems = Ext.create("BPMSoft.BaseViewModelCollection");
					this.set("RelatedProfileItems", relatedProfileItems);
				}
				const profileContainer = this.getSchemaViewItem("LeftModulesContainer");
				if (profileContainer && profileContainer.items) {
					BPMSoft.each(profileContainer.items, function(item) {
						if (item.itemType === BPMSoft.ViewItemType.MODULE) {
							const viewModelItem = this.generateRelatedProfileViewModel(item.name);
							relatedProfileItems.add(viewModelItem.get("Id"), viewModelItem);
						}
					}, this);
				}
				relatedProfileItems.on("move", this.onRelatedProfileItemMove, this);
				Ext.callback(callback, scope);
			},

			/**
			 * Related Profile Item move event handler.
			 * @protected
			 * @override
			 * @param {Number} positionFrom Position move from.
			 * @param {Number} positionTo Position move to.
			 * @param {String} key Item key.
			 */
			onRelatedProfileItemMove: function(positionFrom, positionTo, key) {
				if (positionFrom !== positionTo) {
					const collection = this.get("RelatedProfileItems");
					const item = collection.get(key);
					const name = item.get("ItemName");
					const diff = [{
						"operation": "move",
						"name": name,
						"parentName": "LeftModulesContainer",
						"propertyName": "items",
						"index": positionTo + 1
					}];
					this.onSchemaChanged(diff);
				}
			},

			/**
			 * Returns related ApplicationStructureItem caption.
			 * @protected
			 * @return {Object|null}
			 */
			getApplicationStructureItemConfig: function() {
				const itemId = this.get("ApplicationStructureItemId");
				if (itemId) {
					const wizardManagerName = this.get("WizardManagerName");
					const item = BPMSoft[wizardManagerName].findItem(itemId);
					return {
						itemCaption: item ? item.caption : "",
						itemType: this.get("WizardType")
					};
				}
				return null;
			},

			/**
			 * Generate related profile ViewModel.
			 * @protected
			 * @param {String} name Profile module name.
			 */
			generateRelatedProfileViewModel: function(name) {
				const id = Ext.String.format("Related{0}Item", name);
				return Ext.create("BPMSoft.DesignTimeReorderableItemModel", {
					values: {
						"ReorderableModel": this,
						"ReorderableIndexColumnName": "RelatedProfileReorderableIndex",
						"Id": id,
						"ItemName": name,
						"entitySchemaName": name,
						"canEdit": false,
						"canRemove": true
					},
					methods: {
						edit: BPMSoft.emptyFn,
						remove: BPMSoft.emptyFn
					}
				});
			},

			/**
			 * Registers application component messages.
			 * @param {Object} messageConfig Message config.
			 */
			registerApplictionComponentItemMessage: function(messageConfig) {
				if (Ext.isEmpty(this.get("MessageMap"))) {
					this.set("MessageMap", []);
				}
				if (!Ext.isEmpty(messageConfig)) {
					const messageMap = this.get("MessageMap");
					const needRegister = !(messageMap.some(function(item) {
						return item.messageName === messageConfig.messageName && item.moduleId === messageConfig.moduleId;
					}));
					if (needRegister) {
						this.sandbox.subscribe(messageConfig.messageName, function() {
							return this.callApplictionComponentItemMessageHandler({
								applicationComponentItem: this.get("ActionLayoutItem"),
								messageName: messageConfig.messageName,
								moduleId: messageConfig.moduleId
							}, arguments);
						}, this, [messageConfig.moduleId]);
					}
					messageMap.push(messageConfig);
				}
			},

			/**
			 * Calls application component message handler.
			 * @protected
			 * @param {Object} filterConfig Item filter config.
			 * @param {IArguments | Array} args Handler function arguments.
			 * @return {Object} Message result.
			 */
			callApplictionComponentItemMessageHandler: function(filterConfig, args) {
				const messageMap = this.get("MessageMap");
				const messageConfig = messageMap.filter(function(item) {
					return item.ownerId === filterConfig.applicationComponentItem.instanceId &&
						item.messageName === filterConfig.messageName &&
						item.moduleId === filterConfig.moduleId;
				})[0];
				if (messageConfig && Ext.isFunction(messageConfig.handler)) {
					return messageConfig.handler.apply(filterConfig.applicationComponentItem, args);
				}
			},

			/**
			 * Subscribes sandbox events, which needs this page.
			 * @protected
			 */
			subscribeSandboxEvents: function() {
				this.sandbox.subscribe("OpenDetailDesigner", this._onOpenDetailDesigner, this,
					[this.getDetailModalBoxWindowId()]);
				this.sandbox.subscribe("Validate", this.onValidate, this, [this.sandbox.id]);
				this.sandbox.subscribe("Save", this.onSave, this, [this.sandbox.id]);
				this.sandbox.subscribe("OnAfterSave", this.onAfterSave, this, [this.sandbox.id]);
				this.sandbox.subscribe("GetModuleInfo", this.onGetDataSourcePageData, this,
					[this._getAddDataSourceWindowId()]);
				this.sandbox.subscribe("SaveDataModel", this._onSaveDataModel, this,
					[this._getAddDataSourceWindowId()]);
				this.sandbox.subscribe("GetModuleInfo", this.getTabModalBoxConfig, this,
					[this.getTabModalBoxWindowId()]);
				this.sandbox.subscribe("SaveTabConfig", this.onSaveTabConfig, this,
					[this.getTabModalBoxWindowId()]);
				this.sandbox.subscribe("GetModuleInfo", this.getControlGroupModalBoxConfig, this,
					[this.getControlGroupModalBoxWindowId()]);
				this.sandbox.subscribe("SaveControlGroupConfig", this.onSaveControlGroupConfig, this,
					[this.getControlGroupModalBoxWindowId()]);
				this.sandbox.subscribe("GetModuleInfo", this.getDetailModalBoxConfig, this,
					[this.getDetailModalBoxWindowId()]);
				this.sandbox.subscribe("SaveDetailConfig", this.onSaveDetailConfig, this,
					[this.getDetailModalBoxWindowId()]);
				this.sandbox.subscribe("GetControlGroupConfig", this._getControlGroupConfig, this,
					[this.getControlGroupModalBoxWindowId()]);
				this.sandbox.subscribe("GetDetailConfig", this._getDetailConfig, this,
					[this.getDetailModalBoxWindowId()]);
				this.sandbox.subscribe("GetTabConfig", this._getTabConfig, this,
					[this.getTabModalBoxWindowId()]);
				Ext.EventManager.on(window, "beforeunload", this.onBeforeUnload.bind(this), this);
			},

			/**
			 * Returns identifier of current package.
			 * @protected
			 * @return {String} Identifier of current package.
			 */
			getPackageUId: function() {
				if (!this.destroyed) {
					return this.sandbox.publish("GetPackageUId", null, [this.sandbox.id]);
				}
			},

			/**
			 * Handler of save event.
			 * @protected
			 */
			onSave: function() {
				if (!this.get("GenerationValid")) {
					this.publishSavingResult(null);
					return;
				}
				const angularWizardData = this.getAngularWizard();

				if (angularWizardData && !this.isEmptyObject(angularWizardData)) {
					this.sandbox.publish("onAngularDesignerSave", angularWizardData, ['angularDesigner']);
					this.cleanAngularModules();
					this.saveDesignData(this.publishSavingResult, this);
				} else {
					this.saveDesignData(this.publishSavingResult, this);
				}
			},
			
			cleanAngularModules: function() {
				var collection = this.getAngularModulesLayoutCollection();
				collection.forEach(function(itemConfig) {
					delete itemConfig.angularParameters;
					delete itemConfig.appBuildId;
					delete itemConfig.displayValue;
					delete itemConfig.sysSchemaId;
					delete itemConfig.existName;
					delete itemConfig.imageData;
					delete itemConfig.appWrappers;
					delete itemConfig.sysSchemaUId;
					delete itemConfig.appWrapperUId;
					delete itemConfig.pageSchemaUId;
					delete itemConfig.isNeedBuild;
					delete itemConfig.isParent;
				});
			},
			
			processDeletion: function() {
				const itemsToDelete = this.getAngularModulesDiffCollection();
			
				if (itemsToDelete.length > 0) {
					return itemsToDelete;
				}
			
				return [];
			},
				
			getAngularModulesDiffCollection: function () {
				const schema = this.$Schema;
				const diff = schema.diff;
				const currentCollectionIds = this.getAngularModulesLayoutCollection().map(item => item.id);
				
				let itemsToDelete = [];
			
				BPMSoft.each(diff, function(item) {
					if (item?.values?.markerValue === 'AngularModule') {
						const wrapClassName = item.values.classes.wrapClassName;
						const uniqueGuidPart = this.getClassSuffix(wrapClassName, 'uniqueGuid-');
            			const sysSchemaUIdPart = this.getClassSuffix(wrapClassName, 'sysSchemaUId-');
						if (!currentCollectionIds.includes(item.values.id)) {
							itemsToDelete.push({
								appWrapperUId: uniqueGuidPart,
								sysSchemaUId: sysSchemaUIdPart
							});
						}
					}
				}, this);	
				return itemsToDelete;
			},

			getAngularModulesLayoutCollection: function () {
				const firstCollection = [];
				const gridLayout = this.getGridLayoutEditCollections();
				BPMSoft.each(gridLayout, function(gridLayoutName) {
					const collectionName = this.getGridLayoutEditCollectionName(gridLayoutName);
					const itemsCollection = this.get(collectionName);
					itemsCollection.each(function(modelItem) {
						const itemConfig = modelItem.itemConfig;
						if (itemConfig?.markerValue === 'AngularModule') {
							firstCollection.push(itemConfig);
						} else {
							return
						}
					}, this);
				}, this);

				return firstCollection;
			},

			isEmptyObject:function(obj) {
				return Object.keys(obj).length === 0 && obj.constructor === Object;
			},

			calculateDynamicTimeout: function(data) {
				const timePerRecord = 180000; // 3 минуты на запись
				const totalRecords = (data && data.angularModules && data.angularModules.length) || 0;
				
				return timePerRecord * totalRecords;
			},

			callServiceMethod: function(dataSend, callback) {
				var ajaxProvider = BPMSoft.AjaxProvider;
				var data = dataSend || {};
				var requestUrl = BPMSoft.workspaceBaseUrl + "/DataService/json/SyncReply/AngularDesignerRequest";
				var calculatedTimeout = this.calculateDynamicTimeout(data);
				MaskHelper.ShowBodyMask();
				var request = ajaxProvider.request({
					url: requestUrl,
					headers: {
						"Accept": "application/json",
						"Content-Type": "application/json"
					},
					method: "POST",
					timeout: 6000000,
					jsonData: data,
					callback: callback,
					scope: this
				});
				request.timeout = BPMSoft.BaseServiceProvider.getRequestTimeout(request);
				return request;
			},

			getAngularWizard: function() {
				const schema = this.$Schema.angularModules;
				const globalAngularModules = this.BPMSoft?.angularDesignerObj?.angularModules || [];
				const pageSchemaUId = this.$PageSchema.uId;
				const packagePageSchemaUId = this.$PageSchema.packageUId;
				let result = {};
				const resultArray = schema ? Object.values(schema) : [];

				// Если schema существует и не пуста, используем её данные
				if (resultArray.length > 0 || globalAngularModules.length > 0) {
					result = {
						angularModules: [...resultArray, ...globalAngularModules],
						pageSchemaUId: pageSchemaUId,
						packagePageSchemaUId: packagePageSchemaUId
					};
				} else {
					// Если schema пуста, возвращаем пустой массив для angularModules
					// Но всё равно включаем angularRemoveWrappers
					result = {
						angularModules: [],
						pageSchemaUId: pageSchemaUId,
						packagePageSchemaUId: packagePageSchemaUId
					};
				}
			
				console.log(result, 'Result in getAngularWizard');
				return result;
			},

			/**
			 * private
			 */
			_onOpenDetailDesigner: function(detailId) {
				if (BPMSoft.DetailManager.hasChanges()) {
					const message = this.get("Resources.Strings.SaveMessage");
					const saveButtonCaption = this.get("Resources.Strings.SaveButtonCaption");
					const saveButton = BPMSoft.getButtonConfig("save", saveButtonCaption);
					BPMSoft.showConfirmation(message, (returnCode) => {
						if (returnCode === "save") {
							this._detailId = detailId;
							this.sandbox.publish("SaveWizard", {silentMode: true}, [this.sandbox.id]);
						}
					}, [saveButton, "cancel"], this, {defaultButton: 0});
				} else {
					this.sandbox.publish("OpenDetailDesigner", detailId, [this.sandbox.id]);
				}
			},

			/**
			 * Handler of after save event.
			 * @protected
			 */
			onAfterSave: function() {
				this._updateNewDraggableItemsVisibility();
				if (this._detailId) {
					this.sandbox.publish("OpenDetailDesigner", this._detailId, [this.sandbox.id]);
					this._detailId= null;
				}
			},

			/**
			 * Publishes the results of saving.
			 * @protected
			 * @param {Object} saveResult Result of saving.
			 */
			publishSavingResult: function(saveResult) {
				this.hideBodyMask();
				this.sandbox.publish("SavingResult", saveResult, [this.sandbox.id]);
			},

			/**
			 * Handler of validate event.
			 * @protected
			 */
			onValidate: function() {
				if (!this.get("GenerationValid")) {
					this.publishValidationResult(true);
					return;
				}
				this.asyncValidate(this.publishValidationResult, this);
			},

			/**
			 * Publishes the results of validation.
			 * @protected
			 * @param {Object} result Result of validation.
			 */
			publishValidationResult: function(result) {
				this.hideBodyMask();
				this.sandbox.publish("ValidationResult", result, [this.sandbox.id]);
			},

			/**
			 * Adds new group into the drag and drop elements.
			 * @protected
			 * @param {String} groupName New group of drag and drop elements.
			 */
			addDraggableGroupName: function(groupName) {
				const addGroupName = function(item) {
					item.addDraggableGroupName(groupName);
				};
				this.$DataModels.each(function(dataViewModel) {
					const existingItems = dataViewModel.get("ExistingModelDraggableItems");
					const newModelItems = dataViewModel.get("NewModelDraggableItems");
					const newElementItems = dataViewModel.get("NewElementDraggableItems");
					const angularItems = dataViewModel.get('ExistingAngularModelDraggableItems')
					const newWidgetsItems = dataViewModel.get("NewWidgetsModelDraggableItems");
					if (existingItems) {
						existingItems.each(addGroupName, this);
					}
					if (newModelItems) {
						newModelItems.each(addGroupName, this);
					}
					if (newElementItems) {
						newElementItems.each(addGroupName, this);
					}
					if (newWidgetsItems) {
						newWidgetsItems.each(addGroupName, this);
					}
					if (angularItems) {
						angularItems.each(addGroupName, this);
					}
				}, this);
			},

			/**
			 * Updates used columns.
			 * @protected
			 * @return {Object} Object which contains information about used columns.
			 */
			updateUsedColumns: function() {
				const usedColumns = {};
				const gridLayout = this.getGridLayoutEditCollections();
				BPMSoft.each(gridLayout, function(gridLayoutName) {
					const collectionName = this.getGridLayoutEditCollectionName(gridLayoutName);
					const itemsCollection = this.get(collectionName);
					itemsCollection.each(function(modelItem) {
						const itemConfig = modelItem.itemConfig;
						const bindTo = itemConfig.bindTo || itemConfig.name;
						usedColumns[bindTo] = usedColumns[bindTo] || 0;
						usedColumns[bindTo]++;
					}, this);
				}, this);
				this.set("UsedColumns", usedColumns);
				return usedColumns;
			},

			/**
			 * Updates used lookup columns.
			 * @protected
			 * @return {Object} Object which contains information about used lookup columns.
			 */
			updateUsedLookupColumns: function() {
				const columns = this.columns;
				const usedLookupColumns = Ext.create("BPMSoft.Collection");
				BPMSoft.each(columns, function(column) {
					if (column.referenceSchemaName && !usedLookupColumns.contains(column.uId)) {
						usedLookupColumns.add(column.uId, column.referenceSchemaName);
					}
				}, this);
				this.$UsedLookupColumns = usedLookupColumns;
			},

			/**
			 * Sorts the collection of columns, exposing the first place to show the primary column,
			 * then required, then all the other.
			 * @protected
			 * @param {BPMSoft.core.collections.Collection} collection Collection of columns for sort.
			 * @param {BPMSoft.model.BaseViewModel} dataModel Data source view model.
			 */
			sortColumnsCollection: function(collection, dataModel) {
				const instance = dataModel.get("Schema");
				const primaryDisplayColumnUId = instance.getPropertyValue("primaryDisplayColumnUId");
				collection.sortByFn(function(column1, column2) {
					const uId1 = column1.getPropertyValue("uId");
					if (uId1 === primaryDisplayColumnUId) {
						return -1;
					}
					const uId2 = column2.getPropertyValue("uId");
					if (uId2 === primaryDisplayColumnUId) {
						return 1;
					}
					const isRequired1 = column1.getPropertyValue("isRequired");
					const isRequired2 = column2.getPropertyValue("isRequired");
					if (isRequired1 !== isRequired2) {
						return (isRequired2 - isRequired1);
					}
					let property1 = column1.getPropertyValue("caption");
					let property2 = column2.getPropertyValue("caption");
					property1 = property1 && property1.getValue();
					property2 = property2 && property2.getValue();
					if (property1 === property2) {
						return 0;
					}
					return (property1 < property2) ? -1 : 1;
				}, this);
			},

			/**
			 * Checks the column, if its can be added to the grid.
			 * @protected
			 * @param {BPMSoft.manager.EntitySchemaColumn} column Object of column.
			 * @return {Boolean} true if column can be added to the grid, false - otherwise.
			 */
			columnsFilterFn: function(column) {
				if (column.getStatus() === BPMSoft.ModificationStatus.REMOVED) {
					return false;
				}
				const allowedDataValueTypes = [
					BPMSoft.DataValueType.SHORT_TEXT,
					BPMSoft.DataValueType.MEDIUM_TEXT,
					BPMSoft.DataValueType.LONG_TEXT,
					BPMSoft.DataValueType.MAXSIZE_TEXT,
					BPMSoft.DataValueType.TEXT,
					BPMSoft.DataValueType.INTEGER,
					BPMSoft.DataValueType.FLOAT,
					BPMSoft.DataValueType.MONEY,
					BPMSoft.DataValueType.DATE_TIME,
					BPMSoft.DataValueType.DATE,
					BPMSoft.DataValueType.TIME,
					BPMSoft.DataValueType.LOOKUP,
					BPMSoft.DataValueType.ENUM,
					BPMSoft.DataValueType.BOOLEAN,
					BPMSoft.DataValueType.FLOAT1,
					BPMSoft.DataValueType.FLOAT2,
					BPMSoft.DataValueType.FLOAT3,
					BPMSoft.DataValueType.FLOAT4,
					BPMSoft.DataValueType.FLOAT8,
				];
				return column.usageType !== BPMSoft.EntitySchemaColumnUsageType.None &&
					Ext.Array.contains(allowedDataValueTypes, column.dataValueType);
			},

			/**
			 * @protected
			 */
			loadColumnsCollection: function(collection, columns, designItemClassName, viewModel) {
				const draggableGroupNames = this.getGridLayoutEditCollections();
				const filteredColumns = columns.filterByFn(this.columnsFilterFn, this);
				this.sortColumnsCollection(filteredColumns, viewModel);
				const usedColumns = this.get("UsedColumns");
				BPMSoft.each(filteredColumns, function(column) {
					collection.add(column.uId, Ext.create(column.designToolClassName, { 
						designItemClassName: designItemClassName,
						parentViewModel: viewModel,
						column: column,
						sandbox: {id: this.sandbox.id},
						values: {
							UId: column.uId,
							Name: column.name,
							draggableGroupNames: draggableGroupNames,
							IsUsed: Boolean(usedColumns[column.name]),
							IsRequired: column.isRequired
						}
					}));
				}, this);
			},

			/**
			 * private
			 */
			_getBoundLocalizableConfig: function(itemConfig, bindToParameter) {
				let bindTo = BPMSoft.get(itemConfig, bindToParameter);
				let config;

				if (bindTo) {
					if (typeof bindTo === 'string' && bindTo.startsWith('$')) {
						bindTo = bindTo.replace('$', '');
					} else {
						bindTo = bindTo.bindTo;
					}
					const resourceName = this.getSchemaResourceNameFromModelResourceName(bindTo);
					if (resourceName) {
						const localizableString = this.get("PageSchema").localizableStrings.find(resourceName);
						config = {
							localizableString,
							value: this.get("Initializing") ? this.get(bindTo) : (localizableString || "").toString()
						};
					}
				}
				return config;
			},


			/**
			 * Initialize item label caption.
			 * @protected
			 * @param {Object} itemConfig Item config.
			 */
			initItemLabelCaption: function(itemConfig) {
				const localizableConfig = this._getBoundLocalizableConfig(itemConfig, "labelConfig.caption");
				if (localizableConfig) {
					itemConfig.labelConfig = Ext.apply(itemConfig.labelConfig || {}, {
						captionValue: localizableConfig.value,
						captionLocalizableValue: localizableConfig.localizableString
					});
				}
			},

			getAngularSchema: function(pageSchemaUId, parentSchemaUId, packageUId, callback) {
				var ajaxProvider = BPMSoft.AjaxProvider;
				var requestUrl = BPMSoft.workspaceBaseUrl + "/api/angularModuleController/GetDataSectionMaster?pageSchemaUId=" + pageSchemaUId + "&parentSchemaUId=" + parentSchemaUId + "&packageUId=" + packageUId;
				var request = ajaxProvider.request({
					url: requestUrl,
					headers: {
						"Accept": "application/json",
						"Content-Type": "application/json"
					},
					method: "GET",
					timeout: 6000000,
					callback: callback,
					scope: this
				});
				request.timeout = BPMSoft.BaseServiceProvider.getRequestTimeout(request);
				return request;        
			},
			
			getAppBuild: function(callback) {
				console.log("this", this)
				const pageSchemaUId = this.$Schema.schemaUId;
				const parentSchemaUId = this.$Schema.parentSchemaUId;
				const packageUId = this.getPackageUId();
				return new Promise((resolve, reject) => {
					this.getAngularSchema(pageSchemaUId, parentSchemaUId, packageUId, function(request, success, response) {
						if (success) {
							const responseObject = JSON.parse(response.responseText);
							console.log("responseObject", responseObject);
							const combinedResults = {};
							const parameterCaptions = {};
							const dataValueTypes = {}; 
			
							responseObject.angularModules.forEach((angularModule) => {
								const angularModuleInfo = angularModule.angularSchemaInfo;
								const sysSchemaUId = angularModuleInfo.sysSchemaUId;
			
								if (!combinedResults[sysSchemaUId]) {
									combinedResults[sysSchemaUId] = {
										caption: angularModule.caption,
										fileName: angularModuleInfo.schemaName,
										sysSchemaId: angularModuleInfo.sysSchemaId,
										sysSchemaUId: sysSchemaUId,
										schemaIsChanged: angularModuleInfo.isNeedAngularCompile,
										imageData: {},
										angularParameters: [],
										appWrappers: {}
									};
								}
			
								// Обрабатываем параметры ангулярного модуля
								if (angularModule.angularModuleParameters) {
									angularModule.angularModuleParameters.forEach(parameter => {
										var propExists = combinedResults[sysSchemaUId].angularParameters.some(prop => prop.name === parameter.name);
										if (!propExists) {
											combinedResults[sysSchemaUId].angularParameters.push({
												parameterUId: parameter.uId,
												name: parameter.name,
												defaultValue: parameter.defaultValue || null,
												caption: parameter.caption,
												dataValueType: parameter.dataValueType
											});
											parameterCaptions[parameter.uId] = parameter.caption;
											dataValueTypes[parameter.uId] = parameter.dataValueType;
										}
									});
								}
			
								if (angularModule.images && angularModule.images.length > 0) {
									var iconImage = angularModule.images.find(img => img.name.toLowerCase() === "icon");
									if (iconImage) {
										combinedResults[sysSchemaUId].imageData = iconImage;
									}
								}            
							});
			
							if (responseObject.wrappers) {
								responseObject.wrappers.forEach(wrapper => {
									const wrapperSysSchemaUId = wrapper.sysSchemaUId;
									if (combinedResults[wrapperSysSchemaUId]) { 
										combinedResults[wrapperSysSchemaUId].appWrappers[wrapper.uId] = {
											displayValue: wrapper.displayValue,
											name: wrapper.wrapperName,
											sysSchemaUId: wrapper.sysSchemaUId,
											uId: wrapper.uId,
											isParent: wrapper.isParent,
											params: wrapper.angularParametersValues.map(param => ({
												parameterUId: param.angularParameterUId,
												value: param.angularParameterValue,
												dataValueType: dataValueTypes[param.dataValueType],
												uId: param.uId,
												name: param.name,
												caption: parameterCaptions[param.angularParameterUId]
											}))
										};
									}
								});
							}

							// После обработки всех данных вызываем resolve
							resolve(combinedResults);
						} else {
							reject("Ошибка при запросе к getAngularSchema");
						}
					});
				});
			},

			
			getAngularCollection: function () {
				const angularCollection = this.get("AngularModulesCollection");
				return angularCollection;
			},	

			/**
			 * Initialize item tip.
			 * @protected
			 * @param {Object} itemConfig Item config.
			 */
			initItemTip: function(itemConfig) {
				const localizableConfig = this._getBoundLocalizableConfig(itemConfig, "tip.content");
				if (localizableConfig) {
					itemConfig.tip = Ext.apply(itemConfig.tip || {}, {
						tipValue: localizableConfig.value,
						tipLocalizableValue: localizableConfig.localizableString
					});
				}
			},

			/**
			 * Creates elements collection on a page.
			 * @protected
			 * @param {Object} config Grid configuration.
			 */
			createGridLayoutEditCollection: function(config) {
				config.items = BPMSoft.GridLayoutUtils.fixItemsIntersections(config.items);
				const collection = Ext.create("BPMSoft.BaseViewModelCollection");
				BPMSoft.each(config.items, function(item) {
					this.addGridLayoutItemToCollection(collection, item);
				}, this);
				return collection;
			},

			/**
			 * Returns item column object.
			 * @protected
			 * @param {Object} item Item object.
			 * @return {Object} Item column object.
			 */
			getItemColumn: function(item) {
				let itemColumn = this.columns[item.name];
				if (!itemColumn && item.bindTo) {
					itemColumn = this.columns[item.bindTo] || {};
				}
				return itemColumn;
			},

			/**
			 * Generates the name of the collection grid elements.
			 * @protected
			 * @param {Object|String} config Configuration or name of the presentation element.
			 * @return {string} Collection name of grid elements.
			 */
			getGridLayoutEditCollectionName: function(config) {
				return (config.name || config) + "Collection";
			},

			getGridLayoutEditCollection: function(config) {
				return this.get(this.getGridLayoutEditCollectionName(config));
			},

			/**
			 * Draggable item change event handler.
			 * @protected
			 * @param {BPMSoft.configuration.SchemaDesignToolItem} item Draggable item.
			 * @param {Object} config Event options.
			 */
			draggableItemChanged: function(item, config) {
				this.modifyDraggableConfigByLayoult(config);
				if (config.operation) {
					switch (config.operation) {
						case "InvalidDrop":
							this.onDraggableItemInvalidDrop(item, config);
							break;
						case "DragOver":
							this.onDraggableItemDragOver(item, config);
							break;
						case "DragDrop":
							this.onDraggableItemDragDrop(item, config);
							break;
						case "DragOut":
							this.onDraggableItemInvalidDrop(item, config);
							break;
						case "Remove":
							this.onDraggableItemRemove(item, config);
							break;
						default:
					}
				}
			},

			/**
			 * Modifies draggable item change event options.
			 * @protected
			 * @param {Object} config Event options.
			 */
			modifyDraggableConfigByLayoult: function(config) {
				if (config && config.layoutName === "ProfileContainer") {
					Ext.apply(config, {
						colSpan: 1,
						column: 0
					});
				}
			},

			/**
			 * Event handler of invalid drop, clears selection.
			 * @protected
			 */
			onDraggableItemInvalidDrop: function() {
				const collections = this.getGridLayoutEditCollections();
				BPMSoft.each(collections, function(gridLayoutEditName) {
					this.set(gridLayoutEditName + "Selection", null);
				}, this);
			},

			/**
			 * Creates design schema design item.
			 * @protected
			 * @param {BPMSoft.SchemaDesignToolItem} schemaDesignToolItem Schema design tool item.
			 * @param {Object} config Events params.
			 * @return {Object}
			 */
			createDesignSchemaItem: function(schemaDesignToolItem, config) {
				return schemaDesignToolItem.createDesignItem(this, config);
			},

			/**
			 * Event handler of drag element to the grid.
			 * @protected
			 * @param {BPMSoft.SchemaDesignToolItem} schemaDesignToolItem Schema design tool item.
			 * @param {Object} config Events params.
			 */
			onDraggableItemDragDrop: function(schemaDesignToolItem, config) {
				const currentSelection = this.get(config.layoutName + "Selection");
				if (!currentSelection) {
					return;
				}
				const designItem = this.createDesignSchemaItem(schemaDesignToolItem, config);
				designItem.addToDesignSchema(config);
			},

			/**
			 * Event handler of drag element above the grid, updates the selected area in the grid.
			 * @protected
			 * @param {BPMSoft.configuration.SchemaDesignToolItem} item Schema design tool item.
			 * @param {Object} config Params of events.
			 */
			onDraggableItemDragOver: function(item, config) {
				const selectionName = config.layoutName + "Selection";
				const layoutItems = this.getGridLayoutEditCollection(config.layoutName).getItems();
				if (this._isIntersectWithExistLayoutItems(config, layoutItems)) {
					this.set(selectionName, null);
					delete config.operation;
					return;
				}
				const selection = this.get(selectionName);
				if (!selection || !this._sameSelection(selection, config)) {
					this.set(selectionName, null);
					delete config.operation;
					this.set(selectionName, config);
				}
			},

			/**
			 * Returns list of grids on the page.
			 * @protected
			 * @return {Object} Object of grids on the page and their collection.
			 */
			getGridLayoutEditCollections: function() {
				const gridLayoutEditCollections = this.get("GridLayouts") || [];
				return BPMSoft.deepClone(gridLayoutEditCollections);
			},

			/**
			 * @inheritdoc BasePageV2#getCardPrintButtonVisible
			 * @override
			 */
			getCardPrintButtonVisible: function() {
				return false;
			},

			/**
			 * @inheritdoc BasePageV2#getSectionPrintButtonVisible
			 * @override
			 */
			getSectionPrintButtonVisible: function() {
				return false;
			},

			/**
			 * Returns control group configuration button visibility.
			 * @protected
			 * @param {String} groupName Control group name.
			 * @return {Boolean} True - if control group can be configured, false - in other case.
			 */
			getGroupConfigurationButtonVisible: function(groupName) {
				return !Ext.isEmpty(groupName);
			},

			/**
			 * Returns control group remove button visibility.
			 * @protected
			 * @param {String} groupName Control group name.
			 * @return {Boolean} True - if control group can be removed, false - in other case.
			 */
			getGroupRemoveButtonVisible: function(groupName) {
				return !Ext.isEmpty(groupName);
			},

			/**
			 * Returns non existent of all required columns on the page.
			 * @protected
			 * @return {Array}
			 */
			getNotUsedRequiredColumns: function() {
				const notUsedRequiredColumns = [];
				const usedColumns = this.get("UsedColumns");
				this.$DataModels.each(function(dataModel) {
					if (dataModel.get("Name") === "Elements") {
						return;
					}
					let columns = dataModel.get("Schema").columns;
					columns = columns.filterByFn(this.columnsFilterFn, this);
					columns.each(function(column) {
						const columnPath = dataModel.getColumnPath(column.name);
						if (column.isRequired && !usedColumns[columnPath]) {
							let columnCaption = column.getPropertyValue("caption").toString();
							if (!dataModel.get("IsPrimary")) {
								const dataModelCaption = dataModel.get("Caption");
								columnCaption = dataModelCaption + "." + columnCaption;
							}
							notUsedRequiredColumns.push(columnCaption);
						}
					}, this);
				}, this);
				return notUsedRequiredColumns;
			},

			/**
			 * Checks existence of all required columns on the page.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			validateRequiredFields: function(callback, scope) {
				const notUsedRequiredColumns = this.getNotUsedRequiredColumns();
				if (notUsedRequiredColumns.length) {
					const template = this.get("Resources.Strings.NotUsedRequiredFieldsMessage");
					const caption = Ext.String.format(template, notUsedRequiredColumns.join("\n"));
					const cancelButton = BPMSoft.getButtonConfig("no",
						BPMSoft.Resources.Controls.Button.ButtonCaptionCancel, "cancel");
					this.showConfirmationDialog(caption, function(returnCode) {
						const result = returnCode !== "no";
						callback.call(scope, result);
					}, ["ok", cancelButton], {defaultButton: 0});
				} else {
					callback.call(scope, true);
				}
			},

			/**
			 * Validating a model representation into asynchronous mode.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			asyncValidate: function(callback, scope) {
				let validationResult = true;
				const applyValidationResult = function(next, result) {
					validationResult = validationResult && result;
					if (validationResult) {
						next(validationResult);
					} else {
						callback.call(scope, validationResult);
					}
				};
				BPMSoft.chain(
					this.validateRequiredFields,
					applyValidationResult,
					function() {
						callback.call(scope, validationResult);
					},
					this);
			},

			/**
			 * Save schema changes.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			saveDesignData: function(callback, scope) {
				const maskId = BPMSoft.Mask.show();
				const schemaView = this.get("SchemaView");
				this.applyGridLayoutEditItems(schemaView);
				this.updateProfileContainerItems();
				this.applyTabOrders(schemaView);
				const pageSchema = this.$PageSchema;
				const parentSchemaView = this.get("ParentSchemaView");
				const diff = BPMSoft.JsonDiffer.getJsonDiff(parentSchemaView, schemaView,
					{identifyItemByPath: true});
				pageSchema.setSchemaDiff(diff);
				pageSchema.setSchemaDetails(this.$Schema.details);
				pageSchema.setSchemaModules(this.$Schema.modules);
				pageSchema.setSchemaDataModels(this.$Schema.dataModels);
				const dashboardItem = this.$WritableWidgetDashboardManagerItem;
				if (dashboardItem && BPMSoft.isEmptyObject(dashboardItem.getItems())) {
					BPMSoft.WidgetDashboardManager.removeIfExists(dashboardItem.getId());
					this.$WritableWidgetDashboardManagerItem = null;
				}
				this.undefViewModelClass(pageSchema);
				BPMSoft.chain(
					this.updatePageDetailsRegistration,
					this.updateSspPageColumns,
					function() {
						pageSchema.define(function(errorMessage) {
							BPMSoft.Mask.hide(maskId);
							if (errorMessage) {
								this.error(errorMessage);
							}
							callback.call(scope);
						}, this);
					}, this
				);
			},

			/**
			 * Updates page details registration.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			updatePageDetailsRegistration: function(callback, scope) {
				if (!this.$IsSspSection) {
					return Ext.callback(callback, scope || this);
				}
				const cardUId = this._getCardSchemaUId();
				const registeredDetails = BPMSoft.SspPageDetailsManager.filterByFn(function(item) {
					return item.cardSchemaUId === cardUId;
				});
				const actualDetails = this.getDesignedDetails();
				this.processRemovedDetails(actualDetails, registeredDetails);
				this.processAddedDetails(actualDetails, registeredDetails, callback, scope);
			},

			/**
			 * Retruns {@link BPMSoft.DetailManagerItem} collection for current schema details.
			 * @protected
			 * @return {BPMSoft.Collection} Current schema details items.
			 */
			getDesignedDetails: function() {
				const schema = this.get("Schema") || {};
				const designedDetailsConfig = schema.details;
				const detailItems = BPMSoft.mapObject(designedDetailsConfig, function(config) {
					return this.getDetailManagerItem(config.schemaName);
				}, this);
				const result = Ext.create("BPMSoft.Collection");
				BPMSoft.each(detailItems, function(item) {
					if (item) {
						result.add(item);
					}
				});
				return result;
			},

			/**
			 * Creates new details registration for added details.
			 * @protected
			 * @param {BPMSoft.Collection} actualDetails Current schema details {@link BPMSoft.DetailManagerItem} collection.
			 * @param {BPMSoft.Collection} registeredDetails Current schema {@link BPMSoft.SspPageDetailsManagerItem} collection.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			processAddedDetails: function(actualDetails, registeredDetails, callback, scope) {
				const pageSchema = this.$PageSchema;
				if (Ext.isEmpty(pageSchema)) {
					return Ext.callback(callback, scope || this);
				}
				const cardUId = this._getCardSchemaUId();
				const newItems = [];
				actualDetails.each(function(actualItem) {
					if (!registeredDetails.any(function(item) {
						return actualItem.getId() === item.getSysDetailId();
					})) {
						newItems.push(actualItem);
					}
				}, this);
				if (Ext.isEmpty(newItems)) {
					return Ext.callback(callback, scope || this);
				}
				const generatorFn = function(newItem) {
					return function(next) {
						this.registerDetailOnPage(newItem, cardUId, next, this);
					}.bind(this);
				}.bind(this);
				BPMSoft.chainForArray(newItems, generatorFn, function() {
					this._updateSspSectionModifiedOn(callback, scope);
				}, this);
			},

			/**
			 * Removes details registration for removed details.
			 * @protected
			 * @param {BPMSoft.Collection} actualDetails Current schema details {@link BPMSoft.DetailManagerItem} collection.
			 * @param {BPMSoft.Collection} registeredDetails Current schema {@link BPMSoft.SspPageDetailsManagerItem} collection.
			 */
			processRemovedDetails: function(actualDetails, registeredDetails) {
				registeredDetails.each(function(registeredItem) {
					if (!actualDetails.any(function(item) {
						return item.getId() === registeredItem.getSysDetailId();
					})) {
						registeredItem.remove();
					}
				}, this);
			},

			/**
			 * Creates new {@link BPMSoft.SspPageDetailsManagerItem} for added detail.
			 * @protected
			 * @param {BPMSoft.DetailManagerItem} detail {@link BPMSoft.DetailManagerItem} instance.
			 * @param {String} cardUId Current schema uid.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			registerDetailOnPage: function(detail, cardUId, callback, scope) {
				const manager = BPMSoft.SspPageDetailsManager;
				const config = {
					propertyValues: {
						cardSchemaUId: cardUId,
						entitySchemaUId: detail.getEntitySchemaUId()
					}
				};
				manager.createItem(config, function(item) {
					item.setSysDetailId(detail.getId());
					item.detail = detail;
					manager.addItem(item);
					Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Updates used on SSP page columns list.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			updateSspPageColumns: function(callback, scope) {
				if (!this.$IsSspSection) {
					return Ext.callback(callback, scope || this);
				}
				BPMSoft.chain(
					this.getPortalSchemaAccessList,
					function(next, portalSchemaItem) {
						this.getSspUsedColumns(function(columns) {
							Ext.callback(next, scope || this, [columns, portalSchemaItem]);
						}, this);
					},
					function(next, columns, portalSchemaItem) {
						const portalSchemaItemId = portalSchemaItem.getId();
						this.getNewPortalColumnAccessListItemsConfig(portalSchemaItemId, columns, function(newSspColumns) {
							Ext.callback(next, scope || this, [newSspColumns]);
						}, this);
					},
					function(next, newSspColumns) {
						this.createPortalColumnAccessListItems(newSspColumns, callback, scope || this);
					}, this);
			},

			/**
			 * Returns current section {@link BPMSoft.PortalSchemaAccessListManagerItem} instance.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			getPortalSchemaAccessList: function(callback, scope) {
				const manager = BPMSoft.PortalSchemaAccessListManager;
				const entitySchema = this.entitySchema;
				const entitySchemaName = entitySchema.name;
				const portalSchemaItem = manager.findByFn(function(item) {
					return item.entitySchemaName === entitySchemaName;
				});
				if (portalSchemaItem) {
					return Ext.callback(callback, scope || this, [portalSchemaItem]);
				}
				const config = {
					propertyValues: {
						entitySchemaName: entitySchemaName,
						entitySchemaUId: entitySchema.uId
					}
				};
				manager.createItem(config, function(item) {
					Ext.callback(callback, scope || this, [manager.addItem(item)]);
				}, this);
			},

			/**
			 * Returns used on current page columns collection.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			getSspUsedColumns: function(callback, scope) {
				const usedColumns = this.$UsedColumns;
				const entitySchema = this._getEntitySchemaInstance();
				let columnNames = BPMSoft.keys(usedColumns);
				const detailFilterColumns = this.getDetailsFilterColumns();
				columnNames = Ext.Array.merge(columnNames, detailFilterColumns);
				const columns = entitySchema.columns.filterByFn(function(item) {
					return Ext.Array.contains(columnNames, item.name);
				});
				Ext.callback(callback, scope || this, [columns]);
			},

			/**
			 * Returns used as detail filters columns names array.
			 * @protected
			 * @return {Array} Used as detail filters columns names array.
			 */
			getDetailsFilterColumns: function() {
				const schema = this.get("Schema") || {};
				const designedDetailsConfig = schema.details;
				const columnNames = [];
				BPMSoft.each(designedDetailsConfig, function(config) {
					const filters = config.filter || {};
					const masterColumn = filters.masterColumn;
					if (!Ext.isEmpty(masterColumn)) {
						columnNames.push(masterColumn);
					}
				}, this);
				return columnNames;
			},

			/**
			 * Returns an array of configs for the {@link BPMSoft.PortalColumnAccessListManagerItem} to be created.
			 * @protected
			 * @param {String} portalSchemaItemId Current section {@link BPMSoft.PortalSchemaAccessListManagerItem}
			 * identifier.
			 * @param {BPMSoft.Collection} columns Used columns collection.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			getNewPortalColumnAccessListItemsConfig: function(portalSchemaItemId, columns, callback, scope) {
				const manager = BPMSoft.PortalColumnAccessListManager;
				const newSspColumns = [];
				columns.each(function(column) {
					const uId = column.uId;
					const columnItem = manager.findByFn(function(item) {
						return item.columnUId === uId && item.getPortalSchemaListId() === portalSchemaItemId &&
							!this.isColumnReferenceSchemaChanged(column);
					}, this);
					if (Ext.isEmpty(columnItem)) {
						newSspColumns.push({
							"columnUId": uId,
							"portalSchemaItemId": portalSchemaItemId
						});
					}
				}, this);
				Ext.callback(callback, scope || this, [newSspColumns]);
			},

			/**
			 * Returns sign that lookup column reference schema was changed.
			 * @protected
			 * @param {Object} column Lookup column.
			 */
			isColumnReferenceSchemaChanged: function(column) {
				const usedLookupColumns = this.$UsedLookupColumns;
				const referenceSchemaUId = column.referenceSchemaUId;
				const referenceSchema = BPMSoft.EntitySchemaManager.findItem(referenceSchemaUId);
				const uId = column.uId;
				return usedLookupColumns.find(uId) && referenceSchemaUId && referenceSchema &&
					referenceSchema.name !== usedLookupColumns.find(uId);
			},

			/**
			 * Creates and adds to manager new {@link BPMSoft.PortalColumnAccessListManagerItem}.
			 * @protected
			 * @param {Array} newSspColumns new {@link BPMSoft.PortalColumnAccessListManagerItem} config arrays.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			createPortalColumnAccessListItems: function(newSspColumns, callback, scope) {
				if (Ext.isEmpty(newSspColumns)) {
					return Ext.callback(callback, scope || this);
				}
				const generatorFn = function(newItem) {
					return function(next) {
						this.registerColumnOnPage(newItem, next, this);
					}.bind(this);
				}.bind(this);
				BPMSoft.chainForArray(newSspColumns, generatorFn, function() {
					this._updateSspSectionModifiedOn(callback, scope);
				}, this);
			},

			/**
			 * Creates and adds to manager new {@link BPMSoft.PortalColumnAccessListManagerItem}.
			 * @protected
			 * @param {Object} newItemConfig new {@link BPMSoft.PortalColumnAccessListManagerItem} config.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function scope.
			 */
			registerColumnOnPage: function(newItemConfig, callback, scope) {
				const manager = BPMSoft.PortalColumnAccessListManager;
				const config = {
					propertyValues: {
						columnUId: newItemConfig.columnUId
					}
				};
				manager.createItem(config, function(item) {
					item.setPortalSchemaListId(newItemConfig.portalSchemaItemId);
					item.entitySchema = this._getEntitySchemaInstance();
					manager.addItem(item);
					Ext.callback(callback, scope || this);
				}, this);
			},

			/**
			 * Finds {@link BPMSoft.DetailManagerItem} by name.
			 * @protected
			 * @param {String} detailName Detail schema name.
			 * @return {BPMSoft.DetailManagerItem|null}  {@link BPMSoft.DetailManagerItem} instance.
			 */
			getDetailManagerItem: function(detailSchemaName) {
				return BPMSoft.DetailManager.findByFn(function(item) {
					return item.detailSchemaName === detailSchemaName;
				});
			},

			/**
			 * Update profile container items.
			 * @protected
			 */
			updateProfileContainerItems: function() {
				const profileContainer = this.getSchemaViewItem("ProfileContainer");
				if (profileContainer && profileContainer.items) {
					BPMSoft.each(profileContainer.items, function(item) {
						Ext.apply(item.layout, {
							"colSpan": 24,
							"column": 0
						});
					}, this);
				}
			},

			/**
			 * Removes information about the created class of view model schema.
			 * @protected
			 * @param {BPMSoft.manager.ClientUnitSchema} instance Instance of scheme.
			 */
			undefViewModelClass: function(instance) {
				const entitySchemaName = this.get("EntitySchemaName");
				instance.undefViewModelClass(entitySchemaName);
			},

			/**
			 * Returns prepared grid layouts by collections.
			 * @protected
			 * @param {Object[]} collections Collections.
			 * @return {Object}
			 */
			getGridLayoutsByCollections: function(collections) {
				const gridLayouts = {};
				BPMSoft.each(collections, function(gridLayoutName) {
					const collectionName = this.getGridLayoutEditCollectionName(gridLayoutName);
					gridLayouts[gridLayoutName] = gridLayouts[gridLayoutName] || [];
					const gridLayoutCollection = this.get(collectionName);
					if (!Ext.isEmpty(gridLayoutCollection)) {
						gridLayoutCollection.each(function(item) {
							item.updateLayout();
							const itemConfig = item.itemConfig;
							this._updateItemLabelCaption(itemConfig);
							if (BPMSoft.Features.getIsDisabled("DisableEntityColumnTooltipField")) {
								this._updateItemTip(itemConfig);
							}
							gridLayouts[gridLayoutName].push(itemConfig);
						}, this);
					}
				}, this);
				return gridLayouts;
			},

			/**
			 * Updates order property for tabs from schema view.
			 * @protected
			 * @param {Object} schemaView Scheme view.
			 */
			applyTabOrders: function(schemaView) {
				if (!this.getIsFeatureEnabled("UseTabOrderProperty")) {
					return;
				}
				let tabs;
				BPMSoft.iterateChildItems(schemaView, function(iterationConfig) {
					const item = iterationConfig.item;
					if (item.name === "Tabs" && item.tabs) {
						tabs = item.tabs;
					}
				}, this);
				if (!tabs) {
					return;
				}
				tabs.forEach(function(item) {
					const itemOrder = this.$TabsCollection.indexOfKey(item.name);
					if (itemOrder >= 0) {
						item.order = itemOrder;
					}
				}, this);
			},

			/**
			 * Updates the given scheme of new grid elements.
			 * @protected
			 * @param {Object} schemaView Scheme view.
			 */
			applyGridLayoutEditItems: function(schemaView) {
				const collections = this.getGridLayoutEditCollections();
				const gridLayouts = this.getGridLayoutsByCollections(collections);
				BPMSoft.iterateChildItems(schemaView, function(iterationConfig) {
					const schemaItem = iterationConfig.item;
					const schemaItemConfigItems = gridLayouts[schemaItem.name];
					if (!Ext.isEmpty(schemaItemConfigItems) || Ext.isArray(schemaItemConfigItems)) {
						schemaItem.items = schemaItemConfigItems;
					}
				}, this);
			},

			/**
			 * @inheritdoc BasePageV2#loadDetail
			 * @override
			 */
			loadDetail: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BasePageV2#onRender
			 * @override
			 */
			onRender: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BasePageV2#getTabsContainerVisible
			 * @override
			 */
			getTabsContainerVisible: function() {
				return true;
			},

			/**
			 * @inheritdoc BasePageV2#getDefaultTabName
			 * @override
			 */
			getDefaultTabName: function() {
				let tabName = this.callParent(arguments);
				if (!this.hasTab(tabName)) {
					tabName = null;
				}
				return tabName;
			},

			/**
			 * Has active tab.
			 * @protected
			 * @return {Boolean} True - if tab collection contains active tab, false - otherwise.
			 */
			hasActiveTab: function() {
				const activeTabName = this.get("ActiveTabName");
				return this.hasTab(activeTabName);
			},

			/**
			 * Has tab.
			 * @protected
			 * @return {Boolean} True - if tab collection contains tab with input tab name, false - otherwise.
			 */
			hasTab: function(tabName) {
				const tabsCollection = this.get("TabsCollection");
				return tabsCollection.contains(tabName);
			},

			/**
			 * Tab items ordered.
			 * @protected
			 */
			onTabOrderedChange: function(tabName, position) {
				const moveDiff = this.generateTabMoveDiff(tabName, position);
				this.onSchemaChanged(moveDiff);
			},

			/*
			 * Open the window of detail settings.
			 * @protected
			 */
			openDetailSettingWindow: function(eventName, modelMethod, model, tag) {
				this.set("EditableDetailName", tag || null);
				if (BPMSoft.Features.getIsDisabled("DisableDetailPropertiesPage")) {
					this._openDetailSetting();
				} else {
					this.sandbox.loadModule("ModalBoxSchemaModule", {id: this.getDetailModalBoxWindowId()});
				}
			},

			/**
			 * Save tab configuration.
			 * @protected
			 * @param {Object} tabConfig Tab configuration.
			 */
			onSaveTabConfig: function(tabConfig) {
				const {caption, name} = tabConfig;
				const isNewTab = this.get("IsNewTab");
				if (isNewTab) {
					this.saveNewTab(caption, name);
				} else {
					const activeTabName = this.get("ActiveTabName");
					const tabsCollection = this.get("TabsCollection");
					const activeTab = tabsCollection.get(activeTabName);
					if (name !== activeTabName) {
						this._modifyTab(activeTabName, name);
					}
					const updateConfig = {
						tab: activeTab,
						name: name || activeTabName,
						value: caption
					};
					this.updateTabCaption(updateConfig);
				}
			},

			/**
			 * Adds new tab.
			 * @protected
			 */
			addTab: function() {
				this.showTabModalBox(true);
			},

			/**
			 * Saves new tab.
			 * @protected
			 * @param {String | BPMSoft.LocalizableString} tabCaption Caption of the created tab.
			 * @param {String} [tabName] Name of the created tab.
			 */
			saveNewTab: function(tabCaption, tabName) {
				if (!tabName) {
					tabName = this._getNewTabName();
				}
				this._newItemNames.push(tabName);
				const resourceName = BPMSoft.ViewModelSchemaDesignerUtils.generateTabCaptionResourcesName(tabName);
				this._addNewTabLocalizableString(resourceName, tabCaption);
				const viewModelResourceName =
					BPMSoft.ViewModelSchemaDesignerUtils.getModelStringResourceName(resourceName);
				const tabsCollection = this.$TabsCollection;
				const newTabIndex = this.getTabIndex(tabsCollection, this.$ActiveTabName) + 1;
				if (tabCaption instanceof BPMSoft.LocalizableString) {
					const caption = tabCaption.getValue();
					this.set(viewModelResourceName, caption);
					this._addTabToCollection(tabName, caption, newTabIndex);
				} else {
					this.set(viewModelResourceName, tabCaption);
					this._addTabToCollection(tabName, tabCaption, newTabIndex);
				}
				const insertDiff = this.generateTabInsertDiff(tabName, viewModelResourceName, newTabIndex);
				this.onSchemaChanged(insertDiff);
				this.setNextActiveTabByIndex(tabsCollection, newTabIndex);
			},

			/**
			 * Returns whether tab with name tabName can be removed or not.
			 * @param {String} tabName Tab name.
			 * @return {Boolean}
			 */
			canRemoveTab: function(tabName) {
				const tabsCollection = this.get("TabsCollection");
				return Boolean(tabName) && tabsCollection.getCount() > 1;
			},

			/**
			 * Removes tab.
			 * @protected
			 */
			removeTab: function() {
				const activeTabName = this.get("ActiveTabName");
				if (this.canRemoveTab(activeTabName)) {
					const tabsCollection = this.get("TabsCollection");
					const index = this.getTabIndex(tabsCollection, activeTabName);
					tabsCollection.removeByKey(activeTabName);
					const removeDiff = this.generateTabRemoveDiff(activeTabName);
					this.onSchemaChanged(removeDiff);
					this.setNextActiveTabByIndex(tabsCollection, index);
				}
			},

			/**
			 * Returns tab remove button visibility.
			 * @protected
			 * @return {boolean} true - if tab can be removed, false - in other case.
			 */
			getTabRemoveButtonVisible: function() {
				if (this.getIsFeatureEnabled("UseTabOrderProperty")) {
					return true;
				}
				return this.get("ActiveTabName") !== "ESNTab";
			},

			/**
			 * Returns tab index.
			 * @protected
			 * @param {Object} collection Tabs collection.
			 * @param {String} name Tab name.
			 * @return {Number} Tab index.
			 */
			getTabIndex: function(collection, name) {
				return collection.getKeys().indexOf(name);
			},

			/**
			 * Sets next active tab.
			 * @protected
			 * @param {Object} collection Tabs collection.
			 * @param {Number} index Tab index.
			 */
			setNextActiveTabByIndex: function(collection, index) {
				const keys = collection.getKeys();
				const length = keys.length;
				index = (index >= length) ? length - 1 : index;
				if (length > 0) {
					this.set("ActiveTabName", keys[index]);
				}
			},

			/**
			 * Returns Tab modal box config.
			 * @return {Object}
			 */
			getTabModalBoxConfig: function() {
				const tabCaption = this.getTabCaption();
				return {
					schemaName: "ViewModelSchemaDesignerTabModalBox",
					tabCaption: tabCaption,
					modalBoxSize: {
						"width": "500px",
						"height": "185px"
					}
				};
			},

			/**
			 * Returns tab caption for tab modal box.
			 * @return {String}
			 */
			getTabCaption: function() {
				const tabsCollection = this.get("TabsCollection");
				const isNewTab = this.get("IsNewTab");
				let tabCaption = this.get("Resources.Strings.NewTabNameModalBox") || "";
				if (this.hasActiveTab() && !isNewTab) {
					const activeTabName = this.get("ActiveTabName");
					const activeTab = tabsCollection.get(activeTabName);
					tabCaption = activeTab.get("Caption");
				}
				return tabCaption;
			},

			/**
			 * Returns tab modal box window id.
			 * @return {String}
			 */
			getTabModalBoxWindowId: function() {
				return this.sandbox.id + "_TabModalBox";
			},

			/**
			 * Show tab modal box window.
			 * @protected
			 * @param {Boolean} newTab Whether new tab.
			 */
			showTabModalBox: function(newTab) {
				this.set("IsNewTab", newTab);
				if (!BPMSoft.Features.getIsEnabled("DisableTabPropertiesPage")) {
					this._openTabSetting();
				} else {
					this.sandbox.loadModule("ModalBoxSchemaModule", {
						id: this.getTabModalBoxWindowId()
					});
				}
			},

			/**
			 * Edits tab caption.
			 * @protected
			 */
			editTab: function() {
				if (this.hasActiveTab()) {
					this.showTabModalBox(false);
				}
			},

			/**
			 * Update tab caption.
			 * @param {Object} config Configuration.
			 * @param {Object} config.tab Tab.
			 * @param {String} config.name Tab name.
			 * @param {String | BPMSoft.LocalizableString} config.value Tab caption.
			 */
			updateTabCaption: function(config) {
				const caption = config.value instanceof BPMSoft.LocalizableString
					? config.value.getValue()
					: config.value;
				config.tab.set("Caption", caption);
				const tabCaptionResourceName =
					BPMSoft.ViewModelSchemaDesignerUtils.generateTabCaptionResourcesName(config.name);
				this.updateItemCaption(config.name, config.value, tabCaptionResourceName);
			},

			/**
			 * Removes the detail.
			 * @protected
			 */
			removeDetail: function(eventName, modelMethod, model, tag) {
				this._removeDetail(tag);
			},

			/**
			 * Returns detail edit availability.
			 * @param {String} detailKey Unique detail key.
			 * @return {Boolean} Detail edit availability.
			 */
			canEditDetail: function(detailKey) {
				const detail = this._getSchemaDetail(detailKey);
				if (!detail) {
					return false;
				}
				return this._isRegisteredDetail(detail);
			},

			/**
			 * Generates the name for the group caption of the resource.
			 * @protected
			 * @param {String} groupName Name of the group.
			 * @return {String} Name of resource of group caption.
			 */
			generateGroupCaptionResourcesName: function(groupName) {
				return groupName + "GroupCaption";
			},

			/**
			 * Generates the name for the item label caption of the resource.
			 * @protected
			 * @param {String} itemName Name of the item.
			 * @return {String} Name of resource of group caption.
			 */
			generateLabelCaptionResourcesName: function(itemName) {
				return itemName.replace(/-/g, "") + "LabelCaption";
			},

			/**
			 * Gets the name for the detail caption of the resource.
			 * @protected
			 * @param {String} detailKey Unique detail key.
			 * @return {String} Name of resource of detail caption.
			 */
			getDetailCaptionResourcesName: function(detailKey) {
				return detailKey + "DetailCaption";
			},

			/**
			 * Returns full name of the resource which bind to the item caption.
			 * @protected
			 * @param {String} itemName Name of element.
			 * @return {String|null} Full name of the resource item caption.
			 */
			getCaptionResourcesName: function(itemName) {
				let groupCaptionResourcesCache = this.get("CaptionResourcesCache");
				if (!groupCaptionResourcesCache) {
					groupCaptionResourcesCache = {};
					this.set("CaptionResourcesCache", groupCaptionResourcesCache);
				}
				if (groupCaptionResourcesCache[itemName]) {
					return groupCaptionResourcesCache[itemName];
				}
				const group = this.getSchemaViewItem(itemName);
				if (group && group.caption && group.caption.bindTo) {
					groupCaptionResourcesCache[itemName] = group.caption.bindTo;
					return group.caption.bindTo;
				}
				return null;
			},

			/**
			 * @deprecated
			 */
			getLabelCaptionResourceName: function(itemName) {
				const item = this.getSchemaViewItem(itemName);
				const labelConfig = item && item.labelConfig;
				const caption = labelConfig && labelConfig.caption;
				return caption && caption.bindTo;
			},

			/**
			 * Finds the element into the scheme of the page.
			 * @protected
			 * @param {String} itemName Name of item.
			 * @return {Object} Configuration of item.
			 */
			getSchemaViewItem: function(itemName) {
				const schemaView = this.get("SchemaView");
				let result = null;
				BPMSoft.iterateChildItems(schemaView, function(iterationConfig) {
					const item = iterationConfig.item;
					const isItemFound = (item.name === itemName);
					if (isItemFound) {
						result = item;
					}
					return !isItemFound;
				}, this);
				return result;
			},

			/**
			 * Opens control group settings window.
			 * @protected
			 */
			openGroupSettingWindow: function(eventName, modelMethod, model, tag) {
				this.set("ChangingControlGroupName", tag);
				if (BPMSoft.Features.getIsEnabled("DisableControlGroupPropertiesPage")) {
					this.sandbox.loadModule("ModalBoxSchemaModule", {
						id: this.getControlGroupModalBoxWindowId()
					});
				} else {
					this._openGroupSetting();
				}
			},

			/**
			 * Updates control group caption.
			 * @protected
			 * @param {String} itemName Control group name.
			 * @param {String} captionCaption Control group caption.
			 * @param {String} defaultResourceItemCaption Control group caption resource.
			 */
			updateItemCaption: function(itemName, captionCaption, defaultResourceItemCaption) {
				defaultResourceItemCaption = defaultResourceItemCaption || itemName;
				let modelStringResourceName = this.getCaptionResourcesName(itemName);
				const instance = this.get("PageSchema");
				let localizableString = Ext.create("BPMSoft.LocalizableString");
				const diff = [];
				let bindTo;
				if (Ext.isEmpty(modelStringResourceName)) {
					bindTo = defaultResourceItemCaption;
					const utils = BPMSoft.ViewModelSchemaDesignerUtils;
					modelStringResourceName = utils.getModelStringResourceName(defaultResourceItemCaption);
					instance.localizableStrings.add(defaultResourceItemCaption, localizableString);
					diff.push({
						"operation": "merge",
						"name": itemName,
						"values": {
							"caption": {"bindTo": modelStringResourceName}
						}
					});
				} else {
					bindTo = this.getSchemaResourceNameFromModelResourceName(modelStringResourceName);
					if (instance.localizableStrings.contains(bindTo)) {
						localizableString = instance.localizableStrings.get(bindTo);
					} else {
						instance.localizableStrings.add(bindTo, localizableString);
					}
				}
				this.set(modelStringResourceName, captionCaption || " ");
				if (captionCaption instanceof BPMSoft.LocalizableString) {
					instance.localizableStrings.replace(localizableString, captionCaption, bindTo);
				} else {
					localizableString.setValue(captionCaption);
				}
				this.onSchemaChanged(diff);
			},

			/**
			 * Removes control group.
			 * @protected
			 */
			removeGroup: function(eventName, modelMethod, model, tag) {
				this.removeTabContentItem(tag);
			},

			/**
			 * Generates the name of resource of string from the name parameter of model.
			 * @protected
			 * @param {String} resourceName Parameter of model.
			 * @return {String} Name of resource.
			 */
			getSchemaResourceNameFromModelResourceName: function(resourceName) {
				const resourceRegex = /^Resources\.Strings\.(.*?)$/;
				const result = resourceRegex.exec(resourceName);
				return result && result.length > 1 ? result[1] : null;
			},

			/**
			 * Adds control group to the active tab.
			 * @protected
			 * @return {String} New group name.
			 */
			addGroup: function(name) {
				const groupName = name || this._getNewGroupName();
				const activeTabItems = this.getActiveTabItems();
				const controlGroupViewModel = activeTabItems.createItem({
					Name: groupName,
					ItemType: BPMSoft.ViewItemType.CONTROL_GROUP
				});
				const index = activeTabItems.getCount();
				activeTabItems.add(groupName, controlGroupViewModel, index);
				return groupName;
			},

			/**
			 * @private
			 */
			_modifyGroup: function(oldName, newName) {
				const activeTabItems = this.getActiveTabItems();
				this._modifyItem(activeTabItems, oldName, newName);
			},

			/**
			 * @private
			 */
			_modifyTab: function(oldName, newName) {
				this._modifyItem(this.$TabsCollection, oldName, newName);
				this.$ActiveTabName = newName;
			},

			/**
			 * @private
			 */
			_modifyItem: function(itemCollection, oldName, newName) {
				const item = itemCollection.get(oldName);
				itemCollection.replace(item, item, newName);
				item.$Name = newName;
				const oldResourceName = BPMSoft.ViewModelSchemaDesignerUtils
					.generateTabCaptionResourcesName(oldName);
				const localizableStrings = this.$PageSchema.localizableStrings;
				if (localizableStrings.contains(oldResourceName)) {
					localizableStrings.removeByKey(oldResourceName);
				}
				const viewItem = this.getSchemaViewItem(oldName);
				viewItem.name = newName;
				const index = this._newItemNames.indexOf(oldName);
				this._newItemNames[index] = newName;
			},

			/**
			 * Adds detail to the active tab.
			 * @protected
			 * @param {String} detailKey Unique detail name.
			 * @param {Number} [detailIndex] Detail Index.
			 * @return {String} Unique detail name.
			 */
			addDetail: function(detailKey, detailIndex) {
				const activeTabItems = this.getActiveTabItems();
				const detailViewModel = activeTabItems.createItem({
					Name: detailKey,
					ItemType: BPMSoft.ViewItemType.DETAIL
				});
				const index = detailIndex || activeTabItems.getCount();
				activeTabItems.add(detailKey, detailViewModel, index);
				return detailKey;
			},

			/**
			 * Handler of the click on the action element of the grid.
			 * @protected
			 * @param {String} actionName Name of action.
			 * @param {String} modelItemId Unique id of grid element.
			 * @param {String} layoutName Name of grid.
			 */
			onItemActionClick: function(actionName, modelItemId, layoutName) {
				switch (actionName) {
					case "removeModelItem":
						this.removeModelItem(layoutName, modelItemId);
						break;
					case "openModelItemSettingWindow":
						this.openModelItemSettingWindow(layoutName, modelItemId);
						break;
					default:
				}
			},

			getDesignerModuleId: function() {
				return this.designSchema.sandbox.id + "_ModelItemConfigModule";
			},

			/**
			 * Open the window of grid element settings.
			 * @protected
			 * @param {String} layoutName Collection of grid elements.
			 * @param {String} modelItemId Unique id of grid element.
			 */
			openModelItemSettingWindow: function(layoutName, modelItemId) {
				const collectionName = this.getGridLayoutEditCollectionName(layoutName);
				const collection = this.get(collectionName);
				const item = collection.get(modelItemId);
				if (item.itemConfig?.markerValue === 'AngularModule') {
					if (item.itemConfig.isParent) {
						return;
					}
				}
				item.edit({layoutName: layoutName});
			},

			/**
			 * Remove the grid element.
			 * @protected
			 * @param {String} layoutName Collection of grid elements.
			 * @param {String} modelItemId Unique id of grid element.
			 */
			removeModelItem: function(layoutName, modelItemId) {
				const collectionName = this.getGridLayoutEditCollectionName(layoutName);
				const collection = this.get(collectionName);
				const modelItem = collection.get(modelItemId);
				modelItem.removeFromDesignSchema({layoutName: layoutName});
			},

			/**
			 * Removes tab content item by name.
			 * @private
			 * @param {String} itemName Tab content item name.
			 */
			removeTabContentItem: function(itemName) {
				const activeTabItems = this.getActiveTabItems();
				activeTabItems.removeByKey(itemName);
			},

			/**
			 * Generates adding control group diff.
			 * @protected
			 * @param {Object} item Control group view model.
			 * @param {Number} index Control group index.
			 * @param {String} key Control group name.
			 * @return {Array} Adding control group diff.
			 */
			onAddControlGroup: function(item, index, key) {
				const itemsCollection = Ext.create("BPMSoft.BaseViewModelCollection");
				const activeTabName = this.get("ActiveTabName");
				const utils = BPMSoft.ViewModelSchemaDesignerUtils;
				const gridLayoutName = utils.getUniqueItemName(activeTabName + "GridLayout");
				const gridLayout = this.get("GridLayouts");
				gridLayout.push(gridLayoutName);
				const itemsCollectionName = this.getGridLayoutEditCollectionName(gridLayoutName);
				this.set(itemsCollectionName, itemsCollection);
				this.addDraggableGroupName(gridLayoutName);
				const groupCaptionResourceName = this.generateGroupCaptionResourcesName(key);
				const instance = this.get("PageSchema");
				instance.localizableStrings.add(groupCaptionResourceName, Ext.create("BPMSoft.LocalizableString"));
				this.set(groupCaptionResourceName, " ");
				const groupNameCaption = utils.getModelStringResourceName(groupCaptionResourceName);
				return [{
					"operation": "insert",
					"parentName": activeTabName,
					"name": key,
					"propertyName": "items",
					"index": index,
					"values": {
						"caption": {"bindTo": groupNameCaption},
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"markerValue": "added-group",
						"items": []
					}
				}, {
					"operation": "insert",
					"parentName": key,
					"propertyName": "items",
					"name": gridLayoutName,
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				}];
			},

			/**
			 * Generates adding detail diff.
			 * @protected
			 * @return {Array} Adding detail diff.
			 */
			onAddDetail: function(item, index, key) {
				const activeTabName = this.get("ActiveTabName");
				return [{
					"operation": "insert",
					"parentName": activeTabName,
					"name": key,
					"propertyName": "items",
					"index": index,
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"markerValue": "added-detail"
					}
				}];
			},

			/**
			 * Adds element to tab item content and rerenders view.
			 * @protected
			 * @param {Object} item Element view model.
			 * @param {Number} index Element index.
			 * @param {String} key Element name.
			 */
			onAddTabContentItem: function(item, index, key) {
				let diff;
				const itemType = item.get("ItemType");
				if (itemType === BPMSoft.ViewItemType.CONTROL_GROUP) {
					diff = this.onAddControlGroup(item, index, key);
				}
				if (itemType === BPMSoft.ViewItemType.DETAIL) {
					diff = this.onAddDetail(item, index, key);
				}
				if (diff !== null) {
					this.onSchemaChanged(diff);
				}
			},

			/**
			 * Removes element from tab item content and rerenders view.
			 * @protected
			 * @param {Object} item Element view model.
			 * @param {String} key Element name.
			 */
			onRemoveTabContentItem: function(item, key) {
				const diff = [{
					"operation": "remove",
					"name": key
				}];
				this.onSchemaChanged(diff);
			},

			/**
			 * Moves element in tab item content and rerenders view.
			 * @protected
			 * @param {Number} fromIndex Moving element index.
			 * @param {Number} toIndex Destination index.
			 * @param {String} fromKey Moving element name.
			 */
			onMoveTabContentItem: function(fromIndex, toIndex, fromKey) {
				const diff = [{
					"operation": "move",
					"name": fromKey,
					"parentName": this.get("ActiveTabName"),
					"propertyName": "items",
					"index": toIndex
				}];
				this.onSchemaChanged(diff);
			},

			/**
			 * Subscribes tab collection item events.
			 * @param {Object} tabItem Tab item.
			 */
			subscribeTabCollectionItemEvents: function(tabItem) {
				const tabItemCollection = tabItem.get("Content");
				if (!Ext.isEmpty(tabItemCollection)) {
					tabItemCollection.on("add", this.onAddTabContentItem, this);
					tabItemCollection.on("remove", this.onRemoveTabContentItem, this);
					tabItemCollection.on("move", this.onMoveTabContentItem, this);
					tabItemCollection.on("replace", this._onReplaceTabContentItem, this);
				}
			},

			/**
			 * Unsubscribes tab collection item events.
			 * @param {Object} tabItem Tab item.
			 */
			unsubscribeTabCollectionItemEvents: function(tabItem) {
				const tabItemCollection = tabItem.get("Content");
				if (!Ext.isEmpty(tabItemCollection)) {
					tabItemCollection.un("add", this.onAddTabContentItem, this);
					tabItemCollection.un("remove", this.onRemoveTabContentItem, this);
					tabItemCollection.un("move", this.onMoveTabContentItem, this);
				}
			},

			/**
			 * Subscribes on tab collection events.
			 * @protected
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			subscribeTabCollectionEvents: function(callback, scope) {
				const tabCollection = this.get("TabsCollection");
				if (tabCollection) {
					tabCollection.on("add", this.subscribeTabCollectionItemEvents, this);
					tabCollection.each(function(tabItem) {
						this.subscribeTabCollectionItemEvents(tabItem);
					}, this);
				}
				callback.call(scope);
			},

			/**
			 * Unsubscribes from tab collection events.
			 * @protected
			 */
			unsubscribeTabCollectionEvents: function() {
				const tabCollection = this.get("TabsCollection");
				if (tabCollection) {
					tabCollection.un("add", this.subscribeTabCollectionItemEvents, this);
					tabCollection.each(function(tabItem) {
						this.unsubscribeTabCollectionItemEvents(tabItem);
					}, this);
				}
			},

			/**
			 * @inheritdoc BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				const relatedProfileItems = this.get("RelatedProfileItems");
				if (relatedProfileItems) {
					relatedProfileItems.un("move", this.onRelatedProfileItemMove, this);
				}
				this.unsubscribeTabCollectionEvents();
				Ext.EventManager.un(window, "beforeunload", this.onBeforeUnload, this);
				this.callParent(arguments);
			},

			/**
			 * Returns tab item id.
			 * @protected
			 * @param {String} tabItemContentItemId Tab item container id.
			 * @return {String} Tab item id.
			 */
			getTabItemContentIdFromContainer: function(tabItemContentItemId) {
				const containerSuffix = "DraggableContainer";
				return tabItemContentItemId.substring(0, tabItemContentItemId.length - containerSuffix.length);
			},

			/**
			 * Returns active tab items.
			 * @protected
			 * @return {BPMSoft.Collection} Active tab items.
			 */
			getActiveTabItems: function() {
				const activeTabName = this.get("ActiveTabName");
				const tabCollection = this.get("TabsCollection");
				const activeTab = tabCollection.get(activeTabName);
				return activeTab.get("Content");
			},

			/**
			 * Returns current tab item reorderable index name.
			 * @protected
			 * @return {String} Current tab item reorderable index name.
			 */
			getCurrentTabItemContentReorderableIndexName: function() {
				return this.get("ActiveTabName") + "ReorderableIndex";
			},

			/**
			 * Updates reorderable index after dragenter event fire.
			 * @protected
			 * @param {String} crossedItemId crossed element id.
			 */
			onTabContainerItemDragEnter: function(crossedItemId) {
				const reorderableIndexName = this.getCurrentTabItemContentReorderableIndexName();
				this.set(reorderableIndexName, null);
				const activeTabItems = this.getActiveTabItems();
				const crossedContentItemId = this.getTabItemContentIdFromContainer(crossedItemId);
				const activeTabKeys = activeTabItems.getKeys();
				let index = activeTabKeys.indexOf(crossedContentItemId);
				if (index === -1) {
					index = crossedItemId ? -1 : null;
				}
				this.set(reorderableIndexName, index);
			},

			/**
			 * Clears reorderable index value.
			 * @protected
			 */
			onTabContainerItemDragOut: function() {
				this.set(this.getCurrentTabItemContentReorderableIndexName(), null);
			},

			/**
			 * Reorders tab item content collection.
			 * @protected
			 * @param {String} droppableItemId Dropping element identifier.
			 */
			onTabContainerItemDragDrop: function(droppableItemId) {
				const reorderableIndexName = this.getCurrentTabItemContentReorderableIndexName();
				let reorderableIndex = this.get(reorderableIndexName);
				this.set(reorderableIndexName, null);
				const activeTabItems = this.getActiveTabItems();
				const droppableContentItemId = this.getTabItemContentIdFromContainer(droppableItemId);
				const activeTabKeys = activeTabItems.getKeys();
				const droppableContentItemIndex = activeTabKeys.indexOf(droppableContentItemId);
				if (!Ext.isEmpty(reorderableIndex)) {
					if (droppableContentItemIndex === -1 || reorderableIndex <= droppableContentItemIndex) {
						reorderableIndex++;
					}
					activeTabItems.move(droppableContentItemIndex, reorderableIndex);
					return true;
				}
				return false;
			},

			/**
			 * Returns control group modal box window id.
			 * @protected
			 * @return {String} Control group modal box window id.
			 */
			getControlGroupModalBoxWindowId: function() {
				return this.sandbox.id + "_ControlGroupModalBox";
			},

			/**
			 * Returns detail modal box window id.
			 * @protected
			 * @return {String} Control group modal box window id.
			 */
			getDetailModalBoxWindowId: function() {
				return this.sandbox.id + "_DetailModalBox";
			},

			/**
			 * Returns control group caption.
			 * @protected
			 * @param {String} controlGroupName Control group name.
			 * @return {String} Control group caption.
			 */
			getControlGroupCaption: function(controlGroupName) {
				const captionResourcesName = this.getCaptionResourcesName(controlGroupName);
				return Ext.isEmpty(captionResourcesName) ? "" : this.get(captionResourcesName);
			},

			/**
			 * Returns control group modal box configuration.
			 * @protected
			 * @return {Object} Control group modal box configuration.
			 */
			getControlGroupModalBoxConfig: function() {
				const controlGroupName = this.get("ChangingControlGroupName");
				const caption = Ext.isEmpty(controlGroupName) ? "" : this.getControlGroupCaption(controlGroupName);
				return {
					"schemaName": "ViewModelSchemaDesignerControlGroupModalBox",
					"controlGroupCaption": caption,
					"modalBoxSize": {
						"width": "500px",
						"height": "185px"
					}
				};
			},

			/**
			 * @private
			 */
			_getDetailConfig: function() {
				const detailKey = this.get("EditableDetailName");
				const entitySchema = this.getDetailEntitySchema();
				let detailConfig = null;
				const isNew = Ext.isEmpty(detailKey);
				const details = this.get("Schema").details;
				const detailNames = Object.keys(details).filter((item) => item !== detailKey);
				if (!isNew) {
					const detail = this._getSchemaDetail(detailKey);
					const resourceName = BPMSoft.ViewModelSchemaDesignerUtils.generateDetailCaptionResourcesName(detailKey);
					const designClientUnitSchema = this.get("PageSchema");
					const localizableDetailCaption = designClientUnitSchema.localizableStrings.contains(resourceName)
						? designClientUnitSchema.localizableStrings.get(resourceName)
						: null;
					detailConfig = {
						detailSchemaName: detail.schemaName,
						detailEntitySchemaName: detail.entitySchemaName,
						masterEntitySchemaColumn: detail.filter && detail.filter.masterColumn,
						detailEntitySchemaColumn: detail.filter && detail.filter.detailColumn,
						localizableDetailCaption: localizableDetailCaption,
						detailKey
					};
				}
				return {
					detailConfig: detailConfig,
					masterEntitySchema: entitySchema,
					packageUId: this.getPackageUId(),
					canEdit: isNew || !Ext.isEmpty(details[detailKey]),
					detailNames
				};
			},

			/**
			 * Returns detail modal box configuration.
			 * @protected
			 * @return {Object} Detail modal box configuration.
			 */
			getDetailModalBoxConfig: function() {
				const detailKey = this.get("EditableDetailName");
				const entitySchema = this.getDetailEntitySchema();
				let detailConfig = null;
				const canEditDetailColumn = Ext.isEmpty(detailKey);
				if (!canEditDetailColumn) {
					const detail = this._getSchemaDetail(detailKey);
					const resourceName = BPMSoft.ViewModelSchemaDesignerUtils.generateDetailCaptionResourcesName(detailKey);
					const designClientUnitSchema = this.get("PageSchema");
					const localizableDetailCaption = designClientUnitSchema.localizableStrings.contains(resourceName)
						? designClientUnitSchema.localizableStrings.get(resourceName)
						: null;
					detailConfig = {
						detailSchemaName: detail.schemaName,
						detailEntitySchemaName: detail.entitySchemaName,
						masterEntitySchemaColumn: detail.filter && detail.filter.masterColumn,
						detailEntitySchemaColumn: detail.filter && detail.filter.detailColumn,
						localizableDetailCaption: localizableDetailCaption
					};
				}
				return {
					schemaName: "ViewModelSchemaDesignerDetailModalBox",
					modalBoxSize: {
						width: "500px",
						height: "280px"
					},
					detailConfig: detailConfig,
					masterEntitySchema: entitySchema,
					packageUId: this.getPackageUId(),
					canEditDetailColumn: canEditDetailColumn,
					canEditConnectionColumns: canEditDetailColumn || !Ext.isEmpty(this.get("Schema").details[detailKey])
				};
			},

			/**
			 * Returns detail schema.
			 * @protected
			 * @return {Object}.
			 */
			getDetailEntitySchema: function() {
				const firstDataModel = this.dataModelCollection.first();
				return firstDataModel && firstDataModel.designSchema;
			},

			/**
			 * Saves new control group caption.
			 * @protected
			 * @param {Object} config Configuration object.
			 * @param {String} config.caption Control group caption.
			 * @param {String} config.name Control group name.
			 */
			onSaveControlGroupConfig: function(config) {
				let controlGroupName = this.get("ChangingControlGroupName");
				const controlGroupCaption = config.caption;
				if (Ext.isEmpty(controlGroupName)) {
					controlGroupName = this.addGroup(config.name);
					this._newItemNames.push(controlGroupName);
				}
				if (!BPMSoft.Features.getIsEnabled("DisableControlGroupPropertiesPage")) {
					if (controlGroupName !== config.name) {
						this._modifyGroup(controlGroupName, config.name);
						controlGroupName = config.name;
					}
				}
				const resourceName = this.generateGroupCaptionResourcesName(controlGroupName);
				this.updateItemCaption(controlGroupName, controlGroupCaption, resourceName);
			},

			/**
			 * Saves detail.
			 * @protected
			 * @param {Object} config Configuration object.
			 * @param {String} config.detailSchemaName Detail schema name.
			 * @param {String} config.detailEntitySchemaName Detail entity schema name.
			 * @param {String} config.detailEntitySchemaColumn Detail entity schema connection column name.
			 * @param {String} config.masterEntitySchemaColumn Master entity schema connection column name.
			 * @param {String} config.localizableDetailCaption Localizable detail caption.
			 * @param {String} config.isDetailCaptionChanged Detail caption changed mark.
			 * @param {String} [config.detailKey] Detail key.
			 */
			onSaveDetailConfig: function(config) {
				const detailKey = this.get("EditableDetailName");
				if (detailKey) {
					if (config.detailKey && detailKey !== config.detailKey) {
						this._modifyDetail(detailKey, config);
					} else {
						this._saveExistingDetail(detailKey, config);
					}
				} else {
					this._saveNewDetail(config);
				}
			},

			/**
			 * @private
			 */
			_modifyDetail: function(detailKey, config) {
				const activeTabItems = this.getActiveTabItems();
				const detail = activeTabItems.get(detailKey);
				config.detailIndex = activeTabItems.indexOf(detail);
				this._removeDetail(detailKey);
				this._saveNewDetail(config);
			},

			/**
			 * @private
			 */
			_removeDetail: function(key) {
				const currentSchema = this.get("Schema");
				const currentSchemaDetails = currentSchema.details;
				this.removeTabContentItem(key);
				delete currentSchemaDetails[key];
			},

			/**
			 * @private
			 */
			_isEmptyLocalizableItemColumn: function (value, localizableValue) {
				return Ext.isEmpty(value) &&
					(Ext.isEmpty(localizableValue) || !localizableValue.hasAnyCultureValue());
			},

			/**
			 * Updates item label caption.
			 * @private
			 * @param {Object} itemConfig Item config.
			 */
			_updateItemLabelCaption: function(itemConfig) {
				const labelConfig = itemConfig.labelConfig;
				const caption = labelConfig && labelConfig.caption;
				const bindTo = caption && caption.bindTo;
				const captionValue = labelConfig && Ext.clone(labelConfig.captionValue);
				const captionLocalizableValue = labelConfig && labelConfig.captionLocalizableValue &&
					labelConfig.captionLocalizableValue.clone();
				if (labelConfig) {
					delete labelConfig.captionValue;
					delete labelConfig.captionLocalizableValue;
				}
				const isBindToLocalizableString = bindTo && this._isExistsLocalizableString(bindTo);
				if (this._isEmptyLocalizableItemColumn(captionValue, captionLocalizableValue)) {
					if (BPMSoft.isEmptyObject(labelConfig) || isBindToLocalizableString) {
						delete itemConfig.labelConfig;
					}
					return;
				}
				var resourceName;
				if (isBindToLocalizableString) {
					resourceName = this.getSchemaResourceNameFromModelResourceName(bindTo);
				} else {
					resourceName = this.generateLabelCaptionResourcesName(itemConfig.name);
					labelConfig.caption = {
						bindTo: BPMSoft.ViewModelSchemaDesignerUtils.getModelStringResourceName(resourceName)
					};
				}
				const itemLabelCaption = captionLocalizableValue && captionLocalizableValue.hasAnyCultureValue()
					? captionLocalizableValue
					: captionValue;
				this.updateItemLabelCaptionResource(resourceName, itemLabelCaption);
			},

			/**
			 * Updates item tip.
			 * @private
			 * @param {Object} itemConfig Item config.
			 */
			_updateItemTip: function(itemConfig) {
				const tipConfig = itemConfig.tip;
				const tip = tipConfig && tipConfig.content;
				const bindTo = tip && tip.bindTo;
				const tipValue = tipConfig && Ext.clone(tipConfig.tipValue);
				const tipLocalizableValue = tipConfig && tipConfig.tipLocalizableValue &&
					tipConfig.tipLocalizableValue.clone();
				if (tipConfig) {
					delete tipConfig.tipValue;
					delete tipConfig.tipLocalizableValue;
				}
				const isBindToLocalizableString = bindTo && this._isExistsLocalizableString(bindTo);
				if (this._isEmptyLocalizableItemColumn(tipValue, tipLocalizableValue)) {
					if (BPMSoft.isEmptyObject(tipConfig) || isBindToLocalizableString) {
						delete itemConfig.tip;
					}
					return;
				}
				let resourceName;
				if (isBindToLocalizableString) {
					resourceName = this.getSchemaResourceNameFromModelResourceName(bindTo);
				} else {
					resourceName = this._generateTipResourcesName(itemConfig.name);
					tipConfig.content = {
						bindTo: BPMSoft.ViewModelSchemaDesignerUtils.getModelStringResourceName(resourceName)
					};
				}
				const itemLabelCaption = tipLocalizableValue && tipLocalizableValue.hasAnyCultureValue()
					? tipLocalizableValue
					: tipValue;
				this.updateItemLabelCaptionResource(resourceName, itemLabelCaption);
			},

			/**
			 * Updates item label caption resource.
			 * @protected
			 * @param {String} resourceName Resource name.
			 * @param {String | BPMSoft.LocalizableString} caption Caption.
			 */
			updateItemLabelCaptionResource: function(resourceName, caption) {
				const instance = this.get("PageSchema");
				let localizableString = Ext.create("BPMSoft.LocalizableString");
				if (instance.localizableStrings.contains(resourceName)) {
					localizableString = instance.localizableStrings.get(resourceName);
				} else {
					instance.localizableStrings.add(resourceName, localizableString);
				}
				if (caption instanceof BPMSoft.LocalizableString) {
					localizableString.clear();
					localizableString.merge(caption);
				} else {
					localizableString.setValue(caption);
				}
			},

			/**
			 * Handler of the double click on the action element of the grid.
			 * @protected
			 * @param {String} modelItemId Unique id of grid element.
			 * @param {String} layoutName Name of grid.
			 */
			onItemDblClick: function(modelItemId, layoutName) {
				this.openModelItemSettingWindow(layoutName, modelItemId);
			},		

			/**
			 * Event handler of remove item.
			 * @protected
			 * @param {BPMSoft.SchemaDesignToolItem} item Schema design tool item.
			 */
			onDraggableItemRemove: function(item) {
				const uId = item.get("UId");
				const dataModelSchema = item.parentViewModel.get("Schema");
				const column = dataModelSchema.columns.get(uId);
				let message;
				if (column.isInherited) {
					message = this.get("Resources.Strings.ColumnIsInheritedMessage");
					this.showInformationDialog(message);
					return;
				}
				const columnName = item.get("itemId");
				if (!this._checkDataModelDependencies(columnName, dataModelSchema)) {
					message = this.get("Resources.Strings.DataModelBindsToColumnMessage");
					this.showInformationDialog(message);
					return;
				}
				this._checkBusinessRuleColumnDependencies(columnName, dataModelSchema, function() {
					this._removeExistingModelDraggableItem(uId, item.parentViewModel);
					dataModelSchema.columns.remove(column);
				}, this);
			},

			/**
			 * @protected
			 */
			onAddDataModelButtonClick: function() {
				this.$EditDataModelName = null;
				this.openDataSourcePropertiesPage();
			},

			/**
			 * @protected
			 */
			onEditDataSource: function(name) {
				this.$EditDataModelName = name;
				this.openDataSourcePropertiesPage();
			},

			/**
			 * @protected
			 */
			onRemoveDataSource: function(name, next, scope) {
				const dataModel = this.$DataModels.get(name);
				this.showBodyMask();
				this._checkBusinessRuleDataSourceDependencies(dataModel, function() {
					this.$DataModels.removeByKey(name);
					this._removeDataModelFromSchema(name);
					this.updateGridLayoutEditCollection();
					this.hideBodyMask();
					Ext.callback(next, scope);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#initHasAnyDcm
			 * @override
			 */
			initHasAnyDcm: function(callback, scope) {
				Ext.callback(callback, scope);
			},

			//endregion

			//region Public

			/**
			 * Opens data source properties page.
			 */
			openDataSourcePropertiesPage: function() {
				this.showBodyMask();
				this.sandbox.loadModule("ModalBoxSchemaModule", {
					id: this._getAddDataSourceWindowId(),
					instanceConfig: {
						initialSize: {
							width: 356,
							height: 328
						}
					}
				});
			},

			/**
			 * Updates grid layout items. Removes removed data model columns.
			 */
			updateGridLayoutEditCollection: function() {
				const grid = this.get("GridLayouts");
				const usedColumns = this.get("UsedColumns") || {};
				BPMSoft.each(grid, function(config) {
					const collectionName = this.getGridLayoutEditCollectionName(config);
					const collection = this.get(collectionName);
					collection.each(function(item) {
						const itemConfig = item.itemConfig;
						const bindTo = itemConfig.bindTo || itemConfig.name;
						const bindToConfig = this._parseItemBindTo(bindTo);
						if (bindToConfig.schemaColumn) {
							item.onContentChange();
						} else {
							collection.removeByKey(itemConfig.name);
							delete usedColumns[bindTo];
						}
					}, this);
				}, this);
				this.set("UsedColumns", usedColumns);
			},

			/**
			 * Init WidgetDashboardManager items when WritableWidgetDashboardManagerItem is empty.
			 * Creates new items if needed.
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initWidgetDashboardManagerItems: function(callback, scope) {
				BPMSoft.WidgetDashboardManager.initialize(null, function() {
					if (this.$WritableWidgetDashboardManagerItem) {
						return Ext.callback(callback, scope);
					}
					this._initWritableWidgetDashboardManagerItem()
						.then(this._initReadableWidgetDashboardItemCollection.bind(this))
						.then(function() {
							Ext.callback(callback, scope);
						});
				}, this);
			},

			//endregion

			/**
			 * Gets content value for NewFieldsDisabledToolTipMessage.
			 * @return {String} NewFieldsDisabledToolTipMessage value.
			 */
			getNewFieldsDisabledToolTipMessage: function() {
				return this.get("Resources.Strings.NewFieldsDisabledToolTipMessage");
			},
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "DesignContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["design-container-wrapClass"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DraggableItemsContainer",
				"parentName": "DesignContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["draggable-items-list", "fixed"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FixedBottomItemsContainer",
				"parentName": "DesignContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["fixed-bottom-items-container"]},
					"visible": {"bindTo": "SupportParametersDataModel"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DataModels",
				"parentName": "DraggableItemsContainer",
				"propertyName": "items",
				"index": 4,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DataModelItem",
				"parentName": "DataModels",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"classes": {"wrapClassName": ["data-model-item"]},
					"className": "BPMSoft.ContainerList",
					"idProperty": "Name",
					"itemPrefix": "data-model",
					"dataItemIdPrefix": "data-model",
					"collection": {"bindTo": "DataModels"},
					"defaultItemConfig": {
						"id": "data-model",
						"className": "BPMSoft.ControlGroup",
						"classes": {"wrapClassName": ["data-model-item"]},
						"caption": {"bindTo": "Caption"},
						"collapsed": {"bindTo": "Collapsed"},
						"tag": "DataModel",
						"items": [
							{
								"className": "BPMSoft.Label",
								"caption": {"bindTo": "Resources.Strings.ElementsCaption"},
								"classes": {"labelClass": ["items-label"]},
								"visible": {
									"bindTo": "NewElementDraggableItems",
									"bindConfig": {"converter": "isNotEmptyValue"}
								},
								"markerValue": "ElementsLabel"
							},
							{
								"className": "BPMSoft.ContainerList",
								"idProperty": "Name",
								"itemPrefix": "new-column",
								"dataItemIdPrefix": "new-column",
								"collection": {"bindTo": "NewElementDraggableItems"},
								"visible": {"bindTo": "IsPageElementsVisible"},
								"markerValue": "NewElementsContainer",
								"defaultItemConfig": {
									"className": "BPMSoft.Container",
									"items": [
										{
											"classes": {"wrapClassName": ["draggable-item"]},
											"className": "BPMSoft.ViewModelSchemaDesignerItem",
											"draggableGroupNames": {"bindTo": "draggableGroupNames"},
											"invalidDrop": {"bindTo": "onInvalidDrop"},
											"dragOver": {"bindTo": "onDragOver"},
											"dragDrop": {"bindTo": "onDragDrop"},
											"dragOut": {"bindTo": "onDragOut"},
											"imageConfig": {"bindTo": "getImageConfig"},
											"content": {"bindTo": "getContent"}
										}
									]
								}
							},
							{
								"className": "BPMSoft.Label",
								"id": "AngularLabel",
								"caption": "Angular Модули",
								"classes": {"labelClass": ["items-label"]},
								"visible": {"bindTo": "IsPageElementsVisible"},
								"markerValue": "AngularLabel"				
							},
							{
								"className": "BPMSoft.ContainerList",
								"idProperty": "Name",
								"itemPrefix": "new-angular-column",
								"dataItemIdPrefix": "new-angular-column",
								"collection": {"bindTo": "ExistingAngularModelDraggableItems"},
								"markerValue": "NewAngularElementsContainer",
								"defaultItemConfig": {
									"className": "BPMSoft.Container",
									"items": [
										{
											"classes": {"wrapClassName": ["draggable-angular-item"]},
											"className": "BPMSoft.ViewModelSchemaDesignerItem",
											"draggableGroupNames": {"bindTo": "draggableGroupNames"},
											"invalidDrop": {"bindTo": "onInvalidDrop"},
											"dragOver": {"bindTo": "onDragOver"},
											"dragDrop": {"bindTo": "onDragDrop"},
											"dragOut": {"bindTo": "onDragOut"},
											"imageConfig": {"bindTo": "getImageConfig"},
											"content": {"bindTo": "getContent"},
											"isSchemaIsChanged": {"bindTo": "isSchemaIsChanged"},
										}
									]
								}
							},
							{
								"className": "BPMSoft.Label",
								"caption": {"bindTo": "Resources.Strings.WidgetsCaption"},
								"classes": {"labelClass": ["items-label"]},
								"visible": {"bindTo": "IsPageElementsVisible"},
								"markerValue": "WidgetsLabel"
							},
							{
								"className": "BPMSoft.Container",
								"visible": {"bindTo": "IsNewPageSchema"},
								"classes": {"wrapClassName": "new-column-info-button-container"},
								"markerValue": "NewWidgetInfoButtonContainer",
								"items": [
									{
										"className": "BPMSoft.Label",
										"markerValue": "NewWidgetInfoLabel",
										"labelClass": ["new-fields-info-label"],
										"caption": {"bindTo": "Resources.Strings.NewFieldsDisabledMessage"}
									},
									{
										"className": "BPMSoft.InformationButton",
										"markerValue": "NewWidgetInfoButton",
										"tips": [{"tip": {"content": {"bindTo": "Resources.Strings.WidgetInNewSectionWarning"}}}]
									}
								]
							},
							{
								"className": "BPMSoft.ContainerList",
								"idProperty": "Name",
								"itemPrefix": "new-column",
								"dataItemIdPrefix": "new-column",
								"collection": {"bindTo": "NewWidgetsModelDraggableItems"},
								"visible": {
									"bindTo": "IsNewPageSchema",
									"bindConfig": {
										"converter": function() {
											return this.get("IsPageElementsVisible") && !this.get("IsNewPageSchema");
										}
									}
								},
								"markerValue": "NewWidgetsContainer",
								"defaultItemConfig": {
									"className": "BPMSoft.Container",
									"items": [
										{
											"classes": {"wrapClassName": ["draggable-item"]},
											"className": "BPMSoft.ViewModelSchemaDesignerItem",
											"draggableGroupNames": {"bindTo": "draggableGroupNames"},
											"invalidDrop": {"bindTo": "onInvalidDrop"},
											"dragOver": {"bindTo": "onDragOver"},
											"dragDrop": {"bindTo": "onDragDrop"},
											"dragOut": {"bindTo": "onDragOut"},
											"imageConfig": {"bindTo": "getImageConfig"},
											"content": {"bindTo": "getContent"}
										}
									]
								}
							},
							{
								"className": "BPMSoft.Label",
								"caption": {"bindTo": "Resources.Strings.NewColumnCaption"},
								"classes": {"labelClass": ["items-label"]},
								"visible": {"bindTo": "NewColumnCaptionVisible"},
								"markerValue": "NewColumnLabel"
							},
							{
								"className": "BPMSoft.Container",
								"visible": {
									"bindTo": "CanAddNewColumn",
									"bindConfig": {
										"converter": function() {
											return !this.get("CanAddNewColumn") && this.get("NewColumnCaptionVisible");
										}
									}
								},
								"classes": {"wrapClassName": "new-column-info-button-container"},
								"markerValue": "NewFieldsDisabledContainer",
								"tips": [
									{
										"tip": {
											"content": {"bindTo": "Resources.Strings.NewFieldsDisabledToolTipMessage"},
											"style": BPMSoft.controls.TipEnums.style.ORANGE
										}
									}
								],
								"items": [
									{
										"className": "BPMSoft.Button",
										"id": "NewColumnsInfoButton",
										"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
										"imageConfig": {"bindTo": "Resources.Images.InfoSpriteImage"},
										"classes": {
											"wrapperClass": "info-button",
											"imageClass": "info-button-image"
										},
									},
									{
										"className": "BPMSoft.Tip",
										"id": "NewColumnsInfoTip",
										"style": BPMSoft.controls.TipEnums.style.ORANGE,
										"content": {"bindTo": "getNewFieldsDisabledToolTipMessage"},
									},
									{
										"className": "BPMSoft.Label",
										"markerValue": "NewColumnsInfoLabel",
										"labelClass": ["new-fields-info-label"],
										"caption": {"bindTo": "Resources.Strings.NewFieldsDisabledMessage"}
									}
								]
							},
							{
								"className": "BPMSoft.ContainerList",
								"idProperty": "Name",
								"itemPrefix": "new-column",
								"dataItemIdPrefix": "new-column",
								"visible": {"bindTo": "CanAddNewColumn"},
								"collection": {"bindTo": "NewModelDraggableItems"},
								"markerValue": "NewColumnsContainer",
								"defaultItemConfig": {
									"className": "BPMSoft.Container",
									"items": [
										{
											"classes": {"wrapClassName": ["draggable-item"]},
											"className": "BPMSoft.ViewModelSchemaDesignerItem",
											"draggableGroupNames": {"bindTo": "draggableGroupNames"},
											"invalidDrop": {"bindTo": "onInvalidDrop"},
											"dragOver": {"bindTo": "onDragOver"},
											"dragDrop": {"bindTo": "onDragDrop"},
											"dragOut": {"bindTo": "onDragOut"},
											"imageConfig": {"bindTo": "getImageConfig"},
											"content": {"bindTo": "getContent"}
										}
									]
								}
							},
							{
								"className": "BPMSoft.Label",
								"caption": {"bindTo": "Resources.Strings.ExistingColumnsCaption"},
								"classes": {"labelClass": ["items-label"]},
								"visible": {
									"bindTo": "ExistingModelDraggableItems",
									"bindConfig": {"converter": "isNotEmptyValue"}
								},
								"markerValue": "ExistingColumnLabel"
							},
							{
								"className": "BPMSoft.ContainerList",
								"idProperty": "Name",
								"dataItemIdPrefix": "existed-column",
								"collection": {"bindTo": "ExistingModelDraggableItems"},
								"visible": {
									"bindTo": "ExistingModelDraggableItems",
									"bindConfig": {"converter": "isNotEmptyValue"}
								},
								"markerValue": "ExistingColumnsContainer",
								"defaultItemConfig": {
									"id": "existed-column",
									"className": "BPMSoft.Container",
									"items": [
										{
											"className": "BPMSoft.ViewModelSchemaDesignerItem",
											"draggableGroupNames": {"bindTo": "draggableGroupNames"},
											"invalidDrop": {"bindTo": "onInvalidDrop"},
											"dragOver": {"bindTo": "onDragOver"},
											"dragDrop": {"bindTo": "onDragDrop"},
											"dragOut": {"bindTo": "onDragOut"},
											"content": {"bindTo": "content"},
											"imageConfig": {"bindTo": "imageConfig"},
											"isUsed": {"bindTo": "IsUsed"},
											"isRequired": {"bindTo": "IsRequired"},
											"menu": {"items": {"bindTo": "ToolsMenuItems"}},
											"enableRightIcon": {"bindTo": "EnableRightIcon"},
											"classes": {"wrapClassName": ["draggable-item"]}
										}
									]
								}
							}
						]
					}
				}
			},
			{
				"operation": "insert",
				"name": "AddDataModelButton",
				"parentName": "FixedBottomItemsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"caption": {"bindTo": "Resources.Strings.AddDataModelButton"},
					"imageConfig": {"bindTo": "Resources.Images.AddDataModelButtonImage"},
					"click": {"bindTo": "onAddDataModelButtonClick"},
					"classes": {
						"imageClass": ["add-data-model-btn-image"],
						"wrapperClass": ["add-data-model-btn-wrapper"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "CardWidgetDesigner",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"id": "CardWidgetWrapDesignerContainer",
					"wrapClass": ["card-widget-designer-container-wrapClass"],
					"visible": {"bindTo": "CardWidgetDesignerContainerVisible"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "CardWidgetDesignerMainContainer",
				"propertyName": "items",
				"parentName": "CardWidgetDesigner",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"id": "CardWidgetDesignerMainContainer",
					"wrapClass": ["card-widget-designer-main-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DesignedView",
				"parentName": "DesignContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.DESIGN_VIEW,
					"items": []
				}
			},
			{
				"operation": "move",
				"name": "CardContentWrapper",
				"parentName": "DesignedView",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_DIFF*/,
		infoDiff: [
			{
				"operation": "insert",
				"name": "errorInfoContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["designer-info-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "errorInfoImage",
				"parentName": "errorInfoContainer",
				"propertyName": "items",
				"values": {
					"className": "BPMSoft.ImageEdit",
					"readonly": true,
					"classes": {"wrapClass": ["image-control"]},
					"onPhotoChange": "emptyFn",
					"getSrcMethod": "EmptyInfoImageSrc",
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			},
			{
				"operation": "insert",
				"name": "titleInfoLabel",
				"parentName": "errorInfoContainer",
				"propertyName": "items",
				"values": {
					"classes": {"labelClass": ["title"]},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.DesignerErrorInfoTitleMessage"}
				}
			},
			{
				"operation": "insert",
				"name": "descriptionInfoLabel",
				"parentName": "errorInfoContainer",
				"propertyName": "items",
				"values": {
					"classes": {"labelClass": ["description"]},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.DesignerErrorInfoDescriptionMessage"}
				}
			}
		]
	};
});
