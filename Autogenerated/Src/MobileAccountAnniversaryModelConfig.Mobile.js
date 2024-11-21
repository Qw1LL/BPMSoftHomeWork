BPMSoft.sdk.Model.addBusinessRule("AccountAnniversary", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["AnniversaryType"]
});

BPMSoft.sdk.Model.addBusinessRule("AccountAnniversary", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Date"]
});

BPMSoft.sdk.Model.setAlternativePrimaryDisplayColumnValueFunc("AccountAnniversary", function(record) {
	return record.get("Date");
});
