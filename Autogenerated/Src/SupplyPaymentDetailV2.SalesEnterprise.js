define("SupplyPaymentDetailV2", [],
	function() {
		return {
			entitySchemaName: "SupplyPaymentElement",
			methods: {
				getInvoiceProductInsertQuery: function(config, i) {
					var insert = this.callParent(arguments);
					var product = config.products.getByIndex(i);
					insert.setParameterValue("PriceList", product.get("PriceList").value,
						this.BPMSoft.DataValueType.GUID);
					return insert;
				},

				getSupplyPaymentProductEntitySchemaQuery: function() {
					var esq = this.callParent(arguments);
					esq.addColumn("Product.PriceList", "PriceList");
					return esq;
				}
			}
		};
	}
);
