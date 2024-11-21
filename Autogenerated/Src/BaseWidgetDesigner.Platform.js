define("BaseWidgetDesigner", ["BPMSoft", "ConfigurationEnums", "ColumnEditMixin",
	"css!BaseWidgetDesignerCSS"],
function(BPMSoft, ConfigurationEnums) {
	return {
		messages: {

			/**
			 * ######## ## ######### ################# ####### ###### ########.
			 */
			"GetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ######## ## ######### #######.
			 */
			"OnFiltersChanged": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ########## ######### ######## ###### ########.
			 */
			"SetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ######### ###### ##### #######.
			 */
			"GetSectionEntitySchema": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}

		},
		mixins: {
			ColumnEditMixin: "BPMSoft.ColumnEditMixin"
		},
		attributes: {

			/**
			 * ####### ##### # ########.
			 */
			sectionBindingColumn: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isLookup: true,
				entityStructureConfig: {
					useBackwards: false,
					displayId: true,
					lookupsColumnsOnly: true,
					allowedReferenceSchemas: "getAllowedReferenceSchemas",
					schemaColumnName: "entitySchemaName"
				}
			},

			/**
			 * ####### # ########### # #######.
			 */
			sectionId: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * ######## #####.
			 */
			entitySchemaName: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				isLookup: true,
				lookupListConfig: {
					columns: ["Name", "Caption"],
					filter: "getSchemasFilter"
				},
				referenceSchema: {
					name: BPMSoft.Features.getIsEnabled("UseVwWorkspaceObjects") ?
						"VwWorkspaceObjects" :
						"VwSysSchemaInfo",
					primaryColumnName: "Name",
					primaryDisplayColumnName: "Caption"
				},
				referenceSchemaName: BPMSoft.Features.getIsEnabled("UseVwWorkspaceObjects") ?
					"VwWorkspaceObjects" :
					"VwSysSchemaInfo"
			},

			/**
			 * ###### #######.
			 */
			filterData: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		methods: {

			/**
			 * Filters columns.
			 * @protected
			 * @virtual
			 */
			columnsFiltrationMethod: function(column) {
				if (column.usageType === ConfigurationEnums.EntitySchemaColumnUsageType.None) {
					return false;
				}
				if (BPMSoft.isGUIDDataValueType(column.dataValueType)) {
					return true;
				}
				var allowedReferenceSchemas = this.getAllowedReferenceSchemas();
				return BPMSoft.isLookupDataValueType(column.dataValueType) &&
					BPMSoft.contains(allowedReferenceSchemas, column.referenceSchemaName);
			},

			/**
			 * @inheritDoc BPMSoft.BaseWidgetPreviewDesigner#getWidgetModulePropertiesTranslator
			 */
			getWidgetModulePropertiesTranslator: function() {
				var result = this.callParent(arguments);
				var config = {
					"filterData": "filterData",
					"entitySchemaName": "entitySchemaName",
					"sectionBindingColumn": "sectionBindingColumn",
					"sectionId": "sectionId"
				};
				this.Ext.apply(result, config);
				return result;
			},

			/**
			 * @inheritDoc BPMSoft.BaseWidgetPreviewDesigner#canRefreshWidget
			 */
			canRefreshWidget: function() {
				var canRefresh = this.callParent(arguments) && this.get("filterData");
				return Boolean(canRefresh);
			},

			/**
			 * ########## ######### ### #### ##### # ########.
			 * @protected
			 * @virtual
			 * @return {String} ########## ######### ### #### ##### # ########.
			 */
			getSectionBindingColumnCaption: function() {
				var moduleInfo = this.get("sectionId");
				var moduleId = (moduleInfo && moduleInfo.value) || moduleInfo;
				var moduleCaption = "";
				BPMSoft.each(BPMSoft.configuration.ModuleStructure, function(moduleConfig) {
					if (moduleConfig.moduleId === moduleId) {
						moduleCaption = moduleConfig.moduleCaption;
						return false;
					}
				}, this);
				var sectionBindingColumnFormat = this.get("Resources.Strings.SectionBindingColumnFormat");
				var entitySchemaNameInfo = this.get("entitySchemaName");
				var entitySchemaNameLookupValue  = (entitySchemaNameInfo && entitySchemaNameInfo.displayValue) || "";
				return this.Ext.String.format(sectionBindingColumnFormat, entitySchemaNameLookupValue, moduleCaption);
			},

			/**
			 * ######### ## ###### ########.
			 * @param {*} value ########
			 * @return {boolean} ########## true, #### ####### ## ###### ######, false # ######## ######.
			 */
			isNotEmptyConverter: function(value) {
				return !Ext.isEmpty(value);
			},

			/**
			 * Returns custom filter for columns.
			 * @param {Object} columnName Column name.
			 * @return {Function} Custom column filtration method.
			 */
			getColumnsFiltrationMethod: function(columnName) {
				if (columnName === "sectionBindingColumn") {
					return this.columnsFiltrationMethod;
				}
			},

			/**
			 * ########## ###### ######## #### ####### ### ####### ##### # ########.
			 * @protected
			 * @virtual
			 * @return {String[]} ########## ###### ######## #### ####### ### ####### ##### # ########.
			 */
			getAllowedReferenceSchemas: function() {
				var sectionSchema = this.getSectionSchemaName();
				return sectionSchema && [sectionSchema];
			},

			/**
			 * ########## ### ##### ####### #######.
			 * @protected
			 * @virtual
			 * @return {String[]} ########## ### ##### ####### #######.
			 */
			getSectionSchemaName: function() {
				var designEntitySchemaName = this.get("DesignEntitySchemaName");
				if (designEntitySchemaName) {
					return designEntitySchemaName;
				} else {
					var sectionSchema = this.sandbox.publish("GetSectionEntitySchema");
					return sectionSchema && sectionSchema.name;
				}
			},

			/**
			 * ########## ############# ###### ##########.
			 * @protected
			 * @virtual
			 * @return {String} ########## ############# ###### ##########.
			 */
			getFilterEditModuleId: function() {
				return this.sandbox.id + "_ExtendedFilterEditModule";
			},

			/**
			 * ##### ######## ###### ##########.
			 * @protected
			 * @virtual
			 */
			loadFilterModule: function() {
				var moduleId = this.getFilterEditModuleId();
				this.sandbox.subscribe("OnFiltersChanged", function(args) {
					this.set("filterData", args.serializedFilter);
				}, this, [moduleId]);
				this.sandbox.subscribe("GetFilterModuleConfig", function() {
					var entitySchemaNameProperty = this.get("entitySchemaName");
					return {
						rootSchemaName: entitySchemaNameProperty && entitySchemaNameProperty.Name,
						filters: this.get("filterData")
					};
				}, this, [moduleId]);
				this.sandbox.loadModule("FilterEditModule", {
					renderTo: "FilterProperties",
					id: moduleId
				});
				this.set("filterModuleLoaded", true);
			},

			/**
			 * ##### ######### ####### ######### ######## #####.
			 * @protected
			 * @virtual
			 */
			onEntitySchemaNameChange: function() {
				this.set("filterData", null);
				this.set("sectionBindingColumn", null);
				var entitySchemaNameProperty = this.get("entitySchemaName");
				if (entitySchemaNameProperty) {
					this.loadFilterModule();
					var moduleId = this.getFilterEditModuleId();
					this.sandbox.publish("SetFilterModuleConfig", {
						rootSchemaName: entitySchemaNameProperty && entitySchemaNameProperty.Name
					}, [moduleId]);
				}
				this.initSectionBindingColumn();
			},

			/**
			 * Returns section binding column.
			 * @protected
			 * @virtual
			 */
			getSectionBindingColumn: function(callback, scope) {
				let result = null;
				let selectedObjectSchemaName = this.$entitySchemaName;
				selectedObjectSchemaName = (selectedObjectSchemaName && selectedObjectSchemaName.Name) || selectedObjectSchemaName;
				const sectionSchemaName = this.getSectionSchemaName();
				if (selectedObjectSchemaName && sectionSchemaName) {
					if (selectedObjectSchemaName === sectionSchemaName) {
						result = {
							value: "Id",
							displayValue: "Id",
							dataValueType: BPMSoft.DataValueType.GUID
						};
					} else {
						var config = {
							selectedObjectSchemaName: selectedObjectSchemaName,
							sectionSchemaName: sectionSchemaName
						};
						this.findEntitySchemaColumnsBySectionSchemaName(config, function(filteredColumns) {
							result = filteredColumns.length === 1 ? filteredColumns[0] : null;
						}, this);
					}
				}
				Ext.callback(callback, scope, [result]);
			},

			/**
			 * Initializes section binding column value.
			 * @protected
			 * @virtual
			 */
			initSectionBindingColumn: function() {
				BPMSoft.chain(
					this.getSectionBindingColumn,
					function(next, sectionBindingColumn) {
						this.$sectionBindingColumn = sectionBindingColumn;
					}, this);
			},

			/**
			 * Finds entity schema columns by section schema.
			 * @protected
			 * @param {String} config Configuration object.
			 * @param {String} config.selectedObjectSchemaName Selected object schema name.
			 * @param {String} config.sectionSchemaName Section schema name.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback function context.
			 */
			findEntitySchemaColumnsBySectionSchemaName: function(config, callback, scope) {
				var selectedObjectSchema;
				BPMSoft.chain(
					function(next) {
						BPMSoft.require([config.selectedObjectSchemaName], function(schema) {
							selectedObjectSchema = schema;
							next();
						}, this);
					},
					function() {
						var filteredColumnArray = [];
						BPMSoft.each(selectedObjectSchema.columns, function(column) {
							if (column.dataValueType === BPMSoft.DataValueType.LOOKUP &&
									column.referenceSchemaName === config.sectionSchemaName) {
								filteredColumnArray.push({
									value: column.name,
									displayValue: column.caption,
									dataValueType: column.dataValueType
								});
							}
						}, this);
						callback.call(scope, filteredColumnArray);
					},
					this
				);
			},

			/**
			 * ############## ######### ######## ######.
			 * @protected
			 * @virtual
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ####### ######### ######.
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.on("change:entitySchemaName", this.onEntitySchemaNameChange, this);
					callback.call(this);
				}, this]);
			},

			/**
			 * ##### ######### ####### ######### ######.
			 * @protected
			 * @virtual
			 */
			onRender: function() {
				if (!this.get("filterModuleLoaded")) {
					this.loadFilterModule();
				}
			},

			/**
			 * Generates a Filter to request a list of object schemes in the current configuration.
			 * @virtual
			 * @return {BPMSoft.FilterGroup} Returns a Filter for querying a list of object schemas.
			 */
			getSchemasFilter: function() {
				const filters = this.Ext.create("BPMSoft.FilterGroup");
				filters.addItem(BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"SysWorkspace",
					BPMSoft.SysValue.CURRENT_WORKSPACE.value
				));
				const notInFilter = BPMSoft.createColumnInFilterWithParameters("Name",
					BPMSoft.DataServiceSettings.RestrictedSelectSchemaAccessNames || []);
				notInFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
				filters.addItem(notInFilter);
				if (this.getIsFeatureDisabled("UseVwWorkspaceObjects")) {
					filters.addItem(BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL,
						"ManagerName",
						"EntitySchemaManager"
					));
				}
				return filters;
			},

			/**
			 * @inheritDoc BPMSoft.BaseWidgetPreviewDesigner#setWidgetModuleProperties
			 */
			setWidgetModuleProperties: function(widgetConfig, callback) {
				this.callParent([widgetConfig, function() {
					BPMSoft.chain(function(next) {
							var widgetModulePropertiesTranslator = this.getWidgetModulePropertiesTranslator();
							var widgetPropertyName = widgetModulePropertiesTranslator.entitySchemaName;
							var entitySchemaName = widgetConfig[widgetPropertyName];
							if (!entitySchemaName) {
								next();
								return;
							}
							this.getEntitySchemaCaption(entitySchemaName, function(entitySchemaCaption) {
								this.set("entitySchemaName", {
									value: entitySchemaName,
									Name: entitySchemaName,
									displayValue: entitySchemaCaption
								});
								next();
							}, this);
						},
						function(next) {
							this.mixins.ColumnEditMixin.init.call(this, function() {
								next();
							}, this);
						},
						function() {
							if (widgetConfig.designEntitySchemaName) {
								this.set("DesignEntitySchemaName", widgetConfig.designEntitySchemaName);
							}
							this.set("moduleLoaded", true);
							this.Ext.callback(callback, this);
						}, this);
				}, this]);
			},

			/**
			 * ######### #####, ####### ########## ######### EntitySchemaQuery ### ######### ###### ########## #######.
			 * @overridden
			 * @protected
			 * @virtual
			 * @return {Object} ########## ######### EntitySchemaQuery ### ######### ###### ########## #######.
			 */
			getLookupQuery: function(filterValue, columnName) {
				var esq = this.callParent(arguments);

				// Получаем версию бандла
				let productEdition = "";
				BPMSoft.SysSettings.querySysSettings(["ProductEdition"], function(values) {
					productEdition = values.ProductEdition;
				}, this);

				if(productEdition === "Constructor" || productEdition === "studio"){
					let esqIsAvailableInStudio = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "IsAvailableInStudio", true);
					esq.filters.add("esqIsAvailableInStudio", esqIsAvailableInStudio);
				}
				var lookupColumn = this.columns[columnName];
				var lookupListConfig = lookupColumn.lookupListConfig;
				if (!lookupListConfig) {
					return esq;
				}
				BPMSoft.each(lookupListConfig.columns, function(column) {
					if (!esq.columns.contains(column)) {
						esq.addColumn(column);
					}
				}, this);
				var filterGroup = this.getLookupQueryFilters(columnName);
				esq.filters.addItem(filterGroup);
				var columns = esq.columns;
				if (lookupListConfig.orders) {
					var orders = lookupListConfig.orders;
					BPMSoft.each(orders, function(order) {
						var orderColumnPath = order.columnPath;
						if (!columns.contains(orderColumnPath)) {
							esq.addColumn(orderColumnPath);
						}
						var sortedColumn = columns.get(orderColumnPath);
						var direction = order.direction;
						sortedColumn.orderDirection = direction ? direction : BPMSoft.OrderDirection.ASC;
						var position = order.position;
						sortedColumn.orderPosition = position ? position : 1;
						this.shiftColumnsOrderPosition(columns, sortedColumn);
					}, this);
				}
				return esq;
			},

			/**
			 * ######### #######, ####### ############# ## ########## ####.
			 * @private
			 * @param {String} columnName ######## #######.
			 * @return {BPMSoft.FilterGroup} ########## ###### ########.
			 */
			getLookupQueryFilters: function(columnName) {
				var filterGroup = this.Ext.create("BPMSoft.FilterGroup");
				var column = this.columns[columnName];
				var lookupListConfig = column.lookupListConfig;
				if (lookupListConfig) {
					var filterArray = lookupListConfig.filters;
					BPMSoft.each(filterArray, function(item) {
						var filter;
						if (Ext.isObject(item) && Ext.isFunction(item.method)) {
							filter = item.method.call(this, item.argument);
						}
						if (Ext.isFunction(item)) {
							filter = item.call(this);
						}
						if (Ext.isEmpty(filter)) {
							throw new BPMSoft.InvalidFormatException({
								message: Ext.String.format(
									this.get("Resources.Strings.ColumnFilterInvalidFormatException"), columnName)
							});
						}
						filterGroup.addItem(filter);
					}, this);
					if (lookupListConfig.filter) {
						var filterItem = Ext.isString(lookupListConfig.filter) ? this[lookupListConfig.filter]()
							: lookupListConfig.filter.call(this);
						if (filterItem) {
							filterGroup.addItem(filterItem);
						}
					}
				}
				return filterGroup;
			},

			/**
			 * Returns visibility of section binding column.
			 * @return {Boolean} Visibility of section binding column.
			 */
			getSectionBindingColumnVisible: function() {
				const sectionId = this.get("sectionId");
				const entitySchemaName = this.get("entitySchemaName");
				const sectionSchemaName = this.getSectionSchemaName();
				return Boolean(sectionId) && Boolean(entitySchemaName) && Boolean(sectionSchemaName);
			}

		},
		diff: [
			{
				"operation": "insert",
				"name": "QueryProperties",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"id": "QueryProperties",
					"selectors": {
						"wrapEl": "#QueryProperties"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.QueryPropertiesLabel"
						}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "EntitySchemaName",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "entitySchemaName",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.EntitySchemaNameLabel"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "FilterPropertiesGroup",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {"bindTo": "Resources.Strings.FilterPropertiesLabel"}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FilterProperties",
				"parentName": "FilterPropertiesGroup",
				"propertyName": "items",
				"values": {
					"id": "FilterProperties",
					"itemType": BPMSoft.ViewItemType.MODULE,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "SectionBindingGroup",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {"bindTo": "Resources.Strings.SectionBindingGroupCaption"}
					},
					"visible": {
						"bindTo": "sectionId",
						"bindConfig": {"converter": "isNotEmptyConverter"}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "sectionBindingColumn",
				"parentName": "SectionBindingGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"generator": "ColumnEditGenerator.generatePartial",
					"labelConfig": {"caption": {"bindTo": "getSectionBindingColumnCaption"}},
					"visible": {"bindTo": "getSectionBindingColumnVisible"},
					"controlConfig": {
						"placeholder": {"bindTo": "Resources.Strings.SectionBindingColumnCaption"},
						"classes": ["placeholderOpacity"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "FormatProperties",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"id": "FormatProperties",
					"selectors": {
						"wrapEl": "#FormatProperties"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.FormatPropertiesLabel"
						}
					},
					"items": []
				}
			}
		]
	};
});
