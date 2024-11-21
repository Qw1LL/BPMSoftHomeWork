define("OpportunityFunnelChartJsConfigBuilder", ["FunnelChartJsConfigBuilder"], function() {

	Ext.define("BPMSoft.configuration.OpportunityFunnelChartJsConfigBuilder", {
		extend: "BPMSoft.FunnelChartJsConfigBuilder",
		alternateClassName: "BPMSoft.OpportunityFunnelChartJsConfigBuilder",
		
		// region Methods: Protected
		
		/**
		 * @inheritDoc
		 * @override
		 */
		getLabels: function() {
			return this.callParent(arguments).map(function(label) {
				return label.replace("<br/>", "\n").split("\n");
			});
		},
		
		/**
		 * @inheritDoc
		 * @override
		 */
		getLabelSuffix: function() {
			return BPMSoft.emptyString;
		},
		
		/**
		 * @inheritDoc
		 * @override
		 */
		getDataItemConfig: function(dataItem) {
			const config = this.callParent(arguments);
			Ext.apply(config, {
				countOpp: dataItem.countOpp,
				displayValue: dataItem.displayValue,
				drilldown: dataItem.drilldown,
				menuHeaderValue: dataItem.menuHeaderValue
			});
			return config;
		},
		
		// endregion
		
	});

	return { };
});
