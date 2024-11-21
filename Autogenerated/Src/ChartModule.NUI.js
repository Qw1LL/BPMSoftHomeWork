define("ChartModule", ["ChartModuleHelper", "LocalizationUtilities", "ChartModuleResources", "DataUtilities",
		"GoogleTagManagerUtilities", "MaskHelper", "BaseWidgetModule", "HighchartsWrapper", "EntityStructureHelperMixin",
		"GridUtilitiesV2", "DashboardEnums", "ChartDrillDownProvider", "ContainerList", "MiniPageUtilities", "PageUtilities",
		"DetailManager"],
	function(chartModuleHelper, LocalizationUtilities, resources, DataUtilities, GoogleTagManagerUtilities, MaskHelper) {

		/**
		 * @class BPMSoft.configuration.ChartViewModel
		 * Class of chart module view model .
		 */
		Ext.define("BPMSoft.configuration.ChartViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.ChartViewModel",

			"mixins": {
				/**
				 * @class GridUtilities.
				 */
				"GridUtilities": "BPMSoft.GridUtilities",

				/**
				 * @class MiniPageUtilities
				 */
				"MiniPageUtilitiesMixin": "BPMSoft.MiniPageUtilities",

				/**
				 * @class PageUtilities
				 */
				"PageUtilities": "BPMSoft.PageUtilities"
			},

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * Object schema for module view model.
			 * @type {BPMSoft.BaseEntitySchema}
			 */
			entitySchema: Ext.create("BPMSoft.BaseEntitySchema", {
				columns: {},
				primaryColumnName: "Id"
			}),

			/**
			 * Tag filtering message.
			 * @type {String}
			 */
			filterMessageTag: null,

			/**
			 * Object translator from parameter names to view model columns.
			 * @type {Object}
			 */
			chartModulePropertiesTranslator: {
				"Caption": "caption",
				"hideCaption": "hideCaption",
				"EntitySchemaName": "schemaName",
				"sectionBindingColumn": "sectionBindingColumn",
				"Func": "func",
				"SeriesKind": "type",
				"XAxisCaption": "XAxisCaption",
				"YAxisCaption": "YAxisCaption",
				"XAxisColumn": "xAxisColumn",
				"YAxisColumn": "yAxisColumn",
				"DateTimeFormat": "dateTimeFormat",
				"OrderByAxis": "orderBy",
				"OrderDirection": "orderDirection",
				"IsPercentageMode": "isPercentageMode",
				"primaryColumnName": "primaryColumnName",
				"SerializedFilterData": "filterData",
				"styleColor": "styleColor",
				"SeriesConfig": "seriesConfig",
				"YAxisConfig": "yAxisConfig",
				"XAxisDefaultCaption": "xAxisDefaultCaption",
				"YAxisDefaultCaption": "yAxisDefaultCaption",
				"UseEmptyValue": "useEmptyValue",
				"format": "format",
				"IsStackedChart": "isStackedChart",
				"IsLegendEnabled": "isLegendEnabled"
			},

			/**
			 * Model properties.
			 * type {Object}
			 */
			columns: {
				"NonLocalizedCaption": {
					columnPath: "Caption",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				},
				"SeriesKind": {
					columnPath: "SysChartSeriesKind.Code",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				},
				"Func": {
					columnPath: "SysAggregationType.Code",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				},
				"DateTimeFormat": {
					columnPath: "SysDateTimeFormat.Code",
					type: BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				},
				"ShowSettingsButton": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				},
				"ShowContextMenu": {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				}
			},

			/**
			 * Profile key prefix.
			 * @type {String}
			 */
			profilePrefix: "profile!",

			/**
			 * Code system setting data request restrictions of chart.
			 * @protected
			 * @virtual
			 * @type {String}
			 */
			queryDataLimitSysSettingCode: "ChartQueryDataLimit",

			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
				var entityColumns = BPMSoft.deepClone(this.entitySchema.columns);
				var skipColumns = ["Caption", "SeriesKind", "EntitySchema", "YAxisColumnCaption", "XAxisColumnCaption",
					"ModuleSchemaColumnNameCaption", "Order"];
				BPMSoft.each(entityColumns, function(column, columnName) {
					if (skipColumns.indexOf(columnName) !== -1) {
						return;
					}
					column.type = BPMSoft.ViewModelColumnType.ENTITY_COLUMN;
					column.columnPath = columnName;
				}, this);
				Ext.apply(entityColumns, this.columns);
				this.columns = entityColumns;
			},

			//region Methods: Private

			/**
			 * @private
			 */
			_getDataRootSchema: function() {
				var entitySchema = null;
				if (this.drillDownProvider) {
					var entitySchemaName = this.drillDownProvider.getEntitySchemaName();
					entitySchema = this.drillDownProvider.getEntitySchemaByName(entitySchemaName);
				}
				return entitySchema;
			},

			/**
			 * Creates instance BPMSoft.EntitySchemaQuery.
			 * @private
			 * @return {BPMSoft.EntitySchemaQuery} Instance of EntitySchemaQuery.
			 */
			getChartDataESQ: function() {
				return this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchema: this._getDataRootSchema() || this.entitySchema,
					queryKind: BPMSoft.QueryKind.LIMITED
				});
			},

			/**
			 * Adds filters to Entity schema query.
			 * @private
			 * @param {BPMSoft.EntitySchemaQuery} esq EntitySchemaQuery request.
			 */
			addChartQueryFilters: function(esq) {
				var filterContainer = {
					filters: this.Ext.create("BPMSoft.FilterGroup")
				};
				this.drillDownProvider.addFilters(filterContainer);
				esq.filters.addItem(filterContainer.filters);
			},

			/**
			 * Adds columns to Entity schema query.
			 * @private
			 * @param {BPMSoft.EntitySchemaQuery} esq EntitySchemaQuery request.
			 */
			addChartProfileColumns: function(esq) {
				this.addProfileColumns(esq);
			},

			//endregion

			/**
			 * Processes module display presentation event.
			 * @virtual
			 */
			onRender: function() {
				if (!this.get("Restored")) {
					return;
				}
				if (this.get("GridSettingsChanged") === true) {
					this.reloadGridData();
				} else {
					this.reloadGridColumnsConfig(true);
				}
			},

			/**
			 * Converts widget style to colour.
			 * @param {String} value Style name.
			 * @return {String} Colour.
			 */
			styleColorConverter: function(value) {
				return this.BPMSoft.DashboardEnums.StyleColors[value];
			},

			/**
			 * Initializes the resource model with values from the object resources.
			 * @protected
			 * @virtual
			 * @param {Object} resourcesObj Resource object.
			 */
			initResourcesValues: function(resourcesObj) {
				var resourcesSuffix = "Resources";
				BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
					resourceGroupName = resourceGroupName.replace("localizable", "");
					BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
						var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
						this.set(viewModelResourceName, resourceValue);
					}, this);
				}, this);
			},

			/**
			 * Returns client query with localized caption.
			 * @overridden
			 * @return {BPMSoft.EntitySchemaQuery} Client query with localized caption.
			 */
			getEntitySchemaQuery: function() {
				var entitySchemaQuery = this.callParent(arguments);
				LocalizationUtilities.addLocalizableColumn(entitySchemaQuery, "Caption");
				return entitySchemaQuery;
			},

			/**
			 * Returns true if can set empty view model property.
			 * @private
			 * @param viewModelPropertyName View model property name.
			 * @return {Boolean} True if can set empty view model property.
			 */
			canSetEmptyViewModelProperty: function(viewModelPropertyName) {
				return this.BPMSoft.contains([
					"XAxisDefaultCaption",
					"YAxisDefaultCaption",
					"sectionBindingColumn",
					"UseEmptyValue",
					"IsStackedChart",
					"IsLegendEnabled"
				], viewModelPropertyName);
			},

			/**
			 * Creates chart based on object settings.
			 * @protected
			 * @virtual
			 * @param {Object} config Configuration object.
			 */
			createChartByConfig: function(config) {
				this.BPMSoft.each(this.chartModulePropertiesTranslator, function(configName, viewModelName) {
					var value = config[configName];
					if (value || this.canSetEmptyViewModelProperty(viewModelName)) {
						this.set(viewModelName, value);
					}
				}, this);
			},

			/**
			 * Returns array of categories for current data.
			 * @protected
			 * @virtual
			 * @return {String[]} Array of categories for current data.
			 */
			getCategories: function() {
				var seriesData = this.get("SeriesData");
				var categories = seriesData && seriesData[0].data.map(function(item) {
					return item.name;
				});
				return categories || [];
			},

			/**
			 * Parses data to percents.
			 * @protected
			 * @virtual
			 * @param {Object} seriesData Series data.
			 * @return {String[]} Returns percentage data.
			 */
			parseToPercentage: function(seriesData) {
				var countY = 0;
				BPMSoft.each(seriesData, function(item) {
					countY += item.y;
				});
				countY = (100 / countY);
				BPMSoft.each(seriesData, function(item) {
					item.y = parseFloat((item.y * countY).toFixed(2));
				});
				return seriesData;
			},

			/**
			 * Drills up the schedule.
			 * @protected
			 * @virtual
			 */
			drillUp: function() {
				this.drillDownProvider.drillUp();
				this.refresh();
			},

			/**
			 * Returns the schedule to the initial state.
			 * @protected
			 * @virtual
			 */
			cancelDrill: function() {
				this.drillDownProvider.cancelDrill();
				this.refresh();
			},

			/**
			 * Drills down the schedule at the selected point.
			 * @protected
			 * @virtual
			 * @param {string} tag Type for schedule.
			 */
			drillDownChart: function(tag) {
				var categoryItem = this.get("CurrentPoint").categoryItem;
				this.drillDownProvider.drillDownChart(categoryItem, function() {
					this.drillDownProvider.changeCurrentHistory({
						seriesKind: tag
					}, this);
					this.refresh();
				}, this);
			},

			/**
			 * Changes type of chart.
			 * @protected
			 * @virtual
			 * @param {String} seriesKind New type of chart.
			 */
			changeChartType: function(seriesKind) {
				this.drillDownProvider.changeCurrentHistory({
					seriesKind: seriesKind
				}, this);
				this.set("SeriesKind", seriesKind);
			},

			/**
			 * Deploys chart by selected point with conversion into data grid.
			 * @protected
			 * @virtual
			 */
			showDrillDownData: function() {
				var currentPoint = this.get("CurrentPoint");
				var categoryItem = currentPoint.categoryItem;
				this.drillDownProvider.addItemFilter(categoryItem);
				this.drillDownProvider.changeCurrentHistory({
					displayMode: BPMSoft.DashboardEnums.ChartDisplayMode.GRID,
					entitySchemaName: categoryItem.entitySchemaName,
					categoryItem: categoryItem,
					xAxisColumn: this.drillDownProvider.getCategoryItemXAxisColumnPath(categoryItem),
					yAxisColumn: this.drillDownProvider.getCategoryItemYAxisColumnPath(categoryItem)
				});
				var data = this.getGoogleTagManagerData();
				GoogleTagManagerUtilities.actionModule(data);
				this.refresh();
			},

			/**
			 * Returns data to send to google tag manager.
			 * @protected
			 * @return {Object} Google tag manager data.
			 */
			getGoogleTagManagerData: function() {
				return {
					chartType: this.get("type"),
					action: "ShowDrillDownData"
				};
			},

			/**
			 * Reloads data for current state.
			 * @protected
			 * @virtual
			 * param {Function} callback Callback method.
			 * param {BPMSoft.BaseModel} scope Callback method context.
			 */
			refresh: function(callback, scope) {
				if (!this.drillDownProvider) {
					return;
				}
				var displayMode = this.drillDownProvider.getDisplayMode();
				this.set("displayMode", displayMode);
				switch (displayMode) {
					case BPMSoft.DashboardEnums.ChartDisplayMode.CHART:
						this.getChartSeriesData(function() {
							this.set("SeriesKind", this.drillDownProvider.getSeriesKind());
							this.updateChartSize();
							Ext.callback(callback, scope);
						}, this);
						break;
					case BPMSoft.DashboardEnums.ChartDisplayMode.GRID:
						this.set("IsClearGridData", true);
						this.initProfile(function() {
							this.prepareProfile();
							this.initSortActionItems();
							this.loadGridData();
							Ext.callback(callback, scope);
						}, this);
						break;
				}
			},

			/**
			 * Returns formulaic grid template config.
			 * @protected
			 * @virtual
			 * @param {String} entitySchemaName Name of entity schema.
			 * @param {String} columnPath Path of column.
			 * @return {Object} Formulaic grid template config.
			 */
			getGridItemTemplateConfig: function(entitySchemaName, columnPath) {
				var caption = this.drillDownProvider.getEntitySchemaColumnCaption(entitySchemaName, columnPath);
				if (!caption) {
					var entitySchema = this.drillDownProvider.getEntitySchemaByName(entitySchemaName);
					var columns = entitySchema.columns;
					caption = columns[columnPath].caption;
				}
				return {
					"bindTo": columnPath,
					"caption": caption,
					"captionConfig": {
						"visible": true
					}
				};
			},

			/**
			 * Generates object list in settings, if they empty for specific fields.
			 * @protected
			 * @virtual
			 */
			prepareProfile: function() {
				var profile = this.get("Profile");
				this.set("GridSettingsChanged", true);
				profile = (profile && BPMSoft.deepClone(profile)) || {};
				var gridName = this.getDataGridName();
				if (profile[gridName]) {
					return;
				}
				profile[gridName] = this._getDefaultChartProfile();
				this.set("Profile", profile);
			},

			_getDefaultChartProfile: function() {
				const columnsConfig = this._getDefaultColumnsConfig();
				const listedConfig = {
					"items": columnsConfig
				};
				const tiledConfig = {
					"grid": {
						"rows": 1,
						"columns": 24
					},
					"items": columnsConfig
				};
				const gridProfile = {
					"isTiled": false,
					"type": "listed",
					"key": this.getProfileKey(),
					"listedConfig": BPMSoft.encode(listedConfig),
					"tiledConfig": BPMSoft.encode(tiledConfig)
				};
				return gridProfile;
			},

			_getDefaultColumnsConfig: function() {
				var columnsConfig = [];
				var entitySchemaName = this.drillDownProvider.getEntitySchemaName();
				var entitySchema = this.drillDownProvider.getEntitySchemaByName(entitySchemaName);
				this._addPrimaryDisplayColumnConfig(columnsConfig, entitySchema);
				this._addXAxisColumnConfig(columnsConfig, entitySchema);
				this._addYAxisColumnConfig(columnsConfig, entitySchema);
				this._setColumnsConfigPosition(columnsConfig);
				return columnsConfig;
			},

			_addPrimaryDisplayColumnConfig: function(columnsConfig, entitySchema) {
				const primaryDisplayColumnName = entitySchema.primaryDisplayColumnName;
				if (!Ext.isEmpty(primaryDisplayColumnName)) {
					const entitySchemaName = entitySchema.name;
					const primaryDisplayColumnConfig = this.getGridItemTemplateConfig(entitySchemaName, primaryDisplayColumnName);
					columnsConfig.push(primaryDisplayColumnConfig);
				}
			},
			
			_addXAxisColumnConfig: function(columnsConfig, entitySchema) {
				const entitySchemaName = entitySchema.name;
				const xAxisColumn = this.drillDownProvider.getXAxisColumn();
				const backwardPathKey = ":" + entitySchemaName;
				const isBackwardColumnPath = xAxisColumn && xAxisColumn.indexOf(backwardPathKey) >= 0;
				if (!isBackwardColumnPath) {
					columnsConfig.push(this.getGridItemTemplateConfig(entitySchemaName, xAxisColumn));
				}
			},

			_addYAxisColumnConfig:function(columnsConfig, entitySchema) {
				const entitySchemaName = entitySchema.name;
				const yAxisColumn = this.drillDownProvider.getYAxisColumn();
				if (yAxisColumn !== entitySchema.primaryColumnName) {
					columnsConfig.push(this.getGridItemTemplateConfig(entitySchemaName, yAxisColumn));
				}
			},

			_setColumnsConfigPosition: function(columnsConfig) {				
				var columnsCount = columnsConfig.length;
				var columnWidth = 24 / columnsCount;
				BPMSoft.each(columnsConfig, function(columnConfig, index) {
					Ext.apply(columnConfig, {
						"position": {
							"column": columnWidth * index,
							"colSpan": columnWidth,
							"row": 1
						}
					});
				}, this);
			},

			/**
			 * Changes display mode to grid.
			 * @protected
			 * @virtual
			 */
			showChartData: function() {
				this.drillDownProvider.pushHistory({
					displayMode: BPMSoft.DashboardEnums.ChartDisplayMode.GRID
				}, this);
				this.refresh();
			},

			/**
			 * @inheritDoc BPMSoft.configuration.mixins.GridUtilities#getGridEntitySchema
			 * @overridden
			 */
			getGridEntitySchema: function() {
				var entitySchemaName = this.drillDownProvider.getEntitySchemaName();
				return this.drillDownProvider.getEntitySchemaByName(entitySchemaName) ||
					this.mixins.GridUtilities.getGridEntitySchema.call(this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.mixins.GridUtilities#getGridDataESQ
			 * @overridden
			 */
			getGridDataESQ: function() {
				return this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchema: this._getDataRootSchema(),
					rowViewModelClassName: this.getGridRowViewModelClassName(),
					isDistinct: true
				});
			},

			/**
			 * @inheritDoc BPMSoft.configuration.mixins.GridUtilities#initQueryFilters
			 * @overridden
			 */
			initQueryFilters: function(esq) {
				this.drillDownProvider.addFilters(esq);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.mixins.GridUtilities#getGridDataColumns
			 * @overridden
			 */
			getGridDataColumns: function() {
				var defColumnsConfig = {};
				var entitySchemaName = this.drillDownProvider.getEntitySchemaName();
				var entitySchema = this.drillDownProvider.getEntitySchemaByName(entitySchemaName);
				if (entitySchema) {
					var primaryColumnName = entitySchema.primaryColumnName;
					var primaryDisplayColumnName = entitySchema.primaryDisplayColumnName;
					defColumnsConfig[primaryColumnName] = {
						path: primaryColumnName
					};
					if (primaryDisplayColumnName) {
						defColumnsConfig[primaryDisplayColumnName] = {
							path: primaryDisplayColumnName
						};
					}
				}
				return defColumnsConfig;
			},

			/**
			 * Adds subquery that calculates the number of active access points on the process.
			 * @param esq
			 */
			addProcessEntryPointColumn: BPMSoft.emptyFn,

			/**
			 * Initializes parameters of the view model by passed parameters.
			 * @protected
			 * @virtual
			 */
			initParameters: function() {
				BPMSoft.each(this.chartModulePropertiesTranslator, function(configName, viewModelName) {
					var value = this.get(configName);
					if (value) {
						this.set(viewModelName, value);
					}
				}, this);
			},

			/**
			 * Initializes navigation chain parameter.
			 * @protected
			 * @virtual
			 */
			initBreadCrumbs: function() {
				var collection = this.Ext.create("BPMSoft.Collection");
				collection.on("dataLoaded", this.onBreadCrumbsChanged, this);
				collection.on("add", this.onBreadCrumbsChanged, this);
				collection.on("remove", this.onBreadCrumbsChanged, this);
				collection.on("clear", this.onBreadCrumbsChanged, this);
				this.set("BreadCrumbs", collection);
			},

			/**
			 * Handler for navigation chain change.
			 * @protected
			 * @virtual
			 */
			onBreadCrumbsChanged: function() {
				this.set("isBreadCrumbsVisible", !this.get("BreadCrumbs").isEmpty());
			},

			/**
			 * Initializes provider of chart deployment.
			 * @protected
			 * @virtual
			 * param {Function} callback Callback method.
			 * param {BPMSoft.BaseModel} scope Callback method context.
			 */
			initDrillDownProvider: function(callback, scope) {
				if (this.drillDownProvider) {
					this.drillDownProvider.destroy();
				}
				BPMSoft.chain(
					function(next) {
						if (this.get("EntitySchemaName") && this.get("OrderByAxis")) {
							var drillDownProviderLocalizableValues = {
								BooleanFieldTrueCaption: this.get("Resources.Strings.BooleanFieldTrueCaption"),
								BooleanFieldFalseCaption: this.get("Resources.Strings.BooleanFieldFalseCaption")
							};
							this.drillDownProvider = this.Ext.create("BPMSoft.ChartDrillDownProvider", {
								Ext: this.Ext,
								sandbox: this.sandbox,
								serializedFilterData: this.get("SerializedFilterData"),
								filterMessageTag: this.filterMessageTag,
								localizableValues: drillDownProviderLocalizableValues
							});
							this.drillDownProvider.initState({
								entitySchemaName: this.get("EntitySchemaName"),
								sectionBindingColumn: this.get("sectionBindingColumn"),
								dateTimeFormat: this.get("DateTimeFormat") || "Year;Month",
								xAxisColumn: this.get("XAxisColumn"),
								orderBy: this.get("OrderByAxis"),
								orderDirection: this.get("OrderDirection"),
								func: this.get("Func"),
								seriesKind: this.get("SeriesKind"),
								yAxisColumn: this.get("YAxisColumn"),
								displayMode: this.get("displayMode"),
								seriesConfig: this.get("SeriesConfig"),
								yAxis: this.get("yAxis"),
								YAxisCaption: this.get("YAxisCaption"),
								yAxisConfig: this.get("YAxisConfig"),
								styleColor: this.get("styleColor"),
								useEmptyValue: this.get("UseEmptyValue"),
								primaryColumnValue: this.get("primaryColumnValue"),
								sectionEntitySchemaName: this.get("sectionEntitySchemaName"),
								format: this.get("format"),
								isLegendEnabled: this.get("IsLegendEnabled")
							});
							this.drillDownProvider.on("historyChanged", this.historyChanged, this);
							this.drillDownProvider.getEntitySchema(this.get("EntitySchemaName"), next, this);
						} else {
							this.drillDownProvider = null;
							next();
						}
					},
					function() {
						if (this.drillDownProvider && Ext.isEmpty(this.drillDownProvider.queryDataLimit)) {
							BPMSoft.SysSettings.querySysSettingsItem(this.queryDataLimitSysSettingCode, function(value) {
								this.drillDownProvider.queryDataLimit = value ? value : -1;
								callback.call(scope);
							}, this);
						} else {
							callback.call(scope);
						}
					},
					this
				);
			},

			/**
			 * Updates parameters that depend on state history.
			 * @protected
			 * @virtual
			 */
			historyChanged: function() {
				this.set("isDrilledDown", this.drillDownProvider && this.drillDownProvider.isDrilledDown());
				this.setBreadCrumbs();
			},

			_updateBreadCrumbsExistStyle: function(breadCrumbsExist) {
				var chartContainerId = "chart-wrapper-Chart_" + this.sandbox.id;
				var chartEl = document.getElementById(chartContainerId);
				if (!chartEl) {
					return;
				}
				if (!breadCrumbsExist) {
					chartEl.classList.remove("breadCrumbsExist");
				} else {
					chartEl.classList.add("breadCrumbsExist");
				}
			},

			/**
			 * Sets the parameter of navigation chain.
			 * @protected
			 * @virtual
			 */
			setBreadCrumbs: function() {
				if (!this.drillDownProvider) {
					return;
				}
				this._updateBreadCrumbsExistStyle(false);
				var drillDownCaptions = this.drillDownProvider.getDrillDownCaptions();
				if (drillDownCaptions.length > 0 || this.get("BreadCrumbs").getCount() > 0) {
					var breadCrumbs = new BPMSoft.Collection();
					BPMSoft.each(drillDownCaptions, function(item, index) {
						var columnCaption = item.caption + ":";
						var columnCaptionViewModel = this.getItemViewModel(columnCaption);
						breadCrumbs.add(columnCaptionViewModel);
						var separator = ",";
						if (drillDownCaptions.length === index + 1) {
							separator = "";
						}
						var columnValue = item.value + separator;
						var columnValueViewModel = this.getItemViewModel(columnValue);
						breadCrumbs.add(columnValueViewModel);
					}, this);
					var breadCrumbsParameter = this.get("BreadCrumbs");
					breadCrumbsParameter.clear();
					breadCrumbsParameter.loadAll(breadCrumbs);
					this._updateBreadCrumbsExistStyle(breadCrumbs.getCount() > 0);
				}
			},

			/**
			 * Returns the view model of the navigation chain element.
			 * @protected
			 * @virtual
			 * @param {String} caption Caption of navigation chain element.
			 * @return {BPMSoft.BaseViewModel} View model of the navigation chain element.
			 */
			getItemViewModel: function(caption) {
				var itemViewModel = this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						id: BPMSoft.generateGUID(),
						caption: caption
					}
				});
				itemViewModel.sandbox = this.sandbox;
				itemViewModel.BPMSoft = BPMSoft;
				itemViewModel.parrentViewModel = this;
				return itemViewModel;
			},

			/**
			 * Returns X-axis caption.
			 * @protected
			 * @virtual
			 * @return {String} X-axis caption.
			 */
			getXAxisCaption: function() {
				return this.get("XAxisDefaultCaption") || this.get("XAxisCaption") || "";
			},

			/**
			 * Returns Y-axis caption.
			 * @protected
			 * @virtual
			 * @return {String} Y-axis caption.
			 */
			getYAxisCaption: function() {
				return this.get("YAxisDefaultCaption") || this.get("YAxisCaption") || "";
			},

			/**
			 * Checks whether input display mode equal display mode of chart.
			 * @param {BPMSoft.DashboardEnums.ChartDisplayMode} value Display mode.
			 * @returns {boolean} Return true if equal, otherwise - false.
			 */
			isChartDisplayMode: function(value) {
				return value === BPMSoft.DashboardEnums.ChartDisplayMode.CHART;
			},

			/**
			 * Checks whether input display mode equal display mode of grid.
			 * @param {BPMSoft.DashboardEnums.ChartDisplayMode} value Display mode.
			 * @returns {boolean} Return true if equal, otherwise - false.
			 */
			isGridDisplayMode: function(value) {
				return value === BPMSoft.DashboardEnums.ChartDisplayMode.GRID;
			},

			/**
			 * Returns export to csv menu item visible state.
			 * @param {BPMSoft.DashboardEnums.ChartDisplayMode} value Display mode.
			 * @returns {Boolean} Export to csv menu item visible state.
			 */
			isExportToCsvVisible: function(value) {
				return this.isGridDisplayMode(value) && BPMSoft.Features.getIsEnabled("ExportToCSV");
			},

			/**
			 * Returns export to excel menu item visible state.
			 * @param {BPMSoft.DashboardEnums.ChartDisplayMode} value Display mode.
			 * @returns {Boolean} Export to csv menu item visible state.
			 */
			isExportToExcelVisible: function(value) {
				return this.isGridDisplayMode(value);
			},

			/**
			 * Returns grid settings button visible.
			 * @param {BPMSoft.DashboardEnums.ChartDisplayMode} value Display mode.
			 * @returns {boolean}
			 */
			getOpenGridSettingsVisible: function(value) {
				return this.isGridDisplayMode(value);
			},

			/**
			 * Loads data into grid with pageble options.
			 * @protected
			 */
			loadMore: function() {
				this.loadGridData();
			},

			/**
			 * Returns grid data collection.
			 * @return {Object}
			 */
			getGridData: function() {
				return this.get("GridData");
			},

			/**
			 * Returns profile key in actual way.
			 * @return {String}
			 */
			getProfileKey: function() {
				return this.drillDownProvider.sandbox.id;
			},

			/**
			 * Returns profile key in obsolete way.
			 * @return {String}
			 */
			getProfileKeyByEntitySchemaName: function() {
				return "Chart_" + this.drillDownProvider.getEntitySchemaName();
			},

			/**
			 * Performs data for chart.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback method.
			 * @param {BPMSoft.BaseModel} scope Callback method context.
			 */
			getChartSeriesData: function(callback, scope) {
				if (!this.drillDownProvider) {
					if (callback) {
						callback.call(scope);
					}
					return;
				}
				this.set("DataIsLoading", true);
				this.drillDownProvider.getChartSeriesData(function(seriesData, yAxis) {
					/*
					// TODO: multiple series
					if (this.get("IsPercentageMode")) {
						seriesData = this.parseToPercentage(seriesData);
					}
					*/
					this.set("yAxis", yAxis);
					this.set("SeriesData", seriesData);
					this.checkQueryDataLimit(seriesData);
					this.set("DataIsLoading", false);
					if (callback) {
						callback.call(scope);
					}
				}, this);
			},

			/**
			 * Returns limit traffic data request message.
			 * @protected
			 * @virtual
			 * @param {Object} seriesData Chart data.
			 * @return {String} Limit traffic data request message.
			 */
			getQueryDataLimitMessage: function(seriesData) {
				var seriesExcessQueryDataLimit = [];
				BPMSoft.each(seriesData, function(seriesDataItem) {
					if (seriesDataItem.excessQueryDataLimit) {
						seriesExcessQueryDataLimit.push("\"" + seriesDataItem.name + "\"");
					}
				}, this);
				var queryDataLimitMessageTpl = this.get("Resources.Strings.QueryDataLimitMessage");
				return Ext.String.format(queryDataLimitMessageTpl, seriesExcessQueryDataLimit.join(", "),
					this.drillDownProvider.queryDataLimit);
			},

			/**
			 * Checks for exceeding limit of chart data.
			 * @protected
			 * @virtual
			 * @param {Object} seriesData Chart data.
			 */
			checkQueryDataLimit: function(seriesData) {
				this.set("excessQueryDataLimit", false);
				if (this.drillDownProvider.checkQueryDataLimit()) {
					BPMSoft.each(seriesData, function(seriesDataItem) {
						if (seriesDataItem.excessQueryDataLimit) {
							this.set("excessQueryDataLimit", true);
							return false;
						}
					}, this);
				}
			},

			/**
			 * Returns menu caption for selected drilldown item.
			 * @protected
			 * @virtual
			 * param {Object} currentPoint Selected item.
			 * @returns {String} Menu caption for selected drilldown item.
			 */
			getDrillDownMenuCaption: function(currentPoint) {
				var drillDownCaption = this.get("Resources.Strings.DrillDownCaption");
				return Ext.String.format("{0} '{1}'", drillDownCaption, (currentPoint && currentPoint.name));
			},

			/**
			 * @private
			 */
			_getExcludedEntitySchemaNames: function() {
				return ["Dashboard", "OperatorSingleWindow"];
			},

			/**
			 * @private
			 */
			_getEntitySchemaNameByApplicationStructureItemId: function(config, callback, scope) {
				const id = config.applicationStructureItemId.toLowerCase();
				const modules = Ext.Object.getValues(BPMSoft.configuration.ModuleStructure);
				const module = modules.find(function(item) {
					return (item.moduleId && item.moduleId.toLowerCase()) === id;
				}, this);
				if (module) {
					callback.call(scope, module.entitySchemaName);
				} else {
					BPMSoft.DetailManager.initialize(function() {
						const detailManagerItems = BPMSoft.DetailManager.getItems();
						const detailManagerItem = detailManagerItems.firstOrDefault(function(item) {
							return item.getId().toLowerCase() === id;
						}, this);
						if (detailManagerItem) {
							callback.call(scope, detailManagerItem.getEntitySchemaName());
						} else {
							callback.call(scope, null);
						}
					}, this);
				}
			},

			/**
			 * @private
			 */
			_requireSectionEntitySchema: function(callback, scope) {
				const id = this.get("sectionId");
				if (id) {
					this._getEntitySchemaNameByApplicationStructureItemId({applicationStructureItemId: id}, function(entitySchemaName) {
						const excludedEntitySchemaNames = this._getExcludedEntitySchemaNames();
						if (entitySchemaName && !BPMSoft.contains(excludedEntitySchemaNames, entitySchemaName)) {
							this.set("sectionEntitySchemaName", entitySchemaName);
							BPMSoft.require([entitySchemaName], function(entitySchema) {
								BPMSoft[entitySchemaName] = entitySchema;
								callback.call(scope);
							}, this);
						} else {
							callback.call(scope);
						}
					}, this);
				} else {
					callback.call(scope);
				}
			},

			/**
			 * Initializes values of model.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback method.
			 * @param {Object} scope Callback method context.
			 */
			init: function(callback, scope) {
				this.initParameters();
				this.initBreadCrumbs();
				this.subscribeMessages();
				this.set("displayMode", BPMSoft.DashboardEnums.ChartDisplayMode.CHART);
				this.set("excessQueryDataLimit", false);
				this.set("GridSettingsChanged", true);
				this.initGridData();
				this.mixins.GridUtilities.init.call(this);
				BPMSoft.chain(
					function(next) {
						this._requireSectionEntitySchema(next, this);
					},
					function(next) {
						this.initDrillDownProvider(next, this);
					},
					function(next) {
						if (!this.drillDownProvider) {
							callback.call(scope);
							return;
						}
						this.initEntitySchema();
						this.initProfile(next, this);
					},
					function() {
						this.getChartSeriesData(callback, scope);
					},
					this
				);
			},

			/**
			 * Performs post profile initialization processing.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback f-n.
			 * @param {BPMSoft.BaseModel} scope Scope.
			 */
			onProfileInitialized: function(callback, scope) {
				callback.call(scope);
			},

			/**
			 * Initializes values for grid data collection.
			 * @protected
			 * @virtual
			 */
			initGridData: function() {
				var gridData = this.Ext.create("BPMSoft.BaseViewModelCollection");
				this.set("GridData", gridData);
				this.set("ActiveRow", "");
				if (Ext.isEmpty(this.get("IsPageable"))) {
					this.set("IsPageable", true);
				}
				this.set("IsClearGridData", false);
				if (!Ext.isNumber(this.get("RowCount"))) {
					this.set("RowCount", 5);
				}
			},

			/**
			 * Initializes entity schema.
			 * @protected
			 * @virtual
			 */
			initEntitySchema: function() {
				var entitySchema = this.entitySchema;
				var entitySchemaName = this.get("EntitySchemaName");
				if (entitySchema.name !== entitySchemaName) {
					this.entitySchema = this.drillDownProvider.getEntitySchemaByName(entitySchemaName);
					this.entitySchemaName = entitySchemaName;
				}
			},

			/**
			 * Returns loaded rows count.
			 * @overridden
			 * @return {Number} Loaded rows count.
			 */
			getRowCount: function() {
				return this.get("RowCount");
			},

			/**
			 * Subscribes for parent module messages.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: function() {
				var sandbox = this.sandbox;
				sandbox.subscribe("GenerateChart", function(args) {
					if (args.hasOwnProperty("schemaName")) {
						this.createChartByConfig(args);
						this.initDrillDownProvider(function() {
							if (!this.drillDownProvider) {
								return;
							}
							this.initProfile(function() {
								this.refresh();
							}, this);
						}, this);
					}
				}, this, [sandbox.id]);
			},

			/**
			 * Opens grid settings module.
			 * @protected
			 */
			openGridSettings: function() {
				const gridSettingsId = this.sandbox.id + "_CardModuleV2_GridSettingsPage";
				const entitySchemaName = this.drillDownProvider.getEntitySchemaName();
				const entitySchema = this.getGridEntitySchema();
				const profileKey = this.getProfileKey();
				const propertyName = this.getDataGridName();
				this.sandbox.subscribe("GetGridSettingsInfo", function() {
					return {
						entitySchemaName: entitySchemaName,
						entitySchema: entitySchema,
						profileKey: profileKey,
						propertyName: propertyName
					};
				}, [gridSettingsId]);
				const params = this.sandbox.publish("GetHistoryState");
				this.sandbox.publish("PushHistoryState", {hash: params.hash.historyState, silent: true});
				this.sandbox.loadModule("CardModuleV2", {
					renderTo: "centerPanel",
					id: gridSettingsId,
					keepAlive: true,
					instanceConfig: {
						schemaName: "GridSettingsPage",
						isSchemaConfigInitialized: true
					}
				});
				this.sandbox.subscribe("GridSettingsChanged", function(args) {
					const gridData = this.getGridData();
					gridData.clear();
					if (args && args.newProfileData) {
						this.setColumnsProfile(args.newProfileData, true);
					}
					this.set("GridSettingsChanged", true);
					this.initSortActionItems();
				}, this, [gridSettingsId]);
			},

			/**
			 * @private
			 */
			_requireProfile: function(profileKey, callback, scope) {
				BPMSoft.require([this.profilePrefix + profileKey], function(profile) {
					callback.call(scope, profile);
				}, this);
			},

			/**
			 * @private
			 */
			_redefineProfile: function(profileKey, profile) {
				requirejs.undef(this.profilePrefix + profileKey);
				define(this.profilePrefix + profileKey, [], function() {
					return profile;
				});
			},

			/**
			 * Performs profile initialization.
			 * param {Function} callback Callback f-n.
			 * param {BPMSoft.BaseModel} scope Callback scope.
			 */
			initProfile: function(callback, scope) {
				const profileKey = this.getProfileKey();
				this._requireProfile(profileKey, function(profile) {
					if (Object.keys(profile).length === 0) {
						const profileKeyByEntitySchemaName = this.getProfileKeyByEntitySchemaName();
						this._requireProfile(profileKeyByEntitySchemaName, function(profileByEntitySchemaName) {
							this._redefineProfile(profileKey, profileByEntitySchemaName);
							this.set("Profile", profileByEntitySchemaName);
							this.onProfileInitialized(callback, scope);
						}, this);
					} else {
						this.set("Profile", profile);
						this.onProfileInitialized(callback, scope);
					}
				}, this);
			},

			/**
			 * Generates name of current list in profile.
			 * @protected
			 * @virtual
			 * @return {string} Name of current list in profile.
			 */
			getDataGridName: function() {
				var entitySchemaName = this.drillDownProvider.getEntitySchemaName();
				var xAxisColumn = this.drillDownProvider.getXAxisColumn();
				var yAxisColumn = this.drillDownProvider.getYAxisColumn();
				var dataGridName = Ext.String.format("{0}_{1}_{2}", entitySchemaName, xAxisColumn, yAxisColumn);
				return dataGridName;
			},

			/**
			 * Returns current grid.
			 * @protected
			 * @virtual
			 * @return {Component}
			 */
			getCurrentGrid: function() {
				var gridName = "Chart_" + this.sandbox.id + "_DataGrid";
				return this.Ext.getCmp(gridName + "Grid");
			},

			/**
			 * Updates chart size.
			 * @protected
			 * @virtual
			 */
			updateChartSize: function() {
				var chartName = "Chart_" + this.sandbox.id;
				var chart = this.Ext.getCmp(chartName);
				if (chart) {
					chart.updateSize();
				}
			},

			/**
			 * Initializes items of sort action.
			 * @protected
			 * @virtual
			 */
			initSortActionItems: function() {
				var collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				var gridColumns = this.mixins.GridUtilities.getProfileColumns.call(this);
				BPMSoft.each(gridColumns, function(column, columnName) {
					collection.add(columnName, this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Caption: {bindTo: this.name + columnName + "_SortedColumnCaption"},
							Tag: columnName,
							Click: {bindTo: "sortGrid"}
						}
					}));
				}, this);
				this.updateSortColumnsCaptions(this.get("Profile"));
				var sortColumns = this.get("SortColumns");
				if (sortColumns) {
					sortColumns.clear();
					sortColumns.loadAll(collection);
				} else {
					this.set("SortColumns", collection);
				}
			},

			/**
			 * Exports object list to csv file.
			 * @param {String} [fileType] Export file type. csv or excel.
			 * @protected
			 */
			exportToFile: function(fileType) {
				if (!this.drillDownProvider) {
					return;
				}
				var esq = this.getChartDataESQ();
				this.addChartProfileColumns(esq);
				this.addChartQueryFilters(esq);
				this.initQuerySorting(esq);
				var exportConfig = {
					esq: esq
				};
				if (fileType === "excel") {
					exportConfig.downloadFileName = this.getDownloadFileName(this.$caption);
					DataUtilities.exportToExcelFile(exportConfig);
				} else {
					DataUtilities.exportToCsvFile(exportConfig);
				}
			},

			/**
			 * Checks whether the passed value is empty.
			 * @param {*} value Checked value.
			 * @return {boolean} Returns true - if value is empty, false - otherwise.
			 */
			isEmptyConverter: function(value) {
				return !value;
			},

			/**
			 * Method for subscribe by default for afterrender and afterrerender.
			 */
			loadModule: this.BPMSoft.emptyFn,

			/**
			 * Loads chart without query data limit.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback method.
			 * @param {Object} scope Callback method context.
			 */
			loadChartWithoutQueryDataLimit: function(callback, scope) {
				this.drillDownProvider.ignoreQueryDataLimit = true;
				this.refresh(function() {
					this.drillDownProvider.ignoreQueryDataLimit = false;
					callback.call(scope);
				}, this);
			},

			/**
			 * Handler for click on query data limit warning button.
			 * @protected
			 * @virtual
			 */
			onQueryDataLimitWarningButtonClick: function() {
				var seriesData = this.get("SeriesData");
				BPMSoft.utils.showMessage({
					caption: this.getQueryDataLimitMessage(seriesData),
					handler: function(code) {
						if (code === "yes") {
							this.loadChartWithoutQueryDataLimit(BPMSoft.emptyFn, this);
						}
					},
					buttons: ["yes", "no"],
					defaultButton: 0,
					scope: this
				});
			},

			/**
			 * Handler method for link click.
			 * @param {Guid} targetId Target record identifier.
			 */
			linkClicked: function(targetId) {
				var gridEntitySchemaName = this.getGridEntitySchemaName();
				var moduleStructure = this.getModuleStructure(gridEntitySchemaName);
				if (!moduleStructure) {
					return true;
				}
				MaskHelper.ShowBodyMask();
				this.openPage({
					entitySchemaName: gridEntitySchemaName,
					value: targetId
				});
				MaskHelper.HideBodyMask();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#findLookupColumnAttributeValue
			 * @overridden
			 */
			findLookupColumnAttributeValue: function(columnName, attribute, value) {
				var gridData = this.getGridData();
				var item = gridData.get(value);
				return item.get(attribute);
			},

			/**
			 * On full screen button event handler.
			 */
			onFullScreenBtnClick: function() {
				var moduleId = arguments && arguments[3];
				BPMSoft.toggleFullScreenMode(Ext.String.format("#{0}", moduleId));
			}
		});

		/**
		 * @class BPMSoft.configuration.ChartViewConfig
		 * Class of chart view config.
		 */
		Ext.define("BPMSoft.configuration.ChartViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.ChartViewConfig",

			/**
			 * Returns items of graph types menu.
			 * @private
			 * @param {Object} separatorCaption Header config.
			 * @param {Function} clickHandler Click handler.
			 * @return {Object} result Items of graph types menu.
			 */
			getChartTypeMenuItems: function(separatorCaption, clickHandler) {
				var result = [];
				var separatorConfig = {
					"className": "BPMSoft.MenuSeparator",
					"caption": separatorCaption,
					"visible": {
						"bindTo": "displayMode",
						"bindConfig": {"converter": "isChartDisplayMode"}
					}
				};
				result.push(separatorConfig);
				BPMSoft.each(chartModuleHelper.ChartSeriesKind, function(seriesKind) {
					var chartTypeItem = {
						"imageConfig": seriesKind.imageConfig,
						"caption": seriesKind.displayValue,
						"tag": seriesKind.value,
						"markerValue": seriesKind.value,
						"visible": {
							"bindTo": "displayMode",
							"bindConfig": {"converter": "isChartDisplayMode"}
						},
						"click": clickHandler
					};
					result.push(chartTypeItem);
				});
				return result;
			},

			/**
			 * Returns list of operations for insert chart type menu element in general menu of chart.
			 * @private
			 * @param {String} chartId Chart Id for which you want to make data insertion.
			 * @return {Object[]} operations List of operations for insert chart type menu element in general menu of chart.
			 */
			getChartTypesMenuConfig: function(chartId) {
				var operationTpl = {
					operation: "insert",
					name: "",
					parentName: chartId + "-settings-button",
					propertyName: "menu",
					values: {}
				};
				var operations = [];
				var chartTypeMenuItems = this.getChartTypeMenuItems(
					{"bindTo": "Resources.Strings.ChartChangeTypeCaption"},
					{"bindTo": "changeChartType"}
				);
				BPMSoft.each(chartTypeMenuItems, function(chartTypeMenuItem) {
					var insertChartTypeOperation = Ext.apply(BPMSoft.deepClone(operationTpl), {
						values: chartTypeMenuItem
					});
					insertChartTypeOperation.name = "ChartTypeMenuItem" + chartTypeMenuItem.tag || "Separator";
					operations.push(insertChartTypeOperation);
				}, this);
				return operations;
			},

			/**
			 * Applies changes to the type menu in header of chart.
			 * @private
			 * @param {String} chartId Chart Id.
			 * @param {Object[]} viewConfig Menu config.
			 * @return {Object[]} viewConfig Menu config with applied changes.
			 */
			applyChangeChartTypeMenuConfig: function(chartId, viewConfig) {
				var chartTypesMenuConfig = this.getChartTypesMenuConfig(chartId);
				viewConfig = BPMSoft.JsonApplier.applyDiff(viewConfig, chartTypesMenuConfig);
				return viewConfig;
			},

			/**
			 * Applies changes to the menu items to select drillDown.
			 * @private
			 * @param {String} chartId Chart Id.
			 * @param {Object[]} viewConfig Menu config.
			 * @return {Object[]} viewConfig Menu config with applied changes.
			 */
			applyDrillDownMenuConfig: function(chartId, viewConfig) {
				var chartTypeMenuItems = this.getChartTypeMenuItems(
					{"bindTo": "CurrentPoint", "bindConfig": {"converter": "getDrillDownMenuCaption"}},
					{"bindTo": "drillDownChart"}
				);
				var drillDownConfig = {
					"items": [{
						"caption": {"bindTo": "Resources.Strings.ShowDataCaption"},
						"markerValue": "ShowDataButton",
						"click": {"bindTo": "showDrillDownData"}
					}]
				};
				Ext.Array.insert(drillDownConfig.items, drillDownConfig.items.length, chartTypeMenuItems);
				drillDownConfig.visible = {
					"bindTo": "ShowContextMenu"
				};
				var drillDownMenuUpdateOperation = [{
					operation: "merge",
					name: chartId + "-drilldownMenu",
					values: {
						drilldownMenu: drillDownConfig
					}
				}];
				viewConfig = BPMSoft.JsonApplier.applyDiff(viewConfig, drillDownMenuUpdateOperation);
				return viewConfig;
			},

			/**
			 * Returns config of chart control.
			 * @protected
			 * @virtual
			 * @param {String} chartId Chart identifier.
			 * @return {Object} Chart control config.
			 */
			getChartControlConfig: function(chartId) {
				return {
					"name": chartId + "-drilldownMenu",
					"itemType": BPMSoft.ViewItemType.MODULE,
					"className": "BPMSoft.Chart",
					"type": {"bindTo": "SeriesKind"},
					"xAxisCaption": {"bindTo": "getXAxisCaption"},
					"yAxisCaption": {"bindTo": "getYAxisCaption"},
					"currentPoint": {"bindTo": "CurrentPoint"},
					"drilldownMenu": {},
					"styleColor": {
						"bindTo": "styleColor",
						"bindConfig": {"converter": "styleColorConverter"}
					},
					"series": {"bindTo": "SeriesData"},
					"yAxis": {"bindTo": "yAxis"},
					"categories": {"bindTo": "getCategories"},
					"visible": {
						"bindTo": "displayMode",
						"bindConfig": {"converter": "isChartDisplayMode"}
					},
					"format": {"bindTo": "format"},
					"isStackedChart": {"bindTo": "IsStackedChart"}
				};
			},

			/**
			 * Generates chart view config.
			 * @param {Object} config Chart config.
			 * @return {Object[]} Chart view config.
			 */
			generate: function(config) {
				var chartId = Ext.String.format("Chart_{0}", config.sandboxId);
				var chartWrapperId = Ext.String.format("chart-wrapper-{0}", chartId);
				var viewConfig = [{
					"id": chartWrapperId,
					"name": chartId,
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["default-chart-wrapper"],
					"items": [{
						"name": Ext.String.format("chart-header-wrapper-{0}", chartId),
						"wrapClass": ["default-widget-header", config.styleColor],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": [{
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"name": Ext.String.format("{0}-query-data-limit-button", chartId),
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"imageConfig": {"bindTo": "Resources.Images.QueryDataLimitImage"},
							"classes": {
								"wrapperClass": ["query-data-limit-button"],
								"imageClass": ["query-data-limit-button-image"]
							},
							"markerValue": "QueryDataLimitButton",
							"visible": {"bindTo": "excessQueryDataLimit"},
							"click": {"bindTo": "onQueryDataLimitWarningButtonClick"}
						}, {
							"name": Ext.String.format("caption-{0}", chartId),
							"labelConfig": {
								"classes": ["default-widget-header-label"],
								"labelClass": ""
							},
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Caption"}
						}, {
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"name": Ext.String.format("{0}-full-screen-btn", chartId),
							"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"imageConfig": {"bindTo": "Resources.Images.FullScreenImg"},
							"classes": {
								"wrapperClass": ["chart-full-screen-btn full-screen-btn"]
							},
							"click": {"bindTo": "onFullScreenBtnClick"},
							"tag": chartWrapperId
						}, {
							"name": Ext.String.format("{0}-tools", chartId),
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"wrapClass": ["highchart-tools"],
							"items": [{
								"name": chartId + "_drill-home-button",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"imageConfig": {"bindTo": "Resources.Images.DrillHome"},
								"markerValue": "DrillHomeButton",
								"click": {"bindTo": "cancelDrill"},
								"visible": false
							}, {
								"name": chartId + "_drill-up-button",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"imageConfig": {"bindTo": "Resources.Images.DrillUp"},
								"markerValue": "DrillUpButton",
								"hint": {"bindTo": "Resources.Strings.DrillUpButtonHint"},
								"click": {"bindTo": "drillUp"},
								"visible": {"bindTo": "isDrilledDown"}
							}, {
								"name": chartId + "-settings-button",
								"itemType": BPMSoft.ViewItemType.BUTTON,
								"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								"imageConfig": {"bindTo": "Resources.Images.Settings"},
								"hint": {"bindTo": "Resources.Strings.SettingsButtonHint"},
								"markerValue": "SettingsButton",
								"visible": {
									"bindTo": "ShowSettingsButton"
								},
								"menu": [{
									"name": "ViewSortMenu",
									"caption": {"bindTo": "Resources.Strings.SortMenuCaption"},
									"visible": {
										"bindTo": "displayMode",
										"bindConfig": {"converter": "isGridDisplayMode"}
									},
									"controlConfig": {
										"menu": {
											"items": {"bindTo": "SortColumns"}
										}
									}
								}, {
									"name": "exportToFile",
									"caption": {"bindTo": "Resources.Strings.ExportListToFileButtonCaption"},
									"click": {"bindTo": "exportToFile"},
									"visible": {
										"bindTo": "displayMode",
										"bindConfig": {"converter": "isExportToCsvVisible"}
									}
								}, {
									"name": "exportToExcellFile",
									"caption": {"bindTo": "Resources.Strings.ExportListToExcelFileButtonCaption"},
									"imageConfig": resources.localizableImages.ExportToExcelBtnImage,
									"click": {"bindTo": "exportToFile"},
									"tag": "excel",
									"visible": {
										"bindTo": "displayMode",
										"bindConfig": {"converter": "isExportToExcelVisible"}
									}
								}, {
									"caption": {"bindTo": "Resources.Strings.SetupGridMenuCaption"},
									"visible": {
										"bindTo": "displayMode",
										"bindConfig": {"converter": "getOpenGridSettingsVisible"}
									},
									"name": "OpenGridSettings",
									"click": {"bindTo": "openGridSettings"}
								}, {
									"name": "menuSeparator",
									"itemType": BPMSoft.ViewItemType.MENU_SEPARATOR
								}, {
									"caption": {"bindTo": "Resources.Strings.ShowDataCaption"},
									"markerValue": "ShowDataButton",
									"click": {"bindTo": "showChartData"},
									"visible": {
										"bindTo": "displayMode",
										"bindConfig": {"converter": "isChartDisplayMode"}
									}
								}, {
									"caption": {"bindTo": "Resources.Strings.ShowChartCaption"},
									"markerValue": "ShowChartButton",
									"click": {"bindTo": "drillUp"},
									"visible": {
										"bindTo": "displayMode",
										"bindConfig": {"converter": "isGridDisplayMode"}
									}
								}]
							}]
						}]
					}, {
						"className": "BPMSoft.ContainerList",
						"itemType": BPMSoft.ViewItemType.MODULE,
						"id": "breadcrumbs-module-container" + chartId,
						"idProperty": "id",
						"selectors": {wrapEl: "#breadcrumbs-module-container" + chartId},
						"classes": {
							wrapClassName: ["breadcrumbs-module-container"]
						},
						"isAsync": false,
						"collection": {
							"bindTo": "BreadCrumbs"
						},
						"visible": {
							"bindTo": "isBreadCrumbsVisible"
						},
						"defaultItemConfig": {
							"className": "BPMSoft.Container",
							id: "chart-breadcrumbs-wrapper-" + chartId,
							items: [
								{
									className: "BPMSoft.Label",
									caption: {
										bindTo: "caption"
									}
								}
							]
						}
					},
						this.getChartControlConfig(chartId),
					{
						"name": "grid-wrapper-" + chartId,
						"wrapClass": ["chart-grid-wrapper"],
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"visible": {
							"bindTo": "displayMode",
							"bindConfig": {"converter": "isGridDisplayMode"}
						},
						"items": [{
							"name": chartId + "_DataGrid",
							"type": {"bindTo": "GridType"},
							"safeBind": true,
							"itemType": BPMSoft.ViewItemType.GRID,
							"activeRow": {"bindTo": "ActiveRow"},
							"collection": {"bindTo": "GridData"},
							"isEmpty": {"bindTo": "IsGridEmpty"},
							"isLoading": {"bindTo": "IsGridLoading"},
							"multiSelect": false,
							"primaryColumnName": "Id",
							"sortColumn": {"bindTo": "sortColumn"},
							"sortColumnDirection": {"bindTo": "GridSortDirection"},
							"sortColumnIndex": {"bindTo": "SortColumnIndex"},
							"linkClick": {"bindTo": "linkClicked"},
							"tiledConfig": {
								"name": "DataGridTiledConfig",
								"grid": {
									"columns": 24,
									"rows": 1
								},
								"items": [{
									"name": chartId + "xAxisGridColumn",
									"bindTo": "xAxis",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 11
									},
									"type": BPMSoft.GridCellType.TITLE
								}, {
									"name": chartId + "yAxisGridColumn",
									"bindTo": "yAxis",
									"position": {
										"row": 1,
										"column": 13,
										"colSpan": 11
									}
								}]
							},
							"listedConfig": {
								"name": "DataGridListedConfig",
								"items": [{
									caption: "xAxis",
									"name": chartId + "CaptionGridColumn",
									"bindTo": "xAxis",
									"position": {
										"column": 1,
										"colSpan": 11
									},
									"type": BPMSoft.GridCellType.TITLE
								}, {
									caption: "yAxis",
									"name": chartId + "yAxisGridColumn",
									"bindTo": "yAxis",
									"position": {
										"column": 13,
										"colSpan": 11
									}
								}]
							},
							"linkMouseOver": {"bindTo": "linkMouseOver"}
						}, {
							"name": chartId + "_loadMore",
							"itemType": BPMSoft.ViewItemType.BUTTON,
							"caption": {"bindTo": "Resources.Strings.LoadMoreButtonCaption"},
							"click": {"bindTo": "loadMore"},
							"controlConfig": {
								"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
							},
							"classes": {"textClass": ["load-more-button-class"]},
							"visible": {"bindTo": "CanLoadMoreData"}
						}]
					},
					{
						"name": "LoadingMask" + chartId,
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"classes": {"wrapClassName": ["dashboard-loading-mask"]},
						"visible": {"bindTo": "DataIsLoading"},
						"items": [
							{
								"name": "Spinner" + chartId,
								"itemType": BPMSoft.ViewItemType.COMPONENT,
								"className": "BPMSoft.BubbleSpinner"
							}
						]
					}]
				}];
				viewConfig = this.applyChangeChartTypeMenuConfig(chartId, viewConfig);
				viewConfig = this.applyDrillDownMenuConfig(chartId, viewConfig);
				return viewConfig;
			}

		});

		/**
		 * @class BPMSoft.configuration.ChartModule
		 * Class of chart module.
		 */
		Ext.define("BPMSoft.configuration.ChartModule", {
			alternateClassName: "BPMSoft.ChartModule",
			extend: "BPMSoft.BaseWidgetModule",

			/**
			 * Class name of the Chart module view model.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.ChartViewModel",

			/**
			 * Class name of the Chart module view configuration.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.ChartViewConfig",

			/**
			 * Builds view configuration of inserted module
			 * @protected
			 * @virtual
			 * @param {Object} config Configuration object.
			 * @param {Function} callback Callback function.
			 * @param {BPMSoft.BaseModel} scope Callback scope.
			 * @return {Object[]} Configuration of inserted module.
			 */
			buildView: function(config, callback, scope) {
				var viewGenerator = this.createViewGenerator();
				var viewClass = this.Ext.create(this.viewConfigClassName);
				var schema = {
					viewConfig: viewClass.generate(config)
				};
				var viewConfig = Ext.apply({
					schema: schema
				}, config);
				viewConfig.schemaName = "";
				viewGenerator.generate(viewConfig, callback, scope);
			},

			/**
			 * Initializes module configuration.
			 * @protected
			 * @virtual
			 */
			initConfig: function() {
				var sandbox = this.sandbox;
				this.callParent(["GetChartConfig", sandbox]);
				var chartParameters = sandbox.publish("GetChartParameters", sandbox.id, [sandbox.id]);
				Ext.apply(this.moduleConfig, chartParameters);
				Ext.apply(this.moduleConfig, {
					sandboxId: sandbox.id
				});
			},

			/**
			 * Subscribes to the parent module posts.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: function() {
				this.callParent(arguments);
				const sandbox = this.sandbox;
				const sectionFiltersModuleId = sandbox.publish("GetSectionFilterModuleId");
				sandbox.subscribe("UpdateFilter", this.onUpdateFilter, this, [sectionFiltersModuleId]);
				const extendedFiltersModuleId = sandbox.publish("GetExtendedFilterModuleId");
				sandbox.subscribe("ApplyResultExtendedFilter", this.onUpdateFilter, this, [extendedFiltersModuleId]);
				sandbox.subscribe("SectionUpdateFilter", this.onUpdateFilter, this, [sectionFiltersModuleId]);
			},

			/**
			 * Handler for message UpdateFilter.
			 * @protected
			 * @virtual
			 */
			onUpdateFilter: function() {
				var moduleConfig = this.moduleConfig;
				var isSectionBindingColumn = moduleConfig.sectionBindingColumn;
				var viewModel = this.viewModel;
				if (!isSectionBindingColumn) {
					BPMSoft.each(moduleConfig.seriesConfig, function(item) {
						if (item.sectionBindingColumn) {
							isSectionBindingColumn = true;
							return false;
						}
					}, this);
				}
				if (!Ext.isEmpty(moduleConfig.sectionId) && isSectionBindingColumn && viewModel) {
					viewModel.refresh();
				}
			}
		});

		return BPMSoft.ChartModule;

	});
