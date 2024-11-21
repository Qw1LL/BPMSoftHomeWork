define("ProductDetailV2", [], function() {
		return {
			methods: {
				/**
				 * @inheritdoc BPMSoft.ProductDetailV2#productSelectionHandler
				 * @overridden
				 */
				onProductsSelected: function() {
					this.callParent();
					this.updateOrderProductCurrency();
				},

				/**
				 * Setups order currency for products that has empty order currency
				 * @virtual
				 */
				updateOrderProductCurrency: function() {
					var orderId = this.get("MasterRecordId");
					if (!orderId) {
						return;
					}
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "Order"
					});
					esq.addColumn("Currency");
					esq.addColumn("CurrencyRate");
					esq.getEntity(orderId, function(result) {
						var entity = result.entity;
						if (!entity) {
							return;
						}
						var currency = entity.get("Currency");
						var currencyRate = entity.get("CurrencyRate");
						var update = this.Ext.create("BPMSoft.UpdateQuery", {
							rootSchemaName: "OrderProduct"
						});
						update.setParameterValue("Currency", currency.value, this.BPMSoft.DataValueType.GUID);
						update.setParameterValue("CurrencyRate", currencyRate, this.BPMSoft.DataValueType.FLOAT);
						update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Order", orderId));
						update.filters.addItem(this.BPMSoft.createIsNullFilter(
							this.Ext.create("BPMSoft.ColumnExpression", {columnPath: "Currency"})));
						update.execute();
					}, this);
				}
			}
		};
	}
);
