define("CampaignSchemaRequest", ["CampaignSchemaResponse"], function() {
	/**
	 * @class BPMSoft.data.queries.CampaignSchemaRequest
	 * Campaign schema request class.
	 */
	Ext.define("BPMSoft.data.queries.CampaignSchemaRequest", {
		extend: "BPMSoft.BaseSchemaRequest",
		alternateClassName: "BPMSoft.CampaignSchemaRequest",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#contractName
		 * @overridden
		 */
		contractName: "CampaignSchemaRequest",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaRequest#responseClassName
		 * @overridden
		 */
		responseClassName: "BPMSoft.CampaignSchemaResponse"
	});

	return BPMSoft.data.queries.CampaignSchemaRequest;
});
