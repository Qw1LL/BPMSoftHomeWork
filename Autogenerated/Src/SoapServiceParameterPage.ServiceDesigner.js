define("SoapServiceParameterPage", ["ServiceEnums"], function() {
	return {
		mixins: {},
		messages: {},
		properties: {},
		modules: {},
		attributes: {
			/**
			 * Sequence element name.
			 */
			"SequenceElementName": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		methods: {

			//region Methods: Protected

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
			 * @inheritdoc BPMSoft.ServiceParameterPage#onIsArrayChange
			 * @override
			 */
			onIsArrayChange: function() {
				if (!this.$IsArray) {
					this.$SequenceElementName = "item";
				}
				this.callParent(arguments);
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
			 * @inheritdoc BPMSoft.ServiceParameterPage#getPathPlaceholder
			 * @override
			 */
			getPathPlaceholder: function() {
				if (this.$ParameterType === BPMSoft.services.enums.ServiceParameterType.BODY) {
					return "";
				}
				return this.callParent(arguments);
			},

			getAvailableServiceParameterTypes: function() {
				return [
					BPMSoft.services.enums.ServiceParameterType.BODY,
					BPMSoft.services.enums.ServiceParameterType.HTTP_HEADER,
					BPMSoft.services.enums.ServiceParameterType.COOKIE
				];
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns true if sequence item type allowed for parameter.
			 */
			isSequenceElementNameVisible: function() {
				return this.$Schema && this.$IsArray;
			},

			/**
			 * Returns hint for sequence element name.
			 * @public
			 * @return {String} sequence element name hint.
			 */
			getSequenceElementNameHint: function() {
				switch (this.$DataValueTypeName) {
					case BPMSoft.services.enums.DataValueTypeName.Object:
						return this.get("Resources.Strings.SequenceObjectElementNameTip");
					default:
						return this.get("Resources.Strings.SequenceElementNameTip");
				}
			},

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
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
					"controlConfig": {
						"markerValue": "ParameterSequenceElementNameMarker"
					},
					"visible": {"bindTo": "isSequenceElementNameVisible"},
					"enabled": "$CanEditSchema",
					"classes": {"wrapClassName": ["grid-layout-row"]},
					"tip": {"content": "$getSequenceElementNameHint"}
				}
			},
		]/**SCHEMA_DIFF*/
	};
});
