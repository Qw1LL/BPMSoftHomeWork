define("DuplicatesDetailModuleV2", ["DeduplicationConstants", "BaseNestedModule",
			"DuplicatesDetailViewConfigV2", "DuplicatesDetailViewModelV2"],
	function(DeduplicationConstants) {
		Ext.define("BPMSoft.configuration.DuplicatesDetailModule", {
			extend: "BPMSoft.BaseNestedModule",
			alternateClassName: "BPMSoft.DuplicatesDetailModule",

			Ext: null,
			sandbox: null,
			BPMSoft: null,
			showMask: true,

			/**
			 * Module configuration object.
			 * @type {Object}
			 */
			moduleConfig: null,

			/**
			 * The class name of the viewmodel.
			 * @type {String}
			 */
			viewModelClassName: DeduplicationConstants.features.getIsLazyDuplicatesPageEnabled()
					? "BPMSoft.LazyDuplicatesDetailViewModel"
					: "BPMSoft.DuplicatesDetailViewModel",

			/**
			 * The class name of the generator of view configuration.
			 * @type {String}
			 */
			viewConfigClassName: DeduplicationConstants.features.getIsLazyDuplicatesPageEnabled()
					? "BPMSoft.LazyDuplicatesDetailViewConfig"
					: "BPMSoft.DuplicatesDetailViewConfig",

			/**
			 * The class name of the generator of view.
			 * @type {String}
			 */
			viewGeneratorClass: "BPMSoft.ViewGenerator",

			initConfig: function() {
				var sandbox = this.sandbox;
				this.moduleConfig = sandbox.publish("GetConfig", sandbox.id, [sandbox.id]) || {};
			},

			/**
			 * Create instance of BPMSoft.ViewGenerator class.
			 * @return {BPMSoft.ViewGenerator} Returns object BPMSoft.ViewGenerator.
			 */
			createViewGenerator: function() {
				return this.Ext.create(this.viewGeneratorClass);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewConfig
			 * @overridden
			 */
			initViewConfig: function(callback, scope) {
				var generatorConfig = BPMSoft.deepClone(this.moduleConfig) || {};
				generatorConfig.viewModelClass = this.viewModelClass;
				this.buildView(generatorConfig, function(view) {
					this.viewConfig = view[0];
					callback.call(scope);
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#getViewModelConfig
			 * @overridden
			 */
			getViewModelConfig: function() {
				var config = this.callParent(arguments);
				config.values = Ext.apply({}, this.moduleConfig);
				return config;
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#initViewModelClass
			 * @overridden
			 */
			initViewModelClass: function(callback, scope) {
				this.viewModelClass = this.Ext.ClassManager.get(this.moduleConfig.viewModelClassName || this.viewModelClassName);
				callback.call(scope);
			},

			/**
			 * Creates the view configuration of the module.
			 * @protected
			 * @virtual
			 * @param {Object} config Configuration object.
			 * @param {Function} callback Callback function.
			 * @param {BPMSoft.BaseModel} scope Execution context of callback.
			 * @return {Object[]} Returns the view configuration of the module.
			 */
			buildView: function(config, callback, scope) {
				var viewGenerator = this.createViewGenerator();
				var viewClass = this.Ext.create(this.moduleConfig.viewConfigClassName || this.viewConfigClassName);
				var schema = {
					viewConfig: viewClass.generate(config)
				};
				var viewConfig = Ext.apply({
					schema: schema
				}, config);
				viewConfig.schemaName = "";
				viewGenerator.generate(viewConfig, callback, scope);
			},

			/**
			 * @inheritDoc BPMSoft.configuration.BaseNestedModule#init
			 * @overridden
			 */
			init: function() {
				if (!this.viewModel) {
					this.initConfig();
				}
				this.callParent(arguments);
			}
		});

		return BPMSoft.DuplicatesDetailModule;
	});
