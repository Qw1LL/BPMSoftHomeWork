define("DcmExecutionDataRequest", ["ProcessExecutionDataRequest"], function() {
	/**
	 * @class BPMSoft.data.queries.DcmExecutionDataRequest
	 * Dcm execution data batch request class.
	 */
	Ext.define("BPMSoft.data.queries.DcmExecutionDataRequest", {
		extend: "BPMSoft.ProcessExecutionDataRequest",
		alternateClassName: "BPMSoft.DcmExecutionDataRequest",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ProcessExecutionDataRequest#contractName
		 * @overridden
		 */
		contractName: "GetDcmExecutionData"

		// endregion

	});

	return BPMSoft.data.queries.DcmExecutionDataRequest;
});
