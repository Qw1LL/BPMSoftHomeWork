define("Features", ["BaseSchemaModuleV2"], function() {

	Ext.define("BPMSoft.configuration.FeaturesModule", {
		alternateClassName: "BPMSoft.FeaturesModule",
		extend: "BPMSoft.BaseSchemaModule",

		useHistoryState: false,

		initSchemaName: function() {
			this.schemaName = "FeaturesPage";
		}

	});

	return BPMSoft.FeaturesModule;
});
