define("EsqTimelineDataProvider", ["TimelineColumnFiltersBuilder", "EsqTimelineSearchProvider",
		"BaseAjaxTimelineDataProvider"], function(filtersBuilder) {
	/**
	 * Timeline data provider class that uses Entity Schema Query for loading data of different entities.
	 */
	Ext.define("BPMSoft.configuration.EsqTimelineDataProvider", {
		extend: "BPMSoft.BaseAjaxTimelineDataProvider",
		alternateClassName: "BPMSoft.EsqTimelineDataProvider",

		// region Properties: Protected

		/**
		 * @override
		 */
		searchProviderClassName: "BPMSoft.EsqTimelineSearchProvider",

		// endregion

		// region Methods: Private

		/**
		 * Creates batch query for loading items and applies search filters if search was applied.
		 * @private
		 * @param {Object} searchResultEsqFilters Search result - Esq filter groups for each entity.
		 * @param {Array} entitiesConfig Array of configs for each entity whose records should be loaded.
		 * @param {Object} userFilters Object containing data of user filters like 'by owner', 'by period' etc.
		 */
		_createBatchQueryBySearchResult: function(searchResultEsqFilters, entitiesConfig, userFilters) {
			var batchQuery = Ext.create("BPMSoft.BatchQuery");
			var isSearchApplied = searchResultEsqFilters !== null;
			BPMSoft.each(entitiesConfig, function(entityConfig) {
				var entityEsqSearchFilter = isSearchApplied
					? searchResultEsqFilters[entityConfig.entityConfigKey]
					: null;
				if (isSearchApplied && !entityEsqSearchFilter) {
					return;
				}
				var pagingOptions = entityConfig.pagingOptions;
				if (pagingOptions.rowCount !== 0) {
					var esq = this._getItemQuery(entityConfig, userFilters);
					if (entityEsqSearchFilter) {
						esq.filters.addItem(entityEsqSearchFilter);
					}
					batchQuery.add(esq);
				}
			}, this);
			return batchQuery;
		},

		/**
		 * Builds EntitySchemaQuery for loading items of specific entity.
		 * @private
		 * @param {Object} entityConfig Entity config.
		 * @param {Object} userFilters User filters.
		 * @return {BPMSoft.EntitySchemaQuery} Query for loading items.
		 */
		_getItemQuery: function(entityConfig, userFilters) {
			var entitySchemaName = entityConfig.entitySchemaName;
			var esq = this._createEntitySchemaQuery(entitySchemaName);
			this._initQueryPagingOption(esq, entityConfig);
			this._addColumnsToEsq(esq, entityConfig);
			this._addParameterColumnsToEsq(esq, entityConfig);
			this._addEsqFilters(esq, entityConfig, userFilters);
			return esq;
		},

		/**
		 * Creates new EntitySchemaQuery instance for specified schema.
		 * @private
		 * @param {String} schemaName Root schema name.
		 * @return {BPMSoft.EntitySchemaQuery} Query for loading items.
		 */
		_createEntitySchemaQuery: function(schemaName) {
			return Ext.create("BPMSoft.EntitySchemaQuery", {
				rootSchemaName: schemaName,
				queryKind: BPMSoft.QueryKind.LIMITED
			});
		},

		/**
		 * Inits paging options for specific query.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Query.
		 * @param {Object} entityConfig Entity config.
		 */
		_initQueryPagingOption: function(esq, entityConfig) {
			var pagingOptions = entityConfig.pagingOptions;
			esq.isPageable = true;
			esq.rowCount = pagingOptions.rowCount;
			if (BPMSoft.useOffsetFetchPaging) {
				esq.rowsOffset = pagingOptions.rowsOffset;
			} else {
				this._addConditionalValues(esq, entityConfig);
			}
		},

		/**
		 * Adds conditional values to esq.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Query.
		 * @param {Object} entityConfig Entity config.
		 */
		_addConditionalValues: function(esq, entityConfig) {
			var lastItem = entityConfig.lastItem;
			if (!lastItem) {
				return;
			}
			var entitySchema = BPMSoft.configuration.EntityStructure[entityConfig.entitySchemaName] || {};
			var entityPrimaryColumnName = entitySchema.primaryColumnName || this.primaryColumnName;
			var conditionalValues = Ext.create("BPMSoft.ColumnValues");
			conditionalValues.setParameterValue(
				entityPrimaryColumnName,
				lastItem.get(this.primaryColumnName),
				BPMSoft.DataValueType.GUID
			);
			conditionalValues.setParameterValue(
				this.sortDateColumnName,
				lastItem.get(this.sortDateColumnName),
				BPMSoft.DataValueType.DATE_TIME
			);
			esq.conditionalValues = conditionalValues;
		},

		/**
		 * Adds columns to esq from configs.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Query.
		 * @param {Object} entityConfig Entity config.
		 */
		_addColumnsToEsq: function(esq, entityConfig) {
			var columns = entityConfig.columns;
			esq.addMacrosColumn(BPMSoft.QueryMacrosType.PRIMARY_COLUMN, this.primaryColumnName);
			this._addDefaultColumnsToEsq(esq, entityConfig);
			BPMSoft.each(
				columns,
				function(columnConfig) {
					esq.addColumn(columnConfig.columnName, columnConfig.columnAlias);
				},
				this
			);
		},

		/**
		 * Adds parameter columns to esq from configs.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Query.
		 * @param {Object} entityConfig Entity config.
		 */
		_addParameterColumnsToEsq: function(esq, entityConfig) {
			esq.addParameterColumn(entityConfig.entitySchemaName, BPMSoft.DataValueType.TEXT, "EntitySchemaName");
			esq.addParameterColumn(entityConfig.viewClassName, BPMSoft.DataValueType.TEXT, "TimelineViewClassName");
			esq.addParameterColumn(entityConfig.iconUrl, BPMSoft.DataValueType.TEXT, "IconUrl");
			esq.addParameterColumn(entityConfig.entityConfigKey, BPMSoft.DataValueType.TEXT, "EntityConfigKey");
		},

		/**
		 * Returns type column name of the specified entity schema.
		 * @param {String} entitySchemaName Name of the entity schema.
		 * @return {String}
		 */
		_getEntityTypeColumnName: function(entitySchemaName) {
			var typeColumnName = null;
			var entityStructure = BPMSoft.ModuleUtils.getEntityStructureByName(entitySchemaName);
			if (entityStructure) {
				BPMSoft.each(entityStructure.pages, function(editPage) {
					if (editPage.typeColumnName) {
						typeColumnName = editPage.typeColumnName;
					}
					return false;
				}, this);
			}
			return typeColumnName;
		},

		/**
		 * Adds default columns to esq from configs.
		 * @private
		 * @param {BPMSoft.EntitySchemaQuery} esq Query.
		 * @param {Object} entityConfig Entity config.
		 */
		_addDefaultColumnsToEsq: function(esq, entityConfig) {
			if (entityConfig.orderColumnName) {
				var orderColumn = esq.addColumn(entityConfig.orderColumnName, this.sortDateColumnName);
				orderColumn.orderDirection = entityConfig.orderDirection;
			}
			if (entityConfig.authorColumnName) {
				esq.addColumn(entityConfig.authorColumnName, "Author");
			}
			if (entityConfig.captionColumnName) {
				esq.addColumn(entityConfig.captionColumnName, "Caption");
			}
			if (entityConfig.messageColumnName) {
				esq.addColumn(entityConfig.messageColumnName, "Message");
			}
			var typeColumnName = this._getEntityTypeColumnName(entityConfig.entitySchemaName);
			if (typeColumnName) {
				esq.addColumn(typeColumnName, "EntityTypeColumnValue");
			}
		},

		/**
		 * Applies filters for request.
		 * @protected
		 * @param {BPMSoft.EntitySchemaQuery} esq Query.
		 * @param {Object} entityConfig Config for loading data.
		 * @param {Object} userFilters User filters.
		 */
		_addEsqFilters: function(esq, entityConfig, userFilters) {
			[
				filtersBuilder.buildOwnerFilter(entityConfig, userFilters),
				filtersBuilder.buildPeriodFilter(entityConfig, userFilters),
				filtersBuilder.buildMasterColumnFilter(entityConfig),
				filtersBuilder.buildTypeFilter(entityConfig),
				filtersBuilder.buildCustomFilter(entityConfig),
				filtersBuilder.buildPrimaryColumnFilter(entityConfig),
				filtersBuilder.buildOrderColumnNotEmptyFilter(entityConfig)
			].forEach(function(filter) {
				if (filter) {
					esq.filters.addItem(filter);
				}
			});
		},

		// endregion

		// region Methods: Protected

		/**
		 * @inheritdoc BPMSoft.BaseAjaxTimelineDataProvider#performLoadDataRequest
		 * @override
		 */
		performLoadDataRequest: function(searchResultEsqFilters, config, callback, scope) {
			var batchQuery =
				this._createBatchQueryBySearchResult(searchResultEsqFilters, config.entities, config.filters);
			if (batchQuery.queries.length === 0) {
				Ext.callback(callback, scope);
				return;
			}
			batchQuery.execute(callback, scope);
			return batchQuery.instanceId;
		},

		/**
		 * @inheritdoc BPMSoft.BaseAjaxTimelineDataProvider#onDataLoaded
		 * @override
		 */
		onDataLoaded: function(result, config, callback, scope) {
			Ext.callback(callback, scope, [BPMSoft.deepClone(result)]);
		}

		// endregion

	});
});
