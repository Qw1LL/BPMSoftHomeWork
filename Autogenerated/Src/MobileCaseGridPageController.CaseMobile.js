/* globals Case: false */
/**
 * @class BPMSoft.configuration.controller.CaseGridPage
 */
Ext.define("BPMSoft.configuration.controller.CaseGridPage", {
	alternateClassName: "BPMSoft.configuration.CaseGridPageController",
	extend: "BPMSoft.controller.BaseGridPage",

	statics: {

		/**
		 * @inheritdoc
		 */
		Model: Case

	},

	config: {

		/**
		 * @inheritdoc
		 */
		refs: {
			view: "#CaseGridPage"
		}

	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getActionStoreItem: function(action) {
		if (action.record && !BPMSoft.CaseUtilities.isActionVisible(action)) {
			return null;
		}
		return this.callParent(arguments);
	}

});

/**
 * @class BPMSoft.configuration.store.CaseGridPage
 */
Ext.define("BPMSoft.configuration.store.CaseGridPage", {
	extend: "BPMSoft.store.BaseStore",
	alternateClassName: "BPMSoft.configuration.CaseGridPageStore",

	config: {

		/**
		 * @inheritdoc
		 */
		model: "Case",

		/**
		 * @inheritdoc
		 */
		controller: "BPMSoft.configuration.CaseGridPageController"

	}

});
