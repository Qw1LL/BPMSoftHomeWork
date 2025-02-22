﻿define("MailboxSynchronizationSettingsPageModule", ["BPMSoft", "ext-base", "sandbox", "ConfigurationConstants",
	"LookupUtilities", "MailboxSynchronizationSettingsPageModuleResources", "RightUtilities", "MaskHelper"],
	function(BPMSoft, Ext, sandbox, ConfigurationConstants, LookupUtilities, resources, RightUtilities, MaskHelper) {
		var viewModel;
		var container;

		function requestService(data, methodName, callback) {
			var provider = BPMSoft.AjaxProvider;
			var requestUrl = BPMSoft.workspaceBaseUrl + "/rest/MailboxSynchronizationSettingsService/" + methodName;
			provider.request({
				url: requestUrl,
				headers: {
					"Accept": "application/json",
					"Content-Type": "application/json"
				},
				method: "POST",
				jsonData: data,
				scope: this,
				callback: callback
			});
		}

		function fillMailServerCollection(scope) {
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "MailServer"
			});
			select.addColumn("Id");
			select.addColumn("Name");
			select.getEntityCollection(function(response) {
				if (response.success) {
					var collection = response.collection.collection;
					var mailServerCollection = scope.get("mailServerCollection");
					BPMSoft.each(collection.items, function(element) {
						mailServerCollection[element.get("Id")] = {
							value: element.get("Id"),
							displayValue: element.get("Name")
						};
					}, this);
				}
			}, scope);
		}

		function getEmailDownloadItems() {
			var items = [];
			items.push({
				className: "BPMSoft.Container",
				id: "useEmailDownloadContainer",
				selectors: {
					wrapEl: "#useEmailDownloadContainer"
				},
				classes: {
					wrapClassName: ["control-margin-bottom-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "useEmailDownloadCheckBoxContainer",
						selectors: {
							wrapEl: "#useEmailDownloadCheckBoxContainer"
						},
						classes: {
							wrapClassName: ["smallcontrol-container", "inline-container", "checkbox-vertical-align"]
						},
						items: [
							{
								className: "BPMSoft.CheckBoxEdit",
								markerValue: resources.localizableStrings.UseEmailDownloadCaption,
								id: "useEmailDownload",
								checked: {
									bindTo: "enableMailSynhronization",
									bindConfig: {
										converter: function(value) {
											viewModel.setEmailDownloadControlGroupEnabled(value);
											return value;
										}
									}
								},
								enabled: {
									bindTo: "serverAllowEmailDownloading"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "useEmailDownloadLabelContainer",
						selectors: {
							wrapEl: "#useEmailDownloadLabelContainer"
						},
						classes: {
							wrapClassName: ["inline-container", "label-maxwidth400-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "useEmailDownloadLabel",
								caption: resources.localizableStrings.UseEmailDownloadCaption
							}
						]
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "emailAutoDownloadContainer",
				selectors: {
					wrapEl: "#emailAutoDownloadContainer"
				},
				classes: {
					wrapClassName: ["padding-left40-container", "control-margin-bottom10-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "emailAutoDownloadCheckBoxContainer",
						selectors: {
							wrapEl: "#emailAutoDownloadCheckBoxContainer"
						},
						classes: {
							wrapClassName: ["smallcontrol-container", "inline-container", "checkbox-vertical-align"]
						},
						items: [
							{
								className: "BPMSoft.CheckBoxEdit",
								markerValue: resources.localizableStrings.EmailAutoDownloadCaption,
								id: "emailAutoDownload",
								enabled: {
									bindTo: "emailDownloadControlGroupEnabled"
								},
								checked: {
									bindTo: "automaticallyAddNewEmails"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "emailAutoDownloadLabelContainer",
						selectors: {
							wrapEl: "#emailAutoDownloadLabelContainer"
						},
						classes: {
							wrapClassName: ["inline-container", "label-maxwidth400-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "emailAutoDownloadLabel",
								caption: resources.localizableStrings.EmailAutoDownloadCaption
							}
						]
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "minutesContainer",
				selectors: {
					wrapEl: "#minutesContainer"
				},
				classes: {
					wrapClassName: ["padding-left100-container", "control-margin-bottom30-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "minutesTextEditContainer",
						selectors: {
							wrapEl: "#minutesTextEditContainer"
						},
						classes: {
							wrapClassName: ["textedit-minutes-container", "inline-container"]
						},
						items: [
							{
								className: "BPMSoft.IntegerEdit",
								markerValue: resources.localizableStrings.MinutesCaption,
								id: "minutesValue",
								value: {
									bindTo: "emailsCyclicallyAddingInterval"
								},
								enabled: {
									bindTo: "getAutomaticallyAddNewEmailsEnabled"
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
							wrapClassName: ["inline-container", "label-maxwidth150-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "minutesLabel",
								caption: resources.localizableStrings.MinutesCaption
							}
						]
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "emailDownloadAllContainer",
				selectors: {
					wrapEl: "#emailDownloadAllContainer"
				},
				classes: {
					wrapClassName: ["padding-left40-container", "control-margin-bottom10-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "emailDownloadAllRadioButtonContainer",
						selectors: {
							wrapEl: "#emailDownloadAllRadioButtonContainer"
						},
						classes: {
							wrapClassName: ["smallcontrol-container", "inline-container", "radio-vertical-align"]
						},
						items: [
							{
								className: "BPMSoft.RadioButton",
								markerValue: resources.localizableStrings.EmailDownloadAllCaption,
								tag: "all",
								enabled: {
									bindTo: "emailDownloadControlGroupEnabled"
								},
								checked: {
									bindTo: "downloadFrom"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "emailDownloadAllRadioLabelContainer",
						selectors: {
							wrapEl: "#emailDownloadAllRadioLabelContainer"
						},
						classes: {
							wrapClassName: ["inline-container", "label-maxwidth400-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "emailDownloadAllLabel",
								caption: resources.localizableStrings.EmailDownloadAllCaption
							}
						]
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "startWithDateContainer",
				selectors: {
					wrapEl: "#startWithDateContainer"
				},
				classes: {
					wrapClassName: ["padding-left100-container", "control-margin-bottom30-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "startWithDateLabelContainer",
						selectors: {
							wrapEl: "#startWithDateLabelContainer"
						},
						classes: {
							wrapClassName: ["inline-container", "label-before-control-container",
								"label-maxwidth200-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "startWithDateLabel",
								caption: resources.localizableStrings.StartWithDateCaption
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "startWithDateDateEditContainer",
						selectors: {
							wrapEl: "#startWithDateDateEditContainer"
						},
						classes: {
							wrapClassName: ["inline-container", "dateedit-startWithDate-container"]
						},
						items: [
							{
								className: "BPMSoft.DateEdit",
								markerValue: resources.localizableStrings.StartWithDateCaption,
								id: "startWithDateValue",
								value: {
									bindTo: "loadEmailsFromDate"
								},
								enabled: {
									bindTo: "getStartWithDateEnabled"
								}
							}
						]
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "emailDownloadFromGroupContainer",
				selectors: {
					wrapEl: "#emailDownloadFromGroupContainer"
				},
				classes: {
					wrapClassName: ["padding-left40-container", "control-margin-bottom10-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "emailDownloadFromGroupRadioButtonContainer",
						selectors: {
							wrapEl: "#emailDownloadFromGroupRadioButtonContainer"
						},
						classes: {
							wrapClassName: ["smallcontrol-container", "inline-container", "radio-vertical-align"]
						},
						items: [
							{
								className: "BPMSoft.RadioButton",
								markerValue: resources.localizableStrings.EmailDownloadFromGroupCaption,
								tag: "fromGroup",
								enabled: {
									bindTo: "emailDownloadControlGroupEnabled"
								},
								checked: {
									bindTo: "downloadFrom"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "emailDownloadFromGroupRadioLabelContainer",
						selectors: {
							wrapEl: "#emailDownloadFromGroupRadioLabelContainer"
						},
						classes: {
							wrapClassName: ["inline-container", "label-maxwidth400-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "emailDownloadFromGroupLabel",
								caption: resources.localizableStrings.EmailDownloadFromGroupCaption
							}
						]
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "btnChooseGroupContainer",
				selectors: {
					wrapEl: "#btnChooseGroupContainer"
				},
				classes: {
					wrapClassName: ["padding-left80-container"]
				},
				items: [
					{
						className: "BPMSoft.Button",
						id: "btnChooseGroup",
						caption: resources.localizableStrings.ChooseGroupCaption,
						width: "200px",
						style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
						click: {
							bindTo: "onChooseGroupBtnClick"
						},
						enabled: {
							bindTo: "getChooseGroupEnabled"
						}
					}
				]
			});
			return items;
		}

		function getEmailDispatchItems() {
			var items = [];
			items.push({
				className: "BPMSoft.Container",
				id: "useForEmailDispatchContainer",
				selectors: {
					wrapEl: "#useForEmailDispatchContainer"
				},
				classes: {
					wrapClassName: ["control-margin-bottom10-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "useForEmailDispatchCheckBoxContainer",
						selectors: {
							wrapEl: "#useForEmailDispatchCheckBoxContainer"
						},
						classes: {
							wrapClassName: ["smallcontrol-container", "inline-container", "checkbox-vertical-align"]
						},
						items: [
							{
								className: "BPMSoft.CheckBoxEdit",
								id: "useForEmailDispatch",
								markerValue: resources.localizableStrings.UseForEmailDispatchCaption,
								checked: {
									bindTo: "sendEmailsViaThisAccount",
									bindConfig: {
										converter: function(value) {
											if (value) {
												viewModel.getIsProviderSMTPAddressSet();
											}
											return value;
										}
									}
								},
								enabled: {
									bindTo: "serverAllowEmailSending"
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "useForEmailDispatchLabelContainer",
						selectors: {
							wrapEl: "#useForEmailDispatchLabelContainer"
						},
						classes: {
							wrapClassName: ["inline-container", "label-maxwidth400-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "useForEmailDispatchLabel",
								caption: resources.localizableStrings.UseForEmailDispatchCaption
							}
						]
					}
				]
			});
			items.push({
					className: "BPMSoft.Container",
					id: "useAsDefaultContainer",
					selectors: {
						wrapEl: "#useAsDefaultContainer"
					},
					classes: {
						wrapClassName: ["padding-left40-container"]
					},
					items: [
						{
							className: "BPMSoft.Container",
							id: "useAsDefaultCheckBoxContainer",
							selectors: {
								wrapEl: "#useAsDefaultCheckBoxContainer"
							},
							classes: {
								wrapClassName: ["smallcontrol-container", "inline-container", "checkbox-vertical-align"]
							},
							items: [
								{
									className: "BPMSoft.CheckBoxEdit",
									id: "useAsDefault",
									markerValue: resources.localizableStrings.UseAsDefaultCaption,
									checked: {
										bindTo: "isDefault"
									},
									enabled: {
										bindTo: "setIsDefault"
									}
								}
							]
						},
						{
							className: "BPMSoft.Container",
							id: "useAsDefaultLabelContainer",
							selectors: {
								wrapEl: "#useAsDefaultLabelContainer"
							},
							classes: {
								wrapClassName: ["inline-container", "label-maxwidth400-container"]
							},
							items: [
								{
									className: "BPMSoft.Label",
									id: "useAsDefaultLabel",
									caption: resources.localizableStrings.UseAsDefaultCaption
								}
							]
						}
					]
				},
				{
					className: "BPMSoft.Container",
					id: "isAnonymousAuthenticationContainer",
					selectors: {
						wrapEl: "#isAnonymousAuthenticationContainer"
					},
					classes: {
						wrapClassName: ["padding-left40-container"]
					},
					items: [
						{
							className: "BPMSoft.Container",
							id: "isAnonymousAuthenticationContainer",
							selectors: {
								wrapEl: "#isAnonymousAuthenticationContainer"
							},
							classes: {
								wrapClassName: ["smallcontrol-container", "inline-container", "checkbox-vertical-align"]
							},
							items: [
								{
									className: "BPMSoft.CheckBoxEdit",
									id: "isAnonymousAuthentication",
									markerValue: resources.localizableStrings.IsAnonymousAuthenticationCaption,
									checked: {
										bindTo: "isAnonymousAuthentication"
									}
								}
							]
						},
						{
							className: "BPMSoft.Container",
							id: "isAnonymousAuthenticationLabelContainer",
							selectors: {
								wrapEl: "#isAnonymousAuthenticationLabelContainer"
							},
							classes: {
								wrapClassName: ["inline-container", "label-maxwidth400-container"]
							},
							items: [
								{
									className: "BPMSoft.Label",
									id: "isAnonymousAuthenticationLabel",
									caption: resources.localizableStrings.IsAnonymousAuthenticationCaption
								}
							]
						}
					]
				});
			return items;
		}

		function getButtonsItems() {
			var items = [];
			items.push({
				className: "BPMSoft.Container",
				id: "btnOkContainer",
				selectors: {
					wrapEl: "#btnOkContainer"
				},
				classes: {
					wrapClassName: ["inline-container", "btnOk-container"]
				},
				items: [
					{
						className: "BPMSoft.Button",
						id: "btnOk",
						caption: resources.localizableStrings.OkCaption,
						//width: "100px",
						style: BPMSoft.controls.ButtonEnums.style.ORANGE,
						click: {
							bindTo: "onOkBtnClick"
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "btnCancelContainer",
				selectors: {
					wrapEl: "#btnCancelContainer"
				},
				classes: {
					wrapClassName: ["inline-container"]
				},
				items: [
					{
						className: "BPMSoft.Button",
						id: "btnCancel",
						caption: resources.localizableStrings.CancelCaption,
						style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
						click: {
							bindTo: "onCancelBtnClick"
						}
					}
				]
			});
			return items;
		}

		function getLeftItems() {
			var items = [];
			items.push({
				className: "BPMSoft.Container",
				id: "mailServerLabelContainer",
				selectors: {
					wrapEl: "#mailServerLabelContainer"
				},
				classes: {
					wrapClassName: ["label-above-control-container"]
				},
				items: [
					{
						className: "BPMSoft.Label",
						id: "mailserverLabel",
						caption: resources.localizableStrings.MailServerCaption,
						classes: {
							labelClass: ["required-caption"]
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "mailServerContainer",
				selectors: {
					wrapEl: "#mailServerContainer"
				},
				classes: {
					wrapClassName: ["control-margin-bottom-container"]
				},
				items: [
					{
						className: "BPMSoft.ComboBoxEdit",
						id: "mailserver",
						markerValue: resources.localizableStrings.MailServerCaption,
						list: {
							bindTo: "mailServerList"
						},
						value: {
							bindTo: "mailServerValue"
						},
						change: {
							bindTo: "onMailServerChange"
						},
						prepareList: {
							bindTo: "onPrepareMailServerList"
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "userNameLabelContainer",
				selectors: {
					wrapEl: "#userNameLabelContainer"
				},
				classes: {
					wrapClassName: ["label-above-control-container"]
				},
				items: [
					{
						className: "BPMSoft.Label",
						id: "usernameLabel",
						caption: resources.localizableStrings.UserNameCaption,
						classes: {
							labelClass: ["required-caption"]
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "userNameContainer",
				selectors: {
					wrapEl: "#userNameContainer"
				},
				classes: {
					wrapClassName: ["control-margin-bottom-container"]
				},
				items: [
					{
						className: "BPMSoft.TextEdit",
						id: "username",
						markerValue: resources.localizableStrings.UserNameCaption,
						value: {
							bindTo: "userName",
							bindConfig: {
								converter: function(value) {
									viewModel.setMailboxNameValue(value);
									return value;
								}
							}
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "userPasswordLabelContainer",
				selectors: {
					wrapEl: "#userPasswordLabelContainer"
				},
				classes: {
					wrapClassName: ["label-above-control-container"]
				},
				items: [
					{
						className: "BPMSoft.Label",
						id: "userpasswordLabel",
						caption: resources.localizableStrings.UserPasswordCaption,
						classes: {
							labelClass: ["required-caption"]
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "userPasswordContainer",
				selectors: {
					wrapEl: "#userPasswordContainer"
				},
				classes: {
					wrapClassName: ["control-margin-bottom-container"]
				},
				items: [
					{
						className: "BPMSoft.TextEdit",
						id: "userPasswordValue",
						markerValue: resources.localizableStrings.UserPasswordCaption,
						protect: true,
						value: {
							bindTo: "userPassword"
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "mailboxNameLabelContainer",
				selectors: {
					wrapEl: "#mailboxNameLabelContainer"
				},
				classes: {
					wrapClassName: ["label-above-control-container"]
				},
				items: [
					{
						className: "BPMSoft.Label",
						id: "mailboxNameLabel",
						caption: resources.localizableStrings.MailboxNameCaption,
						classes: {
							labelClass: ["required-caption"]
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "mailboxNameContainer",
				selectors: {
					wrapEl: "#mailboxNameContainer"
				},
				classes: {
					wrapClassName: ["control-margin-bottom-container"]
				},
				items: [
					{
						className: "BPMSoft.TextEdit",
						id: "mailboxNameValue",
						markerValue: resources.localizableStrings.MailboxNameCaption,
						value: {
							bindTo: "mailboxName"
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "senderEmailAddressLabelContainer",
				selectors: {
					wrapEl: "#senderEmailAddressLabelContainer"
				},
				classes: {
					wrapClassName: ["label-above-control-container"]
				},
				items: [
					{
						className: "BPMSoft.Label",
						id: "senderEmailAddressLabel",
						caption: resources.localizableStrings.SenderEmailAddressCaption,
						classes: {
							labelClass: ["required-caption"]
						}
					}
				]
			});
			items.push({
				className: "BPMSoft.Container",
				id: "senderEmailAddressContainer",
				selectors: {
					wrapEl: "#senderEmailAddressContainer"
				},
				classes: {
					wrapClassName: ["control-margin-bottom-container"]
				},
				items: [
					{
						className: "BPMSoft.TextEdit",
						id: "senderemailaddress",
						markerValue: resources.localizableStrings.SenderEmailAddressCaption,
						value: {
							bindTo: "senderEmailAddress"
						}
					}
				]
			});
			return items;
		}

		function getRightItems() {
			var items = [];
			items.push({
				className: "BPMSoft.ControlGroup",
				id: "emailDownloadControlGroupContainer",
				selectors: {
					wrapEl: "#emailDownloadControlGroupContainer"
				},
				classes: {
					wrapClass: "emailDownload-controlgroup",
					wrapContainerClass: "emailDownload-controlgroup-container"
				},
				collapsed: false,
				enabled: {
					bindTo: "emailDownloadControlGroupEnabled"
				},
				caption: resources.localizableStrings.EmailDownloadGroupCaption,
				items: getEmailDownloadItems()
			});
			items.push({
				className: "BPMSoft.ControlGroup",
				id: "emailDispatchControlGroupContainer",
				selectors: {
					wrapEl: "#emailDispatchControlGroupContainer"
				},
				classes: {
					wrapClass: "emailDispatch-controlgroup",
					wrapContainerClass: "emailDispatch-controlgroup-container"
				},
				collapsed: false,
				caption: resources.localizableStrings.EmailDispatchGroupCaption,
				items: getEmailDispatchItems()
			});
			return items;
		}

		function getView() {
			var view = Ext.create("BPMSoft.Container", {
				id: "main",
				markerValue: resources.localizableStrings.TitleCaption,
				selectors: {
					wrapEl: "#main"
				},
				classes: {
					wrapClassName: ["main-container"]
				},
				items: [
					{
						className: "BPMSoft.Container",
						id: "titleContainer",
						selectors: {
							wrapEl: "#titleContainer"
						},
						classes: {
							wrapClassName: ["title-container"]
						},
						items: [
							{
								className: "BPMSoft.Label",
								id: "titleLabel",
								caption: resources.localizableStrings.TitleCaption,
								classes: {
									labelClass: ["label-page-caption"]
								}
							}
						]
					},
					{
						className: "BPMSoft.Container",
						id: "buttonsContainer",
						selectors: {
							wrapEl: "#buttonsContainer"
						},
						classes: {
							wrapClassName: ["buttons-container"]
						},
						items: getButtonsItems()
					},
					{
						className: "BPMSoft.Container",
						id: "bottomContainer",
						selectors: {
							wrapEl: "#bottomContainer"
						},
						classes: {
							wrapClassName: ["bottom-container"]
						},
						items: [
							{
								className: "BPMSoft.Container",
								id: "leftContainer",
								selectors: {
									wrapEl: "#leftContainer"
								},
								classes: {
									wrapClassName: ["left-container"]
								},
								items: getLeftItems()
							},
							{
								className: "BPMSoft.Container",
								id: "rightContainer",
								selectors: {
									wrapEl: "#rightContainer"
								},
								classes: {
									wrapClassName: ["right-container"]
								},
								items: getRightItems()
							}
						]
					}
				]
			});
			return view;
		}

		function getViewModel() {
			var model = Ext.create("BPMSoft.BaseViewModel", {
				columns: {
					mailServerValue: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "mailServerValue",
						isLookup: true,
						isRequired: true
					},
					mailServerList: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "mailServerList",
						isCollection: true
					},
					userName: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "userName",
						isRequired: true
					},
					userPassword: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "userPassword",
						isRequired: true
					},
					senderEmailAddress: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "senderEmailAddress",
						isRequired: true
					},
					mailboxName: {
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						name: "mailboxName",
						isRequired: true
					}
				},
				values: {
					mailboxSyncSettingsId: null,
					mailboxType: "private",
					downloadFrom: "all",
					emailDownloadControlGroupEnabled: true,
					automaticallyAddNewEmails: false,
					emailsCyclicallyAddingInterval: 1,
					enableMailSynhronization: true,
					sysAdminUnitId: BPMSoft.SysValue.CURRENT_USER.value,
					mailServerId: null,
					userName: "",
					userPassword: "",
					senderEmailAddress: "",
					mailboxName: "",
					sendEmailsViaThisAccount: false,
					isDefault: false,
					accessControlsVisible: false,
					loadEmailsFromDate: new Date(),
					mailServerList: new BPMSoft.Collection(),
					mailServerCollection: {},
					serverAllowEmailDownloading: true,
					isAnonymousAuthentication: false,
					serverAllowEmailSending: true,
					newFolders: null
				},
				methods: {
					onOkBtnClick: function() {
						MaskHelper.ShowBodyMask();
						if (this.get("enableMailSynhronization") || this.get("sendEmailsViaThisAccount")) {
							if (this.validate()) {
								if (this.get("enableMailSynhronization") && this.get("automaticallyAddNewEmails")) {
									var interval = parseInt(this.get("emailsCyclicallyAddingInterval"), 10);
									if (interval < 1 || isNaN(interval)) {
										MaskHelper.HideBodyMask();
										BPMSoft.utils.showInformation(
											resources.localizableStrings.EmailsCyclicallyAddingIntervalTooSmallCaption,
											null, null, {buttons: ["ok"]});
										return;
									}
								}
								this.isServerValid();
							}
						} else {
							MaskHelper.HideBodyMask();
							BPMSoft.utils.showInformation(
								resources.localizableStrings.NotSetSendingOrReceivingCheckMessage, null, null,
								{buttons: ["ok"]});
						}
					},
					onCancelBtnClick: function() {
						sandbox.publish("BackHistoryState");
					},
					onChooseGroupBtnClick: function() {
						chekUserCredentials(this);
					},
					onAccessBtnClick: function() {
					},
					onPrepareMailServerList: function(filter, list) {
						list.clear();
						var collection = this.get("mailServerCollection");
						list.loadAll(collection);
					},
					onMailServerChange: function(item) {
						if (item) {
							var data = {
								id: item.value
							};
							requestService(data, "GetMailProviderSettingsById", this.mailServerChangeCallback);
						}
					},
					mailServerChangeCallback: function(request, success, response) {
						if (success) {
							var result = Ext.decode(response.responseText);
							var obj = result.GetMailProviderSettingsByIdResult;
							if (obj) {
								viewModel.set("serverAllowEmailDownloading", obj.AllowEmailDownloading);
								viewModel.set("enableMailSynhronization", obj.AllowEmailDownloading);
								viewModel.set("serverAllowEmailSending", obj.AllowEmailSending);
								if (!obj.AllowEmailSending) {
									viewModel.set("sendEmailsViaThisAccount", obj.AllowEmailSending);
									viewModel.set("isDefault", obj.AllowEmailSending);
								}
							}
						}
					},
					getSettingsCallback: function(result) {
						viewModel.set("accessControlsVisible", result);
					},
					setEmailDownloadControlGroupEnabled: function(value) {
						this.set("emailDownloadControlGroupEnabled", value);
					},
					setIsDefault: function() {
						return this.get("sendEmailsViaThisAccount") && (this.get("mailboxType") === "private");
					},
					getAutomaticallyAddNewEmailsEnabled: function() {
						return this.get("automaticallyAddNewEmails") && this.get("emailDownloadControlGroupEnabled");
					},
					getStartWithDateEnabled: function() {
						return this.get("downloadFrom") === "all" && this.get("emailDownloadControlGroupEnabled");
					},
					getChooseGroupEnabled: function() {
						return this.get("downloadFrom") === "fromGroup" && this.get("emailDownloadControlGroupEnabled");
					},
					setMailboxNameValue: function(value) {
						var mailboxName = this.get("mailboxName");
						if (Ext.isEmpty(mailboxName)) {
							this.set("mailboxName", value);
						}
					},
					getIsProviderSMTPAddressSet: function(callback) {
						if (this.get("mailServerValue") && this.get("mailServerValue").value) {
							var select = Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: "MailServer"
							});
							select.addColumn("SMTPServerAddress");
							select.getEntity(this.get("mailServerValue").value, function(result) {
								var isSet = false;
								if (result.success) {
									var entity = result.entity;
									isSet = !Ext.isEmpty(entity.get("SMTPServerAddress"));
								}
								if (!isSet) {
									BPMSoft.utils.showInformation(
										resources.localizableStrings.SMTPSettingsNotSetMessage, null, null,
										{buttons: ["ok"]});
								} else {
									if (callback) {
										callback.call(this);
									}
								}
							}, this);
						} else {
							BPMSoft.utils.showInformation(resources.localizableStrings.SMTPSettingsNotSetMessage,
								null, null, {buttons: ["ok"]});
						}
					},
					checkIsProviderSMTPAddressSet: function(callback) {
						if (this.get("sendEmailsViaThisAccount")) {
							this.getIsProviderSMTPAddressSet(callback);
						} else {
							callback.call(this);
						}
					},
					createBPMCRMEmailFolder: function() {
						var data = {
							id: this.get("mailServerValue").value,
							userName: this.get("userName"),
							userPassword: this.get("userPassword")
						};
						requestService(data, "CreateBPMCRMFolder", function(request, success) {
							if (success) {
								sandbox.publish("PushHistoryState", {hash: "MailboxSynchronizationSettingsModule"});
							} else {
								BPMSoft.utils.showInformation(resources.localizableStrings.ImapExceptionMessage,
									null, null, {buttons: ["ok"]});
							}
						});
					},
					checkEditContactRights: function(callback, scope) {
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "Contact"
						});
						select.addColumn("Id");
						select.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"[SysAdminUnit:Contact].Id", this.get("sysAdminUnitId")));
						select.getEntityCollection(function(response) {
							var collection = response.collection.collection;
							if (collection.length === 0) {
								callback.call(scope);
							} else {
								var item = collection.getAt(0);
								RightUtilities.checkCanEdit({
									schemaName: "Contact",
									primaryColumnValue: item.get("Id"),
									isNew: false
								}, function(result) {
									callback.call(scope, result);
								}, this);
							}
						}, this);
					},
					checkContactEmail: function(callback, innerCallback) {
						var that = this;
						var userName = this.get("senderEmailAddress");
						if (userName.indexOf("@") === -1) {
							callback.call(this, innerCallback);
						} else {
							this.checkEditContactRights(function(result) {
								if (!Ext.isEmpty(result)) {
									callback.call(this, innerCallback);
									return;
								}
								var select = Ext.create("BPMSoft.EntitySchemaQuery", {
									rootSchemaName: "ContactCommunication"
								});
								select.addColumn("Id");
								select.filters.addItem(BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "CommunicationType",
									ConfigurationConstants.CommunicationType.Email));
								select.filters.addItem(BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "Number", userName));
								select.filters.addItem(BPMSoft.createColumnFilterWithParameter(
									BPMSoft.ComparisonType.EQUAL, "[SysAdminUnit:Contact:Contact].Id",
									this.get("sysAdminUnitId")));
								select.getEntityCollection(function(response) {
									var collection = response.collection.collection;
									if (collection.length === 0) {
										this.AddEmailToContactCommunications(callback, innerCallback);
									} else {
										callback.call(this, innerCallback);
									}
								}, this);
							}, that);
						}
					},
					AddEmailToContactCommunications: function(callback, innerCallback) {
						BPMSoft.utils.showConfirmation(resources.localizableStrings.AddContactEmailMessage,
							function(returnCode) {
								if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
									var select = Ext.create("BPMSoft.EntitySchemaQuery", {
										rootSchemaName: "SysAdminUnit"
									});
									select.addColumn("Contact");
									select.getEntity(this.get("sysAdminUnitId"), function(result) {
										if (result.success) {
											var entity = result.entity;
											var insert = Ext.create("BPMSoft.InsertQuery", {
												rootSchemaName: "ContactCommunication"
											});
											var id = BPMSoft.utils.generateGUID();
											insert.setParameterValue("Id", id, BPMSoft.DataValueType.GUID);
											insert.setParameterValue("CommunicationType",
												ConfigurationConstants.CommunicationType.Email,
												BPMSoft.DataValueType.GUID);
											insert.setParameterValue("Contact", entity.get("Contact").value,
												BPMSoft.DataValueType.GUID);
											insert.setParameterValue("Number", this.get("senderEmailAddress"),
												BPMSoft.DataValueType.TEXT);
											insert.execute();
											callback.call(this, innerCallback);
										}
									}, this);
								} else {
									callback.call(this, innerCallback);
								}
							}, ["yes", "no"], this);
					},
					isServerValid: function() {
						var data = {
							id: this.get("mailServerValue").value,
							userName: this.get("userName"),
							userPassword: this.get("userPassword"),
							enableSync: this.get("enableMailSynhronization"),
							sendEmail: this.get("sendEmailsViaThisAccount"),
							senderEmailAddress: this.get("senderEmailAddress"),
							isAnonymousAuthentication:  this.get("isAnonymousAuthentication")
						};
						requestService(data, "IsServerValid", function(request, success, response) {
							if (success) {
								var result = Ext.decode(response.responseText);
								if (result.IsServerValidResult.IsValid) {
									viewModel.checkUniqueness(viewModel);
								} else {
									MaskHelper.HideBodyMask();
									BPMSoft.utils.showInformation(result.IsServerValidResult.Message, null, null,
										{buttons: ["ok"]});
								}
							} else {
								MaskHelper.HideBodyMask();
							}
						});
					},
					createOrDeleteSyncJob: function() {
						var interval = parseInt(this.get("emailsCyclicallyAddingInterval"), 10);
						var data = {
							create: this.get("enableMailSynhronization") && this.get("automaticallyAddNewEmails"),
							mailboxName: this.get("mailboxName"),
							interval: interval
						};
						requestService(data, "CreateDeleteSyncJob", function(request, success, response) {
							if (success) {
								var result = Ext.decode(response.responseText);
								if (!Ext.isEmpty(result.CreateDeleteSyncJobResult)) {
									MaskHelper.HideBodyMask();
									BPMSoft.utils.showInformation(result.CreateDeleteSyncJobResult, null, null,
										{buttons: ["ok"]});
								} else {
									viewModel.checkContactEmail(viewModel.checkIsProviderSMTPAddressSet,
										viewModel.saveSettings);
								}
							} else {
								MaskHelper.HideBodyMask();
							}
						});
					},
					getSettings: function(renderTo) {
						var id = this.get("mailboxSyncSettingsId");
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "MailboxSyncSettings"
						});
						select.addColumn("AutomaticallyAddNewEmails");
						select.addColumn("EnableMailSynhronization");
						select.addColumn("EmailsCyclicallyAddingInterval");
						select.addColumn("SysAdminUnit");
						select.addColumn("LoadAllEmailsFromMailBox");
						select.addColumn("MailServer");
						select.addColumn("UserName");
						select.addColumn("UserPassword");
						select.addColumn("SenderEmailAddress");
						select.addColumn("MailboxName");
						select.addColumn("IsShared");
						select.addColumn("SendEmailsViaThisAccount");
						select.addColumn("IsDefault");
						select.addColumn("LoadEmailsFromDate");
						select.addColumn("IsAnonymousAuthentication");
						select.getEntity(id, function(result) {
							if (result.success) {
								var entity = result.entity;
								this.set("automaticallyAddNewEmails", entity.get("AutomaticallyAddNewEmails"));
								this.set("enableMailSynhronization", entity.get("EnableMailSynhronization"));
								this.set("emailsCyclicallyAddingInterval",
									entity.get("EmailsCyclicallyAddingInterval"));
								this.set("sysAdminUnitId", entity.get("SysAdminUnit").value);
								this.set("loadAllEmailsFromMailBox", entity.get("LoadAllEmailsFromMailBox"));
								this.set("mailServerValue", {
									value: entity.get("MailServer").value,
									displayValue: entity.get("MailServer").displayValue
								});
								this.set("userName", entity.get("UserName"));
								this.set("userPassword", entity.get("UserPassword"));
								this.set("senderEmailAddress", entity.get("SenderEmailAddress"));
								this.set("mailboxName", entity.get("MailboxName"));
								var isShared = entity.get("IsShared");
								this.set("mailboxType", isShared ? "public" : "private");
								this.set("sendEmailsViaThisAccount", entity.get("SendEmailsViaThisAccount"));
								this.set("isDefault", entity.get("IsDefault"));
								var loadAllEmailsFromMailBox = entity.get("LoadAllEmailsFromMailBox");
								this.set("downloadFrom", loadAllEmailsFromMailBox ? "all" : "fromGroup");
								this.set("loadEmailsFromDate", entity.get("LoadEmailsFromDate"));
								this.set("isAnonymousAuthentication", entity.get("IsAnonymousAuthentication"));
							}
							var view = getView();
							view.bind(this);
							view.render(renderTo);
						}, this);
						RightUtilities.checkCanExecuteOperation({
							operation: "CanManageMailServers"
						}, this.getSettingsCallback);
					},
					saveSettings: function() {
						var settingsId = this.get("mailboxSyncSettingsId");
						if (settingsId) {
							var update = Ext.create("BPMSoft.UpdateQuery", {
								rootSchemaName: "MailboxSyncSettings"
							});
							var filters = update.filters;
							var idFilter = update.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id",
								settingsId);
							filters.add("IdFilter", idFilter);
							update.setParameterValue("AutomaticallyAddNewEmails",
								this.get("automaticallyAddNewEmails"), BPMSoft.DataValueType.BOOLEAN);
							update.setParameterValue("EnableMailSynhronization",
								this.get("enableMailSynhronization"), BPMSoft.DataValueType.BOOLEAN);
							update.setParameterValue("EmailsCyclicallyAddingInterval",
								this.get("emailsCyclicallyAddingInterval"), BPMSoft.DataValueType.INTEGER);
							update.setParameterValue("SysAdminUnit",
								this.get("sysAdminUnitId"), BPMSoft.DataValueType.GUID);
							update.setParameterValue("LoadAllEmailsFromMailBox",
								this.get("downloadFrom") === "all", BPMSoft.DataValueType.BOOLEAN);
							update.setParameterValue("MailServer",
								this.get("mailServerValue").value, BPMSoft.DataValueType.GUID);
							update.setParameterValue("UserName",
								this.get("userName"), BPMSoft.DataValueType.TEXT);
							update.setParameterValue("UserPassword",
								this.get("userPassword"), BPMSoft.DataValueType.TEXT);
							update.setParameterValue("SenderEmailAddress",
								this.get("senderEmailAddress"), BPMSoft.DataValueType.TEXT);
							update.setParameterValue("MailboxName",
								this.get("mailboxName"), BPMSoft.DataValueType.TEXT);
							update.setParameterValue("IsShared",
								this.get("mailboxType") === "public", BPMSoft.DataValueType.BOOLEAN);
							update.setParameterValue("SendEmailsViaThisAccount",
								this.get("sendEmailsViaThisAccount"), BPMSoft.DataValueType.BOOLEAN);
							update.setParameterValue("IsDefault",
								this.get("isDefault"), BPMSoft.DataValueType.BOOLEAN);
							update.setParameterValue("LoadEmailsFromDate",
								this.get("loadEmailsFromDate"), BPMSoft.DataValueType.DATE);
							update.setParameterValue("IsAnonymousAuthentication",
								this.get("isAnonymousAuthentication"), BPMSoft.DataValueType.BOOLEAN);
							update.execute(function() {
								saveFoldersSettings(this);
							}, this);
						} else {
							var insert = getInsertMailboxSyncSettings(this);
							insert.execute(function() {
								saveFoldersSettings(this);
							}, this);
							//this.createBPMCRMEmailFolder();
						}
					},
					checkUniqueness: function(scope) {
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "MailboxSyncSettings"
						});
						select.addColumn("Id");
						var filters = Ext.create("BPMSoft.FilterGroup");
						var uniqureFiledsFilters = Ext.create("BPMSoft.FilterGroup");
						uniqureFiledsFilters.logicalOperation = BPMSoft.LogicalOperatorType.OR;
						uniqureFiledsFilters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"SenderEmailAddress", scope.get("senderEmailAddress")));
						uniqureFiledsFilters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"MailboxName", scope.get("mailboxName")));
						filters.addItem(uniqureFiledsFilters);
						filters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.NOT_EQUAL,
							"Id", scope.get("mailboxSyncSettingsId")));
						select.filters = filters;
						select.getEntityCollection(function(response) {
							if (response.success) {
								var collection = response.collection.collection;
								if (collection.length === 0) {
									viewModel.createOrDeleteSyncJob();
								} else {
									MaskHelper.HideBodyMask();
									BPMSoft.utils.showInformation(resources.localizableStrings.settingsExists);
								}
							} else {
								MaskHelper.HideBodyMask();
							}
						}, scope);
					}
				}
			});
			model.ajaxProvider = BPMSoft.AjaxProvider;
			return model;
		}

		function getInsertMailboxSyncSettings(scope) {
			var insert = Ext.create("BPMSoft.InsertQuery", {
				rootSchemaName: "MailboxSyncSettings"
			});
			var id = BPMSoft.utils.generateGUID();
			scope.set("mailboxSyncSettingsId", id);
			insert.setParameterValue("Id", id, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("AutomaticallyAddNewEmails", scope.get("automaticallyAddNewEmails"),
				BPMSoft.DataValueType.BOOLEAN);
			insert.setParameterValue("EnableMailSynhronization", scope.get("enableMailSynhronization"),
				BPMSoft.DataValueType.BOOLEAN);
			insert.setParameterValue("EmailsCyclicallyAddingInterval", scope.get("emailsCyclicallyAddingInterval"),
				BPMSoft.DataValueType.INTEGER);
			insert.setParameterValue("SysAdminUnit", scope.get("sysAdminUnitId"), BPMSoft.DataValueType.GUID);
			insert.setParameterValue("LoadAllEmailsFromMailBox", scope.get("downloadFrom") === "all",
				BPMSoft.DataValueType.BOOLEAN);
			insert.setParameterValue("MailServer", scope.get("mailServerValue").value, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("UserName", scope.get("userName"), BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("UserPassword", scope.get("userPassword"), BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("SenderEmailAddress", scope.get("senderEmailAddress"),
				BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("MailboxName", scope.get("mailboxName"), BPMSoft.DataValueType.TEXT);
			insert.setParameterValue("IsShared", scope.get("mailboxType") === "public",
				BPMSoft.DataValueType.BOOLEAN);
			insert.setParameterValue("SendEmailsViaThisAccount", scope.get("sendEmailsViaThisAccount"),
				BPMSoft.DataValueType.BOOLEAN);
			insert.setParameterValue("IsDefault", scope.get("isDefault"), BPMSoft.DataValueType.BOOLEAN);
			insert.setParameterValue("LoadEmailsFromDate", scope.get("loadEmailsFromDate"),
				BPMSoft.DataValueType.DATE);
			insert.setParameterValue("IsAnonymousAuthentication", scope.get("isAnonymousAuthentication"),
				BPMSoft.DataValueType.BOOLEAN);
			return insert;
		}

		function chekUserCredentials(scope) {
			if (!scope.get("mailServerValue") || scope.get("userName") === "" || scope.get("userPassword") === "") {
				BPMSoft.utils.showInformation(resources.localizableStrings.CantConnectWithoutCredentials);
				return;
			}
			var data = {
				id: scope.get("mailServerValue") ? scope.get("mailServerValue").value : null,
				userName: scope.get("userName"),
				userPassword: scope.get("userPassword"),
				senderEmailAddress: scope.get("senderEmailAddress"),
				enableSync: scope.get("enableMailSynhronization"),
				sendEmail: scope.get("sendEmailsViaThisAccount")
			};
			if (!Ext.isEmpty(scope.get("mailboxSyncSettingsId"))) {
				getPreviousFoldersSettings(scope);
				return;
			}
			requestService(data, "IsServerValid", function(request, success, response) {
				if (success) {
					var result = Ext.decode(response.responseText);
					if (result.IsServerValidResult.IsValid) {
						getPreviousFoldersSettings(scope);
					} else {
						BPMSoft.utils.showInformation(result.IsServerValidResult.Message, null, null,
							{buttons: ["ok"]});
					}
				}
			});
		}

		function openGroupChoose(scope, folders) {
			var lookupPageId = sandbox.id + "_MailboxFolderSyncSettingsModule";
			var params = sandbox.publish("GetHistoryState");
			sandbox.publish("PushHistoryState", {hash: params.hash.historyState});
			var moduleName = "MailboxFolderSyncSettingsModule";
			sandbox.loadModule(moduleName, {
				renderTo: container,
				id: lookupPageId,
				keepAlive: true
			});
			sandbox.subscribe("GetParams", function() {
				return {
					mailboxId: scope.get("mailboxSyncSettingsId"),
					mailboxName: scope.get("userName"),
					mailServerId: scope.get("mailServerValue") ? scope.get("mailServerValue").value : null,
					mailboxPassword: scope.get("userPassword"),
					folders: folders
				};
			}, [lookupPageId]);
			sandbox.subscribe("ResultSelectedRows", function(args) {
				scope.set("newFolders", args.folders);
			}, [lookupPageId]);
		}

		function saveFoldersSettings(scope) {
			MaskHelper.HideBodyMask();
			var folders = scope.get("newFolders");
			if (Ext.isEmpty(folders)) {
				sandbox.publish("PushHistoryState", {hash: "MailboxSynchronizationSettingsModule"});
				return;
			}
			var mailboxId = scope.get("mailboxSyncSettingsId");
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "MailboxFoldersCorrespondence"
			});
			select.addColumn("Id");
			select.addColumn("ActivityFolder");
			select.addColumn("FolderPath");
			var filters = Ext.create("BPMSoft.FilterGroup");
			filters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Mailbox",
				mailboxId));
			select.filters = filters;
			select.getEntityCollection(function(response) {
				var responseItems = response.collection.getItems();
				getMailboxFolderId(scope, folders, responseItems, mailboxId);
			}, this);
		}

		function alignFoldersSettings(scope, newfolders, oldFolders, mailboxId, mailboxFolderId) {
			if (!newfolders || newfolders.length < 2) {
				return;
			}
			var rootId = newfolders[0].Id;
			var bq = Ext.create("BPMSoft.BatchQuery");
			for (var i = 1; i < newfolders.length; i++) {
				if (!isArrayContainsPath(oldFolders, newfolders[i].Path)) {
					var activityFolderId = BPMSoft.utils.generateGUID();
					var parentId = newfolders[i].ParentId === rootId ? mailboxFolderId : newfolders[i].ParentId;
					bq.add(getActivityFolderInsert(activityFolderId, newfolders[i].Name, parentId));
					bq.add(getMailboxFolderCorrespondenceInsert(mailboxId, activityFolderId, newfolders[i].Path));
				}
			}
			if (bq.queries.length > 0) {
				bq.execute(function() {
					deleteOldFolders(scope, mailboxId, newfolders, oldFolders);
				});
			} else {
				deleteOldFolders(scope, mailboxId, newfolders, oldFolders);
			}
		}

		function deleteOldFolders(scope, mailboxId, newfolders, oldFolders) {
			var bq = Ext.create("BPMSoft.BatchQuery");
			for (var i = 0; i < oldFolders.length; i++) {
				if (!isArrayContainsPathProperty(newfolders, oldFolders[i].get("FolderPath"))) {
					bq.add(getMailboxFolderCorrespondenceDelete(oldFolders[i].get("Id")));
					//bq.add(getActivityFolderDelete(activityFolderId, newfolders[i].Name, parentId));
				}
			}
			bq.execute(function() {
				MaskHelper.HideBodyMask();
				sandbox.publish("PushHistoryState", {hash: "MailboxSynchronizationSettingsModule"});
			});
		}

		function getMailboxFolderCorrespondenceInsert(mailboxId, activityFolderId, path) {
			var insert = Ext.create("BPMSoft.InsertQuery", {
				rootSchemaName: "MailboxFoldersCorrespondence"
			});
			insert.setParameterValue("Mailbox", mailboxId, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("ActivityFolder", activityFolderId, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("FolderPath", path, BPMSoft.DataValueType.TEXT);
			return insert;
		}

		function getMailboxFolderCorrespondenceDelete(id) {
			var del = Ext.create("BPMSoft.DeleteQuery", {
				rootSchemaName: "MailboxFoldersCorrespondence"
			});
			var filters = Ext.create("BPMSoft.FilterGroup");
			filters.addItem(del.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id", id));
			del.filters = filters;
			return del;
		}

		function getActivityFolderInsert(activityFolderId, name, parentId) {
			var insert = Ext.create("BPMSoft.InsertQuery", {
				rootSchemaName: "ActivityFolder"
			});
			insert.setParameterValue("Id", activityFolderId, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("Parent", parentId, BPMSoft.DataValueType.GUID);
			insert.setParameterValue("FolderType", "b97a5836-1cd0-e111-90c6-00155d054c03",
				BPMSoft.DataValueType.GUID);
			insert.setParameterValue("Name", name, BPMSoft.DataValueType.TEXT);
			return insert;
		}

		function getMailboxFolderId(scope, folders, oldFolders, mailboxId) {
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "ActivityFolder"
			});
			select.addColumn("Id");
			var filters = Ext.create("BPMSoft.FilterGroup");
			filters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Name",
				scope.get("mailboxName")));
			select.filters = filters;
			select.getEntityCollection(function(response) {
				var responseItems = response.collection.getItems();
				alignFoldersSettings(scope, folders, oldFolders, mailboxId, responseItems[0].get("Id"));
			}, this);
		}

		function isArrayContainsPath(array, item) {
			for (var i = 0; i < array.length; i++) {
				if (array[i].get("FolderPath") === item) {
					return true;
				}
			}
			return false;
		}

		function isArrayContainsPathProperty(array, item) {
			for (var i = 0; i < array.length; i++) {
				if (array[i].Path === item) {
					return true;
				}
			}
			return false;
		}

		function getPreviousFoldersSettings(scope) {
			var select = Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: "MailboxFoldersCorrespondence"
			});
			select.addColumn("FolderPath");
			var filters = Ext.create("BPMSoft.FilterGroup");
			filters.addItem(select.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Mailbox",
				scope.get("mailboxSyncSettingsId")));
			select.filters = filters;
			select.getEntityCollection(function(response) {
				var responseItems = response.collection.getItems();
				var folders = [];
				for (var i = 0; i < responseItems.length; i++) {
					folders.push(responseItems[i].get("FolderPath"));
				}
				openGroupChoose(scope, folders);
			}, this);
		}

		function reRender(renderTo) {
			var view = getView();
			view.bind(viewModel);
			view.render(renderTo);
		}

		function render(renderTo) {
			if (viewModel) {
				reRender(renderTo);
				return;
			}
			container = renderTo;
			viewModel = getViewModel();
			var state = sandbox.publish("GetHistoryState");
			fillMailServerCollection(viewModel);
			if (state.state && state.state.id) {
				viewModel.set("mailboxSyncSettingsId", state.state.id);
				viewModel.getSettings(renderTo);
			} else {
				var view = getView();
				view.bind(viewModel);
				view.render(renderTo);
			}
		}

		function init() {
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
		}

		return {
			init: init,
			render: render
		};
	});
