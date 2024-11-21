define("WeeklyCronExpressionPage", ["WeeklyCronExpressionPageResources",
	"css!ProcessTimerStartEventPropertiesPageCSS"], function() {
	return {
		attributes: {
			/**
			 * Array of selected week days indexes
			 * @private
			 * @type {Array}
			 */
			"SelectedWeekDays": {
				"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": [],
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Time of process run in days.
			 * @private
			 * @type {Time}
			 */
			"TriggerTime": {
				"dataValueType": this.BPMSoft.DataValueType.TIME,
				"value": new Date(0, 0, 0, 0, 0),
				"onChange" : "onCronExpressionPartChange"
			}
		},
		methods: {

			/**
			 * Returns if week day button is pressed or not.
			 * @private
			 * @param {Number} tag Invoker button tag.
			 * @return {Boolean} is button pressed.
			 */
			_getIsDaySelected: function(tag) {
				var selectedButtons = this.get("SelectedWeekDays");
				return Ext.Array.contains(selectedButtons, tag);
			},

			/**
			 * Week day button click handler.
			 * @private
			 */
			_onWeekDaySelected: function() {
				var tag = arguments[3];
				var selectedWeekDays = this.get("SelectedWeekDays");
				var newSelectedWeekDays = selectedWeekDays.slice();
				if (this._getIsDaySelected(tag)) {
					Ext.Array.remove(newSelectedWeekDays, tag);
				} else {
					newSelectedWeekDays.push(tag);
				}
				this.set("SelectedWeekDays", newSelectedWeekDays);
			},

			/**
			 * Initializes week section.
			 */
			onExpressionInit: function(cron) {
				if (cron) {
					this.set("TriggerTime", cron.getStartTime());
					this.set("SelectedWeekDays", cron.getWeekDays());
				}
			},

			/**
			 * Week section validation handler.
			 */
			isEmptyWeekDays: function() {
				return Ext.isEmpty(this.$SelectedWeekDays);
			},

			/**
			 * @inheritdoc BPMSoft.CompositeCronExpressionPage#getCompositeCronExpressionValue
			 * @protected
			 */
			getCompositeCronExpressionValue: function() {
				const cron = BPMSoft.CronExpression.create();
				cron.setStartTime(this.getValidDateTime(this.get("TriggerTime")));
				const defaultWeekDays = [2];
				const selectedWeekDays = Ext.isEmpty(this.$SelectedWeekDays)
					? defaultWeekDays
					: this.$SelectedWeekDays;
				selectedWeekDays.sort();
				cron.setWeekDays(selectedWeekDays);
				return cron;
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "WeeklyStartContainer",
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
				"name": "WeeklyStartModule",
				"parentName": "WeeklyStartContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "WeekSectionRunEveryLabel",
				"parentName": "WeeklyStartModule",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 26
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.WeekSectionRunEveryLabel"},
					"classes": {"labelClass": ["start-timer-properties-page-label"]}
				}
			},
			{
				"operation": "insert",
				"name": "WeekPeriodGroup",
				"parentName": "WeeklyStartModule",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 26
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "WeekPeriodContainer",
				"parentName": "WeekPeriodGroup",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "WeekPeriodTriggerTime",
				"parentName": "WeekPeriodContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 26
					},
					"labelConfig": {"visible": false},
					"bindTo": "TriggerTime",
					"name": "Time",
					"wrapClass": ["date-time-container-modal-page"]
				}
			},
			{
				"operation": "insert",
				"name": "WeekSectionRunDaysOfWeekLabel",
				"parentName": "WeeklyStartModule",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 26
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.WeekSectionRunDaysOfWeekLabel"},
					"classes": {"labelClass": ["start-timer-properties-page-label"]}
				}
			},
			{
				"operation": "insert",
				"name": "WeekDaysButtonsGroupWrapper",
				"parentName": "WeeklyStartModule",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 26
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["multiselect-button-group-wrapper"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "WeekDaysButtonsGroup",
				"parentName": "WeekDaysButtonsGroupWrapper",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["multiselect-button-group"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "WeekDayButtonSunday",
				"parentName": "WeekDaysButtonsGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getWeekDayButtonCaption"},
					"click": {"bindTo": "_onWeekDaySelected"},
					"pressed": {"bindTo": "_getIsDaySelected"},
					"tag": 1
				}
			},
			{
				"operation": "insert",
				"name": "WeekDayButtonMonday",
				"parentName": "WeekDaysButtonsGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getWeekDayButtonCaption"},
					"click": {"bindTo": "_onWeekDaySelected"},
					"pressed": {"bindTo": "_getIsDaySelected"},
					"tag": 2
				}
			},
			{
				"operation": "insert",
				"name": "WeekDayButtonTuesday",
				"parentName": "WeekDaysButtonsGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getWeekDayButtonCaption"},
					"click": {"bindTo": "_onWeekDaySelected"},
					"pressed": {"bindTo": "_getIsDaySelected"},
					"tag": 3
				}
			},
			{
				"operation": "insert",
				"name": "WeekDayButtonWednesday",
				"parentName": "WeekDaysButtonsGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getWeekDayButtonCaption"},
					"click": {"bindTo": "_onWeekDaySelected"},
					"pressed": {"bindTo": "_getIsDaySelected"},
					"tag": 4
				}
			},
			{
				"operation": "insert",
				"name": "WeekDayButtonThursday",
				"parentName": "WeekDaysButtonsGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getWeekDayButtonCaption"},
					"click": {"bindTo": "_onWeekDaySelected"},
					"pressed": {"bindTo": "_getIsDaySelected"},
					"tag": 5
				}
			},
			{
				"operation": "insert",
				"name": "WeekDayButtonFriday",
				"parentName": "WeekDaysButtonsGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getWeekDayButtonCaption"},
					"click": {"bindTo": "_onWeekDaySelected"},
					"pressed": {"bindTo": "_getIsDaySelected"},
					"tag": 6
				}
			},
			{
				"operation": "insert",
				"name": "WeekDayButtonSaturday",
				"parentName": "WeekDaysButtonsGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "getWeekDayButtonCaption"},
					"click": {"bindTo": "_onWeekDaySelected"},
					"pressed": {"bindTo": "_getIsDaySelected"},
					"tag": 7
				}
			},
			{
				"operation": "insert",
				"name": "WeekDaysButtonsGroupValidation",
				"parentName": "WeekDaysButtonsGroupWrapper",
				"propertyName": "items",
				"values": {
					"visible": {"bindTo": "isEmptyWeekDays"},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ValidationLabel",
				"parentName": "WeekDaysButtonsGroupValidation",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 26
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.WeekDayValidationMessage"},
					"classes": {"labelClass": ["base-edit-validation"]}
				}
			}
		]
	};
});
