define("DayOffsDetailEditPage", ["DayOffsDetailEditPageResources"],
		function(resources) {
			return {
				entitySchemaName: "DayOff",
				attributes: {
					"Date": {
						"columnPath": "Date",
						"dataValueType": this.BPMSoft.DataValueType.DATE,
						"caption": resources.localizableStrings.DateCaption,
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
				methods: {
					/**
					 * Sets attribute DayType.NonWorking when DayType changes
					 * @private
					 */
					onDayTypeChanged: function() {
						if(this.get("DayType")) {
							var nonWorking = this.get("DayType").NonWorking;
							this.set("DayType.NonWorking", nonWorking);
						}
					}
				}
			};
		});
