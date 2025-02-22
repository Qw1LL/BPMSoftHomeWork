﻿define("OpportunityDepartmentPage", ["BusinessRuleModule"],
		function(BusinessRuleModule) {
			return {
				entitySchemaName: "OpportunityDepartment",
				attributes:{
					"SalesDirector": {
						dataValueType: BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {
							filter: function() {
								return BPMSoft.createColumnIsNotNullFilter("[SysAdminUnit:Contact].Id");
							}
						}
					},
					"SysAdminUnit": {
						lookupListConfig: {
							filter: function() {
								return BPMSoft.createColumnFilterWithParameter(
										BPMSoft.ComparisonType.LESS, "SysAdminUnitTypeValue", 4);
							}
						}
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Name",
						"values": {
							"bindTo": "Name",
							"layout": { "column": 0, "row": 0, "colSpan": 24 }
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "SysAdminUnit",
						"values": {
							"bindTo": "SysAdminUnit",
							"layout": { "column": 0, "row": 1, "colSpan": 11 }
						}
					},
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "SalesDirector",
						"values": {
							"bindTo": "SalesDirector",
							"layout": { "column": 0, "row": 2, "colSpan": 11 }
						}
					},
					{
						"operation": "merge",
						"name": "Tabs",
						"parentName": "CardContentContainer",
						"propertyName": "items",
						"values": {
							"visible": false
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
