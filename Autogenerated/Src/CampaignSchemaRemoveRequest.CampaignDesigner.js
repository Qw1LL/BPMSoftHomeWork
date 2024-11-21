define("CampaignSchemaRemoveRequest", ["CampaignSchemaRequest"], function() {
	/**
	 * @class BPMSoft.data.queries.CampaignSchemaRemoveRequest
	 * Campaign schema remove request class.
	 */
	Ext.define("BPMSoft.data.queries.CampaignSchemaRemoveRequest", {
		extend: "BPMSoft.CampaignSchemaRequest",
		alternateClassName: "BPMSoft.CampaignSchemaRemoveRequest",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "CampaignSchemaRemoveRequest"
	});

	return BPMSoft.data.queries.CampaignSchemaRemoveRequest;
});
