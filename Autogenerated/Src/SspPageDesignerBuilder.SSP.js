define("SspPageDesignerBuilder", ["PageDesignerBuilder"], function() {

	Ext.define("BPMSoft.configuration.SspPageDesignerBuilder", {
		extend: "BPMSoft.configuration.PageDesignerBuilder",
		alternateClassName: "BPMSoft.SspPageDesignerBuilder",

		/**
		 * @inheritdoc BPMSoft.ViewModelSchemaDesignerBuilder#designerSchemaName
		 * @override
		 */
		designerSchemaName: "SspPageDesignerSchema"

	});

	return BPMSoft.SspPageDesignerBuilder;
});
