define("SystemNotificationsSchema", ["ConfigurationConstants"], function(Constants) {
	return {
		methods: {
			/**
			 * @inheritdoc BPMSoft.BaseNotificationsSchema#getNotificationImage
			 * @overridden
			 */
			getNotificationImage: function() {
				if (this._isForecastNotification()) {
					return this.getImageUrlBySchemaName("Forecast");
				} else {
					return this.callParent(arguments);
				}
			},

			/**
			 * @private
			 */
			_isForecastNotification: function() {
				return this.$SchemaName === Constants.Forecast.SchemaName ||
						this.$SchemaName === "ForecastSheet";
			},

			/**
			 * @private
			 */
			_openForecastModule: function() {
				this.sandbox.publish("PushHistoryState", {hash: "ForecastsModule"});
			},

			/**
			 * @inheritdoc BPMSoft.BaseNotificationsSchema#onNotificationSubjectClick
			 * @overridden
			 */
			onNotificationSubjectClick: function() {
				if (this._isForecastNotification()) {
					this._openForecastModule();
				} else {
					this.callParent(arguments);
				}
			}
		}
	};
});
