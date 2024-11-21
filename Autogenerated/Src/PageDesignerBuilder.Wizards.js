define("PageDesignerBuilder", ["ViewModelSchemaDesignerBuilder", "PageDesignerViewGenerator",
	"PageDesignerViewModelGenerator"
], function() {

	/**
	 * Page designer builder.
	 */
	Ext.define("BPMSoft.configuration.PageDesignerBuilder", {
		extend: "BPMSoft.configuration.ViewModelSchemaDesignerBuilder",
		alternateClassName: "BPMSoft.PageDesignerBuilder",

		// region Properties: Protected

		/**
		 * @inheritdoc BPMSoft.ViewModelSchemaDesignerBuilder#designerSchemaName
		 * @override
		 */
		designerSchemaName: "PageDesignerSchema",

		/**
		 * Flags that indicates whether designer is read only on not.
		 * @Boolean
		 */
		isReadOnly: false,

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.configuration.ViewModelSchemaDesignerBuilder#createDesignViewGenerator
		 * @override
		 */
		createDesignViewGenerator: function() {
			return Ext.create("BPMSoft.PageDesignerViewGenerator", {
				isReadOnly: this.isReadOnly
			});
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewModelSchemaDesignerBuilder#createViewModelGenerator
		 * @override
		 */
		createViewModelGenerator: function() {
			return Ext.create("BPMSoft.PageDesignerViewModelGenerator", {
				useCache: false,
				isReadOnly: this.isReadOnly
			});
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewModelSchemaDesignerBuilder#buildSchema
		 * @override
		 */
		buildSchema: function(config) {
			const schema = config.schema;
			schema.properties = schema.properties || {};
			schema.properties.isReadOnly = this.isReadOnly;
			this.callParent(arguments);
		},

		/**
		 * @inheritdoc BPMSoft.configuration.ViewModelSchemaDesignerBuilder#generateInfoViewConfig
		 * @override
		 */
		generateInfoViewConfig: function() {
			if (!this.isReadOnly) {
				this.callParent(arguments);
			}
		}

		// endregion

	});

	return BPMSoft.PageDesignerBuilder;
});
