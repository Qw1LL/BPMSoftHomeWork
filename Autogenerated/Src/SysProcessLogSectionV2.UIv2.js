define("SysProcessLogSectionV2", ["BaseFiltersGenerateModule", "ConfigurationConstants", "ProcessModuleUtilities",
			"SysProcessLogSectionV2GridRowViewModel", "DcmSchemaManager", "css!BaseProcessLogSectionCSS",
			"ProcessLogActions"],
	function(BaseFiltersGenerateModule, ConfigurationConstants, ProcessModuleUtilities) {
		return {
			entitySchemaName: "VwSysProcessLog",
			mixins: {
				ProcessLogActions: "BPMSoft.ProcessLogActions"
			},
			attributes: {
				/**
				 * ######## ######## ###### ## ####### ###### #### # ############ ### ############# ######
				 */
				SecurityOperationName: {
					dataValueType: BPMSoft.DataValueType.STRING,
					value: "CanManageProcessLogSection"
				},

				/**
				 * Tag for opening process diagram event.
				 */
				ShowProcessDiagramTag: {
					dataValueType: BPMSoft.DataValueType.TEXT,
					value: ""
				},

				/**
				 * Flag for showing archived records.
				 */
				ShowArchivedRecords: {
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN,
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			messages: {
				"NavigateTo": {
					mode: BPMSoft.MessageMode.BROADCAST,
					direction: BPMSoft.MessageDirectionType.PUBLISH
				}
			},
			methods: {

				/**
				 * Adds filter for archived records.
				 * @private
				 * @param {BPMSoft.FilterGroup} filters Data grid filters.
				 */
				_addArchivedFilter: function(filters) {
					if (!this.get("ShowArchivedRecords")) {
						filters.add("ArchivedFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Archived", false));
					}
					else {
						filters.add("ArchivedFilter", BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "Archived", true));
					}
				},

				/**
				 * Adds to section filters a filter, that hides DCM records.
				 * @private
				 * @param {BPMSoft.FilterGroup} filters
				 */
				addHideDcmFilter: function(filters) {
					const filterName = "HideDcm";
					filters.removeByKey(filterName);
					const shouldHideDcm = !BPMSoft.isDebug && !this.getIsFeatureEnabled("ShowDcmInProcessLog");
					if (shouldHideDcm) {
						const managerName = BPMSoft.manager.DcmSchemaManager.managerName;
						filters.add(filterName, BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.NOT_EQUAL, "SysSchema.ManagerName", managerName));
					}
				},

				/**
				 * ####### ##### ######## ####### ####### ## #### ###### "###".
				 * @overridden
				 */
				addSectionDesignerViewOptions: BPMSoft.emptyFn,

				/**
				 * ############## ####### ### ###### ###### #######
				 * @overridden
				 */
				getGridRowViewModelClassName: function() {
					return "BPMSoft.SysProcessLogSectionV2GridRowViewModel";
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getDefaultGridDataViewCaption
				 * @protected
				 * @overridden
				 */
				getDefaultGridDataViewCaption: function() {
					return this.get("Resources.Strings.ActiveViewCaption");
				},

				/**
				 * ########## ######### ######## ####### # ###### ########### #######
				 * @protected
				 * @overridden
				 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ####### # ######
				 * ########### #######
				 */
				getSectionActions: function() {
					const actionMenuItems = this.callParent(arguments);
					const newActionMenuItems = new BPMSoft.BaseViewModelCollection();
					BPMSoft.each(actionMenuItems, function(item) {
						const caption = item.values.Caption;
						if (caption && caption.bindTo === "Resources.Strings.DeleteRecordButtonCaption") {
							return;
						}
						newActionMenuItems.addItem(item);
					}, this);
					newActionMenuItems.addItem(this.getButtonMenuItem({
						Type: "BPMSoft.MenuSeparator",
						Caption: ""
					}));
					newActionMenuItems.addItem(this.getButtonMenuItem({
						Caption: { "bindTo": "Resources.Strings.CancelExecutionButtonCaption" },
						Click: { "bindTo": "cancelExecutionConfirmation" },
						Visible: { "bindTo": "getShowCancelExecutionMenuVisible" },
						IsEnabledForSelectedAll: true
					}));
					newActionMenuItems.addItem(this.getButtonMenuItem({
						Caption: { "bindTo": "Resources.Strings.OpenSettingsButtonCaption" },
						Click: { "bindTo": "_onOpenSettingsActionClick" },
						IsEnabledForSelectedAll: false
					}));
					return newActionMenuItems;
				},

				_onOpenSettingsActionClick: function() {
					this.sandbox.publish("NavigateTo", {
						target: "Section",
						options: {
							sectionSchema: "SysSettingsSection",
							hideFilterBlock: true,
							folderId: ConfigurationConstants.ProcessLog.processLogSettingsFolderId
						}
					});
				},

				/**
				 * @private
				 */
				_getIsVisibleOpenParentMenuItem: function() {
					const activeRow = this.getActiveRow();
					return Boolean(activeRow && activeRow.$Parent && activeRow.$Parent.value);
				},

				/**
				 * @overridden
				 */
				unSetMultiSelect: function() {
					this.callParent(arguments);
					if (this.get("HasCanceledItems")) {
						this.reloadGridData();
						this.set("HasCanceledItems", false);
					}
				},

				/**
				 * @overridden
				 */
				getGridDataColumns: function() {
					return Ext.apply(this.callParent(arguments), {
						"SysSchema": { path: "SysSchema" },
						"StartDate": { path: "StartDate" },
						"Parent": { path: "Parent" },
						"Status": { path: "Status" },
						"SysSchema.ManagerName": { path: "SysSchema.ManagerName" },
						"ErrorDescription": { path: "ErrorDescription" }
					});
				},

				/**
				 * ############## ######## ######## ########### #######.
				 * @overridden
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 7001);
					this.callParent(arguments);
				},

				/**
				 * @overridden
				 */
				init: function(callback, scope) {
					this.set("UseTagModule", false);
					this.set("UseStaticFolders", true);
					this.set("TagButtonVisible", false);
					this.callParent([function() {
						this.mixins.ProcessLogActions.init.call(this, callback, scope);
					}, this]);
				},

				/**
				 * #### # ###### ######## ## ## ##### #######, ######### #### ##########
				 * ############ ##### SysProcessEntity.
				 */
				updateFiltersByObjectPath: function(filter, entitySchema, updateFiltersByObjectPath) {
					if (!entitySchema) {
						return;
					}
					if (!Ext.isEmpty(filter.leftExpression) && entitySchema !== "VwSysProcessLog") {
						filter.leftExpression.columnPath =
							"[VwSysProcessEntity:SysProcess].[" + entitySchema + ":Id:EntityId]." +
								filter.leftExpression.columnPath;
					} else if (filter.getItems) {
						BPMSoft.each(filter.getItems(), function(item) {
							updateFiltersByObjectPath(item, item.rootSchemaName || entitySchema,
									updateFiltersByObjectPath);
						});
					}
				},

				/**
				 * @overridden
				 */
				initFixedFiltersConfig: function() {
					const fixedFilterConfig = {
						entitySchema: this.entitySchema,
						filters: [
							{
								name: "PeriodFilter",
								caption: this.get("Resources.Strings.PeriodFilterCaption"),
								dataValueType: BPMSoft.DataValueType.DATE,
								startDate: {
									columnName: "StartDate"
								},
								dueDate: {
									columnName: "StartDate"
								}
							},
							{
								name: "Owner",
								caption: this.get("Resources.Strings.OwnerFilterCaption"),
								columnName: "Owner",
								dataValueType: BPMSoft.DataValueType.LOOKUP,
								filter: BaseFiltersGenerateModule.OwnerFilter
							}
						]
					};
					this.set("FixedFilterConfig", fixedFilterConfig);
				},

				/**
				 * @overridden
				 */
				getFilters: function() {
					const filters = this.callParent(arguments);
					const filterName = "WorkspaceFilter";
					if (!filters.contains(filterName)) {
						filters.add(filterName, BPMSoft.createColumnFilterWithParameter(
							BPMSoft.ComparisonType.EQUAL, "SysWorkspace",
							BPMSoft.SysValue.CURRENT_WORKSPACE.value));
					}
					this._addArchivedFilter(filters);
					this.addHideDcmFilter(filters);
					return filters;
				},

				/**
				 * @inheritdoc GridUtilitiesV2#onActiveRowAction
				 * @protected
				 * @overridden
				 */
				onActiveRowAction: function(buttonTag, primaryColumnValue) {
					switch (buttonTag) {
						case "processDiagram":
							this.showProcessDiagram(primaryColumnValue);
							this.set("ShowProcessDiagramTag", "OpenProcessDiagram");
							this.sendGoogleTagManagerData();
							break;
						case "cancelExecution":
							this.cancelExecutionConfirmation();
							break;
						case "processDesigner":
							this.showProcessDesigner();
							break;
						case "showErrorDescription":
							this._showErrorDescription(primaryColumnValue);
							break;
						default:
							this.callParent(arguments);
							break;
					}
				},
				/**
				 * Shows schema designer
				 */
				showProcessDesigner: function() {
					const activeRow = this.getActiveRow();
					const managerName = activeRow.get("SysSchema.ManagerName");
					const schemaId = activeRow.get("SysSchema").value;
					switch (managerName) {
						case BPMSoft.DcmSchemaManager.managerName:
							ProcessModuleUtilities.showDcmSchemaDesignerById(schemaId);
							return;
						case BPMSoft.ProcessSchemaManager.managerName:
						default:
							ProcessModuleUtilities.showProcessSchemaDesignerById(schemaId);
					}
				},

				/**
				 * Performs opening chart the selected process.
				 */
				processDiagram: function() {
					const activeRow = this.getActiveRow();
					const schemaUId = activeRow.get(this.primaryColumnName);
					const managerName = activeRow.get("SysSchema.ManagerName");
					if (managerName === "DcmSchemaManager") {
						ProcessModuleUtilities.showDcmDiagram(schemaUId);
					} else {
						ProcessModuleUtilities.showProcessDiagram(schemaUId);
					}
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#prepareResponseCollection
				 * @overriden
				 */
				prepareResponseCollection: function(collection) {
					this.mixins.GridUtilities.prepareResponseCollection.call(this, collection);
					this.initCancelExecution(collection);
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getGoogleTagManagerData.
				 * @overridden
				 */
				getGoogleTagManagerData: function() {
					const data = this.callParent(arguments);
					const showProcessDiagramTag = this.get("ShowProcessDiagramTag");
					if (!this.Ext.isEmpty(showProcessDiagramTag)) {
						this.Ext.apply(data, {
							action: showProcessDiagramTag
						});
					}
					return data;
				},

				/**
				 * On show archived filter checkbox state change handler.
				 * @param {Boolean} value New checkbox state.
				 */
				onShowArchivedRecordsChecked: function(value) {
					this.set("ShowArchivedRecords", value);
					const filterConfig = this.get("FixedFilterConfig");
					const filterSandbox = filterConfig.sandbox;
					filterSandbox.publish("UpdateFilter", {}, [filterSandbox.id]);
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getInFolderEntityName
				 * @overridden
				 */
				getInFolderEntityName: function() {
					return "SysProcessLogInFolder";
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getFolderEntityName
				 * @overridden
				 */
				getFolderEntityName: function() {
					return "SysProcessLogFolder";
				},

				/**
				 * @inheritdoc BPMSoft.GridUtilitiesV2#getEntityColumnNameInFolderEntity
				 * @overridden
				 */
				getEntityColumnNameInFolderEntity: function() {
					return "SysProcessLog";
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getSectionCode
				 * @override
				 */
				getSectionCode: function() {
					return "SysProcessLog";
				},

				/**
				 * @private
				 */
				_openProcessLibButtonClick: function() {
					this.sandbox.publish("PushHistoryState", { hash: "SectionModuleV2/VwProcessLibSection/" });
				},

				/**
				 * @private
				 */
				_showErrorDescription: function(primaryColumnValue) {
					const item = this.getGridData().get(primaryColumnValue);
					BPMSoft.ProcessLogActions.tryShowErrorDescription(this.sandbox, item.getFullErrorDescription());
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsCardLeftContainer",
					"propertyName": "items",
					"name": "ShowProcessDesignerButton",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.TRANSPARENT_ORANGE,
						"caption": {"bindTo": "Resources.Strings.ProcessDesignerButton"},
						"click": {"bindTo": "showProcessDesigner"}
					}
				},
				{
					"operation": "insert",
					"name": "SeparateModeOpenProcessLibButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"style": BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.ProcessLibButtonCaption"},
						"click": {"bindTo": "_openProcessLibButtonClick"},
						"classes": {"textClass": ["actions-button-margin-right"]}
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowProcessDesigner",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {"bindTo": "Resources.Strings.ProcessDesignerButtonCaption"},
						"tag": "processDesigner"
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowProcessDiagram",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {"bindTo": "Resources.Strings.ProcessDiagramButtonCaption"},
						"tag": "processDiagram"
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowCancelExecution",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {"bindTo": "Resources.Strings.CancelExecutionButtonCaption"},
						"tag": "cancelExecution",
						"visible": {"bindTo": "canCancelProcessExecution"}
					}
				},
				{
					"operation": "insert",
					"name": "DataGridActiveRowShowErrorDescription",
					"parentName": "DataGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {"bindTo": "Resources.Strings.ShowErrorDescriptionButtonCaption"},
						"tag": "showErrorDescription",
						"visible": {"bindTo": "hasErrorDescription"}
					}
				},
				{
					"operation": "merge",
					"name": "SeparateModeAddRecordButton",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "CombinedModeAddRecordButton",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "DeleteRecordMenuItem",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "DataGridActiveRowDeleteAction",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "merge",
					"name": "DataGridActiveRowCopyAction",
					"values": {
						"visible": false
					}
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowDeleteAction"
				},
				{
					"operation": "merge",
					"name": "CardContainer",
					"values": {
						"wrapClass": ["card", "right-el", "sys-process-card-container"]
					}
				},
				{
					"operation": "merge",
					"name": "CombinedModeViewOptionsButton",
					"values": {
						"visible": {"bindTo": "IsSectionVisible"}
					}
				},
				{
					"operation": "insert",
					"name": "HasArchivedFilterContainer",
					"parentName": "FiltersContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["archived-process-filter-container"],
						"items": []
					}
				},
				{
					"operation": "insert",
					"parentName": "HasArchivedFilterContainer",
					"propertyName": "items",
					"name": "ShowArchivedRecords",
					"values": {
						"caption": {"bindTo": "Resources.Strings.HasArchivedFilterCaption"},
						"controlConfig": {
							"className": "BPMSoft.CheckBoxEdit",
							"checkedchanged": {"bindTo": "onShowArchivedRecordsChecked"}
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	});
