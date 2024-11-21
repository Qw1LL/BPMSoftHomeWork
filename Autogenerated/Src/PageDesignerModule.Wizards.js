define("PageDesignerModule", [
	"ViewModelSchemaDesignerModule",
	"PageDesignerBuilder",
	"css!ViewModelSchemaDesignerModule",
	"css!MainHeaderCSS"
], function() {

	Ext.define("BPMSoft.configuration.PageDesignerModule", {
		extend: "BPMSoft.configuration.ViewModelSchemaDesignerModule",
		alternateClassName: "BPMSoft.PageDesignerModule",

		/**
		 * Flag that indicates that the schema is available in read-only mode
		 * @type {Boolean}
		 */
		isReadOnly: false,

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.ViewModelSchemaDesignerModule#createSchemaBuilder
		 * @override
		 */
		createSchemaBuilder: function() {
			return new BPMSoft.PageDesignerBuilder({isReadOnly: this.isReadOnly});
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#render
		 * @override
		 */
		render: function(renderTo) {
			this.callParent(arguments);
			if (this.isReadOnly) {
				const selector = "#" + renderTo.id;
				BPMSoft.Mask.show({
					selector: selector,
					frameVisible: false,
					caption: "",
					opacity: 0,
					showSpinner: false,
					clearMasks: true
				});
			}
		}

		// endregion

	});

	return BPMSoft.PageDesignerModule;
});
