define("CertificatePage", ["BusinessRuleModule"], function(BusinessRuleModule) {
	return {
		entitySchemaName: "Certificate",
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "EducationActivity",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ResultScore",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "IssueDate",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ExpireDate",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 3
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "CompetenceLevel",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 4
					},
					"contentType": BPMSoft.ContentType.ENUM
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "CertificateNumber",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 5
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "Comments",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 6
					}
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			}
		]/**SCHEMA_DIFF*/,
		rules: {
			"EducationActivity": {
				"FiltrationEducationActivityByContact": {
					"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
					"autocomplete": false,
					"autoClean": false,
					"baseAttributePatch": "Contact",
					"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
					"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
					"attribute": "Contact"
				}
			}
		}
	};
});
