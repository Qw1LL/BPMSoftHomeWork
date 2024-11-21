define("QueueModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.QueueModule
	 * ##### ###### ### ###### # ########.
	 */
	Ext.define("BPMSoft.configuration.QueueModule", {
		alternateClassName: "BPMSoft.QueueModule",
		extend: "BPMSoft.BaseSchemaModule",

		//region Methods: Private

		/**
		 * ############# ######## ###### ############# ########### ######.
		 * @private
		 * @param {BPMSoft.BaseViewModel} viewModel ###### #############.
		 */
		initViewModelAttributes: function(viewModel) {
			var parameters = this.parameters;
			viewModel.applyParameters(parameters);
			if (!Ext.isEmpty(parameters)) {
				var entitySchemaName = parameters.EntitySchemaName;
				require([entitySchemaName], function(entitySchema) {
					viewModel.set("EntitySchemaCaption", entitySchema.caption);
					viewModel.set("EntitySchemaPrimaryDisplayColumnName", entitySchema.primaryDisplayColumnName);
				}.bind(this));
			}
		},

		//endregion

		//region Methods: Protected

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "QueuePage";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#createViewModel
		 * @protected
		 * @overridden
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			this.initViewModelAttributes(viewModel);
			return viewModel;
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @protected
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn

		//endregion

	});
	return BPMSoft.QueueModule;
});
