define("OptionalFuncSspRolesDetail", [],
	function() {
		return {
			entitySchemaName: "OptionalFuncSspRole",
			attributes: {
				"UseGeneratedProfile": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				},
				"IsDetailCollapsed": {
					dataValueType: BPMSoft.DataValueType.BOOLEAN,
					value: false
				}
			},
			methods: {

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getAddRecordButtonVisible
				 * @override
				 */
				getAddRecordButtonVisible: function() {
					return true;
				},

				/**
				 * @inheritDoc BaseGridDetailV2#addRecord
				 * @protected
				 * @override
				 */
				addRecord: function() {
					const lookupConfig = {
						entitySchemaName: "SysAdminUnit",
						hideActions: true
					};
					lookupConfig.multiSelect = true;
					const filterGroup = BPMSoft.createFilterGroup();
					filterGroup.add("isPortalRole", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "ConnectionType", 1));
					filterGroup.add("isFunctionalRole", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "SysAdminUnitTypeValue", 6));
					filterGroup.add("isActive", BPMSoft.createColumnFilterWithParameter(
						BPMSoft.ComparisonType.EQUAL, "Active", 1));
					const notExistsFilter = BPMSoft.createNotExistsFilter(
						"[OptionalFuncSspRole:FuncRole:Id].Id");
					const subFilter = BPMSoft.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL,
						"OrgRole", this.get("MasterRecordId"));
					notExistsFilter.subFilters.addItem(subFilter);
					filterGroup.add("notAlreadyAdded", notExistsFilter);
					lookupConfig.filters = filterGroup;
					this.openLookup(lookupConfig, this._addFuncRole, this);
				},

				/**
				 * @inheritDoc BPMSoft.GridUtilitiesV2#getGridDataColumns
				 * @override
				 */
				getGridDataColumns: function() {
					const gridDataColumns = this.callParent(arguments);
					gridDataColumns.FuncRole = {
						path: "FuncRole"
					};
					return gridDataColumns;
				},

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
				 * @override
				 */
				getCopyRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @override
				 */
				getEditRecordMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#addDetailWizardMenuItems
				 * @override
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getDataImportMenuItem
				 * @override
				 */
				getDataImportMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritDoc BPMSoft.BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @override
				 */
				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

				_addFuncRole: function(selectedItems) {
					const insertBatch = Ext.create("BPMSoft.BatchQuery");
					selectedItems.selectedRows.getItems().forEach(function(item) {
						insertBatch.add(this._getInsertRecordQuery(item));
					}, this);
					if (insertBatch.queries.length > 0) {
						insertBatch.execute(this.reloadGridData, this);
					}
				},

				_getInsertRecordQuery: function(item) {
					const insertQuery = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: this.entitySchemaName
					});
					insertQuery.setParameterValue("OrgRole", this.$MasterRecordId,
						BPMSoft.DataValueType.GUID);
					insertQuery.setParameterValue("FuncRole", item.Id, BPMSoft.DataValueType.GUID);
					return insertQuery;
				}
			},
			diff: /**SCHEMA_DIFF*/[
				{
					"operation": "merge",
					"name": "DataGrid",
					"values": {
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "FuncRoleColumn",
									"bindTo": "FuncRole",
									"position": {
										"column": 0,
										"colSpan": 24
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
									"name": "FuncRole",
									"bindTo": "FuncRole",
									"position": {
										"row": 0,
										"column": 0,
										"colSpan": 24
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
