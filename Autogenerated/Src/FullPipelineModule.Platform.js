define("FullPipelineModule", ["ext-base", "LabelDateEdit", "FullPipelineViewConfig",
	"DashboardFunnelEnums", "ChartModule", "ChartSchemaModule"], function(Ext) {

	Ext.define("BPMSoft.configuration.FullPipelineModule", {
		extend: "BPMSoft.ChartSchemaModule",
		alternateClassName: "BPMSoft.FullPipelineModule",

		/**
		 * @inheritDoc BPMSoft.ChartSchemaModule#schemaName
		 * @overridden
		 */
		schemaName: "FullPipelineChartSchema",

		/**
		 * Returns model messages. If messages property is null, returns empty object.
		 * @virtual
		 * @protected
		 * @return {Object} Messages columns.
		 */
		getModuleMessages: function() {
			var baseMessages = this.callParent(arguments);
			return this.Ext.apply(baseMessages, {
				/**
				 * @message GetSectionFilterModuleId
				 * For subscription on UpdateFilter
				 */
				"GetSectionFilterModuleId": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				},
				/**
				 * @message RefreshFullPipelineWidget
				 * Refresh widget on designer demand.
				 */
				"RefreshFullPipelineWidget": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			});
		}
	});

	return BPMSoft.FullPipelineModule;
});
