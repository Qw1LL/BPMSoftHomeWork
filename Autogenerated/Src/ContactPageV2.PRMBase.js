define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
		details: /**SCHEMA_DETAILS*/{
			"Certificate": {
				"schemaName": "CertificateDetail",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "Id"
				}
			},
			"EducationAndCertificate": {
				"schemaName": "EducationAndCertificateDetail",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "Id"
				}
			}
		}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "EducationAndCertificate",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "HistoryTab",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Certificate",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				},
				"parentName": "HistoryTab",
				"propertyName": "items"
			}
		]/**SCHEMA_DIFF*/,
		methods: {},
		rules: {}
	};
});
