define("GaugeDesigner", ["BPMSoft", "GaugeDesignerResources", "css!DesignerToolsCSS"],
	function(BPMSoft, resources) {
		const localizableStrings = resources.localizableStrings;
		return {
			messages: {
				/**
				 * @message GetGaugeConfig
				 * Notify about receiving gauge display module initialization parameters.
				 */
				"GetGaugeConfig": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * @message GenerateGauge
				 * Notification that gauge was generated.
				 */
				"GenerateGauge": {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			attributes: {
				/**
				 * Gauge caption.
				 * @private
				 * @type {String}
				 */
				caption: {
					value: localizableStrings.NewWidget
				},

				/**
				 * Gauge style.
				 * @private
				 * @type {Object}
				 */
				style: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: BPMSoft.DashboardEnums.WidgetColor["widget-orange"]
				},

				/**
				 * Gauge display order.
				 * @private
				 * @type {Object}
				 */
				orderDirection: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					value: {
						value: BPMSoft.OrderDirection.DESC,
						displayValue: localizableStrings.DescendingOrder
					}
				},

				/**
				 * Gauge scale minimum value.
				 * @private
				 * @type {Number}
				 */
				min: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					allowZeroValue: true
				},

				/**
				 * The "Average from" value of the gauge scale.
				 * @private
				 * @type {Number}
				 */
				middleFrom: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					allowZeroValue: true
				},

				/**
				 * The "Average to" value of the gauge scale.
				 * @private
				 * @type {Number}
				 */
				middleTo: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					allowZeroValue: true
				},

				/**
				 * The "Maximum" value of the gauge scale.
				 * @private
				 * @type {Number}
				 */
				max: {
					dataValueType: BPMSoft.DataValueType.INTEGER,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true,
					allowZeroValue: true
				},

				/**
				 * Gauge display order enumeration.
				 * @private
				 * @type {Object}
				 */
				orderDirections: {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					value: {
						"1": {
							value: BPMSoft.OrderDirection.ASC,
							displayValue: localizableStrings.AscendingOrder
						},
						"2": {
							value: BPMSoft.OrderDirection.DESC,
							displayValue: localizableStrings.DescendingOrder
						}
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseAggregationWidgetDesigner#aggregationColumn
				 * @override
				 */
				aggregationColumn: {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isLookup: true,
					entityStructureConfig: {
						useBackwards: false,
						summaryColumnsOnly: true,
						excludeDataValueTypes: [
							BPMSoft.DataValueType.DATE_TIME,
							BPMSoft.DataValueType.DATE,
							BPMSoft.DataValueType.TIME
						],
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
				 * Returns the message name of getting widget module configuration.
				 * @protected
				 * @virtual
				 * @return {String} The message name of getting gauge module configuration.
				 */
				getWidgetConfigMessage: function() {
					return "GetGaugeConfig";
				},

				/**
				 * Returns the message name of widget refreshing.
				 * @protected
				 * @virtual
				 * @return {String} The message name of gauge refreshing.
				 */
				getWidgetRefreshMessage: function() {
					return "GenerateGauge";
				},

				/**
				 * Returns the object of gauge module properties and gauge settings module relation.
				 * @protected
				 * @virtual
				 * @return {Object} Object of gauge module properties and gauge settings module relation.
				 */
				getWidgetModulePropertiesTranslator: function() {
					const gaugeProperties = {
						"style": "style",
						"orderDirection": "orderDirection",
						"min": "min",
						"middleFrom": "middleFrom",
						"middleTo": "middleTo",
						"max": "max"
					};
					return Ext.apply(this.callParent(arguments), gaugeProperties);
				},

				/**
				 * Returns the widget module name.
				 * @protected
				 * @virtual
				 * @return {String} The widget module name.
				 */
				getWidgetModuleName: function() {
					return "GaugeModule";
				},

				/**
				 * Returns the widget style object.
				 * @protected
				 * @virtual
				 * @return {Object} Style object.
				 */
				getStyleDefaultConfig: function() {
					return BPMSoft.DashboardEnums.WidgetColor;
				},

				/**
				 * Fills the widget list style.
				 * @protected
				 * @virtual
				 * @param {String} filter Filter string.
				 * @param {BPMSoft.Collection} list Collection.
				 */
				prepareStyleList: function(filter, list) {
					if (!list) {
						return;
					}
					list.clear();
					list.loadAll(this.getStyleDefaultConfig());
				},

				/**
				 * Fills the widget direction list.
				 * @protected
				 * @virtual
				 * @param {String} filter Filter string.
				 * @param {BPMSoft.Collection} list Collection.
				 */
				prepareOrderDirectionList: function(filter, list) {
					if (!list) {
						return;
					}
					list.clear();
					list.loadAll(this.getOrderDirectionConfig());
				},

				/**
				 * Returns the object of widget order direction.
				 * @protected
				 * @virtual
				 * @return {Object} The object of widget order direction.
				 */
				getOrderDirectionConfig: function() {
					return this.get("orderDirections");
				},

				/**
				 * @inheritdoc BPMSoft.BaseWidgetDesigner#setAttributeDisplayValue
				 * @override
				 */
				setAttributeDisplayValue: function(propertyName, propertyValue) {
					switch (propertyName) {
						case "style":
							propertyValue = this.getStyle(propertyValue);
							break;
						case "orderDirection":
							propertyValue = this.getOrderDirection(propertyValue);
							break;
						default:
							this.callParent(arguments);
							return;
					}
					this.set(propertyName, propertyValue);
				},

				/**
				 * Returns the widget style.
				 * @private
				 * @param {String} styleName Name of the style.
				 * @return {Object} Widget style.
				 */
				getStyle: function(styleName) {
					const styleConfig = this.getStyleDefaultConfig();
					return styleConfig[styleName];
				},

				/**
				 * Returns the widget order direction.
				 * @private
				 * @param {String} orderDirectionName Order direction name.
				 * @return {Object} The widget order direction.
				 */
				getOrderDirection: function(orderDirectionName) {
					const orderDirectionConfig = this.get("orderDirections");
					return orderDirectionConfig[orderDirectionName];
				},

				/**
				 * Returns configuration image for the icon of the order direction of widget.
				 * @protected
				 * @return {Object} Image configuration.
				 */
				getScaleOrderDirectionImageConfig: function() {
					const orderDirection = this.get("orderDirection");
					if (!orderDirection) {
						return null;
					}
					const iconName = (orderDirection.value === BPMSoft.OrderDirection.ASC)
						? "ScaleUpIcon"
						: "ScaleDownIcon";
					const icon = this.get("Resources.Images." + iconName);
					return icon;
				},

				/**
				 * Returns the markerValue name of widget order direction icon.
				 * @protected
				 * @return {Object} The markerValue name of widget order direction icon.
				 */
				getScaleOrderDirectionIconMarkerValueName: function() {
					const orderDirection = this.get("orderDirection");
					if (!orderDirection) {
						return null;
					}
					const markerValueName = (orderDirection.value === BPMSoft.OrderDirection.ASC)
						? "ScaleOrderDirectionIconAsc"
						: "ScaleOrderDirectionIconDesc";
					return markerValueName;
				}

			},
			diff: [
				{
					"operation": "insert",
					"name": "OrderDirection",
					"parentName": "FormatProperties",
					"propertyName": "items",
					"index": 0,
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"bindTo": "orderDirection",
						"labelConfig": {
							"caption": {
								"bindTo": "Resources.Strings.OrderDirectionCaption"
							}
						},
						"controlConfig": {
							"className": "BPMSoft.ComboBoxEdit",
							"prepareList": {
								"bindTo": "prepareOrderDirectionList"
							},
							"list": {
								"bindTo": "orderDirectionList"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "ScaleContainer",
					"parentName": "FormatProperties",
					"propertyName": "items",
					"index": 1,
					"values": {
						"id": "ScaleContainer",
						"selectors": {"wrapEl": "#ScaleContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["scale-container", "control-width-15"],
						"markerValue": "ScaleContainer",
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Style",
					"parentName": "FormatProperties",
					"propertyName": "items",
					"index": 2,
					"values": {
						"dataValueType": BPMSoft.DataValueType.ENUM,
						"bindTo": "style",
						"labelConfig": {
							"caption": {
								"bindTo": "Resources.Strings.StyleCaption"
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
					"name": "ScaleLabelContainer",
					"parentName": "ScaleContainer",
					"propertyName": "items",
					"values": {
						"id": "ScaleLabelContainer",
						"selectors": {"wrapEl": "#ScaleLabelContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["label-wrap"],
						"markerValue": "ScaleLabelContainer",
						"items": []
					}
				},

				{
					"operation": "insert",
					"name": "ScaleControlContainer",
					"parentName": "ScaleContainer",
					"propertyName": "items",
					"values": {
						"id": "ScaleControlContainer",
						"selectors": {"wrapEl": "#ScaleControlContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["control-wrap"],
						"markerValue": "ScaleControlContainer",
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ScaleIndicatorContainer",
					"parentName": "ScaleControlContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"id": "ScaleIndicatorContainer",
						"selectors": {"wrapEl": "#ScaleIndicatorContainer"},
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["scale-indicator-container"],
						"markerValue": "ScaleIndicatorContainer",
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "ScaleLabel",
					"parentName": "ScaleLabelContainer",
					"propertyName": "items",
					"values": {
						classes: {
							"labelClass": ["scale-caption", "t-label-is-required"]
						},
						"itemType": BPMSoft.ViewItemType.LABEL,
						"caption": {"bindTo": "Resources.Strings.ScaleCaption"}
					}
				},
				{
					"operation": "insert",
					"name": "Min",
					"parentName": "ScaleIndicatorContainer",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.INTEGER,
						"bindTo": "min",
						"labelConfig": {
							"visible": false
						},
						"useThousandSeparator": false
					}
				},
				{
					"operation": "insert",
					"name": "MiddleFrom",
					"parentName": "ScaleIndicatorContainer",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.INTEGER,
						"bindTo": "middleFrom",
						"labelConfig": {
							"visible": false
						},
						"useThousandSeparator": false
					}
				},
				{
					"operation": "insert",
					"name": "MiddleToLabel",
					"parentName": "ScaleIndicatorContainer",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.INTEGER,
						"bindTo": "middleTo",
						"labelConfig": {
							"visible": false
						},
						"useThousandSeparator": false
					}
				},
				{
					"operation": "insert",
					"name": "Max",
					"parentName": "ScaleIndicatorContainer",
					"propertyName": "items",
					"values": {
						"dataValueType": BPMSoft.DataValueType.INTEGER,
						"bindTo": "max",
						"labelConfig": {
							"visible": false
						},
						"useThousandSeparator": false
					}
				},
				{
					"operation": "insert",
					"index": 1,
					"name": "ScaleOrderDirectionIcon",
					"parentName": "ScaleControlContainer",
					"propertyName": "items",
					"values": {
						"id": "ScaleOrderDirectionIcon",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "getScaleOrderDirectionImageConfig"},
						"classes": {"wrapperClass": ["scale-order-direction-icon"]},
						"markerValue": {"bindTo": "getScaleOrderDirectionIconMarkerValueName"},
						"selectors": {"wrapEl": "#ScaleOrderDirectionIcon"},
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT
					}
				}
			]
		};
	}
);
