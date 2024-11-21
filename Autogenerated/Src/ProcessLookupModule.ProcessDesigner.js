define("ProcessLookupModule", ["BaseProcessParametersEditModule", "css!ProcessLookupModuleStyles"], function() {
	/**
	 * @class BPMSoft.configuration.ProcessLookupModule
	 * Class ProcessLookupModule
	 */
	Ext.define("BPMSoft.configuration.ProcessLookupModule", {
		alternateClassName: "BPMSoft.ProcessLookupModule",
		extend: "BPMSoft.BaseProcessParametersEditModule",
		/**
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ProcessLookupPage";
		},
		/**
		 * @overridden
		 */
		initParametersInfo: function() {
			this.parametersInfo = this.sandbox.publish("GetParametersInfo", null, [this.sandbox.id]) || {};
		}
	});
	return BPMSoft.ProcessLookupModule;
});
