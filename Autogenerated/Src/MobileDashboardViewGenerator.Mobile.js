/**
 * @class BPMSoft.configuration.DashboardViewGenerator
 */
Ext.define("BPMSoft.configuration.DashboardViewGenerator", {
	alternateClassName: "BPMSoft.DashboardViewGenerator",

	config: {

		/**
		 * @cfg {BPMSoft.DashboardContainerItemsStatus} Default dashboard container items status.
		 */
		defaultItemsStatus: null,

		/**
		 * @cfg {Number} defaultRowHeight Default row height.
		 */
		defaultRowHeight: 50,

		/**
		 * @cfg {Object} Layout configs.
		 */
		layoutConfigs: null,

		/**
		 * @cfg {Object} Event listeners of items.
		 */
		itemListeners: null

	},

	//region Constructors: Public

	constructor: function(config) {
		this.initConfig(config);
	},

	//endregion

	//region Methods: Private

	/**
	 * @private
	 */
	getLoadingItems: function(viewConfig) {
		var items = {};
		for (var i = 0, ln = viewConfig.length; i < ln; i++) {
			var itemConfig = viewConfig[i];
			items[itemConfig.name] = {
				itemId: itemConfig.name,
				xtype: "tsloadmask",
				message: BPMSoft.LocalizableStrings["Sys.DefaultMask.LoadingText"],
				stopEvent: false,
				cls: "ts-mask-flex"
			};
		}
		return items;
	},

	/**
	 * @private
	 */
	getDefaultItems: function() {
		var layoutConfigs = this.getLayoutConfigs();
		var items = {};
		if (this.getDefaultItemsStatus() === BPMSoft.DashboardContainerItemsStatus.Loading) {
			items = this.getLoadingItems(layoutConfigs);
		}
		return items;
	},

	/**
	 * @private
	 */
	getItemLayoutConfig: function(itemName) {
		var layoutConfigs = this.getLayoutConfigs();
		return BPMSoft.Array.find(layoutConfigs, function(layoutItem) {
			return layoutItem.name === itemName;
		});
	},

	//endregion

	//region Methods: Protected

	/**
	 * Returns layout config of item.
	 * @protected
	 * @virtual
	 * @param {Object} item Configuration of dashboard item.
	 * @param {Object} viewConfigItem Configuration of layout.
	 * @return {Object} Layout config with item.
	 */
	getLayoutItem: function(viewConfigItem, item) {
		var layoutItem = viewConfigItem.layout;
		layoutItem.item = item;
		layoutItem.name = viewConfigItem.name;
		if (viewConfigItem.widgetType === BPMSoft.DashboardItemWidgetType.Indicator) {
			layoutItem.halfRow = true;
		}
		if (Ext.os.is.Phone) {
			if (viewConfigItem.widgetType === BPMSoft.DashboardItemWidgetType.Gauge) {
				layoutItem.rowHeight = 300;
			} else if (viewConfigItem.widgetType === BPMSoft.DashboardItemWidgetType.Chart) {
				layoutItem.rowHeight = 350;
			}
		} else {
			layoutItem.rowHeight = this.getDefaultRowHeight();
		}
		layoutItem.cls = "cf-dashboard-item-column";
		return layoutItem;
	},

	/**
	 * Returns configuration of indicator dashboard item.
	 * @protected
	 * @virtual
	 * @param {Object} itemConfig Dashboard item data config.
	 * @return {Object} Configuration of indicator dashboard item.
	 */
	getIndicatorItem: function(itemConfig) {
		return Ext.apply({
			value: itemConfig.data,
			format: itemConfig.format,
			dataValueType: itemConfig.dataValueType,
			xclass: BPMSoft.DashboardItemClassName.Indicator
		}, this.getDefaultItemConfig(itemConfig));
	},
	/**
	 * Returns configuration of chart dashboard item.
	 * @protected
	 * @virtual
	 * @param {Object} itemConfig Dashboard item data config.
	 * @return {Object} Configuration of chart dashboard item.
	 */
	getChartItem: function(itemConfig) {
		var result =  Ext.apply({
			chartData: itemConfig.data,
			chartConfig: itemConfig.chartConfig,
			xclass: BPMSoft.DashboardItemClassName.Chart
		}, this.getDefaultItemConfig(itemConfig));
		if (!Ext.os.is.Phone) {
			var itemLayoutConfig = this.getItemLayoutConfig(itemConfig.name);
			Ext.merge(result, {
				customChartConfig: {
					maxBarRowsCount: itemLayoutConfig.rowSpan,
					maxColumnRowsCount: itemLayoutConfig.colSpan
				}
			});
		}
		return result;
	},

	/**
	 * Returns configuration of gauge dashboard item.
	 * @protected
	 * @virtual
	 * @param {Object} itemConfig Dashboard item data config.
	 * @return {Object} Configuration of gauge dashboard item.
	 */
	getGaugeItem: function(itemConfig) {
		return Ext.apply({
			chartData: [itemConfig.data],
			chartConfig: {
				seriesConfig: [{
					type: BPMSoft.ChartType.Gauge
				}],
				min: itemConfig.min,
				middleFrom: itemConfig.middleFrom,
				middleTo: itemConfig.middleTo,
				max: itemConfig.max,
				orderDirection: itemConfig.orderDirection
			},
			xclass: BPMSoft.DashboardItemClassName.Chart
		}, this.getDefaultItemConfig(itemConfig));
	},

	/**
	 * Returns configuration of grid dashboard item.
	 * @protected
	 * @virtual
	 * @param {Object} itemConfig Dashboard item data config.
	 * @return {Object} Configuration of grid dashboard item.
	 */
	getGridItem: function(itemConfig) {
		return Ext.apply({
			data: itemConfig.data,
			columns: itemConfig.columns,
			xclass: BPMSoft.DashboardItemClassName.Grid
		}, this.getDefaultItemConfig(itemConfig));
	},

	/**
	 * Returns configuration of custom dashboard item.
	 * @protected
	 * @virtual
	 * @param {Object} itemConfig Dashboard item data config.
	 * @param {String} className Class name.
	 * @return {Object} Configuration of grid dashboard item.
	 */
	getCustomItem: function(itemConfig, className) {
		return Ext.apply({
			xclass: className
		}, this.getDefaultItemConfig(itemConfig));
	},

	/**
	 * Returns configuration of default dashboard item.
	 * @protected
	 * @virtual
	 * @param {Object} itemConfig Dashboard item data config.
	 * @return {Object} Configuration of default dashboard item.
	 */
	getDefaultItem: function(itemConfig) {
		var iconCls = "cf-dashboard-not-supported-icon";
		var defaultHtml = Ext.String.format("<div class=\"{0}\"></div><span>{1}</span>", iconCls,
			BPMSoft.LS.MobileDashboardNotSupportedDashboardItem);
		return Ext.apply({
			xclass: "BPMSoft.configuration.controls.BaseDashboardItem",
			cls: "cf-dashboard-not-supported",
			html: defaultHtml
		}, this.getDefaultItemConfig(itemConfig));
	},

	/**
	 * Returns default configuration of dashboard item.
	 * @protected
	 * @virtual
	 * @param {Object} itemConfig Dashboard item data config.
	 * @return {Object} Default configuration of dashboard item.
	 */
	getDefaultItemConfig: function(itemConfig) {
		return {
			title: itemConfig.caption,
			style: itemConfig.style || BPMSoft.DefaultDashboardStyle,
			rawConfig: itemConfig,
			listeners: this.getItemListeners()
		};
	},

	/**
	 * Returns configuration of failed dashboard item.
	 * @protected
	 * @virtual
	 * @return {Object} Configuration of failed dashboard item.
	 */
	getDataNotAvailableItem: function() {
		return {
			xclass: "BPMSoft.configuration.controls.BaseDashboardItem",
			cls: "cf-dashboard-item-failed",
			html: BPMSoft.LS.MobileDashboardItemDataNotAvailable
		};
	},

	//endregion

	//region Methods: Public

	/**
	 * Gets configuration of dashboard container.
	 * @protected
	 * @virtual
	 * @return {Object} Configuration of dashboard container.
	 */
	generateContainer: function(shouldGenerateLayoutItems) {
		var config =  {
			xclass: "BPMSoft.configuration.DashboardContainer",
			scrollable: {
				direction: "vertical",
				directionLock: true
			}
		};
		if (shouldGenerateLayoutItems) {
			config.items = this.generateLayoutItems();
		}
		return config;
	},

	/**
	 * Gets layout items for dashboard container.
	 * @param {Object[]} items List of items.
	 */
	generateLayoutItems: function(items) {
		var layoutConfigs = this.getLayoutConfigs();
		if (!items) {
			items = this.getDefaultItems();
		}
		var layoutItems = [];
		for (var i = 0, ln = layoutConfigs.length; i < ln; i++) {
			var layoutConfig = layoutConfigs[i];
			var item = items[layoutConfig.name];
			if (item && (!Ext.os.is.Phone || BPMSoft.DashboardUtils.getIsSupported(layoutConfig.widgetType))) {
				var layoutItem = this.getLayoutItem(layoutConfig, item);
				layoutItems.push(layoutItem);
			}
		}
		BPMSoft.DashboardUtils.sortGridLayoutItems(layoutItems);
		if (Ext.os.is.Phone) {
			layoutItems = BPMSoft.DashboardUtils.adaptGridLayoutIntoPhoneLayout(layoutItems, 24);
		}
		return layoutItems;
	},

	/**
	 * Returns configuration of dashboard item by widget type.
	 * @param {Object} itemConfig Dashboard item data config.
	 * @return {Object} Configuration of dashboard item.
	 */
	generateItem: function(itemConfig) {
		switch (itemConfig.widgetType) {
			case BPMSoft.DashboardItemWidgetType.Indicator:
				return this.getIndicatorItem(itemConfig);
			case BPMSoft.DashboardItemWidgetType.Chart:
				return this.getChartItem(itemConfig);
			case BPMSoft.DashboardItemWidgetType.Gauge:
				return this.getGaugeItem(itemConfig);
			case BPMSoft.DashboardItemWidgetType.DashboardGrid:
				return this.getGridItem(itemConfig);
			default:
				var customClassName = BPMSoft.DashboardUtils.getCustomWidgetClassName(itemConfig.widgetType);
				if (customClassName !== null) {
					return this.getCustomItem(itemConfig, customClassName);
				} else {
					return Ext.os.is.Phone ? null : this.getDefaultItem(itemConfig);
				}
		}
	}

	//endregion

});
