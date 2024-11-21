define("SspAccountProfilePage", [],
function() {
	return {
		entitySchemaName: "Account",
		messages: {},
		details: /**SCHEMA_DETAILS*/{
			"Services": {
				"schemaName": "ServiceRecepientsDetail",
				"entitySchemaName": "VwServiceRecepients",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Account"
				}
			},
			"ServicePacts": {
				"schemaName": "ServicePactRecipientsDetail",
				"entitySchemaName": "ServiceObject",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Account"
				}
			},
			"AccountAddress": {
				"schemaName": "AccountAddressDetailV2",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Account"
				}
			},
			"ConfItem": {
				"schemaName": "SSPConfItemInAccountDetail",
				"entitySchemaName": "ConfItemUser",
				"filter": {
					"masterColumn": "Id",
					"detailColumn": "Account"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "AccountPageServiceTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 2,
				"values": {
					"caption": {"bindTo": "Resources.Strings.MaintenanceTab"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Services",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "AccountPageServiceTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ServicePacts",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "AccountPageServiceTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "AccountAddress",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "AccountPageServiceTab",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ConfItem",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "AccountPageServiceTab",
				"propertyName": "items",
				"index": 4
			}
		]/**SCHEMA_DIFF*/,
		attributes: {},
		methods: {},
		rules: {},
		userCode: {}
	};
});
