define("ConfigurationBuildWatcher", [], function() {
	/**
	 * Global search configuration build watcher.
	 */
	Ext.define("BPMSoft.ConfigurationBuildWatcher", {
		extend: "BPMSoft.BaseModule",
		Ext: null,
		sandbox: null,
		BPMSoft: null,

		_sysSettings: ["GlobalSearchLookupFilterEnabled", "GlobalSearchIndexedDataConfig"],

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE,
				this.onConfigurationBuildMessageReceived, this);
		},

		_needReloadIndexingConfigs: function(message) {
			const header = message && message.Header || {};
			const body = message && message.Body;
			if (header.Sender === "ConfigurationBuildCompleted") {
				return true;
			}
			return header.Sender === "SysSettingsChanged" && this._sysSettings.includes(body);
		},

		/**
		 * Handles the message of configuration build process.
		 * @param {BPMSoft.ServerChannel} channel Channel messaging server.
		 * @param {Object} message Channel message.
		 */
		onConfigurationBuildMessageReceived: function(channel, message) {
			if (this._needReloadIndexingConfigs(message)) {
				BPMSoft.ConfigurationServiceProvider.callService({
					serviceName: "IndexingConfigService",
					methodName: "SendIndexationConfigs"
				}, BPMSoft.emptyFn, this);
			}
		}

		//endregion

	});

	return BPMSoft.ConfigurationBuildWatcher;
});
