define("SchemaColumnDesignToolItem", ["SchemaDesignToolItem"], function() {
	Ext.define("BPMSoft.SchemaColumnDesignToolItem", {
		extend: "BPMSoft.SchemaDesignToolItem",

		/**
		 * Design schema column
		 * @type {BPMSoft.EntitySchemaColumn}
		 */
		column: null,

		/**
		 * @inheritdoc BPMSoft.SchemaColumnDesignToolItem#getDesignItemConfg
		 * @override
		 */
		getDesignItemConfg: function() {
			return {
				itemConfig: {
					name: this.column.name,
					layout: {colSpan: 11}
				},
				column: this.column,
				schemaModelItemDesignerName: "SchemaModelItemDesigner",
				parentViewModel: this.parentViewModel
			};
		}
	});
	return BPMSoft.SchemaColumnDesignToolItem;
});
