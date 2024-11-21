define("SoapServiceMethodModule", ["BaseSchemaModuleV2",  "css!WebServiceMethodModule"], function() {
	/**
	 * @class BPMSoft.configuration.WebServiceMethodModule
	 */
	Ext.define("BPMSoft.configuration.SoapServiceMethodModule", {
		alternateClassName: "BPMSoft.SoapServiceMethodModule",
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
			this.schemaName = "SoapWebServiceMethodPage";
		}
	});
	return BPMSoft.SoapServiceMethodModule;
});
