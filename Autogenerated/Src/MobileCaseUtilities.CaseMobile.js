/**
 * @class BPMSoft.configuration.CaseUtilities
 */
Ext.define("BPMSoft.configuration.CaseUtilities", {
	alternateClassName: "BPMSoft.CaseUtilities",
	singleton: true,

	/**
	 * Checks if action should be displayed in pages.
	 * @param {Object} action Action config.
	 * @return {Boolean} True, if action should be displayed.
	 */
	isActionVisible: function(action) {
		if (action.name === "OpenPortalMessagePublisherPageAction" && !BPMSoft.ApplicationUtils.isOnlineMode()) {
			return false;
		}
		return true;
	}

});
