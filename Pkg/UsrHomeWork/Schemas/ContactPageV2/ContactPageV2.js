define("ContactPageV2", [], function() {
	return {
		entitySchemaName: "Contact",
		attributes: {},
		modules: /**SCHEMA_MODULES*/{}/**SCHEMA_MODULES*/,
		details: /**SCHEMA_DETAILS*/{
			"UsrSchema40a6a56fDetail5e03d458": {
				"schemaName": "UsrSchema40a6a56fDetail",
				"entitySchemaName": "UsrTransportRequests",
				"filterMethod": "getCancelRequestDetailFilter"
			},
			"UsrSchemaec554c99Detailc66446b5": {
				"schemaName": "UsrSchemaec554c99Detail",
				"entitySchemaName": "UsrTransportRequests",
				"filterMethod": "getRequestDetailFilter"
			}
		}/**SCHEMA_DETAILS*/,
		businessRules: /**SCHEMA_BUSINESS_RULES*/{}/**SCHEMA_BUSINESS_RULES*/,
		methods: {
			
			getCancelRequestDetailFilter: function () {
				const currentContacttId = this.get("Id");
				const canceledStatusId = "79fb9282-9544-4983-a7b6-c032f8aa4b8f";
				const filterGroup = new this.BPMSoft.createFilterGroup();
				const currentContactFilter = this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"UsrDriver",
					currentContacttId
				);
				const statusFilter = this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"UsrStatus",
					canceledStatusId
				);
				
				filterGroup.add("byContactId", currentContactFilter);
				filterGroup.add("byStatus", statusFilter);
				
				return filterGroup;
			},

			getRequestDetailFilter: function () {
				const currentContacttId = this.get("Id");
				const proseccStatusId = "e7174c11-03be-47d9-bb59-6c55838523f7";
				const toDoStatusId = "e5b533bb-6a16-4c10-bba8-95aeadab257b";
				const filterGroup = new this.BPMSoft.createFilterGroup();
				const currentContactFilter = this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"UsrOwner",
					currentContacttId
				);

				// filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.OR;
				const processStatusFilter = this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"UsrStatus",
					proseccStatusId
				);
				const toDoStatusFilter = this.BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"UsrStatus",
					toDoStatusId
				);

				filterGroup.add("byContactId", currentContactFilter);
				filterGroup.add("byPorcessStatus", processStatusFilter);
				filterGroup.add("byToDoStatus", toDoStatusFilter);

				return filterGroup;
			}
		},
		dataModels: /**SCHEMA_DATA_MODELS*/{}/**SCHEMA_DATA_MODELS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "CompletenessContainer",
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
				"name": "CompletenessContainer",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "EnrichCloudAndTimezoneContainer",
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
				"operation": "move",
				"name": "EnrichCloudAndTimezoneContainer",
				"parentName": "ProfileContainer",
				"propertyName": "items",
				"index": 2
			},
			{
				"operation": "merge",
				"name": "ContactTimezonePage",
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
				"operation": "merge",
				"name": "ContactAccountName",
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
				"name": "ContactJobTitleProfile",
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
				"name": "ContactAccountMobilePhone",
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
				"name": "ContactAccountPhone",
				"values": {
					"layout": {
						"colSpan": 24,
						"rowSpan": 1,
						"column": 0,
						"row": 7
					}
				}
			},
			{
				"operation": "merge",
				"name": "ContactAccountEmail",
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
				"operation": "insert",
				"name": "UsrSchema40a6a56fDetail5e03d458",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 6
			},
			{
				"operation": "insert",
				"name": "UsrSchemaec554c99Detailc66446b5",
				"values": {
					"itemType": 2,
					"markerValue": "added-detail"
				},
				"parentName": "GeneralInfoTab",
				"propertyName": "items",
				"index": 7
			},
			{
				"operation": "merge",
				"name": "ContactPageServiceTab",
				"values": {
					"order": 2
				}
			},
			{
				"operation": "merge",
				"name": "CommunicationChannelsTab",
				"values": {
					"order": 6
				}
			},
			{
				"operation": "merge",
				"name": "DoNotUseEmail",
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
				"name": "DoNotUseSms",
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
				"name": "DoNotUseSms",
				"parentName": "CommunicationChannelsContainer",
				"propertyName": "items",
				"index": 1
			},
			{
				"operation": "merge",
				"name": "DoNotUseCall",
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
				"name": "DoNotUseMail",
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
				"name": "JobTabContainer",
				"values": {
					"order": 7
				}
			},
			{
				"operation": "merge",
				"name": "HistoryTab",
				"values": {
					"order": 8
				}
			},
			{
				"operation": "merge",
				"name": "NotesAndFilesTab",
				"values": {
					"order": 9
				}
			},
			{
				"operation": "merge",
				"name": "TrackingEventsTab",
				"values": {
					"order": 5
				}
			},
			{
				"operation": "merge",
				"name": "WrongBrowserInfoDescription",
				"values": {
					"layout": {
						"colSpan": 20,
						"rowSpan": 5,
						"column": 3,
						"row": 7
					}
				}
			},
			{
				"operation": "merge",
				"name": "ESNTab",
				"values": {
					"order": 10
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
