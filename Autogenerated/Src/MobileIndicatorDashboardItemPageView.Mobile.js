/**
 * @class BPMSoft.configuration.view.IndicatorDashboardItemPage
 */
Ext.define("BPMSoft.configuration.view.IndicatorDashboardItemPage", {
	extend: "BPMSoft.view.DashboardItemPage",
	alternateClassName: "BPMSoft.view.IndicatorDashboardItemPage",

	config: {

		/**
		 * @inheritdoc
		 */
		id: "IndicatorDashboardItemPage",

		/**
		 * @inheritdoc
		 */
		itemClassName: "BPMSoft.IndicatorDashboardComponent"

	},

	//region Methods: Protected

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	initialize: function() {
		this.callParent(arguments);
		this.addCls("cf-indicator-dashboard-item-page");
	}

	//endregion

});
