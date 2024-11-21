define("Registration", ["ext-base", "BPMSoft", "sandbox", "RegistrationResources", "RegistrationRes", "FeatureServiceRequest"],
	function(Ext, BPMSoft, sandbox, resources) {

		var module = {};
		var renderContainer;
		var userManagementToken;
		var registrationResources;
		var checkTermsAndConditionsSettingsValue;

		var callServiceMethod = function(name, callback, data, scope) {
			var workspaceBaseUrl = BPMSoft.Features.getIsEnabled("EnableCustomPrefixRouteApi")
				? BPMSoft.utils.common.combinePath(BPMSoft.workspaceBaseUrl, "ssp")
				: BPMSoft.workspaceBaseUrl;
			var requestUrl = workspaceBaseUrl + "/rest/UserManagementService/" + name;
			BPMSoft.AjaxProvider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				callback: function(request, success, response) {
					var responseObject = {};
					if (success) {
						responseObject = BPMSoft.decode(response.responseText);
					}
					callback.call(this, success, responseObject);
				},
				scope: scope
			});
		};

		var initResources = function(callback, scope) {
			if (Ext.isEmpty(registrationResources)) {
				BPMSoft.require(["RegistrationResResources"], function(RegistrationResResources) {
					registrationResources = RegistrationResResources;
					callback.call(scope);
				});
			} else {
				callback.call(scope);
			}
		};

		var prepareModel = function() {
			module.model = Ext.create("BPMSoft.BaseViewModel", {
				columns: {
					Surname: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true,
						caption: resources.localizableStrings.Surname
					},
					FirstName: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true,
						caption: resources.localizableStrings.FirstName
					},
					AdditionalName: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						caption: resources.localizableStrings.AdditionalName
					},
					Email: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true,
						caption: resources.localizableStrings.Email
					},
					Password: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true,
						caption: resources.localizableStrings.Password
					},
					ConfirmPassword: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true,
						caption: resources.localizableStrings.ConfirmPassword
					}
				},
				methods: {
					onRegisterClick: function() {
						var columns = ["Surname", "FirstName", "Email", "Password", "ConfirmPassword"];
						var invalidColumns = [];
						columns.forEach(function(columnName) {
							var value = this.get(columnName);
							if (!value) {
								invalidColumns.push(this.columns[columnName].caption);
							}
						}, this);
						if (invalidColumns.length) {
							var message;
							var value;
							if (invalidColumns.length === 1) {
								message = resources.localizableStrings.RequiredField;
								value = invalidColumns[0];
							} else {
								message = resources.localizableStrings.RequiredFields;
								value = invalidColumns.join(", ");
							}
							this.showInformationDialog(Ext.String.format(message, value));
						} else if (this.get("Email").indexOf("@") === -1) {
							this.showInformationDialog(resources.localizableStrings.InvalidEmail);
						} else if (this.get("Password") !== this.get("ConfirmPassword")) {
							this.showInformationDialog(resources.localizableStrings.PasswordsDoNotMatch);
						} else if (isTermsFeatureEnabled() && this.get("IsAgreed") !== true) {
							this.showInformationDialog(resources.localizableStrings.IsAgreedRequired);
						} else {
							var registerCallback = function(success, response) {
								if (!success) {
									return;
								}
								var responseObject = BPMSoft.decode(response);
								var resultCode = responseObject.ResultCode;
								if (!resultCode) {
									return;
								}
								switch (resultCode) {
									case "LoginIsReserved":
									case "ExistingSysAdminUnit":
									case "Error":
										var resultMessage = responseObject.ResultMessage.replace(/\\n/g, "\n");
										this.showInformationDialog(resultMessage);
										break;
									case "Success":
										var successMessage = resources.localizableStrings.SuccessMessage;
										this.showInformationDialog(successMessage, function() {
											callServiceMethod("Logout", function() {
												window.logout = true;
												window.location.replace(BPMSoft.loaderBaseUrl + "Login/SspLogin.aspx");
											});
										});
										break;
								}
							};
							userManagementToken = {
								Surname: this.get("Surname"),
								FirstName: this.get("FirstName"),
								AdditionalName: this.get("AdditionalName"),
								Email: this.get("Email"),
								Password: this.get("Password"),
								WorkspaceBaseUrl: BPMSoft.loaderBaseUrl
							};
							callServiceMethod("Register", registerCallback, userManagementToken, this);
						}
					},

					onKeyUp: function(e) {
						if (e && e.keyCode === e.ENTER) {
							this.onRegisterClick();
						}
					}
				}
			});
		};

		var renderView = function(renderTo) {
			var imageUrl = BPMSoft.appFramework === "NETFRAMEWORK"
				? window.loginImageUrl
				: "/img/LogoImage?mode=ssp";
			var html = "<img id = 'bpmcrm-logo' src = '" + imageUrl + "'>";
			var logo = {
				id: "bpmcrm-logo",
				className: "BPMSoft.HtmlControl",
				html: html,
				selectors: {wrapEl: "#bpmcrm-logo"}
			};
			var surnameLabel = Ext.create("BPMSoft.Label", {
				caption: resources.localizableStrings.Surname,
				classes: {labelClass: ["label t-label-is-required"]}
			});
			var surnameEdit = Ext.create("BPMSoft.TextEdit", {
				value: {bindTo: "Surname"},
				classes: {wrapClass: ["edit"]},
				keyup: {bindTo: "onKeyUp"},
				markerValue: "surnameEdit"
			});
			var firstNameLabel = Ext.create("BPMSoft.Label", {
				caption: resources.localizableStrings.FirstName,
				classes: {labelClass: ["label t-label-is-required"]}
			});
			var fistNameEdit = Ext.create("BPMSoft.TextEdit", {
				value: {bindTo: "FirstName"},
				classes: {wrapClass: ["edit"]},
				keyup: {bindTo: "onKeyUp"},
				markerValue: "firstNameEdit"
			});
			var additionalNameLabel = Ext.create("BPMSoft.Label", {
				caption: resources.localizableStrings.AdditionalName,
				classes: {labelClass: ["label"]}
			});
			var additionalNameEdit = Ext.create("BPMSoft.TextEdit", {
				value: {bindTo: "AdditionalName"},
				classes: {wrapClass: ["edit"]},
				keyup: {bindTo: "onKeyUp"},
				markerValue: "additionalNameEdit"
			});
			var mailLabel = Ext.create("BPMSoft.Label", {
				caption: resources.localizableStrings.Email,
				classes: {labelClass: ["label t-label-is-required"]}
			});
			var mailEdit = Ext.create("BPMSoft.TextEdit", {
				value: {bindTo: "Email"},
				classes: {wrapClass: ["edit"]},
				keyup: {bindTo: "onKeyUp"},
				markerValue: "emailEdit"
			});
			var passwordLabel = Ext.create("BPMSoft.Label", {
				caption: resources.localizableStrings.Password,
				classes: {labelClass: ["label t-label-is-required"]}
			});
			var passwordEdit = Ext.create("BPMSoft.TextEdit", {
				value: {bindTo: "Password"},
				classes: {wrapClass: ["edit"]},
				protect: true,
				keyup: {bindTo: "onKeyUp"},
				markerValue: "passwordEdit"
			});
			var confirmPasswordLabel = Ext.create("BPMSoft.Label", {
				caption: resources.localizableStrings.ConfirmPassword,
				classes: {labelClass: ["label t-label-is-required"]}
			});
			var confirmPasswordEdit = Ext.create("BPMSoft.TextEdit", {
				value: {bindTo: "ConfirmPassword"},
				classes: {wrapClass: ["edit"]},
				protect: true,
				keyup: {bindTo: "onKeyUp"},
				markerValue: "confirmPasswordEdit"
			});
			var registerButton = Ext.create("BPMSoft.Button", {
				caption: resources.localizableStrings.Register,
				style: BPMSoft.controls.ButtonEnums.style.ORANGE,
				classes: {textClass: ["button", "register-btn"]},
				click: {bindTo: "onRegisterClick"},
				markerValue: "btnRegister"
			});
			var projectVersion = Ext.create("BPMSoft.Label", {
				caption: BPMSoft.frameworkDescription 
				? `${resources.localizableStrings.Version} ${BPMSoft.coreVersion} (${BPMSoft.frameworkDescription})` 
				: `${resources.localizableStrings.Version} ${BPMSoft.coreVersion}`,
				classes: {labelClass: ["label", "project-version"]}
			});
			var registerTitle = Ext.create("BPMSoft.Label", {
				caption: resources.localizableStrings.Registration,
				classes: {labelClass: ["label", "registration-title"]}
			});
			var cancelButton = Ext.create("BPMSoft.Button", {
				caption: resources.localizableStrings.BackButton,
				style: BPMSoft.controls.ButtonEnums.style.ORANGE,
				classes: {textClass: ["button", "cancel-btn"]},
				click: {bindTo: "onCancelClick"},
				markerValue: "btnCancel",
				listeners: {
					click: function() {
						if(BPMSoft.frameworkDescription){
							if(BPMSoft.frameworkDescription.includes('Core')){
								window.location='/Login/SSPLogin.html';
							}
							else{
								window.location = '/login/SSPLogin.aspx';
							}
						}
						else{
							window.location='/login/SSPLogin.aspx';
						}
					}
				}
			});
			var headerContainer = Ext.create("BPMSoft.Container", {
				id: "registrationHeader",
				classes: {
					wrapClassName: ["registration-header-wrapper"]
				},
				selectors: {wrapEl: "#registrationHeader"},
				items: [registerTitle, logo]
			});
			var surnameContainer = Ext.create("BPMSoft.Container", {
				id: "surnameContainer",
				classes: {
					wrapClassName: ["registration-input", "surname-container"]
				},
				selectors: {wrapEl: "#surnameContainer"},
				items: [surnameLabel, surnameEdit]
			});
			var firstNameContainer = Ext.create("BPMSoft.Container", {
				id: "firstNameContainer",
				classes: {
					wrapClassName: ["registration-input", "first-name-container"]
				},
				selectors: {wrapEl: "#firstNameContainer"},
				items: [firstNameLabel, fistNameEdit]
			});
			var additionalNameContainer = Ext.create("BPMSoft.Container", {
				id: "additionalNameContainer",
				classes: {
					wrapClassName: ["registration-input", "additional-name-container"]
				},
				selectors: {wrapEl: "#additionalNameContainer"},
				items: [additionalNameLabel, additionalNameEdit]
			});
			var mailContainer = Ext.create("BPMSoft.Container", {
				id: "mailContainer",
				classes: {
					wrapClassName: ["registration-input", "mail-container"]
				},
				selectors: {wrapEl: "#mailContainer"},
				items: [mailLabel, mailEdit]
			});
			var passwordContainer = Ext.create("BPMSoft.Container", {
				id: "passwordContainer",
				classes: {
					wrapClassName: ["registration-input", "password-container"]
				},
				selectors: {wrapEl: "#passwordContainer"},
				items: [passwordLabel, passwordEdit]
			});
			var confirmPasswordContainer = Ext.create("BPMSoft.Container", {
				id: "confirmPasswordContainer",
				classes: {
					wrapClassName: ["registration-input", "confirm-password-container"]
				},
				selectors: {wrapEl: "#confirmPasswordContainer"},
				items: [confirmPasswordLabel, confirmPasswordEdit]
			});
			var registrationContainer = Ext.create("BPMSoft.Container", {
				id: "registrationContainer",
				selectors: {wrapEl: "#registrationContainer"},
				items: [surnameContainer, firstNameContainer,
					additionalNameContainer, mailContainer,
					passwordContainer, confirmPasswordContainer]
			});
			var buttonsContainer = Ext.create("BPMSoft.Container", {
				id: "regisrationBtns",
				classes: {
					wrapClassName: ["registration-buttons-wrapper"]
				},
				selectors: {wrapEl: "#regisrationBtns"},
				items: [registerButton, cancelButton]
			});
			if (isTermsFeatureEnabled()) {
				var isAgreedCheckbox = Ext.create("BPMSoft.CheckBoxEdit", {
					checked: {bindTo: "IsAgreed"},
					classes: {wrapClass: ["edit"]},
					markerValue: "isAgreedCheckbox"
				});
				var isAgreedLabel = Ext.create("BPMSoft.HtmlControl", {
					id: "is-Agreed",
					html: Ext.String.format("<span id='is-Agreed' class='t-label'>{0}</span>",
						registrationResources.localizableStrings.IsAgreed),
					selectors: {wrapEl: "#is-Agreed"}
				});
				var isAgreedContainer = Ext.create("BPMSoft.Container", {
					id: "isAgreedContainer",
					classes: {
						wrapClassName: ["registration-checkbox-wrapper"]
					},
					items: [isAgreedCheckbox, isAgreedLabel]
				})
				registrationContainer.add(isAgreedContainer);
			}
			module.view = Ext.create("BPMSoft.Container", {
				id: "container",
				selectors: {wrapEl: "#container"},
				classes: {wrapClassName: ["registration-container"]},
				items: [headerContainer, registrationContainer, buttonsContainer, projectVersion],
				renderTo: renderTo
			});
		};

		var isTermsFeatureEnabled = function() {
			return checkTermsAndConditionsSettingsValue === true;
		};

		var initSysSettings = function(callback, scope) {
			BPMSoft.SysSettings.querySysSettingsItem("CheckTermsAndConditions", function(isCheck) {
				checkTermsAndConditionsSettingsValue = isCheck;
				callback.call(scope);
			});
		};

		var init = function() {
			initResources(prepareModel);
		};

		var render = function(renderTo) {
			BPMSoft.chain(
				initResources,
				initSysSettings,
				function() {
					renderContainer = renderTo;
					renderView(renderContainer);
					module.view.bind(module.model);
				}
			);
		};

		return {
			init: init,
			render: render,
			renderTo: Ext.getBody()
		};
	});