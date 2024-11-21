[
	{
		"operation": "insert",
		"name": "settings",
		"values": {
			"entitySchemaName": "Case",
			"settingsType": "RecordPage",
			"details": [],
			"columnSets": [],
			"localizableStrings": {
				"SocialMessageDetailCaptionCase_caption": "Feed",
				"primaryColumnSetCase_caption": "General information",
				"CaseMessageHistoryDetailStandardDetailCase_caption": "Processing",
				"FileDetailV2EmbeddedDetailCase_caption": "Attachments"
			},
			"operation": "insert",
			"modelViewConfig": "{\"viewConfig\":{\"properties\":{\"title\":\"$Number\",\"body\":{\"properties\":{\"items\":[{\"name\":\"PrimaryTab\",\"position\": 1,\"body\":{\"properties\":{\"items\":[{\"name\":\"CaseSymptoms\",\"properties\":{\"maxLines\":5}}]}}},{\"name\":\"CaseMessageHistoryDetailStandardDetail\",\"position\": 0,\"body\":{\"type\":\"Messaging\",\"properties\":{\"enableAttachments\":true,\"enableMentions\":false,\"reverse\":true,\"changeMode\":7}}},{\"name\":\"FileDetailV2EmbeddedDetail\",\"position\": 2,\"body\":{\"properties\":{\"changeMode\":1}}}]}}}},\"controllers\":{\"Case\":{\"model\":{\"config\":{\"columns\":[{\"expression\":{\"columnPath\":\"Number\",\"expressionType\":0}}]}},\"controllers\":{\"CaseMessageHistory\":{\"type\":\"CaseMessagingController\",\"model\":{\"type\":\"CaseMessagingModel\"}}}}}}"
		}
	},
	{
		"operation": "insert",
		"name": "CaseMessageHistoryDetailStandardDetail",
		"values": {
			"caption": "CaseMessageHistoryDetailStandardDetailCase_caption",
			"entitySchemaName": "CaseMessageHistory",
			"filter": {
				"detailColumn": "Case",
				"masterColumn": "Id"
			},
			"detailSchemaName": "CaseMessageHistoryDetail",
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "details",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "primaryColumnSet",
		"values": {
			"items": [],
			"rows": 1,
			"entitySchemaName": "Case",
			"caption": "primaryColumnSetCase_caption",
			"position": 0,
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "e34dac1d-4d7e-48b9-b4ad-996174a81870",
		"values": {
			"row": 0,
			"content": "Description",
			"columnName": "Symptoms",
			"dataValueType": 1,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "c49421c4-137b-438e-bd96-225f04828cf2",
		"values": {
			"row": 1,
			"content": "Status",
			"columnName": "Status",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "a03325a6-6c0d-4bb4-83af-77750466adf1",
		"values": {
			"row": 2,
			"content": "Response time",
			"columnName": "ResponseDate",
			"dataValueType": 7,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 2
	},
	{
		"operation": "insert",
		"name": "2cbdcee3-acbc-4306-8375-fbd5a6a530a3",
		"values": {
			"row": 3,
			"content": "Resolution time",
			"columnName": "SolutionDate",
			"dataValueType": 7,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 3
	},
	{
		"operation": "insert",
		"name": "0b78f76a-2671-4144-8f06-974d2966276e",
		"values": {
			"row": 4,
			"content": "Category",
			"columnName": "Category",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 4
	},
	{
		"operation": "insert",
		"name": "3c5ea6b2-22f3-4238-a9fb-83cfe6806adb",
		"values": {
			"row": 5,
			"content": "SLA",
			"columnName": "ServicePact",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 5
	},
	{
		"operation": "insert",
		"name": "580820b3-a551-4d95-9524-0d5f0cf91470",
		"values": {
			"row": 6,
			"content": "Service",
			"columnName": "ServiceItem",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 6
	},
	{
		"operation": "insert",
		"name": "55f37a6a-1495-4a96-b550-50c9302f7233",
		"values": {
			"row": 7,
			"content": "Configuration item",
			"columnName": "ConfItem",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 7
	},
	{
		"operation": "insert",
		"name": "FileDetailV2EmbeddedDetail",
		"values": {
			"items": [],
			"rows": 1,
			"isDetail": true,
			"filter": {
				"detailColumn": "Case",
				"masterColumn": "Id"
			},
			"detailSchemaName": "FileDetailV2",
			"entitySchemaName": "CaseFile",
			"caption": "FileDetailV2EmbeddedDetailCase_caption",
			"detailType": "File",
			"generator": {
				"xclass": "BPMSoft.FileAndLinksEmbeddedDetailGenerator"
			},
			"displaySeparator": false,
			"businessRules": [],
			"maxRows": 3,
			"position": 1,
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "30fc2b24-684e-4fa4-9cb3-bcfa1e6fba97",
		"values": {
			"row": 0,
			"content": "Data",
			"columnName": "Data",
			"dataValueType": 13,
			"displayColumn": "Name",
			"label": "MobileConstantsFileLabel",
			"placeHolder": "MobileConstantsFileLabel",
			"operation": "insert"
		},
		"parentName": "FileDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "427ebb28-d33b-4de6-b54d-45bf939cd969",
		"values": {
			"row": 1,
			"content": "Type",
			"columnName": "Type",
			"dataValueType": 10,
			"hidden": true,
			"operation": "insert"
		},
		"parentName": "FileDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "db8b2bd4-a35e-4dbf-94e9-f009c1b0c498",
		"values": {
			"row": 2,
			"content": "Name",
			"columnName": "Name",
			"dataValueType": 1,
			"label": "MobileConstantsLinkLabel",
			"placeHolder": "MobileConstantsLinkLabel",
			"viewType": "url",
			"operation": "insert"
		},
		"parentName": "FileDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 2
	},
	{
		"operation": "insert",
		"name": "CaseFileFileAndLinksEditPageVisibilityRule",
		"values": {
			"ruleType": "BPMSoft.FileAndLinksBusinessRule",
			"operation": "insert"
		},
		"parentName": "FileDetailV2EmbeddedDetail",
		"propertyName": "businessRules",
		"index": 0
	}
]