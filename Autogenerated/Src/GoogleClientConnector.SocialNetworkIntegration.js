define("GoogleClientConnector", ["BaseClientConnector", "GoogleServiceRequest"], function() {
	/**
	 * @class BPMSoft.configuration.social.GoogleClientConnector
	 * Class implements working with social network Google on client.
	 */
	Ext.define("BPMSoft.configuration.social.GoogleClientConnector", {
		extend: "BPMSoft.configuration.social.BaseClientConnector",
		alternateClassName: "BPMSoft.GoogleClientConnector",

		//region Methods: Private

		/**
		 * Gets consumer information.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback function context.
		 * @private
		 */
		doRequest: function(callback, scope) {
			var request = this.getServiceRequest({
				className: "BPMSoft.GoogleServiceRequest",
				contractName: "GetConsumerInfo",
				serviceName: "GoogleService"
			});
			request.execute(function(response) {
				callback.call(scope, response);
			}, this);
		}

		//endregion

	});
});
