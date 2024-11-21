 define("FunnelWidgetComponent", ["BaseWidgetComponent"], function() {
	/**
	 * Component for rendering funnel widget component.
	 */
	Ext.define("BPMSoft.controls.FunnelWidgetComponent", {
		extend: "BPMSoft.controls.BaseWidgetComponent",
		alternateClassName: "BPMSoft.FunnelWidgetComponent",

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{styles}" class="crt-funnel-widget-wrapper">',
			'<crt-funnel-widget-component id="{id}" class="funnel-widget" data-qa="funnel-widget">',
			'</crt-funnel-widget-component>',
			'</div>',
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		]

	});

	return BPMSoft.FunnelWidgetComponent;

});
