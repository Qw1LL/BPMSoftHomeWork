define("SysAdminUnitSectionV2", [
		"ConfigurationConstants", "ConfigurationEnums", "PortalRoleFilterUtilities", "SysAdminUnitSectionV2Resources",
		"performancecountermanager", "GridUtilitiesV2", "css!AdministrationCSSV2", "ActualizationUtilities"
	],
	function(ConfigurationConstants, ConfigurationEnums, PortalRoleFilterUtilities, resources, performanceManager) {
		return {
			entitySchemaName: "SysAdminUnit",
			contextHelpId: "259",
			diff: [
				{
					"operation": "merge",
					"name": "SectionWrapContainer",
					"values": {
						"wrapClass": ["SysAdminUnitSectionV2", "section-wrap"]
					}
				},
				{
					"operation": "remove",
					"name": "SeparateModeAddRecordButton"
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowCopyAction"
				},
				{
					"operation": "remove",
					"name": "CombinedModeAddRecordButton"
				},
				{
					"operation": "insert",
					"parentName": "CombinedModeActionButtonsSectionContainer",
					"propertyName": "items",
					"name": "CombinedModeAddButtons",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.ActionButtonCaption"},
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"visible": {"bindTo": "IsAddOrgRoleShowed"},
						"menu": []
					},
					"index": 0
				},
				{
					"operation": "insert",
					"name": "CombinedModeAddOrganisation",
					"parentName": "CombinedModeAddButtons",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddOrganisationButtonCaption"},
						"click": {"bindTo": "onAddOrganisation"},
						"enabled": {"bindTo": "IsOrganisationShowed"}
					}
				},
				{
					"operation": "insert",
					"name": "CombinedModeAddDepartment",
					"parentName": "CombinedModeAddButtons",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddDepartmentButtonCaption"},
						"click": {"bindTo": "onAddDepartment"},
						"enabled": {"bindTo": "IsDepartmentShowed"}
					}
				},
				{
					"operation": "insert",
					"name": "CombinedModeAddCommand",
					"parentName": "CombinedModeAddButtons",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddCommandButtonCaption"},
						"click": {"bindTo": "onAddCommand"},
						"enabled": {"bindTo": "IsCommandShowed"},
						"visible": false
					}
				},
				{
					"operation": "insert",
					"name": "CombinedModeAddFuncRole",
					"parentName": "CombinedModeActionButtonsSectionContainer",
					"propertyName": "items",
					"index": 1,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.ActionButtonCaption"},
						"click": {"bindTo": "onAddFuncRole"},
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"visible": {"bindTo": "IsFuncRoleShowed"},
						"enabled": {"bindTo": "IsFuncRoleEnabled"}
					}
				},
				{
					"operation": "insert",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"index": 0,
					"name": "ActionsButton",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"caption": {"bindTo": "Resources.Strings.ActionButtonCaption"},
						"visible": {"bindTo": "IsAddOrgRoleShowed"},
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"menu": []
					}
				},
				{
					"operation": "insert",
					"name": "AddOrganisation",
					"parentName": "ActionsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddOrganisationButtonCaption"},
						"click": {"bindTo": "onAddOrganisation"},
						"enabled": {"bindTo": "IsOrganisationShowed"}
					}
				},
				{
					"operation": "insert",
					"name": "AddDepartment",
					"parentName": "ActionsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddDepartmentButtonCaption"},
						"click": {"bindTo": "onAddDepartment"},
						"enabled": {"bindTo": "IsDepartmentShowed"}
					}
				},
				{
					"operation": "insert",
					"name": "AddCommand",
					"parentName": "ActionsButton",
					"propertyName": "menu",
					"values": {
						"caption": {"bindTo": "Resources.Strings.AddCommandButtonCaption"},
						"click": {"bindTo": "onAddCommand"},
						"enabled": {"bindTo": "IsCommandShowed"},
						"visible": false
					}
				},
				{
					"operation": "insert",
					"name": "AddFuncRole",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"index": 0,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"style": this.BPMSoft.controls.ButtonEnums.style.ORANGE,
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"caption": {"bindTo": "Resources.Strings.ActionButtonCaption"},
						"click": {"bindTo": "onAddFuncRole"},
						"visible": {"bindTo": "IsFuncRoleShowed"},
						"enabled": {"bindTo": "IsFuncRoleEnabled"}
					}
				},
				{
					"operation": "insert",
					"name": "OrganizationalRolesDataView",
					"parentName": "DataViewsContainer",
					"propertyName": "items",
					"values": {
						"itemType": this.BPMSoft.ViewItemType.SECTION_VIEW,
						"items": []
					}
				},
				{
					"operation": "insert",
					"name": "OrganizationalRolesDataGridContainer",
					"parentName": "OrganizationalRolesDataView",
					"propertyName": "items",
					"values": {
						"markerValue": "OrganizationalRolesDataGrid",
						"itemType": this.BPMSoft.ViewItemType.CONTAINER,
						"wrapClass": ["grid-dataview-container-wrapClass"],
						"items": []
					}
				},
				{
					"operation": "merge",
					"name": "DataGridContainer",
					"values": {
						"markerValue": "FuncRolesDataGrid"
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"parentName": "DataGridContainer",
					"propertyName": "items",
					"values": {
						"baseOffset": 5,
						"hierarchical": true,
						"hierarchicalColumnName": "ParentRoleId",
						"expandHierarchyLevels": {"bindTo": "ExpandHierarchyLevels"},
						"updateExpandHierarchyLevels": {"bindTo": "onExpandHierarchyLevels"},
						"columnsConfig": [
							{
								"cols": 24,
								"key": [
									{
										"name": {"bindTo": "Name"}
									}
								]
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "OrganizationalRolesGrid",
					"parentName": "OrganizationalRolesDataGridContainer",
					"propertyName": "items",
					"values": {
						"id": "OrganizationalRolesGridId",
						"itemType": this.BPMSoft.ViewItemType.GRID,
						"type": {"bindTo": "GridType"},
						"listedZebra": true,
						"activeRow": {"bindTo": "OrganizationalRolesActiveRow"},
						"collection": {"bindTo": "OrganizationalRolesGridData"},
						"isEmpty": {"bindTo": "IsGridEmpty"},
						"isLoading": {"bindTo": "IsGridLoading"},
						"multiSelect": {"bindTo": "MultiSelect"},
						"primaryColumnName": "Id",
						"selectedRows": {"bindTo": "OrganizationalRolesSelectedRows"},
						"sortColumn": {"bindTo": "sortColumn"},
						"sortColumnDirection": {"bindTo": "GridSortDirection"},
						"sortColumnIndex": {"bindTo": "SortColumnIndex"},
						"selectRow": {"bindTo": "rowSelected"},
						"linkClick": {"bindTo": "linkClicked"},
						"needLoadData": {"bindTo": "needLoadData"},
						"activeRowAction": {"bindTo": "onOrganizationalRolesActiveRowAction"},
						"activeRowActions": [],
						"getEmptyMessageConfig": {"bindTo": "prepareEmptyGridMessageConfig"},
						"baseOffset": 5,
						"hierarchical": true,
						"hierarchicalColumnName": "ParentRoleId",
						"expandHierarchyLevels": {"bindTo": "ExpandHierarchyLevels"},
						"updateExpandHierarchyLevels": {"bindTo": "onExpandHierarchyLevels"},
						"columnsConfig": [
							{
								"cols": 24,
								"key": [
									{
										"name": {"bindTo": "Name"}
									}
								]
							}
						]
					}
				},
				{
					"operation": "insert",
					"name": "OrganizationalRolesGridActiveRowOpenAction",
					"parentName": "OrganizationalRolesGrid",
					"propertyName": "activeRowActions",
					"values": {
						"className": "BPMSoft.Button",
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"caption": {"bindTo": "Resources.Strings.OpenRecordGridRowButtonCaption"},
						"tag": "edit"
					}
				},
				{
					"operation": "remove",
					"name": "DataGridActiveRowDeleteAction"
				},
				{
					"operation": "remove",
					"name": "CombinedModeViewOptionsButton"
				},
				{
					"operation": "remove",
					"name": "CloseButton"
				},
				{
					"operation": "remove",
					"name": "CloseSectionButton"
				},
				{
					"operation": "merge",
					"name": "CombinedModeActionsButton",
					"values": {
						"visible": {
							"bindTo": "ShowCloseButton"
						}
					}
				},
				{
					"operation": "insert",
					"name": "CombinedModeCustomActionsButton",
					"parentName": "CombinedModeActionButtonsSectionContainer",
					"propertyName": "items",
					"index": 2,
					"values": {
						hint: {
							bindTo: "Resources.Strings.ActionButtonHint"
						},
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"caption": {"bindTo": "Resources.Strings.ActionsButtonCaption"},
						"style": this.BPMSoft.controls.ButtonEnums.style.DEFAULT,
						"classes": {
							"textClass": ["actions-button-margin-right"],
							"wrapperClass": ["actions-button-margin-right"]
						},
						"menu": {
							"items": {"bindTo": "CustomActionsButtonMenuItems"}
						}
					}
				},
				{
					"operation": "insert",
					"name": "SeparateModeCustomActionsButton",
					"parentName": "SeparateModeActionButtonsLeftContainer",
					"propertyName": "items",
					"index": 10,
					"values": {
						"itemType": this.BPMSoft.ViewItemType.BUTTON,
						"imageConfig": {"bindTo": "Resources.Images.ToolsButtonImage"},
						"style": this.BPMSoft.controls.ButtonEnums.style.TRANSPARENT,
						"classes": {
							"wrapperClass": ["custom-tools-button-wrapper", "custom-t-btn-wrapper"],
							"menuClass": ["custom-tools-button-menu"]
						},
						"menu": {
							"items": {"bindTo": "CustomActionsButtonMenuItems"}
						}
					}
				},
				{
					"operation": "remove",
					"name": "SeparateModeActionsButton"
				},
				{
					"operation": "remove",
					"name": "GridUtilsContainer"
				}
			],
			messages: {
				/**
				 * ######## ########## # ######## # #### ### ######.
				 */
				"SetRecordInformation": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ######## # ############# ####### ######## ## ####### # ####### # ############# ########.
				 */
				"RemoveRecordAndGoToParent": {
					mode: this.BPMSoft.MessageMode.PTP,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				},

				/**
				 * ######## ####### # ############# ############# ############# ######.
				 */
				"UpdateSectionGrid": {
					mode: this.BPMSoft.MessageMode.BROADCAST,
					direction: this.BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {

				/**
				 * ######## ########, ###### ## ####### ###### #### # ############ ### ############# ########.
				 */
				"SecurityOperationName": {
					"dataValueType": this.BPMSoft.DataValueType.STRING,
					"value": "CanManageUsers"
				},

				/**
				 * ####### ######## ###### ############# "############### ####".
				 */
				"OrganizationalRolesDataLoaded": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ####### ######## ###### ############# "############## ####".
				 */
				"FuncRolesDataLoaded": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ###### ######### #########
				 * @type {Array}
				 */
				"ExpandHierarchyLevels": [],

				/**
				 * ###### ######### ######### ## ############
				 * @type {Array}
				 */
				"ExpandHierarchyLevelsBeforeReload": [],

				/**
				 * ######## ######### #### ########### ###### # ############## ######.
				 */
				"CustomActionsButtonMenuItems": {
					"dataValueType": this.BPMSoft.DataValueType.COLLECTION
				},

				/**
				 * ######### ######### ####### ############# "############### ####".
				 */
				"OrganizationalRolesGridData": {"dataValueType": this.BPMSoft.DataValueType.COLLECTION},

				/**
				 * ######## ############# "############### ####".
				 */
				"OrgRolesDataViewName": {
					"dataValueType": this.BPMSoft.DataValueType.TEXT,
					"value": "OrganizationalRolesDataView"
				},

				/**
				 * ####, ########## ## ###### "###########" # #### ###### "########".
				 */
				"IsOrganisationShowed": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ####, ########## ## ###### "########" # ############# "############## ####".
				 */
				"IsFuncRoleShowed": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ####, ########## ## ###### "#############" # #### ###### "########".
				 */
				"IsDepartmentShowed": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ####, ########## ## ###### "#######" # #### ###### "########".
				 */
				"IsCommandShowed": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ####, ########## ## ###### "########" # ############# "############### ####".
				 */
				"IsAddOrgRoleShowed": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN},

				/**
				 * ####, ###### ## ######## ###### "########" # ############# "############## ####".
				 */
				"IsFuncRoleEnabled": {"dataValueType": this.BPMSoft.DataValueType.BOOLEAN},

				/**
				 * Indicates if section can warm up it's pages.
				 * @type {Boolean}
				 */
				"CanUseEditPagesWarmUp": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			mixins: {
				ActualizationUtilities: "BPMSoft.ActualizationUtilities"
			},
			methods: {

				/*
				 * ######### ########### ######## ####### ###### (###### ## ######## ###### "#######" # #### ######
				 * "########").
				 * @return {boolean} ########## true, #### ##### ####### ###### ########.
				 */
				checkOpportunityForDelete: function() {
					var row = this.getActiveRow();
					if (this.Ext.isEmpty(row)) {
						return false;
					}
					var id = row.get("Id");
					var parent = row.get("ParentRoleId");
					return !this.Ext.isEmpty(parent) && id !== ConfigurationConstants.SysAdminUnit.Id.SysAdministrators;
				},

				/**
				 * @inheritDoc GridUtilitiesV2#addItemsToGridData
				 * @overridden
				 */
				addItemsToGridData: function(dataCollection, options) {
					if (options && options.mode === "top") {
						options.mode = "child";
						options.target = this.getLastGroupId();
						this.BPMSoft.each(dataCollection.getItems(), function(item) {
							item.set("HasNesting", 1);
						}, this);
					}
					var gridData = this.getGridData();
					gridData.loadAll(dataCollection, options);
				},

				/**
				 * @inheritDoc BaseSectionV2#loadFiltersModule
				 * @overridden
				 */
				loadFiltersModule: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BaseSectionV2#loadProfileFilters
				 * @overridden
				 */
				loadProfileFilters: this.Ext.callback,

				/**
				 * @inheritDoc GridUtilitiesV2#initQueryColumns
				 * @overridden
				 */
				initQueryColumns: function(esq) {
					this.callParent(arguments);
					this.addHierarchicalColumns(esq);
				},

				/**
				 * Returns page name for current view.
				 * @return {String} Edit page name.
				 */
				getEditPageName: function() {
					return this.isOrganizationalRolesDataView() ? this.getSysAdminUnitPageName()
						: this.getFuncRolesPageName();
				},

				/**
				 * ########## ############# ######### ############### ######. #### ##### ####### ###### ## ####
				 * ###########, ## ## ######### ####### ### ########## ########.
				 * @return {String} ############# ######.
				 */
				getLastGroupId: function() {
					var result = this.isOrganizationalRolesDataView()
						? this.getActiveOrgRoleId()
						: this.getActiveFuncRoleId();
					return result || ConfigurationConstants.SysAdminUnit.Id.AllEmployees;
				},

				/**
				 * ########## ############# ############### ####, ####### ###### ###### #### ########.
				 * @protected
				 */
				getActiveOrgRoleId: function() {
					return this.get("OrganizationalRolesActiveRow") || this.get("OrgRolesActiveRow");
				},

				/**
				 * ########## ############# ############## ####, ####### ###### ###### #### ########.
				 * @protected
				 */
				getActiveFuncRoleId: function() {
					return this.get("ActiveRow") || this.get("FuncRolesActiveRow");
				},

				/**
				 * ######### ######### ######## ########### ######## #######.
				 * @protected
				 * @param {String} itemKey ID - ######### ######.
				 * @param {Object} response ##### ####### ## ######.
				 * @param {Object} callback callback - #######.
				 * @param {Boolean} isSilentMode
				 */
				loadChildItems: function(itemKey, response, callback, isSilentMode) {
					var gridData = this.getGridData();
					this.set("IsClearGridData", false);
					var collection = this.Ext.create("BPMSoft.BaseViewModelCollection");
					this.BPMSoft.each(response.collection.getItems(), function(item) {
						if (!gridData.contains(item.get("Id"))) {
							item.set("HasNesting", 1);
							collection.add(item.get("Id"), item);
						}
					}, this);
					if (collection.getCount()) {
						response.collection = collection;
						var options = {
							mode: "child",
							target: itemKey
						};
						this.onGridDataLoaded(response, options);
					} else {
						var grid = this.getCurrentGrid();
						if (this.Ext.isEmpty(grid)) {
							return;
						}
						var children = [];
						grid.getAllItemChildren(children, itemKey);
						if (children.length === 0 && !isSilentMode) {
							this.setActiveRow(itemKey);
							this.openCard(this.getEditPageName(), ConfigurationEnums.CardStateV2.EDIT,
								this.getLastGroupId());
						}
					}
					if (this.Ext.isFunction(callback)) {
						callback.call(this);
					}
				},

				/**
				 * ############ ######## ############# ######.
				 * @protected
				 * @param {String} itemKey ID - ######### ######.
				 * @param {Boolean} expanded ####### ########### ######.
				 * @param {Object} callback callback - #######.
				 * @param {Boolean} isSilentMode
				 */
				onExpandHierarchyLevels: function(itemKey, expanded, callback, isSilentMode) {
					var gridData = this.getGridData();
					if (gridData.contains(itemKey) && expanded) {
						var esq = this.getGridDataESQ();
						this.initQueryColumns(esq);
						this.initQuerySorting(esq);
						this.initQueryFilters(esq);
						esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"ParentRole.Id", itemKey));
						this.initQueryEvents(esq);
						esq.execute(function(response) {
							this.destroyQueryEvents(esq);
							this.prepareResponseCollection(response.collection);
							this.toggleHierarchyFolding(itemKey, expanded);
							this.loadChildItems(itemKey, response, callback, isSilentMode);
						}, this);
					}
				},

				/**
				 * ######### ######### ###### ####### ##### hierarchicalMinusCss/hierarchicalPlusCss,
				 * #### #### #########/######## ## ######## ########.
				 * @param {String} rowId ID ###### # #######.
				 * @param {Boolean} expanded #######, ### #### ######### ######## ########.
				 */
				toggleHierarchyFolding: function(rowId, expanded) {
					var grid = this.getCurrentGrid();
					var toggle = this.Ext.get(grid.id + grid.hierarchicalTogglePrefix + rowId);
					if (this.Ext.isEmpty(toggle)) {
						return;
					}
					if (expanded) {
						if (toggle.hasCls(grid.hierarchicalPlusCss)) {
							toggle.removeCls(grid.hierarchicalPlusCss);
						}
						toggle.addCls(grid.hierarchicalMinusCss);
					} else {
						if (toggle.hasCls(grid.hierarchicalMinusCss)) {
							toggle.removeCls(grid.hierarchicalMinusCss);
						}
						toggle.addCls(grid.hierarchicalPlusCss);
					}
				},

				/**
				 * Recursively opens all parent groups of hierarchical group.
				 * @protected
				 * @param {String} itemKey ID - ######### ######.
				 * @param {Function} callback callback - #######.
				 */
				expandItemWithParents: function(itemKey, callback) {
					var gridData = this.getGridData();
					if (gridData.contains(itemKey)) {
						this.set("ExpandHierarchyLevels", [itemKey]);
						this.onExpandHierarchyLevels(itemKey, true, null, true);
						if (this.Ext.isFunction(callback)) {
							callback.call(this);
						}
					} else {
						var esq = this.getGridDataESQ();
						this.initQueryColumns(esq);
						this.initQuerySorting(esq);
						this.initQueryFilters(esq);
						esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"Id", itemKey));
						this.initQueryEvents(esq);
						esq.execute(function(response) {
							this.destroyQueryEvents(esq);
							this.BPMSoft.each(response.collection.getItems(), function(item) {
								var parentId = item.get("ParentRoleId");
								if (parentId && !this.Ext.isEmpty(parentId)) {
									this.expandItemWithParents(parentId, function() {
										this.expandItemWithParents(itemKey, callback);
									});
								} else if (this.Ext.isEmpty(this.getActiveRowId())) {
									var gridData = this.getGridData();
									if (gridData.contains(itemKey)) {
										this.setActiveRow(itemKey);
									}
								}
							}, this);
						}, this);
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#reloadGridColumnsConfig
				 * @overridden
				 */
				reloadGridColumnsConfig: function(doReRender) {
					var performanceManagerLabel = this.sandbox.id + "_reloadGridColumnsConfig";
					performanceManager.start(performanceManagerLabel);
					var listedConfig = {
						"type": "listed",
						"isTiled": false,
						"listedConfig": {
							"items": [
								{
									"bindTo": this.entitySchema.primaryDisplayColumn.columnPath,
									"caption": this.entitySchema.primaryDisplayColumn.caption,
									"position": {
										"column": 0,
										"colSpan": 24,
										"row": 1
									},
									"dataValueType": 1,
									"metaCaptionPath": this.entitySchema.primaryDisplayColumn.caption,
									"metaPath": this.entitySchema.primaryDisplayColumn.columnPath,
									"path": this.entitySchema.primaryDisplayColumn.columnPath
								}
							]
						}
					};
					var grid = this.getCurrentGrid();
					if (!grid) {
						performanceManager.stop(performanceManagerLabel);
						return;
					}
					grid.type = this.BPMSoft.GridType.LISTED;
					var viewGenerator = this.Ext.create("BPMSoft.ViewGenerator");
					viewGenerator.viewModelClass = this;
					var gridConfig;
					var bindings = this.BPMSoft.deepClone(grid.bindings);
					gridConfig = {
						listedConfig: listedConfig.listedConfig,
						type: listedConfig.type
					};
					viewGenerator.actualizeListedGridConfig(gridConfig);
					grid.captionsConfig = gridConfig.listedConfig.captionsConfig;
					grid.columnsConfig = gridConfig.listedConfig.columnsConfig;
					grid.listedConfig = gridConfig.listedConfig;
					grid.initBindings(gridConfig.listedConfig);
					grid.bindings = bindings;
					if (doReRender) {
						grid.clear();
						grid.prepareCollectionData();
						if (grid.rendered) {
							grid.reRender();
						}
					}
					var gridData = this.getGridData();
					var activeRowId = this.getActiveRowId();
					var hasActiveRow = !gridData.isEmpty() && grid.rendered && activeRowId;
					if (hasActiveRow) {
						this.expandParentGridItem(activeRowId);
					}
					performanceManager.stop(performanceManagerLabel);
				},

				/**
				 * @inheritDoc BaseSectionV2#onRender
				 * @overridden
				 */
				onRender: function() {
					var historyState = this.getHistoryStateInfo();
					var primaryId = this.getActiveRowId();
					if (historyState.operation !== "edit" || this.Ext.isEmpty(historyState.schemas[1])) {
						this.replaceHistoryForOpeningCard(ConfigurationConstants.SysAdminUnit.Id.AllEmployees, true);
					} else if (!this.Ext.isEmpty(primaryId) && historyState.primaryColumnValue !== primaryId) {
						this.openCard(this.getEditPageName(), ConfigurationEnums.CardStateV2.EDIT, primaryId);
					}
					this.callParent(arguments);
				},

				/**
				 * ######### ###### historyState # ###### ######### ##########.
				 * @param {String} primaryId ############# ######, ### ####### ##### ####### ######## ##############.
				 * @param {Boolean} isSilent ######### ## ##, ##### ## ######### ####### ## ########## ######.
				 * @protected
				 */
				replaceHistoryForOpeningCard: function(primaryId, isSilent) {
					var pageName = this.getCurrentPageName();
					this.sandbox.publish("ReplaceHistoryState", {
						hash: this.BPMSoft.combinePath("SectionModuleV2", this.name,
							pageName, "edit", primaryId),
						silent: isSilent,
						stateObj: {
							module: "SectionModuleV2",
							operation: "edit",
							primaryColumnValue: primaryId,
							schemas: [
								this.name,
								pageName
							],
							workAreaMode: ConfigurationEnums.WorkAreaMode.COMBINED,
							moduleId: this.sandbox.id
						}
					});
				},

				/**
				 * ########## ### ######## ############## ### ######### #############.
				 * @return {String} ### ######## ##############.
				 */
				getCurrentPageName: function() {
					return this.isOrganizationalRolesDataView() ? this.getSysAdminUnitPageName() : this.getFuncRolesPageName();
				},

				/**
				 * @inheritDoc BaseSectionV2#onCardModuleResponse
				 * @overridden
				 * @param {Object} response
				 */
				onCardModuleResponse: function(response) {
					if (this.get("targetType") !== ConfigurationConstants.SysAdminUnit.TypeGuid.User) {
						if (response.action === "edit") {
							this.reloadGridData();
						}
						this.loadGridDataRecord(response.primaryColumnValue);
					}
				},

				/**
				 * ######## ###### #### ###### "###"
				 * @inheritDoc BPMSoft.BaseSectionV2#getViewOptions
				 * @overridden
				 */
				getViewOptions: function() {
					var viewOptions = this.Ext.create("BPMSoft.BaseViewModelCollection");
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.SortMenuCaption"},
						"Items": this.get("SortColumns")
					}));
					viewOptions.addItem(this.getButtonMenuItem({
						"Caption": {"bindTo": "Resources.Strings.OpenGridSettingsCaption"},
						"Click": {"bindTo": "openGridSettings"}
					}));
					return viewOptions;
				},

				/**
				 * ############ ####### ## ###### ########## ######.
				 * @protected
				 * @param {String} buttonTag
				 * @param {String} primaryColumnValue
				 */
				onOrganizationalRolesActiveRowAction: function(buttonTag, primaryColumnValue) {
					switch (buttonTag) {
						case "edit":
							this.editRecord(primaryColumnValue);
							break;
						case "copy":
							this.copyRecord(primaryColumnValue);
							break;
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#onDeleted
				 * @overridden
				 */
				onDeleted: function(returnCode) {
					this.callParent(returnCode);
					if (returnCode.Success) {
						var deletedItems = this.get("deletedItems");
						if (deletedItems.length) {
							this.removeGridRecords(deletedItems);
						}
						var parent = this.get("parentRow");
						this.setActiveRow(parent);
						this.editRecord(ConfigurationConstants.SysAdminUnit.Id.AllEmployees);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getActiveRow
				 * @overridden
				 */
				getActiveRow: function() {
					var activeRow = null;
					var primaryColumnValue = this.getActiveRowId();
					if (primaryColumnValue) {
						var gridData = this.getGridData();
						activeRow = gridData.find(primaryColumnValue) ? gridData.get(primaryColumnValue) : null;
					}
					return activeRow;
				},

				/**
				 * Gets page name of the edit record.
				 * @inheritDoc BPMSoft.BaseSectionV2#getEditPageSchemaName
				 * @overridden
				 */
				getEditPageSchemaName: function() {
					var orgRoleEditPage = this.getSysAdminUnitPageName();
					var funcRoleEditPage = this.getFuncRolesPageName();
					if (this.isOrganizationalRolesDataView()) {
						return orgRoleEditPage;
					} else {
						return funcRoleEditPage;
					}
				},

				/**
				 * Gets default view.
				 * @inheritDoc BPMSoft.BaseSectionV2#getDefaultDataViews
				 * @overridden
				 */
				getDefaultDataViews: function() {
					var baseDataViews = this.callParent(arguments);
					baseDataViews = {
						UsersDataView: {
							index: 0,
							name: "UsersDataView",
							caption: this.get("Resources.Strings.UsersHeader"),
							hint: this.get("Resources.Strings.UsersDataViewHint"),
							icon: this.get("Resources.Images.UsersDataViewIcon")
						},
						OrganizationalRolesDataView: {
							index: 1,
							name: "OrganizationalRolesDataView",
							caption: this.get("Resources.Strings.OrganizationalRolesHeader"),
							hint: this.get("Resources.Strings.OrganizationalStructureDataViewHint"),
							icon: this.get("Resources.Images.OrgRolesIcon")
						},
						GridDataView: {
							index: 2,
							name: "GridDataView",
							caption: this.get("Resources.Strings.FunctionalRolesHeader"),
							hint: this.get("Resources.Strings.FunctionalRolesDataViewHint"),
							icon: this.get("Resources.Images.FuncRolesIcon")
						}
					};
					return baseDataViews;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#changeDataView
				 * @overridden
				 */
				changeDataView: function(view) {
					if (view.tag === "UsersDataView") {
						this.moveToUsersSection();
					} else {
						this.callParent(arguments);
					}
				},

				/**
				 * ######### ####### # ###### #############.
				 * @protected
				 */
				moveToUsersSection: function() {
					this.sandbox.publish("PushHistoryState", {
						hash: this.BPMSoft.combinePath("SectionModuleV2", "UsersSectionV2"),
						stateObj: {
							module: "SectionModuleV2",
							schemas: ["UsersSectionV2"],
							UsersActiveRow: this.get("UsersActiveRow"),
							FuncRolesActiveRow: this.getActiveFuncRoleId(),
							OrgRolesActiveRow: this.getActiveOrgRoleId()
						}
					});
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#reloadGridData
				 * @overridden
				 */
				reloadGridData: function() {
					if (!this.get("IsGridLoading")) {
						var activeRow = this.getActiveRow();
						var expandedItems = this.get("ExpandHierarchyLevels");
						this.set("ActiveRowBeforeReload", activeRow);
						this.set("ExpandHierarchyLevelsBeforeReload", expandedItems);
						this.set("IsClearGridData", true);
						this.loadGridData();
					}
				},

				/**
				 * ########## ######### ############# ####### ## #########
				 * @inheritDoc BPMSoft.BaseSectionV2#getDefaultGridDataViewCaption
				 * @overridden
				 */
				getDefaultGridDataViewCaption: function() {
					var caption = this.isOrganizationalRolesDataView()
						? this.get("Resources.Strings.OrganizationalRolesHeader")
						: this.get("Resources.Strings.FunctionalRolesHeader");
					return caption;
				},

				/**
				 * ######## #######, ### ######## ############# ### "############### ####".
				 * @protected
				 * @return {boolean} ########## true, #### ###### ####### ############# "############### ####", false
				 * # ######### ######.
				 */
				isOrganizationalRolesDataView: function() {
					if (this.Ext.isEmpty(this.get("ActiveViewName"))) {
						this.makeAllViewsNotActive();
						var historyState = this.getHistoryStateInfo();
						return historyState.schemas[1] !== this.getFuncRolesPageName();
					}
					return (this.get("ActiveViewName") === this.get("OrgRolesDataViewName"));
				},

				/**
				 * Returns name of func roles page.
				 * @protected
				 * @returns {String} Name of func roles page.
				 */
				getFuncRolesPageName: function() {
					return "SysAdminUnitFuncRolePageV2";
				},

				/**
				 * Returns name of admin units page.
				 * @protected
				 * @returns {String} Name of admin units page.
				 */
				getSysAdminUnitPageName: function() {
					return "SysAdminUnitPageV2";
				},

				/**
				 * ######## ###### ############# ####### # ###### ## ## #########.
				 * @protected
				 */
				makeAllViewsNotActive: function() {
					var dataViews = this.get("DataViews");
					if (dataViews) {
						dataViews.each(function(dataView) {
							dataView.active = false;
						}, this);
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getActiveViewName
				 * @overridden
				 */
				getActiveViewName: function() {
					var activeViewName = this.isOrganizationalRolesDataView()
						? this.get("OrgRolesDataViewName")
						: this.get("GridDataViewName");
					var dataViews = this.get("DataViews");
					if (dataViews) {
						dataViews.each(function(dataView) {
							if (dataView.active) {
								activeViewName = dataView.name;
							}
						}, this);
					}
					return activeViewName;
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#onGridDataLoaded
				 * @overridden
				 */
				onGridDataLoaded: function(response, options) {
					var gridData = this.getGridData();
					var recordsCount = gridData.getCount();
					var isClearGridData = this.get("IsClearGridData");
					if ((recordsCount > 0) && isClearGridData) {
						gridData.clear();
						this.set("IsClearGridData", false);
					}
					var performanceManagerLabel = this.sandbox.id + "_onGridDataLoaded";
					performanceManager.start(performanceManagerLabel);
					this.afterLoadGridData();
					if (!response.success) {
						performanceManager.stop(performanceManagerLabel);
						return;
					}
					var dataCollection = response.collection;
					this.prepareResponseCollection(dataCollection);
					this.BPMSoft.each(dataCollection.getItems(), function(item) {
						item.set("HasNesting", 1);
					}, this);
					this.initIsGridEmpty(dataCollection);
					this.addItemsToGridData(dataCollection, options);
					performanceManager.stop(performanceManagerLabel);
				},

				/**
				 * ######### # ######### ####### ####### ### ########## ########.
				 * @protected
				 * @param {BPMSoft.EntitySchemaQuery} esq ######, # ####### ##### ######### #######.
				 */
				addHierarchicalColumns: function(esq) {
					if (!esq.columns.contains("ParentRoleId")) {
						esq.addColumn("ParentRole.Id", "ParentRoleId");
					}
					if (!esq.columns.contains("ParentRole")) {
						esq.addColumn("ParentRole");
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#initQuerySorting
				 * @overridden
				 */
				initQuerySorting: function(esq) {
					var gridDataColumns = this.getGridDataColumns();
					var primaryDisplayColumnName = this.entitySchema.primaryDisplayColumnName;
					this.BPMSoft.each(gridDataColumns, function(column) {
						if (primaryDisplayColumnName === column.path) {
							var sortedColumn = esq.columns.collection.get(column.path);
							sortedColumn.orderPosition = 1;
							sortedColumn.orderDirection = this.BPMSoft.OrderDirection.ASC;
						}
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#loadGridData
				 * @overridden
				 */
				loadGridData: function() {
					if (this.get("IsGridLoading") === true) {
						return;
					}
					var performanceManagerLabel = this.sandbox.id + "_loadGridData";
					performanceManager.start(performanceManagerLabel);
					this.beforeLoadGridData();
					var esq = this.getGridDataESQ();
					this.initQueryColumns(esq);
					this.initQuerySorting(esq);
					this.initQueryFilters(esq);
					esq.filters.addItem(this.BPMSoft.createColumnIsNullFilter("ParentRole"));
					this.initQueryOptions(esq);
					this.initQueryEvents(esq);
					this.setGridDataLoaded();
					esq.getEntityCollection(function(response) {
						this.destroyQueryEvents(esq);
						performanceManager.stop(performanceManagerLabel);
						this.onGridDataLoaded(response);
						var rootIds = response.collection.getKeys();
						this.BPMSoft.each(rootIds, function(item) {
							this.set("ExpandHierarchyLevels", [item]);
							this.onExpandHierarchyLevels(item, true, null, true);
						}, this);
						var itemsToExpand = this.get("ExpandHierarchyLevelsBeforeReload");
						if (itemsToExpand) {
							itemsToExpand = itemsToExpand.reverse();
							this.BPMSoft.each(itemsToExpand, function(item) {
								this.expandItemWithParents(item);
							}, this);
						}
					}, this);
				},

				/**
				 * ############# ####### ######## ###### #######.
				 * @protected
				 */
				setGridDataLoaded: function() {
					if (this.isOrganizationalRolesDataView()) {
						this.set("OrganizationalRolesDataLoaded", true);
					} else {
						this.set("FuncRolesDataLoaded", true);
					}
				},

				/**
				 * ########## ###### ##### ##### ### ##########.
				 * @private
				 * @return {Array} ########## ###### ##### #####.
				 */
				getSysAdminUnitTypeList: function() {
					return [
						ConfigurationConstants.SysAdminUnit.Type.Organisation,
						ConfigurationConstants.SysAdminUnit.Type.Department,
						ConfigurationConstants.SysAdminUnit.Type.Team
					];
				},

				/**
				 * ########## ###### ######## ### ######### ############## #####.
				 * @return {BPMSoft.FilterGroup} ###### ########.
				 */
				getFunctionalRolesFilter: function() {
					var filterGroup = this.BPMSoft.createFilterGroup();
					filterGroup.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"SysAdminUnitTypeValue",
						ConfigurationConstants.SysAdminUnit.Type.FuncRole));
					filterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL,
						"Id",
						ConfigurationConstants.SysAdminUnit.Id.AllEmployees));
					return filterGroup;
				},

				/**
				 * ######### ## ##### ####### ####### # #### ## ######, ## ####### #### ######.
				 * @param {Object} filters ##### ########.
				 * @param {String} key ### #######.
				 */
				tryRemoveFilter: function(filters, key) {
					if (filters.contains(key)) {
						filters.removeByKey(key);
					}
				},

				/**
				 * Adds OrganizationalRolesFilter to the existing filters.
				 * @param filters {BPMSoft.FilterGroup} Filters applied in the SysAdminUnit section.
				 */
				addOrganizationalRolesFilter: function (filters) {
					var roles = this.getSysAdminUnitTypeList();
					var orgRolesFilter = PortalRoleFilterUtilities.getSysAdminUnitFilterGroup(roles);
					filters.add("OrganizationalRolesFilter", orgRolesFilter);
				},

				/**
				 * ########## ###### ########, ########### # #######.
				 * @inheritDoc BPMSoft.BaseSectionV2#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var filters = this.callParent(arguments);
					if (this.isOrganizationalRolesDataView()) {
						this.tryRemoveFilter(filters, "FunctionalRolesFilter");
						if (!filters.contains("OrganizationalRolesFilter")) {
							this.addOrganizationalRolesFilter(filters);
						}
					} else {
						this.tryRemoveFilter(filters, "OrganizationalRolesFilter");
						if (!filters.contains("FunctionalRolesFilter")) {
							var functionalRolesFilter = this.getFunctionalRolesFilter();
							filters.add("FunctionalRolesFilter", functionalRolesFilter);
						}
					}
					return filters;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#rowSelected
				 * @overridden
				 */
				rowSelected: function(primaryColumnValue) {
					this.filtrateAdditionButtons(primaryColumnValue);
					var gridData = this.getGridData();
					var currentGrid = this.getCurrentGrid();
					if (gridData.getCount() === 0 || this.Ext.isEmpty(currentGrid) || currentGrid.rendered === false) {
						return;
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritdoc GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					var config = this.callParent(arguments);
					config.SysAdminUnitTypeValue = {path: "SysAdminUnitTypeValue"};
					config.ConnectionType = {path: "ConnectionType"};
					return config;
				},

				/**
				 * ############# ######## ## ######### ### ##########, ############## ### ########### ##########
				 * ###### ##########.
				 * @private
				 */
				prepareAdditionButtons: function(isOrgRoleView) {
					this.set("IsAddOrgRoleShowed", isOrgRoleView);
					this.set("IsFuncRoleShowed", !isOrgRoleView);
					this.set("IsOrganisationShowed", false);
					this.set("IsDepartmentShowed", false);
					this.set("IsCommandShowed", false);
					this.set("IsFuncRoleEnabled", false);
				},

				/**
				 * ## id ###### ###### ## ### # ########## ###### ###### ###### ##########.
				 * @protected
				 */
				filtrateAdditionButtons: function(primaryColumnValue) {
					var isOrgRoleView = this.isOrganizationalRolesDataView();
					if (this.Ext.isEmpty(primaryColumnValue)) {
						return;
					}
					if (this.getGridData().contains(primaryColumnValue)) {
						this.prepareAdditionButtons(isOrgRoleView);
						if (!this.getIsFeatureEnabled("PortalUserManagementV2")
							&& (primaryColumnValue === ConfigurationConstants.SysAdminUnit.Id.PortalUsers
								|| primaryColumnValue === ConfigurationConstants.SysAdminUnit.Id.PRMPortalUsers)) {
							return;
						}
						var row = this.getGridData().get(primaryColumnValue);
						var type = !isOrgRoleView
							? ConfigurationConstants.SysAdminUnit.Type.FuncRole
							: row.get("SysAdminUnitTypeValue");
						switch (type) {
							case ConfigurationConstants.SysAdminUnit.Type.Organisation:
								this.set("IsOrganisationShowed", true);
								this.set("IsDepartmentShowed", true);
								this.set("IsCommandShowed", true);
								break;
							case ConfigurationConstants.SysAdminUnit.Type.Department:
								this.set("IsDepartmentShowed", true);
								this.set("IsCommandShowed", true);
								break;
							case ConfigurationConstants.SysAdminUnit.Type.FuncRole:
								this.set("IsFuncRoleEnabled", true);
								break;
						}
					}
				},

				/**
				 * ########## ####### ####### ## ###### "######## ###########".
				 * @protected
				 */
				onAddOrganisation: function() {
					this.createRecord(ConfigurationConstants.SysAdminUnit.TypeGuid.Organisation,
						this.getSysAdminUnitPageName());
				},

				/**
				 * ########## ####### ####### ## ###### "######## #############".
				 * @protected
				 */
				onAddDepartment: function() {
					this.createRecord(ConfigurationConstants.SysAdminUnit.TypeGuid.Department,
						this.getSysAdminUnitPageName());
				},

				/**
				 * ########## ####### ####### ## ###### "######## #######".
				 * @protected
				 */
				onAddCommand: function() {
					this.createRecord(ConfigurationConstants.SysAdminUnit.TypeGuid.Team,
						this.getSysAdminUnitPageName());
				},

				/**
				 * ########## ####### ####### ## ###### "######## ############## ####".
				 * @protected
				 */
				onAddFuncRole: function() {
					this.createRecord(ConfigurationConstants.SysAdminUnit.TypeGuid.FuncRole,
						this.getFuncRolesPageName());
				},

				/**
				 * ######### ###### ######## ############## ### ######## ##### ####.
				 * @param {String} type id ## ####### SysAdminUnitType, ######### ### ### ########### ######.
				 * @param {String} schemaName ### ######## ############## ### ############ #######.
				 */
				createRecord: function(type, schemaName) {
					this.set("targetType", type);
					this.openCardInChain({
						schemaName: schemaName,
						operation: ConfigurationEnums.CardStateV2.ADD,
						moduleId: this.getChainCardModuleSandboxId(this.BPMSoft.GUID_EMPTY)
					});
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#onCardRendered
				 * @overridden
				 */
				onCardRendered: function() {
					this.set("ShowGridMask", false);
					var activeRow = this.getActiveRow();
					if (!activeRow) {
						var gridData = this.getGridData();
						var historyStateInfo = this.getHistoryStateInfo();
						var primaryColumnValue = historyStateInfo.primaryColumnValue;
						if (gridData.contains(primaryColumnValue)) {
							this.setActiveRow(primaryColumnValue);
						} else {
							this.expandItemWithParents(primaryColumnValue, function() {
								this.setActiveRow(primaryColumnValue);
							});
						}
					}
					this.ensureActiveRowVisible();
					var cardScrollTop = this.get("CardScrollTop");
					if (cardScrollTop !== null) {
						this.Ext.getBody().dom.scrollTop = cardScrollTop;
						this.Ext.getDoc().dom.documentElement.scrollTop = cardScrollTop;
					}
					var deleteButtonEnable = this.checkOpportunityForDelete();
					this.set("DeleteButtonEnable", deleteButtonEnable);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getIsSectionVisible
				 * @overridden
				 */
				getIsSectionVisible: function() {
					return true;
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#saveSectionVisibleStateToProfile
				 * @overridden
				 */
				saveSectionVisibleStateToProfile: BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#getPrimaryColumnValue
				 * @overridden
				 */
				getPrimaryColumnValue: function() {
					return this.getActiveRow();
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#setActiveRow
				 * @overridden
				 */
				setActiveRow: function(value) {
					if (this.isOrganizationalRolesDataView()) {
						this.set("OrganizationalRolesActiveRow", value);
					} else {
						this.set("ActiveRow", value);
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#unSelectRecords
				 * @overridden
				 */
				unSelectRecords: function() {
					if (this.isOrganizationalRolesDataView()) {
						this.set("OrganizationalRolesSelectedRows", []);
					} else {
						this.set("SelectedRows", []);
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#deselectRows
				 * @overridden
				 */
				deselectRows: function() {
					if (this.isOrganizationalRolesDataView()) {
						this.set("OrganizationalRolesActiveRow", null);
						this.set("OrganizationalRolesSelectedRows", []);
					} else {
						this.set("ActiveRow", null);
						this.set("SelectedRows", []);
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getSelectedItems
				 * @overridden
				 */
				getSelectedItems: function() {
					var isMultiSelect = this.get("MultiSelect");
					var result = null;
					if (isMultiSelect) {
						result = this.getSelectedRows();
					} else {
						var activeRow = this.getActiveRowId();
						if (activeRow) {
							result = [activeRow];
						}
					}
					return result;
				},

				/**
				 * ########## id ########## ########
				 * @protected
				 * @return {String} ########## id ########## ########
				 */
				getActiveRowId: function() {
					return this.isOrganizationalRolesDataView()
						? this.get("OrganizationalRolesActiveRow")
						: this.get("ActiveRow");
				},

				/**
				 * ########## ######### ######### #########
				 * @protected
				 * @return {Array} ########## ###### ######### #########
				 */
				getSelectedRows: function() {
					return this.isOrganizationalRolesDataView()
						? this.get("OrganizationalRolesSelectedRows")
						: this.get("SelectedRows");
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#afterLoadGridDataUserFunction
				 * @overridden
				 */
				afterLoadGridDataUserFunction: function(primaryColumnValue) {
					this.rowSelected(primaryColumnValue);
					this.setActiveRow(primaryColumnValue);
					this.expandParentGridItem(primaryColumnValue);
				},

				/**
				 * ######### ######### ############# ######## ############# ####### ### ######## ########.
				 * @param {String} primaryColumnValue ############# ###### # ############# #######, ############
				 * ####### ####### ##### ###########.
				 * @protected
				 */
				expandParentGridItem: function(primaryColumnValue) {
					var grid = this.getCurrentGrid();
					if (this.Ext.isEmpty(grid)) {
						return;
					}
					var gridData = this.getGridData();
					var row = gridData.collection.getByKey(primaryColumnValue);
					var parentId = row.get("ParentRoleId");
					var toggle = this.Ext.get(grid.id + grid.hierarchicalTogglePrefix + parentId);
					if (toggle && toggle.hasCls(grid.hierarchicalPlusCss)) {
						grid.toggleHierarchyFolding(parentId);
					}
				},

				/**
				 * ######### ###### # ###### ######## #############.
				 * @inheritDoc BPMSoft.BaseSectionV2#loadActiveViewData
				 * @overridden
				 */
				loadActiveViewData: function() {
					this.loadGridData();
				},

				/**
				 * ########## ####### ######## ###### #######.
				 * @return {Boolean} ####### ######## ###### #######.
				 */
				getNeedLoadData: function() {
					var needLoadData = true;
					if (this.isOrganizationalRolesDataView()) {
						needLoadData = !this.get("OrganizationalRolesDataLoaded");
					} else {
						needLoadData = !this.get("FuncRolesDataLoaded");
					}
					return needLoadData;
				},

				/**
				 * @inheritDoc BaseSectionV2#loadView
				 * @overridden
				 */
				loadView: function(dataViewName) {
					this.set("ActiveViewName", dataViewName);
					this.saveActiveViewNameToProfile(dataViewName);
					if (this.Ext.get("SysAdminUnitSectionV2Container")) {
						this.openCard(this.getEditPageName(), ConfigurationEnums.CardStateV2.EDIT,
							this.getLastGroupId());
					}
					this.getActiveViewGridSettingsProfile(function() {
						this["load" + dataViewName](this.getNeedLoadData());
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#loadGridDataView
				 * @overridden
				 */
				loadGridDataView: function() {
					this.set("IsClearGridData", true);
					this.callParent(arguments);
				},

				/**
				 * ######### ############# ############### ####.
				 * @protected
				 * @param {Boolean} loadData #### ######## ######.
				 */
				loadOrganizationalRolesDataView: function(loadData) {
					this.set("IsClearGridData", true);
					if (loadData) {
						this.loadGridData();
					}
				},

				/**
				 * ######## ######### #######.
				 * @inheritDoc BPMSoft.BaseSectionV2#getGridData
				 * @overridden
				 */
				getGridData: function() {
					if (!this.isOrganizationalRolesDataView()) {
						return this.get("GridData");
					} else {
						return this.get("OrganizationalRolesGridData");
					}
				},

				/**
				 * ######## ### #######
				 * @inheritDoc BPMSoft.BaseSectionV2#getDataGridName
				 * @overridden
				 */
				getDataGridName: function(gridType) {
					var dataGridName = this.callParent(arguments);
					if (this.isOrganizationalRolesDataView()) {
						dataGridName = "OrganizationalRolesGridData";
					}
					if (gridType) {
						if (gridType === "vertical") {
							dataGridName += "VerticalProfile";
						}
					} else {
						var isCardVisible = this.get("IsCardVisible");
						if (isCardVisible === true) {
							dataGridName += "VerticalProfile";
						}
					}
					return dataGridName;
				},

				/**
				 * ########## ###### #######, # ############ # ####### ##############.
				 * @inheritDoc BPMSoft.BaseSectionV2#getCurrentGrid
				 * @overridden
				 */
				getCurrentGrid: function() {
					return this.isOrganizationalRolesDataView()
						? this.Ext.getCmp("OrganizationalRolesGridId")
						: this.Ext.getCmp(this.name + "DataGridGrid");
				},

				/**
				 * ###### ######## ######### #############. ########## ### ########.
				 * ############## ############## ######## ######## #######
				 * @inheritDoc BPMSoft.BaseSectionV2#setActiveView
				 * @overridden
				 */
				setActiveView: function(activeViewName, loadData) {
					this.initSortActionItems();
					this.showBodyMask();
					if (!this.get("IsCardVisible")) {
						this.hideCard();
					}
					var dataViews = this.get("DataViews");
					dataViews.each(function(dataView) {
						var isViewActive = (dataView.name === activeViewName);
						this.setViewVisible(dataView, isViewActive);
					}, this);
					this.loadView(activeViewName, loadData);
					this.filtrateAdditionButtons(this.getActiveRowId());
				},

				/**
				 * ############## ######### ###### ############# ########.
				 * @protected
				 */
				initOrganizationalRolesGridData: function() {
					this.set("OrganizationalRolesGridData", this.Ext.create("BPMSoft.BaseViewModelCollection"));
					var gridData = this.get("OrganizationalRolesGridData");
					gridData.on("dataLoaded", this.onGridLoaded, this);

				},

				/**
				 * ######### ######## ## #########.
				 * @private
				 */
				subscribeEvents: function() {
					this.sandbox.subscribe("SetRecordInformation", function() {
						var activeRow = this.getActiveRow();
						return {
							parent: this.getActiveRowId(),
							type: this.get("targetType"),
							connectionType: activeRow.get("ConnectionType")
						};
					}, this, [
						this.getChainCardModuleSandboxId(this.BPMSoft.GUID_EMPTY),
						this.getCardModuleSandboxId()
					]);

					this.sandbox.subscribe("RemoveRecordAndGoToParent", function(data) {
						this.set("deletedItems", data.deletedItems);
						this.set("parentRow", data.parent);
						this.set("IsConfirmedDelete", data.IsConfirmedDelete);
						this.deleteRecords();
					}, this, [
						this.getChainCardModuleSandboxId(this.BPMSoft.GUID_EMPTY),
						this.getCardModuleSandboxId()
					]);

					this.sandbox.subscribe("UpdateSectionGrid", function() {
						this.reloadGridData();
					}, this);
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#checkCanDeleteCallback
				 * @overridden
				 */
				checkCanDeleteCallback: function(result) {
					if (result) {
						this.showInformationDialog(resources.localizableStrings[result]);
						return;
					}
					if (this.get("IsConfirmedDelete") === true) {
						this.onDelete(this.BPMSoft.MessageBoxButtons.YES.returnCode);
						return;
					}
					this.showConfirmationDialog(this.get("Resources.Strings.DeleteConfirmationMessage"),
						function(returnCode) {
							this.onDelete(returnCode);
						},
						[
							this.BPMSoft.MessageBoxButtons.YES.returnCode,
							this.BPMSoft.MessageBoxButtons.NO.returnCode
						],
						null);
				},

				destroy: function() {
					BPMSoft.utils.dom.setAttributeToBody("sysadmin-section", false);
				},
				/**
				 * @inheritDoc BPMSoft.BaseSectionV2#init
				 * @overridden
				 */
				init: function() {
					BPMSoft.utils.dom.setAttributeToBody("sysadmin-section", true);
					this.subscribeEvents();
					this.initOrganizationalRolesGridData();
					this.callParent(arguments);
					this.initCustomActionsButtonMenuItems();
					this.setActiveRowsForViewFromHistoryState();
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getIsLinkColumn
				 * @overridden
				 */
				getIsLinkColumn: function() {
					return false;
				},

				/**
				 * ######## ## ####### ######## ###### # ######## ############# # ########### ## ### ######## #######.
				 * @protected
				 */
				setActiveRowsForViewFromHistoryState: function() {
					var state = this.sandbox.publish("GetHistoryState").state;
					this.set("UsersActiveRow", state.UsersActiveRow);
					this.set("FuncRolesActiveRow", state.FuncRolesActiveRow);
					this.set("OrgRolesActiveRow", state.OrgRolesActiveRow);
				},

				/**
				 * ############# ############# ########### #######.
				 * @protected
				 */
				initContextHelp: function() {
					this.set("ContextHelpId", 259);
					this.callParent(arguments);
				},

				/**
				 * ########## ######### ######## #######.
				 * @protected
				 * @return {BPMSoft.BaseViewModelCollection} ########## ######### ######## ####### # ######.
				 * ########### #######
				 */
				getCustomSectionActions: function() {
					var actionMenuItems = this.Ext.create("BPMSoft.BaseViewModelCollection");
					actionMenuItems.addItem(this.getActualizeAdminUnitInRoleButton());
					return actionMenuItems;
				},

				/**
				 * ############## ######### ######## #######.
				 * @protected
				 */
				initCustomActionsButtonMenuItems: function() {
					this.set("CustomActionsButtonMenuItems", this.getCustomSectionActions());
				},

				/**
				 * @inheritdoc BPMSoft.BaseSchemaViewModel#getSectionCode
				 * @override
				 */
				getSectionCode: function() {
					return "SystemUsers";
				}
			}
		};
	});
