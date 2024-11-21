define("SspPageWizard", ["PageWizard", "BaseWizardModule", "PortalSchemaAccessListManager",
		"PortalColumnAccessListManager", "css!PageWizard"], function() {

	Ext.define("BPMSoft.configuration.SspPageWizard", {
		extend: "BPMSoft.configuration.PageWizard",
		alternateClassName: "BPMSoft.SspPageWizard",

		/**
		 * @inheritDoc BPMSoft.configuration.PageWizard#getPageDesignerModuleName
		 * @override
		 */
		getPageDesignerModuleName: function() {
			return "SspPageDesignerModule";
		},

		/**
		 * Initialize PortalSchemaAccessListManager.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		_initPortalSchemaAccessListManager: function(callback) {
			BPMSoft.PortalSchemaAccessListManager.initialize(null, callback, this);
		},

		/**
		 * Initialize PortalColumnAccessListManager.
		 * @private
		 * @param {Function} callback Callback function.
		 */
		_initPortalColumnAccessListManager: function(callback) {
			BPMSoft.PortalColumnAccessListManager.initialize(null, callback, this);
		},

		/**
		 * @inheritDoc BPMSoft.ApplicationStructureItemWizard#getInitChain
		 * @override
		 */
		getInitChain: function() {
			const chain = this.callParent(arguments);
			chain.push(this._initPortalSchemaAccessListManager);
			chain.push(this._initPortalColumnAccessListManager);
			return chain;
		},

		/**
		 * @inheritDoc BPMSoft.ApplicationStructureItemWizard#getRegistrationDataSteps
		 * @override
		 */
		getRegistrationDataSteps: function() {
			const steps = this.callParent(arguments);
			steps.push({
					manager: BPMSoft.PortalSchemaAccessListManager,
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.PortalColumnAccessListManager,
					updateSchemaDataAction: true
				},
				{
					manager: BPMSoft.SspPageDetailsManager,
					processMessage: this.getLocalizableString("DetailRegistrationMessage"),
					updateSchemaDataAction: true
				});
			return steps;
		},

		/**
		 * @inheritdoc BPMSoft.ApplicationStructureItemWizard#getSteps
		 * @override
		 */
		getSteps: function () {
			const steps = this.callParent(arguments);
			let businessRuleSectionStep = _.findWhere(steps, {"schemaName": "BusinessRuleSection"});
			if (this.Ext.isEmpty(businessRuleSectionStep)) {
				return steps;
			}
			businessRuleSectionStep.schemaName = "SspBusinessRuleSection";
			return steps;
		}
	});

	return BPMSoft.SspPageWizard;
});
