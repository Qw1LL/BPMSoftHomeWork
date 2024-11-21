define("PortalEmailMessageMixin", [], function() {
		/**
		 * @class BPMSoft.configuration.PortalEmailMessageMixin
		 * Utilities for Portal email history messages.
		 */
		Ext.define("BPMSoft.configuration.mixins.PortalEmailMessageMixin", {
			alternateClassName: "BPMSoft.PortalEmailMessageMixin",

			/**
			 * @protected
			 */
			getPortalEmailServiceConfig: function() {
				const caseMessageHistoryId = this.$Id;
				const config = {
					serviceName: "PortalEmailMessageService",
					methodName: "GetPortalEmailMessage",
					scope: this,
					data: {
						caseMessageHistoryId: caseMessageHistoryId
					}
				};
				return config;
			},

			/**
			 * Handle service response (sets up view model attributes).
			 * @protected
			 * @param {Object} response Response from service.
			 * @param {Function} callback 
			 */
			handlePortalEmailServiceResponse: function(response, callback) {
				if (response && response.GetPortalEmailMessageResult) {
					this.$EmailRecipients = response.GetPortalEmailMessageResult.recipient;
					this.$MessageType = response.GetPortalEmailMessageResult.messageTypeId;
					this.$EmailSender = response.GetPortalEmailMessageResult.sender;
					this.$IsMessageItemVisible = true;
				} else {
					this.sandbox.publish("HistoryMessageNotInitialized", {messageId: this.get("Id") });
				}
				Ext.callback(callback, this);
			},

			/**
			 * Sets up attributes, which must be provided by safe service.
			 * @public
			 * @param {Function} callback 
			 */
			setPortalEmailMessageAttributes: function(callback) {
				const config = this.getPortalEmailServiceConfig();
				this.callService(config, function(response) {
					this.handlePortalEmailServiceResponse(response, callback);
				}, this);
			}
		});
	}
);
 