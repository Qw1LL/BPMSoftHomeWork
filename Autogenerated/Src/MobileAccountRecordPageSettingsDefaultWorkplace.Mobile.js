[
	{
		"operation": "insert",
		"name": "settings",
		"values": {
			"entitySchemaName": "Account",
			"settingsType": "RecordPage",
			"localizableStrings": {
				"primaryColumnSetAccount_caption": "Account info",
				"ActivityDetailV2StandartDetailAccount_caption": "Activities",
				"AccountCommunicationDetailEmbeddedDetailAccount_caption": "Account communication options",
				"AccountAddressDetailV2EmbeddedDetailAccount_caption": "Account addresses",
				"AccountAnniversaryDetailV2EmbeddedDetailAccount_caption": "Noteworthy events of account",
				"AccountContactsDetailV2StandartDetailAccount_caption": "Contacts",
				"SocialMessageDetailCaptionContact_caption": "Feed"
			},
			"columnSets": [],
			"operation": "insert",
			"details": []
		}
	},
	{
		"operation": "insert",
		"name": "primaryColumnSet",
		"values": {
			"items": [],
			"rows": 1,
			"entitySchemaName": "Account",
			"caption": "primaryColumnSetAccount_caption",
			"operation": "insert",
			"position": 0
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "c7420f75-77cd-4db2-b662-b15d804e8b0d",
		"values": {
			"row": 0,
			"content": "Name",
			"columnName": "Name",
			"dataValueType": 1,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "43b0f0e2-9557-4426-82da-2e79c32d908e",
		"values": {
			"row": 1,
			"content": "Primary contact",
			"columnName": "PrimaryContact",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "31581b18-3bc1-4580-b7a3-496c692f1b47",
		"values": {
			"row": 4,
			"content": "Industry",
			"columnName": "Industry",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 2
	},
	{
		"operation": "insert",
		"name": "97feecc8-13da-4df9-80d1-14ca679c145c",
		"values": {
			"row": 2,
			"content": "Type",
			"columnName": "Type",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 3
	},
	{
		"operation": "insert",
		"name": "eec175e8-2d0b-48fd-89ad-f0c5f818c431",
		"values": {
			"row": 3,
			"content": "Category",
			"columnName": "AccountCategory",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "primaryColumnSet",
		"propertyName": "items",
		"index": 4
	},
	{
		"operation": "insert",
		"name": "AccountCommunicationDetailEmbeddedDetail",
		"values": {
			"items": [],
			"rows": 1,
			"isDetail": true,
			"filter": {
				"detailColumn": "Account",
				"masterColumn": "Id"
			},
			"detailSchemaName": "AccountCommunicationDetail",
			"entitySchemaName": "AccountCommunication",
			"caption": "AccountCommunicationDetailEmbeddedDetailAccount_caption",
			"operation": "insert",
			"position": 1
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "99bbff2e-907d-44a0-86ad-5d5d320e1ffa",
		"values": {
			"row": 1,
			"content": "Number",
			"columnName": "Number",
			"dataValueType": 1,
			"operation": "insert"
		},
		"parentName": "AccountCommunicationDetailEmbeddedDetail",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "d926c65a-c0a6-4c78-9c0a-4d237bfc03c8",
		"values": {
			"row": 0,
			"content": "Type",
			"columnName": "CommunicationType",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "AccountCommunicationDetailEmbeddedDetail",
		"propertyName": "items",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "AccountAddressDetailV2EmbeddedDetail",
		"values": {
			"items": [],
			"rows": 1,
			"isDetail": true,
			"filter": {
				"detailColumn": "Account",
				"masterColumn": "Id"
			},
			"detailSchemaName": "AccountAddressDetailV2",
			"entitySchemaName": "AccountAddress",
			"caption": "AccountAddressDetailV2EmbeddedDetailAccount_caption",
			"operation": "insert",
			"position": 2
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 2
	},
	{
		"operation": "insert",
		"name": "2da5f545-7bfa-4f5d-b942-d63e9c5216d9",
		"values": {
			"row": 0,
			"content": "Address type",
			"columnName": "AddressType",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "AccountAddressDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "2c336ff5-e1dd-4326-8ebd-f1c686f13720",
		"values": {
			"row": 1,
			"content": "Address",
			"columnName": "Address",
			"dataValueType": 1,
			"operation": "insert"
		},
		"parentName": "AccountAddressDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "47a73d75-a377-4ac6-94f3-cdf09a97d9be",
		"values": {
			"row": 2,
			"content": "City",
			"columnName": "City",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "AccountAddressDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 2
	},
	{
		"operation": "insert",
		"name": "efcbf76a-e861-4c55-85ff-d3583a198517",
		"values": {
			"row": 3,
			"content": "State/province",
			"columnName": "Region",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "AccountAddressDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 3
	},
	{
		"operation": "insert",
		"name": "c600f9a4-0eb7-44f4-b61a-d75fecedcbec",
		"values": {
			"row": 4,
			"content": "Country",
			"columnName": "Country",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "AccountAddressDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 4
	},
	{
		"operation": "insert",
		"name": "3a455e66-d474-4113-ad0f-972cdf0d0841",
		"values": {
			"row": 5,
			"content": "ZIP/postal code",
			"columnName": "Zip",
			"dataValueType": 1,
			"operation": "insert"
		},
		"parentName": "AccountAddressDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 5
	},
	{
		"operation": "insert",
		"name": "AccountAnniversaryDetailV2EmbeddedDetail",
		"values": {
			"items": [],
			"rows": 1,
			"isDetail": true,
			"filter": {
				"detailColumn": "Account",
				"masterColumn": "Id"
			},
			"detailSchemaName": "AccountAnniversaryDetailV2",
			"entitySchemaName": "AccountAnniversary",
			"caption": "AccountAnniversaryDetailV2EmbeddedDetailAccount_caption",
			"operation": "insert",
			"position": 3
		},
		"parentName": "settings",
		"propertyName": "columnSets",
		"index": 3
	},
	{
		"operation": "insert",
		"name": "bd55ac0e-1ca6-4dd1-bb2b-f92710a3953e",
		"values": {
			"row": 1,
			"content": "Date",
			"columnName": "Date",
			"dataValueType": 8,
			"operation": "insert"
		},
		"parentName": "AccountAnniversaryDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "d40b73ab-1c15-450b-b5d9-b5a021c909d3",
		"values": {
			"row": 0,
			"content": "Type",
			"columnName": "AnniversaryType",
			"dataValueType": 10,
			"operation": "insert"
		},
		"parentName": "AccountAnniversaryDetailV2EmbeddedDetail",
		"propertyName": "items",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "AccountContactsDetailV2StandartDetail",
		"values": {
			"caption": "AccountContactsDetailV2StandartDetailAccount_caption",
			"entitySchemaName": "Contact",
			"filter": {
				"detailColumn": "Account",
				"masterColumn": "Id"
			},
			"detailSchemaName": "AccountContactsDetailV2",
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "details",
		"index": 0
	},
	{
		"operation": "insert",
		"name": "ActivityDetailV2StandartDetail",
		"values": {
			"caption": "ActivityDetailV2StandartDetailAccount_caption",
			"entitySchemaName": "Activity",
			"filter": {
				"detailColumn": "Account",
				"masterColumn": "Id"
			},
			"detailSchemaName": "ActivityDetailV2",
			"operation": "insert"
		},
		"parentName": "settings",
		"propertyName": "details",
		"index": 1
	},
	{
		"operation": "insert",
		"name": "SocialMessageDetailV2StandartDetail",
		"values": {
			"caption": "SocialMessageDetailCaptionContact_caption",
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
		"index": 2
	}
]