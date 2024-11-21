  define("ChartWidgetComponent", ["BaseWidgetComponent"], function() {
	/**
	 * Component for rendering chart widget component.
	 */
	Ext.define("BPMSoft.controls.ChartWidgetComponent", {
		extend: "BPMSoft.controls.BaseWidgetComponent",
		alternateClassName: "BPMSoft.ChartWidgetComponent",

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="crt-chart-widget-wrapper">',
			'<crt-chart-widget-component id="{id}" class="chart-widget" data-qa="chart-widget">',
			'</crt-chart-widget-component>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		]

	});

	return BPMSoft.ChartWidgetComponent;

});
