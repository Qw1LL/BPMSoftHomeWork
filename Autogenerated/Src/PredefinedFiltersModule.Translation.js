define("PredefinedFiltersModule", ["ext-base", "BPMSoft", "BaseSchemaModuleV2"], function(Ext, BPMSoft) {
	/**
	 * @class BPMSoft.configuration.PredefinedFiltersModule
	 */
	Ext.define("BPMSoft.configuration.PredefinedFiltersModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.PredefinedFiltersModule",

		//region Properties: Protected

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @overridden
		 */
		useHistoryState: false,

		/**
		 * @inheritDoc BPMSoft.configuration.BaseSchemaModule#isSchemaConfigInitialized
		 * @overridden
		 */
		isSchemaConfigInitialized: true,

		/**
		 * @inheritDoc BPMSoft.configuration.BaseSchemaModule#schemaName
		 * @overridden
		 */
		schemaName: "PredefinedFiltersSchema"

		//endregion

	});
	return BPMSoft.PredefinedFiltersModule;
});
