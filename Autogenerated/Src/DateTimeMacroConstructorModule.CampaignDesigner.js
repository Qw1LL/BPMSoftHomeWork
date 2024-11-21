/**
 * Module to load DateTimeMacroConstructorPage.
 */
define("DateTimeMacroConstructorModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.DateTimeMacroConstructorModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.DateTimeMacroConstructorModule",

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @override
		 */
		generateViewContainerId: false,

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @override
		 */
		initSchemaName: function() {
			this.schemaName = "DateTimeMacroConstructorPage";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: BPMSoft.emptyFn
	});
	return BPMSoft.DateTimeMacroConstructorModule;
});
