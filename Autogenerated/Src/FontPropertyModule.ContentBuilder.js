 define("FontPropertyModule", function() {
	return {
		attributes: {
			/**
			 * Font size.
			 */
			FontSize: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 13,
				onChange: "_onFontSizeChanged"
			},
			/**
			 * Color value.
			 */
			Color: {
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "save"
			},
			/**
			 * Line height.
			 */
			LineHeight: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 22,
				onChange: "save"
			},
			/**
			 * Flag indicates does line height available.
			 */
			UseLineHeight: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: true
			},
			/**
			 * Letter spacing.
			 */
			LetterSpacing: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0,
				onChange: "save"
			},
			/**
			 * Flag indicates does letter spacing available.
			 */
			UseLetterSpacing: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				value: false
			}
		},
		properties: {
			/**
			 * Array of applicable style attributes.
			 */
			workStyles: ["font-size","color","line-height","letter-spacing"]
		},
		methods: {
			/**
			 * @private
			 */
			_initFont: function() {
				var styles = this.$Config[this.$PropertyName];
				this.$Color = styles.color || "#000000";
				this.$FontSize = parseFloat(styles["font-size"]) || 13;
				if (this.$UseLineHeight) {
					this.$LineHeight = parseFloat(styles["line-height"]) || 22;
				}
				if (this.$UseLetterSpacing) {
					this.$LetterSpacing = parseFloat(styles["letter-spacing"]) || 0;
				}
			},

			/**
			 * @private
			 */
			_onFontSizeChanged: function() {
				this.$LineHeight = this.$FontSize && this.$LineHeight < this.$FontSize
					? this.$FontSize
					: this.$LineHeight;
				this.save();
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("FontSize", this.fontSizeValidator);
				this.addColumnValidator("LineHeight", this.lineHeightValidator);
				this.addColumnValidator("LetterSpacing", this.letterSpacingValidator);
			},

			/**
			 * Validates font size.
			 * @protected
			 */
			fontSizeValidator: function(value) {
				return BPMSoft.validateNumberRange(7, 200, value);
			},

			/**
			 * Validates line height.
			 * @protected
			 */
			lineHeightValidator: function(value) {
				var minValue = Math.max(this.$FontSize, 7);
				return !this.$UseLineHeight
					? { isValid: true }
					: BPMSoft.validateNumberRange(minValue, 250, value);
			},

			/**
			 * Validates letter spacing.
			 * @protected
			 */
			letterSpacingValidator: function(value) {
				return Ext.isEmpty(value) || !this.$UseLetterSpacing
					? { isValid: true }
					: BPMSoft.validateNumberRange(0, 30, value);
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#validateConfigValues
			 * @override
			 */
			validateConfigValues: function(callback, scope) {
				var isValid = this.fontSizeValidator(this.$FontSize).isValid
					&& this.lineHeightValidator(this.$LineHeight).isValid
					&& this.letterSpacingValidator(this.$LetterSpacing).isValid;
				Ext.callback(callback, scope, [{valid: isValid}]);
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#getPropertyValue
			 * @override
			 */
			getPropertyValue: function() {
				var result = {
					"font-size": this.$FontSize + "px",
					"color": this.$Color
				};
				if (this.$UseLineHeight) {
					result["line-height"] = this.$LineHeight + "px";
				}
				if (this.$UseLetterSpacing) {
					result["letter-spacing"] = (this.$LetterSpacing || 0) + "px";
				}
				return result;

			},

			/**
			 * @inheritdoc BaseStylePropertyModule#init
			 * @override
			 */
			initProperty: function() {
				this.callParent();
				this._initFont();
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "FontSizePropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper", "font-properties-layout"]
				}
			},
			{
				"operation": "insert",
				"name": "FontSize",
				"parentName": "FontSizePropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$FontSize",
					"markerValue": "FontSize",
					"wrapClass": ["style-input"],
					"labelConfig": {
						"caption": "$Resources.Strings.FontSizeCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "LineHeight",
				"parentName": "FontSizePropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$LineHeight",
					"markerValue": "LineHeight",
					"wrapClass": ["style-input"],
					"visible": "$UseLineHeight",
					"labelConfig": {
						"caption": "$Resources.Strings.LineHeightCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "LineHeightPropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper", "line-properties-layout"]
				}
			},
			{
				"operation": "insert",
				"name": "LetterSpacing",
				"parentName": "LineHeightPropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$LetterSpacing",
					"markerValue": "LetterSpacing",
					"wrapClass": ["style-input"],
					"visible": "$UseLetterSpacing",
					"labelConfig": {
						"caption": "$Resources.Strings.LetterSpacingCaption"
					}
				}
			},
			{
				"operation": "insert",
				"name": "FontColorSymbolSpaceContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["symbol-space-container", "control-width-15"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ColorLabel",
				"parentName": "FontColorSymbolSpaceContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"labelClass": ["color-label"]
					},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"markerValue": "ColorLabel",
					"caption": "$Resources.Strings.ColorLabelCaption"
				}
			},
			{
				"operation": "insert",
				"name": "Color",
				"parentName": "FontColorSymbolSpaceContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.COLOR_BUTTON,
					"value": "$Color",
					"defaultValue": "#000001",
					"menuItemClassName": BPMSoft.MenuItemType.COLOR_PICKER
				}
			}
		]
	};
});
