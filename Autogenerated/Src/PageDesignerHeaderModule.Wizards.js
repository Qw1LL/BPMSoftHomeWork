define("PageDesignerHeaderModule", [
	"WizardHeaderModule",
	"css!WizardHeaderModule",
	"PageDesignerHeaderViewConfig",
	"PageDesignerHeaderViewModel"
], function() {
	/**
	 * Class of PageDesignerHeaderModule.
	 */
	Ext.define("BPMSoft.PageDesignerHeaderModule", {
		extend: "BPMSoft.WizardHeaderModule",

		/**
		 * @inheritdoc BPMSoft.WizardHeaderModule#viewConfigClassName
		 * @overridden
		 */
		viewConfigClassName: "BPMSoft.PageDesignerHeaderViewConfig",

		/**
		 * @inheritdoc BPMSoft.WizardHeaderModule#designerViewModelClassName
		 * @overridden
		 */
		viewModelClassName: "BPMSoft.PageDesignerHeaderViewModel"

	});
	return BPMSoft.PageDesignerHeaderModule;
});
