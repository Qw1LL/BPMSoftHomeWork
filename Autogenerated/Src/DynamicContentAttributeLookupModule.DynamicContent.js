/**
 * Module to load DynamicContentAttributeLookupPage.
 */
define("DynamicContentAttributeLookupModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.DynamicContentAttributeLookupModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.DynamicContentAttributeLookupModule",

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
			this.schemaName = "DynamicContentAttributeLookupPage";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: BPMSoft.emptyFn
	});
	return BPMSoft.DynamicContentAttributeLookupModule;
});
