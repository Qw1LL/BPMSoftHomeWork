define("SspPageDesignerModule", ["PageDesignerModule", "SspPageDesignerBuilder",
		"css!ViewModelSchemaDesignerModule", "css!MainHeaderCSS",
		"css!PageDesignerModule"], function() {

	Ext.define("BPMSoft.configuration.SspPageDesignerModule", {
		extend: "BPMSoft.configuration.PageDesignerModule",
		alternateClassName: "BPMSoft.SspPageDesignerModule",

		/**
		 * @inheritDoc BPMSoft.PageDesignerModule#createSchemaBuilder
		 * @override
		 */
		createSchemaBuilder: function() {
			return new BPMSoft.SspPageDesignerBuilder({isReadOnly: this.isReadOnly});
		}
	});

	return BPMSoft.SspPageDesignerModule;
});
