define("OpportunityFunnelDesigner", ["OpportunityFunnelDesignerResources", "ChartModuleHelper", "BPMSoft"],
	function(resources, ChartModuleHelper, BPMSoft) {
		var localizableStrings = resources.localizableStrings;
		return {
			messages: {

				/**
				 * Used to update funnel data on section filters change.
				 */
				"FiltersChanged": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				},

				/**
				 * @deprecated
				 */
				"GenerateOpportunityFunnel": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {

				/**
				 * Funnel default period.
				 */
				DefPeriod: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Sort field.
				 */
				OrderBy: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: false,
					value: {
						value: BPMSoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD,
						displayValue: localizableStrings.OrderByGroupByField
					}
				},

				/**
				 * Funnel chart instance unique id.
				 */
				InstanceUniqueKey: {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * Default period choices list.
				 */
				DefPeriodList: {
					dataValueType: BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#caption
				 * @overridden
				 */
				caption: {
					value: localizableStrings.OpportunityFunnelCaption
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#IsPercentageMode
				 * @overridden
				 */
				IsPercentageMode: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: false
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#ChartType
				 * @overridden
				 */
				ChartType: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: ChartModuleHelper.ChartSeriesKind.funnel
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#XAxisColumn
				 * @overridden
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
				 * @inheritdoc BPMSoft.ChartDesigner#YAxisColumn
				 * @overridden
				 */
				YAxisColumn: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#XAxisCaption
				 * @overridden
				 */
				XAxisCaption: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#YAxisCaption
				 * @overridden
				 */
				YAxisCaption: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#YAxisColumnCaptionLabel
				 * @overridden
				 */
				YAxisColumnCaptionLabel: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: localizableStrings.YAxisCaption
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#StyleColor
				 * @overridden
				 */
				StyleColor: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: BPMSoft.DashboardEnums.WidgetColor["widget-orange"]
				},
				
				/**
				 * @inheritdoc BPMSoft.BaseAggregationWidgetDesigner#FormatValueSettingsVisible
				 * @override
				 */
				FormatValueSettingsVisible: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.ChartDesigner#constructor
				 * @overridden
				 */
				constructor: function() {
					this.callParent(arguments);
					this.seriesProperties = this.Ext.apply({}, this.seriesProperties, {
						"DefPeriod": "defPeriod",
						"InstanceUniqueKey": "instanceUniqueKey"
					});
					this.set("InstanceUniqueKey", this.BPMSoft.generateGUID());
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#init
				 * @overridden
				 */
				init: function(callback, scope) {
					if (this.get("callParentInit")) {
						this.callParent(arguments);
						return;
					}
					this.set("DefPeriodList", this.Ext.create("BPMSoft.Collection"));
					this.callParent([function() {
						this.sandbox.publish("ChangeHeaderCaption", {
							caption: this.get("Resources.Strings.OpportunityFunnelDesignerCaption"),
							moduleName: this.name
						});
						if (this.Ext.isEmpty(this.$filterData)) {
							this.$filterData = this._getDefaultFilterData();
						}
						this.Ext.callback(callback, scope);
					}, this]);
				},

				/**
				 * Returns default filter.
				 * @private
				 * @return {String} The default filter.
				 */
				_getDefaultFilterData: function() {
					var config = this.getFunnelConfig();
					var filter = this.Ext.create("BPMSoft.FilterGroup", {rootSchemaName: config.schemaName});
					filter.serializationInfo = {serializeFilterManagerInfo: true};
					var serializableFilter = {};
					filter.getSerializableObject(serializableFilter, filter.serializationInfo);
					return BPMSoft.encode(serializableFilter);
				},

				/**
				 * Returns configuration object for funnel chart.
				 * @protected
				 * @return {Object}
				 */
				getFunnelConfig: function() {
					return {
						"schemaName": "Opportunity",
						"caption": this.get("Resources.Strings.OpportunityFunnelCaption"),
						"type": "funnel",
						"xAxisColumn": "Stage",
						"func": this.BPMSoft.AggregationType.COUNT,
						"orderBy": {
							value: this.BPMSoft.DashboardEnums.ChartOrderBy.GROUP_BY_FIELD,
							displayValue: this.get("Resources.Strings.OrderByGroupByField")
						},
						"orderDirection": "Ascending"
					};
				},

				/**
				 * Returns view model configuration for series tab.
				 * @param {Object} seriesConfigItem Series item values.
				 * @return {Object} Series tab view model config.
				 */
				getSeriesTabViewModelConfig: function(seriesConfigItem) {
					var seriesConfigItemYAxisConfig = seriesConfigItem.yAxisConfig || {};
					var aggregationTypes = this.getAggregationTypeDefaultConfig();
					var chartTypes = this.getChartTypeDefaultConfig();
					var defPeriods = this.getDefPeriods();
					var styleColors = this.getStyleColorDefaultConfig();
					var yAxisPositions = this.getYAxisPositionDefaultConfig();
					var entitySchemaName = seriesConfigItem.schemaName;
					var entitySchemaNameLookupValue;
					if (entitySchemaName) {
						entitySchemaNameLookupValue = {
							value: entitySchemaName,
							Name: entitySchemaName,
							displayValue: this.BPMSoft[entitySchemaName].caption
						};
					}
					if (!seriesConfigItem.styleColor) {
						seriesConfigItem.styleColor = "widget-green";
					}
					var xAxisColumn = seriesConfigItem.xAxisColumn;
					var xAxisColumnLookupValue = this.getSeriesColumnValue(entitySchemaName, xAxisColumn);
					var yAxisColumn = seriesConfigItem.yAxisColumn;
					var yAxisColumnLookupValue = this.getSeriesColumnValue(entitySchemaName, yAxisColumn);
					var sectionBindingColumn = seriesConfigItem.sectionBindingColumn;
					var sectionBindingColumnLookupValue = this.getSeriesColumnValue(entitySchemaName,
						sectionBindingColumn);
					var seriesTabViewModelConfig = {
						entitySchemaName: entitySchemaNameLookupValue,
						aggregationType: aggregationTypes[seriesConfigItem.func],
						IsPercentageMode: seriesConfigItem.isPercentageMode,
						ChartType: chartTypes[seriesConfigItem.type],
						DefPeriod: defPeriods[seriesConfigItem.defPeriod],
						InstanceUniqueKey: seriesConfigItem.instanceUniqueKey,
						XAxisColumn: xAxisColumnLookupValue,
						aggregationColumn: yAxisColumnLookupValue,
						sectionBindingColumn: sectionBindingColumnLookupValue,
						XAxisCaption: seriesConfigItem.XAxisCaption,
						YAxisCaption: seriesConfigItem.YAxisCaption,
						StyleColor: styleColors[seriesConfigItem.styleColor],
						filterData: seriesConfigItem.filterData,
						Name: seriesConfigItem.seriesName,
						Caption: seriesConfigItem.YAxisCaption || this.getSeriesTabCaption(),
						YAxisMinValue: seriesConfigItemYAxisConfig.min,
						YAxisMaxValue: seriesConfigItemYAxisConfig.max,
						YAxisPosition: yAxisPositions[seriesConfigItemYAxisConfig.position]
					};
					return seriesTabViewModelConfig;
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#loadSeriesCollection
				 * @protected
				 * @overridden
				 */
				loadSeriesCollection: function() {
					var seriesCollection = this.get("SeriesCollection");
					seriesCollection.clear();
					var convertedChartConfig = this.get("ConvertedChartConfig");
					var activeSeriesName = null;
					this.BPMSoft.each(convertedChartConfig.seriesConfig, function(seriesConfigItem) {
						var seriesTabTplConfig = this.getDefaultSeriesPropertiesValues();
						var seriesName = seriesTabTplConfig.Name;
						if (!activeSeriesName) {
							activeSeriesName = seriesName;
						}
						seriesConfigItem.seriesName = seriesName;
						var seriesTabViewModelConfig = this.getSeriesTabViewModelConfig(seriesConfigItem);
						seriesTabTplConfig = this.Ext.apply(seriesTabTplConfig, seriesTabViewModelConfig);
						var seriesTab = this.createSeriesViewModel(seriesTabTplConfig);
						seriesCollection.add(seriesName, seriesTab);
					}, this);
					this.set("ActiveSeriesName", activeSeriesName);
				},

				/**
				 * @inheritdoc BPMSoft.BaseWidgetDesigner#getWidgetInitConfig
				 * @overridden
				 */
				getWidgetInitConfig: function() {
					let initConfig = this.callParent(arguments);
					initConfig = this.Ext.apply(this.getFunnelConfig(), initConfig);
					return initConfig;
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#convertChartConfig
				 * @overridden
				 */
				convertChartConfig: function(chartConfig) {
					chartConfig = this.Ext.apply(this.getFunnelConfig(), chartConfig);
					var config = this.callParent(arguments);
					var mainSeriesConfig = config.seriesConfig[0];
					this.Ext.apply(mainSeriesConfig, {
						defPeriod: chartConfig.defPeriod,
						instanceUniqueKey: chartConfig.instanceUniqueKey
					});
					return config;
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#getModuleId
				 * @overridden
				 */
				getModuleId: function() {
					return this.sandbox.id + "OpportunityFunnelDesigner";
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#getWidgetModuleName
				 * @overridden
				 */
				getWidgetModuleName: function() {
					return "OpportunityFunnelModuleV2";
				},

				/**
				 * Handler for default period value change.
				 * @protected
				 * @param {Object} newPeriod New default period value.
				 */
				onChangeDefPeriod: function(newPeriod) {
					if (this.get("callParentInit")) {
						this.sandbox.publish("FiltersChanged", newPeriod && newPeriod.value);
					}
				},

				/**
				 * @inheritdoc BPMSoft.ChartDesigner#setAttributeDisplayValue
				 * @protected
				 * @overridden
				 */
				setAttributeDisplayValue: function(propertyName, propertyValue) {
					if (propertyName === "DefPeriod") {
						propertyValue = this.getDefPeriods()[propertyValue];
					}
					this.callParent([propertyName, propertyValue]);
				},

				/**
				 * Returns default period options list.
				 * @protected
				 * @return {Object} Period list.
				 */
				getDefPeriods: function() {
					var defPeriodConfig = this.Ext.create("BPMSoft.Collection");
					this.prepareDefPeriodList(null, defPeriodConfig);
					var defPeriod = {};
					defPeriodConfig.eachKey(function(key, item) {
						defPeriod[key] = item;
					}, this);
					return defPeriod;
				},

				/**
				 * Appends default period options to list.
				 * @protected
				 * @param {Object} filter List items filtration data.
				 * @param {Object} list List to load options to.
				 */
				prepareDefPeriodList: function(filter, list) {
					if (list === null) {
						return;
					}
					var defPeriodConfig = this.Ext.create("BPMSoft.Collection");
					defPeriodConfig.add("PastWeek", {
						value: "PastWeek",
						displayValue: this.get("Resources.Strings.PastWeekCaption")
					});
					defPeriodConfig.add("CurrentWeek", {
						value: "CurrentWeek",
						displayValue: this.get("Resources.Strings.CurrentWeekCaption")
					});
					defPeriodConfig.add("PastMonth", {
						value: "PastMonth",
						displayValue: this.get("Resources.Strings.PastMonthCaption")
					});
					defPeriodConfig.add("CurrentMonth", {
						value: "CurrentMonth",
						displayValue: this.get("Resources.Strings.CurrentMonthCaption")
					});
					list.clear();
					list.loadAll(defPeriodConfig);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "remove",
					"name": "type",
					"parentName": "QueryProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "XAxisProperties",
					"parentName": "WidgetProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "OrderProperties",
					"parentName": "WidgetProperties",
					"propertyName": "items"
				},

				{
					"operation": "remove",
					"name": "XAxisCaption",
					"parentName": "FormatProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "YAxisCaption",
					"parentName": "FormatProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "YAxisDefaultCaption",
					"parentName": "FormatProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "YAxisMin",
					"parentName": "FormatProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "YAxisMax",
					"parentName": "FormatProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "YAxisPosition",
					"parentName": "FormatProperties",
					"propertyName": "items"
				},
				{
					"operation": "insert",
					"name": "defPeriod",
					"parentName": "FormatProperties",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"bindTo": "DefPeriod",
						"labelConfig": {
							"visible": true,
							"caption": {
								"bindTo": "Resources.Strings.DefPeriodCaption"
							}
						},
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": {
								"bindTo": "prepareDefPeriodList"
							},
							"list": {
								"bindTo": "DefPeriodList"
							},
							"change": {
								"bindTo": "onChangeDefPeriod"
							}
						}
					}
				},
				{
					"operation": "remove",
					"name": "isPercentageMode",
					"parentName": "FormatProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "Series",
					"parentName": "SeriesTabPanelContainer",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "QueryProperties",
					"parentName": "WidgetProperties",
					"propertyName": "items"
				},
				{
					"operation": "remove",
					"name": "StyleColor"
				}
			]/**SCHEMA_DIFF*/
		};
	});
