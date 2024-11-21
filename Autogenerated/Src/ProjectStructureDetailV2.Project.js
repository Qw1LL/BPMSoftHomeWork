define("ProjectStructureDetailV2", ["XRMConstants", "BPMSoft", "ProjectUtilities", "css!ProjectCSSModule"],
	function(XRMConstants, BPMSoft) {
		return {
			entitySchemaName: "Project",
			messages: {
				/**
				 * @message CardModuleEntityInfo
				 * ###### ############ ### ###### ######### ###### #####
				 * @return {Object} ############ ###### ######### ###### #####
				 */
				"CardModuleEntityInfo": {
					"mode": BPMSoft.MessageMode.PTP,
					"direction": BPMSoft.MessageDirectionType.SUBSCRIBE
				}
			},
			attributes: {
				/**
				 * ######## ## ########### ###### ########
				 */
				"expandedElements": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},
				/**
				 * ######## ## ###### ########### #########,
				 * ###### ###### ########## ############## #######
				 */
				"expandHierarchyLevels": {
					dataValueType: BPMSoft.DataValueType.CUSTOM_OBJECT,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				},

				/**
				 * ######## ## ######## ################ ######## ########
				 */
				"ExpandItemId": {
					dataValueType: BPMSoft.DataValueType.GUID,
					type: BPMSoft.ViewModelColumnType.VIRTUAL_COLUMN
				}
			},
			mixins: {
				/**
				 * ######## ######## ######## ###### ## #######
				 */
				ProjectUtilities: "BPMSoft.ProjectUtilities"
			},
			methods: {
				/**
				 * @overridden
				 */
				disableGridSorting: Ext.emptyFn,

				/**
				 * @overridden
				 */
				sortColumn: Ext.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#init
				 * @overridden
				 */
				init: function() {
					this.mixins.ProjectUtilities.init.call(this);
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#copyRecord
				 * @overridden
				 */
				copyRecord: function() {
					const selectedItems = this.getSelectedItems() || [];
					const selectedItemId = selectedItems[0] || "";
					const selectedItem = this.getGridData().get(selectedItemId);
					if (selectedItem && this.isNotEmpty(selectedItem.get("ParentId"))) {
						this.set("ExpandItemId", selectedItemId);
					}
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.BaseDetailV2#initData
				 * @overridden
				 */
				initData: function() {
					this.callParent(arguments);
					this.set("expandedElements", {});
					this.set("expandHierarchyLevels", []);
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#onDeleted
				 * @overridden
				 */
				onDeleted: function(result) {
					this.callParent(arguments);
					if (result.Success) {
						this.reloadGridData();
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#subscribeSandboxEvents
				 * @overridden
				 */
				subscribeSandboxEvents: function() {
					this.callParent(arguments);
					var changeProjectDatesModuleId = this.getChangeProjectDatesModuleId();
					this.sandbox.subscribe("CardModuleEntityInfo", function() {
						return {
							records: this.getSelectedItems(),
							callerSandboxId: this.sandbox.id
						};
					}, this, [changeProjectDatesModuleId]);
				},

				/**
				 * ###### ########## # ########### # ########### #######
				 * @protected
				 * @virtual
				 */
				clearExpandHierarchyLevels: function() {
					this.set("expandedElements", {});
					this.set("expandHierarchyLevels", []);
					//TODO: ###### ##### ########### ######. ###### ### ########### ######## expandHierarchyLevels
					const grid = this.Ext.getCmp("StructureGrid");
					if (grid) {
						grid.resetExpandHierarchyLevel();
					}
				},

				/**
				 * ####### ########## # ###, ### ####### ######### ## ######### ##########
				 * @protected
				 * @virtual
				 * @param {String} itemId ########## ############# ######
				 */
				removeExpandHierarchyLevel: function(itemId) {
					var expandHierarchyLevels = this.get("expandHierarchyLevels");
					this.set("expandHierarchyLevels", BPMSoft.without(expandHierarchyLevels, itemId));
					//TODO: ###### ##### ########### ######. ###### ### ########### ######## expandHierarchyLevels
					var grid = this.Ext.getCmp("StructureGrid");
					if (grid) {
						grid.expandHierarchyLevels = BPMSoft.without(grid.expandHierarchyLevels, itemId);
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#addGridDataColumns
				 * @overridden
				 */
				addGridDataColumns: function(esq) {
					this.callParent(arguments);
					this.putParentColumn(esq);
					this.putNestingColumn(esq);
					this.putPositionColumn(esq);
				},

				/**
				 * ######### ####### ############# #######, #### #### ############# ######
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq ######,
				 * # ####### ##### ######### ####### ############# #######
				 */
				putParentColumn: function(esq) {
					var parentItem = this.get("ExpandItemId");
					if (parentItem && !esq.columns.contains("ParentId")) {
						esq.addColumn("ParentProject.Id", "ParentId");
					}
				},

				/**
				 * ######### ####### ####### ########
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq ######,
				 * # ####### ##### ######### ####### ####### ########
				 */
				putPositionColumn: function(esq) {
					if (!esq.columns.contains("Position")) {
						esq.addColumn("Position");
					}
				},

				/**
				 * ######### ############ ####### ########## ######## ######### ### ######
				 * @protected
				 * @virtual
				 * @param {BPMSoft.EntitySchemaQuery} esq ######,
				 * # ####### ##### ######### ############ #######
				 */
				putNestingColumn: function(esq) {
					var aggregationColumn = this.Ext.create("BPMSoft.AggregationQueryColumn", {
						aggregationType: BPMSoft.AggregationType.COUNT,
						columnPath: "[Project:ParentProject].Id"
					});
					if (!esq.columns.contains("HasNesting")) {
						esq.addColumn(aggregationColumn, "HasNesting");
					}
				},

				/**
				 * ####### ###### ############### ############ ####### ### ########### #######
				 * @protected
				 * @virtual
				 * @param {String[]} primaryValues ########## ############## ########### #######
				 * @return {String[]} ########## ########## ############## ############ #######
				 */
				getParents: function(primaryValues) {
					var parentPrimaryValues = [];
					var gridData = this.getGridData();
					if (Ext.isEmpty(primaryValues)) {
						return parentPrimaryValues;
					}
					primaryValues.forEach(function(primaryColumnValue) {
						var project = gridData.get(primaryColumnValue);
						var parentPrimaryColumnValue = project.get("ParentId");
						if (parentPrimaryColumnValue) {
							parentPrimaryValues.push(parentPrimaryColumnValue);
						}
					});
					return parentPrimaryValues;
				},

				/**
				 * ######### ########## # ####### ######## ######### ### ######## #######
				 * @protected
				 * @virtual
				 * @param {String[]} primaryColumnValues ########## ############# ######### #######
				 */
				removeGridRecords: function(primaryColumnValues) {
					var updateNestingCollection = this.getParents(primaryColumnValues);
					this.callParent(arguments);
					var gridData = this.getGridData();
					BPMSoft.each(updateNestingCollection, function(projectId) {
						var count = gridData.filterByFn(function(item) {
							return item.get("ParentId") === projectId;
						}, this).getCount();
						if (gridData.contains(projectId)) {
							this.removeExpandHierarchyLevel(projectId);
							var parent = gridData.get(projectId);
							parent.set("HasNesting", count);
						}
					}, this);
				},

				/**
				 * ########## ###### ## ####### ########### #######
				 * @protected
				 * @virtual
				 * @return {Object} ########## ###### ## ####### ########### #######
				 */
				getExpandedItems: function() {
					return this.get("expandedElements");
				},

				/**
				 * ###### ########## # ##### ########### ######
				 * @protected
				 * @virtual
				 * @param {Guid} primaryColumnValue ########## ############ ######
				 */
				setExpandedItem: function(primaryColumnValue) {
					(this.getExpandedItems()[primaryColumnValue]) = {"page": 0};
				},

				/**
				 * Checks is child elements loaded.
				 * @protected
				 * @virtual
				 * @param {Guid} primaryColumnValue Unique record identifier.
				 * @return {boolean} Is child elements loaded.
				 */
				isItemExpanded: function(primaryColumnValue) {
					return Boolean(this.getExpandedItems()[primaryColumnValue]);
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#addItemsToGridData
				 * @overridden
				 */
				addItemsToGridData: function(dataCollection, options) {
					if (dataCollection.isEmpty()) {
						return;
					}
					var firstItem = dataCollection.getByIndex(0);
					var parentId = firstItem.get("ParentId");
					if (parentId) {
						options = {
							mode: "child",
							target: parentId
						};
						var gridData = this.getGridData();
						var parentObj = gridData.get(parentId);
						if (parentObj) {
							parentObj.set("HasNesting", 1);
						}
						if (!this.isItemExpanded(parentId)) {
							return;
						}
					} else {
						this.set("LastRecord", dataCollection.getByIndex(dataCollection.getCount() - 1));
					}
					this.callParent([dataCollection, options]);
					if (options && (options.mode === "child" || options.mode === "top")) {
						var gridDataChild = this.getGridData();
						var tempCollection = this.Ext.create("BPMSoft.Collection");
						tempCollection.loadAll(gridDataChild);
						this.sortCollection(tempCollection);
						gridDataChild.clear();
						gridDataChild.loadAll(tempCollection);
					}
					this.set("ExpandItemId", null);
				},

				/**
				 * ########## ######## ######## #########. ############ ######## ############
				 * ######## ######## ######### ######. ######### ######## ###### ######.
				 * @protected
				 * @virtual
				 * @param {String} primaryColumnValue ########## ############# ######
				 * @param {Boolean} isExpanded ####### ####, ############# ### ########### ############ ######## #######
				 * true - #### #############, false # ######## ######
				 */
				onExpandHierarchyLevels: function(primaryColumnValue, isExpanded) {
					if (!isExpanded || this.isItemExpanded(primaryColumnValue)) {
						return;
					}
					this.setExpandedItem(primaryColumnValue);
					this.set("ExpandItemId", primaryColumnValue);
					this.loadGridData();
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilities#initQueryOptions
				 * @overridden
				 */
				initQueryOptions: function() {
					const isClearGridData = this.get("IsClearGridData");
					if (isClearGridData) {
						this.clearExpandHierarchyLevels();
					}
					const parentItem = this.get("ExpandItemId");
					if (!parentItem) {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilities#initCanLoadMoreData
				 * @overridden
				 */
				initCanLoadMoreData: function() {
					var parentItem = this.get("ExpandItemId");
					if (!parentItem) {
						this.callParent(arguments);
					}
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilities#changeSorting
				 * @overridden
				 */
				changeSorting: function() {
					this.clearExpandHierarchyLevels();
					this.callParent(arguments);
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilities#initQuerySorting
				 * @overridden
				 */
				initQuerySorting: function(esq) {
					const sortedColumn = esq.columns.find("Position");
					if (!sortedColumn) {
						return;
					}
					sortedColumn.orderPosition = 0;
					sortedColumn.orderDirection = BPMSoft.OrderDirection.ASC;
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilities#getFilters
				 * @overridden
				 */
				getFilters: function() {
					var parentItem = this.get("ExpandItemId");
					if (parentItem) {
						var parentProjectFilterGroup = this.BPMSoft.createFilterGroup();
						parentProjectFilterGroup.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL,
							"ParentProject",
							parentItem,
							BPMSoft.DataValueType.GUID
						));
						return parentProjectFilterGroup;
					} else {
						var filters = this.callParent(arguments);
						if (this.get("DetailColumnName") !== "ParentProject") {
							var group = this.BPMSoft.createFilterGroup();
							group.addItem(filters);
							group.addItem(
								BPMSoft.createColumnIsNullFilter(this.entitySchema.hierarchicalColumnName)
							);
							filters = group;
						}
						return filters;
					}
				},

				/**
				 * ######### ### ######### # ####### ###### ###### ### ######
				 * @protected
				 * @virtual
				 * @return {boolean} ########## true #### # ####### ###### ######### ######
				 * false # ######## ######
				 */
				isProjectsInRoot: function() {
					return (this.get("DetailColumnName") !== "ParentProject");
				},

				/**
				 * ######### ### ######### # ####### ###### ###### ### ######
				 * @protected
				 * @virtual
				 * @return {boolean} ########## true #### # ####### ###### ######### ######
				 * false # ######## ######
				 */
				isWorkInRoot: function() {
					return !this.isProjectsInRoot();
				},

				/**
				 * ######### ######## ############## #######
				 * @overridden
				 * @private
				 */
				initEditPages: function() {
					this.callParent(arguments);
					var editPages = this.get("EditPages");
					var workPage = editPages.get(XRMConstants.Project.EntryType.Work);
					workPage.set("Click", {"bindTo": "addToRootRecord"});
					workPage.set("Caption", {"bindTo": "Resources.Strings.AddRootItemCaption"});
					workPage.set("Visible", {"bindTo": "isWorkInRoot"});
					var projectPage = editPages.get(XRMConstants.Project.EntryType.Project);
					projectPage.set("Visible", {"bindTo": "isProjectsInRoot"});
					projectPage.set("Click", {"bindTo": "addToRootRecord"});
					var childItemId = this.BPMSoft.GUID_EMPTY;
					var config = {
						"Id": childItemId,
						"Caption": {"bindTo": "Resources.Strings.AddChildItemCaption"},
						"Click": {"bindTo": "addToChildRecord"},
						"Enabled": {"bindTo": "isSingleSelected"},
						"Tag": childItemId,
						"SchemaName": "WorkPageV2"
					};
					var addToChildMenuItem = this.getButtonMenuItem(config);
					editPages.add(childItemId, addToChildMenuItem);
				},

				/**
				 * ############# ######## ## ######### ### ######### ######## ############# ##### ######
				 * @protected
				 * @virtual
				 * @param {String} key ### #########
				 * @param {*} value ######## #########
				 */
				replaceDefaultValue: function(key, value) {
					var defaultValues = this.get("DefaultValues");
					var oldValue = defaultValues.filter(function(item) {
						return item.name === key;
					});
					if (Ext.isEmpty(oldValue)) {
						defaultValues.push({
							name: key,
							value: value
						});
					} else {
						BPMSoft.each(oldValue, function(item) {
							item.value = value;
						});
					}
				},

				/**
				 * @inheritDoc BPMSoft.BaseDetailV2#getDetailInfo
				 * @overridden
				 */
				getDetailInfo: function() {
					var detailInfo = this.sandbox.publish("GetDetailInfo", null, [this.sandbox.id]) || {};
					var defaultValues = this.get("DefaultValues");
					detailInfo.defaultValues = defaultValues;
					return detailInfo;
				},

				/**
				 * ######### ######## ####### ### ###### ### ########## ######## # ####### ####### ########
				 * @protected
				 * @virtual
				 * @param {String} typeUId ########## ############# #### ###### #######
				 */
				addToRootRecord: function(typeUId) {
					var masterRecordId = (typeUId === XRMConstants.Project.EntryType.Project)
						? this.BPMSoft.GUID_EMPTY
						: this.get("MasterRecordId");
					this.replaceDefaultValue("ParentProject", masterRecordId);
					this.addRecord(typeUId);
				},

				/**
				 * ######### ######## ###### ### ########## ######## ######### ######## ######### ######
				 * @protected
				 * @virtual
				 */
				addToChildRecord: function() {
					var scope = this;
					var selectedItems = this.getSelectedItems();
					this.set("ExpandItemId", selectedItems[0]);
					this.replaceDefaultValue("ParentProject", selectedItems[0]);
					var masterRecordId = this.get("MasterRecordId");
					if (masterRecordId !== null) {
						var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchemaName: "Project"});
						esq.addColumn("Account");
						esq.addColumn("Contact");
						var filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
							"Id", masterRecordId, BPMSoft.DataValueType.GUID);
						esq.filters.add("filter", filter);
						esq.getEntityCollection(function(response) {
							if (!response || !response.success) {
								return;
							}
							var result = response.collection;
							result.each(function(resultItem) {
								var contact = resultItem.get("Contact");
								var account = resultItem.get("Account");
								if (contact != null && contact.value) {
									scope.replaceDefaultValue("Contact", contact.value);
								}
								if (account != null && account.value) {
									scope.replaceDefaultValue("Account", account.value);
								}
								scope.addRecord(XRMConstants.Project.EntryType.Work);
							});
						}, this);
					} else {
						this.addRecord(XRMConstants.Project.EntryType.Work);
					}
				},

				/**
				 * ######### ##### ## ######## ####### # ########## ########
				 * @protected
				 * @virtual
				 * @return {Boolean} ########## ##### ## ######## ####### # ########## ########
				 */
				canChangeSelectedItemPosition: function() {
					var selectedItems = this.getSelectedItems();
					return (!Ext.isEmpty(selectedItems) && (selectedItems.length <= 1));
				},

				/**
				 * ######### ####### ######### ######
				 * @protected
				 * @virtual
				 * @param {Number} offset ######## #######
				 */
				changePosition: function() {
					var shift = arguments[3];
					var activeRow = this.getActiveRow();
					var projectId = activeRow.get("Id");
					this.updateProjectPosition(projectId, shift, this.onPositionChanged, this);
				},

				/**
				 * ########## ########## ######### ####### #####
				 * ######### ###### ###### ######## ##### ########
				 * @protected
				 * @virtual
				 * @param {Object} result ######### ########## ##########
				 */
				onPositionChanged: function(result) {
					if (!result) {
						return;
					}
					var activeRow = this.getActiveRow();
					var parentId = activeRow.get("ParentId");
					if (!parentId) {
						parentId = this.get("MasterRecordId");
					}
					var esq = Ext.create("BPMSoft.EntitySchemaQuery", {rootSchema: this.entitySchema});
					esq.addColumn("Position");
					var filter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"ParentProject", parentId, BPMSoft.DataValueType.GUID);
					esq.filters.add("filter", filter);
					esq.getEntityCollection(function(response) {
						if (!response || !response.success) {
							return;
						}
						var gridData = this.getGridData();
						var result = response.collection;
						result.each(function(resultItem) {
							var resultItemId = resultItem.get("Id");
							var newPosition = resultItem.get("Position");
							var gridRecord = gridData.get(resultItemId);
							gridRecord.set("Position", newPosition);
						});
						var tempCollection = this.Ext.create("BPMSoft.Collection");
						tempCollection.loadAll(gridData);
						this.sortCollection(tempCollection);
						gridData.clear();
						gridData.loadAll(tempCollection);
						const activeRowId = activeRow.get("Id");
						this.setActiveRow(activeRowId);
						this.set("SelectedRows", [activeRowId]);
					}, this);
				},

				/**
				 * ######### ######### # ########### ## #### ####### # ###### ####### ########
				 * @protected
				 * @virtual
				 * @param {BPMSoft.Collection} collection ######### #########
				 */
				sortCollection: function(collection) {
					collection.sortByFn(function(a, b) {
						var positionA = a.get("Position");
						var positionB = b.get("Position");
						var q = positionA - positionB;
						return q === 0 ? 0 : (q) / Math.abs(q);
					});
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#prepareResponseCollection
				 * @overridden
				 */
				prepareResponseCollection: function(collection) {
					this.callParent(arguments);
					collection.each(function(item) {
						item.id = item.get(item.primaryColumnName);
					});
				},

				/**
				 * ########## ########## ############# ###### ######### ######
				 * @protected
				 * @virtual
				 * @return {String} ########## ########## ############# ###### ######### ######
				 */
				getChangeProjectDatesModuleId: function() {
					return this.sandbox.id + "_ChangeProjectDates";
				},

				/**
				 * ######### ###### ######### ######
				 * @protected
				 * @virtual
				 */
				changeProjectDates: function() {
					if (!this.isAnySelected()) {
						return;
					}
					var moduleId = this.getChangeProjectDatesModuleId();
					this.sandbox.loadModule("ChangeProjectDates", {
						id: moduleId,
						keepAlive: true
					});
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: function(toolsButtonMenu) {
					this.callParent(arguments);
					toolsButtonMenu.addItem(this.getButtonMenuSeparator());
					toolsButtonMenu.addItem(this.getButtonMenuItem({
						Caption: {"bindTo": "Resources.Strings.ChangeProjectDatesButtonCaption"},
						Click: {"bindTo": "changeProjectDates"},
						Enabled: {"bindTo": "isAnySelected"}
					}));
				},

				/**
				 * inheritDoc BPMSoft.GridUtilitiesV2#initPageableQueryOption
				 * @override
				 */
				initPageableQueryOption: function(esq) {
					this.callParent(arguments);
					esq.rowsOffset = this.get("IsClearGridData") ? 0 : this._getRootCount();
				},

				/**
				 * @private
				 */
				_getRootCount: function() {
					const gridData = this.getGridData();
					const rootData = gridData.filterByFn(function(item) {
						return !item.columns.hasOwnProperty("ParentId");
					}, this);
					return rootData.getCount();
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"id": "StructureGrid",
						"type": "listed",
						"hierarchical": true,
						"sortColumnDirection": {"bindTo": "disableGridSorting"},
						"hierarchicalColumnName": "ParentId",
						"updateExpandHierarchyLevels": {
							"bindTo": "onExpandHierarchyLevels"
						},
						"expandHierarchyLevels": {
							"bindTo": "expandHierarchyLevels"
						},
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "NameListedGridColumn",
									"bindTo": "Name",
									"position": {
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "StartDateListedGridColumn",
									"bindTo": "StartDate",
									"position": {
										"column": 13,
										"colSpan": 4
									}
								},
								{
									"name": "EndDateListedGridColumn",
									"bindTo": "EndDate",
									"position": {
										"column": 17,
										"colSpan": 4
									}
								},
								{
									"name": "ActualCompletionListedGridColumn",
									"bindTo": "ActualCompletion",
									"position": {
										"column": 21,
										"colSpan": 4
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 3
							},
							"items": [
								{
									"name": "NameTiledGridColumn",
									"bindTo": "Name",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "StartDateTiledGridColumn",
									"bindTo": "StartDate",
									"position": {
										"row": 1,
										"column": 13,
										"colSpan": 4
									}
								},
								{
									"name": "EndDateTiledGridColumn",
									"bindTo": "EndDate",
									"position": {
										"row": 1,
										"column": 17,
										"colSpan": 4
									}
								},
								{
									"name": "ActualCompletionTiledGridColumn",
									"bindTo": "ActualCompletion",
									"position": {
										"row": 1,
										"column": 21,
										"colSpan": 4
									}
								}
							]
						}
					}
				},
				{
					"operation": "insert",
					"name": "UpButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"index": 0,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"tag": -1,
						"imageConfig": {
							"bindTo": "Resources.Images.UpImage"
						},
						"click": {"bindTo": "changePosition"},
						"visible": {"bindTo": "getToolsVisible"},
						"enabled": {"bindTo": "canChangeSelectedItemPosition"},
						"hint": {"bindTo": "Resources.Strings.ChangePositionUpButtonCaption"}
					}
				},
				{
					"operation": "insert",
					"name": "DownButton",
					"parentName": "Detail",
					"propertyName": "tools",
					"index": 1,
					"values": {
						"itemType": BPMSoft.ViewItemType.BUTTON,
						"tag": 1,
						"imageConfig": {
							"bindTo": "Resources.Images.DownImage"
						},
						"click": {"bindTo": "changePosition"},
						"visible": {"bindTo": "getToolsVisible"},
						"enabled": {"bindTo": "canChangeSelectedItemPosition"},
						"hint": {"bindTo": "Resources.Strings.ChangePositionDownButtonCaption"}
					}
				},
				{
					"operation": "remove",
					"name": "ViewSortMenu",
					"parentName": "ViewButton",
					"propertyName": "menu"
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
