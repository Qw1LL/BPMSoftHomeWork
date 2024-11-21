define("DcmSchemaRequest", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.DcmSchemaRequest
	 * Dcm schema request class.
	 */
	Ext.define("BPMSoft.data.queries.DcmSchemaRequest", {
		extend: "BPMSoft.BaseSchemaRequest",
		alternateClassName: "BPMSoft.DcmSchemaRequest",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "DcmSchemaRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "BPMSoft.DcmSchemaResponse"

		//endregion
	});

	return BPMSoft.data.queries.DcmSchemaRequest;
});
