define("DcmSchemaRemoveRequest", ["ext-base", "BPMSoft", "DcmSchemaRequest"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.DcmSchemaRemoveRequest
	 * Dcm schema remove request class.
	 */
	Ext.define("BPMSoft.data.queries.DcmSchemaRemoveRequest", {
		extend: "BPMSoft.DcmSchemaRequest",
		alternateClassName: "BPMSoft.DcmSchemaRemoveRequest",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "RemoveDcmSchemaRequest"

		//endregion
	});

	return BPMSoft.data.queries.DcmSchemaRemoveRequest;
});
