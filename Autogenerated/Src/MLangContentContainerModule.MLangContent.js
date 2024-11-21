define("MLangContentContainerModule", ["BusinessRulesApplierV2", "BaseSchemaModuleV2"], function(BusinessRulesApplier) {
	Ext.define("BPMSoft.configuration.MLangContentContainerModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.MLangContentContainerModule",

		/**
		 * Set income parameters in ViewModel instance.
		 * @param {BPMSoft.BaseViewModel} viewModel ViewModel instance.
		 * @private
		 */
		_setViewModelAttributes: function(viewModel) {
			viewModel.set("parameters", this.parameters);
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = this.parameters.moduleSchemaName;
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#createViewModel
		 * @protected
		 * @overridden
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			if (viewModel.type === BPMSoft.SchemaType.EDIT_VIEW_MODEL_SCHEMA) {
				BusinessRulesApplier.applyDependencies(viewModel);
			}
			this._setViewModelAttributes(viewModel);
			return viewModel;
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn
	});
	return BPMSoft.MLangContentContainerModule;
});
