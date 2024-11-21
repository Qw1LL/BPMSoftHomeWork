define("DashboardModule", ["ext-base", "DashboardModuleResources", "BaseNestedModule", "DashboardEnums"],
	function(ext, resources) {

		/**
		 * @class BPMSoft.configuration.BaseDashboardViewModel
		 * Class of view model of dashboard module.
		 */
		Ext.define("BPMSoft.configuration.BaseDashboardViewModel", {
			extend: "BPMSoft.BaseModel",
			alternateClassName: "BPMSoft.BaseDashboardViewModel",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			
			/**
			 * @private
			 */
			_loadedDashboardsModulesIds: null,
			
			/**
			 * @private
			 */
			_scrollHandlerDelay: 200,
			
			/**
			 * @private
			 */
			_debounceWindowScroll: null,

			/**
			 * @inheritdoc BPMSoft.BaseModel#constructor
			 * @overridden
			 */
			constructor: function() {
				this.callParent(arguments);
				this.initResourcesValues(resources);
				this._loadedDashboardsModulesIds = [];
			},

			/**
			 * Initialize view model by values of resources.
			 * @protected
			 * @virtual
			 * @param {Object} resourcesObj Object of resources.
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
			 * Loads the dashboards.
			 * @protected
			 * @virtual
			 */
			loadNestedModule: function() {
				this.iterateDashboardModules(function(moduleId, moduleConfig) {
					if (this.isDashboardLoaded(moduleId)) {
						return;
					}
					const isDashboardVisible = this.isDashboardElementInViewPort(moduleConfig.renderTo);
					if (!isDashboardVisible) {
						return;
					}
					this.loadDashboardModule(moduleId, moduleConfig);
				}, this);
			},

			/**
			 * Returns true when dashboard is loaded.
			 * @protected
			 * @param {String} dashboardModuleId Dashboard module id.
			 * @returns {Boolean} Is dashboard loaded.
			 */
			isDashboardLoaded: function(dashboardModuleId) {
				return BPMSoft.contains(this._loadedDashboardsModulesIds, dashboardModuleId);
			},
			
			/**
			 * Loads dashboard module.
			 * @protected
			 * @param {String} moduleId Dashboard module id.
			 * @param {Object} moduleConfig Dashboard module config.
			 * @param {String} moduleConfig.moduleName Dashboard module name.
			 * @param {String} moduleConfig.renderTo Dashboard module renderTo element id.
			 */
			loadDashboardModule: function(moduleId, moduleConfig) {
				this.sandbox.loadModule(moduleConfig.moduleName, {
					renderTo: moduleConfig.renderTo,
					id: moduleId
				});
				this._loadedDashboardsModulesIds.push(moduleId);
			},
			
			/**
			 * Checks is dashboard element is visible in viewport.
			 * @protected
			 * @param {String} elementId Dashboard parent container id.
			 * @returns {Boolean} Is dashboard in viewport.
			 */
			isDashboardElementInViewPort: function(elementId) {
				const selector = Ext.String.format("#{0}", elementId);
				return BPMSoft.isElementInViewport(selector);
			},

			/**
			 * Calls the iterator function for dashboards items.
			 * @param {Function} iterateFunction Iterator function.
			 * @param {Object} scope The context of the function.
			 */
			iterateDashboardModules: function(iterateFunction, scope) {
				if (!this.Ext.isFunction(iterateFunction)) {
					return;
				}
				var dashboards = this.getDashboards();
				dashboards.each(function(dashboard) {
					var modulesConfig = dashboard.getVisibleItems();
					this.BPMSoft.each(modulesConfig, function(moduleConfig, renderTo) {
						var config = this.getNestedModuleConfig(moduleConfig);
						var moduleId = this.getModuleId(renderTo, config);
						config.renderTo = renderTo;
						iterateFunction.call(scope, moduleId, config);
					}, this);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseObject#onDestroy
			 * @overridden
			 */
			onDestroy: function() {
				Ext.EventManager.removeListener(window, "scroll",
					this._debounceWindowScroll, this);
				this.iterateDashboardModules(function(moduleId) {
					this.sandbox.unloadModule(moduleId);
				}, this);
				this.callParent(arguments);
			},

			/**
			 * Returns widget configuration.
			 * @protected
			 * @overridden
			 * @param {String} config.widgetType Type of widget.
			 * @return {Object} View of widget.
			 */
			getWidgetConfig: function(config) {
				var widgetConfig = BPMSoft.DashboardEnums.WidgetType[config.widgetType];
				return widgetConfig.view;
			},

			/**
			 * Generates unique identifier for dashboard module.
			 * @protected
			 * @virtual
			 * @param {String} itemName Name of dashboard item.
			 * @param {Object} moduleConfig Configuration of dashboard item.
			 * @return {String} Unique identifier for dashboard module.
			 */
			getModuleId: function(itemName, moduleConfig) {
				var moduleName = "";
				if (moduleConfig && moduleConfig.moduleName) {
					moduleName = moduleConfig.moduleName;
				}
				var sandboxId = this.sandbox.id;
				return this.Ext.String.format("{0}{1}{2}", sandboxId, itemName, moduleName);
			},

			/**
			 * Returns configuration of nested module.
			 * @protected
			 * @virtual
			 * @param {Object} moduleConfig Configuration of dashboard item.
			 * @return {Object} Configuration of nested module.
			 */
			getNestedModuleConfig: function(moduleConfig) {
				const config = Ext.apply({}, this.getWidgetConfig(moduleConfig), moduleConfig);
				const configParameters = config.parameters || {};
				const customParametersModuleName = configParameters.customModuleName;
				const parametersModuleName = configParameters.moduleName;
				config.moduleName = customParametersModuleName 
					|| config.moduleName 
					|| parametersModuleName;
				return config;
			},

			/**
			 * Registrated messages for nested modules.
			 * @protected
			 * @virtual
			 * @param {String} itemName Nested module name.
			 * @param {String} moduleConfig Configuration of dashboard item.
			 */
			registerModuleMessages: function(itemName, moduleConfig) {
				var messages = {};
				var config = this.getNestedModuleConfig(moduleConfig);
				var configurationMessage = config.configurationMessage || config.parameters.configurationMessage;
				messages[configurationMessage] = {
					mode: BPMSoft.MessageMode.PTP,
					direction: BPMSoft.MessageDirectionType.SUBSCRIBE
				};
				this.sandbox.registerMessages(messages);
			},

			/**
			 * Subscribe for require config message for nested module.
			 * @protected
			 * @virtual
			 * @param {String} itemName Nested module name.
			 * @param {Object} moduleConfig Configuration of dashboard item.
			 */
			subscribeNestedModulesMessage: function(itemName, moduleConfig) {
				var config = this.getNestedModuleConfig(moduleConfig);
				var moduleId = this.getModuleId(itemName, config);
				this.registerModuleMessages(itemName, config);
				var configurationMessage = config.configurationMessage || config.parameters.configurationMessage;
				var parameters = config.parameters.parameters || config.parameters;
				this.sandbox.subscribe(configurationMessage, function() {
					return parameters;
				}, [moduleId]);
			},

			/**
			 * Initializes model.
			 * @protected
			 * @virtual
			 * @param {Function} callback Callback function.
			 * @param {Object} scope Execution context.
			 */
			init: function(callback, scope) {
				this._debounceWindowScroll = BPMSoft.debounce(this.loadNestedModule.bind(this),
						this._scrollHandlerDelay);
				Ext.EventManager.addListener(window, "scroll",
						this._debounceWindowScroll, this);
				this.subscribeModuleMessages();
				this.initModulesCaptions();
				callback.call(scope);
			},

			/**
			 * Subscribes on the messages.
			 * @protected
			 * @virtual
			 */
			subscribeModuleMessages: function() {
				var dashboards = this.getDashboards();
				dashboards.each(function(dashboard) {
					var modulesConfig = dashboard.getItems();
					BPMSoft.each(modulesConfig, function(moduleConfig, name) {
						this.subscribeNestedModulesMessage(name, moduleConfig);
					}, this);
				}, this);
			},

			/**
			 * Do actions that required after page had been rendered.
			 * @protected
			 * @virtual
			 */
			onRender: function() {
				if (!this.get("Restored")) {
					this.loadNestedModule();
				}
			},

			/**
			 * Generate property name for module container caption.
			 * @protected
			 * @virtual
			 * @param {String} itemName Nested module name.
			 * @returns {String} Poperty name of module caption.
			 */
			getModuleCaptionPropertyName: function(itemName) {
				return itemName + "ModuleContainer";
			},

			/**
			 * Initialize caption property for nested modules.
			 * @protected
			 * @virtual
			 */
			initModulesCaptions: function() {
				var dashboards = this.getDashboards();
				dashboards.each(function(dashboard) {
					var modulesConfig = dashboard.getItems();
					BPMSoft.each(modulesConfig, function(itemConfig, name) {
						var defaultModuleCaption =
							this.get("Resources.Strings.ModulePrefix") +
								(itemConfig.moduleName || itemConfig.parameters.moduleName);
						var moduleCaption = itemConfig.caption ||
							itemConfig.parameters.caption ||
							defaultModuleCaption;
						this.set(this.getModuleCaptionPropertyName(name), moduleCaption);
					}, this);
				}, this);
			},

			/**
			 * Returns collection of dashboards.
			 * @protected
			 * @virtual
			 * @return {BPMSoft.Collection} Collection of dashboards.
			 */
			getDashboards: function() {
				return this.get("Dashboards");
			},

			/**
			 * Method for subscribe by default for afterrender and afterrerender.
			 */
			loadModule: this.BPMSoft.emptyFn
		});

		/**
		 * @class BPMSoft.configuration.DashboardViewsConfig
		 * Class of view dashboard module.
		 */
		Ext.define("BPMSoft.configuration.DashboardViewConfig", {
			extend: "BPMSoft.BaseObject",
			alternateClassName: "BPMSoft.DashboardViewConfig",

			/**
			 * Row height.
			 * @type {String}
			 */
			rowHeight: "80px",

			/**
			 * Generate collection of dashboard view.
			 * @param {BPMSoft.Collection} items Dashboard collection.
			 * @returns {Object[]} Collection of dashboard view.
			 */
			generate: function(items) {
				var itemsConfig = [];
				items.each(function(item) {
					var itemId = "DashboardItem" + item.getId();
					itemsConfig.push({
						"name": itemId + "GridLayout",
						"rowHeight": this.rowHeight,
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": item.getVisibleViewConfig()
					});
				}, this);
				return itemsConfig;
			}
		});

		/**
		 * @class BPMSoft.configuration.DashboardModule
		 * Class of dashboard module.
		 */
		Ext.define("BPMSoft.configuration.DashboardModule", {
			extend: "BPMSoft.BaseNestedModule",
			alternateClassName: "BPMSoft.DashboardModule",

			/**
			 * Ext framework.
			 * @type {Object}.
			 */
			Ext: null,

			/**
			 * Sandbox.
			 * @type {Object}.
			 */
			sandbox: null,

			/**
			 * BPMSoft framework.
			 * @type {Object}.
			 */
			BPMSoft: null,

			/**
			 * Show mask flag.
			 * @type {Boolean}.
			 */
			showMask: true,

			/**
			 * Root element of view.
			 * @private
			 * @type {Ext.Element}
			 */
			renderContainer: null,

			/**
			 * Module configuration.
			 * @type {Object}
			 */
			moduleConfig: null,

			/**
			 * Name of nested viewModel class.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.BaseDashboardViewModel",

			/**
			 * Name of nested view class.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.DashboardViewConfig",

			/**
			 * Name of view generator.
			 * @type {String}
			 */
			viewGeneratorClass: "BPMSoft.ViewGenerator",

			/**
			 * ReloadDashboard handler.
			 * @protected
			 * @virtual
			 * @return {boolean} Return true.
			 */
			onReloadDashboard: function() {
				if (this.view && !this.view.destroyed) {
					this.view.destroy();
				}
				this.view = null;
				if (this.viewModel && !this.viewModel.destroyed) {
					this.viewModel.destroy();
				}
				this.viewModel = null;
				this.initConfig();
				this.initViewModelClass(function() {
					if (this.destroyed) {
						return;
					}
					this.initViewConfig(function() {
						if (this.destroyed) {
							return;
						}
						var viewModel = this.viewModel = this.createViewModel();
						viewModel.init(function() {
							if (!this.destroyed && this.renderContainer) {
								this.render(this.renderContainer);
							}
						}, this);
					}, this);
				}, this);

				return true;
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseSchemaModule#render
			 * @overridden
			 */
			render: function(renderTo) {
				this.callParent(arguments);
				this.renderContainer = renderTo;
			},

			/**
			 * Create instance of BPMSoft.ViewGenerator.
			 * @return {BPMSoft.ViewGenerator} Return instance of BPMSoft.ViewGenerator.
			 */
			createViewGenerator: function() {
				return this.Ext.create(this.viewGeneratorClass);
			},

			/**
			 * Create nested module view configuration.
			 * @protected
			 * @virtual
			 * param {Object} config Configuration object.
			 * param {Function} callback Callback function.
			 * param {BPMSoft.BaseModel} scope Callback function context.
			 * @return {Object[]} Return nested module view configuration.
			 */
			buildView: function(config, callback, scope) {
				var viewGenerator = this.createViewGenerator();
				var viewClass = this.Ext.create(this.viewConfigClassName);
				var schema = {
					viewConfig: viewClass.generate(config.dashboards)
				};
				var viewConfig = Ext.apply({
					schema: schema
				}, config);
				viewGenerator.generate(viewConfig, callback, scope);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewConfig
			 * @overridden
			 */
			initViewConfig: function(callback, scope) {
				var generatorConfig = BPMSoft.deepClone(this.moduleConfig);
				generatorConfig.viewModelClass = this.viewModelClass;
				generatorConfig.dashboards = this.dashboards;
				this.buildView(generatorConfig, function(view) {
					this.viewConfig = view[0];
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewModelClass
			 * @overridden
			 */
			initViewModelClass: function(callback, scope) {
				this.requireDashboards(this.moduleConfig, function(dashboards) {
					this.dashboards = dashboards;
					this.viewModelClass = Ext.ClassManager.get(this.viewModelClassName);
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#getViewModelConfig
			 * @overridden
			 */
			getViewModelConfig: function() {
				var config = this.callParent(arguments);
				config.values = Ext.apply({}, this.moduleConfig, {Dashboards: this.dashboards});
				return config;
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#init
			 * @overridden
			 */
			init: function() {
				if (!this.viewModel) {
					this.subscribeMessages();
					this.initConfig();
				}
				this.callParent(arguments);
			},

			/**
			 * Initialize configuration of module.
			 * @protected
			 * @virtual
			 */
			initConfig: function() {
				var sandbox = this.sandbox;
				this.moduleConfig = sandbox.publish("GetDashboardInfo", null, [sandbox.id]);
			},

			/**
			 * Subscribe for pearent messages.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: function() {
				var sandbox = this.sandbox;
				sandbox.subscribe("ReloadDashboard", this.onReloadDashboard, this, [sandbox.id]);
			},

			/**
			 * Require dashboard items from manager.
			 * @protected
			 * @virtual
			 * param {Object} config Configuration object.
			 * param {String} config.dashboardId Dashboard uniqueidentifier.
			 * param {Function} callback Callback function.
			 * param {BPMSoft.BaseModel} scope Callback function context.
			 * @return {BPMSoft.Collection} Collection of dashboard items.
			 */
			requireDashboards: function(config, callback, scope) {
				BPMSoft.DashboardManager.initialize({}, function() {
					var dashboardCollection = Ext.create("BPMSoft.Collection");
					if (config && config.dashboardId) {
						var dashboard = BPMSoft.DashboardManager.getItem(config.dashboardId);
						dashboard.loadLazyPropertiesData(function() {
							dashboardCollection.add(dashboard.getId(), dashboard);
							callback.call(scope, dashboardCollection);
						}, this);
						return;
					}
					BPMSoft.DashboardManager.createItem(null, function(dashboard) {
						dashboardCollection.add(dashboard.getId(), dashboard);
						callback.call(scope, dashboardCollection);
					}, this);
				}, this);
			}
		});
		return BPMSoft.DashboardModule;
	});
