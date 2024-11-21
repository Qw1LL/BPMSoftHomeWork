define("LinkedEntitySchemaLookupSection", [],
	function() {
		return {
			attributes: {},
			methods: {

				/**
				 * @protected
				 */
				columnsFiltrationMethod: function(column) {
					const dataValueType = column.dataValueType;
					var allowedTypes = [];
					if (this.columnName === "EmailAddressColumn") {
						allowedTypes = [
							BPMSoft.DataValueType.LOOKUP,
							BPMSoft.DataValueType.TEXT,
							BPMSoft.DataValueType.SHORT_TEXT,
							BPMSoft.DataValueType.MEDIUM_TEXT,
							BPMSoft.DataValueType.MAXSIZE_TEXT,
							BPMSoft.DataValueType.LONG_TEXT
						];
					}
					if (this.columnName === "ContactColumn") {
						allowedTypes = [
							BPMSoft.DataValueType.LOOKUP
						];
					}
					return Ext.Array.contains(allowedTypes, dataValueType);
				},

				/**
				 * @protected
				 */
				updateColumnHandler: function(result, row, columnName) {
					var path = this.formatColumnPath(result.leftExpressionColumnPath, columnName);
					row.set(columnName, path);
					this.onCtrlEnterKeyPressed();
				},
				
				/**
				 * @private
				 */
				_updateColumnValue: function(columnName, row) {
					if (!row) {
						return;
					}
					var entityObject = row.get("EntityObject");
					var schemaUid = entityObject && entityObject.value;
					var schema = BPMSoft.EntitySchemaManager.findItem(schemaUid);
					if (!schema) {
						return;
					}
					var scope = this;
					BPMSoft.StructureExplorerUtilities.open({
						scope: row,
						handlerMethod: function(result) {
							scope.updateColumnHandler.call(scope, result, row, columnName);
						},
						moduleConfig: {
							schemaName: schema.name,
							columnPath: row.get(columnName) || "",
							useBackwards: false,
							allowEmptyResult: true,
							columnsFiltrationMethod: this.columnsFiltrationMethod.bind({ columnName: columnName })
						}
					});
				},

				/**
				 * @private
				 */
				_updateActiveRow: function(columnName) {
					var activeRow = this.getActiveRow();
					if (activeRow) {
						this._updateColumnValue(columnName, activeRow);
					}
				},

				/**
				 * @private
				 */
				_disableEntityObjectColumn: function(columnName, controlsConfig) {
					var activeRow = this.getActiveRow();
					if (!activeRow || !activeRow.isAddOrCopyMode()) {
						var enabled = (columnName !== "EntityObject");
						Ext.apply(controlsConfig, {
							enabled: enabled
						});
					}
				},

				/**
				 * Returns formated column path.
				 * @param {String} path Original column path.
				 * @param {String} columnName The name of column.
				 * @return {String} The column path.
				 */
				formatColumnPath: function(path, columnName) {
					if (columnName === "ContactColumn") {
						path += ".Id";
					}
					return path;
				},

				/**
				 * @protected
				 */
				getIsReadonlyColumn: function(columnName) {
					return columnName === "ContactColumn" || columnName === "EmailAddressColumn";
				},

				/**
				 * @inheritdoc BPMSoft.ConfigurationGridUtilities#getCellControlsConfig
				 * @override
				 */
				getCellControlsConfig: function(entitySchemaColumn) {
					var scope = this;
					var columnName = entitySchemaColumn.name;
					var controlsConfig =
						this.mixins.ConfigurationGridUtilities.getCellControlsConfig.apply(scope, arguments);
					this._disableEntityObjectColumn(columnName, controlsConfig);
					if (this.getIsReadonlyColumn(columnName)) {
						controlsConfig.controlConfig = {
							"readonly": true,
							"markerValue": columnName,
							"applyHighlight": function() {
								setTimeout(function() {
									scope._updateActiveRow(columnName);
								}, 100);
							}
						};
					}
					return controlsConfig;
				}

			},
			diff: /**SCHEMA_DIFF*/[
				]/**SCHEMA_DIFF*/
		};
	});
