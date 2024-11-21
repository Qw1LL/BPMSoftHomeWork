define("ContentPanelModule", ["ConfigurationModuleV2"], function() {
	/**
	 * @class BPMSoft.configuration.ContentPanelModule
	 * Class ContentPanelModule
	 */
	Ext.define("BPMSoft.configuration.ContentPanelModule", {
		extend: "BPMSoft.ConfigurationModule",
		alternateClassName: "BPMSoft.ContentPanelModule",
		/**
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = this.parameters.viewModelConfig.ElementInfo ? "ContentElementPanel": "ContentItemPanel";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @override
		 */
		useHistoryState: false

	});
	return BPMSoft.ContentPanelModule;
});
