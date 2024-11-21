define("CaseNotificationRuleEditPage", [],
	function() {
		return {
			entitySchemaName: "CaseNotificationRule",
			messages: {},
			diff: [
				{
					"operation": "remove",
					"name": "ESNTab"
				},
				{
					"operation": "remove",
					"name": "ESNFeedContainer"
				},
				{
					"operation": "remove",
					"name": "ESNFeed"
				},
				{
					"operation": "insert",
					"name": "CaseStatus",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "CaseCategory",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "EmailTemplate",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "EmailTemplate"
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 3
				}
			],
			methods: {}
		};
	});
