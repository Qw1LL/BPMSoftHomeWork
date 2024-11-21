define("HomePageFunnelDesigner",
	 ["HomePageFunnelDesignerResources", "SchemaViewComponent", "FunnelWidgetComponent", "ExtWidgetConfigConverter",
		 "AngularWidgetConfigConverter", "css!HomePageDesignerCSS", "css!ConfigurationModuleV2", "WidgetEnums",
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
				value: BPMSoft.WidgetEnums.WidgetColor["blue"]
			},
			WidgetColor: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: BPMSoft.WidgetEnums.WidgetColor["blue"]
			},
			WidgetTheme: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				isRequired: true,
				value: BPMSoft.WidgetEnums.WidgetTheme["full-fill"]
			},
			WidgetConfig: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			caption: {
				value: resources.localizableStrings.DefaultCaption
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
			_getLocalizedConfig: function() {
				const { title } = this.currentWidgetConfig;
				const chartName = this.get("WidgetInitConfig").name;
				const titleKey = `${chartName}_title`;
				this.upsertResource(titleKey, title);
				return {
					...this.currentWidgetConfig,
					resources: this.get("Resources"),
					title: this.getPatternLocalizedString(titleKey),
				};
			},

			/**
			 * Fill style collection.
			 * @protected
			 * @virtual
			 * @param {String} filter Filtering string.
			 * @param {BPMSoft.Collection} list List.
			 */
			prepareStyleColorList: function(filter, list) {
				this.reloadList(list, this.getStyleColorDefaultConfig());
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
			getStyleColorDefaultConfig: function() {
				return BPMSoft.WidgetEnums.WidgetColor;
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			init: function(callback, scope) {
				this.initChartDesigner();
				this.callParent([function() {
					this.hideDesignerLoadingMask();
					Ext.callback(callback, scope);
				}, this]);
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

			/**
			 * @inheritDoc
			 * @override
			 */
			initChartDesigner: function() {
				const widgetConfig = this.sandbox.publish("GetModuleConfig", null, [this.sandbox.id]);
				const { itemConfig: { config, name }, defaultConfig, resources } = widgetConfig;
				this.set("Resources", resources ?? {});
				if (config) {
					const { title } = config;
					config.title = this.getResourceValue(title);
				}
				const widgetInitConfig = this.convertToExtWidgetConfig(config || defaultConfig || {});
				this.set("WidgetInitConfig", { ...widgetInitConfig, name: name.replace(/(-|\.)/g, '') });
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
			refreshWidget: function() {
				this.callParent(arguments);
				const canRefresh = this.canRefreshWidget();
				const designWidgetConfig = this.getDesignWidgetConfig();
				const convertedWidgetConfig = this.convertToAngularWidgetConfig(designWidgetConfig);
				const isWidgetConfigChanged = JSON.stringify(convertedWidgetConfig) !== JSON.stringify(this.currentWidgetConfig);
				if (canRefresh && isWidgetConfigChanged) {
					this.currentWidgetConfig = BPMSoft.deepClone(convertedWidgetConfig);
					this.set("WidgetConfig", convertedWidgetConfig);
					const localizedConfig = this._getLocalizedConfig();
					this.sandbox.publish("WidgetConfigChanged", localizedConfig, [this.sandbox.id]);
				}
			},

			/**
			 * Converts a specified Angular funnel widget config to Ext.
			 * @protected
			 * @virtual
			 * @param {AngularFunnelWidgetConfig} widgetConfig The Angular funnel widget config.
			 * @returns {ExtFunnelWidgetConfig} The Ext funnel widget config based on the widgetConfig.
			 */
			convertToExtWidgetConfig: function(widgetConfig) {
				return BPMSoft.AngularWidgetConfigConverter.toExtFunnelWidgetConfig(widgetConfig);
			},

			/**
			 * Converts a specified Ext funnel widget config to Angular.
			 * @protected
			 * @virtual
			 * @param {ExtFunnelWidgetConfig} widgetConfig The Ext funnel widget config.
			 * @returns {AngularFunnelWidgetConfig} The Angular funnel widget config based on the widgetConfig.
			 */
			convertToAngularWidgetConfig: function(widgetConfig) {
				return BPMSoft.ExtWidgetConfigConverter.toAngularFunnelWidgetConfig(widgetConfig);
			},

			/**
			 * @inheritDoc
			 * @override
			 */
			onRender: function() {
				this.callParent(arguments);
				this.observeBodyMutations();
				this.sandbox.publish("DesignerLoaded", null, [this.sandbox.id]);
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
				"operation": "move",
				"name": "Style",
				"parentName": "WidgetProperties",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "FunnelWidgetPreview",
				"parentName": "FooterContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 11,
						"row": 0,
						"colspan": 13,
						"rowSpan": 1
					},
					"itemType": BPMSoft.ViewItemType.COMPONENT,
					"className": "BPMSoft.FunnelWidgetComponent",
					"widgetConfig": { "bindTo": "WidgetConfig" }
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
