define("MacrosModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.MacrosModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.MacrosModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "MacrosPage";
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: BPMSoft.emptyFn
	});
	return BPMSoft.MacrosModule;
});
