define("OrderProductPageV2", ["MoneyModule", "MoneyUtilsMixin"],
		function(MoneyModule) {
			return {
				entitySchemaName: "OrderProduct",
				attributes: {
					/**
					 * Product currency.
					 */
					"Currency": {
						dataValueType: BPMSoft.DataValueType.FLOAT,
						lookupListConfig: {
							columns: ["Division"]
						}
					},
					"Order": {
						lookupListConfig: {
							columns: ["CurrencyRate", "Currency", "Currency.Division"]
						}
					},
					"PrimaryPrice": {
						dependencies: [
							{
								columns: ["Price", "Amount", "DiscountAmount", "TaxAmount", "TotalAmount"],
								methodName: "calculatePrimaryValues"
							}
						]
					},
					"MasterEntityColumnName": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: "Order"
					}
				},
				mixins: {
					MoneyUtilities: "BPMSoft.MoneyUtilsMixin"
				},
				methods: {
					/**
					 * @inheritdoc BasePageV2#onEntityInitialized
					 * @override
					 */
					onEntityInitialized: function() {
						this.callParent(arguments);
						this.set("ProductEntryMasterRecord", this.get("Order"));
					},

					/**
					 * Returns currency division.
					 * @protected
					 */
					getCurrencyDivision: function() {
						const currency = this.get("Currency");
						const division = this.get("Currency.Division");
						return (currency && currency.Division) || division;
					},

					/**
					 * Loads order's currency.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback scope.
					 */
					loadCurrencyOrder: function(callback, scope) {
						const order = this.get("Order");
						if (order && !order.CurrencyRate) {
							const select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
								rootSchemaName: "Order"
							});
							select.addColumn("Currency.Division");
							select.addColumn("CurrencyRate");
							select.addColumn("Currency");
							select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
									this.BPMSoft.ComparisonType.EQUAL, "Id", order.value));
							select.execute(function(response) {
								response.collection.each(function(item) {
									order["Currency.Division"] = item.get("Currency.Division");
									order.CurrencyRate = item.get("CurrencyRate");
									order.Currency = item.get("Currency");
									callback.call(scope || this);
								}, this);
							}, this);
						}
					},

					/**
					 * Handles product select.
					 * @protected
					 */
					onProductSelect: this.Ext.emptyFn,

					/**
					 * Handles price list change.
					 * @protected
					 * @param {Boolean} isNotNeedCallParent Do not invoke callParent function flag.
					 */
					onPriceListChange: function(isNotNeedCallParent) {
						let result = true;
						const order = this.get("Order");
						if (!order) {
							return;
						}
						if (!isNotNeedCallParent) {
							result = this.callParent(arguments);
						}
						if (result) {
							if (order && !order.CurrencyRate) {
								this.loadCurrencyOrder(this.setPriceAsync, this);
							} else {
								this.setPriceAsync();
							}
						}
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "Order",
						"parentName": "BaseGeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "Order",
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							}
						}
					}, {
						"operation": "remove",
						"name": "DeliveryDate"
					}
				]/**SCHEMA_DIFF*/
			};
		});
