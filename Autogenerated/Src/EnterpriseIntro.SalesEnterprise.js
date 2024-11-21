define("EnterpriseIntro", ["EnterpriseIntroResources"], function(resources) {
	return {
		attributes: {},
		methods: {},
		diff: [
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "BasicTile",
				"name": "LeadSectionV2",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Lead",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"name": "SalesTile",
				"propertyName": "items",
				"parentName": "LeftContainer",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generator": "MainMenuTileGenerator.generateMainMenuTile",
					"caption": {"bindTo": "Resources.Strings.SalesCaption"},
					"cls": "sales-tile",
					"icon": resources.localizableImages.SalesIcon,
					"items": []
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SalesTile",
				"name": "OpportunitySectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Opportunity",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SalesTile",
				"name": "OrderSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Order",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SalesTile",
				"name": "ContractSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Contract",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SalesTile",
				"name": "DocumentSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Document",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SalesTile",
				"name": "InvoiceSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Invoice",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SalesTile",
				"name": "ProductSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Product",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SalesTile",
				"name": "ProjectSectionV2",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Project",
					"click": {"bindTo": "onNavigateTo"}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"parentName": "SalesTile",
				"name": "ForecastsModule",
				"values": {
					"itemType": BPMSoft.ViewItemType.LINK,
					"moduleName": "Forecast",
					"click": {"bindTo": "onNavigateTo"}
				}
			}
		]
	};
});
