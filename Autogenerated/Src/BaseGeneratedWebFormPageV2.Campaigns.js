define("BaseGeneratedWebFormPageV2", [],
	function() {
		return {
			entitySchemaName: "GeneratedWebForm",
			details: /**SCHEMA_DETAILS*/{
				LandingCampaign: {
					schemaName: "CampaignWithLandingDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Landing"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"name": "HistoryTab",
					"index": 3,
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.HistoryTabCaption"
						},
						"items": []
					}
				},
				{
					"name": "LandingCampaign",
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
