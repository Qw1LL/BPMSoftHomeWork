define("AccountPageV2", function() {
	return {
		entitySchemaName: "Account",
		details: /**SCHEMA_DETAILS*/{
			Project: {
				schemaName: "ProjectDetailV2",
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
				"index": 7,
				"parentName": "HistoryTabContainer",
				"propertyName": "items",
				"name": "Project",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
