BPMSoft.sdk.Model.addBusinessRule('ContactAnniversary', {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ['AnniversaryType']
});

BPMSoft.sdk.Model.addBusinessRule('ContactAnniversary', {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ['Date']
});

BPMSoft.sdk.Model.setAlternativePrimaryDisplayColumnValueFunc('ContactAnniversary', function(record) {
	return record.get('Date');
});
