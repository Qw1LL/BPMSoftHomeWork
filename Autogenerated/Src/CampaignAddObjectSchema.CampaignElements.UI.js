 /**
 * UI schema for add object campaign element.
 */
define("CampaignAddObjectSchema", ["CampaignAddObjectSchemaResources", "CampaignEnums",
		"CampaignBaseCrudObjectSchema"],
	function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.CampaignAddObjectSchema
	 */
	Ext.define("BPMSoft.manager.CampaignAddObjectSchema", {
		extend: "BPMSoft.CampaignBaseCrudObjectSchema",
		alternateClassName: "BPMSoft.CampaignAddObjectSchema",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#managerItemUId
		 * @override
		 */
		managerItemUId: "62e4fbc6-22c0-456c-8b0f-35133afdfc8a",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 * @override
		 */
		name: "CampaignAddObject",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 * @override
		 */
		caption: resources.localizableStrings.Caption,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#TitleImage
		 * @override
		 */
		titleImage: resources.localizableImages.TitleImage,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#LargeImage
		 * @override
		 */
		largeImage: resources.localizableImages.LargeImage,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#SmallImage
		 * @override
		 */
		smallImage: resources.localizableImages.SmallImage,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 * @override
		 */
		editPageSchemaName: "CampaignAddObjectPage",

		/**
		 * Type of element.
		 * @type {String}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.ADD_OBJECT_ELEMENT,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Configuration.CampaignAddObjectElement, BPMSoft.Configuration"
	});
	return BPMSoft.CampaignAddObjectSchema;
});
