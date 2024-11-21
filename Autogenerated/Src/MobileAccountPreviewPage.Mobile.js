/* globals Account: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "AccountPreviewPage.Controller",
	viewXType: "accountpreviewpageview"
};

Ext.define("AccountPreviewPage.View", {
	extend: "BPMSoft.view.BasePreviewPage",
	xtype: "accountpreviewpageview",
	config: {
		id: "AccountPreviewPage"
	}
});

Ext.define("AccountPreviewPage.Controller", {
	extend: "BPMSoft.controller.BasePreviewPage",

	statics: {
		Model: Account
	},

	config: {
		refs: {
			view: "#AccountPreviewPage"
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
			activityLinkColumnNames: "Account",
			record: this.record
		});
	}

});
