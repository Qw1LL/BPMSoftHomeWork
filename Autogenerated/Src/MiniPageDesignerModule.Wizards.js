define("MiniPageDesignerModule", ["ViewModelSchemaDesignerModule", "MiniPageDesignerBuilder",
	"css!ViewModelSchemaDesignerModule"
], function() {

	/**
	 * Mini page designer module.
	 */
	Ext.define("BPMSoft.configuration.MiniPageDesignerModule", {
		extend: "BPMSoft.configuration.ViewModelSchemaDesignerModule",
		alternateClassName: "BPMSoft.MiniPageDesignerModule",

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.ViewModelSchemaDesignerModule#createSchemaBuilder
		 * @override
		 */
		createSchemaBuilder: function() {
			return new BPMSoft.MiniPageDesignerBuilder();
		},

		/**
		 * @inheritdoc BPMSoft.ViewModelSchemaDesignerModule#getRootSchemaItem
		 * @override
		 */
		getRootSchemaItem: function() {
			return "AlignableMiniPageContainer";
		}

		// endregion

	});

	return BPMSoft.MiniPageDesignerModule;
});
