define("MiniPageDesignerBuilder", ["ViewModelSchemaDesignerBuilder", "MiniPageDesignerViewGenerator",
	"MiniPageDesignerViewModelGenerator"
], function() {

	/**
	 * Mini page designer builder.
	 */
	Ext.define("BPMSoft.configuration.MiniPageDesignerBuilder", {
		extend: "BPMSoft.configuration.ViewModelSchemaDesignerBuilder",
		alternateClassName: "BPMSoft.MiniPageDesignerBuilder",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ViewModelSchemaDesignerBuilder#designerSchemaName
		 * @override
		 */
		designerSchemaName: "MiniPageDesignerSchema",

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.configuration.ViewModelSchemaDesignerBuilder#createDesignViewGenerator
		 * @override
		 */
		createDesignViewGenerator: function() {
			return Ext.create("BPMSoft.MiniPageDesignerViewGenerator");
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewModelSchemaDesignerBuilder#createViewModelGenerator
		 * @override
		 */
		createViewModelGenerator: function() {
			return Ext.create("BPMSoft.MiniPageDesignerViewModelGenerator", {
				useCache: false
			});
		},

		/**
		 * @inheritdoc BPMSoft.configuration.mixins.ViewModelSchemaValidationMixin#getViewSchemaRootItemName
		 * @override
		 */
		getViewSchemaRootItemName: function() {
			return "AlignableMiniPageContainer";
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewModelSchemaDesignerBuilder#buildSchema
		 * @override
		 */
		buildSchema: function(config) {
			config.schema.attributes = config.schema.attributes || {};
			this.callParent(arguments);
		}

		// endregion

	});

	return BPMSoft.MiniPageDesignerBuilder;
});
