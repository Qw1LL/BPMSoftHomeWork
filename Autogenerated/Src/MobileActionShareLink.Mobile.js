/**
 * @class BPMSoft.ActionShare
 * Shares record link.
 */
Ext.define("BPMSoft.configuration.action.ShareLink", {
	extend: "BPMSoft.ActionBase",

	config: {

		/**
		 * @inheritdoc
		 */
		title: "MobileActionShareLinkCaption",

		/**
		 * @inheritdoc
		 */
		iconCls: "cf-action-share-link",

		/**
		 * @inheritdoc
		 */
		useMask: false

	},

	/**
	 * Returns universal hyperlink for record.
	 * @method
	 * @param {String} modelName Name of model.
	 * @param {String} recordId Record identifier.
	 * @return {String} Hyperlink for record.
	 */
	generateItemLink: function(modelName, recordId) {
		var linkTemplate = "{0}Navigation/Navigation.aspx?schemaName={1}&recordId={2}";
		return Ext.String.format(linkTemplate, BPMSoft.CurrentUserInfo.serverUrl, modelName, recordId);
	},

	/**
	 * @inheritdoc
	 */
	execute: function(record, config) {
		this.callParent(arguments);
		var link = this.generateItemLink(record.modelName, record.getPrimaryColumnValue());
		BPMSoft.SocialSharing.share(link);
	}

});
