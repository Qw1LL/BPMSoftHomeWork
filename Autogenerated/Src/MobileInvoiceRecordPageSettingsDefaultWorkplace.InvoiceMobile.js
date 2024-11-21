[
	{
		"operation": "insert",
		"name": "settings",
		"values": {
			"entitySchemaName": "Invoice",
			"details": [],
			"columnSets": [],
			"localizableStrings": {
				"AmountInvoice_caption": "Amount",
				"primaryColumnSetInvoice_caption": "General information",
				"SocialMessageDetailCaptionInvoice_caption": "Feed",
				"VisaDetailV2EmbeddedDetailInvoice_caption": "Invoice approvals"
			},
			"settingsType": "RecordPage",
			"operation": "insert"
		}
	},
	{
		"operation": "insert",
		"name": "SocialMessageDetailV2StandardDetail",
		"values": {
			"caption": "SocialMessageDetailCaptionInvoice_caption",
			"entitySchemaName": "SocialMessage",
			"showForVisibleModule": true,
			"filter": {
				"detailColumn": "EntityId",
				"masterColumn": "Id"
			},
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "details",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "VisaDetailV2EmbeddedDetail",
		"values": {
			"items": [],
			"rows": 1,
			"isDetail": true,
			"filter": {
				"detailColumn": "Invoice",
				"masterColumn": "Id"
			},
			"detailSchemaName": "VisaDetailV2",
			"entitySchemaName": "InvoiceVisa",
			"caption": "VisaDetailV2EmbeddedDetailInvoice_caption",
			"detailType": "Visa",
			"generator": {
				"xclass": "BPMSoft.configuration.VisaEmbeddedDetailGenerator"
			},
			"displaySeparator": false,
			"filters": {
				"type": "BPMSoft.FilterTypes.Group",
				"subfilters": [
					{
						"disableForLocalData": true,
						"property": "SysAdminUnit",
						"modelName": "SysAdminUnitInRole",
						"assocProperty": "SysAdminUnitRoleId",
						"masterColumnName": "VisaOwner",
						"operation": "BPMSoft.FilterOperations.Any",
						"valueIsMacros": true,
						"value": "BPMSoft.ValueMacros.CurrentUser"
					},
					{
						"type": "BPMSoft.FilterTypes.Group",
						"logicalOperation": "BPMSoft.FilterLogicalOperations.Or",
						"subfilters": [
							{
								"property": "Status",
								"compareType": "BPMSoft.ComparisonTypes.NotEqual",
								"isNot": true,
								"value": null
							},
							{
								"property": "Status.IsFinal",
								"value": false
							}
						]
					},
					{
						"property": "IsCanceled",
						"value": false
					}
				]
			},
			"maxRows": 1,
			"position": 0,
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "7aaf7415-c295-44cf-b3f7-9db6edebac99",
		"values": {
			"row": 0,
			"content": "Approval purpose",
			"columnName": "Objective",
			"dataValueType": 1,
			"operation": "insert"
		},
		"parentName": "VisaDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "primaryColumnSet",
		"values": {
			"items": [],
			"rows": 1,
			"entitySchemaName": "Invoice",
			"caption": "primaryColumnSetInvoice_caption",
			"position": 1,
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "f4e8856b-dddd-4de3-b5dc-074d6abf4b1c",
		"values": {
			"row": 0,
			"content": "Number",
			"columnName": "Number",
			"dataValueType": 1,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "7b2c8287-5673-43f1-b3ff-d6d1a53e7e50",
		"values": {
			"row": 1,
			"content": "Owner",
			"columnName": "Owner",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "1e129461-af2e-4652-ba04-096eb816f5f3",
		"values": {
			"row": 2,
			"content": "Payment status",
			"columnName": "PaymentStatus",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 2
	},
	{
		"operation": "insert",
		"name": "f2170c4f-8e54-401a-9aba-8a6181f625fc",
		"values": {
			"row": 3,
			"content": "Paid on",
			"columnName": "DueDate",
			"dataValueType": 8,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 3
	},
	{
		"operation": "insert",
		"name": "1c982236-86fb-4c86-9d18-35a810cc41ef",
		"values": {
			"row": 4,
			"content": "Account",
			"columnName": "Account",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 4
	},
	{
		"operation": "insert",
		"name": "Amount",
		"values": {
			"items": [],
			"rows": 1,
			"entitySchemaName": "Invoice",
			"caption": "AmountInvoice_caption",
			"position": 2,
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 2
	},
	{
		"operation": "insert",
		"name": "af61bbd2-8005-4dba-94e9-e9901ec3af00",
		"values": {
			"row": 0,
			"content": "Currency",
			"columnName": "Currency",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "Amount",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "9512413c-df49-44f9-9197-b5b4fc8cff10",
		"values": {
			"row": 1,
			"content": "Amount",
			"columnName": "Amount",
			"dataValueType": 6,
			"operation": "insert"
		},
		"parentName": "Amount",
		"propertyName": "items",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "5e2e1880-e4ce-4e34-b771-cecedb7b1492",
		"values": {
			"row": 2,
			"content": "Amount, base currency",
			"columnName": "PrimaryAmount",
			"dataValueType": 6,
			"operation": "insert"
		},
		"parentName": "Amount",
		"propertyName": "items",
		"index": 2
	},
	{
		"operation": "insert",
		"name": "d35b194c-bb23-44ba-aec1-93075e330ed8",
		"values": {
			"row": 3,
			"content": "Payment amount",
			"columnName": "PaymentAmount",
			"dataValueType": 6,
			"operation": "insert"
		},
		"parentName": "Amount",
		"propertyName": "items",
		"index": 3
	}
]