define("RelationshipChartGenerator", ["ViewGeneratorV2", "RelationshipChart"], function() {
	/**
	 * @class BPMSoft.configuration.RelationshipChartGenerator
	 * Class.
	 */
	Ext.define("BPMSoft.configuration.RelationshipChartGenerator", {
		alternateClassName: "BPMSoft.RelationshipChartGenerator",
		extend: "BPMSoft.ViewGenerator",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * Generates config for RelationshipChart control.
		 * @param {Object} config Configuration for generator.
		 * @param {Object} config.items Charts nodes.
		 * @param {Object} config.nodeRemove Node Removal Handler.
		 * @return {Object} Configuration.
		 */
		generateChart: function(config) {
			var chartConfig = {
				className: config.className || "BPMSoft.RelationshipChart",
				items: config.items
			};
			var serviceProperties = ["generator"];
			var configWithoutServiceProperties = this.getConfigWithoutServiceProperties(config, serviceProperties);
			Ext.apply(chartConfig, configWithoutServiceProperties);
			return chartConfig;
		}
	});

	return Ext.create("BPMSoft.RelationshipChartGenerator");
});
