define("DcmSchemaInfoRequest", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.DcmSchemaInfoRequest
	 * Dcm schema info request class.
	 */
	Ext.define("BPMSoft.data.queries.DcmSchemaInfoRequest", {
		extend: "BPMSoft.BaseRequest",
		alternateClassName: "BPMSoft.DcmSchemaInfoRequest",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "DcmSchemaInfoRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "BPMSoft.BaseResponse",

		/**
		 * Schema identifier.
		 * @type {String}
		 */
		uId: null,

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.Serializable#getSerializableObject.
		 * @protected
		 * @override
		 */
		getSerializableObject: function(serializableObject) {
			serializableObject.uId = this.uId;
		}

		//endregion

	});

	return BPMSoft.data.queries.DcmSchemaInfoRequest;
});
