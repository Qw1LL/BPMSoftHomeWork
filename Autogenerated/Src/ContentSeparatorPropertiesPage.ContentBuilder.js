define("ContentSeparatorPropertiesPage", [], function() {
	return {
		attributes: {

			/**
			 * Separator thickness.
			 */
			Thickness: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onSeparatorPropertyChange"
			},

			/**
			 * Separator style.
			 */
			Style: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onSeparatorPropertyChange"
			},

			/**
			 * Separator color.
			 */
			Color: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onSeparatorPropertyChange"
			},

			/**
			 * Separator styles list.
			 */
			SeparatorStyleList: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onSeparatorStyleLookupChanged"
			}
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_onSeparatorStyleLookupChanged: function(model, lookupValue) {
				this.$Style = lookupValue && lookupValue.value;
			},

			/**
			 * @private
			 */
			_onSeparatorPropertyChange: function() {
				Ext.apply(this.$Config, {
					Color: this.$Color,
					Style: this.$Style,
					Thickness: (this.$Thickness || 0) + "px"
				});
				this.save();
			},

			// endregion

			// region Methods: Protected

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @override
			 */
			onContentItemConfigChanged: function(config) {
				config = BPMSoft.deepClone(config);
				if (Ext.isObject(config)) {
					this.$Thickness = parseFloat(config.Thickness) || 0;
					this.$Color = config.Color || "";
					const style = Ext.String.capitalize(config.Style || "");
					this.$SeparatorStyleList = {
						value: style,
						displayValue: style
					};
				}
			},

			/**
			 * Creates list of supported separator styles.
			 * @protected
			 */
			prepareSeparatorStylesList: function(filter, list) {
				const result = this.Ext.create("BPMSoft.Collection");
				const stylesValues = [
					"Dotted",
					"Dashed",
					"Solid",
					"Double",
					"Groove",
					"Ridge"
				];
				stylesValues.forEach(function(style) {
					result.add(style, {
						value: style,
						displayValue: style
					});
				});
				list.reloadAll(result);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Thickness", BPMSoft.validateNumberRange.bind(this, 0,
					BPMSoft.DataValueTypeRange.INTEGER.maxValue));
			}

			// endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "ContentSeparatorEditorContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["content-styles-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "PropertiesContainer",
				"propertyName": "items",
				"parentName": "ContentSeparatorEditorContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {
						"bindTo": "Config",
						"bindConfig": {
							"converter": "toBoolean"
						}
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "PropertiesContainer",
				"name": "SeparatorSettingsControlGroup",
				"propertyName": "items",
				"values": {
					"caption": "$Resources.Strings.SeparatorControlGroupLabel",
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"wrapClass": ["separator-settings-control-group"]
				}
			},
			{
				"operation": "insert",
				"name": "SeparatorPropertiesContainer",
				"parentName": "SeparatorSettingsControlGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper", "disable-input-label"]
				}
			},
			{
				"operation": "insert",
				"parentName": "SeparatorPropertiesContainer",
				"propertyName": "items",
				"name": "SeparatorColor",
				"values": {
					"itemType": BPMSoft.ViewItemType.COLOR_BUTTON,
					"value": "$Color",
					"markerValue": "Color",
					"defaultValue": "#cccccc",
					"menuItemClassName": BPMSoft.MenuItemType.COLOR_PICKER,
					"classes": {
						"wrapClasses": ["separator-color-editor"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "SeparatorThicknessImage",
				"parentName": "SeparatorPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["icon-16x16 stroke-width"]
				}
			},
			{
				"operation": "insert",
				"name": "Thickness",
				"parentName": "SeparatorPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"caption": "Thickness",
					"markerValue": "Thickness",
					"wrapClass": ["style-input", "separator-thickness-control"]
				}
			},
			{
				"operation": "insert",
				"name": "SeparatorUnitLabel",
				"parentName": "SeparatorPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "px",
					"classes": {
						"labelClass": ["visible-label", "width-unit-label"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "SeparatorPropertiesContainer",
				"propertyName": "items",
				"name": "SeparatorStyleList",
				"values": {
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": "$prepareSeparatorStylesList"
					},
					"markerValue": "SeparatorStyleList",
					"wrapClass": ["style-input"],
					"caption": "SeparatorStyleList"
				}
			}
		]
	};
});
