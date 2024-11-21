define("ManyToManyRelationsDetail", [], function() {
	return {
		entitySchemaName: "",

		attributes: {
			
			/**
			 * Master record value column name.
			 * @protected
			 * @type {String}
			 */
			"MasterDetailColumnName": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			
			/**
			 * Related record value column name.
			 * @protected
			 * @type {String}
			 */
			"RelatedDetailColumnName": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			
			/**
			 * Related lookup entity name.
			 * @protected
			 * @type {String}
			 */
			"LookupEntityName": {
				dataValueType: BPMSoft.DataValueType.TEXT
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#IsDetailCollapsed
			 * @overridden
			 */
			"IsDetailCollapsed": {
				dataValueType: BPMSoft.DataValueType.BOOLEAN,
				value: false
			}
		},

		messages: {},

		methods: {
			
			//region Methods: Private
			
			/**
			 * @private
			 */
			_getInsertDataQueries: function(selectedRows) {
				const batchQuery = this.Ext.create("BPMSoft.BatchQuery");
				selectedRows.getItems().forEach(function(item) {
					batchQuery.add(this.getInsertQuery(item));
				}, this);
				return batchQuery;
			},
			
			/**
			 * @private
			 **/
			_onLookupResult: function(lookupResult) {
				const query = this._getInsertDataQueries(lookupResult.selectedRows);
				this.showBodyMask();
				query.execute(this.onInsertComplete, this);
			},
			
			// endregion
			
			//region Methods: Protected
			
			/**
			 * @inheritDoc BPMSoft.BaseGridDetailV2#addRecord
			 * @overridden
			 **/
			addRecord: function() {
				this.getOpenLookupConfig(function(config) {
					this.openLookup(config, this._onLookupResult, this);
				}, this);
			},
			
			/**
			 * Prepares query for fetch existing records in detail.
			 * @returns {BPMSoft.EntitySchemaQuery} Query for fetch existing records in detail.
			 */
			getExistedItemsEsq: function() {
				const esq = this.Ext.create("BPMSoft.EntitySchemaQuery", {
					rootSchemaName: this.entitySchemaName
				});
				esq.addColumn(this.$RelatedDetailColumnName);
				esq.filters.add("masterRecordFilter", BPMSoft.createColumnFilterWithParameter(
					BPMSoft.ComparisonType.EQUAL, this.$MasterDetailColumnName, this.$MasterRecordId));
				return esq;
			},
			
			/**
			 * Prepares filter for lookup data.
			 * @param existedCollection
			 * @returns {BPMSoft.BaseFilter} Esq filter for lookup data.
			 */
			getLookupFilters: function(existedCollection) {
				const existedLookupItems = existedCollection.getItems().map(function(item) {
					return item.get(this.$RelatedDetailColumnName).value;
				}, this);
				const existsFilter = BPMSoft.createColumnInFilterWithParameters("Id",
					existedLookupItems);
				existsFilter.comparisonType = BPMSoft.ComparisonType.NOT_EQUAL;
				existsFilter.Name = "existsFilter";
				return existsFilter;
			},
			
			/**
			 * Prepare open lookup config. Call callback with config.
			 * @param {Function} callback The callback function.
			 * @param {Object} [scope] The scope for the callback.
			 */
			getOpenLookupConfig: function(callback, scope) {
				const config = {
					entitySchemaName: this.$LookupEntityName,
					multiSelect: true
				};
				const esq = this.getExistedItemsEsq();
				esq.getEntityCollection(function(result) {
					if (result.success) {
						config.filters = this.getLookupFilters(result.collection);
					}
					Ext.callback(callback, scope, [config]);
				}, this);
			},
			
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getCopyRecordMenuItem
			 * @overridden
			 */
			getCopyRecordMenuItem: BPMSoft.emptyFn,
			
			/**
			 * @inheritdoc BPMSoft.BaseGridDetailV2#getEditRecordMenuItem
			 * @overridden
			 */
			getEditRecordMenuItem: BPMSoft.emptyFn,

			/**
			* Creates related data insert.
			* @param {Object} lookupItem Selected lookup item.
			* @protected
			**/
			getInsertQuery: function(lookupItem) {
				const insert = this.Ext.create("BPMSoft.InsertQuery", {
					rootSchemaName: this.entitySchemaName
				});
				insert.setParameterValue(this.$MasterDetailColumnName, this.$MasterRecordId, this.BPMSoft.DataValueType.GUID);
				insert.setParameterValue(this.$RelatedDetailColumnName, lookupItem.value, this.BPMSoft.DataValueType.GUID);
				return insert;
			},
			
			/**
			 * Lookup data inserted callback.
			 * @protected
			 */
			onInsertComplete: function () {
				this.hideBodyMask();
				this.reloadGridData();
			}
			
			// endregion
			
		},
		diff: /**SCHEMA_DIFF*/[
			{
				"operation": "merge",
				"name": "AddRecordButton",
				"values": {
					"visible": {"bindTo": "getToolsVisible"}
				}
			}
		]/**SCHEMA_DIFF*/
	};
});
