define("LeadPageV2", ["BPMSoft", "OpportunityConfigurationConstants", "LeadConfigurationConst", "BusinessRuleModule"],
		function(BPMSoft, OpportunityConfigurationConstants, LeadConfigurationConst, BusinessRuleModule) {
			return {
				entitySchemaName: "Lead",
				details: /**SCHEMA_DETAILS*/{
				}/**SCHEMA_DETAILS*/,
				attributes: {},
				messages: {
					"GetCurrentOpportunityInfo": {
						mode: BPMSoft.MessageMode.PTP,
						direction: BPMSoft.MessageDirectionType.PUBLISH
					}
				},
				methods: {

					/**
					 * Returns GUID of opportunity
					 * @returns {BPMSoft.DataValueType.GUID}
					 */
					getUidOpportunity: function() {

						var opportunity = this.get("Opportunity");
						return (opportunity) ? opportunity.value : null;
					},

					/**
					 * Returns the primary opportunity contact
					 * @returns {BPMSoft.EntitySchemaQuery}
					 */
					getOpportunityContactESQ: function() {
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "OpportunityContact"
						});
						select.addColumn("Id");
						select.addColumn("Contact");
						select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Opportunity", this.getUidOpportunity()));
						select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "IsMainContact", true));
						return select;
					},

					/**
					 * Returns the opportunity
					 * @returns {BPMSoft.EntitySchemaQuery}
					 */
					getOpportunityESQ: function() {
						var select = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "Opportunity"
						});
						select.addColumn("Id");
						select.addColumn("Budget");
						select.addColumn("Owner");
						select.addColumn("Stage");
						select.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Id", this.getUidOpportunity()));
						return select;
					},

					/**
					 * Sets data from the opportunity
					 * @override
					 */
					onEntityInitialized: function() {
						this.callParent(arguments);
						if (this.isNewMode() && this.getUidOpportunity()) {
							this.getOpportunityContactESQ().getEntityCollection(function(response) {
								if (response.success) {
									if (response.collection.getCount() < 1) {
										return;
									}
									var mainContact = response.collection.getByIndex(0);
									this.set("QualifiedContact", mainContact.get("Contact"), BPMSoft.DataValueType.LOOKUP);
								}
							}, this);
							this.getOpportunityESQ().getEntityCollection(function(response) {
								if (response.success) {
									if (response.collection.getCount() < 1) {
										return;
									}
									var mainOpportunity = response.collection.getByIndex(0);
									this.set("Budget", mainOpportunity.get("Budget"), BPMSoft.DataValueType.MONEY);
									this.set("SalesOwner", mainOpportunity.get("Owner"), BPMSoft.DataValueType.LOOKUP);
								}
							}, this);
						}
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "move",
						"parentName": "LeadPageDealInformationBlock",
						"propertyName": "items",
						"name": "SalesOwner",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.LOOKUP,
							"bindTo": "SalesOwner"
						}
					},
					{
						"operation": "move",
						"parentName": "LeadPageDealInformationBlock",
						"propertyName": "items",
						"name": "OpportunityDepartment",
						"values": {
							"layout": {
								"column": 0,
								"row": 3,
								"colSpan": 11
							},
							"contentType": BPMSoft.ContentType.ENUM,
							"enabled": {"bindTo": "SourceDataEditable"}
						}
					},
					{
						"operation": "insert",
						"parentName": "LeadPageDealInformationBlock",
						"propertyName": "items",
						"name": "Opportunity",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11}
						}
					}
				]/**SCHEMA_DIFF*/,
				rules: {
					"Opportunity": {
						"FilterOpportunityrByAccount": {
							"ruleType": BusinessRuleModule.enums.RuleType.FILTRATION,
							"autocomplete": true,
							"baseAttributePatch": "Account",
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
							"attribute": "QualifiedAccount"
						},
						"EnabledOpportunityForQualifyStatus": {
							"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
							"property": BusinessRuleModule.enums.Property.ENABLED,
							"conditions": [{
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "QualifyStatus"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": LeadConfigurationConst.LeadConst.QualifyStatus.TransferForSale
								}
							}, {
								"leftExpression": {
									"type": BusinessRuleModule.enums.ValueType.ATTRIBUTE,
									"attribute": "QualifyStatus"
								},
								"comparisonType": BPMSoft.ComparisonType.EQUAL,
								"rightExpression": {
									"type": BusinessRuleModule.enums.ValueType.CONSTANT,
									"value": LeadConfigurationConst.LeadConst.QualifyStatus.WaitingForSale
								}
							}]
						}
					}
				},
				userCode: {
				}
			};
		});
