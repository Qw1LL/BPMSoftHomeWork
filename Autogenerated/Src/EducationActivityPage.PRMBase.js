define("EducationActivityPage", [], function() {
	return {
		entitySchemaName: "EducationActivity",
		attributes: {
			"Contact": {
				lookupListConfig: {
					filter: function() {
						return this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
								"Account", this.get("Account"));
					}
				}
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Cost",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 2,
						"layoutName": "Header"
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "Date",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "Header"
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "Contact",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "EducationActivityResult",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 3,
						"layoutName": "Header"
					},
					"contentType": BPMSoft.ContentType.ENUM
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "StatusOfActivity",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 3,
						"layoutName": "Header"
					},
					"contentType": BPMSoft.ContentType.ENUM
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "EducationActivityType",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"contentType": BPMSoft.ContentType.ENUM
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "PaymentMethod",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "Header"
					},
					"contentType": BPMSoft.ContentType.ENUM
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "insert",
				"name": "Description",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 4,
						"layoutName": "Header"
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 8
			}
		]/**SCHEMA_DIFF*/
	};
});
