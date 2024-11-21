define("ESNNotificationModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.ESNNotificationModule
	 * ESNNotificationModule is used for loading ESN notifications.
	 */
	Ext.define("BPMSoft.configuration.ESNNotificationModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.ESNNotificationModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @overridden
		 */
		useHistoryState: false,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ESNNotificationSchema";
		}
	});
	return BPMSoft.ESNNotificationModule;
});
