define("WelcomeScreenModule", ["BaseSchemaModuleV2"/*"css!WelcomeScreenModule"*/],
		function() {
	Ext.define("BPMSoft.configuration.WelcomeScreenModule", {

		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.WelcomeScreenModule",

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
			this.schemaName = "WelcomeScreen";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: BPMSoft.emptyFn

	});
	return BPMSoft.WelcomeScreenModule;
});
