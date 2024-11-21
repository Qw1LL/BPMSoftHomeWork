define('ContactAnniversariesReportFilter', ['ContactAnniversariesReportFilterResources'], function(resources) {

		var config = [
			{
				name: 'FormingMethod',
				dataValueType: 'FormingMethod'
			},
			{
				name: 'PeriodFilter',
				caption: resources.localizableStrings.PeriodFilterCaption,
				dataValueType: 'PeriodFilter',
				columnName: 'CreatedOn',
				startDate: {
					defValue: BPMSoft.startOfWeek(new Date())
				},
				dueDate: {
					defValue: BPMSoft.endOfWeek(new Date())
				}
			}
		];
		return config;
	});
