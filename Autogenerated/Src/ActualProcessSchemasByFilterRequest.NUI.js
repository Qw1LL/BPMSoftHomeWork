define("ActualProcessSchemasByFilterRequest", [
	"ext-base",
	"BPMSoft",
	"ConfigurationServiceRequest",
	"ActualProcessSchemasByFilterResponse"
],
function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.ActualProcessSchemasByFilterRequest
	 * Actual schemas list by specified filters request class.
	 */
	Ext.define("BPMSoft.data.queries.ActualProcessSchemasByFilterRequest", {
		extend: "BPMSoft.ConfigurationServiceRequest",
		alternateClassName: "BPMSoft.ActualProcessSchemasByFilterRequest",

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
		serviceName: "ProcessSchemaManagerService.svc",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "GetActualProcessSchemasByFilter",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "BPMSoft.ActualProcessSchemasByFilterResponse",

		/**
		 * Process package unique identifier.
		 * @type {GUID}
		 */
		packageUId: null,

		/**
		 * Select enabled process schemas only.
		 * @type {Boolean}
		 */
		enabledOnly: false,

		/**
		 * Excluded from result process schema identifiers list.
		 * @type {String[]}
		 */
		excludedSchemas: [],

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseRequest#getSerializableObject
		 * @protected
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			serializableObject.packageUId = this.packageUId;
			serializableObject.enabledOnly = this.enabledOnly;
			serializableObject.excludedSchemas = this.excludedSchemas;
		}

		// endregion
	});

	return BPMSoft.data.queries.ActualProcessSchemasByFilterRequest;
});
