define("AbstractChartJsConfigBuilder", ["ChartJsCustomTooltip"], function() {
	/**
	 * @class BPMSoft.AbstractChartJsConfigBuilder
	 */
	Ext.define("BPMSoft.configuration.AbstractChartJsConfigBuilder", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.AbstractChartJsConfigBuilder",

		// region Properties: Protected

		/**
		 * The maximum length of line in a label.
		 * @protected
		 * @type {Number}
		 */
		maxLabelLineLength: 10,

		/**
		 * The maximum number of lines in a label.
		 * @protected
		 * @type {Number}
		 */
		maxLabelLinesCount: 2,

		/**
		 * The ChartJs type of chart.
		 * @protected
		 * @type {String}
		 */
		chartJsType: null,

		/**
		 * The ChartJs options of chart.
		 * @protected
		 * @type {Object}
		 */
		chartJsOptions: null,

		/**
		 * The Highcharts configuration object.
		 * @protected
		 * @type {Object}
		 */
		highchartsConfig: null,

		// endregion

		// region Properties: Private

		/**
		 * The series index.
		 * @private
		 * @type {Number}
		 */
		_seriesIndex: 0,

		// endregion

		// region Constructors: Public

		/**
		 * Creates object instance.
		 * @param {Object} config Instance configuration object.
		 * @param {Object} config.highchartsConfig Highcharts configuration object.
		 */
		constructor: function(config) {
			this.callParent(arguments);
			this.initDefaultOption();
			this.init(this.chartJsOptions);
		},

		// endregion

		// region Methods: Private

		/**
		 * Gets highcharts label value.
		 * @param {Object} labelConfig Serie or serie data object.
		 * @returns {String} Highcharts label value.
		 * @private
		 */
		_getHighchartsLabelValue: function(labelConfig) {
			return labelConfig && labelConfig.name || "";
		},

		/**
		 * Gets the values of highcharts labels.
		 * @returns {String[]} Highcharts labels array.
		 */
		_getHighchartsLabels: function() {
			let categories = null;
			const xAxisDefault = [{ categories: categories }];
			const xAxis = this.getHighchartsConfigValueOrDefault("xAxis", xAxisDefault);
			if (Ext.isObject(xAxis)) {
				categories = xAxis.categories;
			}
			if (BPMSoft.isArray(xAxis)) {
				categories = xAxis[0].categories;
			}
			if (BPMSoft.isArray(categories)) {
				return categories;
			}
			const series = this.getHighchartsConfigValueOrDefault("series", []);
			const labelsData = series.length === 1 ? series[0].data : series;
			return labelsData.map(this._getHighchartsLabelValue);
		},

		/**
		 * @private
		 */
		_showDrillDown: function(activeItem, event) {
			if (activeItem.drilldown === false) {
				return;
			}
			const drillDownFunction = this.getHighchartsConfigValueOrDefault("chart.events.drilldown", BPMSoft.emptyFn);
			const args = this._getHighchartsDrillDownArgument(activeItem, event);
			drillDownFunction(args);
		},

		/**
		 * @private
		 */
		_getHighchartsDrillDownArgument: function(activeItem, event) {
			const categoryItem = Ext.create("BPMSoft.BaseViewModel", {
				rowConfig: activeItem.rowConfig,
				values: activeItem.values
			});
			Ext.apply(categoryItem, activeItem);
			return {
				point: {
					clickEvent: event,
					categoryItem: categoryItem,
					name: activeItem.name,
					menuHeaderValue: activeItem.menuHeaderValue
				}
			};
		},

		// endregion

		// region Methods: Protected

		/**
		 * Returns chart dataset data.
		 * @param {Object} highchartsSerie Highcharts serie configuration object.
		 * @returns {Object[]} Dataset data.
		 * @protected
		 */
		getDataSetData: BPMSoft.abstractFn,

		/**
		 * Initialize default options.
		 */
		initDefaultOption: function() {
			this.chartJsOptions =  {
				responsive: true,
				maintainAspectRatio: false,
				plugins: {},
				scales: {},
				tooltips: {},
				legend: {},
				layout: {},
				title: {}
			};
		},

		/**
		 * Initialize chart js options.
		 * @protected
		 */
		init: function(chartJsOptions) {
			this.applyOptions(chartJsOptions, this.getEvents());
			this.applyOptions(chartJsOptions.plugins, this.getPlugins());
			this.applyOptions(chartJsOptions.legend, this.getLegendOptions());
			this.applyOptions(chartJsOptions.scales, this.getScalesOptions());
			this.applyOptions(chartJsOptions.layout, this.getLayoutOptions());
			this.applyOptions(chartJsOptions.tooltips, this.getTooltipsOptions());
			this.applyOptions(chartJsOptions.title, this.getTitleOptions());
		},

		/**
		 * Merges options and extended options recursively without referencing them or their children.
		 * @param {Object} options The object into which all subsequent objects are merged.
		 * @param {Object} extendedOptions Any number of objects to merge into the destination.
		 * @returns {Object} The destination object with all passed objects merged in.
		 * @protected
		 */
		applyOptions: function(options, extendedOptions) {
			return Ext.merge(options || {}, extendedOptions || {});
		},

		/**
		 * Gets the chart events.
		 * @protected
		 */
		getEvents: BPMSoft.emptyFn,

		/**
		 * Gets the chart plugins.
		 * @protected
		 */
		getPlugins: function() {
			return {
				datalabels: {
					display: false,
					align: "end",
					anchor: "end",
					color: this.dataLabelColorHandler,
					offset: 2,
					padding: {
						top: 2,
						right: 2,
						bottom: 2,
						left: 2
					},
					textAlign: BPMSoft.getIsRtlMode() ? "right" : "left",
					listeners: {
						click: this.dataLabelClickHandler.bind(this),
						enter: this.dataLabelEnterHandler.bind(this),
						leave: this.dataLabelLeaveHandler.bind(this)
					},
					formatter: this.dataLabelFormatter.bind(this)
				}
			};
		},

		/**
		 * @protected
		 */
		dataLabelColorHandler: function(context) {
			return context.hovered ? "#E56229" : "#666666"
		},

		/**
		 * @protected
		 */
		dataLabelEnterHandler: function (context) {
			context.hovered = true;
			context.activeTooltipEl = context.chart.tooltip._active;
			const segment = context.chart.getDatasetMeta(context.datasetIndex)
					.data[context.dataIndex];
			this._updateActiveTooltip([segment], context);
			return true;
		},

		/**
		 * @protected
		 */
		dataLabelLeaveHandler: function (context) {
			context.hovered = false;
			if (!context.active) {
				this._updateActiveTooltip(context.activeTooltipEl, context);
			}
			return true;
		},

		/**
		 * @private
		 */
		_updateActiveTooltip: function(activeTootlipEl, context) {
			if (!Ext.isArray(activeTootlipEl)) {
				return;
			}
			context.chart.tooltip._active = activeTootlipEl;
			context.chart.tooltip.update();
			context.chart.draw();
		},

		/**
		 * Data label plugin formatter event handler.
		 * @param {Number|String} value Data label value.
		 * @param {Object} labelContext Data label plugin context.
		 * @returns {String|undefined} Data label value.
		 */
		dataLabelFormatter: function(value, labelContext) {
			const dataSet = labelContext.dataset;
			const format = dataSet.format;
			return this.formatDataLabel(value, format);
		},

		/**
		 * Format number data label.
		 * @protected
		 * @param {String|Number} value
		 * @param {Object} format
		 * @param {BPMSoft.DataValueType} format.type Data value type.
		 * @param {BPMSoft.DataValueType} format.decimalPrecision Decimal precision.
		 * @returns {String|undefined} Formatted number value or initial value.
		 */
		formatDataLabel: function(value, format) {
			if (Ext.isNumber(value)) {
				format = format || {};
				return BPMSoft.getFormattedNumberValue(value, {
					type: format.type || BPMSoft.DataValueType.INTEGER,
					decimalPrecision: format.decimalPrecision
				});
			}
			return value;
		},

		/**
		 * Returns chart legend configuration.
		 * @returns {Object} Legend configuration.
		 * @protected
		 */
		getLegendOptions: function() {
			return {
				display: true,
				labels: {
					boxWidth: 13,
					filter: this.filterLegendItemsCallback.bind(this)
				}
			};
		},

		/**
		 * Filters legend items.
		 * @param {Object} legendItem Legend item configuration.
		 * @param {Object} data Chart data object.
		 * @returns {Boolean} Legend item visibility.
		 */
		filterLegendItemsCallback: function (legendItem, data) {
			const currentDataSet = data.datasets[legendItem.datasetIndex]; 
			return Boolean(currentDataSet && currentDataSet.isLegendEnabled);
		},

		/**
		 * Returns chart scales configuration.
		 * @returns {Object} Scales configuration.
		 * @protected
		 */
		getScalesOptions: function() {
			const xAxisHighchartsConfig = this.getHighchartsConfigValueOrDefault("xAxis", []);
			const yAxisHighchartsConfig = this.getHighchartsConfigValueOrDefault("yAxis", []);
			return {
				xAxes: [this.getAxisOptions(xAxisHighchartsConfig)],
				yAxes: [this.getAxisOptions(yAxisHighchartsConfig)]
			};
		},

		/**
		 * Returns chartjs layout configuration.
		 * @returns {Object} Chartjs layout configuration.
		 * @protected
		 */
		getLayoutOptions: function() {
			return {
				padding: {
					left: this.getHighchartsConfigValueOrDefault("chart.marginLeft", 0),
					right: this.getHighchartsConfigValueOrDefault("chart.marginRight", 0),
					top: this.getHighchartsConfigValueOrDefault("chart.marginTop", 0),
					bottom: this.getHighchartsConfigValueOrDefault("chart.marginBottom", 0)
				}
			};
		},

		/**
		 * Returns chart tooltip configuration.
		 * @returns {Object} Tooltip configuration.
		 * @protected
		 */
		getTooltipsOptions: function() {
			const customTooltipFunction = this.getHighchartsConfigValueOrDefault(
				"tooltip.formatter", null);
			if (customTooltipFunction) {
				return this.getCustomTooltipOptions(customTooltipFunction);
			}
			const isTooltipEnabled = this.getHighchartsConfigValueOrDefault(
				"tooltip.enabled", true);
			return {
				enabled: isTooltipEnabled,
				callbacks: {
					title: this.getTooltipTitle.bind(this),
					label: this.getTooltipLabel.bind(this)
				}
			};
		},

		/**
		 * Gets the chart tooltip label.
		 * @param {Object} tooltipItem ChartJs tooltip item.
		 * @param {Object} data Chart data.
		 * @returns {String} Tooltip label.
		 * @protected
		 */
		getTooltipLabel: function(tooltipItem, data) {
			const dataset = data.datasets[tooltipItem.datasetIndex] || {};
			let label = dataset.label || "";
			if (label) {
				label += ": ";
			}
			const value = parseFloat(tooltipItem.value) || tooltipItem.value;
			label += this.formatDataLabel(value, dataset.format);
			return label;
		},

		/**
		 * Returns custom chartjs tooltip configuration.
		 * @param {Function} customTooltipFunction Highcharts tooltip formatter function.
		 * @returns {Object} Custom chartjs tooltip configuration.
		 */
		getCustomTooltipOptions: function(customTooltipFunction) {
			return {
				enabled: false,
				custom: function(tooltipModel) {
					if (BPMSoft.ChartJsCustomTooltip.isEventOnTooltip(this._chart, this._eventPosition)) {
						this._active = [];
						this._lastActive = [];
						return;
					}
					if (tooltipModel.opacity === 0) {
						BPMSoft.ChartJsCustomTooltip.hideTooltip();
						return;
					}
					BPMSoft.ChartJsCustomTooltip.showTooltip(tooltipModel,
						this._chart, customTooltipFunction);
				}
			};
		},

		/**
		 * Returns chart title configuration.
		 * @returns {Object} Title configuration.
		 * @protected
		 */
		getTitleOptions: function() {
			const title = this.getHighchartsConfigValueOrDefault("title.text", "");
			return {
				display: !BPMSoft.isEmpty(title),
				text: title
			};
		},

		/**
		 * Gets the chart tooltip title.
		 * @param {Object} tooltipItem ChartJs tooltip item.
		 * @param {Object} data Chart data.
		 * @returns {String} Tooltip title.
		 * @protected
		 */
		getTooltipTitle: function(tooltipItem, data) {
			const activeDataItem = this.getTooltipActiveDataItem(tooltipItem, data);
			return activeDataItem.name;
		},

		/**
		 * Get active data item by tooltip item.
		 * @param {Object|Object[]} tooltipItem Tooltip items.
		 * @param {Object} data Chart data.
		 * @returns {Object} Data item.
		 */
		getTooltipActiveDataItem: function(tooltipItem, data) {
			const tooltipModel = Ext.isArray(tooltipItem) ? tooltipItem[0] : tooltipItem;
			const activeDataSet = data.datasets[tooltipModel.datasetIndex];
			const dataSetDataItems = activeDataSet.dataItems;
			return dataSetDataItems[tooltipModel.index];
		},

		/**
		 * Returns chart axis configuration.
		 * @returns {Object} Axis configuration.
		 * @protected
		 */
		getAxisOptions: function (axisHighchartsConfig) {
			const axis = BPMSoft.isArray(axisHighchartsConfig) ? axisHighchartsConfig[0] : axisHighchartsConfig;
			const axisTitle = axis && axis.title && axis.title.text;
			return {
				ticks: {},
				scaleLabel: {
					display: !Ext.isEmpty(axisTitle),
					labelString: axisTitle
				},
				beforeBuildTicks: this.calculateMaxTick.bind(this)
			};
		},

		/**
		 * Chart js beforeBuildTicks callback function.
		 * Calculates axis max value.
		 * @param {Object} axis Chart js axis configuration.
		 * @protected
		 */
		calculateMaxTick: function(axis) {
			if (!Ext.isNumber(axis.max)) {
				return;
			}
			var maxDataValue = axis.max;
			axis.buildTicks();
			const axisStep = (axis.max - axis.min) / (axis.ticks.length - 1);
			const needIncreaseMaxTickValue = (axis.max - maxDataValue) / axisStep < 0.5;
			if (needIncreaseMaxTickValue) {
				axis.max = maxDataValue + axisStep;
			}
		},

		/**
		 * Returns chartjs labels array.
		 * @returns {String[]} Chartjs labels array.
		 * @protected
		 */
		getLabels: function() {
			const highchartsLabels = this._getHighchartsLabels();
			return highchartsLabels
				.map(function(label) {
					return this.getLabel(label);
				}.bind(this));
		},

		/**
		 * Returns chartjs data label.
		 * @param {String} label Highcharts data label.
		 * @returns {Object} Chartjs data label.
		 * @protected
		 */
		getLabel: function(label) {
			const wrapConfig = {
				maxLinesCount: this.maxLabelLinesCount,
				maxLineLength: this.maxLabelLineLength
			};
			const wordsByLines = BPMSoft.wrapTextIntoLines(label, wrapConfig);
			return wordsByLines
				.map(function(lineWords) {
					return lineWords.join(' ');
				});
		},

		/**
		 * Returns chart dataset configuration.
		 * @param {Object} highchartsSerie The Highcharts serie configuration object.
		 * @returns {Object} Dataset configuration.
		 * @protected
		 */
		getDataSet: function(highchartsSerie) {
			const highchartsSerieData = highchartsSerie.data;
			const dataItems = highchartsSerieData.map(function(dataItem) {
				return this.getDataItemConfig(dataItem);
			}.bind(this));
			const isLegendEnabledInHighcharts = this.getHighchartsConfigValueOrDefault("legend.enabled", false);
			return {
				data: this.getDataSetData(highchartsSerieData),
				dataItems: dataItems,
				label: highchartsSerie.name,
				backgroundColor: this.getDataSetColor(highchartsSerie),
				format: highchartsSerie.format,
				isLegendEnabled: Boolean(isLegendEnabledInHighcharts || highchartsSerie.isLegendEnabled)
			};
		},

		/**
		 * Returns dataset color.
		 * @param {Object} highchartsSerie Highcharts serie configuration object.
		 * @returns {String[]|String|undefined} Dataset color.
		 * @protected
		 */
		getDataSetColor: function(highchartsSerie) {
			const colors = this.getHighchartsConfigValueOrDefault("colors", null);
			const colorIndex = highchartsSerie._colorIndex;
			const color = BPMSoft.isArray(colors) && Ext.isDefined(colorIndex)
				? colors[colorIndex]
				: highchartsSerie.color;
			if (color) {
				return color;
			}
			if (BPMSoft.isArray(colors)) {
				return colors[this._seriesIndex] || colors[0];
			}
		},

		/**
		 * Returns drill down serie data item configuration.
		 * @param {Object} highchartsSerieDataItem Highcharts serie data item configuration.
		 * @returns {Object} Drill down serie data item configuration.
		 * @protected
		 */
		getDataItemConfig: function (highchartsSerieDataItem) {
			const dataItem = highchartsSerieDataItem || {};
			const categoryItem = dataItem.categoryItem || {};
			return {
				name: dataItem.name,
				values: categoryItem.values,
				xAxis: categoryItem.xAxis,
				rowConfig: categoryItem.rowConfig,
				entitySchemaName: categoryItem.entitySchemaName,
				seriesNumber: categoryItem.seriesNumber,
				seriesValue: categoryItem.seriesValue,
				serializedFilters: this.getDataItemFilters(categoryItem.serializedFilters)
			};
		},

		/**
		 * Returns serialized category item filters.
		 * @param {BPMSoft.FilterGroup} categoryItemFilters Filters collection
		 * @returns {String} Serialized data item filters.
		 * @protected
		 */
		getDataItemFilters: function(categoryItemFilters) {
			if (!categoryItemFilters) {
				return undefined;
			}
			const serializationInfo = categoryItemFilters.getDefSerializationInfo();
			serializationInfo.serializeFilterManagerInfo = true;
			return categoryItemFilters.serialize(serializationInfo);
		},

		/**
		 * Return highcharts configuration value by path or default value.
		 * @param {String} valuePath The path of the property to get splitted by ".".
		 * @param {Object} defaultValue Default value.
		 * @returns {Object} Highcharts configuration value by path or default value.
		 * @protected
		 */
		getHighchartsConfigValueOrDefault: function(valuePath, defaultValue) {
			const value = BPMSoft.findValueByPath(this.highchartsConfig, valuePath);
			return Ext.isDefined(value) && value !== null ? value : defaultValue;
		},

		/**
		 * Canvas click event handler.
		 * @param {Event} event Mouse click event.
		 * @param {Object} component Chartjs instance.
		 */
		canvasClickHandler: function(event, component) {
			const activeEl = _.first(component.getElementAtEvent(event));
			if (!activeEl) {
				return;
			}
			const activeDataset = component.data.datasets[activeEl._datasetIndex];
			const activeItem = activeDataset.dataItems[activeEl._index] || {};
			this._showDrillDown(activeItem, event);
		},

		/**
		 * Data label click event handler.
		 * @param {Object} context Data label context.
		 * @param {Object} clickEvent Data label click event.
		 * @param {Event} clickEvent.native Mouse click event.
		 */
		dataLabelClickHandler: function(context, clickEvent) {
			const activeItem = context.dataset.dataItems[context.dataIndex] || {};
			const activeValue = context.dataset.data[context.dataIndex];
			if (!activeValue) {
				return;
			}
			this._showDrillDown(activeItem, clickEvent && clickEvent.native);
		},

		/**
		 * Returns chart datasets configuration.
		 * @protected
		 * @returns {Object} Datasets configuration.
		 */
		getDataSets: function() {
			const highchartsSeries = this.getHighchartsConfigValueOrDefault("series", []);
			return highchartsSeries.map(this.getDataSet.bind(this));
		},

		// endregion

		// region Methods: Public

		/**
		 * Set series index.
		 * @param {Number} seriesIndex Index of the series.
		 * @return {BPMSoft.AbstractChartJsConfigBuilder}
		 */
		setSeriesIndex: function(seriesIndex) {
			this._seriesIndex = seriesIndex;
			return this;
		},

		/**
		 * Set series instance.
		 * @param {Object} series Series instance.
		 * @return {BPMSoft.AbstractChartJsConfigBuilder}
		 */
		setHighchartSeries: function(series) {
			this.highchartsConfig.series = [Ext.clone(series)];
			return this;
		},

		/**
		 * Generate chart js configuration.
		 * @returns {ChartJsConfig} Chart js configuration.
		 */
		build: function() {
			return {
				type: this.chartJsType,
				data: {
					labels: this.getLabels(),
					datasets: this.getDataSets()
				},
				options: BPMSoft.deepClone(this.chartJsOptions),
				drilldown: {
					canvasClickHandler: this.canvasClickHandler.bind(this)
				}
			};
		}

		// endregion

	});

	return {};
});
