BPMSoft.LastLoadedPageData = {
	controllerName: "AccountGridPage.Controller",
	viewXType: "accountgridpage"
};

Ext.define("AccountGridPage.Store", {
	extend: "BPMSoft.store.BaseStore",
	config: {
		model: "Account",
		controller: "AccountGridPage.Controller"
	}
});

Ext.define("AccountGridPage.View", {
	extend: "BPMSoft.view.BaseGridPage.View",
	xtype: "accountgridpage",
	config: {
		id: "AccountGridPage",
		navigationPanel: {
			id: "AccountGridPage_navigationPanel",
			title: LocalizableStrings["AccountGridPage_navigationPanel_title"]
		},
		grid: {
			id: "AccountGridPage_grid",
			iconCls: "user",
			store: "AccountGridPage.Store"
		}
	}
});

Ext.define("AccountGridPage.Controller", {
	extend: "BPMSoft.controller.BaseGridPage",

	statics: {
		Model: Account
	},

	config: {
		refs: {
			view: "#AccountGridPage",
			navigationPanel: "#AccountGridPage_navigationPanel",
			grid: "#AccountGridPage_grid"
		}
	}

});
