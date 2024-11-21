define("SocialAccountModule", [], function() {
	Ext.define("BPMSoft.configuration.SocialAccountModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.SocialAccountModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#generateViewContainerId
		 * @overridden
		 */
		generateViewContainerId: false,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @overridden
		 */
		initSchemaName: function() {
			this.schemaName = "SocialAccountModuleSchema";
		}
	});
	return BPMSoft.SocialAccountModule;
});
