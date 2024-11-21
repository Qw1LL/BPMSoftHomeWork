define("CommunicationPanel", ["BPMSoft", "RemindingsUtilities", "ESNConstants", "CommunicationPanelHelper"],
	function(BPMSoft, RemindingsUtilities, ESNConstants) {
		return {
			messages: {
				/**
				 * Update counters message.
				 */
				"UpdateCounters": {
					"mode": BPMSoft.MessageMode.BROADCAST,
					"direction": BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Determines if "social feed notifications" menu item is active.
				 * @type {Boolean}
				 */
				"ESNNotificationActive": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},

				/**
				 * "Social feed notifications" menu item image configuration.
				 * @type {Object}
				 */
				"ESNNotificationImageConfig": {
					"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": null
				},

				/**
				 * ####### ##### ###########.
				 * @type {String}
				 */
				"ESNNotificationCounter": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				},

				/**
				 * ###### ### popup ###########.
				 * @type {String}
				 */
				"ESNNotification": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ""
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.CommunicationPanel#updateUserCounters
				 * @overridden
				 */
				updateUserCounters: function(countersData) {
					this.callParent(arguments);
					var esnNotificationsCounterValue = "";
					var esnNotificationsValue = "";
					if (countersData.hasOwnProperty("esnNotificationsCount") &&
							(countersData.esnNotificationsCount > 0)) {
						esnNotificationsCounterValue = countersData.esnNotificationsCount;
					}
					if (countersData.hasOwnProperty("esnNotifications") &&
							(countersData.esnNotifications > 0)) {
						esnNotificationsValue = countersData.esnNotifications;
					}
					this.set("ESNNotificationCounter", esnNotificationsCounterValue);
					this.set("ESNNotification", esnNotificationsValue);
				},

				/**
				 * ######### ############### ###### ### ########## ######## #########.
				 * @overridden
				 * @param {Object} counters ######, ####### # #### ######## ######## #########
				 * ########## ###########.
				 * @return {Object} ############### ###### ### ########## ######## #########.
				 */
				getCountersConfig: function(counters) {
					var result = this.callParent(arguments);
					result.esnNotificationsCount = counters.ESNNotificationsCount;
					return result;
				},

				/**
				 * Handles counters change event.
				 * @private
				 * @param {Object} scope Callback-function execution context.
				 * @param {Function} response Server response object.
				 */
				onSocialMessageReceived: function(scope, response) {
					if (!response) {
						return;
					}
					if (response.Header.Sender === ESNConstants.WebSocketMessageHeader.ESNNotification) {
						this.sandbox.publish("UpdateCounters");
					}
				},

				/**
				 * ############## ######### ######## ######.
				 * @protected
				 * @overridden
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.BPMSoft.ServerChannel.on(this.BPMSoft.EventName.ON_MESSAGE,
							this.onSocialMessageReceived, this);
						if (callback) {
							callback.call(scope || this);
						}
					}, this]);
				},

				/**
				 * ####### ### ######## ## #######.
				 * @virtual
				 */
				destroy: function() {
					this.BPMSoft.ServerChannel.un(this.BPMSoft.EventName.ON_MESSAGE, this.onSocialMessageReceived,
						this);
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc BPMSoft.CommunicationPanel#getPanelItemConfig
				 * @overridden
				 */
				getPanelItemConfig: function(moduleName) {
					var config = this.callParent(arguments);
					if (moduleName !== "ESNFeedModule") {
						return config;
					}
					return this.Ext.apply(config, {
						keepAlive: true
					});
				}

			},
			diff: []
		};
	});
