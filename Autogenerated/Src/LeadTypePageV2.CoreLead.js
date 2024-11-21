define("LeadTypePageV2", function() {
		return {
			entitySchemaName: "LeadType",
			details: /**SCHEMA_DETAILS*/{
				ProductInLeadTypeDetail: {
					schemaName: "ProductInLeadTypeDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "LeadType"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ProductInLeadTypeDetail",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/,
		};
	});
