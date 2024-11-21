/* globals Activity: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "ActivityPreviewPage.Controller",
	viewXType: "activitypreviewpageview"
};

Ext.define("ActivityPreviewPage.View", {
	extend: "BPMSoft.view.BasePreviewPage",
	xtype: "activitypreviewpageview",
	config: {
		id: "ActivityPreviewPage"
	}
});

Ext.define("ActivityPreviewPage.Controller", {
	extend: "BPMSoft.controller.BasePreviewPage",
	statics: {
		Model: Activity
	},
	config: {
		refs: {
			view: "#ActivityPreviewPage"
		}
	}
});
