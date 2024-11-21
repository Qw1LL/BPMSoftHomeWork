define("ReleasePage", ["ConfigurationConstants", "ReleasePageResources", "GeneralDetails", "css!ReleasePageCSS"],
		function(ConfigurationConstants) {
			return {
				entitySchemaName: "Release",
				details: /**SCHEMA_DETAILS*/{
					"ScheduledDate": {
						"schemaName": "ScheduledDateDetail",
						"entitySchemaName": "ScheduledDate",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Release"
						}
					},
					"ReleaseTeam": {
						"schemaName": "ReleaseTeamDetail",
						"entitySchemaName": "ReleaseTeam",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Release"
						}
					},
					"Files": {
						"schemaName": "FileDetailV2",
						"entitySchemaName": "ReleaseFile",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Release"
						}
					},
					"Activity": {
						"schemaName": "ActivityReleaseDetail",
						"entitySchemaName": "Activity",
						"filter": {
							"detailColumn": "Release",
							"masterColumn": "Id"
						}
					},
					"EmailDetailV2": {
						"schemaName": "EmailDetailV2",
						"filter": {
							"detailColumn": "Release",
							"masterColumn": "Id"
						},
						"filterMethod": "emailDetailFilter"
					},
					"Service": {
						"schemaName": "ServiceItemInReleaseDetail",
						"entitySchemaName": "ReleaseServiceItem",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Release"
						}
					},
					"ConfItem": {
						"schemaName": "ConfItemInReleaseDetail",
						"entitySchemaName": "ReleaseConfItem",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Release"
						}
					},
					"ChangeDetail": {
						"schemaName": "ChangeInReleaseDetail",
						"entitySchemaName": "Change",
						"filter": {
							"masterColumn": "Id",
							"detailColumn": "Release"
						}
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
								"colSpan": 11
							}
						},
						"bindTo": "Name",
						"caption": {
							"bindTo": "Resources.Strings.NameCaption"
						},
						"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
						"labelConfig": {
							"visible": true
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
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							},
							"enabled": false
						},
						"parentName": "Header",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "Description",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 24,
								"rowSpan": 1
							},
							"bindTo": "Description",
							"caption": {
								"bindTo": "Resources.Strings.DescriptionCaption"
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
						"name": "Status",
						"values": {
							"layout": {
								"column": 0,
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
						"index": 3
					},
					{
						"operation": "insert",
						"name": "Type",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
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
						"parentName": "Header",
						"propertyName": "items",
						"index": 4
					},
					{
						"operation": "insert",
						"name": "Priority",
						"values": {
							"layout": {
								"column": 0,
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
						"index": 5
					},
					{
						"operation": "insert",
						"name": "RegistrationInformationTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.RegistrationInformationTabCaption"
							},
							"items": []
						},
						"index": 0
					},
					{
						"operation": "insert",
						"name": "PlanningImplementationTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.PlanningImplementationTabCaption"
							},
							"items": []
						},
						"index": 1
					},
					{
						"operation": "insert",
						"name": "PlanningImplementation_GridLayout",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"parentName": "PlanningImplementationTab",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ScheduledReleaseDate",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "ScheduledReleaseDate",
							"caption": {
								"bindTo": "Resources.Strings.ScheduledReleaseDateCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "PlanningImplementation_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ScheduledDate",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "PlanningImplementationTab",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "ReleaseTeam",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "RegistrationInformationTab",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "insert",
						"name": "Activity",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "PlanningImplementationTab",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "insert",
						"name": "ChangeDetail",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "PlanningImplementationTab",
						"propertyName": "items",
						"index": 4
					},
					{
						"operation": "insert",
						"name": "EmailDetailV2",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "PlanningImplementationTab",
						"propertyName": "items",
						"index": 3
					},
					{
						"operation": "insert",
						"name": "ConfItem",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "RegistrationInformationTab",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "Service",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "RegistrationInformationTab",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "PlannedLabor",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "PlannedLabor",
							"caption": {
								"bindTo": "Resources.Strings.PlannedLaborCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "PlanningImplementation_GridLayout",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "CloseTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.CloseTabCaption"
							},
							"items": []
						},
						"index": 2
					},
					{
						"operation": "insert",
						"name": "ReleasedControlGroup",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"caption": {
								"bindTo": "Resources.Strings.ReleaseGroupCaption"
							}
						},
						"parentName": "CloseTab",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ReleasedControlGroup_GridLayout",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"parentName": "ReleasedControlGroup",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ReleasedOn",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "ReleasedOn",
							"caption": {
								"bindTo": "Resources.Strings.ReleasedOnCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							},
							"enabled": false
						},
						"parentName": "ReleasedControlGroup_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "DevelopmentFinishedOn",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "DevelopmentFinishedOn",
							"caption": {
								"bindTo": "Resources.Strings.DevelopmentFinishedOnCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "ReleasedControlGroup_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "TestingFinishedOn",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "TestingFinishedOn",
							"caption": {
								"bindTo": "Resources.Strings.TestingFinishedOnCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "ReleasedControlGroup_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "DeploymentFinishedOn",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "DeploymentFinishedOn",
							"caption": {
								"bindTo": "Resources.Strings.DeploymentFinishedOnCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "ReleasedControlGroup_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "LaborControlGroup",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.CONTROL_GROUP,
							"items": [],
							"caption": {
								"bindTo": "Resources.Strings.LaborGroupCaption"
							}
						},
						"parentName": "CloseTab",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "LaborControlGroup_GridLayout",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"parentName": "LaborControlGroup",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ActualLabor",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "ActualLabor",
							"caption": {
								"bindTo": "Resources.Strings.ActualLaborCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "LaborControlGroup_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ActualDevelopmentLabor",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "ActualDevelopmentLabor",
							"caption": {
								"bindTo": "Resources.Strings.ActualDevelopmentLaborCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "LaborControlGroup_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ActualTestingLabor",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "ActualTestingLabor",
							"caption": {
								"bindTo": "Resources.Strings.ActualTestingLaborCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "LaborControlGroup_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ActualDeploymentLabor",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "ActualDeploymentLabor",
							"caption": {
								"bindTo": "Resources.Strings.ActualDeploymentLaborCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "LaborControlGroup_GridLayout",
						"propertyName": "items",
						"index": 0
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
						"index": 3
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
								"row": 1,
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
					}
				]/**SCHEMA_DIFF*/,
				attributes: {
					"Status": {
						lookupListConfig: {
							columns: ["IsFinal"]
						}
					},
					"ReleasedOn": {
						dependencies: [
							{
								columns: ["Status"],
								methodName: "onStatusChanged"
							}
						]
					}
				},
				methods: {
					/**
					 * @inheritdoc BPMSoft.BasePageV2#init
					 * @overridden
					 */
					init: function() {
						this.statusDefSysSettingsName = "ReleaseStatusDef";
						this.callParent(arguments);
					},

					/**
					 * The event handler changes the field "Status".
					 * @protected
					 */
					onStatusChanged: function() {
						var status = this.get("Status");
						if (!status) {
							return;
						}
						var originalStatus = this.get("OriginalStatus");
						if (!originalStatus) {
							return;
						}
						if (this.isNew || originalStatus !== status) {
							this.handleFinalStatus(status);
						}
					},

					/**
					 * Handler that checks whether the state final.
					 * If it is finite, set values in the "Fact. Complete".
					 * @param {Object} status ######### ######
					 */
					handleFinalStatus: function(status) {
						if (!status.IsFinal) {
							this.set("ReleasedOn", null);
						} else if (!this.get("ReleasedOn")) {
							this.set("ReleasedOn", new Date());
						}
					},

					/**
					 * Checks fields "Fact. release date" and whether it was changed during this opening.
					 * @protected
					 * @returns {Boolean}
					 */
					needUpdateReleasedOn: function() {
						return this.get("ReleasedOn") && this.changedValues.ReleasedOn;
					},

					/**
					 * Checks whether the value of the "Status" equals  System Settings "Default status value".
					 * @protected
					 * @returns {Boolean}
					 */
					isStatusDef: function() {
						var status = this.get("Status");
						var statusDefSysSettingsValue = this.get("StatusDefSysSettingsValue");
						if (!status || !statusDefSysSettingsValue) {
							return;
						}
						return statusDefSysSettingsValue.value === status.value;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#save
					 * @overridden
					 */
					save: function() {
						if (this.needUpdateReleasedOn()) {
							this.set("ReleasedOn", new Date());
						}
						this.callParent(arguments);
						this.updateOriginals();
					},

					/**
					 * It updates the information on the initial data of the object.
					 * @param {Bolean} isNull Clears the initial data.
					 */
					updateOriginals: function(isNull) {
						var status = isNull ? null : this.get("Status");
						this.set("OriginalStatus", status);
					},

					/**
					 * Returns the title of the page.
					 * @protected
					 * @virtual
					 */
					getHeader: function() {
						return this.entitySchema.caption;
					},

					/**
					 * @inheritdoc BPMSoft.BasePageV2#onEntityInitialized
					 * @overridden
					 */
					onEntityInitialized: function() {
						if (this.isAddMode() || this.isCopyMode()) {
							this.getIncrementCode(function(response) {
								this.set("Number", response);
							});
						}
						this.BPMSoft.SysSettings.querySysSettingsItem(this.statusDefSysSettingsName, function(value) {
							this.set("StatusDefSysSettingsValue", value);
						}, this);
						this.updateOriginals();
						this.callParent(arguments);
					},

					/**
					 * The function of creating filters details email.
					 * @protected
					 * @returns {createFilterGroup}
					 */
					emailDetailFilter: function() {
						var filterGroup = new this.BPMSoft.createFilterGroup();
						filterGroup.logicalOperation = BPMSoft.LogicalOperatorType.AND;
						filterGroup.add(
							"ReleaseFilter",
							this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Release", this.get("Id")
							)
						);
						filterGroup.add(
							"EmailFilter",
							this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Type", ConfigurationConstants.Activity.Type.Email
							)
						);
						return filterGroup;
					}
				},
				rules: {},
				userCode: {}
			};
		});
