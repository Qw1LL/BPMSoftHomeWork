define("DailyCronExpressionPage", ["DailyCronExpressionPageResources",
	"css!ProcessTimerStartEventPropertiesPageCSS"], function() {
	return {
		attributes: {

			/**
			 * Period of process run in days.
			 * @private
			 * @type {Number}
			 */
			"DaysPeriod": {
				"dataValueType": this.BPMSoft.DataValueType.INTEGER,
				"value": 1,
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
			 * Initializes day section.
			 * @private
			 */
			onExpressionInit: function(cron) {
				if (cron) {
					this.set("TriggerTime", this.getValidDateTime(cron.getStartTime()));
					var period = cron.getRepetitionPeriod(BPMSoft.cron.Parameters.DayOfMonth);
					if (period) {
						this.set("DaysPeriod", period);
					}
				}
			},

			/**
			 * @inheritdoc BPMSoft.CompositeCronExpressionPage#getCompositeCronExpressionValue
			 * @protected
			 */
			getCompositeCronExpressionValue: function() {
				var period = this.get("DaysPeriod");
				var cron = BPMSoft.CronExpression.create();
				cron.setStartTime(this.getValidDateTime(this.get("TriggerTime")));
				cron.setRepetitionPeriod(BPMSoft.cron.Parameters.DayOfMonth, period);
				return cron;
			},

			/**
			 * @inheritdoc ProcessBaseEventPropertiesPage#setValidationConfig
			 * @overriden
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("DaysPeriod", this.dayOfMonthValidator);
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "DailyRunContainer",
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
				"name": "DailyRunGroup",
				"parentName": "DailyRunContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DailyRunEveryLabel",
				"parentName": "DailyRunContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 22
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.DaySectionRunEveryLabel"},
					"classes": {"labelClass": ["start-timer-properties-page-label"]}
				}
			},
			{
				"operation": "insert",
				"name": "DaysPeriodContainer",
				"parentName": "DailyRunContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "DaysPeriod",
				"parentName": "DaysPeriodContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 10
					},
					"labelConfig": {"visible": false},
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"value": {"bindTo": "DaysPeriod"}
					},
					"wrapClass": []
				}
			},
			{
				"operation": "insert",
				"name": "DaysPeriodJointLabel",
				"parentName": "DaysPeriodContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 11,
						"row": 0,
						"colSpan": 5
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.DaysPeriodJointCaption"},
					"classes": {"labelClass": ["padding-top-4"]}
				}
			},
			{
				"operation": "insert",
				"name": "DaysPeriodTriggerTime",
				"parentName": "DaysPeriodContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 17,
						"row": 0,
						"colSpan": 11
					},
					"labelConfig": {"visible": false},
					"bindTo": "TriggerTime",
					"name": "Time",
					"wrapClass": ["date-time-container-modal-page"]
				}
			}
		]
	};
});