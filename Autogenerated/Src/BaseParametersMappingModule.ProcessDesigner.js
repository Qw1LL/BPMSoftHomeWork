/**
 * Parent: BaseProcessParametersEditModule
 */
define("BaseParametersMappingModule", ["BaseProcessParametersEditModule", "css!ProcessMappingModalBoxStyles"],
		function() {

	Ext.define("BPMSoft.configuration.BaseParametersMappingModule", {
		alternateClassName: "BPMSoft.BaseParametersMappingModule",
		extend: "BPMSoft.BaseProcessParametersEditModule",

		/**
		 * Name of parameter mapping page.
		 * @abstract
		 * @type {String}
		 */
		mappingPageName: Ext.emptyString,

		/**
		 * Name of parameter selection page.
		 * @abstract
		 * @type {String}
		 */
		mappingSelectionPageName: Ext.emptyString,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			if (this.parameters.viewModelConfig.MappingType === BPMSoft.MappingEnums.MappingType.ALL) {
				this.schemaName = this.mappingPageName;
			} else {
				this.schemaName = this.mappingSelectionPageName;
			}
		}
	});

	return BPMSoft.BaseParametersMappingModule;
});
