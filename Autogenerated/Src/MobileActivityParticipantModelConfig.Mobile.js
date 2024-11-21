BPMSoft.sdk.Model.addBusinessRule("ActivityParticipant", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Participant"]
});

BPMSoft.sdk.Model.setAlternativePrimaryDisplayColumnValueFunc("ActivityParticipant", function(record) {
	return record.get("Participant").getPrimaryDisplayColumnValue();
});
