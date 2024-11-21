define("ServiceResponseParameterPage", ["ServiceEnums"], function() {
	return {
		modules: {
			ServiceResponseParameterDefValue: {
				moduleId: "ServiceResponseParameterDefValue",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "ServiceResponseParameterValuePage",
					parameters: {
						viewModelConfig: {
							serviceUId: {
								attributeValue: "ServiceSchemaUId"
							},
							methodUId: {
								attributeValue: "MethodUId"
							},
							findParameterMethodName: {
								getValueMethod: "getFindParameterMethodName"
							},
							CanEditSchema: {
								attributeValue: "CanEditSchema"
							}
						}
					},
					useHistoryState: false
				}
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Validates if DataType is valid for ParameterType.
			 * @param {Number} [parameterTypeId].
			 * @return {Boolean} Is parameter allowed.
			 * @private
			 */
			_isParameterTypeAllowedForResponsePage: function(parameterTypeId) {
				return parameterTypeId === BPMSoft.services.enums.ServiceParameterType.BODY ||
					parameterTypeId === BPMSoft.services.enums.ServiceParameterType.HTTP_HEADER ||
					parameterTypeId === BPMSoft.services.enums.ServiceParameterType.COOKIE;
			},

			/**
			 * Validates if DataType is valid for ParameterType.
			 * @param {String} dataValueTypeName.
			 * @return {Boolean} Is parameter allowed.
			 * @private
			 */
			_isDataValueTypeNameAllowed: function(dataValueTypeName) {
				return dataValueTypeName !== BPMSoft.services.enums.DataValueTypeName.Object ||
						this.$ParameterType === BPMSoft.services.enums.ServiceParameterType.BODY;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#getMethodParameters
			 * @override
			 */
			getMethodParameters: function(method) {
				return method.response.parameters;
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#prepareParameterTypeList
			 * @override
			 */
			prepareParameterTypeList: function(filter, list) {
				var result = {};
				BPMSoft.each(BPMSoft.services.enums.ServiceParameterType, function(key) {
					if (BPMSoft.services.enums.ServiceParameterTypeCaption[key] &&
					this._isParameterTypeAllowedForResponsePage(key)) {
						result[key] = {
							value: key,
							displayValue: BPMSoft.services.enums.ServiceParameterTypeCaption[key]
						};
					}
				}, this);
				list.reloadAll(result);
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#setDataTypeVisible
			 * @override
			 */
			setDataTypeVisible: function() {
				if (this.getIsFeatureEnabled("VariableResponseCookieDataType") || BPMSoft.isDebug) {
					this.$IsDataTypeVisible = true;
				} else {
					if (this.$ParameterType === BPMSoft.services.enums.ServiceParameterType.BODY) {
						this.$IsDataTypeVisible = true;
					} else {
						this.$IsDataTypeVisible = false;
						this.$DataValueTypeName = BPMSoft.services.enums.DataValueTypeName.Text;
					}
				}
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#parameterTypeValidator
			 * @override
			 */
			parameterTypeValidator: function() {
				var message = "";
				return {invalidMessage: message};
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#getParameterEditPageTag
			 * @override
			 */
			getParameterEditPageTag: function() {
				return "ResponseParameterEditPage";
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#getParameterGridTag
			 * @override
			 */
			getParameterGridTag: function() {
				return "ServiceResponseParameterGrid";
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#getFindParameterMethodName
			 * @override
			 */
			getFindParameterMethodName: function() {
				return "findResponseParameterByUId";
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#getFindParameterMethodName
			 * @override
			 */
			getParameterValuePageTag: function() {
				return "ServiceResponseParameterDefValue";
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#setDataTypeEnabled
			 * @override
			 */
			setDataTypeEnabled: function() {
				var hasNestedParameters = this._hasNestedParameters();
				this.$IsDataTypeEnabled = !hasNestedParameters && this.$CanEditSchema;
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#setDefaultDataType
			 * @override
			 */
			setDefaultDataType: function(model) {
				if (this.getPrevious("ParameterType") === BPMSoft.services.enums.ServiceParameterType.BODY &&
					this.$DataValueTypeName === BPMSoft.services.enums.DataValueTypeName.Object) {
					this._onDataTypeChange(model, BPMSoft.services.enums.DataValueTypeName.Text);
				}
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritdoc BPMSoft.ServiceParameterPage#prepareDataValueTypeNameList
			 * @override
			 */
			prepareDataValueTypeNameList: function(filter, list) {
				var result = {};
				BPMSoft.each(BPMSoft.services.enums.DataValueTypeCaption, function(displayValue, value) {
					if (this._isDataValueTypeNameAllowed(value)) {
						result[value] = {value: value, displayValue: displayValue};
					}
				}, this);
				list.reloadAll(result);
			}

			//endregion

		},
		diff: [
			{
				"operation": "remove",
				"name": "ServiceRequestParameterDefValue"
			},
			{
				"operation": "insert",
				"index": 7,
				"parentName": "ParameterEditContainer",
				"name": "ServiceResponseParameterDefValue",
				"propertyName": "items",
				"values": {
					"classes": {"wrapClassName": ["control-width-15", "control-left", "grid-layout-row",
						"module-container"]},
					"itemType": BPMSoft.ViewItemType.MODULE,
					"visible": "$isDefaultValueVisible"
				}
			},
			{
				"operation": "remove",
				"name": "IsRequired"
			},
			{
				"operation": "remove",
				"parentName": "ParameterEditContainer",
				"propertyName": "items",
				"name": "SequenceElementName"
			}
		]
	};
});
