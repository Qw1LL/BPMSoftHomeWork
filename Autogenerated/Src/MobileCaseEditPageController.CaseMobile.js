/* globals Case: false */
/**
 * @class BPMSoft.configuration.controller.CaseEditPage
 */
Ext.define("BPMSoft.configuration.controller.CaseEditPage", {
	alternateClassName: "BPMSoft.configuration.CaseEditPageController",
	extend: "BPMSoft.controller.BaseEditPage",

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
			view: "#CaseEditPage"
		}

	}

});
