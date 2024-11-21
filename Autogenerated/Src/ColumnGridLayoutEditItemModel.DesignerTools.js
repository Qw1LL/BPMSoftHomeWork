define("ColumnGridLayoutEditItemModel", ["ModalBox", "GridLayoutEditItemModel"], function(ModalBox) {

	/**
	 * Class of ColumnGridLayoutEditItemModel
	 */
	Ext.define("BPMSoft.configuration.ColumnGridLayoutEditItemModel", {
		extend: "BPMSoft.GridLayoutEditItemModel",
		alternateClassName: "BPMSoft.ColumnGridLayoutEditItemModel",

		/**
		 * @type {BPMSoft.EntitySchemaColumn}
		 */
		column: null,

		/**
		 * @type {BPMSoft.ViewModelColumnType}
		 */
		itemColumnType: null,

		/**
		 * @type {BPMSoft.BaseViewModel}
		 */
		parentViewModel: null,

		/**
		 * @type {String}
		 */
		schemaModelItemDesignerName: null,

		/**
		 * @type {Boolean}
		 */
		isUsed: false,

		/**
		 * Returns item valid value.
		 * @private
		 * @return {Boolean}
		 */
		isValidItem: function() {
			const itemType = this.itemConfig && this.itemConfig.itemType;
			const isValidViewModelColumnType = BPMSoft.contains(BPMSoft.ViewModelColumnType, this.itemColumnType);
			const hasType = Ext.isNumeric(itemType) || isValidViewModelColumnType;
			return !Ext.isEmpty(this.column) || hasType;
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getImageConfig
		 * @overridden
		 */
		getImageConfig: function() {
			const dataValueType = this.get("DataValueType");
			const resourceName = this.getResourceNameForDataValueType(dataValueType);
			return this.get(resourceName);
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getDragActionCode
		 * @overridden
		 */
		getDragActionCode: function() {
			const dataValueType = this.get("DataValueType");
			const contentType = this.itemConfig.contentType;
			if (BPMSoft.isTextDataValueType(dataValueType) && contentType === BPMSoft.ContentType.LONG_TEXT) {
				return this.callParent(arguments);
			} else {
				return BPMSoft.DragAction.MOVE | BPMSoft.DragAction.RESIZE_LEFT | BPMSoft.DragAction.RESIZE_RIGHT;
			}
		},

		/**
		 * Returns the localizable resource name depending on the transmitted data type.
		 * @protected
		 * @virtual
		 * @param {BPMSoft.DataValueType} dataValueType Data type.
		 * @return {string} Localizable resource name.
		 */
		getResourceNameForDataValueType: function(dataValueType) {
			switch (dataValueType) {
				case BPMSoft.DataValueType.TEXT:
				case BPMSoft.DataValueType.SHORT_TEXT:
				case BPMSoft.DataValueType.MEDIUM_TEXT:
				case BPMSoft.DataValueType.LONG_TEXT:
				case BPMSoft.DataValueType.MAXSIZE_TEXT:
					return "Resources.Images.TextEditImage";
				case BPMSoft.DataValueType.INTEGER:
					return "Resources.Images.IntegerEditImage";
				case BPMSoft.DataValueType.FLOAT:
				case BPMSoft.DataValueType.FLOAT1:
				case BPMSoft.DataValueType.FLOAT2:
				case BPMSoft.DataValueType.FLOAT3:
				case BPMSoft.DataValueType.FLOAT4:
				case BPMSoft.DataValueType.FLOAT8:
				case BPMSoft.DataValueType.MONEY:
					return "Resources.Images.FloatEditImage";
				case BPMSoft.DataValueType.DATE_TIME:
				case BPMSoft.DataValueType.DATE:
				case BPMSoft.DataValueType.TIME:
					return "Resources.Images.DateTimeEditImage";
				case BPMSoft.DataValueType.LOOKUP:
					return "Resources.Images.LookupEditImage";
				case BPMSoft.DataValueType.ENUM:
					return "Resources.Images.ComboBoxEditImage";
				case BPMSoft.DataValueType.BOOLEAN:
					return "Resources.Images.CheckBoxImage";
				default:
					return "";
			}
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getCaption
		 * @overridden
		 */
		getCaption: function() {
			if (this.column) {
				let caption = (this.column.caption || this.column.name).toString();
				if (this.isUsed && (!this.parentViewModel.$IsPrimary ||
						this.parentViewModel.$Name === "Parameters")) {
					caption += " (" + this.parentViewModel.get("Caption") + ")";
				}
				return caption;
			}
			let result = this.itemConfig.bindTo || this.itemConfig.name;
			if (!this.isValidItem()) {
				result += " " + this.get("Resources.Strings.RemovedInvalidColumnCaption");
			}
			return result;
		},

		/**
		 * Initializes data value type.
		 * @protected
		 * @virtual
		 */
		initDataValueType: function() {
			const column = this.column;
			if (column) {
				this.set("DataValueType", column.dataValueType);
			}
		},

		/**
		 * Returns array of classes for current item.
		 * @protected
		 * @virtual
		 * @return {String[]} Array of CSS classes.
		 */
		getItemClasses: function() {
			const column = this.column;
			const wrapClasses = [];
			if (column && column.isRequired) {
				wrapClasses.push("is-required");
			}
			return wrapClasses;
		},

		/**
		 * Initializes IsRequired attribute.
		 * @protected
		 * @virtual
		 */
		initIsRequired: function() {
			const column = this.column || {};
			const itemConfig = this.itemConfig || {};
			const isRequired = column.isRequired || itemConfig.isRequired;
			this.set("IsRequired", isRequired);
		},

		/**
		 * Column changes event handler.
		 * @protected
		 * @virtual
		 */
		onContentChange: function() {
			this.initIsRequired();
			this.initDataValueType();
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			if (this.column) {
				this.column.on("changed", this.onContentChange, this);
			}
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getConfigurationButtonVisible
		 * @overridden
		 */
		getConfigurationButtonVisible: function() {
			return this.column && !this.itemConfig.generator;
		},

		/**
		 * @inheritdoc BPMSoft.BaseViewModel#destroy
		 * @overridden
		 */
		destroy: function() {
			if (this.column) {
				this.column.un("changed", this.onContentChange, this);
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.Component#getDomAttributes
		 * @overridden
		 */
		getDomAttributes: function() {
			return {
				"data-valid-column": this.isValidItem(),
				"data-required": this.get("IsRequired")
			};
		},

		/**
		 * Returns entity schema column for design item.
		 * @protected
		 * @return {BPMSoft.EntitySchemaColumn} Entity schema column for design item.
		 */
		getDesignEntitySchemaColumn: function() {
			return this.column;
		},

		/**
		 * Returns item config for design item.
		 * @protected
		 * @param {BPMSoft.ViewModelSchemaDesignerSchema} designSchema Design schema.
		 * @param {String} layoutName Layout name.
		 * @return {Object} Item config for design item.
		 */
		getDesignItemConfig: function(designSchema, layoutName) {
			const currentSelection = designSchema.get(layoutName + "Selection");
			const itemConfig = BPMSoft.deepClone(this.itemConfig);
			Ext.apply(itemConfig.layout, currentSelection);
			itemConfig.bindTo = this.parentViewModel.getColumnPath(itemConfig.name);
			itemConfig.name += BPMSoft.generateGUID();
			return itemConfig;
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#createDesignItem
		 * @overridden
		 */
		createDesignItem: function(designSchema, config) {
			if (this.schemaModelItemDesignerName === null) {
				throw new BPMSoft.NullOrEmptyException();
			}
			return Ext.create(Ext.getClassName(this), {
				designSchema: designSchema,
				parentViewModel: this.parentViewModel,
				itemConfig: this.getDesignItemConfig(designSchema, config.layoutName),
				column: this.getDesignEntitySchemaColumn(designSchema),
				schemaModelItemDesignerName: this.schemaModelItemDesignerName,
				isUsed: true
			});
		},

		/**
		 * Adds design item to design schema collection.
		 * @protected
		 * @virtual
		 * @param {String} layoutName Collection of grid elements.
		 */
		addItemToDesignSchemaCollection: function(layoutName) {
			const designSchema = this.designSchema;
			const collection = designSchema.getGridLayoutEditCollection(layoutName);
			const itemConfig = this.itemConfig;
			collection.add(itemConfig.name, this);
			const usedColumns = designSchema.get("UsedColumns");
			if (Ext.isEmpty(usedColumns[itemConfig.bindTo])) {
				usedColumns[itemConfig.bindTo] = 0;
			}
			usedColumns[itemConfig.bindTo]++;
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#getMessages
		 * @overridden
		 */
		getMessages: function() {
			const designerModuleId = this.getDesignerModuleId();
			return [{
				ownerId: this.instanceId,
				messageName: "GetModuleInfo",
				moduleId: designerModuleId,
				handler: this.getConfigureModelItemModuleConfig
			}, {
				ownerId: this.instanceId,
				messageName: "GetColumnConfig",
				moduleId: designerModuleId,
				handler: this.getConfigureModelItemColumnConfig
			}, {
				ownerId: this.instanceId,
				messageName: "GetSchemaColumnsNames",
				moduleId: designerModuleId,
				handler: this.getSchemaColumnsNames
			}, {
				ownerId: this.instanceId,
				messageName: "GetDesignerDisplayConfig",
				moduleId: designerModuleId,
				handler: this.getDesignerDisplayConfig
			}, {
				ownerId: this.instanceId,
				messageName: "OnDesignerSaved",
				moduleId: designerModuleId,
				handler: this.onDesignerSave
			}, {
				ownerId: this.instanceId,
				messageName: "GetNewLookupPackageUId",
				moduleId: designerModuleId,
				handler: this.getPackageUId
			}, {
				ownerId: this.instanceId,
				messageName: "GetEntitySchemaName",
				moduleId: designerModuleId,
				handler: this._getEntitySchemaName
			}];
		},

		/**
		 * Generates designer module id.
		 * @protected
		 * @virtual
		 * @return {String} Designer module id.
		 */
		getDesignerModuleId: function() {
			return this.designSchema.sandbox.id + "_ModelItemConfigModule";
		},

		/**
		 * Returns designer module schema name.
		 * @protected
		 * @virtual
		 * @return {Object} Designer module schema name.
		 */
		getConfigureModelItemModuleConfig: function() {
			if (this.schemaModelItemDesignerName === null) {
				throw new BPMSoft.NullOrEmptyException();
			}
			return {schemaName: this.schemaModelItemDesignerName};
		},

		/**
		 * Returns designer module item.
		 * @protected
		 * @virtual
		 * @return {Object} Designer module item.
		 */
		getConfigureModelItemColumnConfig: function() {
			return this;
		},

		/**
		 * Generates the array of column for current item.
		 * @protected
		 * @virtual
		 * @return {String[]} Array of column for current item.
		 */
		getSchemaColumnsNames: function() {
			return this.parentViewModel.get("Schema").columns.mapArrayByPath("name");
		},

		/**
		 * Generates designer display configuration.
		 * @protected
		 * @virtual
		 * @return {Object} Designer display item configuration.
		 */
		getDesignerDisplayConfig: function() {
			return {isNewColumn: this.designSchema.get("ActionLayoutCreate")};
		},

		/**
		 * Returns identifier of current package.
		 * @protected
		 * @virtual
		 * @return {String} Identifier of current package.
		 */
		getPackageUId: function() {
			return this.designSchema.getPackageUId();
		},

		/**
		 * Adds column to data model.
		 * @protected
		 */
		addColumnToEntitySchema: function() {
			const dataModelSchema = this.parentViewModel.get("Schema");
			dataModelSchema.addColumn(this.column);
		},

		/**
		 * Adds new schema design tool to design schema.
		 * @protected
		 */
		addSchemaDesignToolItemToDesignSchema: function() {
			const collection = Ext.create("BPMSoft.Collection");
			collection.add(this.column.uId, this.column);
			const existingModelDraggableItems = this.parentViewModel.get("ExistingModelDraggableItems");
			this.designSchema.loadColumnsCollection(existingModelDraggableItems, collection,
				"BPMSoft.ExistingColumnGridLayoutEditItemModel", this.parentViewModel);
		},

		/**
		 * Updates schema design tool from entity schema column information.
		 * @protected
		 */
		updateSchemaDesignToolItem: function() {
			const draggableItemsCollection = this.parentViewModel.get("ExistingModelDraggableItems");
			const item = draggableItemsCollection.get(this.column.uId);
			const column = this.column;
			item.set("IsRequired", column.isRequired);
			item.set("content", column.caption.getValue());
			item.updateImageConfig();
		},

		/**
		 * Designer save event handler.
		 * @protected
		 */
		onDesignerSave: function() {
			const designSchema = this.designSchema;
			if (designSchema.get("ActionLayoutCreate")) {
				const layoutName = designSchema.get("ActionLayoutName");
				this.addItemToDesignSchemaCollection(layoutName);
				this.addColumnToEntitySchema();
				this.addSchemaDesignToolItemToDesignSchema();
			}
			this.updateSchemaDesignToolItem();
		},

		/**
		 * Opens designer.
		 * @protected
		 */
		openDesigner: function() {
			this.designSchema.showBodyMask();
			const moduleId = this.getDesignerModuleId();
			const column = this.column || {};
			switch (column.dataValueType) {
				case BPMSoft.DataValueType.TEXT:
				case BPMSoft.DataValueType.LONG_TEXT:
				case BPMSoft.DataValueType.MEDIUM_TEXT:
				case BPMSoft.DataValueType.SHORT_TEXT:
				case BPMSoft.DataValueType.MAXSIZE_TEXT:
					if (BPMSoft.Features.getIsDisabled("DisableTextPageItemPropertiesPage") && !Ext.isIE) {
						this._openDesignerNew();
					} else {
						this.designSchema.sandbox.loadModule("ModalBoxSchemaModule", {id: moduleId});
					}
					break;
				case BPMSoft.DataValueType.DATE_TIME:
				case BPMSoft.DataValueType.DATE:
				case BPMSoft.DataValueType.TIME:
					if (BPMSoft.Features.getIsDisabled("DisableDateTimePageItemPropertiesPage") && !Ext.isIE) {
						this._openDesignerNew();
					} else {
						this.designSchema.sandbox.loadModule("ModalBoxSchemaModule", {id: moduleId});
					}
					break;
				case BPMSoft.DataValueType.INTEGER:
				case BPMSoft.DataValueType.FLOAT:
				case BPMSoft.DataValueType.FLOAT1:
				case BPMSoft.DataValueType.FLOAT2:
				case BPMSoft.DataValueType.FLOAT3:
				case BPMSoft.DataValueType.FLOAT4:
				case BPMSoft.DataValueType.FLOAT8:
				case BPMSoft.DataValueType.MONEY:
					if (!BPMSoft.Features.getIsEnabled("DisableNumberPageItemPropertiesPage") && !Ext.isIE) {
						this._openDesignerNew();
					} else {
						this.designSchema.sandbox.loadModule("ModalBoxSchemaModule", {id: moduleId});
					}
					break;
				case BPMSoft.DataValueType.BOOLEAN:
					if (!BPMSoft.Features.getIsEnabled("DisableBooleanPageItemPropertiesPage") && !Ext.isIE) {
						this._openDesignerNew();
					} else {
						this.designSchema.sandbox.loadModule("ModalBoxSchemaModule", {id: moduleId});
					}
					break;
				case BPMSoft.DataValueType.LOOKUP:
					if (!BPMSoft.Features.getIsEnabled("DisableLookupPageItemPropertiesPage") && !Ext.isIE) {
						this._openDesignerNew();
					} else {
						this.designSchema.sandbox.loadModule("ModalBoxSchemaModule", {id: moduleId});
					}
					break;
				default:
					this.designSchema.sandbox.loadModule("ModalBoxSchemaModule", {id: moduleId});
			}
		},

		/**
		 * @private
		 */
		_openDesignerNew: function() {
			const moduleId = this.getDesignerModuleId();

			const renderTo = ModalBox.show({
				widthPixels: 550,
				heightPixels: 610,
				allowClickPropagation: true
			}, function() {
				this.designSchema.sandbox.unloadModule(moduleId);
			}, this);
			const moduleName = this.parentViewModel.$Name === "Parameters"
				? "ClientUnitParameterPropertiesPageModule"
				: "EntityColumnPropertiesPageModule";
			this.designSchema.sandbox.loadModule(moduleName, {
				id: moduleId,
				renderTo: renderTo
			});
		},

		/**
		 * @private
		 */
		_getEntitySchemaName: function() {
			return this.parentViewModel.get("Schema").caption.getValue();
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#edit
		 * @overridden
		 */
		edit: function(config) {
			if (this.column && !this.itemConfig.generator) {
				const designSchema = this.designSchema;
				designSchema.set("ActionLayoutName", config.layoutName);
				designSchema.set("ActionLayoutItem", this);
				designSchema.set("ActionLayoutCreate", false);
				this.openDesigner();
			}
		},

		/**
		 * @inheritdoc BPMSoft.GridLayoutEditItemModel#removeFromDesignSchema
		 * @overridden
		 */
		removeFromDesignSchema: function() {
			const designSchema = this.designSchema;
			const itemConfig = this.itemConfig;
			const bindTo = itemConfig.bindTo || itemConfig.name;
			const usedColumns = designSchema.get("UsedColumns");
			if (usedColumns[bindTo]) {
				usedColumns[bindTo]--;
			}
			if (!usedColumns[bindTo]) {
				const itemType = itemConfig.itemType;
				const viewItemType = BPMSoft.ViewItemType;
				if (itemType !== viewItemType.CONTAINER && itemType !== viewItemType.GRID_LAYOUT && this.column) {
					const existingModelDraggableItems = this.parentViewModel.get("ExistingModelDraggableItems");
					const columnUId = this.column.getPropertyValue("uId");
					const existingModelDraggableItem = existingModelDraggableItems.get(columnUId);
					existingModelDraggableItem.set("IsUsed", false);
				}
			}
			this.callParent(arguments);
		}
	});

	return BPMSoft.ColumnGridLayoutEditItemModel;
});
