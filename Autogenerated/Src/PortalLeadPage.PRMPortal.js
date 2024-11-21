define("PortalLeadPage", ["BusinessRuleModule", "LeadConfigurationConst", "PortalLeadSectionActionsDashboard"],
	function(BusinessRuleModule, LeadConfigurationConst) {
		return {
			entitySchemaName: "Lead",
			attributes: {
				/**
				 * Partner identifier.
				 * @type {GUID}
				 */
				"PartnerOwnerId": {
					"dataValueType": BPMSoft.DataValueType.GUID,
					"type": BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			diff: /**SCHEMA_DIFF*/ [{
				"operation": "insert",
				"name": "ActionsDashboardModule",
				"parentName": "ActionDashboardContainer",
				"propertyName": "items",
				"values": {
					"classes": {
						"wrapClassName": ["actions-dashboard-module"]
					},
					"itemType": this.BPMSoft.ViewItemType.MODULE
				}
			}, {
				"operation": "remove",
				"name": "QualificationProcessButton"
			}, {
				"operation": "remove",
				"name": "AccountProfile"
			}, {
				"operation": "remove",
				"name": "ContactProfile"
			}, {
				"operation": "remove",
				"name": "LeadEngagementTab"
			}, {
				"operation": "remove",
				"name": "LeadsSimilarSearchResult"
			}, {
				"operation": "remove",
				"name": "LeadEmail"
			}, {
				"operation": "remove",
				"name": "Activities"
			}, {
				"operation": "remove",
				"name": "Calls"
			}, {
				"operation": "remove",
				"name": "SiteEvent"
			}, {
				"operation": "remove",
				"name": "ESNTab"
			},{
				"operation": "remove",
				"name": "NewLeadDisqualifyReason"
			},
				//endregion Remove operations
				{
					"operation": "merge",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "LeadOwner",
					"values": {
						"bindTo": "Owner",
						"layout": {
							"column": 0,
							"row": 15,
							"colSpan": 24
						},
						"enabled": false
					}
				}, {
					"operation": "merge",
					"parentName": "ProfileContainer",
					"propertyName": "items",
					"name": "LeadRegisterMethodInProfile",
					"values": {
						"enabled": false
					}
				}, {
					"operation": "merge",
					"parentName": "LeadPageDealInformationBlock",
					"propertyName": "items",
					"name": "SalesOwner",
					"values": {
						"enabled": false
					}
				}, {
					"operation": "merge",
					"name": "Opportunity",
					"values": {
						"itemType": BPMSoft.ViewItemType.TEXT,
						"showValueAsLink": false,
					}
				}
			], /**SCHEMA_DIFF*/
			modules: /**SCHEMA_MODULES*/ {
				ActionsDashboardModule: {
					"config": {
						"isSchemaConfigInitialized": true,
						"schemaName": "PortalLeadSectionActionsDashboard",
						"useHistoryState": false,
						"parameters": {
							"viewModelConfig": {
								"entitySchemaName": "Lead",
								"actionsConfig": {
									"schemaName": "QualifyStatus",
									"columnName": "QualifyStatus",
									"colorColumnName": "Color",
									"filterColumnName": "IsDisplayed",
									"orderColumnName": "StageOrder"
								},
								"dashboardConfig": {
									"Activity": {
										"masterColumnName": "Id",
										"referenceColumnName": "Lead"
									}
								}
							}
						}
					}
				}
			},
			methods: {
				/**
				 * @inheritDoc BasePageV2#getActions
				 * @overridden
				 */
				getActions: function() {
					var emptyCollection = Ext.create("BPMSoft.BaseViewModelCollection");
					return emptyCollection;
				},

				/**
				 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
				 */
				onEntityInitialized: function() {
					this.callParent(arguments);
					this.setPartnerOwnerId();
					this.setLeadDefaultFields();
				},

				/**
				 * @inheritDoc WorkLeadProcess.LeadPageV2#getIsChangePartnersRightsNeeded
				 * @overridden
				 */
				getIsChangePartnersRightsNeeded: function() {
					return false;
				},

				/**
				 * Set lead fields with default values
				 * @protected
				 */
				setLeadDefaultFields: function() {
					if (this.isNewMode()) {
						this._setDefaultLeadRegisterMethod(LeadConfigurationConst
								.LeadConst.LeadRegisterMethod.LeadFromPartner);
						this.setLeadPartner();
					}
				},

				/**
				 * Set default LeadRegisterMethod
				 * @param leadRegisterMethod RegisterMethod to set
				 * @private
				 */
				_setDefaultLeadRegisterMethod: function(leadRegisterMethod) {
					this.loadLookupDisplayValue("RegisterMethod", leadRegisterMethod);
				},

				/**
				 * Set Partner in Lead as Current User Account
				 * @protected
				 */
				setLeadPartner: function() {
					var currentUserAccount = this.BPMSoft.SysValue.CURRENT_USER_ACCOUNT;
					if (currentUserAccount && !this.BPMSoft.isEmptyGUID(currentUserAccount.value)) {
						this.set("Partner", currentUserAccount);
					}
				},

				/**
				 * Set PartnerOwnerId attribute
				 * @protected
				 */
				setPartnerOwnerId: function() {
					var partnerOwnerId = this.get("Partner.Owner");
					this.set("PartnerOwnerId", partnerOwnerId);
				}
			},
			rules: {
				"Owner": {
					"FilteringOwnerByPartner": {
						ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
						baseAttributePatch: "Id",
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						type: BusinessRuleModule.enums.ValueType.ATTRIBUTE,
						attribute: "PartnerOwnerId"
					}
				},
				"Opportunity": {
					"EnabledOpportunityForQualifyStatus": {
						"ruleType": BusinessRuleModule.enums.RuleType.DISABLED
					},
					"DisabledOpportunity": {
						"ruleType": BusinessRuleModule.enums.RuleType.BINDPARAMETER,
						"property": BusinessRuleModule.enums.Property.ENABLED,
						"conditions": [{
							"leftExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": true
							},
							"comparisonType": BPMSoft.ComparisonType.EQUAL,
							"rightExpression": {
								"type": BusinessRuleModule.enums.ValueType.CONSTANT,
								"value": false
							}
						}]
					}
				}
			}
		};
	});
