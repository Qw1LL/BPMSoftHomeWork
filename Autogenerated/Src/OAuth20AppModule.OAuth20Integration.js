define("OAuth20AppModule", ["BaseSchemaModuleV2",  "css!WebServiceMethodModule", "css!OAuth20AppModule"], function() {
	/**
	 * @class BPMSoft.configuration.OAuth20AppModule
	 */
	Ext.define("BPMSoft.configuration.OAuth20AppModule", {
		alternateClassName: "BPMSoft.OAuth20AppModule",
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "OAuth20AppModalPage";
		}
	});
	return BPMSoft.OAuth20AppModule;
});
