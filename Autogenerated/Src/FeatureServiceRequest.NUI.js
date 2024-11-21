define("FeatureServiceRequest", ["ext-base", "BPMSoft", "ConfigurationServiceRequest"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.configuration.FeatureServiceRequest
	 * Class used to interact with features web service.
	 */
	Ext.define("BPMSoft.configuration.FeatureServiceRequest", {
		extend: "BPMSoft.ConfigurationServiceRequest",
		alternateClassName: "BPMSoft.FeatureServiceRequest",

		/**
		 * Feature code.
		 * @type {String}
		 */
		code: null,

		/**
		 * Feature state.
		 * @type {BPMSoft.core.enums.FeatureState}
		 */
		state: null,

		/**
		 * @inheritdoc BPMSoft.configuration.ConfigurationServiceRequest#serviceName
		 * @overridden
		 */
		serviceName: "FeatureService",

		/**
		 * @inheritdoc BPMSoft.core.BaseRequest#getSerializableObject
		 * @overridden
		 */
		getSerializableObject: function(serializableObject) {
			this.callParent(arguments);
			serializableObject.code = this.code;
			if (this.state !== null) {
				serializableObject.state = this.state;
			}
		},

		/**
		 * @inheritdoc BPMSoft.core.BaseRequest#validate
		 * @overridden
		 */
		validate: function() {
			this.callParent(arguments);
			if (Ext.isEmpty(this.code)) {
				throw new BPMSoft.ArgumentNullOrEmptyException({argumentsName: "code"});
			}
		},

		/**
		 * Updates state of the feature.
		 * @param {Object} config State parameters.
		 * @param {BPMSoft.core.enums.FeatureState} config.state New feature state.
		 * @param {Boolean} [config.forAllUsers] If defined as true state will be updated for all users,
		 * otherwise only for current user.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 * @throws {BPMSoft.ArgumentNullOrEmptyException} If state is not defined in config.
		 */
		updateFeatureState: function(config, callback, scope) {
			this.contractName = (config.forAllUsers === true) ? "SetFeatureStateForAllUsers" : "SetFeatureState";
			if (Ext.isEmpty(config.state)) {
				throw new BPMSoft.ArgumentNullOrEmptyException({argumentsName: "config.state"});
			}
			this.state = config.state;
			this.execute(callback, scope);
		},

		/**
		 * Returns current feature state.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Callback scope.
		 */
		getFeatureState: function(callback, scope) {
			this.contractName = "GetFeatureState";
			this.execute(function(response) {
				var result = response ? response.FeatureState : null;
				callback.call(scope, result);
			}, this);
		}

	});

	return BPMSoft.FeatureServiceRequest;

});
