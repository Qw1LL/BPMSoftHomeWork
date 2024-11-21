define("DcmSchemaUpdateRequest", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.DcmSchemaUpdateRequest
	 * Dcm schema update request class.
	 */
	Ext.define("BPMSoft.data.queries.DcmSchemaUpdateRequest", {
		extend: "BPMSoft.BaseSchemaUpdateRequest",
		alternateClassName: "BPMSoft.DcmSchemaUpdateRequest",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "ContractDcmSchema",

		//endregion

		//region Methods: Private

		/**
		 * @inheritdoc BPMSoft.BaseSchemaUpdateRequest#getData
		 * @overridden
		 */
		getData: function() {
			var resources = {};
			var schema = this.schema;
			schema.getLocalizableValues(resources);
			return {
				metaData: schema.serialize(),
				resources: resources,
				uId: schema.uId,
				packageUId: schema.packageUId,
				requestTimeout: this.requestTimeout
			};
		}

		//endregion
	});

	return BPMSoft.data.queries.DcmSchemaUpdateRequest;
});
