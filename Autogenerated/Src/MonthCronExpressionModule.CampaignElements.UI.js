define("MonthCronExpressionModule", ["MonthCronExpressionModuleResources"], function() {
	return {
		attributes: {
		},
		methods: {
		},
		diff: [
			{
				"operation": "remove",
				"name": "MonthSectionTriggerTimerLabel"
			},
			{
				"operation": "remove",
				"name": "MonthPeriodTriggerTime"
			}
		]
	};
});
