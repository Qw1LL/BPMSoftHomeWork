define("ActivityPageV2", ["BusinessRuleModule", "ActivityBusinessRulesMixin"],
	function() {
		return {
			entitySchemaName: "Activity",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {
				"Opportunity": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						filter: function() {
							return this.getOpportunityFilters();
						},
						columns: ["Account", "Contact"]
					},
					dependencies: [
						{
							columns: ["Opportunity"],
							methodName: "setContactAndAccountByOpportunity"
						}
					]
				}
			},
			mixins: {
				ActivityBusinessRulesMixin: "BPMSoft.ActivityBusinessRulesMixin"
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
