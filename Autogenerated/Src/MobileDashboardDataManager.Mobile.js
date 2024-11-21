/**
 * @class BPMSoft.configuration.DashboardDataManager
 * Manages dashboard data.
 */
Ext.define("BPMSoft.configuration.DashboardDataManager", {
	alternateClassName: "BPMSoft.DashboardDataManager",
	singleton: true,

	/**
	 * Loads layout config of dashboards.
	 * @param {Object} config Configuration object:
	 * @param {String} config.dashboardId Id of dashboard.
	 * @param {Function} config.success Called on success.
	 * @param {Function} config.failure Called on failure.
	 * @param {Object} config.scope Value of 'this' in the above functions.
	 */
	loadStructure: function(config) {
		BPMSoft.AnalyticsService.getDashboardViewConfig({
			id: config.dashboardId,
			groupId: BPMSoft.configuration.consts.DashboardRequestsGroupId,
			success: config.success,
			failure: config.failure,
			scope: config.scope
		});
	},

	/**
	 * Loads information of dashboards.
	 * @param {Object} config Configuration object:
	 * @param {String} config.sectionId Id of section.
	 * @param {Function} config.success Called on success.
	 * @param {Function} config.failure Called on failure.
	 * @param {Object} config.scope Value of 'this' in the above functions.
	 */
	loadRecords: function(config) {
		var sectionId = config.sectionId || BPMSoft.SysModuleId.Dashboard;
		var filters = Ext.create("BPMSoft.Filter", {
			property: "Section",
			value: sectionId
		});
		var proxy = BPMSoft.DataUtils.getOnlineProxy();
		BPMSoft.DataUtils.loadRecords({
			modelName: "SysDashboard",
			columns: ["Id", "Caption"],
			orderByColumns: [{column: "Caption", orderType: BPMSoft.OrderTypes.ASC}],
			filters: filters,
			proxy: proxy,
			isCancelable: true,
			success: function(records, operation) {
				Ext.callback(config.success, config.scope, [records, operation]);
			},
			failure: function(exception) {
				Ext.callback(config.failure, config.scope, [exception]);
			},
			scope: this
		});
	},

	/**
	 * Loads dashboard item.
	 * @param {Object} config Configuration object:
	 * @param {SysDashboard} config.sysDashboardRecord Instance of model.
	 * @param {String} config.itemName Dashboard's item name.
	 * @param {Function} config.success Called on success.
	 * @param {Function} config.failure Called on failure.
	 * @param {Object} config.scope Value of 'this' in the above functions.
	 */
	loadDashboardItem: function(config) {
		BPMSoft.AnalyticsService.getDashboardItemData({
			dashboardId: config.sysDashboardRecord.getPrimaryColumnValue(),
			groupId: BPMSoft.configuration.consts.DashboardRequestsGroupId,
			itemName: config.itemName,
			timeZoneOffset: -BPMSoft.util.getCurrentTimezoneOffsetInMinutes(),
			success: config.success,
			failure: config.failure,
			scope: config.scope
		});
	}

});
