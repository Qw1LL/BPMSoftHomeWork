define("BaseAnniversaryPageV2", ["css!ContactPageV2CSS"], function() {
	return {
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "actions",
				"values": {
					"visible": false
				}
			},
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
				"name": "AnniversaryType",
				"values": {
					"contentType": BPMSoft.ContentType.ENUM,
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "Header",
				"propertyName": "items",
				"name": "Date",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 11
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
