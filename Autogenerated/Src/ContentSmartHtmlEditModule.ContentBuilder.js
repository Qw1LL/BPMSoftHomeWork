/**
 * Module to load ContentSmartHtmlEditPage.
 */
define("ContentSmartHtmlEditModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.ContentSmartHtmlEditModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.ContentSmartHtmlEditModule",

		sandbox: null,
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
			this.schemaName = "ContentSmartHtmlEditPage";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: BPMSoft.emptyFn
	});
	return BPMSoft.ContentSmartHtmlEditModule;
});
