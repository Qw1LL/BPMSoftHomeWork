define("CampaignSchemaResponse", ["CampaignSchema"], function() {
	/**
	 * @class BPMSoft.data.queries.CampaignSchemaResponse
	 * Campaign schema response class.
	 */
	Ext.define("BPMSoft.data.queries.CampaignSchemaResponse", {
		extend: "BPMSoft.BaseSchemaResponse",
		alternateClassName: "BPMSoft.CampaignSchemaResponse",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaResponse#schemaClassName
		 * @overridden
		 */
		schemaClassName: "BPMSoft.CampaignSchema",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaResponse#createSchemaInstance
		 * @overridden
		 */
		createSchemaInstance: function(config) {
			return BPMSoft.SchemaDesignerUtilities.createInstanceByMetaData({
				metaData: config.metaData,
				schemaClassName: this.schemaClassName,
				resources: config.resources
			});
		}
	});

	return BPMSoft.data.queries.CampaignSchemaResponse;
});
