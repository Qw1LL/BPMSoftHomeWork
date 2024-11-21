define("DcmSchemaResponse", ["ext-base", "BPMSoft", "DcmSchema"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.DcmSchemaResponse
	 * Dcm schema response class.
	 */
	Ext.define("BPMSoft.data.queries.DcmSchemaResponse", {
		extend: "BPMSoft.BaseSchemaResponse",
		alternateClassName: "BPMSoft.DcmSchemaResponse",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseSchemaResponse#schemaClassName
		 * @overridden
		 */
		schemaClassName: "BPMSoft.DcmSchema",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "DcmSchemaResponse",

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseSchemaResponse#createSchemaInstance
		 * @overridden
		 */
		createSchemaInstance: function(config) {
			return BPMSoft.SchemaDesignerUtilities.createInstanceByMetaData({
				metaData: config.metaData,
				schemaClassName: this.schemaClassName,
				resources: config.resources
			});
		}

		//endregion
	});

	return BPMSoft.data.queries.DcmSchemaResponse;
});
