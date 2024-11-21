define("CampaignValidateRequest", ["CampaignValidationResponse"], function() {
	/**
	 * @class BPMSoft.data.queries.CampaignValidateRequest
	 * Campaign schema validate request class.
	 */
	Ext.define("BPMSoft.data.queries.CampaignValidateRequest", {
		extend: "BPMSoft.BaseSchemaUpdateRequest",
		alternateClassName: "BPMSoft.CampaignValidateRequest",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "CampaignValidateRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "BPMSoft.CampaignValidationResponse",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaUpdateRequest#getData
		 * @overridden
		 */
		getData: function() {
			var schema = this.schema;
			var resources = {};
			schema.getLocalizableValues(resources);
			return {
				metaData: schema.serialize(),
				resources: resources,
				uId: schema.uId,
				packageUId: schema.packageUId,
				requestTimeout: this.requestTimeout,
				changedItems: schema.changedItems
			};
		}
	});
	return BPMSoft.CampaignValidateRequest;
});
