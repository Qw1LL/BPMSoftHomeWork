define("AccountPageV2", [],
function() {
	return {
		entitySchemaName: "Account",
		details: /**SCHEMA_DETAILS*/{
			Cases: {
				schemaName: "CaseDetail",
				filter: {
					masterColumn: "Id",
					detailColumn: "Account"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "HistoryTabContainer",
				"index": 0,
				"propertyName": "items",
				"name": "Cases",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.DETAIL
				}
			}
		]/**SCHEMA_DIFF*/,
		attributes: {},
		methods: {},
		rules: {},
		userCode: {}
	};
});
