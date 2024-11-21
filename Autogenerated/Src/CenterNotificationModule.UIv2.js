define("CenterNotificationModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.CenterNotificationModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.CenterNotificationModule",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @overridden
		 */
		useHistoryState: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "CenterNotificationSchema";
		}
	});

	return BPMSoft.CenterNotificationModule;
});
