define("PortalMessageModalBoxModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.PortalMessageModalBoxModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.PortalMessageModalBoxModule",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "PortalMessageModalBoxModuleSchema";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn

	});
	return BPMSoft.PortalMessageModalBoxModule;
});