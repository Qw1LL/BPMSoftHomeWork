BPMSoft.sdk.Model.addBusinessRule("Case", {
	name: "CaseContactAccountRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	requireType: BPMSoft.RequirementTypes.OneOf,
	triggeredByColumns: ["Contact", "Account"]
});

BPMSoft.sdk.Model.setDefaultValuesFunc("Case", function(config) {
	config.record.set("RegisteredOn", new Date());
	config.record.set("Origin", BPMSoft.SysSettings.MobileDefaultCaseOrigin);
	Ext.callback(config.success, config.scope);
});

BPMSoft.sdk.Model.addBusinessRule("Case", {
	name: "CaseContactAccountMutualFiltrationRule",
	ruleType: BPMSoft.RuleTypes.MutualFiltration,
	triggeredByColumns: ["Account", "Contact"],
	connections: [{
		parent: "Account",
		child: "Contact"
	}]
});

BPMSoft.sdk.Model.addBusinessRule("Case", {
	name: "CaseOwnerFiltrationRule",
	ruleType: BPMSoft.RuleTypes.Filtration,
	events: [BPMSoft.BusinessRuleEvents.Load],
	triggeredByColumns: ["Owner"],
	filters: Ext.create("BPMSoft.Filter", {
		property: "ConnectionType",
		modelName: "SysAdminUnit",
		assocProperty: "Contact",
		operation: BPMSoft.FilterOperations.Any,
		name: "CaseOwner_SysAdminUnit_Filtration",
		value: BPMSoft.SysAdminUnitConnectionType.AllEmployees
	})
});
