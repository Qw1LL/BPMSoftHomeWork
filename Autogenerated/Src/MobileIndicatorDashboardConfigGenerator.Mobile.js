/**
 * @class BPMSoft.configuration.IndicatorDashboardConfigGenerator
 * Config generator of indicator dashboard.
 */
Ext.define("BPMSoft.configuration.IndicatorDashboardConfigGenerator", {
	extend: "BPMSoft.BaseDashboardItemConfigGenerator",
	alternateClassName: "BPMSoft.IndicatorDashboardConfigGenerator",

	config: {

		/**
		 * @cfg {String} format Format of value.
		 */
		format: null

	},

	/**
	 * @protected
	 */
	defaultFormat: {
		textDecorator: "{0}"
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	convertValue: function(value, type) {
		var result;
		var formatConfig = this.getFormat() || this.defaultFormat;
		value = this.parseValue(value, type);
		if (Ext.isEmpty(value) && BPMSoft.Number.isNumericDataValueType(type)) {
			value = 0;
		}
		if (Ext.isNumber(value)) {
			if (Ext.isEmpty(formatConfig.decimalPrecision)) {
				formatConfig.decimalPrecision = (formatConfig.type === BPMSoft.DataValueType.Integer) ? 0 : 2;
			}
			if (formatConfig.decimalPrecision === 0) {
				value = Math.round(value);
			}
			result = BPMSoft.Number.getFormattedValue(value, formatConfig);
		} else if (Ext.isDate(value)) {
			var dateFormat = formatConfig.dateFormat || BPMSoft.Date.getDateFormat();
			result = Ext.Date.format(value, dateFormat);
		} else {
			result = "";
		}
		var textDecorator = formatConfig.textDecorator;
		if (textDecorator) {
			result = Ext.String.format(textDecorator, result);
		}
		return result;
	}

});
