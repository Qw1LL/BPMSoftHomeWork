define("SetEnabledDcmSchemaRequest", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.SetEnabledDcmSchemaRequest
	 * Dcm schema set enabled request class.
	 */
	Ext.define("BPMSoft.data.queries.SetEnabledDcmSchemaRequest", {
		extend: "BPMSoft.BaseSchemaRequest",
		alternateClassName: "BPMSoft.SetEnabledDcmSchemaRequest",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "SetEnabledDcmSchemaRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "BPMSoft.BaseResponse",

		/**
		 * Dcm schemas identifiers to enable
		 * @type {Array}
		 */
		items: null,

		/**
		 * Dcm schema enable flag state.
		 * @type {Boolean}
		 */
		enabled: null,

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#getSerializableObject.
		 * @protected
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			serializableObject.items = this.items;
			serializableObject.enabled = this.enabled;
		}

		//endregion
	});

	return BPMSoft.data.queries.SetEnabledDcmSchemaRequest;

});
