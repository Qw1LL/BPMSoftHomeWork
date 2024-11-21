define("ProcessSchemaParameterEditModule", ["ProcessMiniEditPageModule"], function() {

	Ext.define("BPMSoft.configuration.ProcessSchemaParameterEditModule", {
		alternateClassName: "BPMSoft.ProcessSchemaParameterEditModule",
		extend: "BPMSoft.ProcessMiniEditPageModule",

		/**
		 * {Object} Current process parameter config.
		 * {Object} parameterEditInfo.parameters Parameter config.
		 * {Object} parameterEditInfo.methods Parameter methods.
		 * @protected
		 */
		parameterEditInfo: null,

		/**
		 * @inheritDoc BaseSchemaModule#initHistoryState.
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#isSchemaConfigInitialized
		 * @overridden
		 */
		isSchemaConfigInitialized: false,

		/**
		 * @inheritDoc BaseSchemaModule#init.
		 * @overridden
		 */
		init: function() {
			this.parameterEditInfo = this.sandbox.publish("GetParameterEditInfo", null, [this.sandbox.id]) || {};
			this.callParent(arguments);
		},

		/**
		 * @inheritDoc BaseSchemaModule#initSchemaName.
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "ProcessSchemaParameterEditPage";
		},

		/**
		 * @inheritDoc BaseSchemaModule#getViewModelConfig.
		 * @overridden
		 */
		getViewModelConfig: function() {
			var viewModelConfig = this.callParent(arguments);
			Ext.apply(viewModelConfig, {
				values: this.parameterEditInfo.parameters,
				methods: this.parameterEditInfo.methods
			});
			return viewModelConfig;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getSchemaBuilderConfig
		 * @protected
		 * @overridden
		 */
		getSchemaBuilderConfig: function() {
			var result = this.callParent(arguments);
			return Ext.apply(result, {
				useCache: false
			});
		},

		/**
		 * @inheritDoc BaseSchemaModule#generateSchemaStructure.
		 * @overridden
		 */
		generateSchemaStructure: function(callback, scope) {
			var config = this.getSchemaBuilderConfig();
			this.schemaBuilder.build(config, function(viewModelClass, viewConfig) {
				callback.call(scope, viewModelClass, viewConfig);
			}, this);
		}
	});

	return BPMSoft.ProcessSchemaParameterEditModule;
});
