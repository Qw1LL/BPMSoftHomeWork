define("OpportunityPageV2", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "Opportunity",
			messages: {},
			attributes: {},
			mixins: {},
			modules: /**SCHEMA_MODULES*/{
				"ClientProfile": {
					"config": {
						"isSchemaConfigInitialized": true,
						"useHistoryState": false,
						"schemaName": "ClientProfileSchema",
						"parameters": {
							"viewModelConfig": {
								"masterColumnName": "Client"
							}
						}
					}
				}
			}/**SCHEMA_MODULES*/,
			details: /**SCHEMA_DETAILS*/{
				Activities: {
					schemaName: "OpportunityHistoryActivityDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					},
					defaultValues: {
						Account: {masterColumn: "Account"},
						Contact: {masterColumn: "Contact"}
					}
				},
				Calls: {
					schemaName: "CallDetail",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					}
				},
				EmailDetailV2: {
					schemaName: "EmailDetailV2",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					},
					filterMethod: "emailDetailFilter"
				},
				OpportunityTeam: {
					schemaName: "OpportunityTeamDetailV2New",
					filter: {
						masterColumn: "Id",
						detailColumn: "Opportunity"
					},
					defaultValues: {
						Campaign: {
							masterColumn: "Id"
						}
					}
				}
			}/**SCHEMA_DETAILS*/,
			methods: {

				/**
				 * Creates filter for detail Email.
				 * @protected
				 * @return {BPMSoft.FilterGroup} Group filters.
				 */
				emailDetailFilter: function() {
					var recordId = this.get("Id");
					var filterGroup = new this.BPMSoft.createFilterGroup();
					filterGroup.add("OpportunityNotNull", this.BPMSoft.createColumnIsNotNullFilter("Opportunity"));
					filterGroup.add("OpportunityConnection", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Opportunity", recordId));
					filterGroup.add("ActivityType", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
					return filterGroup;
				},

				/**
				 * Checks show Contact details.
				 * @return {Boolean} True if show.
				 */
				isShowContactsDetail: function() {
					var client = this.get("Client");
					if (!this.Ext.isEmpty(client) && client.column === "Contact") {
						return true;
					}
					return false;
				},

				/**
				 * Checks show Account details.
				 * @return {Boolean} True if show.
				 */
				isShowAccountsDetail: function() {
					var client = this.get("Client");
					if (!this.Ext.isEmpty(client) && client.column !== "Account") {
						return false;
					}
					return true;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "OpportunityTeam",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					},
					"index": 3
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "Type",
					"values": {
						"layout": {"column": 13, "row": 5, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"propertyName": "items",
					"name": "ResponsibleDepartment",
					"values": {
						"layout": {"column": 0, "row": 3, "colSpan": 11},
						"contentType": BPMSoft.ContentType.ENUM
					}
				},
				{
					"operation": "insert",
					"parentName": "OpportunityPageGeneralContainer",
					"name": "IsPrimary",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.RADIO_GROUP,
						"value": {"bindTo": "IsPrimary"},
						"items": [],
						"layout": {"column": 0, "row": 0, "colSpan": 11, "rowSpan": 2}
					}
				},
				{
					"operation": "insert",
					"parentName": "IsPrimary",
					"propertyName": "items",
					"name": "FirstOpportunity",
					"values": {
						"caption": {"bindTo": "Resources.Strings.FirstOpportunityCaption"},
						"value": true
					}
				},
				{
					"operation": "insert",
					"parentName": "IsPrimary",
					"propertyName": "items",
					"name": "SecondOpportunity",
					"values": {
						"caption": {"bindTo": "Resources.Strings.SecondOpportunityCaption"},
						"value": false
					}
				},
				{
					"operation": "insert",
					"name": "HistoryAccountTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.HistoryCustomerTabCaption"},
						"items": []
					},
					"index": 6
				},
				{
					"operation": "insert",
					"parentName": "HistoryAccountTab",
					"name": "OpportunityHistoryAccountTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryAccountTab",
					"propertyName": "items",
					"name": "ContactsAccount",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "isShowAccountsDetail"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryAccountTab",
					"propertyName": "items",
					"name": "OpportunityAccount",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "isShowAccountsDetail"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryAccountTab",
					"propertyName": "items",
					"name": "ActivitiesAccount",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "isShowAccountsDetail"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryAccountTab",
					"propertyName": "items",
					"name": "FilesAccount",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "isShowAccountsDetail"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryAccountTab",
					"propertyName": "items",
					"name": "OpportunityContact",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "isShowContactsDetail"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryAccountTab",
					"propertyName": "items",
					"name": "ActivitiesContact",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "isShowContactsDetail"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryAccountTab",
					"propertyName": "items",
					"name": "FilesContact",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL,
						"visible": {"bindTo": "isShowContactsDetail"}
					}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "Activities",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "Calls",
					"values": {"itemType": BPMSoft.ViewItemType.DETAIL}
				},
				{
					"operation": "insert",
					"parentName": "HistoryTab",
					"propertyName": "items",
					"name": "EmailDetailV2",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				}
			]/**SCHEMA_DIFF*/,
			rules: {}
		};
	});
