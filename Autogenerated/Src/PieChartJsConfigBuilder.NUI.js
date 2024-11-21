define("PieChartJsConfigBuilder", ["AbstractChartJsConfigBuilder"], function() {
	
	Ext.define("BPMSoft.configuration.PieChartJsConfigBuilder", {
		extend: "BPMSoft.AbstractChartJsConfigBuilder",
		alternateClassName: "BPMSoft.PieChartJsConfigBuilder",

		// region Fields: Private

		/**
		 * @private
		 */
		_pieChartPlugins: {
			datalabels: {
				display: true,
				labels: {
					outer: {
						align: "end",
						anchor: "end",
						display: "auto",
						formatter: BPMSoft.emptyFn
					},
					inner: {
						align: "center",
						anchor: "center",
						display: "auto",
						color: "#ffffff",
						listeners: {},
						textAlign: "center",
						formatter: BPMSoft.emptyFn
					}
				}
			}
		},

		/**
		 * @private
		 */
		_pieChartDataSetOptions: {
			borderWidth: 1
		},

		/**
		 * @private
		 */
		_pieChartScalesOptions: {
			xAxes: [{
				display: false,
				offset: true
			}],
			yAxes: [{
				display: false,
				offset: true
			}]
		},

		/**
		 * @private
		 */
		_pieChartLayoutOptions: {
			padding: {
				top: 20,
				bottom: 20,
				left: 20,
				right: 20
			}
		},
		
		/**
		 * @private
		 */
		_minPadding: 20,
		
		/**
		 * @private
		 */
		_calculatedPercentPadding: {
			topBottom: 7,
			leftRight: 15
		},

		// endregion

		// region Properties: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		chartJsType: "pie",

		// endregion

		// region Methods: Private
		
		_getCalculatedLayoutOptions: function() {
			const pieDefaultLayoutOptions = BPMSoft.deepClone(this._pieChartLayoutOptions);
			const calculatedPadding = this._calculateLayoutPadding();
			this.applyOptions(pieDefaultLayoutOptions.padding, calculatedPadding);
			return pieDefaultLayoutOptions;
		},
		
		_calculateLayoutPadding: function() {
			const wrapElSize = this._getChartWrapperSize();
			const calculatedHorizontalPadding = wrapElSize.width * (this._calculatedPercentPadding.leftRight / 100);
			const calculatedVerticalPadding = wrapElSize.height * (this._calculatedPercentPadding.topBottom / 100);
			const calculatedPadding = {};
			if (calculatedHorizontalPadding > this._minPadding) {
				Ext.apply(calculatedPadding, { left: calculatedHorizontalPadding, right: calculatedHorizontalPadding });
			}
			if (calculatedVerticalPadding > this._minPadding) {
				Ext.apply(calculatedPadding, { top: calculatedVerticalPadding, bottom: calculatedVerticalPadding });
			}
			return calculatedPadding;
		},
		
		_getChartWrapperSize: function () {
			const renderTo = this.getHighchartsConfigValueOrDefault("chart.renderTo", "");
			const wrapEl = Ext.get(renderTo);
			return {
				height: wrapEl && wrapEl.getHeight() || 0,
				width: wrapEl && wrapEl.getWidth() || 0
			};
		},
		
		// endregion
		
		// region Methods: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		getPlugins: function() {
			const plugins = this.callParent(arguments);
			this._pieChartPlugins.datalabels.labels.outer.formatter =
					this.getOuterLabelValue.bind(this);
			this._pieChartPlugins.datalabels.labels.inner.formatter =
					this.getInnerLabelValue.bind(this);
			this._pieChartPlugins.datalabels.labels.outer.color = 
					this.dataLabelColorHandler;
			return this.applyOptions(plugins, this._pieChartPlugins);
		},
		
		/**
		 * Returns outer data label value.
		 * @param {Number} value Pie data value.
		 * @param {Object} ctx Data label context.
		 * @returns {String|String[]} Data label value.
		 */
		getOuterLabelValue: function(value, ctx) {
			const labelValue = ctx.dataset.dataItems[ctx.dataIndex].name;
			return this.getLabel(labelValue);
		},
		
		/**
		 * Returns inner data label value.
		 * @param {Number} value Pie data value.
		 * @param {Object} ctx Data label context.
		 * @returns {String|String[]} Data label value.
		 */
		getInnerLabelValue: function(value, ctx) {
			const format = ctx.dataset.format;
			const formattedValue = this.formatDataLabel(value, format);
			return Ext.String.format("{0}\n({1}%)",
					formattedValue, Math.round(value / Ext.Array.sum(ctx.dataset.data) * 100));
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getScalesOptions: function() {
			return BPMSoft.deepClone(this._pieChartScalesOptions);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getLegendOptions: function() {
			return {
				display: false
			};
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getLayoutOptions: function() {
			const layoutOptions = this.callParent(arguments);
			const calculatedLayoutOptions = this._getCalculatedLayoutOptions();
			return this.applyOptions(layoutOptions, calculatedLayoutOptions);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getTooltipsOptions: function() {
			const tooltipOptions = this.callParent(arguments);
			const pieTooltipOptions = {
				callbacks: {
					label: this.getTooltipLabel.bind(this),
				},
			};
			return this.applyOptions(tooltipOptions, pieTooltipOptions);
		},
		
		/**
		 * Returns pie chart tooltip label.
		 * @param {Object} tooltipItem Chartjs tooltip item.
		 * @param {Object} data Chart data.
		 * @returns {String} Tooltip label.
		 */
		getTooltipLabel: function (tooltipItem, data) {
			const activeDataSet = data.datasets[tooltipItem.datasetIndex];
			const dataSetData = activeDataSet.data;
			const activeData = dataSetData[tooltipItem.index];
			const formattedValue = this.formatDataLabel(activeData, activeDataSet.format);
			return Ext.String.format("{0}: {1}{2}",
					activeDataSet.label, formattedValue,
					this.getTooltipPercentLabel(dataSetData, activeData));
		},
		
		/**
		 * Returns percent value label.
		 * @param {Number[]} datasetData Active dataset data array.
		 * @param {Number} activeData Active item value.
		 * @returns {String} Percent value label.
		 */
		getTooltipPercentLabel: function(datasetData, activeData) {
			const percentValue = activeData / datasetData.reduce(function(total, sum) {
				return total + sum;
			}) * 100;
			return Ext.String.format(" ({0}%)", Math.round(percentValue));
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSet: function() {
			const dataSet = this.callParent(arguments);
			return this.applyOptions(dataSet, this._pieChartDataSetOptions);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSetData: function(highchartsSerieData) {
			return highchartsSerieData.map(function(x) {
				return Ext.isObject(x) ? x.y : x || 0;
			});
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSetColor: function(highchartsSerie) {
			const highchartsColors = this.getHighchartsConfigValueOrDefault("colors", null);
			const highchartsSerieData = highchartsSerie.data;
			const highchartsSerieLength = highchartsSerieData.length;
			let colors = !Ext.isEmpty(highchartsColors)
					? BPMSoft.deepClone(highchartsColors)
					: highchartsSerieData.map(function(seria) {
						return seria && seria.color;
					});
			while (colors.length < highchartsSerieLength) {
				colors = colors.concat(colors);
			}
			return colors.slice(0, highchartsSerieLength);
		},

		// endregion

	});

	return { };
});