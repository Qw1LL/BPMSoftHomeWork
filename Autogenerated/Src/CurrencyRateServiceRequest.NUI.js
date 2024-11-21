define("CurrencyRateServiceRequest", ["ext-base", "BPMSoft", "ConfigurationServiceRequest"],
	function(Ext, BPMSoft) {
		/**
		 * @class BPMSoft.configuration.CurrencyRateServiceRequest
		 * Class used to interact with currency rate web service.
		 */
		Ext.define("BPMSoft.configuration.CurrencyRateServiceRequest", {
			extend: "BPMSoft.ConfigurationServiceRequest",
			alternateClassName: "BPMSoft.CurrencyRateServiceRequest",

			/**
			 * Currency Id.
			 * @type {String}
			 */
			currencyId: null,

			/**
			 * @inheritdoc BPMSoft.configuration.ConfigurationServiceRequest#serviceName
			 * @overridden
			 */
			serviceName: "CurrencyRateService",

			/**
			 * @inheritdoc BPMSoft.core.BaseRequest#getSerializableObject
			 * @overridden
			 */
			getSerializableObject: function(serializableObject) {
				this.callParent(arguments);
				serializableObject.currencyId = this.currencyId;
			},

			/**
			 * Gets actual currency rates from service.
			 * @param {Function} callback Callback
			 * @param {BPMSoft.BaseViewModel} scope Callback scope.
			 */
			getActualCurrencyRates: function(callback, scope) {
				this.contractName = "GetActualCurrencyRates";
				this.execute(function(response) {
					response = response || {};
					var result = this.currencyId ? response[0] : response;
					callback.call(scope, result);
				}, this);
			}
		});

		return BPMSoft.CurrencyRateServiceRequest;

	});
