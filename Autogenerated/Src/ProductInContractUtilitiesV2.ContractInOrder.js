define("ProductInContractUtilitiesV2", [],
	function() {
		/**
		* @class BPMSoft.configuration.ProductInContractUtilities
		* ############### #####
		*/
		Ext.define("BPMSoft.configuration.ProductInContractUtilities", {
			alternateClassName: "BPMSoft.ProductInContractUtilities",

			scope: null,

			/**
			 * ######### ########## ######### ###### ### ###### #######,
			 * ####### ########## ####### # ####### #########.
			 * @private
			 * @param {String} orderId ############# ######.
			 * @param {String} contractId ############# ########.
			 * @param {Function} callback ####### ######### ######.
			 * @param {Object} scope ########.
			 */
			openProductLookupToLink: function(orderId, contractId, callback, scope) {
				var config = {
					entitySchemaName: "OrderProduct",
					multiSelect: true,
					hideActions: true,
					columns: ["Name"]
				};
				this.scope = scope || this;
				this.BPMSoft = this.scope.BPMSoft;
				this.Ext = this.scope.Ext;
				this.callback = callback;

				var filters = this.BPMSoft.createFilterGroup();
				var idFilter = this.BPMSoft.createColumnFilterWithParameter(this.BPMSoft.ComparisonType.EQUAL,
					"Order", orderId);
				var contractIsNull = this.BPMSoft.createColumnIsNullFilter("Contract");
				filters.addItem(idFilter);
				filters.addItem(contractIsNull);
				config.filters = filters;
				this.scope.openLookup(config, function(response) {
					this.linkSelectedRecords(response, orderId, contractId);
				}, this);
			},

			/**
			 * ######### ##### ### ######### ######### # ####### #########.
			 * @private
			 * @param {Object} items ###### #### {columnName: string, selectedRows: []}.
			 * ######## ###### ######### ####### ## ###########.
			 * @param {String} orderId ############# ######.
			 * @param {String} contractId ############# ########.
			 */
			linkSelectedRecords: function(items, orderId, contractId) {
				var selectedRows = items.selectedRows.getKeys();
				if (items.selectedRows.getCount() > 0) {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "OrderProduct"
					});
					update.setParameterValue("Contract", contractId, this.BPMSoft.DataValueType.GUID);
					update.filters.addItem(this.BPMSoft.createColumnInFilterWithParameters("Id", selectedRows));
					update.execute(function() {
						this.updateContractAmount(orderId, contractId);
					}, this);
				}
			},

			/**
			 * ########## ######## # ####### #########.
			 * @private
			 * @param {String} orderId ############# ######.
			 * @param {String} contractId ############# ########.
			 */
			connectProducts: function(orderId, contractId) {
				var update = this.Ext.create("BPMSoft.UpdateQuery", {
					rootSchemaName: "OrderProduct"
				});
				update.setParameterValue("Contract", contractId, this.BPMSoft.DataValueType.GUID);
				update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Order",  orderId));
				update.filters.addItem(this.BPMSoft.createColumnIsNullFilter("Contract"));
				update.execute(function() {
					this.updateContractAmount(orderId, contractId);
				}, this);
			},

			/**
			 * ######### ####### ############# ######### # #########.
			 * @private
			 * @param {String} orderId ############# ######.
			 * @param {Function} callback ####### ######### ######.
			 */
			getIsOrderHasUnlinkedProducts: function(orderId, callback) {
				var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "OrderProduct"
				});
				select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Order",  orderId));
				select.filters.addItem(this.BPMSoft.createColumnIsNullFilter("Contract"));
				select.execute(function(response) {
					if (response && response.success) {
						if (response.collection.getCount() > 0) {
							callback.call(this, true);
						} else {
							callback.call(this, false);
						}
					}
				}, this);
			},

			/**
			 * ############ ##### ######### # ######## # ######### ##.
			 * @private
			 * @param {String} orderId ############# ######.
			 * @param {String} contractId ############# ########.
			 */
			updateContractAmount: function(orderId, contractId) {
				var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "OrderProduct"
				});
				select.addAggregationSchemaColumn("TotalAmount", this.BPMSoft.AggregationType.SUM, "TotalAmountSum");
				var filterGroup = new this.BPMSoft.createFilterGroup();
				filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
				filterGroup.add("OrderFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Order", orderId));
				filterGroup.add("ContractFilter", this.BPMSoft.createColumnFilterWithParameter(
					this.BPMSoft.ComparisonType.EQUAL, "Contract", contractId));
				select.filters = filterGroup;
				select.getEntityCollection(function(response) {
					if (response.success && response.collection) {
						var items = response.collection.getItems();
						if (items.length > 0) {
							var update = this.Ext.create("BPMSoft.UpdateQuery", {
								rootSchemaName: "Contract"
							});
							update.setParameterValue("Amount", items[0].get("TotalAmountSum"),
								this.BPMSoft.DataValueType.MONEY);
							update.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Id", contractId));
							update.execute(function() {
								if (this.callback) {
									this.callback.call(this.scope, contractId);
								}
							}, this);
						}
					}
				}, this);
			}
		});
		return Ext.create(BPMSoft.configuration.ProductInContractUtilities);
	});
