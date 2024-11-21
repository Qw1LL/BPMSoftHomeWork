define("OpportunityTimelineItemView", ["BaseTimelineItemView"],
	function() {
	/**
	 * @class BPMSoft.configuration.OpportunityTimelineItemView
	 * Opportunity timeline item view class.
	 */
	Ext.define("BPMSoft.configuration.OpportunityTimelineItemView", {
		extend: "BPMSoft.BaseTimelineItemView",
		alternateClassName: "BPMSoft.OpportunityTimelineItemView",

		// region Methods: Protected

		/**
		 * Returns opportunity info view config.
		 * @protected
		 * @return {Object} Opportunity info view config.
		 */
		getOpportunityInfoContainerViewConfig: function() {
			var budgetFieldConfig = {
				"textValueConverter": "getFormattedFloatNumberValue"
			};
			return {
				"name": "OpportunityInfoContainer",
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"classes": {
					"wrapClassName": ["timeline-tile-info-container"]
				},
				"items": [
					this.getTextWithLabelContainerViewConfig("Resources.Strings.LeadTypeLabel", "LeadType"),
					this.getTextWithLabelContainerViewConfig("Resources.Strings.BudgetLabel", "Budget", budgetFieldConfig),
					this.getTextWithLabelContainerViewConfig("Resources.Strings.StageLabel", "Stage")
				]
			};
		},

		/**
		 * @inheritdoc BPMSoft.BaseTimelineItemView#getBodyViewConfig
		 * @override
		 */
		getBodyViewConfig: function() {
			var bodyConfig = this.callParent(arguments);
			bodyConfig.items = [this.getOpportunityInfoContainerViewConfig()];
			return bodyConfig;
		}

		// endregion

	});
});
