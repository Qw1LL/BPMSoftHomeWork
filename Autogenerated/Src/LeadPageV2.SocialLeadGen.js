define("LeadPageV2", [], function() {
	return {
		entitySchemaName: "Lead",
		attributes: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"LeadGenExtendedLeadInformationDetail": {
				"schemaName": "LeadGenExtendedLeadInformationDetail",
				"entitySchemaName": "LeadGenExtendedLeadInformation",
				"filter": {
					"detailColumn": "Id",
					"masterColumn": "LeadGenExtendedLeadInfo"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
			/**
			 * @private
			 */
			_getSocialLeadGenSectionFeatureState: function () {
				return this.getIsFeatureEnabled("SocialLeadGenSection");
			},
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "NewLeadType",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "NewLeadDisqualifyReason",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				}
			},
			{
				"operation": "move",
				"name": "NewLeadDisqualifyReason",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "LeadRegisterMethodInProfile",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 2
					}
				}
			},
			{
				"operation": "merge",
				"name": "LeadWebFormInProfile",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 3
					}
				}
			},
			{
				"operation": "move",
				"name": "LeadWebFormInProfile",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "merge",
				"name": "LeadBudget",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 4
					}
				}
			},
			{
				"operation": "merge",
				"name": "LeadCreatedOn",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 5
					}
				}
			},
			{
				"operation": "merge",
				"name": "LeadOwner",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 6
					}
				}
			},
			{
				"operation": "merge",
				"name": "LeadPredictiveScoreContainer",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 8
					}
				}
			},
			{
				"operation": "merge",
				"name": "GeneralInfoTab",
				"values": {
					"order": 0
				}
			},
			{
				"operation": "merge",
				"name": "SearchInSocialNetworksButton",
				"values": {
					"layout": {
						"colSpan": 1,
						"rowSpan": 1,
						"column": 10,
						"row": 0
					}
				}
			},
			{
				"operation": "move",
				"name": "SearchInSocialNetworksButton",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "merge",
				"name": "SearchInGoogleButton",
				"values": {
					"layout": {
						"colSpan": 1,
						"rowSpan": 1,
						"column": 22,
						"row": 0
					}
				}
			},
			{
				"operation": "move",
				"name": "SearchInGoogleButton",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "Contact",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "Account",
				"values": {
					"layout": {
						"colSpan": 10,
						"rowSpan": 1,
						"column": 13,
						"row": 0
					}
				}
			},
			{
				"operation": "move",
				"name": "Account",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "merge",
				"name": "Job",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "EmployeesNumber",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "MobilePhone",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2
					}
				}
			},
			{
				"operation": "move",
				"name": "MobilePhone",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "merge",
				"name": "Country",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 2
					}
				}
			},
			{
				"operation": "merge",
				"name": "Email",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 3
					}
				}
			},
			{
				"operation": "move",
				"name": "Email",
				"parentName": "LeadPageRegisterInfoBlock",
				"propertyName": "items",
				"index": 8
			},
			{
				"operation": "merge",
				"name": "Website",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 3
					}
				}
			},
			{
				"operation": "merge",
				"name": "CountryStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "RegionStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "CityStr",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				}
			},
			{
				"operation": "insert",
				"name": "LeadGenExtendedLeadInformationDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": "$_getSocialLeadGenSectionFeatureState"
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "merge",
				"name": "NeedInfoTab",
				"values": {
					"order": 1
				}
			},
			{
				"operation": "merge",
				"name": "LeadTypeStatus",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "LeadEngagementTab",
				"values": {
					"order": 2
				}
			},
			{
				"operation": "merge",
				"name": "LeadMedium",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "BpmRef",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0
					}
				}
			},
			{
				"operation": "move",
				"name": "BpmRef",
				"parentName": "LeadPageSourceInfoBlock",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "LeadSource",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "WebForm",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1
					}
				}
			},
			{
				"operation": "move",
				"name": "WebForm",
				"parentName": "LeadPageSourceInfoBlock",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "merge",
				"name": "RegisterMethod",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2
					}
				}
			},
			{
				"operation": "merge",
				"name": "DealSpecificsTab",
				"values": {
					"order": 4
				}
			},
			{
				"operation": "merge",
				"name": "Budget",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0
					}
				}
			},
			{
				"operation": "merge",
				"name": "NextActualizationDate",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0
					}
				}
			},
			{
				"operation": "move",
				"name": "NextActualizationDate",
				"parentName": "LeadPageDealInformationBlock",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "SalesOwner",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "MeetingDate",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1
					}
				}
			},
			{
				"operation": "merge",
				"name": "DecisionDate",
				"values": {
					"layout": {
						"colSpan": 6,
						"rowSpan": 1,
						"column": 13,
						"row": 2
					}
				}
			},
			{
				"operation": "merge",
				"name": "OpportunityDepartment",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2
					}
				}
			},
			{
				"operation": "merge",
				"name": "HistoryTab",
				"values": {
					"order": 5
				}
			},
			{
				"operation": "merge",
				"name": "ESNTab",
				"values": {
					"order": 7
				}
			},
			{
				"operation": "merge",
				"name": "NotesTab",
				"values": {
					"order": 6
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
