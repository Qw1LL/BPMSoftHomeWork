define("WebServiceWizardWebComponent", ["web-service-proxy-component"], function() {
	Ext.define("BPMSoft.controls.WebServiceWizardWebComponent", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.WebServiceWizardWebComponent",

		/**
		 * @inheritDoc BPMSoft.Component#tpl
		 * @override
		 */
		tpl: [
			/*jshint white:false */
			/*jshint quotmark:true */
			//jscs:disable
			'<div id="{id}-wrap" style="{wrapStyle}" class="{wrapClass}">',
				'<ts-web-service-proxy id="{id}">',
				'</ts-web-service-proxy>',
			'</div>'
			//jscs:enable
			/*jshint quotmark:false */
			/*jshint white:true */
		],

		/**
		 * @inheritDoc BPMSoft.Component#getSelectors
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				webserviceProxyEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc BPMSoft.Component#init
		 * @override
		 */
		init: function() {
			this.callParent(arguments);
			this.subscribeEvents();
		},

		/**
		 * @protected
		 * @virtual
		 */
		subscribeEvents: function() {
			// this.addEvents();
		},

		/**
		 * @inheritDoc BPMSoft.Component#initDomEvents
		 * @override
		 */
		initDomEvents: function() {
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc BPMSoft.Component#clearDomListeners
		 * @override
		 */
		clearDomListeners: function() {
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc BPMSoft.Component#getTplData
		 * @override
		 */
		getTplData: function() {
			this.selectors = this.getSelectors();
			const tplData = this.callParent(arguments);
			tplData.wrapStyle = {
				display: "none"
			};
			return tplData;
		},

		/**
		 * @inheritDoc BPMSoft.Component#getBindConfig
		 * @override
		 */
		getBindConfig: function() {
			return this.callParent(arguments);
		}
	});

	return BPMSoft.WebServiceWizardWebComponent;
});
