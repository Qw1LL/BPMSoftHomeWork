define("MultiLookupUtilitiesMixin", function() {
	/**
	 * @class BPMSoft.configuration.mixins.MultiLookupUtilitiesMixin
	 * Provides methods for setup and open multiLookup edit (control), and for process multiLookup result.
	 * @alternateClassName BPMSoft.MultiLookupUtilitiesMixin
	 */
	Ext.define("BPMSoft.configuration.mixins.MultiLookupUtilitiesMixin", {
		alternateClassName: "BPMSoft.MultiLookupUtilitiesMixin",

		/**
		 * Gets image id for MultiLookup.
		 * @protected
		 * @virtual
		 * @param {String} columnName Column Name.
		 * @return {guid} Image id.
		 */
		getLookupImageId: function(columnName) {
			var lookupImageId = "";
			var columnsInfo = BPMSoft.configuration.ColumnsInfo;
			BPMSoft.each(columnsInfo, function(column, name) {
				if (name === columnName) {
					lookupImageId = column.ImageId;
					return false;
				}
			}, this);
			return lookupImageId;
		},

		/**
		 * Handler on sets value to MultiLookup.
		 * @protected
		 * @virtual
		 * @param {String} columnName MultiLookup name.
		 * @return {Array} Array of related columns.
		 */
		getMultiLookupColumns: function(columnName) {
			var column = this.getColumnByName(columnName);
			return column && column.multiLookupColumns || null;
		},

		/**
		 * ######### ### ##### ####### ### ############## #######, #### #### ############ ########.
		 * @protected
		 * @virtual
		 * @param {String} columnName ######## #######.
		 */
		updateColumnReferenceSchemaByMultiLookupValue: function(columnName) {
			var column = this.getColumnByName(columnName);
			var attributeValues = this.get(columnName);
			var connectedColumn = attributeValues && this.getColumnByName(attributeValues.column);
			if (column && column.multiLookupColumns && connectedColumn) {
				column.referenceSchemaName = connectedColumn.referenceSchemaName;
			}
		},

		/**
		 * Initialize MultiLookup values.
		 * @protected
		 * @virtual
		 */
		initMultiLookup: function() {
			this.BPMSoft.each(this.columns, function(column, multiLookupColumnName) {
				var multiLookupColumns = column.multiLookupColumns;
				if (multiLookupColumns) {
					let hasValue = false;
					this.BPMSoft.each(multiLookupColumns, function(columnName) {
						var attributeValues = this.get(columnName);
						if (attributeValues) {
							this.Ext.apply(attributeValues, {"column": columnName});
							this.set(multiLookupColumnName, attributeValues);
							hasValue = true;
						}
					}, this);
					if (!hasValue) {
						this.set(multiLookupColumnName, null);
					}
				}
			}, this);
		},

		/**
		 * Handler for sets MultiLookup values.
		 * Last argument is multiLookup column name.
		 * @protected
		 * @virtual
		 */
		onSetMultiLookup: function() {
			var multiLookupName = arguments[arguments.length - 1];
			var multiLookupColumns = this.getMultiLookupColumns(multiLookupName);
			if (this.Ext.isEmpty(multiLookupColumns)) {
				return;
			}
			var multiLookupValues = this.get(multiLookupName);
			var entityColumn = multiLookupValues && multiLookupValues.column;
			this.BPMSoft.each(multiLookupColumns, function(columnName) {
				if (columnName === entityColumn) {
					this.loadLookupDisplayValue(columnName, multiLookupValues.value);
				} else {
					this.set(columnName, null, {silent: false});
				}
			}, this);
		},

		/**
		 * ##### ######### leftIconConfig ### MultiLookup.
		 * @protected
		 * @virtual
		 * @param {String} multiLookupName ######## ####### MultiLookup.
		 * @return {object} ###### leftIconConfig.
		 */
		getMultiLookupIconConfig: function(multiLookupName) {
			var imageConfig = null;
			var multiLookupColumns = this.getMultiLookupColumns(multiLookupName);
			if (Ext.isEmpty(multiLookupColumns)) {
				return;
			}
			BPMSoft.each(multiLookupColumns, function(columnName) {
				if (this.get(columnName)) {
					imageConfig = {
						"source": BPMSoft.ImageSources.SYS_IMAGE,
						"params": {
							"primaryColumnValue": this.getLookupImageId(columnName)
						}
					};
				}
			}, this);
			return imageConfig;
		},

		/**
		 * ######## ##### ###### ## multilookup #######.
		 * @overridden
		 * @param {String} filterValue ###### ### primaryDisplayColumn.
		 * @param {BPMSoft.Collection} list #########, # ####### ##### ######### ######.
		 * @param {String} columnName ### ####### ViewModel.
		 */
		loadMultiLookupData: function(filterValue, list, columnName) {
			var multiLookupColumns = this.getMultiLookupColumns(columnName);
			var batch = Ext.create("BPMSoft.BatchQuery");
			var rowCount = this.get("QueryRowCount");
			BPMSoft.each(multiLookupColumns, function(columnName) {
				var query = this.getLookupQuery(filterValue, columnName);
				query.rowCount = rowCount;
				batch.add(query);
			}, this);
			batch.execute(function(response) {
				if (response && response.success) {
					list.clear();
					var objects = {};
					var applyImageConfig = function(item) {
						var key = item.value;
						if (!key) {
							return true;
						}
						objects[key] = this.Ext.apply(item, {
							"column": column,
							"imageConfig": {
								"source": BPMSoft.ImageSources.SYS_IMAGE,
								"params": {
									"primaryColumnValue": this.getLookupImageId(column)
								}
							}
						});
					};
					for (var i = 0; i < multiLookupColumns.length; i++) {
						var column = multiLookupColumns[i];
						var queryResult = response.queryResults && response.queryResults[i];
						if (!Ext.isEmpty(queryResult.rows)) {
							BPMSoft.each(queryResult.rows, applyImageConfig, this);
						}
					}
					list.loadAll(objects);
				}
			}, this);
		},

		/**
		 * ########## ######### ######## ###### ## ########### ### multilookup #######.
		 * @protected
		 * @param {Object} args #########.
		 * @param {String} columnName ######## #######.
		 * @return {Object} ######### ######## ###### ## ###########.
		 */
		getMultiLookupPageConfig: function(args, columnName) {
			var multiLookupColumns = this.getMultiLookupColumns(columnName);
			var multiLookupConfig = multiLookupColumns.map(function(column) {
				var config = this.getLookupPageConfig(args, column);
				Ext.apply(config, {
					columnName: columnName,
					columnValue: this.get(columnName),
					multiLookupColumnName: column
				});
				var lookupDefValues = this.getLookupValuePairs(column);
				if (lookupDefValues) {
					var valuePairs = config.valuePairs || [];
					config.valuePairs = this.Ext.Array.merge(valuePairs, lookupDefValues);
				}
				return config;
			}, this);
			return {
				lookupPageName: "MultiLookupModule",
				multiLookupConfig: multiLookupConfig
			};
		},

		getLookupPageConfig: BPMSoft.emptyFn
	});

	return BPMSoft.MultiLookupUtilitiesMixin;
});
