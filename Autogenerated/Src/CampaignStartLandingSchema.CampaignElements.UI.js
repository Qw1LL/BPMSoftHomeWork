define("CampaignStartLandingSchema", ["CampaignStartLandingSchemaResources",
	"CampaignEnums", "CampaignStartSignalSchema", "CampaignElementMixin"],
		function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.CampaignStartLandingSchema
	 * Schema of start landing element.
	 */
	Ext.define("BPMSoft.manager.CampaignStartLandingSchema", {
		extend: "BPMSoft.CampaignStartSignalSchema",
		alternateClassName: "BPMSoft.CampaignStartLandingSchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "3A5EC15A-A0C1-42B3-A0C2-2B8CC975E337",

		/**
		 * @inheritdoc BPMSoft.manager.CampaignStartSignalSchema#name
		 */
		name: "CampaignStartLanding",

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
		 * @inheritdoc BPMSoft.CampaignStartSignalSchema#editPageSchemaName
		 */
		editPageSchemaName: "CampaignStartLandingPage",

		/**
		 * @inheritdoc BPMSoft.CampaignStartSignalSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Configuration.CampaignStartLandingElement, BPMSoft.Configuration",

		/**
		 * @override
		 * @type {enum}
		 */
		entitySignal: BPMSoft.EntityChangeType.Inserted,

		/**
		 * @override
		 * @type {Boolean}
		 */
		hasEntityFilters: true,

		/**
		 * @override
		 * @type {String}
		 */
		entityFilters: null,

		/**
		 * Identifier of the landing page
		 */
		landingId: null,

		/**
		 * Clears linked landing when element copy is created.
		 * @inheritdoc BPMSoft.manager.CampaignBaseElementSchema#prepareCopy
		 * @override
		 */
		prepareCopy: function() {
			var copy = this.callParent(arguments);
			copy.entityFilters = null;
			copy.landingId = null;
			return copy;
		},

		/**
		 * @inheritdoc BPMSoft.CampaignStartSignalSchema#getSerializableProperties
		 * @override
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["landingId"]);
		},

		/**
		 * @inheritdoc BPMSoft.CampaignBaseElementSchema#getElementMarkers
		 * @override
		 */
		getElementMarkers: function() {
			var markers = {};
			if (this.isRecurring) {
				markers.recurring = { name: "Recurring" };
			}
			return markers;
		},

		/**
		 * @inheritDoc BPMSoft.CampaignBaseElementSchema#initTitleImage
		 * @override
		 */
		initTitleImage: function() {
			this.titleImage = this.isRecurring
				? resources.localizableImages.TitleIsRecurringImage
				: resources.localizableImages.TitleImage;
		}
	});
	return BPMSoft.CampaignStartLandingSchema;
});
