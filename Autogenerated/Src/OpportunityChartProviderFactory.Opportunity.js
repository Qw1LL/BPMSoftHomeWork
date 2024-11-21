define("OpportunityChartProviderFactory", ["ChartProviderFactory", "OpportunityFunnelChartJsConfigBuilder"], function() {
	
	Ext.define("BPMSoft.configuration.OpportunityChartProviderFactory", {
		extend: "BPMSoft.ChartProviderFactory",
		alternateClassName: "BPMSoft.OpportunityChartProviderFactory",
		
		// region Fields: Private
		
		/**
		 * @private
		 */
		_opportunityChartConfigMapping: {
			funnel: {
				configBuilderName: "BPMSoft.OpportunityFunnelChartJsConfigBuilder"
			}
		},
		
		// endregion
		
		// region Methods: Protected
		
		/**
		 * @inheritDoc
		 * @override
		 */
		createChartJsProvider: function(config) {
			config.chartConfigMapping = this._opportunityChartConfigMapping;
			return this.callParent([config]);
		}
		
		// endregion
		
	});
	
	return {};
});
