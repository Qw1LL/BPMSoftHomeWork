define("SectionMiniPageWizard", ["SectionPageWizard", "css!PageWizard"], function() {

	/**
	 * Class of visual module of representation for the page wizard
	 */
	Ext.define("BPMSoft.configuration.SectionMiniPageWizard", {
		extend: "BPMSoft.configuration.SectionPageWizard",
		alternateClassName: "BPMSoft.SectionMiniPageWizard",

		//region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.SectionPageWizard#pageWizardUrl
		 * @override
		 */
		pageWizardUrl: BPMSoft.DesignTimeEnums.WizardUrl.SECTION_MINIPAGE_WIZARD_URL,

		//endregion

		//region Methods: Private

		/**
		 * @inheritdoc BPMSoft.SectionPageWizard#getPageDesignerModuleName
		 * @override
		 */
		getPageDesignerModuleName: function() {
			return "MiniPageDesignerModule";
		}

		//endregion
	});

	return BPMSoft.SectionMiniPageWizard;
});
