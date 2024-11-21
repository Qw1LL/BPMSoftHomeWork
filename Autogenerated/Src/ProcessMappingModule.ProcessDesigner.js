/**
 * Parent: BaseParametersMappingModule
 */
define("ProcessMappingModule", ["BaseParametersMappingModule"], function() {

	Ext.define("BPMSoft.configuration.ProcessMappingModule", {
		alternateClassName: "BPMSoft.ProcessMappingModule",
		extend: "BPMSoft.BaseParametersMappingModule",

		/**
		 * @inheritdoc BPMSoft.BaseParametersMappingModule#mappingPageName
		 * @overridden
		 */
		mappingPageName: "ProcessMappingPage",

		/**
		 * @inheritdoc BPMSoft.BaseParametersMappingModule#mappingSelectionPageName
		 * @overridden
		 */
		mappingSelectionPageName: "ProcessParameterSelectionPage"
	});

	return BPMSoft.ProcessMappingModule;
});
