define("ParametrizedServiceMethodBuilder", ["JsonServiceMetaDataConverter", "ServiceEnums"], function() {
	return {
		attributes: {

			/**
			 * Indicates if response parameters can be set up.
			 */
			SetupResponseParameters: { value: false },

			/**
			 * Indicates if method type can be set up.
			 */
			SetupMethodType: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Parsed method uri.
			 */
			ParsedMethodUri: {
				dataValueType: BPMSoft.DataValueType.TEXT,
				onChange: "_onParsedMethodUriChanged"
			},

			/**
			 * Parsed method request type.
			 */
			ParsedMethodType: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				onChange: "_onParsedMethodTypeChanged"
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_onParsedMethodUriChanged: function() {
				if (this.$ParsedMethod) {
					var request = this.$ParsedMethod.getPropertyValue("request");
					request.setPropertyValue("uri", this.$ParsedMethodUri);
				}
			},

			/**
			 * @private
			 */
			_onParsedMethodTypeChanged: function() {
				if (this.$ParsedMethod) {
					var request = this.$ParsedMethod.getPropertyValue("request");
					request.setPropertyValue("httpMethodType", this.$ParsedMethodType && this.$ParsedMethodType.value);
				}
			},

			/**
			 * Fill HTTP method type list.
			 * @private
			 * @param {String} filter The filter string.
			 * @param {BPMSoft.Collection} list The list.
			 */
			_prepareMethodTypeList: function(filter, list) {
				if (list === null) {
					return;
				}
				var result = {};
				BPMSoft.each(BPMSoft.services.enums.HttpMethodType, function(key, type) {
					if (type !== "UNDEFINED") {
						result[key] = {value: key, displayValue: type};
					}
				}, this);
				list.reloadAll(result);
			},

			/**
			 * @private
			 */
			_getAuthTypeName: function() {
				if (this.$ParsedMethod && this.$ParsedMethod.useAuthInfo) {
					const serviceSchema = this.$ParsedMethod.getServiceSchema();
					return this._getAuthTypeLookupDisplayValue(serviceSchema.authInfo.authType);
				}
			},

			/**
			 * @private
			 */
			_getAuthTypeLookupDisplayValue: function(dataValueTypeName) {
				return BPMSoft.services.enums.AuthTypeCaption[dataValueTypeName];
			},

			//endregion

			//region Methods: Protected

			/**
			 * @protected
			 */
			prepareUri: function(method) {
				this.$ParsedMethodUri = method.request.uri;
				delete this.changedValues.ParsedMethodUri;
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns if method use AuthInfo.
			 */
			useAuth: function() {
				return Boolean(this.$ParsedMethod && this.$ParsedMethod.useAuthInfo);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "MethodSetupGridLayoutContainer",
				"parentName": "MethodSetupContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MethodSetupGridLayout",
				"parentName": "MethodSetupGridLayoutContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"collapseEmptyRow": true
				}
			},
			{
				"operation": "insert",
				"name": "MethodPropertiesCaption",
				"parentName": "MethodSetupGridLayout",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 0, "colSpan": 24},
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": "$Resources.Strings.MethodPropertiesCaption",
					"classes": { "labelClass": ["service-method-builder-caption-16"] }
				}
			},
			{
				"operation": "insert",
				"name": "MethodUri",
				"parentName": "MethodSetupGridLayout",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 24},
					"bindTo": "ParsedMethodUri",
					"caption": "$Resources.Strings.MethodUri",
					"classes": {"labelClass": ["service-method-builder-text-align-right"]}
				}
			},
			{
				"operation": "insert",
				"name": "ParsedMethodType",
				"parentName": "MethodSetupGridLayout",
				"propertyName": "items",
				"values": {
					"layout": { "column": 0, "row": 2, "colSpan": 11},
					"bindTo": "ParsedMethodType",
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"caption": "$Resources.Strings.MethodRequestType",
					"classes": {"labelClass": ["service-method-builder-text-align-right"]},
					"visible": "$SetupMethodType",
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"enabled": false,
						"prepareList": "$_prepareMethodTypeList"
					}
				}
			},
			{
				"operation": "insert",
				"name": "UseAuthInfo",
				"parentName": "MethodSetupGridLayout",
				"propertyName": "items",
				"values": {
					"layout": {"column": 0, "row": 3, "colSpan": 11},
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"bindTo": "_getAuthTypeName",
					"caption": "$Resources.Strings.AuthenticationCaption",
					"enabled": false,
					"classes": {"labelClass": ["service-method-builder-text-align-right"]},
					"visible": "$useAuth"
				}
			}

		]/**SCHEMA_DIFF*/
	};
});
