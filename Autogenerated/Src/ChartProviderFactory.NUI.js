define("ChartProviderFactory", ["ChartjsProvider"], function() {
	Ext.define("BPMSoft.configuration.ChartProviderFactory", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.ChartProviderFactory",
		
		
		// region Methods: Private
		
		/**
		 * @private
		 * @param {String} providerName
		 * @param {Object} config
		 * @return {Object} Created provider.
		 */
		_createProvider: function(providerName, config) {
			return Ext.create(providerName, {config: config});
		},
		
		// endregion
		
		// region Methods: Protected

		/**
		 * Create chartjs provider.
		 * @param {Object} config Provider configuration.
		 * @returns {Object} chartjs provider instance.
		 */
		createChartJsProvider: function(config) {
			return this._createProvider("BPMSoft.ChartjsProvider", config);
		},
		
		// endregion
		
		// region Methods: Public
		
		/**
		 * Create chart provider by chart config.
		 * @param {Object} config
		 * @return {Object} Created provider.
		 */
		createProvider: function(config) {
			return this.createChartJsProvider(config);
		}
		
		// endregion
		
	});
	
	return {};
});
