define("FileImportWizardHeaderViewModel", ["FileImportWizardHeaderViewModelResources", "WizardHeaderModule"],
		function(resources) {
	Ext.define("BPMSoft.configuration.FileImportWizardHeaderViewModel", {
		extend: "BPMSoft.WizardHeaderViewModel",
		alternateClassName: "BPMSoft.FileImportWizardHeaderViewModel",

		/**
		 * @inheritdoc
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.initResourcesValues(resources);
		},

		/**
		 * Handles close button click.
		 */
		closeButtonClick: function() {
			this.cancelButtonClick();
		},

		/**
		 * Handles previous step button click.
		 */
		previousStepButtonClick: function() {
			this.previous();
		},

		/**
		 * Handles next step button click.
		 */
		nextStepButtonClick: function() {
			this.next();
		},

		/**
		 * Gets wizard header container marker value.
		 * @return {String}
		 */
		getWizardHeaderContainerMakerValue: function() {
			return this.get("currentStep");
		},

		/**
		 * @inheritdoc BPMSoft.WizardHeaderViewModel#isCancelButtonVisible
		 * @override
		 */
		isCancelButtonVisible: function() {
			return true;
		},

		/**
		 * @inheritdoc BPMSoft.WizardHeaderViewModel#isSaveButtonVisible
		 * @override
		 */
		isSaveButtonVisible: function() {
			return true;
		},

		/**
		 * @inheritdoc BPMSoft.WizardHeaderViewModel#isUtilsFooterVisible
		 * @override
		 */
		isUtilsFooterVisible: function() {
			return false;
		}
	});
});
