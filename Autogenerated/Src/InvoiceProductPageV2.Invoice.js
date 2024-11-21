define("InvoiceProductPageV2", ["MoneyModule"],
		function(MoneyModule) {
			return {
				entitySchemaName: "InvoiceProduct",
				attributes: {
					"Invoice": {
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
					"CurrencyRate": {
						dataValueType: BPMSoft.DataValueType.FLOAT,
						type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
						value: 1
					},
					"MasterEntityColumnName": {
						dataValueType: this.BPMSoft.DataValueType.TEXT,
						value: "Invoice"
					}
				},
				messages: {
					"GetCardCurrencyRate": {
						mode: this.BPMSoft.MessageMode.PTP,
						direction: this.BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				details: /**SCHEMA_DETAILS*/{
				}/**SCHEMA_DETAILS*/,
				methods: {

					/**
					 * Processes product selection.
					 * @protected
					 */
					onProductSelect: this.Ext.emptyFn,

					/**
					 * Returns MoneyModule
					 * @return {BPMSoft.MoneyModule} money module.
					 */
					getMoneyModule: function() {
						return MoneyModule;
					},

					/**
					 * Returns currency division.
					 * @protected
					 * @return {Number} Division.
					 */
					getCurrencyDivision: function() {
						const invoice = this.get("Invoice");
						return invoice && invoice["Currency.Division"];
					},

					/**
					 * @inheritdoc BaseProductDetailPageV2#calculatePrimaryValues
					 * @override
					 */
					calculatePrimaryValues: function() {
						this.setCurrencyRateFromCard();
						this.callParent(arguments);
					},

					/**
					 * Sets currency rate from card.
					 * @protected
					 */
					setCurrencyRateFromCard: function() {
						const rate = this.sandbox.publish("GetCardCurrencyRate", null, ["InvoicePageV2"]);
						this.set("CurrencyRate", rate);
					},

					/**
					 * Returns entity schema query.
					 * @return {BPMSoft.EntitySchemaQuery} Invoice entity schema query.
					 */
					getInvoiceEsq: function() {
						return this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "Invoice"
						});
					},

					/**
					 * Loads invoice's currency.
					 * @param {Function} callback Callback function.
					 * @param {Object} scope Callback scope.
					 */
					loadCurrencyInvoice: function(callback, scope) {
						const invoice = this.get("Invoice");
						if (invoice && !invoice.CurrencyRate) {
							const select = this.getInvoiceEsq();
							select.addColumn("Currency.Division");
							select.addColumn("CurrencyRate");
							select.addColumn("Currency");
							select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
									this.BPMSoft.ComparisonType.EQUAL, "Id", invoice.value));
							select.execute(function(response) {
								response.collection.each(function(item) {
									invoice["Currency.Division"] = item.get("Currency.Division");
									invoice.CurrencyRate = item.get("CurrencyRate");
									invoice.Currency = item.get("Currency");
									callback.call(scope || this);
								}, this);
							}, this);
						}
					},

					/**
					 * Handles price list change.
					 * @protected
					 * @param {Boolean} isNotNeedCallParent Do not invoke callParent function flag.
					 */
					onPriceListChange: function(isNotNeedCallParent) {
						let result = true;
						const invoice = this.get("Invoice");
						if (!invoice) {
							return;
						}
						if (!isNotNeedCallParent) {
							result = this.callParent(arguments);
						}
						if (result) {
							if (invoice && !invoice.CurrencyRate) {
								this.loadCurrencyInvoice(this.setPriceAsync, this);
							} else {
								this.setPriceAsync();
							}
						}
					},

					/**
					 * @inheritdoc BasePageV2#onEntityInitialized
					 * @override
					 */
					onEntityInitialized: function() {
						this.callParent(arguments);
						this.set("ProductEntryMasterRecord", this.get("Invoice"));
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "Invoice",
						"parentName": "BaseGeneralInfoBlock",
						"propertyName": "items",
						"values": {
							"bindTo": "Invoice",
							"enabled": false,
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
