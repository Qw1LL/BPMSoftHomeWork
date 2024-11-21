define("NotificationsSettingsModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.NotificationsSettingsModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.NotificationsSettingsModule",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @overridden
		 */
		useHistoryState: true,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#init
		 * @overridden
		 */
		init: function() {
			this.sandbox.registerMessages(this.messages);
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "NotificationsSettingsSchema";
		}
	});

	return BPMSoft.NotificationsSettingsModule;
});
