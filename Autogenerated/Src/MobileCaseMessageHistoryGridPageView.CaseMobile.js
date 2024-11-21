/**
 * @class BPMSoft.configuration.view.CaseMessageHistoryGridPage
 */
Ext.define("BPMSoft.configuration.view.CaseMessageHistoryGridPage", {
	extend: "BPMSoft.view.BaseGridPage.View",
	alternateClassName: "BPMSoft.configuration.CaseMessageHistoryGridPageView",

	config: {

		/**
		 * @inheritdoc
		 */
		id: "CaseMessageHistoryGridPage",

		/**
		 * @inheritdoc
		 */
		grid: {
			store: "BPMSoft.configuration.CaseMessageHistoryGridPageStore"
		},

		/**
		 * @inheritdoc
		 */
		cls: "cf-separated-grid-items"

	}
});
