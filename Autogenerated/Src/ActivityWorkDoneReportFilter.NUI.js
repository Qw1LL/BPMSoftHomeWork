define('ActivityWorkDoneReportFilter', ['ActivityWorkDoneReportFilterResources', 'ConfigurationConstants'],
	function(resources, ConfigurationConstants) {
		var startDate = BPMSoft.startOfWeek(Ext.Date.add(new Date(), 'd', -7));
		var dueDate = BPMSoft.endOfWeek(startDate);

		var config = [
			{
				name: 'PeriodFilter',
				dataValueType: 'PeriodFilter',
				columnName: 'DueDate',
				startDate: {
					defValue: startDate
				},
				dueDate: {
					defValue: dueDate
				}
			},
			{
				name: 'Owner',
				caption: resources.localizableStrings.Owner,
				dataValueType: 'LOOKUP',
				columnName: 'Owner',
				defValue: BPMSoft.SysValue.CURRENT_USER_CONTACT,
				parameterName: 'OwnerId'
			},
			{
				name: 'Type',
				caption: resources.localizableStrings.Type,
				dataValueType: 'ENUM',
				columnName: 'Type',
				defValue: {
					value: ConfigurationConstants.Activity.Type.Task,
					displayValue: resources.localizableStrings.TaskCaption
				},
				parameterName: 'ActivityType'
			}
		];
		return config;
	});
