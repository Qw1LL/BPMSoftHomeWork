define("DateTimeMappingModule", ["BaseProcessParametersEditModule", "css!DateTimeMappingModule"], function() {
	/**
	 * @class BPMSoft.configuration.DateTimeMappingModule
	 * Class DateTimeMappingModule
	 */
	Ext.define("BPMSoft.configuration.DateTimeMappingModule", {
		alternateClassName: "BPMSoft.DateTimeMappingModule",
		extend: "BPMSoft.BaseProcessParametersEditModule",
		/**
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "DateTimeMappingPage";
		}
	});
	return BPMSoft.DateTimeMappingModule;
});
