define("SysAdminUnitInWorkplaceDetailV2", ["ConfigurationConstants"],
	function(ConfigurationConstants) {
		return {
			entitySchemaName: "SysAdminUnitInWorkplace",
			methods: {

				/**
				 * ########## ######### ###### ########## ######
				 * @overridden
				 */
				getAddRecordButtonVisible: function() {
					return this.getToolsVisible();
				},

				/**
				 * @overridden
				 */
				onCardSaved: function() {
					this.openSysAdminLookup();
				},

				/**
				 * @overridden
				 **/
				addRecord: function() {
					this.sandbox.publish("SaveRecord", {
						isSilent: true,
						messageTags: [this.sandbox.id]
					}, [this.sandbox.id]);
				},

				/**
				 * Open administration objects directories.
				 * @private
				 */
				openSysAdminLookup: function() {
					this._getSysAdminLookupConfig(function openLookupByConfig(config) {
						this.openLookup(config, this.addCallBack, this);
					}, this);
				},

				/**
				 * Creates a config to open a directory.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution context.
				 * @return {Object} Configuration object.
				 */
				_getSysAdminLookupConfig: function(callback, scope) {
					var config = {
						entitySchemaName: "SysAdminUnit",
						multiSelect: true,
						hideActions: true
					};
					this._getSysAdminUnitFilter(function(filterGroup) {
						config.filters = filterGroup;
						Ext.callback(callback, scope || this, [config]);
					}, this);
				},

				/**
				 * Gets SysAdminUnit filter group.
				 * @private
				 * @param {Function} callback Callback function.
				 * @param {Object} scope Callback execution context.
				 * @return {Object} Filter group SysAdminUnit.
				 */
				_getSysAdminUnitFilter: function(callback, scope) {
					var workplaceId = this.get("MasterRecordId");
					var esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "SysAdminUnitInWorkplace"
					});
					esq.addColumn("SysAdminUnit.Id", "SysAdminUnitId");
					esq.filters.addItem(this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "SysWorkplace", workplaceId));
					esq.getEntityCollection(function(result) {
						var sysAdminUnits = [];
						if (result.success && !result.collection.isEmpty()) {
							result.collection.each(function(item) {
								sysAdminUnits.push(item.get("SysAdminUnitId"));
							}, this);
						}
						var filters = this._getFilterBySysAdminUnitsInWorkplace(sysAdminUnits);
						Ext.callback(callback, scope || this, [filters]);
					}, scope);
				},

				/**
				 * Gets the filter by SysAdminUnit.
				 * @private
				 * @param {Array} sysAdminUnits Admin units in workplace.
				 * @return {Object} Filter group.
				 */
				_getFilterBySysAdminUnitsInWorkplace: function(sysAdminUnits) {
					var filterGroup = this.BPMSoft.createFilterGroup();
					if (sysAdminUnits.length > 0) {
						var existsFilter =
								this.BPMSoft.createColumnInFilterWithParameters("Id", sysAdminUnits);
						existsFilter.comparisonType = this.BPMSoft.ComparisonType.NOT_EQUAL;
						filterGroup.addItem(existsFilter);
					}
					filterGroup.add("roleFilter", this._gerSysAdminUnitTypeFilter());
					return filterGroup;
				},

				/**
				 * Gets the filter by admin unit type.
				 * @private
				 * @return {Object} Filter group SysAdminUnit by type.
				 */
				_gerSysAdminUnitTypeFilter: function() {
					var typeRolesFilter = this.BPMSoft.createFilterGroup();
					var rolesFilter1 = this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.LESS, "SysAdminUnitTypeValue",
							ConfigurationConstants.SysAdminUnit.Type.User);
					typeRolesFilter.logicalOperation = this.BPMSoft.LogicalOperatorType.OR;
					var rolesFilter2 = this.BPMSoft.createColumnFilterWithParameter(
							this.BPMSoft.ComparisonType.EQUAL, "SysAdminUnitTypeValue",
							ConfigurationConstants.SysAdminUnit.Type.FuncRole);
					typeRolesFilter.addItem(rolesFilter1);
					typeRolesFilter.add("functionalRoleFilter", rolesFilter2);
					return typeRolesFilter;
				},

				/**
				 * callBack function openLookup
				 * @private
				 * @param {Object} args
				 */
				addCallBack: function(args) {
					var bq = Ext.create("BPMSoft.BatchQuery");
					this.selectedRows = args.selectedRows.getItems();
					this.selectedItems = [];
					this.selectedRows.forEach(function(item) {
						bq.add(this.getInsertQuery(item));
						this.selectedItems.push(item.value);
					}, this);
					if (bq.queries.length) {
						bq.execute(this.onItemInsert, this);
					}
				},

				/**
				* ########## ###### ## ########## ####### #################
				* @param  {Object} item ######### # ########### ###### {SysWorkplaceId, value}
				* @private
				* @return Object
				 **/
				getInsertQuery: function(item) {
					var insert = Ext.create("BPMSoft.InsertQuery", {
						rootSchemaName: "SysAdminUnitInWorkplace"
					});
					insert.setParameterValue("SysAdminUnit", item.value, BPMSoft.DataValueType.GUID);
					insert.setParameterValue("SysWorkplace", this.get("MasterRecordId"), BPMSoft.DataValueType.GUID);
					return insert;
				},

				/**
				 * ######## ########## ######## # ######
				 * @private
				 * @param {Object} response
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
				 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
				 * @overridden
				 */
				getEditRecordMenuItem: BPMSoft.emptyFn

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
						"type": "listed",
						"listedConfig": {
							"name": "DataGridListedConfig",
							"items": [
								{
									"name": "NameListedGridColumn",
									"bindTo": "SysAdminUnit.Name",
									"position": { "column": 1, "colSpan": 24 }
								}
							]
						},
						"tiledConfig": {
							"name": "DataGridTiledConfig",
							"grid": { "columns": 24, "rows": 1 },
							"items": [
								{
									"name": "NameTiledGridColumn",
									"bindTo": "SysAdminUnit.Name",
									"type": "text",
									"position": { "row": 1, "column": 0, "colSpan": 20 }
								}
							]
						}
					}
				},
			]/**SCHEMA_DIFF*/
		};
	}
);
