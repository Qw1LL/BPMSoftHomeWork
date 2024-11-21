define("OpportunityPageV2", [],
		function() {
			return {
				entitySchemaName: "Opportunity",
				details: /**SCHEMA_DETAILS*/{
					Document: {
						schemaName: "DocumentDetailV2",
						entitySchemaName: "Document",
						filter: {
							masterColumn: "Id",
							detailColumn: "Opportunity"
						},
						defaultValues: {
							Account: { masterColumn: "Account" },
							Contact: { masterColumn: "Contact" }
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "HistoryTab",
						"propertyName": "items",
						"name": "Document",
						"values": { "itemType": BPMSoft.ViewItemType.DETAIL }
					}
				]/**SCHEMA_DIFF*/
			};
		});
