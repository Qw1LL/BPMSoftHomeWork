define("FileImportWizardHeaderModule", ["WizardHeaderModule", "FileImportWizardHeaderViewConfig",
		"FileImportWizardHeaderViewModel", "css!WizardHeaderModule"], function() {
	Ext.define("BPMSoft.configuration.FileImportWizardHeaderModule", {
		extend: "BPMSoft.WizardHeaderModule",
		alternateClassName: "BPMSoft.FileImportWizardHeaderModule",

		//region Properties: Public

		/**
		 * @inheritdoc
		 * @overridden
		 */
		viewConfigClassName: "BPMSoft.FileImportWizardHeaderViewConfig",

		/**
		 * @inheritdoc
		 * @overridden
		 */
		viewModelClassName: "BPMSoft.FileImportWizardHeaderViewModel",

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc
		 * @overridden
		 */
		showLoadingMask: function() {
			if (this.showMask && this.renderToId) {
				this.maskId = BPMSoft.Mask.show();
			}
		}

		//endregion

	});
	return BPMSoft.FileImportWizardHeaderModule;
});
