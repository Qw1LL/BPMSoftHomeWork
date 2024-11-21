define("ForecastBuilder", ["ext-base", "ForecastBuilderResources", "RightUtilities", "MaskHelper",
			"ConfigurationEnums", "ServiceHelper", "ImageCustomGeneratorV2", "AcademyUtilities"
		],
		function(Ext, resources, RightUtilities, MaskHelper, ConfigurationEnums, ServiceHelper, ImageCustomGenerator,
				AcademyUtilities) {

			/**
			 * @class BPMSoft.configuration.ForecastViewsConfig
			 * ##### ############ ############ ############# ###### ############.
			 */
			Ext.define("BPMSoft.configuration.ForecastsViewConfig", {
				extend: "BPMSoft.BaseObject",
				alternateClassName: "BPMSoft.ForecastsViewConfig",

				/**
				 * ########## ############ ############# ###### ############.
				 * @return {Object[]} ########## ############ ############# ###### ############.
				 */
				generate: function() {
					return [
						{
							"name": "Tabs",
							"itemType": BPMSoft.ViewItemType.TAB_PANEL,
							"activeTabChange": {"bindTo": "onActiveTabChange"},
							"activeTabName": {"bindTo": "ActiveTabName"},
							"classes": {"wrapClass": ["tab-panel-margin-bottom"]},
							"collection": {"bindTo": "TabsCollection"},
							"markerValue": "mainForecastPage",
							"defaultMarkerValueColumnName": "Caption",
							"controlConfig": {
								"items": [
									{
										"className": "BPMSoft.Button",
										"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
										"imageConfig": {"bindTo": "Resources.Images.Settings"},
										"hint": {"bindTo": "Resources.Strings.ConfigurationButtonHint"},
										"markerValue": "SettingsButton",
										"menu": {
											items: [
												{
													"caption": {"bindTo": "Resources.Strings.AddButtonCaption"},
													"click": {"bindTo": "addForecast"},
													"markerValue": {"bindTo": "Resources.Strings.AddButtonCaption"},
													"enabled": {
														"bindTo": "ForecastRightLevel",
														"bindConfig": {"converter": "isSchemaCanAppendRightConverter"}
													}
												}, {
													"caption": {"bindTo": "Resources.Strings.EditButtonCaption"},
													"click": {"bindTo": "editCurrentForecast"},
													"markerValue": {"bindTo": "Resources.Strings.EditButtonCaption"},
													"enabled": {"bindTo": "canEdit"}
												}, {
													"caption": {"bindTo": "Resources.Strings.CopyButtonCaption"},
													"click": {"bindTo": "copyCurrentForecast"},
													"markerValue": {"bindTo": "Resources.Strings.CopyButtonCaption"},
													"enabled": {"bindTo": "canCopy"}
												}, {
													"caption": {"bindTo": "Resources.Strings.DeleteButtonCaption"},
													"click": {"bindTo": "deleteCurrentForecast"},
													"markerValue": {"bindTo": "Resources.Strings.DeleteButtonCaption"},
													"enabled": {"bindTo": "canDelete"}
												}, {
													"caption": "",
													"className": "BPMSoft.MenuSeparator"
												}, {
													"caption": {"bindTo": "Resources.Strings.RightsButtonCaption"},
													"click": {"bindTo": "manageCurrentForecastRights"},
													"markerValue": {"bindTo": "Resources.Strings.RightsButtonCaption"},
													"enabled": {"bindTo": "canManageRights"}
												}
											]
										}
									}
								]
							}
						},
						{
							"name": "Message",
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"wrapClass": ["empty-grid-message"],
							"visible": {
								"bindTo": "IsTabsEmpty"
							},
							"items": [
								{
									"name": "Image",
									"classes": {
										wrapClass: ["image-container"]
									},
									"getSrcMethod": "getSrcMethod",
									"onPhotoChange": "onPhotoChange",
									"defaultImage": {"bindTo": "getDefaultImageURL"},
									"generator": "ImageCustomGeneratorV2.generateSimpleCustomImage"
								},
								{
									"name": "Title",
									"itemType": BPMSoft.ViewItemType.CONTAINER,
									"wrapClass": ["title"],
									"items": [
										{
											"name": "Title",
											"itemType": BPMSoft.ViewItemType.LABEL,
											"caption": {"bindTo": "Resources.Strings.MessageTitle"}
										}
									]
								},
								{
									"name": "Description",
									"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
									"wrapClass": ["description"],
									"items": [
										{
											"name": "Action",
											"itemType": BPMSoft.ViewItemType.CONTAINER,
											"wrapClass": ["action"],
											"items": [
												{
													"name": "Action",
													"itemType": BPMSoft.ViewItemType.LABEL,
													"caption": {"bindTo": "Resources.Strings.MessageAction"}
												}
											]
										},
										{
											"name": "Reference",
											"itemType": BPMSoft.ViewItemType.CONTAINER,
											"wrapClass": ["reference"],
											"items": [
												{
													"name": "Link",
													"itemType": BPMSoft.ViewItemType.HYPERLINK,
													"caption": {bindTo: "LinkAcademy"},
													"tpl": resources.localizableStrings.MessageReference,
													"href": {bindTo: "LinkAcademy"}
												}
											]
										}
									]
								}
							]
						},
						{
							"name": "ForecastModule",
							"itemType": BPMSoft.ViewItemType.CONTAINER,
							"visible": {
								"bindTo": "IsTabsEmpty",
								"bindConfig": {
									"converter": "invertBooleanValue"
								}
							}
						}
					];
				}
			});

			/**
			 * @class BPMSoft.configuration.BaseForecastsViewModel
			 * ##### ###### ############# ###### #####.
			 */
			Ext.define("BPMSoft.configuration.BaseForecastsViewModel", {
				extend: "BPMSoft.BaseModel",
				alternateClassName: "BPMSoft.BaseForecastsViewModel",
				mixins: {
					rightsUtilities: "BPMSoft.RightUtilitiesMixin"
				},

				Ext: null,
				sandbox: null,
				BPMSoft: null,

				constructor: function() {
					this.callParent(arguments);
					this.initResourcesValues(resources);
				},

				/**
				 * ############## ###### ########## ######## ## ####### ########.
				 * @protected
				 * @virtual
				 * @param {Object} resourcesObj ###### ########.
				 */
				initResourcesValues: function(resourcesObj) {
					var resourcesSuffix = "Resources";
					BPMSoft.each(resourcesObj, function(resourceGroup, resourceGroupName) {
						resourceGroupName = resourceGroupName.replace("localizable", "");
						BPMSoft.each(resourceGroup, function(resourceValue, resourceName) {
							var viewModelResourceName = [resourcesSuffix, resourceGroupName, resourceName].join(".");
							this.set(viewModelResourceName, resourceValue);
						}, this);
					}, this);
				},

				/**
				 * ############## ######### ######## ###### ### Tabs.
				 * @protected
				 * @virtual
				 */
				initTabs: function() {
					var defaultTabName = this.getDefaultTabName();
					if (!defaultTabName) {
						this.set("ActiveTabName", defaultTabName);
						this.loadRecordRights();
						var forecastModuleId = this.getForecastModuleId();
						this.sandbox.unloadModule(forecastModuleId);
						this.setIsTabsEmpty();
						return;
					}
					var forecasts = this.get("Forecasts");
					var activeTabName = this.get("ActiveTabName");
					var tabName = activeTabName && forecasts.find(activeTabName)
							? activeTabName
							: defaultTabName;
					this.setActiveTab(tabName);
					this.loadRecordRights();
					this.setIsTabsEmpty();
				},

				/**
				 * ######## ### ## #########.
				 * @protected
				 * @virtual
				 * @return {String} ########## ### ## #########.
				 */
				getDefaultTabName: function() {
					var tabsCollection = this.get("TabsCollection");
					if (tabsCollection.isEmpty()) {
						return "";
					}
					var defaultTab = tabsCollection.getByIndex(0);
					return defaultTab.get("Name");
				},

				/**
				 * ############# ######## #######.
				 * @protected
				 * @virtual
				 * @param {String} tabName ### #######.
				 */
				setActiveTab: function(tabName) {
					MaskHelper.ShowBodyMask();
					this.set("ActiveTabName", tabName);
				},

				/**
				 * ############ ####### ######### #######.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.BaseViewModel} activeTab ######### #######.
				 */
				onActiveTabChange: function(activeTab) {
					var currentForecastName = activeTab.get("Name");
					this.set("ActiveTabName", currentForecastName);
					this.saveActiveTabNameToProfile(currentForecastName);
					this.loadRecordRights();
					this.loadForecastModule();
				},

				/**
				 * ########## ######## ## ####### ## #####.
				 * @private
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ########## ####### ######### ######.
				 */
				getActiveTabNameFromProfile: function(callback, scope) {
					var key = this.getProfileKey();
					BPMSoft.require(["profile!" + key], function(profile) {
						this.set("ActiveTabName", profile.activeTabName);
						if (callback) {
							callback.call(scope);
						}
					}, this);
				},

				/**
				 * ######### ############# ######### ####### # #######.
				 * @private
				 * @param {String} activeTabName ############# ######## ############.
				 */
				saveActiveTabNameToProfile: function(activeTabName) {
					var key = this.getProfileKey();
					BPMSoft.utils.saveUserProfile(key, {
						activeTabName: activeTabName
					}, false);
				},

				/**
				 * ########## #### ### ##########\######### ###### ## #######.
				 * @protected
				 * @virtual
				 * @return {String} key ########## #### ### ###### ############ ####### #######.
				 */
				getProfileKey: function() {
					return "Forecasts_ModuleForecast";
				},

				/**
				 * ######### ########## #### ####### ### ######## ############.
				 */
				loadRecordRights: function() {
					var currentForecastName = this.get("ActiveTabName");
					this.set("CurrentRecordRightLevel", 0);
					if (currentForecastName) {
						RightUtilities.getSchemaRecordRightLevel(
								"Forecast",
								currentForecastName,
								function(rightLevel) {
									this.set("CurrentRecordRightLevel", rightLevel);
								}, this);
					}
				},

				/**
				 * ####### ####### ## #####.
				 * @param {String} tabName ### ####### ### ########.
				 */
				removeTab: function(tabName) {
					var tabsCollection = this.get("TabsCollection");
					tabsCollection.removeByKey(tabName);
				},

				/**
				 * ############## ######### ########.
				 * @protected
				 * @virtual
				 */
				initHeader: function() {
					var pageCaption = this.get("Resources.Strings.Caption");
					this.sandbox.publish("InitDataViews", {caption: pageCaption});
					this.initContextHelp();
				},

				/**
				 * ############## ########### #######.
				 * @protected
				 * @virtual
				 */
				initContextHelp: function() {
					var contextHelpId = 1022;
					var contextHelpConfig = {
						scope: this,
						contextHelpId: contextHelpId,
						contextHelpCode: "ForecastBuilder",
						callback: function(value) {
							this.set("LinkAcademy", value);
						}
					};
					this.sandbox.publish("InitContextHelp", contextHelpConfig);
					AcademyUtilities.getUrl(contextHelpConfig);
				},

				/**
				 * ######### ### ######### ###### ############.
				 * @protected
				 * @virtual
				 */
				loadForecastModule: function() {
					var forecastModuleId = this.getForecastModuleId();
					var forecastId = this.get("ActiveTabName");
					if (!this.sandbox.publish("ReloadForecast", null, [forecastModuleId])) {
						this.sandbox.loadModule("ForecastModule", {
							renderTo: "ForecastModuleContainer",
							id: forecastModuleId,
							forecastId: forecastId
						});
					}
				},

				/**
				 * ########## ########## ############# ### ###### ############.
				 * @protected
				 * @virtual
				 * @return {String} ########## ########## ############# ### ###### ############.
				 */
				getForecastModuleId: function() {
					return this.sandbox.id + "ForecastModule";
				},

				/**
				 * ############## ###### ############# ######## ######### ############ ############.
				 * @protected
				 * @virtual
				 */
				initData: function() {
					var forecasts = this.get("Forecasts");
					var tabsValues = [];
					forecasts.each(function(forecast) {
						tabsValues.push({
							Caption: forecast.get("Name"),
							Name: forecast.get("Id")
						});
					}, this);
					var tabsCollection = Ext.create("BPMSoft.BaseViewModelCollection", {
						entitySchema: Ext.create("BPMSoft.BaseEntitySchema", {
							columns: {},
							primaryColumnName: "Name"
						})
					});
					tabsCollection.loadFromColumnValues(tabsValues);
					this.set("TabsCollection", tabsCollection);
					this.setIsTabsEmpty();

				},

				/**
				 * ############# ######## ######### ######### #######.
				 * @protected
				 * @virtual
				 */
				setIsTabsEmpty: function() {
					var isEmpty = this.isCollectionEmptyConverter(this.get("TabsCollection"));
					this.set("IsTabsEmpty", isEmpty);
				},

				/**
				 * ############# ## ######### ## ######### ######## ############.
				 * @protected
				 * @virtual
				 */
				subscribeForecastMessage: function() {
					var forecastModuleId = this.getForecastModuleId();
					var addForecastModuleId = this.getAddForecastModuleId();
					var copyForecastModuleId = this.getCopyForecastModuleId();
					var editForecastModuleId = this.getEditForecastModuleId();
					this.sandbox.subscribe("GetForecastInfo", this.onGetForecastInfo, this, [forecastModuleId]);
					this.sandbox.subscribe("SetForecastResult", this.onSetForecastResult, this,
							[forecastModuleId, addForecastModuleId, copyForecastModuleId, editForecastModuleId]);
				},

				/**
				 * ############ ######### ###### ######## ############.
				 * @protected
				 * @virtual
				 * @param {Object} result ######### ###### ########.
				 */
				onSetForecastResult: function(result) {
					var forecastId = result.forecastId;
					if (!forecastId) {
						return;
					}
					var forecasts = this.get("Forecasts");
					var forecast = forecasts.find(forecastId);
					if (forecast) {
						forecast.set("Name", result.forecastName);
					} else {
						forecast = forecasts.createItem({
							"Id": result.forecastId,
							"Name": result.forecastName
						});
						forecasts.add(result.forecastId, forecast);
					}
					this.set("Forecasts", forecasts);
					this.unloadNestedModules();
					this.set("ReloadNestedModules", true);
					this.saveActiveTabNameToProfile(forecastId);
					this.setActiveTab(forecastId);
					this.initData();
					this.loadRecordRights();
				},

				/**
				 * ######### ### ######## ######.
				 * @protected
				 * @virtual
				 */
				unloadNestedModules: function() {
					var moduleId = this.getForecastModuleId();
					this.sandbox.unloadModule(moduleId);
				},

				/**
				 * ########## ####### ######### ########## ### ######## ############ ### ######## ##### ######.
				 * @protected
				 * @virtual
				 * @return {Object} ########## ########## ## ############.
				 */
				onGetForecastAddInfo: function() {
					return {
						"createNew": true
					};
				},

				/**
				 * ########## ####### ######### ########## ### ######## ############ ### ########### ############ ######.
				 * @protected
				 * @virtual
				 * @return {Object} ########## ########## ## ############.
				 */
				onGetForecastCopyInfo: function() {
					return {
						"copyItem": true,
						"forecastId": this.get("ActiveTabName")
					};
				},

				/**
				 * ########## ####### ######### ########## ### ######## ############.
				 * @protected
				 * @virtual
				 * @return {Object} ########## ########## ## ############.
				 */
				onGetForecastInfo: function() {
					return {
						"forecastId": this.get("ActiveTabName")
					};
				},

				/**
				 * ########## ############ ######## ############ ### ########## ###### ############.
				 * @protected
				 * @virtual
				 * @return {String} ########## ############ ######## ############.
				 */
				getAddForecastModuleId: function() {
					return this.sandbox.id + "_Forecast_Add";
				},

				/**
				 * ########## ############ ######## ############ ### ########### ############# ############.
				 * @protected
				 * @virtual
				 * @return {String} ########## ############ ######### #####.
				 */
				getCopyForecastModuleId: function() {
					return this.sandbox.id + "_Forecast_Copy";
				},

				/**
				 * ########## ############ ###### ############ ### ##############
				 * @protected
				 * @virtual
				 * @return {String} ########## ############ ######## ############.
				 */
				getEditForecastModuleId: function() {
					return this.sandbox.id + "_Forecast_Edit";
				},

				/**
				 * ######### ######## ############.
				 * @protected
				 * @virtual
				 * @param {string} moduleId ########### ############# ######.
				 * @param {string} operation ######## ###### # ####### (CardStateV2).
				 */
				openForecastPage: function(moduleId, operation) {
					MaskHelper.ShowBodyMask();
					var historyState = this.sandbox.publish("GetHistoryState");
					var forecastId = this.get("ActiveTabName");
					var valuePairs = [
						{
							name: "EntitySchemaUId",
							value: "ae46fb87-c02c-4ae8-ad31-a923cdd994cf"
						},
						{
							name: "EntitySchemaName",
							value: "Opportunity"
						}
					];
					if (operation === ConfigurationEnums.CardStateV2.COPY) {
						var forecastNameCopy = this.get("Forecasts").find(forecastId).get("Name") +
								" - " + this.get("Resources.Strings.CopySuffix");
						valuePairs.push({
							name: "Name",
							value: forecastNameCopy
						});
					}
					var config = {
						hash: historyState.hash.historyState,
						silent: true,
						stateObj: {
							isSeparateMode: true,
							schemaName: "ForecastPage",
							entitySchemaName: "Forecast",
							operation: operation,
							primaryColumnValue: forecastId,
							valuePairs: valuePairs,
							isSilent: true
						}
					};
					this.sandbox.publish("PushHistoryState", config);
					this.sandbox.loadModule("CardModuleV2", {
						renderTo: this.renderTo,
						id: moduleId || this.getForecastModuleId(),
						keepAlive: true
					});
				},

				/**
				 * ######### ##### ## ####### ############ ############# ############.
				 * @protected
				 * @virtual
				 * @return {Boolean} ########## true #### ##### # false # ######## ######.
				 */
				canEdit: function() {
					var rightLevel = this.get("ForecastRightLevel");
					return this.isSchemaCanEditRightConverter(rightLevel) && this.get("ActiveTabName");
				},

				/**
				 * ######### ##### ## ####### ############ ########## ############.
				 * @protected
				 * @virtual
				 * @return {Boolean} ########## true #### ##### # false # ######## ######.
				 */
				canCopy: function() {
					var rightLevel = this.get("ForecastRightLevel");
					return this.isSchemaCanAppendRightConverter(rightLevel) && this.get("ActiveTabName");
				},

				/**
				 * ######### ##### ## ####### ############ ####### ############.
				 * @protected
				 * @virtual
				 * @return {Boolean} ########## true #### ##### # false # ######## ######.
				 */
				canDelete: function() {
					var rightLevel = this.get("ForecastRightLevel");
					return this.isSchemaCanDeleteRightConverter(rightLevel) && this.get("ActiveTabName");
				},

				/**
				 * ######### ###### ## ########## #########.
				 * @protected
				 * @virtual
				 * @param {BPMSoft.Collection} value #########.
				 * @return {Boolean} ########## true #### ###### # false # ######## ######.
				 */
				isCollectionEmptyConverter: function(value) {
					return !value || value.isEmpty();
				},

				/**
				 * ########## ######## ########## ########. ############ ### ########## # ######### ## ########.
				 * @param {boolean} value ########.
				 * @return {boolean} ######## ########.
				 */
				invertBooleanValue: function(value) {
					return !value;
				},

				/**
				 * ######### ##### ## ######## ### ####### ######.
				 * @protected
				 * @virtual
				 * @param {String} operation ########.
				 * @return {Boolean} ########## true #### #### #####, false # ######## ######.
				 */
				checkRecordOperationRights: function(operation) {
					var rights = this.get("CurrentRecordRightLevel");
					var result =
							(operation === BPMSoft.RightsEnums.operationTypes.read &&
							this.isSchemaRecordCanReadRightConverter(rights)) ||
							(operation === BPMSoft.RightsEnums.operationTypes.edit &&
							this.isSchemaRecordCanEditRightConverter(rights)) ||
							(operation === BPMSoft.RightsEnums.operationTypes["delete"] &&
							this.isSchemaRecordCanDeleteRightConverter(rights));
					if (!result) {
						BPMSoft.utils.showInformation(this.get("Resources.Strings.NotEnoughRightsMessage"));
					}
					return result;
				},

				/**
				 * #########, ##### ## ####### ############ ################ ##### ####### ######.
				 * @protected
				 * @virtual
				 * @return {Boolean} ########## true #### #### #####, false # ######## ######.
				 */
				canManageRights: function() {
					var currentRecordRightLevel = this.get("CurrentRecordRightLevel");
					return this.isSchemaRecordCanChangeReadRightConverter(currentRecordRightLevel) ||
							this.isSchemaRecordCanChangeEditRightConverter(currentRecordRightLevel) ||
							this.isSchemaRecordCanChangeDeleteRightConverter(currentRecordRightLevel);
				},

				/**
				 * #########, ##### ## ####### ############ ####### ### ######## ######## ############.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ########.
				 * @protected
				 */
				canDeleteForecastItems: function(callback, scope) {
					var forecastId = this.get("ActiveTabName");
					var dataSend = {
						forecastId: forecastId
					};
					var config = {
						serviceName: "ForecastService",
						methodName: "GetCanDeleteForecastItems",
						data: dataSend,
						callback: callback,
						scope: scope
					};
					ServiceHelper.callService(config);
				},

				/**
				 * ######### ######## ############## ######## ############.
				 * @protected
				 * @virtual
				 */
				editCurrentForecast: function() {
					if (!this.checkRecordOperationRights(BPMSoft.RightsEnums.operationTypes.edit)) {
						return;
					}
					this.openForecastPage(this.getEditForecastModuleId(), ConfigurationEnums.CardStateV2.EDIT);
				},

				/**
				 * ######### ########### ######## ############.
				 * @protected
				 * @virtual
				 */
				copyCurrentForecast: function() {
					this.openForecastPage(this.getCopyForecastModuleId(), ConfigurationEnums.CardStateV2.COPY);
				},

				/**
				 * ######### ######## ########## ############.
				 * @protected
				 * @virtual
				 */
				addForecast: function() {
					this.openForecastPage(this.getAddForecastModuleId(), ConfigurationEnums.CardStateV2.ADD);
				},

				/**
				 * ####### ####### ############.
				 * @protected
				 * @virtual
				 */
				deleteCurrentForecast: function() {
					if (!this.checkRecordOperationRights(BPMSoft.RightsEnums.operationTypes["delete"])) {
						return;
					}
					this.canDeleteForecastItems(function(result) {
						var resultMessage = result.GetCanDeleteForecastItemsResult;
						if (resultMessage) {
							BPMSoft.utils.showConfirmation(resources.localizableStrings[resultMessage], function() {
							}, [
								BPMSoft.MessageBoxButtons.OK.returnCode
							], this, {
								style: BPMSoft.MessageBoxStyles.ORANGE
							});
						} else {
							BPMSoft.utils.showConfirmation(this.get("Resources.Strings.DeleteConfirmationMessage"),
									function(returnCode) {
										if (returnCode === BPMSoft.MessageBoxButtons.YES.returnCode) {
											this.onDeleteAccept();
										}
									},
									[this.BPMSoft.MessageBoxButtons.NO.returnCode,
										this.BPMSoft.MessageBoxButtons.YES.returnCode],
									this
							);
						}
					}, this);
				},

				/**
				 * ######### ######## ############## ## ######## ############.
				 * @protected
				 * @virtual
				 */
				onDeleteAccept: function() {
					var forecastId = this.get("ActiveTabName");
					var batchQuery = this.Ext.create("BPMSoft.BatchQuery");
					var deleteForecastItemsQuery = Ext.create("BPMSoft.DeleteQuery", {
						rootSchemaName: "ForecastItem"
					});
					deleteForecastItemsQuery.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Forecast", forecastId));
					batchQuery.add(deleteForecastItemsQuery);
					var deleteForecastQuery = Ext.create("BPMSoft.DeleteQuery", {
						rootSchemaName: "Forecast"
					});
					deleteForecastQuery.enablePrimaryColumnFilter(forecastId);
					batchQuery.add(deleteForecastQuery);
					batchQuery.execute(function(response) {
						if (response.success) {
							this.removeTab(forecastId);
							this.set("ActiveTabName", null);
							var forecasts = this.get("Forecasts");
							var item = forecasts.find(forecastId);
							if (item) {
								forecasts.remove(item);
							}
							this.initTabs();
						}
					}, this);
				},

				/**
				 * ######### ######## ######### #### ######## ############.
				 * @protected
				 * @virtual
				 */
				manageCurrentForecastRights: function() {
					this.openRightsModule();
				},

				/**
				 * ########## ############# ### ###### ######## ############.
				 * @protected
				 * @virtual
				 * @return {String} ########## ############# ### ###### ####.
				 */
				getRightsModuleId: function() {
					return this.sandbox.id + "_Rights";
				},

				/**
				 * ######### ######## ######### ####.
				 * @protected
				 * @virtual
				 */
				openRightsModule: function() {
					MaskHelper.ShowBodyMask();
					this.sandbox.loadModule("Rights", {
						renderTo: "centerPanel",
						id: this.getRightsModuleId(),
						keepAlive: true
					});
				},

				/**
				 * Returns default image url.
				 * @return {String} Default image url.
				 */
				getDefaultImageURL: function() {
					return BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.EmptyInfoImage);
				},

				/**
				 * ############# ## ######### ############ ######.
				 * @protected
				 * @virtual
				 */
				subscribeSandboxMessages: function() {
					this.subscribeForecastMessage();
					var rightsModuleId = this.getRightsModuleId();
					this.sandbox.subscribe("GetRecordInfo", function() {
						var forecasts = this.get("Forecasts");
						var forecastId = this.get("ActiveTabName");
						var forecastName = forecasts.get(forecastId).get("Name");
						return {
							entitySchemaName: "Forecast",
							entitySchemaCaption: this.get("Resources.Strings.Caption"),
							primaryColumnValue: forecastId,
							primaryDisplayColumnValue: forecastName
						};
					}, this, [rightsModuleId]);
				},

				/**
				 * ############## ######### ######## ######.
				 * @protected
				 * @virtual
				 */
				init: function(callback, scope) {
					BPMSoft.chain(
							this.getActiveTabNameFromProfile,
							function() {
								this.initData();
								this.subscribeSandboxMessages();
								this.initHeader();
								this.initTabs();
								RightUtilities.getSchemaOperationRightLevel("Forecast", function(rightLevel) {
									this.set("ForecastRightLevel", rightLevel);
									callback.call(scope || this);
								}, this);
							},
							this
					);
				},

				/**
				 * ######### ########### ######## ##### ############ #############.
				 * @protected
				 * @virtual
				 */
				onRender: function() {
					MaskHelper.HideBodyMask();
					if (this.get("Restored")) {
						this.initHeader();
					}
					this.loadForecastModule();
				}
			});

			/**
			 * @class BPMSoft.configuration.ForecastBuilder
			 * ##### ############### # #### ###### ######### ############# # ###### ###### ############# ### ###### ############.
			 */
			return Ext.define("BPMSoft.configuration.ForecastBuilder", {
				extend: "BPMSoft.BaseObject",
				alternateClassName: "BPMSoft.ForecastBuilder",

				/**
				 * ### ####### ###### ############# ### ###### ############.
				 * @type {String}
				 */
				viewModelClass: "BPMSoft.BaseForecastsViewModel",

				/**
				 * ### ######## ##### ########## ############ ############# ############.
				 * @type {String}
				 */
				viewConfigClass: "BPMSoft.ForecastViewConfig",

				/**
				 * ### ##### ########## #############.
				 * @type {String}
				 */
				viewGeneratorClass: "BPMSoft.ViewGenerator",

				/**
				 * ############ ##########.
				 * @type {Object}
				 */
				generatorConfig: null,

				/**
				 * ######### ######### ############ ## ####, ############### ## ########
				 * @protected
				 * @virtual
				 * @param {Function} callback ####### ######### ######.
				 * @param {BPMSoft.BaseModel} scope ######## ########## ####### ######### ######.
				 * @return {BPMSoft.Collection} ########## ######### ############.
				 */
				requireForecasts: function(callback, scope) {
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Forecast"
					});
					esq.addColumn("Id");
					var nameColumn = esq.addColumn("Name");
					nameColumn.orderPosition = 1;
					nameColumn.orderDirection = BPMSoft.OrderDirection.ASC;
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							callback.call(scope, response.collection);
						}
					}, this);
				},

				/**
				 * ####### ######### ###### BPMSoft.ViewGenerator.
				 * @return {BPMSoft.ViewGenerator} ########## ###### BPMSoft.ViewGenerator.
				 */
				createViewGenerator: function() {
					return Ext.create(this.viewGeneratorClass);
				},

				/**
				 * ####### ##### ###### ############# ### ###### ############.
				 * @protected
				 * @virtual
				 * @param {Object} config ###### ############.
				 * @param {Function} callback ####### ######### ######.
				 * @param {BPMSoft.BaseModel} scope ######## ########## ####### ######### ######.
				 * @return {BPMSoft.BaseModel} ########## ##### ###### ############# ### ###### ############.
				 */
				buildViewModel: function(config, callback, scope) {
					var viewModelColumns = {
						"Forecasts": {
							dataValueType: BPMSoft.DataValueType.COLLECTION,
							type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
							value: config.forecasts
						}
					};
					var viewModelClass = Ext.define("BPMSoft.configuration.ForecastViewModel", {
						extend: this.viewModelClass,
						alternateClassName: "BPMSoft.ForecastViewModel",
						columns: viewModelColumns
					});
					callback.call(scope, viewModelClass);
				},

				/**
				 * ####### ############ ############# ###### ############.
				 * @protected
				 * @virtual
				 * @param {Object} config ###### ############.
				 * @param {BPMSoft.Collection} config.forecasts ######### ############.
				 * @param {Function} callback ####### ######### ######.
				 * @param {BPMSoft.BaseModel} scope ######## ########## ####### ######### ######.
				 * @return {Object[]} ########## ############ ############# ###### ############.
				 */
				buildView: function(config, callback, scope) {
					if (Ext.isFunction(config)) {
						scope = callback;
						callback = config;
						config = this.generatorConfig;
					} else {
						Ext.apply(config, this.generatorConfig);
					}
					var viewGenerator = this.createViewGenerator();
					var viewClass = Ext.create(this.viewConfigClass);
					var schema = {
						viewConfig: viewClass.generate(config.forecasts)
					};
					var viewConfig = Ext.apply({
						schema: schema
					}, config);
					viewGenerator.generate(viewConfig, function(viewConfig) {
						callback.call(scope, viewConfig);
						viewGenerator.destroy();
						viewGenerator = null;
					});
				},

				/**
				 * ########## ###### # ###### ############# ### ###### ############.
				 * @param {Object} config ############ ###### #####.
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ########## ####### ######### ######.
				 */
				build: function(config, callback, scope) {
					var defaultConfig = {};
					var generatorConfig = this.generatorConfig = Ext.apply({}, config, defaultConfig);
					this.requireForecasts(function(forecastEntityCollection) {
						generatorConfig.forecasts = forecastEntityCollection;
						this.buildViewModel(generatorConfig, function(viewModelClass) {
							generatorConfig.viewModelClass = viewModelClass;
							this.buildView(generatorConfig, function(view) {
								callback.call(scope, viewModelClass, view);
							}, this);
						}, this);
					}, this);
				},

				/**
				 * ####### ######### #########.
				 * @overridden
				 */
				destroy: function() {
					this.generatorConfig = null;
					this.callParent(arguments);
				}
			});
		});
