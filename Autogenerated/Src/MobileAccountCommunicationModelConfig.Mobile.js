BPMSoft.sdk.Model.addBusinessRule("AccountCommunication", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["Number"]
});

BPMSoft.sdk.Model.addBusinessRule("AccountCommunication", {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ["CommunicationType"]
});

BPMSoft.sdk.Model.addBusinessRule("AccountCommunication", {
	ruleType: BPMSoft.RuleTypes.Filtration,
	triggeredByColumns: ["CommunicationType"],
	filters: Ext.create("BPMSoft.Filter", {
		type: BPMSoft.FilterTypes.Group,
		subfilters: [
			Ext.create("BPMSoft.Filter", {
				property: "UseforAccounts",
				value: true
			}),
			Ext.create("BPMSoft.Filter", {
				property: "Id",
				funcType: BPMSoft.FilterFunctions.NotIn,
				funcArgs: [BPMSoft.GUID.Twitter, BPMSoft.GUID.Facebook, BPMSoft.GUID.LinkedIn]
			})
		],
		name: "a4265c53-b393-4e16-be5f-ee0e5a7faa8c"
	})
});

BPMSoft.sdk.Model.setAlternativePrimaryDisplayColumnValueFunc("AccountCommunication", function(record) {
	return record.get("Number");
});
