define("AlignPropertyModule", function() {
	return {
		attributes: {
			/**
			 * Align property value.
			 */
			Align: {
				dataValueType: BPMSoft.core.enums.DataValueType.STRING,
				type: BPMSoft.core.enums.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "save"
			}
		},
		properties: {
			/**
			 * Array of applicable style attributes.
			 */
			workStyles: ["text-align"]
		},
		methods: {
			/**
			 * @private
			 */
			_initAlign: function() {
				var propertyValue = this.$Config[this.$PropertyName];
				var value = Ext.isObject(propertyValue) ? propertyValue["text-align"] : propertyValue;
				this.$Align = value || BPMSoft.Align.CENTER;
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#getPropertyValue
			 * @override
			 */
			getPropertyValue: function() {
				return Ext.isObject(this.$Config[this.$PropertyName])
					? { "text-align": this.$Align }
					: this.$Align;
			},

			/**
			 * @inheritdoc BaseStylePropertyModule#init
			 * @override
			 */
			initProperty: function() {
				this.callParent();
				this._initAlign();
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "Align",
				"propertyName": "items",
				"values": {
					"generateId": false,
					"itemType": BPMSoft.ViewItemType.RADIO_GROUP,
					"value": "$Align",
					"markerValue": "Align",
					"wrapClass": ["sheet-position-control-group-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "LeftAlign",
				"parentName": "Align",
				"propertyName": "items",
				"values": {
					"generateId": false,
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
					"generateId": false,
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
					"generateId": false,
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
