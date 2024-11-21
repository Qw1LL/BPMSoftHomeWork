define("FullPipelineChartProviderFactory", ["ChartProviderFactory", "FullPipelineChartJsConfigBuilder"], function() {
	
	Ext.define("BPMSoft.configuration.FullPipelineChartProviderFactory", {
		extend: "BPMSoft.ChartProviderFactory",
		alternateClassName: "BPMSoft.FullPipelineChartProviderFactory",
		
		// region Fields: Private
		
		/**
		 * @private
		 */
		_fullPipeLineChartConfigMapping: {
			funnel: {
				configBuilderName: "BPMSoft.FullPipelineChartJsConfigBuilder"
			}
		},
		
		// endregion
		
		// region Methods: Protected
		
		/**
		 * @inheritDoc
		 * @override
		 */
		createChartJsProvider: function(config) {
			config.chartConfigMapping = this._fullPipeLineChartConfigMapping;
			return this.callParent([config]);
		}
		
		// endregion
		
	});
	
	return {};
});
