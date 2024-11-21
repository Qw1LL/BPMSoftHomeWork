define("CtiPanelModule", ["BaseSchemaModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.CtiPanelModule
	 * CTI panel page class to work with calls.
	 */
	Ext.define("BPMSoft.configuration.CtiPanelModule", {
		alternateClassName: "BPMSoft.CtiPanelModule",
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * Initializes the name of the scheme.
		 * @protected
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "CtiPanel";
		},

		/**
		 * Creates view model. Extends model {@link BPMSoft.CtiModel} by current class model.
		 * @protected
		 * @overridden
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			var model = Ext.merge(BPMSoft.CtiModel.model, viewModel.model);
			Ext.merge(viewModel, BPMSoft.CtiModel, {
				init: viewModel.init
			});
			viewModel.model = model;
			BPMSoft.CtiModel = BPMSoft.integration.telephony.CtiModel = viewModel;
			return viewModel;
		},

		/**
		 * Replaces the last element in the chain of states, if the identifier module is different from the current.
		 * @protected
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn

	});
	return BPMSoft.CtiPanelModule;
});
