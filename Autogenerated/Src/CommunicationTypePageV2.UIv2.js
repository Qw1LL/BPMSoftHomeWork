 define("CommunicationTypePageV2", [],
	function() {
		return {
			entitySchemaName: "CommunicationType",
			methods: {
			},
			details: /**SCHEMA_DETAILS*/{
				CommunicationTypeByCommunicationDetail: {
					schemaName: "CommunicationTypeByCommunicationDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "CommunicationType"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Tabs",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Name",
					"values": {
						"layout": {"column": 0, "row": 0, "colSpan": 18}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Description",
					"values": {
						"bindTo": "Description",
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"layout": {"column": 0, "row": 1, "colSpan": 18}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "UseforContacts",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 9}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "UseforAccounts",
					"values": {
						"layout": {"column": 9, "row": 2, "colSpan": 9}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "CommunicationTypeByCommunicationDetail",
					"values": {
						"layout": {"column": 0, "row": 4, "colSpan": 24},
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
