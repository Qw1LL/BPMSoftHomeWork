 /**
 * UI schema for update object campaign element.
 */
define("CampaignUpdateObjectSchema", ["CampaignUpdateObjectSchemaResources", "CampaignEnums",
		"CampaignBaseCrudObjectSchema"],
	function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.CampaignUpdateObjectSchema
	 */
	Ext.define("BPMSoft.manager.CampaignUpdateObjectSchema", {
		extend: "BPMSoft.CampaignBaseCrudObjectSchema",
		alternateClassName: "BPMSoft.CampaignUpdateObjectSchema",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#managerItemUId
		 * @override
		 */
		managerItemUId: "8182fbc6-22c0-456c-8b0f-35133afdfc8a",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 * @override
		 */
		name: "CampaignUpdateObject",

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
		editPageSchemaName: "CampaignUpdateObjectPage",

		/**
		 * Type of element.
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.UPDATE_OBJECT_ELEMENT,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Configuration.CampaignUpdateObjectElement, BPMSoft.Configuration"
	});
	return BPMSoft.CampaignUpdateObjectSchema;
});
