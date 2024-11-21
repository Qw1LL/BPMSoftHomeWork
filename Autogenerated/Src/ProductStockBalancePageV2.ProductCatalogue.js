// D9 Team
define("ProductStockBalancePageV2", [],
	function() {
		return {
			entitySchemaName: "ProductStockBalance",
			attributes: {

				/**
				 * ######### ########## ########
				 * @type {BPMSoft.DataValueType.FLOAT}
				 */
				"AvailableQuantity": {
					dependencies: [ {
						columns: ["TotalQuantity", "ReserveQuantity"],
						methodName: "recalculateAvailableQuantity"
					}]
				}
			},
			methods: {

				/**
				 * ######## ########## ########## ######## ## ######
				 * @protected
				 */
				recalculateAvailableQuantity: function() {
					var totalQuantity = this.get("TotalQuantity") || 0.0;
					var reserveQuantity = this.get("ReserveQuantity") || 0.0;
					var availableQuantity = totalQuantity - reserveQuantity;
					this.set("AvailableQuantity", availableQuantity);
				},

				/**
				 * ######### ########## ######. ######## ############ ###### ### ########
				 * @protected
				 * @virtual
				 * @param callback ####### ######### ###### ### ########### #########
				 * @param scope ######## ##########
				 */
				validateWarehouse:  function(callback, scope) {
					var result = {
						success: true
					};
					var product = this.get("Product");
					var warehouse = this.get("Warehouse");
					if (this.Ext.isEmpty(product) || this.Ext.isEmpty(warehouse)) {
						result.message = this.get("Resources.Strings.CantCheckWarehouseError");
						result.success = false;
						callback.call(scope || this, result);
						return;
					}
					if (this.isNewMode() || this.changedValues.Warehouse) {
						var select = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "ProductStockBalance"
						});
						select.addAggregationSchemaColumn("Id", BPMSoft.AggregationType.COUNT, "IdCOUNT");
						select.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Product", product.value));
						select.filters.addItem(BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Warehouse", warehouse.value));
						select.getEntityCollection(function(response) {
							if (response.success) {
								if (response.collection.getCount() < 1) {
									result.message = this.get("Resources.Strings.CantCheckWarehouseError");
									result.success = false;
								} else {
									var selectResult  =  response.collection.getByIndex(0);
									var warehousesCount = selectResult.get("IdCOUNT");
									if (warehousesCount > 0) {
										result.message = this.get("Resources.Strings.WarehouseExists");
										result.success = false;
									}
								}
							} else {
								result.message = this.get("Resources.Strings.CantCheckWarehouseError");
								result.success = false;
							}
							callback.call(scope || this, result);
						}, this);
					} else {
						callback.call(scope || this, result);
					}
				},

				/**
				 * ########### ######### ########
				 * @protected
				 * @override
				 * @param callback ####### ######### ######
				 * @param scope ######## ##########
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						BPMSoft.chain(
							function(next) {
								this.validateWarehouse(function(response) {
									if (this.validateResponse(response)) {
										next();
									}
								}, this);
							},
							function(next) {
								callback.call(scope, response);
								next();
							}, this);
					}, this]);
				},

				/**
				 *  ########## ###### ######### ######## ########, #### ##### ## ################ ## #######
				 *  ####### ##### ######## # ####### ######
				 * @returns {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########
				 */
				getActions: function() {
					var parentActions = this.callParent(arguments);
					if (parentActions && !this.getSchemaAdministratedByRecords()) {
						parentActions.clear();
					}
					return parentActions;
				}
			},
			diff: /**SCHEMA_DIFF*/[
// Tabs
				{
					"operation": "merge",
					"name": "Tabs",
					"values": {
						"visible": false
					}
				},

// Columns and details
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Product",
					"values": {
						"bindTo": "Product",
						"layout": { "column": 0, "row": 0, "colSpan": 11 },
						"enabled": false,
						"controlConfig": {
							"enableRightIcon": false
						}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Warehouse",
					"values": {
						"bindTo": "Warehouse",
						"contentType": BPMSoft.ContentType.ENUM,
						"layout": { "column": 0, "row": 1, "colSpan": 11 }
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "TotalQuantity",
					"values": {
						"bindTo": "TotalQuantity",
						"layout": { "column": 13, "row": 0, "colSpan": 11 },
						"controlConfig": {"decimalPrecision": 3}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "ReserveQuantity",
					"values": {
						"bindTo": "ReserveQuantity",
						"layout": { "column": 13, "row": 1, "colSpan": 11 },
						"controlConfig": {"decimalPrecision": 3}
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "AvailableQuantity",
					"values": {
						"bindTo": "AvailableQuantity",
						"layout": { "column": 13, "row": 2, "colSpan": 11 },
						"enabled": false,
						"controlConfig": {"decimalPrecision": 3}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
