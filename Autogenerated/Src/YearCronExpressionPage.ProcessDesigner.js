﻿define("YearCronExpressionPage", ["YearCronExpressionPageResources",
	"css!ProcessTimerStartEventPropertiesPageCSS"], function(resources) {
	return {
		attributes: {

			/**
			 * Year period month attribute.
			 * @private
			 * @type {Object}
			 */
			"YearPeriodMonths": {
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				"value": {
					"value": 1,
					"displayValue": resources.localizableStrings.MonthJanuaryCaption
				},
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Flag that indicates yearly run at specific day of specific month.
			 * @private
			 * @type {Boolean}
			 */
			"IsOrdinalRun": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": true,
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Weekday numbers.
			 * @private
			 * @type {Object}
			 */
			"OrdinalWeekdayCollection": {
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				"value": {
					"value": 1,
					"displayValue": resources.localizableStrings.WeekDayNumberFirst
				},
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Weekday names.
			 * @private
			 * @type {Object}
			 */
			"WeekdayCollection": {
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				"value": {
					"value": 1,
					"displayValue": BPMSoft.Resources.CultureSettings.shortDayNames[0]
				},
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Month names for weekday number option.
			 * @private
			 * @type {Object}
			 */
			"YearPeriodOrdinalMonths": {
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				"value": {
					"value": 1,
					"displayValue": resources.localizableStrings.MonthJanuaryCaption
				},
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Year period's run day.
			 * @private
			 * @type {Number}
			 */
			"YearPeriodDayOfMonth": {
				"dataValueType": this.BPMSoft.DataValueType.NUMBER,
				"value": 1,
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Trigger time for year period timer.
			 * @private
			 * @type {Time}
			 */
			"YearPeriodTriggerTime": {
				"dataValueType": this.BPMSoft.DataValueType.TIME,
				"value": new Date(0, 0, 0, 0, 0),
				"onChange" : "onCronExpressionPartChange"
			}
		},
		methods: {

			/**
			 * Saves year period trigger date.
			 * @private
			 * @param {Object} cron Cron expression.
			 */
			_saveYearTriggerDate: function(cron) {
				var isMonthDay = this.get("IsOrdinalRun");
				if (isMonthDay) {
					this._saveMonthDayPeriodType(cron);
				} else {
					this._saveWeekdayNumberPeriodType(cron);
				}
			},

			/**
			 * Saves weekday number period type.
			 * @private
			 * @param {Object} cron Cron expression.
			 */
			_saveWeekdayNumberPeriodType: function(cron) {
				var weekDayNumber = this.get("OrdinalWeekdayCollection");
				var weekDayName = this.get("WeekdayCollection");
				var month = this.get("YearPeriodOrdinalMonths");
				cron.setWeekDayOrdinalInfo(weekDayName.value, weekDayNumber.value);
				cron.setParameter(BPMSoft.cron.Parameters.Month, month.value);
			},

			/**
			 * Saves month day period type.
			 * @private
			 * @param {Object} cron Cron expression.
			 */
			_saveMonthDayPeriodType: function(cron) {
				var day = this.get("YearPeriodDayOfMonth");
				var month = this.get("YearPeriodMonths");
				cron.setParameter(BPMSoft.cron.Parameters.DayOfMonth, day);
				cron.setParameter(BPMSoft.cron.Parameters.Month, month.value);
			},

			/**
			 * Saves year period trigger time.
			 * @private
			 * @param {Object} cron Cron expression.
			 */
			_saveYearTriggerTime: function(cron) {
				var triggerTime = this.get("YearPeriodTriggerTime");
				var startTime = this.getValidDateTime(triggerTime);
				cron.setStartTime(startTime);
			},

			/**
			 * Initializes year month day period.
			 * @private
			 * @param {Object} cron Cron expression.
			 */
			_initYearMonthlyPeriodType: function(cron) {
				var day = cron.getParameter(BPMSoft.cron.Parameters.DayOfMonth) || 1;
				this.set("YearPeriodDayOfMonth", day);
				var month = cron.getParameter(BPMSoft.cron.Parameters.Month);
				this._initYearPeriodMonth("YearPeriodMonths", month);
			},

			/**
			 * Initializes monthly year period.
			 * @private
			 * @param {String} collectionName Collection name.
			 * @param {Number} month Month number.
			 */
			_initYearPeriodMonth: function(collectionName, month) {
				var monthCollection = this._getMonthsCollection();
				var selectedMonth = month ? monthCollection.get(month) : monthCollection.first();
				this.set(collectionName, selectedMonth);
			},

			/**
			 * Initializes year weekday ordinal period.
			 * @private
			 * @param {Object} cron Cron expression.
			 */
			_initYearOrdinalWeekdayPeriodType: function(cron) {
				var weekDay = cron.getDayOfWeekOrdinalInfo();
				var weekDays = this.getDayOfWeekCollection();
				this.set("WeekdayCollection", weekDays.get(weekDay.dayOfWeek));
				var weekDayNumbers = this._getWeekDayNumberCollection();
				this.set("OrdinalWeekdayCollection", weekDayNumbers.get(weekDay.order));
				var month = cron.getParameter(BPMSoft.cron.Parameters.Month);
				this._initYearPeriodMonth("YearPeriodOrdinalMonths", month);
			},

			/**
			 * Initializes year period trigger date.
			 * @private
			 * @param {Object} cron Cron expression.
			 */
			_initYearPeriodTriggerDate: function(cron) {
				var isMonthDay = cron.getIsParameterDefault(BPMSoft.cron.Parameters.DayOfWeek);
				this.set("IsOrdinalRun", isMonthDay);
				if (isMonthDay) {
					this._initYearMonthlyPeriodType(cron);
				} else {
					this._initYearOrdinalWeekdayPeriodType(cron);
				}
			},

			/**
			 * Initializes year period trigger time.
			 * @private
			 * @param {Object} cron Cron expression.
			 */
			_initYearPeriodTriggerTime: function(cron) {
				var triggerTime = cron.getStartTime();
				var startTime = this.getValidDateTime(triggerTime);
				this.set("YearPeriodTriggerTime", startTime);
			},

			/**
			 * Returns collection of month names.
			 * @private
			 * @return {BPMSoft.Collection}
			 */
			_getMonthsCollection: function() {
				var months = [
					resources.localizableStrings.MonthJanuaryCaption,
					resources.localizableStrings.MonthFebruaryCaption,
					resources.localizableStrings.MonthMarchCaption,
					resources.localizableStrings.MonthAprilCaption,
					resources.localizableStrings.MonthMayCaption,
					resources.localizableStrings.MonthJuneCaption,
					resources.localizableStrings.MonthJulyCaption,
					resources.localizableStrings.MonthAugustCaption,
					resources.localizableStrings.MonthSeptemberCaption,
					resources.localizableStrings.MonthOctoberCaption,
					resources.localizableStrings.MonthNovemberCaption,
					resources.localizableStrings.MonthDecemberCaption
				];
				return this._getLookupItemsCollection(months);
			},

			/**
			 * Returns collection of numeral weekdays.
			 * @private
			 * @returns {BPMSoft.Collection}.
			 */
			_getWeekDayNumberCollection: function() {
				var captions = [
					resources.localizableStrings.WeekDayNumberFirst,
					resources.localizableStrings.WeekDayNumberSecond,
					resources.localizableStrings.WeekDayNumberThird,
					resources.localizableStrings.WeekDayNumberFourth,
					resources.localizableStrings.WeekDayNumberFifth
				];
				return this._getLookupItemsCollection(captions);
			},

			/**
			 * Prepares weekday numbers list.
			 * @param {Object} filter Filter object.
			 * @param {BPMSoft.Collection} list Weekday numbers list.
			 */
			getWeekdayNumbersList: function(filter, list) {
				if (!Ext.isEmpty(list)) {
					list.reloadAll(this._getWeekDayNumberCollection());
				}
			},

			/**
			 * Prepares month names list.
			 * @param {Object} filter Filter object.
			 * @param {BPMSoft.Collection} list Month names list.
			 */
			getMonthNamesList: function(filter, list) {
				if (!Ext.isEmpty(list)) {
					list.reloadAll(this._getMonthsCollection());
				}
			},

			/**
			 * Initializes year section.
			 * @private
			 */
			onExpressionInit: function(cron) {
				if (cron) {
					this._initYearPeriodTriggerDate(cron);
					this._initYearPeriodTriggerTime(cron);
				}
			},

			/**
			 * @inheritdoc BPMSoft.CompositeCronExpressionPage#getCompositeCronExpressionValue
			 * @protected
			 */
			getCompositeCronExpressionValue: function() {
				var cron = BPMSoft.CronExpression.create();
				this._saveYearTriggerDate(cron);
				this._saveYearTriggerTime(cron);
				return cron;
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "YearGroup",
				"parentName": "SectionContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": []
				}
			},
			{
				"operation": "insert",
				"name": "YearContainer",
				"parentName": "YearGroup",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "YearStartDayLabel",
				"parentName": "YearContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 22
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.YearStartDayLabel"},
					"classes": {"labelClass": ["start-timer-properties-page-label"]}
				}
			},
			{
				"operation": "insert",
				"name": "YearRadioButtons",
				"parentName": "YearContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 24
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "RunAtMonthDay",
				"parentName": "YearRadioButtons",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 2
					},
					"className": "BPMSoft.RadioButton",
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"wrapClass": ["padding-top-4"],
					"labelConfig": {"visible": false},
					"checked": {"bindTo": "IsOrdinalRun"},
					"tag": true
				}
			},
			{
				"operation": "insert",
				"name": "RunAtMonthWeekDay",
				"parentName": "YearRadioButtons",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 2
					},
					"className": "BPMSoft.RadioButton",
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"wrapClass": ["padding-top-4"],
					"labelConfig": {"visible": false},
					"checked": {"bindTo": "IsOrdinalRun"},
					"tag": false
				}
			},
			{
				"operation": "insert",
				"name": "YearPeriodDayOfMonth",
				"parentName": "YearRadioButtons",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 3,
						"row": 0,
						"colSpan": 8
					},
					"labelConfig": {"visible": false},
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"value": {"bindTo": "YearPeriodDayOfMonth"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "OrdinalWeekdayCollection",
				"parentName": "YearRadioButtons",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 3,
						"row": 1,
						"colSpan": 8
					},
					"contentType": this.BPMSoft.ContentType.ENUM,
					"labelConfig": {"visible": false},
					"controlConfig": {"prepareList": {"bindTo": "getWeekdayNumbersList"}}
				}
			},
			{
				"operation": "insert",
				"name": "YearDayLabel",
				"parentName": "YearRadioButtons",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 4
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.YearDayLabel"},
					"classes": {"labelClass": ["padding-top-4", "black-text"]}
				}
			},
			{
				"operation": "insert",
				"name": "WeekdayCollection",
				"parentName": "YearRadioButtons",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 5
					},
					"contentType": this.BPMSoft.ContentType.ENUM,
					"labelConfig": {"visible": false},
					"controlConfig": {"prepareList": {"bindTo": "getWeekDayNamesList"}}
				}
			},
			{
				"operation": "insert",
				"name": "YearPeriodMonths",
				"parentName": "YearRadioButtons",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 18,
						"row": 0,
						"colSpan": 8
					},
					"contentType": this.BPMSoft.ContentType.ENUM,
					"labelConfig": {"visible": false},
					"controlConfig": {"prepareList": {"bindTo": "getMonthNamesList"}}
				}
			},
			{
				"operation": "insert",
				"name": "YearPeriodOrdinalMonths",
				"parentName": "YearRadioButtons",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 18,
						"row": 1,
						"colSpan": 8
					},
					"contentType": this.BPMSoft.ContentType.ENUM,
					"labelConfig": {"visible": false},
					"controlConfig": {"prepareList": {"bindTo": "getMonthNamesList"}}
				}
			},
			{
				"operation": "insert",
				"name": "YearRunProcessAtTimeLabel",
				"parentName": "YearContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 22
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.YearRunProcessAtTime"},
					"classes": {"labelClass": ["start-timer-properties-page-label"]}
				}
			},
			{
				"operation": "insert",
				"name": "YearPeriodTriggerTime",
				"parentName": "YearContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 26
					},
					"labelConfig": {"visible": false},
					"bindTo": "YearPeriodTriggerTime",
					"name": "Time",
					"wrapClass": ["date-time-container-modal-page"]
				}
			}
		]
	};
});