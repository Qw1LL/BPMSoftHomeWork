define("PRMPartnerManagerModule", ["BaseSchemaModuleV2"], function() {

	Ext.define("BPMSoft.configuration.PRMPartnerManagerModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.PRMPartnerManagerModule",


		useHistoryState: false,


		initSchemaName: function() {
			this.schemaName = "PRMPartnerManagerSchema";
		}
	});
	return BPMSoft.PRMPartnerManagerModule;
});
