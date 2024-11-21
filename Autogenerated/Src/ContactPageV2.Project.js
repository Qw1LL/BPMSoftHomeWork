define("ContactPageV2", ["ConfigurationConstants"], function(ConfigurationConstants) {
	return {
		entitySchemaName: "Contact",
		details: /**SCHEMA_DETAILS*/{
			Project: {
				schemaName: "ProjectDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "Contact"
				}
			},
			InternalRate: {
				schemaName: "ContactInternalRateDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "Contact"
				}
			},
			ExternalRate: {
				schemaName: "ContactExternalRateDetailV2",
				filter: {
					masterColumn: "Id",
					detailColumn: "Contact"
				}
			}
		}/**SCHEMA_DETAILS*/,
		methods: {
			getRateDetailsVisible: function() {
				if (this.get("Type")) {
					return this.get("Type").value === ConfigurationConstants.ContactType.Employee;
				}
				return false;
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "HistoryTab",
				"index": 7,
				"propertyName": "items",
				"name": "Project",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL
				}
			},
			{
				"operation": "insert",
				"parentName": "JobTabContainer",
				"propertyName": "items",
				"name": "InternalRate",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL,
					"visible": {
						"bindTo": "getRateDetailsVisible"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "JobTabContainer",
				"propertyName": "items",
				"name": "ExternalRate",
				"values": {
					"itemType": BPMSoft.ViewItemType.DETAIL,
					"visible": {
						"bindTo": "getRateDetailsVisible"
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
