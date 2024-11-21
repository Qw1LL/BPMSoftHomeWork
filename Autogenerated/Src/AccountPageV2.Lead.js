define("AccountPageV2", [],
	function() {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{
				Leads: {
					schemaName: "LeadDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "QualifiedAccount"
					},
					useRelationship: true
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "HistoryTabContainer",
					"propertyName": "items",
					"name": "Leads",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
