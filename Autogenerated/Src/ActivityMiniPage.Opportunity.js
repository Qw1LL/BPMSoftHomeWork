define("ActivityMiniPage", ["BusinessRuleModule", "ActivityBusinessRulesMixin"], function() {
	return {
		entitySchemaName: "Activity",
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "ProcessResult",
				"values": {
					"wrapClass": ["activity-opportunity-mini-page-result-container"],
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.ResultControlPlaceholder"
						},
						"isRequired": true
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		attributes: {
			/**
			 * Activity entity opportunity column.
			 * @type {Object}
			 */
			"Opportunity": {
				"lookupListConfig": {
					"filter": function() {
						return this.getOpportunityFilters();
					},
					"columns": ["Account", "Contact"]
				},
				"dependencies": [
					{
						"columns": ["Opportunity"],
						"methodName": "setContactAndAccountByOpportunity"
					}
				]
			}
		},
		mixins: {
			/**
			 * @class ActivityBusinessRulesMixin
			 * Activity business rules mixin.
			 */
			ActivityBusinessRulesMixin: "BPMSoft.ActivityBusinessRulesMixin"
		}
	};
});
