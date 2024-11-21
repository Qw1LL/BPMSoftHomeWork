Ext.define("BPMSoft.PhoneCallLogUtils", {
	singleton: true,

	/**
	 * @private
	 */
	pageName: "MobilePhoneCallLogPage",

	/**
	 * Opens page for phone call logging.
	 * @param {Object} config Configuration object:
	 * @param {String\Object} config.activityLinkColumnNames Columns name or array of object with column names, linking object with activity.
	 * @param {BPMSoft.model.BaseModel} config.record Record.
	 */
	openPage: function(config) {
		var pageData = {
			controllerName: "MobilePhoneCallLogPage.Controller",
			pageSchemaName: "MobilePhoneCallLogPage.View",
			viewXType: "mobilephonecalllogpageview"
		};
		BPMSoft.PageCache.addItem(this.pageName, pageData);
		var pageConfig = {
			pageSchemaName: this.pageName,
			defaultRecordData: {
				activityLinkColumnNames: config.activityLinkColumnNames,
				record: config.record,
				start: new Date()
			}
		};
		var mainPageController = BPMSoft.util.getMainController();
		setTimeout(function() {
			BPMSoft.Router.route("record", mainPageController, [pageConfig]);
		}.bind(this), 1000);
	}

});
