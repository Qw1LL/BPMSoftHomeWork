define("ProcessElementStatusResponse", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.ProcessElementStatusResponse
	 * Process element running status response.
	 */
	Ext.define("BPMSoft.data.queries.ProcessElementStatusResponse", {
		extend: "BPMSoft.BaseResponse",
		alternateClassName: "BPMSoft.ProcessElementStatusResponse",

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseResponse#getResponsePropertyNames.
		 * @overridden
		 */
		getResponsePropertyNames: function() {
			var parentResponsePropertyName = this.callParent(arguments);
			Ext.Array.push(parentResponsePropertyName, ["status"]);
			return parentResponsePropertyName;
		}

		//endregion

	});

	return BPMSoft.data.queries.ProcessElementStatusResponse;
});
