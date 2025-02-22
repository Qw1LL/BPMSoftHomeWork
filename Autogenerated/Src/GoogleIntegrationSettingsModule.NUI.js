﻿define("GoogleIntegrationSettingsModule", ["ext-base", "BPMSoft", "sandbox", "ConfigurationConstants",
		"GoogleIntegrationUtilities", "GoogleIntegrationSettingsModuleResources", "TagConstantsV2",
		"GoogleIntegrationUtilitiesV2"],
	function(Ext, BPMSoft, sandbox, ConfigurationConstants, googleUtilities, resources, TagConstants) {

		Ext.define("BPMSoft.configuration.GoogleIntegrationSettingsModuleViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.GoogleIntegrationSettingsModuleViewModel",

			mixins: {
				GoogleIntegrationUtils: "BPMSoft.GoogleIntegrationUtilities"
			},

			/**
			 * Initializes view model.
			 * @protected
			 */
			init: function() {
				this.mixins.GoogleIntegrationUtils.init.call(this);
			},

			/**
			 * Process save button click. Save sync settings.
			 * @protected
			 */
			onOkBtnClick: function() {
				if (this.validate()) {
					if (schema === "Contact") {
						this.validateGoogleContactsIntegrationRights();
					}
					var minutesValue = viewModel.get("googleSyncInterval");
					BPMSoft.SysSettings.postPersonalSysSettingsValue(GoogleSynchInterval, minutesValue,
						function() {
							if (schema === "Contact") {
								var groupValue = viewModel.get("tagValue").value;
								BPMSoft.SysSettings.postPersonalSysSettingsValue("GoogleContactGroup",
									groupValue, function() {
										createScheduledJob(true);
									});
							} else {
								createScheduledJob(true);
							}
						});
					var lastSyncDateValue = new Date(viewModel.get("googleSyncDate"));
					var lastSyncTimeValue = new Date(viewModel.get("googleSyncTime"));
					var lastSyncDateTimeValue = new Date(lastSyncDateValue.getFullYear(),
						lastSyncDateValue.getMonth(), lastSyncDateValue.getDate(), lastSyncTimeValue.getHours(),
						lastSyncTimeValue.getMinutes());
					BPMSoft.SysSettings.postPersonalSysSettingsValue(GoogleLastSynchronization,
						lastSyncDateTimeValue, function(result) {
							if (result.success) {
								return;
							}
							throw new BPMSoft.InvalidOperationException(result.errorInfo.message);
						});
					BPMSoft.SysSettings.postPersonalSysSettingsValue(GoogleLastSynchronizationEnd,
						lastSyncDateTimeValue, function(result) {
							if (result.success) {
								return;
							}
							throw new BPMSoft.InvalidOperationException(result.errorInfo.message);
						});
				}
			},

			/**
			 * Process cancel button click. Discard sync settings.
			 * @protected
			 */
			onCancelBtnClick: function() {
				sandbox.publish("BackHistoryState");
			},

			/**
			 * Loads tag list.
			 * @param {Object} filter Collection filter.
			 * @param {BPMSoft.Collection} list Tags list.
			 */
			onPrepareTagList: function(filter, list) {
				list.clear();
				list.loadAll(staticGroups);
			},

			/**
			 * Process right icon click.
			 * @protected
			 */
			rightIconClick: function() {
				authLogin(this);
			},

			/**
			 * Opens google auth page.
			 * @protected
			 */
			openLoginPage: this.rightIconClick

		});

		var staticGroups = {};
		var view, viewModel;
		var schema = "Contact";
		var JobName, SyncProcessName, GoogleSynchInterval, GoogleLastSynchronization, GoogleLastSynchronizationEnd;
		var SyncJobGroupName = "GoogleIntegration";

		function setSchema() {
			var history = sandbox.publish("GetHistoryState");
			if (history.state) {
				schema = history.state.schema === "Activity" ? "Activity" : "Contact";
				JobName = history.state.schema === "Activity" ? "SynchGoogleCalendar" : "SynchGoogleContacts";
				SyncProcessName = history.state.schema === "Activity" ?
					"GCalendarSynchronizationModuleProcess" : "GContactSynchronizationModuleProcess";
				GoogleSynchInterval = history.state.schema === "Activity" ?
					"GoogleCalendarSynchInterval" : "GoogleContactSynchInterval";
				GoogleLastSynchronization = (schema === "Activity") ?
					"GoogleCalendarLastSynchronization" : "GoogleContactLastSynchronization";
				GoogleLastSynchronizationEnd = (schema === "Activity") ?
					"GoogleCalendarLastSynchronizationEnd" : "GoogleContactLastSynchronizationEnd";
			}
		}

		function setTagSelectedItemById(id) {
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "ContactTag"
			});
			select.addColumn("Id");
			select.addColumn("Name");
			select.getEntity(id, function(response) {
				var entity = response.entity;
				if (entity) {
					var value = {value: entity.get("Id"), displayValue: entity.get("Name")};
					viewModel.set("tagValue", value);
				}
			}, this);
		}

		function getPrivateTags() {
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "ContactTag"
			});
			select.addColumn("Id");
			select.addColumn("Name");
			select.filters.add("privateTagFilter", select.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "Type", TagConstants.TagType.Private));
			select.filters.add("CurrentUserFilter", select.createColumnFilterWithParameter(
				BPMSoft.ComparisonType.EQUAL, "CreatedBy", this.BPMSoft.SysValue.CURRENT_USER_CONTACT.value));
			select.getEntityCollection(fillPrivateTags, this);
		}

		function fillPrivateTags(response) {
			var entities = response.collection;
			entities.each(function(item) {
				staticGroups[item.get("Id")] = {value: item.get("Id"), displayValue: item.get("Name")};
			}, this);
		}

		function authLogin() {
			googleUtilities.showGoogleAuthenticationWindow(setLoginControl);
		}

		function setAutoSyncState(jobName, syncJobGroupName) {
			var provider = BPMSoft.AjaxProvider;
			var data = {
				JobName: jobName,
				SyncJobGroupName: syncJobGroupName
			};
			var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			var requestUrl = workspaceBaseUrl + "/rest/SchedulerJobService/CheckIfJobExist";
			provider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				callback: function(request, success, response) {
					var ifExistResult = false;
					if (success) {
						ifExistResult = BPMSoft.decode(response.responseText);
						viewModel.set("isAutoSync", ifExistResult.CheckIfJobExistResult);
					}
				},
				scope: this
			});
		}

		/**
		 * ############# ######## ###### login.
		 * @param {String} login (optional) ##### ####### ###### Google.
		 * @public
		 */
		function setLoginControl(login) {
			if (!Ext.isEmpty(login)) {
				viewModel.set("login", login);
				viewModel.set("enabledLogin", false);
				return;
			}
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "SocialAccount"
			});
			select.addColumn("Login");
			select.filters.add("UserIdFilter", select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"User", BPMSoft.SysValue.CURRENT_USER.value));
			select.filters.add("TypeIdFilter", select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
				"Type", ConfigurationConstants.CommunicationType.Google));
			select.getEntityCollection(function(response) {
				if (response.success) {
					var entities = response.collection;
					if (entities.getCount() > 0) {
						login = entities.getByIndex(0).get("Login");
						viewModel.set("login", login);
						viewModel.set("enabledLogin", false);
					}
				}
			}, this);
		}

		function createScheduledJob(returnBack) {
			var provider = BPMSoft.AjaxProvider;
			var data = {
				JobName: JobName + BPMSoft.SysValue.CURRENT_USER.value,
				SyncJobGroupName: SyncJobGroupName,
				SyncProcessName: SyncProcessName,
				periodInMinutes: viewModel.get("googleSyncInterval"),
				recreate: viewModel.get("isAutoSync")
			};
			var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
			var requestUrl = workspaceBaseUrl + "/rest/SchedulerJobService/CreateSyncJob";
			provider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				callback: function() {
					if (returnBack) {
						sandbox.publish("BackHistoryState");
					}
				},
				scope: this
			});
		}

		function initModel() {
			var isActivity = (schema === "Activity");
			viewModel.set("isGroupVisible", !isActivity);
			viewModel.set("autoSyncCaption", isActivity ?
				resources.localizableStrings.ActivityAutoSyncCaption :
				resources.localizableStrings.ContactAutoSyncCaption);
			viewModel.columns.tagValue.isRequired = !isActivity;
			setLoginControl();
			setAutoSyncState(JobName + BPMSoft.SysValue.CURRENT_USER.value, SyncJobGroupName);
			BPMSoft.SysSettings.querySysSettingsItem(GoogleLastSynchronization, function(value) {
				viewModel.set("googleSyncDate", value);
				viewModel.set("googleSyncTime", value);
			}, this);
			BPMSoft.SysSettings.querySysSettingsItem(GoogleSynchInterval, function(value) {
				if (value) {
					viewModel.set("googleSyncInterval", value);
				}
			}, this);
			if (schema === "Contact") {
				BPMSoft.SysSettings.querySysSettingsItem("GoogleContactGroup", function(value) {
					if (value) {
						var recordId = (Ext.isObject(value)) ? value.value : value;
						setTagSelectedItemById(recordId);
					}
				}, this);
			}
			viewModel.init();
		}

		function getView() {
			var container = Ext.create("BPMSoft.Container", {
				id: "generalContainer",
				selectors: {
					wrapEl: "#generalContainer"
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "buttonsContainer",
						selectors: {
							wrapEl: "#buttonsContainer"
						},
						classes: {
							wrapClassName: ["buttons-container"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "btnOkContainer",
								selectors: {
									wrapEl: "#btnOkContainer"
								},
								classes: {
									wrapClassName: ["btnOk-container"]
								},
								items: [
									{
										className: "BPMSoft.Button",
										id: "btnOk",
										caption: resources.localizableStrings.BtnOKCaption,
										width: "100px",
										style: BPMSoft.controls.ButtonEnums.style.ORANGE,
										click: {
											bindTo: "onOkBtnClick"
										}
									}
								]
							},
							{
								className: "BPMSoft.Container",
								id: "btnCancelContainer",
								selectors: {
									wrapEl: "#btnCancelContainer"
								},
								classes: {
									wrapClassName: ["btnCancel-container"]
								},
								items: [
									{
										className: "BPMSoft.Button",
										id: "btnCancel",
										caption: resources.localizableStrings.BtnCancelCaption,
										width: "100px",
										style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
										click: {
											bindTo: "onCancelBtnClick"
										}
									}
								]
							}

						]
					},
					{
						className: "BPMSoft.Container",
						id: "userLoginContainer",
						selectors: {
							wrapEl: "#userLoginContainer"
						},
						classes: {
							wrapClassName: ["userlogin-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "userLoginLabel",
								caption: resources.localizableStrings.UserLoginCaption,
								classes: {
									labelClass: ["required-caption"]
								}
							},
							{
								className: "BPMSoft.TextEdit",
								id: "userLogin",
								value: {
									bindTo: "login"
								},
								enabled: false,
								classes: {
									wrapperClass: "userLogin-right-icon"
								},
								rightIconConfig: {
									source: BPMSoft.ImageSources.URL,
									url: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.LookUpIcon)
								},
								enableRightIcon: true,
								onRightIconClick: authLogin
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "groupContainer",
						selectors: {
							wrapEl: "#groupContainer"
						},
						classes: {
							wrapClassName: ["group-container"]
						},
						visible: {bindTo: "isGroupVisible"},
						items: [
							{
								className: "BPMSoft.Label",
								id: "groupLabel",
								caption: resources.localizableStrings.TagCaption,
								classes: {
									labelClass: ["required-caption"]
								}
							},
							{
								className: "BPMSoft.ComboBoxEdit",
								id: "group",
								value: {
									bindTo: "tagValue"
								},
								list: {
									bindTo: "tagList"
								},
								prepareList: {
									bindTo: "onPrepareTagList"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "autosyncContainer",
						selectors: {
							wrapEl: "#autosyncContainer"
						},
						classes: {
							wrapClassName: ["autosync-container"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "autosyncCheckBoxLabelContainer",
								selectors: {
									wrapEl: "#autosyncCheckBoxLabelContainer"
								},
								classes: {
									wrapClassName: ["autosync-checkboxedit-label-container"]
								},
								items: [
									{
										className: "BPMSoft.Container",
										id: "autosyncCheckBoxContainer",
										selectors: {
											wrapEl: "#autosyncCheckBoxContainer"
										},
										classes: {
											wrapClassName: ["autosync-checkboxedit-container"]
										},
										items: [
											{
												className: "BPMSoft.CheckBoxEdit",
												id: "autoSync",
												classes: {
													wrapClass: ["autosync-checkboxedit"]
												},
												checked: {
													bindTo: "isAutoSync"
												}
											}
										]
									},
									{
										className: "BPMSoft.Container",
										id: "autosyncLabelContainer",
										selectors: {
											wrapEl: "#autosyncLabelContainer"
										},
										classes: {
											wrapClassName: ["autosync-label-container"]
										},
										items: [
											{
												className: "BPMSoft.Label",
												id: "autoSyncLabel",
												caption: {
													bindTo: "autoSyncCaption"
												},
												labelClass: "t-label autosync-label"
											}
										]
									}
								]
							},
							{
								className: "BPMSoft.Container",
								id: "minutesTextEditLabelContainer",
								selectors: {
									wrapEl: "#minutesTextEditLabelContainer"
								},
								classes: {
									wrapClassName: ["minutes-textedit-label-container"]
								},
								items: [
									{
										className: "BPMSoft.Container",
										id: "minutesTextEditContainer",
										selectors: {
											wrapEl: "#minutesTextEditContainer"
										},
										classes: {
											wrapClassName: ["minutes-textedit-container"]
										},
										items: [
											{
												className: "BPMSoft.TextEdit",
												id: "minutes",
												classes: {
													wrapClass: ["minutes-textedit"]
												},
												value: {
													bindTo: "googleSyncInterval"
												}
											}
										]
									},
									{
										className: "BPMSoft.Container",
										id: "minutesLabelContainer",
										selectors: {
											wrapEl: "#minutesLabelContainer"
										},
										classes: {
											wrapClassName: ["minutes-label-container"]
										},
										items: [
											{
												className: "BPMSoft.Label",
												id: "minutesLabel",
												caption: resources.localizableStrings.MinutesCaption,
												labelClass: "t-label minutes-label"
											}
										]
									}
								]
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "lastSyncDateContainer",
						selectors: {
							wrapEl: "#lastSyncDateContainer"
						},
						classes: {
							wrapClassName: ["lastSyncDate-container", "flex-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "GoogleSyncDateLabel",
								caption: resources.localizableStrings.SyncFromDateCaption,
								classes: {
									labelClass: ["required-caption"]
								}
							},
							{
								className: BPMSoft.DateEdit,
								id: "GoogleSyncDateEdit",
								visible: true,
								value: {
									bindTo: "googleSyncDate"
								}
							},
							{
								className: BPMSoft.TimeEdit,
								classes: {
									wrapClass: ["googleSync-timeEdit"]
								},
								id: "GoogleSyncTimeEdit",
								visible: true,
								value: {
									bindTo: "googleSyncTime"
								}
							}
						]
					}
				]
			});
			return container;
		}

		function getViewModel() {
			return Ext.create("BPMSoft.GoogleIntegrationSettingsModuleViewModel", {
				columns: {
					login: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "login",
						isRequired: true
					},
					tagValue: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "tagValue",
						isLookup: true,
						isRequired: true
					},
					tagList: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "tagList",
						isCollection: true
					},
					googleSyncDate: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.DATE,
						name: "googleSyncDate",
						isRequired: true
					},
					googleSyncTime: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						dataValueType: BPMSoft.DataValueType.DATE,
						name: "googleSyncTime",
						isRequired: true
					}
				},
				values: {
					tagList: new BPMSoft.Collection(),
					login: null,
					enabledLogin: true,
					autoSyncCaption: "",
					googleContactGroup: "",
					googleLastSync: "",
					googleSyncDate: null,
					googleSyncTime: null,
					googleSyncInterval: "",
					isAutoSync: false,
					isGroupVisible: true
				}
			});

		}

		function render(renderTo) {
			var headerCaption = resources.localizableStrings.WindowCaption;
			sandbox.publish("ChangeHeaderCaption", {
				caption: headerCaption,
				dataViews: new BPMSoft.Collection()
			});
			sandbox.subscribe("NeedHeaderCaption", function() {
				sandbox.publish("InitDataViews", {caption: headerCaption});
			}, this);
			getPrivateTags();
			setSchema();
			view = getView();
			viewModel = getViewModel();
			initModel();
			view.bind(viewModel);
			view.render(renderTo);
		}

		return {
			render: render
		};
	});
