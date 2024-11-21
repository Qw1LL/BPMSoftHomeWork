define("NotificationCountersServiceRequest", ["ext-base", "BPMSoft", "ConfigurationServiceRequest"],
	function(Ext, BPMSoft) {
		/**
		 * @class BPMSoft.configuration.NotificationCountersServiceRequest
		 * Requests notification counters.
		 */
		Ext.define("BPMSoft.configuration.NotificationCountersServiceRequest", {
			extend: "BPMSoft.ConfigurationServiceRequest",
			alternateClassName: "BPMSoft.NotificationCountersServiceRequest",

			/**
			 * @inheritDoc BPMSoft.configuration.ConfigurationServiceRequest#serviceName
			 * @overridden
			 */
			serviceName: "NotificationInfoService",

			/**
			 * Gets counter value from dictionary object.
			 * @private
			 * @param {String} counterName Counter name.
			 * @param {Object} counters Counters dictionary.
			 * @return {Number} Counter value.
			 */
			_getCounterValue: function(counterName, counters) {
				var counter = BPMSoft.findWhere(counters, { Key: counterName }) || {};
				var counterValue = counter.Value || 0;
				return counterValue;
			},

			/**
			 * Gets notification counters from service.
			 * @param {Function} callback Callback function.
			 * @param {BPMSoft.BaseViewModel} scope Callback scope.
			 */
			getCounters: function(callback, scope) {
				this.contractName = "GetCounters";
				this.execute(function(response) {
					var countersInfo = {};
					if (response.success) {
						var counters = response.NotificationCounters;
						countersInfo = {
							remindingsCount: this._getCounterValue("Reminding", counters),
							visaCount: this._getCounterValue("Visa", counters),
							esnNotificationsCount: this._getCounterValue("ESNNotification", counters),
							notificationsCount: this._getCounterValue("Notification", counters),
							anniversariesCount: this._getCounterValue("Anniversary", counters),
							resetCounters: true
						};
					} else {
						this.log(response.errorInfo.message, BPMSoft.LogMessageType.ERROR);
					}
					Ext.callback(callback, scope, [countersInfo]);
				}, this);
			}
		});

		return BPMSoft.NotificationCountersServiceRequest;

	});
