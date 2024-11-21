define("AreaSplineChartJsConfigBuilder", ["SplineChartJsConfigBuilder"], function() {
	
	Ext.define("BPMSoft.configuration.AreaSplineChartJsConfigBuilder", {
		extend: "BPMSoft.SplineChartJsConfigBuilder",
		alternateClassName: "BPMSoft.AreaSplineChartJsConfigBuilder",

		// region Fields: Private

		/**
		 * @private
		 */
		_areaSplineChartDataSetOptions: {
			fill: true
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSet: function() {
			const dataSet = this.callParent(arguments);
			return this.applyOptions(dataSet, this._areaSplineChartDataSetOptions);
		}

		// endregion

	});

	return { };
});