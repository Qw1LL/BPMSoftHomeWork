define("CampaignValidationResponse", [], function() {
	/**
	 * @class BPMSoft.data.queries.CampaignValidationResponse
	 * Campaign validation response class.
	 */
	Ext.define("BPMSoft.data.queries.CampaignValidationResponse", {
		extend: "BPMSoft.BaseResponse",
		alternateClassName: "BPMSoft.CampaignValidationResponse",
		
		/**
		 * @inheritdoc BPMSoft.BaseResponse#getResponsePropertyNames.
		 * @protected
		 * @override
		 */
		getResponsePropertyNames: function() {
			var parentResponsePropertyName = this.callParent(arguments);
			parentResponsePropertyName.push("warningInfo");
			parentResponsePropertyName.push("isValid");
			return parentResponsePropertyName;
		}

	});
	return BPMSoft.data.queries.CampaignValidationResponse;
});
