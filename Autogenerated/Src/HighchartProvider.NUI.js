define("HighchartProvider", ["HighchartsTypedConfig", "HighchartsMore", "AbstractChartProvider"],
	function(highchartsTypedConfig) {
	Ext.define("BPMSoft.configuration.HighchartProvider", {
		extend: "BPMSoft.AbstractChartProvider",
		alternateClassName: "BPMSoft.HighchartProvider",

		/**
		 * @inheritDoc
		 */
		init: function() {
			let config = this.config;
			const chartType = config.chart.type;
			const typeOptionsConfig = Ext.clone(highchartsTypedConfig[chartType]);
			this.config = config = Ext.merge(typeOptionsConfig, config);
			this.component = new Highcharts.Chart(config);
		}
	});
	return {};
});
