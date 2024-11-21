define("MobileSectionDesignerEnums", ["MobileSectionDesignerEnumsResources"], function() {

	Ext.ns("BPMSoft.MobileSectionDesignerEnums");

	/**
	 * Mobile base grid settings schema UId.
	 * @enum
	 */
	BPMSoft.MobileSectionDesignerEnums.BaseMobileGridPageSettingsUId = "d95270f5-6b67-444d-83ac-5a1555857650";

	/**
	 * Default modules for new workplace.
	 * @Array
	 */
	BPMSoft.MobileSectionDesignerEnums.DefaultManifestModules = ["Contact", "Account", "Activity", "SocialMessage"];

	/**
	 * List of modules that are not configurable.
	 * @Array
	 */
	BPMSoft.MobileSectionDesignerEnums.NotConfigurableModules = ["SocialMessage", "SysDashboard", "Approval"];

	/**
	 * List of non-standard modules.
	 * @enum
	 * Key: module name
	 * Value: module code (from SysModule table)
	 */
	BPMSoft.MobileSectionDesignerEnums.ModuleWithoutSysModuleEntity = {
		SysDashboard: "Dashboard",
		Approval: "Approval"
	};

});
