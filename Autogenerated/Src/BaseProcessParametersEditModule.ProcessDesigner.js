define("BaseProcessParametersEditModule", ["ModalBox", "BaseSchemaModuleV2"], function() {
	/**
	 * BaseProcessParametersEditModule
	 */
	Ext.define("BPMSoft.configuration.BaseProcessParametersEditModule", {
		extend: "BPMSoft.configuration.BaseSchemaModule",
		alternateClassName: "BPMSoft.BaseProcessParametersEditModule",

		/**
		 * @inheritdoc BPMSoft.BaseModule#render
		 * @override
		 */
		showMask: true,

		/**
		 * Parameters info.
		 * @type []
		 */
		parametersInfo: null,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: Ext.emptyFn,

		/**
		 * Initialize parameters info.
		 * @protected
		 */
		initParametersInfo: function() {
			this.parametersInfo = {};
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @override
		 */
		init: function() {
			this.showLoadingMask();
			this.initParametersInfo();
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getViewModelConfig
		 * @override
		 */
		getViewModelConfig: function() {
			var viewModelConfig = this.callParent(arguments);
			var values = {
				modalBoxCaption: this.parametersInfo.modalBoxCaption
			};
			var originalValues = viewModelConfig ? viewModelConfig.values : null;
			values = Ext.apply(values, this.parametersInfo.parameters, originalValues);
			Ext.apply(viewModelConfig, {
				values: values,
				methods: this.parametersInfo.methods
			});
			return viewModelConfig;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getSchemaBuilderConfig
		 * @override
		 */
		getSchemaBuilderConfig: function() {
			var result = this.callParent(arguments);
			result.useCache = false;
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#generateSchemaStructure
		 * @override
		 */
		generateSchemaStructure: function(callback, scope) {
			var config = this.getSchemaBuilderConfig();
			this.schemaBuilder.build(config, function(viewModelClass, viewConfig) {
				callback.call(scope, viewModelClass, viewConfig);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#render
		 * @override
		 */
		render: function() {
			this.callParent(arguments);
			this.hideLoadingMask();
		},

		/**
		 * @inheritdoc BPMSoft.BaseObject#onDestroy
		 * @override
		 */
		onDestroy: function() {
			this.hideLoadingMask();
			this.callParent(arguments);
		}
	});

	return BPMSoft.BaseProcessParametersEditModule;
});
