/* globals Opportunity: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "BPMSoft.configuration.OpportunityEditPageController",
	viewXClass: "BPMSoft.configuration.OpportunityEditPageView"
};

Ext.define("BPMSoft.configuration.OpportunityEditPageView", {
	extend: "BPMSoft.view.BaseEditPage",
	alternateClassName: "OpportunityEditPage.View",
	config: {
		id: "OpportunityEditPage"
	}
});

Ext.define("BPMSoft.configuration.OpportunityEditPageController", {
	extend: "BPMSoft.controller.BaseEditPage",
	alternateClassName: "OpportunityEditPage.Controller",
	statics: {
		Model: Opportunity
	},
	config: {
		refs: {
			view: "#OpportunityEditPage"
		}
	}
});
