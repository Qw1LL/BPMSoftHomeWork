define("RemindPassword", ["ext-base", "BPMSoft", "sandbox", "RemindPasswordResources"],
		function(Ext, BPMSoft, sandbox, resources) {

			var module = {};
			var renderContainer;
			var recoveryPasswordToken;
			const headClass = "login-label-logo";
			const versionClass = "forget-version";

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
			
			const addHtmlElem = function() {
				const div = document.createElement('div');
				div.innerHTML = `
		<div id = "image-edit-header" class="ts-image-edit-header">Забыли пароль?</div>
		`;
				document.querySelector('.ts-image-edit-inner-container').appendChild(div);
			}
			
			var renderView = function(renderTo) {
				const version = Ext.create("BPMSoft.Label", {
					caption: {
						bindTo: "productVersion"
					},
					classes: {
						labelClass: [versionClass]
					}
				});
				let imageUrl = BPMSoft.appFramework === "NETFRAMEWORK"
					? window.loginImageUrl
					: "/img/LogoImage";
				const logo = Ext.create("BPMSoft.ImageEdit", {
					readonly: true,
					classes: {
						wrapClass: [headClass]
					},
					imageSrc: imageUrl
				});
				var forgetLabel = Ext.create("BPMSoft.Label", {
					caption: resources.localizableStrings.ForgetPassword,
					classes: {labelClass: ["forget"]}
				});
				var mailLabel = Ext.create("BPMSoft.Label", {
					caption: resources.localizableStrings.EmailOrLogin,
					classes: {labelClass: ["label"]}
				});
				var mailEdit = Ext.create("BPMSoft.TextEdit", {
					value: {bindTo: "EmailOrLogin"},
					classes: {wrapClass: ["input-edit"]},
					keyup: {bindTo: "onKeyUp"},
					markerValue: "emailEdit"
				});
				var remindPasswordButton = Ext.create("BPMSoft.Button", {
					caption: resources.localizableStrings.RecoverPassword,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					classes: {textClass: ["button"]},
					click: {bindTo: "onRemindPasswordClick"},
					markerValue: "btnRemindPassword"
				});
				const cancelButton = Ext.create("BPMSoft.Button", {
					caption: resources.localizableStrings.Cancel,
					classes: {textClass: ["button-cancel"]},
					click: {bindTo: "onCancelButtonClick"},
					markerValue: "btnCancel"
				});
				var remindPasswordContainer = Ext.create("BPMSoft.Container", {
					id: "remindPasswordContainer",
					selectors: {wrapEl: "#remindPasswordContainer"},
					items: [forgetLabel, mailLabel, mailEdit, remindPasswordButton, cancelButton]
				});
				var contFooter = Ext.create("BPMSoft.Container", {
					id: "remindPasswordFooterContainer",
					classes: {
						wrapClassName: ["remindPassword-container-footer"]
					},
					items: [version]
				});
				module.view = Ext.create("BPMSoft.Container", {
					id: "container",
					selectors: {wrapEl: "#container"},
					classes: {wrapClassName: ["remindPassword-container"]},
					items: [logo, remindPasswordContainer, contFooter],
					renderTo: renderTo
				});
				addHtmlElem();
			};
			
			
			const prepareModel = function() {

				module.model = Ext.create("BPMSoft.BaseViewModel", {
					values: {
						productVersion: BPMSoft.frameworkDescription
						? `${BPMSoft.Resources.LoginPage.Version} ${BPMSoft.coreVersion} (${BPMSoft.frameworkDescription})`
						: `${BPMSoft.Resources.LoginPage.Version} ${BPMSoft.coreVersion}`,
						workspaceList: Ext.create("BPMSoft.Collection")
					},
					columns: {
						EmailOrLogin: {
							dataValueType: BPMSoft.DataValueType.TEXT,
							isRequired: true,
							caption: resources.localizableStrings.EmailOrLogin
						}
					},
					methods: {
						onRemindPasswordClick: function() {
							var emailOrLogin = this.get("EmailOrLogin");
							if (!emailOrLogin) {
								this.showInformationDialog(resources.localizableStrings.RequiredEmailOrLogin);
							}
							else {
								var remindPasswordCallback = function(success, response) {
									if (!success) {
										return;
									}
									var responseObject = BPMSoft.decode(response);
									var resultCode = responseObject.ResultCode;
									if (!resultCode) {
										return;
									}
									switch (resultCode) {
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
													window.location.replace(BPMSoft.loaderBaseUrl + "SspLogin.aspx");
												});
											});
											break;
									}
								};
								recoveryPasswordToken = {
									EmailOrLogin: emailOrLogin
								};
								callServiceMethod("RemindPassword", remindPasswordCallback, recoveryPasswordToken, this);
							}
						},
						
						onCancelButtonClick: function() {
							window.history.go(-1);
						},

						onKeyUp: function(e) {
							if (e && e.keyCode === e.ENTER) {
								this.onRemindPasswordClick();
							}
						}
					}
				});
			};
			
			

			var init = function() {
				prepareModel();
			};

			var render = function(renderTo) {
				renderContainer = renderTo;
				renderView(renderContainer);
				module.view.bind(module.model);
			};

			return {
				init: init,
				render: render,
				renderTo: Ext.getBody()
			};
		});
