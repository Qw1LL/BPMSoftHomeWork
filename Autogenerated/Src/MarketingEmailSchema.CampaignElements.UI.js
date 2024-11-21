/**
 * Schema of marketing email element.
 */
define("MarketingEmailSchema", ["MarketingEmailSchemaResources", "CampaignEnums",
	"CampaignBaseCommunicationSchema"],
		function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.MarketingEmailSchema
	 * Schema of base communication element.
	 */
	Ext.define("BPMSoft.manager.MarketingEmailSchema", {
		extend: "BPMSoft.CampaignBaseCommunicationSchema",
		alternateClassName: "BPMSoft.MarketingEmailSchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "5782fbc6-22c0-456c-8b0f-35133afdfc8f",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 */
		name: "MarketingEmail",

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
		editPageSchemaName: "MarketingEmailPage",

		/**
		 * Type of element
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.MARKETING_EMAIL,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @protected
		 * @overridden
		 */
		typeName: "BPMSoft.Configuration.MarketingEmailElement, BPMSoft.Configuration",

		/**
		 * Background fill color.
		 * @protected
		 * @type {String}
		 */
		color: "rgba(148, 148, 235, 1)",

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
		 * @overridden
		 */
		width: 69,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#height
		 * @overridden
		 */
		height: 55,

		/**
		 * Marketing Email as element of campaign.
		 */
		marketingEmailId: null,

		/**
		 * Name of the Marketing Email audience schema.
		 */
		audienceSchemaName: null,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessFlowElementSchema#getConnectionUserHandles
		 * @overridden
		 */
		getConnectionUserHandles: function() {
			return ["CampaignSequenceFlow", "EmailConditionalTransition"];
		},

		/**
		 * Clears linked bulkEmail when element copy is created.
		 * @inheritdoc BPMSoft.manager.CampaignBaseElementSchema#prepareCopy
		 * @overridden
		 */
		prepareCopy: function() {
			var copy = this.callParent(arguments);
			copy.marketingEmailId = null;
			return copy;
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @overridden
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["marketingEmailId", "audienceSchemaName"]);
		},

		/**
		 * @inheritdoc CampaignBaseElementSchema#validate
		 * @overridden
		 */
		validate: function() {
			var results = Ext.create("BPMSoft.Collection");
			if (this.getIncomingSequenceFlows().length === 0) {
				results.add(CampaignEnums.CampaignFlowSchemaValidationRules.ASYNC_WITHOUT_INCOMINGS,
					resources.localizableStrings.AsyncWithoutIncomingsMessage);
			}
			return results;
		}
	});
	return BPMSoft.MarketingEmailSchema;
});
