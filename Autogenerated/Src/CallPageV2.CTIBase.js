define("CallPageV2", ["BusinessRuleModule", "ConfigurationConstants"],
	function(BusinessRuleModule, ConfigurationConstants) {
		return {
			entitySchemaName: "Call",
			rules: {
				"Result": {
					"FiltrationResultByActivityCategory": {
						ruleType: BusinessRuleModule.enums.RuleType.FILTRATION,
						baseAttributePatch: "[ActivityCategoryResultEntry:ActivityResult].ActivityCategory",
						comparisonType: BPMSoft.ComparisonType.EQUAL,
						type: BusinessRuleModule.enums.ValueType.CONSTANT,
						value: ConfigurationConstants.Activity.ActivityCategory.Call
					}
				}
			},
			details: /**SCHEMA_DETAILS*/{
				Files: {
					schemaName: "FileDetailV2",
					entitySchemaName: "CallFile",
					filter: {
						detailColumn: "Call"
					}
				},
				EntityConnections: {
					schemaName: "EntityConnectionsDetailV2",
					entitySchemaName: "EntityConnection",
					filter: {
						masterColumn: "Id",
						detailColumn: "SysModuleEntity"
					}
				}
			}/**SCHEMA_DETAILS*/,
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "CallerId",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "CalledId",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "Direction",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"contentType": BPMSoft.ContentType.ENUM,
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "CreatedBy",
					"parentName": "Header",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.GeneralInfoTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CallDurationTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CallDurationTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotesAndFilesTab",
					"parentName": "Tabs",
					"propertyName": "tabs",
					"values": {
						"caption": {"bindTo": "Resources.Strings.NotesAndFilesTabCaption"},
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "NotesAndFilesTabContainer",
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "Files",
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"name": "NotesControlGroup",
					"parentName": "NotesAndFilesTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {"bindTo": "Resources.Strings.NotesGroupCaption"},
						"controlConfig": {
							"collapsed": false
						}
					}
				},
				{
					"operation": "insert",
					"name": "Notes",
					"parentName": "NotesControlGroup",
					"propertyName": "items",
					"values": {
						"contentType": BPMSoft.ContentType.RICH_TEXT,
						"layout": {"column": 0, "row": 0, "colSpan": 24},
						"labelConfig": {
							"visible": false
						},
						"controlConfig": {
							"imageLoaded": {
								"bindTo": "insertImagesToNotes"
							},
							"images": {
								"bindTo": "NotesImagesCollection"
							}
						}
					}
				},
				{
					"operation": "insert",
					"name": "NotesAndFilesInformationBlock",
					"parentName": "NotesAndFilesTabContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CallCommonControlGroup",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "CallPageGeneralBlock",
					"parentName": "CallCommonControlGroup",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "StartDate",
					"parentName": "CallPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "EndDate",
					"parentName": "CallPageGeneralBlock",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "CallPageResultContainer",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"values": {
						"caption": {"bindTo": "Resources.Strings.CallResultContainerCaption"},
						"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"controlConfig": {"collapsed": false}
					}
				},
				{
					"operation": "insert",
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"name": "EntityConnections",
					"values": {
						"itemType": BPMSoft.ViewItemType.DETAIL
					}
				},
				{
					"operation": "insert",
					"parentName": "CallPageResultContainer",
					"propertyName": "items",
					"name": "ResultGridLayout",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": [],
						"controlConfig": {
							"collapseEmptyRow": true
						}
					}
				},
				{
					"operation": "insert",
					"name": "Result",
					"parentName": "ResultGridLayout",
					"propertyName": "items",
					"values": {
						"contentType": BPMSoft.ContentType.ENUM,
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 24
						}
					}
				},
				{
					"operation": "insert",
					"name": "Comment",
					"parentName": "ResultGridLayout",
					"propertyName": "items",
					"values": {
						"contentType": BPMSoft.ContentType.LONG_TEXT,
						"layout": {
							"column": 0,
							"row": 4,
							"colSpan": 24,
							"rowSpan": 3
						},
						"caption": {"bindTo": "Resources.Strings.DetailedResultCaption"}
					}
				},
				{
					"operation": "insert",
					"name": "CallDurationBlock",
					"parentName": "CallDurationTab",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "Duration",
					"parentName": "CallDurationBlock",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "BeforeConnectionTime",
					"parentName": "CallDurationBlock",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "TalkTime",
					"parentName": "CallDurationBlock",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11
						}
					}
				},
				{
					"operation": "insert",
					"name": "HoldTime",
					"parentName": "CallDurationBlock",
					"propertyName": "items",
					"values": {
						"enabled": false,
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
