define("AccountPageV2", [],
	function() {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{
				Order: {
					schemaName: "OrderDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Account"
					},
					useRelationship: true
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "HistoryTabContainer",
					"propertyName": "items",
					"name": "Order",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
