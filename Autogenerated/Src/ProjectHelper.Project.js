define("ProjectHelper", ["ext-base", "BPMSoft", "ProjectHelperResources", "ConfigurationEnums",
	"ProjectServiceHelper", "ProjectLookupModule", "XRMConstants"],
	function(Ext, BPMSoft, resources, ConfigurationEnums,
		ProjectServiceHelper, ProjectLookupModule, XRMConstants) {
		var hierarchicalProjectFieldConfig = {
			type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
			name: "Project",
			columnPath: "Project",
			dataValueType: BPMSoft.DataValueType.TEXT,
			visible: true,
			customItem: true,
			lookupPageSettings: {
				hierarchical: true,
				filterObjectPath: "[VwProjectHierarchy:BaseProject].Project",
				updateViewModel: function() {
					this.updateAddCardModuleEntityInfo = function(entity, activeRow) {
						if (entity.typeUId === XRMConstants.Project.EntryType.Project) {
							return;
						}
						var hierarchicalColumnName = this.getHierarchicalColumnName();
						if (!Ext.isEmpty(hierarchicalColumnName)) {
							entity.valuePairs = [{
								name: hierarchicalColumnName,
								value: activeRow
							}];
						}
					};
					this.isSingleSelected = function() {
						var activeRow = this.get("activeRow");
						var selectedRows = this.get("selectedRows");
						var records = activeRow ? [activeRow] : selectedRows;
						if (records && records.length === 1) {
							return true;
						}
						return false;
					};
					this.getSingleSelected = function() {
						var records = this.getSelectedItems()[0];
						if (records && records.length === 1) {
							return records[0];
						}
						return null;
					};
				},
				updateActionsConfig: function(actionsMenuConfig) {
					BPMSoft.each(actionsMenuConfig, function(menuItem) {
						if (!menuItem.tag || menuItem.tag.indexOf("add") === -1) {
							return;
						}
						if (menuItem.tag.indexOf(XRMConstants.Project.EntryType.Work) !== -1) {
							menuItem.enabled = {
								bindTo: "isSingleSelected"
							};
						}
					});
				}
			},
			filter: function() {
				var filtersCollection = BPMSoft.createFilterGroup();
				var account = this.get("Account");
				if (!Ext.isEmpty(account)) {
					filtersCollection.add("accountFilter",
						BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL,
							"[VwProjectHierarchy:Id].Account.Id",
							account.value));
				}
				return filtersCollection;
			},
			customItemConfig: {
				className: "BPMSoft.ProjectLookupEdit",
				tag: "Project",
				loadVocabulary: {bindTo: "loadVocabulary"},
				value: {bindTo: "Project"}
			}
		};

		function pushMethodsToViewModel() {
			this.ShowProjectPath = function() {
				var projectPath = this.get("Project");
				if (!Ext.isEmpty(projectPath)) {
					this.showInformationDialog();
				}
			};
			this.openProjectLookup = function() {
				this.loadVocabulary(arguments[2], arguments[3]);
			};
			this.getSelectedProjectContactAndAccount = function(projectId) {
				var select = Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: "Project"
				});
				select.addColumn("Id");
				select.addColumn("Name");
				select.addColumn("Contact");
				select.addColumn("Account");
				select.addColumn("ProjectEntryType");
				select.addColumn("Opportunity");
				var group = BPMSoft.createFilterGroup();
				group.logicalOperation = BPMSoft.LogicalOperatorType.AND;
				group.add("FilterProjectEntryType", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"ProjectEntryType", XRMConstants.Project.EntryType.Project));
				group.add("FilterVwProjectHierarchy", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL,
					"[VwProjectHierarchy:BaseProject].Project", projectId));
				select.filters.add("parentProjectFilter", group);
				select.getEntityCollection(function(result) {
					if (result.success) {
						if (result.collection.getCount() > 0) {
							var project = result.collection.getByIndex(0);
							this.updateValueFromProject(project, "Account");
							this.updateValueFromProject(project, "Contact");
							this.updateValueFromProject(project, "Opportunity");
						}
					}
				}, this);
			};
			this.updateValueFromProject = function(viewModel, columnName) {
				var value = viewModel.get(columnName);
				if (value && value.value && BPMSoft.isEmptyGUID(value.value)) {
					return;
				}
				if (!Ext.isEmpty(value)) {
					this.set(columnName, viewModel.get(columnName));
				}
			};
			this.updateProjectPath = function() {
				var project = this.get("Project");
				if (Ext.isEmpty(project)) {
					return;
				}
				ProjectServiceHelper.GetProjectParentsNames(project.value, function(result) {
					var project = this.get("Project");
					project = BPMSoft.deepClone(project);
					if (this.action === ConfigurationEnums.CardState.View) {
						project.displayValue = projectCaptionConverter(result);
					}
					if (!Ext.isEmpty(project)) {
						this.getSelectedProjectContactAndAccount(project.value);
					}
					project.customDisplayValue = result;
					this.set("Project", project);
				}, this);
			};
			var baseInit = this.init;
			this.init = function() {
				baseInit.apply(this, arguments);
				this.on("change:Project", function() {
					this.updateProjectPath();
				}, this);
				this.updateProjectPath();
			};
		}

		function projectCaptionConverter(projectPath) {
			if (Ext.isEmpty(projectPath)) {
				return "";
			}
			var elementsCount = projectPath.length;
			if (elementsCount === 1) {
				return projectPath[0];
			}
			if (elementsCount === 2) {
				return projectPath.join("/");
			}
			if (elementsCount > 2) {
				return projectPath[0] + "/ ... /" + projectPath[projectPath.length - 1];
			}
			return "";
		}
		var projectFieldConfig = {
			type: BPMSoft.core.enums.ViewModelSchemaItem.ATTRIBUTE,
			name: "Project",
			columnPath: "Project",
			dataValueType: BPMSoft.DataValueType.LOOKUP,
			visible: true,
			filter: function() {
				var filtersCollection = BPMSoft.createFilterGroup();
				filtersCollection.add("ParentFilter", BPMSoft.createColumnIsNullFilter("ParentProject"));
				var account = this.get("Account");
				if (!Ext.isEmpty(account)) {
					filtersCollection.add("AccountFilter",
						BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Account",
							account.value));
				}

				return filtersCollection;
			},
			lookupPageSettings: {
				updateActionsConfig: function(actionsMenuConfig) {
					BPMSoft.each(actionsMenuConfig, function(menuItem) {
						if (!menuItem.tag || menuItem.tag.indexOf("add") === -1) {
							return;
						}
						if (menuItem.tag.indexOf(XRMConstants.Project.EntryType.Work) !== -1) {
							menuItem.visible = false;
						}
					});
				}
			}
		};
		return {
			ProjectFieldConfig: projectFieldConfig,
			HierarchicalProjectFieldConfig: hierarchicalProjectFieldConfig,
			PushMethodsToViewModel: pushMethodsToViewModel
		};
	});
