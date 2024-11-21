define("IndicatorDesigner", ["BPMSoft", "IndicatorDesignerResources"],
	function(BPMSoft, resources) {
		var localizableStrings = resources.localizableStrings;
		return {
			messages: {

				/**
				 * ######## ## ######### ### ######### ########## ############# ###### ##########.
				 */
				"GetIndicatorConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ########## ######### ### ######### ##########.
				 */
				"GenerateIndicator": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}

			},
			attributes: {
				/**
				 * ######### #######.
				 */
				caption: {
					value: localizableStrings.NewWidget
				},

				/**
				 * ##### ##########.
				 */
				style: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: BPMSoft.DashboardEnums.WidgetColor["widget-orange"]
				},

				/**
				 * ##### ##########.
				 */
				fontStyle: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: {
						value: "default-indicator-font-size",
						displayValue: localizableStrings.FontStyleDefault
					}
				},

				/**
				 * ######### #######.
				 */
				formatCaption: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				
				/**
				 * @inheritdoc BPMSoft.BaseAggregationWidgetDesigner#format
				 * @override
				 */
				format: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: false,
					value: {
						"textDecorator": "{0}",
						"thousandSeparator": BPMSoft.Resources.CultureSettings.thousandSeparator,
						"type": BPMSoft.DataValueType.FLOAT,
						"dateFormat": BPMSoft.Resources.CultureSettings.dateFormat
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseAggregationWidgetDesigner#FormatValueSettingsVisible
				 * @override
				 */
				FormatValueSettingsVisible: {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: true
				}

			},
			methods: {

				/**
				 * ########## ######## ######### ######### ######## ###### #######.
				 * @protected
				 * @virtual
				 * @return {String} ########## ######## ######### ######### ######## ###### #######.
				 */
				getWidgetConfigMessage: function() {
					return "GetIndicatorConfig";
				},

				/**
				 * ########## ######## ######### ########## #######.
				 * @protected
				 * @virtual
				 * @return {String} ########## ######## ######### ########## #######.
				 */
				getWidgetRefreshMessage: function() {
					return "GenerateIndicator";
				},

				/**
				 * ########## ###### ########### ####### ###### ####### # ###### ######### #######.
				 * @protected
				 * @virtual
				 * @return {Object} ########## ###### ########### ####### ###### ####### # ###### ######### #######.
				 */
				getWidgetModulePropertiesTranslator: function() {
					var widgetModulePropertiesTranslator = {
						aggregationColumn: "columnName",
						style: "style",
						fontStyle: "fontStyle"
					};
					return Ext.apply(this.callParent(arguments), widgetModulePropertiesTranslator);
				},

				/**
				 * ########## ######## ###### #######.
				 * @protected
				 * @virtual
				 * @return {String} ########## ######## ###### #######.
				 */
				getWidgetModuleName: function() {
					return "IndicatorModule";
				},

				/**
				 * @inheritdoc BPMSoft.BaseWidgetDesigner#setAttributeDisplayValue
				 * ############ ######## ### ####### #####.
				 * @protected
				 * @overridden
				 */
				setAttributeDisplayValue: function(propertyName, propertyValue) {
					switch (propertyName) {
						case "style":
							propertyValue = this.getStyleLookupValue(propertyValue);
							break;
						case "fontStyle":
							propertyValue = this.getFontStyleLookupValue(propertyValue);
							break;
						default:
							this.callParent(arguments);
							return;
					}
					this.set(propertyName, propertyValue);
				},

				/**
				 * ########## ###### ######## #####.
				 * @protected
				 * @virtual
				 * @param {String} styleValue ######## #####.
				 * @return {Object} ########## ###### ######## #####.
				 */
				getStyleLookupValue: function(styleValue) {
					var styleDefaultConfig = this.getStyleDefaultConfig();
					return styleDefaultConfig[styleValue];
				},

				/**
				 * ########## ###### ######## ##### #######.
				 * @protected
				 * @virtual
				 * @param {String} fontStyleValue ######## ##### #######.
				 * @return {Object} ########## ###### ######## ##### #######.
				 */
				getFontStyleLookupValue: function(fontStyleValue) {
					var fontStyleDefaultConfig = this.getFontStyleDefaultConfig();
					return fontStyleDefaultConfig[fontStyleValue];
				},

				/**
				 * ########## ###### ######.
				 * @protected
				 * @virtual
				 * @return {Object} ########## ###### ######.
				 */
				getStyleDefaultConfig: function() {
					return BPMSoft.DashboardEnums.WidgetColor;
				},

				/**
				 * ######### ######### ######.
				 * @protected
				 * @virtual
				 * @param {String} filter ###### ##########.
				 * @param {BPMSoft.Collection} list ######.
				 */
				prepareStyleList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					list.loadAll(this.getStyleDefaultConfig());
				},

				/**
				 * ########## ###### ###### ########.
				 * @protected
				 * @virtual
				 * @return {Object} ########## ###### ###### ########.
				 */
				getFontStyleDefaultConfig: function() {
					var fontStyleDefaultConfig = {
						"default-indicator-font-size": {
							value: "default-indicator-font-size",
							displayValue: this.get("Resources.Strings.FontStyleDefault")
						},
						"big-indicator-font-size": {
							value: "big-indicator-font-size",
							displayValue: this.get("Resources.Strings.FontStyleBig")
						}
					};
					return fontStyleDefaultConfig;
				},

				/**
				 * ######### ######### ###### ########.
				 * @protected
				 * @virtual
				 * @param {String} filter ###### ##########.
				 * @param {BPMSoft.Collection} list ######.
				 */
				prepareFontStyleList: function(filter, list) {
					if (list === null) {
						return;
					}
					list.clear();
					list.loadAll(this.getFontStyleDefaultConfig());
				},

				/**
				 * @inheritdoc BPMSoft.BaseAggregationWidgetDesigner#getTextdecoratorConfig
				 * @override
				 */
				getTextdecoratorConfig: function() {
					var format = this.get("format");
					return {
						textDecorator: {
							dataValueType: BPMSoft.DataValueType.TEXT,
							caption: this.get("Resources.Strings.FormatTextLabel"),
							value: format.textDecorator,
							description: this.get("Resources.Strings.FormatTextDescription")
						}
					};
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "Style",
					"parentName": "FormatProperties",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"bindTo": "style",
						"labelConfig": {
							"visible": true,
							"caption": {
								"bindTo": "Resources.Strings.StyleLabel"
							}
						},
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": {
								"bindTo": "prepareStyleList"
							},
							"list": {
								"bindTo": "styleList"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "FontStyle",
					"parentName": "FormatProperties",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"bindTo": "fontStyle",
						"labelConfig": {
							"visible": true,
							"caption": {
								"bindTo": "Resources.Strings.FontStyleLabel"
							}
						},
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": {
								"bindTo": "prepareFontStyleList"
							},
							"list": {
								"bindTo": "fontStyleList"
							}
						}
					}
				}
			]
		};
	});
