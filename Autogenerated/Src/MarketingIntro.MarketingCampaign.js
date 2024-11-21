define("MarketingIntro", ["MarketingIntroResources"], function(resources) {
	return {
		attributes: {},
		methods: {},
		diff: [
			{
				"operation": "insert",
				"name": "MarketingTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.MarketingCaption"},
					"cls": "marketing",
					"icon": resources.localizableImages.CampaignsIcon,
					"items": []
				},
				"index": 1
			},
			{
				"operation": "remove",
				"name": "ContactSectionV2"
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "MarketingTile",
				"name": "ContactSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ContactSectionCaption"},
					"tag": "SectionModuleV2/ContactSectionV2/",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "MarketingTile",
				"name": "CampaignSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.CampaignSectionCaption"},
					"tag": "SectionModuleV2/CampaignSectionV2/",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "MarketingTile",
				"name": "BulkEmailSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.BulkEmailSectionCaption"},
					"tag": "SectionModuleV2/BulkEmailSectionV2/",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "MarketingTile",
				"name": "CampaignPlannerSection",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.CampaignPlannerSectionCaption"},
					"tag": "SectionModuleV2/CampaignPlannerSection/",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "MarketingTile",
				"name": "GeneratedWebFormSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.GeneratedWebFormSectionCaption"},
					"tag": "SectionModuleV2/GeneratedWebFormSectionV2/",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "MarketingTile",
				"name": "EventSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.EventSectionCaption"},
					"tag": "SectionModuleV2/EventSectionV2/",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "MarketingTile",
				"name": "LeadSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.LeadSectionCaption"},
					"tag": "SectionModuleV2/LeadSectionV2/",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "BasicTile",
				"name": "ProductSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"caption": {"bindTo": "Resources.Strings.ProductSectionCaption"},
					"tag": "SectionModuleV2/ProductSectionV2/",
					"click": {"bindTo": "onNavigateTo"}
				},
				"index": 1
			},
			{
				"operation": "remove",
				"name": "MobileAppLinksPanel"
			}
		]
	};
});
