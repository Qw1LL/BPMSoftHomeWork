define("FileImportWizardStep", ["BPMSoft", "ext-base", "WizardStep"], function(BPMSoft, Ext) {
	/**
	 * @class BPMSoft.configuration.FileImportWizardStep
	 * FileImportWizardStep wizard step view model.
	 */
	Ext.define("BPMSoft.configuration.FileImportWizardStep", {
		extend: "BPMSoft.WizardStep",
		alternateClassName: "BPMSoft.FileImportWizardStep",

		/**
		 * @inheritdoc WizardStep#initCanUseStep
		 * @overridden
		 */
		initCanUseStep: function(callback, scope) {
			this.set(this.canUseStepPropertyName, true);
		}

	});

	return BPMSoft.FileImportWizardStep;
});