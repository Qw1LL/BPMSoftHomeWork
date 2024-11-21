define("RestWebServiceMethodPage", [ "RestWebServiceMethodPageResources"
], function(resources) {
	return {
		attributes: {

			/**
			 * Request Content Type.
			 */
			"Content": {
				"dataValueType": BPMSoft.DataValueType.ENUM,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"value": "JSON"
			},

			/**
			 * Full Request URI.
			 */
			"FullUri": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Can open Uri request builder.
			 */
			"CanOpenUriRequestBuilder": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			}
		},
		methods: {

			//region Private

			/**
			 * Update FullUri attribute to display.
			 * @param uri
			 * @private
			 */
			_updateFullUri: function(uri) {
				const baseUri = this.$ServiceSchema.baseUri;
				this.$FullUri = uri === null ? baseUri : baseUri + this._appendQueryParameters(uri);
			},

			/**
			 * @private
			 */
			_hasNewUriParameters: function() {
				const parameterNames = this._getNewUriParametersNames();
				return parameterNames.length > 0;
			},

			/**
			 * @private
			 */
			_getNewUriParametersNames: function() {
				const uriParametersNames = this._getUriParametersNames();
				const serviceParameterTypeEnum = BPMSoft.services.enums.ServiceParameterType;
				const queryParameters = this._findParametersByType(serviceParameterTypeEnum.QUERY_STRING);
				const urlSegments = this._findParametersByType(serviceParameterTypeEnum.URL_SEGMENT);
				const urlSegmentsDifference = _.difference(uriParametersNames.uri,
					_.pluck(urlSegments.getItems(), "path"));
				const queryParametersDifference = _.difference(uriParametersNames.query,
					_.pluck(queryParameters.getItems(), "path"));
				return urlSegmentsDifference.concat(queryParametersDifference);
			},

			/**
			 * @private
			 */
			_getUriParametersNames: function() {
				const uriParametersJson = this._getUriParametersJson();
				return {
					uri: _.keys(uriParametersJson.request.uri),
					query: _.keys(uriParametersJson.request.query)
				};
			},

			/**
			 * @private
			 */
			_hasUriParameters: function() {
				const uriParametersNames = this._getUriParametersNames();
				var allUriParametersNames = uriParametersNames.uri.concat(uriParametersNames.query);
				return allUriParametersNames.length > 0;
			},

			/**
			 * @private
			 */
			_getUriParametersJson: function() {
				const uriConverter = new BPMSoft.UriJsonConverter();
				return uriConverter.convert(this.$Uri);
			},

			/**
			 * @private
			 */
			_findParametersByType: function(parametersType) {
				return this.$Parameters.filterByPath("type", parametersType);
			},

			/**
			 * @private
			 */
			_appendQueryParameters: function(uri) {
				if (!uri) {
					uri = this.$Uri || "";
				}
				const defaultValue = this.get("Resources.Strings.DefaultParameterValue");
				const queryPart = this._findParametersByType(BPMSoft.services.enums.ServiceParameterType.QUERY_STRING)
					.map(function(parameter) {
						if (!Ext.isEmpty(parameter.defValue.value)) {
							const defValue = BPMSoft.ServiceDesignerUtilities.getFormattedValue(parameter.defValue,
								parameter.dataValueTypeName);
							return parameter.path + "=" + (parameter.defValue.source ===
							BPMSoft.services.enums.ServiceParameterValueSource.CONST
								? defValue
								: "{" + defValue + "}");
						} else {
							return Ext.String.format("{0}={{1}}", parameter.path, defaultValue);
						}
					})
					.getItems()
					.join("&");
				return uri + (queryPart ? "?" + queryPart : queryPart);
			},

			/**
			 * @private
			 */
			_updateCanOpenUriRequestBuilderAttribute: function() {
				this.$CanOpenUriRequestBuilder = this.$Uri && this._hasNewUriParameters();
			},

			/**
			 * @private
			 */
			_updateMethodUri: function(uri) {
				uri = uri.trim();
				var domain = BPMSoft.getUrlDomain(uri);
				if (Ext.isEmpty(this.$ServiceSchema.baseUri) && domain) {
					this.$ServiceSchema.setPropertyValue("baseUri", domain);
				}
				if (domain) {
					uri = uri.replace(domain, "");
				}
				BPMSoft.defer(function() {
					this.$Uri = uri;
				}, this);
			},

			//endregion

			//region Protected

			/**
			 * @inheritdoc BPMSoft.WebServiceMethotPage#onUriAttributeChange.
			 * @overridden
			 */
			onUriAttributeChange: function(model, value) {
				this._updateFullUri(value);
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.WebServiceMethotPage#onAddRequestParameter.
			 * @overridden
			 */
			onAddRequestParameter: function() {
				this.callParent(arguments);
				this._updateCanOpenUriRequestBuilderAttribute();
				this._updateFullUri();
			},

			/**
			 * @inheritdoc BPMSoft.WebServiceMethotPage#initMethodParameters.
			 * @overridden
			 */
			initMethodParameters: function() {
				this.callParent(arguments);
				if (this.$Method.request.uri) {
					this._updateFullUri(this.$Method.request.uri);
				}
			},

			/**
			 * @inheritdoc BPMSoft.WebServiceMethotPage#onLoadCanEditSchema.
			 * @overridden
			 */
			onLoadCanEditSchema: function() {
				this._updateCanOpenUriRequestBuilderAttribute();
			},

			/**
			 * @inheritdoc BPMSoft.WebServiceMethotPage#onSchemaChanged.
			 * @overridden
			 */
			onSchemaChanged: function(changes) {
				this.callParent(arguments);
				if (changes.uri) {
					this._updateMethodUri(changes.uri);
				}
				this._updateFullUri();
				this._updateCanOpenUriRequestBuilderAttribute();
			},

			/**
			 * @inheritdoc BPMSoft.WebServiceMethotPage#validateUri.
			 * @overridden
			 */
			validateUri: function(callback, scope) {
				if (this._hasNewUriParameters()) {
					var parameterNames = this._getNewUriParametersNames();
					var confirmationMessage;
					var template = this.get("Resources.Strings.WrongUriMessage");
					if (parameterNames.length === 1) {
						confirmationMessage = this.Ext.String.format(template, parameterNames[0]);
					}
					if (parameterNames.length > 1) {
						template = this.get("Resources.Strings.WrongUrisMessage");
						confirmationMessage = this.Ext.String.format(template, parameterNames.join(", "));
					}
					this.showConfirmationDialog(confirmationMessage,
						function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
								this.openUriRequestBuilder();
							}
							callback.call(scope, false);
						}, ["yes", "no"]);
				} else {
					callback.call(scope, true);
				}
			},

			//endregion

			//region Public

			/**
			 * Quick setup from cURL button handler.
			 */
			openCurlRequestBuilder: function() {
				this._showQuickSetupWindow("CurlRequestBuilder");
			},

			/**
			 * Quick setup request from Raw button handler.
			 */
			openRawRequestBuilder: function() {
				this._showQuickSetupWindow("RawRequestBuilder");
			},

			/**
			 * Quick setup response from Raw button handler.
			 */
			openRawResponseBuilder: function() {
				this._showQuickSetupWindow("RawResponseBuilder");
			},

			/**
			 * Quick setup Request from JSON button handler.
			 */
			openJsonRequestBuilder: function() {
				this._showQuickSetupWindow("JsonRequestBuilder");
			},

			/**
			 * Quick setup Response from JSON button handler.
			 */
			openJsonResponseBuilder: function() {
				this._showQuickSetupWindow("JsonResponseBuilder");
			},

			/**
			 * Open uri request builder handler in quick setup.
			 */
			onQuickSetupUriRequestBuilderClick: function() {
				if (this.$Uri && this._hasUriParameters()) {
					this.openUriRequestBuilder();
				} else {
					this.showInformationDialog(this.get("Resources.Strings.QuickSetupEmptyUriMessage"));
				}
			},

			/**
			 * Open uri request builder handler.
			 */
			openUriRequestBuilder: function() {
				this._showQuickSetupWindow("UriRequestBuilder", this.$Uri);
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "HttpMethodType",
				"values": {
					"layout": {"column": 15, "row": 0, "colSpan": 9},
					"bindTo": "HttpMethodType",
					"dataValueType": BPMSoft.DataValueType.ENUM,
					"caption": {"bindTo": "Resources.Strings.HttpMethodTypeCaption"},
					"controlConfig": {
						"className": "BPMSoft.ComboBoxEdit",
						"prepareList": {"bindTo": "_prepareMethodTypeList"}
					},
					"enabled": {
						"bindTo": "CanEditSchema"
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Content",
				"values": {
					"layout": {"column": 15, "row": 1, "colSpan": 9},
					"bindTo": "Content",
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"caption": {"bindTo": "Resources.Strings.ContentTypeCaption"},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "UseAuthInfo",
				"values": {
					"contentType": BPMSoft.ContentType.LONG_TEXT,
					"layout": {"column": 15, "row": 3, "colSpan": 9},
					"bindTo": "UseAuthInfo",
					"caption": {"bindTo": "Resources.Strings.UseAuthInfoCaption"},
					"enabled": "$CanChangeUseAuthInfo"
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Uri",
				"values": {
					"layout": {"column": 0, "row": 2, "colSpan": 14},
					"bindTo": "Uri",
					"caption": {"bindTo": "Resources.Strings.UriCaption"},
					"enabled": {
						"bindTo": "CanEditSchema"
					},
					"tip": {"content": "$Resources.Strings.AddressHint"},
					"controlConfig": {
						"rightIconClick": "$openUriRequestBuilder",
						"enableRightIcon": "$CanOpenUriRequestBuilder",
						"rightIconConfig": {
							"source": BPMSoft.ImageSources.URL,
							"url": BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.WizardIcon)
						},
						"rightIconClasses": ["open-web-service-method-builder-right-icon"]
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "RequestTimeout",
				"values": {
					"layout": {"column": 15, "row": 2, "colSpan": 9},
					"bindTo": "RequestTimeout",
					"caption": {"bindTo": "Resources.Strings.RequestTimeoutCaption"},
					"enabled": {
						"bindTo": "CanEditSchema"
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "FullUri",
				"values": {
					"contentType": BPMSoft.ContentType.LONG_TEXT,
					"layout": {"column": 0, "row": 3, "colSpan": 14},
					"bindTo": "FullUri",
					"caption": {"bindTo": "Resources.Strings.FullUriCaption"},
					"enabled": false
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				operation: "insert",
				name: "QuickSetupButton",
				parentName: "ActionContainer",
				propertyName: "items",
				index: 2,
				values: {
					itemType: BPMSoft.ViewItemType.BUTTON,
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					caption: {bindTo: "Resources.Strings.QuickSetupButtonCaption"},
					imageConfig: {bindTo: "Resources.Images.WizardIcon"},
					classes: {
						wrapperClass: ["quick-setup-button", "actions-button-margin-right"]
					},
					menu: {
						items: [
							{
								caption: "$Resources.Strings.RequestExampleSeparatorCaption",
								className: "BPMSoft.MenuSeparator"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupCurlButtonCaption"},
								click: "$openCurlRequestBuilder",
								markerValue: "CurlRequestBuilder"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupRawRequestButtonCaption"},
								click: "$openRawRequestBuilder",
								markerValue: "RawRequestBuilder"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupJsonRequestButtonCaption"},
								click: "$openJsonRequestBuilder",
								markerValue: "JsonRequestBuilder"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupUriButtonCaption"},
								click: "$onQuickSetupUriRequestBuilderClick",
								markerValue: "UriRequestBuilder"
							},
							{
								caption: "$Resources.Strings.ResponseExampleSeparatorCaption",
								className: "BPMSoft.MenuSeparator"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupRawResponseButtonCaption"},
								click: "$openRawResponseBuilder",
								markerValue: "RawResponseBuilder"
							},
							{
								caption: {bindTo: "Resources.Strings.QuickSetupJsonResponseButtonCaption"},
								click: "$openJsonResponseBuilder",
								markerValue: "JsonResponseBuilder"
							}
						]
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/
	};
});
