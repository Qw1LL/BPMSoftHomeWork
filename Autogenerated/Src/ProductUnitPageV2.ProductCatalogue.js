define("ProductUnitPageV2", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "ProductUnit",
			attributes: {
				/**
				 * ####### #########.
				 * @type: {BPMSoft.DataValueType.LOOKUP}
				 */
				"Unit": {
					"isRequired": true
				},

				/**
				 * ########## ####### #########.
				 * @type: {BPMSoft.DataValueType.FLOAT}
				 */
				"OldNumberOfBaseUnits": {
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: this.BPMSoft.DataValueType.FLOAT
				},

				/**
				 * ########## ####### ###### #########.
				 * @type: {BPMSoft.DataValueType.FLOAT}
				 */
				"NumberOfBaseUnits": {
					dependencies: [
						{
							columns: ["IsBase"],
							methodName: "isBaseChange"
						}
					]
				},

				/**
				 * ####, ######## ## ######## ####### #######
				 * @type: {BPMSoft.DataValueType.BOOLEAN}
				 */
				"CanChangeIsBase": {
					type: this.BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: this.BPMSoft.DataValueType.BOOLEAN
				},

				/**
				 * ####, ####### ######### #### ########
				 * @type: {BPMSoft.DataValueType.BOOLEAN}
				 */
				"IsUnitChanged": { dataValueType: this.BPMSoft.DataValueType.BOOLEAN }
			},
			rules: {
				/**
				 * ######-####### #### "#######"
				 */
				"IsBase": {
					"EnabledIsBase": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.ENABLED,
						conditions: [
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "CanChangeIsBase"
								},
								comparisonType: this.BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: false
								}
							}
						]
					}
				},

				/**
				 * ######-####### #### "########## ####### ######"
				 */
				"NumberOfBaseUnits": {
					"EnabledNumberOfBaseUnits": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.ENABLED,
						conditions: [
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "IsBase"
								},
								comparisonType: this.BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: false
								}
							}
						]
					},
					"RequiredNumberOfBaseUnits": {
						ruleType: BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						property: BusinessRuleModule.enums.Property.REQUIRED,
						conditions: [
							{
								leftExpression: {
									type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									attribute: "IsBase"
								},
								comparisonType: this.BPMSoft.ComparisonType.EQUAL,
								rightExpression: {
									type: BusinessRuleModule.enums.ValueType.CONSTANT,
									value: false
								}
							}
						]
					}
				}
			},
			methods: {
				/**
				 * ######## ###### ## ######### ###### ###### ####### ######### # ######### #######
				 * @protected
				 * @param id
				 * @param numberOfBaseUnits
				 * @returns {BPMSoft.UpdateQuery} ########## ###### ## ######### ######
				 */
				getProductUnitUpdateQuery: function(id, numberOfBaseUnits) {
					var update = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "ProductUnit"
					});
					var product = this.get("Product");
					var oldNumberOfBaseUnits = this.get("OldNumberOfBaseUnits");
					oldNumberOfBaseUnits =
						(this.Ext.isEmpty(oldNumberOfBaseUnits) ||
							oldNumberOfBaseUnits === 0) ? 1 : oldNumberOfBaseUnits;
					var newNumberOfBaseUnits = numberOfBaseUnits / oldNumberOfBaseUnits;
					var filters = update.filters;
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Product", product.value));
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", id));
					update.setParameterValue("IsBase", false, this.BPMSoft.DataValueType.BOOLEAN);
					update.setParameterValue("NumberOfBaseUnits", newNumberOfBaseUnits,
						this.BPMSoft.DataValueType.FLOAT);
					return update;
				},

				/**
				 * ############# ####### ######### ### ######### ####### #######
				 * @param callback
				 */
				reCalcProductUnitAfterChangeBaseUnit: function(callback) {
					var product =  this.get("Product");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "ProductUnit"
					});
					esq.addColumn("Id");
					esq.addColumn("Product");
					esq.addColumn("Unit");
					esq.addColumn("IsBase");
					esq.addColumn("NumberOfBaseUnits");
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Product.Id", product.value));
					esq.getEntityCollection(function(response) {
						if (response.success) {
							var batch = this.Ext.create("BPMSoft.BatchQuery");
							response.collection.each(function(item) {
								if (this.get("Id") !== item.get("Id")) {
									var update = this.getProductUnitUpdateQuery(
										item.get("Id"),
										item.get("NumberOfBaseUnits"));
									batch.add(update, function() {}, this);
								}
							}, this);
							batch.execute(function() {
								callback.call(this);
							}, this);
						} else {
							callback.call(this);
						}
					}, this);
				},

				/**
				 * ######## ###### ## ######### ###### ###### ########
				 * @protected
				 * @returns {BPMSoft.UpdateQuery} ########## ###### ## ######### ######
				 */
				getProductUpdateQuery: function() {
					var updateProduct = this.Ext.create("BPMSoft.UpdateQuery", {
						rootSchemaName: "Product"
					});
					var product = this.get("Product");
					var filters = updateProduct.filters;
					filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", product.value));
					updateProduct.setParameterValue("Unit", this.get("Unit").value, this.BPMSoft.DataValueType.GUID);
					return updateProduct;
				},

				/**
				 * ######### ############## ######## ##### ########## ######
				 * @protected
				 * @overriden
				 * @param response
				 * @param config
				 */
				onSaved: function(response, config) {
					var canSaved = (config && config.canSaved) ? config.canSaved : false;
					var isBase = this.get("IsBase");
					if (isBase && !canSaved) {
						this.reCalcProductUnitAfterChangeBaseUnit(function() {
							this.getProductUpdateQuery().execute(function() {
								var info = config || {};
								info.canSaved = true;
								this.onSaved(response, info);
							}, this);
						});
					}
					if (canSaved || !isBase) {
						if (isBase) {
							config.isSilent = true;
							this.callParent(arguments);
							var updateConfig = {detail: "ProductPriceDetail",
								reloadAll: true,
								primaryColumnValue: this.get(this.primaryColumnName)
							};
							this.sandbox.publish("UpdateDetail", updateConfig, [this.sandbox.id]);
							this.sandbox.publish("BackHistoryState");
						} else {
							this.callParent(arguments);
						}
					}
				},

				/**
				 * ######### ############## ######## ##### ############# ########
				 * @protected
				 * @overriden
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.canChangeIsBase();
				},

				/**
				 * ######### ########### ######### #### "#######"
				 * @protected
				 */
				canChangeIsBase: function() {
					this.set("CanChangeIsBase", this.get("IsBase"));
				},

				/**
				 * ############ ######### #### "#######"
				 * @protected
				 */
				isBaseChange: function() {
					var isBase = this.get("IsBase");
					if (isBase) {
						this.set("OldNumberOfBaseUnits", this.get("NumberOfBaseUnits"));
						this.set("NumberOfBaseUnits", 1);
					}
				},

				/**
				 * ########## ################ ######### ##### ########
				 * @protected
				 * @param callback
				 * @param scope
				 */
				validateUnit: function(callback, scope) {
					var result = {
						success: true
					};
					if (this.isNewMode() || this.changedValues.Unit) {
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "ProductUnit"
						});
						esq.addAggregationSchemaColumn("Id", this.BPMSoft.AggregationType.COUNT, "Count");
						esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Product", this.get("Product").value));
						var unit = this.get("Unit");
						esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "Unit", unit.value));
						esq.getEntityCollection(function(response) {
							var unique = true;
							if (response.success) {
								unique = (response.collection.getCount() > 0 &&
									response.collection.getItems()[0].get("Count") > 0) ? false : true;
							}
							if (!unique) {
								result.message = this.get("Resources.Strings.UnitExistsMessage");
								result.success = false;
							}
							callback.call(scope || this, result);
						}, this);
					} else {
						callback.call(scope || this, result);
					}
				},

				/**
				 * ########## ########### ######### ##### ########
				 * @protected
				 * @overriden
				 * @param callback
				 * @param scope
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (!this.validateResponse(response)) {
							return;
						}
						this.BPMSoft.chain(
							function(next) {
								this.validateUnit(function(response) {
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
					"name": "IsBase",
					"values": {
						"bindTo": "IsBase",
						"layout": { "column": 13, "row": 0, "colSpan": 11 }
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "Unit",
					"values": {
						"bindTo": "Unit",
						"layout": { "column": 0, "row": 1, "colSpan": 11 },
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "Header",
					"propertyName": "items",
					"name": "NumberOfBaseUnits",
					"values": {
						"bindTo": "NumberOfBaseUnits",
						"layout": { "column": 13, "row": 1, "colSpan": 11 }
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
