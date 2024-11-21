define("KnowledgeBasePageV2", [],
	function() {
		return {
			entitySchemaName: "KnowledgeBase",
			columns: {},
			details: /**SCHEMA_DETAILS*/{
				"CaseInKnowledgeBase": {
					"schemaName": "CaseInKnowledgeBaseDetail",
					"entitySchemaName": "KnowledgeBaseInCase",
					"filter": {
						"detailColumn": "KnowledgeBase",
						"masterColumn": "Id"
					}
				}
			}/**SCHEMA_DETAILS*/,
			messages: {},
			methods: {},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "RelationsTab",
					"values": {
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.RelationsTabCaption"
						}
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "CaseInKnowledgeBase",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "RelationsTab",
					"propertyName": "items",
					"index": 0
				}
			]/**SCHEMA_DIFF*/,
			rules: {},
			userCode: {}
		};
	});
