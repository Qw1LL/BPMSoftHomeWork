define("BaseViewModule", ["BaseViewModuleResources", "performancecountermanager", "ConfigurationConstants",
	"ServiceHelper", "profile!clientWorkplaceMenuProfile", "HomePageInWorkplaceUtils", "ViewGeneratorV2"
], function(resources, performanceCounterManager, ConfigurationConstants, serviceHelper, {workplaceId}, HomePageInWorkplaceUtils) {

	/**
	 * The base class module of visual presentation.
	 */
	Ext.define("BPMSoft.configuration.BaseViewModule", {
		extend: "BPMSoft.core.BaseObject",
		alternateClassName: "BPMSoft.BaseViewModule",

		Ext: null,
		sandbox: null,
		BPMSoft: null,

		/**
		 * Wait interval in milliseconds for debouncing {@link #onLoadModule} method. At the end of this interval,
		 * the {@link #onLoadModule} method will be called with the most recently arguments.
		 * @protected
		 * @type {Number}
		 */
		loadModuleDelay: 30,

		/**
		 * A sign of async module.
		 * @type {Boolean}
		 */
		isAsync: true,

		/**
		 * The last state hash.
		 * @type {Object}
		 */
		currentHash: {
			historyState: ""
		},

		/**
		 * Code of the home page by default.
		 * @type {String}
		 */
		defaultHomeModule: ConfigurationConstants.DefaultHomeModule,

		/**
		 * Code of the home page.
		 * @type {String}
		 */
		homeModule: "",

		/**
		 * Flag that indicates if current user has home page in SysAdminUnit.
		 * @private
		 * @type {Boolean}
		 */
		_useCurrentUserHomePage: false,

		/**
		 * The name of the main container module.
		 * @type {Object[]}
		 */
		containerName: "ViewModuleContainer",

		/**
		 * The configuration of the module view.
		 * @type {Object[]}
		 */
		viewConfig: null,

		/**
		 * The class name of the generator representation.
		 * @type {String}
		 */
		viewGeneratorClass: "BPMSoft.ViewGenerator",

		/**
		 * The difference in the representation scheme.
		 * @type {Object[]}
		 */
		diff: [{
			"operation": "insert",
			"name": "centerPanel",
			"values": {
				"id": "centerPanel",
				"selectors": {"wrapEl": "#centerPanel"},
				"itemType": BPMSoft.ViewItemType.CONTAINER,
				"wrapClass": ["default-center-panel-content"]

			}
		}],

		/**
		 * @inheritdoc BPMSoft.BaseObject#constructor
		 * @override
		 */
		constructor: function() {
			this.callParent(arguments);
			this.delayedLoadModule = BPMSoft.debounce(this.onLoadModule, this.loadModuleDelay);
		},

		/**
		 * Init module.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		init: function(callback, scope) {
			this._initMessages();
			BPMSoft.chain(
				this.initSysSettings,
				this.initViewConfig,
				this.initHomePage,
				function() {
					this.subscribeMessages();
					callback.call(scope);
				},
				this
			);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#destroy
		 * @override
		 */
		destroy: function() {
			const messages = this.getMessages();
			const messageKeys = BPMSoft.keys(messages);
			this.sandbox.unRegisterMessages(messageKeys);
			this.callParent(arguments);
		},

		_initMessages: function() {
			const messages = this.getMessages();
			if (!messages) {
				return;
			}
			this.sandbox.registerMessages(messages);
		},

		/**
		 * Returns object that describes messages.
		 * @protected
		 */
		getMessages: BPMSoft.emptyFn,

		/**
		 * Display view.
		 * @param {Ext.Element} renderTo The reference to the container in which to display the view.
		 */
		render: function(renderTo) {
			this.renderView(renderTo);
			this.loadNonVisibleModules();
			this.initHistoryState();
		},

		/**
		 * Checks whether the execution context is an instance of a class, or a basic prototype.
		 * @protected
		 * @return {Boolean} Returns true if current execution context is an instance of a class
		 * false otherwise.
		 */
		isInstance: function() {
			return this.hasOwnProperty("instanceId") && this.instanceId;
		},

		/**
		 * Creates a schema view based on the parameter difference for the whole class hierarchy.
		 * @protected
		 * @return {Object[]} Returns the schema of the view.
		 */
		getSchema: function() {
			var baseSchema = [];
			if (this.superclass.getSchema) {
				baseSchema = this.superclass.getSchema();
			}
			return this.hasDiff() ? BPMSoft.JsonApplier.applyDiff(baseSchema, this.diff) : baseSchema;
		},

		/**
		 * Checks if the context parameter of the difference scheme.
		 * @protected
		 * @return {Boolean} Returns true if so, false otherwise.
		 */
		hasDiff: function() {
			const isInstance = this.isInstance();
			const diff = this.diff;
			return (isInstance && (diff !== this.superclass.diff)) ||
				(!isInstance && (this.hasOwnProperty("diff") && !Ext.isEmpty(diff)));
		},

		/**
		 * Creates a configuration module view.
		 * @protected
		 * @param {Object} config A configuration object.
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		buildView: function(config, callback, scope) {
			const viewGenerator = this.createViewGenerator();
			const schema = {
				viewConfig: this.getSchema()
			};
			const viewConfig = Ext.apply({
				schema: schema
			}, config);
			viewGenerator.generate(viewConfig, callback, scope);
		},

		/**
		 * Initialises configuration object module view.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initViewConfig: function(callback, scope) {
			const generatorConfig = {};
			generatorConfig.viewModelClass = this.self;
			this.buildView(generatorConfig, function(view) {
				this.viewConfig = view;
				callback.call(scope);
			}, this);
		},

		/**
		 * Creates an instance of the class BPMSoft.ViewGenerator.
		 * @protected
		 * @return {BPMSoft.ViewGenerator}
		 */
		createViewGenerator: function() {
			return this.Ext.create(this.viewGeneratorClass);
		},

		/**
		 * Initialises basic system settings.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initSysSettings: function(callback, scope) {
			const settingsNames = this.getSysSettingsNames();
			BPMSoft.SysSettings.querySysSettings(settingsNames, function(values) {
				this.onSysSettingsResponse(values);
				callback.call(scope);
			}, this);
		},

		/**
		 * Returns an array of the names of the system settings whose values are queried and cached when you log in
		 * system user.
		 * @protected
		 * @return {String[]} Array with the names of the system settings whose values are queried and cached when
		 * the logon user.
		 */
		getSysSettingsNames: function() {
			return ["BuildType", "ShowDemoLinks", "PrimaryCulture", "SchedulerTimingStart", "SchedulerTimingEnd",
				"SchedulerDisplayTimingStart"];
		},

		/**
		 * Processes the results of loading the system settings.
		 * @protected
		 */
		onSysSettingsResponse: BPMSoft.emptyFn,

		/**
		 * Creates and loads the main panel of the website.
		 * @protected
		 * @param {Ext.Element} renderTo The reference to the container in which to display the view.
		 */
		renderView: function(renderTo) {
			this.view = this.Ext.create("BPMSoft.Container", {
				id: this.containerName,
				selectors: {wrapEl: "#" + this.containerName},
				items: BPMSoft.deepClone(this.viewConfig),
				markerValue: this.containerName
			});
			this.view.render(renderTo);
		},

		/**
		 * Initializes the initial state.
		 * @protected
		 */
		initHistoryState: function() {
			const token = this.sandbox.publish("GetHistoryState");
			if (token) {
				this.onHistoryStateChanged(token, true);
			}
		},

		/**
		 * @deprecated
		 */
		checkWebSocketSupport: BPMSoft.emptyFn,

		/**
		 * Downloads invisible utility modules.
		 * @protected
		 */
		loadNonVisibleModules: function() {
			this.sandbox.loadModule("NavigationModule");
		},

		/**
		 * Subscribes to messages.
		 * @protected
		 */
		subscribeMessages: function() {
			const sandbox = this.sandbox;
			sandbox.subscribe("LoadModule", this.onLoadModule, this);
			sandbox.subscribe("HistoryStateChanged", function(token) {
				this.onHistoryStateChanged(token);
			}, this);
			sandbox.subscribe("RefreshCacheHash", this.refreshCacheHash, this);
			sandbox.subscribe("NavigationModuleLoaded", this.loadMainPanelsModules, this);
		},

		/**
		 * Loads the modules in the main panel.
		 * @protected
		 */
		loadMainPanelsModules: function() {
			const schema = this.getSchema();
			BPMSoft.iterateChildItems(schema, function(iterationConfig) {
				const item = iterationConfig.item;
				if (item.itemType === BPMSoft.ViewItemType.MODULE) {
					this.onLoadModule({
						moduleName: item.moduleName,
						renderTo: item.name
					});
				}
			}, this);
			this.loadHomePage();
		},

		/**
		 * Init code of the home page for the current user.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initHomePage: function(callback, scope) {
			serviceHelper.callService({
				serviceName: "CurrentUserService",
				methodName: "GetCurrentUserHomePage",
				callback: function(response, success) {
					if (success && response && response.homePage) {
						this.homeModule = response.homePage;
						this._useCurrentUserHomePage = true;
					} else {
						if (BPMSoft.isCurrentUserSsp()) {
							this.initHomePageFromSysSettings(callback, scope);
							return;
						}
						this.homeModule = this.defaultHomeModule;
					}
					Ext.callback(callback, scope || this);
				},
				scope: this
			});
		},

		/**
		 * Initializes code of the home page for the current user from system settings.
		 * @protected
		 * @param {Function} callback The callback function.
		 * @param {Object} scope The scope of callback function.
		 */
		initHomePageFromSysSettings: function(callback, scope) {
			const sysSettingsCodes = ["SSPMainPage"];
			BPMSoft.SysSettings.querySysSettings(sysSettingsCodes, function (sysSettings) {
				if (sysSettings) {
					const sysSettingsSSPMainPage = sysSettings.SSPMainPage;
					const mainPageModuleId = sysSettingsSSPMainPage.value;
					BPMSoft.each(BPMSoft.configuration.ModuleStructure, function(module) {
						if (module.moduleId === mainPageModuleId) {
							this.homeModule = module.entitySchemaName;
							this._useCurrentUserHomePage = true;
							return false;
						}
					}, this);
				} else {
					this.homeModule = this.defaultHomeModule;
				}
				Ext.callback(callback, scope || this);
			}, this);
		},

		/**
		 * Loading module.
		 * @protected
		 * @param {Object} config Load module config.
		 * @param {String} config.renderTo Name of the module container.
		 * @param {String} config.moduleId The unique module identifier.
		 * @param {String} config.moduleName Name of the module.
		 * @param {Boolean} config.keepAlive The sign of the previous module loaded into the container
		 * will be destroyed there.
		 * @param {Object} [config.instanceConfig] Config for module instance.
		 */
		onLoadModule: function(config) {
			const renderTo = config.renderTo;
			if (!Ext.isEmpty(renderTo)) {
				const moduleConfig = {
					renderTo: renderTo,
					id: config.moduleId,
					keepAlive: config.keepAlive || false
				};
				this.sandbox.loadModule(config.moduleName, moduleConfig);
			}
		},

		/**
		 * Loads module. If called multiple times in row only the last module will be loaded.
		 * @private
		 * @param {Object} config Load module config used in {@link #onLoadModule} method.
		 */
		delayedLoadModule: BPMSoft.emptyFn,

		/**
		 * Finds module name in the object browser state.
		 * @protected
		 * @param {Object} token The state object browser.
		 * @return {String} Returns the name of the module.
		 */
		getModuleName: function(token) {
			if (token.state && token.state.moduleName) {
				return token.state.moduleName;
			}
			return token.hash ? token.hash.moduleName : null;
		},

		/**
		 * Processed traditionally t the status change. Starts the timer performance.
		 * @protected
		 */
		onStateChanged: function() {
			performanceCounterManager.clearAllTimeStamps();
			performanceCounterManager.setTimeStamp("StateChanged");
		},

		/**
		 * Handles new condition, loads the module chain.
		 * @protected
		 * @param {Object} token The object of the new browser state.
		 */
		loadChainModule: function(token) {
			const currentState = this.sandbox.publish("GetHistoryState");
			const moduleId = currentState.state && currentState.state.moduleId;
			const moduleName = this.getModuleName(token);
			if (!moduleId || !moduleName) {
				return;
			}
			this.onStateChanged();
			this.onLoadModule({
				moduleName: moduleName,
				moduleId: moduleId,
				renderTo: "centerPanel"
			});
		},

		/**
		 * Processes new state, loads module.
		 * @protected
		 * @param {Object} token New browser state object.
		 * @param {Boolean} [immediateLoad] If defined as true, new module will be loaded immediately,
		 * otherwise it will be loaded with {@link #loadModuleDelay} delay.
		 */
		loadModuleFromHistoryState: function(token, immediateLoad) {
			const moduleName = this.getModuleName(token);
			if (!moduleName) {
				return;
			}
			const currentState = this.sandbox.publish("GetHistoryState");
			const keepAlive = this.Ext.isObject(currentState.state) ? currentState.state.keepAlive : false;
			const id = this.generateModuleId(moduleName, currentState);
			this.onStateChanged();
			const config = {
				moduleName: moduleName,
				moduleId: id,
				renderTo: "centerPanel",
				keepAlive: keepAlive
			};
			if (immediateLoad === true) {
				this.onLoadModule(config);
			} else {
				this.delayedLoadModule(config);
			}
		},

		/**
		 * Generates module unique id base on module name and current state.
		 * @protected
		 * @param {String} moduleName Module name.
		 * @param {Object} currentState Browser state object.
		 * @return {String} Returns module unique identifier.
		 */
		generateModuleId: function(moduleName, currentState) {
			const id = currentState.state && currentState.state.id;
			let result = moduleName;
			const hash = currentState.hash;
			const schemaName = (currentState.hash && currentState.hash.entityName) || "";
			if (!this.Ext.isEmpty(hash) && !this.Ext.isEmpty(hash.recordId)) {
				result += "_" + hash.recordId;
			}
			return id || result + "_" + schemaName;
		},

		/**
		 * Processes state changes. Loads require modules.
		 * @protected
		 * @param {Object} token Browser new state object.
		 * @param {Boolean} [immediateLoad] If defined as true, new module will be loaded immediately,
		 * otherwise it will be loaded with {@link #loadModuleDelay} delay.
		 */
		onHistoryStateChanged: function(token, immediateLoad) {
			if (this._isNeedLoadInChain(token)) {
				this.loadChainModule(token);
			} else {
				this.refreshCacheHash();
				this.loadModuleFromHistoryState(token, immediateLoad);
			}
		},

		/**
		 * @private
		 */
		_isNeedLoadInChain: function(token) {
			if (token.state && token.state.forceNotInChain) {
				return false;
			}
			return this.currentHash.historyState === token.hash.historyState;
		},

		/**
		 * Updates the current status for the module.
		 * @protected
		 */
		refreshCacheHash: function() {
			const currentHistoryState = this.sandbox.publish("GetHistoryState");
			this.currentHash.historyState = currentHistoryState.hash.historyState;
		},

		/**
		 * Opens the home page, if the status was not ascertained.
		 * @protected
		 */
		loadHomePage: function() {
			const state = this.sandbox.publish("GetHistoryState");
			const hash = state.hash;
			if (hash.historyState) {
				if (hash.moduleName === "MainMenu") {
					this.replaceHomePage();
				}
			} else {
				this.openHomePage();
			}
		},

		/**
		 * Opens the home page.
		 * @protected
		 */
		openHomePage: function() {
			const hash = this.getHomePagePath();
			this.sandbox.publish("PushHistoryState", {hash: hash});
		},

		/**
		 * Replaces the current home page.
		 * @private
		 */
		replaceHomePage: function() {
			const hash = this.getHomePagePath();
			this.sandbox.publish("ReplaceHistoryState", {hash: hash});
		},
		/**
		 * @protected
		 */
		getDefaultWorkplaceModule: function() {
			const workplace = HomePageInWorkplaceUtils.getCurrentWorkplace(workplaceId);
			return HomePageInWorkplaceUtils.getCurrentWorkplaceModuleName(workplace);
		},

		/**
		 * Returns the path to the home page.
		 * @protected
		 * @return {String}
		 */
		getHomePagePath: function() {
			let _homeModule = this.homeModule;
			if (BPMSoft.Features.getIsDisabled("DisableHomePageInWorkplace") && !this._useCurrentUserHomePage) {
				const workplace = HomePageInWorkplaceUtils.getCurrentWorkplace(workplaceId);
				if (workplace?.homePageSchemaName &&
					BPMSoft.ServerSchemaType[workplace?.homePageSchemaType] === BPMSoft.SchemaType.ANGULAR_SCHEMA) {
					return BPMSoft.combinePath("HomePage", workplace.homePageSchemaName);
				}
				if (workplace?.homePageSchemaName) {
					return BPMSoft.combinePath("IntroPage", workplace.homePageSchemaName);
				} else {
					_homeModule = this.getDefaultWorkplaceModule();
				}
			}
			const module = BPMSoft.configuration.ModuleStructure[_homeModule];
			return module
				? BPMSoft.combinePath(module.sectionModule, module.sectionSchema)
				: this.getHomeModulePath();
		},

		/**
		 * Returns the path to the starting module.
		 * @protected
		 * @return {String}
		 */
		getHomeModulePath: function() {
			return this.homeModule;
		}
	});

	return BPMSoft.BaseViewModule;
});
