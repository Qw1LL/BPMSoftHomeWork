define("AddCampaignParticipantSchema", ["AddCampaignParticipantSchemaResources",
	"CampaignEnums", "CampaignBaseAudienceSchema", "CampaignElementMixin"],
		function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.AddCampaignParticipantSchema
	 * Schema of base audience element.
	 */
	Ext.define("BPMSoft.manager.AddCampaignParticipantSchema", {
		extend: "BPMSoft.CampaignBaseAudienceSchema",
		alternateClassName: "BPMSoft.AddCampaignParticipantSchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "bbd2372a-66c0-4e4c-9f38-3aeae2e78c66",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 */
		name: "AddAudience",

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
		editPageSchemaName: "AddCampaignParticipantPage",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Configuration.AddCampaignParticipantElement, BPMSoft.Configuration",

		/**
		 * Type of element
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.ADD_AUDIENCE,

		/**
		 * Background fill color.
		 * @protected
		 * @type {String}
		 */
		color: "rgba(101, 215, 144, 1)",

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#width
		 * @override
		 */
		width: 55,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#height
		 * @override
		 */
		height: 55,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#incomingConnectionsLimit
		 * @override
		 */
		incomingConnectionsLimit: 0,

		/**
		 * FolderId from which participants should be added into campaign.
		 * @type {String}
		 */
		folderId: null,

		/**
		 * Search data string to filter imported audience.
		 * @type {String}
		 */
		filter: null,

		/**
		 * Flag to indicate that audience import is provided by filter.
		 * @type {Boolean}
		 */
		hasFilter: false,

		/**
		 * Flag to indicate that element can do recurring participants add.
		 * @type {Boolean}
		 */
		isRecurring: false,

		/**
		 * Number of days before participant will be added next time.
		 * @type {Number}
		 */
		recurringFrequencyInDays: null,

		/**
		 * AudienceSchemaId of objects to be added into campaign.
		 * @type {String}
		 */
		audienceSchemaId: null,

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @override
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["folderId", "recurringFrequencyInDays", "isRecurring",
				"filter", "hasFilter", "audienceSchemaId"]);
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
			if (this.hasFilter && !Ext.isEmpty(this.filter)) {
				markers.filter = { name: "AddFilter" };
			}
			if (!this.hasFilter && !Ext.isEmpty(this.folderId)) {
				markers.folder = { name: "AddFolder" };
			}
			return markers;
		},

		/**
		 * @inheritDoc BPMSoft.CampaignBaseElementSchema#initTitleImage
		 * @override
		 */
		initTitleImage: function() {
			if (this.hasFilter && !Ext.isEmpty(this.filter)) {
				this.titleImage = this.isRecurring
					? resources.localizableImages.TitleHasFilterIsRecurringImage
					: resources.localizableImages.TitleHasFilterImage;
			} else if (!this.hasFilter && !Ext.isEmpty(this.folderId)) {
				this.titleImage = this.isRecurring
					? resources.localizableImages.TitleRecurringWithFolderImage
					: resources.localizableImages.TitleWithFolderImage;
			} else {
				this.titleImage = this.isRecurring
					? resources.localizableImages.TitleIsRecurringImage
					: resources.localizableImages.TitleImage;
			}
		},

		/**
		 * @inheritDoc BPMSoft.CampaignBaseElementSchema#initLargeImage
		 * @override
		 */
		initLargeImage: function() {
			this.largeImage = this.isRecurring
				? resources.localizableImages.LargeIsRecurringImage
				: resources.localizableImages.LargeImage;
		},

		/**
		 * @inheritdoc CampaignBaseElementSchema#validate
		 * @override
		 */
		validate: function() {
			var results = Ext.create("BPMSoft.Collection");
			if (this.getOutgoingsSequenceFlows().length === 0) {
				results.add(CampaignEnums.CampaignFlowSchemaValidationRules.ADD_AUDIENCE_WITHOUT_OUTGOINGS,
					resources.localizableStrings.AddAudienceWithoutOutgoingsMessage);
			}
			return results;
		}
	});
	return BPMSoft.AddCampaignAudienceSchema;
});
