/**
 * Schema of campaign Event element page
 * Parent: CampaignBaseEventPage
 */
define("CampaignEventPage", [],
	function() {
		return {
			methods: {
				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode
				 * @override
				 */
				getContextHelpCode: function() {
					return "CampaignEventElement";
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
