define("OutdatedModuleWatcher", [], function() {
	/**
	 * Outdated module watcher.
	 */
	Ext.define("BPMSoft.OutdatedModuleWatcher", {
		extend: "BPMSoft.BaseModule",
		Ext: null,
		sandbox: null,
		BPMSoft: null,

		//region Methods: Private

		/**
		 * Requires module descriptor.
		 * @private
		 * @param {String} moduleName Module name.
		 */
		_forceRequireModuleDescriptors: function(moduleName) {
			if (BPMSoft.useStaticFileContent) {
				this._resetBundleRequireConfig();
			}
			if (BPMSoft.useParallelSchemaBuilding) {
				const structures = BPMSoft.configuration.Structures || {};
				delete structures[moduleName];
			}
			require.undef(moduleName);
			require.undef(moduleName + "Resources");
			this.sandbox.requireModuleDescriptors(["force!" + moduleName], BPMSoft.emptyFn, this);
		},

		/**
		 * Resets bundle require config.
		 * @private
		 */
		_resetBundleRequireConfig: function() {
			BPMSoft.SchemaManagerEventObserver.resetBundleRequireConfig();
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseViewModule#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			BPMSoft.ServerChannel.on(BPMSoft.ServerChannelSender.BROADCAST_MESSAGE,
				this.onBroadcastServerMessage, this);
			BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE,
				this.onConfigurationBuildMessageReceived, this);
		},

		/**
		 * Handles the broadcast server message.
		 * @protected
		 * @param {BPMSoft.ServerChannel} channel Channel messaging server BPMCRM.
		 * @param {Object} broadcastMessage Broadcast message.
		 */
		onBroadcastServerMessage: function(channel, broadcastMessage) {
			if (broadcastMessage) {
				var moduleName = broadcastMessage.name;
				switch (broadcastMessage.event) {
					case "ClientUnitSchema_Outdated":
					case "EntitySchema_Outdated":
						this._forceRequireModuleDescriptors(moduleName);
						break;
					default:
						return;
				}
			}
		},

		/**
		 * Handles the message of configuration build process.
		 * @param {BPMSoft.ServerChannel} channel Channel messaging server.
		 * @param {Object} message Channel message.
		 */
		onConfigurationBuildMessageReceived: function(channel, message) {
			if (!BPMSoft.useStaticFileContent || !message) {
				return;
			}
			if (message.Header.Sender === "ConfigurationBuildCompleted") {
				var decodedMessage = BPMSoft.decode(message.Body || "{}");
				if (decodedMessage.configurationHash) {
					BPMSoft.configurationContentHash = decodedMessage.configurationHash;
				}
			}
		}

		//endregion

	});

	return BPMSoft.OutdatedModuleWatcher;
});
