define("DcmWizardStep", ["BPMSoft", "ext-base", "WizardStep", "DcmUtilities"], function(BPMSoft, Ext) {
	/**
	 * @class BPMSoft.configuration.DcmWizardStep
	 * DCM wizard step view model.
	 */
	Ext.define("BPMSoft.configuration.DcmWizardStep", {
		extend: "BPMSoft.WizardStep",
		alternateClassName: "BPMSoft.DcmWizardStep",

		/**
		 * @inheritdoc WizardStep#initCanUseStep
		 * @overridden
		 */
		initCanUseStep: function(callback, scope) {
			BPMSoft.DcmUtilities.checkCanManageDcmRights(function(allow) {
				this.set(this.canUseStepPropertyName, allow);
				Ext.callback(callback, scope);
			}, this);
		}

	});

	return BPMSoft.DcmWizardStep;
});
