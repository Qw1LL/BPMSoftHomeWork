define("LineChartJsConfigBuilder", ["AbstractChartJsConfigBuilder"], function() {
	
	Ext.define("BPMSoft.configuration.LineChartJsConfigBuilder", {
		extend: "BPMSoft.AbstractChartJsConfigBuilder",
		alternateClassName: "BPMSoft.LineChartJsConfigBuilder",

		// region Fields: Private

		/**
		 * @private
		 */
		_lineDataSetOptions: {
			fill: false,
			lineTension: 0,
			datalabels: {
				display: false
			}
		},

		// endregion

		// region Properties: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		chartJsType: "line",

		// endregion

		// region Methods: Protected

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSet: function() {
			const dataSet = this.callParent(arguments);
			const dataSetOptions = this.applyOptions(this._lineDataSetOptions, {
				borderColor: dataSet.backgroundColor
			});
			return this.applyOptions(dataSet, dataSetOptions);
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSetData: function(highchartsSerieData) {
			return highchartsSerieData.map(function(x) {
				if (Ext.isObject(x)) {
					return {x: x.x, y: x.y};
				} else if (BPMSoft.isArray(x)) {
					return {x: x[0], y: x[1]};
				} else {
					return x || 0;
				}
			});
		},

		// endregion

	});

	return { };
});