define("QueueClientNotificationUtilities", ["BPMSoft", "ServiceHelper"], function(BPMSoft, ServiceHelper) {
	Ext.define("BPMSoft.configuration.QueueClientNotificationUtilities", {
		alternateClassName: "BPMSoft.QueueClientNotificationUtilities",
		extend: "BPMSoft.core.BaseObject",
		singleton: true,

		//region Properties: Private

		/**
		 * Indicates queues notification has been initialized.
		 * @type {Boolean}
		 * @private
		 */
		isNotificationInitialized: false,

		//endregion

		//region Methods: Private

		/**
		 * Handles queues notification messages.
		 * @private
		 * @param {Object} scope Method execution context.
		 * @param {Object} response Response from the server.
		 */
		onQueuesNotification: function(scope, response) {
			if (!response || !response.Header || response.Header.Sender !== "QueuesNotification") {
				return;
			}
			var message = "QueuesNotification: " + response.Body;
			var logMessage = response.Header.BodyTypeName;
			var logMessageType;
			switch (logMessage) {
				case "Warn":
					logMessageType = BPMSoft.LogMessageType.WARNING;
					break;
				case "Error":
					logMessageType = BPMSoft.LogMessageType.ERROR;
					break;
				case "Info":
					logMessageType = BPMSoft.LogMessageType.INFORMATION;
					break;
				default:
					break;
			}
			this.log(message, logMessageType);
		},

		//endregion

		//region Methods: Public

		/**
		 * Subscribes on queues notifications.
		 */
		subscribeForQueuesNotifications: function() {
			if (this.isNotificationInitialized) {
				return;
			}
			ServiceHelper.callService("QueuesService", "SubscribeForQueuesNotifications");
			BPMSoft.ServerChannel.un(BPMSoft.EventName.ON_MESSAGE, this.onQueuesNotification, this);
			BPMSoft.ServerChannel.on(BPMSoft.EventName.ON_MESSAGE, this.onQueuesNotification, this);
			this.isNotificationInitialized = true;
		}

		//endregion

	});
	return BPMSoft.configuration.QueueClientNotificationUtilities;
});
