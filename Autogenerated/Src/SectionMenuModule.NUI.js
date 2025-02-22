﻿define("SectionMenuModule", ["SectionMenuModuleResources", "ModuleUtils", "MaskHelper", "LeftPanelUtilitiesV2", "CheckModuleDestroyMixin"],
	function(resources, ModuleUtils, MaskHelper, LeftPanelUtilities) {
		function createConstructor(context) {
			var sideBar;
			var sideBarConfig;
			var viewModel;
			var Ext = context.Ext;
			var sandbox = context.sandbox;
			var BPMSoft = context.BPMSoft;
			var info;
			var pages;
			var currentSelection = null;

			var getSideBarItems = function() {
				var config = [];
				var moduleStructure = BPMSoft.configuration.ModuleStructure;
				var modules = info && info.modules ? info.modules : Object.keys(moduleStructure);
				if (!modules) {
					return;
				}
				setSideBarHomePage(config);
				var availableSections = info.AvailableSections;
				var defaultIconUrl = BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.DefaultIconSvg);
				modules.forEach(function(module) {
					if (module.moduleId !== BPMSoft.GUID_EMPTY) {
						var moduleName = module.moduleName ? module.moduleName : module;
						var moduleConfig = moduleStructure[moduleName];
						if (moduleConfig.hide !== "true") {
							if (!Ext.isArray(availableSections) || availableSections.indexOf(moduleName) >= 0) {
								var caption = moduleStructure[moduleName].moduleCaption;
								var tag = ModuleUtils.getModuleTag(moduleName);
								var imageId = moduleStructure[moduleName].imageId;
								var imageUrl = imageId ? getImageUrl(imageId) : defaultIconUrl;
								var itemUrl = BPMSoft.workspaceBaseUrl + "/Nui/ViewModule.aspx#" + tag;
								var itemConfig = {
									caption: caption,
									tag: tag,
									imageUrl: imageUrl,
									href: itemUrl,
									domAttributes: {"module-name": module.moduleName}
								};
								if (!BPMSoft.Features.getIsEnabled("SectionMenuLink")) {
									itemConfig.href = null;
								}
								config.push(itemConfig);
							}
						}
					}
				});
				return config;
			};
			
			const isHomePageAngularSchema = function() {
				return info?.homePageSchemaName &&
					BPMSoft.ServerSchemaType[info?.homePageSchemaType] === BPMSoft.SchemaType.ANGULAR_SCHEMA;
			};

			const setSideBarHomePage = function(config) {
				if (BPMSoft.Features.getIsEnabled('DisableHomePageInWorkplace')) {
					return;
				}
				if (isHomePageAngularSchema()) {
					config.push({
						caption: resources.localizableStrings.HomePageTitle,
						domAttributes: {"module-name": "HomePage"},
						imageUrl: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.HomePageSidebarImage),
						tag: "HomePage/" + info?.homePageSchemaName
					});
				} else if (info?.homePageSchemaName) {
					config.push({
						caption: resources.localizableStrings.HomePageTitle,
						domAttributes: {"module-name": "IntroPage"},
						imageUrl: BPMSoft.ImageUrlBuilder.getUrl(resources.localizableImages.HomePageSidebarImage),
						tag: "IntroPage/" + info?.homePageSchemaName,
					});
				}
			};

			var initViewModel = function() {
				Ext.define("BPMSoft.configuration.SectionMenuBaseViewModel", {
					extend: "BPMSoft.BaseViewModel",
					mixins: [
						"BPMSoft.CheckModuleDestroyMixin"
					],
					sandbox: null,
					BPMSoft: null,
					Ext: null
				});
				viewModel = this.viewModel = Ext.create("BPMSoft.configuration.SectionMenuBaseViewModel", {
					values: {
						Collapsed: false
					},
					methods: {
						/**
						 * @inheritdoc BPMSoft.BaseViewModel#init
						 * @overridden
						 */
						init: function(callback, scope) {
							LeftPanelUtilities.on("collapsedChanged", this.onSideBarCollapsedChanged, this);
							this.set("Collapsed", LeftPanelUtilities.getCollapsed());
							callback.call(scope);
						},

						/**
						 * On sidebar collapsed attribute changed handler.
						 * @param {Boolean} isCollapsed Value of collapsed state.
						 */
						onSideBarCollapsedChanged: function(isCollapsed) {
							this.set("Collapsed", isCollapsed);
						},

						/**
						 * On sidebar item selected handler.
						 * Loads selected section.
						 * @param {Number} item Selected item index.
						 * @param {String} tag Selected item tag.
						 */
						onSidebarItemSelected: function(item, tag) {
							var histroyState = sandbox.publish("GetHistoryState");
							var currentModule = histroyState.hash.historyState;
							var state = histroyState.state;
							var isInChainModule = currentModule === tag && state.isInChain;
							if (isInChainModule) {
								sandbox.publish("BackHistoryState");
							}
							if (currentModule !== tag) {
								MaskHelper.ShowBodyMask();
								sandbox.publish("PushHistoryState", {hash: tag});
							}
						},
						/**
						 * Returns dom attributes.
						 * @return {{collapsed: Boolean}}
						 */
						getDomAttributes: function() {
							return {collapsed: this.get("Collapsed")}
						}
					},
					sandbox: sandbox,
					BPMSoft: BPMSoft,
					Ext: Ext
				});
			};

			/*
			 * Returns tips array generated for passed sidebar items.
			 * @param {Array} items Array of sidebar item configs.
			 * @return {Array} Tips.
			 */
			var getSidebarTips = function(items) {
				var tips = [];
				BPMSoft.each(items, function(item) {
					tips.push({
						tip: {
							content: item.caption,
							displayMode: BPMSoft.controls.TipEnums.displayMode.NARROW,
							tag: item.tag,
							markerValue: item.caption
						},
						settings: {
							alignEl: "getItemImageEl"
						}
					});
				});
				return tips;
			};

			var getImageUrl = function(imageId) {
				var imageConfig = {
					source: BPMSoft.ImageSources.SYS_IMAGE,
					params: {
						primaryColumnValue: imageId
					}
				};
				var imageUrl = BPMSoft.ImageUrlBuilder.getUrl(imageConfig);
				return imageUrl;
			};

			function onHistoryStateChanged(token, silent) {
				if (!sideBar) {
					return;
				}
				var currentState = sandbox.publish("GetHistoryState");
				var moduleName = token.hash ? token.hash.moduleName : null;
				var entityName = token.hash ? token.hash.entityName : null;
				var oldOperationType = currentState.hash.operationType;
				if (entityName) {
					entityName = moduleName + "/" + findCurrentSection(entityName, oldOperationType) + "/";
				} else {
					entityName = moduleName + "/";
				}
				onSelectedSideBarItemChanged(entityName, silent);
			}

			function findCurrentSection(entityName, oldOperationType) {
				for (var i = 0; i < pages.length; i += 1) {
					for (var j = 0; j < pages[i].length; j += 1) {
						if (entityName === pages[i][j]) {
							entityName = pages[i][0];
							return entityName;
						}
					}
				}
				if (entityName.search("Page") !== -1) {
					entityName = entityName.replace("Page", "Section");
				} else {
					if (oldOperationType) {
						entityName = oldOperationType + "Section";
					}
				}
				return entityName;
			}

			function findAllSections() {
				var arr = [];
				var isCreated;
				var sections = BPMSoft.configuration.ModuleStructure;
				var entityStructure;
				for (var i in sections) {
					isCreated = false;
					entityStructure = BPMSoft.configuration.EntityStructure[i] || sections[i].pages;
					var pages = entityStructure ? entityStructure.pages : null;
					if (pages) {
						for (var j = 0; j < pages.length; j += 1) {
							if (pages[j].cardSchema) {
								if (!isCreated) {
									arr[arr.length] = [];
									arr[arr.length - 1][0] = sections[i].sectionSchema;
									isCreated = true;
								}
								arr[arr.length - 1][arr[arr.length - 1].length] = pages[j].cardSchema;
							}
						}
					}
				}
				return arr;
			}

			/**
			 * PostSectionMenuConfig message handler.
			 * Initializes sidebar module config.
			 * @param {BPMSoft.Collection} args List of section items.
			 */
			function onPostSectionMenuConfig(args) {
				info = args;
				var items = getSideBarItems();
				var tips = getSidebarTips(items);
				var index = 0;
				var selectedItemIndex = -1;
				const { loadFirstModule } = args;
				BPMSoft.each(items, function(item) {
					if (item.tag === currentSelection) {
						selectedItemIndex = index;
						return;
					}
					index++;
				});
				sideBarConfig = {
					items: items,
					selectedItemIndex: loadFirstModule && items.length ? 0: selectedItemIndex,
					tips: tips,
					collapsed: {
						"bindTo": "Collapsed"
					},
					canExecute: {
						"bindTo": "canBeDestroyed"
					},
					domAttributes: {
						"bindTo": "getDomAttributes"
					}
				};
				if (!BPMSoft.Features.getIsEnabled("SectionMenuLink")) {
					sideBarConfig.itemSelected = {
						bindTo: "onSidebarItemSelected"
					};
				}
			}

			/**
			 * Loads first module from sidebar config.
			 */
			function loadFirstModule() {
				BPMSoft.defer(() => {
					viewModel.onSidebarItemSelected(0, sideBarConfig.items[0]?.tag);
				});
			}

			function init(callback, scope) {
				MaskHelper.ShowBodyMask();
				initViewModel.call(this);
				callback = callback || Ext.emptyFn;
				scope = scope || this;
				pages = findAllSections();
				sandbox.subscribe("FocusCorrectSideBar", function() {
					correctFocusSideBar();
				});
				sandbox.subscribe("SelectedSideBarItemChanged", onSelectedSideBarItemChanged, [sandbox.id]);
				sandbox.subscribe("PostSectionMenuConfig", function(args) {
					onPostSectionMenuConfig(args);
					if (args.loadFirstModule && sideBarConfig?.items?.length) {
						loadFirstModule();
					}
					viewModel.init(function() {
						callback.call(scope);
					}, this);
				}, [sandbox.id, "SectionMenuModuleId"]);
				sandbox.publish("GetSectionMenuInfo", sandbox.id);
				var token = sandbox.publish("GetHistoryState");
				if (token) {
					onHistoryStateChanged(token, true);
				}
			}

			var render = function(renderTo) {
				if (!Ext.isEmpty(viewModel) && !Ext.isEmpty(sideBar)) {
					sideBar.destroy();
				}
				sideBar = Ext.create("BPMSoft.SideBar", BPMSoft.deepClone(sideBarConfig));
				sideBar.bind(viewModel);
				sideBar.render(renderTo);
				MaskHelper.HideBodyMask();
			};

			function correctFocusSideBar() {
				var currentState = sandbox.publish("GetHistoryState");
				var sectionName = currentState.hash.moduleName + "/" +
					currentState.hash.entityName.replace("Page", "Section") + "/";
				onSelectedSideBarItemChanged(sectionName);
			}

			function onSelectedSideBarItemChanged(item, silent) {
				currentSelection = item;
				if (sideBar) {
					var index = 0;
					sideBar.setSelectedItem();
					BPMSoft.each(sideBar.items, function(sideBarItem) {
						if (compareSideBarItemTag(sideBarItem.tag, item)) {
							sideBar.setSelectedItem(index);
							var config = {
								caption: sideBarItem.caption
							};
							if (silent !== true) {
								sandbox.publish("SectionChanged", config);
							}
							return true;
						}
						index++;
					});
				}
			}

			/**
			 * Compares value of the selected item tag from left panel with value of the tag from hash.
			 * @param {String} itemTag Tag of the element from sidebar.
			 * @param {String} tag Tag from hash.
			 * @return {Boolean} Are tags equal.
			 */
			function compareSideBarItemTag(itemTag, tag) {
				if (itemTag === tag) {
					return true;
				}
				var tagItems = tag.split("/");
				if (tagItems.length > 2 && tagItems[1].indexOf("Section") > 0) {
					var sidebarTagItems = itemTag.split("/");
					if (sidebarTagItems.length > 2 && sidebarTagItems[1] === tagItems[1]) {
						return true;
					}
				}
				return false;
			}

			return Ext.define("BPMSoft.configuration.SectionMenuModule", {
				extend: "BPMSoft.BaseModule",
				isAsync: true,
				viewModel: null,
				init: init,
				render: render
			});
		}

		return createConstructor;
	});
