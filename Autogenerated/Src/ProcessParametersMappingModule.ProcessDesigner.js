/* jshint ignore:start */
/* jscs:disable */
define("ProcessParametersMappingModule", ["BaseProcessParametersEditModule"], function() {

	Ext.define("BPMSoft.configuration.ProcessParametersMappingModule", {
		alternateClassName: "BPMSoft.ProcessParametersMappingModule",
		extend: "BPMSoft.BaseProcessParametersEditModule",

		initParametersInfo: function() {
			this.parametersInfo = {};
		},

		initSchemaName: function() {
			this.schemaName = "ProcessParametersMappingPage";
		}
	});
	return BPMSoft.ProcessParametersMappingModule;
});
/* jscs:enable */
/* jshint ignore:end */
