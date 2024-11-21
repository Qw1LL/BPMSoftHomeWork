define("ProcessElementParametersMappingModule", ["BaseProcessParametersEditModule"], function() {

	Ext.define("BPMSoft.configuration.ProcessElementParametersMappingModule", {
		alternateClassName: "BPMSoft.ProcessElementParametersMappingModule",
		extend: "BPMSoft.BaseProcessParametersEditModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ProcessElementParametersMappingPage";
		},

		/**
		 * @inheritdoc BPMSoft.BaseProcessParametersEditModule#initParametersInfo
		 * @overridden
		 */
		initParametersInfo: function() {
			this.parametersInfo = {};
		}
	});
	return BPMSoft.ProcessElementParametersMappingModule;
});
