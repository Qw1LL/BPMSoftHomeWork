define("CampaignSchemaUpdateRequest", [], function() {
	/**
	 * @class BPMSoft.data.queries.CampaignSchemaUpdateRequest
	 * Campaign schema update request class.
	 */
	Ext.define("BPMSoft.data.queries.CampaignSchemaUpdateRequest", {
		extend: "BPMSoft.BaseSchemaUpdateRequest",
		alternateClassName: "BPMSoft.CampaignSchemaUpdateRequest",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "ContractCampaignSchema",

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
	return BPMSoft.CampaignSchemaUpdateRequest;
});
