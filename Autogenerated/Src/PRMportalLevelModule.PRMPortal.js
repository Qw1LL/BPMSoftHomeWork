define("PRMportalLevelModule", ["BaseSchemaModuleV2"], function() {

	Ext.define("BPMSoft.configuration.PRMportalLevelModule", {
		extend: "BPMSoft.BaseSchemaModule",
		alternateClassName: "BPMSoft.PRMportalLevelModule",


		useHistoryState: false,


		initSchemaName: function() {
			this.schemaName = "PRMportalLevelSchema";
		}
	});
	return BPMSoft.PRMportalLevelModule;
});
