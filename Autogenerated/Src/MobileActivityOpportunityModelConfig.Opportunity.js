BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "ActivityAccountOpportunityFiltrationRule",
	ruleType: BPMSoft.RuleTypes.Filtration,
	events: [BPMSoft.BusinessRuleEvents.Load, BPMSoft.BusinessRuleEvents.ValueChanged],
	triggeredByColumns: ["Account"],
	filteredColumn: "Opportunity",
	filters: Ext.create("BPMSoft.Filter", {
		property: "Account"
	})
});

BPMSoft.sdk.Model.addBusinessRule("Activity", {
	name: "ActivityAccountByOpportunityRule",
	ruleType: BPMSoft.RuleTypes.Custom,
	triggeredByColumns: ["Opportunity"],
	events: [BPMSoft.BusinessRuleEvents.ValueChanged, BPMSoft.BusinessRuleEvents.Save,
		BPMSoft.BusinessRuleEvents.Load],
	executeFn: function(record, rule, column, customData, callbackConfig) {
		var opportunityRecord = record.get("Opportunity");
		if (opportunityRecord) {
			var accountRecord = record.get("Account");
			if (!accountRecord) {
				var opportunityModel = Ext.ModelManager.getModel("Opportunity");
				opportunityModel.load(opportunityRecord.getId(), {
					isCancelable: false,
					queryConfig: Ext.create("BPMSoft.QueryConfig", {
						columns: ["Account"],
						modelName: "Opportunity"
					}),
					success: function(loadedRecord) {
						if (loadedRecord) {
							record.set("Account", loadedRecord.get("Account"), true);
						}
						Ext.callback(callbackConfig.success, callbackConfig.scope);
					},
					failure: function(record, operation) {
						var exception = operation.getError();
						Ext.callback(callbackConfig.failure, callbackConfig.scope, [exception]);
					},
					scope: this
				});
				return;
			}
		}
		Ext.callback(callbackConfig.success, callbackConfig.scope);
	},
	position: 1
});
