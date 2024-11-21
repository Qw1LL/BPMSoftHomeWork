define("EntityColumnMappingViewModel", ["BPMSoft", "EntityColumnMappingViewModelResources",
		"EntitySchemaDesignerUtilities", "MenuItemsMappingMixin", "MappingEditMixin"],
	function(BPMSoft, resources) {
		/**
		 * @class BPMSoft.EntityColumnMappingViewModel
		 * Class for entity column mapping view model.
		 */
		Ext.define("BPMSoft.model.EntityColumnMappingViewModel", {
			extend: "BPMSoft.model.BaseModel",
			alternateClassName: "BPMSoft.EntityColumnMappingViewModel",
			mixins: {
				mappingEditMixin: "BPMSoft.MappingEditMixin",
				menuItemsMappingMixin: "BPMSoft.MenuItemsMappingMixin"
			},
			attributes: {
				/**
				 * Tool button image.
				 */
				"ToolButtonImage": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * Invoker Uid.
				 */
				"InvokerUId": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			columns: {

				/**
				 * Related column identifier.
				 */
				Id: {
					dataValueType: BPMSoft.DataValueType.TEXT
				},
				ProcessElement: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Related schema column.
				 */
				SchemaColumn: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
				},

				/**
				 * Mapping edit caption.
				 */
				Caption: {
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * Mapping edit value.
				 */
				Value: {
					dataValueType: BPMSoft.DataValueType.MAPPING
				},

				/**
				 * Identifier of the related localizable parameter value list item.
				 */
				LocalizableParameterValueId: {
					dataValueType: BPMSoft.DataValueType.TEXT
				},

				/**
				 * Tool button menu collection.
				 */
				ToolButtonMenu: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * Collection of source schema columns that fit current mapping by their types.
				 */
				SourceColumns: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * Menu items view model collection.
				 */
				MenuItems: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				}
			},

			/**
			 * Sandbox object.
			 * @private
			 */
			sandbox: null,

			//region Methods: Private

			/**
			 * @inheritdoc BPMSoft.model.BaseModel#constructor
			 */
			constructor: function() {
				this.callParent(arguments);
				this.addEvents("itemRemoved");
				this.on("itemRemoved", this.onItemRemoved);
				this.initMappingEntitySchema(this.initDesignerType, this);
			},

			/**
			 * Initialize view model. Actualize mapping display value.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function call context.
			 */
			init: function(callback, scope) {
				var mapping = this.get("Value");
				var mappingValue = mapping.value;
				if (mapping.source === BPMSoft.ProcessSchemaParameterValueSource.ConstValue ||
						mapping.source === BPMSoft.ProcessSchemaParameterValueSource.None) {
					callback.call(scope);
					return;
				}
				if (mapping.source === BPMSoft.ProcessSchemaParameterValueSource.EntityMapping) {
					var sourceColumn = this.findSourceColumn(mappingValue);
					var displayValue = this.getMappingDisplayValue(sourceColumn);
					mapping.displayValue = displayValue;
					this.set("Value", mapping);
					callback.call(scope);
					return;
				}
				var processElement = this.get("ProcessElement");
				var schema = processElement.parentSchema;
				BPMSoft.FormulaParserUtils.getFormulaDisplayValue(mappingValue, schema, function(displayValue) {
					mapping.displayValue = displayValue;
					this.set("Value", mapping);
					callback.call(scope);
				}, this);
			},

			/**
			 * On item removed method.
			 * @virtual
			 */
			onItemRemoved: BPMSoft.emptyFn,

			/**
			 * Returns invoker uid of the view model.
			 * @return {String} Invoker uid of the view model.
			 */
			getInvokerUId: function() {
				return this.get("InvokerUId");
			},

			/**
			 * Handles 'Delete' menu item click.
			 * @private
			 */
			onDeleteClick: function() {
				this.parentCollection.remove(this);
				const id = this.get("Id");
				this.fireEventArgs("itemRemoved", [id]);
				this.destroy();
			},

			/**
			 * Handles 'Column from this selection' menu items click.
			 * @private
			 * @param {String} columnId Schema column identifier.
			 */
			onSourceColumnMenuItemClick: function(columnId) {
				var sourceColumn = this.findSourceColumn(columnId);
				if (sourceColumn) {
					this.setValueBySourceColumn(sourceColumn);
				}
			},

			/**
			 * Returns source entity schema column by uId.
			 * @private
			 * @param {String} columnId Column unique identifier.
			 * @return {BPMSoft.EntitySchemaColumn/Null}
			 */
			findSourceColumn: function(columnId) {
				var sourceColumns = this.get("SourceColumns");
				if (!sourceColumns) {
					return null;
				}
				return sourceColumns.find(columnId);
			},

			/**
			 * Returns display value for mapping.
			 * @param {BPMSoft.EntitySchemaColumn} sourceColumn Entity schema column.
			 * @return {String}
			 */
			getMappingDisplayValue: function(sourceColumn) {
				if (!sourceColumn) {
					return "";
				}
				var displayValueFormat = resources.localizableStrings.SourceColumnDisplayValueFormat;
				return displayValueFormat.replace("{columnCaption}", sourceColumn.caption || "");
			},

			/**
			 * Clears value, when source schema columns list changed.
			 * @private
			 * @param {BPMSoft.Collection} sourceSchemaColumns Source schema columns.
			 */
			clearValueAfterSourceSchemaColumnsChanged: function(sourceSchemaColumns) {
				var value = this.get("Value");
				if (!value || (value.source !== BPMSoft.ProcessSchemaParameterValueSource.EntityMapping)) {
					return;
				}
				var columnId = value.value;
				if (sourceSchemaColumns && sourceSchemaColumns.find(columnId)) {
					return;
				}
				this.setValueBySourceColumn();
			},

			/**
			 * Sets mapping value based on the source column.
			 * @private
			 * @param {{id: String, caption: String}} [sourceColumn] Source column config.
			 */
			setValueBySourceColumn: function(sourceColumn) {
				var parameterSources = BPMSoft.process.enums.ProcessSchemaParameterValueSource;
				var source = (sourceColumn) ? parameterSources.EntityMapping : parameterSources.None;
				var displayValue = this.getMappingDisplayValue(sourceColumn);
				var columnId = (sourceColumn) ? sourceColumn.id : null;
				var sourceValue = {
					value: columnId,
					displayValue: displayValue,
					source: source,
					metaPath: columnId
				};
				this.setMappingEditValue("Value", sourceValue);
			},

			/**
			 * Generates marker value for current item component.
			 * @private
			 * @param {String} [suffix] Component name suffix.
			 * @return {String}
			 */
			getMarkerValue: function(suffix) {
				var schemaColumn = this.get("SchemaColumn");
				var columnName = (schemaColumn) ? schemaColumn.name : this.get("Caption");
				return "entityColumnMapping" + suffix + "-" + columnName;
			},

			/**
			 * Generates marker value for current item tools button.
			 * @private
			 * @return {String}
			 */
			getToolsButtonContainerMarkerValue: function() {
				return this.getMarkerValue("ToolsButton");
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.core.BaseObject#onDestroy.
			 * @overridden
			 */
			onDestroy: function() {
				const menuItems = this.get("MenuItems");
				if (menuItems) {
					menuItems.destroy();
				}
				const sourceColumns = this.get("SourceColumns");
				if (sourceColumns) {
					sourceColumns.destroy();
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.MenuItemsMappingMixin#getParameterReferenceSchemaUId
			 * @override
			 */
			getParameterReferenceSchemaUId: function() {
				const schemaColumn = this.get("SchemaColumn");
				return schemaColumn ? schemaColumn.referenceSchemaUId : null;
			},
			//endregion

			//region Methods: Public

			/**
			 * Updates source columns.
			 * @param {BPMSoft.Collection} sourceSchemaColumns Source schema columns.
			 */
			updateSourceColumns: function(sourceSchemaColumns) {
				const schemaColumn = this.get("SchemaColumn");
				this.set("DataValueType", schemaColumn.dataValueType);
				this.clearValueAfterSourceSchemaColumnsChanged(sourceSchemaColumns);
				if (!schemaColumn) {
					this.set("SourceColumns", null);
					return;
				}
				const targetDataValueTypeInfo = {
					dataValueType: schemaColumn.getPropertyValue("dataValueType"),
					referenceSchemaUId: schemaColumn.getPropertyValue("referenceSchemaUId")
				};
				const sourceColumns = BPMSoft.EntitySchemaDesignerUtilities
					.filterSourceSchemaColumns(sourceSchemaColumns, targetDataValueTypeInfo);
				var isSourceColumnsEmpty = sourceColumns.isEmpty();
				this.set("SourceColumns", isSourceColumnsEmpty ? null : sourceColumns);
			}

			//endregion

		});
	}
);
