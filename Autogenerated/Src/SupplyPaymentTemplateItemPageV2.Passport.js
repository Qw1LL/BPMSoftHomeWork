define("SupplyPaymentTemplateItemPageV2", ["BPMSoft", "BusinessRuleModule", "ConfigurationConstants"],
	function(BPMSoft, BusinessRuleModule, ConfigurationConstants) {
		return {
			entitySchemaName: "SupplyPaymentTemplateItem",
			attributes: {
				/**
				 * ########
				 */
				"Name": {
					dataValueType: BPMSoft.DataValueType.TEXT,
					isRequired: true,
					dependencies: [
						{
							columns: ["Type"],
							methodName: "onTypeChanged"
						}
					]
				},

				"PreviousElement": {
					lookupListConfig: {
						hideActions: true,
						filters: [
							function() {
								var Id = this.get("Id");
								var filterGroup = Ext.create("BPMSoft.FilterGroup");
								filterGroup.add("prevElement", this.BPMSoft.createColumnFilterWithParameter(
									this.BPMSoft.ComparisonType.NOT_EQUAL, "Id", Id));
								return filterGroup;
							}
						]
					}
				},

				/**
				 * ### ####
				 */
				"Type": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					isRequired: true
				}
			},
			methods: {
				/**
				 * ############# ####### ### ###### #########, ########## ### ############## ####### ### ##########
				 * ##### ######.
				 * @inheritdoc BPMSoft.BaseViewModel#setDefaultValues
				 * @protected
				 * @overridden
				 */
				setDefaultValues: function() {
					this.callParent(arguments);
					this.set("IsEntityInitialized", true);
				}
			},
			rules: {
				"PreviousElement": {
					"BindParameterRequiredPreviousElement": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.REQUIRED,
						"conditions": [
							{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "DelayType"
								},
								"comparisonType": BPMSoft.ComparisonType.NOT_EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": ConfigurationConstants.SupplyPayment.Fixed
								}
							}
						]
					},
					"FiltrationPreviousElementByTemplate": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "SupplyPaymentTemplate",
						"comparisonType": BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "SupplyPaymentTemplate"
					}
				}
			}
		};
	}
);

