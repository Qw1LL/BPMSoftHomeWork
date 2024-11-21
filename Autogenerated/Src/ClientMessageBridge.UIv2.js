define("ClientMessageBridge", ["ConfigurationConstants"], function(ConfigurationConstants) {
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
			},

			/**
			 * @message NotificationInfo
			 * Notification that has been received information about notifications.
			 */
			"NotificationInfo": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message UpdateReminding
			 * Notification that has been changed count of the notifications.
			 */
			"UpdateReminding": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetRemindingCounters
			 * Notification that has been received information about notification counters.
			 */
			"GetRemindingCounters": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetRemindingCounters
			 * Notification that has been received information about reloading application.
			 */
			"ReloadApplication": {
				"mode": BPMSoft.MessageMode.BROADCAST,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		attributes: {
			/**
			 * Flag that shows loaded or not the multi delete message listener.
			 */
			"IsMessagesListenerLoaded": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Last received config for the sandbox message.
			 */
			"LastSandboxConfig": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": {}
			},

			/**
			 * Notifications sender names.
			 */
			"NotificationsSenderNames": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": ["NotificationInfo", "UpdateReminding", "GetRemindingCounters", "ReloadApplication"]
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
			 * @inheritdoc BPMSoft.BaseViewModel#init
			 * @override
			 */
			init: function() {
				this.callParent(arguments);
				var multiDeleteMessages = ConfigurationConstants.MultiDelete;
				var notificationsSenderNames = this.get("NotificationsSenderNames");
				this.addMessageConfig({
					sender: multiDeleteMessages.MultiDeleteWebsocketSender,
					messageName: multiDeleteMessages.MultiDeleteSandboxMessageName,
					isSaveHistory: false
				});
				this.BPMSoft.each(notificationsSenderNames, function(name) {
					this.addMessageConfig({
						sender: name,
						messageName: name,
						isSaveHistory: true
					});
				}.bind(this));
				this.sandbox.subscribe("ListenMultiDeleteMessages", this.onInitMessagesListener, this);
			},

			/**
			 * @inheritdoc BPMSoft.ClientMessageBridge#beforePublishMessage
			 * @override
			 */
			beforePublishMessage: function(sandboxMessageName, webSocketBody) {
				this.callParent(arguments);
				var multiDeleteSandboxMessageName = ConfigurationConstants.MultiDelete.MultiDeleteSandboxMessageName;
				var isMessagesListenerLoaded = this.get("IsMessagesListenerLoaded");
				if (sandboxMessageName === multiDeleteSandboxMessageName && !isMessagesListenerLoaded) {
					this.set("LastSandboxConfig", webSocketBody);
				}
			}
		}
	};
});
