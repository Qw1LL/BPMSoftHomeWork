 define("CampaignDeduplicatorSchema", ["CampaignDeduplicatorSchemaResources",
	"CampaignEnums", "CampaignBaseElementSchema", "CampaignElementMixin"],
		function(resources, CampaignEnums) {
	/**
	 * @class BPMSoft.manager.CampaignDeduplicatorSchema
	 * Schema of deduplicator element.
	 */
	Ext.define("BPMSoft.manager.CampaignDeduplicatorSchema", {
		extend: "BPMSoft.CampaignBaseElementSchema",
		alternateClassName: "BPMSoft.CampaignDeduplicatorSchema",

		mixins: {
			campaignElementMixin: "BPMSoft.CampaignElementMixin"
		},

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "155B4655-38D5-486C-95DE-BF77FD5218EA",

		/**
		 * @inheritdoc BPMSoft.manager.CampaignStartSignalSchema#name
		 */
		name: "CampaignDeduplicator",

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
		editPageSchemaName: "CampaignDeduplicatorPage",

		/**
		 * Type of element
		 * @type {string}
		 */
		elementType: CampaignEnums.CampaignSchemaElementTypes.CAMPAIGN_DEDUPLICATOR,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @override
		 */
		typeName: "BPMSoft.Configuration.CampaignDeduplicatorElement, BPMSoft.Configuration",

		/**
		 * Background fill color.
		 * @protected
		 * @type {String}
		 */
		color: "rgba(132, 157, 195, 1)",

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
		 * Identifier of the entity schema
		 */
		entitySchemaUId: null,

		/**
		 * Path to column duplicates search by.
		 * @type {String}
		 */
		columnPath: null,

		/**
		 * Flag to indicate that element can suspend participants with empty column values.
		 * @type {Boolean}
		 */
		suspendParticipantsWithEmptyValues: false,

		/**
		 * @inheritdoc BPMSoft.CampaignBaseElementSchema#getSerializableProperties
		 * @override
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["entitySchemaUId", "columnPath",
				"suspendParticipantsWithEmptyValues"]);
		},

		/**
		 * @inheritdoc CampaignBaseElementSchema#validate
		 * @override
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
	return BPMSoft.CampaignDeduplicatorSchema;
});
