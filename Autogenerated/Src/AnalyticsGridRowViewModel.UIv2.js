define("AnalyticsGridRowViewModel", ["ext-base", "AnalyticsGridRowViewModelResources", "BaseGridRowViewModel"],
		function(Ext, resources) {
	/**
	 * @class BPMSoft.configuration.AnalyticsGridRowViewModel
	 */
	Ext.define("BPMSoft.configuration.AnalyticsGridRowViewModel", {
		extend: "BPMSoft.BaseGridRowViewModel",
		alternateClassName: "BPMSoft.AnalyticsGridRowViewModel",

		isChartActionsButtonVisible: function() {
			return this.get("chartActionsButtonVisible");
		},

		/**
		 * @inheritdoc BPMSoft.configuration.BaseGridRowViewModel#initResources
		 */
		initResources: function(strings) {
			strings = strings || {};
			this.callParent([Ext.apply(BPMSoft.deepClone(strings), resources.localizableStrings)]);
		}
	});

	return BPMSoft.AnalyticsGridRowViewModel;
});
