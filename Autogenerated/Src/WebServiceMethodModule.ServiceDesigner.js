define("WebServiceMethodModule", ["BaseSchemaModuleV2",  "css!WebServiceMethodModule"], function() {
	/**
	 * @class BPMSoft.configuration.WebServiceMethodModule
	 */
	Ext.define("BPMSoft.configuration.WebServiceMethodModule", {
		alternateClassName: "BPMSoft.WebServiceMethodModule",
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
			this.schemaName = "RestWebServiceMethodPage";
		}
	});
	return BPMSoft.WebServiceMethodModule;
});
