/* globals VwMobileCaseMessageHistory: false */
/**
 * @class BPMSoft.configuration.controller.CaseMessageHistoryGridPage
 */
Ext.define("BPMSoft.configuration.controller.CaseMessageHistoryGridPage", {
	alternateClassName: "BPMSoft.configuration.CaseMessageHistoryGridPageController",
	extend: "BPMSoft.controller.BaseGridPage",

	statics: {

		/**
		 * @inheritdoc
		 */
		Model: VwMobileCaseMessageHistory

	},

	config: {

		/**
		 * @inheritdoc
		 */
		refs: {
			view: "#CaseMessageHistoryGridPage"
		}

	}

});

/**
 * @class BPMSoft.configuration.store.CaseMessageHistoryGridPage
 */
Ext.define("BPMSoft.configuration.store.CaseMessageHistoryGridPage", {
	extend: "BPMSoft.store.BaseStore",
	alternateClassName: "BPMSoft.configuration.CaseMessageHistoryGridPageStore",

	config: {

		/**
		 * @inheritdoc
		 */
		model: "VwMobileCaseMessageHistory",

		/**
		 * @inheritdoc
		 */
		controller: "BPMSoft.configuration.CaseMessageHistoryGridPageController"

	}

});
