define("FormatUtils", ["ext-base", "BPMSoft", "FormatUtilsResources"],
	function(Ext, BPMSoft, resources) {
	
		/**
		 * Returns date diff in days.
		 * @private
		 * @param {Object} dateConfig Date configuration.
		 * @param {Boolean} dateConfig.hasTimezoneOffset Date value has timezone offset.
		 * @param {DateTime} dateValue Datetime value.
		 * @return {Number} Difference between dates in days.
		 */
		function _getDateDiffDays(dateConfig, dateValue) {
			let dateDiff = 0;
			if (dateConfig && dateConfig.hasTimezoneOffset && BPMSoft.Features.getIsEnabled("DisableSmartFormatDateFix")) {
				const dateValueWithOffset = new Date();
				const timezoneOffset = dateValue.getTimezoneOffset() * BPMSoft.DateRate.MILLISECONDS_IN_MINUTE;
				dateValueWithOffset.setTime(dateValue.getTime() - timezoneOffset);
				const currentDateValueWithOffset = new Date();
				currentDateValueWithOffset.setTime(currentDateValueWithOffset.getTime() - timezoneOffset);
				dateDiff = dateDiffDays(dateValueWithOffset, currentDateValueWithOffset);
			} else {
				dateDiff = dateDiffDays(dateValue, new Date());
			}
			return dateDiff;
		}

		/**
		 * Returns formatted date difference value.
		 * @private
		 * @param {Object} dateDiff Difference of dates in dates.
		 * @param {DateTime} dateValue Datetime value.
		 * @return {Number} Formatted date difference value.
		 */
		function _getDatePart(dateDiff, dateValue) {
			const cultureSetting = BPMSoft.Resources.CultureSettings;
			let datePart = "";
			switch (dateDiff) {
				case -1:
					datePart = resources.localizableStrings.Tomorrow;
					break;
				case 0:
					datePart = resources.localizableStrings.Today;
					break;
				case 1:
					datePart = resources.localizableStrings.Yesterday;
					break;
				case 2:
					datePart = resources.localizableStrings.BeforeYesterday;
					break;
				default:
					datePart = Ext.Date.dateFormat(dateValue, cultureSetting.dateFormat);
					break;
			}
			return datePart;
		}

		/**
		 * Returns date diff in days.
		 */
		function dateDiffDays(startDate, endDate) {
			return BPMSoft.dateDiffDays(startDate, endDate);
		}

		/**
		 * Smart format of date as word.
		 * @param {Object | Date} dateConfig Date configuration information or date value.
		 * @param {Date} dateConfig.dateValue Date value.
		 * @param {Boolean} dateConfig.hasTimezoneOffset Is true if date has timezone offset.
		 */
		function smartFormatDate(dateConfig) {
			const cultureSetting = BPMSoft.Resources.CultureSettings;
			const dateValue = Ext.isObject(dateConfig) ? dateConfig.dateValue : dateConfig;
			if (dateValue) {
				const dateDiff = _getDateDiffDays(dateConfig, dateValue);
				const datePart = _getDatePart(dateDiff, dateValue);
				const timePart = Ext.Date.dateFormat(dateValue, cultureSetting.timeFormat);
				return Ext.String.format("{0} {2} {1}", datePart, timePart, resources.localizableStrings.In);
			}
			return null;
		}

		/**
		 * Returns created on caption.
		 * @returns {String}
		 */
		function getDateCaption(prefix, day, minutes) {
			return prefix + " " + day + ":" + minutes;
		}

		return {
			dateDiffDays: dateDiffDays,
			smartFormatDate: smartFormatDate,
			getDateCaption: getDateCaption
		};
	});
