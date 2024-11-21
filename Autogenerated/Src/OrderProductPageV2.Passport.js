define("OrderProductPageV2", ["BusinessRuleModule", "OrderUtilities"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "OrderProduct",
			mixins: {
				OrderUtilities: "BPMSoft.OrderUtilities"
			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#asyncValidate
				 * @protected
				 * @overridden
				 */
				asyncValidate: function(callback, scope) {
					this.callParent([function(response) {
						if (response.success && this.needValidateQuantity()) {
							this.validateQuantity(callback);
						} else {
							callback.call(scope, response);
						}
					}, this]);
				},

				/**
				 * ########## ############ ######### ##########.
				 * @return {Boolean} true, #### ########## #########.
				 */
				needValidateQuantity: function() {
					return this.changedValues && this.changedValues.hasOwnProperty("Quantity");
				},

				/**
				 * ######### ######## ########## # ########.
				 * @param {Function} callback ##### ######### ######.
				 */
				validateQuantity: function(callback) {
					this.callService({
						serviceName: "OrderPassportService",
						methodName: "ValidateOrderProductQuantity",
						data: {
							"orderProductId": this.get("Id"),
							"newQuantity": this.get("Quantity")
						}
					}, function(response) {
						var responseResult = response.ValidateOrderProductQuantityResult || {};
						callback.call(this, {
							success: responseResult.success,
							message: (responseResult.errorInfo && responseResult.errorInfo.message) || ""
						});
					}, this);
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"name": "Currency",
					"values": {
						"layout": {"column": 0, "row": 6, "colSpan": 11}
					}
				},
				{
					"operation": "insert",
					"parentName": "AmountBlock",
					"propertyName": "items",
					"name": "CurrencyRate",
					"values": {
						"layout": {"column": 13, "row": 6, "colSpan": 11}
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"Currency": {
					"BindParameterEnabledCurrency": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							},
							"comparisonType": this.BPMSoft.core.enums.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							}
						}]
					}
				},
				"CurrencyRate": {
					"BindParameterEnabledCurrencyRate": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							},
							"comparisonType": this.BPMSoft.core.enums.ComparisonType.NOT_EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							}
						}]
					}
				}
			}
		};
	}
);
