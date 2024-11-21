define("ProcessExecutionDataRequest", [
	"ext-base",
	"BPMSoft",
	"ConfigurationServiceRequest",
	"ProcessExecutionDataResponse"
],
function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.ProcessExecutionDataRequest
	 * Process execution data batch request class.
	 */
	Ext.define("BPMSoft.data.queries.ProcessExecutionDataRequest", {
		extend: "BPMSoft.ConfigurationServiceRequest",
		alternateClassName: "BPMSoft.ProcessExecutionDataRequest",

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
		contractName: "GetExecutionData",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "BPMSoft.ProcessExecutionDataResponse",

		/**
		 * Process elements identifiers.
		 * @type {String[]}
		 */
		elementUIds: null,

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#getSerializableObject
		 * @protected
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			serializableObject.elementUIds = this.elementUIds;
		}

		// endregion
	});

	return BPMSoft.data.queries.ProcessExecutionDataRequest;
});
