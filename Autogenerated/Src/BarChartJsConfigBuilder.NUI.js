define("BarChartJsConfigBuilder", ["AbstractChartJsConfigBuilder"], function() {
		
	Ext.define("BPMSoft.configuration.BarChartJsConfigBuilder", {
		extend: "BPMSoft.AbstractChartJsConfigBuilder",
		alternateClassName: "BPMSoft.BarChartJsConfigBuilder",

		// region Fields: Private

		/**
		 * @private
		 */
		_isStackedBar: false,

		/**
		 * @private
		 */
		_barDataSetOptions: {
			datalabels: {
				display: true,
				offset: 0
			}
		},

		/**
		 * @private
		 */
		_stackedBarDataSetOptions: {
			stack: "stack",
			borderWidth: 1,
			borderColor: "#ffffff",
			datalabels: {
				display: true,
				offset: 0,
				align: "center",
				anchor: "center",
				color: "#ffffff"
			}
		},

		// endregion

		// region Properties: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		chartJsType: "bar",

		// endregion

		// region Methods: Private

		_getIsStackedBar: function() {
			const stackedHighChartValue = this.getHighchartsConfigValueOrDefault("plotOptions.series.stacking", false) ||
				this.getHighchartsConfigValueOrDefault("plotOptions.column.stacking", false);
			return Boolean(stackedHighChartValue);
		},

		// endregion

		// region Methods: Protected

		init: function() {
			this._isStackedBar = this._getIsStackedBar();
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSet: function() {
			const dataSet = this.callParent(arguments);
			if (this._isStackedBar) {
				return this.applyStackedBarDataSetOptions(dataSet);
			}
			return this.applyOptions(dataSet, this._barDataSetOptions);
		},

		/**
		 * Stacked bar data label plugin formatter event handler.
		 * @param {Number|String} value Data label value.
		 * @param {Object} labelContext Data label plugin context.
		 * @returns {String|undefined} Data label value.
		 */
		stackedBarDataLabelFormatter: function(value, labelContext) {
			const isStackedSerie = labelContext.dataset.stack;
			const isSerieValueEmpty = value === 0;
			if (isStackedSerie && isSerieValueEmpty) {
				return "";
			}
			return this.dataLabelFormatter(value, labelContext);
		},

		/**
		 * Applies stacked data set properties on data set configuration.
		 * @protected
		 * @param {Object} dataSet Data set configuration.
		 * @returns {Object} Stacked data set configuration.
		 */
		applyStackedBarDataSetOptions: function(dataSet) {
			const dataSetOptions = this.applyOptions(this._stackedBarDataSetOptions, {
				datalabels: {
					formatter: this.stackedBarDataLabelFormatter.bind(this)
				}
			});
			return this.applyOptions(dataSet, dataSetOptions);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getAxisOptions: function(options) {
			const axisOptions = this.callParent(arguments);
			const isDisplayLabels = Ext.isDefined(options.labels && options.labels.enabled) ? options.labels.enabled : true;
			const barAxisOptions = {
				display: isDisplayLabels,
				stacked: this._isStackedBar,
			};
			return this.applyOptions(axisOptions, barAxisOptions);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSetData: function(highchartsSerieData) {
			return highchartsSerieData.map(function(x) {
				if (Ext.isObject(x)) {
					return x.y;
				} else if (BPMSoft.isArray(x)) {
					return x[1];
				} else {
					return x || 0;
				}
			});
		},

		// endregion

	});

	return { };
});