BPMSoft.Configuration.OpportunityStage = {
	RejectedByUs: "736f54fd-e240-46f8-8c7c-9066c30aff59",
	TranslationIntoAnotherProcess: "9abf243c-fc00-45cf-8e28-cdb66c9208b0",
	FinishedWithLoss: "a9aafdfe-2242-4f42-8cd5-2ae3b9556d79",
	FinishedWithVictory: "60d5310c-5be6-df11-971b-001d60e938c6"
};

BPMSoft.sdk.Model.addBusinessRule("Opportunity", {
	name: "OpportunityTitleRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Title"]
});

BPMSoft.sdk.Model.addBusinessRule("Opportunity", {
	name: "OpportunityStageRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Stage"]
});

BPMSoft.sdk.Model.addBusinessRule("Opportunity", {
	name: "OpportunityLeadTypeRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["LeadType"]
});

BPMSoft.sdk.Model.addBusinessRule("Opportunity", {
	name: "OpportunityAccountContactRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	requireType: BPMSoft.RequirementTypes.OneOf,
	events: [BPMSoft.BusinessRuleEvents.Save, BPMSoft.BusinessRuleEvents.ValueChanged],
	triggeredByColumns: ["Account", "Contact"]
});

BPMSoft.sdk.Model.addBusinessRule("Opportunity", {
	ruleType: BPMSoft.RuleTypes.MutualFiltration,
	triggeredByColumns: ["Account", "Contact"],
	connections: [
		{
			parent: "Account",
			child: "Contact"
		}
	]
});

BPMSoft.sdk.Model.addBusinessRule("Opportunity", {
	name: "OpportunityAmountValidatorRule",
	ruleType: BPMSoft.RuleTypes.Custom,
	triggeredByColumns: ["Amount"],
	events: [BPMSoft.BusinessRuleEvents.ValueChanged, BPMSoft.BusinessRuleEvents.Save],
	executeFn: function(model, rule, column, customData, callbackConfig) {
		var revenue = model.get("Amount");
		if ((revenue < 0) || Ext.isEmpty(revenue)) {
			model.set("Amount", 0, true);
		}
		Ext.callback(callbackConfig.success, callbackConfig.scope);
	}
});

BPMSoft.sdk.Model.addBusinessRule("Opportunity", {
	name: "OpportunityStageProbabilityDependencyRule",
	ruleType: BPMSoft.RuleTypes.Custom,
	triggeredByColumns: ["Stage"],
	events: [BPMSoft.BusinessRuleEvents.ValueChanged, BPMSoft.BusinessRuleEvents.Save],
	executeFn: function(model, rule, column, customData, callbackConfig) {
		var stage = model.get("Stage");
		var stageId;
		if (stage) {
			stageId = stage.getId();
		} else {
			Ext.callback(callbackConfig.success, callbackConfig.scope);
			return;
		}
		if (stageId === BPMSoft.Configuration.OpportunityStage.RejectedByUs ||
			stageId === BPMSoft.Configuration.OpportunityStage.TranslationIntoAnotherProcess ||
			stageId === BPMSoft.Configuration.OpportunityStage.FinishedWithLoss) {
			model.set("Probability", 0, true);
		} else if (stageId === BPMSoft.Configuration.OpportunityStage.FinishedWithVictory) {
			model.set("Probability", 100, true);
		}
		Ext.callback(callbackConfig.success, callbackConfig.scope);
	}
});

BPMSoft.sdk.Model.addBusinessRule("Opportunity", {
	name: "OpportunityProbabilityValidatorRule",
	ruleType: BPMSoft.RuleTypes.Custom,
	triggeredByColumns: ["Probability"],
	events: [BPMSoft.BusinessRuleEvents.ValueChanged, BPMSoft.BusinessRuleEvents.Save],
	executeFn: function(model, rule, column, customData, callbackConfig) {
		var invalidMessage = "";
		var probability = model.get("Probability");
		if (probability < 0) {
			probability = 0;
		} else if (probability > 100) {
			probability = 100;
		}
		model.set("Probability", probability, true);
		var isValid = true;
		var stage = model.get("Stage");
		var maxProbability = -1;
		if (stage) {
			maxProbability = model.get("Stage.MaxProbability");
		}
		if (probability && probability > maxProbability && maxProbability >= 0) {
			isValid = false;
			invalidMessage = BPMSoft.LocalizableStrings.ProbabilityIsGreaterThenMaxProbabilityByStageMessageCaption +
				maxProbability;
			model.changeProperty("Probability", {
				isValid: {
					value: isValid,
					message: invalidMessage
				}
			});
		} else {
			model.changeProperty("Probability", {
				isValid: {
					value: isValid
				}
			});
		}
		Ext.callback(callbackConfig.success, callbackConfig.scope, [isValid]);
	}
});
