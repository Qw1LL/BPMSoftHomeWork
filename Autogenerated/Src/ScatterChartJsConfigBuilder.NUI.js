define("ScatterChartJsConfigBuilder", ["LineChartJsConfigBuilder"], function() {
	
	Ext.define("BPMSoft.configuration.ScatterChartJsConfigBuilder", {
		extend: "BPMSoft.LineChartJsConfigBuilder",
		alternateClassName: "BPMSoft.ScatterChartJsConfigBuilder",

		// region Fields: Private

		/**
		 * @private
		 */
		_scatterDataSetOptions: {
			showLine: false,
		},

		// endregion

		// region Methods: Protected
		
		/**
		 * @inheritDoc
		 * @override
		 */
		getDataSet: function() {
			const dataSet = this.callParent(arguments);
			return this.applyOptions(dataSet, this._scatterDataSetOptions);
		}

		// endregion
		
	});
	
	return { };
});