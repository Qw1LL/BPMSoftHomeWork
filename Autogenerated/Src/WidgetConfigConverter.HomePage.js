 define("WidgetConfigConverter", [], function() {
	Ext.define("BPMSoft.configuration.WidgetConfigConverter", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.WidgetConfigConverter",

		statics: {

			/**
			 * @private
			 */
			 _dateTimeFormatRegExpMap: {
				 ext: new RegExp(/(\\)?(j|d|D|l|n|m|M|F|y|Y|a|A|g|G|h|H|i|s|S)|./, "g"),
				 moment: new RegExp(/(\\)?(DD?|dddd?|MM?M?M?|YYY?Y?|a|A|hh?|HH?|mm|ss|S)|./, "g")
			 },

			/**
			 * @private
			 */
			_dateTimeFormatTokensMapping: [
				{
					ext: "j", // Day of Month: 1 2 ... 30 31
					moment: "D"
				},
				{
					ext: "d", // Day of Month: 01 02 ... 30 31
					moment: "DD"
				},
				{
					ext: "D", // Day of Week: Sun Mon ... Fri Sat
					moment: "ddd"
				},
				{
					ext: "l", // Day of Week: Sunday Monday ... Friday Saturday
					moment: "dddd"
				},
				{
					ext: "n", // Month: 1 2 ... 11 12
					moment: "M"
				},
				{
					ext: "m", // Month: 01 02 ... 11 12
					moment: "MM"
				},
				{
					ext: "M", // Month: Jan Feb ... Nov Dec
					moment: "MMM"
				},
				{
					ext: "F", // Month: January February ... November December
					moment: "MMMM"
				},
				{
					ext: "y", // Year: 70 71 ... 29 30
					moment: "YY"
				},
				{
					ext: "Y", // Year: 1970 1971 ... 2029 2030
					moment: "YYYY"
				},
				{
					ext: "a", // AM/PM: am pm
					moment: "a"
				},
				{
					ext: "A", // AM/PM: AM PM
					moment: "A"
				},
				{
					ext: "g", // Hour: 1 2 ... 11 12 (12-hour format)
					moment: "h"
				},
				{
					ext: "G", // Hour: 0 1 ... 22 23 (24-hour format)
					moment: "H"
				},
				{
					ext: "h", // Hour: 01 02 ... 11 12 (12-hour format)
					moment: "hh"
				},
				{
					ext: "H", // Hour: 00 01 ... 22 23 (24-hour format)
					moment: "HH"
				},
				{
					ext: "i", // Minute: 00 01 ... 58 59
					moment: "mm"
				},
				{
					ext: "s", // Second: 00 01 ... 58 59
					moment: "ss"
				}
			],

			/**
			 * @private
			 */
			 _getDateTimeRegExp: function(specification) {
				const regExp = this._dateTimeFormatRegExpMap[specification];
				if(regExp) {
					return regExp;
				}
				throw `The '${specification}' date-time specification is not supported.`;
			},

			/**
			 * @private
			 */
			_getDateTimeFormatTokensMap: function(fromSpecification, toSpecification) {
				const dateTimeFormatTokensMap = {};
				this._dateTimeFormatTokensMapping.forEach(function(tokenMapping) {
					const fromToken = tokenMapping[fromSpecification];
					const toToken = tokenMapping[toSpecification];
					dateTimeFormatTokensMap[fromToken] = toToken;
				});
				return dateTimeFormatTokensMap;
			},

			/**
			 * Conveters a specified date-time format from one specification to another.
			 * @param {String} source The date-time format in the "fromSpecification" specification.
			 * @param {String} fromSpecification "ext" or "moment"
			 * @param {String} toSpecification "ext" or "moment"
			 * @return {String} The date-time format in the "toSpecification" specification.
			 */
			convertDateTimeFormat: function(source, fromSpecification, toSpecification) {
				const tokensMap = this._getDateTimeFormatTokensMap(fromSpecification, toSpecification);
				const fromTokenRegExp = this._getDateTimeRegExp(fromSpecification);
				const fromSourceTokens = source.match(fromTokenRegExp);
				return fromSourceTokens
					.map(function(token) {
						return tokensMap.hasOwnProperty(token) ? tokensMap[token] : token;
					})
					.join('');
			}
		},
	});
	return BPMSoft.WidgetConfigConverter;
});
