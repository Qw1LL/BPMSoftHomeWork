define("CampaignParticipantPage", [], function() {
	return {
		entitySchemaName: "CampaignParticipant",
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "Contactf0a1fe21-82fe-49c8-a2d3-847f809048e4",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "Header"
					},
					"bindTo": "Contact"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CampaignItem7a4a7c6a-f7f3-48b1-87c6-8418dbda609c",
				"values": {
					"contentType": this.BPMSoft.ContentType.ENUM,
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "Header"
					},
					"bindTo": "CampaignItem"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "StepCompleted068a0f21-0b6d-4228-b0d4-5654c0e26493",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "Header"
					},
					"bindTo": "StepCompleted"
				},
				"parentName": "Header",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "remove",
				"name": "actions"
			}
		]/**SCHEMA_DIFF*/,
		attributes: {
			"CampaignItem": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				lookupListConfig: {
					filter: function() {
						return this.campaignItemFilters();
					}
				}
			},
			"Contact": {
				dataValueType: this.BPMSoft.DataValueType.LOOKUP,
				lookupListConfig: {
					filter: function() {
						return this.campaignContactFilter();
					}
				}
			}
		},
		methods: {

			/**
			 * Creates filter for campaign items by CampaignId.
			 * @returns {BPMSoft.CompareFilter} Filters for select campaign items.
			 * @protected
             */
			campaignItemFilters: function() {
				var filters = this.BPMSoft.createFilterGroup();
				filters.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
				var notInCampaignElementType = this.BPMSoft.createColumnInFilterWithParameters(
					"CampaignElementType", ["Transition", "StartSignal"]);
				notInCampaignElementType.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
				filters.addItem(notInCampaignElementType);
				filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "Campaign", this.get("Campaign").value)
				);
				filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, "IsDeleted", false)
				);
				return filters;
			},

			/**
			 * Creates filter for campaign contacts by CampaignId and exclude existing campaign audience contacts
			 * @returns {BPMSoft.ExistsFilter} Filter for select contacts.
             */
			campaignContactFilter: function() {
				var notExistsFilter = this.BPMSoft.createNotExistsFilter("[CampaignParticipant:Contact:Id].Id");
				notExistsFilter.subFilters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Campaign", this.get("Campaign").value));
				return notExistsFilter;
			}
		},
		rules: {},
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/
	};
});
