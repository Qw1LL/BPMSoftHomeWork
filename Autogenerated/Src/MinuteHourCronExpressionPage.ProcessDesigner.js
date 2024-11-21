define("MinuteHourCronExpressionPage", ["MinuteHourCronExpressionPageResources",
	"css!ProcessTimerStartEventPropertiesPageCSS"], function(resources) {
	return {
		attributes: {

			/**
			 * Period of process run in minutes/hours.
			 * @private
			 * @type {Number}
			 */
			"MinuteHourPeriod": {
				"dataValueType": this.BPMSoft.DataValueType.INTEGER,
				"value": 1,
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Period of process run in minutes/hours.
			 * @private
			 * @type {Number}
			 */
			"MinuteHourPeriodStart": {
				"dataValueType": this.BPMSoft.DataValueType.TIME,
				"value": new Date(0, 0, 0, 0, 0),
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Period of process run in minutes/hours.
			 * @private
			 * @type {Number}
			 */
			"MinuteHourPeriodEnd": {
				"dataValueType": this.BPMSoft.DataValueType.TIME,
				"value": new Date(0, 0, 0, 23, 59),
				"onChange" : "onCronExpressionPartChange"
			},

			/**
			 * Period of process run in minutes/hours.
			 * @private
			 * @type {Number}
			 */
			"MinuteHourPeriodType": {
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				"value": {
					value: BPMSoft.cron.Parameters.Minutes,
					displayValue: resources.localizableStrings.MinuteHourSectionMinuteCaption
				},
				"onChange" : "onCronExpressionPartChange"
			}
		},
		messages: {
			/**
			 * @message GetMinuteHourPeriodType
			 * Gets minute or hour cron expression period type.
			 */
			"GetMinuteHourPeriodType": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			/**
			 * Returns minute hours section types.
			 * @return {Object} Minute hours section types.
			 * @private
			 */
			_getMinuteHourTypes: function() {
				return {
					"minute": {
						value: BPMSoft.cron.Parameters.Minutes,
						displayValue: this.get("Resources.Strings.MinuteHourSectionMinuteCaption")
					},
					"hours": {
						value: BPMSoft.cron.Parameters.Hours,
						displayValue: this.get("Resources.Strings.MinuteHourSectionHourCaption")
					}
				};
			},

			/**
			 * Prepares minute hour period type list.
			 * @param {Object} filter Filter object.
			 * @param {BPMSoft.Collection} list Period type list.
			 */
			_prepareMinuteHourPeriodTypeList: function(filter, list) {
				if (!Ext.isEmpty(list)) {
					list.reloadAll(this._getMinuteHourTypes());
				}
			},

			/**
			 * Initializes minute hour section.
			 * @public
			 */
			onExpressionInit: function(cron) {
				if (cron) {
					var minutePeriodTypes = this._getMinuteHourTypes();
					if (cron.getIsParameterEmpty(BPMSoft.cron.Parameters.Minutes)) {
						var config = cron.getIntervalWithPeriod(BPMSoft.cron.Parameters.Hours);
						this.set("MinuteHourPeriodType", minutePeriodTypes.hours);
						this.set("MinuteHourPeriodStart", new Date(0, 0, 0, config.start));
						this.set("MinuteHourPeriodEnd", new Date(0, 0, 0, config.end, 59));
						this.set("MinuteHourPeriod", config.period || 0);
					} else {
						var hoursInterval = cron.getInterval(BPMSoft.cron.Parameters.Hours);
						var minutesPeriod = cron.getRepetitionPeriod(BPMSoft.cron.Parameters.Minutes);
						this.set("MinuteHourPeriodType", minutePeriodTypes.minute);
						this.set("MinuteHourPeriodStart", new Date(0, 0, 0, hoursInterval && hoursInterval.start));
						this.set("MinuteHourPeriodEnd", new Date(0, 0, 0, hoursInterval && hoursInterval.end, 59));
						this.set("MinuteHourPeriod", minutesPeriod || 1);
					}
				}
			},

			/**
			 * @override BPMSoft.CompositeCronExpressionPage#init
			 * @protected
			 */
			init: function(callback, scope) {
				this.callParent(arguments);
				this.sandbox.subscribe("GetMinuteHourPeriodType", function() {
					return this.get("MinuteHourPeriodType");
				}, this, [this.sandbox.id]);
			},

			/**
			 * @inheritdoc BPMSoft.CompositeCronExpressionPage#getCompositeCronExpressionValue
			 * @protected
			 */
			getCompositeCronExpressionValue: function() {
				var cron = BPMSoft.CronExpression.create();
				cron.setRepetitionPeriod(BPMSoft.cron.Parameters.DayOfMonth, 1);
				var parameterTypeLookup = this.get("MinuteHourPeriodType");
				var startTime = this.get("MinuteHourPeriodStart");
				var endTime = this.get("MinuteHourPeriodEnd");
				if (!parameterTypeLookup || !startTime || !endTime) {
					return;
				}
				var parameterType = parameterTypeLookup.value;
				var startHour = startTime.getHours();
				var endHour = endTime.getHours();
				var period = this.get("MinuteHourPeriod");
				if (parameterType === BPMSoft.cron.Parameters.Hours) {
					cron.setIntervalWithPeriod(BPMSoft.cron.Parameters.Hours, {
						start: startHour,
						end: endHour,
						period: period
					});
					cron.setParameter(BPMSoft.cron.Parameters.Minutes, 0);
				} else {
					cron.setInterval(BPMSoft.cron.Parameters.Hours, startHour, endHour);
					cron.setRepetitionPeriod(parameterType, period);
				}
				return cron;
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "MinuteHourContainer",
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
				"name": "MinuteHourGroup",
				"parentName": "MinuteHourContainer",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"wrapClassName": ["minute-hour-grid-layout"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourRunEveryLabel",
				"parentName": "MinuteHourGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 22
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.MinuteHourRunEveryLabel"},
					"classes": {"labelClass": ["start-timer-properties-page-label"]}
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourPeriod",
				"parentName": "MinuteHourGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					},
					"labelConfig": {"visible": false},
					"itemType": this.BPMSoft.ViewItemType.TEXT,
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"value": {"bindTo": "MinuteHourPeriod",
							"bindConfig": {
								"converter": function(value) {
									return value !== 0 ? value : "0";
								}
							}}
					},
					"wrapClass": []
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourPeriodType",
				"parentName": "MinuteHourGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"column": 13
					},
					"contentType": this.BPMSoft.ContentType.ENUM,
					"labelConfig": {"visible": false},
					"controlConfig": {"prepareList": {"bindTo": "_prepareMinuteHourPeriodTypeList"}}
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourIntervalGroup",
				"parentName": "MinuteHourGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 28
					},
					"itemType": this.BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": []
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourIntervalContainer",
				"parentName": "MinuteHourIntervalGroup",
				"propertyName": "items",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourIntervalFromLabel",
				"parentName": "MinuteHourIntervalContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 1
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.MinuteHourIntervalFromLabel"}
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourPeriodStart",
				"parentName": "MinuteHourIntervalContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 1,
						"row": 0,
						"colSpan": 10
					},
					"labelConfig": {"visible": false},
					"bindTo": "MinuteHourPeriodStart",
					"name": "Time",
					"interval": 60,
					"wrapClass": ["date-time-container-modal-page"]
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourIntervalToLabel",
				"parentName": "MinuteHourIntervalContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 12,
						"row": 0,
						"colSpan": 1
					},
					"itemType": this.BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.MinuteHourIntervalToLabel"}
				}
			},
			{
				"operation": "insert",
				"name": "MinuteHourPeriodEnd",
				"parentName": "MinuteHourIntervalContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 14,
						"row": 0,
						"colSpan": 11
					},
					"labelConfig": {"visible": false},
					"bindTo": "MinuteHourPeriodEnd",
					"name": "Time",
					"startMinute": 59,
					"interval": 60,
					"wrapClass": ["date-time-container-modal-page"]
				}
			}
		]
	};
});
