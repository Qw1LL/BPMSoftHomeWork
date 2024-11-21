define("EmailPageV2", ["LookupUtilities", "ProjectServiceHelper"], function(LookupUtilities, ProjectServiceHelper) {
	return {
		entitySchemaName: "Activity",
		attributes: {
			/**
			 * ###### ######## #######.
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
			 * ######.
			 */
			"Project": {
				"lookupListConfig": {
					columns: ["Account", "Contact", "Opportunity"]
				},
				"dependencies": [
					{
						"columns": ["Project"],
						"methodName": "onProjectChange"
					}
				]
			},
			/**
			 * ######### ######## ##### ####### ######## "##########" # "#######".
			 */
			"CommonActivityProjectColumnsCollection": {
				"dataValueType": BPMSoft.DataValueType.COLLECTION,
				"value": ["Account", "Contact", "Opportunity"]
			}
		},
		methods: {
			/**
			 * ####### ######## ###### ########### Email #########.
			 * @protected
			 */
			openProjectLookup: function() {
				var lookup = this.getProjectLookupConfig("Name");
				lookup.config.actionsButtonVisible = false;
				LookupUtilities.Open(this.sandbox, lookup.config, lookup.callback, this, null, false, false);
			},

			/**
			 * ############ ############ ######## ###### ## ###########.
			 * @protected
			 * @param {String} columnName
			 * @return {Object}
			 */
			getProjectLookupConfig: function(columnName) {
				var scope = this;
				var callback = function(args) {
					scope.onProjectLookupSelected(args);
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
			 * ####### ####### ### #####.
			 * @protected
			 * @param {String} arg
			 * @return {Object}
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
			 * ###########, ##### ####### ######## ## ######## ###### ## ###########.
			 * @protected
			 * @param {Object} args
			 */
			onProjectLookupSelected: function(args) {
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
			 * ######### ######### ######## # #### #####.
			 * @protected
			 */
			onFullProjectNameChange: function() {
				var fullName = this.get("FullProjectName");
				if (this.Ext.isEmpty(fullName)) {
					this.set("Project", null);
					this.set("OldFullProjectName", "");
					return;
				}
				if (this.get("OldFullProjectName") !==  fullName && this.get("IsEntityInitialized")) {
					this.openProjectLookup();
				}
			},

			/**
			 * #####, ############# ##### ############# #######.
			 * @protected
			 * @overridden
			 */
			onEntityInitialized: function() {
				if (this.isNew) {
					var project = this.get("Project");
					var fullProjectName = this.get("FullProjectName");
					if (project && this.Ext.isEmpty(fullProjectName)) {
						this.formFullProjectName(project);
					}
				}
				this.set("OldFullProjectName", this.get("FullProjectName"));
				this.callParent(arguments);
			},

			/**
			 * ######### ########### #### "FullProjectName".
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
			 * ######### ######.
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
			 * ############ ######### ######## #### ######.
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
			 * ######### ###### ######## #######.
			 * @protected
			 * @param {Object} project
			 */
			formFullProjectName: function(project) {
				var projectId = project.value;
				ProjectServiceHelper.getRootProjectId(projectId, function(rootProjectId) {
					var fullProjectName = "";
					var projectName = project.displayValue;
					if (rootProjectId && rootProjectId !== projectId) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchemaName: "Project"
						});
						esq.addColumn("Name");
						esq.filters.add("primaryColumnFilter", this.BPMSoft.createColumnFilterWithParameter(
								this.BPMSoft.ComparisonType.EQUAL, "Id", rootProjectId));
						esq.getEntityCollection(function(result) {
							if (result.success && result.collection.getCount()) {
								fullProjectName += result.collection.getByIndex(0).values.Name + "/../" +
										projectName;
							} else {
								fullProjectName += projectName;
							}
							this.set("OldFullProjectName", fullProjectName);
							this.set("FullProjectName", fullProjectName);
						}, this);
					} else {
						this.set("OldFullProjectName", projectName);
						this.set("FullProjectName", projectName);
					}

				}, this);
			},

			/**
			 * ######## ###### ######## #######.
			 * @ovveridden
			 * @return {[String]} ###### ######## #######.
			 */
			getDefQuickAddColumnNames: function() {
				var columns = this.callParent(arguments);
				columns.push("Project");
				return columns;
			},

			/**
			 * ############# ###### # #######.
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
			 * ############ ####### ## ###### # #### "###### ### #######".
			 * @param {String} url
			 * @return {Boolean}
			 */
			onFullProjectNameLinkClick: function(url) {
				return this.onLinkClick(url, "Project");
			}
		},
		details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "insert",
				"parentName": "EmailGeneralInfoTab",
				"name": "ConnectionWithProjectControlGroup",
				"propertyName": "items",
				"index": 2,
				"values": {
					"itemType": BPMSoft.ViewItemType.CONTROL_GROUP,
					"caption": {
						"bindTo": "Resources.Strings.ConnectionWithProjectDetailCaption"
					},
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ConnectionWithProjectControlGroup",
				"propertyName": "items",
				"name": "ConnectionWithProjectControlBlock",
				"values": {
					"itemType": BPMSoft.ViewItemType.GRID_LAYOUT,
					"items": []
				}
			},
			{
				"operation": "insert",
				"parentName": "ConnectionWithProjectControlBlock",
				"propertyName": "items",
				"name": "FullProjectName",
				"values": {
					"bindTo": "FullProjectName",
					"layout": {
						"column": 0,
						"row": 0,
						"colSpan": 24
					},
					"controlConfig": {
						"className": "BPMSoft.TextEdit",
						"rightIconClasses": ["custom-right-item", "lookup-edit-right-icon"],
						"rightIconClick": {
							"bindTo": "openProjectLookup"
						},
						"linkclick": {
							bindTo: "onFullProjectNameLinkClick"
						}
					},
					"hasClearIcon": true,
					"showValueAsLink": true,
					"href": {
						"bindTo": "FullProjectName",
						"bindConfig": {"converter": "setProjectUrl"}
					}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
