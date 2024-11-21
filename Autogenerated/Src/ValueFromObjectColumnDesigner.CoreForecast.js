define("ValueFromObjectColumnDesigner", ["StructureExplorerUtilities", "ForecastEntityLookupMixin",
	"EntityStructureHelperMixin", "css!ValueFromObjectColumnDesigner"],
	function(StructureExplorerUtilities) {
		return {
			attributes: {
				/**
				 * Column source objects list.
				 */
				"ForecastSource": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"isRequired": true,
					"onChange": "handleForecastSourceChange"
				},

				/**
				 * Period column path.
				 */
				"PeriodColumnPath": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
				},

				/**
				 * Period column caption.
				 */
				"PeriodColumnCaption": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"isRequired": true,
					"value": ""
				},

				/**
				 * Indicator column path.
				 */
				"IndicatorColumnPath": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
				},

				/**
				 * Indicator column caption.
				 */
				"IndicatorColumnCaption": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"isRequired": true,
					"value": ""
				},

				/**
				 * Calculation operations list.
				 */
				"CalculationFunction": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"isLookup": true,
					"isRequired": true,
					"onChange": "handleCalculationFunctionChange",
					"value": ""
				},

				/**
				 * Calculation coefficient.
				 */
				"Coefficient": {
					"dataValueType": this.BPMSoft.DataValueType.INTEGER,
					"value": this.coefficientDefaultValue
				},

				/**
				 * Reference column path.
				 */
				"RefColumnPath": {
					"dataValueType": BPMSoft.DataValueType.TEXT
				},

				/**
				 * Reference column caption.
				 */
				"RefColumnCaption": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"isRequired": true,
					"value": ""
				},

				/**
				 * Indicates is referenced columns lookup is enabled.
				 */
				"IsObjectColumnRefLookupEnabled": {
					"dataValueType": BPMSoft.DataValueType.Collection
				},

				/**
				 * Caption of column reference.
				 */
				"ObjectColumnReferenceCaption": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"value": ""
				}
			},
			properties: {
				coefficientDefaultValue: 100,
				StructureExplorerUtilities: StructureExplorerUtilities,
				columnsMetaData: {
					"period": {
						settingsIdColumnName: "periodColumnId",
						settingsPathColumnName: "periodColumnPath",
						modelPathName: "PeriodColumnPath",
						modelCaptionName: "PeriodColumnCaption",
						useBackwards: true
					},
					"func": {
						settingsIdColumnName: "funcColumnId",
						settingsPathColumnName: "funcColumnPath",
						modelPathName: "IndicatorColumnPath",
						modelCaptionName: "IndicatorColumnCaption",
						useBackwards: true
					},
					"ref": {
						settingsIdColumnName: "refColumnId",
						settingsPathColumnName: "refColumnPath",
						modelPathName: "RefColumnPath",
						modelCaptionName: "RefColumnCaption",
						useBackwards: true
					}
				}
			},
			messages: {
				/**
				 * @message SetFilterModuleConfig
				 * Publishes filter config to filter module.
				 */
				"SetFilterModuleConfig": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetColumnConfig
				 * Returns column config from loaded module.
				 */
				"GetColumnConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GetFilters
				 * Gets filters from filter module.
				 */
				"GetFilters": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @message GetFilterModuleConfig
				 * Returns filter config to filter module.
				 */
				"GetFilterModuleConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message StructureExplorerInfo
				 * Returns settings for Structure explorer modal box.
				 */
				"StructureExplorerInfo": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message ColumnSelected
				 * Returns selected column config.
				 */
				"ColumnSelected": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			mixins: {
				"ForecastEntityLookupMixin": "BPMSoft.ForecastEntityLookupMixin",
				"EntityStructureHelper": "BPMSoft.EntityStructureHelperMixin"
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#init
				 * @override
				 */
				init: function(callback, scope) {
					this._subscribeMessages();
					this.set("AvailableFunctions", this.Ext.create("BPMSoft.Collection"));
					this.columnsMetaData["period"].filterFn = this.filterPeriodColumns;
					this.columnsMetaData["func"].filterFn = this.filterIndicatorColumns;
					this.columnsMetaData["ref"].filterFn = this.filterRefColumns;
					this.callParent([function() {
						this.loadColumnSettings(function() {
							this._setObjectColumnReferenceCaption();
							this.$IsInitialized = true;
							this.mixins.ForecastEntityLookupMixin.init(callback, scope);
						}, this);
					}, this]);
				},

				/**
				 * @private
				 */
				_setObjectColumnReferenceCaption: function() {
					const template = this.get("Resources.Strings.ForecastObjectColumnReferenceGroupContainerCaption");
					const targetSchema = this.BPMSoft.EntitySchemaManager.findItemByName(this.$forecastSourceItemName);
					const sourceSchemaName = this.$ForecastSource && this.$ForecastSource.displayValue || "";
					this.$ObjectColumnReferenceCaption =
						this.Ext.String.format(template, sourceSchemaName, targetSchema.caption);
					this.$forecastSourceId = targetSchema.uId;
				},

				/**
				 * @private
				 */
				_subscribeMessages: function() {
					this.sandbox.subscribe("GetColumnConfig", this.convertModuleToColumnConfig, this,
						[this.sandbox.id]);
				},

				/**
				 * Converts view model to column config.
				 * @return {Object} Column config.
				 */
				convertModuleToColumnConfig: function() {
					const validationResult = this.validate();
					if (!validationResult) {
						return null;
					}
					const filters = this.sandbox.publish("GetFilters", null, [this.$FilterEditModuleId], this);
					const serializedFilter = filters.serializedFilter || "";
					return {
						sourceUId: this.$ForecastSource.value,
						filter: serializedFilter,
						periodColumnPath: this.$PeriodColumnPath,
						funcCode: this.$CalculationFunction.value.toLowerCase(),
						funcColumnPath: this.$IndicatorColumnPath,
						refColumnPath: this.$RefColumnPath,
						percentOperand: this.$Coefficient
					};
				},

				/**
				 * @private
				 */
				_loadRefColumnBySourceObjectName: function(sourceObjectName) {
					this.getEntitySchemaByName(sourceObjectName, function(schema) {
						if (schema) {
							const columns = Object.values(schema.columns).filter(function(column) {
								return column.referenceSchemaName === this.$forecastSourceItemName && column.columnPath;
							}, this);
							if (columns.length === 1) {
								this.set("RefColumnPath", columns[0].columnPath);
								this.set("RefColumnCaption", columns[0].caption);
							}
						}
					}, this);
				},

				/**
				 * Returns filter module config.
				 * @return {Object} Filter module config.
				 */
				getFilterModuleConfig: function(entitySchemaName) {
					return {
						rootSchemaName: entitySchemaName,
						actionsVisible: false,
						filters: this.$ColumnSettings && this.$ColumnSettings.filter
					};
				},

				/**
				 * Loads available functions list for ComboboxEdit.
				 * @public
				 * @param {Object} filter ComboboxEdit value.
				 * @param {BPMSoft.Collection} list List of comboboxEdit values.
				 */
				initAvailableFunctionsCollection: function(filter, list) {
					const availableFunctions = this.Ext.create("BPMSoft.Collection");
					const keys = ["count", "sum", "avg"];
					keys.forEach(function(f) {
						const key = f.toUpperCase();
						availableFunctions.add(this.BPMSoft.AggregationType[key], {
							value: key,
							displayValue: this.BPMSoft.Resources.AggregationType[key]
						});
					}, this);
					list.reloadAll(availableFunctions);
				},

				/**
				 * Load forecast source schema
				 * @param {String} schemaName Schema name
				 * @private
				 */
				_initSourceObjectSchema: function(schemaName) {
					const schema = this.BPMSoft[schemaName];
					if (!schema) {
						this.BPMSoft.require([schemaName], function() { 
							this._setSourceObjectPrimaryColumnName(schemaName);
						}, this);
					} else {
						this._setSourceObjectPrimaryColumnName(schemaName);
					}
				},
				
				/**
				 * @param schemaName Entity schema name.
				 * @private
				 */
				_setSourceObjectPrimaryColumnName: function(schemaName) {
					const schema = this.BPMSoft[schemaName];
					if (schema) {
						this.$sourceObjectPrimaryColumnName = schema.primaryColumn.name;
					}
				},

				/**
				 * Handles event after selected item changed.
				 * @public
				 * @param {Backbone.Model} model Control model.
				 * @param {Object} item New selected item.
				 */
				handleForecastSourceChange: function(model, item) {
					this._initSourceObjectSchema(item ? item.Name : this.$ForecastSource.Name);
					if (!this.$IsInitialized) {
						return;
					}
					const metaData = this.columnsMetaData;
					const props = Object.getOwnPropertyNames(metaData);
					const modelColumnNames = this.BPMSoft.flatten(props.map(function(propName) {
						return [
							metaData[propName].modelPathName,
							metaData[propName].modelCaptionName
						];
					}));
					this._clearViewModelColumns(["CalculationFunction"].concat(modelColumnNames));
					if (this.$ColumnSettings) {
						this.$ColumnSettings.filter = "";
					}
					this.setColumnValue("Coefficient", this.coefficientDefaultValue);
					if (item) {
						const filterModuleConfig = this.getFilterModuleConfig(item.Name);
						this.sandbox.publish("SetFilterModuleConfig", filterModuleConfig, [this.$FilterEditModuleId]);
						this._loadRefColumnBySourceObjectName(item.Name);
						this._setObjectColumnReferenceCaption();
					}
				},

				/**
				 * @private
				 */
				_clearViewModelColumns: function(columnNames) {
					this.BPMSoft.each(columnNames, function(name) {
						this.setColumnValue(name, null, { preventValidation: true });
					}, this);
				},

				/**
				 * @private
				 */
				_loadFilterModule: function(containerName) {
					this.$FilterEditModuleId = this.sandbox.id + "_FilterEditModule";
					this.sandbox.loadModule("FilterEditModule", {
						renderTo: containerName,
						keepAlive: false,
						id: this.$FilterEditModuleId
					});
					this.sandbox.subscribe("GetFilterModuleConfig", function() {
						const entitySchemaName = this.$ForecastSource && this.$ForecastSource.Name;
						return this.isEmpty(entitySchemaName)
							? {}
							: this.getFilterModuleConfig(entitySchemaName);
					}, this, [this.$FilterEditModuleId]);
				},

				/**
				 * Loads column settings to fields.
				 */
				loadColumnSettings: function(callback, scope) {
					if (this.isEmpty(this.$ColumnSettings)) {
						this.Ext.callback(callback, scope);
						return;
					}
					const sourceUId = this.$ColumnSettings.sourceUId;
					const funcCode = this.$ColumnSettings.funcCode && this.$ColumnSettings.funcCode.toUpperCase();
					if (this.isNotEmpty(funcCode)) {
						this.set("CalculationFunction", {
							value: funcCode,
							displayValue: this.BPMSoft.Resources.AggregationType[funcCode]
						});
					}
					this.set("Coefficient", this.$ColumnSettings.percentOperand);
					if (this.isNotEmpty(sourceUId)) {
						this.BPMSoft.EntitySchemaManager.getItemByUId(sourceUId, function(schema) {
							this.set("ForecastSource", {
								value: schema.uId,
								Name: schema.name,
								displayValue: schema.caption
							});
							this._fillColumns(schema.name, callback, scope);
						}, this);
					} else {
						this.Ext.callback(callback, scope);
					}
				},

				/**
				 * @private
				 */
				_setColumnById: function(columnId, metaData, callback, scope) {
					const schema = this.$ForecastSource;
					this.getColumns({ entitySchemaName: schema.Name }, function(columns) {
						const column = columns[columnId.toLowerCase()];
						this.set(metaData.modelPathName, column.columnName);
						this.set(metaData.modelCaptionName, column.displayValue);
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @private
				 */
				_setColumnByPath: function(columnPath, metaData, callback, scope) {
					const schema = this.$ForecastSource;
					const serviceParameters = [{
						schemaName: schema.Name,
						columnPath: columnPath,
						key: columnPath
					}];
					this.getColumnPathCaption(this.Ext.JSON.encode(serviceParameters), function(columnInfo) {
						const column = columnInfo[0] || {};
						this.set(metaData.modelPathName, columnPath);
						this.set(metaData.modelCaptionName, column.columnCaption);
						this.Ext.callback(callback, scope);
					}, this);
				},

				/**
				 * @private
				 */
				_fillColumn: function(columnCode, callback, scope) {
					const metaData = this.columnsMetaData[columnCode];
					const columnId = this.$ColumnSettings[metaData.settingsIdColumnName];
					const columnPath = this.$ColumnSettings[metaData.settingsPathColumnName];
					if (columnId) {
						this._setColumnById(columnId, metaData, callback, scope);
					} else if (columnPath) {
						this._setColumnByPath(columnPath, metaData, callback, scope);
					} else {
						this.Ext.callback(callback, scope);
					}
				},

				/**
				 * @private
				 */
				_fillColumns: function(schemaName, callback, scope) {
					this.BPMSoft.eachAsync(
						Object.getOwnPropertyNames(this.columnsMetaData),
						function(columnCode, next) {
							this._fillColumn(columnCode, next, scope);
						},
						function() {
							Ext.callback(callback, scope);
						},
						this
					);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSchemaViewModel#onRender
				 * @override
				 */
				onRender: function() {
					if (!this.$FilterEditModuleId) {
						this._loadFilterModule("FiltersContainer");
					}
				},

				/**
				 * Forms StructureExplorer module config.
				 * @protected
				 * @virtual
				 * @return {Object} StructureExplorer module config
				 */
				getStructureExplorerConfig: function(columnMetaData) {
					const entitySchemaName = this.$ForecastSource && this.$ForecastSource.Name;
					return {
						schemaName: entitySchemaName,
						columnPath: this.get(columnMetaData.modelPathName),
						useBackwards: columnMetaData.useBackwards,
						useCount: false,
						columnsFiltrationMethod: columnMetaData.filterFn.bind(this)
					};
				},

				/**
				 * Filters column for period field.
				 * @param {Object} column Column to check.
				 * @return {Boolean} Is column valid.
				 */
				filterPeriodColumns: function(column) {
					return this.BPMSoft.isValidForMappingOnDateDataValueType(column.dataValueType);
				},

				/**
				 * Filters column for indicator field.
				 * @param {Object} column Column to check.
				 * @return {Boolean} Is column valid.
				 */
				filterIndicatorColumns: function(column) {
					return this.BPMSoft.isNumberDataValueType(column.dataValueType);
				},

				/**
				 * Filters column for reference field.
				 * @param {Object} column Column to check.
				 * @param {Object} selectedReferenceEntity Currently selected entity config.
				 * @return {Boolean} Is column valid.
				 */
				filterRefColumns: function(column, selectedReferenceEntity) {
					const isIdColumn = column.name && column.name === "Id";
					const isSectionEntityIsForecastEntity = this.$ForecastSource.value === this.$forecastSourceId;
					const isReferenceEntityIsForecastEntity = selectedReferenceEntity &&
						selectedReferenceEntity.schema.name === this.$forecastSourceItemName;
					if (isIdColumn && (isSectionEntityIsForecastEntity || isReferenceEntityIsForecastEntity)) {
						return true;
					}
					return column.referenceSchemaName === this.$forecastSourceItemName;
				},

				/**
				 * Checks if current calculation function is count operation.
				 * @return {Boolean} current calculation function is count operation.
				 */
				isCountMode: function() {
					return this.$CalculationFunction &&
						this.BPMSoft.AggregationType[this.$CalculationFunction.value] ===
						this.BPMSoft.AggregationType.COUNT;
				},

				/**
				 * Returns indicator settings visibility flag.
				 * @return {Boolean} indicator settings is visible.
				 */
				getIndicatorSettingsVisibility: function() {
					return !this.isCountMode();
				},

				/**
				 * Handles calculation function change.
				 */
				handleCalculationFunctionChange: function() {
					if (this.$CalculationFunction && this.isCountMode() && this.$CalculationFunction.value !== "") {
						this.setColumnValue("IndicatorColumnCaption", this.$sourceObjectPrimaryColumnName);
						this.setColumnValue("IndicatorColumnPath", this.$sourceObjectPrimaryColumnName);
					} else {
						this.setColumnValue("IndicatorColumnCaption", "");
						this.setColumnValue("IndicatorColumnPath", "");
					}
				},

				/**
				 * Opens StructureExplorer modal box.
				 */
				openStructureExplorer: function(columnCode) {
					if (!this.$ForecastSource) {
						return;
					}
					const columnMetaData = this.columnsMetaData[columnCode];
					const config = this.getStructureExplorerConfig(columnMetaData);
					this.StructureExplorerUtilities.Open(this.sandbox, config, this.structureExplorerHandler.bind(this, columnCode), this, this);
				},

				/**
				 * Opens structure explorer modal box for Period field.
				 */
				openStructureExplorerForPeriod: function() {
					this.openStructureExplorer("period");
				},

				/**
				 * Opens structure explorer modal box for Indicator field.
				 */
				openStructureExplorerForIndicator: function() {
					this.openStructureExplorer("func");
				},

				/**
				 * Opens structure explorer modal box for Reference field.
				 */
				openStructureExplorerForReference: function() {
					this.openStructureExplorer("ref");
				},

				/**
				 * StructureExplorer selection handler.
				 * @virtual
				 * @param {String} columnCode Column metadata code.
				 * @param {Object} args Structure explorer selection result.
				 */
				structureExplorerHandler: function(columnCode, args) {
					const columnMetaData = this.columnsMetaData[columnCode];
					const columnCaption = args.leftExpressionCaption;
					const columnPath = args.leftExpressionColumnPath;
					this.set(columnMetaData.modelPathName, columnPath);
					this.set(columnMetaData.modelCaptionName, columnCaption);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "ColumnDesigner",
					"operation": "insert",
					"values": {
						"items": [],
						"classes": { "wrapClassName": ["column-designer-container"] },
						"itemType": BPMSoft.ViewItemType.CONTAINER
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnDesigner",
					"propertyName": "items",
					"name": "ColumnDesignerGridLayout",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"classes": {
							"wrapClassName": ["column-designer-layout"]
						},
						"items": []
					}
				},
				{
					"name": "CalcConditionCaption",
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.CalcConditionGroupContainerCaption"
						},
						"classes": { "labelClass": ["rule-group-label"] },
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 22
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"name": "ForecastSource",
					"values": {
						"labelConfig": {
							"caption": { "bindTo": "Resources.Strings.ForecastColumnObjectUIdCaption" }
						},
						"labelWrapConfig": { "classes": { "wrapClassName": ["source-caption"] } },
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"listViewConfig": {
								"styles": {
									"wrapStyle": {
										"width": "360px"
									}
								}
							},
							"prepareList": {
								"bindTo": "prepareForecastEntityList"
							},
							"loadNextPage": {
								"bindTo": "loadNextForecastEntities"
							}
						},
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "FiltersContainer",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"values": {
						"id": "FiltersContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["filters-container"],
						"items": [],
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"name": "PeriodColumnCaption",
					"values": {
						"labelConfig": {
							"caption": { "bindTo": "Resources.Strings.ForecastSourcePeriodColumnCaption" }
						},
						"labelWrapConfig": { "classes": { "wrapClassName": ["source-caption"] } },
						"wrapClass": ["structure-column-edit"],
						"controlConfig": {
							"className": "BPMSoft.TextEdit",
							"readonly": true,
							"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
							"rightIconClick": { "bindTo": "openStructureExplorerForPeriod" }
						},
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						}
					}
				},
				{
					"name": "CalcMethodGroupCaption",
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.CalcMethodGroupContainerCaption"
						},
						"classes": { "labelClass": ["rule-group-label"] },
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 22
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"name": "CalculationFunction",
					"values": {
						"labelConfig": {
							"caption": { "bindTo": "Resources.Strings.CalculationFunctionCaption" }
						},
						"classes": {
							"wrapClassName": ["coefficient-lookup"]
						},
						"labelWrapConfig": { "classes": { "wrapClassName": ["source-caption"] } },
						"contentType": BPMSoft.ContentType.ENUM,
						"controlConfig": {
							"prepareList": {
								"bindTo": "initAvailableFunctionsCollection"
							}
						},
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"name": "IndicatorColumnCaption",
					"values": {
						"labelConfig": {
							"caption": { "bindTo": "Resources.Strings.IndicatorCaption" }
						},
						"wrapClass": ["indicator-lookup", "structure-column-edit"],
						"labelWrapConfig": { "classes": { "wrapClassName": ["source-caption"] } },
						"controlConfig": {
							"className": "BPMSoft.TextEdit",
							"readonly": true,
							"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
							"rightIconClick": { "bindTo": "openStructureExplorerForIndicator" }
						},
						"visible": { "bindTo": "getIndicatorSettingsVisibility" },
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 18
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"name": "IndicatorMultiplication",
					"values": {
						"caption": "X",
						"classes": { "labelClass": ["multiple-character-caption"] },
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"layout": {
							"column": 18,
							"row": 6,
							"colSpan": 2
						},
						"visible": { "bindTo": "getIndicatorSettingsVisibility" },
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"name": "Coefficient",
					"values": {
						"wrapClass": ["coefficient"],
						"labelConfig": {
							"visible": false
						},
						"layout": {
							"column": 20,
							"row": 6,
							"colSpan": 4
						},
						"visible": { "bindTo": "getIndicatorSettingsVisibility" },
						"markerValue": "Coefficient"
					}
				},
				{
					"name": "ForecastObjectColumnReferenceGroupGroupCaption",
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.ForecastObjectColumnReferenceCaption"
						},
						"classes": { "labelClass": ["rule-group-label"] },
						"itemType": this.BPMSoft.ViewItemType.LABEL,
						"layout": {
							"column": 0,
							"row": 7,
							"colSpan": 22
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "ColumnDesignerGridLayout",
					"propertyName": "items",
					"name": "RefColumnCaption",
					"values": {
						"labelConfig": {
							"caption": { "bindTo": "ObjectColumnReferenceCaption" }
						},
						"labelWrapConfig": { "classes": { "wrapClassName": ["source-caption"] } },
						"wrapClass": ["structure-column-edit"],
						"controlConfig": {
							"className": "BPMSoft.TextEdit",
							"readonly": true,
							"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
							"rightIconClick": { "bindTo": "openStructureExplorerForReference" }
						},
						"layout": {
							"column": 0,
							"row": 8,
							"colSpan": 24
						}
					}
				}
			] /**SCHEMA_DIFF*/
		};
	});
