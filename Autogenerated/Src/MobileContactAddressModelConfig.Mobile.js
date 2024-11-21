BPMSoft.sdk.Model.addBusinessRule("ContactAddress", {
	name: "ContactAddressRequirementRule",
	ruleType: BPMSoft.RuleTypes.Requirement,
	requireType: BPMSoft.RequirementTypes.OneOf,
	triggeredByColumns: ["Address", "City", "Country"],
	position: 3
});

BPMSoft.sdk.Model.addBusinessRule("ContactAddress", {
	name: "ContactAddressMutualFiltrationRule",
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

BPMSoft.sdk.Model.setAlternativePrimaryDisplayColumnValueFunc("ContactAddress", function(record) {
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

BPMSoft.sdk.Model.addBusinessRule("ContactAddress", {
	name: "ContactAddressFiltrationRule",
	ruleType: BPMSoft.RuleTypes.Filtration,
	triggeredByColumns: ["AddressType"],
	position: 2,
	filters: Ext.create("BPMSoft.Filter", {
		type: BPMSoft.FilterTypes.Group,
		subfilters: [
			Ext.create("BPMSoft.Filter", {
				property: "ForContact",
				value: true
			})
		],
		name: "a4365c55-b393-4e26-be5f-ee0e6a7faa8c"
	})
});
