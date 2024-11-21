define("DetailProcessSettingsManager", ["BaseProcessSettingsManager", "DetailProcessSettingsManagerItem"],
		function() {
	Ext.define("BPMSoft.DetailProcessSettingsManager", {
		extend: "BPMSoft.BaseProcessSettingsManager",
		alternateClassName: "BPMSoft.DetailProcessSettingsManager",
		singleton: true,

		/**
		 * @inheritdoc BPMSoft.BaseProcessSettingsManager#itemClassName
		 * @overridden
		 */
		itemClassName: "BPMSoft.DetailProcessSettingsManagerItem",

		/**
		 * @inheritdoc BPMSoft.BaseProcessSettingsManager#entitySchemaName
		 * @overridden
		 */
		entitySchemaName: "ProcessInDetails",

		/**
		 * @inheritdoc BPMSoft.BaseProcessSettingsManager#additionalColumnNames
		 * @overridden
		 */
		additionalColumnNames : {
			detailId: "SysDetailId"
		},

		/**
		 * @inheritdoc BPMSoft.BaseProcessSettingsManager#getSchemaDataName
		 * @overridden
		 */
		getSchemaDataName: function() {
			return "RunProcessFromDetails";
		}
	});
	return BPMSoft.DetailProcessSettingsManager;
});
