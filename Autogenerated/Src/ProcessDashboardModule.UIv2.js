define("ProcessDashboardModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.ProcessDashboardModule
	 */
	Ext.define("BPMSoft.configuration.ProcessDashboardModule", {
		alternateClassName: "BPMSoft.ProcessDashboardModule",
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @overridden
		 */
		useHistoryState: false,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		* @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		* @overridden
		*/
		initSchemaName: function() {
			this.schemaName = "ProcessDashboardSchema";
		}
	});
	return BPMSoft.ProcessDashboardModule;
});
