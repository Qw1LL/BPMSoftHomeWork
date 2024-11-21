define("FullscreenHeaderModule", ["BaseSchemaModuleV2"], function() {
	Ext.define("BPMSoft.configuration.FullscreenHeaderModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.FullscreenHeaderModule",

		/**
		 * @inheritdoc BaseSchemaModule#initSchemaName
		 * @override
		 */
		initSchemaName: function() {
			this.schemaName = "FullscreenHeaderSchema";
		}

	});
	return BPMSoft.FullscreenHeaderModule;
});
