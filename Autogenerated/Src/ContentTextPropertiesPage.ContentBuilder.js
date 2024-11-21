define("ContentTextPropertiesPage", ["css!ContentItemStylesPageCSS"], function() {
	return {
		attributes: {

			/**
			 * Text line height.
			 */
			LineHeight: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onLineHeightChanged"
			},

			/**
			 * Text element width.
			 */
			Width: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onTextWidthChanged"
			},

			/**
			 * Text element height.
			 */
			Height: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onTextHeightChanged"
			},

			/**
			 * Text element align in block.
			 */
			Align: {
				dataValueType: BPMSoft.core.enums.DataValueType.STRING,
				type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
				value: BPMSoft.Align.LEFT,
				onChange: "_onAlignChanged"
			}

		},
		properties: {
			workStyles: ["height", "width", "line-height"]
		},
		methods: {

			// region Methods: Private

			/**
			 * @private
			 */
			_onLineHeightChanged: function(model, lineHeight) {
				if (this.isChanged(this.$Config.Styles["line-height"] + "px", this.$LineHeight)) {
					if (lineHeight) {
						Ext.apply(this.$Config.Styles, {
							"line-height": lineHeight + "px"
						});
					} else {
						delete this.$Config.Styles["line-height"];
					}
					this.save();
				}
			},

			/**
			 * @private
			 */
			_onTextWidthChanged: function(model, width) {
				if (this.isChanged(this.$Config.Styles.width + "px", this.$Width)) {
					if (!Ext.isEmpty(width)) {
						Ext.apply(this.$Config.Styles, {
							"width": width + "px"
						});
					} else {
						delete this.$Config.Styles.width;
					}
					this.save();
				}
			},

			/**
			 * @private
			 */
			_onTextHeightChanged: function(model, height) {
				if (this.isChanged(this.$Config.Styles.height + "px", this.$Height)) {
					if (!Ext.isEmpty(height)) {
						Ext.apply(this.$Config.Styles, {
							"height": height + "px"
						});
					} else {
						delete this.$Config.Styles.height;
					}
					this.save();
				}
			},

			/**
			 * @private
			 */
			_onAlignChanged: function(model, align) {
				this.$Config.Align = align;
				this.save();
			},

			//endregion

			// region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @override
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("LineHeight", this.positiveNumberValidator);
				this.addColumnValidator("Width", this.positiveNumberValidator);
				this.addColumnValidator("Height", this.positiveNumberValidator);
			},

			/**
			 * @inheritdoc ContentItemPropertiesPage#onContentItemConfigChanged
			 * @overridden
			 */
			onContentItemConfigChanged: function(config) {
				if (config) {
					config.Styles = config.Styles || {};
					this.$LineHeight = config.Styles["line-height"]
						? parseFloat(config.Styles["line-height"])
						: BPMSoft.emptyString;
					this.$Width = config.Styles.width ? parseFloat(config.Styles.width) : BPMSoft.emptyString;
					this.$Height = config.Styles.height ? parseFloat(config.Styles.height) : BPMSoft.emptyString;
					this.$Align = this.$Config.Align;
				}
			}

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"name": "ContentTextPropertiesContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["content-styles-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"name": "TextSizeGroup",
				"parentName": "ContentTextPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.TextOptionsCaption"
				},
				"index": 1
			},
			{
				"operation": "insert",
				"parentName": "TextSizeGroup",
				"name": "LineHeightGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "LineHeightGroup",
				"propertyName": "items",
				"name": "LineHeight",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$LineHeight",
					"wrapClass": ["style-input", "line-height-input"],
					"controlConfig": {"placeholder": "$Resources.Strings.PlaceholderAutoText"},
					"labelConfig": {
						"caption": "$Resources.Strings.LineHeightCaption"
					},
					"classes": {"wrapClassName": ["show-placeholder"]},
					"markerValue": "LineHeight"
				}
			},
			{
				"operation": "insert",
				"parentName": "TextSizeGroup",
				"name": "TextSizeGroupContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper"]
				}
			},
			{
				"operation": "insert",
				"parentName": "TextSizeGroupContainer",
				"propertyName": "items",
				"name": "Width",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"wrapClass": ["style-input"],
					"controlConfig": {"placeholder": "$Resources.Strings.PlaceholderAutoText"},
					"labelConfig": {
						"caption": "$Resources.Strings.TextElementWidth"
					},
					"classes": {"wrapClassName": ["show-placeholder"]},
					"markerValue": "TextWidth"
				}
			},
			{
				"operation": "insert",
				"parentName": "TextSizeGroupContainer",
				"propertyName": "items",
				"name": "Height",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"wrapClass": ["style-input"],
					"controlConfig": {"placeholder": "$Resources.Strings.PlaceholderAutoText"},
					"labelConfig": {
						"caption": "$Resources.Strings.TextElementHeight"
					},
					"classes": {"wrapClassName": ["show-placeholder"]},
					"markerValue": "TextHeight"
				}
			},
			{
				"operation": "insert",
				"name": "AlignGroup",
				"parentName": "ContentTextPropertiesContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"caption": "$Resources.Strings.TextElementAlign"
				}
			},
			{
				"operation": "insert",
				"name": "AlignContainer",
				"parentName": "AlignGroup",
				"propertyName": "items",
				"values": {
					"markerValue": "AlignContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["content-builder-align-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Align",
				"parentName": "AlignContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"wrapClass": ["sheet-position-control-group-container"],
					"items": [],
					"value": "$Align"
				}
			},
			{
				"operation": "insert",
				"name": "LeftAlign",
				"parentName": "Align",
				"propertyName": "items",
				"values": {
					"labelConfig": {"visible": false},
					"markerValue": "Left",
					"value": BPMSoft.Align.LEFT,
					"classes": {
						"wrapClass": ["sheet-align sheet-align-left"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "CenterAlign",
				"parentName": "Align",
				"propertyName": "items",
				"values": {
					"labelConfig": {"visible": false},
					"markerValue": "Center",
					"value": BPMSoft.Align.CENTER,
					"classes": {
						"wrapClass": ["sheet-align sheet-align-center"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "RightAlign",
				"parentName": "Align",
				"propertyName": "items",
				"values": {
					"labelConfig": {"visible": false},
					"markerValue": "Right",
					"value": BPMSoft.Align.RIGHT,
					"classes": {
						"wrapClass": ["sheet-align sheet-align-right"]
					}
				}
			}
		]
	};
});
