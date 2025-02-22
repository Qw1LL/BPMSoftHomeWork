﻿/**
 * Page schema for dcm schema properties.
 * Parent: BaseProcessSchemaPropertiesPage => ProcessFlowElementPropertiesPage => BaseProcessSchemaElementPropertiesPage
 */
define("DcmSchemaPropertiesPage", [
	"ext-base",
	"BPMSoft",
	"DcmSchemaPropertiesPageResources",
	"StructureExplorerUtilities",
	"DcmSchema",
	"SectionEntitySelectMixin",
	"DcmSchemaManager",
	"DcmSchemaFilterProviderModule",
	"ProcessLookupPageMixin"
], function(Ext, BPMSoft, resources, StructureExplorerUtilities) {
	return {
		mixins: {
			sectionEntitySelectMixin: "BPMSoft.SectionEntitySelectMixin",
			processLookupPageMixin: "BPMSoft.ProcessLookupPageMixin"
		},
		messages: {
			"ColumnSelected": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"StructureExplorerInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetStructureExplorerSchemaName": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			"GetDcmSettingId": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Caption.
			 */
			"caption": {
				isRequired: true
			},
			/**
			 * Section entity schema.
			 */
			"EntitySchema": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				caption: resources.localizableStrings.SectionCaption
			},
			/**
			 * Entity stage lookup column.
			 */
			"StageColumn": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				caption: resources.localizableStrings.StageColumnCaption
			},
			/**
			 * Flag that indicates whether filter is visible.
			 */
			"IsFilterVisible": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * DCM setting filters.
			 */
			"DcmSettingsId": {
				dataValueType: BPMSoft.DataValueType.GUID,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * DCM setting filters.
			 */
			"DcmSettingFilters": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Entity columns.
			 */
			"EntityColumns": {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Init entity schema.
			 * @private
			 * @param {BPMSoft.Designers.DcmSchema} dcmSchema Dcm schema.
			 */
			initEntitySchema: function(dcmSchema) {
				var entitySchema = dcmSchema.entitySchema;
				var entityInfo = this.getEntityInfo(entitySchema);
				this.set("EntitySchema", entityInfo, {silent: true});
				this.setValidationInfo("EntitySchema", true, null);
			},

			/**
			 * Init entity schema filter columns.
			 * @private
			 * @param {Function} callback The callback function.
			 * @param {Object} scope The scope of callback function.
			 */
			initEntitySchemaFilterColumns: function(callback, scope) {
				this.getEntitySchemaFilterColumns(function(entityColumns) {
					this.set("EntityColumns", entityColumns);
					callback.call(scope);
				}, this);
			},

			/**
			 * Returns lookup list item entity info.
			 * @private
			 * @param {BPMSoft.manager.EntitySchema} entity Entity schema.
			 * @return {{name: String, value: String, displayValue: String}}
			 */
			getEntityInfo: function(entity) {
				if (entity) {
					return {
						name: entity.getName(),
						value: entity.uId,
						displayValue: entity.getCaption()
					};
				}
			},

			/**
			 * Init entity schema.
			 * @private
			 * @param {BPMSoft.Designers.DcmSchema} dcmSchema Dcm schema instance.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution scope.
			 */
			initStageColumn: function(dcmSchema, callback, scope) {
				var columnUId = dcmSchema.stageColumnUId;
				var entitySchema = this.get("EntitySchema");
				var schemaUId = entitySchema.value;
				this.getEntityColumnInfo(schemaUId, columnUId, function(columnInfo) {
					this.set("StageColumn", columnInfo);
					callback.call(scope);
				}, this);
			},

			/**
			 * Returns full information about column of entity schema.
			 * @private
			 * @param {String} schemaUId Entity schema identifier.
			 * @param {String} columnUId Column identifier.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			getEntityColumnInfo: function(schemaUId, columnUId, callback, scope) {
				var config = {
					schemaUId: schemaUId,
					packageUId: this.get("packageUId")
				};
				BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, function(schema) {
					var column = schema && schema.columns.find(columnUId);
					var columnInfo = this.getColumnInfo(column);
					callback.call(scope, columnInfo);
				}, this);
			},

			/**
			 * Returns lookup list item column info.
			 * @private
			 * @param {BPMSoft.manager.EntitySchemaColumn} column Entity schema column.
			 * @return {{name: String, value: String, displayValue: String}}
			 */
			getColumnInfo: function(column) {
				if (column) {
					return {
						name: column.name,
						value: column.uId,
						displayValue: column.caption.getValue()
					};
				}
			},

			/**
			 * Returns entity schema filter columns for entity schema.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {BPMSoft.Collection} callback.result Entity schema lookup columns.
			 * @param {Object} scope Execution scope.
			 */
			getEntitySchemaFilterColumns: function(callback, scope) {
				var entitySchema = this.get("EntitySchema");
				var schemaUId = entitySchema.value;
				var packageUId = this.get("packageUId");
				var config = {
					schemaUId: schemaUId,
					packageUId: packageUId
				};
				BPMSoft.EntitySchemaManager.findBundleSchemaInstance(config, function(schema) {
					var lookupColumns = schema.columns.filter(function(column) {
						return column.dataValueType === BPMSoft.DataValueType.LOOKUP;
					});
					var result = Ext.create("BPMSoft.Collection");
					lookupColumns.each(function(column) {
						var columnInfo = this.getColumnInfo(column);
						result.add(columnInfo.value, {
							id: columnInfo.value,
							caption: columnInfo.displayValue,
							name: columnInfo.name
						});
					}, this);
					result.sort("displayValue");
					callback.call(scope, result);
				}, this);
			},

			/**
			 * Saves schema filters.
			 * @private
			 * @param {BPMSoft.Designers.DcmSchema} dcmSchema Dcm schema.
			 */
			saveFiltersInDcmSchema: function(dcmSchema) {
				var filters = this.getSerializedFilters();
				dcmSchema.setPropertyValue("filters", filters);
			},

			/**
			 * Saves DCM setting.
			 * @private
			 */
			saveFiltersInDcmSettings: function() {
				var filterManager = this.get("FilterManager");
				var filters = filterManager.filters;
				var dcmSettingFilters = this.getDcmSettingFiltersBySchemaFilters(filters);
				this.set("DcmSettingFilters", dcmSettingFilters);
				var dcmSettingsItem = this.getDcmSettingsItem();
				dcmSettingsItem.setFilters(dcmSettingFilters);
			},

			/**
			 * Returns DCM settings filters.
			 * @private
			 * @param {BPMSoft.Collection} filters Filters.
			 * @return {Array}
			 */
			getDcmSettingFiltersBySchemaFilters: function(filters) {
				var dcmSettingFilters;
				if (filters && !filters.isEmpty()) {
					var items = filters.getItems();
					var entityColumns = this.get("EntityColumns");
					dcmSettingFilters = items.map(function(filter) {
						var leftExpression = filter.leftExpression;
						var columns = entityColumns.filterByFn(function(item) {
							return item.name === leftExpression.columnPath;
						});
						var column = columns.first();
						return {
							columnUId: column.id
						};
					});
				} else {
					dcmSettingFilters = [
						{
							columnUId: null
						}
					];
				}
				return dcmSettingFilters;
			},

			/**
			 * Returns DCM settings item.
			 * @private
			 */
			getDcmSettingsItem: function() {
				var dcmSettingsId = this.get("DcmSettingsId");
				return BPMSoft.SysDcmSettingsManager.getItem(dcmSettingsId);
			},

			/**
			 * Returns serialized filters.
			 * @private
			 * @returns {Object}
			 */
			getSerializedFilters: function() {
				if (this.get("IsFilterVisible")) {
					var filterManager = this.get("FilterManager");
					var filters = filterManager.filters;
					if (filters && !filters.isEmpty()) {
						var options = {serializeFilterManagerInfo: true};
						return filters.serialize(options);
					}
				}
				return "";
			},

			/**
			 * Returns deserialized filters.
			 * @private
			 * @param {String} filters Serialized filters.
			 * @returns {Object}
			 */
			getDeserializedFilters: function(filters) {
				if (this.Ext.isEmpty(filters)) {
					return "";
				}
				return this.BPMSoft.deserialize(filters);
			},

			/**
			 * Creates entity schema filter manager.
			 * @private
			 * @param {BPMSoft.data.filters.DcmSchemaFilterProvider} provider Filter provider.
			 * @param {BPMSoft.FilterGroup} filters Filters.
			 * @returns {BPMSoft.FilterManager}
			 */
			createFilterManager: function(provider, filters) {
				var filterManager = Ext.create("BPMSoft.FilterManager", {
					provider: provider,
					rootSchemaName: provider.rootSchemaName
				});
				filters = filters || this.Ext.create("BPMSoft.FilterGroup");
				filterManager.setFilters(filters);
				this.set("FilterManager", filterManager);
				filterManager.on("removeFilter", this.onRemoveFilter, this);
				return filterManager;
			},

			/**
			 * Creates entity schema filter provider.
			 * @private
			 * @param {String} entitySchemaName The filter root entity schema.
			 * @returns {BPMSoft.DcmSchemaFilterProvider}
			 */
			createFilterProvider: function(entitySchemaName) {
				var provider = this.Ext.create("BPMSoft.DcmSchemaFilterProvider", {
					rootSchemaName: entitySchemaName,
					sandbox: this.sandbox
				});
				provider.on("GetAllowedFilterManageOperations", this.onGetAllowedFilterManageOperations, this);
				provider.on("GetAllowedFilterGroupManageOperations",
					this.onGetAllowedFilterGroupManageOperations, this);
				this.set("FilterProvider", provider);
				return provider;
			},

			/**
			 * Returns initial SysDcmSettings filters column identifiers.
			 * @private
			 * @return {String[]}
			 */
			getSysDcmSettingsInitialFilterColumnsIds: function() {
				var dcmSettingsItem = this.getDcmSettingsItem();
				var dataManagerItem = dcmSettingsItem.getDataManagerItem();
				var filtersString = dataManagerItem.viewModel.getInitialValue("Filters");
				var filters = Ext.JSON.decode(filtersString, true);
				var columnIds = [];
				if (filters) {
					filters.forEach(function(filterData) {
						if (filterData.columnUId) {
							columnIds.push(filterData.columnUId);
						}
					});
				}
				return columnIds;
			},

			/**
			 * GetAllowedFilterManageOperations event handler. Process DcmSchema filters manage operations.
			 * @private
			 * @param {Object} eventArgs
			 * @param {BPMSoft.BaseFilter} eventArgs.filterItem Filter item for which manage operations
			 * are requested.
			 * @param {Object} eventArgs.allowedManageOperations Filter item manage operations.
			 * @return {Boolean}
			 */
			onGetAllowedFilterManageOperations: function(eventArgs) {
				var columnIds = this.getSysDcmSettingsInitialFilterColumnsIds();
				var canChangeFilters = columnIds.length === 0;
				Ext.apply(eventArgs.allowedManageOperations, {
					canViewEnabled: false,
					canEditEnabled: false,
					canEditLeftExpression: canChangeFilters,
					canRemove: canChangeFilters,
					canSelect: false
				});
				return false;
			},

			/**
			 * GetAllowedFilterGroupManageOperations event handler. Process DcmSchema filters manage operations.
			 * @private
			 * @param {Object} eventArgs
			 * @param {BPMSoft.BaseFilter} eventArgs.filterItem FilterGroup item for which manage operations
			 * are requested.
			 * @param {Object} eventArgs.allowedManageOperations Filter item manage operations.
			 * @return {Boolean}
			 */
			onGetAllowedFilterGroupManageOperations: function(eventArgs) {
				var filterGroup = eventArgs.filterItem;
				var canAddFilters = filterGroup.getCount() === 0;
				Ext.apply(eventArgs.allowedManageOperations, {
					canViewEnabled: false,
					canEditEnabled: false,
					canViewGroupType: false,
					canEditGroupType: false,
					canAddFilters: canAddFilters,
					canRemove: false,
					canSelect: false
				});
				return false;
			},

			/**
			 * Initializes filter edit.
			 * @private
			 * @param {BPMSoft.Designers.DcmSchema} dcmSchema Dcm schema.
			 */
			initFilterEdit: function(dcmSchema) {
				var entitySchema = dcmSchema.entitySchema;
				var filters = this.getDeserializedFilters(dcmSchema.filters);
				if (!this.getIsActualFilters(filters)) {
					filters = "";
				}
				var provider = this.createFilterProvider(entitySchema.name);
				this.createFilterManager(provider, filters);
				var isFilterVisible = this.get("IsFilterVisible");
				if (BPMSoft.isEmptyObject(filters) && isFilterVisible) {
					var dcmSettingFilters = this.get("DcmSettingFilters");
					var columnIds = dcmSettingFilters.map(function(dcmSettingFilter) {
						return dcmSettingFilter.columnUId;
					});
					this.setFilterColumns(columnIds);
				}
			},

			/**
			 * Returns flag whether schema filters is actual.
			 * @private
			 * @param {BPMSoft.Collection} filters Schema filters.
			 * @return {Boolean}
			 */
			getIsActualFilters: function(filters) {
				var dcmSettingFilters = this.getDcmSettingFiltersBySchemaFilters(filters);
				var actualDcmSettingFilters = this.get("DcmSettingFilters");
				return BPMSoft.isEqual(dcmSettingFilters, actualDcmSettingFilters);
			},

			/**
			 * Shows select filter column window.
			 * @private
			 */
			openSelectFilterColumnWindow: function() {
				var entitySchema = this.get("EntitySchema");
				var config = {
					schemaName: entitySchema.name,
					lookupsColumnsOnly: true,
					useBackwards: false,
					displayId: false,
					firstColumnsOnly: true
				};
				this.openStructureExplorer(config, this.filterColumnSelectedCallback, this);
			},

			/**
			 * Handles after filter column is selected.
			 * @private
			 * @param {Object} response Selected columns.
			 */
			filterColumnSelectedCallback: function(response) {
				var selectedRows = response.metaPath;
				this.setFilterColumns(selectedRows);
				this.setDcmSettingsFilters(selectedRows);
				this.set("IsFilterVisible", true);
			},

			/**
			 * Opens the structure explorer.
			 * @private
			 * @param {Object} config Config.
			 * @param {Function} callback Callback function.
			 * @param {Function} callback Callback execution context.
			 */
			openStructureExplorer: function(config, callback, scope) {
				StructureExplorerUtilities.Open(this.sandbox, config, callback, this.renderTo, scope || this);
			},

			/** Sets filter columns.
			* @private
			* @param {Array} columnIds Column IDs.
			*/
			setFilterColumns: function(columnIds) {
				var filterColumns = this.get("EntityColumns");
				var filterManager = this.get("FilterManager");
				var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
				columnIds.forEach(function(id) {
					var column = filterColumns.find(id);
					if (column) {
						var leftExpression = Ext.create("BPMSoft.ColumnExpression", {
							columnPath: column.name
						});
						var filter = BPMSoft.createInFilter(leftExpression, []);
						filterGroup.add(id, filter);
					}
				});
				filterManager.setFilters(filterGroup);
			},

			/**
			 * Handler of removing filter item.
			 * @private
			 * @param {BPMSoft.BaseFilter} filter Filter.
			 * @param {BPMSoft.FilterGroup} filterGroup Filter group.
			 */
			onRemoveFilter: function(filter, filterGroup) {
				var isFilterVisible = filterGroup && !filterGroup.isEmpty();
				this.set("IsFilterVisible", isFilterVisible);
			},

			/**
			 * Sets DCM setting filters.
			 * @private
			 * @param {Array} columnIds Columns IDs.
			 */
			setDcmSettingsFilters: function(columnIds) {
				var filter = [];
				columnIds.forEach(function(id) {
					filter.push({
						columnUId: id
					});
				});
				this.set("DcmSettingFilters", filter);
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc ProcessSchemaElementEditable#onElementDataLoad
			 * @overridden
			 */
			onElementDataLoad: function(dcmSchema, callback, scope) {
				this.callParent([
					dcmSchema, function() {
						BPMSoft.chain(
							function(next) {
								this.initEntitySchema(dcmSchema);
								this.initStageColumn(dcmSchema, next, this);
							},
							function(next) {
								this._initVersionAttributes(dcmSchema);
								this.initEntitySchemaFilterColumns(next, this);
							},
							function() {
								this.initDcmSettingsFilter();
								this.initFilterEdit(dcmSchema);
								callback.call(scope);
							}, this
						);
					}, this
				]);
			},

			/**
			 * @private
			 */
			_initVersionAttributes: function(schema) {
				this.set("version", schema.version);
			},

			/**
			 * Init Dcm settings filter.
			 */
			initDcmSettingsFilter: function() {
				var dcmSettingsId = this.sandbox.publish("GetDcmSettingId", null);
				this.set("DcmSettingsId", dcmSettingsId);
				var dcmSettingsItem = this.getDcmSettingsItem();
				this.set("DcmSettingFilters", dcmSettingsItem.getFilters());
				var isEmptyDcmSettingFilters = this.getIsEmptyDcmSettingFilters();
				this.set("IsFilterVisible", !isEmptyDcmSettingFilters);
			},

			getIsEmptyDcmSettingFilters: function() {
				var dcmSettingFilters = this.get("DcmSettingFilters");
				return dcmSettingFilters.length === 0 || !dcmSettingFilters[0].columnUId;
			},

			/**
			 * @inheritdoc BaseProcessSchemaElementPropertiesPage#saveValues
			 * @overridden
			 */
			saveValues: function() {
				this.callParent(arguments);
				var dcmSchema = this.get("ProcessElement");
				this.saveFiltersInDcmSchema(dcmSchema);
				this.saveFiltersInDcmSettings();
			},

			/**
			 * Returns the caption of filters region.
			 * @private
			 * @return {String}
			 */
			getFiltersRegionCaption: function() {
				var template = this.get("Resources.Strings.FiltersRegionCaption");
				var entitySchema = this.get("EntitySchema");
				return Ext.String.format(template, entitySchema.displayValue);
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				var filterManager = this.get("FilterManager");
				var filterProvider = this.get("FilterProvider");
				if (filterManager) {
					filterManager.un("removeFilter", this.onRemoveFilter, this);
					filterManager.destroy();
				}
				if (filterProvider) {
					filterProvider.destroy();
				}
				this.callParent(arguments);
			},

			/**
			 * @private
			 */
			_getShouldShowVersionControls: function() {
				return BPMSoft.DcmSchemaManager.getCanUseProcessVersions();
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"parentName": "EditorsContainer",
				"propertyName": "items",
				"name": "DcmSchemaLayout",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"classes": {
						"wrapClassName": ["base-data-modification-user-task-properties-page"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "EntitySchema",
				"values": {
					"wrapClass": ["top-caption-control"],
					"contentType": BPMSoft.ContentType.ENUM,
					"enabled": false,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "StageColumn",
				"values": {
					"wrapClass": ["top-caption-control"],
					"contentType": BPMSoft.ContentType.ENUM,
					"enabled": false,
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "description",
				"values": {
					"contentType": BPMSoft.ContentType.LONG_TEXT,
					"wrapClass": ["top-caption-control"],
					"caption": {"bindTo": "Resources.Strings.ProcessDescriptionCaption"},
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "version",
				"values": {
					"wrapClass": ["top-caption-control"],
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 24,
						"rowSpan": 1
					},
					"visible": { "bindTo": "_getShouldShowVersionControls" },
					"enabled": false
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "name",
				"values": {
					"wrapClass": ["top-caption-control"],
					"caption": {"bindTo": "Resources.Strings.NameCaption"},
					"isRequired": {"bindTo": "_getIsNameRequired"},
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "FiltersContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"layout": {
						"column": 0,
						"row": 5,
						"colSpan": 24
					}
				}
			},
			{
				"operation": "insert",
				"name": "FiltersRegionLabel",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "getFiltersRegionCaption"},
					"labelConfig": {
						"isRequired": {"bindTo": "IsFilterVisible"}
					},
					"classes": {
						"labelClass": ["t-title-label-proc", "t-label-is-required-proc"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "DcmSettingFilters",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["dcm-setting-filter"]},
					"items": [],
					"visible": {
						"bindTo": "IsFilterVisible",
						"bindConfig": {"converter": "invertBooleanValue"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "DcmSettingFiltersImage",
				"parentName": "DcmSettingFilters",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"controlConfig": {
						"classes": {
							"wrapperClass": ["information-button"]
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "DcmSettingFiltersMessage",
				"parentName": "DcmSettingFilters",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DcmSettingFiltersLabel",
				"parentName": "DcmSettingFiltersMessage",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"classes": {
						"labelClass": ["dcm-setting-filters-label"]
					},
					"caption": {"bindTo": "Resources.Strings.DcmSettingFilterCaption"}
				}
			},
			{
				"operation": "insert",
				"name": "SelectFilterColumn",
				"parentName": "DcmSettingFiltersMessage",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": {"bindTo": "Resources.Strings.SelectFilterColumnCaption"},
					"click": {"bindTo": "openSelectFilterColumnWindow"},
					"classes": {
						"textClass": ["select-filter-column-button"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "FiltersContainer",
				"propertyName": "items",
				"name": "ExtendedFiltersContainer",
				"values": {
					"id": "ExtendedFiltersContainer",
					"selectors": {"wrapEl": "#ExtendedFiltersContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {
						"bindTo": "IsFilterVisible"
					},
					"wrapClass": ["filter-edit-container"]
				}
			},
			{
				"operation": "insert",
				"parentName": "ExtendedFiltersContainer",
				"propertyName": "items",
				"name": "ExtendedFilters",
				"values": {
					"id": "ExtendedFilters",
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.FilterEdit",
					"selectors": {"wrapEl": "#ExtendedFilters"},
					"filterManager": {
						"bindTo": "FilterManager"
					}
				}
			},
			{
				"operation": "insert",
				"name": "OtherPropertiesRegionLabel",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 6,
						"colSpan": 24
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.OtherPropertiesRegionCaption"},
					"classes": {
						"labelClass": ["t-title-label-proc", "other-properties-label"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "SysPackage",
				"values": {
					"wrapClass": ["top-caption-control"],
					"enabled": {
						"bindTo": "IsSysPackageEnabled"
					},
					"controlConfig": {
						"prepareList": {
							"bindTo": "onPrepareSysPackageList"
						}
					},
					"layout": {
						"column": 0,
						"row": 7,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "remove",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "StudioFreeProcessUrl",
				"values": {
					"wrapClass": ["top-caption-control"],
					"layout": {
						"column": 0,
						"row": 8,
						"colSpan": 22,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "remove",
				"name": "OpenStudioFreeButton",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"hint": {"bindTo": "Resources.Strings.StudioFreeProcessUrlHint"},
					"imageConfig": {"bindTo": "Resources.Images.OpenButtonImage"},
					"classes": {
						"wrapperClass": ["open-schema-designer-tool-button", "open-studio-free-button"]
					},
					"click": {"bindTo": "onOpenStudioFreeButtonClick"},
					"layout": {
						"column": 22,
						"row": 8,
						"colSpan": 2
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "enabled",
				"values": {
					"wrapClass": ["t-checkbox-control"],
					"enabled": false,
					"layout": {
						"column": 0,
						"row": 9,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "isActualVersion",
				"values": {
					"visible": { "bindTo": "_getShouldShowVersionControls" },
					"wrapClass": ["t-checkbox-control"],
					"enabled": false,
					"layout": {
						"column": 0,
						"row": 10,
						"colSpan": 24,
						"rowSpan": 1
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DcmSchemaLayout",
				"propertyName": "items",
				"name": "useSystemSecurityContext",
				"values": {
					"wrapClass": ["t-checkbox-control"],
					"layout": {
						"column": 0,
						"row": 11,
						"colSpan": 24,
						"rowSpan": 1
					},
					"visible": {"bindTo": "FeatureDisableAdminRightsInScriptTaskEnabled"}
				}
			}
		]
	};
});
