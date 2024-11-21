 define("CampaignAddObjectPage", ["CampaignAddObjectPageResources"], function() {
	return {
		methods: {
			/**
			 * @inheritdoc CampaignBaseCrudObjectPage#getEntitySchemaLookupName
			 * @override
			 */
			getEntitySchemaLookupName: function() {
				return "CmpgnAddObjElEntity";
			}

		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
