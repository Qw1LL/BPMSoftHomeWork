/**
 * @class BPMSoft.AnalyticsServiceResponseParser
 * Parses response from AnalyticsService.
 */
Ext.define("BPMSoft.configuration.service.AnalyticsServiceResponseParser", {
	alternateClassName: "BPMSoft.AnalyticsServiceResponseParser",
	singleton: true,

	/**
	 * @private
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
	 * @private
	 */
	convertData: function(dataRow, columnConfigs) {
		var result = {};
		var columns = Object.keys(dataRow);
		for (var i = 0, ln = columns.length; i < ln; i++) {
			var columnName = columns[i];
			var value = dataRow[columnName];
			var columnConfig = columnConfigs[columnName];
			if (columnConfig) {
				var dataValueType = columnConfig.dataValueType;
				if (dataValueType === BPMSoft.DataValueType.Lookup && Ext.isObject(value)) {
					value.referenceSchemaName = columnConfig.referenceSchemaName;
				} else {
					value = this.parseValue(value, dataValueType);
				}
			}
			result[columnName] = value;
		}
		return result;
	},

	/**
	 * @private
	 */
	parseColumnConfigs: function(columnConfigs) {
		var result = {};
		for (var i = 0, ln = columnConfigs.length; i < ln; i++) {
			var columnConfig = columnConfigs[i];
			var columnName = this.getColumnConfigName(columnConfig);
			result[columnName] = columnConfig;
		}
		return result;
	},

	/**
	 * @private
	 */
	getColumnConfigName: function(columnConfig) {
		return columnConfig.bindTo || columnConfig.metaPath;
	},

	/**
	 * Parses data.
	 * @param {Array} data Data section in response from AnalyticsService.
	 * @param {Object} columnConfigs Parsed 'columns' section in response from AnalyticsService.
	 */
	parseData: function(data, columnConfigs) {
		var parsedData = [];
		columnConfigs = this.parseColumnConfigs(columnConfigs);
		for (var i = 0, ln = data.length; i < ln; i++) {
			var row = data[i];
			var parsedRow = this.convertData(row, columnConfigs);
			parsedData.push(parsedRow);
		}
		return parsedData;
	}

});
