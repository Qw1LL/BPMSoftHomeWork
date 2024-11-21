define("FindContactsInSocialNetworksModule", ["ext-base", "BPMSoft", "sandbox", "SocialAccountAuthUtilities",
		"FindContactsInSocialNetworksModuleResources", "MaskHelper", "ConfigurationEnums", "Contact"],
	function(Ext, BPMSoft, sandbox, SocialAccountAuthUtilities, resources, MaskHelper, ConfigurationEnums, Contact) {

	var container = null;
	var viewModel = null;
	var viewConfig = null;
	var createNewContactCaption = null;

	/**
	 * ########## ######## ############ #### ########## #####.
	 * @private
	 * @return {String} ######## ############ #### ########## #####.
	 */
	function getAllSocialNetworks() {
		var socialNetworks = "Facebook,Twitter";
		if (Contact.columns.LinkedIn.usageType !== ConfigurationEnums.EntitySchemaColumnUsageType.None) {
			socialNetworks += ",LinkedIn";
		}
		return socialNetworks;
	}

	function getView() {
		var btnCreateNewContactCaption;
		if (createNewContactCaption != null) {
			btnCreateNewContactCaption = createNewContactCaption;
		} else {
			btnCreateNewContactCaption = resources.localizableStrings.CreateNewContactButtonCaption;
		}
		return {
			className: "BPMSoft.Container",
			id: "view-container",
			selectors: {
				wrapEl: "#view-container"
			},
			markerValue: "FindContactsInSocialNetworksModule",
			items: [{
				className: "BPMSoft.Container",
				id: "top-buttons",
				selectors: {
					wrapEl: "#top-buttons"
				},
				items: [{
					className: "BPMSoft.Button",
					id: "btnCreateNewContact",
					caption: btnCreateNewContactCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					tag: "createNewContact",
					visible: {
						bindTo: "moduleMode",
						bindConfig: {
							converter: function(value) {
								return isSearchMode(value);
							}
						}
					},
					click: {
						bindTo: "onCreateNewContactBtnClick"
					},
					classes: {
						textClass: "top-button"
					}
				}, {
					className: "BPMSoft.Button",
					id: "btnOk",
					caption: resources.localizableStrings.OKButtonCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					tag: "ok",
					visible: {
						bindTo: "moduleMode",
						bindConfig: {
							converter: function(value) {
								return !isSearchMode(value);
							}
						}
					},
					click: {
						bindTo: "onOKBtnClick"
					},
					classes: {
						textClass: "top-button"
					},
					markerValue: "SelectButton"
				}, {
					className: "BPMSoft.Button",
					id: "btnClose",
					caption: resources.localizableStrings.CloseButtonCaption,
					style: BPMSoft.controls.ButtonEnums.style.ORANGE,
					tag: "close",
					click: {
						bindTo: "onCloseBtnClick"
					},
					classes: {
						textClass: "top-button"
					}
				}, {
					className: "BPMSoft.Button",
					id: "btnView",
					caption: resources.localizableStrings.ViewButtonCaption,
					tag: "view",
					click: {
						bindTo: "onViewBtnClick"
					},
					classes: {
						textClass: "top-button"
					}
				}],
				classes: {
					wrapClassName: ["top-buttons"]
				}
			}, {
				className: "BPMSoft.Container",
				id: "search-area",
				selectors: {
					wrapEl: "#search-area"
				},
				items: [{
					className: "BPMSoft.TextEdit",
					id: "edSearch",
					classes: {
						wrapClass: ["search-edit"]
					},
					enterkeypressed: {
						bindTo: "onFindBtnClick"
					},
					value: {
						bindTo: "searchCriteria"
					},
					markerValue: "SocialSearchQuery"
				}, {
					className: "BPMSoft.Container",
					id: "findButtonContainer",
					selectors: {
						wrapEl: "#findButtonContainer"
					},
					classes: {
						wrapClassName: ["find-button"]
					},
					items: [{
						className: "BPMSoft.Button",
						id: "btnFind",
						caption: resources.localizableStrings.FindButtonCaption,
						tag: "find",
						click: {
							bindTo: "onFindBtnClick"
						},
						markerValue: "SearchButton"
					}]
				}]
			}, {
				className: "BPMSoft.Container",
				id: "filterArea",
				selectors: {
					wrapEl: "#filterArea"
				},
				visible: {
					bindTo: "moduleMode",
					bindConfig: {
						converter: function(value) {
							return isSearchMode(value);
						}
					}
				},
				items: [{
					className: "BPMSoft.Label",
					caption: resources.localizableStrings.FilterSocialNetworksLabelCaption,
					classes: {
						labelClass: ["controlCaption"]
					}
				},
					{
						className: "BPMSoft.ComboBoxEdit",
						id: "cbxFilterSocialNetworks",
						classes: {
							wrapClass: ["filter-social-networks"]
						},
						value: {
							bindTo: "SocialNetworkFilterListValue"
						},
						list: {
							bindTo: "SocialNetworkFilterList"
						},
						prepareList: {
							bindTo: "GetSocialNetworkFilterListData"
						},
						markerValue: resources.localizableStrings.FilterSocialNetworksLabelCaption
					}]
			}, {
				className: "BPMSoft.Container",
				id: "resultsArea",
				selectors: {
					wrapEl: "#resultsArea"
				},
				items: [{
					className: "BPMSoft.Label",
					caption: resources.localizableStrings.ResultsLabelCaption,
					classes: {
						labelClass: ["controlCaption"]
					}
				}, {
					className: "BPMSoft.Grid",
					id: "grdResults",
					type: "listed",
					activeRow: {
						bindTo: "activeRow"
					},
					collection: {
						bindTo: "gridData"
					},
					captionsConfig: [{
						cols: 24,
						name: resources.localizableStrings.SocialAccountColCaption
					}],
					columnsConfig: [{
						cols: 24,
						key: [{
							name: {
								bindTo: "socialnetworkImage"
							},
							type: "grid-icon-32x32"
						}, {
							name: {
								bindTo: "Name"
							},
							type: "text"
						}]
					}]
				}]
			}]
		};
	}

	function getSearchViewModel() {
		viewConfig = getView();
		var view = Ext.create(viewConfig.className || "BPMSoft.Container", viewConfig);
		viewModel = getViewModel();
		view.bind(viewModel);
		var historyState = sandbox.publish("LookupInfo", null, [sandbox.id]);
		if (historyState == null) {
			historyState = sandbox.publish("GetHistoryState").state;
		}
		if (!historyState.mode) {
			historyState = sandbox.publish("SetInitialisationData", null, [sandbox.id]);
		}
		var mode = historyState.mode;
		viewModel.set("moduleMode", mode);
		if (mode === "choice") {
			var socialNetworkValue = {
				value: historyState.socialNetwork
			};
			viewModel.set("SocialNetworkFilterListValue", socialNetworkValue);
		}
		viewModel.set("searchCriteria", historyState.recordName);
		MaskHelper.HideBodyMask();
		view.render(container);
		return viewModel;
	}

	function getViewModel() {
		return Ext.create("BPMSoft.BaseViewModel", {
			values: {
				moduleMode: "search",
				searchCriteria: "",
				activeRow: "",
				gridData: Ext.create("BPMSoft.BaseViewModelCollection", {
					listeners: {
						dataloaded: function() {
							this.sortByFn(function(o1, o2) {
								var property1 = o1.get("Name");
								var property2 = o2.get("Name");
								if (property1 === property2) {
									return 0;
								}
								return (property1 < property2) ? -1 : 1;
							});
						}
					},
					rowConfig: {Name: "Name", Id: "Id"}
				}),
				/**
				 * ######## ########## ####, ## ####### ##### ############# ########## ######. "### ########## ####" ##
				 * #########
				 * @type {String}
				 */
				SocialNetworkFilterListValue: {
					value: getAllSocialNetworks(),
					displayValue: resources.localizableStrings.AllSocialNetworksCaption
				},
				SocialNetworkFilterList: new BPMSoft.Collection()
			},
			methods: {
				GetSocialNetworkFilterListData: function(filter, list) {
					list.clear();
					var listValues = {
						"0": {
							value: getAllSocialNetworks(),
							displayValue: resources.localizableStrings.AllSocialNetworksCaption
						},
						"2": {value: "Facebook", displayValue: "Facebook"},
						"3": {value: "Twitter", displayValue: "Twitter"}
					};
					if (Contact.columns.LinkedIn.usageType !== ConfigurationEnums.EntitySchemaColumnUsageType.None) {
						listValues["1"] = {value: "LinkedIn", displayValue: "LinkedIn"};
					}
					list.loadAll(listValues);
				},
				onCloseBtnClick: function() {
					sandbox.publish("BackHistoryState");
				},
				onOKBtnClick: function() {
					var activeRow = getActiveRow(this);
					var socialNetworkName = this.get("SocialNetworkFilterListValue").value;
					if (activeRow !== null && activeRow.values !== null) {
						var id = activeRow.values.Id;
						var name = activeRow.values.Name;
						sandbox.publish("ResultSelectedRows", {
							id: id,
							name: name,
							socialNetworkName: socialNetworkName
						}, [sandbox.id]);
					}
					sandbox.publish("BackHistoryState");
				},
				onViewBtnClick: function() {
					var activeRow = getActiveRow(this);
					var profileUrl;
					if (activeRow !== null && activeRow.values !== null) {
						profileUrl = activeRow.values.PublicProfileUrl;
					}
					if (profileUrl !== undefined && profileUrl !== "") {
						if (Ext.isIE) {
							profileUrl = profileUrl.replace("#!/", "");
						}
						window.open(profileUrl);
					}
				},
				onCreateNewContactBtnClick: function() {
					var activeRow = getActiveRow(this);
					if (activeRow !== null) {
						createContactBySocialProfile(activeRow);
					}
				},
				onFindBtnClick: function() {
					this.set("activeRow", "");
					doSearchSocialData(this);
				}
			}
		});
	}

	function isSearchMode(mode) {
		return mode === "search";
	}

	function doSearchSocialData(scope) {
		var searchCriteria = scope.get("searchCriteria");
		if (searchCriteria === "") {
			return;
		}
		var gridData = scope.get("gridData");
		gridData.clear();
		MaskHelper.ShowBodyMask();
		var socialNetwork = scope.get("SocialNetworkFilterListValue").value;
		var dataSend = {
			searchCriteria: searchCriteria,
			socialNetworks: socialNetwork
		};
		var ajaxProvider = BPMSoft.AjaxProvider;
		callServiceMethod(ajaxProvider, "FindUsers", function(response) {
			if (response.FindUsersResult) {
				var responseData = Ext.decode(response.FindUsersResult);
				var exceptionNetworks = responseData.exceptionNetworks;
				var accessTokenExNetworks = responseData.accessTokenExNetworks;
				if (exceptionNetworks !== undefined && exceptionNetworks !== "" && exceptionNetworks !== "None") {
					showInformationDialog(this, exceptionNetworks, resources.localizableStrings.SocialNetworkError);
				}
				if (accessTokenExNetworks !== undefined && accessTokenExNetworks !== ""
					&& accessTokenExNetworks !== "None") {
					showAuthInformationDialog(this, accessTokenExNetworks,
						resources.localizableStrings.SocialNetworksError);
				}
				var results = {};
				BPMSoft.each(responseData.users, function(item) {
					if (item.Person) {
						item = item.Person;
						item.SocialNetwork = 4;
					}
					var viewModel = Ext.create("BPMSoft.BaseViewModel", {
						rowConfig: {
							Id: {caption: "Id", dataValueType: BPMSoft.DataValueType.GUID},
							Name: {caption: "Name", dataValueType: BPMSoft.DataValueType.TEXT},
							socialnetworkImage: {caption: "Image",
								dataValueType: BPMSoft.DataValueType.LOOKUP,
								primaryImageColumnName: "socialnetworkImage",
								isLookup: true}
						},
						values: item,
						methods: {
							getLookupImageUrl: function() {
								var socialNetwork = this.get("SocialNetwork");
								var image = null;
								switch (socialNetwork) {
									case 2:
										image = resources.localizableImages.facebookimg;
										break;
									case 4:
										image = resources.localizableImages.linkedinimg;
										break;
									case 8:
										image = resources.localizableImages.twitterimg;
										break;
								}
								return BPMSoft.ImageUrlBuilder.getUrl(image);
							}
						}
					});
					if (item.Id) {
						results[item.Id] = viewModel;
					} else if (item.Person) {
						results[item.Person.Id] = viewModel;
					}

				});
				gridData.loadAll(results);
			}
			MaskHelper.HideBodyMask();
		}, dataSend, scope);
	}

	function showInformationDialog(scope, networks, message) {
		scope.showInformationDialog(message + networks);
	}

	function showAuthInformationDialog(scope, networks, message) {
		if (Ext.isEmpty(networks)) {
			return;
		}
		if (networks === "All") {
			networks = "Facebook, Twitter";
			if (Contact.columns.LinkedIn.usageType !== ConfigurationEnums.EntitySchemaColumnUsageType.None) {
				networks += ", LinkedIn";
			}
		}
		var socialNetwork = networks.split(", ")[0];
		var cfg = {
			style: BPMSoft.MessageBoxStyles.ORANGE
		};
		scope.showConfirmationDialog(
			message + networks, function getSelectedButton(returnCode) {
				if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
					openSocialNetworkAuthWindow(socialNetwork, scope);
				}
			}, ["yes", "no"], cfg);
	}

	function openSocialNetworkAuthWindow(socialNetwork, scope) {
		SocialAccountAuthUtilities.checkSysSettingsAndOpenWindow(socialNetwork, sandbox, function() {
			scope.onFindBtnClick();
		});
	}

	function callServiceMethod(ajaxProvider, methodName, callback, dataSend, scope) {
		var data = dataSend || {};
		var workspaceBaseUrl = BPMSoft.utils.uri.getConfigurationWebServiceBaseUrl();
		var requestUrl = workspaceBaseUrl + "/rest/GetSocialProfileService/" + methodName;
		ajaxProvider.request({
			url: requestUrl,
			headers: {
				"Accept": "application/json",
				"Content-Type": "application/json"
			},
			method: "POST",
			jsonData: data,
			scope: scope,
			callback: function(request, success, response) {
				var responseObject = {};
				if (success) {
					responseObject = BPMSoft.decode(response.responseText);
				}
				callback.call(this, responseObject);
			}
		});
	}

	function createContactBySocialProfile(currItem) {
		var dataSend = {
			socialMediaId: currItem.values.SocialNetwork,
			socialAccountId: currItem.values.Id
		};
		var ajaxProvider = BPMSoft.AjaxProvider;
		callServiceMethod(ajaxProvider, "GetSocialProfile", function(response) {
			var socialProfileData = [];
			var result = Ext.decode(response.GetSocialProfileResult);
			BPMSoft.each(result, function(value, key) {
				if (value != null) {
					switch (key) {
						case "SocialNetwork":
							socialProfileData.push({
								name: value,
								value: this.Name
							});
							break;
						case "ProfileId":
							socialProfileData.push({
								name: this.SocialNetwork + "Id",
								value: value
							});
							break;
						case "BirthDate":
							socialProfileData.push({
								name: key,
								value: new Date(value)
							});
							break;
						case "City":
							if (!BPMSoft.isEmptyGUID(value)) {
								socialProfileData.push({
									name: "City",
									value: value
								});
							}
							break;
						case "Country":
							if (!BPMSoft.isEmptyGUID(value)) {
								socialProfileData.push({
									name: "Country",
									value: value
								});
							}
							break;
						case "Gender":
							break;
						case "GenderId":
							if (!BPMSoft.isEmptyGUID(value)) {
								socialProfileData.push({
									name: "Gender",
									value: value
								});
							}
							break;
						default:
							socialProfileData.push({
								name: key,
								value: value
							});
					}
				}
			});
			if (Object.keys(socialProfileData).length > 0) {
				openContactPage(socialProfileData);
			}
		}, dataSend, this);
	}

	function openContactPage(socialProfileData) {
		var initialisationData = sandbox.publish("SetInitialisationData", null, [sandbox.id]);
		var historyState = sandbox.publish("GetHistoryState");
		socialProfileData.push({
			name: "Account",
			value: initialisationData.recordId
		});
		sandbox.publish("PushHistoryState", {
			hash: historyState.hash.historyState,
			stateObj: {
				isSeparateMode: true,
				schemaName: "ContactPageV2",
				entitySchemaName: "Contact",
				operation: ConfigurationEnums.CardStateV2.ADD,
				valuePairs: socialProfileData
			}
		});
		sandbox.loadModule("CardModuleV2", {
			renderTo: container,
			keepAlive: true
		});
	}

	function getActiveRow(scope) {
		var activeRow = scope.get("activeRow");
		if (activeRow) {
			var gridData = scope.get("gridData");
			return gridData.get(activeRow);
		}
		return null;
	}

	function render(renderTo) {
		var headerCaption = resources.localizableStrings.SearchEditLabelCaption;
		sandbox.publish("ChangeHeaderCaption", {
			caption: headerCaption,
			dataViews: new BPMSoft.Collection()
		});
		sandbox.subscribe("NeedHeaderCaption", function() {
			sandbox.publish("InitDataViews", {caption: headerCaption});
		}, this);
		if (viewModel) {
			var config = getView();
			var view = Ext.create(config.className || "BPMSoft.Container", config);
			view.bind(viewModel);
			view.render(renderTo);
			return;
		}
		container = renderTo;
		viewModel = getSearchViewModel();
		doSearchSocialData(viewModel);
	}

	function init() {
		var state = sandbox.publish("GetHistoryState");
		var currentHash = state.hash;
		var currentState = state.state || {};
		if (currentState.moduleId !== sandbox.id) {
			var newState = BPMSoft.deepClone(currentState);
			newState.moduleId = sandbox.id;
			sandbox.publish("PushHistoryState", {
				stateObj: newState,
				pageTitle: null,
				hash: currentHash.historyState,
				silent: true
			});
		}
	}

	return {
		init: init,
		render: render
	};
});
