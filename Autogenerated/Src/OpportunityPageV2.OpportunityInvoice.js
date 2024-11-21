define("OpportunityPageV2", [], function() {
		return {
			entitySchemaName: "Opportunity",
			details: /**SCHEMA_DETAILS*/{
				Invoice: {
					schemaName: "InvoiceDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					},
					defaultValues: {
						Account: {masterColumn: "Account"},
						Contact: {masterColumn: "Contact"}
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
			]/**SCHEMA_DIFF*/
		};
	});
