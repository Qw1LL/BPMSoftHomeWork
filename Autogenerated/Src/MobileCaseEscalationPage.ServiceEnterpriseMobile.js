/* globals Case: false */
BPMSoft.PageCache.addItem("CaseEscalationPage", {
	controllerName: "BPMSoft.configuration.controller.CaseEscalationPage",
	pageSchemaName: "CaseEscalationPage",
	viewXClass: "BPMSoft.configuration.view.CaseEscalationPage"
});

/**
 * @class BPMSoft.configuration.view.CaseEscalationPage
 */
Ext.define("BPMSoft.configuration.view.CaseEscalationPage", {
	extend: "BPMSoft.view.BaseEditPage",

	config: {

		/**
		 * @inheritdoc
		 */
		id: "CaseEscalationPage"

	}

});

/**
 * @class BPMSoft.configuration.controller.CaseEscalationPage
 */
Ext.define("BPMSoft.configuration.controller.CaseEscalationPage", {
	extend: "BPMSoft.configuration.controller.EditPage",

	config: {

		refs: {

			/**
			 * @inheritdoc
			 */
			view: "#CaseEscalationPage"

		},

		pageType: BPMSoft.PageTypes.Custom,

		/**
		 * @inheritdoc
		 */
		businessRuleConfigs: [{
			name: "CaseEscalationOwnerOrGroupRequirementRule",
			ruleType: BPMSoft.RuleTypes.Requirement,
			requireType: BPMSoft.RequirementTypes.OneOf,
			events: [BPMSoft.BusinessRuleEvents.Save, BPMSoft.BusinessRuleEvents.ValueChanged],
			triggeredByColumns: ["Owner", "Group"]
		}],

		/**
		 * @inheritdoc
		 */
		columnConfigs: [
			{
				name: "SupportLevel"
			},
			{
				name: "Owner",
				customEditConfig: {
					required: true
				}
			},
			{
				name: "Group",
				customEditConfig: {
					required: true
				}
			}
		]

	},

	statics: {

		/**
		 * @inheritdoc
		 */
		Model: Case

	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getCustomTitle: function() {
		return BPMSoft.LS.CaseEscalationPageTitle;
	}

});
