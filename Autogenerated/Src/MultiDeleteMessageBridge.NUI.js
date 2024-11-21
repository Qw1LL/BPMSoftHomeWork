define("MultiDeleteMessageBridge", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			messages: {
				/**
				 * @message ListenMultiDeleteMessages
				 * Notification that module for processing multi delete has been initialized.
				 */
				"ListenMultiDeleteMessages": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message MultiDeleteStateChange
				 * Notification that has been changed the state of the deleted items.
				 */
				"MultiDeleteStateChange": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Flag that shows loaded or not the multi delete message listener.
				 */
				"IsMessagesListenerLoaded": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},

				/**
				 * Last received config for the sandbox message.
				 */
				"LastSandboxConfig": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					value: {}
				}
			},
			methods: {
				/**
				 * Handler for the message listener initialization.
				 * @private
				 */
				onInitMessagesListener: function() {
					var lastSandboxConfig = this.get("LastSandboxConfig");
					var messageName = ConfigurationConstants.MultiDelete.MultiDeleteSandboxMessageName;
					this.set("IsMessagesListenerLoaded", true);
					this.publishMessageResult(messageName, lastSandboxConfig);
				},

				/**
				 * Load MultiDeleteResultModule.
				 * @private
				 */
				loadMultiDeleteResultModule: function() {
					this.sandbox.loadModule("BaseSchemaModuleV2", {
						id: this.sandbox.id + "_multiDeleteResultModule",
						instanceConfig: {
							generateViewContainerId: false,
							useHistoryState: false,
							schemaName: "MultiDeleteResultSchema",
							isSchemaConfigInitialized: true
						}
					});
				},

				/**
				 * @inheritdoc BPMSoft.BaseViewModel#init
				 * @overridden
				 */
				init: function() {
					var multiDeleteMessages = ConfigurationConstants.MultiDelete;
					this.callParent(arguments);
					this.addMessageConfig({
						sender: multiDeleteMessages.MultiDeleteWebsocketSender,
						messageName: multiDeleteMessages.MultiDeleteSandboxMessageName
					});
					this.sandbox.subscribe("ListenMultiDeleteMessages", this.onInitMessagesListener, this);
				},

				/**
				 * @inheritdoc BPMSoft.ClientMessageBridge#beforePublishMessage
				 * @overridden
				 */
				beforePublishMessage: function(sandboxMessageName, webSocketBody) {
					var messageName = ConfigurationConstants.MultiDelete.MultiDeleteSandboxMessageName;
					var isMessagesListenerLoaded = this.get("IsMessagesListenerLoaded");
					if (sandboxMessageName === messageName && !isMessagesListenerLoaded) {
						this.set("LastSandboxConfig", webSocketBody);
						this.loadMultiDeleteResultModule();
					}
				}

			}
		};
	});
