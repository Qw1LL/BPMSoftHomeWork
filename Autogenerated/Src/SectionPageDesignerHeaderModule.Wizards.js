define("SectionPageDesignerHeaderModule", [
	"PageDesignerHeaderModule",
	"css!WizardHeaderModule",
	"SectionPageDesignerHeaderViewConfig",
	"SectionPageDesignerHeaderViewModel"
], function() {
	/**
	 * Class of SectionPageDesignerHeaderModule.
	 */
	Ext.define("BPMSoft.SectionPageDesignerHeaderModule", {
		extend: "BPMSoft.PageDesignerHeaderModule",

		/**
		 * @inheritdoc BPMSoft.PageDesignerHeaderModule#viewConfigClassName
		 * @override
		 */
		viewConfigClassName: "BPMSoft.SectionPageDesignerHeaderViewConfig",

		/**
		 * @inheritdoc BPMSoft.PageDesignerHeaderModule#designerViewModelClassName
		 * @override
		 */
		viewModelClassName: "BPMSoft.SectionPageDesignerHeaderViewModel"

	});

	return BPMSoft.SectionPageDesignerHeaderModule;
});
