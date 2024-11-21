define("CampaignTargetPageV2", [], function() {
		return {
			entitySchemaName: "CampaignTarget",
			attributes: {
				"Campaign": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP
				},
				"Contact": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filters: [
							function() {
								var campaign = this.get("Campaign");
								var filterGroup = Ext.create("BPMSoft.FilterGroup");
								var existsSubFilters = this.BPMSoft.createFilterGroup();
								existsSubFilters.addItem(this.BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "Campaign", campaign.value));
								filterGroup.add("Exists",
									BPMSoft.createNotExistsFilter("[CampaignTarget:Contact].Id",
										existsSubFilters));
								return filterGroup;
							}
						]
					}
				}
			},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Campaign",
					"values": {
						"bindTo": "Campaign",
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						},
						"enabled": false
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Contact",
					"values": {
						"bindTo": "Contact",
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "remove",
					"name": "actions"
				}
			]/**SCHEMA_DIFF*/
		};
	});
