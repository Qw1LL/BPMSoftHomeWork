BPMSoft.sdk.Model.addBusinessRule('ContactCommunication', {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ['Number'],
	position: 0
});

BPMSoft.sdk.Model.addBusinessRule('ContactCommunication', {
	ruleType: BPMSoft.RuleTypes.Requirement,
	triggeredByColumns: ['CommunicationType'],
	position: 1
});

BPMSoft.sdk.Model.addBusinessRule('ContactCommunication', {
	ruleType: BPMSoft.RuleTypes.Filtration,
	triggeredByColumns: ['CommunicationType'],
	position: 2,
	filters: Ext.create('BPMSoft.Filter', {
		type: BPMSoft.FilterTypes.Group,
		subfilters: [
			Ext.create('BPMSoft.Filter', {
				property: 'UseforContacts',
				value: true
			}),
			Ext.create('BPMSoft.Filter', {
				property: 'Id',
				funcType: BPMSoft.FilterFunctions.NotIn,
				funcArgs: [BPMSoft.GUID.Twitter, BPMSoft.GUID.Facebook, BPMSoft.GUID.LinkedIn]
			})
		],
		name: 'a4265c53-b393-4e16-be5f-ee0e5a7faa8c'
	})
});

BPMSoft.sdk.Model.setAlternativePrimaryDisplayColumnValueFunc('ContactCommunication', function(record) {
	return record.get('Number');
});
