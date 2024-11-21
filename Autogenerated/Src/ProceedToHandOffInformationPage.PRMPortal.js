define("ProceedToHandOffInformationPage", [], function() {
	return {
		entitySchemaName: "",
		attributes: {
			"IsSSPMode": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": BPMSoft.isCurrentUserSsp()
			}
		},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "SystemUserUIContainer",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {
						"bindTo": "IsSSPMode",
						"bindConfig": {"converter": "invertBooleanValue"}
					}
				}
			},
			{
				"operation": "move",
				"name": "Header",
				"parentName": "SystemUserUIContainer",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "SSPUserUIContainer",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {
						"bindTo": "IsSSPMode"
					}
				}
			},
			{
				"operation": "insert",
				"name": "SSPUserUIContainer_GridLayout",
				"parentName": "SSPUserUIContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"classes": {
						"wrapClassName": ["prm-portal-grid"]
					},
					"items": [],
					"collapseEmptyRow": true
				}
			},
			{
				"operation": "insert",
				"name": "LeadType",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "LeadType",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "SSPUserUIContainer_GridLayout",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Budget",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 1,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "Budget",
					"enabled": true
				},
				"parentName": "SSPUserUIContainer_GridLayout",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "OpportunityResponsible",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 2,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "OpportunityResponsible",
					"enabled": true,
					"contentType": 5
				},
				"parentName": "SSPUserUIContainer_GridLayout",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "MeetingTime",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "Header"
					},
					"bindTo": "MeetingTime",
					"enabled": true
				},
				"parentName": "SSPUserUIContainer_GridLayout",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "DecisionDate",
				"values": {
					"layout": {
						"colSpan": 23,
						"rowSpan": 1,
						"column": 1,
						"row": 5,
						"layoutName": "Header"
					},
					"bindTo": "DecisionDate",
					"enabled": true
				},
				"parentName": "SSPUserUIContainer_GridLayout",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "Comment",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 2,
						"column": 0,
						"row": 6,
						"layoutName": "Header"
					},
					"bindTo": "Comment",
					"enabled": true
				},
				"parentName": "SSPUserUIContainer_GridLayout",
				"propertyName": "items",
				"index": 6
			}
		]/**SCHEMA_DIFF*/,
		rules: {}
	};
});
