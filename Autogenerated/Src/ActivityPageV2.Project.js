define("ActivityPageV2", ["LookupUtilities", "ProjectServiceHelper", "css!ProjectServiceHelper"],
		function(LookupUtilities, ProjectServiceHelper) {
			return {
				entitySchemaName: "Activity",
				attributes: {
					/**
					 * Full project name.
					 */
					"FullProjectName": {
						"dataValueType": BPMSoft.DataValueType.TEXT,
						"dependencies": [
							{
								"columns": ["FullProjectName"],
								"methodName": "onFullProjectNameChange"
							}
						]
					},
					/**
					 * Project.
					 */
					"Project": {
						"lookupListConfig": {
							columns: ["Account", "Contact", "Opportunity", "ProjectEntryType"]
						},
						"dependencies": [
							{
								"columns": ["Project"],
								"methodName": "onProjectChange"
							}
						]
					},
					/**
					 * Collection of the mutual colomns name for activity and project section.
					 */
					"CommonActivityProjectColumnsCollection": {
						"dataValueType": BPMSoft.DataValueType.COLLECTION,
						"value": ["Account", "Contact", "Opportunity"]
					}
				},
				methods: {
					/**
					 * Opens emails recivers page.
					 * @protected
					 */
					openProjectLookup: function() {
						var lookup = this.getLookupConfig("Name");
						lookup.config.actionsButtonVisible = false;
						LookupUtilities.Open(this.sandbox, lookup.config, lookup.callback, this, null, false, false);
					},

					/**
					 * Returns configuration object for lookup selection page.
					 * @protected
					 * @param {String} columnName Name of the column.
					 * @return {Object} Configuration object for lookup selection page.
					 */
					getLookupConfig: function(columnName) {
						var scope = this;
						var callback = function(args) {
							scope.onLookupSelected(args);
						};
						var rez = {
							config: {
								entitySchemaName: "Project",
								columnName: columnName,
								hierarchical: true,
								multiSelect: false
							},
							callback: callback
						};
						var projectPathFilters = Ext.create("BPMSoft.FilterGroup");
						BPMSoft.each(this.get("CommonActivityProjectColumnsCollection"), function(columnName) {
							var filter = scope.createProjectFilterByCommonField(columnName);
							if (filter) { projectPathFilters.addItem(filter); }
						});
						rez.config.filters = projectPathFilters;
						return rez;
					},

					/**
					 * Returns filters for the fields.
					 * @protected
					 * @param {String} arg
					 * @return {Object} Filters for the fields.
					 */
					createProjectFilterByCommonField: function(arg) {
						if (arg) {
							var val = this.get(arg);
							if (val) {
								return this.BPMSoft.createColumnFilterWithParameter(
										this.BPMSoft.ComparisonType.EQUAL, arg, val.value);
							} else {
								return null;
							}
						}
					},

					/**
					 * Handler for lookup selection event.
					 * @protected
					 * @param {Object} args
					 */
					onLookupSelected: function(args) {
						var project;
						var selectedRows = args.selectedRows;
						if (!selectedRows.isEmpty()) {
							project = selectedRows.getByIndex(0);
							this.loadLookupDisplayValueAsync("Project", project.value, function() {
								this.formFullProjectName(project);
							});
							return;
						} else {
							project = this.get("Project");
							if (!project) {
								return;
							}
							this.formFullProjectName(project);
						}
					},

					/**
					 *
					 * Handler for the full project change event.
					 * @protected
					 */
					onFullProjectNameChange: function() {
						var fullName = this.get("FullProjectName");
						if (this.Ext.isEmpty(fullName)) {
							this.set("Project", null);
							this.set("OldFullProjectName", "");
							return;
						}
						if (this.get("OldFullProjectName") !== fullName && this.get("IsEntityInitialized")) {
							this.openProjectLookup();
						}
					},

					/**
					 *
					 * Handler for the entity initialized event.
					 * @protected
					 * @overridden
					 */
					onEntityInitialized: function() {
						const project = this.get("Project");
						const fullProjectName = this.get("FullProjectName");
						if (project && this.Ext.isEmpty(fullProjectName)) {
							this.formFullProjectName(project);
						}
						this.set("OldFullProjectName", this.get("FullProjectName"));
						this.callParent(arguments);
					},

					/**
					 * Sets validation config for the full project name.
					 * @protected
					 */
					setValidationConfig: function() {
						this.callParent(arguments);
						this.addColumnValidator("FullProjectName", function(value) {
							var invalidMessage = "";
							if (value !== this.get("OldFullProjectName") && this.get("IsEntityInitialized")) {
								invalidMessage = this.get("Resources.Strings.FullProjectNameChangedWithoutProjectSelectionWarning");
							}
							return {
								fullInvalidMessage: invalidMessage,
								invalidMessage: invalidMessage
							};
						});
					},

					/**
					 * Saved object.
					 * @overridden
					 */
					save: function() {
						var project = this.get("Project");
						var owner = this.get("Owner");
						if (!project || !owner) {
							this.callParent(arguments);
							return;
						}
						var projectId = project.value;
						var ownerId = owner.value;
						var ownerName = owner.displayValue;
						var args = arguments;
						if (!this.get("ownerChecked")) {
							ProjectServiceHelper.CheckOwnerInProjectActivity(projectId, ownerId, function(hasProjectResource) {
								if (!hasProjectResource) {
									var handler = function(result) {
										if (result !== BPMSoft.MessageBoxButtons.YES.returnCode) {
											this.set("ownerChecked", true);
											this.save(args);
											return;
										}
										ProjectServiceHelper.addContactToProjectResourceElement(projectId, owner, function() {
											this.set("ownerChecked", true);
											this.save(args);
										}, this);
									};
									var template = this.get("Resources.Strings.ProjectResourceElementMissing");
									this.showConfirmationDialog(Ext.String.format(template, ownerName), handler, ["yes", "no"]);
								} else {
									this.set("ownerChecked", true);
									this.save(args);
								}
							}, this);
							return;
						}
						this.callParent(args);
						this.set("ownerChecked", false);
					},

					/**
					 * Handler for project filed change event.
					 * @protected
					 */
					onProjectChange: function() {
						var project = this.get("Project");
						if (project) {
							if (project.Account && !this.get("Account")) {
								this.set("Account", project.Account);
							}
							if (project.Contact && !this.get("Contact")) {
								this.set("Contact", project.Contact);
							}
							if (project.Opportunity && !this.get("Opportunity")) {
								this.set("Opportunity", project.Opportunity);
							}
						}
					},

					/**
					 * Creates and sets full project name.
					 * @protected
					 * @param {Object} project
					 */
					formFullProjectName: function(project) {
						var projectId = project.value;
						ProjectServiceHelper.getProjectFullName(projectId, function(projectName) {
							this.set("OldFullProjectName", projectName);
							this.set("FullProjectName", projectName);
						}, this);
					},

					/**
					 * Gets columns name array.
					 * @ovveridden
					 * @return {[String]} Columnns name.
					 */
					getDefQuickAddColumnNames: function() {
						var columns = this.callParent(arguments);
						columns.push("Project");
						return columns;
					},

					/**
					 * Sets link to the project.
					 * @param {String} fullName
					 * @return {Object}
					 */
					setProjectUrl: function(fullName) {
						var href = {};
						var project = this.get("Project");
						if (project && !this.Ext.isEmpty(fullName)) {
							href = this.getLinkUrl("Project");
							href.caption = fullName;
						}
						return href;
					},

					/**
					 * Hadler for full project link click.
					 * @param {String} url
					 * @return {Boolean}
					 */
					onFullProjectNameLinkClick: function(url) {
						return this.onLinkClick(url, "Project");
					}
				},
				diff: /**SCHEMA_DIFF*/[
					{
						"operation": "insert",
						"parentName": "GeneralInfoTab",
						"name": "ConnectionWithProjectControlGroup",
						"propertyName": "items",
						"index": 2,
						"values": {
							"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
							"caption": {"bindTo": "Resources.Strings.ConnectionWithProjectDetailCaption"},
							"items": [],
							"wrapClass": ["connection-with-project-control-group"]
						}
					},
					{
						"operation": "insert",
						"parentName": "ConnectionWithProjectControlGroup",
						"propertyName": "items",
						"name": "FullProjectName",
						"values": {
							"layout": {"column": 0, "row": 0, "colSpan": 24},
							"tip": {
								"content": {"bindTo": "Resources.Strings.FullProjectNameTip"}
							},
							"bindTo": "FullProjectName",
							"hasClearIcon": true,
							"showValueAsLink": true,
							"caption": {"bindTo": "Resources.Strings.FullProjectCaption"},
							"href": {
								"bindTo": "FullProjectName",
								"bindConfig": {"converter": "setProjectUrl"}
							},
							"controlConfig": {
								"className": "BPMSoft.TextEdit",
								"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
								"rightIconClick": {"bindTo": "openProjectLookup"},
								"linkclick": {bindTo: "onFullProjectNameLinkClick"}
							}
						}
					}
				]/**SCHEMA_DIFF*/,
				details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/
			};
		});
