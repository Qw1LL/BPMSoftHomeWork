define("DashboardGridModule", ["BPMSoft", "ext-base", "DashboardGridModuleResources", "BaseWidgetModule",
	"GridUtilitiesV2", "ContainerListGenerator",
	"ContainerList", "MiniPageUtilities", "ModuleUtils", "DashboardGridViewModel", "DashboardGridViewConfig",
	"DashboardListedGridViewModel", "DashboardListedGridViewConfig"],
	function(BPMSoft, Ext, resources) {

		/**
		 * @class BPMSoft.configuration.DashboardGridModule
		 * Class of dashboard grid module.
		 */
		Ext.define("BPMSoft.configuration.DashboardGridModule", {
			extend: "BPMSoft.BaseWidgetModule",
			alternateClassName: "BPMSoft.DashboardGridModule",

			/**
			 * Entity schema.
			 * @type {BPMSoft.BaseEntitySchema}
			 */
			entitySchema: null,

			/**
			 * Class name of the DashboardGrid module view model.
			 * @type {String}
			 */
			viewModelClassName: "BPMSoft.DashboardListedGridViewModel",

			/**
			 * Class name of the DashboardGrid module view configuration.
			 * @type {String}
			 */
			viewConfigClassName: "BPMSoft.DashboardListedGridViewConfig",

			/**
			 * @inheritDoc BPMSoft.configuration.BaseWidgetModule#initViewConfig
			 * @overridden
			 */
			initViewConfig: function(callback, scope) {
				var generatorConfig = BPMSoft.deepClone(this.moduleConfig);
				generatorConfig.viewModelClass = this.viewModelClass;
				generatorConfig.entitySchema = this.entitySchema;
				this.buildView(generatorConfig, function(view) {
					this.viewConfig = view[0];
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseWidgetModule#initViewModelClass
			 * @overridden
			 */
			initViewModelClass: function(callback, scope) {
				var moduleConfig = this.moduleConfig;
				BPMSoft.require([moduleConfig.entitySchemaName], function(entitySchema) {
					this.entitySchema = entitySchema;
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
				config.entitySchema = this.entitySchema;
				config.resources = resources;
				return config;
			},

			/**
			 * Initializes module configuration.
			 * @protected
			 * @virtual
			 */
			initConfig: function() {
				this.callParent(["GetDashboardGridConfig", this.sandbox]);
			},

			/**
			 * Subscribes to the specific module posts.
			 * @protected
			 * @virtual
			 */
			subscribeMessages: function() {
				this.callParent(arguments);
				this.subscribeMessagesInternal("GenerateDashboardGrid");
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseWidgetModule#onGenerateWidget
			 * @overridden
			 */
			onGenerateWidget: function() {
				this.onGenerateDashboardGrid();
			},

			/**
			 * GenerateDashboardGrid handler.
			 * @protected
			 * @virtual
			 */
			onGenerateDashboardGrid: function() {
				if (this.view && !this.view.destroyed) {
					this.view.destroy();
				}
				this.view = null;
				if (!this.viewModel) {
					return true;
				}
				var renderTo = Ext.get(this.viewModel.renderTo);
				if (this.viewModel && !this.viewModel.destroyed) {
					this.viewModel.destroy();
				}
				this.viewModel = null;
				this.moduleConfig = null;
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
							if (!this.destroyed && renderTo) {
								this.render(renderTo);
							}
						}, this);
					}, this);
				}, this);
				return true;
			}
		});

		return BPMSoft.DashboardGridModule;
	});
