define("ContactPageV2", [],
	function() {
		return {
			entitySchemaName: "Contact",
			details: /**SCHEMA_DETAILS*/{
				"ConfItem": {
					"schemaName": "ConfItemInContactDetail",
					"entitySchemaName": "ConfItemUser",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Contact"
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
					"parentName": "GeneralInfoTab",
					"propertyName": "items"
				}
			]/**SCHEMA_DIFF*/
		};
	});
