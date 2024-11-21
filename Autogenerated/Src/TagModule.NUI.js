define("TagModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.TagModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.TagModule",

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
			this.schemaName = "TagModuleSchema";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn,

		/**
		 * ####### ###### # ############# ## ########### ######.
		 * @overridden
		 */
		createViewModel: function() {
			var viewModel = this.callParent(arguments);
			var parameters = this.parameters;
			if (parameters) {
				viewModel.set("TagSchemaName", parameters.TagSchemaName);
				viewModel.set("InTagSchemaName", parameters.InTagSchemaName);
				viewModel.set("RecordId", parameters.RecordId);
			}
			return viewModel;
		}
	});
	return BPMSoft.TagModule;
});
