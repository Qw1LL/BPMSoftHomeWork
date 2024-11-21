/**
 * Module to load CampaignTemplateEditPage.
 */
define("CampaignTemplateEditModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.CampaignTemplateEditModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.CampaignTemplateEditModule",

		sandbox: null,
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
			this.schemaName = "CampaignTemplateEditPage";
		},

		/**
		 * @inheritDoc BPMSoft.BaseSchemaModule#initHistoryState
		 * @override
		 */
		initHistoryState: BPMSoft.emptyFn
	});
	return BPMSoft.CampaignTemplateEditModule;
});
