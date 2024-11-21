define("SysSectionPanelSettingsModule", ["SysSectionPanelSettingsModuleResources", "MaskHelper",
		"SecurityUtilities", "BaseModule", "ContextHelpMixin", "SystemOperationsPermissionsMixin"],
	function(resources, MaskHelper) {
		return Ext.define("BPMSoft.configuration.SysSectionPanelSettingsModule", {
			extend: "BPMSoft.BaseModule",
			alternateClassName: "BPMSoft.SysSectionPanelSettingsModule",
			mixins: {
				SecurityUtilitiesMixin: "BPMSoft.SecurityUtilitiesMixin",
				SystemOperationsPermissionsMixin: "BPMSoft.SystemOperationsPermissionsMixin",

				/**
				 * @class ContextHelpMixin ######### ########### ###### # ####### ######## #######.
				 */
				ContextHelpMixin: "BPMSoft.ContextHelpMixin"
			},

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * #######-####### ######### ## #########.
			 * @protected
			 * @type {String}
			 */
			defaultKeyPrefix: "Default",

			/**
			 * ####### ####, ### ###### ############### ##########.
			 * @private
			 * @type {Boolean}
			 */
			isAsync: true,

			/**
			* @private
			* @type {Boolean}
			*/
			isCanExecute: false,

			/**
			 * ############# ######### # ######### ######## ######### ########, ####### ###### ############# ######.
			 * @virtual
			 * @param {Function} callback #######, ####### ##### ####### ## ##########.
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback.
			 */
			init: function(callback, scope) {
				this.callParent(arguments);
				this.checkAvailability(function() {
					var localizableStrings = resources.localizableStrings;
					var headerCaption = localizableStrings.HeaderCaption;
					this.sandbox.publish("ChangeHeaderCaption", {
						isMainMenu: false,
						caption: headerCaption,
						dataViews: this.Ext.create("BPMSoft.Collection")
					});
					this.sandbox.subscribe("NeedHeaderCaption", function() {
						this.sandbox.publish("InitDataViews", {
							isMainMenu: false,
							caption: headerCaption,
							dataViews: this.Ext.create("BPMSoft.Collection")
						});
					}, this);
					this.initHistoryState();
					this.initContextHelp();
					this.checkSchemaOperationAvailability(function(){}, this);
					this.initSysSettings({
						callback: callback,
						scope: scope
					});
				});
			},

			/**
			 * ###### ######### ######## ######### ######## ## #########.
			 * @protected
			 * @param {Object} options ##### ########## ########### {BPMSoft.BaseViewModel}.
			 * @param {Function} options.callback ####### ######### ###### ##### ######### ########## ########## ###########.
			 * @param {Object} options.scope ####### ######### ### ####### ######### ######.
			 */
			initSysSettings: function(options) {
				var callback = options.callback;
				var scope = options.scope;
				var settings = {};
				var columns = {
					SectionPanelBackgroundColor: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true
					},
					SectionPanelFontColor: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true
					},
					SectionPanelSelectedBackgroundColor: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true
					},
					SectionPanelSelectedFontColor: {
						dataValueType: BPMSoft.DataValueType.TEXT,
						isRequired: true
					}
				};
				this.settingColumns = columns;
				var settingNames = BPMSoft.keys(columns);
				var getSettings = function(sysSettings) {
					BPMSoft.each(sysSettings, function(value, key) {
						settings[key] = value;
					}, this);
					this.viewModel = this.createViewModel({values: settings, columns: columns});
					this.viewModel.on("change", this.onChange, this);
					callback.call(scope);
				};
				this.BPMSoft.SysSettings.querySysSettings(settingNames, getSettings, this);
			},

			/**
			 * Returns module viewmodel instance or null if module is not initialized.
			 * @return {BPMSoft.BaseViewModel|null}
			 */
			getViewModel: function() {
				return this.viewModel;
			},

			/**
			 * ####### #viewModel.
			 * @protected
			 * @param {Object} options ##### ### ######## {BPMSoft.BaseViewModel}.
			 * @param {Object} options.columns ####### ### {BPMSoft.BaseViewModel}.
			 * @param {Object} options.values ######### ########/######## ## ######### ### {BPMSoft.BaseViewModel}.
			 * @returns {BPMSoft.BaseViewModel}
			 */
			createViewModel: function(options) {
				var BPMSoft = this.BPMSoft;
				var sandbox = this.sandbox;
				var columns = options.columns;
				var self = this;
				columns.hasChanges = {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					isRequired: false
				};
				var values = options.values;
				values.hasChanges = false;
				return this.Ext.create("BPMSoft.BaseViewModel", {
					columns: columns,
					values: values,
					methods: {
						onSave: function() {
							self.saveSettingValues();
						},
						onClose: function() {
							self.discardSettingValues();
						},
						onCancel: function() {
							sandbox.publish("BackHistoryState");
						},
						onRestore: function() {
							MaskHelper.ShowBodyMask();
							var options = {
								callback: self.setValues,
								scope: self
							};
							self.getDefaultSettingValues(options);
						},

						/**
						 * ########## ######### ######## #########.
						 * @protected
						 * @deprecated Use {@link #BPMSoft.BaseModel.invertBooleanValue}.
						 * @param {Boolean} value ########.
						 * @return {Boolean} ########## ######### ######## value.
						 */
						inverseValue: function(value) {
							return !value;
						}
					}
				});
			},

			/**
			 * ######### ##### ######## ######### ########.
			 * @protected
			 */
			saveSettingValues: function() {
				if (isCanExecute === true) {
					MaskHelper.ShowBodyMask();
					var localizableStrings = resources.localizableStrings;
					var viewModel = this.viewModel;
					var newSettingValues = BPMSoft.deepClone(viewModel.model.attributes);
					var saveCallback = function(result) {
						MaskHelper.HideBodyMask();
						if (!result.success) {
							this.showInformationDialog(localizableStrings.ErrorOnSave, Ext.emptyFn);
							return;
						}
						viewModel.values = BPMSoft.deepClone(viewModel.model.attributes);
						viewModel.model.set("hasChanges", false);
						var lessConstants = BPMSoft.Resources.LessConstants;
						lessConstants.SectionPanelBackgroundColor = viewModel.get("SectionPanelBackgroundColor");
						lessConstants.SectionPanelFontColor = viewModel.get("SectionPanelFontColor");
						lessConstants.SectionPanelSelectedBackgroundColor =
							viewModel.get("SectionPanelSelectedBackgroundColor");
						lessConstants.SectionPanelSelectedFontColor = viewModel.get("SectionPanelSelectedFontColor");
						BPMSoft.controls.SideBar.generateStyleSheet();
					};
					var postData = {
						sysSettingsValues: newSettingValues
					};
					this.BPMSoft.SysSettings.updateSysSettingsValue(postData, saveCallback, this);
				}
				else
					this.showPermissionsErrorMessage(this.getSecurityOperationName());
			},

			/**
			 * ############# ######## ### ########## ########## ########.
			 * @protected
			 */
			reloadPage: function() {
				window.location.reload();
			},

			/**
			 * ######### ####### ######### # ######### ######### ########.
			 * @protected
			 * @param {BPMSoft.BaseViewModel} viewModel ###### #############.
			 */
			onChange: function(viewModel) {
				var defaultSettingValues = BPMSoft.deepClone(viewModel.values);
				delete defaultSettingValues.hasChanges;
				var newSettingValues = BPMSoft.deepClone(viewModel.model.attributes);
				delete newSettingValues.hasChanges;
				var settingsChanged = Ext.Object.equals(defaultSettingValues, newSettingValues);
				viewModel.set("hasChanges", !(settingsChanged));
			},

			/**
			 * ########## ######## ########.
			 * @protected
			 */
			discardSettingValues: function() {
				var viewModel = this.viewModel;
				var initValues = BPMSoft.deepClone(viewModel.values);
				viewModel.set(initValues);
			},

			/**
			 * ########### ##### ######## BPMSoft.BaseViewModel.
			 * @protected
			 */
			setValues: function(newValues) {
				var viewModel = this.viewModel;
				viewModel.set(newValues);
				MaskHelper.HideBodyMask();
			},

			/**
			 * ######## ######## ## ######### ## ######### ########.
			 * @protected
			 * @param {Object} options
			 */
			getDefaultSettingValues: function(options) {
				var callback = options.callback;
				var scope = options.scope;
				var defaultSettings = {};
				var columns = this.settingColumns;
				var settingNames = BPMSoft.keys(columns);
				var updateSettingNames = function(item, index, list) {
					list[index] = this.defaultKeyPrefix + item;
				};
				BPMSoft.each(settingNames, updateSettingNames, this);
				var getSettings = function(sysSettings) {
					BPMSoft.each(sysSettings, function(value, key) {
						var settingKey = key.replace(this.defaultKeyPrefix, "");
						defaultSettings[settingKey] = value;
					}, this);
					callback.call(scope, defaultSettings);
				};
				this.BPMSoft.SysSettings.querySysSettings(settingNames, getSettings, scope);
			},

			/**
			 * ########## ############# ######
			 * @returns {BPMSoft.GridLayout} ############# ######.
			 */
			generateView: function() {
				var localizableStrings = resources.localizableStrings;
				return this.Ext.create("BPMSoft.GridLayout", {
					"id": "settings-section-panel",
					"markerValue": "sys-color-settings",
					"items": [
						{
							"item": {
								"className": "BPMSoft.Container",
								"id": "settings-section-buttons-container",
								"items": [
									{
										"className": "BPMSoft.Button",
										"id": "settings-section-panel-save",
										"markerValue": "save-button",
										"caption": localizableStrings.Save,
										"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
										"visible": {bindTo: "hasChanges"},
										"click": {bindTo: "onSave"}
									},
									{
										"className": "BPMSoft.Button",
										"id": "settings-section-panel-discard-changes",
										"markerValue": "cancel-button",
										"caption": localizableStrings.Cancel,
										"visible": {bindTo: "hasChanges"},
										"click": {bindTo: "onClose"}
									},
									{
										"className": "BPMSoft.Button",
										"id": "settings-section-panel-cancel",
										"markerValue": "close-button",
										"caption": localizableStrings.Close,
										"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
										"visible": {
											"bindTo": "hasChanges",
											"bindConfig": {"converter": "invertBooleanValue"}
										},
										"click": {bindTo: "onCancel"}
									},
									{
										"className": "BPMSoft.Button",
										"id": "settings-section-panel-restore-default",
										"markerValue": "restore-button",
										"caption": localizableStrings.Restore,
										"click": {bindTo: "onRestore"}
									}
								]
							},
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						{
							"item": {
								"className": "BPMSoft.Container",
								"id": "settings-section-panel-checkboxes-container",
								"items": [
									{
										"className": "BPMSoft.Container",
										"id": "settings-section-panel-first-checkbox",
										"items": [
											{
												"className": "BPMSoft.ColorButton",
												"id": "settings-section-panel-background-color-picker",
												"markerValue": "color-button",
												"value": {bindTo: "SectionPanelBackgroundColor"},
												"menuItemClassName": BPMSoft.MenuItemType.COLOR_PICKER
											},
											{
												"className": "BPMSoft.Label",
												"id": "settings-section-panel-background-color-label",
												"caption": localizableStrings.SectionPanelBackgroundColor,
												"classes": {}
											}
										]
									},
									{
										"className": "BPMSoft.Container",
										"id": "settings-section-panel-second-checkbox",
										"items": [
											{
												"className": "BPMSoft.ColorButton",
												"id": "settings-section-panel-font-color-picker",
												"markerValue": "color-button",
												"value": {bindTo: "SectionPanelFontColor"},
												"menuItemClassName": BPMSoft.MenuItemType.COLOR_PICKER
											},
											{
												"className": "BPMSoft.Label",
												"id": "settings-section-panel-font-color-label",
												"caption": localizableStrings.SectionPanelFontColor
											}
										]
									},
									{
										"className": "BPMSoft.Container",
										"id": "settings-section-panel-third-checkbox",
										"items": [
											{
												"className": "BPMSoft.ColorButton",
												"id": "settings-section-panel-selected-section-background-color-picker",
												"markerValue": "color-button",
												"value": {bindTo: "SectionPanelSelectedBackgroundColor"},
												"menuItemClassName": BPMSoft.MenuItemType.COLOR_PICKER
											},
											{
												"className": "BPMSoft.Label",
												"id": "settings-section-panel-selected-section-background-color-label",
												"caption": localizableStrings.SectionPanelSelectedBackgroundColor
											}
										]
									},
									{
										"className": "BPMSoft.Container",
										"id": "settings-section-panel-fourth-checkbox",
										"items": [
											{
												"className": "BPMSoft.ColorButton",
												"id": "settings-section-panel-selected-section-font-color-picker",
												"markerValue": "color-button",
												"value": {bindTo: "SectionPanelSelectedFontColor"},
												"menuItemClassName": BPMSoft.MenuItemType.COLOR_PICKER
											},
											{
												"className": "BPMSoft.Label",
												"id": "settings-section-panel-selected-section-font-color-label",
												"caption": localizableStrings.SectionPanelSelectedFontColor
											}
										]
									}
								]
							},
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						}]
					});
			},

			/**
			 * ######### ####### ########## ######.
			 */
			render: function(renderTo) {
				var view = this.generateView();
				view.bind(this.viewModel);
				view.render(renderTo);
				MaskHelper.HideBodyMask();
			},

			/**
			 * ######## ######### ####### # ####### #########, #### ### ############# ###### ########## ## ########
			 * @protected
			 * @virtual
			 */
			initHistoryState: function() {
				var sandbox = this.sandbox;
				var state = sandbox.publish("GetHistoryState");
				var currentHash = state.hash;
				var currentState = state.state || {};
				if (currentState.moduleId === sandbox.id) {
					return;
				}
				var newState = this.prepareHistoryState(currentState);
				sandbox.publish("ReplaceHistoryState", {
					stateObj: newState,
					pageTitle: null,
					hash: currentHash.historyState,
					silent: true
				});
			},

			/**
			 * ############## ##### ######### ########
			 * @protected
			 * @virtual
			 * @return {Object} ########## ##### ######### ########
			 */
			prepareHistoryState: function(currentState) {
				var newState = this.BPMSoft.deepClone(currentState);
				newState.moduleId = this.sandbox.id;
				return newState;
			},

			/**
			 * ########## ######## ######## ###### ## ####### ###### #### # ############ ### ############# ####### ###
			 * ########
			 * @protected
			 * @virtual
			 * @return {String|null} ######## ########.
			 */
			getSecurityOperationName: function() {
				return "CanManageSectionPanelColorSettings";
			},

			/**
			 * ############# ######### ######## ########### ########## ################ ########.
			 * @protected
			 * @virtual
			 * @param {String} operationName ### ################ ########.
			 * @param {Boolean} result ######### ######## ########### ########## ################ ########.
			 */
			setCanExecuteOperationResult: function(operationName, result) {
				if(this.getSecurityOperationName() !== operationName)
					return;

				isCanExecute = result;
			},

			/**
			 * ####### ### ######## ## ####### # ########## ######.
			 * @overridden
			 * @param {Object} config ######### ########### ######
			 */
			destroy: function(config) {
				if (config.keepAlive !== true) {
					if (this.viewModel) {
						this.viewModel.destroy();
						this.viewModel = null;
					}
					this.callParent(arguments);
				}
			}
		});
	});
