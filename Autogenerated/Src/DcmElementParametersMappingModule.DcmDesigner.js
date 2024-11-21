define("DcmElementParametersMappingModule", ["ProcessElementParametersMappingModule"], function() {

	Ext.define("BPMSoft.configuration.DcmElementParametersMappingModule", {
		alternateClassName: "BPMSoft.DcmElementParametersMappingModule",
		extend: "BPMSoft.ProcessElementParametersMappingModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "DcmElementParametersMappingPage";
		}

	});
	return BPMSoft.DcmElementParametersMappingModule;
});
