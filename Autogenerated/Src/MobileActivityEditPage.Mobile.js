/* globals Activity: false */
BPMSoft.LastLoadedPageData = {
	controllerName: "BPMSoft.configuration.controller.ActivityEditPage",
	viewXType: "activityeditpageview"
};

Ext.define("BPMSoft.configuration.view.ActivityEditPage", {
	alternateClassName: "ActivityEditPage.View",
	extend: "BPMSoft.view.BaseEditPage",

	xtype: "activityeditpageview",

	config: {
		id: "ActivityEditPage"
	}

});

Ext.define("BPMSoft.configuration.controller.ActivityEditPage", {
	alternateClassName: "ActivityEditPage.Controller",
	extend: "BPMSoft.controller.BaseEditPage",

	statics: {
		Model: Activity
	},

	config: {
		refs: {
			view: "#ActivityEditPage"
		}
	},

	/**
	 * @obsolete
	 */
	refreshDirtyDataByColumns: Ext.emptyFn,

	/**
	 * @protected
	 * @overriden
	 */
/*
	shouldOpenPreviewPageOnSave: function() {
		var pageHistoryItem = this.getPageHistoryItem();
		if (pageHistoryItem && pageHistoryItem.getParent()) {
			var gridPageController = BPMSoft.PageNavigator.getHistoryItemController(pageHistoryItem.getParent());
			if (gridPageController instanceof BPMSoft.configuration.controller.ActivityGridPage) {
				var gridMode = gridPageController.getActivityGridMode();
				if (gridMode === BPMSoft.Configuration.ActivityGridModeTypes.Schedule) {
					return false;
				}
			}
		}
		return this.callParent(arguments);
	}
*/
});
