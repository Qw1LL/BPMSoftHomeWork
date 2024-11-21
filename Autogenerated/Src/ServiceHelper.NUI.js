define("ServiceHelper", ["ext-base", "BPMSoft"], function(Ext, BPMSoft) {

	/**
	 * Calls specified web-service method.
	 * @param {String|Object} config Service name or configuration object containing call parameters.
	 * @param {String} methodName Method name.
	 * @param {Function} callback (optional) Callback function.
	 * @param {Object} data (optional) Object containing request data.
	 * @param {Object} scope (optional) Callback function execution context.
	 * @param {String} requestId (optional) Request unique identifier.
	 * @return {Object} Request instance.
	 */
	function internalCallService(config, methodName, callback, data, scope, requestId) {
		var serviceName;
		if (config && Ext.isObject(config)) {
			serviceName = config.serviceName;
			methodName = config.methodName;
			callback = config.callback;
			data = config.data;
			scope = config.scope;
			requestId = config.requestId;
		} else {
			serviceName = config;
		}
		var dataSend = data || {};
		var requestUrl = buildConfigurationUrl(serviceName, methodName);
		var requestConfig = {
			url: requestUrl,
			headers: {
				"Accept": "application/json",
				"Content-Type": "application/json"
			},
			method: "POST",
			jsonData: Ext.encode(dataSend),
			instanceId: requestId,
			callback: function(request, success, response) {
				if (callback) {
					callServiceCallback(success, response, callback, this);
				}
			},
			scope: scope || this
		};
		if (config && config.timeout) {
			requestConfig.timeout = config.timeout;
		}
		return BPMSoft.AjaxProvider.request(requestConfig);
	}

	/**
	 * Calls specified web-service method.
	 * @param {String|Object} config Service name or configuration object containing call parameters.
	 * @param {String} methodName Method name.
	 * @param {Object} data (optional) Object containing request data.
	 * @param {Object} scope (optional) Callback function execution context.
	 * @param {String} requestId (optional) Request unique identifier.
	 * @return {Promise} Promise with request instance.
	 */
	function internalCallServiceAsync(config, methodName, data, scope, requestId) {
		return new Promise((resolve) => {
			this.callService(config, methodName, function(response) {
				resolve(response);
			}, data, scope, requestId);
		});
	}


	/**
	 * Calls specified core web-service method.
	 * @param {Object} config Configuration object containing call parameters.
	 * @param {String} config.serviceName Service name.
	 * @param {String} config.methodName Method name.
	 * @param {Object} config.data (optional) Object containing request data.
	 * @param {Function} callback (optional) Callback function.
	 * @param {Object} scope (optional) Callback function execution context.
	 */
	function callCoreService(config, callback, scope) {
		BPMSoft.AjaxProvider.request({
			url: BPMSoft.combinePath(BPMSoft.workspaceBaseUrl, "ServiceModel", config.serviceName + ".svc",
				config.methodName),
			method: "POST",
			scope: scope || this,
			jsonData: config.data || {},
			callback: function(options, success, response) {
				if (callback) {
					callServiceCallback(success, response, callback, this);
				}
			}
		});
	}

	/**
	 * Calls callback function.
	 * @param {Boolean} success Service call executed successfully.
	 * @param {Object} response Server response.
	 * @param {Function} callback Callback function.
	 * @param {Object} scope Callback function execution context.
	 */
	function callServiceCallback(success, response, callback, scope) {
		var responseObject = response;
		if (success) {
			responseObject = BPMSoft.decode(response.responseText);
		}
		callback.call(scope, responseObject, success);
	}

	/**
	 * Builder url address.
	 * @param {String} Service name.
	 * @param {String} Method name.
	 * @return {String} Url address with service and method name.
	 */
	function buildConfigurationUrl(serviceName, methodName) {
		const baseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
		const transferName = 'rest';
		return BPMSoft.combinePath(baseUrl, transferName, serviceName, methodName);
	}

	return {
		callServiceAsync: internalCallServiceAsync,
		callService: internalCallService,
		callCoreService: callCoreService,
		buildConfigurationUrl: buildConfigurationUrl
	};
});
