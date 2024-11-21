define("AccountPageV2", [],
	function() {
		return {
			entitySchemaName: "Account",
			details: /**SCHEMA_DETAILS*/{
				"ConfItem": {
					"schemaName": "ConfItemInAccountDetail",
					"entitySchemaName": "ConfItemUser",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Account"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "ConfItem",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "AccountPageGeneralTabContainer",
					"propertyName": "items"
				}
			]/**SCHEMA_DIFF*/
		};
	});
