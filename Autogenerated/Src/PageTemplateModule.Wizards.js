define("PageTemplateModule", ["MaskHelper", "BaseSchemaModuleV2"], function(MaskHelper) {
	Ext.define("BPMSoft.PageTemplateModule", {
		extend: "BPMSoft.BaseSchemaModule",

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#useHistoryState
		 * @override
		 */
		useHistoryState: false,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#showMask
		 * @override
		 */
		showMask: true,

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#initSchemaName
		 * @override
		 */
		initSchemaName: function() {
			this.schemaName = "PageTemplateLookupPage";
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#getWrapClassNames
		 * @override
		 */
		getWrapClassNames: function() {
			var classes = this.callParent();
			classes.push("page-template-lookup");
			return classes;
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#render
		 * @override
		 */
		render: function() {
			this.callParent(arguments);
			MaskHelper.HideBodyMask();
		},

		/**
		 * @inheritdoc BPMSoft.BaseSchemaModule#init
		 * @override
		 */
		init: function() {
			MaskHelper.ShowBodyMask();
			this.callParent(arguments);
		}
	});

	return BPMSoft.PageTemplateModule;
});
