﻿define("SysRoleInMobWorkplaceDetail", ["SysRoleInMobWorkplaceDetailResources", "MobileDesignerUtils",
	"ConfigurationConstants"],
	function(resources, MobileDesignerUtils, ConfigurationConstants) {
		return {
			entitySchemaName: "SysRoleInMobWorkplace",
			methods: {

				/**
				 * @private
				 */
				sysRoleIdPath: "SysRole.Id",

				/**
				 * @private
				 */
				sysRoleNamePath: "SysRole.Name",

				/**
				 * @private
				 */
				openSysAdminLookup: function() {
					var workplaceId = this.get("MasterRecordId");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysRoleInMobWorkplace"
					});
					esq.addColumn("SysRole.Id", "SysRoleId");
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "SysMobileWorkplace", workplaceId));
					esq.getEntityCollection(function(result) {
						var existingRoles = [];
						if (result.success) {
							result.collection.each(function(item) {
								existingRoles.push(item.get("SysRoleId"));
							}, this);
						}
						var config = {
							entitySchemaName: "SysAdminUnit",
							multiSelect: true
						};
						var filterGroup = this.BPMSoft.createFilterGroup();
						if (existingRoles.length > 0) {
							var existsFilter = this.BPMSoft.createColumnInFilterWithParameters("Id", existingRoles);
							existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
							filterGroup.addItem(existsFilter);
						}
						config.filters = filterGroup;
						this.openLookup(config, this.addCallback, this);
					}, this);
				},

				/**
				 * @private
				 */
				addCallback: function(args) {
					var batchQuery = Ext.create("BPMSoft.BatchQuery");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						batchQuery.add(this.getInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (batchQuery.queries.length) {
						batchQuery.execute(this.onItemInsert, this);
					}
				},

				/**
				 * @private
				 **/
				getInsertQuery: function(item) {
					var insert = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "SysRoleInMobWorkplace"
					});
					insert.setParameterValue("SysRole", item.value, BPMSoft.DataValueType.GUID);
					insert.setParameterValue("SysMobileWorkplace", this.get("MasterRecordId"), BPMSoft.DataValueType.GUID);
					return insert;
				},

				/**
				 * @private
				 **/
				onItemInsert: function(response) {
					if (response && response.success) {
						var queryResult = response.queryResults;
						var rowIds = [];
						this.BPMSoft.each(queryResult, function(item) {
							if (item.id) {
								rowIds.push(item.id);
							}
						});
						var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
							rootSchema: this.entitySchema
						});
						this.initQueryColumns(esq);
						var filter = this.BPMSoft.createColumnInFilterWithParameters("Id", rowIds);
						filter.comparisonType = this.BPMSoft.ComparisonType.EQUAL;
						esq.filters.add("id", filter);
						esq.getEntityCollection(function(response) {
							this.onGridDataLoaded(response);
						}, this);
					}
				},

				/**
				 * ########## ######### ###### ########## ######
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @protected
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return this.getToolsVisible();
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#onCardSaved
				 * @protected
				 * @overridden
				 */
				onCardSaved: function() {
					this.openSysAdminLookup();
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addRecord
				 * @protected
				 * @overridden
				 **/
				addRecord: function() {
					this.sandbox.publish("SaveRecord", {
						isSilent: true,
						messageTags: [this.sandbox.id]
					}, [this.sandbox.id]);
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @protected
				 * @overridden
				 */
				getSwitchGridModeMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @protected
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @protected
				 * @overridden
				 */
				getCopyRecordMenuItem: BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @protected
				 * @overridden
				 */
				addDetailWizardMenuItems: BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.configuration.mixins.GridUtilities#getGridDataColumns
				 * @protected
				 * @overridden
				 */
				getGridDataColumns: function() {
					var defColumnsConfig = this.callParent(arguments);
					var columnPath = this.sysRoleIdPath;
					defColumnsConfig[columnPath] = {path: columnPath};
					columnPath = this.sysRoleNamePath;
					defColumnsConfig[columnPath] = {path: columnPath};
					return defColumnsConfig;
				},

				/**
				 * @inheritDoc BPMSoft.configuration.mixins.GridUtilities#checkCanDelete
				 * @protected
				 * @overridden
				 */
				checkCanDelete: function(items, callback, scope) {
					var gridData = this.getGridData();
					var isExistsAllEmployeesRight = false;
					for (var i = 0, ln = items.length; i < ln; i++) {
						var item = gridData.get(items[i]);
						if (item.get(this.sysRoleIdPath) === ConfigurationConstants.SysAdminUnit.Id.AllEmployees) {
							isExistsAllEmployeesRight = true;
							break;
						}
					}
					if (!isExistsAllEmployeesRight) {
						this.Ext.callback(callback, scope);
						return;
					}
					var detailInfo = this.getDetailInfo();
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysMobileWorkplace"
					});
					esq.addColumn("Code");
					var filter = this.BPMSoft.createColumnFilterWithParameter(
						this.BPMSoft.ComparisonType.EQUAL, "Id", detailInfo.masterRecordId);
					esq.filters.add("id", filter);
					esq.getEntityCollection(function(response) {
						if (response && response.success) {
							var collection = response.collection;
							if (collection.getCount() === 1) {
								var result = collection.getItems()[0];
								if (MobileDesignerUtils.defaultWorkplaceCode === result.get("Code")) {
									this.showInformationDialog(resources.localizableStrings.DeleteDefaultWorkplaceRightMessage);
									return;
								}
								this.Ext.callback(callback, scope);
							}
						}
					}, this);
				}

			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "Detail",
					"values": {
						"wrapClass": ["hide-grid-caption-wrapClass"]
					}
				},
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "tiled",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "SysRoleName",
									"bindTo": "SysRole.Name",
									"position": {
										"column": 1,
										"colSpan": 24,
										"row": 1
									},
									"type": BPMSoft.GridCellType.TEXT,
									"captionConfig": {
										"visible": false
									}
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": {
								"columns": 24,
								"rows": 1
							},
							"items": [
								{
									"name": "SysRoleName",
									"bindTo": "SysRole.Name",
									"position": {
										"row": 1,
										"column": 0,
										"colSpan": 20
									},
									"type": BPMSoft.GridCellType.TEXT,
									"captionConfig": {
										"visible": false
									}
								}
							]
						}
					}
				}
			]/**SCHEMA_DIFF*/
		};
	}
);
