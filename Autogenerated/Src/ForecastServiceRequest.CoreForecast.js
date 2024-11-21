define("ForecastServiceRequest", ["ext-base", "BPMSoft", "ConfigurationServiceRequest"],
	function(Ext, BPMSoft) {
		Ext.define("BPMSoft.configuration.ForecastServiceRequest", {
			extend: "BPMSoft.ConfigurationServiceRequest",
			alternateClassName: "BPMSoft.ForecastServiceRequest",

			/**
			 * @inheritdoc BPMSoft.configuration.ConfigurationServiceRequest#serviceName
			 * @overridden
			 */
			serviceName: "forecast.api",

			/**
			 * Forecast identifier.
			 */
			forecastId: '',

			/**
			 * @inheritdoc BPMSoft.core.BaseRequest#getSerializableObject
			 * @overridden
			 */
			getSerializableObject: function(serializableObject) {
				this.callParent(arguments);
				serializableObject.forecastId = this.forecastId;
			},

			/**
			 * Returns calculation status.
			 * @param {Function} callback Call back function.
			 * @param {Object} scope Scope.
			 */
			getCalculatedStatus(callback, scope) {
				this.contractName = "forecast/calc/status";
				this.execute(function(response) {
					const result = response ? response.GetCalcStatusResult : null
					callback.call(scope, result);
				}, this);
			}
		});

		return BPMSoft.ForecastServiceRequest;
	});
