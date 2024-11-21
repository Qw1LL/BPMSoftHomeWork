define("SectionProcessSettingsManager", ["BaseProcessSettingsManager", "SectionProcessSettingsManagerItem"],
		function() {
	Ext.define("BPMSoft.SectionProcessSettingsManager", {
		extend: "BPMSoft.BaseProcessSettingsManager",
		alternateClassName: "BPMSoft.SectionProcessSettingsManager",
		singleton: true,

		/**
		 * @inheritdoc BPMSoft.BaseProcessSettingsManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.SectionProcessSettingsManagerItem",

		/**
		 * @inheritdoc BPMSoft.BaseProcessSettingsManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "ProcessInModules",

		/**
		 * @inheritdoc BPMSoft.BaseProcessSettingsManager#additionalColumnNames
		 * @overridden
		 */
		additionalColumnNames : {
			moduleId: "SysModuleId"
		},

		/**
		 * @inheritdoc BPMSoft.BaseProcessSettingsManager#getSchemaDataName
		 * @overridden
		 */
		getSchemaDataName: function() {
			return "RunProcessFromSections";
		}
	});
	return BPMSoft.SectionProcessSettingsManager;
});
