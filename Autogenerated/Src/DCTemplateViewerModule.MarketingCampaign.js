define("DCTemplateViewerModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.DCTemplateViewerModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.DCTemplateViewerModule",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @override
		 */
		generateViewContainerId: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @override
		 */
		initSchemaName: function() {
			this.schemaName = "DCTemplateViewerSchema";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: BPMSoft.emptyFn
	});
	return BPMSoft.DCTemplateViewerModule;
});