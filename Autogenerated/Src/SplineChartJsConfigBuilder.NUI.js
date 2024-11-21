define("SplineChartJsConfigBuilder", ["LineChartJsConfigBuilder"], function() {
	
	Ext.define("BPMSoft.configuration.SplineChartJsConfigBuilder", {
		extend: "BPMSoft.LineChartJsConfigBuilder",
		alternateClassName: "BPMSoft.SplineChartJsConfigBuilder",

		// region Fields: Private

		/**
		 * @private
		 */
		_splineChartTooltipOptions: {
			intersect: false
		},

		/**
		 * @private
		 */
		_splineChartDataSetOptions: {
			pointRadius: 0,
			pointHitRadius: 5,
			lineTension: 0.4,
			cubicInterpolationMode: "monotone"
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		getTooltipsOptions: function() {
			const tooltipOptions = this.callParent(arguments);
			return this.applyOptions(tooltipOptions, this._splineChartTooltipOptions);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSet: function() {
			const dataSet = this.callParent(arguments);
			return this.applyOptions(dataSet, this._splineChartDataSetOptions);
		},

		// endregion

	});
	
	return { };
});