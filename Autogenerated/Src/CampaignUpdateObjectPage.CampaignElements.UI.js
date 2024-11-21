define("CampaignUpdateObjectPage", ["CampaignUpdateObjectPageResources"], function() {
	return {
		methods: {
			/**
			 * @inheritdoc CampaignBaseCrudObjectPage#getEntitySchemaLookupName
			 * @override
			 */
			getEntitySchemaLookupName: function() {
				return "CmpgnUpdObjElEntity";
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
