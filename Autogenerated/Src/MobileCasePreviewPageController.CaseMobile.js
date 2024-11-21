/* globals Case: false */
/**
 * @class BPMSoft.configuration.controller.CasePreviewPage
 */
Ext.define("BPMSoft.configuration.controller.CasePreviewPage", {
	extend: "BPMSoft.controller.BasePreviewPage",
	alternateClassName: "BPMSoft.configuration.CasePreviewPageController",

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
			view: "#CasePreviewPage"
		}

	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	initializeView: function(view) {
		this.callParent(arguments);
		view.addFeedActionButton({
			listeners: {
				tap: this.onFeedActionButtonTap,
				scope: this
			}
		});
	},

	/**
	 * Calls when feed action button has been tapped.
	 * @protected
	 * @virtual
	 */
	onFeedActionButtonTap: function() {
		this.executeAction({
			name: "CaseOpenFeedDetailAction"
		});
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getActionStoreItem: function(action) {
		if (!BPMSoft.CaseUtilities.isActionVisible(action)) {
			return null;
		}
		return this.callParent(arguments);
	}

});
