define("UsrTransportRequestsbf551ba7Section", [], function() {
	return {
		entitySchemaName: "UsrTransportRequests",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
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
