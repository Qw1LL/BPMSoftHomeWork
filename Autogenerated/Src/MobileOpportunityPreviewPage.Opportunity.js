/* globals Opportunity: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "BPMSoft.configuration.OpportunityPreviewPageController",
	viewXClass: "BPMSoft.configuration.OpportunityPreviewPageView"
};

Ext.define("BPMSoft.configuration.OpportunityPreviewPageView", {
	extend: "BPMSoft.view.BasePreviewPage",
	alternateClassName: "OpportunityPreviewPage.View",
	config: {
		id: "OpportunityPreviewPage"
	}
});

Ext.define("BPMSoft.configuration.OpportunityPreviewPageController", {
	extend: "BPMSoft.controller.BasePreviewPage",
	alternateClassName: "OpportunityPreviewPage.Controller",
	statics: {
		Model: Opportunity
	},
	config: {
		refs: {
			view: "#OpportunityPreviewPage"
		}
	}
});
