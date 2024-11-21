define("ServiceMethodBuilder", ["SourceCodeEditGenerator"], function() {
	return {
		messages: {

			/**
			 * @message GetSelectedParameters
			 * Publishes to get selected parameters from ServiceBuilderParameterGrid.
			 * @return {Array} Returns selected parameters uids.
			 */
			GetSelectedParameters: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			/**
			 * @message GetParametersConfig
			 * Subscribes to on get parameters config.
			 */
			GetParametersConfig: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			},

			/**
			 * @message ServiceMethodBuilt
			 * Sends method for update parameters.
			 * @return {Object} new method.
			 */
			ServiceMethodBuilt: {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			}

		},
		modules: {
			ServiceMethodBuilderRequestParameters: {
				moduleId: "ServiceMethodBuilderRequestParameters",
				moduleName: "ConfigurationModuleV2",
				reload: true,
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "ServiceBuilderParameterGrid",
					useHistoryState: false
				}
			},
			ServiceMethodBuilderResponseParameters: {
				moduleId: "ServiceMethodBuilderResponseParameters",
				moduleName: "ConfigurationModuleV2",
				reload: true,
				config: {
					isSchemaConfigInitialized: false,
					schemaName: "ServiceBuilderResponseParameterGrid",
					useHistoryState: false
				}
			}
		},
		attributes: {

			/**
			 * Service UId.
			 */
			DestinationServiceUId: {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Method UId.
			 */
			DestinationMethodUId: {
				dataValueType: BPMSoft.DataValueType.GUID
			},

			/**
			 * Current page mode.
			 */
			CurrentMode: {
				dataValueType: BPMSoft.DataValueType.ENUM,
				onChange: "_onCurrentModeChange"
			},

			/**
			 * Parsed method.
			 */
			ParsedMethod: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Service schema.
			 */
			ServiceSchema: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Service Method.
			 */
			Method: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Indicates if request parameters can be set up.
			 */
			SetupRequestParameters: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Indicates if response parameters can be set up.
			 */
			SetupResponseParameters: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: true
			},

			/**
			 * Result information message.
			 */
			ResultMessage: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},

			/**
			 * Result information message part 2.
			 */
			ResultMessagePart2: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},

			/**
			 * Result information image.
			 */
			ResultImage: {
				dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT
			},

			/**
			 * Input data.
			 */
			InputData: {
				dataValueType: BPMSoft.DataValueType.TEXT
			},

			/**
			 * Input data focused.
			 */
			InputDataFocused: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				onChange: "_onInputDataFocusedChange"
			}

		},
		properties: {
			_operationModes: null
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_onInputDataFocusedChange: function() {
				if (this.$InputDataFocused) {
					BPMSoft.ResourceMutex.lock("InputFocus");
				} else {
					BPMSoft.ResourceMutex.release("InputFocus");
				}
			},

			/**
			 * @private
			 */
			_onCurrentModeChange: function() {
				if (this.$CurrentMode === this._operationModes.METHOD_SETUP_RESULT) {
					if (this.$ParsedMethod) {
						this.$ResultMessage = this.get("Resources.Strings.SaveSuccessInfo");
						this.$ResultImage = this.get("Resources.Images.SetupResultImageSuccess");
					} else {
						this.$ResultMessage = this.get("Resources.Strings.ParseFailedInfo");
						this.$ResultMessagePart2 = this.get("Resources.Strings.ParseFailedInfoPart2");
						this.$ResultImage = this.get("Resources.Images.SetupResultImageFail");
					}
				}
				this.$InputDataFocused = this.$CurrentMode === this._operationModes.INPUT_DATA;
			},

			/**
			 * @private
			 */
			_initOperationModes: function() {
				return {
					INPUT_DATA: 1,
					METHOD_SETUP: 2,
					METHOD_SETUP_RESULT: 3
				};
			},

			/**
			 * Initialize request method.
			 * @private
			 */
			_initMethod: function(callback, scope) {
				var config = {
					serviceUId: this.$DestinationServiceUId,
					methodUId: this.$DestinationMethodUId
				};
				BPMSoft.ServiceSchemaManager.findMethodByUId(config, function(method) {
					if (method) {
						this.$Method = method;
						this.$ServiceSchema = method.getServiceSchema();
					}
					Ext.callback(callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_getSelectedRequestParameters: function() {
				return this.sandbox.publish("GetSelectedParameters", null, ["ServiceMethodBuilderRequestParameters"]);
			},

			/**
			 * @private
			 */
			_getSelectedResponseParameters: function() {
				return this.sandbox.publish("GetSelectedParameters", null, ["ServiceMethodBuilderResponseParameters"]);
			},

			/**
			 * @private
			 */
			_removeRedundantParameters: function(metaItem, selectedParameters, setupParameters) {
				var parameters = metaItem.getPropertyValue("parameters") || metaItem.getPropertyValue("itemProperties");
				if (setupParameters) {
					var keys = BPMSoft.deepClone(parameters.getKeys());
					var key = keys.shift();
					while (key) {
						if (!BPMSoft.contains(selectedParameters, key)) {
							parameters.removeByKey(key);
						}
						key = keys.shift();
					}
				} else {
					parameters.clear();
				}
				parameters.each(function(value) {
					this._removeRedundantParameters(value, selectedParameters, setupParameters);
				}, this);
			},

			/**
			 * @private
			 */
			_prepareRequestParameters: function() {
				var selectedParameters = this._getSelectedRequestParameters();
				var metaItem = this.$ParsedMethod.getPropertyValue("request");
				this._removeRedundantParameters(metaItem, selectedParameters, this.$SetupRequestParameters);
			},

			/**
			 * @private
			 */
			_prepareResponseParameters: function() {
				var selectedParameters = this._getSelectedResponseParameters();
				var metaItem = this.$ParsedMethod.getPropertyValue("response");
				this._removeRedundantParameters(metaItem, selectedParameters, this.$SetupResponseParameters);
			},

			/**
			 * @private
			 */
			_beforeMethodMerge: function() {
				this._prepareRequestParameters();
				this._prepareResponseParameters();
			},

			//endregion

			//region Methods: Protected


			/**
			 * Returns image resource.
			 * @protected
			 */
			getImage: function() {
				if (this.$ResultImage) {
					return this.BPMSoft.ImageUrlBuilder.getUrl(this.$ResultImage);
				}
			},

			/**
			 * Back button handler.
			 * @protected
			 */
			back: function() {
				this.$ParsedMethod = null;
				this.$CurrentMode = this._operationModes.INPUT_DATA;
			},

			/**
			 * Returns merge method options.
			 * @return {Object} Merge options.
			 * @protected.
			 */
			getMergeOptions: function() {
				return null;
			},

			/**
			 * Returns parsed method.
			 * @return {BPMSoft.ServiceMethod} Parsed method.
			 * @protected.
			 */
			parseMethod: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseServiceParameterGrid#getServiceBuilderTags
			 * @override
			 */
			getServiceBuilderTags: function() {
				return ["ServiceMethodBuilder"];
			},

			//endregion

			//region Methods: Public

			/**
			 * @inheritDoc BPMSoft.BaseObject#constructor.
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this._operationModes = this._initOperationModes();
			},

			/**
			 * @inheritDoc BPMSoft.BaseSchemaViewModel#init.
			 * @overridden
			 */
			init: function(callback, scope) {
				this.callParent([
					function() {
						BPMSoft.chain(
							function(next) {
								BPMSoft.ServiceSchemaManager.initialize(next, this);
							},
							function(next) {
								var moduleInfo = this.get("moduleInfo") || {};
								this.$CurrentMode = this._operationModes.INPUT_DATA;
								this.$DestinationServiceUId = moduleInfo.destinationServiceUId;
								this.$DestinationMethodUId = moduleInfo.destinationMethodUId;
								this._initMethod(next, this);
							},
							function() {
								this.sandbox.subscribe("GetParametersConfig", this.getParsedResponseParameters, this,
									["ServiceMethodBuilderResponseParameters"]);
								this.sandbox.subscribe("GetParametersConfig", this.getParsedRequestParameters, this,
									["ServiceMethodBuilderRequestParameters"]);
								Ext.callback(callback, scope);
							},
							this
						);
					}, this]);
			},

			/**
			 * Save method.
			 */
			save: function() {
				this._beforeMethodMerge();
				this.$Method.merge({
					method: this.$ParsedMethod,
					options: this.getMergeOptions()
				});
				this.$CurrentMode = this._operationModes.METHOD_SETUP_RESULT;
				this.sandbox.publish("ServiceMethodBuilt", this.$ParsedMethod.serialize(),
						this.getServiceBuilderTags());
				this.destroyModule();
			},

			/**
			 * Parse data base method.
			 */
			parse: function(callback, scope) {
				this.$ParsedMethod = this.parseMethod();
				if (this.$ParsedMethod) {
					this.$CurrentMode = this._operationModes.METHOD_SETUP;
				} else {
					this.$CurrentMode = this._operationModes.METHOD_SETUP_RESULT;
				}
				Ext.callback(callback, scope);
			},

			/**
			 * Close modal window.
			 */
			close: function() {
				this.destroyModule();
			},

			/**
			 * Returns serialized parsed method request parameters.
			 */
			getParsedRequestParameters: function() {
				var request = this.$ParsedMethod.getPropertyValue("request");
				var requestParameters = request.getPropertyValue("parameters");
				return requestParameters.serialize();
			},

			/**
			 * Returns serialized parsed method response parameters.
			 */
			getParsedResponseParameters: function() {
				var response = this.$ParsedMethod.getPropertyValue("response");
				var responseParameters = response.getPropertyValue("parameters");
				return responseParameters.serialize();
			},

			/**
			 * Indicates if user can go back to the previous step.
			 */
			canGoBack: function() {
				return this.$CurrentMode === this._operationModes.METHOD_SETUP_RESULT ||
					this.$CurrentMode === this._operationModes.METHOD_SETUP;
			},

			/**
			 * Returns if Cancel button visible.
			 */
			canClose: function() {
				return this.$CurrentMode !== this._operationModes.METHOD_SETUP;
			},

			/**
			 * Returns if Save button visible.
			 */
			canSave: function() {
				return this.$CurrentMode === this._operationModes.METHOD_SETUP;
			},

			/**
			 * Returns if InputData container visible.
			 */
			isInputDataMode: function() {
				return this.$CurrentMode === this._operationModes.INPUT_DATA;
			},

			/**
			 *  Returns if MethodSetup container visible.
			 */
			isMethodSetupMode: function() {
				return this.$CurrentMode === this._operationModes.METHOD_SETUP;
			},

			/**
			 * Returns if MethodSetupResult container visible.
			 */
			isMethodSetupResultMode: function() {
				return this.$CurrentMode === this._operationModes.METHOD_SETUP_RESULT;
			},

			/**
			 * Returns Cancel button caption, dependent on current operating mode.
			 */
			getCancelButtonCaption: function() {
				if (this.$CurrentMode !== this._operationModes.METHOD_SETUP_RESULT) {
					return this.get("Resources.Strings.CancelButtonCaption");
				} else {
					return this.$ParsedMethod
						? this.get("Resources.Strings.DoneButtonCaption")
						: this.get("Resources.Strings.CloseButtonCaption");
				}
			},

			/**
			 * Returns BackButton style, dependent on current operating mode.
			 */
			getBackButtonStyle: function() {
				return this.$CurrentMode === this._operationModes.METHOD_SETUP
					? BPMSoft.controls.ButtonEnums.style.DEFAULT
					: BPMSoft.controls.ButtonEnums.style.ORANGE;
			},

			/**
			 * Returns CancelButton style, dependent on current operating mode.
			 */
			getCancelButtonStyle: function() {
				return this.$CurrentMode === this._operationModes.METHOD_SETUP_RESULT && this.$ParsedMethod
					? BPMSoft.controls.ButtonEnums.style.ORANGE
					: BPMSoft.controls.ButtonEnums.style.DEFAULT;
			}

			//endregion

		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"name": "QuickSetupWindowWrapper",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"classes": {"wrapClassName": ["service-method-builder-wrapper"]}
				}
			},
			{
				"operation": "insert",
				"name": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "HeaderTitle",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"labelConfig": {
						"caption": "$Resources.Strings.Title",
						"classes": ["service-method-builder-caption"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "CloseIcon",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"imageConfig": {"bindTo": "Resources.Images.CloseIcon"},
					"classes": {"wrapperClass": ["service-builder-close-btn"]},
					"click": {"bindTo": "close"}
				}
			},
			
			{
				"operation": "insert",
				"name": "FooterContainer",
				"parentName": "QuickSetupWindowWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"classes": {
						"wrapClassName": ["service-builder-footer-wrapper"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "ActionButtonsContainer",
				"parentName": "QuickSetupWindowWrapper",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"classes": {"wrapClassName": ["service-builder-action-buttons-wrapper"]}
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"name": "SaveButton",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.SaveButtonCaption"},
					"click": {"bindTo": "save"},
					"visible": {"bindTo": "canSave"}
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"name": "NextButton",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"caption": {"bindTo": "Resources.Strings.NextButtonCaption"},
					"click": "$parse",
					"visible": "$isInputDataMode"
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"index": 3,
				"name": "CancelButton",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": {"bindTo": "getCancelButtonStyle"},
					"caption": {"bindTo": "getCancelButtonCaption"},
					"click": {"bindTo": "close"},
					"visible": "$canClose"
				}
			},
			{
				"operation": "insert",
				"parentName": "ActionButtonsContainer",
				"propertyName": "items",
				"name": "BackButton",
				"index": 2,
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": {"bindTo": "getBackButtonStyle"},
					"caption": {"bindTo": "Resources.Strings.BackButtonCaption"},
					"click": {"bindTo": "back"},
					"visible": {"bindTo": "canGoBack"}
				}
			},
			{
				"operation": "insert",
				"name": "InputDataContainer",
				"parentName": "FooterContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": "$isInputDataMode",
					"classes": {
						"wrapClassName": ["service-builder-input-container"]
					}
				}
			},
			{
				"operation": "insert",
				"propertyName": "items",
				"name": "InputData",
				"parentName": "InputDataContainer",
				"values": {
					"contentType": BPMSoft.ContentType.RICH_TEXT,
					"generator": "SourceCodeEditGenerator.generate",
					"id": "InputData",
					"useWorker": false,
					"markerValue": "InputData",
					"enableLiveAutocompletion": false,
					"focused": "$InputDataFocused"
				}
			},
			{
				"operation": "insert",
				"name": "MethodSetupContainer",
				"parentName": "FooterContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": "$isMethodSetupMode"
				}
			},
			{
				"operation": "insert",
				"name": "ParametersContainer",
				"parentName": "MethodSetupContainer",
				"propertyName": "items",
				"values": {
					"className": "BPMSoft.LazyContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": ["service-method-builder-parameters"],
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ParametersContainer",
				"name": "ServiceMethodBuilderRequestParameters",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"classes": {"wrapClass": []},
					"visible": "$SetupRequestParameters"
				}
			},
			{
				"operation": "insert",
				"parentName": "ParametersContainer",
				"name": "ServiceMethodBuilderResponseParameters",
				"propertyName": "items",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.MODULE,
					"classes": {"wrapClass": []},
					"visible": "$SetupResponseParameters"
				}
			},
			{
				"operation": "insert",
				"name": "MethodSetupResultContainer",
				"parentName": "FooterContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"items": [],
					"visible": {"bindTo": "isMethodSetupResultMode"}
				}
			},
			{
				"operation": "insert",
				"name": "ResultBubble",
				"parentName": "MethodSetupResultContainer",
				"propertyName": "items",
				"values": {
					"getSrcMethod": "getImage",
					"readonly": true,
					"classes": {"wrapClass": ["bubble-image-panel"]},
					"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
				}
			},
			{
				"operation": "insert",
				"parentName": "MethodSetupResultContainer",
				"propertyName": "items",
				"name": "ResultTextContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {
						"wrapClassName": ["border-container"]
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "MethodSetupResultInfoLine1",
				"parentName": "ResultTextContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"labelConfig": {
						"caption": "$ResultMessage"
					},
					"classes": {
						"labelClass": ["result"]
					}
				}
			},
			{
				"operation": "insert",
				"name": "MethodSetupResultInfoLine2",
				"parentName": "ResultTextContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"labelConfig": {
						"caption": "$ResultMessagePart2"
					},
					"classes": {
						"labelClass": ["result-message", "result"]
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
