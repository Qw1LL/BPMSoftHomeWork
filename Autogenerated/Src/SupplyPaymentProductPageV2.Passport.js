define("SupplyPaymentProductPageV2", ["BusinessRuleModule"],
	function(BusinessRuleModule) {
		return {
			entitySchemaName: "VwSupplyPaymentProduct",
			attributes: {
				/**
				* ##### ## ########.
				*/
				UsedAmount: {
					dependencies: [
						{
							columns: ["UsedQuantity"],
							methodName: "onUsedQuantityChanged"
						}
					]
				}
			},
			methods: {
				/**
				 * @inheritDoc BPMSoft.BasePageV2#onSaved
				 * @overridden
				 */
				onSaved: function() {
					this.callParent(arguments);
					this.validateUsedQuantity(this.get("UsedQuantity"));
				},

				/**
				 * ########## ######### ##########.
				 * @private
				 */
				onUsedQuantityChanged: function() {
					this.recalculateQuantityValues();
				},

				/**
				 * ######## ##### ## ##########.
				 * @private
				 */
				recalculateQuantityValues: function() {
					if (!this.validationConfig.UsedQuantity) {
						this.setValidationConfig();
					}
					const productPrice = this.get("Price");
					const discountPercent = this.get("DiscountPercent") || 0;
					const discountAmount = this.get("DiscountAmount") || 0;
					const quantity = this.get("UsedQuantity");
					if (productPrice) {
						const amount = quantity * productPrice - (quantity * discountAmount);
						this.set("UsedAmount", amount);
					}
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2ViewModel#setValidationConfig
				 * @overridden
				 */
				setValidationConfig: function() {
					this.callParent(arguments);
					this.addColumnValidator("UsedQuantity", this.validateUsedQuantity);
				},

				/**
				 * ######### ############ #### ### ##########.
				 * @param {String} value
				 * @return {Object} ########## ###### # ######## ###### ######### ####.
				 */
				validateUsedQuantity: function(value) {
					var invalidMessage = "";
					var maxQuantity = this.get("MaxQuantity");
					if (value > maxQuantity) {
						invalidMessage = this.get("Resources.Strings.ValidateUsedQuantity");
					} else
					if (value < 0) {
						invalidMessage = this.get("Resources.Strings.ValidateUsedQuantityMoreZero");
					}
					return {
						invalidMessage: invalidMessage
					};
				}
			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/,
			rules: {
				"OrderProduct": {
					"BindParameterEnabledOrderProduct": {
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
				"MaxQuantity": {
					"BindParameterEnabledMaxQuantity": {
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
				"UsedAmount": {
					"BindParameterEnabledUsedAmount": {
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
