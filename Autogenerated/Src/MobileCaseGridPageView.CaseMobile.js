/**
 * @class BPMSoft.configuration.view.CaseGridPage
 */
Ext.define("BPMSoft.configuration.view.CaseGridPage", {
	extend: "BPMSoft.view.BaseGridPage.View",
	alternateClassName: "BPMSoft.configuration.CaseGridPageView",

	config: {

		/**
		 * @inheritdoc
		 */
		id: "CaseGridPage",

		/**
		 * @inheritdoc
		 */
		grid: {
			store: "BPMSoft.configuration.CaseGridPageStore"
		}

	}
});
