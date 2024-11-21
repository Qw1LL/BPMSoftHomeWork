define("SysLogoSettingsModule", ["SysLogoSettingsModuleResources", "MaskHelper", "SecurityUtilities", "BaseModule",
		"ContextHelpMixin", "SystemOperationsPermissionsMixin"],
	function(resources, maskHelper) {

		/**
		 * @class BPMSoft.SysLogoSettingsModule
		 * ##### ###### ############## ######### ######## ############# ######### ##########.
		 */
		return Ext.define("BPMSoft.configuration.SysLogoSettingsModule", {
			extend: "BPMSoft.BaseModule",
			alternateClassName: "BPMSoft.SysLogoSettingsModule",
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
			 * ####### ####, ### ###### ############### ##########.
			 * @private
			 * @type {Boolean}
			 */
			isAsync: true,

			/**
			 * ###### ####-########## ######### ########. ### ### ######## - ### ### ######### #########, # ######## -
			 * #### ########## (###, #########, ########).
			 * @private
			 * @type {Object}
			 */
			logoSysSettingsCfg: null,

			/**
			* @private
			* @type {Boolean}
			*/
			isCanExecute: false,

			/**
			 * ############# ######### # ######### ######## ######### ######## # ############# ########## ##########,
			 * ##### ####, ####### ###### ############# ######.
			 * @param {Function} callback #######, ####### ##### ####### ## ##########
			 * @param {Object} scope ########, # ####### ##### ####### ####### callback
			 * @virtual
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
					var logoSysSettingsNames = [
						"LogoImage",
						"MenuLogoImage",
						"HeaderLogoImage"
					];
					this.logoSysSettingsCfg = {};
					this.BPMSoft.SysSettings.querySysSettings(logoSysSettingsNames, function(sysSettings) {
						this.BPMSoft.each(sysSettings, function(sysSettingValue, sysSettingName) {
							this.logoSysSettingsCfg[sysSettingName] = {
								code: sysSettingName,
								value: sysSettingValue,
								caption: localizableStrings[sysSettingName + "Caption"] || sysSettingName
							};
						}, this);
						this.viewModel = this.createViewModel();
						callback.call(scope);
					}, this);
				});
			},

			/**
			 * ########## ######## ######## ###### ## ####### ###### #### # ############ ### ############# ####### ###
			 * ########
			 * @protected
			 * @virtual
			 * @return {String|null} ######## ########.
			 */
			getSecurityOperationName: function() {
				return "CanManageLogo";
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
			 * ####### ############# ######, ########## ### # ########## # ######### ######## ###### ############# #
			 * #############.
			 * @param {Ext.Element} renderTo #########, # ####### ########## ######.
			 */
			render: function(renderTo) {
				var view = this.generateView();
				view.bind(this.viewModel);
				view.render(renderTo);
				maskHelper.HideBodyMask();
			},

			/**
			 * ####### ###### ############# #######.
			 * @return {BPMSoft.BaseViewModel} ###### ############# ######.
			 */
			createViewModel: function() {
				var Ext = this.Ext;
				var BPMSoft = this.BPMSoft;
				var sandbox = this.sandbox;
				var columns = {};
				var columnValues = {};
				var localizableStrings = resources.localizableStrings;
				var logoSysSettingsCfg = this.logoSysSettingsCfg;
				var self = this;
				BPMSoft.each(logoSysSettingsCfg, function(logoSysSettingConfig) {
					var sysSettingCode = logoSysSettingConfig.code;
					var sysSettingValue = logoSysSettingConfig.value;
					columns[sysSettingCode] = {
						dataValueType: BPMSoft.DataValueType.BLOB
					};
					columnValues[sysSettingCode] = sysSettingValue;
					var defaultSysSettingValueColumnName = "default" + sysSettingCode;
					columns[defaultSysSettingValueColumnName] = {
						dataValueType: BPMSoft.DataValueType.BLOB
					};
					columnValues[defaultSysSettingValueColumnName] = sysSettingValue;
					var sysSettingValueSysImageIdColumnName = sysSettingCode + "_sysImageId";
					columns[sysSettingValueSysImageIdColumnName] = {
						dataValueType: BPMSoft.DataValueType.TEXT
					};
					columnValues[sysSettingValueSysImageIdColumnName] = null;
				}, this);
				columns.MarkerValue = {
					dataValueType: BPMSoft.DataValueType.TEXT
				};
				columnValues.MarkerValue = "sys-logo-settings";
				return Ext.create("BPMSoft.BaseViewModel", {
					columns: columns,
					values: columnValues,
					validationConfig: {},
					methods: {

						/**
						 * ########## ####### ####, ############# ## ###### ########## ######### ########.
						 * @return {Boolean}
						 */
						getSaveButtonVisible: function() {
							var changedSysSettings = this.getChangedSysSettings();
							var changedSysSettingsNames = BPMSoft.keys(changedSysSettings);
							return (changedSysSettingsNames.length > 0);
						},

						/**
						 * ########## ####### ######### ###### "#######".
						 * @return {Boolean}
						 */
						getCloseButtonVisible: function() {
							var changedSysSettings = this.getChangedSysSettings();
							var changedSysSettingsNames = BPMSoft.keys(changedSysSettings);
							return changedSysSettingsNames.length === 0;
						},

						/**
						 * ########## ###### # ########### ######### ###########. ### ######## ####### -
						 * ### ######### #########, # ######## ######## - ##### ######## #########. #### ########
						 * ######### ######### ## ########, # ####### ## ##### ################ ########.
						 * @return {Object}
						 */
						getChangedSysSettings: function() {
							var changedSysSettings = {};
							BPMSoft.each(logoSysSettingsCfg, function(logoSysSettingConfig) {
								var sysSettingCode = logoSysSettingConfig.code;
								var value = this.get(sysSettingCode);
								var defValue = this.get("default" + sysSettingCode);
								if (value !== defValue) {
									changedSysSettings[sysSettingCode] = value;
								}
							}, this);
							return changedSysSettings;
						},

						/**
						 * ########## ####### ## ###### ########## ######### ######### ########. ########## ######
						 * ## ###### ### ########## ######### ########. #### ###### ## #### ########## ######,
						 * ##### ########## ############### #########.
						 */
						onSaveClick: function() {
							if (isCanExecute === true) {
								this.set("MarkerValue", "saving");
								var postData = {
									sysSettingsValues: this.getChangedSysSettings()
								};
								BPMSoft.SysSettings.postSysSettingsValues(postData, function (result) {
									if (!result.success) {
										this.showInformationDialog(localizableStrings.ServerErrorMessage, Ext.emptyFn);
										return;
									}
									this.onSysSettingsSaved(result.saveResult);
								}, this);
							}
							else
								self.showPermissionsErrorMessage(self.getSecurityOperationName());
						},

						/**
						 * ########## ###### ####### ## ###### ########### ######### ########. #### ########## ######
						 * ######, ############ ########### ############### ######### # ##### ######## #######
						 * ## ########## ########, ##### ########## ######### # ########### # ############# #########.
						 * @param {Object} saveResult ######### ###### ####### ## ###### ########## ######.
						 */
						onSysSettingsSaved: function(saveResult) {
							var saveErrors = [];
							BPMSoft.each(saveResult, function(saveResult, sysSettingCode) {
								if (saveResult !== true) {
									saveErrors.push(sysSettingCode);
								}
							}, this);
							if (saveErrors.length !== 0) {
								this.set("MarkerValue", "sys-logo-settings");
								var sysSettingsCaptions = [""];
								BPMSoft.each(saveErrors, function(sysSettingCode) {
									sysSettingsCaptions.push(logoSysSettingsCfg[sysSettingCode].caption);
								}, this);
								var saveErrorMessage = localizableStrings.SaveErrorMessage.replace(/\\n/g, "\n");
								var errorMessage = BPMSoft.getFormattedString(saveErrorMessage,
									sysSettingsCaptions.join("\n- "));
								this.showInformationDialog(errorMessage, Ext.emptyFn);
							} else {
								window.location.reload();
							}
						},

						/**
						 * ############### ######## ######### ######## # ######### ## #########, ## ## ##### ##########.
						 */
						restoreInitialLogoSysSettings: function() {
							BPMSoft.each(logoSysSettingsCfg, function(logoSysSettingConfig) {
								var sysSettingCode = logoSysSettingConfig.code;
								var value = this.get(sysSettingCode);
								var initValue = this.get("default" + sysSettingCode);
								if (value !== initValue) {
									this.updateSysSettingValue({
										code: sysSettingCode,
										value: initValue,
										imageId: null
									});
								}
							}, this);
						},

						/**
						 * ########## ####### ####### ## ###### "######".
						 */
						onCancelClick: function() {
							this.restoreInitialLogoSysSettings();
						},

						/**
						 * ########## ####### ## ###### ######. ######### ####### ## ########## ########.
						 */
						onCloseClick: function() {
							sandbox.publish("BackHistoryState");
						},

						/**
						 * ########## Url # ####### data-url, ### ########### ######## ######## ###########
						 * ######### ######## ############# #########.
						 * @param {String} sysSettingCode ### ######### #########.
						 * @return {String} Url # ####### data-url.
						 */
						getImageSrc: function(sysSettingCode) {
							return this.getSysSettingImageSrc({
								code: sysSettingCode,
								value: this.get(sysSettingCode),
								sysImageId: this.get(sysSettingCode + "_sysImageId")
							});
						},

						/**
						 * @member BPMSoft
						 * @inheritdoc BPMSoft.SysLogoSettingsModule.getSysSettingUrlValue
						 */
						getSysSettingImageSrc: this.getSysSettingUrlValue,

						/**
						 * ########## ####### ######### ######## ######### #########.
						 * @param {File} file #### # ############, ####### ### ###### #############.
						 * @param {String} sysSettingCode ### ######### #########.
						 */
						onImageChange: function(file, sysSettingCode) {
							if (file) {
								var self = this;
								FileAPI.readAsBinaryString(file, function(e) {
									var eventType = e.type;
									if (eventType === "load") {
										self.onBinaryStringRead(sysSettingCode, file, e.result);
									} else if (eventType === "error") {
										throw new BPMSoft.UnknownException({
											message: e.error
										});
									}
								});
							} else {
								this.updateSysSettingValue({
									code: sysSettingCode,
									value: this.get("default" + sysSettingCode),
									imageId: null
								});
							}
						},

						/**
						 * ########## ####### ###### ##### # ######## ######. ##### ######### ######## ###### #
						 * ###### base64 # ######### ######## # ###### #############. ### IE, ############# ###########
						 * ######## ########### ##### ## ###### # ####### SysImage.
						 * @param {String} sysSettingCode ### ######### #########.
						 * @param {File} imageFile ########### #### # ############.
						 * @param {String} binaryString ###### # ############ ######### ####### #####.
						 */
						onBinaryStringRead: function(sysSettingCode, imageFile, binaryString) {
							var sysSettingValue = btoa(binaryString);
							if (Ext.isIE) {
								BPMSoft.ImageApi.upload({
									onComplete: this.onFileUpload.bind(this, sysSettingCode, sysSettingValue),
									onError: function(imageId, error) {
										if (error) {
											throw new BPMSoft.UnknownException({
												message: error
											});
										}
									},
									scope: this,
									file: imageFile
								});
							} else {
								this.set(sysSettingCode, sysSettingValue);
							}
						},

						/**
						 * ########## ####### ######## ##### ## ###### # ####### SysImage. ##### ######### #####
						 * ######## # ###### #############.
						 * @param {String} sysSettingCode ### ######### #########.
						 * @param {String} sysSettingValue ######## ######### ######### # ####### base64.
						 * @param {String} imageId ############# ###### # ########### ############ # ####### SysImage.
						 */
						onFileUpload: function(sysSettingCode, sysSettingValue, imageId) {
							this.updateSysSettingValue({
								code: sysSettingCode,
								value: sysSettingValue,
								imageId: imageId
							});
						},

						/**
						 * ##### ######### ###### ######### ######### # ###### #############.
						 * @param {Object} sysSettingConfig ############ ######### #########.
						 * @param {String} sysSettingConfig.code ### ######### #########.
						 * @param {String} sysSettingConfig.value ######## ######### #########.
						 * @param {String} sysSettingConfig.imageId ############# ###### # ########### ############
						 * # ####### SysImage.
						 */
						updateSysSettingValue: function(sysSettingConfig) {
							var sysSettingCode = sysSettingConfig.code;
							this.set(sysSettingCode + "_sysImageId", sysSettingConfig.imageId, {
								silent: true
							});
							this.set(sysSettingCode, sysSettingConfig.value);
						}

					}
				});
			},

			/**
			 * ########## URL-##### ### ######## ## ########## ############. URL ########### # ####### data-url
			 * ### #### ######### ##### IE. ### IE ########### ####### URL ## ######## ############ # #######
			 * ######## ######### ########. #### ####### ######## imageId, URL ######### ## ######## ###########
			 * # ####### SysImage.
			 * @param {Object} sysSettingConfig ################ ###### ############# ########.
			 * @param {String} sysSettingConfig.code ### ######### #########.
			 * @param {String} sysSettingConfig.value ######## ######### ########.
			 * @param {String} sysSettingConfig.sysImageId ############# ###### # ####### SysImage. ###### ### IE.
			 * @return {String} URL ########.
			 */
			getSysSettingUrlValue: function(sysSettingConfig) {
				var urlBuilderConfig;
				if (Ext.isIE) {
					var sysImageId = sysSettingConfig.sysImageId;
					if (sysImageId) {
						urlBuilderConfig = {
							source: BPMSoft.ImageSources.SYS_IMAGE,
							params: {
								primaryColumnValue: sysImageId
							}
						};
					} else {
						urlBuilderConfig = {
							source: BPMSoft.ImageSources.SYS_SETTING,
							params: {
								r: sysSettingConfig.code
							}
						};
					}
				} else {
					const imageDataUrl = BPMSoft.ImageUrlBuilder.getDataUrlByBase64(sysSettingConfig.value);
					urlBuilderConfig = {
						source: BPMSoft.ImageSources.URL,
						url: imageDataUrl
					};
				}
				return BPMSoft.ImageUrlBuilder.getUrl(urlBuilderConfig);
			},

			/**
			 * ########## ############# ######
			 * @return {BPMSoft.Container} ############# ######.
			 */
			generateView: function() {
				var Ext = this.Ext;
				var logoSettingsViewConfig = this.generateLogoSettingsViewConfig();
				var localizableStrings = resources.localizableStrings;
				return Ext.create("BPMSoft.Container", {
					id: "sys-logo-settings",
					classes: {
						wrapClassName: ["sys-logo-settings"]
					},
					markerValue: {"bindTo": "MarkerValue"},
					items: [
						{
							className: "BPMSoft.Container",
							id: "buttons-container",
							items: [
								{
									className: "BPMSoft.Button",
									id: "save-button",
									markerValue: "save-button",
									caption: localizableStrings.SaveButtonCaption,
									style: BPMSoft.controls.ButtonEnums.style.ORANGE,
									click: {
										bindTo: "onSaveClick"
									},
									classes: {
										textClass: ["save-button"]
									},
									visible: {
										bindTo: "getSaveButtonVisible"
									}
								},
								{
									className: "BPMSoft.Button",
									id: "cancel-button",
									markerValue: "cancel-button",
									caption: localizableStrings.CancelButtonCaption,
									click: {
										bindTo: "onCancelClick"
									},
									visible: {
										bindTo: "getSaveButtonVisible"
									}
								},
								{
									className: "BPMSoft.Button",
									id: "close-button",
									markerValue: "close-button",
									caption: localizableStrings.CloseButtonCaption,
									style: BPMSoft.controls.ButtonEnums.style.ORANGE,
									click: {
										bindTo: "onCloseClick"
									},
									visible: {
										bindTo: "getCloseButtonVisible"
									}
								}
							]
						},
						logoSettingsViewConfig
					]
				});
			},

			/**
			 * ########## ############# ### ####### ############## ######### ######## ############# #########.
			 * @return {Object} ################ ###### ####### ############## ######### ########.
			 */
			generateLogoSettingsViewConfig: function() {
				var logoSysSettingsCfg = this.logoSysSettingsCfg;
				var gridLayoutItemsConfig = [];
				var labelColumn = 0;
				var row = 0;
				var rowSpan = 3;
				var imageEditColumn = 2;
				var imageEditColumnSpan = 22;
				var labelColumnSpan = imageEditColumn;
				this.BPMSoft.each(logoSysSettingsCfg, function(sysSettingConfig) {
					gridLayoutItemsConfig.push({
						column: labelColumn,
						row: row,
						colSpan: labelColumnSpan,
						rowSpan: rowSpan,
						item: this.getLabelViewConfig(sysSettingConfig)
					});
					gridLayoutItemsConfig.push({
						column: imageEditColumn,
						row: row,
						colSpan: imageEditColumnSpan,
						rowSpan: rowSpan,
						item: this.getImageEditViewConfig(sysSettingConfig)
					});
					row += rowSpan + 1;
				}, this);
				return {
					className: "BPMSoft.GridLayout",
					id: "sys-logo-settings-content",
					items: gridLayoutItemsConfig
				};
			},

			/**
			 * ########## ############# ### ######## ########## BPMSoft.Label, ### ######### ######### #########.
			 * @param {Object} sysSettingConfig ####-########## ######### ########.
			 * @return {Object} ################ ###### ######## ########## BPMSoft.Label.
			 */
			getLabelViewConfig: function(sysSettingConfig) {
				var sysSettingCode = sysSettingConfig.code;
				return {
					className: "BPMSoft.Container",
					id: sysSettingConfig.code + "-label-wrap",
					classes: {
						wrapClassName: ["logo-label-wrap"]
					},
					items: [
						{
							className: "BPMSoft.Label",
							id: sysSettingCode + "-label",
							caption: sysSettingConfig.caption
						}
					]
				};
			},

			/**
			 * ########## ############# ### ######## ########## BPMSoft.ImageEdit,
			 * ### ############## ######### #########.
			 * @param {Object} sysSettingConfig ####-########## ######### ########.
			 * @return {Object} ################ ###### ######## ########## BPMSoft.ImageEdit.
			 */
			getImageEditViewConfig: function(sysSettingConfig) {
				var sysSettingCode = sysSettingConfig.code;
				var imageUrl = this.getSysSettingUrlValue({
					code: sysSettingCode,
					value: sysSettingConfig.value
				});
				return {
					className: "BPMSoft.Container",
					id: sysSettingCode + "-img-wrap",
					items: [
						{
							className: "BPMSoft.ImageEdit",
							id: sysSettingCode + "-img",
							markerValue: sysSettingCode,
							defaultImageSrc: imageUrl,
							tag: sysSettingCode,
							imageSrc: {
								bindTo: "getImageSrc"
							},
							change: {
								bindTo: "onImageChange"
							},
							width: "auto",
							height: "100%"
						}
					]
				};
			},

			/**
			 * ######## ######### ####### # ####### #########, #### ### ############# ###### ########## ## ########.
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
			 * ############## ##### ######### ########.
			 * @protected
			 * @virtual
			 * @return {Object} ########## ##### ######### ########.
			 */
			prepareHistoryState: function(currentState) {
				var newState = this.BPMSoft.deepClone(currentState);
				newState.moduleId = this.sandbox.id;
				return newState;
			},

			/**
			 * ####### ### ######## ## ####### # ########## ######.
			 * @overridden
			 * @param {Object} config ######### ########### ######.
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
	}
);
