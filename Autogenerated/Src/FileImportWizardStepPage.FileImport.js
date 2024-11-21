define("FileImportWizardStepPage", ["FileImportServiceRequest"], function() {
	return {
		attributes: {
			/**
			 * Import session unique identifier.
			 */
			"ImportSessionId": {
				dataValueType: BPMSoft.DataValueType.GUID
			},
			/**
			 * Next step page name.
			 */
			NextStepPageName: {
				dataValueType: BPMSoft.DataValueType.TEXT
			}
		},
		messages: {
			/**
			 * Publish message for current step change.
			 */
			"CurrentStepChange": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"CancelWizard": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},

			"NextStepButtonEnabled": {
				mode: this.BPMSoft.MessageMode.PTP,
				direction: this.BPMSoft.MessageDirectionType.PUBLISH
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * Returns request to FileImportService.
			 * @private
			 * @param {Object} requestConfig Configuration for service request.
			 * @param {String} requestConfig.contractName Contract name.
			 * @param {String} requestConfig.importSessionId Import session identifier.
			 */
			getRequest: function(requestConfig) {
				return this.Ext.create(BPMSoft.configuration.fileImport.FileImportServiceRequest,
						requestConfig);
			},

			/**
			 * Sends request to FileImportService.
			 * @private
			 * @param {Object} requestConfig Configuration for service request.
			 * @param {String} requestConfig.contractName Contract name.
			 * @param {String} requestConfig.importSessionId Import session identifier.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Callback execution scope.
			 */
			sendRequest: function(requestConfig, callback, scope) {
				var request = this.getRequest(requestConfig);
				request.execute(function(response) {
					this.processResponse(response, callback, scope);
				}, this);
			},

			/**
			 * Processes response.
			 * @private
			 * @param {BPMSoft.core.BaseResponse} response Response.
			 * @param {Boolean} response.sucess Request result.
			 * @param {Object} response.errorInfo Request error information.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Callback execution scope.
			 */
			processResponse: function(response, callback, scope) {
				if (response && !response.success) {
					this.logRequestError(response.errorInfo);
					this.showInformationDialog(response.errorInfo.message);
					return;
				}
				callback.call(scope, response);
			},

			/**
			 * Initializes import parameters.
			 * @private
			 * @param {Function} callback Callback.
			 * @param {BPMSoft.core.BaseResponse} callback.response Server response.
			 * @param {Array} callback.response.Columns Import columns.
			 * @param {Object} scope Context for callback function execution.
			 */
			getImportParameters: function(callback, scope) {
				var importSessionId = this.get("ImportSessionId");
				var config = {
					contractName: "GetColumnsMappingParameters",
					importSessionId: importSessionId
				};
				this.sendRequest(config, callback, scope);
			},

			/**
			 * Sets column mapping parameters.
			 * @private
			 * @param {Array} columns Import schema columns.
			 * @param {Function} callback Callback.
			 * @param {Object} scope Callback execution scope.
			 */
			setColumnsMappingParameters: function(columns, callback, scope) {
				var importSessionId = this.get("ImportSessionId");
				var config = {
					contractName: "SetColumnsMappingParameters",
					importSessionId: importSessionId,
					columns: columns
				};
				this.sendRequest(config, callback, scope);
			},

			/**
			 * Scrolls page to top.
			 */
			scrollToTop: function() {
				var body = this.Ext.getBody();
				body.dom.scrollTop = 0;
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BPMSoft.BaseWizardStepPage#getSubscribersTags
			 * @overridden
			 */
			getSubscribersTags: function() {
				var parentSubscribersTags = this.callParent();
				parentSubscribersTags.push("ViewModule_FileImportWizardHeaderModule");
				return parentSubscribersTags;
			},

			/**
			 * Returns validation result.
			 * @protected
			 * @virtual
			 * @return {Boolean}
			 */
			getValidationResult: function() {
				return true;
			},

			/**
			 * Returns saving result.
			 * @protected
			 * @virtual
			 * @return {Boolean}
			 */
			getSavingResult: function() {
				return true;
			},

			/**
			 * Initializes import session.
			 * @virtual
			 * @protected
			 */
			initImportSession: function() {
				var historyStateInfo = this.getStateInfo();
				var importSessionId = historyStateInfo.primaryColumnValue;
				if (!importSessionId) {
					var message = this.get("Resources.Strings.EmptyImportSessionIdMessage");
					this.showInformationDialog(message);
					throw new BPMSoft.NullOrEmptyException({
						message: message
					});
				}
				this.set("ImportSessionId", importSessionId);
			},

			/**
			 * Sets import session info parameters.
			 * @protected
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Scope of callback function.
			 */
			setImportSessionInfoParameters: function(callback, scope) {
				var isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
				if (!isGoogleTagManagerEnabled) {
					callback.call(scope);
					return;
				}
				var importSessionId = this.get("ImportSessionId");
				var config = {
					contractName: "GetImportSessionInfo",
					importSessionId: importSessionId
				};
				this.sendRequest(config, function(response) {
					this.set("TotalRowsCount", response.totalRowsCount);
					this.set("ImportObject", response.importObject);
					callback.call(scope);
				}, this);
			},

			/**
			 * Logs error message.
			 * @private
			 * @param {Object} errorInfo Error information.
			 * @param {BPMSoft.LogMessageType} [type=BPMSoft.LogMessageType.ERROR] Log message type.
			 */
			logRequestError: function(errorInfo, type) {
				var message = this.getRequestErrorMessage(errorInfo);
				var messageType = (this.Ext.isEmpty(type)) ? this.BPMSoft.LogMessageType.ERROR : type;
				this.log(message, messageType);
			},

			/**
			 * Gets error message.
			 * @private
			 * @param {Object} errorInfo Error information.
			 * @return Error message.
			 */
			getRequestErrorMessage: function(errorInfo) {
				var template = "{0}: {1}\n{2}";
				return this.Ext.String.format(template, errorInfo.errorCode, errorInfo.message, errorInfo.stackTrace);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			initializeProfile: function(callback, scope) {
				callback.call(scope);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			initTypeColumnName: BPMSoft.emptyFn,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#initGoogleTagManager
			 * @protected
			 * @overridden
			 */
			initGoogleTagManager: function(callback, scope) {
				this.callParent([
					function() {
						var isGoogleTagManagerEnabled = this.get("IsGoogleTagManagerEnabled");
						if (!isGoogleTagManagerEnabled) {
							callback.call(scope);
							return;
						}
						var key = this.get("ImportSessionId") + this.name;
						this.BPMSoft.require(["profile!" + key], function(profile) {
							if (profile && profile.isVisited) {
								this.set("IsGoogleTagManagerEnabled", false);
								this.setImportSessionInfoParameters(callback, scope);
								return;
							}
							this.BPMSoft.saveUserProfile(key, {isVisited: true}, false, function() {
								this.setImportSessionInfoParameters(callback, scope);
							}, this);
						}, this);
					}, this
				]);
			},

			/**
			 * @inheritdoc BPMSoft.BaseSchemaViewModel#getGoogleTagManagerData
			 * @protected
			 * @overridden
			 */
			getGoogleTagManagerData: function() {
				var data = this.callParent(arguments);
				this.Ext.apply(data, {
					primaryColumnValue: this.get("ImportSessionId")
				});
				this.applyImportSessionInfoParameters(data);
				return data;
			},

			/**
			 * Applies import session info parameters ot data.
			 * @protected
			 * @virtual
			 * @param {Object} data Google tag manager data.
			 */
			applyImportSessionInfoParameters: function(data) {
				var importObject = this.get("ImportObject");
				this.Ext.apply(data, {
					totalRowsCount: this.get("TotalRowsCount"),
					importObjectName: importObject.name
				});
			},

			//endregion

			//region Methods: Public

			/**
			 * Returns state info processed from history state.
			 * When schemas list contains more than one element, sets it to the primaryColumnValue property.
			 * Strange logic inside.
			 * @return {Object} History state info object.
			 */
			getStateInfo: function() {
				const stateInfo = this.getHistoryStateInfo();
				const stateSchemas = stateInfo.schemas;
				if (stateSchemas && stateSchemas.length > 1) {
					stateInfo.primaryColumnValue = stateSchemas.pop();
				}
				return stateInfo;
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			init: function() {
				this.initImportSession();
				this.callParent(arguments);
				this.sandbox.registerMessages(this.messages);
			},

			/**
			 * @inheritdoc
			 * @overridden
			 */
			onRender: function() {
				this.scrollToTop();
				this.callParent(arguments);
			},

			/**
			 * Returns next button caption.
			 * @return {String}
			 */
			getNextButtonMarkerValue: function() {
				return "LowerNextButton";
			},

			/**
			 * Handles next button click.
			 * @virtual
			 */
			onNextButtonClick: function() {
				this.switchToNextStep();
			},

			closeButtonClick: function() {
				this.sandbox.publish("CancelWizard", null, this.getSubscribersTags());
			},

			/**
			 * Initiates switch to a next page.
			 */
			switchToNextStep: function() {
				this.sandbox.publish("CurrentStepChange", this.get("NextStepPageName"), this.getSubscribersTags());
			},

			nextButtonEnabled: function(){				
				var nextPageName=this.get("NextStepPageName");
				var saveFile=this.get("SaveFileResult");
				if(saveFile){
					this.sandbox.publish("NextStepButtonEnabled", saveFile);
				}
				if(saveFile || nextPageName!=="FileImportColumnsMappingPage"){					
					return true;
				}

				this.sandbox.publish("NextStepButtonEnabled", false);
				return false;				
			}
		},
		diff: [
			{
				"operation": "insert",
				"name": "MainContainer",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generateId": false,
					"classes": {"wrapClassName": ["main-container"]},
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
					"generateId": false,
					"classes": {"wrapClassName": ["header-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "HeaderLabelContainer",
				"parentName": "HeaderContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generateId": false,
					"classes": {"wrapClassName": ["header-label-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "HeaderLabel",
				"parentName": "HeaderLabelContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"caption": {"bindTo": "Resources.Strings.Header"},
					"classes": {"labelClass": ["header-label"]}
				}
			},
			{
				"operation": "insert",
				"name": "CenterContainer",
				"parentName": "MainContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generateId": false,
					"classes": {"wrapClassName": ["center-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "FooterContainer",
				"parentName": "MainContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generateId": false,
					"classes": {"wrapClassName": ["footer-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "BottomActionsContainer",
				"parentName": "CenterContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"generateId": false,
					"classes": {"wrapClassName": ["bottom-actions-container"]},
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "NextButton",
				"parentName": "BottomActionsContainer",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
					"generateId": false,
					"classes": {
						"textClass": ["file-import-next-footer-button"],
					},
					"enabled": {"bindTo": "nextButtonEnabled"},
					"click": {"bindTo": "onNextButtonClick"},
					"caption": {"bindTo": "Resources.Strings.NextButtonCaption"},
					"markerValue": {"bindTo": "getNextButtonMarkerValue"}
				}
			},			
			{
				"operation": "insert",
				"name": "CloseButton",
				"parentName": "FooterContainer",
				"propertyName": "items",
				"index": 0,
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"generateId": false,
					"click": {"bindTo": "closeButtonClick"},
					"caption": {"bindTo": "Resources.Strings.CloseButton"},
					"classes": {
						"textClass": ["close-footer-button"],
						"wrapperClass": ["close-footer-button"]
					},
					"markerValue": {"bindTo": "CloseButton"}
				}
			},

		]
	};
});
