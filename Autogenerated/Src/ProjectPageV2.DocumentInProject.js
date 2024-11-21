define("ProjectPageV2", [],
		function() {
			return {
				entitySchemaName: "Project",
				details: /**SCHEMA_DETAILS*/{
					Documents: {
						schemaName: "DocumentDetailV2",
						entitySchemaName: "Document",
						filter: {
							masterColumn: "Id",
							detailColumn: "Project"
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
						"name": "Documents",
						"values": {
							"itemType": BPMSoft.ViewItemType.DETAIL
						}
					}
				]/**SCHEMA_DIFF*/,
				methods: {}
			};
		});
