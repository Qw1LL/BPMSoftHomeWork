define("CampaignBaseCommunicationSchema", ["ext-base", "BPMSoft", "CampaignBaseCommunicationSchemaResources",
	"CampaignElementGroups", "CampaignBaseElementSchema"], function(Ext, BPMSoft, resources) {
	/**
	 * @class BPMSoft.manager.CampaignBaseCommunicationSchema
	 * Schema of base audience element.
	 */
	Ext.define("BPMSoft.manager.CampaignBaseCommunicationSchema", {
		extend: "BPMSoft.CampaignBaseElementSchema",
		alternateClassName: "BPMSoft.CampaignBaseCommunicationSchema",

		//region Properties: Protected

		/**
		 * UId of current manager item.
		 */
		managerItemUId: "5790fbc6-22c0-456c-8b0f-35133afdfc8f",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 */
		name: "Communication",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 */
		caption: resources.localizableStrings.BaseCommunicationCaption,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#group
		 */
		group: "Communication",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 */
		editPageSchemaName: "CampaignBaseCommunicationPropertiesPage",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#typeName
		 * @protected
		 * @overridden
		 */
		typeName: "BPMSoft.Core.Campaign.FlowElement",

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @overridden
		 */
		constructor: function() {
			if (!BPMSoft.CampaignElementGroups.Items.contains("Communication")) {
				BPMSoft.CampaignElementGroups.Items.add("Communication", {
					name: "Communication",
					caption: resources.localizableStrings.CommunicationElementCaption
				});
			}
			this.callParent(arguments);
		}

		//endregion
	});
	return BPMSoft.CampaignBaseCommunicationSchema;
});
