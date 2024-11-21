/*jshint maxparams: 20 */
define("ProfileModule", ["ext-base", "BPMSoft", "sandbox", "ProfileModuleResources", "ConfigurationConstants",
	"LookupUtilities", "Contact", "StorageUtilities", "SysAdminUnit", "DesktopPopupNotification", "ServiceHelper",
	"MaskHelper"],
	function(Ext, BPMSoft, sandbox, resources, ConfigurationConstants,
		LookupUtilities, Contact, storageUtilities, SysAdminUnit, DesktopPopupNotification, ServiceHelper, MaskHelper) {
		var viewModel;
		var container;

		function callServiceMethod(methodName, callback, dataSend) {
			const ajaxProvider = BPMSoft.AjaxProvider;
			const data = dataSend || {};
			const workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			const requestUrl = workspaceBaseUrl + "/rest/CommandLineService/" + methodName;
			const request = ajaxProvider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				callback: function(request, success, response) {
					let responseObject = {};
					if (success) {
						responseObject = BPMSoft.decode(response.responseText);
					}
					callback.call(this, responseObject);
				},
				scope: this
			});
			return request;
		}

		function getCulture() {
			ServiceHelper.callService({
				serviceName: "CurrentUserService",
				methodName: "GetCurrentUserCulture",
				callback: function(response, success) {
					if (!success || !response || !response.cultureInfo) {
						return;
					}
					const cultureInfo = response.cultureInfo;
					const cultureId = cultureInfo.cultureId;
					const cultureName = cultureInfo.cultureName;
					const timeZoneCode = cultureInfo.timeZoneCode;
					const timeZoneId = cultureInfo.timeZoneId;
					const timeZoneName = cultureInfo.timeZoneName;
					viewModel.set("defculture", {value: cultureId, displayValue: cultureName});
					viewModel.set("deftimeZone", {value: timeZoneId, displayValue: timeZoneName, code: timeZoneCode});
					viewModel.set("deftimeZoneId", timeZoneCode);
					viewModel.set("culture", {value: cultureId, displayValue: cultureName});
					viewModel.set("timeZone", {value: timeZoneId, displayValue: timeZoneName, code: timeZoneCode});
					viewModel.set("timeZoneId", timeZoneCode);
				},
				scope: this
			});
		}

		/**
		 * ############## ########### #######.
		 * @protected
		 * @virtual
		 */
		function loadContextHelp(id) {
			var contextHelpConfig = {
				contextHelpId: id,
				contextHelpCode: "ProfileModule"
			};
			sandbox.publish("InitContextHelp", contextHelpConfig);
		}

		function loadHeader(renderTo) {
			if (!viewModel) {
				viewModel = getViewModel();
			}
			var viewConfig = getViewModel();
			viewConfig = generateMainView();

			var sysSettings = ["BuildType"];
			BPMSoft.SysSettings.querySysSettings(sysSettings, function() {
				var buildType = BPMSoft.SysSettings.cachedSettings.BuildType &&
						BPMSoft.SysSettings.cachedSettings.BuildType.value;
				viewModel.set("visibleByBuildType", buildType !==
					ConfigurationConstants.BuildType.Public);
			}, this);
			viewConfig.bind(viewModel);
			viewConfig.render(renderTo);
		}

		/**
		 * ########## ######### ###### ####### ########### ## ####### ########### ########.
		 * @private
		 * @returns {String} ########## ######### ### ######.
		 */
		function getNotificationButtonCaption() {
			switch (DesktopPopupNotification.getPermissionLevel()) {
				case DesktopPopupNotification.PermissionType.GRANTED:
					return resources.localizableStrings.displayNotificationsAllowCaption;
				case DesktopPopupNotification.PermissionType.DENIED:
					return resources.localizableStrings.displayNotificationsDeniedCaption;
				default:
					return resources.localizableStrings.displayNotificationsCaption;
			}
		}

		var getViewModel = function() {
			return Ext.create("BPMSoft.BaseViewModel", {
				columns: {
					languageList: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "languageList",
						isCollection: true
					},
					culture: {
						type: BPMSoft.ViewModelColumnType.ATTRIBUTE,
						name: "culture",
						isRequired: true
					}
				},
				values: {
					languageList: Ext.create("BPMSoft.Collection"),
					timeZone: null,
					timeZoneList: Ext.create("BPMSoft.Collection"),
					timeZoneId: null,
					visibleByBuildType: false,
					notificationButtonCaption: getNotificationButtonCaption(),
					notificationButtonEnabled: DesktopPopupNotification.getPermissionLevel() ===
						DesktopPopupNotification.PermissionType.DEFAULT,
					isNotificationsSupported: DesktopPopupNotification.getIsNotificationSupported(),
					isSsp: BPMSoft.isCurrentUserSsp()
				},
				methods: {
					onCancel: function() {
						sandbox.publish("BackHistoryState");
					},
					onClick: function() {
						if (this.validate()) {
							var culture = this.get("culture");
							var defCulture = viewModel.get("defculture");
							var cultureChanged = (culture.value !== defCulture.value);
							var timeZone = this.get("timeZone");
							var currentTimeZoneCode = (timeZone) ? timeZone.code : null;
							var timeZoneChanged = (currentTimeZoneCode !== viewModel.get("deftimeZoneId"));
							var currentTimeZone = (timeZone) ? timeZone.value : null;
							if (!cultureChanged && !timeZoneChanged) {
								this.onCancel();
								return;
							}
							var changedColumns = {};
							if (cultureChanged) {
								changedColumns.SysCulture = culture.value;
							}
							if (timeZoneChanged) {
								changedColumns.TimeZone = currentTimeZone ? currentTimeZone : BPMSoft.GUID_EMPTY;
							}
							var saveCallback = function(response) {
								if (response) {
									response.message = response.UpdateOrCreateUserResult;
									response.success = Ext.isEmpty(response.message);
								}
								if (response.success) {
									if (timeZoneChanged) {
										this.showInformationDialog(
											resources.localizableStrings.childChangeTimeZoneMessage,
											this.onCancel
										);
									} else {
										this.onCancel();
									}
								}
							};
							var config = {
								serviceName: "UserProfileEditService",
								methodName: "UpdateUserProfile",
								callback: saveCallback,
								scope: this,
								data: { 
									updateUser: changedColumns
								}
							};
							ServiceHelper.callService(config, this);
						}
					},
					passwordClick: function() {
						var passwordModule = "ChangePasswordModule";
						sandbox.publish("PushHistoryState", {hash: passwordModule});
					},
					socialClick: function() {
						var socialModule = "SocialAccountModule";
						sandbox.publish("PushHistoryState", {hash: socialModule});
					},
					mailClick: function() {
						var mailModule = "MailboxSynchronizationSettingsModule";
						sandbox.publish("PushHistoryState", {hash: mailModule});
					},
					openCommandsGrid: function() {
						var contactFiler = BPMSoft.createFilterGroup();
						contactFiler.name = "contactFiler";
						var filter = BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "CreatedBy",
							BPMSoft.SysValue.CURRENT_USER_CONTACT.value);
						contactFiler.addItem(filter);
						var config = {
							entitySchemaName: "Macros",
							mode: "editMode",
							multiSelect: false,
							columnName: "Name",
							filters: contactFiler,
							cardCustomConfig: {
								cardSchema: "MacrosPageModule"
							},
							methods: {
								onDeleted: function() {
									callServiceMethod("ClearCache", function() {
											storageUtilities.clearStorage(
												storageUtilities.ClearStorageModes.GROUP, "CommandLineStorage");
											sandbox.publish("ChangeCommandList");
										},
										{
											"cacheArray": ["VwCommandActionCache", "CommandParamsCache"]
										});
								}
							}
						};
						var handler = function() {
						};
						LookupUtilities.Open(sandbox, config, handler, this);
					},
					onPrepareLanguageList: function() {
						var cultureSelect = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "SysCulture"});
						cultureSelect.addColumn("Id");
						cultureSelect.addColumn("Name");
						cultureSelect.getEntityCollection(function(response) {
							var list = this.get("languageList");
							if (response.success) {
								var responseItems = response.collection.getItems();
								var columnList = {};
								BPMSoft.each(responseItems, function(item) {
									columnList[item.get("Id")] = {
										value: item.get("Id"),
										displayValue: item.get("Name")
									};
								});
								list.clear();
								list.loadAll(columnList);
							}
						}, this);
					},
					onPrepareTimeZoneList: function() {
						var cultureSelect = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "TimeZone"
						});
						cultureSelect.addColumn("Id");
						cultureSelect.addColumn("Name");
						cultureSelect.addColumn("Code");
						cultureSelect.getEntityCollection(function(response) {
							var list = this.get("timeZoneList");
							if (response.success) {
								var responseItems = response.collection.getItems();
								var columnList = {};
								BPMSoft.each(responseItems, function(item) {
									columnList[item.get("Id")] = {
										value: item.get("Id"),
										displayValue: item.get("Name"),
										code: item.get("Code")
									};
								});
								list.clear();
								list.loadAll(columnList);
							}
						}, this);
					},
					flashToDefault: function() {
						this.showConfirmationDialog(resources.localizableStrings.onFlashWarning, function(returnCode) {
							if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
								var query = Ext.create("BPMSoft.DeleteQuery", {
									rootSchemaName: "SysProfileData"
								});
								var currentUserContactId = BPMSoft.SysValue.CURRENT_USER_CONTACT.value;
								var filter = BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "Contact", currentUserContactId);
								query.filters.addItem(filter);
								query.execute(this.onFlashed, this);
							}
						}, ["yes", "no"]);
					},
					onFlashed: function(response) {
						if (response && response.success) {
							this.showConfirmationDialog(resources.localizableStrings.flashSuccessful,
							function(returnCode) {
								if (returnCode === BPMSoft.MessageBoxButtons.CLOSE.returnCode) {
									window.location.reload();
								}
							});
						} else {
							this.showConfirmationDialog(resources.localizableStrings.onFlashError);
						}
					},
					/**
					 * ######### ###### ## ########## ########### # ############# ############### ######### ######.
					 * @public
					 */
					requestNotificationPermission: function() {
						var scope = this;
						DesktopPopupNotification.requestPermission(function() {
							var buttonCaption = getNotificationButtonCaption();
							var buttonEnabled = (DesktopPopupNotification.getPermissionLevel() ===
								DesktopPopupNotification.PermissionType.DEFAULT);
							scope.set("notificationButtonCaption", buttonCaption);
							scope.set("notificationButtonEnabled", buttonEnabled);
						});
					},
					isLanguageSelectionVisible: function() {
						return (this.get("visibleByBuildType") && !this.get("isSsp"));
					},
					isTimezoneSelectionVisible: function() {
						return this.get("visibleByBuildType");
					},
					isCommandLineSettingsVisible: function() {
						return !this.get("isSsp");
					},
					isDefaultSettingsButtonVisible: function() {
						return !this.get("isSsp");
					},
					isSyncSettingsVisible: function() {
						return (this.get("visibleByBuildType") && !this.get("isSsp"));
					},
					isNotificationsSettingsVisible: function() {
						return (this.get("isNotificationsSupported") && !this.get("isSsp"));
					}
				}
			});
		};

		function generateMainView() {
			var buttonsConfig = Ext.create("BPMSoft.Container", {
				id: "buttonsMenu",
				classes: {wrapClassName: ["buttons-menu-container"]},
				selectors: {wrapEl: "#buttonsMenu"},
				items: [
					{
						className: "BPMSoft.Button",
						caption: resources.localizableStrings.saveButtonCaption,
						click: {
							bindTo: "onClick"
						},
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						classes: {
							textClass: ["profile-save-button"]
						}
					},
					{
						className: "BPMSoft.Button",
						caption: resources.localizableStrings.cancelButtonCaption,
						click: {
							bindTo: "onCancel"
						}
					}
				]
			});
			var leftPanelConfig = Ext.create("BPMSoft.Container", {
				id: "left-container",
				classes: {
					wrapClassName: [
						"left-container"
					]
				},
				selectors: {
					wrapEl: "#left-container"
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "leftTopGroupContainer",
						selectors: {
							wrapEl: "#leftTopGroupContainer"
						},
						classes: {
							wrapClassName: [
								"profile-module-left-container-bottom-border"
							]
						},
						items: [
							{
								className: "BPMSoft.Button",
								tag: "password",
								caption: resources.localizableStrings.changePasswordCaption,
								classes: {
									textClass: "profile-button"
								},
								click: {
									bindTo: "passwordClick"
								}
							},
							{
								className: "BPMSoft.Label",
								caption: resources.localizableStrings.languageCaption,
								classes: {
									labelClass: "controlCaption"
								},
								visible: false
							},
							{
								className: "BPMSoft.ComboBoxEdit",
								value: {
									bindTo: "culture"
								},
								list: {
									bindTo: "languageList"
								},
								prepareList: {
									bindTo: "onPrepareLanguageList"
								},
								visible: false,
								classes: {
									wrapClass: ["language-combo-box-edit-wrap"]
								}
							},
							{
								className: "BPMSoft.Label",
								caption: SysAdminUnit.columns.TimeZoneId.caption,
								classes: {
									labelClass: "controlCaption"
								},
								visible: {
									bindTo: "isTimezoneSelectionVisible"
								}
							},
							{
								className: "BPMSoft.ComboBoxEdit",
								value: {
									bindTo: "timeZone"
								},
								list: {
									bindTo: "timeZoneList"
								},
								prepareList: {
									bindTo: "onPrepareTimeZoneList"
								},
								visible: {
									bindTo: "isTimezoneSelectionVisible"
								},
								markerValue: "time-zone-value"
							},
							{
								className: "BPMSoft.Button",
								caption: resources.localizableStrings.myCommandsCaption,
								tag: "myCommands",
								classes: {
									textClass: "profile-button"
								},
								// style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
								click: {
									bindTo: "openCommandsGrid"
								},
								visible: {
									bindTo: "isCommandLineSettingsVisible"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "leftMiddleGroupContainer",
						selectors: {
							wrapEl: "#leftMiddleGroupContainer"
						},
						classes: {
							wrapClassName: [
								"profile-module-left-container-bottom-border"
							]
						},
						visible: {
							bindTo: "isSyncSettingsVisible"
						},
						items: [
							{
								className: "BPMSoft.Button",
								caption: resources.localizableStrings.mailboxesCaption,
								classes: {
									textClass: "profile-button"
								},
								click: {
									bindTo: "mailClick"
								}
							},
							{
								className: "BPMSoft.Button",
								caption: resources.localizableStrings.socialNetworkAccountsCaption,
								classes: {
									textClass: "profile-button"
								},
								click: {
									bindTo: "socialClick"
								},
								visible: false,
								markerValue: "SocialAccountsButton"
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "notificationGroupContainer",
						selectors: {
							wrapEl: "#notificationGroupContainer"
						},
						classes: {
							wrapClassName: [
								"profile-module-left-container-bottom-border"
							]
						},
						visible: {
							bindTo: "isNotificationsSettingsVisible"
						},
						items: [
							{
								className: "BPMSoft.Button",
								caption: {
									bindTo: "notificationButtonCaption"
								},
								classes: {
									textClass: "profile-button"
								},
								enabled: {
									bindTo: "notificationButtonEnabled"
								},
								click: {
									bindTo: "requestNotificationPermission"
								}
							}
						]
					},
					{
						className: "BPMSoft.Button",
						caption: resources.localizableStrings.defaultSettingsCaption,
						tag: "default",
						classes: {
							textClass: "profile-button"
						},
						click: {
							bindTo: "flashToDefault"
						},
						visible: {
							bindTo: "isDefaultSettingsButtonVisible"
						}
					}
				]
			});
			var resultConfig = Ext.create("BPMSoft.Container", {
				id: "profileModuleTopContainer",
				selectors: {
					wrapEl: "#profileModuleTopContainer"
				},
				classes: {wrapClassName: ["profile-module"]},
				items: [
					buttonsConfig,
					leftPanelConfig
				]

			});
			return resultConfig;
		}

		var render = function(renderTo) {
			MaskHelper.HideBodyMask();
			var headerCaption = Ext.String.format(resources.localizableStrings.headerCaption,
					BPMSoft.SysValue.CURRENT_USER_CONTACT.displayValue);
			sandbox.publish("ChangeHeaderCaption", {
				caption: headerCaption,
				dataViews: new BPMSoft.Collection()
			});
			sandbox.subscribe("NeedHeaderCaption", function() {
				sandbox.publish("InitDataViews", {caption: headerCaption});
			}, this);
			container = renderTo;
			getCulture();
			loadHeader(renderTo);
		};

		return {
			init: function() {
				var state = sandbox.publish("GetHistoryState");
				var currentHash = state.hash;
				var currentState = state.state || {};
				if (currentState.moduleId === sandbox.id) {
					return;
				}
				var newState = BPMSoft.deepClone(currentState);
				newState.moduleId = sandbox.id;
				sandbox.publish("ReplaceHistoryState", {
					stateObj: newState,
					pageTitle: null,
					hash: currentHash.historyState,
					silent: true
				});
				loadContextHelp("1012");
			},
			render: render
		};
	}
);
