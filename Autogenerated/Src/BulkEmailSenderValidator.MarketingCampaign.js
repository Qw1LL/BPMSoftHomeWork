/**
 * Class to validate bulk email sender.
 */
define("BulkEmailSenderValidator", ["BpmCrmCloudServiceApi", "BpCloudIntegrationEnums"],
	function() {
		/**
		 * @class BPMSoft.configuration.BulkEmailSenderValidator
		 */
		Ext.define("BPMSoft.configuration.BulkEmailSenderValidator", {
			alternateClassName: "BPMSoft.BulkEmailSenderValidator",

			/**
			 * Validates domains whether its in active status.
			 * @param {Object} validationConfig Validation config with domains to validate, email id and esp provider.
			 * @param {Function} callback Callback function
			 * @param {Object} scope Callback scope receives validation result.
			 */
			validateDomains: function(validationConfig, callback, scope) {				
				var config = {
					serviceName: "MailingService",
					methodName: "ValidateDomains",
					data: {
						validateSenderDomainRequest: validationConfig
					}
				};
				BPMSoft.ConfigurationServiceProvider.callService(config, function(response) {
					if(!response.ValidateDomains) {
						callback.call(scope, response);
						return;
					};
					var domainInfos = response.ValidateDomains.SenderDomainInfos;
					var result = {
						Domains: domainInfos
					};
					callback.call(scope, result);
				}, this);
			}
		});

		return Ext.create("BPMSoft.configuration.BulkEmailSenderValidator");
	});