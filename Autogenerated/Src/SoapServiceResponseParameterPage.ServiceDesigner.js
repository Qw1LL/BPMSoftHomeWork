define("SoapServiceResponseParameterPage", ["ServiceEnums"], function() {
	return {
		modules: {
		},
		attributes: {
			/**
			 * Sequence element name.
			 */
			"SequenceElementName": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#getPathPlaceholder
			 * @override
			 */
			getPathPlaceholder: function() {
				if (this.$ParameterType === BPMSoft.services.enums.ServiceParameterType.BODY) {
					return "";
				}
				return this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#getTrackedAttributes
			 * @override
			 */
			getTrackedAttributes: function() {
				const attributes = this.callParent(arguments);
				attributes.push("SequenceElementName");
				return attributes;
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#getAttributeMap
			 * @override
			 */
			getAttributeMap: function() {
				const attributeMap = this.callParent(arguments);
				return Ext.apply(attributeMap, {
					sequenceElementName: "SequenceElementName",
				});
			},

			/**
			 * Returns true if sequence item type allowed for parameter.
			 */
			isSequenceElementNameVisible: function() {
				return this.$Schema && 
					this.$IsArray && 
					this.$DataValueTypeName === BPMSoft.services.enums.DataValueTypeName.Object;
			},

			//endregion

		},
		diff: [
			{
				"operation": "insert",
				"parentName": "ParameterEditContainer",
				"propertyName": "items",
				"name": "SequenceElementName",
				"index": 6,
				"values": {
					"layout": {"column": 0, "row": 3, "colSpan": 8},
					"bindTo": "SequenceElementName",
					"caption": "$Resources.Strings.SequenceElementNameCaption",
					"enabled": "$CanEditSchema",
					"classes": {"wrapClassName": ["grid-layout-row"]},
					"visible": {"bindTo": "isSequenceElementNameVisible"},
					"tip": {"content": {"bindTo":"Resources.Strings.SequenceObjectElementNameTip"}}
				}
			},
		]
	};
});
