define("ActivityPageV2", [],
	function() {
		return {
			details: /**SCHEMA_DETAILS*/{
				Calls: {
					schemaName: "CallDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Activity"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"name": "CallTab",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CallTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "CallTab",
					"propertyName": "items",
					"name": "Calls",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
