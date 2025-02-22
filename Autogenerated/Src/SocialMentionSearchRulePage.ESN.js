﻿ define("SocialMentionSearchRulePage", [], function() {
		return {
			entitySchemaName: "SocialMentionSearchRule",
			details: /**SCHEMA_DETAILS*/{}/**SCHEMA_DETAILS*/,
			attributes: {
				/**
				 * Entity schema field name lookup column for combobox.
 				 */
				"EntitySchemaLookup": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				},

				/**
				 * Filtration by field name lookup column for combobox.
 				 */
				"FilterByColumnLookup": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				},

				/**
				 * User field name lookup column for combobox.
 				 */
				"UserColumnLookup": {
					"dataValueType": this.BPMSoft.DataValueType.LOOKUP,
					"type": this.BPMSoft.ViewModelColumnType.ENTITY_COLUMN
				}
			},
			methods: {

				//region Methods: Private

				/**
				 * Updates columns value.
				 * @private
				 * @param {Object} column Current column object.
				 * @return {Object|null} Current column lookup value.
				 */
				_updateColumnValue: function(fieldName, column) {
					if (!Ext.isObject(column)) {
						return null;
					}
					const columnName = column.name || column.columnPath;
					if (columnName) {
						this.set(fieldName, columnName || "");
					}
					return column;
				},

				//endregion

				//region Methods: Protected

				/**
				 * Fills entity schemas list.
				 * @protected
				 * @param {String|null} [filter] Column caption filter.
				 * @param {BPMSoft.Collection} list Entity schemas list.
				 */
				fillEntitySchemaList: function(filter, list) {
					if (this.Ext.isEmpty(list)) {
						return;
					}
					list.clear();
					const esq = Ext.create("BPMSoft.EntitySchemaQuery", {
						rootSchemaName: "VwEntityObjects"
					});
					esq.addColumn("Id");
					esq.addColumn("Name");
					var displayValueColumn = esq.addColumn("Title");
					displayValueColumn.orderDirection = BPMSoft.OrderDirection.ASC;
					esq.getEntityCollection(function(response) {
						if (!response.success || !response.collection) {
							return;
						}
						var collection = response.collection;
						this.BPMSoft.each(collection, function(item) {
							item.value = item.get("Id");
							item.name = item.get("Name");
							item.displayValue = item.get("Title");
							item.markerValue = item.displayValue;
						});
						list.reloadAll(response.collection);
					}, this);
				},

				/**
				 * Fills search rule columns list.
				 * @protected
				 * @param {String|null} [filter] Column caption filter.
				 * @param {BPMSoft.Collection} list User columns list.
				 */
				fillFilterByColumnsList: function(filter, list) {
					this.fillColumnList(filter, list, ["Account", "Contact"], ["Id"]);
				},

				/**
				 * Fills user columns list.
				 * @protected
				 * @param {String|null} [filter] Column caption filter.
				 * @param {BPMSoft.Collection} list User columns list.
				 */
				fillUserColumnList: function(filter, list) {
					this.fillColumnList(filter, list, ["Contact"], []);
				},

				/**
				 * Fills columns expandable list.
				 * @protected
				 * @param {String|null} [filter] Column caption filter.
				 * @param {BPMSoft.Collection} list Contact columns list.
				 * @param {String[]} exceptionReferenceSchemas Column schemas to display in combobox list.
				 * @param {Boolean} exceptionColumns Column names to display in combobox list.
				 */
				fillColumnList: function(filter, list, exceptionReferenceSchemas, exceptionColumns) {
					if (this.Ext.isEmpty(list)) {
						return;
					}
					list.clear();
					var schemaName = this.get("EntitySchema");
					if (this.isEmpty(schemaName)) {
						return;
					}
					BPMSoft.require([schemaName], function(entitySchema) {
						const columns = entitySchema && BPMSoft.deepClone(entitySchema.columns);
						this.BPMSoft.each(columns, function(column) {
							var needDeleteColumn = !exceptionReferenceSchemas.includes(column.referenceSchemaName) &&
								!exceptionColumns.includes(column.name);
							if (needDeleteColumn) {
								delete columns[column.name];
								return true;
							}
							column.value = column.uId;
							column.displayValue = column.caption;
							column.markerValue = column.displayValue;
						});
						list.loadAll(columns);
					}, this);
				},

				//endregion

				//region Methods: Public

				/**
				 * Updates EntitySchema column value and clears columns lists.
				 * @param {String|Object} schema Current schema.
				 * @return {Object|null} Selected schema lookup value.
				 */
				onEntitySchemaChanged: function(schema) {
					if (this.isEmpty(schema)) {
						return null;
					}
					const schemaName = schema.name;
					if (this.isEmpty(schemaName) || this.get("EntitySchema") === schemaName) {
						return schema;
					}
					this.set("EntitySchema", schemaName);
					this.set("FilterByColumn", "");
					this.set("UserColumn", "");
					this.set("FilterByColumnLookup", {
						displayValue: Ext.emptyString,
						value: Ext.emptyString
					});
					this.set("UserColumnLookup", {
						displayValue: Ext.emptyString,
						value: Ext.emptyString
					});
					return schema;
				},

				/**
				 * Updates FilterByColumn column value.
				 * @param {String|Object} column Current selected column.
				 * @return {Object|null} Selected column lookup value.
				 */
				onFilterByColumnChanged: function(column) {
					if (this.isEmpty(column)) {
						return null;
					}
					return this._updateColumnValue("FilterByColumn", column);
				},

				/**
				 * Updates UserColumn column value.
				 * @param {String|Object} column Current selected column.
				 * @return {Object|null} Selected column lookup value.
				 */
				onUserColumnChanged: function(column) {
					if (this.isEmpty(column)) {
						return null;
					}
					return this._updateColumnValue("UserColumn", column);
				}

				//endregion

			},
			diff: /**SCHEMA_DIFF*/[]/**SCHEMA_DIFF*/
		};
	});
