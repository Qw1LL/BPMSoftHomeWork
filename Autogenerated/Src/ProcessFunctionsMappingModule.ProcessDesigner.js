define("ProcessFunctionsMappingModule", ["BaseProcessParametersEditModule"], function() {
	/**
	 * @class BPMSoft.configuration.ProcessFunctionsMappingModule
	 */
	Ext.define("BPMSoft.configuration.ProcessFunctionsMappingModule", {
		alternateClassName: "BPMSoft.ProcessFunctionsMappingModule",
		extend: "BPMSoft.BaseProcessParametersEditModule",
		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ProcessFunctionsMappingPage";
		}
	});
	return BPMSoft.ProcessFunctionsMappingModule;
});
