define("BulkEmailSubscriptionPageV2", ["BPMSoft"], function(BPMSoft) {
	return {
		entitySchemaName: "BulkEmailSubscription",
		attributes: {
			BulkEmailType: {
				lookupListConfig: {
					filters: [
						function() {
							var contact = this.get("Contact");
							var filterGroup = Ext.create("BPMSoft.FilterGroup");
							filterGroup.add("IsSignable",
								BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL,
									"IsSignable",
									1));
							var existsSubFilters = this.BPMSoft.createFilterGroup();
							existsSubFilters.addItem(this.BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "Contact", contact.value));
							filterGroup.add("Exists",
								BPMSoft.createNotExistsFilter("[BulkEmailSubscription:BulkEmailType].Id",
								existsSubFilters));
							return filterGroup;
						}
					]
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"propertyName": "items",
				"name": "BulkEmailSubscriptionContainer",
				"parentName": "CardContentContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "BulkEmailSubscriptionContainer",
				"propertyName": "items",
				"name": "Contact",
				"values": {
					"layout": {"column": 0, "row": 0},
					"enabled": false
				}
			},
			{
				"operation": "insert",
				"parentName": "BulkEmailSubscriptionContainer",
				"propertyName": "items",
				"name": "BulkEmailType",
				"values": {
					"layout": {"column": 0, "row": 1}
				}
			},
			{
				"operation": "insert",
				"parentName": "BulkEmailSubscriptionContainer",
				"propertyName": "items",
				"name": "BulkEmailSubsStatus",
				"values": {
					"contentType": BPMSoft.ContentType.ENUM,
					"layout": {"column": 0, "row": 2}
				}
			},
			{
				"operation": "remove",
				"name": "actions"
			}
		]/**SCHEMA_DIFF*/
	};
});
