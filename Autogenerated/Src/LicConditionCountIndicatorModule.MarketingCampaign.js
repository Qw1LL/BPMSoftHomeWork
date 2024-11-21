define("LicConditionCountIndicatorModule", ["ServiceHelper", "LicConditionCountIndicatorModuleResources",
		"IndicatorModule"],
	function(ServiceHelper) {

		/**
		 * Class represent view model for indicator dashboard.
		 */
		Ext.define("BPMSoft.configuration.LicConditionCountIndicatorViewModel", {
			extend: "BPMSoft.IndicatorViewModel",
			alternateClassName: "BPMSoft.LicConditionCountIndicatorViewModel",

			/**
			 * Calls the service to find actual license name.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 * */
			_getActualLicPackageName: function(callback, scope) {
				var config = {
					serviceName: "CustomLicPackageService",
					methodName: "GetFullPackageNameByNamePatterns",
					data: {
						namePatterns: [
							"BpmCrm Marketing BPMStudio.*1000.*",
							"bpmcrm marketing active contacts.*",
							"marketing bpmstudio.*active contacts.*",
							"marketing.*active contacts.*",
							"Marketing.*active contacts.*", 
							"bpmonline.*marketing.*active contacts.*",
							"Bpmonline.*marketing.*active contacts.*",
							"Bpmonline.*Marketing.*active contacts.*",
							"BPMSoft.*marketing.*active contacts.*",
							"BPMSoft.*Marketing.*active contacts.*"
						]
					}
				};
				this.callService(config, function(response) {
					if (response && response.GetFullPackageNameByNamePatternsResult) {
						callback.call(scope, response.GetFullPackageNameByNamePatternsResult);
					}
				}, this);
			},
			
			/**
			 * Call service.
			 * @protected
			 * @virtual
			 * @param {Object} config Configuration.
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 * */
			callService: function(config, callback, scope) {
				ServiceHelper.callService(config.serviceName, config.methodName, callback, config.data, scope);
			},

			/**
			 * Initialize value of indicator.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 */
			getIndicatorValues: function(callback, scope, packageName) {
				var serviceMethod = "GetMaxConditionCount";
				var config = {
					serviceName: "CustomLicPackageService",
					methodName: serviceMethod,
					data: {
						packageNames: [packageName]
					}
				};
				this.callService(config,
					function(response) {
						if (response && response.GetMaxConditionCountResult) {
							var responseObject = response[serviceMethod + "Result"];
							var index = 0;
							var maxIndex = 0;
							var maxContact = 0;
							BPMSoft.each(responseObject, function(item) {
								if (item.ConditionCount > maxContact) {
									maxContact = item.ConditionCount;
									maxIndex = index;
								}
								index++;
							}, this);
							var countValue = responseObject[maxIndex].ConditionCount;
							this.set("value", countValue);
						}
						callback.call(scope);
					}, this);
			},

			/**
			 * Prepare indicator parameters.
			 * @protected
			 * @overriden
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 */
			prepareWidget: function(callback, scope) {
				this._getActualLicPackageName(function(packageName) {
					this.getIndicatorValues(callback, scope, packageName);
				}, this);
			}
		});

		Ext.define("BPMSoft.configuration.LicConditionCountIndicatorModule", {
			extend: "BPMSoft.IndicatorModule",
			alternateClassName: "BPMSoft.LicConditionCountIndicatorModule",

			/**
			 * Class name for view model of dashboard indicator.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.LicConditionCountIndicatorViewModel"
		});
		return BPMSoft.LicConditionCountIndicatorModule;
	});
