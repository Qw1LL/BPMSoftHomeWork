define("WorkingWeekDetailPage", ["WorkingWeekDetailPageResources"],
		function(resources) {
			return {
				entitySchemaName: "DayInCalendar",
				mixins: {},
				attributes: {
					"DayOfWeek": {
						"columnPath": "DayOfWeek",
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP.GUID,
						"caption": resources.localizableStrings.DayOfWeekCaption,
						"isRequired": true,
						"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN
					},
					"DayType": {
						"columnPath": "DayType",
						"dataValueType": this.BPMSoft.DataValueType.LOOKUP.GUID,
						"caption": resources.localizableStrings.DayTypeCaption,
						"isRequired": true,
						"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN,
						"lookupListConfig": {
							"columns": ["NonWorking"]
						},
						"dependencies": [
							{
								"columns": ["DayType"],
								"methodName": "onDayTypeChanged"
							}
						]
					},
					"WorkingIntervals": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"caption": resources.localizableStrings.WorkingIntervalsCaption,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"DayType.NonWorking": {
						"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				diff: [],
				methods: {
					/**
					 * Sets attribute DayType.NonWorking when DayType changes
					 * @private
					 */
					onDayTypeChanged: function() {
						var nonWorking = this.get("DayType").NonWorking;
						this.set("DayType.NonWorking", nonWorking);
					}
				}
			};
		});
