define("ConfigurationServiceRequest", ["ConfigurationServiceProvider"], function() {
	Ext.define("BPMSoft.configuration.ConfigurationServiceRequest", {
		extend: "BPMSoft.BaseRequest",
		alternateClassName: "BPMSoft.ConfigurationServiceRequest",

		/**
		 * #### # #######.
		 * @protected
		 * @type {String}
		 */
		serviceUrl: "../rest",

		/**
		 * @protected
		 * @type {String}
		 */
		sspServiceUrl: "../ssp/rest",

		/**
		 * @protected
		 * @type {Boolean}
		 */
		useSspServiceUrl: false,

		/**
		 * ######## #######.
		 * @protected
		 * @type {String}
		 */
		serviceName: "",

		/**
		 * ######## ######## ####### ######, ####### ###### ######### ########## #######.
		 * @protected
		 * @type {String}
		 */
		resultPropertyName: "",

		/**
		 * ####### ######## ######## ####### ######, ####### ###### ######### ########## #######.
		 * @private
		 * @type {String}
		 */
		resultPropertyNameSuffix: "Result",

		/**
		 * @inheritdoc BPMSoft.BaseRequest#constructor
		 * @overridden
		 */
		constructor: function() {
			this.callParent(arguments);
			this.serviceProvider = BPMSoft.ConfigurationServiceProvider;
		},

		/**
		 * ######## URL ### ####### # ###-#######.
		 * @protected
		 * @return {String} URL ### ####### # ###-#######.
		 */
		getRequestUrl: function() {
			const baseUrl = (this.useSspServiceUrl && BPMSoft.CurrentUser && BPMSoft.isCurrentUserSsp())
				? this.sspServiceUrl
				: this.serviceUrl;
			return BPMSoft.combinePath(baseUrl, this.serviceName, this.contractName);
		},

		/**
		 * ########## ######## ######## ####### ######, ####### ###### ######### ########## #######.
		 * @param {Object} config ############ #######.
		 * @return {String} ######## ######## ####### ######, ####### ###### ######### ########## #######.
		 */
		getResultPropertyName: function(config) {
			var resultPropertyName = this.resultPropertyName;
			if (resultPropertyName) {
				return resultPropertyName;
			}
			var contractName = config.contractName || this.contractName;
			return (contractName + this.resultPropertyNameSuffix);
		},

		/**
		 * @inheritdoc BPMSoft.BaseRequest#getRequestConfig
		 * @overridden
		 */
		getRequestConfig: function() {
			var config = this.callParent(arguments);
			return Ext.apply({}, config, {
				url: this.getRequestUrl(),
				resultPropertyName: this.getResultPropertyName(config)
			});
		},

		/**
		 * @inheritdoc BPMSoft.BaseRequest#validate
		 * @overridden
		 */
		validate: function() {
			this.callParent(arguments);
			if (!this.serviceName) {
				throw new BPMSoft.NullOrEmptyException({
					message: "serviceName"
				});
			}
		}
	});
});
