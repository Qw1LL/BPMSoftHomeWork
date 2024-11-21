define("CampaignBaseAudienceSchema", ["ext-base", "BPMSoft", "CampaignBaseAudienceSchemaResources",
	"CampaignElementGroups", "CampaignElementMixin", "CampaignBaseElementSchema"], function(Ext, BPMSoft, resources) {
	/**
	 * @class BPMSoft.manager.CampaignBaseAudienceSchema
	 * Schema of base audience element.
	 */
	Ext.define("BPMSoft.manager.CampaignBaseAudienceSchema", {
		extend: "BPMSoft.CampaignBaseElementSchema",
		alternateClassName: "BPMSoft.CampaignBaseAudienceSchema",

		//region Properties: Protected

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "5950fbc6-22c0-456c-8b0f-35133afdfc8f",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 */
		name: "Audience",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 */
		caption: resources.localizableStrings.BaseAudienceCaption,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#group
		 */
		group: "Audience",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 */
		editPageSchemaName: "CampaignBaseAudiencePropertiesPage",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @protected
		 * @overridden
		 */
		typeName: "BPMSoft.Core.Campaign.CampaignSchemaElement",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#nodeType
		 * @overridden
		 */
		nodeType: BPMSoft.diagram.UserHandlesConstraint.Event,

		/**
		 * AudienceSchemaId of objects to be added into campaign.
		 * @type {String}
		 */
		audienceSchemaId : null,

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			if (!BPMSoft.CampaignElementGroups.Items.contains("Audience")) {
				BPMSoft.CampaignElementGroups.Items.add("Audience", {
					name: "Audience",
					caption: resources.localizableStrings.AudienceElementGroupCaption
				});
			}
			this.callParent(arguments);
		}

		//endregion
	});
	return BPMSoft.CampaignBaseAudienceSchema;
});
