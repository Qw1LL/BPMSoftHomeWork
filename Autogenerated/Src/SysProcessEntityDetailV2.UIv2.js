define("SysProcessEntityDetailV2", ["BPMSoft"],
	function() {
		return {
			entitySchemaName: "VwSysProcessEntity",
			attributes: {},
			methods: {
				/**
				 * @inheritdoc BaseGridDetailV2#addRecordOperationsMenuItems
				 * @overridden
				 */
				addRecordOperationsMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BaseGridDetailV2#addDetailWizardMenuItems
				 * @overridden
				 */
				addDetailWizardMenuItems: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BaseGridDetailV2#getSwitchGridModeMenuItem
				 * @overridden
				 */
				getSwitchGridModeMenuItem: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc GridUtilitiesV2#linkClicked
				 * @overridden
				 */
				linkClicked: this.BPMSoft.emptyFn,

				/**
				 * @inheritdoc BaseDetailV2#initDetailOptions
				 * @overridden
				 */
				initDetailOptions: function() {
					this.set("IsDetailCollapsed", true);
					this.callParent();
				},

				/**
				 * @inheritdoc GridUtilitiesV2#getGridDataColumns
				 * @overridden
				 */
				getGridDataColumns: function() {
					const config = this.callParent();
					const columns = ["EntityId", "ReferenceSchemaName"];
					BPMSoft.each(columns, function(column) {
						config[column] = {path: column};
					}, this);
					return config;
				},

				/**
				 * @inheritdoc GridUtilitiesV2#updateLoadedGridData
				 * @overridden
				 */
				updateLoadedGridData: function(response, callback, scope) {
					const rows = response.collection;
					this._getSchemaNamesBatchQuery(rows, function(batchQuery) {
						batchQuery.execute(function(result) {
							if (result.queryResults) {
								BPMSoft.each(result.queryResults, function(queryResult, queryResultIndex) {
									const row = rows.getByIndex(queryResultIndex);
									scope._setEntityDisplayValue(queryResult, row);
								});
							}
							callback.call(scope, response);
						}, this);
					}, this);
				},

				/**
				 * Sets valid entity display value.
				 * @private
				 * @param {Object} queryResult BatchQuery result.
				 * @param {Collection} row Entity.
				 */
				_setEntityDisplayValue: function(queryResult, row) {
					const resultRow = queryResult.rows[0];
					const displayColumnPath = this.entitySchema.primaryDisplayColumnName;
					row.set("RecordNotFound", !resultRow);
					if (resultRow) {
						if (row.get("EntityId") === resultRow.Id) {
							const rowTitle = resultRow.Name ? resultRow.Name : BPMSoft.formatGUID(resultRow.Id, "B");
							row.set(displayColumnPath, rowTitle);
						}
					} else {
						row.set(displayColumnPath, this.get("Resources.Strings.ReferenceEntityNotFound"));
					}
				},

				/**
				 * Creates BatchQuery to select valid entity names.
				 * @private
				 * @param {Collection} items Entity collection.
				 * @param {Function} callback The callback function.
				 * @param {Object} scope The scope of callback function.
				 */
				_getSchemaNamesBatchQuery: function(items, callback, scope) {
					const batchQuery = Ext.create("BPMSoft.BatchQuery");
					const chainArguments = [];
					items.each(function(item) {
						chainArguments.push(function(next) {
							const referenceSchemaName = item.get("ReferenceSchemaName");
							this.getEntitySchemaByName(referenceSchemaName, function(schema) {
								const entityId = item.get("EntityId");
								batchQuery.add(this._getEntityNameESQ(schema, entityId));
								next();
							});
						});
					}, this);
					chainArguments.push(function() {
						callback.call(scope, batchQuery);
					});
					BPMSoft.chain.apply(this, chainArguments);
				},

				/**
				 * Creates query to select valid schema primary display column value.
				 * @private
				 * @param {Object} schema entity schema.
				 * @param {String} entityId Entity identifier.
				 * @return {BPMSoft.EntitySchemaQuery} ESQ for specific entity.
				 */
				_getEntityNameESQ: function(schema, entityId) {
					const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: schema.name
					});
					if (schema.primaryDisplayColumn) {
						esq.addColumn(schema.primaryDisplayColumn.name, "Name");
					}
					const filter = esq.createColumnFilterWithParameter(BPMSoft.ComparisonType.EQUAL, "Id", entityId);
					esq.filters.add(filter);
					return esq;
				},

				/**
				 * @inheritdoc GridUtilitiesV2#addColumnLink
				 * @overridden
				 */
				addColumnLink: function(item, column) {
					if (item.get("RecordNotFound")){
						return;
					}
					const columnPath = column.columnPath;
					if (columnPath !== "EntityDisplayValue") {
						this.callParent(arguments);
						return;
					}
					const onColumnLinkClickHandler = "on" + columnPath + "LinkClick";
					const referenceSchemaName = item.get("ReferenceSchemaName");
					const entitySchemaConfig = BPMSoft.configuration.ModuleStructure[referenceSchemaName];
					const scope = this;
					if (entitySchemaConfig) {
						item[onColumnLinkClickHandler] = function() {
							return scope._createEntityDisplayValueLink(item, referenceSchemaName,
								columnPath, "EntityId");
						};
					}
				},

				/**
				 * Creates link on EntityDisplayValue column.
				 * @private
				 * @param item ESQ collection item.
				 * @param referenceSchemaName Referenced object schema name.
				 * @param displayValueColumnPath Referenced object name column path.
				 * @param idColumnPath Referenced object Id column path.
				 * @return {Object} column link.
				 */
				_createEntityDisplayValueLink: function(item, referenceSchemaName, displayValueColumnPath,
						idColumnPath) {
					const recordId = item.get(idColumnPath);
					const displayValue = item.get(displayValueColumnPath);
					const link = recordId && displayValue
						? this.createLink(referenceSchemaName, displayValueColumnPath, displayValue, recordId)
						: "";
					return link;
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
									"name": "EntityDisplayValueListedGridColumn",
									"bindTo": "EntityDisplayValue",
									"position": {
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "SysSchemaListedGridColumn",
									"bindTo": "SysSchema",
									"position": {
										"column": 13,
										"colSpan": 11
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
									"name": "EntityDisplayValueTiledGridColumn",
									"bindTo": "EntityDisplayValue",
									"position": {
										"row": 1,
										"column": 1,
										"colSpan": 11
									}
								},
								{
									"name": "SysSchemaTiledGridColumn",
									"bindTo": "SysSchema",
									"position": {
										"row": 1,
										"column": 13,
										"colSpan": 11
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
