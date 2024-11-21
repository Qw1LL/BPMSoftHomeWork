define("ReleaseTeamPage", ["BusinessRuleModule", "BaseFiltersGenerateModule"],
	function(BusinessRuleModule, BaseFiltersGenerateModule) {
		return {
			entitySchemaName: "ReleaseTeam",
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
