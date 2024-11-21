define("CurrencyRatePage", ["BusinessRuleModule", "MoneyUtilsMixin"],
		function(BusinessRuleModule) {
			return {
				entitySchemaName: "CurrencyRate",
				attributes: {},
				mixins: {
					MoneyUtilsMixin: "BPMSoft.MoneyUtilsMixin"
				},
				messages: {
					"GetCurrencyDivision": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				rules: {
					"EndDate": {
						"BindParameterEnabledEndDate": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.ENABLED,
							"conditions": [{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": true
								},
								"comparisonType": this.BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": true
								}
							}]
						}
					}
				},
				methods: {
					/**
					 * @inheritDoc BPMSoft.BaseViewModel#setDefaultValues
					 * @overridden
					 */
					setDefaultValues: function() {
						this.callParent(arguments);
						this.set("CreatedOn", undefined);
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#saveEntityInChain
					 * @overriden
					 */
					saveEntityInChain: function(next) {
						this.BPMSoft.EntitySchemaQuery.clearCache("CurrencyRateListItem");
						this.callParent([next]);
					},

					/**
					 * @inheritDoc BaseSchemaViewModel#setValidationConfig
					 * @overridden
					 */
					setValidationConfig: function() {
						this.callParent(arguments);
						this.addColumnValidator("Rate", this.rateValidator);
					},

					/**
					 * Validates Rate field.
					 * @protected
					 * @virtual
					 * @return {Object} Validation error messages config.
					 */
					rateValidator: function() {
						var invalidMessage = "";
						var rate = this.get("Rate");
						if (rate < 0) {
							invalidMessage = this.get("Resources.Strings.InvalidRateValue");
						}
						return {
							fullInvalidMessage: invalidMessage,
							invalidMessage: invalidMessage
						};
					},

					/**
					 * @inheritDoc BPMSoft.BaseViewModel#getSaveQuery
					 * @overridden
					 */
					getSaveQuery: function() {
						var query = this.callParent(arguments);
						var division = this.sandbox.publish("GetCurrencyDivision", null);
						var rateValue = this.changedValues.Rate;
						query = this.formCurrencyRateSaveQuery({
							query: query,
							division: division,
							rate: rateValue
						});
						return query;
					}
				},
				diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
			};
		});
