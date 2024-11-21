define("ContentMjDividerPropertiesPage", ["ContentMjDividerPropertiesPageResources",
		"css!ContentMjDividerPropertiesPageCSS"], function(resources) {
	return {
		attributes: {
			/**
			 * Divider width.
			 */
			Width: {
				dataValueType: BPMSoft.DataValueType.FLOAT,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onWidthChanged"
			}
		},
		properties: {
			defaults: {
				/**
				 * Max width size for divider (%).
				 * @type {Number}
				 */
				maxWidth: 100,
				/**
				 * Min width size for divider (%).
				 * @type {Number}
				 */
				minWidth: 0
			}
		},
		methods: {

			/**
			 * @private
			 */
			_onWidthChanged: function() {
				if (this.validateColumn("Width")) {
					Ext.apply(this.$Config, {
						Width: this.$Width ? this.$Width + "%" : BPMSoft.emptyString
					});
					this.save();
				}
			},

			/**
			 * Validates input width value, if the validation has passed, sets width of divider.
			 * @protected
			 * @param {Number} value Divider Width.
			 * @return {Object} Validation result.
			 */
			widthRangeValidator: function(value) {
				var invalidMessage = "";
				if ((value > this.defaults.maxWidth) || (value < this.defaults.minWidth)) {
					invalidMessage = Ext.String.format(resources.localizableStrings.MaxWidthLimitExceptionText,
						this.defaults.minWidth, this.defaults.maxWidth);
				}
				if (value === this.defaults.minWidth) {
					invalidMessage = resources.localizableStrings.ZeroWidthLimitExceptionText;
				}
				return {
					fullInvalidMessage: invalidMessage,
					invalidMessage: invalidMessage
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("Width", this.widthRangeValidator);
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @override
			 */
			onContentItemConfigChanged: function(config) {
				this.callParent(arguments);
				if (config) {
					this.$Width = config.Width ? parseFloat(config.Width) : BPMSoft.emptyString;
				}
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "SizeGroup",
				"parentName": "SeparatorSettingsControlGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.SizeGroupCaption",
					"wrapClass": ["divider-width-wrap"]
				},
				"index": 0
			},
			{
				"operation": "insert",
				"parentName": "SizeGroup",
				"name": "SizeGroupContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "SizeGroupContainer",
				"propertyName": "items",
				"name": "Width",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"wrapClass": ["style-input"],
					"controlConfig": {"placeholder": "$Resources.Strings.PlaceholderAutoText"},
					"labelConfig": {
						"caption": "$Resources.Strings.DividerElementWidthCaption"
					},
					"classes": {"wrapClassName": ["show-placeholder"]},
					"markerValue": "DividerWidth"
				}
			}
		]
	};
});
