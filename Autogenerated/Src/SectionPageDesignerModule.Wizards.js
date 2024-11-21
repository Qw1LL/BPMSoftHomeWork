define("SectionPageDesignerModule", [
	"PageDesignerModule",
	"css!ViewModelSchemaDesignerModule",
	"css!PageDesignerModule",
	"css!SectionPageDesignerModule",
	"css!MainHeaderCSS"
], function() {

	Ext.define("BPMSoft.configuration.SectionPageDesignerModule", {
		extend: "BPMSoft.configuration.PageDesignerModule",
		alternateClassName: "BPMSoft.SectionPageDesignerModule",

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.PageDesignerModule#createSchemaBuilder
		 * @override
		 */
		createSchemaBuilder: function() {
			return new BPMSoft.ViewModelSchemaDesignerBuilder();
		}

		// endregion

	});

	return BPMSoft.SectionPageDesignerModule;
});
