define("WebServiceMethodPage", [
	"WebServiceMethodPageResources", "ServiceParameterGrid", "ServiceMetaItemViewModelMixin", "CurlRequestBuilder",
	"ServiceDesignerUtilities", "JsonRequestBuilder", "JsonResponseBuilder"
], function() {
	return {
		messages: {
			/**
			 * @message CloseMethodPage
			 * Closed method page.
			 */
			"CloseMethodPage": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH
			},
			/**
			 * @message OpenServiceClient
			 * Opens service client.
			 */
			"OpenServiceClient": {
				"mode": BPMSoft.MessageMode.PTP,
				"direction": BPMSoft.MessageDirectionType.PUBLISH				
			}
		},
		mixins: {
			observableItem: "BPMSoft.ObservableItem",
			serviceMetaItemViewModelMixin: "BPMSoft.ServiceMetaItemViewModelMixin",
			EntityResponseValidationMixin: "BPMSoft.EntityResponseValidationMixin",
		},
		properties: {
			useItemInitialValues: true,
			useViewModelToItemBinding: true,
			_managerItemStatus: null,
			_managerItem: null
		},
		attributes: {

			/**
			 * Caption.
			 */
			"Caption": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"isRequired": true,
				"validateOrder": 0
			},

			/**
			 * Name.
			 */
			"Name": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"isRequired": true,
				"validateOrder": 1
			},

			/**
			 * BPMSoft.ServiceMethodResponse.
			 */
			"Response": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},

			/**
			 * BPMSoft.ServiceMethodRequest.
			 */
			"Request": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},

			/**
			 * Request URI.
			 */
			"Uri": {
				"dataValueType": BPMSoft.DataValueType.TEXT,
				"onChange": "onUriAttributeChange",
				"isRequired": true,
				"validateOrder": 3
			},

			/**
			 * Request Http Method Type.
			 */
			"HttpMethod": {
				"dataValueType": BPMSoft.DataValueType.ENUM,
				"onChange": "_onServiceMethodRequestAttributeChange"
			},

			/**
			 * Request Http Method Type.
			 */
			"HttpMethodType": {
				"dataValueType": BPMSoft.DataValueType.LOOKUP,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"onChange": "_onMethodTypeChange",
				"isRequired": true,
				"validateOrder": 4
			},

			/**
			 * Request method type list.
			 */
			"HttpMethodTypeList": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION
			},

			/**
			 * Request parameters.
			 */
			"Parameters": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"value": null
			},

			/**
			 * Request timeout.
			 */
			"RequestTimeout": {
				"dataValueType": BPMSoft.DataValueType.INTEGER,
				"isRequired": true,
				"validateOrder": 5
			},

			/**
			 * Method UId.
			 */
			"MethodUId": {
				"dataValueType": BPMSoft.DataValueType.GUID,
				"value": null
			},

			/**
			 * Service UId.
			 */
			"ServiceUId": {
				"dataValueType": BPMSoft.DataValueType.GUID,
				"value": null
			},

			/**
			 * Method object.
			 */
			"Method": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				"onChange": "_onMethodChange"
			},

			/**
			 * Service schema instance.
			 */
			"ServiceSchema": {
				"dataValueType": BPMSoft.DataValueType.CUSTOM_OBJECT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},

			/**
			 * Is allow edit fields.
			 */
			"CanEditSchema": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"onChange": "_setShowAccessInfo"
			},

			/**
			 * Is show access info.
			 */
			"ShowAccessInfo": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Use service authentification info.
			 */
			"UseAuthInfo": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Indicates is sse service authentification info can be changed.
			 */
			"CanChangeUseAuthInfo": {
				"dataValueType": BPMSoft.DataValueType.BOOLEAN,
				"value": false
			},

			/**
			 * Save tab active name.
			 */
			"ActiveTabName": {
				"dataValueType": this.BPMSoft.DataValueType.TEXT,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			},
			/**
			 * Tabs collection.
			 */
			"TabsCollection": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
			}
		},
		modules: {
			"ServiceRequestParameters": {
				"moduleId": "ServiceRequestParameters",
				"moduleName": "ConfigurationModuleV2",
				"reload": false,
				"config": {
					"isSchemaConfigInitialized": false,
					"schemaName": "ServiceParameterGrid",
					"parameters": {
						"viewModelConfig": {
							"ServiceSchemaUId": {
								"attributeValue": "ServiceUId"
							},
							"MethodUId": {
								"getValueMethod": "getMethodUId"
							}
						}
					},
					"useHistoryState": false
				}
			},
			"ServiceResponseParameters": {
				"moduleId": "ServiceResponseParameters",
				"moduleName": "ConfigurationModuleV2",
				"reload": false,
				"config": {
					"isSchemaConfigInitialized": false,
					"schemaName": "ServiceResponseParameterGrid",
					"parameters": {
						"viewModelConfig": {
							"ServiceSchemaUId": {
								"attributeValue": "ServiceUId"
							},
							"MethodUId": {
								"getValueMethod": "getMethodUId"
							}
						}
					},
					"useHistoryState": false
				}
			}
		},
		methods: {

			//region Private

			/**
			 * @private
			 */
			_onMethodChange: function() {
				this.subscribeOnItemChanged(this.$Method);
			},

			/**
			 * @private
			 */
			_hasServiceAuthentification: function() {
				var authInfo = this.$ServiceSchema.authInfo;
				return (authInfo && authInfo.authType) !== BPMSoft.services.enums.AuthType.None;
			},

			/**
			 * @private
			 */
			_getUniqueValue: function(items, property, prefix) {
				var properties = items.mapArray(function(item) {
					return item[property].toString();
				}, this);
				return BPMSoft.getUniqueValue(properties, prefix);
			},

			/**
			 * @private
			 */
			_getNamePrefix: function() {
				var usrPrefix = BPMSoft.ServiceSchemaManager.schemaNamePrefix;
				return usrPrefix + "Method";
			},

			/**
			 * @private
			 */
			_createNewMethod: function() {
				const methodConfig = this.getDefaultMethodConfig(this.$ServiceSchema);
				const method = new BPMSoft.ServiceMethod(methodConfig);
				var namePrefix = this._getNamePrefix();
				var captionPrefix = this.get("Resources.Strings.MethodCaptionPrefix") + " ";
				var methods = this.$ServiceSchema.methods;
				var caption = this._getUniqueValue(methods, "caption", captionPrefix);
				method.caption = new BPMSoft.LocalizableString(caption);
				method.name = this._getUniqueValue(methods, "name", namePrefix);
				method.uri = "";
				method.uId = BPMSoft.generateGUID();
				method.useAuthInfo =
					this.$ServiceSchema.authInfo.authType !== BPMSoft.services.enums.AuthType.None;
				methods.add(method.uId, method);
				this.$MethodUId = method.uId;
				this.$Method = method;
				this.initMethodParameters();
			},

			/**
			 * @private
			 */
			_getSchemaPropertyByAttributeName: function(attributeName) {
				return BPMSoft.toLowerCamelCase(attributeName);
			},

			/**
			 * @private
			 */
			_onServiceMethodRequestAttributeChange: function(model, value) {
				if (this.$Request) {
					this._onAttributeChange(this.$Request, model, value);
				}
			},

			/**
			 * @private
			 */
			_onAttributeChange: function(attribute, model, value) {
				var changedAttribute = BPMSoft.first(Object.keys(model.changed));
				var schemaProperty = this._getSchemaPropertyByAttributeName(changedAttribute);
				if (BPMSoft.isInstanceOfClass(attribute[schemaProperty], "BPMSoft.LocalizableString")) {
					attribute[schemaProperty].setValue(value);
				} else {
					attribute.setPropertyValue(schemaProperty, value);
				}
			},

			/**
			 * Returns Web Service type list.
			 * @private
			 * @return {Object} type list.
			 */
			_getListTypes: function(enumType) {
				var result = {};
				BPMSoft.each(enumType, function(key, type) {
					if (type === "UNDEFINED") {
						return;
					}
					result[key] = {value: key, displayValue: type};
				}, this);
				return result;
			},

			/**
			 * Fill HTTP method type list.
			 * @private
			 * @param {String} filter The filter string.
			 * @param {BPMSoft.Collection} list The list.
			 */
			_prepareMethodTypeList: function(filter, list) {
				this._reloadTypeList(BPMSoft.services.enums.HttpMethodType, filter, list);
			},

			/**
			 * Reload type list.
			 * @param enumList
			 * @param filter
			 * @param list
			 * @private
			 */
			_reloadTypeList: function(enumList, filter, list) {
				if (list === null) {
					return;
				}
				list.reloadAll(this._getListTypes(enumList));
			},

			/**
			 * @private
			 */
			_onMethodTypeChange: function(model, valueType) {
				if (valueType) {
					this._requestTypeValidator(valueType.value, function(result) {
						if (result.invalidMessage) {
							var previousValue = this.getPrevious("HttpMethodType");
							BPMSoft.defer(function() {
								this.$HttpMethodType = previousValue;
							}, this);
							this.showInformationDialog(result.invalidMessage);
						} else {
							this.$HttpMethod = valueType && valueType.value;
						}
					}, this);
				}
			},

			/**
			 * @private
			 */
			_copyMethod: function(method) {
				var namePrefix = this._getNamePrefix();
				var methods = this.$ServiceSchema.methods;
				var serializedMethod = method.serialize();
				var metaData = JSON.parse(serializedMethod);
				metaData.uId = BPMSoft.generateGUID();
				metaData.name = this._getUniqueValue(methods, "name", namePrefix);
				metaData.caption = method.caption + " - Copy";
				metaData._serviceSchema = this.$ServiceSchema;
				this.$MethodUId = metaData.uId;
				var copyMethod = new BPMSoft.ServiceMethod(metaData);
				this.$IsChanged = true;
				methods.add(this.getMethodUId(), copyMethod);
				return copyMethod;
			},

			/**
			 * Initialize request method.
			 * @private
			 */
			_initMethod: function(callback, scope) {
				BPMSoft.ServiceSchemaManager.getInstanceByUId(this.$ServiceUId, function(instance) {
					this.$ServiceSchema = instance;
					this._managerItem = BPMSoft.ServiceSchemaManager.items.get(this.$ServiceUId);
					this._managerItemStatus = this._managerItem.getStatus();
					BPMSoft.ServiceDesignerUtilities.canEditSchema(instance, function(result) {
						this.$CanEditSchema = result;
						var method = instance.methods.findByFn(function(i) {
							return i.uId === this.$MethodUId;
						}, this);
						if (method) {
							this.$Method = this._isCopyMode() ? this._copyMethod(method) : method;
							this.initMethodParameters();
							this.$Method.saveState();
							this.$ShowDiscardButton = true;
						} else {
							this._createNewMethod();
						}
						this.onLoadCanEditSchema();
						this.$ServiceSchema.on("changed", this.onSchemaChanged, this);
						Ext.callback(callback, scope);
					}, this);
				}, this);
			},

			/**
			 * @private
			 */
			_getParametersByType: function(type) {
				return this.$Method.request.parameters.filterByFn(function(item) {
					return item.type === type;
				}, this);
			},

			/**
			 * @private
			 */
			_uriEmptyBracketValidator: function(uriString) {
				var message = uriString.match(/{}/g) ? this.get("Resources.Strings.WrongUrisEmptyBracketsMessage") : "";
				return {invalidMessage: message};
			},

			/**
			 * @private
			 */
			_uriPairedBracketValidator: function(uriString) {
				var message = "";
				var brackets = uriString.replace(/[^{|}]/g, "");
				var unPairedBrackets = brackets.replace(/{}/g, "");
				if (unPairedBrackets.length) {
					message = this.get("Resources.Strings.WrongUrisBracketsMessage");
				}
				return {invalidMessage: message};
			},

			/**
			 * @private
			 */
			_requestTypeValidator: function(type, callback, scope) {
				var validationResult = {
					invalidMessage: ""
				};
				if (type === BPMSoft.services.enums.HttpMethodType.GET) {
					BPMSoft.chain(
							function(next) {
								BPMSoft.ServiceSchemaManager.findRequestParameterByType({
									serviceUId: this.$ServiceSchema.uId,
									methodUId: this.$Method.uId,
									type: BPMSoft.services.enums.ServiceParameterType.BODY
								}, next, this);
							},
							function(next, parameter) {
								if (parameter) {
									validationResult.invalidMessage = this.get("Resources.Strings.WrongRequestTypeMessage");
								}
								Ext.callback(callback, scope, [validationResult]);
							}, this);
				} else {
					Ext.callback(callback, scope, [validationResult]);
				}
			},

			/**
			 * @private
			 */
			_setShowAccessInfo: function() {
				this.$ShowAccessInfo = !this.$CanEditSchema;
			},

			/**
			 * @private
			 */
			_isCopyMode: function() {
				return this.$Operation === BPMSoft.ConfigurationEnums.CardOperation.COPY;
			},

			/**
			 * @private
			 */
			_isNewMode: function() {
				return this._isAddMode() || this._isCopyMode();
			},

			/**
			 * @private
			 */
			_isAddMode: function() {
				return this.$Operation === BPMSoft.ConfigurationEnums.CardOperation.ADD;
			},

			/**
			 * @private
			 */
			_getDefaultTabName: function() {
				var defaultTabName = null;
				if (this.$TabsCollection && !this.$TabsCollection.isEmpty()) {
					var firstTab = this.$TabsCollection.getByIndex(0);
					defaultTabName = firstTab.get("Name");
				}
				return defaultTabName;
			},

			/**
			 * @private
			 */
			_initTabs: function() {
				var defaultTabName = this._getDefaultTabName();
				if (defaultTabName) {
					this.$ActiveTabName = defaultTabName;
					this.set(defaultTabName, true);
				}
			},

			/**
			 * @private
			 */
			_activeTabChange: function(activeTab) {
				var activeTabName = activeTab.get("Name");
				this.$TabsCollection.eachKey(function(tabName, tab) {
					var tabContainerVisibleBinding = tab.get("Name");
					this.set(tabContainerVisibleBinding, false);
				}, this);
				this.set(activeTabName, true);
			},

			/**
			 * @private
			 */
			_close: function() {
				this.sandbox.publish("CloseMethodPage");
				BPMSoft.utils.dom.setAttributeToBody("hide-scroll", false);
			},

			/**
			 * @private
			 */
			_getActiveTabName: function(schemaName) {
				return BPMSoft.contains(["JsonResponseBuilder", "RawResponseBuilder"], schemaName)
						? "ResponseTab"
						: "RequestTab";
			},

			/**
			 * @private
			 */
			_showQuickSetupWindow: function(schemaName, uri) {
				if (this.$CanEditSchema) {
					var pageId = this.sandbox.id + schemaName;
					this.sandbox.loadModule("ModalBoxSchemaModule", {
						id: pageId,
						instanceConfig: {
							moduleInfo: {
								uri: uri,
								schemaName: schemaName,
								destinationServiceUId: this.$ServiceUId,
								destinationMethodUId: this.$MethodUId
							},
							mainContainerWrapClasses: ["service-quick-setup-wrap"],
							headerWrapClasses: ["service-quick-setup-header-wrap"],
							initialSize: {width: 920, height: "580px"},
							customBoxClasses: ['ts-modalbox-scroll']
						}
					});
					this.$ActiveTabName = this._getActiveTabName(schemaName);
				} else {
					this.showInformationDialog(this.get("Resources.Strings.AccessDeny"));
				}
			},

			//endregion

			//region Protected

			/**
			 * @protected
			 */
			getDefaultMethodConfig: function(serviceSchema) {
				return {
					_serviceSchema: serviceSchema,
					request: this.getDefaultMethodRequestConfig(),
					response: this.getDefaultMethodResponseConfig(),
				};
			},

			/**
			 * @protected
			 */
			getDefaultMethodRequestConfig: function() {
				return {};
			},

			/**
			 * @protected
			 */
			getDefaultMethodResponseConfig: function() {
				return {};
			},

			/**
			 * @return {BPMSoft.controls.ButtonEnums.style}
			 * @protected
			 */
			getCancelButtonStyle: function() {
				return this.$CanEditSchema
						? BPMSoft.controls.ButtonEnums.style.DEFAULT
						: BPMSoft.controls.ButtonEnums.style.ORANGE;
			},

			/**
			 * @protected
			 */
			onUriAttributeChange: function(model, value) {
				this._onServiceMethodRequestAttributeChange(model, value);
			},

			/**
			 * @protected
			 */
			onLoadCanEditSchema: this.BPMSoft.emptyFn,

			/**
			 * @protected
			 */
			onAddRequestParameter: this.BPMSoft.emptyFn,

			/**
			 * @protected
			 */
			initMethodParameters: function() {
				this.$Request = this.$Method.request;
				this.$Response = this.$Method.response;
				this.$RequestTimeout = this.$Method.requestTimeout;
				this.set("HttpMethod", this.$Method.request.httpMethodType, {silent: true});
				this.$HttpMethodType = {
					displayValue: this.$Method.request.findHttpMethodTypeName(),
					value: this.$Method.request.httpMethodType
				};
				this.set("Parameters", this.$Method.request.parameters, {silent: true});
				this.$Parameters.on("add", this.onAddRequestParameter, this);
				if (this.$Method.name) {
					this.$Name = this.$Method.name;
				}
				if (this.$Method.request.uri) {
					this.set("Uri", this.$Method.request.uri, {silent: true});
				}
				this.$UseAuthInfo = this.$Method.useAuthInfo;
				this.$CanChangeUseAuthInfo = this._hasServiceAuthentification() && this.$CanEditSchema;
				var caption = this.$Method.caption.getValue();
				if (caption) {
					this.$Caption = caption;
				}
			},

			/**
			 * @protected
			 */
			onSchemaChanged: function(changes) {
				if (this.needValidateUri(changes)) {
					this.validateColumn("Uri");
				}
				this.$CanChangeUseAuthInfo = this._hasServiceAuthentification();
				if (changes.httpMethodType) {
					this.$HttpMethodType = {
						displayValue: this.$Method.request.findHttpMethodTypeName(),
						value: this.$Method.request.httpMethodType
					};
				}
			},

			/**
			 * @inheritdoc BPMSoft.ServiceMetaItemViewModelMixin#duplicateNameValidator.
			 * @overridden
			 */
			duplicateNameValidator: function(schemaName) {
				var message = "";
				BPMSoft.ServiceSchemaManager.getInstanceByUId(this.$ServiceUId, function(item) {
					var method = item.methods.findByFn(function(i) {
						return i.name === schemaName;
					}, this);
					if (method && method.uId !== this.$Method.uId) {
						message = this.get("Resources.Strings.DuplicateNameMessage");
					}
				}, this);
				return {invalidMessage: message};
			},

			/**
			 * @inheritdoc BPMSoft.ObservableItem#getAttributeMap
			 * @override
			 */
			getAttributeMap: function() {
				return {
					caption: "Caption",
					name: "Name",
					response: "Response",
					request: "Request",
					parameters: "Parameters",
					requestTimeout: "RequestTimeout",
					useAuthInfo: "UseAuthInfo"
				};
			},

			/**
			 * @inheritdoc BPMSoft.BaseObject#onDestroy
			 * @override
			 */
			onDestroy: function() {
				if (this.$Parameters) {
					this.$Parameters.un("add", this.onAddRequestParameter, this);
				}
				this.$ServiceSchema.un("changed", this.onSchemaChanged, this);
				this.unsubscribeAllItems();
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#getPageHeader
			 * @override
			 */
			getPageHeader: function() {
				return (this.$Method && this.$Method.caption.getValue()) || "";
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onDiscardChangesClick
			 * @override
			 */
			onDiscardChangesClick: function() {
				if (this._isNewMode()) {
					this.$ServiceSchema.methods.removeByKey(this.getMethodUId());
				} else {
					this.$Method.restoreState();
					this.initMethodParameters();
				}
				this._close();
				this._managerItem.setStatus(this._managerItemStatus);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#setValidationConfig
			 * @overridden
			 */
			setValidationConfig: function() {
				this.callParent(arguments);
				this.setNameValidationConfig();
				this.addColumnValidator("RequestTimeout", this.positiveNumberValidator);
			},

			/**
			 * @inheritdoc BPMSoft.BaseModel#set
			 * @overridden
			 */
			set: function(key, value, options) {
				if (!this.$CanEditSchema) {
					options = options || {};
					options.skipValidation = true;
				}
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				BPMSoft.utils.dom.setAttributeToBody("hide-scroll", true);
				this.callParent([
					function() {
						BPMSoft.chain(
								function(next) {
									BPMSoft.ServiceSchemaManager.initialize(next, this);
								},
								function(next) {
									this._initMethod(next, this);
								},
								function() {
									this._initTabs();
									callback.call(scope || this);
								}, this);
					}, this
				]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#loadEntity
			 * @override
			 */
			loadEntity: function(primaryColumnValue, callback, scope) {
				callback.call(scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#copyEntity
			 * @override
			 */
			copyEntity: function(primaryColumnValue, callback, scope) {
				callback.call(scope);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#getColumnCaptionByName.
			 * @overridden
			 */
			getColumnCaptionByName: function(name) {
				var caption;
				switch (name) {
					case "Name":
						caption = this.get("Resources.Strings.CodeCaption");
						break;
					case "Caption":
						caption = this.get("Resources.Strings.MethodNameCaption");
						break;
					case "Uri":
						caption = this.get("Resources.Strings.UriCaption");
						break;
					case "HttpMethodType":
						caption = this.get("Resources.Strings.HttpMethodTypeCaption");
						break;
					case "RequestTimeout":
						caption = this.get("Resources.Strings.RequestTimeoutCaption");
						break;
					default:
						caption = this.callParent(arguments);
				}
				return caption;
			},

			/**
			 * Return MethodUId.
			 * @return {GUID} methodUId.
			 */
			getMethodUId: function() {
				return this.$MethodUId;
			},

			/**
			 * @protected
			 */
			validateUri: function(callback, scope) {
				callback.call(scope, true);
			},

			/**
			 * Ok button click handler.
			 */
			onOkButtonClick: function() {
				var defaultUriValidation = _.toArray(this.validationConfig.Uri);
				this.addColumnValidator("Uri", this._uriEmptyBracketValidator);
				this.addColumnValidator("Uri", this._uriPairedBracketValidator);
				this.asyncValidate(function(response) {
					this.validationConfig.Uri = defaultUriValidation;
					if (this.validateResponse(response)) {
						this.validateUri(function(canSave) {
							if (canSave) {
								this.$Method.saveState();
								this._close();
							}
						}, this);
					}
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#asyncValidate
			 * @overridden
			 */
			asyncValidate: function(callback, scope) {
				var resultObject = {
					success: this.validate()
				};
				if (!resultObject.success) {
					resultObject.message = this.getValidationMessage();
				}
				this.Ext.callback(callback, scope, [resultObject]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#validate
			 * @overridden
			 */
			validate: function() {
				return this.$CanEditSchema ? this.callParent(arguments) : true;
			},

			/**
			 * Checks if need validate uri path.
			 * @param {Object} changes Contains changes of object.
			 * @protected
			 */
			needValidateUri: function(changes) {
				if (changes) {
					var keys = Object.keys(changes);
					var isChangedParameters = keys.filter(function(key) {
						return key.indexOf("parameter") !== -1;
					});
					return isChangedParameters.length && !Ext.isEmpty(this.$Uri);
				} else {
					return false;
				}
			},

			onOpenServiceClientButtonClicked: function() {
				this.sandbox.publish("OpenServiceClient", this.$MethodUId);
			},

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "ServiceMethodPageWrapper",
				"values": {
					"id": "ServiceMethodPageWrapper",
					"selectors": {"wrapEl": "#ServiceMethodPageWrapper"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["card-content-container", "web-service-method-card-content-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "HeaderContainer",
				"parentName": "ServiceMethodPageWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {wrapClassName: ["web-service-method-header-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ServiceMethodPageContentContainer",
				"parentName": "ServiceMethodPageWrapper",
				"propertyName": "items",
				"values": {
					"id": "ServiceMethodPageContentContainer",
					"selectors": {"wrapEl": "#ServiceMethodPageContentContainer"},
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["web-service-method-page-center-main-container", "center-main-container"],
					"items": [],
					"markerValue": "CenterMainContainer"
				}
			},
			{
				"operation": "insert",
				"name": "ActionContainer",
				"parentName": "ServiceMethodPageContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["web-service-method-action-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MainContainer",
				"parentName": "ServiceMethodPageContentContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-container-margin-bottom", "web-service-method-page-main-container"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "HeaderContainer",
				"parentName": "MainContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-container-margin-bottom", "web-service-method-page-side-padding"],
					"items": [],
					"markerValue": {"bindTo": "HeaderContainerMarkerValue"}
				}
			},
			{
				"operation": "insert",
				"name": "HeaderCaptionContainer",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["header-caption-container-margin"],
					"visible": {
						"bindTo": "_isNewMode"
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "NewRecordPageCaption",
				"parentName": "HeaderCaptionContainer",
				"propertyName": "items",
				"values": {
					"labelClass": ["new-record-header-caption-label"],
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "NewRecordPageCaption"},
					"visible": {"bindTo": "checkNewRecordPageCaptionSet"}
				}
			},
			{
				"operation": "insert",
				"name": "Header",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"collapseEmptyRow": true
				}
			},
			{
				"operation": "insert",
				"name": "TabsContainer",
				"parentName": "MainContainer",
				"propertyName": "items",
				"values": {
					"className": "BPMSoft.LazyContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["web-service-method-page-side-padding", "web-service-method-page-tabs"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Tabs",
				"parentName": "TabsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.TAB_PANEL,
					"activeTabChange": {"bindTo": "_activeTabChange"},
					"activeTabName": {"bindTo": "ActiveTabName"},
					"classes": {"wrapClass": ["tab-panel-margin-bottom"]},
					"collection": {"bindTo": "TabsCollection"},
					"tabs": []
				}
			},
			{
				"operation": "remove",
				"name": "actions"
			},
			{
				"operation": "remove",
				"name": "PrintButton"
			},
			{
				"operation": "insert",
				"name": "Caption",
				"values": {
					"controlConfig": {
						"focused": true
					},
					"layout": {"column": 0, "row": 0, "colSpan": 14},
					"bindTo": "Caption",
					"caption": {"bindTo": "Resources.Strings.MethodNameCaption"},
					"enabled": {
						"bindTo": "CanEditSchema"
					}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "Name",
				"values": {
					"layout": {"column": 0, "row": 1, "colSpan": 14},
					"bindTo": "Name",
					"caption": {"bindTo": "Resources.Strings.CodeCaption"},
					"enabled": {
						"bindTo": "CanEditSchema"
					},
					"tip": {"content": "$Resources.Strings.CodeHint"}
				},
				"parentName": "Header",
				"propertyName": "items"
			},
			{
				"operation": "insert",
				"name": "RequestTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"caption": {"bindTo": "Resources.Strings.RequestTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "RequestParameters",
				"parentName": "RequestTab",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"controlConfig": {
						"collapsed": false
					},
					"markerValue": "RequestParameters"
				}
			},
			{
				"operation": "insert",
				"parentName": "RequestParameters",
				"name": "ServiceRequestParameters",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"classes": {"wrapClass": ["height-100-percentage"]}
				}
			},
			{
				"operation": "insert",
				"name": "ResponseTab",
				"parentName": "Tabs",
				"propertyName": "tabs",
				"values": {
					"classes": {"wrapClass": ["height-100-percentage"]},
					"caption": {"bindTo": "Resources.Strings.ResponseTabCaption"},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "ResponseParameters",
				"parentName": "ResponseTab",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": [],
					"controlConfig": {
						"collapsed": false
					},
					"markerValue": "RequestParameters"
				}
			},
			{
				"operation": "insert",
				"parentName": "ResponseParameters",
				"name": "ServiceResponseParameters",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"classes": {"wrapClass": ["height-100-percentage"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"name": "OKButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"classes": {"textClass": "actions-button-margin-right"},
					"visible": {"bindTo": "CanEditSchema"},
					"click": {"bindTo": "onOkButtonClick"},
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"tag": "ok",
					"markerValue": "ok"
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"name": "DiscardChangesButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": {"bindTo": "Resources.Strings.CancelButtonCaption"},
					"style": {"bindTo": "getCancelButtonStyle"},
					"classes": {"textClass": "actions-button-margin-right"},
					"click": {"bindTo": "onDiscardChangesClick"}
				}
			},
			{
				operation: "insert",
				name: "OpenServiceClientButton",
				parentName: "ActionContainer",
				propertyName: "items",
				values: {
					itemType: BPMSoft.ViewItemType.BUTTON,
					style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
					caption: "$Resources.Strings.OpenServiceClientButtonCaption",
					"click": {"bindTo": "onOpenServiceClientButtonClicked"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"name": "CloseIcon",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.CloseIcon"},
					"classes": {"wrapperClass": ["web-service-method-page-close-btn"]},
					"click": {"bindTo": "onDiscardChangesClick"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionContainer",
				"propertyName": "items",
				"name": "AccessInfoButton",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": {
						"bindTo": "Resources.Strings.AccessDeny"
					},
					"controlConfig": {
						"visible": {
							"bindTo": "ShowAccessInfo"
						}
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		rules: {},
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/
	};
});
