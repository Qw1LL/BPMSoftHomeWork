define("OpportunityFunnelModuleV2", ["ext-base", "LabelDateEdit", "OpportunityFunnelViewConfig",
		"DashboardFunnelEnums", "ChartModule", "ChartSchemaModule"], function(Ext) {
	/**
	 * @class BPMSoft.configuration.OpportunityFunnelModule
	 * ##### ###### ####### ######.
	 */
	Ext.define("BPMSoft.configuration.OpportunityFunnelModuleV2", {
		extend: "BPMSoft.ChartSchemaModule",
		alternateClassName: "BPMSoft.OpportunityFunnelModuleV2",

		/**
		 * @inheritDoc BPMSoft.ChartSchemaModule#schemaName
		 * @overridden
		 */
		schemaName: "FunnelChartSchema"
	});

	return BPMSoft.OpportunityFunnelModuleV2;
});
