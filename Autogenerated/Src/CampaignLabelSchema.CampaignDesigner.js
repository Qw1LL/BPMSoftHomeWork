 Ext.define("BPMSoft.manager.CampaignLabelSchema", {
	extend: "BPMSoft.manager.ProcessLabelSchema",
	alternateClassName: "BPMSoft.CampaignLabelSchema",

	/**
	 * @type {String}
	 */
	description: null,

	/**
	 * @type {Boolean}
	 */
	isDescription: false,

	/**
	 * @inheritdoc BPMSoft.manager.BaseSchema#getSerializableProperties
	 * @override
	 */
	getSerializableProperties: function() {
		var baseSerializableProperties = this.callParent(arguments);
		return Ext.Array.push(baseSerializableProperties, ["description"]);
	}

});
