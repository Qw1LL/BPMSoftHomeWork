define("MLListPredictionMixin", ["BPMSoft", "ConfigurationEnums"], function(BPMSoft,
		ConfigurationEnums) {
	Ext.define("BPMSoft.configuration.mixins.MLListPredictionMixin", {
		alternateClassName: "BPMSoft.MLListPredictionMixin",

		_getListPredictionResultAttributeName: function(attribute) {
			return attribute.replace("Lookup", "");
		},

		_getListPredictionResultViewModelColumnLookups: function() {
			return ["ListPredictResultSubjectColumnLookup", "ListPredictResultObjectColumnLookup",
				"ListPredictResultValueColumnLookup", "ListPredictResultModelColumnLookup",
				"ListPredictResultDateColumnLookup"];
		},

		_clearListPredictionResultColumns: function() {
			const columns = this._getListPredictionResultViewModelColumnLookups();
			BPMSoft.each(columns, function(column) {
				this.set(column, null, {skipValidation: true});
			}, this);
		},

		_initializeListPredictionResultColumns: function() {
			const columns = this.get("ListPredictResultColumns");
			const attributesList = this._getListPredictionResultViewModelColumnLookups();
			BPMSoft.each(attributesList, function(attribute) {
				const modelAttributeName = this._getListPredictionResultAttributeName(attribute);
				const value = this.get(modelAttributeName);
				const savedColumn = BPMSoft.find(columns, function(column) {
					return column.name === value;
				});
				if (savedColumn) {
					this.set(attribute, savedColumn);
				}
			}, this);
		},

		/**
		 * If list prediction result column required modifies its model's property.
		 * @param {String} columnName - column name.
		 * @private
		 * @return {Boolean} True if column is required.
		 */
		_setListPredictionColumnRequired: function(columnName) {
			const isRequired = !this.Ext.isEmpty(this.$ListPredictResultSchema);
			this.columns[columnName].isRequired = isRequired;
			return isRequired;
		},

		/**
		 * Get suitable schema columns filter function for List prediction result columns.
		 * @param {String} columnName - name of List prediction result column.
		 * @returns {Function} - filter function.
		 */
		_getListPredictionResultColumnsListFilter: function(columnName) {
			let additionalCondition;
			switch (columnName) {
				case "ListPredictResultObjectColumnLookup":
				case "ListPredictResultSubjectColumnLookup":
				case "ListPredictResultModelColumnLookup":
					additionalCondition = function(column) {
						return BPMSoft.isLookupDataValueType(column.dataValueType) ||
							column.dataValueType === BPMSoft.DataValueType.GUID;
					};
					break;
				case "ListPredictResultValueColumnLookup":
					additionalCondition = function(column) {
						return BPMSoft.isNumberDataValueType(column.dataValueType);
					};
					break;
				case "ListPredictResultDateColumnLookup":
					additionalCondition = function(column) {
						return BPMSoft.isDateDataValueType(column.dataValueType);
					};
					break;
				default:
					additionalCondition = function() {
						return true;
					};
					break;
			}
			return function(column) {
				if (column.usageType !== ConfigurationEnums.EntitySchemaColumnUsageType.General) {
					return false;
				}
				return additionalCondition(column);
			};
		},

		/**
		 * Find List prediction result schema column with given reference schema.
		 * @param {String} referenceSchemaName - lookup reference schema name.
		 * @param {Function} filter - additional column filter.
		 * @private
		 */
		_findColumnByReferenceSchema: function(referenceSchemaName, filter) {
			return BPMSoft.find(this.$ListPredictResultSchemaColumns, function(item) {
				return filter(item) && item.referenceSchemaName === referenceSchemaName;
			});
		},

		/**
		 * Set given suitable to corresponding List prediction result column attribute.
		 * @param {Object} column - suitable column descriptor.
		 * @param ListPredictResultColumnLookupName - List prediction result column attribute name.
		 * @private
		 */
		_setSuitableColumn: function(column, ListPredictResultColumnLookupName) {
			if (!this.Ext.isEmpty(column)) {
				this.set(ListPredictResultColumnLookupName, this._getListValue(column.uId,
					column.caption, column.name));
			}
		},

		_setSuitableColumnBySchemaName: function(attributeName, schemaName, filter) {
			const probableColumn = this._findColumnByReferenceSchema(schemaName, filter);
			this._setSuitableColumn(probableColumn, attributeName);
		},

		/**
		 * Fill List prediction result column suitable column from List prediction result schema.
		 * @param {String} listPredictResultColumnName - List prediction result column attribute name.
		 * @param {Object} searchConfig - settings for suitable column search.
		 * @private
		 */
		_fillWithSuitableColumn: function(listPredictResultColumnName, searchConfig) {
			const currentValue = this.get(listPredictResultColumnName);
			if (!this.Ext.isEmpty(currentValue)) {
				return;
			}
			const filter = this._getListPredictionResultColumnsListFilter(listPredictResultColumnName);
			if (this.Ext.isEmpty(searchConfig)) {
				if (listPredictResultColumnName === "ListPredictResultModelColumnLookup") {
					const probableColumn = this._findColumnByReferenceSchema(this.entitySchemaName, filter);
					this._setSuitableColumn(probableColumn, listPredictResultColumnName);
					return;
				}
				const probableColumns = BPMSoft.filter(this.$ListPredictResultSchemaColumns, function(item) {
					return filter(item);
				});
				if (probableColumns.length === 1) {
					this._setSuitableColumn(probableColumns[0], listPredictResultColumnName);
				}
				return;
			}
			if (searchConfig.schemaAttribute) {
				const schema = this.get(searchConfig.schemaAttribute);
				if (!schema) {
					return;
				}
				this._setSuitableColumnBySchemaName(listPredictResultColumnName, schema.name, filter);
			} else {
				const columnPath = this.get(searchConfig.columnPathAttribute);
				if (this.Ext.isEmpty(columnPath)) {
					return;
				}
				this._getSchemaColumn(columnPath, function(column) {
					this._setSuitableColumnBySchemaName(listPredictResultColumnName, column.referenceSchemaName, filter);
				});
			}
		},

		/**
		 * Get schema column descriptor by path array.
		 * @param {Object} schema - schema decriptor.
		 * @param {Array} pathArray - path elements array.
		 * @param {Function} callback - callback function to process result. Sync
		 * call not supported.
		 * @private
		 */
		_getColumnByPathArray: function(schema, pathArray, callback) {
			const columnName = pathArray.shift();
			const column = schema.getColumnByName(columnName);
			if (pathArray.length) {
				BPMSoft.require([column.referenceSchemaName], function(foundSchema) {
					this._getColumnByPathArray(foundSchema, pathArray, callback);
				}, this);
			} else {
				this.Ext.callback(callback, this, [column]);
			}
		},

		/**
		 * Get schema column descriptor by column path. Reverse mode is not supported.
		 * @param {String} columnPath - column path.
		 * @param {Function} callback - callback function to process result. Sync call not supported.
		 * @private
		 */
		_getSchemaColumn: function(columnPath, callback) {
			const parts = columnPath.split(".");
			this._getColumnByPathArray(BPMSoft[this.$RootSchema.name], parts, callback);
		},

		/**
		 * Handles change of List prediction result columns attributes.
		 */
		onListPredictionResultColumnLookupAttributeChange: function(args, changedColumnName) {
			const modelAttributeName = this._getListPredictionResultAttributeName(changedColumnName);
			const selectedColumn = this.get(changedColumnName);
			const selectedColumnName = selectedColumn ? selectedColumn.name : null;
			this.set(modelAttributeName, selectedColumnName);
		},

		/**
		 * Prepare dropdown list elements for List prediction result columns.
		 * @param {String} filterValue - filter string.
		 * @param {Object} list - current list.
		 * @param {String} columnName - List prediction result column name.
		 */
		prepareListPredictionSchemaColumnLookupList: function(filterValue, list, columnName) {
			if (this.Ext.isEmpty(list)) {
				list = new BPMSoft.Collection();
			}
			const filterFunction = this._getListPredictionResultColumnsListFilter(columnName);
			const columns = this.$ListPredictResultSchemaColumns;
			const suitableColumns = {};
			BPMSoft.each(columns, function(column) {
				if (filterFunction(column)) {
					suitableColumns[column.uId] = this._getListValue(column.uId, column.caption, column.name);
				}
			}, this);
			list.reloadAll(suitableColumns);
		},

		/**
		 * Handles change of list prediction results schema.
		 */
		onListPredictionResultSchemaChanged: function() {
			if (!this.$ListPredictResultSchemaInitialized) {
				return;
			}
			if (!this.$ListPredictResultSchema) {
				this.$ListPredictResultColumns = null;
				this.$ListPredictResultSchemaColumns = null;
				this.$ListPredictResultSchemaUId = null;
				this._clearListPredictionResultColumns();
				return;
			}
			if (this.$ListPredictResultSchemaUId !== this.$ListPredictResultSchema.value) {
				this._clearListPredictionResultColumns();
			}
			this.$ListPredictResultSchemaUId = this.$ListPredictResultSchema.value;
			this.initializeListPredictionResultSchemaColumns(function() {
				this._fillWithSuitableColumn("ListPredictResultSubjectColumnLookup",
					this.$ListPredictSubjectColumnSearchConfig);
				this._fillWithSuitableColumn("ListPredictResultObjectColumnLookup",
					this.$ListPredictObjectColumnSearchConfig);
				this._fillWithSuitableColumn("ListPredictResultModelColumnLookup");
				this._fillWithSuitableColumn("ListPredictResultValueColumnLookup");
				this._fillWithSuitableColumn("ListPredictResultDateColumnLookup");
			}, this);
		},

		initializeSchema: function(schemaAttributeName) {
			const rootSchemaUId = this.get(schemaAttributeName + "UId");
			const rootSchemaList = this.getRootSchemaList();
			const rootSchema = rootSchemaList[rootSchemaUId];
			this.set(schemaAttributeName, rootSchema);
		},

		/**
		 * Setup List prediction result schema lookup.
		 */
		initializeListPredictionResultSchema: function() {
			this.initializeSchema("ListPredictResultSchema");
			this.$ListPredictResultSchemaInitialized = true;
		},

		initializeListPredictionResultSchemaColumns: function(callback, scope) {
			this.initializeSchemaColumns("ListPredictResultSchemaColumns", "ListPredictResultSchema", "ListPredictResultColumns",
				callback, scope);
		},

		/**
		 * @return {Boolean} True if ListPredictResultUserColumnLookup column is required.
		 */
		setListPredictionResultSubjectColumnRequired: function() {
			return this._setListPredictionColumnRequired("ListPredictResultSubjectColumnLookup");
		},

		/**
		 * @return {Boolean} True if ListPredictResultItemColumnLookup column is required.
		 */
		setListPredictionResultObjectColumnRequired: function() {
			return this._setListPredictionColumnRequired("ListPredictResultObjectColumnLookup");
		}

	});

	return BPMSoft.MLListPredictionMixin;
});
