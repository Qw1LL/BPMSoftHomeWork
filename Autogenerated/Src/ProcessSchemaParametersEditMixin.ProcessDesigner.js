define("ProcessSchemaParametersEditMixin", [],
	function() {
		/**
		 * @class BPMSoft.configuration.mixins.ProcessSchemaParametersEditMixin
		 * Process schema parameters edit mixin.
		 */
		Ext.define("BPMSoft.configuration.mixins.ProcessSchemaParametersEditMixin", {
			alternateClassName: "BPMSoft.ProcessSchemaParametersEditMixin",

			// region Methods: Private

			/**
			 * @private
			 */
			_getColumnInitMethod: function(columnConfig) {
				const bindConfig = columnConfig.parameterBindConfig;
				return columnConfig.initMethod || bindConfig && bindConfig.onInit;
			},

			/**
			 * @private
			 */
			_getColumnSaveMethod: function(columnConfig) {
				const bindConfig = columnConfig.parameterBindConfig;
				return columnConfig.doAutoSave ? "saveParameter" : bindConfig && bindConfig.onSave;
			},

			/**
			 * @private
			 */
			_initParameterFromColumnConfig: function(columnConfig, parameter) {
				parameter.skipValidation = columnConfig.skipValidation || false;
				parameter.forceRemove = columnConfig.forceRemove || false;
				parameter.parameterBindConfig = columnConfig.parameterBindConfig;
			},

			// endregion

			// region Methods: Protected

			/**
			 * Returns the value of parameter.
			 * @protected
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
			 */
			getParameterValue: function(parameter) {
				const column = this.columns[parameter.name];
				return column.dataValueType === BPMSoft.DataValueType.MAPPING
					? parameter.getMappingValue()
					: parameter.getValue();
			},

			/**
			 * Initializes the attributes values from the element's parameters values.
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 * @protected
			 */
			initParameters: function(element) {
				BPMSoft.each(this.columns, function(columnConfig, columnName) {
					const parameter = element.findParameterByName(columnName);
					const initMethod = this._getColumnInitMethod(columnConfig);
					if (!Ext.isEmpty(initMethod)) {
						this[initMethod](parameter, columnConfig);
					}
					if (parameter) {
						this._initParameterFromColumnConfig(columnConfig, parameter);
					}
				}, this);
			},

			/**
			 * Updates parameter values from the attribute values.
			 * @param {BPMSoft.ProcessBaseElementSchema} element Process element.
			 * @protected
			 */
			saveParameters: function(element) {
				BPMSoft.each(this.columns, function(columnConfig, columnName) {
					const saveMethod = this._getColumnSaveMethod(columnConfig);
					if (!Ext.isEmpty(saveMethod)) {
						const parameter = element.findParameterByName(columnName);
						this[saveMethod](parameter, columnConfig);
					}
				}, this);
			},

			/**
			 * Sets the value of the property.
			 * @protected
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
			 */
			initProperty: function(parameter) {
				const parameterName = parameter.name;
				this.set(parameterName, this.getParameterValue(parameter));
			},

			/**
			 * Sets the property value without triggering model events.
			 * @protected
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
			 */
			initPropertySilent: function(parameter) {
				const parameterName = parameter.name;
				const parameterValue = this.getParameterValue(parameter);
				const silent = !parameterValue || !parameterValue.value;
				this.set(parameterName, parameterValue, {
					silent: silent
				});
			},

			/**
			 * Returns default value for parameter from column config.
			 * @protected
			 * @param {Object} columnConfig Column config.
			 * @param {Object} columnConfig.parameterBindConfig.defaultValue Default parameter value.
			 * @returns {*|null} Default value or null.
			 */
			getDefaultValueFromColumnConfig: function(columnConfig) {
				const parameterBindConfig = columnConfig.parameterBindConfig;
				return Boolean(parameterBindConfig)
					? parameterBindConfig.defaultValue
					: null;
			},

			/**
			 * Safely sets the value of the property.
			 * @protected
			 * @param {Object} parameter Parameter to set value from.
			 * @param {Object} columnConfig Column config.
			 */
			safeInitProperty: function(parameter, columnConfig) {
				const parameterName = parameter.name;
				if (parameter.hasValue()) {
					const parameterValue = this.getParameterValue(parameter);
					this.set(parameterName, parameterValue);
					return;
				}
				const defaultValue = this.getDefaultValueFromColumnConfig(columnConfig);
				this.set(parameterName, defaultValue);
			},

			/**
			 * Saves parameter only if its value not equals to the default value from parameterBindConfig.
			 * @protected
			 * @param {Object} parameter Parameter to set value from.
			 * @param {Object} columnConfig Column config.
			 */
			safeSaveParameter: function(parameter, columnConfig) {
				const defaultValue = this.getDefaultValueFromColumnConfig(columnConfig);
				const value = this.getParameterSourceValue(parameter);
				if (!BPMSoft.isEqual(value, defaultValue)) {
					this.saveParameter(parameter);
				}
			},

			/**
			 * Returns parameter mapping source value.
			 * @protected
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
			 * @return {Object}
			 */
			getParameterSourceValue: function(parameter) {
				const parameterName = parameter.name;
				let sourceValue = {};
				const attributeValue = this.get(parameterName);
				if (attributeValue != null) {
					const column = this.columns[parameterName];
					if (column.dataValueType === BPMSoft.DataValueType.MAPPING) {
						sourceValue = attributeValue;
					} else {
						if (column.dataValueType === BPMSoft.DataValueType.LOOKUP) {
							sourceValue.value = attributeValue.value;
							sourceValue.displayValue = attributeValue.displayValue;
						} else {
							sourceValue.value = attributeValue;
							sourceValue.displayValue = Ext.isEmpty(attributeValue)
								? attributeValue
								: attributeValue.toString();
						}
						sourceValue.source = BPMSoft.ProcessSchemaParameterValueSource.ConstValue;
					}
				}
				return sourceValue;
			},

			/**
			 * Save parameter.
			 * @protected
			 * @param {BPMSoft.ProcessSchemaParameter} parameter Process parameter.
			 */
			saveParameter: function(parameter) {
				const sourceValue = this.getParameterSourceValue(parameter);
				parameter.setMappingValue(sourceValue);
			}

			// endregion

		});

	});