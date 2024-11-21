define("BaseAggregationWidgetDesigner", ["BPMSoft"],
function(BPMSoft) {
	return {
		messages: {
			/**
			 * ######## ## ######### StructureExplorer.
			 */
			"StructureExplorerInfo": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},
			/**
			 * ######## ## ######### ###### ####### # StructureExplorer.
			 */
			"ColumnSelected": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		attributes: {

			/**
			 * ####### #### #########.
			 */
			aggregationType: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: {
					value: BPMSoft.AggregationType.COUNT,
					displayValue: BPMSoft.Resources.AggregationType.COUNT
				}
			},

			/**
			 * ####### # ######## #########.
			 */
			aggregationColumn: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isLookup: true,
				entityStructureConfig: {
					useBackwards: false,
					summaryColumnsOnly: true,
					schemaColumnName: "entitySchemaName",
					aggregationTypeParameterName: "aggregationType"
				},
				dependencies: [
					{
						columns: ["aggregationType"],
						methodName: "onAggregationTypeChange"
					}
				]
			},
			
			/**
			 * Format value control visibility.
			 * @protected
			 */
			FormatValueSettingsVisible: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			
			/**
			 * Widget format data value configuration.
			 * @protected
			 */
			format: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: false,
				value: {
					"thousandSeparator": BPMSoft.Resources.CultureSettings.thousandSeparator,
					"type": BPMSoft.DataValueType.INTEGER,
					"dateFormat": BPMSoft.Resources.CultureSettings.dateFormat
				}
			}
		},
		methods: {

			/**
			 * ########## ###### ########### ####### ###### ####### # ###### ######### #######.
			 * @protected
			 * @virtual
			 * @return {Object} ########## ###### ########### ####### ###### ####### # ###### ######### #######.
			 */
			getWidgetModulePropertiesTranslator: function() {
				var aggregationProperties = {
					aggregationType: "aggregationType",
					aggregationColumn: "aggregationColumn",
					format: "format"
				};
				return Ext.apply(this.callParent(arguments), aggregationProperties);
			},

			/**
			 * ##### ####### ######### ############ #######.
			 * @protected
			 * @virtual
			 */
			clearColumn: function() {
				this.set("aggregationColumn", null);
			},

			/**
			 * ##### ######### ####### ######### ######## #####.
			 * @protected
			 * @virtual
			 */
			onEntitySchemaNameChange: function() {
				if (this.get("moduleLoaded")) {
					this.clearColumn();
				}
				this.callParent(arguments);
			},

			/**
			 * ##### ######### ####### ######### ####### #########.
			 * @protected
			 * @virtual
			 */
			onAggregationTypeChange: function() {
				if (this.get("moduleLoaded")) {
					this.clearColumn();
				}
			},

			/**
			 * ##### ########### ######### ############ #######.
			 * @private
			 * @param {Object} value ########.
			 * @return {Boolean} ####### ######### ############ #######.
			 */
			aggregationColumnVisibilityConverter: function(value) {
				var entitySchema = this.get("entitySchemaName");
				var allowedAggregationTypes = [
					BPMSoft.AggregationType.SUM,
					BPMSoft.AggregationType.MAX,
					BPMSoft.AggregationType.MIN,
					BPMSoft.AggregationType.AVG
				];
				return entitySchema && value && value.value &&
					BPMSoft.contains(allowedAggregationTypes, value.value);
			},

			/**
			 * ##### ######### ######## #########.
			 * @protected
			 * @virtual
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("aggregationColumn", function(value) {
					var invalidMessage = "";
					var isVisible = this.aggregationColumnVisibilityConverter(this.get("aggregationType"));
					if (isVisible && !value) {
						invalidMessage = BPMSoft.Resources.BaseViewModel.columnRequiredValidationMessage;
					}
					return {
						fullInvalidMessage: invalidMessage,
						invalidMessage: invalidMessage
					};
				});
			},

			/**
			 * ########## ###### ##### #########.
			 * @protected
			 * @virtual
			 * @return {Object} ########## ###### ##### #########.
			 */
			getAggregationTypeDefaultConfig: function() {
				var aggregationTypeDefaultConfig = {};
				BPMSoft.each(BPMSoft.AggregationType, function(typeValue, typeName) {
					if (typeValue === BPMSoft.AggregationType.NONE) {
						return;
					}
					aggregationTypeDefaultConfig[typeValue] = {
						value: typeValue,
						displayValue: BPMSoft.Resources.AggregationType[typeName]
					};
				}, this);
				return aggregationTypeDefaultConfig;
			},

			/**
			 * ######### ######### ##### ####### #########.
			 * @protected
			 * @virtual
			 * @param {String} filter ###### ##########.
			 * @param {BPMSoft.Collection} list ######.
			 */
			prepareAggregationTypesList: function(filter, list) {
				if (list === null) {
					return;
				}
				list.clear();
				list.loadAll(this.getAggregationTypeDefaultConfig());
			},

			/**
			 * ########## ###### ######## ####### #########.
			 * @protected
			 * @virtual
			 * @param {Number} aggregationTypeValue ### #########.
			 * @return {Object} ########## ###### ######## ####### #########.
			 */
			getAggregationTypeLookupValue: function(aggregationTypeValue) {
				var aggregationTypeDefaultConfig = this.getAggregationTypeDefaultConfig();
				aggregationTypeValue = (Ext.isNumber(aggregationTypeValue) || aggregationTypeValue.match(/\d+/g))
					? aggregationTypeValue
					: BPMSoft.AggregationType[aggregationTypeValue.toUpperCase()];
				return aggregationTypeDefaultConfig[aggregationTypeValue];
			},

			/**
			 * @inheritdoc BPMSoft.BaseWidgetDesigner#setAttributeDisplayValue
			 * ############ ######## ### ####### #### #########.
			 * @protected
			 * @overridden
			 */
			setAttributeDisplayValue: function(propertyName, propertyValue) {
				if (propertyName === "aggregationType") {
					var aggregationTypeLookupValue =
						this.getAggregationTypeLookupValue(propertyValue);
					this.set(propertyName, aggregationTypeLookupValue);
				} else {
					this.callParent(arguments);
				}
			},
			
			/**
			 * ########## ### ###### ######## ##########.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.DataValueType} ########## ### ###### ######## ##########.
			 */
			getValueDataValueType: function() {
				var result = BPMSoft.DataValueType.TEXT;
				var aggregationType = this.get("aggregationType");
				var columnDataValueType = this.get("aggregationColumn");
				if (aggregationType && (aggregationType.value === BPMSoft.AggregationType.COUNT)) {
					result = BPMSoft.DataValueType.INTEGER;
				} else if (!this.Ext.isEmpty(columnDataValueType)) {
					result = columnDataValueType.dataValueType;
				}
				return result;
			},
			
			/**
			 * ########## ###### ######## ### ########## ##############.
			 * @protected
			 * @virtual
			 * @return {String} ########## ###### ######## ### ########## ##############.
			 */
			getFormatValueTemplate: function() {
				var result;
				var format = this.get("format");
				var dataValueType = this.getValueDataValueType();
				switch (dataValueType) {
					case BPMSoft.DataValueType.INTEGER:
					case BPMSoft.DataValueType.FLOAT:
					case BPMSoft.DataValueType.MONEY:
						var numberTemplate = 1000000.00;
						result = BPMSoft.getFormattedNumberValue(numberTemplate, format || {
							type: BPMSoft.DataValueType.INTEGER
						});
						break;
					case BPMSoft.DataValueType.TIME:
					case BPMSoft.DataValueType.DATE_TIME:
					case BPMSoft.DataValueType.DATE:
						var dateTemplate = new Date();
						var dateFormat = format.dateFormat || BPMSoft.Resources.CultureSettings.dateFormat;
						result = this.Ext.Date.format(dateTemplate, dateFormat);
						break;
				}
				return result;
			},
			
			/**
			 * ##### ######## ########### #### ######### #######.
			 * @protected
			 * @virtual
			 */
			openFormatSettings: function() {
				var dataValueType = this.getValueDataValueType();
				var formatSettingConfig = this.getFormatSettingsConfig(dataValueType);
				BPMSoft.utils.inputBox(
						this.get("Resources.Strings.FormatLabel"),
						this.onFormatSettingsClose,
						["yes", "cancel"],
						this,
						formatSettingConfig,
						{ defaultButton: 0 }
				);
			},
			
			/**
			 * Returns text decoration control configuration.
			 * @protected
			 * @returns {Object} Text decoration control configuration.
			 */
			getTextdecoratorConfig: function() {
				return {};
			},
			
			/**
			 * ########## ###### ######### ########### #### ######### #######.
			 * @protected
			 * @virtual
			 * @param {BPMSoft.DataValueType} dataValueType ### ###### ##########.
			 * @return {Object} ########## ###### ######### ########### #### ######### #######.
			 */
			getFormatSettingsConfig: function(dataValueType) {
				var format = this.get("format") || {};
				var config = this.getTextdecoratorConfig();
				var decimalPrecision = (this.Ext.isDefined(format.decimalPrecision)) ? format.decimalPrecision :
						(format.type === BPMSoft.DataValueType.FLOAT && 2 || 0);
				switch (dataValueType) {
					case BPMSoft.DataValueType.INTEGER:
					case BPMSoft.DataValueType.FLOAT:
					case BPMSoft.DataValueType.MONEY:
						var numberFormatConfig = {
							decimalPrecision: {
								dataValueType: BPMSoft.DataValueType.INTEGER,
								caption: this.get("Resources.Strings.FormatDecimalPrecision"),
								value: decimalPrecision,
								description: this.get("Resources.Strings.FormatDecimalPrecisionDescription")
							}
						};
						this.Ext.apply(config, numberFormatConfig);
						break;
					case BPMSoft.DataValueType.TIME:
					case BPMSoft.DataValueType.DATE_TIME:
					case BPMSoft.DataValueType.DATE:
						var dateFormat = format.dateFormat;
						var dateFormatConfig = {
							dateFormatWithTime: {
								dataValueType: BPMSoft.DataValueType.BOOLEAN,
								caption: this.get("Resources.Strings.FormatDateTime"),
								value: dateFormat && (dateFormat !== BPMSoft.Resources.CultureSettings.dateFormat),
								description: this.get("Resources.Strings.FormatDateTimeDescription")
								
							}
						};
						this.Ext.apply(config, dateFormatConfig);
						break;
				}
				return config;
			},
			
			/**
			 * ##### ######### ######## ########### #### ######### #######.
			 * @protected
			 * @virtual
			 * @param {String} returnCode ### ######## ####.
			 * @param {Object} controlData ###### ######### ######### ##########.
			 */
			onFormatSettingsClose: function(returnCode, controlData) {
				if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
					var format = {};
					BPMSoft.each(controlData, function(property, propertyName) {
						var propertyValue = property.value;
						if (propertyName === "textDecorator") {
							format[propertyName] = propertyValue || "{0}";
						} else if (propertyName === "dateFormatWithTime") {
							var dateFormatPropertyName = "dateFormat";
							if (propertyValue) {
								var dateFormat = this.Ext.String.format(
										"{0} {1}",
										BPMSoft.Resources.CultureSettings.dateFormat,
										BPMSoft.Resources.CultureSettings.timeFormat
								);
								format[dateFormatPropertyName] = dateFormat;
							} else {
								format[dateFormatPropertyName] = BPMSoft.Resources.CultureSettings.dateFormat;
							}
						} else if (propertyName === "decimalPrecision") {
							var dataValueTypePropertyName = "type";
							format[dataValueTypePropertyName] = (propertyValue)
									? BPMSoft.DataValueType.FLOAT
									: BPMSoft.DataValueType.INTEGER;
							format[propertyName] = propertyValue;
						} else {
							format[propertyName] = propertyValue;
						}
					}, this);
					this.set("format", format);
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "AggregationType",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "aggregationType",
					"labelConfig": {
						"caption": { "bindTo": "Resources.Strings.AggregationTypeLabel" }
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": { "bindTo": "prepareAggregationTypesList" },
						"list": { "bindTo": "aggregationTypeList" }
					}
				}
			},
			{
				"operation": "insert",
				"name": "aggregationColumn",
				"parentName": "QueryProperties",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODEL_ITEM,
					"generator": "ColumnEditGenerator.generatePartial",
					"labelConfig": {
						"caption": { "bindTo": "Resources.Strings.AggregationColumnLabel" },
						"isRequired": true
					},
					"visible": {
						"bindTo": "aggregationType",
						"bindConfig": { "converter": "aggregationColumnVisibilityConverter"}
					}
				}
			},
			{
				"operation": "insert",
				"name": "FormatValue",
				"parentName": "FormatProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"bindTo": "getFormatValueTemplate",
					"visible": {
						"bindTo": "FormatValueSettingsVisible"
					},
					"labelConfig": {
						"caption": {
							"bindTo": "Resources.Strings.FormatLabel"
						}
					},
					"classes": { "wrapClass": ["lookup-only-editable"] },
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"readonly": true,
						"rightIconClick": {
							"bindTo": "openFormatSettings"
						},
						"rightIconClasses": ["lookup-edit-right-icon"]
					}
				}
			}
		]
	};
});
