define("ContactPageV2", [],
	function() {
		return {
			entitySchemaName: "Contact",
			details: /**SCHEMA_DETAILS*/{
				SiteEventDetail: {
					schemaName: "SiteEventDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Contact"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "SiteEventDetail",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
