define("OAuth20ServiceAuthInfoValuesPage", ["InformationButtonResources", "OAuth20Utilities",
	"ServiceOAuthAuthenticatorEndpointHelper"], function(informationButtonResources) {
	return {
		attributes: {

			/**
			 * @inheritdoc AuthInfoParameterValuePage#AuthInfoPropertyName
			 * @override
			 */
			AuthInfoPropertyName: {
				value: "applicationId"
			},

			/**
			 * OAuth20 application.
			 */
			Application: {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
				onChange: "_onApplicationChanged",
				referenceSchemaName: "OAuthApplications"
			},

			/**
			 * OAuth20 application page visible indicator.
			 */
			ShowOAuth20AppPage: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			},

			/**
			 * Is allow edit schema.
			 */
			CanEditSchema: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			},

			/**
			 * Is OAuth application valid.
			 */
			IsApplicationValid: {
				dataValueType: BPMSoft.DataValueType.BOOLEAN
			}
		},
		properties: {
			_applicationList: null,

			/**
			 * Default image id constant.
			 */
			DEFAULT_IMAGE_ID: "AD408054-6040-4BF5-B0E6-E86C20B6CB02"
		},

		messages: {
			/**
			 * @message CloseOAuth20AppPage
			 * Closed method page.
			 */
			"CloseOAuth20AppPage": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.SUBSCRIBE
			}
		},
		methods: {

			//region Methods: Private

			/**
			 * @private
			 */
			_onApplicationChanged: function() {
				this.$Source = BPMSoft.services.enums.ServiceParameterValueSource.CONST;
				this.$Value = this.$Application && this.$Application.value;
			},

			/**
			 * Returns image url for SysImage by id.
			 * @private
			 */
			_getSysImageUrl: function(sysImageId) {
				const imageConfig = {
					source: BPMSoft.ImageSources.SYS_IMAGE,
					params: {
						primaryColumnValue: sysImageId
					}
				};
				return BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
			},

			/**
			 * @private
			 */
			_initApplication: function() {
				const application = this._applicationList[this.$Value];
				if (application) {
					this.$Application = application;
				} else {
					if (this.$Application && !this.$Value) {
						this.$Application = null;
					}
				}
			},

			/**
			 * @private
			 */
			_subscribeCloseOAuth20AppPageSandboxEvent: function() {
				this.sandbox.subscribe("CloseOAuth20AppPage", this._closeOAuth20AppPage, this);
			},

			/**
			 * @private
			 */
			_clearApplication: function() {
				this.$Application = null;
			},

			/**
			 * @private
			 */
			_closeOAuth20AppPage: function(appId) {
				this._initApplicationList(
						function() {
							this.$Value = appId;
							const application = this._applicationList[this.$Value];
							this._clearApplication();
							this.$Application = application;
						},
						this
				);
				this.$ShowOAuth20AppPage = false;
			},

			/**
			 * @private
			 */
			_handleGetEntityCollection: function(response, callback, scope) {
				if (response && response.success) {
					response.collection.each(function(item) {
						const imageId = item.$Image ? item.$Image.value : this.DEFAULT_IMAGE_ID;
						this._applicationList[item.$Id] = {
							value: item.$Id,
							displayValue: item.$Name,
							Image: {"value": imageId},
							imageUrl: this._getSysImageUrl(imageId)
						};
					}, this);
				}
				Ext.callback(callback, scope);
			},

			/**
			 * @private
			 */
			_initApplicationList: function(callback, scope) {
				this._applicationList = {};
				const select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "OAuthApplications"
				});
				select.addColumn("Id");
				select.addColumn("Name");
				select.addColumn("Image");
				BPMSoft.OAuth20Utilities.addCustomApplicationFilters(select.filters);
				select.getEntityCollection(function(response) {
					this._handleGetEntityCollection(response, callback, scope);
				}, this);
			},

			/**
			 * @private
			 */
			_getApplicationAction: function() {
				const isExistingApp = this.$Value && !BPMSoft.isEmptyGUID(this.$Value);
				return isExistingApp ? BPMSoft.ConfigurationEnums.CardOperation.EDIT
					: BPMSoft.ConfigurationEnums.CardOperation.ADD;
			},

			/**
			 * @inheritdoc BaseServiceParameterValuePage#onValueChanged
			 * @override
			 */
			onValueChanged: function() {
				this.authInfoValue.setPropertyValue("value", this.$Value);
				if (this.$Value) {
					BPMSoft.ServiceOAuthAuthenticatorEndpointHelper.validateApplication(this.$Value,
						function(result) {
							this.$IsApplicationValid = result;
						}, this);
				} else {
					this.$IsApplicationValid = true;
				}
			},

			//endregion

			//region Methods: Protected

			/**
			 * @inheritdoc BaseSchemaViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this._subscribeCloseOAuth20AppPageSandboxEvent();
				this.callParent([
					function() {
						BPMSoft.chain(
							function(next) {
								this._initApplicationList(next, this);
							},
							function() {
								this._initApplication();
								Ext.callback(callback, scope);
							},
							this
						);
					}, this
				]);
			},

			/**
			 * @inheritdoc AuthParameterValuePage#updateAuth
			 * @override
			 */
			updateAuth: function() {
				this._initApplication();
			},

			//endregion

			//region Methods: Public

			/**
			 * Opens OAuth application in modal window.
			 */
			onApplicationActionButtonClick: function() {
				const appAction = this._getApplicationAction();
				const appId = appAction === BPMSoft.ConfigurationEnums.CardOperation.EDIT
					? this.$Application.value : BPMSoft.generateGUID();
				var viewModelConfig = {
					Id: appId,
					PrimaryColumnValue: appId,
					Operation: appAction
				};
				this.$ShowOAuth20AppPage = true;
				this.sandbox.loadModule("OAuth20AppModule", {
					renderTo: "AppPageContainer",
					instanceConfig: {
						parameters: {
							viewModelConfig: viewModelConfig
						}
					}
				});
			},

			/**
			 * Prepares list of OAuth 2.0 applications.
			 * @param {String} filter List filter.
			 * @param {BPMSoft.Collection} list List of applications.
			 */
			prepareApplicationList: function(filter, list) {
				list.reloadAll(this._applicationList);
			},

			/**
			 * Returns Open/Add OAuth app button image config.
			 * @return {Object}
			 */
			getOpenOAuthButtonImageConfig: function() {
				if (this._getApplicationAction() === BPMSoft.ConfigurationEnums.CardOperation.EDIT) {
					return this.get("Resources.Images.OpenButtonImage");
				} else {
					return this.get("Resources.Images.AddButtonImage32");
				}
			}

			//endregion

		},
		diff: [
			{
				"operation": "remove",
				"name": "InputContainer"
			},
			{
				"operation": "merge",
				"name": "CardContentWrapper",
				"values": {
					"id": "CardContentWrapperOAuth20AppPage"
				}
			},
			{
				"operation": "insert",
				"name": "AppContainer",
				"className": "BPMSoft.GridLayoutEdit",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"name": "Application",
				"parentName": "AppContainer",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 11
					},
					"caption": "$Resources.Strings.ApplicationCaption",
					"contentType": BPMSoft.ContentType.ENUM,
					"controlConfig": {
						"prepareList": {"bindTo": "prepareApplicationList"},
						"iconsVisible": false,
						"enabled": "$CanEditSchema"
					},
					"classes": {
						"wrapClassName": ["app-select"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "AppContainer",
				"name": "AppButtonsGroup",
				"propertyName": "items",
				"values": {
					"layout": {
						"column": 11,
						"row": 0,
						"colSpan": 1
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"items": []
				},
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ApplicationActionButton",
				"parentName": "AppButtonsGroup",
				"propertyName": "items",
				"values": {
					"itemType": BPMSoft.ViewItemType.BUTTON,
					"click": "$onApplicationActionButtonClick",
					"imageConfig": {
						"bindTo": "getOpenOAuthButtonImageConfig"
					},
					"classes": {
						"wrapperClass": ["t-no-padding"],
						"imageClass": ["t-action-btn-image"]
					}
				}
			},
			{
				"operation": "insert",
				"parentName": "AppButtonsGroup",
				"propertyName": "items",
				"name": "InvalidApplication",
				"values": {
					"itemType": this.BPMSoft.ViewItemType.INFORMATION_BUTTON,
					"content": "$Resources.Strings.InvalidApplicationTip",
					"style": BPMSoft.TipStyle.RED,
					"controlConfig": {
						"visible": {
							"bindTo": "IsApplicationValid",
							"bindConfig": {
								"converter": "invertBooleanValue"
							}
						},
						"imageConfig": informationButtonResources.localizableImages.WarningIcon
					}
				}
			},
			{
				"operation": "insert",
				"name": "AppPageContainer",
				"values": {
					"id": "AppPageContainer",
					"itemType": BPMSoft.ViewItemType.CONTAINER,
					"classes": {"wrapClassName": ["method-page-container"]},
					"items": [],
					"visible": {"bindTo": "ShowOAuth20AppPage"},
					"enabled": "$CanEditSchema"
				}
			}
		]
	};
});
