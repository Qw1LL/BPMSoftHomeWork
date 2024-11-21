BPMSoft.sdk.Model.addBusinessRule("AccountAddress", {
	name: "AccountAddressMutualFiltrationRule",
	ruleType: BPMSoft.RuleTypes.MutualFiltration,
	triggeredByColumns: ["Country", "Region", "City"],
	connections: [
		{
			parent: "Country",
			child: "City"
		},
		{
			parent: "Country",
			child: "Region"
		},
		{
			parent: "Region",
			child: "City"
		}
	]
});

BPMSoft.sdk.Model.addBusinessRule("AccountAddress", {
	name: "AccountAddressRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	requireType: BPMSoft.RequirementTypes.OneOf,
	triggeredByColumns: ["Address", "City", "Country"],
	position: 3
});

/*
BPMSoft.sdk.Model.addBusinessRule("AccountAddress", {
	ruleType: BPMSoft.RuleTypes.Custom,
	triggeredByColumns: ["Primary"],
	events: [BPMSoft.BusinessRuleEvents.ValueChanged],
	executeFn: function(model, rule, column, customData, callbackConfig) {
		var stores = model.stores[0];
		if (!model.get("Primary")) {
			Ext.callback(callbackConfig.success, callbackConfig.scope);
			return;
		}
		var currentRecordId = model.get("Id");
		for (var i = 0, ln = stores.getCount(); i < ln; i++) {
			var item = stores.getData().items[i];
			var id = item.get("Id");
			if (id !== currentRecordId) {
				item.set("Primary", false, true);
			}
		}
		Ext.callback(callbackConfig.success, callbackConfig.scope);
	}
});
*/

BPMSoft.sdk.Model.setAlternativePrimaryDisplayColumnValueFunc("AccountAddress", function(record) {
	var country = record.get("Country");
	var countryValue = (!Ext.isEmpty(country)) ? country.getPrimaryDisplayColumnValue() : "";
	var city = record.get("City");
	var cityValue = (!Ext.isEmpty(city)) ? city.getPrimaryDisplayColumnValue() : "";
	var address = record.get("Address");
	var value = (!Ext.isEmpty(countryValue)) ? countryValue + ", " : "";
	value += (!Ext.isEmpty(cityValue)) ? cityValue + ", " : "";
	value += (!Ext.isEmpty(address)) ? address + ", " : "";
	return value.substring(0, value.length - 2);
});

BPMSoft.sdk.Model.addBusinessRule("AccountAddress", {
	name: "AccountAddressTypeFiltrationRule",
	ruleType: BPMSoft.RuleTypes.Filtration,
	triggeredByColumns: ["AddressType"],
	position: 2,
	filters: Ext.create("BPMSoft.Filter", {
		type: BPMSoft.FilterTypes.Group,
		subfilters: [
			Ext.create("BPMSoft.Filter", {
				property: "ForAccount",
				value: true
			})
		],
		name: "a4365c55-b393-4e16-be5f-ee0e6a7faa8c"
	})
});
