define("BpCloudIntegrationPageV2", ["EmailHelperModule", "BpmCrmCloudServiceApi",
			"BpCloudIntegrationEnums", "ServiceHelper", "SecurityUtilities", "ContextHelpMixin",
			"AcademyUtilities", "MultilineLabel", "SendingDomainsDetailV2",
			 "css!MultilineLabel", "css!BpCloudIntegrationPageV2CSS"],
		function(EmailHelperModule) {
			/** @enum
			 * System email status */
			SystemEmailStatus = {
				Checked: 1,
				CheckFailed: 2
			};
			return {
				messages: {
					/**
					 * @message GetSenderDomainsInfo
					 * Gets the sender domains info.
					 */
					"GetSenderDomainsInfo": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					/**
					 * @message DomainSelected
					 * Domain selected.
					 */
					"DomainSelected": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				},
				details: {
					"MailingProviders": {
						schemaName: "MailingProvidersDetail"
					},
					"SenderDomains": {
						schemaName: "SendingDomainsDetailV2"
					},
					"ProviderSenderDomains": {
						schemaName: "ProviderSenderDomainsDetail"
					}
				},
				mixins: {
					SecurityUtilitiesMixin: "BPMSoft.SecurityUtilitiesMixin",
					ContextHelpMixin: "BPMSoft.ContextHelpMixin"
				},
				attributes: {
					"IsInitializingAttributes": {
						"value": false,
						"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Domain to receive responses.
					 */
					"WebHooks": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					"MaskConfig": {
						"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						"value": {uniqueMaskId: this.BPMSoft.generateGUID()}
					},
					"CloudEmailServiceName": {
						"value": "CloudEmailService"
					},
					/**
					 * Value of DKIM setup script.
					 */
					"DKIMScript": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Value of DKIM setup script template.
					 */
					"DKIMScriptTemplate": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Value of the default DKIM key.
					 */
					"DefaultDKIMKey": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Value of the default Spf key.
					 */
					"DefaultSpfKey": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Value of SPF setup script.
					 */
					"SPFScript": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Value of Mx setup script.
					 */
					"MxScript": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Value of DMARC setup script.
					 */
					"DMARCScript": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Value of additional settings script.
					 */
					"AdditionalSettingsScript": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Template of additional settings script.
					 */
					"AdditionalSettingsScriptTemplate": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Additional settings area caption.
					 */
					"AdditionalSettingsCaption": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Caption of the "Setup Instructions" control group.
					 */
					"SetupInstructionsControlGroupCaption": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Returns true if container of the setup instructions is collapsed.
					 */
					"IsSetupInstructionsCollapsed": {
						"value": true,
						"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Url of the academy page.
					 */
					"AcademyUrl": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Name of email service provider.
					 */
					"EmailServiceProvider": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Time to stop parsing webhooks.
					 */
					"DoNotParseFrom": {
						"dataValueType": this.BPMSoft.DataValueType.TIME,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Time to start parsing webhooks.
					 */
					"DoNotParseTo": {
						"dataValueType": this.BPMSoft.DataValueType.TIME,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Cloud service API key.
					 */
					"ApiKey": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Cloud service auth key.
					 */
					"AuthKey": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Cloud services connection URL.
					 */
					"CloudConnectionUrl": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Returns true if cloud is available with given URL and API key.
					 */
					"CloudConnectionStatus": {
						"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Message that indicates cloud availability.
					 */
					"CloudConnectionStatusCaption": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Detailed cloud service connection error message.
					 */
					"CloudConnectionStatusErrorMessage": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Dom-attribute that is added to control that indicated state of cloud.
					 */
					"CloudConnectionStatusDomAttribute": {
						"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Returns true if domain to receive web hooks is available.
					 */
					"WebhooksConnectionStatus": {
						"dataValueType": this.BPMSoft.DataValueType.BOOLEAN,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Message that indicated web hook URL availability.
					 */
					"WebhooksConnectionStatusCaption": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * System email value.
					 */
					"SystemEmail": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * System email status value.
					 */
					"SystemEmailStatus": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Dom-attribute that is added to control that indicates system email status.
					 */
					"SystemEmailStatusDomAttribute": {
						"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Detailed web hook url connection error message.
					 */
					"WebhooksConnectionStatusErrorMessage": {
						"dataValueType": this.BPMSoft.DataValueType.TEXT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					},
					/**
					 * Dom-attribute that is added to control that indicated state of web hook URL.
					 */
					"WebhooksConnectionStatusDomAttribute": {
						"dataValueType": this.BPMSoft.DataValueType.CUSTOM_OBJECT,
						"type": this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
					}
				},
				methods: {
					_initMx: function(domain) {
						var mxKey = this.getObjectPropertyByName(domain, "Mx", "");
						var mxConfig = {mxValue: mxKey};
						this.updateMxScript(mxConfig);
					},

					_initSPF: function(domainsInfo, domain) {
						var defaultSpf = this.getObjectPropertyByName(domainsInfo, "SpfValue", "");
						this.set("DefaultSpfKey", defaultSpf);
						var spfKey = this.getObjectPropertyByName(domain, "SpfKey", defaultSpf);
						var spfConfig = {spfValue: spfKey};
						this.updateSPFScript(spfConfig);
					},

					_initAdditionalSettings: function(domainsInfo, domain) {
						var domainValidationRecord = this.getObjectPropertyByName(domainsInfo, "DomainValidationRecord", "");
						this.set("AdditionalSettingsScriptTemplate", domainValidationRecord);
						var domainValue = this.getObjectPropertyByName(domain, "Domain", "");
						var captionConfig = {domain: domainValue};
						this.updateAdditionalSettingsScript(captionConfig);
					},

					_initDMARC: function(domainsInfo) {
						var dmarcScript = this.getObjectPropertyByName(domainsInfo, "DmarcValue", "");
						this.set("DMARCScript", dmarcScript);
					},

					_initDKIM: function(domainsInfo, domain) {
						var dkimsSriptTemplate = this.getObjectPropertyByName(domainsInfo, "DKIMRecord",
							this.get("Resources.Strings.DKIMScriptTemplate"));
						var defaultDKIMKey = this.getObjectPropertyByName(domainsInfo, "DefaultDKIMKey", "");
						this.set("DKIMScriptTemplate", dkimsSriptTemplate);
						this.set("DefaultDKIMKey", defaultDKIMKey);
						var dkimConfig = {dkimKey: this.getObjectPropertyByName(domain, "Key", this.get("DefaultDKIMKey"))};
						this.updateDKIMScript(dkimConfig);
					},

					_initSetupInstructionsCaption: function(domain) {
						if(domain) {
							var captionConfig = {domain: this.getObjectPropertyByName(domain, "Domain", "")};
							this.updateSetupInstructionsCaption(captionConfig);
						} else {
							var defCaption = this.get("Resources.Strings.SetupInstructionsDefaultCaption");
							this.set("SetupInstructionsControlGroupCaption", defCaption);
						}
					},

					_getAdditionalSettingsAcademyUrl: function(callback, scope) {
						var academyConfig = {
							contextHelpId: "1976",
							scope: this,
							callback: function(url) {
								var captionTemplate = this.get("Resources.Strings.AdditionalSettingsCaption");
								this.$AdditionalSettingsCaption = Ext.String.format(captionTemplate, url);
								callback.call(scope);
							}
						};
						BPMSoft.AcademyUtilities.getUrl(academyConfig);
					},

					/**
					 * Clean viewModel changedValues field.
					 * @private
					 */
					clearChangedValues: function() {
						this.changedValues = {};
					},

					/**
					 * Returns true if feature FromEmailFromNameMacros is enabled.
					 * @private
					 * @returns {Boolean} True if feature FromEmailFromNameMacros is enabled.
					 */
					_getFromEmailFromNameMacrosEnabled: function() {
						return this.BPMSoft.Features.getIsEnabled("FromEmailFromNameMacros");
					},

					/**
					 * Validates system email.
					 * @private
					 * @return {Object} Returns validation result.
					 */
					_systemEmailValidator: function() {
						var validationMessage = "";
						var systemEmail = this.$SystemEmail;
						if (Ext.isEmpty(systemEmail)) {
							validationMessage = this.get("Resources.Strings.FieldEmptyValidationMessage");
							this._setSystemEmailStatus(SystemEmailStatus.CheckFailed);
							return this._getValidationResult(validationMessage);
						}
						if (!EmailHelperModule.isEmailValid(systemEmail)) {
							validationMessage = this.get("Resources.Strings.InvalidEmailErrorMessage");
							this._setSystemEmailStatus(SystemEmailStatus.CheckFailed);
							return this._getValidationResult(validationMessage);
						}
						return this._getValidationResult(validationMessage);
					},

					/**
					 * Gets validation message result.
					 * @param {String} shortMessage Message for tool tip.
					 * @param {String} fullMessage Message for message box.
					 * @returns {{fullInvalidMessage: *, invalidMessage: *}}
					 * @private
					 */
					_getValidationResult: function(shortMessage, fullMessage) {
						return {
							fullInvalidMessage: shortMessage,
							invalidMessage: fullMessage ? fullMessage : shortMessage
						};
					},

					/**
					 * Sets system emails status and related dom attribute.
					 * @param {BPMSoft.SystemEmailStatus} status System email status.
					 * @private
					 */
					_setSystemEmailStatus: function(status) {
						switch(status) {
							case SystemEmailStatus.Checked: {
								this.$SystemEmailStatus = this.get("Resources.Strings.EmailCheckedStatusCaption");
								this.$SystemEmailStatusDomAttribute = {
									"check-email-status": "checked"
								};
								break;
							}
							case SystemEmailStatus.CheckFailed: {
								this.$SystemEmailStatus = this.get("Resources.Strings.EmailCheckFailedStatusCaption");
								this.$SystemEmailStatusDomAttribute = {
									"check-email-status": "check-failed"
								};
								break;
							}
							default:
								break;
						}
					},

					/**
					 * Sets email verification status by email verification service response.
					 * @param {Object} responseData Response DTO.
					 * @param {Boolean} isSuccess Indicates whether service call was successful.
					 * @private
					 */
					_processEmailCheckingResponse: function(responseData, isSuccess) {
						if (!isSuccess || !responseData.GetCheckedEmails) {
							if (!this.$IsInitializingAttributes) {
								this._setSystemEmailStatus(SystemEmailStatus.CheckFailed);
								this.showInformationDialog(this.get("Resources.Strings.UnableToConnectToCesError"));
								this.$IsInitializingAttributes = false;
							}
							return;
						}
						var responseResult = responseData.GetCheckedEmails.result;
						var sysEmailData = responseResult.find(function(emailData) {
							return emailData.email === this.$SystemEmail;
						}, this);
						var emailChecked = sysEmailData && sysEmailData.is_checked;
						var emailStatus = emailChecked ? SystemEmailStatus.Checked : SystemEmailStatus.CheckFailed;
						if (emailStatus === SystemEmailStatus.CheckFailed && !this.$IsInitializingAttributes) {
							var template = this.get("Resources.Strings.GetCheckedEmailFailedErrorMessage");
							var email = (sysEmailData && sysEmailData.email) || this.$SystemEmail;
							var emailDomain = email.replace(/.*@/, "");
							var message = Ext.String.format(template, email, emailDomain);
							this.showInformationDialog(message);
						}
						this.$IsInitializingAttributes = false;
						this._setSystemEmailStatus(emailStatus);
					},

					_showInformationMessage: function(template, value) {
						var message = template;
						if (value) {
							message = Ext.String.format(template, value);
						}
						this.showInformationDialog(message);
					},

					_getIsMxVisible: function() {
						return Boolean(this.$MxScript);
					},

					_getIsDkimVisible: function() {
						return Boolean(this.$DKIMScript);
					},

					_getIsSpfVisible: function() {
						return Boolean(this.$SPFScript);
					},

					_getIsDmarcVisible: function() {
						return Boolean(this.$DMARCScript);
					},

					_getIsAdditionalSettingsVisible: function() {
						return Boolean(this.$AdditionalSettingsScript);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#initTabs
					 * @overridden
					 */
					initTabs: function() {
						if (!this.getBulkEmailUXEnabled()) {
							var tabsCollection = this.get("TabsCollection");
							tabsCollection.removeByKey("TabSenderDomains");
						}
						this.callParent(arguments);
					},

					/**
					 * @inheritdoc BPMSoft.PrintReportUtilities#initCardPrintForms
					 * @overridden
					 */
					initCardPrintForms: function() {
						this.set("IsCardPrintButtonVisible", false);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#initActionButtonMenu
					 * @overridden
					 */
					initActionButtonMenu: function() {
						this.set("ActionsButtonVisible", false);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getPageHeaderCaption
					 * @overridden
					 */
					getPageHeaderCaption: function() {
						return this.getHeader();
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getPageHeaderCaption
					 * @overridden
					 */
					getHeader: function() {
						return this.get("Resources.Strings.PageHeaderTemplate");
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#save
					 * @overridden
					 */
					save: function() {
						var data = this.getSaveConfig();
						this.showBodyMask(this.get("MaskConfig"));
						this.saveSysSettingsValuesIfChanged(function() {
							this.BPMSoft.BpmCrmCloudServiceApi.updateUserSettings(data, this.onSaveResponse, this);
						}, this);
					},

					/**
					 * Returns key value pair of changed system settings and their values.
					 * @private
					 * @return {Object} Changed system setting code as object keys and new values as object values.
					 */
					getChangedSysSettingsValues: function() {
						var settingsToFieldsMap = this.getSysSettingsToFieldsMap();
						var sysSettingsData = {};
						var codes = settingsToFieldsMap.getKeys();
						this.BPMSoft.each(codes, function(sysSettingsCode) {
							var attributeName = settingsToFieldsMap.get(sysSettingsCode);
							if (this.changedValues && (attributeName in this.changedValues)) {
								sysSettingsData[sysSettingsCode] = this.get(attributeName);
							}
						}, this);
						return sysSettingsData;
					},

					/**
					 * Updates changed system properties.
					 * @private
					 */
					saveSysSettingsValuesIfChanged: function(callback, scope) {
						var sysSettingsData = this.getChangedSysSettingsValues();
						this.BPMSoft.SysSettings.postSysSettingsValues({
							sysSettingsValues: sysSettingsData
						}, callback || Ext.emptyFn, scope || this);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#init
					 * @overridden
					 */
					init: function(callback, scope) {
						var tabsCollection = this.get("TabsCollection");
						if (!this.getIsEspSelectionFeatureEnabled()) {
							tabsCollection.removeByKey("TabEspManagements");
						};
						this.callParent([function() {
							this.showBodyMask(this.get("MaskConfig"));
							BPMSoft.BpmCrmCloudServiceApi.accountInfo(this.onInitResponse, this);
							this._initSetupInstructionsCaption();
							this.getAcademyUrl(function() {
								this.initSenderDomainsHelpText();
								this._getAdditionalSettingsAcademyUrl(callback, scope);
							}, this);
						}, this]);
					},

					/**
					 * @inheritDoc BasePageV2#onEntityInitialized
					 * @overridden
					 */
					onEntityInitialized: function(callback, scope) {
						this.callParent(arguments);
						this._initAttributesFromSysSettings(this.onAttributesLoaded, this);
					},

					/**
					 * Handles whether all page attributes are loaded.
					 * @protected
					 */
					onAttributesLoaded: function() {
						this.clearChangedValues();
						if (this._getFromEmailFromNameMacrosEnabled()) {
							this.$IsInitializingAttributes = true;
							this.checkEmailStatus(false);
						}
					},

					/**
					 * Initializes attributes form system setting values.
					 * @private
					 */
					_initAttributesFromSysSettings: function(callback, scope) {
						var settingsToFieldsMap = this.getSysSettingsToFieldsMap();
						var codes = settingsToFieldsMap.getKeys();
						this.BPMSoft.SysSettings.querySysSettings(codes, function(settingsQueryResult) {
							this.BPMSoft.each(settingsQueryResult || {}, function(settingValue, settingName) {
								var attributeName = settingsToFieldsMap.get(settingName);
								this.set(attributeName, settingValue);
							}, this);
							this.Ext.callback(callback, scope);
						}, this);
					},

					/**
					 * Returns map of system setting names to attribute names.
					 * @private
					 * @returns {BPMSoft.Collection} Collection with system settings names as keys and attribute names
					 * as values.
					 */
					getSysSettingsToFieldsMap: function() {
						var map = Ext.create("BPMSoft.Collection");
						map.add("CloudServicesAPIKey", "ApiKey");
						map.add("CloudServicesAuthKey", "AuthKey");
						map.add("CloudServicesBaseUrl", "CloudConnectionUrl");
						map.add("StartHandleWebHookProcessAt", "DoNotParseTo");
						map.add("StopHandleWebHookProcessAt", "DoNotParseFrom");
						map.add("DefaultESPEmail", "SystemEmail");
						return map;
					},

					/**
					 * Returns config object for service availability indicator control.
					 * @private
					 * @param {Boolean} status Service availability status.
					 * @return {Object} Config object for service availability indicator control.
					 */
					getConnectionStatusConfig: function(status) {
						var config = {};
						if (status) {
							config = {
								caption: this.get("Resources.Strings.ConnectedCaption"),
								attribute: {
									"data-connection-status": "connected"
								}
							};
						} else {
							config = {
								caption: this.get("Resources.Strings.DisconnectedCaption"),
								attribute: {
									"data-connection-status": "disconnected"
								}
							};
						}
						return config;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#subscribeDetailEvents
					 * @overridden
					 */
					subscribeDetailEvents: function(detailConfig, detailName) {
						this.callParent(arguments);
						if (this.getBulkEmailUXEnabled()) {
							var detailId = this.getDetailId(detailName);
							this.sandbox.subscribe("GetSenderDomainsInfo", this.onGetSenderDomainsInfoMessage,
								this, [detailId]);
							this.sandbox.subscribe("DomainSelected", this.onDomainSelected,
								this, [detailId]);
						}
					},

					/**
					 * Handles call for "SenderDomainsInfo" message.
					 * @param {Function} config.callback Callback function.
					 * @param {Object} config.scope Execution context.
					 */
					onGetSenderDomainsInfoMessage: function(config) {
						if (this.Ext.isObject(config)) {
							this.getSenderDomainsInfo(config.callback, config.scope, config.providerName);
						}
					},

					/**
					 * Gets the sender domains info.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 * @param {String} providerName Name of provider.
					 */
					getSenderDomainsInfo: function(callback, scope, providerName) {
						if (!providerName) {
							BPMSoft.BpmCrmCloudServiceApi.senderDomainsInfo(function(response) {
								this.onSenderDomainsInfoResponse(response);
								this.Ext.callback(callback, scope, [response.DomainsInfo]);
							}, this);
						} else {
							var data = {
								"senderDomainsInfoRequest" : {
									"providerName": providerName
								}
							};
							BPMSoft.BpmCrmCloudServiceApi.getSenderDomainsInfoByProvider(data, function(response) {
								this.onSenderDomainsInfoResponse(response);
								this.Ext.callback(callback, scope, [response.DomainsInfo]);
							}, this);
						}
					},

					/**
					 * On save response handler.
					 * @private
					 * @param {Object} response Web service response.
					 */
					onSaveResponse: function(response) {
						this.baseProcessResponse(response.AccountInfo, this.onSaveSuccess, this.onSaveError);
					},

					/**
					 * On account info response handler.
					 * @private
					 * @param {Object} response Web service response.
					 */
					onAccountInfoResponse: function(response) {
						this.baseProcessResponse(response.AccountInfo, this.onAccountInfoSuccess,
							this.onAccountInfoError);
					},

					/**
					 * On init response handler.
					 * @private
					 * @param {Object} response Web service response.
					 */
					onInitResponse: function(response) {
						this.baseProcessResponse(response.AccountInfo, this.onInitSuccess, this.onInitError);
					},

					/**
					 * On domain info response handler.
					 * @private
					 * @param {Object} response Web service response.
					 */
					onSenderDomainsInfoResponse: function(response) {
						this.baseProcessResponse(
							response.DomainsInfo, this.onSenderDomainsInfoSuccess, this.onSenderDomainsInfoError);
					},

					/**
					 * On "save" success handler.
					 * @private
					 * @param {Object} accountInfo Account information.
					 */
					onSaveSuccess: function(accountInfo) {
						this.set("CloudConnectionStatus", true);
						this.set("WebhooksConnectionStatus", true);
						var authKey = this.get("AuthKey");
						if (!authKey) {
							this.set("WebhooksConnectionStatus", false);
							this.set("WebhooksConnectionStatusErrorMessage",
								this.get("Resources.Strings.WrongAuthKeyMessage"));
						}
						var isMailingEnabled = this.getMailingServiceIsActive(accountInfo);
						if (!isMailingEnabled) {
							this.set("CloudConnectionStatus", false);
							this.set("WebhooksConnectionStatus", false);
							this.set("CloudConnectionStatusErrorMessage",
								this.get("Resources.Strings.MailingServiceInActive"));
							this.set("WebhooksConnectionStatusErrorMessage",
								this.get("Resources.Strings.MailingServiceInActive"));
						}
						var providerName = this.getProviderName(accountInfo);
						this.set("EmailServiceProvider", providerName);
						this.initCloudConnectionStatusProperties();
						this.initWebhooksConnectionStatusProperties();
						this.updateButtonsVisibility(false, {force: true});
					},

					/**
					 * On "save" error handler.
					 * @private
					 * @param {String} errorMessage Error message.
					 */
					onSaveError: function(errorMessage) {
						this.set("WebhooksConnectionStatus", false);
						this.set("WebhooksConnectionStatusErrorMessage", errorMessage);
						this.initWebhooksConnectionStatusProperties();
						this.showBodyMask(this.get("MaskConfig"));
						this.BPMSoft.BpmCrmCloudServiceApi.accountInfo(this.onAccountInfoResponse, this);
					},

					/**
					 * Sets property WebhooksConnectionStatusErrorMessage basing on response from IntegrationStatus
					 * property of AccountInfo response.
					 * @private
					 * @param (Object) integrationStatus IntegrationStatus property of AccountInfo response.
					 */
					setWebHooksConnectedStatusErrorMessage: function(integrationStatus) {
						if (integrationStatus) {
							if (!integrationStatus.IsValidAuthKey) {
								var invalidAuthKeyMsg = this.get("Resources.Strings.WrongAuthKeyMessage");
								this.set("WebhooksConnectionStatusErrorMessage", invalidAuthKeyMsg);
							} else if (!integrationStatus.IsValidWebHookAppDomain) {
								var invalidWebHookAppDomainMsg =
									this.get("Resources.Strings.WrongWebHookDomainMessage");
								this.set("WebhooksConnectionStatusErrorMessage", invalidWebHookAppDomainMsg);
							}
						}
					},

					/**
					 * On "accountInfo" success handler.
					 * @private
					 * @param {Object} accountInfo Account information.
					 */
					onAccountInfoSuccess: function(accountInfo) {
						var providerName = this.getProviderName(accountInfo);
						providerName = providerName.localeCompare("UniOne", undefined, { sensitivity: 'accent' }) === 0 ?
							"Unisender Go" : providerName;
						this.set("EmailServiceProvider", providerName);
						this.set("CloudConnectionStatus", true);
						if (!this.getMailingServiceIsActive(accountInfo)) {
							this.set("CloudConnectionStatus", false);
							this.set("WebhooksConnectionStatus", false);
							this.set("CloudConnectionStatusErrorMessage",
								this.get("Resources.Strings.MailingServiceInActive"));
							this.set("WebhooksConnectionStatusErrorMessage",
								this.get("Resources.Strings.MailingServiceInActive"));
							this.initWebhooksConnectionStatusProperties();
						}
						this.initCloudConnectionStatusProperties();
						this.updateButtonsVisibility(false, {force: true});
					},

					/**
					 * On "init" success handler.
					 * @param {Object} accountInfo Web service response.
					 */
					onInitSuccess: function(accountInfo) {
						var webHookAppDomain = this.getObjectPropertyByName(accountInfo, "WebHookAppDomain", "");
						this.set("WebHooks", webHookAppDomain);
						var integrationStatus = this.getObjectPropertyByName(accountInfo, "IntegrationStatus", null);
						this.set("WebhooksConnectionStatus", integrationStatus && integrationStatus.IsValidAuthKey &&
							integrationStatus.IsValidWebHookAppDomain);
						this.setWebHooksConnectedStatusErrorMessage(integrationStatus);
						this.initWebhooksConnectionStatusProperties();
						this.onAccountInfoSuccess(accountInfo);
					},

					/**
					 * Initializes CloudConnectionStatusCaption and CloudConnectionStatusDomAttribute properties
					 * depending on CloudConnectionStatus value.
					 * @private
					 */
					initCloudConnectionStatusProperties: function() {
						var cloudConnectionStatus = this.get("CloudConnectionStatus");
						var cloudConnectionStatusConfig = this.getConnectionStatusConfig(cloudConnectionStatus);
						this.set("CloudConnectionStatusCaption", cloudConnectionStatusConfig.caption);
						this.set("CloudConnectionStatusDomAttribute", cloudConnectionStatusConfig.attribute);
					},

					/**
					 * Initializes WebhooksConnectionStatusCaption and WebhooksConnectionStatusDomAttribute properties
					 * depending on WebhooksConnectionStatus value.
					 * @private
					 */
					initWebhooksConnectionStatusProperties: function() {
						var webhooksConnectionStatus = this.get("WebhooksConnectionStatus");
						var webhooksConnectionStatusConfig = this.getConnectionStatusConfig(webhooksConnectionStatus);
						this.set("WebhooksConnectionStatusCaption", webhooksConnectionStatusConfig.caption);
						this.set("WebhooksConnectionStatusDomAttribute", webhooksConnectionStatusConfig.attribute);
					},

					/**
					 * Returns object that contains information about account services.
					 * @private
					 * @param {Object} accountInfo  Account information.
					 * @returns {Object} Object that contains information about account services.
					 */
					getMailingProvider: function(accountInfo) {
						var services = this.getObjectPropertyByName(accountInfo, "Services", null);
						if (!services) {
							return null;
						}
						var serviceNames = BPMSoft.BpCloudIntegration.enums.Service;
						return this.BPMSoft.findWhere(services, {"ServiceName": serviceNames.CloudEmailService});
					},

					/**
					 * Returns name of the current provider for the mailing service by recieved account information.
					 * @param {Object} accountInfo Account information.
					 * @returns {string} Provider's name.
					 */
					getProviderName: function(accountInfo) {
						var providerName = "";
						var service = this.getMailingProvider(accountInfo);
						if (service) {
							var settings = this.getObjectPropertyByName(service, "Settings", null);
							if (settings) {
								providerName = settings.Provider;
							}
						}
						return providerName;
					},

					/**
					 * Checks whether mailing service is enabled for account.
					 * private
					 * @param {Object} accountInfo Account information.
					 * @returns {Boolean} True if mailing service is enabled.
					 */
					getMailingServiceIsActive: function(accountInfo) {
						var service = this.getMailingProvider(accountInfo);
						return service && service.IsActive;
					},

					/**
					 * Returns value of the object property by name.
					 * @protected
					 * @param {Object} object Object.
					 * @param {String} propertyName Property name.
					 * @param {*} defaultValue Default value.
					 * @returns {*}
					 */
					getObjectPropertyByName: function(object, propertyName, defaultValue) {
						if (this.Ext.isObject(object) && object.hasOwnProperty(propertyName)) {
							return object[propertyName];
						}
						return defaultValue || null;
					},

					/**
					 * On "account info" error handler.
					 * @param {String} errorMessage Error message.
					 */
					onAccountInfoError: function(errorMessage) {
						this.set("CloudConnectionStatusErrorMessage", errorMessage);
						this.set("CloudConnectionStatus", false);
						this.initCloudConnectionStatusProperties();
						this.updateButtonsVisibility(false, {force: true});
					},

					/**
					 * On "init" error handler.
					 * @private
					 * @param {String} errorMessage Error message.
					 */
					onInitError: function(errorMessage) {
						this.set("WebhooksConnectionStatus", false);
						this.initWebhooksConnectionStatusProperties();
						this.onAccountInfoError(errorMessage);
					},

					/**
					 * Returns true if feature ESPSelection is enabled.
					 * @private
					 * @returns {Boolean} True if feature enabled.
					 */
					getIsEspSelectionFeatureEnabled: function() {
						return this.BPMSoft.Features.getIsEnabled("ESPSelection");
					},

					/**
					 * Returns true if SenderDomain detail visible.
					 * @private
					 * @returns {Boolean} True if detail enabled.
					 */
					getIsSenderDomainsDetailVisible: function() {
						return !this.getIsEspSelectionFeatureEnabled() && this.$CloudConnectionStatus;
					},

					/**
					 * Returns true if ProviderSenderDomain detail visible.
					 * @private
					 * @returns {Boolean} True if detail enabled.
					 */
					getIsProviderSenderDomainsDetailVisible: function() {
						return this.getIsEspSelectionFeatureEnabled() && this.$CloudConnectionStatus;
					},

					/**
					 * Returns inverted state of cloud connection.
					 * @private
					 * @returns {Boolean} True if connection failed.
					 */
					getIsCloudConnectionFailed: function() {
						return !this.$CloudConnectionStatus;
					},

					/**
					 * On "SenderDomainsInfo" success handler.
					 * @private
					 * @param {Object} domainInfo Web service response.
					 */
					onSenderDomainsInfoSuccess: function(domainInfo) {
						this.set("IsSetupInstructionsCollapsed", false);
						var domain = _.first(domainInfo.Domains);
						this._initDKIM(domainInfo, domain);
						this._initDMARC(domainInfo, domain);
						this._initSPF(domainInfo, domain);
						this._initAdditionalSettings(domainInfo, domain);
						this._initSetupInstructionsCaption(domain);
						this._initMx(domain);
					},

					/**
					 * Handles call for "DomainSelected" message.
					 * @param {BPMSoft.BaseViewModel} domain.
					 */
					onDomainSelected: function(domain) {
						var domainValue = {domain: domain.get("Domain")};
						var key = domain.get("Key") || this.get("DefaultDKIMKey");
						var dkimConfig = {dkimKey: key};
						var spfKey = domain.get("SpfKey") || this.get("DefaultSpfKey");
						var spfConfig = {spfValue: spfKey};
						var mxKey = domain.get("Mx");
						var mxConfig = {mxValue: mxKey};
						this.updateSPFScript(spfConfig);
						this.updateDKIMScript(dkimConfig);
						this.updateSetupInstructionsCaption(domainValue);
						this.updateAdditionalSettingsScript(domainValue);
						this.updateMxScript(mxConfig);
					},

					/**
					 * Updates caption of the "Setup instructions" group.
					 * @param {Object} config.
					 * @param {String} config.domain.
					 */
					updateSetupInstructionsCaption: function(config) {
						if (config && config.domain) {
							var captionTemplate = this.get("Resources.Strings.SetupInstructionsCaptionTemplate");
							var caption = this.Ext.String.format(captionTemplate, config.domain);
							this.set("SetupInstructionsControlGroupCaption", caption);
						} else {
							this._initSetupInstructionsCaption();
						}
					},

					/**
					 * Updates text of the Mx script.
					 * @param {Object} config.
					 * @param {String} config.mxValue.
					 */
					updateMxScript: function(config) {
						var mxScirpt = "";
						if (config && config.mxValue) {
							var mxScriptTemplate = this.get("Resources.Strings.MxScriptTemplate");
							mxScirpt = this.Ext.String.format(mxScriptTemplate, config.mxValue);
						}
						this.set("MxScript", mxScirpt);
					},

					/**
					 * Updates text of the SPF script.
					 * @param {Object} config.
					 * @param {String} config.spfValue.
					 */
					updateSPFScript: function(config) {
						var spfScirpt = "";
						if (config && config.spfValue) {
							var spfScriptTemplate = this.get("Resources.Strings.SPFScriptTemplate");
							spfScirpt = this.Ext.String.format(spfScriptTemplate, config.spfValue);
						}
						this.set("SPFScript", spfScirpt);
					},

					/**
					 * Updates text of the DKIM script.
					 * @param {Object} config.
					 * @param {String} config.dkimKey.
					 */
					updateDKIMScript: function(config) {
						var dkimScirpt = "";
						if (config && config.dkimKey) {
							var dkimScriptTemplate = this.get("DKIMScriptTemplate");
							dkimScirpt = this.Ext.String.format(dkimScriptTemplate, config.dkimKey);
						}
						this.set("DKIMScript", dkimScirpt);
					},

					/**
					 * Updates additional settings text script.
					 * @protected
					 * @param {Object} config Config with necessary parameters.
					 */
					updateAdditionalSettingsScript: function(config) {
						var template = this.get("AdditionalSettingsScriptTemplate");
						if (template && config.domain) {
							this.$AdditionalSettingsScript = Ext.String.format(template, config.domain);
						} else {
							this.$AdditionalSettingsScript = "";
						}
					},

					/**
					 * On "SenderDomainsInfo" error handler.
					 * @private
					 */
					onSenderDomainsInfoError: function() {
						this.set("IsSetupInstructionsCollapsed", false);
						this.updateDKIMScript();
						this.updateSPFScript();
						this.updateSetupInstructionsCaption();
						this.updateMxScript();
					},

					/**
					 * Base web service response handler.
					 * @private
					 * @param {Object} data Web service response.
					 * @param {Function} onSuccess Success response handler.
					 * @param {Function} onError Error response handler.
					 * @param {Object} scope Execution context.
					 */
					baseProcessResponse: function(data, onSuccess, onError, scope) {
						var errorMessage;
						var isError = true;
						var responseCode = BPMSoft.BpCloudIntegration.enums.ResponseCode;
						var api = BPMSoft.BpmCrmCloudServiceApi;
						if (this.isEmpty(data)) {
							errorMessage = api.getMessageByResponseCode(responseCode.SERVICE_UNAVAILABLE);
						} else if (data.Code !== responseCode.SUCCESS) {
							errorMessage = api.getMessageByResponseCode(data.Code);
							errorMessage = this.Ext.String.format(errorMessage, data.Message);
						} else {
							isError = false;
						}
						var callback = isError ? onError : onSuccess;
						var callbackParameter = isError ?  errorMessage : data;
						this.hideBodyMask(this.get("MaskConfig"));
						if (this.Ext.isFunction(callback)) {
							callback.call(scope || this, callbackParameter);
						}
					},

					/**
					 * Returns config for the save operation.
					 * @protected
					 * @returns {Object} Config.
					 */
					getSaveConfig: function() {
						return {
							"webHookAppDomain": this.get("WebHooks"),
							"authKey": this.get("AuthKey")
						};
					},

					/**
					 * Calls the web method of the BpmCrmCloudService.
					 * @protected
					 * @param {String} methodName Name of the web method.
					 * @param {Object} data Parameters.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Execution context.
					 */
					callBpmCrmCloudService: function(methodName, data, callback, scope) {
						scope = scope || this;
						this.BPMSoft.BpmCrmCloudServiceApi.callService(methodName, data, callback, scope);
					},

					/**
					 * Returns true if feature BulkEmailUXEnabled is enabled.
					 * @private
					 * @returns {Boolean} True if feature BulkEmailUXEnabled is enabled.
					 */
					getBulkEmailUXEnabled: function() {
						return this.BPMSoft.Features.getIsEnabled("BulkEmailUX");
					},

					/**
					 * Returns true if feature BulkEmailUXEnabled is disabled.
					 * @private
					 * @returns {Boolean} True if feature BulkEmailUXEnabled is disabled.
					 */
					getBulkEmailUXDisabled: function() {
						return !this.getBulkEmailUXEnabled();
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getDetailFilter
					 * @overridden
					 */
					getDetailFilter: Ext.emptyFn,

					/**
					 * @inheritdoc BPMSoft.BasePageV2#getDetailMasterColumnName
					 * @overridden
					 */
					getDetailMasterColumnName: Ext.emptyFn,

					/**
					 * Gets url for academy and pass it into the callback function.
					 * @param {Function} callback.
					 * @param {Object} scope.
					 */
					getAcademyUrl: function(callback, scope) {
						var config = this.getContextHelpConfig();
						config.callback = function(academyUrl) {
							this.set("AcademyUrl", academyUrl);
							this.Ext.callback(callback, scope);
						};
						config.scope = scope;
						BPMSoft.AcademyUtilities.getUrl(config);
					},

					/**
					 * Initializes help text with url for academy.
					 */
					initSenderDomainsHelpText: function() {
						var academyUrl = this.get("AcademyUrl");
						var textTemplate = this.get("Resources.Strings.SenderDomainsHelpTextCaption");
						textTemplate = this.Ext.String.format(textTemplate, academyUrl);
						this.set("Resources.Strings.SenderDomainsHelpTextCaption", textTemplate);
					},

					/**
					 * Check email status button handler.
					 * @protected
					 */
					onCheckEmailStatusButtonClick: function() {
						this.checkEmailStatus(false);
					},

					/**
					 * Checks if inserted system emails is verified in ESP.
					 * @protected
					 * @param skipValidataion {Boolean} Indicates weather to validate SystemEmail attribute.
					 */
					checkEmailStatus: function(skipValidataion) {
						var validationOptions = {skipValidation: skipValidataion};
						if(!this.validateColumn("SystemEmail", validationOptions)) {
							return;
						}
						var requestData = {emails: [this.$SystemEmail]};
						this.BPMSoft.BpmCrmCloudServiceApi.getCheckedEmails(requestData,
							this._processEmailCheckingResponse, this);
					},

					/**
					 * Adds view model columns validators.
					 * @inheritdoc BPMSoft.BasePageV2ViewModel#setValidationConfig.
					 * @override
					 */
					setValidationConfig: function() {
						this.callParent(arguments);
						this.addColumnValidator("SystemEmail", this._systemEmailValidator);
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "TabGeneralSettings",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.GeneralSettingsTabCaption"
							},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs"
					},
					{
						"operation": "insert",
						"name": "TabEspManagements",
						"enabled": false,
						"values": {
							"caption": { "bindTo": "Resources.Strings.EspManagementsTabCaption"	},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs"
					},
					{
						"operation": "insert",
						"name": "TabSenderDomains",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.SenderDomainsTabCaption"
							},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs"
					},
					{
						"operation": "insert",
						"name": "TabResponsesParsingSettings",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.ResponsesParsingSettingsTabCaption"
							},
							"items": []
						},
						"parentName": "Tabs",
						"propertyName": "tabs"
					},
					{
						"operation": "insert",
						"parentName": "TabGeneralSettings",
						"name": "GeneralSettingsControlGroup",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"visible": {"bindTo": "getBulkEmailUXDisabled"}
						},
						"index": 0
					},
					{
						"name": "EmailSendSetupControlGroup",
						"operation": "insert",
						"parentName": "TabGeneralSettings",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {
								"bindTo": "Resources.Strings.EmailSendSetupControlGroupCaption"
							},
							"tools": [],
							"items": [],
							"wrapClass": ["cloudintegration-control-group"],
							"visible": {"bindTo": "getBulkEmailUXEnabled"}
						},
						"index": 1
					},
					{
						"name": "StopParsingWebhooksControlGroup",
						"operation": "insert",
						"parentName": "TabResponsesParsingSettings",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {
								"bindTo": "Resources.Strings.StopParsingWebhooksControlGroupCaption"
							},
							"tools": [],
							"items": [],
							"wrapClass": ["cloudintegration-control-group"],
							"visible": {"bindTo": "getBulkEmailUXEnabled"}
						},
						"index": 1
					},
					{
						"operation": "insert",
						"name": "ReloadEmailSendSetupButton",
						"parentName": "EmailSendSetupControlGroup",
						"propertyName": "tools",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"click": {"bindTo": "save"},
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"caption": {"bindTo": "Resources.Strings.CheckSettingsButtonCaption"},
							"classes": {
								"textClass": ["cloudintegration-refresh-button"]
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "EmailSendSetupControlGroup",
						"name": "EmailSendSetupBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"index": 0
					},
					{
						"operation": "insert",
						"name": "EmailServiceProvider",
						"parentName": "EmailSendSetupBlock",
						"propertyName": "items",
						"values": {
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.EmailServiceProviderCaption"
								}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "EmailSendSetupBlock",
						"propertyName": "items",
						"name": "ApiKey",
						"values": {
							"bindTo": "ApiKey",
							"layout": {"column": 13, "row": 0, "colSpan": 11},
							"tip": {
								"content": {"bindTo": "Resources.Strings.ApiKeyInfoButtonCaption"}
							},
							"caption": {"bindTo": "Resources.Strings.ApiKeyCaption"},
						}
					},
					{
						"operation": "insert",
						"parentName": "EmailSendSetupBlock",
						"propertyName": "items",
						"name": "CloudConnectionUrl",
						"values": {
							"bindTo": "CloudConnectionUrl",
							"layout": {"column": 0, "row": 1, "colSpan": 11},
							"tip": {
								"content": {"bindTo": "Resources.Strings.CloudConnectionUrlCaption"}
							},
							"caption": {"bindTo": "Resources.Strings.CloudConnectionUrlInfoButtonCaption"},
						}
					},
					{
						"operation": "insert",
						"name": "CloudConnectionStatusCaption",
						"parentName": "EmailSendSetupBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"controlConfig": {
								"readonly": true,
								"classes": ["cloudintegration-status-label"]
							},
							"domAttributes": { "bindTo": "CloudConnectionStatusDomAttribute" },
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.ConnectionStatusCaption"
								}
							}
						}
					},
					{
						"operation": "insert",
						"name": "CloudConnectionStatusErrorMessage",
						"parentName": "EmailSendSetupBlock",
						"propertyName": "items",
						"values": {
							"enabled": false,
							"contentType": BPMSoft.ContentType.LONG_TEXT,
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							},
							"visible": {
								"bindTo": "CloudConnectionStatus",
								"bindConfig": {"converter": "invertBooleanValue"}
							},
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.ErrorMessageCaption"
								}
							}
						}
					},
					{
						"name": "ResponseReceiveSetupControlGroup",
						"operation": "insert",
						"parentName": "TabGeneralSettings",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {
								"bindTo": "Resources.Strings.ResponseReceiveSetupControlGroupCaption"
							},
							"tools": [],
							"items": [],
							"wrapClass": ["cloudintegration-control-group"],
							"visible": {"bindTo": "getBulkEmailUXEnabled"}
						},
						"index": 2
					},
					{
						"operation": "insert",
						"name": "ReloadResponseReceiveSetupButton",
						"parentName": "ResponseReceiveSetupControlGroup",
						"propertyName": "tools",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"click": {"bindTo": "save"},
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"caption": {"bindTo": "Resources.Strings.CheckSettingsButtonCaption"},
							"classes": {
								"textClass": ["cloudintegration-refresh-button"]
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "ResponseReceiveSetupControlGroup",
						"name": "ResponseReceiveSetupBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "ResponseReceiveSetupBlock",
						"propertyName": "items",
						"name": "WebHooks",
						"values": {
							"bindTo": "WebHooks",
							"layout": {"column": 0, "row": 0, "colSpan": 11},
							"tip": {
								"content": {"bindTo": "Resources.Strings.WebHooksInfoMessage"}
							},
							"caption": {"bindTo": "Resources.Strings.WebHooksCaption"},
						}
					},
					{
						"operation": "insert",
						"parentName": "ResponseReceiveSetupBlock",
						"propertyName": "items",
						"name": "AuthKey",
						"values": {
							"bindTo": "AuthKey",
							"layout": {"column": 13, "row": 0, "colSpan": 11},
							"tip": {
								"content": {"bindTo": "Resources.Strings.AuthKeyInfoButtonCaption"}
							},
							"caption": {"bindTo": "Resources.Strings.AuthKeyCaption"},
						}
					},
					{
						"operation": "insert",
						"name": "WebhooksConnectionStatusCaption",
						"parentName": "ResponseReceiveSetupBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"controlConfig": {
								"readonly": true,
								"classes": ["cloudintegration-status-label"]
							},
							"domAttributes": { "bindTo": "WebhooksConnectionStatusDomAttribute" },
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.ConnectionStatusCaption"
								}
							}
						}
					},
					{
						"operation": "insert",
						"name": "WebhooksConnectionStatusErrorMessage",
						"parentName": "ResponseReceiveSetupBlock",
						"propertyName": "items",
						"values": {
							"enabled": false,
							"contentType": BPMSoft.ContentType.LONG_TEXT,
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"visible": {
								"bindTo": "WebhooksConnectionStatus",
								"bindConfig": {"converter": "invertBooleanValue"}
							},
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.ErrorMessageCaption"
								}
							}
						}
					},
					{
						"name": "SystemEmailControlGroup",
						"operation": "insert",
						"parentName": "TabGeneralSettings",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {
								"bindTo": "Resources.Strings.SystemEmailControlGroupCaption"
							},
							"tools": [],
							"items": [],
							"wrapClass": ["cloudintegration-control-group"],
							"visible": {"bindTo": "_getFromEmailFromNameMacrosEnabled"}
						},
						"index": 3
					},
					{
						"operation": "insert",
						"name": "CheckEmailButton",
						"parentName": "SystemEmailControlGroup",
						"propertyName": "tools",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"click": {"bindTo": "onCheckEmailStatusButtonClick"},
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"caption": {"bindTo": "Resources.Strings.CheckEmailButtonCaption"},
							"classes": {
								"textClass": ["cloudintegration-refresh-button"]
							}
						}
					},
					{
						"operation": "insert",
						"name": "VerifyEmailButton",
						"parentName": "SystemEmailControlGroup",
						"propertyName": "tools",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.BUTTON,
							"click": {"bindTo": "onVerifySystemEmailButtonClick"},
							"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
							"caption": {"bindTo": "Resources.Strings.VerifyButtonCaption"},
							"classes": {
								"textClass": ["cloudintegration-refresh-button"]
							},
							"visible": "$IsVerifyButtonVisible"
						}
					},
					{
						"operation": "insert",
						"parentName": "SystemEmailControlGroup",
						"name": "SystemEmailSetupGridLayout",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"index": 0
					},
					{
						"operation": "insert",
						"parentName": "SystemEmailSetupGridLayout",
						"propertyName": "items",
						"name": "SystemEmail",
						"values": {
							"bindTo": "SystemEmail",
							"layout": {"column": 0, "row": 0, "colSpan": 11},
							"tip": {
								"content": {"bindTo": "Resources.Strings.DefaultESPEmailInfoMessage"}
							},
							"caption": {"bindTo": "Resources.Strings.DefaultESPEmailCaption"},
						}
					},					
					{
						"operation": "insert",
						"name": "SystemEmailStatus",
						"parentName": "SystemEmailSetupGridLayout",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"controlConfig": {
								"readonly": true,
								"classes": ["system-email-status"]
							},
							"domAttributes": { "bindTo": "SystemEmailStatusDomAttribute" },
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.DefaultESPEmailStateCaption"
								}
							},
							"styles": {
								"margin-top": "5px"
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "StopParsingWebhooksControlGroup",
						"name": "ResponsesParsingBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"index": 2
					},
					{
						"operation": "insert",
						"name": "DoNotParseFrom",
						"parentName": "ResponsesParsingBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 5,
								"rowSpan": 1
							},
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.StopHandleWebHookProcessAt"
								}
							},
							"labelWrapConfig": {
								"classes": {
									"wrapClassName": ["cloudintegration-label-small"]
								}
							}
						}
					},
					{
						"operation": "insert",
						"name": "DoNotParseTo",
						"parentName": "ResponsesParsingBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 5,
								"rowSpan": 1
							},
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.StartHandleWebHookProcessAt"
								}
							},
							"labelWrapConfig": {
								"classes": {
									"wrapClassName": ["cloudintegration-label-small"]
								}
							}
						}
					},
					{
						"operation": "insert",
						"parentName": "GeneralSettingsControlGroup",
						"name": "GeneralSettingsBlock",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"index": 0
					},
					{
						"operation": "insert",
						"name": "WebHooks",
						"parentName": "GeneralSettingsBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 23,
								"rowSpan": 1
							},
							"labelConfig": {
								"visible": true,
								"caption": {
									"bindTo": "Resources.Strings.WebHooksCaption"
								}
							},
							"tip": {
								"content": {"bindTo": "Resources.Strings.WebHooksInfoMessage"}
							}
						}
					},
					{
						"name": "TabEspManagementsLayout",
						"operation": "insert",
						"parentName": "TabEspManagements",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": [],
						}
					},
					{
						"name": "EspManagementContainer",
						"operation": "insert",
						"parentName": "TabEspManagementsLayout",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "ProviderDetailDataNotAvailableBlankSlate",
						"parentName": "EspManagementContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"caption": { "bindTo": "Resources.Strings.ProvidersDataNotAvailableBlankSlate" },
							"labelClass": ["blank-slate-message"],
							"visible": { "bindTo": "getIsCloudConnectionFailed" }
						}
					},
					{
						"name": "MailingProviders",
						"operation": "insert",
						"parentName": "EspManagementContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL,
							"visible": {
								"bindTo": "CloudConnectionStatus"
							}
						}
					},
					{
						"name": "TabSenderDomainsLayout",
						"operation": "insert",
						"parentName": "TabSenderDomains",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						}
					},
					{
						"name": "SenderDomainsGridContainer",
						"operation": "insert",
						"parentName": "TabSenderDomainsLayout",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTAINER,
							"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 1},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "DomainDetailDataNotAvailableBlankSlate",
						"parentName": "SenderDomainsGridContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.LABEL,
							"caption": { "bindTo": "Resources.Strings.DomainsDataNotAvailableBlankSlate" },
							"labelClass": ["blank-slate-message"],
							"visible": { "bindTo": "getIsCloudConnectionFailed" }
						}
					},
					{
						"name": "SenderDomains",
						"operation": "insert",
						"parentName": "SenderDomainsGridContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL,
							"visible": {
								"bindTo": "getIsSenderDomainsDetailVisible"
							}
						}
					},
					{
						"name": "ProviderSenderDomains",
						"operation": "insert",
						"parentName": "SenderDomainsGridContainer",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL,
							"visible": {
								"bindTo": "getIsProviderSenderDomainsDetailVisible"
							}
						}
					},
					{
						"name": "SetupInstructions",
						"operation": "insert",
						"parentName": "TabSenderDomainsLayout",
						"propertyName": "items",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {
								"bindTo": "SetupInstructionsControlGroupCaption"
							},
							"tools": [],
							"items": [],
							"wrapClass": ["cloudintegration-control-group"],
							"controlConfig": {
								"collapsed": {"bindTo": "IsSetupInstructionsCollapsed"}
							},
							"layout": {"column": 13, "row": 0, "colSpan": 11, "rowSpan": 1}
						}
					},
					{
						"name": "SenderDomainsHelpTextLabel",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"className": "BPMSoft.MultilineLabel",
							"caption": {"bindTo": "Resources.Strings.SenderDomainsHelpTextCaption"},
							"contentVisible": true,
							"classes": {
								"labelClass": ["cloudintegration-regular-text"]
							}
						}
					},
					{
						"name": "MxTextLabel",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption":  {"bindTo": "Resources.Strings.MxTextLabelCaption"},
							"className": "BPMSoft.MultilineLabel",
							"contentVisible": true,
							"visible": {"bindTo": "_getIsMxVisible"}
						},
						"classes": {
							"labelClass": ["cloudintegration-regular-text"]
						}
					},
					{
						"name": "MxScript",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "MxScript"},
							"contentVisible": true,
							"visible": {"bindTo": "_getIsMxVisible"},
							"classes": {
								"labelClass": ["info-area-label"]
							}
						}
					},
					{
						"name": "MxFootnote",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.MxFootnoteCaption"},
							"classes": {
								"labelClass": ["cloudintegration-code cloudintegration-footnote-label"]
							},
							"visible": {"bindTo": "_getIsMxVisible"}
						}
					},
					{
						"name": "SPFTextLabel",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.SPFTextLabelCaption"},
							"className": "BPMSoft.MultilineLabel",
							"contentVisible": true,
							"visible": {"bindTo": "_getIsSpfVisible"},
						},
						"classes": {
							"labelClass": ["cloudintegration-regular-text"]
						}
					},
					{
						"name": "SPFScript",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "SPFScript"},
							"contentVisible": true,
							"visible": {"bindTo": "_getIsSpfVisible"},
							"classes": {
								"labelClass": ["info-area-label"]
							}
						}
					},
					{
						"name": "SPFFootnote",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.SPFFootnoteCaption"},
							"visible": {"bindTo": "_getIsSpfVisible"},
							"classes": {
								"labelClass": ["cloudintegration-code cloudintegration-footnote-label"]
							}
						}
					},
					{
						"name": "DKIMTextLabel",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.DKIMTextLabelCaption"},
							"className": "BPMSoft.MultilineLabel",
							"contentVisible": true,
							"visible": {"bindTo": "_getIsDkimVisible"},
						},
						"classes": {
							"labelClass": ["regular-text"]
						}
					},
					{
						"name": "DKIMScript",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "DKIMScript"},
							"contentVisible": true,
							"visible": {"bindTo": "_getIsDkimVisible"},
							"classes": {
								"labelClass": ["info-area-label"]
							}
						}
					},
					{
						"name": "DKIMFootnote",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.DKIMFootnoteCaption"},
							"visible": {"bindTo": "_getIsDkimVisible"},
							"classes": {
								"labelClass": ["cloudintegration-code cloudintegration-footnote-label"]
							}
						}
					},
					{
						"name": "DMARCTextLabel",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"className": "BPMSoft.MultilineLabel",
							"contentVisible": true,
							"caption": {"bindTo": "Resources.Strings.DMARCSettingCaption"},
							"visible": {"bindTo": "_getIsDmarcVisible"},
							"classes": {
								"labelClass": ["cloudintegration-regular-text"]
							}
						}
					},
					{
						"name": "DMARCScript",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "DMARCScript"},
							"contentVisible": true,
							"visible": {"bindTo": "_getIsDmarcVisible"},
							"classes": {
								"labelClass": ["info-area-label"]
							}
						}
					},
					{
						"name": "DMARCFootnote",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "Resources.Strings.DMARCSettingHelpCaption"},
							"visible": {"bindTo": "_getIsDmarcVisible"},
							"classes": {
								"labelClass": ["cloudintegration-code cloudintegration-footnote-label"]
							}
						}
					},
					{
						"name": "AdditonalSettingsLabel",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"itemType": BPMSoft.ViewItemType.LABEL,
							"className": "BPMSoft.MultilineLabel",
							"caption": {"bindTo": "AdditionalSettingsCaption"},
							"contentVisible": true,
							"visible": {"bindTo": "_getIsAdditionalSettingsVisible"},
							"classes": {
								"labelClass": ["cloudintegration-regular-text"]
							}
						}
					},
					{
						"name": "AdditionalSettingsScript",
						"operation": "insert",
						"parentName": "SetupInstructions",
						"propertyName": "items",
						"values": {
							"className": "BPMSoft.MultilineLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": {"bindTo": "AdditionalSettingsScript"},
							"contentVisible": true,
							"visible": {"bindTo": "_getIsAdditionalSettingsVisible"},
							"classes": {
								"labelClass": ["info-area-label"]
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
