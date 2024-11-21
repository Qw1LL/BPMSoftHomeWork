define("InvoicePageV2", ["BusinessRuleModule", "InvoiceConfigurationConstants"],
	function(BusinessRuleModule, InvoiceConfigurationConstants) {
		return {
			entitySchemaName: "Invoice",
			methods: {
				/**
				 * @inheritDoc BPMSoft.BasePageV2#onEntityInitialized
				 * @overridden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.readSupplyPaymentElement();
				},

				/**
				 * ##### #### ### ####### ######## # #####, ######### # ####### ######.
				 * @param {Function} callback ##### ######### ######.
				 * @param {Object} scope ######## ##########.
				 * @private
				 */
				readSupplyPaymentElement: function(callback, scope) {
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SupplyPaymentElement",
						rowCount: 1
					});
					esq.addColumn("Id");
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Invoice", this.get("Id")));
					esq.getEntityCollection(function(response) {
						var element = null;
						var collection = response.collection;
						if (collection && collection.getCount()) {
							var item = collection.getByIndex(0);
							element = {value: item.get("Id")};
						}
						this.set("SupplyPaymentElement", element);
						if (callback) {
							callback.call(scope || this);
						}
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#save
				 * @overridden
				 */
				save: function(config) {
					if (!this.get("IsCancel")) {
						this.needToCancelInvoice(function(result) {
							if (result) {
								this.set("IsCancel", true);
								this.save(config);
							}
						}, this);
					} else {
						this.set("IsCancel", false);
						this.callParent(arguments);
					}

				},

				/**
				 * ########## #### # ######## # ####### ##### ## #### ####.
				 * @protected
				 * @param {Function} callback ####### ######### ######.
				 * @param {Object} scope ######## ######### ######.
				 */
				needToCancelInvoice: function(callback, scope) {
					var supplyPaymentElement = this.get("SupplyPaymentElement");
					var paymentStatus = this.get("PaymentStatus") || {};
					var isCancel = this.get("IsCancel");
					if (paymentStatus.value === InvoiceConfigurationConstants.Invoice.PaymentStatus.Canceled &&
							supplyPaymentElement && !isCancel) {
						this.showConfirmationDialog(this.get("Resources.Strings.CleanupSupplyPaymentElement"),
							function(dialogResult) {
								if (dialogResult === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
									callback.call(scope, true);
								} else {
									callback.call(scope, false);
								}
							},
							["yes", "no"]
						);
					} else {
						callback.call(scope, true);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BasePageV2#saveEntityInChain
				 * @overridden
				 */
				saveEntityInChain: function(next) {
					var callback = next;
					if (this.get("SupplyPaymentElement")) {
						callback = this.readSupplyPaymentElement.bind(this, next);
					}
					this.callParent([callback]);
				}
			},
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
