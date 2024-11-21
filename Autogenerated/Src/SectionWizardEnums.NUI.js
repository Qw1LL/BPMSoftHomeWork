define("SectionWizardEnums", ["ext-base", "BPMSoft", "SectionWizardEnumsResources"],
	function() {
		Ext.ns("BPMSoft.SectionWizardEnums");

		/**
		 * @enum
		 * Section wizard page names
		 */
		BPMSoft.SectionWizardEnums.PageName = {
			/**
			 * Main settings page name.
			 */
			MAIN_SETTINGS: "MainSettings",
			/**
			 * Page designer page name.
			 */
			PAGE_DESIGNER: "PageDesigner",
			/**
			 * Page DCM cases.
			 */
			PAGE_CASES: "Cases"
		};
	}
);
