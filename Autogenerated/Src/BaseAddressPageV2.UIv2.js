define("BaseAddressPageV2", ["BusinessRuleModule", "css!ContactPageV2CSS"], function(BusinessRuleModule) {
	return {
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "Tabs",
				"values": {
					visible: false
				}
			},
			{
				"operation": "merge",
				"name": "actions",
				"values": {
					visible: false
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Country",
				"values": {
					bindTo: "Country",
					layout: { column: 0, row: 0, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "AddressType",
				"values": {
					bindTo: "AddressType",
					contentType: BPMSoft.ContentType.ENUM,
					layout: { column: 13, row: 0, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Region",
				"values": {
					bindTo: "Region",
					layout: { column: 0, row: 1, colSpan: 11 },
					tip: {
						content: { bindTo: "Resources.Strings.RegionFilterRuleTip" }
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Zip",
				"values": {
					bindTo: "Zip",
					layout: { column: 13, row: 1, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "City",
				"values": {
					bindTo: "City",
					layout: { column: 0, row: 2, colSpan: 11 },
					tip: {
						content: { bindTo: "Resources.Strings.CityFilterRuleTip" }
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Primary",
				"values": {
					bindTo: "Primary",
					layout: { column: 13, row: 3, colSpan: 11 }
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Address",
				"values": {
					bindTo: "Address",
					layout: { column: 13, row: 2, colSpan: 11 }
				}
			}
		]/**SCHEMA_DIFF*/,
		rules: {
			"Region": {
				"FiltrationRegionByCountry": {
					ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
					autocomplete: true,
					autoClean: true,
					baseAttributePatch: "Country",
					comparisonType: BPMSoft.ComparisonType.EQUAL,
					type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					attribute: "Country"
				}
			},
			"City": {
				"FiltrationCityByCountry": {
					ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
					autocomplete: true,
					autoClean: true,
					baseAttributePatch: "Country",
					comparisonType: BPMSoft.ComparisonType.EQUAL,
					type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					attribute: "Country"
				},
				"FiltrationCityByRegion": {
					ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
					autocomplete: true,
					autoClean: true,
					baseAttributePatch: "Region",
					comparisonType: BPMSoft.ComparisonType.EQUAL,
					type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					attribute: "Region"
				}
			}
		}
	};
});
