 /**
 * UI schema for base CRUD object campaign element.
 */
define("CampaignBaseCrudObjectSchema", ["CampaignBaseCrudObjectSchemaResources",
		"CampaignBaseElementSchema"],
	function(resources) {
	/**
	 * @class BPMSoft.manager.CampaignBaseCrudObjectSchema
	 */
	Ext.define("BPMSoft.manager.CampaignBaseCrudObjectSchema", {
		extend: "BPMSoft.CampaignBaseElementSchema",
		alternateClassName: "BPMSoft.CampaignBaseCrudObjectSchema",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#managerItemUId
		 * @override
		 */
		managerItemUId: "4582fbc6-22c0-456c-8b0f-35133afdfc8a",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#name
		 * @override
		 */
		name: "CampaignBaseCrudObject",

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#caption
		 * @override
		 */
		caption: resources.localizableStrings.Caption,

		/**
		 * @inheritdoc BPMSoft.manager.ProcessBaseElementSchema#group
		 * @override
		 */
		group: "SystemActions",

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#editPageSchemaName
		 * @override
		 */
		editPageSchemaName: null,

		/**
		 * @inheritdoc BPMSoft.ProcessBaseElementSchema#color
		 * @override
		 */
		color: "rgba(132, 157, 195, 1)",

		/**
		 * Entity schema name.
		 * @protected
		 * @type {String}
		 */
		entityName: null,

		/**
		 * @type {Array}
		 */
		columnValues: null,

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			if (!BPMSoft.CampaignElementGroups.Items.contains("SystemActions")) {
				BPMSoft.CampaignElementGroups.Items.add("SystemActions", {
					name: "SystemActions",
					caption: resources.localizableStrings.SystemActionsGroupCaption
				});
			}
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
		 * @override
		 */
		getSerializableProperties: function() {
			var baseSerializableProperties = this.callParent(arguments);
			return Ext.Array.push(baseSerializableProperties, ["entityName", "columnValues"]);
		}
	});
	return BPMSoft.CampaignBaseCrudObjectSchema;
});
