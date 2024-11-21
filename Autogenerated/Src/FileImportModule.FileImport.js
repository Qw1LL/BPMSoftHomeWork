define("FileImportModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.FileImportModule
	 * Class FileImportModule is designed to import files.
	 */
	Ext.define("BPMSoft.configuration.FileImportModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.FileImportModule",

		//region Methods: Protected

		/**
		 * @inheritdoc
		 * @overridden
		 */
		initSchemaName: function() {
			this.callParent(arguments);
			if (this.Ext.isEmpty(this.schemaName)) {
				this.schemaName = "FileImportStartPage";
			}
		}

		//endregion

	});
	return BPMSoft.FileImportModule;
});
