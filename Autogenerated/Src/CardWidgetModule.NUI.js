define("CardWidgetModule", ["BaseNestedModule", "WidgetDashboardManager", "HistoryStateUtilities",
	"DashboardManagerItem", "CardWidgetModuleViewConfig"], function() {

	/**
	 * @class BPMSoft.configuration.CardWidgetModule
	 */
	Ext.define("BPMSoft.configuration.CardWidgetModule", {
		extend: "BPMSoft.BaseNestedModule",
		alternateClassName: "BPMSoft.CardWidgetModule",

		mixins: {
			historyStateUtilities: "BPMSoft.HistoryStateUtilities"
		},

		Ext: null,
		sandbox: null,
		BPMSoft: null,
		showMask: true,

		/**
		 * Module config.
		 * @type {Object}
		 */
		moduleConfig: null,

		/**
		 * Child module render to container id.
		 * @type {String}
		 */
		childModuleRenderTo: null,

		/**
		 * The class name of the view model.
		 * @type {String}
		 */
		viewModelClassName: "BPMSoft.BaseSchemaViewModel",

		/**
		 * The class name of the generator of view configuration.
		 * @type {String}
		 */
		viewConfigClassName: "BPMSoft.CardWidgetModuleViewConfig",

		/**
		 * The class name of the generator of view.
		 * @type {String}
		 */
		viewGeneratorClass: "BPMSoft.ViewGenerator",

		/**
		 * Creates the view configuration of the module.
		 * @protected
		 * @virtual
		 * @param {Object} config Configuration object.
		 * @param {Function} callback Callback function.
		 * @param {BPMSoft.BaseModel} scope Execution context of callback.
		 */
		buildView: function(config, callback, scope) {
			var viewGenerator = this.Ext.create(this.viewGeneratorClass);
			var viewClass = this.Ext.create(this.viewConfigClassName);
			this.childModuleRenderTo = "CardWidget" + this.sandbox.id;
			var schema = {
				viewConfig: viewClass.generate(this.childModuleRenderTo)
			};
			var viewConfig = Ext.apply({
				schema: schema
			}, config);
			viewConfig.schemaName = "";
			viewGenerator.generate(viewConfig, callback, scope);
		},

		/**
		 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewConfig
		 * @overridden
		 */
		initViewConfig: function(callback, scope) {
			var generatorConfig = {};
			generatorConfig.viewModelClass = this.viewModelClass;
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
			this.viewModelClass = this.Ext.ClassManager.get(this.viewModelClassName);
			callback.call(scope);
		},

		/**
		 * @inheritdoc BPMSoft.BaseNestedModule#init
		 * @overridden
		 */
		init: function(callback, scope) {
			this.callParent([function() {
				BPMSoft.WidgetDashboardManager.initialize({}, callback, scope || this);
			}, this]);
			this.sandbox.subscribe("EntityInitialized", this.initWidgetModule, this, [this.sandbox.id]);
		},

		/**
		 * @inheritdoc BPMSoft.BaseNestedModule#init
		 * @overridden
		 */
		render: function() {
			this.callParent(arguments);
			this.initWidgetModule();
		},

		/**
		 * Init and load widget module.
		 * @protected
		 */
		initWidgetModule: function() {
			var config = this.parameters && this.parameters.viewModelConfig;
			if (config) {
				this._getWidgetModuleConfig(config, this.loadWidgetModule, this);
			} else {
				this.warning("viewModelConfig is not defined");
			}
		},

		/**
		 * Loads widget module.
		 * @param {Object} widgetModuleConfig Widget module config.
		 * @param {String} widgetModuleConfig.widgetModuleName Widget module name.
		 * @param {Object} widgetModuleConfig.parameters Widget module parameters.
		 */
		loadWidgetModule: function(widgetModuleConfig) {
			var params = widgetModuleConfig.parameters;
			params.primaryColumnValue = params.primaryColumnValue || BPMSoft.GUID_EMPTY;
			this.sandbox.loadModule(widgetModuleConfig.widgetModuleName, {
				id: widgetModuleConfig.id + "_CardWidget",
				renderTo: this.childModuleRenderTo,
				instanceConfig: {
					moduleConfig: params
				}
			});
		},

		/**
		 * Gets card primary column value.
		 * @protected
		 * @returns {String} Card primary column value.
		 */
		getPrimaryColumnValue: function() {
			var historyState = this.sandbox.publish("GetHistoryState");
			var state = historyState.state || {};
			var primaryColumnValue = state.primaryColumnValue;
			if (!primaryColumnValue) {
				var historyStateInfo = this.getHistoryStateInfo();
				primaryColumnValue = historyStateInfo.primaryColumnValue;
			}
			return primaryColumnValue;
		},

		/**
		 * Gets widget module config.
		 * @protected
		 * @param {String} recordId SysDashboard record id.
		 * @param {String} widgetKey Widget item key.
		 * @param {Function} callback Callback function.
		 * @param {Object} scope Execution context of callback.
		 */
		getWidgetModuleConfig: function(recordId, widgetKey, callback, scope) {
			var config = {
				recordId: arguments[0],
				widgetKey: arguments[1]
			};
			this._getWidgetModuleConfig(config, callback, scope);
		},

		/**
		 * @private
		 */
		_getWidgetModuleConfig: function(config, callback, scope) {
			const recordId = config.recordId;
			const widgetKey = config.widgetKey;
			const defaultPrimaryColumnValue = config.primaryColumnValue;
			const dashboard = BPMSoft.WidgetDashboardManager.getItem(recordId);
			dashboard.loadLazyPropertiesData(function() {
				const dashboardWidgets = dashboard.getItems();
				const widgetConfig = dashboardWidgets[widgetKey];
				const widgetType = BPMSoft.DashboardEnums.WidgetType[widgetConfig.widgetType];
				if (!widgetType) {
					throw new BPMSoft.UnsupportedTypeException();
				}
				widgetConfig.widgetModuleName = widgetType.view && widgetType.view.moduleName;
				widgetConfig.parameters.primaryColumnValue = this.getPrimaryColumnValue() || defaultPrimaryColumnValue;
				widgetConfig.id = widgetKey;
				Ext.callback(callback, scope || this, [widgetConfig]);
			}, this);
		}

	});

	return BPMSoft.CardWidgetModule;
});
