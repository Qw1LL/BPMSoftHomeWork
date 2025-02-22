﻿define("ChartDesigner", [
	"BPMSoft",
	"ChartDesignerResources",
	"ChartModuleHelper",
	"InformationButtonResources",
	"ChartCompatibilityValidator",
	"css!ChartDesignerLess"
], function(BPMSoft, resources, ChartModuleHelper, informationButtonResources) {
	const localizableStrings = resources.localizableStrings;
	return {
		messages: {

			/**
			 * ########## ######### ############# ###### ########.
			 */
			"RerenderModule": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ######## ## ######### ########## ########## ### ###### #######.
			 */
			"GetChartConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ########## ######### ### ######### ########## ############# ###### ######### ########.
			 */
			"GetModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ########## ######### ### ###### ########## ######### ###### ######### ########.
			 */
			"PostModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ########## ######### ### ######### #######.
			 */
			"GenerateChart": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ########## ######### ######### ######### ###### #######.
			 */
			"ChangeHeaderCaption": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ########## ######### ### ########### ########### #########.
			 */
			"BackHistoryState": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * ######## ## ######### ######### ######## #####.
			 */
			"GetSectionSchemaName": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ######## ## ######### StructureExplorer.
			 */
			"StructureExplorerInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ######## ## ######### ###### ####### # StructureExplorer.
			 */
			"ColumnSelected": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ######## ## ######### ################# ####### ###### ########.
			 */
			"GetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * ########## ######### ######## ###### ########.
			 */
			"SetFilterModuleConfig": {
				mode: BPMSoft.MessageMode.BROADCAST,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}

		},
		attributes: {
			/**
			 * ######### #######.
			 */
			caption: {
				value: localizableStrings.NewChartCaption
			},
			/**
			 * ###### #####.
			 */
			SeriesConfig: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * ####### ###### #########.
			 */
			IsPercentageMode: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},
			/**
			 * #### ##########.
			 */
			OrderBy: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: {
					value: BPMSoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD,
					displayValue: localizableStrings.OrderByGroupByField
				}
			},
			/**
			 * ########### ##########.
			 */
			OrderDirection: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: {
					value: "Ascending",
					displayValue: localizableStrings.OrderDirectionASC
				}
			},
			/**
			 * ### #######.
			 */
			ChartType: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: ChartModuleHelper.ChartSeriesKind.line
			},
			/**
			 * ######## ####### ## #.
			 */
			XAxisColumn: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				isLookup: true,
				entityStructureConfig: {
					useBackwards: true,
					summaryColumnsOnly: false,
					schemaColumnName: "entitySchemaName"
				}
			},
			/**
			 * ####### ######### ####### ## #.
			 */
			YAxisColumnVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * ##### ####### ### #.
			 */
			XAxisCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				dependencies: [
					{
						columns: ["ChartType"],
						methodName: "onChartTypeChange"
					}
				]
			},
			/**
			 * ##### ####### ### #.
			 */
			YAxisCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * ###### ####.
			 */
			DateTimeFormat: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * ##### #######.
			 */
			StyleColor: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: BPMSoft.DashboardEnums.WidgetColor["widget-orange"]
			},
			/**
			 * ######### #####.
			 */
			SeriesCollection: {
				dataValueType: BPMSoft.DataValueType.COLLECTION,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: false
			},
			/**
			 * ######## ####### ######## #####.
			 */
			ActiveSeriesName: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: false
			},
			/**
			 * ########### ############ ######## ####### ### #.
			 */
			YAxisMinValue: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: false
			},
			/**
			 * ############ ############ ######## ####### ### #.
			 */
			YAxisMaxValue: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: false
			},
			/**
			 * ######### ####### ### # .
			 */
			YAxisPosition: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: {
					value: BPMSoft.DashboardEnums.ChartAxisPosition.NONE,
					displayValue: localizableStrings.ChartAxisPositionNone
				}
			},

			/**
			 * Default X-axis caption.
			 */
			XAxisDefaultCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Default Y-axis caption.
			 */
			YAxisDefaultCaption: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: null
			},

			/**
			 * Use empty value.
			 */
			UseEmptyValue: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Is stacked chart.
			 */
			IsStackedChart: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Is legend enabled for serie.
			 */
			IsLegendEnabled: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Series is unsupported.
			 */
			IsUnsupportedTypes: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			},

			/**
			 * Series compatibility mapping of the chart.
			 */
			SeriesCompatibilityMapping: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseAggregationWidgetDesigner#FormatValueSettingsVisible
			 * @override
			 */
			FormatValueSettingsVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			}
		},
		methods: {

			/**
			 * @private
			 */
			_availabelStackedChartTypes: ["bar", "column"],

			/**
			 * Object translator from model properties chart to object graph settings.
			 * @private
			 * @type {Object}
			 */
			chartProperties: {
				"OrderBy": "orderBy",
				"OrderDirection": "orderDirection",
				"DateTimeFormat": "dateTimeFormat",
				"caption": "caption",
				"sectionId": "sectionId",
				"XAxisDefaultCaption": "xAxisDefaultCaption",
				"YAxisDefaultCaption": "yAxisDefaultCaption",
				"UseEmptyValue": "useEmptyValue",
				"IsStackedChart": "isStackedChart"
			},

			/**
			 * ###### ########### ####### ###### ##### ####### # ####### ######## #######
			 * @private
			 * @type {Object}
			 */
			seriesProperties: {
				"entitySchemaName": "schemaName",
				"sectionBindingColumn": "sectionBindingColumn",
				"aggregationType": "func",
				"IsPercentageMode": "isPercentageMode",
				"ChartType": "type",
				"XAxisColumn": "xAxisColumn",
				"aggregationColumn": "yAxisColumn",
				"XAxisCaption": "XAxisCaption",
				"YAxisCaption": "YAxisCaption",
				"StyleColor": "styleColor",
				"filterData": "filterData",
				"YAxisMinValue": "min",
				"YAxisMaxValue": "max",
				"YAxisPosition": "position",
				"format": "format",
				"IsLegendEnabled": "isLegendEnabled"
			},

			/**
			 * ###### ######## ####### ###### ####### ### # ##### #######.
			 * @private
			 * @type {String[]}
			 */
			yAxisConfigProperties: ["YAxisMinValue", "YAxisMaxValue", "YAxisPosition"],

			/**
			 * #### ######## ######### #######.
			 * @private
			 * @type {String}
			 */
			tabCaptionProperty: "YAxisCaption",

			/**
			 * @private
			 */
			_addSeries: function(seriesName, seriesViewModel) {
				const seriesCollection = this.get("SeriesCollection");
				seriesCollection.add(seriesName, seriesViewModel);
				this.set("ActiveSeriesName", seriesName);
				this.set("moduleLoaded", true);
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#getWidgetModulePropertiesTranslator
			 * @protected
			 * @overridden
			 */
			getWidgetModulePropertiesTranslator: function() {
				const widgetModulePropertiesTranslator = Ext.apply({}, this.chartProperties);
				return Ext.apply(widgetModulePropertiesTranslator, this.seriesProperties);
			},

			/**
			 * ########## ###### ######## ####### ##### ## #########.
			 * @protected
			 * @virtual
			 * @return {Object} ########## ###### ######## ####### ##### ## #########..
			 */
			getDefaultSeriesPropertiesValues: function() {
				const result = {
					Name: BPMSoft.generateGUID(),
					Caption: this.getSeriesTabCaption()
				};
				for (var viewModelPropertyName in this.seriesProperties) {
					result[viewModelPropertyName] = this.columns[viewModelPropertyName].value;
				}
				return result;
			},

			/**
			 * ########## ############## ####### ######## #######.
			 * @protected
			 * @virtual
			 * @param {Object} chartConfig ####### ######## #######.
			 * @return {Object} ########## ############### ###### ######## #######.
			 */
			convertChartConfig: function(chartConfig) {
				const config = {
					caption: chartConfig.caption,
					orderBy: chartConfig.orderBy,
					orderDirection: chartConfig.orderDirection,
					dateTimeFormat: chartConfig.dateTimeFormat,
					useEmptyValue: chartConfig.useEmptyValue,
					isLegendEnabled: chartConfig.isLegendEnabled,
					seriesConfig: [
						{
							primaryColumnName: chartConfig.primaryColumnName,
							filterData: chartConfig.filterData,
							func: chartConfig.func,
							schemaName: chartConfig.schemaName,
							type: chartConfig.type,
							xAxisColumn: chartConfig.xAxisColumn,
							XAxisCaption: chartConfig.XAxisCaption,
							yAxisColumn: chartConfig.yAxisColumn,
							YAxisCaption: chartConfig.YAxisCaption,
							styleColor: chartConfig.styleColor,
							yAxisConfig: chartConfig.yAxisConfig,
							sectionBindingColumn: chartConfig.sectionBindingColumn,
							sectionId: chartConfig.sectionId,
							format: chartConfig.format,
							isLegendEnabled: chartConfig.isLegendEnabled
						}
					],
					isNew: !chartConfig.hasOwnProperty("func")
				};
				BPMSoft.each(chartConfig.seriesConfig, function(seriesConfigItem) {
					config.seriesConfig.push({
						primaryColumnName: seriesConfigItem.primaryColumnName,
						filterData: seriesConfigItem.filterData,
						func: seriesConfigItem.func,
						schemaName: seriesConfigItem.schemaName,
						type: seriesConfigItem.type,
						xAxisColumn: seriesConfigItem.xAxisColumn,
						XAxisCaption: seriesConfigItem.XAxisCaption,
						yAxisColumn: seriesConfigItem.yAxisColumn,
						YAxisCaption: seriesConfigItem.YAxisCaption,
						styleColor: seriesConfigItem.styleColor,
						yAxisConfig: seriesConfigItem.yAxisConfig,
						sectionBindingColumn: seriesConfigItem.sectionBindingColumn,
						format: seriesConfigItem.format,
						isLegendEnabled: seriesConfigItem.isLegendEnabled
					});
				}, this);
				return config;
			},

			/**
			 * ########## ######## ########.
			 * @private
			 * @param {Mixed} value ####### ########.
			 * @return {Mixed} ########## ######## ########.
			 */
			getPropertyValue: function(value) {
				return Ext.isObject(value) ? (value.Name || value.value) : value;
			},

			/**
			 * ########## ###### ######## ####### ######## ###### ############# #####.
			 * @private
			 * @param {BPMSoft.BaseViewModel} seriesItemViewModel ###### ###### ############# #####.
			 * @return {Object} ########## ###### ######## ####### ######## ###### ############# #####.
			 */
			getSeriesConfigItem: function(seriesItemViewModel) {
				const seriesConfigItem = {
					primaryColumnName: "Id",
					yAxisConfig: {
						position: BPMSoft.DashboardEnums.ChartAxisPosition.NONE
					}
				};
				BPMSoft.each(this.seriesProperties, function(chartConfigPropertyName, seriesItemPropertyName) {
					const value = seriesItemViewModel.get(seriesItemPropertyName);
					if (BPMSoft.contains(this.yAxisConfigProperties, seriesItemPropertyName)) {
						if (!Ext.isEmpty(value)) {
							seriesConfigItem.yAxisConfig[chartConfigPropertyName] = this.getPropertyValue(value);
						}
					} else {
						seriesConfigItem[chartConfigPropertyName] = this.getPropertyValue(value);
					}
				}, this);
				seriesConfigItem.format = seriesItemViewModel.$format;
				seriesConfigItem.isLegendEnabled = seriesItemViewModel.$IsLegendEnabled;
				return seriesConfigItem;
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#getWidgetConfig
			 * @protected
			 * @overridden
			 */
			getWidgetConfig: function() {
				const chartConfig = {
					seriesConfig: []
				};
				BPMSoft.each(this.chartProperties, function(chartConfigPropertyName, viewModelPropertyName) {
					const value = this.get(viewModelPropertyName);
					chartConfig[chartConfigPropertyName] = this.getPropertyValue(value);
				}, this);
				const seriesCollection = this.get("SeriesCollection");
				seriesCollection.each(function(seriesItemViewModel, seriesItemViewModelIndex) {
					const seriesConfigItem = this.getSeriesConfigItem(seriesItemViewModel);
					if (seriesItemViewModelIndex === 0) {
						Ext.apply(chartConfig, seriesConfigItem);
					} else {
						chartConfig.seriesConfig.push(seriesConfigItem);
					}
				}, this);
				return chartConfig;
			},

			/**
			 * ######### ######## entity #### #####.
			 * @protected
			 * @virtual
			 * @param {Object} seriesConfig ###### ######### #####.
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ########## ####### ######### ######.
			 */
			loadSeriesEntitySchema: function(seriesConfig, callback, scope) {
				const entitySchemaNames = [];
				BPMSoft.each(seriesConfig, function(seriesConfigItem) {
					this.Ext.Array.include(entitySchemaNames, seriesConfigItem.schemaName);
				}, this);
				BPMSoft.require(entitySchemaNames, callback, scope);
			},

			/**
			 * ########## #### ####### #####.
			 * @private
			 * @param {String} schemaName ######## entity #####.
			 * @param {String} columnPath #### #######.
			 * @return {String} ########## #### ####### #####.
			 */
			getColumnKey: function(schemaName, columnPath) {
				return Ext.String.format("{0}_{1}", schemaName, columnPath);
			},

			/**
			 * ########## ###### ######### ####### ####### ####### #######.
			 * @private
			 * @param {String} schemaName ######## entity #####.
			 * @param {String} columnPath #### #######.
			 * @return {Object} ########## ###### ######### ####### ####### ####### #######.
			 */
			getColumnPathCaptionParameterConfig: function(schemaName, columnPath) {
				return {
					schemaName: schemaName,
					columnPath: columnPath,
					key: this.getColumnKey(schemaName, columnPath)
				};
			},

			/**
			 * ######### ######## ########## # ######## entity #### #####.
			 * @protected
			 * @virtual
			 * @param {Object} seriesConfig ###### ######### #####.
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ########## ####### ######### ######.
			 */
			loadSeriesColumnCaptions: function(seriesConfig, callback, scope) {
				const serviceParameters = [];
				BPMSoft.each(seriesConfig, function(seriesConfigItem) {
					const schemaName = seriesConfigItem.schemaName;
					const xAxisColumn = seriesConfigItem.xAxisColumn;
					serviceParameters.push(this.getColumnPathCaptionParameterConfig(schemaName, xAxisColumn));
					const yAxisColumn = seriesConfigItem.yAxisColumn;
					if (yAxisColumn) {
						serviceParameters.push(this.getColumnPathCaptionParameterConfig(schemaName, yAxisColumn));
					}
					const sectionBindingColumn = seriesConfigItem.sectionBindingColumn;
					if (sectionBindingColumn) {
						serviceParameters.push(this.getColumnPathCaptionParameterConfig(schemaName,
							sectionBindingColumn));
					}
				}, this);
				this.getColumnPathCaption(this.Ext.JSON.encode(serviceParameters), function(response) {
					response.forEach(function(columnInfo) {
						this.set(columnInfo.key, {
							dataValueType: columnInfo.dataValueType,
							displayValue: columnInfo.columnCaption,
							referenceSchemaName: columnInfo.referenceSchemaName
						});
					}, this);
					callback.call(scope);
				}, this);
			},

			/**
			 * ####### ###### ###### ############# ## ####### ######## #####.
			 * @protected
			 * @virtual
			 * @param {Object} propertyValues ###### ######### #####.
			 * @return {BPMSoft.BaseViewModel} ###### ###### ############# ## ####### ######## #####.
			 */
			createSeriesViewModel: function(propertyValues) {
				const columns = {};
				for (var seriesProperty in this.seriesProperties) {
					columns[seriesProperty] = this.columns[seriesProperty] || {};
				}
				return this.Ext.create("BPMSoft.BaseViewModel", {
					columns: columns,
					values: propertyValues
				});
			},

			/**
			 * ########## ###### ######## ###### ##### #####.
			 * @private
			 * @param {String} entitySchemaName ######## entity #####.
			 * @param {String} columnPath #### #######.
			 * @return {Object} ########## ###### ######## ###### ##### #####.
			 */
			getSeriesColumnValue: function(entitySchemaName, columnPath) {
				let columnLookupValue;
				if (columnPath) {
					const columnKey = this.getColumnKey(entitySchemaName, columnPath);
					columnLookupValue = Ext.apply(this.get(columnKey), {
						value: columnPath
					});
				}
				return columnLookupValue;
			},

			/**
			 * ######### ######## ######### ##### #######.
			 * @protected
			 * @virtual
			 */
			loadSeriesCollection: function() {
				const seriesCollection = this.get("SeriesCollection");
				seriesCollection.clear();
				const convertedChartConfig = this.get("ConvertedChartConfig");
				let activeSeriesName;
				BPMSoft.each(convertedChartConfig.seriesConfig, function(seriesConfigItem) {
					let seriesTabTplConfig = this.getDefaultSeriesPropertiesValues();
					const seriesName = seriesTabTplConfig.Name;
					if (!activeSeriesName) {
						activeSeriesName = seriesName;
					}
					if (!convertedChartConfig.isNew) {
						const seriesConfigItemYAxisConfig = seriesConfigItem.yAxisConfig || {};
						const aggregationTypes = this.getAggregationTypeDefaultConfig();
						const chartTypes = this.getChartTypeDefaultConfig();
						const styleColors = this.getStyleColorDefaultConfig();
						const yAxisPositions = this.getYAxisPositionDefaultConfig();
						const entitySchemaName = seriesConfigItem.schemaName;
						let entitySchemaNameLookupValue;
						if (entitySchemaName) {
							entitySchemaNameLookupValue = {
								value: entitySchemaName,
								Name: entitySchemaName,
								displayValue: BPMSoft[entitySchemaName].caption
							};
						}
						const xAxisColumn = seriesConfigItem.xAxisColumn;
						const xAxisColumnLookupValue = this.getSeriesColumnValue(entitySchemaName, xAxisColumn);
						const yAxisColumn = seriesConfigItem.yAxisColumn;
						const yAxisColumnLookupValue = this.getSeriesColumnValue(entitySchemaName, yAxisColumn);
						const sectionBindingColumn = seriesConfigItem.sectionBindingColumn;
						const sectionBindingColumnLookupValue = this.getSeriesColumnValue(entitySchemaName,
							sectionBindingColumn);
						const seriesTabViewModelConfig = {
							entitySchemaName: entitySchemaNameLookupValue,
							aggregationType: aggregationTypes[seriesConfigItem.func],
							IsPercentageMode: seriesConfigItem.isPercentageMode,
							ChartType: chartTypes[seriesConfigItem.type],
							XAxisColumn: xAxisColumnLookupValue,
							aggregationColumn: yAxisColumnLookupValue,
							sectionBindingColumn: sectionBindingColumnLookupValue,
							XAxisCaption: seriesConfigItem.XAxisCaption,
							YAxisCaption: seriesConfigItem.YAxisCaption,
							StyleColor: styleColors[seriesConfigItem.styleColor],
							filterData: seriesConfigItem.filterData,
							Name: seriesName,
							Caption: seriesConfigItem.YAxisCaption || this.getSeriesTabCaption(),
							YAxisMinValue: seriesConfigItemYAxisConfig.min,
							YAxisMaxValue: seriesConfigItemYAxisConfig.max,
							YAxisPosition: yAxisPositions[seriesConfigItemYAxisConfig.position],
							UseEmptyValue: seriesConfigItem.useEmptyValue,
							format: seriesConfigItem.format,
							IsLegendEnabled: seriesConfigItem.isLegendEnabled
						};
						seriesTabTplConfig = Ext.apply(seriesTabTplConfig, seriesTabViewModelConfig);
					}
					const seriesTab = this.createSeriesViewModel(seriesTabTplConfig);
					seriesCollection.add(seriesName, seriesTab);
				}, this);
				this.set("ActiveSeriesName", activeSeriesName);
			},

			/**
			 * ######### ########## ####### ###### ############# ######### ######## ########## ######
			 * ############# #####.
			 * @protected
			 * @virtual
			 * @param {BPMSoft.BaseViewModel} seriesItem ###### ############# #####
			 */
			updateViewModelBySeriesItem: function(seriesItem) {
				this.set("ActiveSeriesTabIsChanging", true);
				this.set("entitySchemaName", null);
				const dateTimeFormat = this.get("DateTimeFormat");
				const useEmptyValue = this.get("UseEmptyValue");
				for (var propertyName in this.seriesProperties) {
					this.set(propertyName, null);
					this.set(propertyName, seriesItem.get(propertyName));
				}
				this.set("DateTimeFormat", dateTimeFormat);
				this.set("UseEmptyValue", useEmptyValue);
				this.set("ActiveSeriesTabIsChanging", false);
			},

			/**
			 * ######### ############# ######### ########.
			 * @protected
			 * @virtual
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ########## ####### ######### ######.
			 */
			initChartDesigner: function(callback, scope) {
				const chartConfig = this.get("WidgetInitConfig") ||
					this.sandbox.publish("GetModuleConfig", null, [this.sandbox.id]);
				const convertedChartConfig = this.convertChartConfig(chartConfig);
				const seriesConfig = convertedChartConfig.seriesConfig;
				this.set("ConvertedChartConfig", this.convertChartConfig(chartConfig));
				BPMSoft.chain(
					function(next) {
						this.loadSeriesEntitySchema(seriesConfig, function() {
							next();
						}, this);
					},
					function() {
						this.loadSeriesColumnCaptions(seriesConfig, function() {
							callback.call(scope);
						}, this);
						this.loadSeriesCollection();
					},
					this
				);
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#init
			 * @protected
			 * @overridden
			 */
			init: function(callback, scope) {
				if (!this.get("callParentInit")) {
					this.initChartDesigner(function() {
						this.set("callParentInit", true);
						this.init(callback, scope);
					}, this);
				} else {
					this.callParent([
						function() {
							this.chartDesignerParentInitCallback(callback, scope);
						}, this
					]);
				}
			},

			/**
			 * ############ ####### ####### ######### ###### ######## ###### #############.
			 * @private
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ######## ########## ####### ######### ######.
			 */
			chartDesignerParentInitCallback: function(callback, scope) {
				this.on("change:ActiveSeriesName", function() {
					this.set("moduleLoaded", true);
				}, this);
				this.on("change:XAxisColumn", this.onXAxisColumnChange, this);
				this.loadSeriesCollection();
				callback.call(scope);
			},

			/**
			 * ########## ###### ############# ## ######## #####.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.BaseViewModel[]} scope ######## ########## ####### ######### ######.
			 */
			getInvalidSeries: function() {
				const seriesCollection = this.get("SeriesCollection");
				const invalidSeriesCollection = seriesCollection.filterByFn(function(item) {
					return !item.validate();
				});
				return invalidSeriesCollection.getItems();
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#validate
			 * @protected
			 * @overridden
			 */
			validate: function() {
				const isValid = this.callParent(arguments);
				const invalidSeries = this.getInvalidSeries();
				return isValid && (invalidSeries.length === 0);
			},

			/**
			 * ############ ####### ######### ###### x.
			 * @protected
			 * @virtual
			 * @param {BPMSoft.BaseViewModel} viewModel ######### #######.
			 */
			onXAxisColumnChange: function(viewModel, changedColumn) {
				if (!this.get("ActiveSeriesTabIsChanging")) {
					let showWarning = false;
					if (changedColumn) {
						const activeSeriesName = this.get("ActiveSeriesName");
						const seriesCollection = this.get("SeriesCollection");
						const changedSeries = seriesCollection.get(activeSeriesName);
						const changedSeriesEntitySchema = changedSeries.get("entitySchemaName") || {};
						const changedSeriesEntitySchemaName = changedSeriesEntitySchema.Name;
						const changedColumnDataValueType = changedColumn.dataValueType;
						const changedColumnIsLookup = (changedColumn.dataValueType === BPMSoft.DataValueType.LOOKUP);
						seriesCollection.each(function(item) {
							if (activeSeriesName !== item.get("Name")) {
								const itemXAxisColumn = item.get("XAxisColumn") || {};
								const itemEntitySchema = item.get("entitySchemaName") || {};
								const itemEntitySchemaName = itemEntitySchema.Name;
								const itemXAxisColumnDataValueType = itemXAxisColumn.dataValueType;
								const diffTypes = changedColumnDataValueType !== itemXAxisColumnDataValueType;
								const dateTimeDataValueTypes =
									BPMSoft.isDateDataValueType(changedColumnDataValueType) &&
									BPMSoft.isDateDataValueType(itemXAxisColumnDataValueType);
								const sameSchema = (itemEntitySchemaName === changedSeriesEntitySchemaName);
								const diffReferenceSchema =
									itemXAxisColumn.referenceSchemaName !== changedColumn.referenceSchemaName;
								const changeColumnCondition = (diffTypes || diffReferenceSchema) &&
									!dateTimeDataValueTypes;
								if (sameSchema) {
									if (changeColumnCondition) {
										item.set("XAxisColumn", changedColumn, {silent: true});
									}
								} else if (changeColumnCondition) {
									item.set("XAxisColumn", null, {silent: true});
									showWarning = true;
								} else if (changedColumnIsLookup) {
									if (diffReferenceSchema) {
										item.set("XAxisColumn", null, {silent: true});
										showWarning = true;
									}
								}
							}
						});
					}
					if (showWarning) {
						const message = this.get("Resources.Strings.UpdatedXAxisColumns");
						BPMSoft.utils.showInformation(message, null, null, {buttons: ["ok"]});
					}
				}
				if (changedColumn && changedColumn.dataValueType &&
					!BPMSoft.isDateDataValueType(changedColumn.dataValueType)) {
					this.set("DateTimeFormat", null);
				}
			},

			/**
			 * ############ ####### ######### #######.
			 * @protected
			 * @virtual
			 * @param {BPMSoft.BaseViewModel} seriesItem ######### #######.
			 */
			onActiveSeriesChange: function(seriesItem) {
				this.set("moduleLoaded", false);
				this.updateViewModelBySeriesItem(seriesItem);
			},

			/**
			 * ######### ########### ###### ######## #####.
			 * @protected
			 * @virtual
			 * @return {Boolean} ########### ###### ######## #####.
			 */
			getIsDeleteSeriesButtonEnabled: function() {
				const seriesCollection = this.get("SeriesCollection");
				return seriesCollection.getCount() > 1;
			},

			/**
			 * Adds a new series.
			 * @virtual
			 */
			addSeries: function() {
				const newSeriesItemConfig = this.getDefaultSeriesPropertiesValues();
				const newSeriesItemName = newSeriesItemConfig.Name;
				const newSeriesViewModel = this.createSeriesViewModel(newSeriesItemConfig);
				this._addSeries(newSeriesItemName, newSeriesViewModel);
			},

			/**
			 * Adds a new series which is a copy of the current active series.
			 * @virtual
			 */
			copyActiveSeries: function() {
				const activeSeries = this.getActiveSeries();
				const defaultSeriesConfig = this.getDefaultSeriesPropertiesValues();
				const copiedSeriesName = defaultSeriesConfig.Name;
				const copiedSeriesCaption = activeSeries.$Caption;
				const copiedSeriesConfig = {
					Name: copiedSeriesName,
					Caption: copiedSeriesCaption
				};
				Object
					.keys(this.seriesProperties)
					.forEach(function(seriesPropName) {
						copiedSeriesConfig[seriesPropName] = activeSeries.get(seriesPropName);
					});
				const copiedSeriesViewModel = this.createSeriesViewModel(copiedSeriesConfig);
				this._addSeries(copiedSeriesName, copiedSeriesViewModel);
			},

			/**
			 * Function of removing active series.
			 * @virtual
			 */
			deleteActiveSeries: function() {
				const activeSeriesName = this.get("ActiveSeriesName");
				const seriesCollection = this.get("SeriesCollection");
				seriesCollection.removeByKey(activeSeriesName);
				const firstItem = seriesCollection.getByIndex(0);
				this.set("ActiveSeriesName", firstItem.get("Name"));
				const orderByConfig = this.getOrderByDefaultConfig();
				this.set("OrderBy", orderByConfig[BPMSoft.DashboardEnums.ChartOrderBy.CHART_ENTITY_COLUMN + ":0"]);
				this.set("moduleLoaded", true);
			},

			/**
			 * Gets the active series.
			 * @virtual
			 * @return {BPMSoft.BaseViewModel | null} The view model instance of the active series
			 * or null if there is no active series.
			 */
			getActiveSeries: function() {
				const activeSeriesName = this.get("ActiveSeriesName");
				if (!activeSeriesName) {
					return null;
				}
				const seriesCollection = this.get("SeriesCollection");
				return seriesCollection.get(activeSeriesName);
			},

			/**
			 * Returns the title of series tab.
			 * @protected
			 * @virtual
			 * @return {String} Returns the title of series tab.
			 */
			getSeriesTabCaption: function() {
				let tabIndex = 1;
				const seriesTabCaptionTpl = this.get("Resources.Strings.SeriesTabCaption");
				let tabCaption = Ext.String.format(seriesTabCaptionTpl, tabIndex);
				const findTabCaptionFunction = function(item) {
					return item.get("Caption") === tabCaption;
				};
				const seriesCollection = this.get("SeriesCollection");
				let captionExists = seriesCollection.getCount() > 0;
				while (captionExists) {
					tabCaption = Ext.String.format(seriesTabCaptionTpl, tabIndex);
					const foundItemsCollection = seriesCollection.filterByFn(findTabCaptionFunction);
					captionExists = foundItemsCollection.getCount() > 0;
					tabIndex += 1;
				}
				return tabCaption;
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#onDataChange
			 * @protected
			 * @overridden
			 */
			onDataChange: function(viewModel) {
				if (!this.get("ActiveSeriesTabIsChanging")) {
					const activeSeries = this.getActiveSeries();
					if (activeSeries) {
						const changedValues = viewModel.changed;
						BPMSoft.each(changedValues, function(changedPropertyValue, changedPropertyName) {
							if (this.seriesProperties[changedPropertyName]) {
								activeSeries.set(changedPropertyName, changedPropertyValue);
								if (changedPropertyName === this.tabCaptionProperty) {
									activeSeries.set("Caption", changedPropertyValue ||
										this.getSeriesTabCaption());
								}
							}
						}, this);
					}
				}
				this._setIsUnsupportedTypes();
				this._setIsStackedChart();
				this.callParent(arguments);
			},

			/**
			 * @private
			 */
			_setIsUnsupportedTypes: function() {
				const useHighCharts = BPMSoft.Features.getIsEnabled("UseHighCharts");
				if (useHighCharts) {
					return;
				}
				const seriesCollection = this.get("SeriesCollection");
				const series = seriesCollection && seriesCollection.getItems() || [];
				const types = series.map(function(item) {
					const charType = item.get("ChartType") || {};
					return charType.value;
				});
				const compatibilityMapping = this.get("SeriesCompatibilityMapping");
				const isCompatibilityTypes = BPMSoft.ChartCompatibilityValidator
					.isCompatibilityTypes(types, compatibilityMapping);
				this.set("IsUnsupportedTypes", !isCompatibilityTypes);
			},

			/**
			 * @private
			 */
			_setIsStackedChart: function() {
				const barSeries = this.$SeriesCollection.filterByFn(function(serie) {
					const chartType = serie.$ChartType || {};
					return this._isAvailableStackedChartType(chartType.value);
				}, this);
				const isNotContainsBarSeries = barSeries.getCount() === 0;
				if (isNotContainsBarSeries) {
					this.$IsStackedChart = false;
				}
			},

			/**
			 * @private
			 */
			_isAvailableStackedChartType: function(chartTypeValue) {
				return BPMSoft.contains(this._availabelStackedChartTypes, chartTypeValue);
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#getWidgetModuleName
			 * @protected
			 * @overridden
			 */
			getWidgetModuleName: function() {
				return "ChartModule";
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#getWidgetConfigMessage
			 * @protected
			 * @overridden
			 */
			getWidgetConfigMessage: function() {
				return "GetChartConfig";
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#getWidgetRefreshMessage
			 * @protected
			 * @overridden
			 */
			getWidgetRefreshMessage: function() {
				return "GenerateChart";
			},

			/**
			 * Returns the object of types of charts.
			 * @private
			 * @return {Object} Returns the object of types of charts.
			 */
			getChartTypeDefaultConfig: function() {
				const chartTypeDefaultConfig = {};
				BPMSoft.each(ChartModuleHelper.ChartSeriesKind, function(seriesKind) {
					chartTypeDefaultConfig[seriesKind.value] = {
						value: seriesKind.value,
						displayValue: seriesKind.displayValue,
						imageConfig: seriesKind.imageConfig
					};
				});
				return chartTypeDefaultConfig;
			},

			/**
			 * Fills the collection of types of charts.
			 * @protected
			 * @virtual
			 * @param {String} filter Filter's string.
			 * @param {BPMSoft.Collection} list List.
			 */
			prepareChartTypesList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getChartTypeDefaultConfig());
			},

			/**
			 * Returns type of sorting of the chart.
			 * If results are ordered by series in chart, property can be either in full notation:
			 * [BPMSoft.DashboardEnums.ChartOrderBy.CHART_ENTITY_COLUMN]:[SeriesIndex]
			 * or in reduced notation:
			 * [BPMSoft.DashboardEnums.ChartOrderBy.CHART_ENTITY_COLUMN]
			 * Latter implies SeriesIndex = 0.
			 * @private
			 * @param {String | Object} propertyValue Value of the OrderBy property from config.
			 * @return {String} type of sorting of the chart.
			 */
			_getOrderBy: function(propertyValue) {
				propertyValue = propertyValue.value || propertyValue;
				const splittedValue = propertyValue.split(":");
				const orderBy = splittedValue[0];
				let orderByPropertyValue;
				if (orderBy === BPMSoft.DashboardEnums.ChartOrderBy.CHART_ENTITY_COLUMN) {
					const seriesOrderIndex = parseInt(splittedValue[1], 10) || 0;
					orderByPropertyValue = orderBy.concat(":", seriesOrderIndex);
				} else {
					orderByPropertyValue = propertyValue;
				}
				return this.getOrderByDefaultConfig()[orderByPropertyValue];
			},

			/**
			 * Returns the object of sortable types.
			 * @private
			 * @return {Object} Returns the object of sortable types.
			 */
			getOrderByDefaultConfig: function() {
				const orderByDefaultConfig = {
					GroupByField: {
						value: BPMSoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD,
						displayValue: this.get("Resources.Strings.OrderByGroupByField")
					}
				};
				const valueTemplate = BPMSoft.DashboardEnums.ChartOrderBy.CHART_ENTITY_COLUMN + ":{0}";
				const displayValueTpl = this.get("Resources.Strings.OrderByChartEntityColumnSeries");
				const seriesCollection = this.get("SeriesCollection");
				seriesCollection.each(function(seriesItemViewModel, seriesItemViewModelIndex) {
					const value = Ext.String.format(valueTemplate, seriesItemViewModelIndex);
					const displayValue = Ext.String.format(displayValueTpl, seriesItemViewModel.get("Caption"));
					orderByDefaultConfig[value] = {
						value: value,
						displayValue: displayValue
					};
				}, this);
				return orderByDefaultConfig;
			},

			/**
			 * Fills the collection of sortable columns.
			 * @protected
			 * @virtual
			 * @param {String} filter Filter's string.
			 * @param {BPMSoft.Collection} list List.
			 */
			prepareOrderByList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getOrderByDefaultConfig());
			},

			/**
			 * Returns the object of sort directions.
			 * @private
			 * @return {Object} Returns the object of sort directions.
			 */
			getOrderDirectionDefaultConfig: function() {
				const orderByDefaultConfig = {
					Ascending: {
						value: "Ascending",
						displayValue: this.get("Resources.Strings.OrderDirectionASC")
					},
					Descending: {
						value: "Descending",
						displayValue: this.get("Resources.Strings.OrderDirectionDESC")
					}
				};
				return orderByDefaultConfig;
			},

			/**
			 * Fills the collection of sort directions.
			 * @protected
			 * @virtual
			 * @param {String} filter Filter's string.
			 * @param {BPMSoft.Collection} list List.
			 */
			prepareOrderDirectionList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getOrderDirectionDefaultConfig());
			},

			/**
			 * Returns the object of types of date.
			 * @private
			 * @return {Object} Returns the object of types of date.
			 */
			getDateTimeFormatDefaultConfig: function() {
				const dateTimeFormatDefaultConfig = {
					"Year": {
						value: "Year",
						displayValue: this.get("Resources.Strings.DateTimeFormatYear")
					},
					"Month;Year": {
						value: "Month;Year",
						displayValue: this.get("Resources.Strings.DateTimeFormatMonthYear")
					},
					"Month": {
						value: "Month",
						displayValue: this.get("Resources.Strings.DateTimeFormatMonth")
					},
					"Week": {
						value: "Week",
						displayValue: this.get("Resources.Strings.DateTimeFormatWeek")
					},
					"Day;Month;Year": {
						value: "Day;Month;Year",
						displayValue: this.get("Resources.Strings.DateTimeFormatDayMonthYear")
					},
					"Day;Month": {
						value: "Day;Month",
						displayValue: this.get("Resources.Strings.DateTimeFormatDayMonth")
					},
					"Day": {
						value: "Day",
						displayValue: this.get("Resources.Strings.DateTimeFormatDay")
					},
					"Hour": {
						value: "Hour",
						displayValue: this.get("Resources.Strings.DateTimeFormatHour")
					}
				};
				return dateTimeFormatDefaultConfig;
			},

			/**
			 * Fills the collection of types of date.
			 * @protected
			 * @virtual
			 * @param {String} filter Filter's string.
			 * @param {BPMSoft.Collection} list List.
			 */
			prepareDateTimeFormatList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getDateTimeFormatDefaultConfig());
			},

			/**
			 * Returns Y-axis label position.
			 * @private
			 * @return {Object} Y-axis label position.
			 */
			getYAxisPositionDefaultConfig: function() {
				const yAxisPositionDefaultConfig = {};
				yAxisPositionDefaultConfig[BPMSoft.DashboardEnums.ChartAxisPosition.NONE] = {
					value: BPMSoft.DashboardEnums.ChartAxisPosition.NONE,
					displayValue: this.get("Resource.Strings.ChartAxisPositionNone")
				};
				yAxisPositionDefaultConfig[BPMSoft.DashboardEnums.ChartAxisPosition.LEFT] = {
					value: BPMSoft.DashboardEnums.ChartAxisPosition.LEFT,
					displayValue: this.get("Resource.Strings.ChartAxisPositionLeft")
				};
				yAxisPositionDefaultConfig[BPMSoft.DashboardEnums.ChartAxisPosition.RIGHT] = {
					value: BPMSoft.DashboardEnums.ChartAxisPosition.RIGHT,
					displayValue: this.get("Resource.Strings.ChartAxisPositionRight")
				};
				return yAxisPositionDefaultConfig;
			},

			/**
			 * Fill ordered column collection.
			 * @protected
			 * @virtual
			 * @param {String} filter Filtered string.
			 * @param {BPMSoft.Collection} list List.
			 */
			prepareYAxisPositionList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getYAxisPositionDefaultConfig());
			},

			/**
			 * Schema name changing event handler.
			 * @protected
			 * @virtual
			 */
			onEntitySchemaNameChange: function() {
				if (this.get("moduleLoaded")) {
					this.set("XAxisColumn", null);
				}
				this.callParent(arguments);
			},

			/**
			 * Aggregation type changing event handler.
			 * @private
			 */
			onChartTypeChange: function() {
				const oldValue = arguments[2];
				if (oldValue) {
					this.set("XAxisCaption", null);
					this.set("YAxisCaption", null);
				}
			},

			/**
			 * Returns type date format visibility.
			 * @private
			 * @param {BPMSoft.DataValueType} value Value.
			 * @return {Boolean} Type date format visibility.
			 */
			dateTimeFormatVisibilityConverter: function(value) {
				return value && BPMSoft.isDateDataValueType(value.dataValueType);
			},

			/**
			 * Returns X-axis caption visibility.
			 * @private
			 * @param {BPMSoft.DataValueType} value Value.
			 * @return {Boolean} X-axis caption visibility
			 */
			xAxisCaptionVisibilityConverter: function(value) {
				const allowedChartTypes = ["spline", "line", "areaspline", "scatter"];
				return value && BPMSoft.contains(allowedChartTypes, value.value);
			},

			/**
			 * Returns Y-axis caption.
			 * @private
			 * @param {BPMSoft.DataValueType} value Value.
			 * @return {String} Y-axis caption.
			 */
			yAxisCaptionLabelConverter: function(value) {
				const allowedChartTypes = ["spline", "line", "areaspline", "scatter"];
				const testCondition = value && value.value && BPMSoft.contains(allowedChartTypes, value.value);
				const result = (testCondition)
					? this.get("Resources.Strings.YAxisCaption")
					: this.get("Resources.Strings.YAxisCaption2");
				return result;
			},

			/**
			 * Returns visibility of X-axis column.
			 * @private
			 * @param {Object} value Value.
			 * @return {Boolean} Visibility of X-axis column.
			 */
			XAxisColumnVisibilityConverter: function(value) {
				return Boolean(value);
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#setAttributeDisplayValue
			 * @protected
			 * @override
			 */
			setAttributeDisplayValue: function(propertyName, propertyValue) {
				switch (propertyName) {
					case "ChartType":
						propertyValue = this.getChartTypeDefaultConfig()[propertyValue];
						break;
					case "OrderDirection":
						propertyValue = this.getOrderDirectionDefaultConfig()[propertyValue];
						break;
					case "OrderBy":
						propertyValue = this._getOrderBy(propertyValue);
						break;
					case "DateTimeFormat":
						propertyValue = this.getDateTimeFormatDefaultConfig()[propertyValue];
						break;
					case "StyleColor":
						propertyValue = this.getStyleColorDefaultConfig()[propertyValue];
						break;
					default:
						this.callParent(arguments);
						return;
				}
				this.set(propertyName, propertyValue);
			},

			/**
			 * Sets validation settings.
			 * @private
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("DateTimeFormat", function(value) {
					let invalidMessage = "";
					if (this.dateTimeFormatVisibilityConverter(this.get("XAxisColumn")) &&
						(!value || (value && !value.value))) {
						invalidMessage = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				});
			},

			/**
			 * Returns style object.
			 * @protected
			 * @virtual
			 * @return {Object} Style object.
			 */
			getStyleColorDefaultConfig: function() {
				return BPMSoft.DashboardEnums.WidgetColor;
			},

			/**
			 * Fill style collection.
			 * @protected
			 * @virtual
			 * @param {String} filter Filtering string.
			 * @param {BPMSoft.Collection} list List.
			 */
			prepareStyleColorList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getStyleColorDefaultConfig());
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#save
			 * @protected
			 * @overridden
			 */
			save: function() {
				const invalidSeries = this.getInvalidSeries();
				if (invalidSeries.length > 0) {
					const message = Ext.String.format(this.get("Resources.Strings.InvalidSeriesConfig"),
						invalidSeries[0].get("Caption"));
					BPMSoft.showInformation(message, null, null, {buttons: ["ok"]});
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Returns section binding column.
			 * @protected
			 * @virtual
			 */
			getSectionBindingColumn: function(callback, scope) {
				const seriesCollection = this.$SeriesCollection;
				const activeSeries = seriesCollection.get(this.$ActiveSeriesName);
				const sectionBindingColumn = activeSeries.values.sectionBindingColumn;
				if (sectionBindingColumn) {
					Ext.callback(callback, scope, [sectionBindingColumn]);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Gets is unsupported types in series.
			 * @return {Boolean}
			 */
			getIsUnsupportedTypes: function () {
				return this.get("IsUnsupportedTypes");
			},

			/**
			 * Returns visibility of stacked bar configuration control.
			 * @protected
			 * @return {Boolean}
			 */
			isStackedChartAvailableConverter: function(chartType) {
				return this._isAvailableStackedChartType(chartType && chartType.value);
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "type",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "ChartType",
					"layout": {
						"column": 0,
						"row": 6,
						"colSpan": 24
					},
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.ChartTypeCaption"
						}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareChartTypesList"
						},
						"list": {
							"bindTo": "ChartTypeList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsStackedChart",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"bindTo": "IsStackedChart",
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": "isStackedChartAvailableConverter"
						}
					},
					"labelConfig": {
						"visible": true,
						"caption": {"bindTo": "Resources.Strings.IsStackedChartCaption"}
					},
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit"
					}
				}
			},
			{
				"operation": "insert",
				"name": "IsLegendEnabled",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"bindTo": "IsLegendEnabled",
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": function(chartType) {
								const disableLegendChartTypes = ['pie', 'funnel'];
								const chartTypeValue = chartType && chartType.value;
								return !BPMSoft.contains(disableLegendChartTypes, chartTypeValue);
							}
						}
					},
					"labelConfig": {
						"visible": true,
						"caption": {"bindTo": "Resources.Strings.IsLegendEnabledCaption"}
					},
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit"
					}
				}
			},
			{
				"operation": "move",
				"name": "QueryProperties",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "move",
				"name": "SectionBindingGroup",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 9
			},
			{
				"operation": "move",
				"name": "FormatProperties",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 10
			},
			{
				"operation": "move",
				"name": "FilterPropertiesGroup",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "insert",
				"name": "XAxisProperties",
				"parentName": "WidgetProperties",
				"index": 6,
				"propertyName": "items",
				"values": {
					"id": "XAxisProperties",
					"selectors": {
						"wrapEl": "#XAxisProperties"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.XAxisPropertiesCaption"
						}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "XAxisColumn",
				"parentName": "XAxisProperties",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"generator": "ColumnEditGenerator.generatePartial",
					"labelConfig": {
						"visible": true,
						"caption": {"bindTo": "Resources.Strings.AggregationColumnLabel"},
						"isRequired": true
					},
					"visible": {
						"bindTo": "entitySchemaName",
						"bindConfig": {"converter": "XAxisColumnVisibilityConverter"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "dateTimeFormat",
				"parentName": "XAxisProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "DateTimeFormat",
					"visible": {
						"bindTo": "XAxisColumn",
						"bindConfig": {"converter": "dateTimeFormatVisibilityConverter"}
					},
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.DateFormatCaption"
						}
					},
					"controlConfig": {
						"placeholder": {
							"bindTo": "Resources.Strings.DateFormatPlaceholder"
						},
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareDateTimeFormatList"
						},
						"list": {
							"bindTo": "DateTimeFormatList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "useEmptyValue",
				"parentName": "XAxisProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"bindTo": "UseEmptyValue",
					"visible": {
						"bindTo": "XAxisColumn",
						"bindConfig": {"converter": "XAxisColumnVisibilityConverter"}
					},
					"labelConfig": {
						"visible": true,
						"caption": {"bindTo": "Resources.Strings.UseEmptyValueCaption"}
					},
					"controlConfig": {
						"className": "BPMSoft.CheckBoxEdit"
					}
				}
			},
			{
				"operation": "insert",
				"name": "OrderProperties",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 7,
				"values": {
					"id": "OrderProperties",
					"selectors": {
						"wrapEl": "#OrderProperties"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"controlConfig": {
						"collapsed": false,
						"caption": {
							"bindTo": "Resources.Strings.OrderPropertiesGroupLabel"
						}
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "orderBy",
				"parentName": "OrderProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "OrderBy",
					"labelConfig": {
						"visible": true,
						"isRequired": true,
						"caption": {
							"bindTo": "Resources.Strings.SortCaption"
						}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareOrderByList"
						},
						"list": {
							"bindTo": "OrderByList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "orderDirection",
				"parentName": "OrderProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "OrderDirection",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.OrderDirectionCaption"
						}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareOrderDirectionList"
						},
						"list": {
							"bindTo": "OrderDirectionList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "StyleColor",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "StyleColor",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.StyleLabel"
						}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareStyleColorList"
						},
						"list": {
							"bindTo": "StyleColorList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "isPercentageMode",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"visible": false,
					"bindTo": "IsPercentageMode",
					"layout": {
						"column": 13,
						"row": 4,
						"colSpan": 11
					},
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.IsPercentageModeCaption"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "XAxisCaption",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"bindTo": "XAxisCaption",
					"contentType": 1,
					"visible": {
						"bindTo": "ChartType",
						bindConfig: {
							converter: "xAxisCaptionVisibilityConverter"
						}
					},
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.XAxisCaption"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "YAxisCaption",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"bindTo": "YAxisCaption",
					"contentType": 1,
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "ChartType",
							"bindConfig": {
								"converter": "yAxisCaptionLabelConverter"
							}
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "YAxisMin",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"visible": false,
					"bindTo": "YAxisMinValue",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.YAxisMinValueLabel"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "YAxisMax",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"visible": false,
					"bindTo": "YAxisMaxValue",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.YAxisMaxValueLabel"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "YAxisPosition",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"visible": false,
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "YAxisPosition",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.YAxisPositionLabel"
						}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareYAxisPositionList"
						},
						"list": {
							"bindTo": "YAxisPositionList"
						}
					}
				}
			},
			{
				"operation": "insert",
				"name": "XAxisDefaultCaption",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 1,
				"values": {
					"bindTo": "XAxisDefaultCaption",
					"visible": {
						"bindTo": "ChartType",
						bindConfig: {
							converter: "xAxisCaptionVisibilityConverter"
						}
					},
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.XAxisDefaultCaption"
						}
					},
					"tip": {
						"content": {"bindTo": "Resources.Strings.XAxisDefaultCaptionTip"}
					}

				}
			},
			{
				"operation": "insert",
				"name": "YAxisDefaultCaption",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 2,
				"values": {
					"bindTo": "YAxisDefaultCaption",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.YAxisDefaultCaption"
						}
					},
					"tip": {
						"content": {"bindTo": "Resources.Strings.YAxisDefaultCaptionTip"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "UnsupportedTypesInfo",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 3,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["unsupported-types"],
					"items": [],
					"visible": {"bindTo": "getIsUnsupportedTypes"}
				}
			},
			{
				"operation": "insert",
				"name": "UnsupportedTypesInfoButton",
				"parentName": "UnsupportedTypesInfo",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {"bindTo": "Resources.Strings.UnsupportedTypesMessage"},
					"style": BPMSoft.TipStyle.ORANGE,
					"controlConfig": {
						"imageConfig": informationButtonResources.localizableImages.WarningIcon
					}
				}
			},
			{
				"operation": "insert",
				"name": "SeriesTabPanelContainer",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 4,
				"values": {
					"id": "SeriesTabPanelContainer",
					"selectors": {
						"wrapEl": "#SeriesTabPanelContainer"
					},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["chart-designer-series-tab-panel"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Series",
				"parentName": "SeriesTabPanelContainer",
				"propertyName": "items",
				"index": 5,
				"values": {
					"itemType": BPMSoft.ViewItemType.TAB_PANEL,
					"activeTabChange": {"bindTo": "onActiveSeriesChange"},
					"activeTabName": {"bindTo": "ActiveSeriesName"},
					"collection": {"bindTo": "SeriesCollection"},
					"tabs": [],
					"controlConfig": {
						"items": [
							{
								"className": "BPMSoft.Button",
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"imageConfig": {"bindTo": "Resources.Images.Settings"},
								"markerValue": "SettingsButton",
								"menu": {
									items: [
										{
											"caption": {"bindTo": "Resources.Strings.AddSeriesButtonCaption"},
											"click": {"bindTo": "addSeries"},
											"markerValue": "AddSeriesButton"
										}, {
											"caption": {"bindTo": "Resources.Strings.CopySeriesButtonCaption"},
											"click": {"bindTo": "copyActiveSeries"},
											"markerValue": "CopyActiveSeriesButton",
											"enabled": {
												"bindTo": "ActiveSeriesName"
											}
										}, {
											"caption": {"bindTo": "Resources.Strings.DeleteSeriesButtonCaption"},
											"click": {"bindTo": "deleteActiveSeries"},
											"markerValue": "DeleteSeriesButton",
											"enabled": {
												"bindTo": "ActiveSeriesName",
												"bindConfig": {"converter": "getIsDeleteSeriesButtonEnabled"}
											}
										}
									]
								}
							}
						]
					}
				}
			}
		]
	};
});
