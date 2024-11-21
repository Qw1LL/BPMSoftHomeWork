define("EntityColumnsModule", ["ModalBox", "BaseSchemaModuleV2"], function() {
	/**
	 * EntityColumnsModule
	 */
	Ext.define("BPMSoft.configuration.EntityColumnsModule", {
		extend: "BPMSoft.configuration.BaseSchemaModule",
		alternateClassName: "BPMSoft.EntityColumnsModule",

		/**
		 * @inheritdoc BPMSoft.BaseModule#showMask
		 * @override
		 */
		showMask: true,

		/**
		 * Columns lookup info.
		 * @type []
		 */
		lookupInfo: null,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: Ext.emptyFn,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @override
		 */
		init: function() {
			this.showLoadingMask();
			this.lookupInfo = this.sandbox.publish("GetColumnsLookupInfo", null, [this.sandbox.id]) || {};
			this.callParent(arguments);
		},

		/**
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "EntityColumnLookupPage";
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getSchemaBuilderConfig
		 * @override
		 */
		getSchemaBuilderConfig: function() {
			const result = this.callParent(arguments);
			result.useCache = false;
			return result;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#generateSchemaStructure
		 * @override
		 */
		generateSchemaStructure: function(callback, scope) {
			const config = this.getSchemaBuilderConfig();
			this.schemaBuilder.build(config, function(viewModelClass, viewConfig) {
				callback.call(scope, viewModelClass, viewConfig);
			}, this);
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getViewModelConfig
		 * @override
		 */
		getViewModelConfig: function() {
			const viewModelConfig = this.callParent(arguments);
			let values = {
				modalBoxCaption: this.lookupInfo.modalBoxCaption
			};
			const originalValues = viewModelConfig ? viewModelConfig.values : null;
			values = Ext.apply(values, this.lookupInfo.values, originalValues);
			Ext.apply(viewModelConfig, {
				values: values
			});
			return viewModelConfig;
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
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getViewConfig
		 * @override
		 */
		getViewConfig: function(viewModel) {
			const viewConfig = this.callParent(arguments);
			if (Ext.isFunction(viewModel.getWrapClassNames)) {
				viewConfig.classes.wrapClassName.push(...viewModel.getWrapClassNames())
			}
			return viewConfig;
		}
	});

	return BPMSoft.EntityColumnsModule;
});
