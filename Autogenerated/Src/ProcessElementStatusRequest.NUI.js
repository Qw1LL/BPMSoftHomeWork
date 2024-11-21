define("ProcessElementStatusRequest", [
	"ext-base",
	"BPMSoft",
	"ConfigurationServiceRequest",
	"ProcessElementStatusResponse"
],
function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.ProcessElementStatusRequest
	 * Process element running status request.
	 */
	Ext.define("BPMSoft.data.queries.ProcessElementStatusRequest", {
		extend: "BPMSoft.ConfigurationServiceRequest",
		alternateClassName: "BPMSoft.ProcessElementStatusRequest",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ConfigurationServiceRequest#serviceUrl
		 * @overridden
		 */
		serviceUrl: "../ServiceModel",

		/**
		 * @inheritdoc BPMSoft.ConfigurationServiceRequest#serviceName
		 * @overridden
		 */
		serviceName: "ProcessEngineService.svc",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "GetProcessElementStatus",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "BPMSoft.ProcessElementStatusResponse",

		/**
		 * Process element unique identifier.
		 * @type {GUID}
		 */
		processElementUId: null,

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#getSerializableObject
		 * @protected
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			serializableObject.processElementUId = this.processElementUId;
		}

		// endregion

	});

	return BPMSoft.data.queries.ProcessElementStatusRequest;
});
