define("ServiceResponseParameterGrid", [], function() {
	return {
		modules: {
			ResponseServiceParameterPage: {
				moduleId: "ResponseServiceParameterPage",
				moduleName: "ConfigurationModuleV2",
				config: {
					isSchemaConfigInitialized: false,
					schemaName: {
						getValueMethod: "getServiceParameterEditPage"
					},
					parameters: {
						viewModelConfig: {
							ServiceSchemaUId: {
								attributeValue: "ServiceSchemaUId"
							},
							MethodUId: {
								attributeValue: "MethodUId"
							},
							ParameterUId: {
								attributeValue: "ParameterUId"
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
		properties: {
			restServiceParameterEditPage: "ServiceResponseParameterPage",
			soapServiceParameterEditPage: "SoapServiceResponseParameterPage",
		},
		methods: {

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterGrid#getMethodParameters
			 * @override
			 */
			getMethodParameters: function(method) {
				return method.response.parameters;
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterGrid#createParameter
			 * @override
			 */
			createParameter: function() {
				return this.callParent([{
					type: BPMSoft.services.enums.ServiceParameterType.BODY
				}]);
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterGrid#getParameterEditPageTag
			 * @override
			 */
			getParameterEditPageTag: function() {
				return "ResponseParameterEditPage";
			},

			/**
			 * @inheritdoc BPMSoft.ServiceParameterGrid#getParameterGridTag
			 * @override
			 */
			getParameterGridTag: function() {
				return "ServiceResponseParameterGrid";
			},

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterGrid#getServiceBuilderTags
			 * @override
			 */
			getServiceBuilderTags: function() {
				return ["ServiceResponseMethodBuilder"];
			}

			//endregion

		},
		diff: [
			{
				operation: "remove",
				name: "ServiceParameterPage"
			},
			{
				operation: "insert",
				parentName: "MainContainer",
				name: "ResponseServiceParameterPage",
				propertyName: "items",
				values: {
					itemType: BPMSoft.ViewItemType.MODULE,
					visible: {
						bindTo: "ActiveRow",
						bindConfig: {converter: "activeRowIsNotEmpty"}
					},
					classes: {wrapClassName: ["service-parameter-grid-page"]}
				}
			}
		]
	};
});
