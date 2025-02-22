﻿/* globals SysDashboard: false */
Ext.define("RecentDashboardsModel", {
	extend: "Ext.data.Model",
	config: {
		idProperty: "Id",
		fields: ["Id", "Caption", "Group", "Order"]
	}
});

Ext.define("BPMSoft.configuration.controller.DashboardPage", {
	extend: "BPMSoft.controller.BaseConfigurationPage",

	statics: {
		Model: SysDashboard
	},

	inheritableStatics: {

		/**
		 * @inheritdoc
		 * @protected
		 * @overridden
		 */
		isCacheable: function() {
			return false;
		}

	},

	config: {
		refs: {
			view: "#MobileDashboardPage"
		},
		control: {
			view: {
				dashboardactivated: "onDashboardActivated",
				requestitem: "onDashboardItemRequested",
				refreshbuttontap: "onRefreshButtonTap",
				pullrefresh: "onPullRefresh",
				dashboardpickerselect: "onDashboardPickerSelect",
				dashboarditemfullscreenbuttontap: "onDashboardItemFullscreenButtonTap",
				dashboarditemrecordlinktap: "onDashboardItemRecordLinkTap"
			}
		}
	},

	/**
	 * @private
	 */
	profileData: null,

	/**
	 * @protected
	 */
	areLookupsLoaded: true,

	/**
	 * @protected
	 */
	records: null,

	/**
	 * @protected
	 */
	recentDashboardsLimit: 5,

	/**
	 * @private
	 */
	sysDashboardRecord: null,

	/**
	 * @private
	 */
	getDashboardPickerStore: function() {
		if (!this.profileData.recentDashboards) {
			this.profileData.recentDashboards = [];
		}
		var recentDashboards = this.profileData.recentDashboards;
		var pickerRecords = [];
		if (Ext.isArray(this.records)) {
			for (var i = 0, ln = this.records.length; i < ln; i++) {
				var record = this.records[i];
				var id = record.getPrimaryColumnValue();
				var group = 2;
				var order = i;
				if (Ext.Array.contains(recentDashboards, id)) {
					group = 1;
					order = recentDashboards.indexOf(id);
				}
				pickerRecords.push({
					Caption: record.getPrimaryDisplayColumnValue(),
					Id: id,
					Group: group,
					Order: order
				});
			}
		}
		return Ext.create("Ext.data.Store", {
			model: "RecentDashboardsModel",
			data: pickerRecords,
			sorters: [
				{
					property : "Order",
					direction: "ASC"
				}
			],
			grouper: {
				property: "Group"
			}
		});
	},

	/**
	 * @private
	 */
	saveRecentDashboards: function() {
		var dashboardId = this.profileData.dashboardId;
		var recentDashboards = this.profileData.recentDashboards;
		var index = recentDashboards.indexOf(dashboardId);
		if (index !== -1) {
			recentDashboards.splice(index, 1);
		}
		recentDashboards.splice(0, 0, dashboardId);
		recentDashboards.splice(this.recentDashboardsLimit, recentDashboards.length);
	},

	/**
	 * @private
	 */
	loadSysDashboardProfileData: function(config) {
		BPMSoft.MobileProfileManager.loadData({
			key: "SysDashboard",
			success: function(profileData) {
				if (profileData) {
					profileData = Ext.JSON.decode(profileData.get("Value"), true);
				} else {
					profileData = {};
				}
				this.profileData = profileData;
				Ext.callback(config.callback, config.scope);
			},
			failure: function() {
				var profileData = {};
				this.profileData = profileData;
				Ext.callback(config.callback, config.scope);
			},
			scope: config.scope
		});
	},

	/**
	 * @private
	 */
	saveSysDashboardProfileData: function() {
		var profileData = this.profileData;
		var profileValue = Ext.JSON.encode(profileData);
		BPMSoft.MobileProfileManager.saveData({
			key: "SysDashboard",
			value: profileValue
		});
	},

	/**
	 * @private
	 */
	updateViewByException: function(config) {
		var exception = config.exception;
		if (exception instanceof BPMSoft.AbortRequestException) {
			var dashboardContainer = config.dashboardContainer;
			if (dashboardContainer.getItemsStatus() !== BPMSoft.DashboardContainerItemsStatus.NotLoaded) {
				dashboardContainer.setItemsStatus(BPMSoft.DashboardContainerItemsStatus.NotLoaded);
			}
		}
	},

	/**
	 * Returns id of record.
	 * @protected
	 * @return Id of record.
	 */
	getRecordById: function(recordId) {
		return BPMSoft.Array.find(this.records, function(record) {
			return record.getId() === recordId;
		});
	},

	/**
	 * Shows picker for select dashboars.
	 * @protected
	 * @virtual
	 * @return {BPMSoft.LookupPicker} Instance of picker.
	 */
	showDashboardPicker: function() {
		var view = this.getView();
		var dashboardPicker = view.getDashboardPicker();
		var pickerList = dashboardPicker.getComponent();
		var pickerStore = this.getDashboardPickerStore();
		pickerList.setStore(pickerStore);
		var selectedRecord = pickerStore.getById(this.profileData.dashboardId);
		if (selectedRecord) {
			pickerList.select(selectedRecord, false, true);
		}
		if (!dashboardPicker.getParent()) {
			Ext.Viewport.add(dashboardPicker);
		}
		dashboardPicker.clearSearchValue();
		dashboardPicker.show();
	},

	/**
	 * Called when dashboard item is selected in picker.
	 * @protected
	 * @virtual
	 * @param {RecentDashboardsModel} pickerRecord Instance of model.
	 */
	onDashboardPickerSelect: function(pickerRecord) {
		var id = pickerRecord.getId();
		for (var i = 0, ln = this.records.length; i < ln; i++) {
			var record = this.records[i];
			if (record.getPrimaryColumnValue() === id) {
				var view = this.getView();
				view.setActiveDashboard(i);
				break;
			}
		}
		this.profileData.dashboardId = id;
		this.saveRecentDashboards();
		this.saveSysDashboardProfileData();
	},

	/**
	 * Subscribes on title tap event.
	 * @protected
	 * @virtual
	 */
	initializeTitle: function() {
		var view = this.getView();
		var navigationPanel = view.getNavigationPanel();
		var title = navigationPanel.getTitle();
		title.element.on("tap", this.onTitleElementTap, this);
	},

	/**
	 * Called when page title has been tapped.
	 * @protected
	 * @virtual
	 * @param {Event} event Event.
	 */
	onTitleElementTap: function(event) {
		this.showDashboardPicker();
		event.stopEvent();
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "dashboard-picker"
			}
		});
	},

	/**
	 * Called when dashboard structure is loaded.
	 * @protected
	 * @virtual
	 * @param {BPMSoft.BaseModel[]} records Instances of model.
	 */
	onDashboardRecordsLoaded: function(records) {
		var view = this.getView();
		this.records = records;
		view.setDashboards(records, this.profileData.dashboardId);
		var loadDataCounterKey = this.getLoadDataCounterKey();
		BPMSoft.PerformanceCounter.stop(loadDataCounterKey);
		this.trackAnalyticsEvent({
			properties: {
				DashboardsCount: records.length
			}
		});
	},

	/**
	 * Called when dashboard is activated.
	 * @protected
	 * @virtual
	 * @param {Number} index Index of dashboard.
	 * @param {BPMSoft.configuration.DashboardContainer} dashboardContainer Instance of dashboard container.
	 */
	onDashboardActivated: function(index, dashboardContainer) {
		var dashboardId = this.profileData.dashboardId = dashboardContainer.getItemId();
		this.sysDashboardRecord = this.getRecordById(dashboardId);
		this.saveSysDashboardProfileData();
		if (dashboardContainer.getItemsStatus() !== BPMSoft.DashboardContainerItemsStatus.Loaded) {
			this.loadDashboardDataIntoContainer(index, dashboardContainer);
		}
	},

	/**
	 * Called when dashboard item is requested.
	 * @protected
	 * @virtual
	 * @param {BPMSoft.configuration.view.DashboardPage} view View.
	 * @param {BPMSoft.BaseModel} sysDashboardRecord Instance of model.
	 * @param {String} itemName Name of dashboard.
	 */
	onDashboardItemRequested: function(config) {
		var view = config.view;
		var sysDashboardRecord = config.sysDashboardRecord;
		var itemName = config.itemName;
		this.loadDashboardItem({
			sysDashboardRecord: sysDashboardRecord,
			itemName: itemName,
			dashboardContainer: config.dashboardContainer,
			success: function(data) {
				view.setDashboardItemData(sysDashboardRecord, itemName, data);
			},
			failure: function(exception) {
				view.setDashboardItemData(sysDashboardRecord, itemName, null);
				BPMSoft.Logger.logException(BPMSoft.LogSeverityLevel.Error, exception);
			},
			scope: this
		});
	},

	/**
	 * Called when fullscreen button in dashboard item is tapped.
	 * @protected
	 * @virtual
	 */
	onDashboardItemFullscreenButtonTap: function(dashboardItem, itemName) {
		var controllerName;
		var viewXClass;
		if (dashboardItem instanceof BPMSoft.ChartDashboardItem) {
			controllerName = "BPMSoft.controller.ChartDashboardItemPage";
			viewXClass = "BPMSoft.view.ChartDashboardItemPage";
		} else if (dashboardItem instanceof BPMSoft.IndicatorDashboardItem) {
			controllerName = "BPMSoft.controller.IndicatorDashboardItemPage";
			viewXClass = "BPMSoft.view.IndicatorDashboardItemPage";
		} else {
			return;
		}
		BPMSoft.util.openPage({
			controllerName: controllerName,
			viewXClass: viewXClass,
			sysDashboardRecord: this.sysDashboardRecord,
			pagePosition: BPMSoft.PagePosition.Primary,
			itemName: itemName
		});
	},

	/**
	 * Called when record link of dashboard item has been tapped.
	 * @protected
	 * @virtual
	 * @param {String} modelName Name of model.
	 * @param {String} recordId Record id.
	 */
	onDashboardItemRecordLinkTap: function(modelName, recordId) {
		if (recordId && modelName) {
			BPMSoft.util.openPreviewPage(modelName, {
				recordId: recordId,
				isStartRecord: true
			});
		}
	},

	/**
	 * Called when refresh button has been tapped.
	 * @protected
	 * @virtual
	 */
	onRefreshButtonTap: function() {
		if (!this.records) {
			this.loadData();
		} else {
			this.refreshActiveDashboardData();
		}
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Tap,
			properties: {
				control: "dashboard-refresh-button"
			}
		});
	},

	/**
	 * Called when dashboard container has been pulled to refresh.
	 * @protected
	 * @virtual
	 */
	onPullRefresh: function(view, dashboardContainer) {
		var record = this.getRecordById(dashboardContainer.getItemId());
		if (!BPMSoft.RequestManager.hasActiveRequests(BPMSoft.configuration.consts.DashboardRequestsGroupId)) {
			this.loadDashboardDataIntoContainer(record, dashboardContainer);
		} else {
			dashboardContainer.stopPullRefresh();
		}
	},

	/**
	 * Refreshes active dashboard.
	 * @protected
	 * @virtual
	 */
	refreshActiveDashboardData: function() {
		var view = this.getView();
		var index = view.getActiveDashboardIndex();
		var dashboardContainer = view.getActiveDashboardContainer();
		if (!BPMSoft.RequestManager.hasActiveRequests(BPMSoft.configuration.consts.DashboardRequestsGroupId)) {
			this.refreshDashboardData(index, dashboardContainer);
		}
	},

	/**
	 * Refreshes dashboard.
	 * @protected
	 * @virtual
	 * @param {Number} index Index of dashboard.
	 * @param {BPMSoft.configuration.DashboardContainer} dashboardContainer Instance of dashboard container.
	 */
	refreshDashboardData: function(index, dashboardContainer) {
		var dashboardRecord = this.records[index];
		if (!dashboardRecord) {
			return;
		}
		this.loadDashboardDataIntoContainer(dashboardRecord, dashboardContainer);
	},

	/**
	 * Loads data of dashboard and set to container.
	 * @protected
	 * @param {Number|BPMSoft.BaseModel} value Record or index of record.
	 * @param {BPMSoft.configuration.DashboardContainer} dashboardContainer Instance of dashboard container.
	 */
	loadDashboardDataIntoContainer: function(value, dashboardContainer) {
		if (dashboardContainer.getItemsStatus() === BPMSoft.DashboardContainerItemsStatus.Loading) {
			return;
		}
		if (Ext.isNumber(value)) {
			value = this.records[value];
		}
		BPMSoft.RequestManager.abortRequests(BPMSoft.configuration.consts.DashboardRequestsGroupId);
		dashboardContainer.setItemsStatus(BPMSoft.DashboardContainerItemsStatus.Loading);
		this.loadDashboardStructure({
			sysDashboardRecord: value,
			success: function(viewConfigItems) {
				this.setDashboardContainerConfig(dashboardContainer, value, viewConfigItems);
			},
			failure: function(exception) {
				this.updateViewByException({
					exception: exception,
					dashboardContainer: dashboardContainer
				});
				BPMSoft.Logger.logException(BPMSoft.LogSeverityLevel.Error, exception);
			},
			scope: this
		});
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	launch: function() {
		var args = arguments;
		this.loadSysDashboardProfileData({
			callback: function() {
				this.initializeTitle();
				BPMSoft.configuration.controller.DashboardPage.superclass.launch.call(this, args);
			},
			scope: this
		});
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	loadData: function() {
		this.checkConnection(function() {
			this.doLoadData();
		});
	},

	/**
	 * Checks connection and does specify behavior.
	 * @protected
	 * @virtual
	 * @param {Function} callback Callback function.
	 */
	checkConnection: function(callback) {
		var view = this.getView();
		if (!BPMSoft.Connection.isOnline()) {
			view.setNoData(true);
		} else {
			view.setNoData(false);
			Ext.callback(callback, this);
		}
	},

	/**
	 * Loads data if there is Internet connection.
	 * @protected
	 * @virtual
	 */
	doLoadData: function() {
		var loadDataCounterKey = this.getLoadDataCounterKey();
		BPMSoft.PerformanceCounter.start(loadDataCounterKey);
		this.loadDashboardRecords(function(records) {
			this.onDashboardRecordsLoaded(records);
		}, null);
	},

	/**
	 * Loads dashboards structure.
	 * @protected
	 * @param {Function} callback Callback function.
	 * @param {String} dashboardId Id of dashboard.
	 */
	loadDashboardRecords: function(callback, dashboardId) {
		BPMSoft.Mask.show();
		BPMSoft.DashboardDataManager.loadRecords({
			dashboardId: dashboardId,
			success: function(records, operation) {
				Ext.callback(callback, this, [records]);
				BPMSoft.Mask.hide();
			},
			failure: function(exception) {
				if (!(exception instanceof BPMSoft.AbortRequestException)) {
					BPMSoft.MessageBox.showException(exception);
				}
				BPMSoft.Mask.hide();
			},
			scope: this
		});
	},

	/**
	 * Track analytics of dashboard load duration.
	 * @protected
	 * @param {BPMSoft.BaseModel} sysDashboardRecord Instance of model.
	 */
	trackAnalyticsEventForDashboard: function(sysDashboardRecord) {
		var properties = {
			"DashboardName": sysDashboardRecord.getPrimaryDisplayColumnValue(),
			"TargetName": BPMSoft.PageTypes.Preview,
			"PageModelName": this.getModelName()
		};
		BPMSoft.AnalyticsManager.trackEvent({
			eventName: BPMSoft.AnalyticsManagerEventNames.Open,
			properties: properties
		});
	},

	/**
	 * Loads data of dashboard.
	 * @protected
	 * @param {Object} config Configuration object:
	 * @param {BPMSoft.BaseModel} config.sysDashboardRecord Instance of model.
	 * @param {Function} config.success Called on success.
	 * @param {Function} config.failure Called on failure.
	 * @param {Object} config.scope Value of 'this' in the above functions.
	 */
	loadDashboardStructure: function(config) {
		var sysDashboardRecord = config.sysDashboardRecord;
		BPMSoft.DashboardDataManager.loadStructure({
			dashboardId: sysDashboardRecord.getId(),
			success: function(data) {
				Ext.callback(config.success, config.scope, [data.items]);
			},
			failure: function(exception) {
				Ext.callback(config.failure, config.scope, [exception]);
			},
			scope: this,
			useCache: false
		});
	},

	/**
	 * Loads dashboard item data.
	 * @protected
	 * @param {Object} config Configuration object:
	 * @param {BPMSoft.BaseModel} config.sysDashboardRecord Instance of model.
	 * @param {String} config.itemName Name of dashboard item.
	 * @param {Function} config.success Called on success.
	 * @param {Function} config.failure Called on failure.
	 * @param {Object} config.scope Value of 'this' in the above functions.
	 */
	loadDashboardItem: function(config) {
		BPMSoft.DashboardDataManager.loadDashboardItem({
			sysDashboardRecord: config.sysDashboardRecord,
			itemName: config.itemName,
			success: function(data) {
				Ext.callback(config.success, config.scope, [data]);
			},
			failure: function(exception) {
				this.updateViewByException({
					exception: exception,
					dashboardContainer: config.dashboardContainer
				});
				Ext.callback(config.failure, config.scope, [exception]);
			},
			scope: this
		});
	},

	/**
	 * Sets data to dashboard container.
	 * @protected
	 * @virtual
	 * @param {BPMSoft.configuration.DashboardContainer} dashboardContainer Instance of dashboard container.
	 * @param {BPMSoft.BaseModel} sysDashboardRecord Instance of model.
	 * @param {Object[]} config Configurations of layout items.
	 */
	setDashboardContainerConfig: function(dashboardContainer, sysDashboardRecord, config) {
		var view = this.getView();
		view.setDashboardConfig(dashboardContainer, sysDashboardRecord, config);
		if (dashboardContainer.getItemsStatus() === BPMSoft.DashboardContainerItemsStatus.Loading) {
			dashboardContainer.setItemsStatus(BPMSoft.DashboardContainerItemsStatus.Loaded);
		}
		this.trackAnalyticsEventForDashboard(sysDashboardRecord);
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	cancelAllAsyncOperations: function() {
		this.callParent(arguments);
		BPMSoft.RequestManager.abortRequests(BPMSoft.configuration.consts.DashboardRequestsGroupId);
	}

});
