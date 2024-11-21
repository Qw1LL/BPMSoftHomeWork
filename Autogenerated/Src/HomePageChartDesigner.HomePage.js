 define("HomePageChartDesigner",
	 ["HomePageChartDesignerResources", "SchemaViewComponent", "ChartWidgetComponent", "ExtWidgetConfigConverter",
		 "AngularWidgetConfigConverter",  "css!HomePageDesignerCSS", "css!ConfigurationModuleV2", "WidgetEnums",
		 "HomePageWidgetDesignerMixin"],
 function(resources) {
	return {
		messages: {
			WidgetConfigChanged: {
				direction: BPMSoft.MessageDirectionType.PUBLISH,
				mode: BPMSoft.MessageMode.BROADCAST
			},
			DesignerLoaded: {
				direction: BPMSoft.MessageDirectionType.PUBLISH,
				mode: BPMSoft.MessageMode.BROADCAST
			},
			ModalOpening: {
				direction: BPMSoft.MessageDirectionType.PUBLISH,
				mode: BPMSoft.MessageMode.BROADCAST
			},
			ModalClosing: {
				direction: BPMSoft.MessageDirectionType.PUBLISH,
				mode: BPMSoft.MessageMode.BROADCAST
			},
		},
		attributes: {
			StyleColor: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: BPMSoft.WidgetEnums.WidgetColor["green"]
			},
			WidgetColor: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: BPMSoft.WidgetEnums.WidgetColor["green"]
			},
			WidgetTheme: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: BPMSoft.WidgetEnums.WidgetTheme["full-fill"]
			},
			ChartWidgetConfig: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			RowCount: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 50
			}
		},
		mixins: {
			/**
			 * @class HomePageWidgetDesignerMixin provides the widgets adjustment functionality.
			 */
			HomePageWidgetDesignerMixin: "BPMSoft.HomePageWidgetDesignerMixin"
		},
		methods: {

			/**
		 	* @private
		 	*/
			_getLocalizedSeries: function() {
				const chartName = this.get("WidgetInitConfig").name;
				return this.currentWidgetConfig.series.map((series, index) => {
					const labelKey = `${chartName}_series_${index}`;
					this.upsertResource(labelKey, series.label);
					series.label = this.getPatternLocalizedString(labelKey);
					return series;
				});
			},

			/**
		 	* @private
		 	*/
			_getLocalizedAxis: function(axis, axisName) {
				const chartName = this.get("WidgetInitConfig").name;
				const axisKey = `${chartName}_${axis}`;
				const settedAxisName = this.upsertResource(axisKey, axisName);
				return settedAxisName ? this.getPatternLocalizedString(axisKey) : '';
			},

			/**
		 	* @private
		 	*/
			_getLocalizedConfig: function() {
				const resources = this.get("Resources");
				const chartName = this.get("WidgetInitConfig").name;
				const titleKey = `${chartName}_title`;
				this.upsertResource(titleKey, this.currentWidgetConfig.title)
				const localizedSeries = this._getLocalizedSeries();
				const localizedConfig = { 
					...this.currentWidgetConfig,
					series: localizedSeries,
					title: this.getPatternLocalizedString(titleKey),
					resources,
				};
				const { xAxis = {}, yAxis = {} } = this.currentWidgetConfig.scales;
				localizedConfig.scales.xAxis.name = this._getLocalizedAxis('xAxis', xAxis.name);
				localizedConfig.scales.yAxis.name = this._getLocalizedAxis('yAxis', yAxis.name);
				return localizedConfig;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			save: BPMSoft.emptyFn,

			/**
			 * @inheritDoc
			 * @override
			 */
			cancel: BPMSoft.emptyFn,

			/**
			 * @inheritDoc
			 * @override
			 */
			init: function(callback, scope) {
				this.callParent([function() {
					this.hideDesignerLoadingMask();
					BPMSoft.SysSettings.querySysSettingsItem("ChartQueryDataLimit", function(value) {
						this.$RowCount = value;
						Ext.callback(callback, scope);
					}, this);
				}, this]);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getChartTypeDefaultConfig: function() {
				const baseTypes = this.callParent(arguments);
				Ext.merge(baseTypes.pie, {
					displayValue: resources.localizableStrings.DoughnutChartCaption
				});
				return baseTypes;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			initChartDesigner: function() {
				const widgetConfig = this.sandbox.publish("GetModuleConfig", null, [this.sandbox.id]);
				const { itemConfig: { config, name }, defaultConfig, resources } = widgetConfig;
				this.setResources(resources)
				if (config) {
					const { title, scales } = config;
					if (scales) {
						const { xAxis = {}, yAxis = {} } = scales;
						config.scales.xAxis.name = this.getResourceValue(xAxis.name);
						config.scales.yAxis.name = this.getResourceValue(yAxis.name);
					}
					config.title = this.getResourceValue(title);
					config.series.forEach(series => series.label = this.getResourceValue(series.label));
				}
				const widgetInitConfig = this.convertToExtWidgetConfig(config || defaultConfig || {});
				this.set("WidgetInitConfig", { ...widgetInitConfig, name: name.replace(/(-|\.)/g, '') });
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getSeriesConfigItem: function(viewModel) {
				const itemConfig = this.callParent(arguments);
				const selectedEntitySchema = viewModel && viewModel.$entitySchemaName || {};
				itemConfig.schemaCaption = selectedEntitySchema.displayValue || '';
				itemConfig.rowCount = this.$RowCount;
				return itemConfig;
			},
			
			/**
			 * @inheritDoc
			 * @override
			 */
			refreshWidget: function() {
				this.callParent(arguments);
				const canRefresh = this.canRefreshWidget();
				const designWidgetConfig = this.getDesignWidgetConfig();
				const convertedWidgetConfig = this.convertToAngularWidgetConfig(designWidgetConfig);
				const isWidgetConfigChanged = JSON.stringify(convertedWidgetConfig) !== JSON.stringify(this.currentWidgetConfig);
				if (canRefresh && isWidgetConfigChanged && !this.$IsUnsupportedTypes) {
					this.currentWidgetConfig = BPMSoft.deepClone(convertedWidgetConfig);
					this.$ChartWidgetConfig = convertedWidgetConfig;
					const localizedConfig = this._getLocalizedConfig();
					this.sandbox.publish("WidgetConfigChanged", localizedConfig, [this.sandbox.id]);
				}
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			copyActiveSeries: function() {
				this.callParent(arguments);
				this.refreshWidget();
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			deleteActiveSeries: function() {
				const deletingSeriesIndex = this.$SeriesCollection.indexOfKey(this.$ActiveSeriesName);
				this.callParent(arguments);
				const chartName = this.get("WidgetInitConfig").name;
				const keyBase = `${chartName}_series`;
				const key = `${keyBase}_${deletingSeriesIndex}`;
				const resources = this.get("Resources");
				delete resources.strings[key];
				Object.keys(resources.strings).forEach((key) => {
					let serialNumber = Number(key.split('series_')[1]);
					const needPositionRecalculation = key.startsWith(keyBase) && serialNumber > deletingSeriesIndex;
					if (needPositionRecalculation) {
						const brokenOrderSeriesKey = `${keyBase}_${serialNumber}`;
						resources.strings[`${keyBase}_${serialNumber-1}`] = resources.strings[brokenOrderSeriesKey]
						delete resources.strings[brokenOrderSeriesKey];
					};
				});
				this.setResources(resources);
				this.refreshWidget();
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getWidgetModulePropertiesTranslator: function() {
				let props = this.callParent(arguments);
				props.WidgetColor = "widgetColor";
				props.WidgetTheme = "widgetTheme";
				return props;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getDesignWidgetConfig: function() {
				const config = this.callParent(arguments);
				config.widgetColor = this.$WidgetColor?.value;
				config.widgetTheme = this.$WidgetTheme?.value;
				return config;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			setAttributeDisplayValue: function(propertyName, propertyValue) {
				switch (propertyName) {
					case "WidgetColor":
						propertyValue = this.getStyleColorDefaultConfig()[propertyValue];
						break;
					case "WidgetTheme":
						propertyValue = this.getWidgetThemeDefaultConfig()[propertyValue];
						break;
					default:
						this.callParent(arguments);
						return;
				}
				this.set(propertyName, propertyValue);
			},

			convertToExtWidgetConfig: function(widgetConfig) {
				return BPMSoft.AngularWidgetConfigConverter.toExtChartWidgetConfig(widgetConfig);
			},

			convertToAngularWidgetConfig: function(widgetConfig) {
				return BPMSoft.ExtWidgetConfigConverter.toAngularChartWidgetConfig(widgetConfig);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.observeBodyMutations();
				this.sandbox.publish("DesignerLoaded", null, [this.sandbox.id]);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			getStyleColorDefaultConfig: function() {
				return BPMSoft.WidgetEnums.WidgetColor;
			},

			yAxisCaptionLabelConverter: function() {
				return this.get("Resources.Strings.YAxisCaption2");
			},

			axisCaptionVisibilityConverter: function(value) {
				const chartTypesWithoutAxis = ["pie", "funnel"];
				return Boolean(value && !BPMSoft.contains(chartTypesWithoutAxis, value.value));
			},

			styleColorVisibilityConverter: function(value) {
				const chartTypesWithoutColorsSettings = ["pie", "funnel"];
				return Boolean(value && !BPMSoft.contains(chartTypesWithoutColorsSettings, value.value));
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "HeaderStyleColor",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "WidgetColor",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.WidgetColorLabel"
						}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareStyleColorList"
						},
						"list": {
							"bindTo": "WidgetColorList"
						}
					}
				},
				"index": 1,
			},
			{
				"operation": "insert",
				"name": "WidgetTheme",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"bindTo": "WidgetTheme",
					"labelConfig": {
						"visible": true,
						"caption": {
							"bindTo": "Resources.Strings.WidgetThemeLabel"
						}
					},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {
							"bindTo": "prepareWidgetThemeList"
						},
						"list": {
							"bindTo": "WidgetThemeList"
						}
					}
				},
				"index": 2,
			},
			{
				"operation": "merge",
				"name": "XAxisDefaultCaption",
				"values": {
					"bindTo": "XAxisDefaultCaption",
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": "axisCaptionVisibilityConverter"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "StyleColor",
				"values": {
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": "styleColorVisibilityConverter"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "YAxisDefaultCaption",
				"values": {
					"bindTo": "YAxisDefaultCaption",
					"visible": {
						"bindTo": "ChartType",
						"bindConfig": {
							"converter": "axisCaptionVisibilityConverter"
						}
					}
				}
			},
			{
				"operation": "merge",
				"name": "XAxisCaption",
				"values": {
					"visible": false,
				}
			},
			{
				"operation": "merge",
				"name": "WidgetProperties",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 10
					}
				}
			},
			{
				"operation": "merge",
				"name": "FooterContainer",
				"parentName": "WidgetDesignerContainer",
				"propertyName": "items",
				"values": {
					"id": "FooterContainer",
					"selectors": {
						"wrapEl": "#FooterContainer"
					},
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"layout": {
						"column": 0,
						"row": 1,
						"colSpan": 20
					}
				}
			},
			{
				"operation": "insert",
				"name": "ChartWidgetPreview",
				"parentName": "FooterContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 11,
						"row": 0,
						"column": 13,
						"rowSpan": 1
					},
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.ChartWidgetComponent",
					"widgetConfig": { "bindTo": "ChartWidgetConfig" }
				}
			},
			{
				"operation": "remove",
				"name": "WidgetModule"
			},
			{
				"operation": "remove",
				"name": "CancelButton"
			},
			{
				"operation": "remove",
				"name": "SaveButton"
			}
		]
	};
});
