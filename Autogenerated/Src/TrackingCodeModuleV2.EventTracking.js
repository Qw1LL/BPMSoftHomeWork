define("TrackingCodeModuleV2", ["BaseNestedModule", "TrackingCodeViewConfigV2", "TrackingCodeViewModelV2"
], function() {
	Ext.define("BPMSoft.configuration.TrackingCodeModule", {
		extend: "BPMSoft.BaseNestedModule",
		alternateClassName: "BPMSoft.TrackingCodeModule",
		Ext: null,
		sandbox: null,
		BPMSoft: null,
		showMask: true,
		parameters: {
			config: null
		},

		/**
		 * The class name of the view model.
		 * @type {String}
		 */
		viewModelClassName: "BPMSoft.TrackingCodeViewModel",

		/**
		 * The class name of the generator of view configuration.
		 * @type {String}
		 */
		viewConfigClassName: "BPMSoft.TrackingCodeViewConfig",

		/**
		 * The class name of the generator of view.
		 * @type {String}
		 */
		viewGeneratorClass: "BPMSoft.ViewGenerator",

		/**
		 * Create instance of BPMSoft.ViewGenerator class.
		 * @return {BPMSoft.ViewGenerator} Returns object BPMSoft.ViewGenerator.
		 */
		createViewGenerator: function() {
			return this.Ext.create(this.viewGeneratorClass);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.BaseNestedModule#initViewConfig
		 * @override
		 */
		initViewConfig: function(callback, scope) {
			var generatorConfig = BPMSoft.deepClone(this.parameters.config) || {};
			generatorConfig.viewModelClass = this.viewModelClass;
			this.buildView(generatorConfig, function(view) {
				this.viewConfig = view[0];
				callback.call(scope);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.BaseNestedModule#getViewModelConfig
		 * @override
		 */
		getViewModelConfig: function() {
			var config = this.callParent(arguments);
			config.values = Ext.apply({}, this.parameters.config);
			return config;
		},

		/**
		 * @inheritdoc BPMSoft.configuration.BaseNestedModule#initViewModelClass
		 * @override
		 */
		initViewModelClass: function(callback, scope) {
			this.viewModelClass = this.Ext.ClassManager.get(this.viewModelClassName);
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
			var viewClass = this.Ext.create(this.viewConfigClassName);
			var schema = {
				viewConfig: viewClass.generate(config)
			};
			var viewConfig = Ext.apply({
				schema: schema
			}, config);
			viewConfig.schemaName = "";
			viewGenerator.generate(viewConfig, callback, scope);
		}
	});

	return BPMSoft.TrackingCodeModule;
});
