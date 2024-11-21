define("SectionPageDesignerHeaderViewModel", ["MaskHelper", "PageDesignerHeaderViewModel"], function() {

	/**
	 * Class for SectionPageDesignerHeaderViewModel.
	 */
	Ext.define("BPMSoft.configuration.SectionPageDesignerHeaderViewModel", {
		extend: "BPMSoft.configuration.PageDesignerHeaderViewModel",
		alternateClassName: "BPMSoft.SectionPageDesignerHeaderViewModel",

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.WizardHeaderViewModel#saveButtonClick
		 * @override
		 */
		saveButtonClick: function() {
			this.sandbox.publish("CurrentStepChange", null, [this.sandbox.id]);
		},

		/**
		 * @inheritdoc BPMSoft.WizardHeaderViewModel#isSaveButtonVisible
		 * @override
		 */
		isSaveButtonVisible: function() {
			if (this?.getCurrentStep()?.get("Id") == "PageDesigner") {
				return true;
			} else {
				return false;
			}
		}

		//endregion

	});

	return BPMSoft.SectionPageDesignerHeaderViewModel;
});
