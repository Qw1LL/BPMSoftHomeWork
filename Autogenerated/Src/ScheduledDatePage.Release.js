define("ScheduledDatePage", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "ScheduledDate",
			attributes: {
				"StartDate": {
					dependencies: [
						{
							columns: ["EndDate"],
							methodName: "onEndDateChanged"
						}
					]
				},
				"EndDate": {
					dependencies: [
						{
							columns: ["StartDate"],
							methodName: "onStartDateChanged"
						}
					]
				}
			},
			methods: {
				onEndDateChanged: function() {
					var endDate = this.get("EndDate");
					if (this.get("StartDate") < endDate) {
						return;
					}

					this.set("StartDate", endDate);
				},
				onStartDateChanged: function() {
					var startDate = this.get("StartDate");
					if (startDate < this.get("EndDate")) {
						return;
					}

					this.set("EndDate", startDate);
				}
			},
			rules: {
				"Status": {
					"NotFinal": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"baseAttributePatch": "IsFinal",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.CONSTANT,
						"value": false
					},
					"NotDefault": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"baseAttributePatch": "Id",
						"comparisonType": this.BPMSoft.ComparisonType.NOT_EQUAL,
						"type": BusinessRuleModule.enums.ValueType.SYSSETTING,
						"value": "ReleaseStatusDef"
					}
				}
			}
		};
	});
