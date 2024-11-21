define("ColumnSettings", ["ColumnSettingsResources", "BaseSchemaModuleV2", "ColumnSettingsViewModel"],
	function(resources) {
		/**
		 * @class BPMSoft.configuration.ColumnSettings
		 * Class for setting up properties of the grid columns.
		 */
		Ext.define("BPMSoft.configuration.ColumnSettings", {
			alternateClassName: "BPMSoft.ColumnSettings",
			extend: "BPMSoft.BaseSchemaModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ###### ############# ###### ######### #######
			 * @private
			 * @type {Object}
			 */
			viewModel: null,

			/**
			 * ####, ####### ######### ################## ## #########
			 * @private
			 * @type {Boolean}
			 */
			isProviderInitialized: false,

			/**
			 * ####, ####### ######### ################### ## ### ######
			 * @private
			 * @type {Boolean}
			 */
			isInitialized: false,

			/**
			 * ######## ########
			 * @private
			 * @type {Object}
			 */
			filterManager: null,

			/**
			 * entitySchemaProvider
			 * @private
			 * @type {Object}
			 */
			entitySchemaProvider: null,

			/**
			 * ############ ##### ########
			 * @private
			 * @type {String}
			 */
			schemaName: "",

			/**
			 * ############ #######
			 * @private
			 * @type {Object}
			 */
			columnInfo: null,

			/**
			 * Is nested column settings tag. True when need render not in chain.
			 * @protected
			 * @type {Boolean}
			 */
			isNestedColumnSettingModule: false,

			/**
			 * Does previous page caption should be hidden.
			 * @private
			 * @type {Boolean}
			 */
			hidePageCaption: false,

			/**
			 * @private
			 */
			_columnTypeConfig: {
				titleType: {
					value: "title",
					displayValue: resources.localizableStrings.CaptionCaption
				},
				textType: {
					value: "text",
					displayValue: resources.localizableStrings.TextCaption
				},
				linkType: {
					value: "link",
					displayValue: resources.localizableStrings.LinkCaption
				},
				iconType: {
					value: "icon",
					displayValue: resources.localizableStrings.IconCaption
				},
				defaultType: {
					value: "text",
					displayValue: resources.localizableStrings.TextCaption
				}
			},

			createHeaderItems : function() {
				return [
					{
						id: "HeaderLabel",
						tag: "HeaderlLabel",
						className: "BPMSoft.Label",
						markerValue: resources.localizableStrings.ColumnCaption + ": " + (this.columnInfo.metaCaptionPath || this.columnInfo.leftExpressionCaption),
						caption: resources.localizableStrings.ColumnCaption + ": " +  (this.columnInfo.metaCaptionPath || this.columnInfo.leftExpressionCaption),
						classes: {
							labelClass: ["header-caption-label"]
						},
						width: "auto"
					}, {
						className: "BPMSoft.Button",
						caption: "",
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						imageConfig: resources.localizableImages.CloseImage,
						markerValue: "closeButton",
						classes: {
							wrapperClass: ["close-btn-user-class"]
						},
						click: {
							bindTo: "cancelButtonClick"
						},
						visible: false
					}
					
				]
			},

			/**
			 * ####### ############# ###### ###### ######### #######.
			 * @param {Ext.Element} renderTo ####### ######### ### #########.
			 * @return {Container|*} ########## ############# ###### ###### ######### #######.
			 */
			createView: function(renderTo) {
				const view = this.Ext.create("BPMSoft.Container", {
					renderTo: renderTo,
					id: "columnSettingsContainer",
					selectors: {
						el: "#columnSettingsContainer",
						wrapEl: "#columnSettingsContainer"
					},
					classes: {
						wrapClassName: ["column-settings-container"]
					},
					items: [
						{
							className: "BPMSoft.Container",
							id: "headerContainer",
							selectors: {
								wrapEl: "#headerContainer"
							},
							classes: {
								wrapClassName: ["header-container-container"]
							},
							items: this.createHeaderItems()
						},
						{
							className: "BPMSoft.Container",
							id: "columnPropertiesSettingsContainer",
							selectors: {
								wrapEl: "#columnPropertiesSettingsContainer"
							},
							classes: {
								wrapClassName: ["column-properties-settings-container"]
							},
							items: [
								{
									className: "BPMSoft.Container",
									id: "leftColumnSettingsContainer",
									selectors: {
										wrapEl: "#leftColumnSettingsContainer"
									},
									classes: {
										wrapClassName: ["left-column-settings-container"]
									},
									items: [
										{
											className: "BPMSoft.Label",
											caption: resources.localizableStrings.ColumnCaption,
											classes: {
												labelClass: ["column-caption-label"]
											},
											visible: {bindTo: "isBackward"}
										},
										{
											className: "BPMSoft.Container",
											id: "columnCaptionContainer",
											selectors: {
												wrapEl: "#columnCaptionContainer"
											},
											visible: {bindTo: "isBackward"},
											items: [
												{
													id: "columnCaptionLabel",
													className: "BPMSoft.Label",
													caption: {
														bindTo: "columnCaption"
													},
													classes: {
														labelClass: ["column-caption-label-value"]
													}
												}
											]
										},
										{
											className: "BPMSoft.Label",
											caption: resources.localizableStrings.TitleCaption,
											classes: {
												labelClass: ["title-label"]
											}
										},
										{
											id: "titleEdit",
											className: "BPMSoft.TextEdit",
											markerValue: resources.localizableStrings.TitleCaption,
											value: {bindTo: "titleValue"}
										},
										{
											className: "BPMSoft.Container",
											id: "hideTitleSettings",
											selectors: {
												wrapEl: "#hideTitleSettings"
											},
											classes: {
												wrapClassName: ["hide-title-settings-container"]
											},
											visible: {bindTo: "isTiled"},
											items: [
												{
													id: "isCaptionHiddenEdit",
													className: "BPMSoft.CheckBoxEdit",
													checked: {bindTo: "isCaptionHidden"}
												},
												{
													id: "hideCaptionLabel",
													className: "BPMSoft.Label",
													caption: resources.localizableStrings.HideTitleCaption,
													inputId: "isCaptionHiddenEdit-el",
													classes: {
														labelClass: ["hide-title-label"]
													}
												}
											]
										},
										{
											className: "BPMSoft.Container",
											id: "functionSettings",
											selectors: {
												wrapEl: "#functionSettings"
											},
											classes: {
												wrapClassName: ["function-settings-container"]
											},
											visible: {bindTo: "isAggregatedColumn"},
											items: [
												{
													id: "functionLabel",
													className: "BPMSoft.Label",
													caption: resources.localizableStrings.FunctionCaption,
													width: "100%"
												},
												{
													className: "BPMSoft.Container",
													id: "sumRadioSettings",
													selectors: {
														wrapEl: "#sumRadioSettings"
													},
													classes: {
														wrapClassName: ["radio-settings-container"]
													},
													visible: {bindTo: "sumContainerRadioButton"},
													items: [
														{
															id: "sumRadioButton",
															className: "BPMSoft.RadioButton",
															enabled: true,
															tag: BPMSoft.AggregationType.SUM,
															checked: {bindTo: "functionButtonsGroup"}
														},
														{
															id: "sumFunctionLabel",
															className: "BPMSoft.Label",
															caption: resources.localizableStrings.SumFunctionCaption,
															width: "auto",
															classes: {
																labelClass: ["function-label"]
															},
															inputId: "sumRadioButton-el"
														}
													]
												},
												{
													className: "BPMSoft.Container",
													id: "maxRadioSettings",
													selectors: {
														wrapEl: "#maxRadioSettings"
													},
													classes: {
														wrapClassName: ["radio-settings-container"]
													},
													visible: {bindTo: "maxContainerRadioButton"},
													items: [
														{
															id: "maxRadioButton",
															className: "BPMSoft.RadioButton",
															enabled: true,
															tag: BPMSoft.AggregationType.MAX,
															checked: {bindTo: "functionButtonsGroup"}
														},
														{
															id: "maxFunctionLabel",
															className: "BPMSoft.Label",
															caption: resources.localizableStrings.MaxFunctionCaption,
															width: "auto",
															classes: {
																labelClass: ["function-label"]
															},
															inputId: "maxRadioButton-el"
														}
													]
												},
												{
													className: "BPMSoft.Container",
													id: "minRadioSettings",
													selectors: {
														wrapEl: "#minRadioSettings"
													},
													classes: {
														wrapClassName: ["radio-settings-container"]
													},
													visible: {bindTo: "minContainerRadioButton"},
													items: [
														{
															id: "minRadioButton",
															className: "BPMSoft.RadioButton",
															enabled: true,
															tag: BPMSoft.AggregationType.MIN,
															checked: {bindTo: "functionButtonsGroup"}
														},
														{
															id: "minFunctionLabel",
															className: "BPMSoft.Label",
															caption: resources.localizableStrings.MinFunctionCaption,
															width: "auto",
															classes: {
																labelClass: ["function-label"]
															},
															inputId: "minRadioButton-el"
														}
													]
												},
												{
													className: "BPMSoft.Container",
													id: "avgRadioSettings",
													selectors: {
														wrapEl: "#avgRadioSettings"
													},
													classes: {
														wrapClassName: ["radio-settings-container"]
													},
													visible: {bindTo: "avgContainerRadioButton"},
													items: [
														{
															id: "avgRadioButton",
															className: "BPMSoft.RadioButton",
															enabled: true,
															tag: BPMSoft.AggregationType.AVG,
															checked: {bindTo: "functionButtonsGroup"}
														},
														{
															id: "avgFunctionLabel",
															className: "BPMSoft.Label",
															caption: resources.localizableStrings.AvgFunctionCaption,
															width: "auto",
															classes: {
																labelClass: ["function-label"]
															},
															inputId: "avgRadioButton-el"
														}
													]
												}
											]
										},
										{
											className: "BPMSoft.ControlGroup",
											caption: resources.localizableStrings.TypeCaption,
											collapsed: true,
											bottomLine: false,
											visible: {bindTo: "isColumnTypeVisible"},
											items: [
												{
													className: "BPMSoft.Label",
													caption: resources.localizableStrings.ColumnTypeCaption,
													classes: {
														labelClass: ["text-size-label"]
													}
												},
												{
													id: "columnTypeEdit",
													className: "BPMSoft.ComboBoxEdit",
													value: {bindTo: "selectedColumnType"},
													list: {bindTo: "columnTypes"},
													prepareList: {bindTo: "getColumnTypes"}
												}
											]
										}
									]
								},
								{
									className: "BPMSoft.Container",
									id: "rightColumnSettingsContainer",
									selectors: {
										wrapEl: "#rightColumnSettingsContainer"
									},
									classes: {
										wrapClassName: ["right-column-settings-container"]
									},
									visible: {bindTo: "isBackward"},
									items: [
										{
											className: "BPMSoft.ControlGroup",
											caption: resources.localizableStrings.FilterCaption,
											collapsed: false,
											bottomLine: false,
											items: [
												{
													className: "BPMSoft.Container",
													id: "FilterProperties",
													selectors: {
														wrapEl: "#FilterProperties"
													}
												}
											]
										}
									]
								}
							]
						},
						{
							className: "BPMSoft.Container",
							id: "topSettings",
							selectors: {
								wrapEl: "#topSettings"
							},
							classes: {
								wrapClassName: ["top-settings-container"]
							},
							items: [
								{
									id: "SaveButton",
									tag: "SaveButton",
									className: "BPMSoft.Button",
									style: BPMSoft.controls.ButtonEnums.style.ORANGE,
									caption: resources.localizableStrings.SaveButtonCaption,
									click: {
										bindTo: "saveButtonClick"
									}
								},
								{
									id: "CancelButton",
									className: "BPMSoft.Button",
									style: BPMSoft.controls.ButtonEnums.style.DEFAULT,
									caption: resources.localizableStrings.CancelButtonCaption,
									classes: {
										textClass: ["cancel-button"]
									},
									click: {
										bindTo: "cancelButtonClick"
									}
								}
							]
						}
					]
				});
				return view;
			},

			/**
			 * Creates an instance of the view model of the module for setting column properties.
			 * @return {BaseViewModel|*} Instance of the view model.
			 */
			createViewModel: function() {
				const viewModel = this.Ext.create("BPMSoft.ColumnSettingsViewModel", {
					values: {
						/**
						 * ############ #######
						 * @private
						 * @type {Object}
						 */
						columnInfo: null,

						/**
						 * ######### #######
						 * @private
						 * @type {String}
						 */
						columnCaption: "",

						/**
						 * ######## #######
						 * @private
						 * @type {String}
						 */
						titleValue: "",

						/**
						 * ######### ##### #######
						 * @private
						 * @type {BPMSoft.Collection}
						 */
						columnTypes: new BPMSoft.Collection(),

						/**
						 * ######### ### #######
						 * @private
						 * @type {Object}
						 */
						selectedColumnType: null,

						/**
						 * ####, ######### ## ############ ## ### #######
						 * @private
						 * @type {Boolean}
						 */
						isAggregatedColumn: false,

						/**
						 * ### ######### ###### #######
						 * @private
						 * @type {Object}
						 */
						functionButtonsGroup: BPMSoft.AggregationType.SUM,

						/**
						 * ####, ####### ######### ######## ## #######
						 * # ######## ######### ######### ######### #######
						 * @private
						 * @type {Boolean}
						 */
						isCaptionHidden: false,

						/**
						 * ######## ########
						 * @private
						 * @type {Object}
						 */
						filterManager: null,

						/**
						 * ####, ####### ######### ###### #### ######
						 * @private
						 * @type {Boolean}
						 */
						isTiled: true,

						/**
						 * ######### ######### ########
						 * @private
						 * @type {Object}
						 */
						selectedFilters: null,

						/**
						 * ####, ####### ######### ######## ## ####### ########## sumContainerRadioButton
						 * @private
						 * @type {Boolean}
						 */
						sumContainerRadioButton: false,

						/**
						 *####, ####### #########  ######## ## ####### ########## maxContainerRadioButton
						 * @private
						 * @type {Boolean}
						 */
						maxContainerRadioButton: false,

						/**
						 *####, ####### ######### ######## ## ####### ########## minContainerRadioButton
						 * @private
						 * @type {Boolean}
						 */
						minContainerRadioButton: false,

						/**
						 * ####, ####### ######### ######## ## ####### ########## avgContainerRadioButton
						 * @private
						 * @type {Boolean}
						 */
						avgContainerRadioButton: false,

						/**
						 * A flag that indicates whether the column type settings are visible.
						 * @private
						 * @type {Boolean}
						 */
						isColumnTypeVisible: true,

						/**
						 * Sandbox
						 * @private
						 * @type {Object}
						 */
						sandbox: null,

						/**
						 * A flag that indicates whether the link type is available.
						 * @private
						 * @type {Boolean}
						 */
						useLinkType: false
					},
					resources: resources
				});
				return viewModel;
			},

			/**
			 * ############# ######### ######## ###### ######### #######.
			 * @param {Function} callback ####### ######### ######.
			 */
			init: function(callback) {
				this.togglePageClass(true);
				const state = this.sandbox.publish("GetHistoryState");
				const currentHash = state.hash;
				const currentState = state.state || {};
				if (currentState.moduleId === this.sandbox.id) {
					return;
				}
				this.sandbox.publish("ReplaceHistoryState", {
					stateObj: {
						moduleId: this.sandbox.id
					},
					pageTitle: null,
					hash: currentHash.historyState,
					silent: true
				});
				this.columnInfo = this.sandbox.publish("ColumnSettingsInfo", null, [this.sandbox.id]);
				this.schemaName = this._getSchemaName(this.columnInfo);
				Ext.callback(callback, this);
			},

			/**
			 * Toggles unique class for this page on specific container
			 * @param {boolean} add
			 */
			togglePageClass: function (add) {
				var className = 'column-settings-page';
				var containerName = 'ViewModuleContainer';
				var container = this.Ext.get(containerName);
				add ? container.addCls(className) : container.removeCls(className);
			},

			/**
			 * Initializes the page title in the top pane.
			 */
			initHeaderCaption: function() {
				if (this.isNestedColumnSettingModule) {
					return;
				}
				const headerCaption = resources.localizableStrings.PageCaption + this.columnInfo.leftExpressionCaption;
				this.sandbox.publish("InitDataViews", {
					caption: headerCaption,
					hidePageCaption: this.hidePageCaption
				});
			},

			/**
			 * @private
			 */
			_getSchemaName: function(columnInfo) {
				return columnInfo && (columnInfo.lastReferenceSchemaName || columnInfo.schemaName ||
					columnInfo.referenceSchemaName);
			},

			/**
			 * @private
			 */
			_setSelectedColumnType: function() {
				let titleType;
				switch (this.columnInfo.columnType) {
					case "title":
						titleType = this._columnTypeConfig.titleType;
						break;
					case "text":
						titleType = this._columnTypeConfig.textType;
						break;
					case "link":
						titleType = this._columnTypeConfig.linkType;
						break;
					case "icon":
						titleType = this._columnTypeConfig.iconType;
						break;
					default:
						titleType = this._columnTypeConfig.defaultType;
						break;
				}
				this.viewModel.set("selectedColumnType", titleType);
			},

			/**
			 * @private
			 */
			_setInitialModelState: function() {
				this.viewModel.set("sandbox", this.sandbox);
				this.viewModel.set("filterManager", this.filterManager);
				this.viewModel.set("columnCaption", this.columnInfo.metaCaptionPath
					? this.columnInfo.metaCaptionPath
					: this.columnInfo.leftExpressionCaption);
				this.viewModel.set("titleValue", this.columnInfo.leftExpressionCaption);
				this._setSelectedColumnType();
				this.viewModel.set("isTiled", this.columnInfo.isTiled);
				this.viewModel.set("columnInfo", this.columnInfo);
				this.viewModel.set("isAggregatedColumn", this.columnInfo.isBackward &&
						this.columnInfo.aggregationType !== BPMSoft.AggregationType.COUNT &&
						this.columnInfo.aggregationFunction !== "count");
				this.viewModel.set("isBackward", this.columnInfo.isBackward && !this.columnInfo.hideFilter);
				this.viewModel.set("isCaptionHidden", !_.isUndefined(this.columnInfo.isCaptionHidden)
					? this.columnInfo.isCaptionHidden
					: false);
				if (this.columnInfo.aggregationType) {
					this.viewModel.set("functionButtonsGroup", this.columnInfo.aggregationType);
				} else if (this.columnInfo.isBackward && this.columnInfo.aggregationFunction === "count") {
					this.viewModel.set("functionButtonsGroup", BPMSoft.AggregationType.COUNT);
				}
				this.viewModel.set("referenceSchemaName", this.columnInfo.referenceSchemaName);
				this.viewModel.set("schemaName", this.columnInfo.schemaName);
				this.viewModel.set("lastReferenceSchemaName", this.columnInfo.lastReferenceSchemaName);
				this.viewModel.set("isNestedColumnSettingModule", this.isNestedColumnSettingModule);
				this.viewModel.set("isColumnTypeVisible", this.isColumnTypeVisible);
				this.viewModel.set("hidePageCaption", this.hidePageCaption);
			},

			/**
			 * @private
			 */
			_initViewModel: function() {
				this.initHeaderCaption();
				this.viewModel = this.createViewModel();
				this._setInitialModelState();
				this.isInitialized = true;
				this.viewModel.showRadioButtons();
			},

			/**
			 * ########## ############# # ######### renderTo.
			 * @param {Ext.Element} renderTo ###### ## #########, # ####### ##### ############ #############.
			 */
			render: function(renderTo) {
				if (!this.isProviderInitialized) {
					this.initializeProvider(renderTo);
					return;
				}
				const container = this.renderContainer = this.entitySchemaProvider.renderTo = renderTo;
				const view = this.createView(container);
				this.loadFilterModule();
				view.bind(this.viewModel);
			},

			/**
			 * @private
			 */
			_registerFilterEditModuleMessages: function() {
				this.sandbox.registerMessages({
					"OnFiltersChanged": {
						"mode": BPMSoft.MessageMode.BROADCAST,
						"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
					},
					"GetFilterModuleConfig": {
						"mode": BPMSoft.MessageMode.PTP,
						"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
					}
				});
			},

			/**
			 * @private
			 */
			_getFilterEditModuleId: function() {
				return this.sandbox.id + "_ExtendedFilterEditModule";
			},

			/**
			 * @private
			 */
			_subscribeToFilterMessages: function(moduleId) {
				this.sandbox.subscribe("OnFiltersChanged", function(args) {
					this.viewModel.set("filterData", args.serializedFilter);
					const filter = BPMSoft.deserialize(args.serializedFilter);
					this.filterManager.setFilters(filter || this.Ext.create("BPMSoft.FilterGroup"));
				}, this, [moduleId]);
				this.sandbox.subscribe("GetFilterModuleConfig", function() {
					const columnInfo = this.columnInfo;
					var rootSchemaName = this._getSchemaName(columnInfo);
					return {
						rootSchemaName: rootSchemaName,
						filters: columnInfo && columnInfo.serializedFilter,
						entitySchemaFilterProviderConfig: {
							shouldHideLookupActions: columnInfo && columnInfo.shouldHideLookupActions,
							isColumnSettingsHidden: columnInfo && columnInfo.isColumnSettingsHidden
						}
					};
				}, this, [moduleId]);
			},

			/**
			 * ##### ######## ###### ##########.
			 * @protected
			 * @virtual
			 */
			loadFilterModule: function() {
				if (!this.isInitialized) {
					this._initViewModel();
				}
				if (this.viewModel.get("filterModuleLoaded")) {
					return;
				}
				this._registerFilterEditModuleMessages();
				const moduleId = this._getFilterEditModuleId();
				this._subscribeToFilterMessages(moduleId);
				this.sandbox.loadModule("FilterEditModule", {
					renderTo: "FilterProperties",
					id: moduleId
				});
				this.viewModel.set("filterModuleLoaded", true);
			},

			/**
			 * ####### ### ######## ## ####### # ########## ######.
			 * @override
			 * @param {Object} config ######### ########### ######.
			 */
			destroy: function destroy(config) {
				this.togglePageClass(false);
				if (config.keepAlive) {
					return;
				}
				if (this.entitySchemaProvider && !this.entitySchemaProvider.destroyed) {
					this.entitySchemaProvider.destroy();
				}
				this.entitySchemaProvider = null;
				requirejs.undef("EntitySchemaFilterProviderModule");
			},

			/**
			 * ############## EntitySchemaFilterProvider.
			 * @param {Ext.Element} renderTo ####### ######### ### #########.
			 */
			initializeProvider: function initializeProvider(renderTo) {
				const filter = BPMSoft.deserialize(this.columnInfo.serializedFilter);
				const map = {};
				map.EntitySchemaFilterProviderModule = {
					sandbox: "sandbox_" + this.sandbox.id,
					"ext-base": "ext_" + this.Ext.id
				};
				requirejs.config({
					map: map
				});
				this.BPMSoft.require(["EntitySchemaFilterProviderModule"],
					function(EntitySchemaFilterProviderModule) {
						this.entitySchemaProvider = new EntitySchemaFilterProviderModule({
							rootSchemaName: this.schemaName
						});
						this.filterManager = this.Ext.create("BPMSoft.FilterManager", {
							provider: this.entitySchemaProvider
						});
						this.filterManager.setFilters(filter || this.Ext.create("BPMSoft.FilterGroup"));
						this.isProviderInitialized = true;
						this.render(renderTo);
					}, this);
			}
		});
		return BPMSoft.ColumnSettings;
	});
