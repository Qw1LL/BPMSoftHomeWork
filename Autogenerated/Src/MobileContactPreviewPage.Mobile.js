/* globals Contact: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "ContactPreviewPage.Controller",
	viewXType: "contactpreviewpageview"
};

Ext.define("ContactPreviewPage.View", {
	extend: "BPMSoft.view.BasePreviewPage",
	xtype: "contactpreviewpageview",
	config: {
		id: "ContactPreviewPage"
	}
});

Ext.define("ContactPreviewPage.Controller", {
	extend: "BPMSoft.controller.BasePreviewPage",

	statics: {
		Model: Contact
	},

	config: {
		refs: {
			view: "#ContactPreviewPage"
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onCallPhoneStarted: function() {
		this.callParent(arguments);
		BPMSoft.PhoneCallLogUtils.openPage({
			activityLinkColumnNames: [
				{
					parentColumnName: "Id",
					activityColumnName: "Contact"
				},
				{
					parentColumnName: "Account",
					activityColumnName: "Account"
				}
			],
			record: this.record
		});
	}

});
