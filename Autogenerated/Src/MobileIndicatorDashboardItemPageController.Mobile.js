/**
 * @class BPMSoft.configuration.controller.IndicatorDashboardItemPage
 */
Ext.define("BPMSoft.configuration.controller.IndicatorDashboardItemPage", {
	extend: "BPMSoft.controller.DashboardItemPage",
	alternateClassName: "BPMSoft.controller.IndicatorDashboardItemPage",

	config: {
		refs: {
			view: "#IndicatorDashboardItemPage"
		}
	},

	//region Properties: Protected

	/**
	 * @inheritdoc
	 * @overridden
	 */
	gridDataServiceName: "getIndicatorGridData",

	/**
	 * @inheritdoc
	 * @overridden
	 */
	gridDataConfigServiceName: "getIndicatorGridDataConfig",

	//endregion

	//region Methods: Private

	/**
	 * @private
	 */
	getIndicatorValue: function(metadata) {
		var configGenerator = Ext.create("BPMSoft.IndicatorDashboardConfigGenerator", {
			format: metadata.format
		});
		return configGenerator.convertValue(metadata.data, metadata.dataValueType);
	},

	//endregion

	//region Methods: Protected

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	generateDashboardItemConfig: function(metadata) {
		return {
			value: this.getIndicatorValue(metadata),
			style: metadata.style || BPMSoft.DefaultDashboardStyle
		};
	}

	//endregion

});
