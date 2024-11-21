define("MktgActivityPage", ["BusinessRuleModule", "ConfigurationConstants", "PartnersOwnerMixin", "BPMSoft"],
	function(BusinessRuleModule, ConfigurationConstants) {
		return {
			entitySchemaName: "MktgActivity",
			details: /**SCHEMA_DETAILS*/{
			}/**SCHEMA_DETAILS*/,
			mixins: {
				/**
				 * Mixin represents methods for partners owners.
				 */
				PartnersOwnerMixin: "BPMSoft.PartnersOwnerMixin"
			},
			attributes: {
				"PartnersActivityType": {
					"dataValueType": BPMSoft.DataValueType.TEXT,
					"value": ConfigurationConstants.MktgActivity.Type.PartnersActivityType
				},
				"Account": {
					"dependencies": [
						{
							"columns": ["MktgActivityType"],
							"methodName": "onMktgActivityTypeChanged"
						},
						{
							"columns": ["Owner"],
							"methodName": "fillPartnerByOwner"
						}
					],
					"onChange": "autoCompleteOwner",
					"lookupListConfig": {
						"columns": [
							"[VwSystemUsers:Contact:PrimaryContact].Contact"
						]
					}
				},
				"PartnerAccountType": {
					"dataValueType": BPMSoft.DataValueType.GUID,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					"value": ConfigurationConstants.AccountType.Partner
				},
				"Fund": {
					"lookupListConfig": {
						"filter": function() {
							return this.getCurrentPartnershipFundFilter();
						}
					}
				},
				"Owner": {
					"dataValueType": BPMSoft.DataValueType.LOOKUP,
					"lookupListConfig": {
						"filter": function () {
							return this.getOwnerFilter("MktgActivityType");
						},
						"columns": [
							"Account.Type"
						]
					}
				}
			},
			methods: {

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.initializeDefaultValues("Account", this.get("PartnersActivityType"));
				},

				/**
				 * MktgActivityType changed event method handler.
				 */
				onMktgActivityTypeChanged: function() {
					this.clearPartnerIfColumnChange("MktgActivityType");
				},

				/**
				 * Create filter for fund.
				 * protected
				 * @returns {Object}
				 */
				getCurrentPartnershipFundFilter: function() {
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.add("ActivePartnership", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"Partnership.IsActive", 1));
					filterGroup.add("CurrentPartnership", this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"Partnership", this.get("Partnership").value));
					return filterGroup;
				}
				
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "MktgActivityType",
					"values": {
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 11,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Account",
					"values": {
						"layout": {
							"column": 0,
							"row": 5,
							"colSpan": 11,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Fund",
					"values": {
						"layout": {
							"column": 0,
							"row": 6,
							"colSpan": 11,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Partnership",
					"values": {
						"layout": {
							"column": 13,
							"row": 5,
							"colSpan": 11,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Url",
					"values": {
						"layout": {
							"column": 13,
							"row": 4,
							"colSpan": 11,
							"rowSpan": 1
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "MarketingActivityControlGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.MarketingActivityGroupCaption"
						}
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "MarketingActivityControlGroup_GridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "MarketingActivityControlGroup",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Description",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24,
							"rowSpan": 1
						},
						"contentType": this.BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {
							"visible": false
						}
					},
					"parentName": "MarketingActivityControlGroup_GridLayout",
					"propertyName": "items"
				}
			]/**SCHEMA_DIFF*/,
			rules: {
				"Partnership": {
					"VisibleRule": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "MktgActivityType"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "PartnersActivityType"
							}
						}]
					}
				},
				"Account": {
					"VisibleRule": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "MktgActivityType"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "PartnersActivityType"
							}
						}]
					},
					"FiltrationPartnerByAccountType": {
						"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
						"autocomplete": true,
						"baseAttributePatch": "Type",
						"comparisonType": this.BPMSoft.ComparisonType.EQUAL,
						"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						"attribute": "PartnerAccountType"
					}
				},
				"Fund": {
					"VisibleRule": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.VISIBLE,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "MktgActivityType"
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
								"attribute": "PartnersActivityType"
							}
						}]
					}
				}
			},
			userCode: {}
		};
	});
