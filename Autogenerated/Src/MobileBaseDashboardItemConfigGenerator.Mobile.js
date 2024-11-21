/**
 * @class BPMSoft.configuration.BaseDashboardItemConfigGenerator
 * Config generator of base dashboard item.
 */
Ext.define("BPMSoft.configuration.BaseDashboardItemConfigGenerator", {
	alternateClassName: "BPMSoft.BaseDashboardItemConfigGenerator",

	//region Constructors: Public

	constructor: function(config) {
		this.initConfig(config);
	},

	//endregion

	//region Methods: Protected

	/**
	 * Parses value by type.
	 * @protected
	 * @virtual
	 * @param {*} value Value.
	 * @param {BPMSoft.DataValueType} type Data value type.
	 */
	parseValue: function(value, type) {
		if (type === BPMSoft.DataValueType.Time || type === BPMSoft.DataValueType.Date ||
			type === BPMSoft.DataValueType.DateTime) {
			if (Ext.isEmpty(value)) {
				value = null;
			} else {
				value = BPMSoft.Date.parseDateValue(value);
			}
		}
		return value;
	},

	/**
	 * Converts value to string depends on data value type.
	 * @protected
	 * @virtual
	 * @param {*} value Value.
	 * @param {BPMSoft.DataValueType} type Data value type.
	 * @return {String} String value.
	 */
	convertValue: function(value, type) {
		value = this.parseValue(value, type);
		return BPMSoft.String.getTypedValue(value, type);
	},

	/**
	 * Returns sortable value.
	 * @protected
	 * @virtual
	 * @param {*} value Value.
	 * @param {BPMSoft.DataValueType} type Data value type.
	 * @return {*} Sortable value.
	 */
	getSortableValue: function(value, type) {
		value = this.parseValue(value, type);
		if (type === BPMSoft.DataValueType.Lookup) {
			return BPMSoft.String.getTypedValue(value, type);
		} else {
			if (Ext.isDate(value)) {
				value = value.getTime();
			}
			return value;
		}
	}

	//endregion

});
