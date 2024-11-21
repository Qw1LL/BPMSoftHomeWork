define("ProcessSettingsModule", ["BaseSchemaModuleV2", "css!ProcessSettingsModule"], function() {
	Ext.define("BPMSoft.configuration.ProcessSettingsModule", {
		alternateClassName: "BPMSoft.ProcessSettingsModule",
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ProcessSettingsPage";
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn
	});
	return BPMSoft.ProcessSettingsModule;
});
