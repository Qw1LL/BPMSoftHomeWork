define("ChangePage", ["BaseFiltersGenerateModule", "ServiceDeskConstants", "ConfigurationConstants",
		"ChangePageResources"],
	function(BaseFiltersGenerateModule, ServiceDeskConstants, ConfigurationConstants) {
			return {
				entitySchemaName: "Change",
				details: /**SCHEMA_DETAILS*/{
					"Files": {
						"schemaName": "FileDetailV2",
						"entitySchemaName": "ChangeFile",
						"filter": {
							"detailColumn": "Change",
							"masterColumn": "Id"
						}
					},
					"Activity": {
						"schemaName": "ActivityChangeDetail",
						"entitySchemaName": "Activity",
						"filter": {
							"detailColumn": "Change",
							"masterColumn": "Id"
						}
					},
					"EmailDetailV2": {
						"schemaName": "EmailDetailV2",
						"filter": {
							"detailColumn": "Change",
							"masterColumn": "Id"
						},
						"filterMethod": "emailDetailFilter"
					},
					"Case": {
						"schemaName": "CaseChangeDetail",
						"entitySchemaName": "Case",
						"filter": {
							"detailColumn": "Change",
							"masterColumn": "Id"
						}
					},
					"Problem": {
						"schemaName": "ProblemChangeDetail",
						"entitySchemaName": "Problem",
						"filter": {
							"detailColumn": "Change",
							"masterColumn": "Id"
						}
					},
					"ConfItem": {
						"schemaName": "ConfItemInChangeDetail",
						"entitySchemaName": "ChangeConfItem",
						"filter": {
							"detailColumn": "Change",
							"masterColumn": "Id"
						}
					},
					"Service": {
						"schemaName": "ServiceItemInChangeDetail",
						"entitySchemaName": "ChangeServiceItem",
						"filter": {
							"detailColumn": "Change",
							"masterColumn": "Id"
						}
					}
				}/**SCHEMA_DETAILS*/,
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "Header",
						"propertyName": "items",
						"name": "Name",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11
							},
							"bindTo": "Name",
							"caption": {
								"bindTo": "Resources.Strings.NameCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
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
						"name": "Owner",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Owner",
							"caption": {
								"bindTo": "Resources.Strings.OwnerCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
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
						"name": "Group",
						"values": {
							"layout": {
								"column": 13,
								"row": 3,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Group",
							"caption": {
								"bindTo": "Resources.Strings.GroupCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
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
						"name": "ClassificationTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 0,
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.ClassificationTabCaption"
							},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "Classification_GridLayout",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"parentName": "ClassificationTab",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "Purpose",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Purpose",
							"caption": {
								"bindTo": "Resources.Strings.PurposeCaption"
							},
							"contentType": this.BPMSoft.ContentType.ENUM,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Classification_GridLayout",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "Source",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Source",
							"caption": {
								"bindTo": "Resources.Strings.SourceCaption"
							},
							"contentType": this.BPMSoft.ContentType.ENUM,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Classification_GridLayout",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "Category",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Category",
							"caption": {
								"bindTo": "Resources.Strings.CategoryCaption"
							},
							"contentType": this.BPMSoft.ContentType.ENUM,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Classification_GridLayout",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "insert",
						"name": "Author",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "Author",
							"caption": {
								"bindTo": "Resources.Strings.AuthorCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Classification_GridLayout",
						"propertyName": "items",
						"index": 3
					},
					{
						"operation": "insert",
						"name": "RegisteredOn",
						"values": {
							"layout": {
								"column": 13,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "RegisteredOn",
							"caption": {
								"bindTo": "Resources.Strings.RegisteredOnCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							},
							"enabled": false
						},
						"parentName": "Classification_GridLayout",
						"propertyName": "items",
						"index": 4
					},
					{
						"operation": "insert",
						"name": "ConfItem",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "ClassificationTab",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "Service",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "ClassificationTab",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "insert",
						"name": "Case",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "ClassificationTab",
						"propertyName": "items",
						"index": 3
					},
					{
						"operation": "insert",
						"name": "Problem",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "ClassificationTab",
						"propertyName": "items",
						"index": 4
					},
					{
						"operation": "insert",
						"name": "ExecutionTab",
						"parentName": "Tabs",
						"propertyName": "tabs",
						"index": 1,
						"values": {
							"caption": {
								"bindTo": "Resources.Strings.ExecutionTabCaption"
							},
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "Execution_GridLayout",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.GRID_LAYOUT,
							"items": []
						},
						"parentName": "ExecutionTab",
						"propertyName": "items",
						"index": 0
					},
					{
						"operation": "insert",
						"name": "ScheduledClosureDate",
						"values": {
							"layout": {
								"column": 0,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "ScheduledClosureDate",
							"caption": {
								"bindTo": "Resources.Strings.ScheduledClosureDateCaption"
							},
							"contentType": this.BPMSoft.ContentType.DATE_TIME,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Execution_GridLayout",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "ClosureDate",
						"values": {
							"layout": {
								"column": 13,
								"row": 0,
								"colSpan": 11,
								"rowSpan": 1
							},
							"markerValue": "ClosureDate ФактЗавершение",
							"bindTo": "ClosureDate",
							"caption": {
								"bindTo": "Resources.Strings.ClosureDateCaption"
							},
							"contentType": this.BPMSoft.ContentType.DATE_TIME,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Execution_GridLayout",
						"propertyName": "items",
						"index": 2
					},
					{
						"operation": "insert",
						"name": "PlannedLabor",
						"values": {
							"layout": {
								"column": 0,
								"row": 1,
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
						"parentName": "Execution_GridLayout",
						"propertyName": "items",
						"index": 3
					},
					{
						"operation": "insert",
						"name": "ActualLabor",
						"values": {
							"layout": {
								"column": 13,
								"row": 1,
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
						"parentName": "Execution_GridLayout",
						"propertyName": "items",
						"index": 4
					},
					{
						"operation": "insert",
						"name": "ParentChange",
						"values": {
							"layout": {
								"column": 0,
								"row": 2,
								"colSpan": 11,
								"rowSpan": 1
							},
							"bindTo": "ParentChange",
							"caption": {
								"bindTo": "Resources.Strings.ParentChangeCaption"
							},
							"contentType": this.BPMSoft.ContentType.SHORT_TEXT,
							"labelConfig": {
								"visible": true
							}
						},
						"parentName": "Execution_GridLayout",
						"propertyName": "items",
						"index": 5
					},
					{
						"operation": "insert",
						"name": "Activity",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "ExecutionTab",
						"propertyName": "items",
						"index": 1
					},
					{
						"operation": "insert",
						"name": "EmailDetailV2",
						"values": {
							"itemType": this.BPMSoft.ViewItemType.DETAIL
						},
						"parentName": "ExecutionTab",
						"propertyName": "items",
						"index": 2
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
					"ClosureDate": {
						dependencies: [
							{
								columns: ["Status"],
								methodName: "onStatusChanged"
							}
						]
					},
					"Owner": {
						dataValueType: this.BPMSoft.DataValueType.LOOKUP,
						lookupListConfig: {filter: BaseFiltersGenerateModule.OwnerFilter}
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
					}
				},
				methods: {
					/**
					 * @inheritDoc BasePageV2#init
					 * @overridden
					 */
					init: function() {
						this.statusDefSysSettingsName = "ChangeStatusDef";
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
					 * @param {Object} status ######### #########
					 */
					handleFinalStatus: function(status) {
						if (!status.IsFinal) {
							this.set("ClosureDate", null);
						} else if (!this.get("ClosureDate")) {
							this.set("ClosureDate", new Date());
						}
					},

					/**
					 * Checks fields "Fact. Complete" and whether it was changed during this opening.
					 * @protected
					 * @returns {Boolean}
					 */
					needUpdateClosureDate: function() {
						return this.get("ClosureDate") && this.changedValues.ClosureDate;
					},

					/**
					 * Checks whether the value of the "Status" equals  System Settings "Default status value"
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
						if (this.needUpdateClosureDate()) {
							this.set("ClosureDate", new Date());
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
							"ChangeFilter",
							this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Change", this.get("Id")
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
