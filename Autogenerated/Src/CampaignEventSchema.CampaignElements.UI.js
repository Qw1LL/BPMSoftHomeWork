/**
 * Schema of campaign event element.
 */
define("CampaignEventSchema", ["CampaignEventSchemaResources", "CampaignEnums",
		"CampaignBaseEventSchema"],
	function(resources, CampaignEnums) {
		/**
		 * @class BPMSoft.manager.CampaignEventSchema
		 * Schema of event element.
		 */
		Ext.define("BPMSoft.manager.CampaignEventSchema", {
			extend: "BPMSoft.CampaignBaseEventSchema",
			alternateClassName: "BPMSoft.CampaignEventSchema",

			mixins: {
				campaignElementMixin: "BPMSoft.CampaignElementMixin"
			},

			/**
			 * UId of current manager item.
			 */
			managerItemUId: "952B9FDB-9152-4F93-95C6-E20AE37E000C",

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#name
			 */
			name: "CampaignEvent",

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#caption
			 */
			caption: resources.localizableStrings.Caption,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#TitleImage
			 */
			titleImage: resources.localizableImages.TitleImage,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#LargeImage
			 */
			largeImage: resources.localizableImages.LargeImage,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#SmallImage
			 */
			smallImage: resources.localizableImages.SmallImage,

			/**
			 * Type of element
			 * @type {string}
			 */
			elementType: CampaignEnums.CampaignSchemaElementTypes.CAMPAIGN_EVENT,

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
			 * @protected
			 * @overidde
			 */
			typeName: "BPMSoft.Configuration.CampaignEventElement, BPMSoft.Configuration",

						/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
			 */
			editPageSchemaName: "CampaignEventPage",

			/**
			 * Background fill color.
			 * @protected
			 * @type {String}
			 */
			color: "rgba(247, 194, 0, 1)"
		});
		return BPMSoft.CampaignEventSchema;
	});
