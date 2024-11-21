define("LicPackageDashboardIndicatorModule", ["ServiceHelper", "LicPackageDashboardIndicatorModuleResources",
		"IndicatorModule", "css!LicPackageDashboardIndicatorModule"],
	function(ServiceHelper) {

		/**
		 * @class BPMSoft.configuration.LicPackageDashboardIndicatorViewConfig
		 * Class represent the view configuration for indicator.
		 */
		Ext.define("BPMSoft.configuration.LicPackageDashboardIndicatorViewConfig", {
			extend: "BPMSoft.IndicatorViewConfig",
			alternateClassName: "BPMSoft.LicPackageDashboardIndicatorViewConfig",

			/**
			 * Generate the configuration view for indicator.
			 * @protected
			 * @overridden
			 * @return {Object[]} Returns the configuration view of the indicator module.
			 */
			generate: function() {
				var result = this.callParent(arguments);
				var id = BPMSoft.Component.generateId();
				var internalContainer = result.items[0].items;
				internalContainer[2] = {
					"name": "indicator-service-value" + id,
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {
						"bindTo": "dateCaption",
						"bindConfig": {converter: "dateValueConvertor"}
					},
					"classes": {"labelClass": ["indicator-service-value", "margin-date"]}
				};
				return result;
			}
		});

		/**
		 * Class represent view model for indicator dashboard.
		 */
		Ext.define("BPMSoft.configuration.LicPackageDashboardIndicatorViewModel", {
			extend: "BPMSoft.IndicatorViewModel",
			alternateClassName: "BPMSoft.LicPackageDashboardIndicatorViewModel",
			dateCaption: null,

			/**
			 * Calls the service to find actual license name.
			 * @private
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Callback execution scope.
			 * */
			_getActualLicPackageName: function(callback, scope) {
				var serviceMethod = "GetFullPackageNameByNamePatterns";
				var config = {
					serviceName: "CustomLicPackageService",
					methodName: serviceMethod,
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
			 * */
			getIndicatorValues: function(callback, scope, packageName) {
				var serviceMethod = "GetLastActualizedConditionResult";
				var config = {
					serviceName: "CustomLicPackageService",
					methodName: serviceMethod,
					data: {
						packageNames: [packageName]
					}
				};
				this.callService(config,
					function(response) {
						if (response && response.GetLastActualizedConditionResultResult) {
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
							var dateValue = responseObject[maxIndex].ConditionDate;
							this.set("dateCaption", dateValue);
						}
						callback.call(scope);
					}, this);
			},

			/**
			 * Convert data value to date/time format.
			 * @protected
			 * @virtual
			 * @param {Number} value Value which should be converted.
			 * @return {String} Returens formated string.
			 */
			dateValueConvertor: function(value) {
				var result = "";
				var formatConfig = this.get("dateLabelFormat") || this.defaultFormat;
				var dateValue = new Date(value);
				if (Ext.isDate(dateValue) && !isNaN(dateValue.getDate())) {
					var datePart = Ext.Date.dateFormat(dateValue, BPMSoft.Resources.CultureSettings.dateFormat);
					var timePart = Ext.Date.dateFormat(dateValue, BPMSoft.Resources.CultureSettings.timeFormat);
					var textDecorator = formatConfig.textDecorator;
					if (textDecorator) {
						result = Ext.String.format(textDecorator, datePart, timePart);
					}
				}
				return result;
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

		Ext.define("BPMSoft.configuration.LicPackageDashboardIndicatorModule", {
			extend: "BPMSoft.IndicatorModule",
			alternateClassName: "BPMSoft.LicPackageDashboardIndicatorModule",

			/**
			 * Class name for view model of dashboard indicator.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.LicPackageDashboardIndicatorViewModel",

			/**
			 * Class name for view configuration of dashboard indicator.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.LicPackageDashboardIndicatorViewConfig"

		});
		return BPMSoft.LicPackageDashboardIndicatorModule;
	});
