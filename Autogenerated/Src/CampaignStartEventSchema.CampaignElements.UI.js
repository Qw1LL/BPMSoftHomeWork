define("CampaignStartEventSchema", ["CampaignStartEventSchemaResources",
	"CampaignEnums", "CampaignStartSignalSchema", "CampaignElementMixin"],
		function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.CampaignStartEventSchema
	 * Schema of start event element.
	 */
	Ext.define("BPMSoft.manager.CampaignStartEventSchema", {
		extend: "BPMSoft.CampaignStartSignalSchema",
		alternateClassName: "BPMSoft.CampaignStartEventSchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "2A30D844-0DC9-42FC-9F02-B7D5A3FABB97",

		/**
		 * @inheritdoc BPMSoft.manager.CampaignStartSignalSchema#name
		 */
		name: "CampaignStartEvent",

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
		editPageSchemaName: "CampaignStartEventPage",

		/**
		 * @inheritdoc BPMSoft.CampaignStartSignalSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Configuration.CampaignStartEventElement, BPMSoft.Configuration",

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
		 * Identifier of the event page
		 */
		eventId: null,

		/**
		 * Clears linked landing when element copy is created.
		 * @inheritdoc BPMSoft.manager.CampaignBaseElementSchema#prepareCopy
		 * @override
		 */
		prepareCopy: function() {
			var copy = this.callParent(arguments);
			copy.entityFilters = null;
			copy.eventId = null;
			return copy;
		},

		/**
		 * @inheritdoc BPMSoft.CampaignStartSignalSchema#getSerializableProperties
		 * @override
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["eventId"]);
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
	return BPMSoft.CampaignStartEventSchema;
});
