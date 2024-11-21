/**
 * Schema of campaign base event element.
 */
define("CampaignBaseEventSchema", ["CampaignBaseEventSchemaResources", "CampaignEnums",
		"CampaignBaseAudienceSchema"],
	function(resources, CampaignEnums) {
		/**
		 * @class BPMSoft.manager.CampaignEventSchema
		 * Schema of base event element.
		 */
		Ext.define("BPMSoft.manager.CampaignBaseEventSchema", {
			extend: "BPMSoft.CampaignBaseAudienceSchema",
			alternateClassName: "BPMSoft.CampaignBaseEventSchema",

			mixins: {
				campaignElementMixin: "BPMSoft.CampaignElementMixin"
			},

			/**
			 * UId of current manager item.
			 */
			managerItemUId: "6fb3d10c-9725-4839-a122-c3112ac2a7e3",

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#name
			 */
			name: "CampaignBaseEvent",

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
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
			 */
			editPageSchemaName: "CampaignBaseEventPage",

			/**
			 * Type of element
			 * @type {string}
			 */
			elementType: CampaignEnums.CampaignSchemaElementTypes.CAMPAIGN_EVENT,

			/**
			 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
			 * @protected
			 * @overridden
			 */
			typeName: "BPMSoft.Configuration.CampaignBaseEventElement, BPMSoft.Configuration",

			/**
			 * Background fill color.
			 * @protected
			 * @type {String}
			 */
			color: "rgba(247, 194, 0, 1)",

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
			 * @overridden
			 */
			width: 55,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#height
			 * @overridden
			 */
			height: 55,

			/**
			 * Identifier of the Event entity in campaign event element
			 */
			eventId: null,

			/**
			 * @inheritdoc BPMSoft.manager.ProcessFlowElementSchema#getConnectionUserHandles
			 * @overridden
			 */
			getConnectionUserHandles: function() {
				return ["CampaignSequenceFlow", "EventConditionalTransition"];
			},

			/**
			 * Clears linked event when element copy is created.
			 * @inheritdoc BPMSoft.manager.CampaignBaseElementSchema#prepareCopy
			 * @overridden
			 */
			prepareCopy: function() {
				var copy = this.callParent(arguments);
				copy.eventId = null;
				return copy;
			},

			/**
			 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
			 * @overridden
			 */
			getSerializableProperties: function() {
				var baseSerializableProperties = this.callParent(arguments);
				return Ext.Array.push(baseSerializableProperties, ["eventId"]);
			}
		});
		return BPMSoft.CampaignBaseEventSchema;
	});
