define("ContactPageV2", [],
function() {
	return {
		entitySchemaName: "Contact",
		details: /**SCHEMA_DETAILS*/{
			Cases: {
				schemaName: "CaseDetail",
				filter: {
					masterColumn: "Id",
					detailColumn: "Contact"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "HistoryTab",
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
