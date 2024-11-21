define("CasePageTimeZoneModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.CasePageTimeZoneModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.CasePageTimeZoneModule",

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
			this.schemaName = "CasePageTimeZoneModuleSchema";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @overridden
		 */
		initHistoryState: Ext.emptyFn
	});
	return BPMSoft.CasePageTimeZoneModule;
});
