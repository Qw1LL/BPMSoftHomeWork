   define("BaseWidgetComponent", [], function() {
	Ext.define("BPMSoft.controls.BaseWidgetComponent", {
		extend: "BPMSoft.controls.Component",
		alternateClassName: "BPMSoft.BaseWidgetComponent",

		widgetConfig: null,

		/**
		 * @inheritDoc
		 * @override
		 */
		tpl: null,
		
		/**
		 * @inheritDoc
		 * @override
		 */
		getTplData: function() {
			const tplData = this.callParent(arguments);
			this.selectors = this.getSelectors();
			Ext.apply(tplData, {
				widgetConfig: this.widgetConfig,
			});
			return tplData;
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getSelectors: function() {
			return {
				wrapEl: "#" + this.id + "-wrap",
				widgetEl: "#" + this.id
			};
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		getBindConfig: function() {
			const bindConfig = this.callParent(arguments);
			const widgetBindConfig = {
				widgetConfig: {
					changeMethod: "setWidgetConfig"
				}
			};
			Ext.apply(widgetBindConfig, bindConfig);
			return widgetBindConfig;
		},

		setWidgetConfig: function(widgetConfig) {
			if (!widgetConfig) {
				return;
			}
			this.widgetConfig = widgetConfig;
			if (this.rendered) {
				this.setElementConfig();
			}
		},

		/**
		 * @inheritDoc
		 * @override
		 */
		onAfterRender: function() {
			this.callParent(arguments);
			if (this.widgetConfig) {
				this.setElementConfig();
			}
		},
		
		setElementConfig: function() {
			this.widgetEl.dom.config = this.widgetConfig;
		},

	});

	return BPMSoft.BaseWidgetComponent;

});
