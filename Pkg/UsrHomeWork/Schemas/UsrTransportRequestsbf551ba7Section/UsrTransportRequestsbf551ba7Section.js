define("UsrTransportRequestsbf551ba7Section", [], function() {
	return {
		entitySchemaName: "UsrTransportRequests",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		attributes: {
			"AddTeamButtonVisible": {
				"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"caption": "AddTeamButtonVisible",
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "AddTeam",
				"parentName": "CombinedModeActionButtonsCardLeftContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": "Добавить команду", // знаю, что есть ресурсы, не добавлял для ускорения выполненя задачи "bindTo": "Resources.Strings.blabla
					"click": { "bindTo": "onCardAction" },
					"visible": { "bindTo": "AddTeamButtonVisible" },
					"enabled": true,
					"tag": "onAddTeam"
				}
			},
		]/**SCHEMA_DIFF*/,
		methods: {

			initFixedFiltersConfig: function() {
				let fixedFilterConfig = {
					entitySchema: this.entitySchema,
					filters: []
				};

				fixedFilterConfig.filters.push({
					name: "PeriodFilter",
					caption: "период",
					dataValueType: this.BPMSoft.DataValueType.DATE,
					columnName: "CreatedOn",
					startDate: {
						defValue: this.BPMSoft.startOfWeek(new Date())
					},
					dueDate: {
						defValue: this.BPMSoft.endOfWeek(new Date())
					}
				});

				fixedFilterConfig.filters.push({
					name: "StatusFilter",
					caption: "Статус",
					addNewFilterCaption: "Добавить статус",
					appendCurrentContactMenuItem: false,
					defValue: null,
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					columnName: "UsrStatus",
				});

				fixedFilterConfig.filters.push({
					name: "CarFilter",
					caption: "Автомобиль",
					addNewFilterCaption: "Добавить автомобиль",
					appendCurrentContactMenuItem: false,
					defValue: null,
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					columnName: "UsrCar",
				});

				fixedFilterConfig.filters.push({
					name: "DriverFilter",
					caption: "Водитель",
					addNewFilterCaption: "Добавить водителя",
					appendCurrentContactMenuItem: false,
					defValue: null,
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					columnName: "UsrDriver",
				});
				
				
				this.set("FixedFilterConfig", fixedFilterConfig);
			}
		}
	};
});
