﻿define("CityPageV2", ["BPMSoft", "BusinessRuleModule", "ext-base", "sandbox"],
		function(BPMSoft, BusinessRuleModule, Ext, sandbox) {
			return {
				entitySchemaName: "City",
				attributes: {
					"Region": {
						name: "Region",
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						dependencies: [
							{
								columns: ["Country"],
								methodName: "CountryOnChange"
							}
						]
					}
				},
				details: /**SCHEMA_DETAILS*/{
				}/**SCHEMA_DETAILS*/,
				methods: {
					CountryOnChange: function() {
						var country = this.get("Country");
						if (Ext.isEmpty(country)) {
							this.set("Region", null);
						}
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"name": "Country",
						"values": {
							"bindTo": "Country",
							"layout": {"column": 0, "row": 1, "colSpan": 11}
						}
					}, {
						"operation": "insert",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"name": "Region",
						"values": {
							"bindTo": "Region",
							"layout": {"column": 0, "row": 2, "colSpan": 11}
						}
					}, {
						"operation": "insert",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"name": "TimeZone",
						"values": {
							"bindTo": "TimeZone",
							"layout": {"column": 0, "row": 3, "colSpan": 11}
						}
					}, {
						"operation": "merge",
						"name": "Description",
						"values": {
							"bindTo": "Description",
							"layout": {"column": 0, "row": 4, "colSpan": 24}
						}
					}
				]/**SCHEMA_DIFF*/,
				rules: {
					"Region": {
						"FilteringCityByCounty": {
							ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
							autocomplete: true,
							baseAttributePatch: "Country",
							comparisonType: BPMSoft.ComparisonType.EQUAL,
							type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							attribute: "Country",
							attributePath: "",
							value: ""
						}
					}
				},
				userCode: {}
			};
		});
