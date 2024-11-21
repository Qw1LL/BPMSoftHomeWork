define("ProblemPage", ["BaseFiltersGenerateModule", "ServiceDeskConstants", "ConfigurationConstants", "css!ProblemPageCSS"],
	function(BaseFiltersGenerateModule, ServiceDeskConstants, ConfigurationConstants) {
		return {
			entitySchemaName: "Problem",
			details: /**SCHEMA_DETAILS*/{
				"Files": {
					"schemaName": "FileDetailV2",
					"entitySchemaName": "ProblemFile",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Problem"
					}
				},
				"Case": {
					"schemaName": "CaseInProblemDetail",
					"entitySchemaName": "ProblemInCase",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Problem"
					}
				},
				"Activities": {
					"schemaName": "ActivityDetailV2",
					"entitySchemaName": "Activity",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Problem"
					}
				},
				"EmailDetailV2": {
					"schemaName": "EmailDetailV2",
					"filter": {
						"masterColumn": "Id",
						"detailColumn": "Problem"
					},
					"filterMethod": "getEmailDetailFilter"
				}
			}/**SCHEMA_DETAILS*/,
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
					"name": "Number",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Number",
						"caption": {
							"bindTo": "Resources.Strings.NumberCaption"
						},
						"enabled": false
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "Symptoms",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 24,
							"rowSpan": 1
						},
						"bindTo": "Symptoms",
						"caption": {
							"bindTo": "Resources.Strings.SymptomsCaption"
						},
						"contentType": this.BPMSoft.ContentType.LONG_TEXT,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "Owner",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Owner",
						"caption": {
							"bindTo": "Resources.Strings.OwnerCaption"
						},
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "Status",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Status",
						"caption": {
							"bindTo": "Resources.Strings.StatusCaption"
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "Group",
					"values": {
						"layout": {
							"column": 0,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Group",
						"caption": {
							"bindTo": "Resources.Strings.GroupEditCaption"
						},
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "insert",
					"name": "Priority",
					"values": {
						"layout": {
							"column": 13,
							"row": 3,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Priority",
						"caption": {
							"bindTo": "Resources.Strings.PriorityCaption"
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "Header",
					"propertyName": "items",
					"index": 6
				},
				{
					"operation": "insert",
					"name": "GeneralInfoTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.GeneralInfoTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "CurrentStatusGroupLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Type",
					"values": {
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Type",
						"caption": {
							"bindTo": "Resources.Strings.TypeCaption"
						},
						"contentType": this.BPMSoft.ContentType.ENUM,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "CurrentStatusGroupLayout",
					"propertyName": "items",
					"index": 0
				},
				{
					"operation": "insert",
					"name": "Author",
					"values": {
						"layout": {
							"column": 13,
							"row": 0,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "Author",
						"caption": {
							"bindTo": "Resources.Strings.AuthorCaption"
						},
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "CurrentStatusGroupLayout",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "ServiceItem",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ServiceItem",
						"caption": {
							"bindTo": "Resources.Strings.ServiceItemCaption"
						}
					},
					"parentName": "CurrentStatusGroupLayout",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "RegisteredOn",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "RegisteredOn",
						"caption": {
							"bindTo": "Resources.Strings.RegisteredOnCaption"
						},
						"enabled": false
					},
					"parentName": "CurrentStatusGroupLayout",
					"propertyName": "items",
					"index": 3
				},
				{
					"operation": "insert",
					"name": "ConfItem",
					"values": {
						"layout": {
							"column": 0,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ConfItem",
						"caption": {
							"bindTo": "Resources.Strings.ConfItemCaption"
						},
						"contentType": this.BPMSoft.ContentType.LOOKUP,
						"labelConfig": {
							"visible": true
						}
					},
					"parentName": "CurrentStatusGroupLayout",
					"propertyName": "items",
					"index": 4
				},
				{
					"operation": "insert",
					"name": "SolutionPlanedOn",
					"values": {
						"layout": {
							"column": 13,
							"row": 2,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SolutionPlanedOn",
						"caption": {
							"bindTo": "Resources.Strings.SolutionPlanedOnCaption"
						},
						"enabled": true
					},
					"parentName": "CurrentStatusGroupLayout",
					"propertyName": "items",
					"index": 5
				},
				{
					"operation": "insert",
					"name": "Case",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"parentName": "GeneralInfoTab",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "SolutionTab",
					"values": {
						"caption": {
							"bindTo": "Resources.Strings.SolutionTabCaption"
						},
						"items": []
					},
					"parentName": "Tabs",
					"propertyName": "tabs",
					"index": 1
				},
				{
					"operation": "insert",
					"name": "SolutionRichText_gridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "SolutionContainer",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "SolutionTab",
					"propertyName": "items",
					"name": "Activities",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"index": 2
				},
				{
					"operation": "insert",
					"parentName": "SolutionTab",
					"propertyName": "items",
					"name": "EmailDetailV2",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.DETAIL
					},
					"index": 3
				},
				{
					"operation": "insert",
					"name": "Solution",
					"values": {
						"contentType": this.BPMSoft.ContentType.RICH_TEXT,
						"layout": {
							"column": 0,
							"row": 0,
							"colSpan": 24
						},
						"labelConfig": {
							"visible": true
						},
						"bindTo": "Solution",
						"controlConfig": {
							"imageLoaded": {
								"bindTo": "insertImagesToNotes"
							},
							"images": {
								"bindTo": "NotesImagesCollection"
							}
						}
					},
					"parentName": "SolutionRichText_gridLayout",
					"propertyName": "items",
					"index": 1
				},
				{
					"operation": "insert",
					"parentName": "SolutionTab",
					"propertyName": "items",
					"name": "SolutionContainer",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
						"items": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "SolutionFooter_gridLayout",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
						"items": []
					},
					"parentName": "SolutionContainer",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "SolutionProvidedOn",
					"values": {
						"layout": {
							"column": 0,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "SolutionProvidedOn",
						"caption": {
							"bindTo": "Resources.Strings.SolutionProvidedOnCaption"
						},
						"enabled": true
					},
					"parentName": "SolutionFooter_gridLayout",
					"propertyName": "items",
					"index": 2
				},
				{
					"operation": "insert",
					"name": "ClosureDate",
					"values": {
						"layout": {
							"column": 13,
							"row": 1,
							"colSpan": 11,
							"rowSpan": 1
						},
						"bindTo": "ClosureDate",
						"caption": {
							"bindTo": "Resources.Strings.ClosureDateCaption"
						},
						"enabled": true
					},
					"parentName": "SolutionFooter_gridLayout",
					"propertyName": "items",
					"index": 3
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
					"index": 2
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
				}

			]/**SCHEMA_DIFF*/,
			attributes: {
				"Owner": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
				},
				"Author": {
					dataValueType: this.BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
				},
				"ConfItem": {
					lookupListConfig: {
						dataValueType: this.BPMSoft.DataValueType.LOOKUP,
						columns: ["Type"]
					}
				},
				"Group": {
					lookupListConfig: {
						filter: function() {
							return this.BPMSoft.createColumnInFilterWithParameters("SysAdminUnitTypeValue", [
								ServiceDeskConstants.SysAdminUnitType.Organization.Value,
								ServiceDeskConstants.SysAdminUnitType.Division.Value,
								ServiceDeskConstants.SysAdminUnitType.Managers.Value,
								ServiceDeskConstants.SysAdminUnitType.Team.Value
							]);
						}
					}
				},
				"Priority": {
					dataValueType: BPMSoft.DataValueType.LOOKUP,
					lookupListConfig: {
						orders: [
							{
								columnPath: "Priority"
							}
						]
					}
				}
			},
			methods: {
				/**
				 * ####### ######### ############# ########.
				 * ############# ################ ##### ### ##### # ########## #########!
				 * @overridden
				 */
				onEntityInitialized: function() {
					if (this.isAddMode() || this.isCopyMode()) {
						this.getIncrementCode(function(response) {
							this.set("Number", response);
						});
					}
					this.callParent(arguments);
				},

				/**
				 * ############# ############# ########### #######.
				 * @protected
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 1064);
					this.callParent(arguments);
				},

				/**
				 * ######## ###### ### ###### "Email".
				 * @return {BPMSoft.createFilterGroup}
				 */
				getEmailDetailFilter: function() {
					var filterGroup = this.BPMSoft.createFilterGroup();
					filterGroup.add("IdFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Problem", this.get("Id")));
					filterGroup.add("EmailFilter", this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email));
					return filterGroup;
				}
			},
			rules: {},
			userCode: {}
		};
	});
