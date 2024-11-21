define("PaddingPropertyModule", function() {
	return {
		attributes: {
			/**
			 * Padding left.
			 */
			PaddingLeft: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0,
				onChange: "save"
			},

			/**
			 * Padding top.
			 */
			PaddingTop: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0,
				onChange: "save"
			},

			/**
			 * Padding right.
			 */
			PaddingRight: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0,
				onChange: "save"
			},

			/**
			 * Padding bottom.
			 */
			PaddingBottom: {
				dataValueType: BPMSoft.DataValueType.INTEGER,
				value: 0,
				onChange: "save"
			}
		},
		properties: {
			/**
			 * Array of applicable style attributes.
			 */
			workStyles: ["padding-top","padding-bottom","padding-left","padding-right"]
		},
		methods: {
			/**
			 * @private
			 */
			_initPadding: function() {
				var styles = this.$Config[this.$PropertyName];
				this.$PaddingLeft = this.getPaddingValue(parseFloat(styles["padding-left"]));
				this.$PaddingTop = this.getPaddingValue(parseFloat(styles["padding-top"]));
				this.$PaddingRight = this.getPaddingValue(parseFloat(styles["padding-right"]));
				this.$PaddingBottom = this.getPaddingValue(parseFloat(styles["padding-bottom"]));
			},

			/**
			 * Validates positive numbers.
			 * @param {Number} value Value.
			 * @return {Object} Validation info.
			 */
			positiveNumberValidator: function(value) {
				return BPMSoft.validateNumberRange(0, BPMSoft.DataValueTypeRange.INTEGER.maxValue, value);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @overridden
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.addColumnValidator("PaddingTop", this.positiveNumberValidator);
				this.addColumnValidator("PaddingBottom", this.positiveNumberValidator);
				this.addColumnValidator("PaddingLeft", this.positiveNumberValidator);
				this.addColumnValidator("PaddingRight", this.positiveNumberValidator);
			},

			/**
			 * Gets only valid padding value.
			 * @param {Number} value Value.
			 * @return {Number} Valid padding value.
			 */
			getPaddingValue: function(value) {
				return (value && value > 0) ? value : 0;
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#getPropertyValue
			 * @override
			 */
			getPropertyValue: function() {
				return {
					"padding-left": this.getPaddingValue(this.$PaddingLeft) + "px",
					"padding-top": this.getPaddingValue(this.$PaddingTop) + "px",
					"padding-right": this.getPaddingValue(this.$PaddingRight) + "px",
					"padding-bottom": this.getPaddingValue(this.$PaddingBottom) + "px"
				};
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#init
			 * @override
			 */
			initProperty: function() {
				this.callParent();
				this._initPadding();
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "PaddingPropertiesLayout",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"wrapClass": ["control-editor-wrapper", "padding-properties-layout"]
				}
			},
			{
				"operation": "insert",
				"parentName": "PaddingPropertiesLayout",
				"propertyName": "items",
				"name": "PaddingTop",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$PaddingTop",
					"markerValue": "PaddingTop",
					"wrapClass": ["style-input"],
					"labelConfig": {
						"caption": "$Resources.Strings.PaddingTopCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "PaddingPropertiesLayout",
				"propertyName": "items",
				"name": "PaddingRight",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$PaddingRight",
					"markerValue": "PaddingRight",
					"wrapClass": ["style-input"],
					"labelConfig": {
						"caption": "$Resources.Strings.PaddingRightCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "PaddingPropertiesLayout",
				"propertyName": "items",
				"name": "PaddingBottom",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$PaddingBottom",
					"markerValue": "PaddingBottom",
					"wrapClass": ["style-input"],
					"labelConfig": {
						"caption": "$Resources.Strings.PaddingBottomCaption"
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "PaddingPropertiesLayout",
				"propertyName": "items",
				"name": "PaddingLeft",
				"values": {
					"itemType": BPMSoft.ViewItemType.TEXT,
					"value": "$PaddingLeft",
					"markerValue": "PaddingLeft",
					"wrapClass": ["style-input"],
					"labelConfig": {
						"caption": "$Resources.Strings.PaddingLeftCaption"
					}
				}
			}
		]
	};
});
