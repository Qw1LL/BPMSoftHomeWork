define("ChangePasswordModuleSchema", ["ServiceHelper", "ChangePasswordModuleSchemaResources"],
	function(ServiceHelper, resources) {
		return {
			attributes: {
				"currentPassword": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},
				"newPassword": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},
				"newPasswordConfirmation": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"isRequired": true
				},
				"isLdap": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},
				"isUserDisable2FA": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": false
				},
				"TotpCode": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				"IsTotpEnabled": {
					"dataValueType": BPMSoft.DataValueType.BOOLEAN,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			diff: [
				{
					"operation": "insert",
					"name": "RelationshipControlGroup",
					"values": {
						"id": "top-container",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 0
				},			
				{
					"operation": "insert",
					"name": "leftPanelContainer",
					"parentName": "RelationshipControlGroup",
					"values": {
						"id": "leftPanelContainer",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "currentPassword",
					"parentName": "leftPanelContainer",
					"propertyName": "items",
					"values": {
						"id": "current-password",
						"visible": {"bindTo": "isNotRecoveryMode"},
						"value": {
							"bindTo": "currentPassword"
						},	
						"controlConfig": {
							"protect": true,
							"className": "BPMSoft.TextEdit",
							"rightIconClick": {
								"bindTo": "changeCurrentPasswordIcon"
							},
							"rightIconClasses": ["hide-password-eye", "show-password-eye"]
						},
						"labelConfig": {
							"caption":  {"bindTo": "Resources.Strings.currentPasswordCaption"}
						},
						"markerValue": "current-password",
						"wrapClass": ["search-edit"]
					}
				}, 
				{
					"operation": "insert",
					"name": "newPassword",
					"parentName": "leftPanelContainer",
					"propertyName": "items",
					"values": {
						"id": "new-password",
						"value": {
							"bindTo": "newPassword"
						},
						"controlConfig": {
							"protect": true,
							"rightIconClick": {
								"bindTo": "changeNewPasswordIcon"
							},
							"rightIconClasses": ["hide-password-eye", "show-password-eye"]
						},
						"layout": {
							"column": 1,
							"row": 1,
							"colSpan": 11
						},
						"labelConfig": {
							"caption":  {"bindTo": "Resources.Strings.newPasswordCaption"}
						},
						"keyup": {
							"bindTo": "onNewPasswordKeypress"
						},
						"markerValue": "new-password",
						"wrapClass": ["search-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "newPasswordConfirmation",
					"parentName": "leftPanelContainer",
					"propertyName": "items",
					"values": {
						"id": "new-password-confirmation",
						"value": {
							"bindTo": "newPasswordConfirmation"
						},
						"controlConfig": {
							"protect": true,
							"rightIconClick": {
								"bindTo": "changeNewPasswordConfirmationIcon"
							},
							"rightIconClasses": ["hide-password-eye", "show-password-eye"]
						},
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11
						},
						"labelConfig": {
							"caption": {"bindTo": "getNewPasswordConfirmationCaptionText"}
						},
						"keyup": {
							"bindTo": "onNewPasswordConfirmationKeypress"
						},
						"markerValue": "new-password-confirmation",
						"wrapClass": ["search-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "TotpCode",
					"parentName": "leftPanelContainer",
					"propertyName": "items",
					"values": {
						"id": "totp-code",
						"visible": {"bindTo": "isTotpEnabled"},
						"isRequired": {"bindTo": "isTotpEnabled"},
						"value": {
							"bindTo": "TotpCode"
						},
						"controlConfig": {
							"protect": false
						},
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 11
						},
						"labelConfig": {
							"caption": {
								"bindTo": "Resources.Strings.totpCodeCaption"
							}
						},
						"markerValue": "totp-code",
						"wrapClass": ["search-edit"]
					}
				},
				{
					"operation": "insert",
					"name": "buttonsMenu",
					"parentName": "RelationshipControlGroup",
					"values": {
						"id": "buttonsMenu",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "main-buttons-container",
					"parentName": "buttonsMenu",
					"values": {
						"id": "main-buttons-container",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"items": []
					},
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "change-password-button",
					"parentName": "main-buttons-container",
					"propertyName": "items",
					"values": {
						"id": "change-password-button",
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": {"bindTo": "getStyleChangePasswordButton"},
						"caption": {"bindTo": "getSaveButtonCaptionText"},
						"enabled": {
							"bindTo": "isLdap",
							"bindConfig": {
								"converter": function(value) {
									return !value;
								}
							}
						},
						"click": {"bindTo": "onChangePasswordClick"},
						"classes": {"textClass": ["change-password-save-button"]}
					}
				},
				{
					"operation": "insert",
					"name": "cancel-button",
					"parentName": "main-buttons-container",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"id": "cancel-button",
						"caption": {"bindTo" : "Resources.Strings.cancelButtonCaption"},
						"click": {
							"bindTo": "onCancelClick"
						}
					}
				},
			],

			methods: {

				init: function() {
					this.callParent(arguments);
					this.actualizeColumnRequired();
					this.initIsLdap();
					this.initIsUserDisable2FA();
					this.setTotpStatus();
					this.setHeaderInRecoveryMode();
				},

				getStyleChangePasswordButton: function(){
					return !this.isNotRecoveryMode() ? BPMSoft.controls.ButtonEnums.style.ORANGE : BPMSoft.controls.ButtonEnums.style.DEFAULT;
				},

				getSaveButtonCaptionText: function() {
					return !this.isNotRecoveryMode() ? this.get("Resources.Strings.saveButtonRecoveryModeCaption") : this.get("Resources.Strings.saveButtonCaption");
				},

				getNewPasswordConfirmationCaptionText: function() {
					return !this.isNotRecoveryMode() ? this.get("Resources.Strings.newPasswordConfirmationRecoveryModeCaption") : this.get("Resources.Strings.newPasswordConfirmationCaption");
				},
				
				setHeaderInRecoveryMode: function () {
					if (!this.isNotRecoveryMode()) {
						const idHeader = 'MainHeaderSchemaCaptionValueLabel';
						const header = this.get("Resources.Strings.headerRecoveryModeCaption");
						var isAdded = false;
						document.getElementById("mainHeader").addEventListener("DOMSubtreeModified", function () {
							if (!isAdded) {
								const element = document.getElementById(idHeader);
								if (element) {
									isAdded = true;
									element.innerHTML = header
								}
							}
						});
					}
				},

				actualizeColumnRequired: function() {
					this.columns.currentPassword.isRequired = this.isNotRecoveryMode();
				},

				isNotRecoveryMode: function() {
					var hash = this.BPMSoft.router.Router.getHash();
					return hash.indexOf("PasswordRecoveryMode") === -1;
				},
				
				changeCurrentPasswordIcon: function() {
					const currentPassword = document.querySelector('#current-password-el');
					const currentIcon = document.querySelector('#current-password-right-icon');
					const type = currentPassword.getAttribute("type") === "password" ? "text" : "password";
					currentPassword.setAttribute("type", type);
					currentIcon.classList.toggle('show-password-eye');
				},

				changeNewPasswordIcon: function() {
					const newPassword = document.querySelector('#new-password-el');
					const currentIcon = document.querySelector('#new-password-right-icon');
					const type = newPassword.getAttribute("type") === "password" ? "text" : "password";
					newPassword.setAttribute("type", type);
					currentIcon.classList.toggle('show-password-eye');
				},

				changeNewPasswordConfirmationIcon: function () {
					const newPasswordConfirmation = document.querySelector('#new-password-confirmation-el');
					const currentIcon = document.querySelector('#new-password-confirmation-right-icon');
					const type = newPasswordConfirmation.getAttribute("type") === "password" ? "text" : "password";
					newPasswordConfirmation.setAttribute("type", type);
					currentIcon.classList.toggle('show-password-eye');
				},

				getParameterByName: function(name) {
					name = name.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
					var hash = BPMSoft.router.Router.getHash();
					var regex = new RegExp("[\\?&]" + name + "=([^&]*)"),
						results = regex.exec(hash);
					return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
				},

				/**
				 * Redirects to main page or previous state on success pasword change.
				 */
				successRedirect: function() {
					if (this.isNotRecoveryMode()) {
						this.sandbox.publish("BackHistoryState");
					} else {
						var location = window.location;
						var origin = location.origin || location.protocol + "//" + location.host;
						var url = Ext.String.format("{0}{1}", origin, location.pathname);
						this.changeUrl(url);
					}
				},

				/**
				 * Sets url to native window.location.url.
				 * @private
				 * @param {String} url Url to set.
				 */
				changeUrl: function(url) {
					window.location.href = url;
				},

				setTotpStatus: function() {
					BPMSoft.AjaxProvider.request({
						url: BPMSoft.workspaceBaseUrl +
							"/../ServiceModel/TotpSetupService.svc/GetTotpInfo",
						method: "POST",
						jsonData: null,
						callback: function(options, result, response) {
							var responseObject = BPMSoft.decode(response.responseText);
							this.set("IsTotpEnabled", responseObject.GetTotpInfoResult.isTotpEnabled);
							this.set("TotpProviderName", responseObject.GetTotpInfoResult.providerName);
						},
						scope: this
					});
				},

				onChangePasswordClick: function() {
					var isValid = this.validate();

					if (!isValid) {
						return;
					}

					var passwordIsNotValidMessage = this.validatePassword();

					if (passwordIsNotValidMessage) {
						this.showInformationDialog(passwordIsNotValidMessage);
						return;
					}

					this.showConfirmationDialog(this.get("Resources.Strings.ChangePasswordWarning"),
						function(returnCode) {
							if (returnCode === this.BPMSoft.MessageBoxButtons.NO.returnCode || returnCode === null) {
								return;
							}
							this.validateTotpCode(this.changePassword);
						},
						[this.BPMSoft.MessageBoxButtons.YES.returnCode, this.BPMSoft.MessageBoxButtons.NO.returnCode],
						null);
				},

				validatePassword: function() {
					var password = BPMSoft.Password;
					var newPassword = this.get("newPassword");
					var localizableStrings = resources.localizableStrings;

					var passwordMustMeetTheSecurityCriteria 
						= localizableStrings.PasswordMustMeetTheSecurityCriteria;

					var validationResultMessage = BPMSoft.emptyString;

					if (!password.containsAtLeastEightCharacters(newPassword)) {
						validationResultMessage += 
							`\n ${localizableStrings.PasswordIsAtLeastEigthCharactersLong}`;
					}

					if (!password.containsAtLeastOneCharactersWithUpperCase(newPassword)) {
						validationResultMessage += 
							`\n ${localizableStrings.NumberOfUpperCaseCharactersIsAtLeastOne}`;
					}

					if (!password.containsAtLeastOneCharacterWithLowercase(newPassword)) {
						validationResultMessage += 
							`\n ${localizableStrings.NumberOfLowercaseCharactersIsAtLeastOne}`;
					}

					if (!password.containsAtLeastOneDigit(newPassword)) {
						validationResultMessage += 
							`\n ${localizableStrings.NumberOfDigitsIsAtLeastOne}`;
					}

					if (!password.containsAtLeastOneSpecialCharacter(newPassword)) {
						validationResultMessage += 
							`\n ${localizableStrings.NumberOfSpecialCharactersIsAtLeastOne}`;
					}

					if (validationResultMessage === BPMSoft.emptyString) {
						return null;
					}

					return passwordMustMeetTheSecurityCriteria += validationResultMessage;
				},

				validateTotpCode: function(callback) {
					if (!this.isTotpEnabled()) {
						return this.Ext.callback(callback, this);
					}
					var data = {
						totpCode: this.get("TotpCode")
					};
					BPMSoft.AjaxProvider.request({
						url: BPMSoft.workspaceBaseUrl +
							"/ServiceModel/TotpChangePasswordValidator.svc/VerifyOnlyTotpCode",
						method: "POST",
						jsonData: data,
						callback: function(options, result, response) {
							var responseObject = BPMSoft.decode(response.responseText);
							if (responseObject && responseObject.VerifyOnlyTotpCodeResult && responseObject.VerifyOnlyTotpCodeResult.isSuccess) {
								var isTotpValid = responseObject.VerifyOnlyTotpCodeResult.isTotpCodeValid;
								if (isTotpValid) {
									return this.Ext.callback(callback, this);
								} else {
									this.showInformationDialog(resources.localizableStrings.invalidTotpToken);
								}
							} else {
								this.log(responseObject.VerifyOnlyTotpCodeResult.additionalInfo);
								this.showInformationDialog(resources.localizableStrings.invalidTotpToken);
							}
						},
						scope: this
					});
				},

				changePassword: function() {
					var password = this.get("currentPassword");
					var newPassword = this.get("newPassword");
					var newPasswordConfirmation = this.get("newPasswordConfirmation");
					var sysValues = BPMSoft.SysValue;
					var passwordRecoveryModeKey = this.getParameterByName("PasswordRecoveryMode");
					var authToken = {
						UserName: sysValues.CURRENT_USER.displayValue,
						UserPassword: password,
						WorkspaceName: sysValues.CURRENT_WORKSPACE.displayValue,
						NewUserPassword: newPassword,
						ConfirmUserPassword: newPasswordConfirmation,
						PasswordRecoveryMode: passwordRecoveryModeKey
					};
					if (this.isTotpEnabled()) {
						authToken.ClaimList = this.getAdditionalTotpClaims();
						authToken.ProviderName = this.get("TotpProviderName");
					}
					var changePasswordServiceUrl = BPMSoft.workspaceBaseUrl +
						"/../ServiceModel/AuthService.svc/DoChangePasswordLogin";
					BPMSoft.AjaxProvider.request({
						url: changePasswordServiceUrl,
						method: "POST",
						jsonData: authToken,
						callback: function(options, result, response) {
							var localizableStrings = resources.localizableStrings;
							if (!result) {
								var errorMessage = localizableStrings.errorPasswordChangeMessage;
								this.showInformationDialog(errorMessage, Ext.emptyFn);
							}
							var responseObject = BPMSoft.decode(response.responseText);
							if (responseObject.Code !== 0) {
								this.showInformationDialog(responseObject.Message, Ext.emptyFn);
							} else {
								var successMessage = localizableStrings.successPasswordChangeMessage;
								const isNotRecoveryMode=this.isNotRecoveryMode()
								this.showInformationDialog(successMessage, function() {
									var dataSend = {
										userId: sysValues.CURRENT_USER.value
										};
									var config = {
										serviceName: "AdministrationService",
										methodName: "TerminateUserSessions",
										data: dataSend
									};
									this.callService(config, function(){
										if(isNotRecoveryMode) {
										window.location.reload();
									}
									else{
										this.successRedirect();
									}
									});									
								});
							}
						},
						scope: this
					});
				},

				onCancelClick: function() {
					this.successRedirect();
				},

				onNewPasswordKeypress: function() {
					var newPasswordTextEdit = Ext.getCmp("new-password");
					var newPasswordInputValue = newPasswordTextEdit.getTypedValue();
					this.set("newPassword", newPasswordInputValue);
				},

				onNewPasswordConfirmationKeypress: function() {
					var newPasswordConfirmationTextEdit = Ext.getCmp("new-password-confirmation");
					var newPasswordConfirmationInputValue = newPasswordConfirmationTextEdit.getTypedValue();
					this.set("newPasswordConfirmation", newPasswordConfirmationInputValue);
				},

				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("newPassword", this.newPasswordValidator);
					this.addColumnValidator("newPasswordConfirmation", this.newPasswordConfirmationValidator);
				},

				newPasswordValidator: function(newPassword) {
					var newPasswordConfirmation = this.get("newPasswordConfirmation");
					var invalidMessage = "";
					if (!Ext.isEmpty(newPasswordConfirmation)) {
						if (newPasswordConfirmation !== newPassword) {
							invalidMessage = resources.localizableStrings.passwordMissMatchMessageCaption;
						} else {
							this.validationInfo.set("newPasswordConfirmation", {
								invalidMessage: "",
								isValid: true
							});
						}
					}
					return {
						invalidMessage: invalidMessage
					};
				},

				newPasswordConfirmationValidator: function(newPasswordConfirmation) {
					var newPassword = this.get("newPassword");
					var invalidMessage = "";
					if (newPasswordConfirmation !== newPassword) {
						invalidMessage = resources.localizableStrings.passwordMissMatchMessageCaption;
					} else {
						this.validationInfo.set("newPassword", {
							invalidMessage: "",
							isValid: true
						});
					}
					return {
						invalidMessage: invalidMessage
					};
				},

				initIsLdap: function() {
					ServiceHelper.callService({
						serviceName: "CurrentUserService",
						methodName: "GetIsCurrentUserSynchronizedWithLdap",
						callback: function(response, success) {
							if (success && response) {
								this.set("isLdap", response.isSynchronized);
							}
						},
						scope: this
					});
				},

				initIsUserDisable2FA: function() {
					ServiceHelper.callService({
						serviceName: "CurrentUserService",
						methodName: "GetIsCurrentUserDisable2FA",
						callback: function(response, success) {
							if (success && response) {
								this.set("isUserDisable2FA", response.isUserDisable2FA);
							}
						},
						scope: this
					});
				},

				isTotpEnabled : function() {
					return this.get("IsTotpEnabled") && !this.get("isUserDisable2FA");
				},

				getAdditionalTotpClaims: function() {
					var userClaims = [];
					var totpUserClaim = {
						"Key": "token",
						"Value": this.get("TotpCode")
					};
					userClaims.push(totpUserClaim);
					return userClaims;
				},

			}
		};
	});
