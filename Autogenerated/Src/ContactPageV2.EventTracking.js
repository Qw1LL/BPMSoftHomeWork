define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
		details: /**SCHEMA_DETAILS*/{
			SiteEventDetail: {
				schemaName: "SiteEventDetailV2",
				entitySchemaName: "SiteEvent",
				filter: {
					masterColumn: "Id",
					detailColumn: "[Lead:BpmSessionId:BpmSessionId].QualifiedContact"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/ [
			{
				"operation": "move",
				"parentName": "HistoryTab",
				"propertyName": "items",
				"name": "SiteEventDetail",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				},
				"index": 0
			}
		] /**SCHEMA_DIFF*/
	};
});
