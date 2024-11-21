define("ProcessExecutionDataResponse", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.ProcessExecutionDataResponse
	 * Process execution data response class.
	 */
	Ext.define("BPMSoft.data.queries.ProcessExecutionDataResponse", {
		extend: "BPMSoft.BaseResponse",
		alternateClassName: "BPMSoft.ProcessExecutionDataResponse",

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseResponse#getResponsePropertyNames.
		 * @protected
		 * @overridden
		 */
		getResponsePropertyNames: function() {
			var parentResponsePropertyName = this.callParent(arguments);
			Ext.Array.push(parentResponsePropertyName, ["batch"]);
			return parentResponsePropertyName;
		}

		//endregion
	});

	return BPMSoft.data.queries.ProcessExecutionDataResponse;
});
