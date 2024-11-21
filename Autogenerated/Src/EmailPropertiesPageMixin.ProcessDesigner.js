define("EmailPropertiesPageMixin", ["ext-base", "BPMSoft", "ProcessUserTaskConstants",
	"ProcessSchemaUserTaskUtilities", "EmailPropertiesPageMixinResources"],
		function(Ext, BPMSoft, ProcessUserTaskConstants, ProcessSchemaUserTaskUtilities, resources) {
	Ext.define("BPMSoft.configuration.mixins.EmailPropertiesPageMixin", {
		alternateClassName: "BPMSoft.EmailPropertiesPageMixin",

		/**
		 * Sets display importance value.
		 * @protected
		 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
		 */
		initImportance: function(parameter) {
			var importanceConfig = this.getImportanceConfig();
			var defaultValue = ProcessUserTaskConstants.EMAIL_IMPORTANCE.Normal;
			this.initLookupAttribute(parameter, importanceConfig, defaultValue);
		},

		/**
		 * Init lookup attribute.
		 * @private
		 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
		 * @param {Object} config Lookup config.
		 * @param {String} defaultValue Default value.
		 */
		initLookupAttribute: function(parameter, config, defaultValue) {
			var valueSource = parameter.getValueSource();
			if (valueSource === BPMSoft.ProcessSchemaParameterValueSource.None) {
				return;
			}
			var value = parameter.getValue();
			if (Ext.isEmpty(value)) {
				value = defaultValue;
			}
			var item = BPMSoft.findWhere(config, {value: value});
			var parameterName = parameter.name;
			this.set(parameterName, item);
		},

		/**
		 * Returns importance config.
		 * @protected
		 * @return {Object}
		 */
		getImportanceConfig: function() {
			var emailImportance = ProcessUserTaskConstants.EMAIL_IMPORTANCE;
			var localizableStrings = resources.localizableStrings;
			var config = {};
			config[emailImportance.Low] = {
				value: emailImportance.Low,
				displayValue: localizableStrings.LowMailImportanceCaption
			};
			config[emailImportance.Normal] = {
				value: emailImportance.Normal,
				displayValue: localizableStrings.NormalMailImportanceCaption
			};
			config[emailImportance.Hight] = {
				value: emailImportance.Hight,
				displayValue: localizableStrings.HighMailImportanceCaption
			};
			return config;
		},

		/**
		 * The event handler for preparing of the data drop-down period.
		 * @protected
		 * @param {Object} filter Filters for data preparation.
		 * @param {BPMSoft.Collection} list The data for the drop-down list.
		 */
		onPrepareImportanceList: function(filter, list) {
			if (BPMSoft.isEmptyObject(list)) {
				return;
			}
			list.clear();
			list.loadAll(this.getImportanceConfig());
		}
	});
});
