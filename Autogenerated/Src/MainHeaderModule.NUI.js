define("MainHeaderModule", ["MainHeaderModuleResources", "IconHelper", "ServiceHelper",
		"MainHeaderExtensions", "ConfigurationConstants", "BaseSchemaModuleV2",
		"ImageView", "css!MainHeaderExtensions", "MainMenuUtilities"],
	function(resources, iconHelper, serviceHelper, extensions, ConfigurationConstants) {

		/**
		 * ####### ############ ###### ############# # #######.
		 * @private
		 * @param {Object} config ############ ###### ############# # #######.
		 * @return {Object} ########## ############ ###### ############# # #######.
		 */
		var createViewIconButtonConfig = function(config) {
			var buttonConfig = iconHelper.createIconButtonConfig(config);
			buttonConfig.imageConfig = {
				source: BPMSoft.ImageSources.URL,
				url: BPMSoft.ImageUrlBuilder.getUrl(config.icon)
			};
			return buttonConfig;
		};

		Ext.define("BPMSoft.configuration.MainHeaderViewModel", {
			extend: "BPMSoft.BaseViewModel",
			alternateClassName: "BPMSoft.MainHeaderViewModel",
			mixins: {
				TooltipUtilitiesMixin: "BPMSoft.TooltipUtilities"
			}
		});

		/**
		 * ##### MainHeaderModule ############ ### ######## ########## ####### ######.
		 */
		Ext.define("BPMSoft.configuration.MainHeaderModule", {
			extend: "BPMSoft.configuration.BaseSchemaModule",
			alternateClassName: "BPMSoft.MainHeaderModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,

			/**
			 * ###### ############# ####### ######.
			 * @private
			 * @type {Object}
			 */
			viewModel: null,

			/**
			 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
			 * @override
			 */
			initHistoryState: Ext.emptyFn,

			generateViewContainerId: false,

			/**
			 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
			 * @override
			 */
			initSchemaName: function() {
				if (!this.BPMSoft.Features.getIsEnabled("OldUI")) {
					this.schemaName = "MainHeaderSchema";
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
			 * @override
			 */
			getViewConfig: function() {
				var viewConfig = this.callParent(arguments);
				viewConfig.classes.wrapClassName = [];
				return viewConfig;
			},

			/**
			 * ############# ######### ######## ###### ####### ######.
			 * @protected
			 */
			init: function(callback, scope) {
				if (!this.BPMSoft.Features.getIsEnabled("OldUI")) {
					this.callParent(arguments);
					return;
				}
				this.viewModel = this.createViewModel();
				this.viewModel.Ext = this.Ext;
				this.viewModel.BPMSoft = this.BPMSoft;
				this.viewModel.init();
				this.Ext.callback(callback, scope || this);
			},

			/**
			 * ########## ############# # ######### renderTo.
			 * @param {Ext.Element} renderTo ###### ## #########, # ####### ##### ############ #############.
			 */
			render: function(renderTo) {
				this.viewModel.loadProfileButtonMenu();
				if (!this.BPMSoft.Features.getIsEnabled("OldUI")) {
					this.callParent(arguments);
					return;
				}
				var view = this.getView();
				view.bind(this.viewModel);
				view.render(renderTo);
				this.viewModel.loadCommandModule();
				this.viewModel.loadContextHelpModule();
			},

			/**
			 * ####### ###### ############# ####### ######.
			 * @protected
			 * @return {Object} ########## ###### ############# ####### ######.
			 */
			createViewModel: function() {
				if (!this.BPMSoft.Features.getIsEnabled("OldUI")) {
					return this.callParent(arguments);
				}
				var values = {
					/**
					 * ########## sandbox ######.
					 * @private
					 * @type {Object}
					 */
					sandbox: this.sandbox,

					/**
					 * ######### ####### #####.
					 * @private
					 * @type {String}
					 */
					HeaderCaption: "",

					/**
					 * Header caption marker value.
					 * @private
					 * @type {String}
					 */
					HeaderCaptionMarkerValue: "",

					/**
					 * ### ######### #############.
					 * @private
					 * @type {String}
					 */
					ActiveViewName: "",

					/**
					 * ######### ###### ############# #######.
					 * @private
					 * @type {Collection}
					 */
					ViewButtons: new this.BPMSoft.Collection(),

					/**
					 * ####, ####### ######### ###### ########## ####### ######.
					 * #### ######## True, ## ########## ## ######## #### - ####### ##### ############,
					 * ###### ##########.
					 * #### ######## False, ## ########### ##### - ####### ##### #########, ###### ############.
					 * @private
					 * @type {Boolean}
					 */
					IsMainMenu: false,

					/**
					 * ####, ####### ######### ##### ## ##### ######### ####### ######.
					 * @private
					 * @type {Boolean}
					 */
					IsCaptionVisible: true,

					/**
					 * ####, ####### ######### ##### ## ##### ###### ########## ######.
					 * @private
					 * @type {Boolean}
					 */
					IsCommandLineVisible: false,

					IsSSP: (this.BPMSoft.CurrentUser.userType === this.BPMSoft.UserType.SSP),

					/**
					 * ####, ####### ######### ##### ## ##### ###### ########### #######.
					 * @private
					 * @type {Boolean}
					 */
					IsContextHelpVisible: false,

					/**
					 * ####, ####### ######### ##### ## ##### ###### "######## #######".
					 * @private
					 * @type {Boolean}
					 */
					IsSystemDesignerVisible: false,

					/**
					 * ####, ####### ######### ##### ## ###### #### ######## ############ # ####### ######.
					 * @private
					 * @type {Boolean}
					 */
					IsUserPhotoVisible: true,

					/**
					 * ####, ####### ######### ##### ## ##### ###### ####### # ####### ######.
					 * @private
					 * @type {Boolean}
					 */
					IsLogoVisible: true,

					/**
					 * ####, ####### ######### ##### ## ###### ####### ######.
					 * @private
					 * @type {Boolean}
					 */
					IsMainHeaderVisible: true,

					/**
					 * ############# ########## ######## ############.
					 * @private
					 * @type {String}
					 */
					ContactPhotoId: "",

					/**
					 * ######## ######, ####### ###### #######.
					 * @private
					 * @type {String}
					 */
					ModuleName: "",

					/**
					 * ######### ####### #### ###### ####### ############.
					 * @private
					 * @type {BPMSoft.BaseViewModelCollection}
					 */
					ProfileMenuCollection: Ext.create("BPMSoft.BaseViewModelCollection")
				};
				var methods = {
					/**
					 * Loads command line module.
					 * @private
					 */
					loadCommandModule: function() {
						var commandLineContainer = this.Ext.getCmp("header-command-line-container");
						if (commandLineContainer && commandLineContainer.rendered) {
							this.getSandbox().loadModule("CommandLineModule", {
								renderTo: "header-command-line-container"
							});
						}
					},

					/**
					 * Loads profile button menu items.
					 * @private
					 */
					loadProfileButtonMenu: function() {
						var profileMenuCollection = this.get("ProfileMenuCollection");
						profileMenuCollection.addItem(Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Id: "profile-menu-item",
								Caption: resources.localizableStrings.ProfileMenuItemCaption,
								Click: {
									bindTo: "onProfileMenuItemClick"
								},
								MarkerValue: resources.localizableStrings.ProfileMenuItemCaption,
								ImageConfig: resources.localizableImages.YourProfileIcon
							}
						}));
						profileMenuCollection.addItem(Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Id: "separator-profil-menu-item",
								Type: "BPMSoft.MenuSeparator",
								Caption: ""
							}
						}));
						profileMenuCollection.addItem(Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Id: "exit-menu-item",
								Caption: resources.localizableStrings.ExitMenuItemCaption,
								Click: {
									bindTo: "onExitMenuItemClick"
								},
								MarkerValue: resources.localizableStrings.ExitMenuItemCaption
							}
						}));
					},

					/**
					 * Loads module of context help button.
					 * @private
					 */
					loadContextHelpModule: function() {
						var sandbox = this.getSandbox();
						var contextHelpContainer = this.Ext.getCmp("header-context-help-container");
						if (contextHelpContainer && contextHelpContainer.rendered) {
							var contextHelpModuleId = sandbox.loadModule("ContextHelpModule", {
								renderTo: "header-context-help-container"
							});
							sandbox.subscribe("InitContextHelp", function(config) {
								sandbox.publish("ChangeContextHelpId", config, [contextHelpModuleId]);
							}, this);
						}
					},

					/**
					 * Unloads command line module.
					 * @private
					 */
					unloadCommandModule: function() {
						this.getSandbox().unloadModule("CommandLineModule");
					},

					/**
					 * Unloads module of context help button.
					 * @private
					 */
					unloadContextHelpModule: function() {
						this.getSandbox().unloadModule("ContextHelpModule");
					},

					/**
					 * Reloads command line module.
					 * @private
					 */
					reloadCommandModule: function() {
						this.unloadCommandModule();
						this.loadCommandModule();
					},

					/**
					 * Reloads module of context help button.
					 * @private
					 */
					reloadContextHelpModule: function() {
						this.unloadContextHelpModule();
						this.loadContextHelpModule();
					},

					/**
					 * ######## sandbox.
					 * @private
					 * @return {Object} sandbox.
					 */
					getSandbox: function() {
						return this.get("sandbox");
					},

					/**
					 * ######## ######### ###### ######.
					 * @returns {boolean}
					 */
					getIsButtonsVisible: function() {
						return (this.get("ViewButtons").getCount() > 1);
					},

					/**
					 * ############ ###### ######### # ########### ## ####### ###### #############.
					 */
					fixHeaderWidth: function() {
						var captionContainer = this.Ext.get("caption");
						if (!captionContainer) {
							return;
						}
						var viewButtonsVisible = this.getIsButtonsVisible();
						if (viewButtonsVisible) {
							captionContainer.removeCls("fix-width");
						} else {
							captionContainer.addCls("fix-width");
						}
					},

					/**
					 * ######## ######### ####### ######.
					 * @private
					 * @param {Object} config ############ ######### ####### ######.
					 */
					onInitDataViews: function(config) {
						var conf = (config && config[0].settings) ? config[0].settings : config[0];
						if (conf.dataViews) {
							this.setButtons(conf);
						} else {
							this.set("ViewButtons", new this.BPMSoft.Collection());
							this.setSettings(conf);
						}
						if (!this.Ext.isEmpty(conf.caption)) {
							this.set("HeaderCaption", conf.caption);
						}
						this.set("HeaderCaptionMarkerValue", conf.markerValue || conf.caption || "");
						this.set("ModuleName", conf.moduleName ? conf.moduleName : "");
					},

					/**
					 * ############# ######### ###### ############ #############.
					 * @param {Object} config
					 */
					setButtons: function(config) {
						var buttons = new this.BPMSoft.Collection();
						var buttonsContainer = this.Ext.getCmp("button-switch");
						if (buttonsContainer) {
							this.clearContainerItems("button-switch");
							config.dataViews.each(function(item) {
								var bConfig = item.icon
									? this.createViewIconButtonConfig(item)
									: this.createButtonConfig(item);
								if (item.markerValue) {
									bConfig.markerValue = item.markerValue;
								}
								if (item.active) {
									this.set("ActiveViewName", item.name);
								}
								buttons.add(bConfig);
								buttonsContainer.add(bConfig);
							}, this);
							this.set("ViewButtons", buttons);
							this.setSettings(config);
							buttonsContainer.bind(this);
							this.setPressedViewButtons(this.get("ActiveViewName"));
						}
					},

					/**
					 * ############ ####### ## ####### "### #######" #### ###### #######.
					 * @private
					 */
					onProfileMenuItemClick: function() {
						this.getSandbox().publish("PushHistoryState", {hash: "UserProfile"});
					},

					/**
					 * ############ ####### ## ####### "#####" #### ###### #######.
					 * @private
					 */
					onExitMenuItemClick: async function() {
						await BPMSoft.MainMenuUtilities.logout();
					},

					/**
					 * Handles logo click.
					 * @private
					 */
					onLogoClick: function() {
						this.openHomePage();
					},

					/**
					 * Open home page.
					 * @protected
					 */
					openHomePage: function() {
						var isPortalUser = this.get("IsSSP");
						if (isPortalUser) {
							var defaultPortalHomeModule = ConfigurationConstants.DefaultPortalHomeModule;
							this.sandbox.publish("PushHistoryState", {hash: defaultPortalHomeModule});
						} else {
							var defaultIntroPageName = BPMSoft.configuration.defaultIntroPageName;
							if (defaultIntroPageName) {
								var defaultHomeModule = ConfigurationConstants.DefaultHomeModule;
								var hash = this.BPMSoft.combinePath(defaultHomeModule, defaultIntroPageName);
								this.getSandbox().publish("PushHistoryState", {hash: hash});
							}
						}
					},

					/**
					 * ############ ####### ## ###### "######## #######".
					 */
					onSystemDesignerClick: function() {
						BPMSoft.Mask.show();
						var sandbox = this.getSandbox();
						sandbox.publish("PushHistoryState", {
							hash: "IntroPage/SystemDesigner"
						});
					},

					/**
					 * ############ ####### ## ######### #######.
					 * @private
					 */
					onCaptionClick: function() {
						this.updateSection();
					},

					/**
					 * ######### ######.
					 * @private
					 */
					updateSection: function() {
						this.getSandbox().publish("UpdateSection", null, [this.get("ModuleName") + "_UpdateSection"]);
					},

					/**
					 * ########## ####### # ######### ######.
					 * @private
					 */
					resetSection: function() {
						this.getSandbox().publish("ResetSection", null, [this.get("ModuleName") + "_ResetSection"]);
					},

					/**
					 * ############ ####### ## ###### ############ ##### #####.
					 * @private
					 */
					onViewButtonClick: function() {
						var tag = arguments[3];
						this.setPressedViewButtons(tag);
						var viewConfig = {
							tag: tag,
							moduleName: this.get("ModuleName")
						};
						var sandbox = this.getSandbox();
						sandbox.publish("ChangeDataView", viewConfig, [sandbox.id + "_" + viewConfig.moduleName]);
					},

					/**
					 * ############ ####### ## ###### ############ ############# # ######### ######.
					 * @private
					 * @param {String} viewName ### #############.
					 */
					setPressedViewButtons: function(viewName) {
						var buttons = this.get("ViewButtons");
						var items = buttons.getItems();
						var isPressed = false;
						this.BPMSoft.each(items, function(item) {
							if (item.tag === viewName) {
								isPressed = true;
								this.set(item.tag + "Active", true);
							} else {
								this.set(item.tag + "Active", false);
							}
						}, this);
						if (!isPressed && items.length > 0) {
							this.set(items[0].tag + "Active", true);
						}
					},

					/**
					 * ############# ###### ######### ####### ## ############.
					 * @private
					 * @param {Object} config ############ ######## ####### ######.
					 */
					setSettings: function setSettings(config) {
						var mainHeader = this.Ext.get("mainHeader");
						var centerPanelContainer = this.Ext.get("centerPanelContainer");
						if (config.hasOwnProperty("isMainHeaderVisible")) {
							mainHeader.setVisible(config.isMainHeaderVisible);
							centerPanelContainer.addCls("center-panel-no-padding-top");
						} else {
							mainHeader.setVisible(true);
							centerPanelContainer.removeCls("center-panel-no-padding-top");
						}
						var logoVisible = true;
						if (config.hasOwnProperty("isMainMenu")) {
							this.set("IsMainMenu", config.isMainMenu);
							logoVisible = false;
							this.set("IsLogoVisible", logoVisible);
						} else {
							this.set("IsMainMenu", false);
							logoVisible = true;
							this.set("IsLogoVisible", logoVisible);
						}
						if (config.hasOwnProperty("isCaptionVisible")) {
							this.set("IsCaptionVisible", config.isCaptionVisible);
						} else {
							this.set("IsCaptionVisible", true);
						}
						this.commandLineVisible(config);
						this.contextHelpVisible(config);
						this.setSystemDesignerVisible(config);
						if (config.hasOwnProperty("isUserPhotoVisible")) {
							this.set("IsUserPhotoVisible", config.isUserPhotoVisible);
						} else {
							this.set("IsUserPhotoVisible", true);
						}
						if (config.hasOwnProperty("isLogoVisible")) {
							this.set("IsLogoVisible", config.isLogoVisible);
						} else {
							this.set("IsLogoVisible", logoVisible);
						}
						if (config.hasOwnProperty("isLogoVisible")) {
							this.set("IsLogoVisible", config.isLogoVisible);
						} else {
							this.set("IsLogoVisible", logoVisible);
						}
					},

					/**
					 * #############, ###### ## ############, ######## ###### ########## ## ########### #########
					 * ######. ######## ## ########### # ####### ######### ###### ## ######.
					 * @private
					 * @param {Object} config ############ ######## ####### ######.
					 */
					commandLineVisible: function(config) {
						var isCommandLineVisible = !this.get("IsSSP");
						if (isCommandLineVisible && config.hasOwnProperty("isCommandLineVisible")) {
							isCommandLineVisible = config.isCommandLineVisible;
						}
						if (this.get("IsCommandLineVisible") !== isCommandLineVisible) {
							this.set("IsCommandLineVisible", isCommandLineVisible);
							this.reloadCommandModule();
						}
					},

					/**
					 * #############, ###### ## ############, ######## ###### ########## ## ########### ###### ######.
					 * ######## ## ########### # ####### ###### ###### ## ######.
					 * @private
					 * @param {Object} config ############ ######## ####### ######.
					 */
					contextHelpVisible: function(config) {
						var isContextHelpVisible = !this.get("IsSSP");
						if (isContextHelpVisible && config.hasOwnProperty("isContextHelpVisible")) {
							isContextHelpVisible = config.isContextHelpVisible;
						}
						if (this.get("IsContextHelpVisible") !== isContextHelpVisible) {
							this.set("IsContextHelpVisible", isContextHelpVisible);
							this.reloadContextHelpModule();
						}
					},

					/**
					 * #############, ###### ## ############, ######## ###### ########## ## ########### ######
					 * "######## #######". ######## ## ########### # ####### ###### "######## #######" ## ######.
					 * @private
					 * @param {Object} config ############ ######## ####### ######.
					 */
					setSystemDesignerVisible: function(config) {
						var isSystemDesignerVisible = !this.get("IsSSP");
						if (config.hasOwnProperty("isSystemDesignerVisible")) {
							isSystemDesignerVisible = config.isSystemDesignerVisible;
						}
						this.BPMSoft.SysSettings.querySysSettings(["BuildType"], function(sysSettings) {
							var buildType = sysSettings.BuildType;
							if (buildType && (buildType.value === ConfigurationConstants.BuildType.Public)) {
								isSystemDesignerVisible = false;
							}
							this.set("IsSystemDesignerVisible", isSystemDesignerVisible);
						}, this);
					},

					/**
					 * ####### ######### ####### ######.
					 * @private
					 */
					clearHeader: function() {
						var mainHeader = this.Ext.get("mainHeader");
						if (mainHeader && !mainHeader.isVisible()) {
							mainHeader.setVisible(true);
						}
						this.set("HeaderCaption", "");
						this.set("HeaderCaptionMarkerValue", "");
					},

					/**
					 * ####### ######## ########## # ############## ###.
					 * @param {String} containerId ############# ##########.
					 * @param {Boolean} needRerender ####, ###########, ########## ## ############## #########
					 * ##### ######## #########.
					 */
					clearContainerItems: function(containerId, needRerender) {
						var container = this.Ext.getCmp(containerId);
						if (container && container.getWrapEl()) {
							if (container.getWrapEl()) {
								container.items.each(function(item) {
									container.remove(item);
									item.destroy();
								}, this);
							}
						}
						if (needRerender) {
							container.reRender();
						}
					},

					/**
					 * ####### ############ ###### ############# # #######.
					 * @private
					 * @param {Object} config ################ ###### #############.
					 * @return {Object} ############ ######## ########## ############# # #######.
					 */
					createViewIconButtonConfig: createViewIconButtonConfig,

					/**
					 * ####### ############ ###### ### ######.
					 * @private
					 * @param {Object} config ############.
					 * @return {Object} ############ ######## ########## ### ######.
					 */
					createButtonConfig: function(config) {
						var buttonConfig = {
							caption: config.caption ? config.caption : config.name,
							tag: [config.name, config.caption],
							markerValue: [config.name, config.caption],
							hint: config.hint,
							className: "BPMSoft.Button",
							style: this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
							pressed: {bindTo: config.name + "Active"},
							click: {bindTo: config.func ? config.func : "onViewButtonClick"},
							classes: {
								textClass: ["view-no-images-class"],
								pressedClass: ["pressed-button-view"]
							},
							menu: {
								items: {
									bindTo: "ProfileMenuCollection"
								},
								ulClass: "profile-menu"
							}
						};
						return buttonConfig;
					},

					/**
					 * Initializes main header module initial state.
					 * @protected
					 */
					init: function() {
						var sandbox = this.getSandbox();
						sandbox.subscribe("InitDataViews", function() {
							this.onInitDataViews(arguments);
							this.fixHeaderWidth();
						}, this);
						sandbox.subscribe("ChangeHeaderCaption", function(args) {
							this.set("HeaderCaption", args.caption);
							this.set("HeaderCaptionMarkerValue", args.markerValue || args.caption);
							this.set("ModuleName", args.moduleName ? args.moduleName : "");
							if (args.dataViews) {
								this.setButtons(args);
							}
							this.fixHeaderWidth();
						}, this);
						if (this.Ext.isEmpty(this.get("HeaderCaption"))) {
							sandbox.publish("NeedHeaderCaption");
						}
						var contactPhotoId = this.BPMSoft.SysValue.CURRENT_USER_CONTACT.primaryImageValue;
						this.set("ContactPhotoId", contactPhotoId);
						if (Ext.isFunction(extensions.customInitViewModel)) {
							extensions.customInitViewModel(this.viewModel || this);
						}
					},

					/**
					 * Gets contact photo config.
					 * @private
					 * @return {Object} Photo config.
					 */
					getContactPhoto: function() {
						var photoId = this.get("ContactPhotoId");
						if (this.BPMSoft.isEmptyGUID(photoId)) {
							return resources.localizableImages.ContactEmptyPhoto;
						}
						var photoConfig = {
							source: this.BPMSoft.ImageSources.ENTITY_COLUMN,
							params: {
								schemaName: "SysImage",
								columnName: "Data",
								primaryColumnValue: photoId
							}
						};
						return {
							source: this.BPMSoft.ImageSources.URL,
							url: this.BPMSoft.ImageUrlBuilder.getUrl(photoConfig)
						};
					}
				};
				if (Ext.isFunction(extensions.extendViewModelValues)) {
					extensions.extendViewModelValues(values);
				}
				if (Ext.isFunction(extensions.extendViewModelMethods)) {
					extensions.extendViewModelMethods(methods);
				}
				var viewModel = this.Ext.create("BPMSoft.MainHeaderViewModel", {
					values: values,
					methods: methods
				});
				return viewModel;
			},

			/**
			 * ######## ############ #############.
			 * @private
			 * @return {Object} ########## ############ #############.
			 */
			getView: function() {
				return this.getContainer("mainHeaderContainer", ["main-header", "fixed"], this.getHeaderItems());
			},

			/**
			 * ########## ############# ##########.
			 * @private
			 * @param {String} id #############.
			 * @param {Object} wrapClass ###### ##########.
			 * @param {Object} items ######### ######## #########.
			 * @return {Object} ########## ############ ##########.
			 */
			getContainer: function(id, wrapClass, items) {
				var container = this.Ext.create("BPMSoft.Container", {
					id: id,
					classes: {
						wrapClassName: this.Ext.isArray(wrapClass) ? wrapClass : [wrapClass]
					},
					selectors: {
						wrapEl: "#" + id
					},
					items: items ? items : []
				});
				return container;
			},

			/**
			 * Apply image config with Logo config.
			 * @private
			 * @return {Object} Logo config.
			 */
			applyLogoHintConfig: function(imageConfig) {
				var config = Ext.apply(imageConfig, {
					hint: resources.localizableStrings.LogoHint
				});
				return config;
			},

			/**
			 * Returns tip view.
			 * @param {Object} config Configuration to generatate tip view.
			 * @return {Object}
			 */
			generateTip: function(config) {
				var viewGenerator = Ext.create("BPMSoft.ViewGenerator");
				var tip = viewGenerator.generatePartial(Ext.merge({
					itemType: this.BPMSoft.ViewItemType.TIP
				}, config), {
					schemaName: "MainHeaderModule",
					schema: {},
					viewModelClass: Ext.ClassManager.get("BPMSoft.MainHeaderViewModel")
				})[0];
				return tip;
			},

			/**
			 * ########## ###### ########### ######### #############.
			 * @private
			 * @return {Object} ###### ########### ######### #############.
			 */
			getHeaderItems: function() {
				var menuLogoImageContainer = this.getContainer("main-header-menu-logo-image-container",
					"main-header-menu-logo-image-container-class");
				menuLogoImageContainer.add(
					this.getImageConfig("menuLogoImage", ["main-header-menu-logo-image"],
						this.getMenuLogoImageConfig())
				);
				this.setVisibleBinding(menuLogoImageContainer, "IsMainMenu");
				var captionContainer = this.getContainer("caption", "caption-class", [this.generateCaption()]);
				var buttonsContainer = this.getContainer("button-switch", "button-class");
				this.setVisibleBinding(buttonsContainer, "getIsButtonsVisible");
				var emptyContainer = this.getContainer("empty-container", "empty-container-class");
				var commandLineContainer = this.getContainer("header-command-line-container", "command-line-class");
				this.setVisibleBinding(commandLineContainer, "IsCommandLineVisible");
				var imageContainer = this.getContainer("main-header-image-container",
					"main-header-image-container-class");
				var photo = this.getProfileButtonConfig();
				imageContainer.add(photo);
				if (Ext.isFunction(extensions.extendImageContainer)) {
					extensions.extendImageContainer(imageContainer);
				}
				this.setVisibleBinding(imageContainer, "IsUserPhotoVisible");
				var contextHelpContainer = this.getContainer("header-context-help-container", "context-help-class");
				this.setVisibleBinding(contextHelpContainer, "IsContextHelpVisible");
				var systemDesignerTip = this.generateTip({
					content: resources.localizableStrings.SystemDesignerTip,
					className: "BPMSoft.ContextTip",
					contextIdList: ["0", "IntroPage"],
					behaviour: {
						displayEvent: this.BPMSoft.controls.TipEnums.displayEvent.NONE
					}
				});
				var systemDesignerContainer = this.getContainer("header-system-designer-container",
					"context-system-designer-class", [
						Ext.apply(this.createViewIconButtonConfig({
							name: "system-designer",
							hint: resources.localizableStrings.SystemDesignerCaption,
							icon: resources.localizableImages.SystemDesignerIcon,
							func: "onSystemDesignerClick",
							wrapperClass: "system-designer-button",
							imageClass: "system-designer-image"
						}), {
							tips: [systemDesignerTip]
						})
					]);
				this.setVisibleBinding(systemDesignerContainer, "IsSystemDesignerVisible");
				var logoContainer = this.getContainer("main-header-logo-container", "main-header-logo-container-class");
				var imageConfig = {};
				var logoConfig = {};
				if (this.viewModel.get("IsSSP")) {
					imageConfig =
						this.getImageConfig("logoImage", ["main-header-logo-image"], this.getLogoImageConfig());
					logoConfig = this.applyLogoHintConfig(imageConfig);
					logoContainer.add(logoConfig);
				} else {
					imageConfig = this.getImageConfig("logoImage", ["main-header-logo-image", "cursor-pointer"],
						this.getLogoImageConfig(), "onLogoClick");
					logoConfig = this.applyLogoHintConfig(imageConfig);
					logoContainer.add(logoConfig);
				}
				this.setVisibleBinding(logoContainer, "IsLogoVisible");
				var leftHeaderContainer = this.getContainer("left-header-container", "left-header-container-class");
				var rightHeaderContainer = this.getContainer("right-header-container", "right-header-container-class");
				var rightImageContainer = this.getContainer("header-right-image-container",
					"context-right-image-class");
				leftHeaderContainer.add([
					menuLogoImageContainer,
					captionContainer,
					buttonsContainer,
					emptyContainer,
					commandLineContainer
				]);
				rightImageContainer.add([
					contextHelpContainer,
					systemDesignerContainer
				]);
				rightHeaderContainer.add([
					imageContainer,
					rightImageContainer,
					logoContainer
				]);
				return [
					leftHeaderContainer,
					rightHeaderContainer
				];
			},

			/**
			 * ########## ############ ######## ########## #########.
			 * @private
			 * @return {Object} ############ ######## ########## #########.
			 */
			generateCaption: function() {
				var caption = {
					className: "BPMSoft.Label",
					classes: {
						labelClass: ["header-section-caption-class", "cursor-pointer"]
					},
					caption: {
						bindTo: "HeaderCaption"
					},
					markerValue: {
						bindTo: "HeaderCaptionMarkerValue"
					},
					visible: {
						bindTo: "IsCaptionVisible"
					},
					click: {
						bindTo: "onCaptionClick"
					}
				};
				return caption;
			},

			/**
			 * ####### ############ ###### ############# # #######.
			 * @private
			 * @param {Object} config ################ ###### #############.
			 * @return {Object} ############ ######## ########## ############# # #######.
			 */
			createViewIconButtonConfig: createViewIconButtonConfig,

			/**
			 * ####### ################ ###### ###### ####### ############.
			 * @private
			 * @return {Object} ########## ################ ###### ###### ####### ############.
			 */
			getProfileButtonConfig: function() {
				var buttonConfig = {
					id: "profile-user-button",
					className: "BPMSoft.Button",
					selectors: {
						wrapEl: "#profile-user-button"
					},
					hint: resources.localizableStrings.ProfileImageButtonHintCaption,
					markerValue: "userProfileButton",
					imageConfig: {
						bindTo: "getContactPhoto"
					},
					menu: {
						items: {
							bindTo: "ProfileMenuCollection"
						},
						ulClass: "profile-menu"
					},
					style: this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
					iconAlign: this.BPMSoft.controls.ButtonEnums.iconAlign.LEFT,
					classes: {
						wrapperClass: ["photo-icon-wrapper"],
						imageClass: ["photo-icon"],
						markerClass: ["profile-photo-btn-marker-class"]
					}
				};
				return buttonConfig;
			},

			/**
			 * ######### ####### ######### # ##########.
			 * @private
			 * @param {Object} container ######### # ######## ########### #######.
			 * @param {String} modelItem ######## ######## ######.
			 */
			setVisibleBinding: function(container, modelItem) {
				container.bindings.visible = {
					config: {
						changeMethod: "setVisible"
					},
					modelItem: modelItem
				};
			},

			/**
			 * ########## ############ ######## ########## # ############.
			 * @private
			 * @param {String} name ############.
			 * @param {String} className ###### ######## ##########.
			 * @param {String} config ############ ###########.
			 * @param {String} click ### ######, ####### ######### ### #####.
			 * @return {Object} ############ ######## ########## # ############.
			 */
			getImageConfig: function(name, className, config, click) {
				if (!Ext.isArray(className) && !Ext.isEmpty(className)) {
					className = [className];
				}
				var imageUrl = this.getImageSrc(config);
				var imageConfig = {
					id: name,
					selectors: {
						wrapEl: "#" + name
					},
					className: "BPMSoft.ImageView",
					imageSrc: imageUrl,
					classes: {
						wrapClass: className
					}
				};
				if (click) {
					imageConfig.click = {
						bindTo: click
					};
				}
				return imageConfig;
			},

			/**
			 * ########## URL ###########.
			 * @private
			 * @param {Object} config
			 * @return {String} URL
			 */
			getImageSrc: function(config) {
				return this.BPMSoft.ImageUrlBuilder.getUrl(config);
			},

			/**
			 * ########## ############ ########### ########.
			 * @private
			 * @return {Object} ############ ###########.
			 */
			getLogoImageConfig: function() {
				return {
					params: {
						r: "HeaderLogoImage"
					},
					source: this.BPMSoft.ImageSources.SYS_SETTING
				};
			},

			/**
			 * ########## ############ ########### ########.
			 * @private
			 * @return {Object} ############ ########### ########.
			 */
			getMenuLogoImageConfig: function() {
				return {
					params: {
						r: "MenuLogoImage"
					},
					source: this.BPMSoft.ImageSources.SYS_SETTING
				};
			}
		});
		return BPMSoft.MainHeaderModule;
	});
