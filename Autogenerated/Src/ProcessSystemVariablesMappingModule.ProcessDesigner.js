define("ProcessSystemVariablesMappingModule", ["BaseProcessParametersEditModule"], function() {
	/**
	 * @class BPMSoft.configuration.ProcessFunctionsMappingModule
	 */
	Ext.define("BPMSoft.configuration.ProcessSystemVariablesMappingModule", {
		alternateClassName: "BPMSoft.ProcessSystemVariablesMappingModule",
		extend: "BPMSoft.BaseProcessParametersEditModule",
		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ProcessSystemVariablesMappingPage";
		}
	});
	return BPMSoft.ProcessSystemVariablesMappingModule;
});
