define("ProcessDateTimeMappingModule", ["BaseProcessParametersEditModule"], function() {
	/**
	 * @class BPMSoft.configuration.ProcessFunctionsMappingModule
	 */
	Ext.define("BPMSoft.configuration.ProcessDateTimeMappingModule", {
		alternateClassName: "BPMSoft.ProcessDateTimeMappingModule",
		extend: "BPMSoft.BaseProcessParametersEditModule",
		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ProcessDateTimeMappingPage";
		}
	});
	return BPMSoft.ProcessDateTimeMappingModule;
});
