define("CustomProcessPageV2", ["BaseFiltersGenerateModule"],
function(BaseFiltersGenerateModule) {
	return {
		entitySchemaName: "Contact",
		columns: {},
		details: /**SCHEMA_DETAILS*/{
		}/**SCHEMA_DETAILS*/,
		methods: {},
		attributes: {
			"Owner": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"values": {
					"itemType": 7,
					"name": "CustomProcessPageGeneralTabContainer",
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralTabContainer",
				"propertyName": "items",
				"values": {
					"name": "CustomProcessPageGeneralBlock",
					"itemType": 0,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralBlock",
				"propertyName": "items",
				"values": {
					"name": "Name",
					"bindTo": "Name",
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralBlock",
				"propertyName": "items",
				"values": {
					"name": "Account",
					"bindTo": "Account",
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralBlock",
				"propertyName": "items",
				"values": {
					"name": "SalutationType",
					"bindTo": "SalutationType",
					"layout": {
						"column": 0,
						"row": 2,
						"colSpan": 11
					},
					"contentType": "BPMSoft.ContentType.ENUM"
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralBlock",
				"propertyName": "items",
				"values": {
					"name": "BirthDate",
					"bindTo": "BirthDate",
					"layout": {
						"column": 0,
						"row": 3,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralBlock",
				"propertyName": "items",
				"values": {
					"name": "Owner",
					"bindTo": "Owner",
					"layout": {
						"column": 0,
						"row": 4,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralBlock",
				"propertyName": "items",
				"values": {
					"name": "CustomDateTime",
					"layout": {
						"column": 0,
						"row": 5,
						"colSpan": 11
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralBlock",
				"propertyName": "items",
				"values": {
					"name": "Gender",
					"layout": {
						"column": 0,
						"row": 6,
						"colSpan": 11
					},
					"contentType": "BPMSoft.ContentType.ENUM"
				}
			},
			{
				"operation": "insert",
				"parentName": "CustomProcessPageGeneralBlock",
				"propertyName": "items",
				"values": {
					"name": "AggregateByColumnVirtual",
					"layout": {
						"column": 0,
						"row": 7,
						"colSpan": 11
					},
					"contentType": "BPMSoft.ContentType.ENUM"
				}
			}
		]/**SCHEMA_DIFF*/,
		rules: {},
		userCode: {}
	};
});
