/**
 * @class BPMSoft.configuration.view.ChartDashboardItemPage
 */
Ext.define("BPMSoft.configuration.view.ChartDashboardItemPage", {
	extend: "BPMSoft.configuration.view.DashboardItemPage",
	alternateClassName: "BPMSoft.view.ChartDashboardItemPage",

	config: {

		/**
		 * @inheritdoc
		 */
		id: "ChartDashboardItemPage",

		/**
		 * @inheritdoc
		 */
		itemClassName: "BPMSoft.Chart"

	},

	//region Methods: Protected

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	createDashboardItem: function(config) {
		var dashboardItem = this.callParent(arguments);
		dashboardItem.on("charttap", this.onDashboardItemTap, this);
		dashboardItem.on("chartpointtap", this.onDashboardItemPointTap, this);
		return dashboardItem;
	},

	/**
	 * Handles tap on dashboard item.
	 * @protected
	 * @virtual
	 */
	onDashboardItemTap: function(chart, config) {
		this.fireEvent("charttap", chart, config);
	},

	/**
	 * Handles tap on dashboard item point.
	 * @protected
	 * @virtual
	 */
	onDashboardItemPointTap: function(chart, pointIndex, serieIndex) {
		this.fireEvent("chartpointtap", chart, pointIndex, serieIndex);
	}

	//endregion

});
