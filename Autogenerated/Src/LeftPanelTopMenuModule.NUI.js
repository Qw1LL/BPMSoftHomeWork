define("LeftPanelTopMenuModule", ["PortalClientConstants", "MainHeaderSchema", "LeftPanelTopMenuModuleResources", "LookupUtilities",
	"ConfigurationConstants", "LeftPanelUtilitiesV2", "HoverMenuButton",
	"CheckModuleDestroyMixin", "ProcessEntryPointUtilities", "MaskHelper", "ProcessModuleUtilities", "ServiceHelper", 
	"MainMenuUtilities"
], function(PortalConstants, MainHeaderSchema, resources, LookupUtilities, ConfigurationConstants, LeftPanelUtilities) {
	function createConstructor(context) {
		var Ext = context.Ext;
		var sandbox = context.sandbox;
		var BPMSoft = context.BPMSoft;

		/**
		 * Left panel top menu module view model.
		 */
		Ext.define("BPMSoft.LeftPanelTopMenuModuleViewModel", {
			extend: "BPMSoft.BaseViewModel",
			mixins: [
				"BPMSoft.CheckModuleDestroyMixin"
			],
			Ext: null,
			BPMSoft: null,
			sandbox: null,

			/**
			 * @inheritdoc BPMSoft.BaseViewModel#init
			 * @override
			 */
			init: function(callback, scope) {
				this.loadMenu();
				this.setSystemDesignerVisible();
				LeftPanelUtilities.on("collapsedChanged", this.onSideBarCollapsedChanged, this);
				this.set("Collapsed", LeftPanelUtilities.getCollapsed());
				callback.call(scope);
			},

			/**
			 * Sets based on the configuration of the property is responsible for the display panel buttons "System Designer".
			 * Responsible for showing and hiding "System Designer" button on the toolbar.
			 * @private
			 */
			setSystemDesignerVisible: function() {
				var isSystemDesignerVisible = !this.get("IsSSP");
				BPMSoft.SysSettings.querySysSettings(["BuildType"], function(sysSettings) {
					var buildType = sysSettings.BuildType;
					if (buildType && (buildType.value === ConfigurationConstants.BuildType.Public)) {
						isSystemDesignerVisible = false;
					}
					this.set("IsSystemDesignerVisible", isSystemDesignerVisible);
				}, this);
			},

			/**
			 * Returns main menu item config.
			 * @param {Object} entity Main menu lookup value.
			 * @return {Object} Main menu item config.
			 */
			getConfigMenuItem: function(entity) {
				var uId = entity.get("IntroPageUId");
				var name = entity.get("Name");
				var tag = entity.get("Tag");
				return {
					Id: uId,
					Caption: name,
					Tag: tag,
					Class: "menu-item",
					Click: {bindTo: "goToIntroPageFromMenu"},
					canExecute: {bindTo: "canBeDestroyed"}
				};
			},

			/**
			 * Fills the collection of the main menu items.
			 * @protected
			 */
			loadItemsMainMenu: function() {
				var cacheKey = "ApplicationMainMenu_TopPanel_Items";
				var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "ApplicationMainMenu",
					isDistinct: true,
					clientESQCacheParameters: {
						cacheItemName: cacheKey
					},
					serverESQCacheParameters: {
						cacheLevel: BPMSoft.ESQServerCacheLevels.SESSION,
						cacheGroup: "ApplicationMainMenu",
						cacheItemName: cacheKey
					}
				});
				esq.addColumn("Id");
				esq.addColumn("IntroPageUId");
				esq.addColumn("Name");
				esq.addColumn("[SysSchema:UId:IntroPageUId].Name", "Tag");
				esq.getEntityCollection(function(result) {
					if (!result.success) {
						return;
					}
					var menuCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					var entities = result.collection;
					var mainMenuConfig = {
						Id: "menu-menu-item",
						Tag: "MainMenu",
						Caption: resources.localizableStrings.mainManuMenuItemCaption,
						Visible: {
							bindTo: "IsSSP",
							bindConfig: {
								converter: function(value) {
									return !value;
								}
							}
						}
					};
					var entitiesCount = entities.getCount();
					if (entitiesCount === 0) {
						mainMenuConfig.Class = "menu-item";
						mainMenuConfig.Click = {bindTo: "goToFromMenu"};
						menuCollection.add(mainMenuConfig.Id, this.Ext.create("BPMSoft.BaseViewModel", {
							values: mainMenuConfig
						}));
					} else if (entitiesCount === 1) {
						entities.each(function(entity) {
							var menuItem = this.getConfigMenuItem(entity);
							menuItem.Caption = mainMenuConfig.Caption;
							menuCollection.add(menuItem.Id, this.Ext.create("BPMSoft.BaseViewModel", {
								values: menuItem
							}));
						}, this);
					} else {
						mainMenuConfig.Type = "BPMSoft.MenuSeparator";
						menuCollection.add(mainMenuConfig.Id, this.Ext.create("BPMSoft.BaseViewModel", {
							values: mainMenuConfig
						}));
						entities.each(function(entity) {
							var menuItem = this.getConfigMenuItem(entity);
							menuCollection.add(menuItem.Id, this.Ext.create("BPMSoft.BaseViewModel", {
								values: menuItem
							}));
						}, this);
						var id = "end-menu-menu-item";
						menuCollection.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
							values: {
								Id: id,
								Type: "BPMSoft.MenuSeparator"
							}
						}));
					}
					var mainMenuItems = this.get("MainMenuItems");
					menuCollection.loadAll(mainMenuItems);
					mainMenuItems.clear();
					mainMenuItems.loadAll(menuCollection);
				}, this);
			},

			/**
			 * Loads quick add menu items.
			 * @protected
			 */
			loadItemsQuickAddMenu: function() {
				var collection = this.get("quickAddMenu");
				collection.clear();
				var quickItems = BPMSoft.configuration.QuickAddMenu.QuickAddMenu;
				BPMSoft.each(quickItems, function(item) {
					var id = item.itemId;
					collection.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
						values: this.getItemQuickAddMenuConfig(id, item)
					}));
				}, this);
			},

			/**
			 * Gets config of the quick add menu item.
			 * @private
			 * @param {String} id Item id name.
			 * @param {Object} item
			 * @return {Object} Config of the quick add menu item.
			 */
			getItemQuickAddMenuConfig: function(id, item) {
				var config = item.hasAddMiniPage ? {} : {
					canExecute: {"bindTo": "canBeDestroyed"}
				};
				this.Ext.apply(config, {
					Id: id,
					Caption: item.name,
					Click: {bindTo: "processQuickMenuClick"},
					ModuleName: item.ModuleName,
					Tag: id,
					TypeColumnName: item.TypeColumnName,
					TypeColumnValue: item.TypeColumnValue,
					EditPageName: item.EditPageName,
					EntitySchemaName: item.EntitySchemaName,
					MiniPage: {
						schemaName: item.miniPageSchema,
						hasAddMiniPage: item.hasAddMiniPage
					}
				});
				return config;
			},

			/**
			 * Processes quick add menu item click.
			 * @protected
			 * @param {String} tag Tag value of quick add menu item.
			 */
			processQuickMenuClick: function(tag) {
				var collection = this.get("quickAddMenu");
				var quickMenuItem = collection.get(tag);
				var moduleName = quickMenuItem.get("ModuleName") || "SysModuleEditManageModule";
				require([moduleName], function(module) {
					if (module) {
						module.Run({
							sandbox: sandbox,
							item: quickMenuItem
						});
					}
				});
			},

			/**
			 * Return menu item view model.
			 * @private
			 * @param {Object} modelConfig Configuration object.
			 **/
			_createMenuItem: function(modelConfig) {
				return this.Ext.create("BPMSoft.BaseViewModel", {
					values: modelConfig
				});
			},

			/**
			 * Fills caption to "Run process" menu.
			 * @private
			 * @param {BPMSoft.Collection} startProcessMenuItems Menu items collection.
			 */
			_fillCaptionMenuItem: function(startProcessMenuItems) {
				var id = "caption-runprocess-menu-item";
				var modelConfig = {
					Id: id,
					Type: "BPMSoft.MenuSeparator",
					Caption: resources.localizableStrings.RunProcessButtonMenuCaption
				};
				startProcessMenuItems.add(id, this._createMenuItem(modelConfig));
			},

			/**
			 * Fills process record item to "Run process" menu.
			 * @private
			 * @param {BPMSoft.Collection} startProcessMenuItems Menu items collection.
			 * @param {String} id Item id.
			 * @param {String} caption Item caption.
			 */
			_fillRunProcessMenuItem: function(startProcessMenuItems, id, caption) {
				var modelConfig = {
					Id: id,
					Caption: caption,
					Click: {bindTo: "runProcess"},
					canExecute: {bindTo: "canBeDestroyed"},
					Tag: id,
					MarkerValue: caption
				};
				startProcessMenuItems.add(id, this._createMenuItem(modelConfig));
			},

			/**
			 * Fills separator to "Run process" menu.
			 * @private
			 * @param {BPMSoft.Collection} startProcessMenuItems Menu items collection.
			 */
			_fillSeparatorMenuItem: function(startProcessMenuItems) {
				var id = "separator-runprocess-menu-item";
				var modelConfig = {
					Id: id,
					Type: "BPMSoft.MenuSeparator"
				};
				startProcessMenuItems.add(id, this._createMenuItem(modelConfig));
			},

			/**
			 * Fills "open process page" item to "Run process" menu.
			 * @private
			 * @param {BPMSoft.Collection} startProcessMenuItems Menu items collection.
			 */
			_fillOpenProcessPageMenuItem: function(startProcessMenuItems) {
				var id = "open-process-page";
				var modelConfig = {
					Id: id,
					Caption: resources.localizableStrings.AnotherProcessMenuItemCaption,
					Click: {bindTo: "openProcessPage"},
					Tag: id
				};
				startProcessMenuItems.add(id, this._createMenuItem(modelConfig));
			},

			/**
			 * Returned clear startProcessMenu collection.
			 * @private
			 * @return {BPMSoft.Collection} Start process menu items.
			 */
			_getClearedStartProcessMenuItems: function() {
				var startProcessMenuItems = this.get("startProcessMenu");
				startProcessMenuItems.clear();
				return startProcessMenuItems;
			},

			/**
			 * Fills the collection menus global business process start button.
			 */
			loadItemsStartProcessMenu: function() {
				BPMSoft.ProcessModuleUtilities.getQuickStartProcessList(function (success, processes) {
					if (!success){
						throw new BPMSoft.QueryExecutionException();
					}
					const menuItems = this._getClearedStartProcessMenuItems();
					if (!BPMSoft.isEmpty(processes)){
						this._fillCaptionMenuItem(menuItems);
						BPMSoft.each(processes, function (process){
							this._fillRunProcessMenuItem(menuItems, process.id, process.caption);
						}, this);
						this._fillSeparatorMenuItem(menuItems);
						this._fillOpenProcessPageMenuItem(menuItems);
					}
					this.sandbox.publish("LoadedItemsStartProcessMenu");
				}, this);
			},

			/**
			 * Returns view config.
			 * @return {Object} View config.
			 */
			getViewConfig: function() {
				var view = {
					id: "side-bar-top-menu-module-container",
					selectors: {
						wrapEl: "#side-bar-top-menu-module-container"
					},
					classes: {
						wrapClassName: ["top-menu-module-container"]
					},
					items: this.getTopMenuConfig()
				};
				return view;
			},

			/**
			 * Returns menu object.
			 * @return {Object}
			 */
			loadMenu: function() {
				this.loadItemsStartProcessMenu();
				this.sandbox.subscribe("ResetStartProcessMenuItems", function() {
					this.loadItemsStartProcessMenu();
				}, this);
				this.loadItemsQuickAddMenu();
				var menuCollection = this.Ext.create("BPMSoft.BaseViewModelCollection");
				var id = "process-menu-item";
				menuCollection.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: id,
						Tag: "ProcessExecute",
						Caption: resources.localizableStrings.processMenuItemCaption,
						Click: {bindTo: "openProcessPage"},
						Visible: {
							bindTo: "IsSSP",
							bindConfig: {
								converter: function(value) {
									return !value;
								}
							}
						}
					}
				}));
				id = "collapse-menu-item";
				menuCollection.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: id,
						Tag: "CollapseMenu",
						Caption: this.getCollapseSideBarMenuItemCaptionConfig(),
						Click: {bindTo: "collapseSideBar"}
					}
				}));
				var workplaceMenu = this.getWorkplaceMenu();
				if (workplaceMenu.getCount() > 0) {
					menuCollection.loadAll(workplaceMenu);
				}
				id = "system-designer-menu-item";
				menuCollection.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: id,
						Tag: "IntroPage/SystemDesigner",
						Caption: resources.localizableStrings.systemDesignerMenuItemCaption,
						Click: {bindTo: "goToFromMenu"},
						Visible: {bindTo: "IsSystemDesignerVisible"},
						canExecute: {bindTo: "canBeDestroyed"}
					}
				}));
				id = "profile-menu-item";
				menuCollection.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: id,
						Tag: "UserProfile",
						Caption: resources.localizableStrings.userProfileMenuItemCaption,
						Click: {bindTo: "goToFromMenu"},
						canExecute: {bindTo: "canBeDestroyed"}
					}
				}));
				id = "exit-menu-item";
				menuCollection.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
					values: {
						Id: id,
						Tag: "Exit",
						ClassName: "BPMSoft.MenuItem",
						Caption: resources.localizableStrings.exitMenuItemCaption,
						Click: {bindTo: "exitClick"},
						canExecute: {bindTo: "canBeDestroyed"}
					}
				}));
				var mainMenuItems = this.get("MainMenuItems");
				mainMenuItems.loadAll(menuCollection);
				this.loadItemsMainMenu();
			},

			/**
			 * Returns collection of workplace models for workplace menu.
			 * @return {BPMSoft.BaseViewModelCollection} Workplace models collection.
			 */
			getWorkplaceMenu: function() {
				var workplaceMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
				var workplaces = BPMSoft.deepClone(
					BPMSoft.configuration.WorkplacesStructure.Workplaces);
				if (workplaces.length > 0) {
					var id = "separator-top-menu-item";
					workplaceMenuItems.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Id: id,
							Type: "BPMSoft.MenuSeparator",
							Caption: resources.localizableStrings.workPlaceMenuItemCaption
						}
					}));
					workplaces.sort(function(a, b) {
						if (a.name < b.name) {
							return -1;
						}
						if (a.name > b.name) {
							return 1;
						}
						return 0;
					});
					BPMSoft.each(workplaces, function(item) {
						if (item.hide) {
							return;
						}
						var menuItemConfig = {
							Caption: item.name,
							Tag: item.workplaceId,
							Click: {
								bindTo: "workPlaceMenuItemClick"
							},
							Id: "workspace-" + BPMSoft.formatGUID(item.workplaceId, "N") + "-menu-item"
						};
						workplaceMenuItems.add(this.Ext.create("BPMSoft.BaseViewModel", {
							values: menuItemConfig
						}));
					}, this);
					id = "separator-botom-menu-item";
					workplaceMenuItems.add(id, this.Ext.create("BPMSoft.BaseViewModel", {
						values: {
							Id: id,
							Type: "BPMSoft.MenuSeparator"
						}
					}));
				}
				return workplaceMenuItems;
			},

			/**
			 * Returns the top menu configuration.
			 * @return {Object}
			 */
			getTopMenuConfig: function() {
				var menuConfig = [
					{
						id: "collapse-button",
						tag: "CollapseMenu",
						className: "BPMSoft.HoverMenuButton",
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						classes: {
							imageClass: ["button-image-size"],
							wrapperClass: ["collapse-button-wrapperEl"]
						},
						imageConfig: resources.localizableImages.collapseIconSvg,
						click: {
							bindTo: "collapseSideBar"
						},
						hint: this.getCollapseSideBarMenuItemCaptionConfig(),
						markerValue: this.getCollapseSideBarMenuItemCaptionConfig()
					},
					{
						id: "menu-button",
						tag: "MainMenu",
						className: "BPMSoft.HoverMenuButton",
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						hint: {bindTo: "getMenuButtonHint"},
						markerValue: "MainMenu",
						classes: {
							imageClass: ["button-image-size"],
							wrapperClass: ["menu-button-wrapperEl"]
						},
						imageConfig: resources.localizableImages.menuIconSvg,
						menu: {
							items: {bindTo: "MainMenuItems"},
							"alignType": "tr?",
							"ulClass": "position-fixed"
						},
						delayedShowEnabled: {
							bindTo: "Collapsed"
						},
						showDelay: this.get("ShowDelay"),
						hideDelay: this.get("HideDelay")
					},
					{
						id: "menu-startprocess-button",
						tag: "StartProcessMenu",
						className: "BPMSoft.HoverMenuButton",
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						hint: {bindTo: "getStartProcessMenuButtonHint"},
						markerValue: "StartProcessMenu",
						classes: {
							imageClass: ["button-image-size"],
							wrapperClass: ["menu-startprocess-button-wrapperEl"]
						},
						imageConfig: resources.localizableImages.processIconSvg,
						menu: {
							items: {bindTo: "startProcessMenu"},
							"alignType": "tr?",
							"ulClass": "position-fixed"
						},
						click: {
							bindTo: "startProcessMenuButtonClick"
						},
						visible: {
							bindTo: "IsSSP",
							bindConfig: {
								converter: function(value) {
									return !value;
								}
							}
						},
						delayedShowEnabled: {
							bindTo: "Collapsed"
						},
						showDelay: this.get("ShowDelay"),
						hideDelay: this.get("HideDelay")
					},
					{
						id: "menu-quickadd-button",
						tag: "quickAddMenu",
						className: "BPMSoft.HoverMenuButton",
						style: BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						classes: {
							imageClass: ["button-image-size"],
							wrapperClass: ["menu-quickadd-button-wrapperEl"]
						},
						hint: {
							bindTo: "getQuickAddHint"
						},
						markerValue: resources.localizableStrings.AddButtonHint,
						imageConfig: resources.localizableImages.quickaddIconSvg,
						menu: {
							items: {bindTo: "quickAddMenu"},
							"alignType": "tr?",
							"ulClass": "position-fixed"
						},
						visible: {
							bindTo: "IsSSP",
							bindConfig: {
								converter: function(value) {
									return !value;
								}
							}
						},
						delayedShowEnabled: {
							bindTo: "Collapsed"
						},
						showDelay: this.get("ShowDelay"),
						hideDelay: this.get("HideDelay")
					}
				];
				return menuConfig;
			},

			/**
			 * Handles start process button click.
			 * @protected
			 * @return {boolean} Returns false for preventing default click handler.
			 */
			startProcessMenuButtonClick: function() {
				var startProcessMenu = this.get("startProcessMenu");
				if (startProcessMenu.getCount() > 0) {
					return false;
				}
				this.openProcessPage();
			},

			/**
			 * Returns quick add menu button hint.
			 * @return {String} Quick add menu button hint text.
			 */
			getQuickAddHint: function() {
				return this.getHint(resources.localizableStrings.AddButtonHint);
			},

			/**
			 * Returns start process menu button hint.
			 * @return {String} Start process menu button hint text.
			 */
			getStartProcessMenuButtonHint: function() {
				return this.getHint(resources.localizableStrings.StartProcessButtonHint);
			},

			/**
			 * Returns menu button hint.
			 * @return {String} Menu button hint text.
			 */
			getMenuButtonHint: function() {
				return this.getHint(resources.localizableStrings.MenuButtonHint);
			},

			/**
			 * Returns hint text.
			 * When left panel state is collapsed, returns null.
			 * @param {String} hint Hint text.
			 * @return {String|null} Hint text.
			 */
			getHint: function(hint) {
				var collapsed = this.get("Collapsed");
				if (!collapsed) {
					return hint;
				}
				return null;
			},

			/**
			 * Returns the configuration of the switching element collapsed left panel.
			 * @return {Object}
			 */
			getCollapseSideBarMenuItemCaptionConfig: function() {
				return {
					bindTo: "Collapsed",
					bindConfig: {
						converter: this.getCollapseSideBarMenuItemCaption
					}
				};
			},

			/**
			 * Run the business process from the list of global processes start button.
			 * @param {Object} tag UId business Process diagrams.
			 */
			runProcess: function(tag) {
				BPMSoft.ProcessModuleUtilities.executeProcess({
					sysProcessId: tag
				});
			},

			goTo: function() {
				var tag = arguments[3];
				var currentModule = this.sandbox.publish("GetHistoryState").hash.historyState;
				if (currentModule !== tag) {
					BPMSoft.MaskHelper.ShowBodyMask();
					this.sandbox.publish("PushHistoryState", {hash: tag});
				}
			},

			/**
			 * @deprecated
			 */
			replaceWindowLocation: function(location) {
				window.location.replace(location);
			},

			/**
			 * Handles exit menu item click.
			 * @private
			 */
			exitClick: async function() {
				await BPMSoft.MainMenuUtilities.logout();
			},

			openUserProfilePage: function() {
				const path = this.BPMSoft.combinePath("CardModuleV2",
					PortalConstants.DesignerPagesName.ProfileContactPageSchema, "edit",
					BPMSoft.SysValue.CURRENT_USER_CONTACT.value);
				const historyStateConfig = {hash: path};
				this.sandbox.publish("PushHistoryState", historyStateConfig);
			},

			goToFromMenu: function(tag) {
				const isSsp = BPMSoft.isCurrentUserSsp();

				if (tag === "UserProfile" && isSsp) {
					this.openUserProfilePage();
					return;
				}

				var currentHistoryState = this.sandbox.publish("GetHistoryState").hash.historyState;
				if (currentHistoryState !== tag) {
					BPMSoft.Mask.show();
					this.sandbox.publish("PushHistoryState", {hash: tag});
				}
			},

			goToIntroPageFromMenu: function(tag) {
				var currentHistoryState = this.sandbox.publish("GetHistoryState").hash.historyState;
				if (currentHistoryState !== tag) {
					var hash = "IntroPage/" + tag;
					this.sandbox.publish("PushHistoryState", {hash: hash});
				}
			},

			openProcessPage: function() {
				BPMSoft.ProcessModuleUtilities.showStartProcessPage(this.sandbox,
					resources.localizableStrings.processLookupCaption);
			},

			collapseSideBar: function() {
				LeftPanelUtilities.changeCollapsed();
			},

			showESN: function() {
				var esnHash = "SectionModuleV2/ESNFeedSectionV2/";
				var currentModule = this.sandbox.publish("GetHistoryState").hash.historyState;
				if (currentModule !== esnHash) {
					BPMSoft.MaskHelper.ShowBodyMask();
					this.sandbox.publish("PushHistoryState", {hash: esnHash});
				}
			},

			/**
			 * Returns the text for the switching element folding left panel.
			 * @param {Boolean} isCollapsed Collapsed flag.
			 * @return {String} The text for the switching element folding left panel.
			 */
			getCollapseSideBarMenuItemCaption: function(isCollapsed) {
				if (this.Ext.isEmpty(isCollapsed)) {
					isCollapsed = LeftPanelUtilities.getDefaultCollapsed();
				}
				if (isCollapsed) {
					return resources.localizableStrings.expandSideBarMenuItemCaption;
				} else {
					return resources.localizableStrings.collapseSideBarMenuItemCaption;
				}
			},

			workPlaceMenuItemClick: function(tag) {
				var workplaceItem = this.getWorkplaceData(tag);
				if (workplaceItem) {
					this.sandbox.publish("ChangeCurrentWorkplace", tag);
				}
			},

			getWorkplaceData: function(workplaceId) {
				var workplaces = BPMSoft.configuration.WorkplacesStructure.Workplaces;
				var workplaceItem = null;
				if (workplaces.length > 0) {
					BPMSoft.each(workplaces, function(item) {
						if (item.workplaceId === workplaceId) {
							workplaceItem = item;
						}
					}, this);
				}
				return workplaceItem;
			},

			/**
			 * Handler of the changes Hide left panel.
			 * @param {Boolean} isCollapsed Collapsed attribute.
			 */
			onSideBarCollapsedChanged: function(isCollapsed) {
				this.sandbox.publish("ChangeSideBarCollapsed", isCollapsed);
				this.set("Collapsed", isCollapsed);
				this.sandbox.publish("ChangeGridUtilitiesContainerSize");
			}

		});

		Ext.define("BPMSoft.configuration.LeftPanelTopMenuModule", {
			extend: "BPMSoft.BaseModule",
			isAsync: false,
			viewModel: null,
			viewModelClassName: "BPMSoft.LeftPanelTopMenuModuleViewModel",

			render: function(renderTo) {
				this.generate(renderTo);
			},

			init: function(callback, scope) {
				var viewModel = this.viewModel = this.getViewModel();
				callback = callback || Ext.emptyFn;
				scope = scope || this;
				viewModel.init(function() {
					callback.call(scope);
				}, this);
			},

			getViewModel: function() {
				return Ext.create(this.viewModelClassName, {
					BPMSoft: BPMSoft,
					Ext: Ext,
					sandbox: sandbox,
					values: {
						Collapsed: false,
						quickAddMenu: Ext.create("BPMSoft.BaseViewModelCollection"),
						startProcessMenu: Ext.create("BPMSoft.BaseViewModelCollection"),
						MainMenuItems: Ext.create("BPMSoft.BaseViewModelCollection"),
						IsSystemDesignerVisible: true,
						IsSSP: BPMSoft.isCurrentUserSsp(),
						ShowDelay: 0,
						HideDelay: 20
					}
				});
			},

			generate: function(container) {
				var viewModel = this.viewModel;
				var view = this.view;
				if (!Ext.isEmpty(viewModel) && !Ext.isEmpty(view)) {
					view.destroy();
				}
				var viewConfig = viewModel.getViewConfig();
				view = Ext.create("BPMSoft.Container", BPMSoft.deepClone(viewConfig));
				view.bind(viewModel);
				view.render(container);
				BPMSoft.MaskHelper.HideBodyMask();
			}
		});

		return BPMSoft.configuration.LeftPanelTopMenuModule;
	}

	return createConstructor;
});
