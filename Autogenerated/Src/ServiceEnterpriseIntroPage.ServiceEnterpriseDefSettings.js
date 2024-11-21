define("ServiceEnterpriseIntroPage", ["ServiceEnterpriseIntroPageResources", "css!IntroPageCSS"],
	function(resources) {
		return {
			attributes: {},
			methods: {},
			diff: [
				{
					"operation": "remove",
					"name": "MobileAppLinksPanel"
				},
				{
					"operation": "insert",
					"name": "ServiceTile",
					"propertyName": "items",
					"parentName": "LeftContainer",
					"index": 1,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"generator": "MainMenuTileGenerator.generateMainMenuTile",
						"caption": {"bindTo": "Resources.Strings.ServiceCaption"},
						"cls": "service-tile itil-service-transitions-tile",
						"icon": resources.localizableImages.ServiceIcon,
						"items": []
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "CaseSection",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.CaseSectionCaption"},
						"tag": "SectionModuleV2/CaseSection/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "ProblemSection",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ProblemSectionCaption"},
						"tag": "SectionModuleV2/ProblemSection/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "ConfItemSection",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ConfItemSectionCaption"},
						"tag": "SectionModuleV2/ConfItemSection/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "ChangeSection",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ChangeSectionCaption"},
						"tag": "SectionModuleV2/ChangeSection/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "ReleaseSection",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ReleaseSectionCaption"},
						"tag": "SectionModuleV2/ReleaseSection/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "ServiceItemSection",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ServiceSectionCaption"},
						"tag": "SectionModuleV2/ServiceItemSection/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "ServicePactSection",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.ServicePactSectionCaption"},
						"tag": "SectionModuleV2/ServicePactSection/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "QueueItemSection",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.QueueSectionCaption"},
						"tag": "SectionModuleV2/QueueItemSection/",
						"click": {"bindTo": "onNavigateTo"}
					}
				},
				{
					"operation": "insert",
					"propertyName": "items",
					"parentName": "ServiceTile",
					"name": "OperatorSingleWindowModule",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.LINK,
						"caption": {"bindTo": "Resources.Strings.OperatorSingleWindowSectionCaption"},
						"tag": "OperatorSingleWindowModule/",
						"click": {"bindTo": "onNavigateTo"}
					}
				}
			]
		};
	}
);
