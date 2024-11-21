define("InvoiceProductDetailV2", [], function() {
	return {
		entitySchemaName: "InvoiceProduct",
		attributes: {},
		methods: {
			init: function() {
				this.callParent(arguments);
				this.set("MultiSelect", false);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
