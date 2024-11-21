define("WorkResourceElementPageV2", ["WorkResourceElementServiceHelper", "ProjectServiceHelper", "ConfigurationEnums"],
		function(WorkResourceElementServiceHelper, ProjectServiceHelper, ConfigurationEnums) {
			return {
				entitySchemaName: "WorkResourceElement",
				attributes: {
					"Project": {
						"lookupListConfig": {
							"columns": ["ParentProject", "ParentProject.ProjectEntryType"]
						}
					},
					"ProjectResourceElement": {
						"lookupListConfig": {
							filter: function() {
								var rootProjectId = this.get("RootProjectId");
								return BPMSoft.createColumnFilterWithParameter(
										BPMSoft.ComparisonType.EQUAL, "Project",
										rootProjectId);
							}
						}
					}
				},
				methods: {
					/**
					 * ########## ###### ######### ######## ########
					 * @override
					 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ########
					 */
					getActions: function() {
						return this.Ext.create("BPMSoft.BaseViewModelCollection");
					},

					/**
					 * ####### ######### ############# ########
					 * @overridden
					 */
					onEntityInitialized: function() {
						this.callParent(arguments);
						this.set("RootProjectId", BPMSoft.GUID_EMPTY);
						var projectRes = this.get("ProjectResourceElement");
						this.set("oldProjectResourceElementId",
								(!Ext.isEmpty(projectRes) && BPMSoft.isGUID(projectRes.value)) ? projectRes.value : null);
						this.set("oldPlanningWork", this.get("PlanningWork"));

						var project = this.get("Project");
						if (!project || !BPMSoft.isGUID(project.value)) {
							return;
						}
						ProjectServiceHelper.getRootProjectId(project.value, function(rootProjectId) {
							this.set("RootProjectId", rootProjectId);
						}, this);
						if (this.get("Operation") === ConfigurationEnums.CardState.Add) {
							this.set("PlanningWork", 0);
							this.set("ActualWork", 0);
						}
					},

					/**
					 * ########## ######
					 * @overridden
					 */
					save: function() {
						var id = this.get("Id");
						var project = this.get("Project");
						var projectResourceElement = this.get("ProjectResourceElement");
						if (!this.validate() || Ext.isEmpty(project) || Ext.isEmpty(projectResourceElement) ||
							!BPMSoft.isGUID(projectResourceElement.value) ||
							BPMSoft.isEmptyGUID(projectResourceElement.value)) {
							return;
						}
						var resourceId = projectResourceElement.value;
						var projectId = project.value;
						if (this.isNew) {
							if (!this.projectResourceElementChecked) {
								WorkResourceElementServiceHelper.GetCanCreate(id, resourceId, projectId, function(response) {
									if (!response.Success) {
										this.showInformationDialog(this.get("Resources.Strings.ResourceExists"));
									} else {
										this.projectResourceElementChecked = true;
										this.save();
									}
								}, this);
								return;
							} else {
								this.projectResourceElementChecked = false;
								this.callParent(arguments);
							}
						} else {
							if (!this.canEditChecked) {
								var planingWork = this.get("PlanningWork") || 0;
								WorkResourceElementServiceHelper.GetCanEdit(id, resourceId, planingWork, function(response) {
									if (!response.Success) {
										switch (response.Code) {
											case 1010:
												this.showInformationDialog(this.get("Resources.Strings.ResourceExists"));
												break;
											case 2110:
												this.showInformationDialog(
														Ext.String.format(this.get("Resources.Strings.PlaningWorkIsLessMessage"),
																response.Plan));
												break;
											case 3010:
												this.showInformationDialog(this.get("Resources.Strings.HasChildWorkMessage"));
												break;
											case 3020:
												this.showInformationDialog(this.get("Resources.Strings.HasChildActivityMessage"));
												break;
											default:
												break;
										}
									} else {
										this.canEditChecked = true;
										this.save();
										return;
									}
								}, this);
								return;
							}
							this.callParent(arguments);
							this.canEditChecked = false;
						}
						return;
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"name": "WorkResourceElementPageGeneralTabContainer",
						"parentName": "CardContentContainer",
						"propertyName": "items",
						"values": {
							"itemType": 7,
							"items": []
						}
					},
					{
						"operation": "insert",
						"parentName": "WorkResourceElementPageGeneralTabContainer",
						"name": "WorkResourceElementPageGeneralBlock",
						"propertyName": "items",
						"values": {
							"itemType": 0,
							"items": []
						}
					},
					{
						"operation": "insert",
						"name": "Project",
						"parentName": "WorkResourceElementPageGeneralBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"row": 0,
								"column": 0,
								"colSpan": 24
							},
							"controlConfig": {
								"enabled": false
							},
							"caption": { bindTo: "Resources.Strings.WorkCaption"}
						}
					},
					{
						"operation": "insert",
						"name": "ProjectResourceElement",
						"parentName": "WorkResourceElementPageGeneralBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"row": 1,
								"column": 0,
								"colSpan": 24
							},
							"contentType": BPMSoft.ContentType.ENUM
						}
					},
					{
						"operation": "insert",
						"name": "PlanningWork",
						"parentName": "WorkResourceElementPageGeneralBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"row": 2,
								"column": 0,
								"colSpan": 24
							},
							"caption": { bindTo: "Resources.Strings.PlanningWorkCaption"}
						}
					},
					{
						"operation": "insert",
						"name": "ActualWork",
						"parentName": "WorkResourceElementPageGeneralBlock",
						"propertyName": "items",
						"values": {
							"layout": {
								"row": 3,
								"column": 0,
								"colSpan": 24
							},
							"controlConfig": {
								"enabled": false
							},
							"caption": { bindTo: "Resources.Strings.ActualWorkCaption"}
						}
					}
				]/**SCHEMA_DIFF*/
			};
		});
