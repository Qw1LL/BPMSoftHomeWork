define("OrderProductDetailV2", [], function() {
	return {
		entitySchemaName: "OrderProduct",
		methods: {
			init: function() {
				this.callParent(arguments);
				this.set("MultiSelect", false);
			}
		},
		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
