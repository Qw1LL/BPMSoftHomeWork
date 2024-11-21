/* globals Lead: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "LeadPreviewPage.Controller",
	viewXType: "leadpreviewpageview"
};

Ext.define("LeadPreviewPage.View", {
	extend: "BPMSoft.view.BasePreviewPage",
	xtype: "leadpreviewpageview",
	config: {
		id: "LeadPreviewPage"
	}
});

Ext.define("LeadPreviewPage.Controller", {
	extend: "BPMSoft.controller.BasePreviewPage",

	statics: {
		Model: Lead
	},

	config: {
		refs: {
			view: "#LeadPreviewPage"
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
			activityLinkColumnNames: "Lead",
			record: this.record
		});
	}

});
