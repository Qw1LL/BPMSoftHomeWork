define("AnalyticsManagerItem", ["SspPageDetailsManagerItemResources", "GoogleTagManagerMixin"], function() {

	/**
	 * @class BPMSoft.AnalyticsManagerItem
	 */

	Ext.define("BPMSoft.AnalyticsManagerItem", {
		extend: "BPMSoft.ObjectManagerItem",
		alternateClassName: "BPMSoft.AnalyticsManagerItem",

		// region Methods: Protected

		/**
		 * Gets modified item name.
		 * @abstract
		 * @return {String} Modified item name.
		 */
		getModifiedString: BPMSoft.abstractFn

		// endregion

	});

	return BPMSoft.SspPageDetailsManagerItem;
});
