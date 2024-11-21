define("OmniChatPage", [], function() {
	return {
		entitySchemaName: "OmniChat",
		attributes: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"Cases": {
				"schemaName": "CaseChatDetail",
				"entitySchemaName": "CaseInChat",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Chat"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
          	{
				"operation": "insert",
				"name": "ChatInformationTab",
				"values": {
					"items": [],
					"caption": {
						"bindTo": "Resources.Strings.ChatInformationTabCaption"
					},
					"order": 1
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Cases",
				"values": {
					"itemType": 2
				},
				"parentName": "ChatInformationTab",
				"propertyName": "items",
				"index": 0
			}
		]/**SCHEMA_DIFF*/
	};
});
