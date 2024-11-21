define("InvoiceSearchRowSchema", ["MultiLookupUtilitiesMixin"], function() {
	return {
		attributes: {
			"Client": {
				"caption": {"bindTo": "Resources.Strings.ClientColumnCaption"},
				"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
				"multiLookupColumns": ["Contact", "Account"]
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "remove",
				"name": "EntitySchemaCaption"
			},
			{
				"operation": "merge",
				"name": "FoundColumnsContainerList",
				"values": {
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "StartDate",
				"values": {
					"layout": {
						"column": 13,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Amount",
				"values": {
					"layout": {
						"column": 18,
						"row": 0,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Client",
				"values": {
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "Owner",
				"values": {
					"layout": {
						"column": 13,
						"row": 1,
						"colSpan": 6
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "DataContainer",
				"propertyName": "items",
				"name": "PaymentStatus",
				"values": {
					"layout": {
						"column": 18,
						"row": 1,
						"colSpan": 6
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
