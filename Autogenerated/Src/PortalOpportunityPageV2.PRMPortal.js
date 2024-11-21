  define("PortalOpportunityPageV2", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Opportunity",
			details: /**SCHEMA_DETAILS*/ {
				Lead: {
					schemaName: "LeadDetailV2",
					entitySchemaName: "Lead",
					filter: {
						detailColumn: "Opportunity",
						masterColumn: "Id"
					},
					defaultValues: {
						QualifiedAccount: {
							masterColumn: "Account"
						},
						Budget: {
							masterColumn: "Budget"
						},
						SalesOwner: {
							masterColumn: "Owner"
						},
						LeadType: {
							masterColumn: "LeadType"
						}
					}
				}
			} /**SCHEMA_DETAILS*/,
			modules: /**SCHEMA_MODULES*/{
				"ClientProfile": {
					"config": {
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"schemaName": "PortalClientProfileSchema",
						"parameters": {
							"viewModelConfig": {
								"masterColumnName": "Client"
							}
						}
					}
				}
			}/**SCHEMA_MODULES*/,
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 * @override
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this._initializePartnerSale();
					this._initializePartner();
				},

				/**
				 * @private
				 */
				_initializePartnerSale: function () {
					if (this.isEmpty(this.$Type)) {
						this.$Type = {
							value: ConfigurationConstants.Opportunity.Type.PartnerSale
						};
					}
				},

				/**
				 * @private
				 */
				_initializePartner: function () {
					if (this.isEmpty(this.$Owner)) {
						this.$Owner = this.BPMSoft.SysValue.CURRENT_USER_CONTACT;
					}
					if (this.isEmpty(this.$Partner) &&
						!this.BPMSoft.isEmptyGUID(this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT.value)) {
							this.$Partner = this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT;
					}
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getLookupPageConfig
				 * @override
				 */
				getLookupPageConfig: function () {
					const parentConfig = this.callParent(arguments);
					parentConfig.hideActions = true;
					return parentConfig;
				}
			},
			diff: /**SCHEMA_DIFF*/ [
				{
					"operation": "insert",
					"name": "LeadTab",
					"values": {
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.LeadTabCaption"
						}
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "merge",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "OpportunityTitle",
					"values": {
						"bindTo": "Title",
						"layout": {"column": 0, "row": 0, "colSpan": 24}
					}
				},
				{
					"operation": "merge",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Amount",
					"values": {"layout": {"column": 0, "row": 1, "colSpan": 11}}
				},
				{
					"operation": "merge",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Probability",
					"values": {
						"layout": {"column": 13, "row": 1, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.ProbabilityTip"}
						}
					}
				},
				{
					"operation": "merge",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Owner",
					"values": {
						"layout": {"column": 0, "row": 2, "colSpan": 11},
						"tip": {
							"content": {"bindTo": "Resources.Strings.OwnerTip"}
						}
					}
				},
				{
					"operation": "merge",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Category",
					"values": {
						"layout": {"column": 13, "row": 2, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Source",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "merge",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "CreatedOn",
					"values": {
						"dataValueType": BPMSoft.DataValueType.DATE,
						"layout": {"column": 13, "row": 3, "colSpan": 11}
					}
				},
				{
					"operation": "remove",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Partner",
				},
				{
					"operation": "remove",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "CloseReason",
				},
				{
					"operation": "insert",
					"name": "Lead",
					"values": {
						"itemType": 2
					},
					"parentName": "LeadTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "merge",
					"parentName": "DescriptionGroupBlock",
					"propertyName": "items",
					"name": "Description",
					"values": {
						"labelConfig": {"visible": true},
					}
				},
				{
					"operation": "merge",
					"parentName": "OpportunityTacticAndCompetitorBlock",
					"propertyName": "items",
					"name": "Tactic",
					"values": {
						"layout": {"column": 0, "row": 1, "rowSpan": 1, "colSpan": 11},
					}
				},
				{
					"operation": "merge",
					"parentName": "OpportunityTacticAndCompetitorBlock",
					"propertyName": "items",
					"name": "CheckDate",
					"values": {"layout": {"column": 13, "row": 1, "rowSpan": 1, "colSpan": 11}}
				},
				{
					"operation": "remove",
					"name": "Partner"
				}
			]/**SCHEMA_DIFF*/
		};
	});
