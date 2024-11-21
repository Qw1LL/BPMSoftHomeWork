define("MultiDeleteDependencies", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.MultiDeleteDependencies", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.MultiDeleteDependencies",

		deletedRecordId: null,

		itemId: null,

		deletedEntitySchemaName: null,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @overridden
		 */
		useHistoryState: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "MultiDeleteDependenciesSchema";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#getViewModelConfig
		 * @overridden
		 */
		getViewModelConfig: function() {
			var viewModelConfig = this.callParent(arguments);
			Ext.apply(viewModelConfig, {
				values: {
					DeletedEntitySchemaName: this.deletedEntitySchemaName,
					DeletedRecordId: this.deletedRecordId,
					ItemId: this.itemId
				}
			});
			return viewModelConfig;
		}
	});

	return BPMSoft.MultiDeleteDependencies;
});
