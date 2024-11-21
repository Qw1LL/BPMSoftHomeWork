define("SoapWebServiceV2Page", ["SoapWebServiceV2PageResources", "css!ServiceDesignerStyles"],
	function() {
		return {
			mixins: {},
			attributes: {
				Namespace: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					isRequired: true
				},
			},
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			modules: {},
			properties: {
				defaultNamespace: "http://tempuri.org/",
				defaultPrefix: "tem",
			},
			methods: {

				_addNamespace: function (prefix, name, isDefault) {
					const namespace = Ext.create("BPMSoft.ServiceNamespace", {
						prefix: prefix,
						name: name,
						uId: BPMSoft.generateGUID(),
						isDefault: isDefault
					});
					this.$Schema.namespaces.add(namespace.uId, namespace);
				},

				_checkIsNamespaceWithoutPrefix: function(namespace) {
					const namespaceWithoutRegex = /^(((https?|ftp|smtp):\/\/)|([^:]+$))/;
					return namespace.match(namespaceWithoutRegex) !== null;
				},

				_getNamespaceMetadata: function(namespace) {
					const metadata = {
						hasPrefix: true,
						prefix: null,
						namespace: null,
						valid: true
					}
					if (this._checkIsNamespaceWithoutPrefix(namespace)) {
						metadata.hasPrefix = false;
						metadata.namespace = namespace;
					} else {
						const extractNamespacePrefixRegex = /^([a-zA-Z0-9_\-]+?):(.+)$/;
						const match = namespace.match(extractNamespacePrefixRegex);
						if (match) {
							metadata.prefix = match[1];
							metadata.namespace = match[2];
						}
						metadata.valid = match !== null;
					}
					return metadata;
				},

				_calculateNamespacesWithoutPrefix: function(namespacesMetadata) {
					return namespacesMetadata.reduce(function(count, namespaceMetadata) {
						return namespaceMetadata.hasPrefix ? count : count + 1;
					}, 0);
				},

				_splitNamespaces: function(namespaceString) {
					const parseRegex = /(.+?)(;|$)/gm;
					const result = [];
					const matches = namespaceString.matchAll(parseRegex);
					for (let match of matches) {
						result.push(match[1]);
					}
					return result;
				},

				_getNamespacesInfo: function(namespaceString) {
					const namespaces = this._splitNamespaces(namespaceString);
					const namespacesMetadata = namespaces.map(this._getNamespaceMetadata, this);
					return {
						namespacesWithoutPrefix: this._calculateNamespacesWithoutPrefix(namespacesMetadata),
						namespacesMetadata: namespacesMetadata
					}
				},

				_getNamespacePrefix: function(namespaceMetadata) {
					return namespaceMetadata.hasPrefix ? namespaceMetadata.prefix : this.defaultPrefix;
				},

				_addNamespaces: function(namespacesInfo) {
					if (namespacesInfo.namespacesWithoutPrefix > 1) {
						return;
					}
					let first = true;
					for (const namespaceMetadata of namespacesInfo.namespacesMetadata) {
						const prefix = this._getNamespacePrefix(namespaceMetadata);
						this._addNamespace(prefix, namespaceMetadata.namespace, first);
						first = false;
					}
				},

				_namespacesValidator: function(namespaceString) {
					const namespacesInfo = this._getNamespacesInfo(namespaceString);
					return this._validateNamespaces(namespacesInfo);
				},

				_validateNamespaces: function(namespacesInfo) {
					let invalidMessage = null;
					const hasInvalidNamespaces = namespacesInfo.namespacesMetadata.some(function(namespaceMetadata) {
						return !namespaceMetadata.valid;
					});
					if (namespacesInfo.namespacesWithoutPrefix > 1 || hasInvalidNamespaces) {
						invalidMessage = this.get("Resources.Strings.InvalidNamespaceMessage");
					}
					return {
						invalidMessage: invalidMessage,
						isValid: invalidMessage === null
					};
				},

				_onNamespaceChanged: function() {
					if (this.$Namespace) {
						this.$Schema.namespaces.clear();
						const namespacesInfo = this._getNamespacesInfo(this.$Namespace);
						if (this._validateNamespaces(namespacesInfo).isValid !== true) {
							return;
						}
						this._addNamespaces(namespacesInfo);
					}
				},

				_fillNamespaceAttribute: function() {
					const namespaces = this.$Schema.namespaces.getItems();
					if (namespaces.length === 1) {
						this.$Namespace = namespaces[0].name;
					} else {
						this.$Namespace = namespaces.map(function(item) {
							return item.prefix + ":" + item.name
						}).join(";\r\n");
					}
				},

				/**
				 * @private
				 */
				_getServiceData: function() {
					var data = this.initialConfig && this.initialConfig.values && this.initialConfig.values.wizardServiceData;
					return data;
				},

				/**
				 * @private
				 */
				_applySchemaData: function(serviceData) {
					this.$Schema.setPropertyValue("name", serviceData.name);
					this.$Schema.setPropertyValue("baseUri", serviceData.baseUri);
					this.$Schema.setLocalizableStringPropertyValue("caption", serviceData.caption);
				},

				_getPrefixedName: function(name, parentName) {
					return !!parentName ?
						BPMSoft.ServiceSchemaManager.schemaNamePrefix + parentName + name :
						BPMSoft.ServiceSchemaManager.schemaNamePrefix + name;
				},

				/**
				 * @private
				 */
				_applyMethodsData: function(serviceData) {
					BPMSoft.each(serviceData.methods.items, function(methodConfig) {
						const defaultMethodConfig = this.getDefaultMethodConfig(this.$Schema);
						const config = Ext.merge(defaultMethodConfig, methodConfig)
						const method = Ext.create("BPMSoft.ServiceMethod", config);
						this.$Schema.methods.add(method);
					}, this);
				},

				/**
				 * @private
				 */
				_applyNamespacesData: function(serviceData) {
					let isDefault = true; 
					serviceData.namespaces.forEach(function(namespace) {
						this._addNamespace(namespace.prefix, namespace.name, isDefault);
						isDefault = false;
					}, this);
				},

				_containsPrefix:function(prefix) {
					return this.$Schema.namespaces.filter(function (ns) {
						return ns.prefix === prefix;
					}).getCount() > 0;
				},

				_getInvalidPrefix: function(path) {
					const regExp = /\s*:\s*/;
					const separated = path.split(regExp);
					return (separated.length > 1 && !this._containsPrefix(separated[0])) ? separated[0] : null;
				},

				_validateParameter: function(parameter, methodName) {
					const paths = parameter.path.split('/');
					const prefixes = paths
						.map(function(path) {
							return this._getInvalidPrefix(path);
						}, this)
						.filter(function(prefix) {
							return !!prefix;
						}, this)
						.join(',');
					const message = this.get("Resources.Strings.InvalidParameterMessage");
					return prefixes ? this.Ext.String.format(message, parameter.caption, methodName, prefixes) : null;
				},

				_validateMethod: function(method) {
					const prefix = this._getInvalidPrefix(method.request.uri);
					const message = this.get("Resources.Strings.InvalidMethodMessage");
					return prefix ? this.Ext.String.format(message, method.caption, prefix) : null;
				},

				_validateParameters: function(parameters, methodCaption, invalidMessages) {
					parameters.each(function(parameter) {
						const message = this._validateParameter(parameter, methodCaption);
						if(message) {
							invalidMessages.push(message);
						}
					}, this);
				},

				_validateMethods: function(methods, invalidMessages) {
					methods.each(function(method) {
						const message = this._validateMethod(method);
						if(message) {
							invalidMessages.unshift(message);
						}
						this._validateParameters(method.request.parameters, method.caption, invalidMessages);
						this._validateParameters(method.response.parameters, method.caption, invalidMessages);
					}, this);
				},

				_prepareMessage: function(messages) {
					let resultMessage = this.get("Resources.Strings.InvalidSchemaTitleMessage");
					messages.forEach(function(message) {
						resultMessage = resultMessage + '\n' + message;
					});
					return resultMessage;
				},

				_getSaveServiceButtonConfig: function() {
					return BPMSoft.getBlueButtonConfig("save-service",
						this.get("Resources.Strings.SaveServiceButtonCaption"));
				},

				_getConfirmDialogConfig: function() {
					return {
						customWrapClass: "web-service-confirm-dialog"
					} 
				},

				/**
				 * @override
				 */
				getServiceType: function() {
					return this.callParent(arguments) || BPMSoft.services.enums.ServiceType.SOAP12;
				},

				/**
				 * @override
				 */
				getDefaultMethodConfig: function(schema) {
					const methodConfig = this.callParent(arguments);
					return Ext.apply(methodConfig, {
						response: {
							contentType: BPMSoft.services.enums.ServiceContentType.XML
						}
					})
				},

				/**
				 * @override
				 */
				applyWizardData: function () {
					const serviceData = this._getServiceData();
					if (!Ext.isEmpty(serviceData)) {
						this._applySchemaData(serviceData);
						this._applyMethodsData(serviceData);
						this._applyNamespacesData(serviceData);
					}
				},

				/**
				 * @override
				 */
				onServiceSchemaLoaded: function() {
					this.callParent(arguments);
					this._fillNamespaceAttribute();
					this.on("change:Namespace", this._onNamespaceChanged, this);
					if (!this.$Namespace) {
						this.$Namespace = this.defaultNamespace;
					}
				},

				validateSchema: function() {
					let invalidMessages = [];
					this._validateMethods(this.$Schema.methods, invalidMessages);
					return invalidMessages;
				},

				getValidationSchemaResult: function() {
					let validationResult = {
						success: true,
						validationMassage: ""
					};
					const invalidMessages = this.validateSchema();
					if(invalidMessages.length > 0) {
						validationResult.success = false;
						validationResult.validationMassage = this._prepareMessage(invalidMessages);
					}
					return validationResult;
				},

				/**
				 * @inheritdoc BPMSoft.WebServiceV2Page#internalSave
				 * @override
				 */
				internalSave: function(callback, scope) {
					const saveServiceButton = this._getSaveServiceButtonConfig();
					const config = this._getConfirmDialogConfig();
					const validationResult = this.getValidationSchemaResult();
					const parentInternalSave = this.getParentMethod(this, [callback, scope]);
					if (validationResult.success) {
						parentInternalSave();
					} else {
						this.showConfirmationDialog(
							validationResult.validationMassage, function(result) {
								if (result === saveServiceButton.returnCode) {
									parentInternalSave();
								}
							},
							[saveServiceButton, BPMSoft.MessageBoxButtons.CANCEL],
							config
						);
					}
				},

				/**
				 * @inheritdoc BPMSoft.WebServiceV2Page#onDiscardChangesClick
				 * @override
				 */
				discardSchemaChanges: function() {
					this.callParent(arguments);
					this._fillNamespaceAttribute();
				},

				/**
				 * @inheritdoc BPMSoft.WebServiceV2Page#init
				 * @override
				 */
				init: function(callback, scope) {
					this.callParent([function() {
						this.addColumnValidator("Namespace", this._namespacesValidator);
						Ext.callback(callback, scope);
					}, this]);
				},

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Namespace",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 11},
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"caption": "$Resources.Strings.SoapNamespaceCaption",
						"tip": {"content": "$Resources.Strings.SoapNamespaceHint"}
					}
				},
				{
					"operation": "merge",
					"name": "Description",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 11, "rowSpan": 1}
					}
				},
				{
					"operation": "merge",
					"name": "PackageLookup",
					"values": {
						"layout": {"column": 13, "row": 3, "colSpan": 11},		
					}
				},
				{
					"operation": "merge",
					"name": "BaseUri",
					"values": {
						"tip": ""
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
