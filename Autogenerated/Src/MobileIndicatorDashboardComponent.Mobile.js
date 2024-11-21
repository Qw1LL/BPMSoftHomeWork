/**
 * @class BPMSoft.configuration.controls.IndicatorDashboardComponent
 */
Ext.define("BPMSoft.configuration.controls.IndicatorDashboardComponent", {
	extend: "Ext.Component",
	alternateClassName: "BPMSoft.IndicatorDashboardComponent",

	config: {

		/**
		 * @cfg {String} value Value.
		 */
		value: null,

		/**
		 * @cfg {String} style Widget style.
		 */
		style: null

	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	initialize: function() {
		this.callParent(arguments);
		this.addCls("cf-indicator-dashboard-component");
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-updater
	 */
	updateStyle: function(newStyle, oldStyle) {
		var className;
		if (newStyle) {
			className = BPMSoft.DashboardUtils.getClassNameByStyle(newStyle);
			this.addCls(className);
		}
		if (oldStyle) {
			className = BPMSoft.DashboardUtils.getClassNameByStyle(oldStyle);
			this.removeCls(className);
		}
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-updater
	 */
	updateValue: function(value) {
		this.setHtml(value);
	}

});
