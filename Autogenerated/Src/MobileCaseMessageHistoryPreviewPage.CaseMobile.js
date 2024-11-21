/* globals VwMobileCaseMessageHistory: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "BPMSoft.configuration.CaseMessageHistoryPreviewPageController",
	viewXClass: "BPMSoft.configuration.CaseMessageHistoryPreviewPageView"
};

Ext.define("BPMSoft.configuration.view.CaseMessageHistoryPreviewPage", {
	extend: "BPMSoft.view.BasePreviewPage",
	alternateClassName: "BPMSoft.configuration.CaseMessageHistoryPreviewPageView",
	config: {
		id: "CaseMessageHistoryPreviewPage"
	}
});

Ext.define("BPMSoft.configuration.controller.CaseMessageHistoryPreviewPage", {
	extend: "BPMSoft.controller.BasePreviewPage",
	alternateClassName: "BPMSoft.configuration.CaseMessageHistoryPreviewPageController",

	statics: {
		Model: VwMobileCaseMessageHistory
	},

	config: {
		refs: {
			view: "#CaseMessageHistoryPreviewPage"
		}
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onLoadRecord: function(loadedRecord) {
		var message = loadedRecord.get("Message");
		message = Ext.htmlDecode(message);
		var text = BPMSoft.String.getTextFromHtml(message);
		text = text.replace(/\n/g, "<br>");
		loadedRecord.set("Message", text);
		this.callParent(arguments);
	}

});
