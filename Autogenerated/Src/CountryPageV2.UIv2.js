define("CountryPageV2", [],
		function() {
			return {
				entitySchemaName: "Country",
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
				attributes: {},
				methods: {},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "actions"
					},
					{
						"operation": "remove",
						"name": "ViewOptionsButton"
					},
					{
						"operation": "insert",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"name": "BillingInfo",
						"values": {
							"bindTo": "BillingInfo",
							"layout": {"column": 0, "row": 1, "colSpan": 11}
						}
					},
					{
						"operation": "insert",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"name": "TimeZone",
						"values": {
							"bindTo": "TimeZone",
							"layout": {"column": 0, "row": 2, "colSpan": 11}
						}
					},
					{
						"operation": "insert",
						"parentName": "GeneralInfoBlock",
						"propertyName": "items",
						"name": "Code",
						"values": {
							"bindTo": "Code",
							"layout": {"column": 0, "row": 3, "colSpan": 11}
						}
					},
					{
						"operation": "merge",
						"name": "Description",
						"values": {
							"layout": {"column": 0, "row": 4, "colSpan": 24}
						}
					}

				]/**SCHEMA_DIFF*/

			};
		});
