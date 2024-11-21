define("ActualProcessSchemasByFilterResponse", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.data.queries.ActualProcessSchemasByFilterResponse
	 * Process execution data response class.
	 */
	Ext.define("BPMSoft.data.queries.ActualProcessSchemasByFilterResponse", {
		extend: "BPMSoft.BaseResponse",
		alternateClassName: "BPMSoft.ActualProcessSchemasByFilterResponse",

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseResponse#getResponsePropertyNames.
		 * @overridden
		 */
		getResponsePropertyNames: function() {
			var parentResponsePropertyName = this.callParent(arguments);
			Ext.Array.push(parentResponsePropertyName, ["schemas"]);
			return parentResponsePropertyName;
		}

		//endregion
	});

	return BPMSoft.data.queries.ActualProcessSchemasByFilterResponse;
});
