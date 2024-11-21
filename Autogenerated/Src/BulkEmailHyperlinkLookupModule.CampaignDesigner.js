/**
 * Module to load BulkEmailHyperlinkLookupPage.
 */
define("BulkEmailHyperlinkLookupModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.BulkEmailHyperlinkLookupModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.BulkEmailHyperlinkLookupModule",

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
			this.schemaName = "BulkEmailHyperlinkLookupPage";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: BPMSoft.emptyFn
	});
	return BPMSoft.BulkEmailHyperlinkLookupModule;
});
