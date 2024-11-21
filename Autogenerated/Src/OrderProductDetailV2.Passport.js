define("OrderProductDetailV2", ["OrderUtilities"],
	function() {
		return {
			entitySchemaName: "OrderProduct",
			mixins: {
				OrderUtilities: "BPMSoft.OrderUtilities"
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BaseDetailV2#init
				 * @overridden
				 */
				init: function() {
					this.callParent(arguments);
					this.initValidateActions();
				},

				/**
				 * ############# #######.
				 * @protected
				 */
				initValidateActions: function() {
					var config = {
						getId: function() {
							var activeRow = this.get("ActiveRow");
							if (!activeRow) {
								return null;
							}
							var collection = this.getGridData();
							var item = collection.get(activeRow);
							return item.get("Order") && item.get("Order").value;
						},
						name: "Order"
					};
					this.deleteRecords = this.needToChangeInvoice(config, this.deleteRecords, this);
					this.editRecord = this.needToChangeInvoice(config, this.editRecord, this);
					this.addRecord = this.needToChangeInvoice(config, this.addRecord, this);
					this.copyRecord = this.needToChangeInvoice(config, this.copyRecord, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	}
);
