define('BaseReportParameterInModulePageFilter', ['BaseReportParameterInModulePageFilterResources'],
	function(resources) {

		var config = [
			{
				name: 'FormingMethod',
				dataValueType: 'FormingMethod'
			}
//				,
//				{
//					name: 'PeriodFilter',
//					caption: resources.localizableStrings.PeriodFilterCaption,
//					dataValueType: 'PeriodFilter',
//					startDate: {
//						columnName: 'StartDate',
//						defValue: BPMSoft.startOfWeek(new Date())
//					},
//					dueDate: {
//						columnName: 'DueDate',
//						defValue: BPMSoft.endOfWeek(new Date())
//					}
//				},

//				{
//					name: 'Owner',
//					caption: resources.localizableStrings.OwnerFilterCaption,
//					columnName: 'Owner',
//					defValue: BPMSoft.SysValue.CURRENT_USER_CONTACT,
//					dataValueType: 'LOOKUP',
//					appendFilter: function(filterInfo) {
//						var filter;
//						if (filterInfo.value && filterInfo.value.length > 0) {
//							filter = BPMSoft.createColumnInFilterWithParameters(
//								'[ActivityParticipant:Activity].Participant',
//								filterInfo.value);
//						}
//						return filter;
//					}
//				}
		]
		return config;
	});
