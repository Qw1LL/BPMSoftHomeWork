define("IsolatedRecordDetail", [], function() {
	return {
		entitySchemaName: "VwIsolatedRecord",
		attributes: {
		},
		properties: {
			/**
			 * Array of isolated entity schema configs.
			 */
			_isolatedSchemas: []
		},
		methods: {
			/**
			 * Handles event when isolated schemas received from server.
			 * @param {[{name: String, primaryDisplayColumn: String}]} isolatedSchemasInfo Configs of isolated entity schemas.
			 * @param {Function} callback Callback function.
			 * @private
			 */
			_onLoadIsolatedSchemas: function(isolatedSchemasInfo, callback) {
				this._isolatedSchemas = isolatedSchemasInfo || [];
				callback();
			},

			/**
			 * Formats alias for column used to get display value of record.
			 * @param {{name: String, primaryDisplayColumn: String}} schemaInfo Config of isolated entity schema.
			 * @returns {String} Column alias.
			 * @private
			 */
			_getIsolatedSchemaColumnAlias: function(schemaInfo) {
				return Ext.String.format("{0}_{1}", schemaInfo.name, schemaInfo.primaryDisplayColumn);
			},

			/**
			 * Returns mapping between entity schema name and model value that stores its display value.
			 * @param {Object} values Dataset model values.
			 * @private
			 */
			_getNameEntityMapping: function(values) {
				const mapping = {};
				BPMSoft.each(this._isolatedSchemas, function(schemaInfo) {
					if (!schemaInfo.name || !schemaInfo.primaryDisplayColumn) {
						return;
					}
					const columnAlias = this._getIsolatedSchemaColumnAlias(schemaInfo);
					mapping[schemaInfo.name] = values[columnAlias];
				}, this);
				return mapping;
			},

			/**
			 * @private
			 * @param {Object} defColumnsConfig Default columns which are always requested.
			 */
			_applyAdditionalDefaultColumns: function(defColumnsConfig) {
				const additionalDefaultColumns = ["EntitySchemaName", "RecordId"];
				BPMSoft.each(additionalDefaultColumns, function(columnName) {
					defColumnsConfig[columnName] = {
						path: columnName
					};
				});
			},

			/**
			 * Returns array of column names used to get display value of record.
			 * @private
			 */
			_getNameDisplayColumnNames: function() {
				const columnNames = [];
				BPMSoft.each(this._isolatedSchemas, function(schemaInfo) {
					if (!schemaInfo.name || !schemaInfo.primaryDisplayColumn) {
						return;
					}
					const columnAlias = this._getIsolatedSchemaColumnAlias(schemaInfo);
					columnNames.push(columnAlias);
				}, this);
				return columnNames;
			},


			/**
			 * @private
			 * @param {BPMSoft.model.BaseViewModel} item The row to process the cell from.
			 * @return {String} Display value of the current item.
			 */
			_getDisplayValue: function(item) {
				const columns = item.getModelColumns();
				const values = Object.keys(columns).reduce(function(accumulator, columnName) {
					accumulator[columnName] = item.get(columnName);
					return accumulator;
				}, {});
				return this._getNameEntityMapping(values)[item.$EntitySchemaName];
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#loadGridData
			 * @override
			 */
			loadGridData: function() {
				const parentInit = this.getParentMethod(this, arguments);
				this.callService({
					serviceName: "IsolatedAccessService",
					methodName: "GetIsolatedSchemasInfo",
					data: {
						externalAccessId: this.$MasterRecordId
					}
				}, function(responseObject) {
					this._onLoadIsolatedSchemas(responseObject.result, parentInit);
				});
			},

			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditPage
			 * @override
			 */
			getEditPage: function(recordId, typeColumnValue) {
				const record = this.getGridData().find(recordId);
				const currentEntitySchema = record.$EntitySchemaName;
				const editPages = this.getEditPagesCollectionByName(currentEntitySchema);
				return editPages.find(typeColumnValue) || editPages.first();
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#addPrimaryColumnLink
			 * @override
			 */
			addPrimaryColumnLink: function(item, column) {
				const displayValue = this._getDisplayValue(item);
				if (!displayValue) {
					return;
				}
				const entitySchemaName = item.$EntitySchemaName;
				const entitySchemaConfig = BPMSoft.configuration.ModuleStructure[entitySchemaName];
				if (!entitySchemaConfig) {
					return;
				}
				const columnPath = column.columnPath;
				const scope = this;
				this.addColumnLinkClickHandler(item, column, function() {
					const recordId = item.$RecordId;
					return scope.createLink.call(item, entitySchemaName, columnPath,
						displayValue, recordId);
				});
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#addGridDataColumns
			 * @override
			 */
			addGridDataColumns: function(esq) {
				this.callParent(arguments);
				BPMSoft.each(this._isolatedSchemas, function(schemaInfo) {
					if (!schemaInfo.name || !schemaInfo.primaryDisplayColumn) {
						return;
					}
					if (BPMSoft.DataServiceSettings &&
							BPMSoft.DataServiceSettings.RestrictedSelectSchemaAccessNames.includes(schemaInfo.name)) {
						return;
					}
					const columnPath = Ext.String.format("[{0}:Id:RecordId].{1}",
						schemaInfo.name, schemaInfo.primaryDisplayColumn);
					const columnAlias = this._getIsolatedSchemaColumnAlias(schemaInfo);
					esq.addColumn(columnPath, columnAlias);
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#applyEsqSortingByCell
			 * @override
			 */
			applyEsqSortingByCell: function(cell, esq) {
				if (cell.metaPath !== "Name") {
					this.callParent(arguments);
					return;
				}
				const displayColumnNames = this._getNameDisplayColumnNames();
				BPMSoft.each(displayColumnNames, function(columnName) {
					const esqColumn = esq.columns.collection.get(columnName);
					if (!esqColumn) {
						return;
					}
					esqColumn.orderPosition = cell.orderPosition;
					esqColumn.orderDirection = cell.orderDirection;
				}, this);
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridDataColumns
			 * @override
			 */
			getGridDataColumns: function() {
				const defColumnsConfig = this.callParent(arguments);
				this._applyAdditionalDefaultColumns(defColumnsConfig);
				return defColumnsConfig;
			},

			/**
			 * @inheritdoc BPMSoft.GridUtilities#getGridRowViewModelConfig
			 * @override
			 */
			getGridRowViewModelConfig: function() {
				const gridRowViewModelConfig = this.callParent(arguments);
				const values = gridRowViewModelConfig.values;
				const nameEntityMapping = this._getNameEntityMapping(values);
				const unavailableDisplayValueText = this.get("Resources.Strings.UnavailableDisplayValueText");
				values.Name = nameEntityMapping[values.EntitySchemaName] || unavailableDisplayValueText;
				return gridRowViewModelConfig;
			},

			/**
			 * @inheritdoc BaseDetailV2#init
			 * @override
			 */
			init: function() {
				this.$IsEnabled = false;
				this.callParent(arguments);
			},

			/**
			 * @inheritdoc BaseDetailV2#getDetailInfo
			 * @override
			 */
			getDetailInfo: function() {
				const detailInfo = this.callParent(arguments);
				detailInfo.isEnabled = false;
				return detailInfo;
			}
		},

		diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
	};
});
