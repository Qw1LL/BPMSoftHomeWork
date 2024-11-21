/**
 * @class BPMSoft.configuration.view.SocialMessageGridPage
 */
Ext.define("BPMSoft.configuration.view.SocialMessageGridPage", {
	alternateClassName: "SocialMessageGridPage.View",
	extend: "BPMSoft.view.BaseGridPage.View",

	xtype: "socialmessagegridpageview",

	config: {

		id: "SocialMessageGridPage",

		grid: {

			xtype: "cffeedlist",

			store: "SocialMessageGridPage.Store",

			htmlEncode: false

		},

		/**
		 * @inheritdoc
		 */
		ownerButton: false

	},

	/**
	 * @private
	 */
	addOwnerButton: function() {
		var ownerButton = this.getOwnerButton();
		this.add(ownerButton);
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-applier
	 */
	applyOwnerButton: function(newButton) {
		if (!newButton) {
			return false;
		}
		var config = {
			cls: "cf-social-message-grid-owner-button",
			iconCls: "",
			markerValue: "social-message-owner-button"
		};
		return Ext.factory(config, "Ext.Button", this.getOwnerButton());
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-updater
	 */
	updateOwnerButton: function(newButton, oldButton) {
		if (newButton) {
			this.setOwnerButtonImage(null);
			this.addOwnerButton();
		}
		if (oldButton) {
			Ext.destroy(oldButton);
		}
	},

	setOwnerButtonImage: function(image) {
		var ownerButton = this.getOwnerButton();
		var defaultImageCls = "cf-social-message-owner-default-image";
		if (image) {
			ownerButton.removeCls(defaultImageCls);
		} else {
			ownerButton.addCls(defaultImageCls);
			image = BPMSoft.Configuration.getDefaultOwnerImage();
		}
		ownerButton.setIcon(image);
	}
});
