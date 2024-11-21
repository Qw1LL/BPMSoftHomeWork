define("LeadPageV2", ["css!LeadPageV2ManagementCSS", "SalesReadyLeadLifecycleMixin"], function() {
	return {
		entitySchemaName: "Lead",
		mixins: {
			SalesReadyLeadLifecycleMixin: "BPMSoft.SalesReadyLeadLifecycleMixin"
		},
		modules: /**SCHEMA_MODULES*/{
			"AccountProfileDesc": {
				"config": {
					"schemaName": "LeadAccountProfileSchema",
					"isSchemaConfigInitialized": true,
					"useHistoryState": false,
					"parameters": {
						"viewModelConfig": {
							"masterColumnName": "QualifiedAccount"
						}
					}
				}
			},
			"ContactProfileDesc": {
				"config": {
					"schemaName": "LeadContactProfileSchema",
					"isSchemaConfigInitialized": true,
					"useHistoryState": false,
					"parameters": {
						"viewModelConfig": {
							"masterColumnName": "QualifiedContact"
						}
					}
				}
			}
		}/**SCHEMA_MODULES*/,
		messages: {
			/**
			 * @message UpdateCommunicationDetail
			 * Updates detail.
			 */
			"UpdateCommunicationDetail": {
				mode: BPMSoft.MessageMode.PTP,
				direction: BPMSoft.MessageDirectionType.PUBLISH
			},
		},
		attributes: {
			/**
			 * Qualified contact.
			 */
			"QualifiedContact": {
				dataValueType: BPMSoft.DataValueType.LOOKUP,
				lookupListConfig: {
					columns: ["Email"]
				},
				onChange: "onQualifiedContactChange"
			},

			/**
			 * The qualification stage id.
			 * @type {Boolean}
			 */
			"QualificationStageId": {
				dataValueType: this.BPMSoft.DataValueType.GUID,
				value: "d790a45d-03ff-4ddb-9dea-8087722c582c"
			},
		},
		details: /**SCHEMA_DETAILS*/{
			"ContactCommunicationDetail": {
				"schemaName": "ContactCommunicationDetail",
				"entitySchemaName": "ContactCommunication",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "QualifiedContact"
				}
			},
			"CallDetail": {
				"schemaName": "CallDetail",
				"entitySchemaName": "Call",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "QualifiedContact"
				}
			},
			"EmailDetailV2": {
				"schemaName": "EmailDetailV2",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "QualifiedContact"
				},
				"defaultValues": {
					"Lead": {
						"masterColumn": "Id"
					}
				},
				"filterMethod": "getEmailDetailFilter"
			},
			"ContactActivityDetailV2": {
				"schemaName": "ActivityDetailV2",
				"entitySchemaName": "Activity",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "QualifiedContact"
				}
			},
			"AccountActivityDetailV2": {
				"schemaName": "ActivityDetailV2",
				"entitySchemaName": "Activity",
				"filter": {
					"detailColumn": "Account",
					"masterColumn": "QualifiedAccount"
				}
			},
			"ContactAddressDetailV2": {
				"schemaName": "ContactAddressDetailV2",
				"entitySchemaName": "ContactAddress",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "QualifiedContact"
				}
			},
			"LeadsSimilarSearchResultDetail": {
				"schemaName": "LeadsSimilarSearchResultDetailV2",
				"entitySchemaName": "Lead",
				"filter": {
					"detailColumn": "Id",
					"masterColumn": "Id"
				}
			},
			"ContactCommunicationDetailV2": {
				"schemaName": "ContactCommunicationDetail",
				"entitySchemaName": "ContactCommunication",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "QualifiedContact"
				}
			},
			"LeadSpecificationDetail": {
				"schemaName": "LeadSpecificationDetailV2",
				"entitySchemaName": "SpecificationInLead",
				"filter": {
					"detailColumn": "Lead",
					"masterColumn": "Id"
				}
			},
			"LeadProductDetailV2": {
				"schemaName": "LeadProductDetailV2",
				"entitySchemaName": "LeadProduct",
				"filter": {
					"detailColumn": "Lead",
					"masterColumn": "Id"
				}
			},
			"AccountCallDetail": {
				"schemaName": "CallDetail",
				"entitySchemaName": "Call",
				"filter": {
					"detailColumn": "Account",
					"masterColumn": "QualifiedAccount"
				}
			},
			"AccountAddressDetail": {
				"schemaName": "AccountAddressDetailV2",
				"entitySchemaName": "AccountAddress",
				"filter": {
					"detailColumn": "Account",
					"masterColumn": "QualifiedAccount"
				}
			},
			"ContactCallDetailV2": {
				"schemaName": "CallDetail",
				"entitySchemaName": "Call",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "QualifiedContact"
				}
			},
			"ContactAddressDetail": {
				"schemaName": "ContactAddressDetailV2",
				"entitySchemaName": "ContactAddress",
				"filter": {
					"detailColumn": "Contact",
					"masterColumn": "QualifiedContact"
				}
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{
			"GeneralInfoTab": {
				"ShowElementOnThePage_GeneralInfoTab": {
					"uId": "f0b371cd-fda2-4239-ac28-c2e2d48de435",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 3,
							"leftExpression": {
								"type": 2,
								"value": "UseTheSalesReadyLeadLifecycle",
								"dataValueType": 12
							},
							"rightExpression": {
								"type": 0,
								"value": false,
								"dataValueType": 12
							}
						}
					]
				}
			},
			"NeedInfoTab": {
				"ShowElementOnThePage_NeedInfoTab": {
					"uId": "3415d680-75a0-4647-9a65-557d215fb60e",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 3,
							"leftExpression": {
								"type": 2,
								"value": "UseTheSalesReadyLeadLifecycle",
								"dataValueType": 12
							},
							"rightExpression": {
								"type": 0,
								"value": false,
								"dataValueType": 12
							}
						}
					]
				}
			},
			"LeadEngagementTab": {
				"ShowElementOnThePage_LeadEngagementTab": {
					"uId": "abac5fb6-cc85-41f3-af63-98dee875f72e",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 3,
							"leftExpression": {
								"type": 2,
								"value": "UseTheSalesReadyLeadLifecycle",
								"dataValueType": 12
							},
							"rightExpression": {
								"type": 0,
								"value": false,
								"dataValueType": 12
							}
						}
					]
				}
			},
			"TrackingEventsTab": {
				"ShowElementOnThePage_TrackingEventsTab": {
					"uId": "344c2fee-4749-4e53-819e-9adc59822654",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 3,
							"leftExpression": {
								"type": 2,
								"value": "UseTheSalesReadyLeadLifecycle",
								"dataValueType": 12
							},
							"rightExpression": {
								"type": 0,
								"value": false,
								"dataValueType": 12
							}
						}
					]
				}
			},
			"DealSpecificsTab": {
				"ShowElementOnThePage_DealSpecificsTab": {
					"uId": "7e99a92b-f341-47dd-bfcc-fbf110ebec10",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 3,
							"leftExpression": {
								"type": 2,
								"value": "UseTheSalesReadyLeadLifecycle",
								"dataValueType": 12
							},
							"rightExpression": {
								"type": 0,
								"value": false,
								"dataValueType": 12
							}
						}
					]
				}
			},
			"AccountActivityDetailV2": {
				"ShowElementOnThePage_AccountActivityDetailV2": {
					"uId": "183e3055-bfb6-4269-91cf-89abbb289464",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedAccount"
							}
						}
					]
				}
			},
			"AccountAddressDetail": {
				"ShowElementOnThePage_AccountAddressDetail": {
					"uId": "207b5dd6-f9fc-484d-ba7f-45f28ecf63b0",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedAccount"
							}
						}
					]
				}
			},
			"AccountCallDetail": {
				"ShowElementOnThePage_AccountCallDetail": {
					"uId": "eafc838a-3217-46c6-a7e9-3d7212810cb9",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedAccount"
							}
						}
					]
				}
			},
			"ContactCallDetailV2": {
				"ShowElementOnThePage_ContactCallDetailV2": {
					"uId": "9ab58bfd-f9e5-45c6-903c-ebfc8fe4ea2e",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 1,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedAccount"
							}
						},
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedContact"
							}
						}
					]
				}
			},
			"ContactAddressDetail": {
				"ShowElementOnThePage_ContactAddressDetail": {
					"uId": "f3f861f5-1af4-4247-91c8-77127e4787cd",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 1,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedAccount"
							}
						},
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedContact"
							}
						}
					]
				}
			},
			"ContactAddressDetailV2": {
				"ShowElementOnThePage_ContactAddressDetailV2": {
					"uId": "e61fe9d0-49a0-4deb-8b87-3be235b62f78",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedContact"
							}
						}
					]
				}
			},
			"ContactActivityDetailV2": {
				"ShowElementOnThePage_ContactActivityDetailV2": {
					"uId": "2f7a3cd0-97ba-472a-9478-886ecf58b99a",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedContact"
							}
						}
					]
				}
			},
			"EmailDetailV2": {
				"ShowElementOnThePage_EmailDetailV2": {
					"uId": "e698125b-623c-47f3-80fe-7f00b46b1902",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedContact"
							}
						}
					]
				}
			},
			"CallDetail": {
				"ShowElementOnThePage_CallDetail": {
					"uId": "2f50b5e3-b196-47f6-8599-e5fc3b1ba8b5",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedContact"
							}
						}
					]
				}
			},
			"ContactCommunicationDetail": {
				"ShowElementOnThePage_ContactCommunicationDetail": {
					"uId": "3d314c48-9eb8-4666-b747-98c681937e70",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedContact"
							}
						}
					]
				}
			},
			"ContactCommunicationDetailV2": {
				"ShowElementOnThePage_ContactCommunicationDetailV2": {
					"uId": "3d314c48-9eb8-4666-b747-98c681937e71",
					"enabled": true,
					"removed": false,
					"ruleType": 0,
					"property": 0,
					"logical": 0,
					"conditions": [
						{
							"comparisonType": 2,
							"leftExpression": {
								"type": 1,
								"attribute": "QualifiedContact"
							}
						}
					]
				}
			}
		}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
			
			//region Methods: Protected

			/**
			 * Updates contact communication detail data.
			 * @protected
			 */
			updateCommunicationDetail: function() {
				var communicationDetailId = this.getDetailId("ContactCommunicationDetail");
				var communicationDetailV2Id = this.getDetailId("ContactCommunicationDetailV2");
				this.sandbox.publish("UpdateCommunicationDetail", null, [communicationDetailId]);
				this.sandbox.publish("UpdateCommunicationDetail", null, [communicationDetailV2Id]);
			},
			
			/**
			 * Handles QualifiedContact field change.
			 * @protected
			 */
			onQualifiedContactChange: function(model, value) {
				if(value) {
					this.updateCommunicationDetail();
				}
			},

			/**
			 * Returns array of detail names that are duplicating on page.
			 * @virtual
			 * @return {String[]} Array of detail names. 
			 */
			getDuplicateDetail: function() {
				return ["ContactCommunicationDetail", "ContactCommunicationDetailV2", "CallDetail", "EmailDetailV2", 
					"ContactActivityDetailV2", "AccountActivityDetailV2", "ContactAddressDetailV2", 
					"LeadsSimilarSearchResultDetail", "LeadSpecificationDetail", "LeadProductDetailV2", 
					"AccountCallDetail", "AccountAddressDetail", "ContactCallDetailV2", "ContactAddressDetail"];	
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseEntityPage#getDetailInfo
			 * @override
			 */
			getDetailInfo: function() {
				const detailInfo = this.callParent(arguments);
				const duplicateDetails = this.getDuplicateDetail();
				if (duplicateDetails.includes(detailInfo.detailName)) {
					detailInfo.detailElementsPrefix = BPMSoft.generateGUID();
				}
				return detailInfo;
			},
			
			/**
			 * @inheritdoc BPMSoft.LeadPageV2#init
			 * @override
			 */
			init: function(callback, scope) {
				const parentInit = this.getParentMethod();
				this.BPMSoft.chain(
					this.loadSalesReadyLeadLifecycleSysSetting,
					this.loadQualifyStatus,
					function() {
						this.initSalesReadyLeadLifecycleTabsVisibility();
						parentInit.call(this, callback, scope);
					}, this);
			},

			/**
			 * Loads qualify status.
			 * @protected
			 */
			loadQualifyStatus: function(callback, scope) {
				if (!this.isNewMode()) {
					this.Ext.callback(callback, scope);
					return;
				}
				if (!this.$UseTheSalesReadyLeadLifecycle) {
					this.$QualifyStatus = {
						value: this.$QualificationStageId
					}
					this.Ext.callback(callback, scope);
				} else {
					this.BPMSoft.SysSettings.querySysSettingsItem(["DefaultLeadStage"], function(result) {
						this.$QualifyStatus = result;
						this.Ext.callback(callback, scope);
					}, this);
				}
			},

			/**
			 * @inheritdoc BPMSoft.BasePageV2#onGetColumnsValues
			 * @override
			 */
			onGetColumnsValues: function(columnNames) {
				var result = this.callParent(arguments);
				if (this.get("UseTheSalesReadyLeadLifecycle")
					&& columnNames.includes("Email")
					&& this.get("QualifiedContact")) {
					result["Email"] = this.$QualifiedContact.Email;
				}
				return result;
			},

			/**
			 * @inheritdoc BPMSoft.LeadManagementUtilities#initLeadManagementButtonVisibility
			 * @override
			 */
			initLeadManagementButtonVisibility: function(entity) {
				if (this.get("UseTheSalesReadyLeadLifecycle")) {
					this.set("LeadManagementButtonVisible", false);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * Initializes SalesReadyLeadLifecycle tabs visibility.
			 * @protected
			 */
			initSalesReadyLeadLifecycleTabsVisibility: function () {
				if (!this.get("UseTheSalesReadyLeadLifecycle")) {
					this.setActiveTab("GeneralInfoTab");
					const tabsCollection = this.get("TabsCollection");
					if (tabsCollection.contains("LeadPageMQLTab")) {
						tabsCollection.removeByKey("LeadPageMQLTab");
					}
					if (tabsCollection.contains("LeadPageSQLTab")) {
						tabsCollection.removeByKey("LeadPageSQLTab");
					}
				}	
			},
			//endregion
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
					},
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					}
				}
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
					},
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
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
				"operation": "move",
				"name": "DuplicatesWidgetContainer",
				"parentName": "LeftModulesContainer",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "move",
				"name": "ProfileContainer",
				"parentName": "LeftModulesContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LeadProfilesAsc",
				"values": {
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle",
						"bindConfig": {
							"converter": "invertBooleanValue"
						}
					},
					"id": "lead-profiles-container-asc",
					"itemType": 7,
					"items": []
				},
				"parentName": "LeftModulesContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "AccountProfile",
				"values": {
					"itemType": 4
				},
				"parentName": "LeadProfilesAsc",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ContactProfile",
				"values": {
					"itemType": 4
				},
				"parentName": "LeadProfilesAsc",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LeadProfilesDesc",
				"values": {
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					},
					"id": "lead-profiles-container-desc",
					"itemType": 7,
					"items": []
				},
				"parentName": "LeftModulesContainer",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "ContactProfileDesc",
				"values": {
					"itemType": 4
				},
				"parentName": "LeadProfilesDesc",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "AccountProfileDesc",
				"values": {
					"itemType": 4
				},
				"parentName": "LeadProfilesDesc",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LeadPageMQLTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.LeadPageMQLTabTabCaption"
					},
					"items": [],
					"order": 0
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "ContactCommunicationDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {"bindTo": "UseTheSalesReadyLeadLifecycle"}
				},
				"parentName": "LeadPageMQLTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "CallDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {"bindTo": "UseTheSalesReadyLeadLifecycle"}
				},
				"parentName": "LeadPageMQLTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "EmailDetailV2",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageMQLTab",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ContactActivityDetailV2",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageMQLTab",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "AccountActivityDetailV2",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageMQLTab",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ContactAddressDetailV2",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageMQLTab",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "LeadsSimilarSearchResultDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageMQLTab",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "LeadPageSQLTab",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.LeadPageSQLTabTabCaption"
					},
					"items": [],
					"order": 1
				},
				"parentName": "Tabs",
				"propertyName": "tabs",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "ContactCommunicationDetailV2",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageSQLTab",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "LeadPageSQLTabOpportunityPlanningGroup",
				"values": {
					"caption": {
						"bindTo": "Resources.Strings.LeadPageSQLTabOpportunityPlanningGroupGroupCaption"
					},
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"markerValue": "added-group",
					"items": []
				},
				"parentName": "LeadPageSQLTab",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "LeadPageSQLTabGridLayout",
				"values": {
					"itemType": 0,
					"items": []
				},
				"parentName": "LeadPageSQLTabOpportunityPlanningGroup",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "BudgetV2",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 0,
						"layoutName": "LeadPageSQLTabGridLayout"
					},
					"bindTo": "Budget"
				},
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 0
			},
			{
				"operation": "insert",
				"name": "NextActualizationDateV2",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 0,
						"layoutName": "LeadPageSQLTabGridLayout"
					},
					"bindTo": "NextActualizationDate"
				},
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "insert",
				"name": "SalesOwnerV2",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 1,
						"layoutName": "LeadPageSQLTabGridLayout"
					},
					"bindTo": "SalesOwner"
				},
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "MeetingDateV2",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 1,
						"layoutName": "LeadPageSQLTabGridLayout"
					},
					"bindTo": "MeetingDate"
				},
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "OpportunityDepartmentV2",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 0,
						"row": 2,
						"layoutName": "LeadPageSQLTabGridLayout"
					},
					"bindTo": "OpportunityDepartment"
				},
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "CommentarySqlTab",
				"values": {
					"contentType": BPMSoft.ContentType.LONG_TEXT,
					"layout": {
						"colSpan": 0,
						"rowSpan": 0,
						"column": 0,
						"row": 1,
						"layoutName": "LeadPageSQLTabOpportunityPlanningGroup"
					},
					"bindTo": "Commentary"
				},
				"parentName": "LeadPageSQLTabOpportunityPlanningGroup",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "DecisionDateV2",
				"values": {
					"layout": {
						"colSpan": 11,
						"rowSpan": 1,
						"column": 13,
						"row": 2,
						"layoutName": "LeadPageSQLTabGridLayout"
					},
					"bindTo": "DecisionDate"
				},
				"parentName": "LeadPageSQLTabGridLayout",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "AccountCallDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageSQLTab",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "insert",
				"name": "ContactCallDetailV2",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageSQLTab",
				"propertyName": "items",
				"index": 3
			},
			{
				"operation": "insert",
				"name": "AccountAddressDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageSQLTab",
				"propertyName": "items",
				"index": 4
			},
			{
				"operation": "insert",
				"name": "ContactAddressDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageSQLTab",
				"propertyName": "items",
				"index": 5
			},
			{
				"operation": "insert",
				"name": "LeadSpecificationDetail",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageSQLTab",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "LeadProductDetailV2",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail",
					"visible": {
						"bindTo": "UseTheSalesReadyLeadLifecycle"
					}
				},
				"parentName": "LeadPageSQLTab",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "merge",
				"name": "GeneralInfoTab",
				"values": {
					"order": 2
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
						"colSpan": 11,
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
				"name": "NeedInfoTab",
				"values": {
					"order": 3
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
					"order": 4
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
					"order": 6
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
						"colSpan": 11,
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
					"order": 7
				}
			},
			{
				"operation": "merge",
				"name": "ESNTab",
				"values": {
					"order": 9
				}
			},
			{
				"operation": "merge",
				"name": "NotesTab",
				"values": {
					"order": 8
				}
			},
			{
				"operation": "merge",
				"name": "TimelineTab",
				"values": {
					"order": 5
				}
			},
			{
				"operation": "remove",
				"name": "AccountProfile"
			},
			{
				"operation": "remove",
				"name": "ContactProfile"
			}
		]/**SCHEMA_DIFF*/
	};
});
