define("ProjectSectionV2", ["BaseFiltersGenerateModule", "ProjectGridRowViewModel", "ProjectUtilities"],
function(BaseFiltersGenerateModule) {
	return {
		entitySchemaName: "Project",
		mixins: {
			/**
			 * Contains method for project values calculations.
			 */
			ProjectUtilities: "BPMSoft.ProjectUtilities"
		},
		methods: {

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#init
			 * @overridden
			 */
			init: function() {
				this.mixins.ProjectUtilities.init.call(this);
				this.callParent(arguments);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#getSectionActions
			 * @overridden
			 */
			getSectionActions: function() {
				var actionMenuItems = this.callParent(arguments);
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Type": "BPMSoft.MenuSeparator",
					"Caption": ""
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": { "bindTo": "Resources.Strings.CalculateFinanceCaption" },
					"Click": { "bindTo": "CalculateProjectCollectionFinance" },
					"Enabled": {"bindTo": "isAnySelected"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Type": "BPMSoft.MenuSeparator",
					"Caption": { "bindTo": "Resources.Strings.ManpowerGroupCaption" }
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": { "bindTo": "Resources.Strings.CountManpowerCaption" },
					"Click": { "bindTo": "CalculateProjectCollectionActualWork" },
					"Enabled": {"bindTo": "isAnySelected"}
				}));
				actionMenuItems.addItem(this.getButtonMenuItem({
					"Caption": { "bindTo": "Resources.Strings.CalculatePlanManpowerCaption" },
					"Click": { "bindTo": "CalculateProjectCollectionLaborPlan" },
					"Enabled": {"bindTo": "isAnySelected"}
				}));
				return actionMenuItems;
			},

			/**
			 * Forms fixed filters for section data.
			 * @param {Object} filterInfo - Filter data.
			 * @param {Object} filterInfo.startDate Project start date.
			 * @param {Object} filterInfo.dueDate Project due data.
			 * @return {BPMSoft.FilterGroup} Formed filters.
			 */
			getFixedFilters:  function(filterInfo) {
				var startDate = filterInfo.startDate.value;
				var dueDate = filterInfo.dueDate.value;
				if (!startDate && !dueDate) {
					return null;
				}
				var startDateColumnName = filterInfo.startDate.columnName;
				var dueDateColumnName = filterInfo.dueDate.columnName;
				var filter = this.Ext.create("BPMSoft.FilterGroup");
				var periodFilterCollection = this.Ext.create("BPMSoft.FilterGroup");
				periodFilterCollection.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
				if (startDate) {
					filter.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					var endPeriodFilterCollection = this.Ext.create("BPMSoft.FilterGroup");
					endPeriodFilterCollection.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
					endPeriodFilterCollection.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.GREATER_OR_EQUAL, dueDateColumnName,
						this.BPMSoft.startOfDay(startDate))
					);
					endPeriodFilterCollection.addItem(this.BPMSoft.createColumnIsNotNullFilter(startDateColumnName));

					filter.addItem(endPeriodFilterCollection);

					var nullEndPeriodFilterCollection = Ext.create("BPMSoft.FilterGroup");
					nullEndPeriodFilterCollection.logicalOperation = this.BPMSoft.LogicalOperatorType.AND;
					nullEndPeriodFilterCollection.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.GREATER_OR_EQUAL, startDateColumnName,
						this.BPMSoft.startOfDay(startDate)));
					nullEndPeriodFilterCollection.addItem(this.BPMSoft.createColumnIsNullFilter(dueDateColumnName));

					filter.addItem(nullEndPeriodFilterCollection);

					periodFilterCollection.add(dueDateColumnName, filter);
				}
				if (dueDate) {
					filter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.LESS_OR_EQUAL, startDateColumnName,
						this.BPMSoft.endOfDay(dueDate));
					periodFilterCollection.addItem(filter);
				}
				if (startDate && dueDate) {
					filter = periodFilterCollection;
				}
				var finalFilter = this.Ext.create("BPMSoft.FilterGroup");
				finalFilter.add("fixedProjectFilters", filter);

				return finalFilter;
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#initFixedFiltersConfig
			 * @overridden
			 */
			initFixedFiltersConfig: function() {
				var fixedFilterConfig = {
					entitySchema: this.entitySchema,
					filters: [
						{
							name: "PeriodFilter",
							caption: this.get("Resources.Strings.PeriodFilterCaption"),
							dataValueType: this.BPMSoft.DataValueType.DATE,
							columnName: "StartDate",
							startDate: {
								columnName: "StartDate"
							},
							dueDate: {
								columnName: "EndDate"
							},
							getFilter: this.getFixedFilters.bind(this)
						},
						{
							name: "Owner",
							caption: this.get("Resources.Strings.OwnerFilterCaption"),
							dataValueType: this.BPMSoft.DataValueType.LOOKUP,
							filter: BaseFiltersGenerateModule.OwnerFilter,
							columnName: "Owner"
						}
					]
				};
				this.set("FixedFilterConfig", fixedFilterConfig);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#getGridRowViewModelClassName
			 * @overridden
			 */
			getGridRowViewModelClassName: function() {
				return "BPMSoft.ProjectGridRowViewModel";
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#onActiveRowAction
			 * @overridden
			 */
			onActiveRowAction: function(buttonTag, primaryColumnValue) {
				this.callParent(arguments);
				switch (buttonTag) {
					case "CalculateProjectFinance":
						this.CalculateProjectCollectionFinance([primaryColumnValue]);
						break;
					case "CalculateProjectActualWork":
						this.CalculateProjectCollectionActualWork([primaryColumnValue]);
						break;
					case "CalculateProjectLaborPlan":
						this.CalculateProjectCollectionLaborPlan([primaryColumnValue]);
						break;
				}
			},

			/**
			 * Removes sub project edit page.
			 * @overridden
			 */
			initEditPages: function() {
				this.callParent(arguments);
				var editPages = this.get("EditPages");
				var pages = editPages.clone();
				editPages.clear();
				pages.each(function(editPage) {
					var editPageSchemaName = editPage.get("SchemaName");
					if (editPageSchemaName !== "WorkPageV2") {
						var projectEditPageKey = editPage.get("Id");
						editPages.add(projectEditPageKey, editPage);
					}
				}, this);
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#addRecord
			 * @overridden
			 */
			addRecord: function(typeColumnValue) {
				if (!typeColumnValue) {
					var editPages = this.get("EditPages");
					typeColumnValue = editPages.getByIndex(0).get("Tag");
					this.callParent([typeColumnValue]);
				} else {
					this.callParent(arguments);
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#getFilters
			 * @overridden
			 */
			getFilters: function() {
				var filters = this.callParent(arguments);
				filters.add("FirstProjectFilter",
					this.BPMSoft.createColumnIsNullFilter(this.entitySchema.hierarchicalColumnName));
				return filters;
			},

			/**
			 * Initializes context help information.
			 * @overridden
			 * @protected
			 */
			initContextHelp: function() {
				this.set("ContextHelpId", 1021);
				this.callParent(arguments);
			},

			/**
			 * Reloads grid data by array of project identifiers.
			 * @protected
			 * @virtual
			 * @param {String[]} projects Array of projects identifiers.
			 */
			reloadItems: function(keys) {
				this.BPMSoft.each(keys, function(key) {
					this.loadGridDataRecord(key);
				}, this);
			},

			/**
			 * Performs calculation of project finances.
			 * @protected
			 * @virtual
			 * @param {String[]} projects Array of projects identifiers.
			 */
			CalculateProjectCollectionFinance: function(projects) {
				projects = projects || this.getSelectedItems();
				if (!Ext.isEmpty(projects)) {
					this.CalculateProjectFinance(projects, function() {
						this.reloadItems(projects);
					}, this);
				}
			},

			/**
			 * Performs calculation of labor plan.
			 * @protected
			 * @virtual
			 * @param {String[]} projects Array of projects identifiers.
			 */
			CalculateProjectCollectionLaborPlan: function(projects) {
				projects = projects || this.getSelectedItems();
				if (!Ext.isEmpty(projects)) {
					this.CalculateProjectLaborPlan(projects, function() {
						this.reloadItems(projects);
					}, this);
				}
			},

			/**
			 * Performs calculation on actual work.
			 * @protected
			 * @virtual
			 * @param {String[]} projects Array of projects identifiers.
			 */
			CalculateProjectCollectionActualWork: function(projects) {
				projects = projects || this.getSelectedItems();
				if (!Ext.isEmpty(projects)) {
					this.CalculateProjectActualWork(projects, function() {
						this.reloadItems(projects);
					}, this);
				}
			},

			/**
			 * @inheritDoc BPMSoft.BaseSectionV2#copyRecord
			 * @override
			 */
			copyRecord: function(primaryColumnValue, ignoreConfirmation) {
				if (ignoreConfirmation === true) {
					this.callParent(arguments);
				} else {
					this.showConfirmationDialog(
						this.get("Resources.Strings.CopyProjectStructure"),
						this.handleCopyWithStructureConfirmationResult.bind(this, primaryColumnValue),
						[this.BPMSoft.MessageBoxButtons.YES, this.BPMSoft.MessageBoxButtons.NO]
					);
				}
			},

			/**
			 * Handles confirmation result on copy action.
			 * @protected
			 * @param primaryColumnValue - record id.
			 * @param result - confirmation result.
			 */
			handleCopyWithStructureConfirmationResult: function(primaryColumnValue, result) {
				if (result === this.BPMSoft.MessageBoxButtons.YES.returnCode) {
					this.copyProject(primaryColumnValue);
				} else {
					this.copyRecord(primaryColumnValue, true);
				}
			},

			/**
			 * Copy project with hierarchy.
			 * @protected
			 * @param projectId - project identifier.
			 */
			copyProject: function(projectId) {
				var callServiceConfig = {
					serviceName: "ProjectUtilitiesService",
					methodName: "CopyProjectWithStructure",
					data: {
						"projectId": projectId
					}
				};
				this.callService(callServiceConfig, this.handleServiceCopyResponse, this);
			},

			/**
			 * Opens edit page after project copying.
			 * @protected
			 * @param response - service response.
			 */
			handleServiceCopyResponse: function(response) {
				if (!response.success || response.success !== true) {
					this.log(response.errorInfo, BPMSoft.LogMessageType.ERROR);
					return;
				}
				var recordId = response.CreatedProjectId;
				if (this.BPMSoft.isGUID(recordId) && !this.BPMSoft.isEmptyGUID(recordId)) {
					this.editRecord(recordId);
				}
			}
		},
		diff: /**SCHEMA_DIFF*/[
			//				DataGridActiveRowCopyAction
			{
				"operation": "insert",
				"name": "DataGridActiveRowActionsAction",
				"parentName": "DataGrid",
				"propertyName": "activeRowActions",
				"values": {
					"className": "BPMSoft.Button",
					"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
					"caption": { "bindTo": "Resources.Strings.ActionsButtonCaption" },
					"menu": {
						"items": [{
							"tag": "CalculateProjectFinance",
							"caption": { "bindTo": "Resources.Strings.CalculateFinanceCaption" }
						}, {
							"tag": "CalculateProjectActualWork",
							"caption": { "bindTo": "Resources.Strings.CountManpowerCaption" }
						}, {
							"tag": "CalculateProjectLaborPlan",
							"caption": { "bindTo": "Resources.Strings.CalculatePlanManpowerCaption" }
						}]
					}
				}
			}
		]/**SCHEMA_DIFF*/,
		userCode: {}
	};
});
