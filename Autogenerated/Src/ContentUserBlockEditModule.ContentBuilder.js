/**
 * Module to load ContentUserBlockEditPage.
 */
define("ContentUserBlockEditModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.ContentUserBlockEditModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.ContentUserBlockEditModule",

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
			this.schemaName = "ContentUserBlockEditPage";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: BPMSoft.emptyFn
	});
	return BPMSoft.ContentUserBlockEditModule;
});
