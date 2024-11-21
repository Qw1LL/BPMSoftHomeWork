/**
 * @class BPMSoft.configuration.IndicatorDashboardItem
 * Dashboard item that displays indicator widget.
 */
Ext.define("BPMSoft.configuration.controls.IndicatorDashboardItem", {
	extend: "BPMSoft.configuration.controls.BaseDashboardItem",
	alternateClassName: "BPMSoft.IndicatorDashboardItem",

	config: {

		/**
		 * @cfg {String} value Value.
		 */
		value: null,

		/**
		 * @cfg {String} format Format of value.
		 */
		format: null,

		/**
		 * @cfg {BPMSoft.DataValueType} dataValueType Data value type.
		 */
		dataValueType: null,

		/**
		 * @inheritdoc
		 */
		cssSuffix: "indicator",

		/**
		 * @inheritdoc
		 */
		fullscreenButton: true,

		/**
		 * @inheritdoc
		 */
		configGeneratorClassName: "BPMSoft.IndicatorDashboardConfigGenerator"

	},

	/**
	 * @property
	 * @private
	 */
	indicatorComponent: null,

	/**
	 * @deprecated
	 */
	defaultFormat: null,

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	createConfigGenerator: function(config) {
		config = Ext.applyIf(config || {}, {
			format: this.getFormat()
		});
		return this.callParent([config]);
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-applier
	 */
	applyValue: function(value) {
		return this.convertValue(value, this.getDataValueType());
	},

	/**
	 * @protected
	 * @virtual
	 * @cfg-updater
	 */
	updateValue: function(value) {
		if (this.indicatorComponent) {
			Ext.destroy(this.indicatorComponent);
		}
		this.indicatorComponent = Ext.create("BPMSoft.IndicatorDashboardComponent", {
			value: value
		});
		this.innerHtmlElement.appendChild(this.indicatorComponent.element);
	}

});
