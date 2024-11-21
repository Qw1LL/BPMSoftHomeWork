/**
 * Schema of campaign add to event element page
 * Parent: CampaignBaseEventPage
 */
define("CampaignAddToEventPage", [],
	function() {
		return {
			methods: {
				/**
				 * @inheritdoc BaseCampaignSchemaElementPage#getContextHelpCode
				 * @override
				 */
				getContextHelpCode: function() {
					return "CampaignAddToEventElement";
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
