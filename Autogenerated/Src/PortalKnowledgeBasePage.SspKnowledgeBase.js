define("PortalKnowledgeBasePage", [],
		function() {
			return {
				entitySchemaName: "KnowledgeBase",
				details: /**SCHEMA_DETAILS*/{
					"FileDetailReadOnly": {
						"schemaName": "FileDetailReadOnly",
						"entitySchemaName": "KnowledgeBaseFile",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "KnowledgeBase"
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "remove",
						"name": "RelationsTab"
					},
					{
						"operation": "merge",
						"name": "Name",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"enabled": false
						}
					},
					{
						"operation": "merge",
						"name": "Type",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"enabled": false
						}
					},
					{
						"operation": "merge",
						"name": "ModifiedBy",
						"values": {
							"layout": {"column": 0, "row": 1, "colSpan": 11},
							"controlConfig": {"enabled": false}
						}
					},
					{
						"operation": "merge",
						"name": "ModifiedOn",
						"values": {
							"layout": {"column": 13, "row": 1, "colSpan": 5},
							"controlConfig": {"enabled": false}
						}
					},
					{
						"operation": "merge",
						"name": "Notes",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 24,
								"rowSpan": 1
							},
							"enabled": false
						}
					},
					{
						"operation": "remove",
						"name": "KnowledgeBasePageGeneralTegContainer"
					},
					{
						"operation": "merge",
						"name": "LikeContainer",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 24,
								"rowSpan": 1
							}
						}
					},
					{
						"operation": "remove",
						"name": "Files"
					},
					{
						"operation": "insert",
						"name": "FileDetailReadOnly",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "FilesTab",
						"propertyName": "items",
						"index": 0
					}
				]/**SCHEMA_DIFF*/,
				methods: {
					/**
					 * @overriden
					 * ############## ######## ########
					 */
					initActionButtonMenu: function() {
						this.set("ActionsButtonVisible", false);
					}
				}
			};
		});
