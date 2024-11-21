define("ServiceItemPage", [],
		function() {
			return {
				entitySchemaName: "ServiceItem",
				details: /**SCHEMA_DETAILS*/{
					"ServicePacts": {
						"schemaName": "ServicePactInServiceDetail",
						"entitySchemaName": "ServiceInServicePact",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "ServiceItem"
						}
					},
					"ServiceEngineers": {
						"schemaName": "ServiceEngineerDetail",
						"entitySchemaName": "ServiceEngineer",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "ServiceItem"
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "UsersTab",
						"values": {
							"items": [],
							"caption": {
								"bindTo": "Resources.Strings.UsersTabCaption"
							}
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "ServicePacts",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "UsersTab",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ServiceConditionsTab",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.ServiceConditionsTabCaption"
							},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ServiceEngineers",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "ServiceConditionsTab",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "Owner",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Owner",
							"caption": {
								"bindTo": "Resources.Strings.OwnerCaption"
							},
							"contentType": this.BPMSoft.ContentType.LOOKUP,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Header",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "Category",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Category",
							"caption": {
								"bindTo": "Resources.Strings.CategoryCaption"
							},
							"contentType": this.BPMSoft.ContentType.ENUM,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Header",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "merge",
						"name": "Name",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "CaseCategory",
						"values": {
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 11,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "ReactionTimeValue",
						"values": {
							"layout": {
								"column": 9,
								"row": 1,
								"colSpan": 2,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "ReactionTimeUnit",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 9,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "SolutionTimeValue",
						"values": {
							"layout": {
								"column": 22,
								"row": 1,
								"colSpan": 2,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "Status",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "merge",
						"name": "SolutionTimeUnit",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 9,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "remove",
						"name": "Calendar"
					}
				]/**SCHEMA_DIFF*/,
				attributes: {},
				methods: {},
				rules: {},
				userCode: {}
			};
		});
