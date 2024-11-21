define("AbstractChartProvider", [], function() {
	Ext.define("BPMSoft.configuration.AbstractChartProvider", {
		extend: "BPMSoft.BaseObject",
		alternateClassName: "BPMSoft.AbstractChartProvider",

		/**
		 * Chart provider name.
		 * @protected
		 * @type {String}
		 */
		chartProviderName: "",
		
		/**
		 * Initial config.
		 * @protected
		 * @type {Object}
		 */
		config: null,

		/**
		 * Instance of the char object of native library.
		 * @protected
		 */
		component: null,

		/**
		 * @inheritDoc
		 */
		constructor: function() {
			this.callParent(arguments);
			this.init();
			this.setProviderName();
		},

		/**
		 * @abstract
		 */
		init: BPMSoft.abstractFn,

		/**
		 * @abstract
		 */
		setYAxisCaption: BPMSoft.abstractFn,

		/**
		 * @abstract
		 */
		setXAxisCaption: BPMSoft.abstractFn,

		/**
		 * @abstract
		 */
		setType: BPMSoft.abstractFn,

		/**
		 * @abstract
		 */
		updateSize: BPMSoft.abstractFn,

		/**
		 * @abstract
		 */
		setChartConfig: BPMSoft.abstractFn,
		
		/**
		 * @protected
		 */
		setProviderName: function() {
			const chartWrapper = document.getElementById(this.config.chart.renderTo);
			const chartWrapperParent = chartWrapper && chartWrapper.parentElement;
			if (chartWrapperParent) {
				chartWrapperParent.setAttribute("chart-provider", this.chartProviderName);
			}
		},
		
		render: function() {
			this.component.render();
		},

		destroy: function() {
			this.component.destroy();
		},

	});
	return {};
});
