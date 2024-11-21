   define("IndicatorWidgetComponent", ["BaseWidgetComponent"], function() {
	/**
	 * Component for rendering indicator widget component.
	 */
	Ext.define("BPMSoft.controls.IndicatorWidgetComponent", {
		extend: "BPMSoft.controls.BaseWidgetComponent",
		alternateClassName: "BPMSoft.IndicatorWidgetComponent",

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="crt-indicator-widget-wrapper">',
			'<crt-indicator-widget-component id="{id}" class="indicator-widget" data-qa="indicator-widget">',
			'</crt-indicator-widget-component>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		]

	});

	return BPMSoft.IndicatorWidgetComponent;

});
