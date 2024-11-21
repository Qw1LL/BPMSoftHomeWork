/* globals Case: false */
/**
 * @class BPMSoft.configuration.controller.ServiceCasePreviewPage
 */
Ext.define("BPMSoft.configuration.controller.ServiceCasePreviewPage", {
	extend: "BPMSoft.configuration.controller.CasePreviewPage",
	alternateClassName: "BPMSoft.configuration.ServiceCasePreviewPageController",

	statics: {

		/**
		 * @inheritdoc
		 */
		Model: Case

	},

	/**
	 * Opens case escalation page.
	 * @protected
	 */
	openCaseEscalationPage: function() {
		BPMSoft.util.openCachedPage("CaseEscalationPage", {
			recordId: this.record.getId()
		});
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	onActionExecutionStart: function(action) {
		var config = action.config;
		if (config.name === "escalate") {
			this.openCaseEscalationPage();
		} else {
			this.callParent(arguments);
		}
	},

	/**
	 * @protected
	 * @virtual
	 */
	getEscalateActionConfig: function() {
		return {
			name: "escalate",
			title: BPMSoft.LS.ServiceCasePreviewPageEscalateActionTitle,
			iconCls: "cf-action-escalation-icon",
			useMask: false,
			position: 4
		};
	},

	/**
	 * @inheritdoc
	 * @protected
	 * @overridden
	 */
	getCustomActions: function() {
		var actions = [this.getEscalateActionConfig()];
		var parentActions = this.callParent(arguments);
		if (parentActions) {
			actions = actions.concat(parentActions);
		}
		return actions;
	}

});
