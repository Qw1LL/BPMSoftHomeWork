define("ConfigurationModuleV2", ["BusinessRulesApplierV2", "BaseSchemaModuleV2"], function(BusinessRulesApplier) {

	/**
	 * @class BPMSoft.configuration.ConfigurationModule
	 * ##### ###### ######### ######### #####.
	 */
	Ext.define("BPMSoft.configuration.ConfigurationModule", {
		alternateClassName: "BPMSoft.ConfigurationModule",
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#createViewModel
		 * ##### ### #### ########, ######### ########### #######
		 * (##. {@link BPMSoft.BusinessRulesApplier.applyDependencies}).
		 * @protected
		 * @overridden
		 * @param {Object} viewModelClass ##### ###### ############# #####.
		 * @return {Object} ########## ######### ###### ############# #####.
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			BusinessRulesApplier.applyDependencies(viewModel);
			return viewModel;
		},


		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#prepareHistoryState
		 * @protected
		 * @overridden
		 */
		prepareHistoryState: function() {
			var newState = this.callParent(arguments);
			this.schemaName = newState.designerSchemaName;
			delete newState.designerSchemaName;
			return newState;
		},

		/**
		 * ############## ######## #####.
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			var historyState = this.sandbox.publish("GetHistoryState");
			var hash = historyState.hash;
			var state = historyState.state;
			this.schemaName = this.schemaName || hash.entityName || "";
		}

	});
	return BPMSoft.ConfigurationModule;

});
