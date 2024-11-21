define("SchemaAngularDesignToolItem", ["SchemaDesignToolItem"], function() {
	Ext.define("BPMSoft.SchemaAngularDesignToolItem", {
		extend: "BPMSoft.SchemaDesignToolItem",

		/**
		 * Widget config.
		 * @type {Object}
		 */
		item: null,

		/**
		 * @inheritdoc BPMSoft.configuration.SchemaDesignToolItem#getDesignItemConfg
		 * @override
		 */
		getDesignItemConfg: function() {
			return {
				itemConfig: {
					name: this.item.fileName,
					caption: this.item.fileName,
					layout: {colSpan: 11},
					sysSchemaId: this.item.sysSchemaId,
					sysSchemaUId: this.item.sysSchemaUId,
					angularParameters: this.item.angularParameters,
					imageData: this.item.imageData,
					appWrappers: this.item.appWrappers
				},
				parentViewModel: this.parentViewModel,
				itemType: 'Angular',
				schemaModelItemDesignerName: "SchemaModelItemDesigner",
				itemCaption: this.item.caption,
			};
		}
	});
	return BPMSoft.SchemaAngularDesignToolItem;
}); 