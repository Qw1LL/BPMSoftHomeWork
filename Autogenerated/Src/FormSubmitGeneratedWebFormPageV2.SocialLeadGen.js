 /**
 * @inheritDoc FormSubmitGeneratedWebFormPageV2
 */
define("FormSubmitGeneratedWebFormPageV2", ["FormSubmitGeneratedWebFormPageV2Resources", "css!SocialLeadGenGeneratedWebFormPageV2CSS"], function (resources) {
	return {
		attributes: {
			"IsLeadGenSubscribed": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			"SocialPageId": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			"SocialPageName": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			"SocialFormName": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			"BPMStudioUrl": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: BPMSoft.loaderBaseUrl.replace(/\/\s*$/, "")
			},
			"LeadGenToggle": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			"LeadGenToggleEnabled": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			"LeadGenToggleHintText": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			"IsLeadGenEnabledStatus": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			},
			"IsAccountExists": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			"IsAccountEnabled": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},
			"ActivePanelCode": {
				dataValueType: BPMSoft.DataValueType.TEXT,
				value: ""
			}
		},
		methods: {
			/**
			 * @private
			 */
				_getLeadGenFeatureState: function() {
				return this.BPMSoft.Features.getIsEnabled("SocialLeadGen");
			},

			/**
			 * @private
			 */
			_getFacebookIcon: function() {
				return this.BPMSoft.ImageUrlBuilder.getUrl(this.get("Resources.Images.LeadGenFacebookIcon"));
			},

			/**
			 * @private
			 */
			_accountSettingsPanelVisibility: function() {
				return (this.get("ActivePanelCode") === "ACCOUNT_SETTINGS" && this.get("LeadGenToggle"));
			},

			/**
			 * @private
			 */
			_leadGenSettingsPanelVisibility: function() {
				return (this.get("ActivePanelCode") === "LEADGEN_SETTINGS" && this.get("LeadGenToggle"));
			},

			/**
			 * @private
			 */
			_getPageLink: function(value) {
				return {
					"url": value ? "https://facebook.com/" + this.get("SocialPageId") : "",
					"caption": value,
				};
			},

			/**
			 * @private
			 */
			_getDirection: function() {
				return this.BPMSoft.getIsRtlMode() ? "rtl" : "ltr";
			},

			/**
			 * @private
			 */
			_showCloudIntegrationErrorMessage: function() {
				BPMSoft.utils.showMessage({
					caption: resources.localizableStrings.LeadGenIntegrationErrorCaption,
					style: this.BPMSoft.MessageBoxStyles.RED
				});
			},

			/**
			 * @private
			 */
			_getLeadGenSubscribtionPanelCaption: function() {
				var localizableStrings = resources.localizableStrings;
				return this.get("IsLeadGenSubscribed") ?
					localizableStrings.LeadGenConnectedCaption :
					localizableStrings.LeadGenSubscribtionPanelLabelCaption;
			},

			/**
			 * @private
			 */
			_applyToggleState: function(state) {
				switch (state) {
					case 'active':
						this.set("LeadGenToggleEnabled", true)
						this.set("LeadGenToggleHintText", '');
						break;
					case 'loading':
						this.set("LeadGenToggleEnabled", false)
						this.set("LeadGenToggleHintText", resources.localizableStrings.LeadGenIntegrationLoadingCaption);
						break;
					case 'error':
						this.set("LeadGenToggleEnabled", false)
						this.set("LeadGenToggleHintText", resources.localizableStrings.LeadGenIntegrationErrorCaption);
						break;
					default:
						throw new Error('Invalid toggle state'); 
				}
			},

			/**
			 * @private
			 */
			_getLeadGenSubscribtion: function(onSuccess, onFailure, scope) {
				var config = {
					serviceName: "SocialLeadGenService",
					methodName: "GetSubscribtion",
					data: {
						subscribtionRequest: {
							LandingId: this.$PrimaryColumnValue
						}
					}
				};
				this.callService(config, function(responseData, response) {
					if (response.status === 200) {
						var result = responseData.GetSubscribtionResult;
						onSuccess.call(scope, result);
					} else {
						onFailure.call(scope);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_deleteLeadGenSubscribtion: function(onSuccess, onFailure, scope) {
				var config = {
					serviceName: "SocialLeadGenService",
					methodName: "DeleteSubscribtion",
					data: {
						unsubscribtionRequest: {
							LandingId: this.$PrimaryColumnValue
						}
					}
				};
				this.callService(config, function(responseData, response) {
					if (response.status === 200) {
						var result = responseData.DeleteSubscribtionResult;
						onSuccess.call(scope, result);
					} else {
						onFailure.call(scope);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_getLeadGenAccount: function(onSuccess, onFailure, scope) {
				var config = {
					serviceName: "SocialLeadGenService",
					methodName: "GetAccount",
					data: {}
				};
				this.callService(config, function(responseData, response) {
					if (response.status === 200) {
						var result = responseData.GetAccountResult;
						onSuccess.call(scope, result);
					} else {
						onFailure.call(scope);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_createLeadGenAccount: function(onSuccess, onFailure, scope) {
				var config = {
					serviceName: "SocialLeadGenService",
					methodName: "CreateAccount",
					data: {
						createAccountRequest: {
							BPMStudioDomain: this.get("BPMStudioUrl")
						}
					}
				};
				this.callService(config, function(responseData, response) {
					if (response.status === 200) {
						var result = responseData.CreateAccountResult;
						onSuccess.call(scope, result);
					} else {
						onFailure.call(scope);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_updateLeadGenAccount: function(onSuccess, onFailure, scope) {
				var config = {
					serviceName: "SocialLeadGenService",
					methodName: "UpdateAccount",
					data: {
						updateAccountRequest: {
							BPMStudioDomain: this.get("BPMStudioUrl")
						}
					}
				};
				this.callService(config, function(responseData, response) {
					if (response.status === 200) {
						var result = responseData.CreateAccountResult;
						onSuccess.call(scope, result);
					} else {
						onFailure.call(scope);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_generateLeadGenSessionToken: function(onSuccess, onFailure, scope) {
				var config = {
					serviceName: "SocialLeadGenService",
					methodName: "GenerateSessionToken"
				};
				this.callService(config, function(responseData, response) {
					if (response.status === 200) {
						var result = responseData.GenerateSessionTokenResult;
						onSuccess.call(scope, result);
					} else {
						onFailure.call(scope);
					}
				}, this);
			},

			/**
			 * @private
			 */
			_applyLeadGenSubscribtionInfo: function(response) {
				this.set("IsLeadGenSubscribed", response.IsLeadGenSubscribed);
				this.set("SocialPageId", response.PageId);
				this.set("SocialPageName", response.PageName);
				this.set("SocialFormName", response.FormName);
			},

			/**
			 * @private
			 */
			_loadLeadGenSubscribtionInfo: function(toggleRelated) {
				this._applyToggleState('loading');
				this._getLeadGenSubscribtion(function(response) {
					this._applyToggleState('active');
					if (toggleRelated) {
						this.set("LeadGenToggle", response.IsLeadGenSubscribed);
					}
					this._applyLeadGenSubscribtionInfo(response);
				}, this._showCloudIntegrationErrorMessage, this);
			},

			/**
			 * @private
			 */
			_loadLeadGenAccountInfo: function() {
				this._applyToggleState('loading');
				this._getLeadGenAccount(
					function(response) {
						this.set("IsAccountExists", response.IsAccountExists);
						this.set("IsAccountEnabled", response.IsAccountEnabled);
						if (response.IsAccountExists) {
							this.set("BPMStudioUrl", response.BPMStudioUrl);
							this.set("ActivePanelCode", "LEADGEN_SETTINGS");
							this._loadLeadGenSubscribtionInfo(true);
						} else {
							this._applyToggleState('active');
							this.set("ActivePanelCode", "ACCOUNT_SETTINGS");
						}
					}, 
					function() {
						this._applyToggleState('error');
					},
					this
				);
			},

			/**
			 * @private
			 */
			_onCreateUpdateAccountClick: function() {
				const onAccountChanged = function() {
					this.set("IsAccountExists", true);
					this.set("IsAccountEnabled", true);
					this.set("ActivePanelCode", "LEADGEN_SETTINGS");
				};
				if (this.get("IsAccountExists")) {
					this._updateLeadGenAccount(onAccountChanged, this._showCloudIntegrationErrorMessage, this);
				} else {
					this._createLeadGenAccount(onAccountChanged, this._showCloudIntegrationErrorMessage, this);
				}
			},

			/**
			 * @private
			 */
			_onEditAccountClick: function() {
				this.set("ActivePanelCode", "ACCOUNT_SETTINGS");
			},

			/**
			 * @private
			 */
			_onSelectResourceClick: function() {
				this._generateLeadGenSessionToken(function(response) {
					var url = response.AccountServiceUrl + "/app?" +
						"locale=" + BPMSoft.Resources.CultureSettings.currentCultureName + "&" +
						"dir=" + this._getDirection() + "&" +
						"social_network=facebook&" +
						"session_token=" + response.SessionToken + "&" +
						"web_form_id=" + this.$PrimaryColumnValue + "&" +
						"landing_type=submitted_form";
					window.open(url);
				}, this._showCloudIntegrationErrorMessage, this);
			},

			/**
			 * @private
			 */
			_onPageLinkClick: function(url) {
				window.open(url, "_blank");
				return false;
			},

			/**
			 * @private
			 */
			_onRefreshClick: function() {
				this._loadLeadGenSubscribtionInfo(false);
			},

			/**
			 * @private
			 */
			_onLeadGenToggleClick: function() {
				if (this.get("IsLeadGenSubscribed") && !this.get("LeadGenToggle")) {
					this._deleteLeadGenSubscribtion(function(response) {
						this._applyLeadGenSubscribtionInfo(response);
					},
					this._showCloudIntegrationErrorMessage, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
			 * @overridden
			 */
			onEntityInitialized: function() {
				this.callParent(arguments);
				this.set("LeadGenToggle", false);
				this.set("LeadGenToggleEnabled", false);
				if (this._getLeadGenFeatureState()) {
					if (this.isNew) {
						this.set("LeadGenToggleHintText", resources.localizableStrings.LeadGenIntegrationSaveRequired);
					} else {
						this._loadLeadGenAccountInfo();
					}
				}
			}
		},
		diff: [
			//account settions panel
			{
				"name": "LeadGenAccountSectionPanel",
				"parentName": "LeadGenSettingsPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"classes": {
						"wrapClassName": ["leadgen-settings-section-panel"]
					},
					"visible": "$_accountSettingsPanelVisibility"
				}
			},
			{
				"name": "LeadGenAccountSectionPanelLabel",
				"parentName": "LeadGenAccountSectionPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"caption": "$Resources.Strings.LeadGenAccountPanelLabelCaption",
					"classes": {
						"labelClass": ["section-panel-label"]
					}
				}
			},
			{
				"name": "BPMStudioUrlFieldContainer",
				"parentName": "LeadGenAccountSectionPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": "field-wrapper",
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"items": [
						{
							"name": "BPMStudioUrlLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": "$Resources.Strings.LeadGenBPMStudioUrlFieldCaption",
							"classes": {
								"labelClass": ["field-label"]
							}
						},
						{
							"name": "BPMStudioUrl",
							"labelConfig": {
								"visible": false
							}
						}
					],
				}
			},
			{

				"name": "AccountActionButtonsContainer",
				"parentName": "LeadGenAccountSectionPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"name": "CreateLeadGenAccountButton",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": "action-buttons-wrapper reverse",
					"layout": { "column": 0, "row": 3, "colSpan": 24 },
					"items": [{
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.LeadGenConfirmationButtonCaption",
						"click": "$_onCreateUpdateAccountClick",
						"imageConfig": {
							"source": this.BPMSoft.ImageSources.URL,
							"url": this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.LeadGenRightIcon)
						},
						"classes": {
							"wrapperClass": ["button-wrapper"],
							"textClass": "button-text",
							"imageClass": ["button-image"]
						}
					}]
				}
			},
			//subscribtion settings panel
			{
				"name": "LeadGenSubscribtionSectionPanel",
				"parentName": "LeadGenSettingsPanel",
				"propertyName": "items",
				"operation": "insert",
				"index": 1,
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": [],
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"classes": {
						"wrapClassName": ["leadgen-settings-section-panel"]
					},
					"visible": "$_leadGenSettingsPanelVisibility"
				}
			},
			{
				"name": "LeadGenSubscribtionSectionPanelLabel",
				"parentName": "LeadGenSubscribtionSectionPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"itemType": BPMSoft.ViewItemType.LABEL,
					"layout": { "column": 0, "row": 0, "colSpan": 24 },
					"caption": "$_getLeadGenSubscribtionPanelCaption",
					"classes": {
						"labelClass": ["section-panel-label"]
					}
				}
			},
			{
				"name": "PageFieldContainer",
				"parentName": "LeadGenSubscribtionSectionPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": "field-wrapper",
					"layout": { "column": 0, "row": 1, "colSpan": 24 },
					"items": [
						{
							"name": "PageLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": "$Resources.Strings.LeadGenPageFieldCaption",
							"classes": {
								"labelClass": ["field-label"]
							}
						},
						{
							"name": "PageLink",
							"showValueAsLink": true,
							"labelConfig": {
								"visible": false
							},
							"bindTo": "SocialPageName",
							"href": {
								"bindTo": "SocialPageName",
								"bindConfig": { "converter": "_getPageLink" }
							},
							"controlConfig": {
								"enabled": false,
								"className": "BPMSoft.TextEdit",
								"linkclick": { bindTo: "_onPageLinkClick" }
							}
						}
					],
				}
			},
			{
				"name": "FormFieldContainer",
				"parentName": "LeadGenSubscribtionSectionPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": "field-wrapper",
					"layout": { "column": 0, "row": 2, "colSpan": 24 },
					"items": [
						{
							"name": "SocialFormLabel",
							"itemType": BPMSoft.ViewItemType.LABEL,
							"caption": "$Resources.Strings.LeadGenFormFieldCaption",
							"classes": {
								"labelClass": ["field-label"]
							}
						},
						{
							"name": "SocialFormName",
							"labelConfig": {
								"visible": false
							},
							"controlConfig": {
								"enabled": false
							}
						}
					]
				}
			},
			{
				"name": "SubscribtionActionButtonsContainer",
				"parentName": "LeadGenSubscribtionSectionPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"wrapClass": "action-buttons-wrapper",
					"layout": { "column": 0, "row": 3, "colSpan": 24 },
					"items": [{
						"name": "SelectSourceButton",
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"layout": { "column": 0, "row": 3, "colSpan": 14 },
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.LeadGenSourceButtonCaption",
						"click": "$_onSelectResourceClick",
						"imageConfig": {
							"source": this.BPMSoft.ImageSources.URL,
							"url": this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.LeadGenSettingsIcon)
						},
						"classes": {
							"wrapperClass": ["button-wrapper"],
							"textClass": "button-text",
							"imageClass": ["button-image"]
						}
					},
					{
						"name": "RefreshSourceButton",
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"caption": "$Resources.Strings.LeadGenRefreshButtonCaption",
						"click": "$_onRefreshClick",
						"imageConfig": {
							"source": this.BPMSoft.ImageSources.URL,
							"url": this.BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.LeadGenRefreshIcon)
						},
						"classes": {
							"wrapperClass": ["button-wrapper"],
							"textClass": "button-text",
							"imageClass": ["button-image"]
						}
					}
					]
				}
			},
			{
				"name": "EditLeadGenAccountButton",
				"parentName": "LeadGenSubscribtionSectionPanel",
				"propertyName": "items",
				"operation": "insert",
				"values": {
					"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					"layout": { "column": 0, "row": 5, "colSpan": 24 },
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"caption": "$Resources.Strings.LeadGenEditButtonCaption",
					"click": "$_onEditAccountClick",
					"classes": {
						"wrapperClass": ["button-wrapper"],
						"textClass": "button-text",
					}
				}
			}
		]
	};
});