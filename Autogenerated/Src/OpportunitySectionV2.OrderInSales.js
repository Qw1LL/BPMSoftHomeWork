define("OpportunitySectionV2", ["OpportunityOrderUtilities"],
	function() {
		return {
			mixins: {
				/**
				 * Order utilities mixin.
				 */
				OpportunityOrderUtilities: "BPMSoft.OpportunityOrderUtilities"
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "CreateOrderFromOpportunityButton",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "getButtonCaption"},
						"click": {"bindTo": "onCardAction"},
						"tag": "CreateOrderFromOpportunity",
						"enabled": {"bindTo": "canEntityBeOperated"},
						"classes": {
							"textClass": ["actions-button-margin-right"]
						}
					}
				},
				{
					"operation": "merge",
					"name": "CloseButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					}
				},
				{
					"operation": "merge",
					"name": "CombinedModeActionsButton",
					"values": {
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						},
				},
			]/**SCHEMA_DIFF*/
		};
	});
