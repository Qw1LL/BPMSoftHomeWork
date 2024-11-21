define("ProjectPageV2", [],
		function() {
			return {
				entitySchemaName: "Project",
				details: /**SCHEMA_DETAILS*/{
					"Invoice": {
						"schemaName": "InvoiceDetailV2",
						"filter": {
							"detailColumn": "Project",
							"masterColumn": "Id"
						},
						"defaultValues": {
							"ParentProject": {
								"masterColumn": "Id"
							},
							"Account": {
								"masterColumn": "Account"
							},
							"Contact": {
								"masterColumn": "Contact"
							}
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "HistoryTab",
						"propertyName": "items",
						"name": "Invoice",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					}
				]/**SCHEMA_DIFF*/,
				methods: {}
			};
		});
