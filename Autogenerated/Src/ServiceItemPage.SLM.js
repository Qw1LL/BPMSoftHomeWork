define("ServiceItemPage", ["CaseServiceUtility"],
	function() {
		return {
			entitySchemaName: "ServiceItem",
			details: /**SCHEMA_DETAILS*/{
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "ServiceItemFile",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "ServiceItem"
					}
				},
				"Cases": {
					"schemaName": "CaseInServiceItemDetail",
					"entitySchemaName": "Case",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "ServiceItem"
					}
				}
			}/**SCHEMA_DETAILS*/,
			mixins: {
				/**
				 * @class CaseServiceUtility implements work with service item on page.
				 */
				CaseServiceUtility: "BPMSoft.CaseServiceUtility"
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"name": "Name",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
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
					"name": "ReactionTimeValue",
					"values": {
						"layout": {
							"column": 22,
							"row": 0,
							"colSpan": 2,
							"rowSpan": 1
						},
						"bindTo": "ReactionTimeValue",
						"labelConfig": {
							"visible": false
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "ReactionTimeUnit",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 9,
							"rowSpan": 1
						},
						"bindTo": "ReactionTimeUnit",
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "Status",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Status",
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "HistoryTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.HistoryTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "SolutionTimeValue",
					"values": {
						"layout": {
							"column": 22,
							"row": 1,
							"colSpan": 2,
							"rowSpan": 1
						},
						"bindTo": "SolutionTimeValue",
						"labelConfig": {
							"visible": false
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "SolutionTimeUnit",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 9,
							"rowSpan": 1
						},
						"bindTo": "SolutionTimeUnit",
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "insert",
					"name": "CaseCategory",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "CaseCategory",
						"contentType": this.BPMSoft.ContentType.ENUM
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 6
				},
				{
					"operation": "insert",
					"name": "NotesFilesTab",
					"values": {
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.NotesFilesTabCaption"
						}
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "Files",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "NotesFilesTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Cases",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "HistoryTab",
					"propertyName": "items",
					"index": 0
				},

				{
					"operation": "insert",
					"name": "NotesControlGroup",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": [],
						"caption": {
							"bindTo": "Resources.Strings.NotesGroupCaption"
						}
					},
					"parentName": "NotesFilesTab",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Notes",
					"values": {
						"contentType": this.BPMSoft.ContentType.RICH_TEXT,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
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
					},
					"parentName": "NotesControlGroup",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Calendar",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Calendar",
						"caption": {
							"bindTo": "Resources.Strings.CalendarCaption"
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 7
				}
			]/**SCHEMA_DIFF*/,
			attributes: {
				"ReactionTimeUnit": {
					"lookupListConfig": {
						orders: [
							{columnPath: "Position"}
						]
					}
				},
				"SolutionTimeUnit": {
					"lookupListConfig": {
						orders: [
							{columnPath: "Position"}
						]
					}
				},
				"Calendar": {
					lookupListConfig: {
						hideActions: true
					}
				}

			},
			methods: {
				/**
				 * @inheritdoc BPMSoft.BasePageV2#initContextHelp
				 * @overridden
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1061);
					this.callParent(arguments);
				},
				/**
				 * @inheritdoc BPMSoft.BasePageV2#save
				 * @overridden
				 */
				save: function() {
					this.setAbsoluteValue("ReactionTimeValue");
					this.setAbsoluteValue("SolutionTimeValue");
					this.callParent(arguments);
				}
			},
			rules: {},
			userCode: {}
		};
	});
